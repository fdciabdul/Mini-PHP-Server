Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices

Public Class WebServer
    Inherits WindowsFormsApplicationBase

    'Variable declaration
    Private allowLoop As Boolean = False
    Private output_txt As System.Windows.Forms.RichTextBox
    Private listener As HttpListener
    Private LocalAddress As IPAddress
    Private ThreadHandler As Thread
    Private WebThread As Thread
    Private txttmpLocFile As String
    Private sWebserverRoot As String
    Private sStartupPath As String
    Private portNum As Int32

    'Constructor which assign a output_box for info reporting
    Public Sub New(output As System.Windows.Forms.RichTextBox, appPath As String)

        output_txt = output
        sStartupPath = appPath

    End Sub

    'Gets IP address from host
    Private Function GetIPAddress() As IPAddress

        Dim strHostName As String

        Dim strIPAddress As IPAddress

        strHostName = System.Net.Dns.GetHostName()

        strIPAddress = System.Net.Dns.GetHostEntry(strHostName).AddressList(0)

        Return strIPAddress

    End Function

    'Starts the webserver
    Public Sub StartWebServer()

        'Assigns enviroment settings
        sWebserverRoot = My.Settings.filePath

        If My.Settings.protocol = "HTTP" Then
            portNum = My.Settings.httpPortNum
        Else
            portNum = My.Settings.httpsPortNum
        End If

        'Obtains IP
        If My.Settings.IPauto = False Then
            LocalAddress = IPAddress.Parse(My.Settings.IPaddress)
        Else
            LocalAddress = GetIPAddress()
        End If

        allowLoop = True

        'Starts httplistener and ThreadHandler thread
        Try

            output_txt.AppendText(vbNewLine & "INFO: Starting Server...")
            listener = New HttpListener()
            listener.Prefixes.Add(My.Settings.protocol & "://*:" & portNum & "/")
            output_txt.AppendText(vbNewLine & "INFO: Listener created")
            listener.Start()
            output_txt.AppendText(vbNewLine & "INFO: Listening on " & My.Settings.protocol & "://*:" & portNum & "/")
            ThreadHandler = New Thread(AddressOf ThreadLoopHandler)
            output_txt.AppendText(vbNewLine & "INFO: Threadhandler created")
            ThreadHandler.Start()
            output_txt.AppendText(vbNewLine & "INFO: Threadhandler started")

            output_txt.AppendText(vbNewLine & "INFO: Webserver started successfully")

        Catch ex As Exception

            output_txt.AppendText(vbNewLine & "ERROR: " & ex.Message)

        End Try

    End Sub

    'Stops the webserver
    Public Sub StopWebServer()

        allowLoop = False

        Try

            output_txt.AppendText(vbNewLine & "INFO: Stoppping Server...")

            'Terminates ThreadHandler thread
            If ThreadHandler IsNot Nothing Then

                If ThreadHandler.IsAlive Then

                    ThreadHandler.Abort()

                End If

                ThreadHandler = Nothing
                output_txt.AppendText(vbNewLine & "INFO: Threadhandler aborted")

            End If

            'Terminates WebThread thread
            If WebThread IsNot Nothing Then

                If WebThread.IsAlive Then

                    WebThread.Abort()

                End If

                WebThread = Nothing
                output_txt.AppendText(vbNewLine & "INFO: WebThread aborted")

            End If

            'Terminates listener
            If listener IsNot Nothing Then

                If listener.IsListening Then

                    listener.Abort()

                End If

                listener = Nothing
                output_txt.AppendText(vbNewLine & "INFO: Listener aborted")

            End If

        Catch ex As Exception

            output_txt.AppendText(vbNewLine & "ERROR: " & ex.Message)

        End Try

    End Sub


    'Thread that handles ProcessRequest threads for http requests
    Private Sub ThreadLoopHandler()

        While allowLoop = True

            Try

                Dim ctx As HttpListenerContext = listener.GetContext()
                WebThread = New Thread(AddressOf ProcessRequest)
                WebThread.Start(ctx)

            Catch ex As Exception

            End Try

        End While

    End Sub


    'Processes HTTP requests
    Public Sub ProcessRequest(ByVal data As HttpListenerContext)

        Try

            Dim outPutContent As String = ""
            Dim sCurrentIndex As String
            Dim fileName As String
            sCurrentIndex = sWebserverRoot

            Dim urlRequest As String = data.Request.RawUrl

            'Defines file path and file name from urlRequest
            If urlRequest = "/" Then

                If (File.Exists(sCurrentIndex & "/" & My.Settings.startFile)) Then

                    sCurrentIndex = sWebserverRoot & "\" & My.Settings.startFile
                    fileName = My.Settings.startFile

                Else

                    Throw New Exception("File not found...")

                End If

            Else

                fileName = urlRequest.Substring(urlRequest.LastIndexOf("/") + 1)

                If fileName.Contains("?") Then

                    fileName = fileName.Replace(fileName.Substring(fileName.IndexOf("?")), "")

                End If

                sCurrentIndex = sWebserverRoot & "\" & fileName
                sCurrentIndex.Replace("/", "\")

            End If

            If fileName.Substring(fileName.IndexOf(".")) = ".php" Then

                'Reads script to outPutContent with php processing

                Try

                    'Declares new process
                    Dim CGIprocess As New System.Diagnostics.Process()

                    Dim params As String = ""

                    'Adds Query Strings to argument params if present
                    If data.Request.QueryString.HasKeys Then


                        For Each key In data.Request.QueryString.AllKeys

                            params = params & key & "=" & data.Request.QueryString.Get(key) & " "

                        Next

                    End If

                    'Setup of CGI envorment variables
                    CGIprocess.StartInfo.FileName = My.Settings.phpFilePath
                    CGIprocess.StartInfo.Arguments = " -q " & """" & sCurrentIndex & """"
                    CGIprocess.StartInfo.UseShellExecute = False
                    CGIprocess.StartInfo.RedirectStandardOutput = True
                    CGIprocess.StartInfo.StandardOutputEncoding = Encoding.UTF8
                    CGIprocess.StartInfo.RedirectStandardInput = True
                    CGIprocess.StartInfo.CreateNoWindow = True
                    CGIprocess.StartInfo.EnvironmentVariables.Add("REDIRECT_STATUS", "200")
                    CGIprocess.StartInfo.EnvironmentVariables.Add("SCRIPT_NAME", fileName)
                    CGIprocess.StartInfo.EnvironmentVariables.Add("SCRIPT_FILENAME", sCurrentIndex)
                    CGIprocess.StartInfo.EnvironmentVariables.Add("SERVER_INTERFACE", "CGI/1.1")
                    CGIprocess.StartInfo.EnvironmentVariables.Add("GETWAY_INTERFACE", "CGI/1.1")
                    CGIprocess.StartInfo.EnvironmentVariables.Add("SERVER_PROTOCOL", "HTTP/1.1")
                    CGIprocess.StartInfo.EnvironmentVariables.Add("REQUEST_URI", urlRequest)
                    CGIprocess.StartInfo.EnvironmentVariables.Add("SERVER_PORT", portNum)
                    CGIprocess.StartInfo.EnvironmentVariables.Add("REQUEST_METHOD", data.Request.HttpMethod)
                    CGIprocess.StartInfo.EnvironmentVariables.Add("CONTENT_TYPE", data.Request.ContentType)
                    CGIprocess.StartInfo.EnvironmentVariables.Add("CONTENT_LENGTH", data.Request.ContentLength64)
                    CGIprocess.StartInfo.EnvironmentVariables.Add("QUERY_STRING", params)

                    'Starts the PHP-CGI process
                    CGIprocess.Start()

                    'Writes data to php://stdin if POST method
                    If data.Request.HttpMethod = "POST" Then

                        Dim str As String = New StreamReader(data.Request.InputStream).ReadToEnd()
                        CGIprocess.StandardInput.WriteLine(str)
                        CGIprocess.StandardInput.Close()

                    End If

                    'Gets output from CGIProcess
                    outPutContent = CGIprocess.StandardOutput.ReadToEnd()

                    If outPutContent.IndexOf("<") >= 0 Then

                        outPutContent = outPutContent.Substring(outPutContent.IndexOf("<"))

                    End If

                    'Terminates Process
                    CGIprocess.WaitForExit()
                    CGIprocess.Close()


                Catch ex As Exception

                    outPutContent = "An error occured: " & ex.Message

                End Try


            Else

                'Reads script to outPutContent without php processing

                Dim fs As FileStream = New FileStream(sCurrentIndex, FileMode.Open, FileAccess.Read, FileShare.Read)

                Using textReader As New System.IO.StreamReader(fs)

                    outPutContent = textReader.ReadToEnd

                End Using

                Debug.WriteLine("FileRead: " & outPutContent)


            End If

            'Sends response back to client
            SendHeader("1.1", GetMimeType(fileName), outPutContent.Length, " 200 OK", data)
            SendToBrowser(outPutContent, data)

        Catch ex As Exception

            Dim sErrorMessage = "404 Error! File Does Not Exists..."
            SendHeader("1.1", "text/html", sErrorMessage.Length, " 404 ERROR", data)
            SendToBrowser(sErrorMessage, data)

        End Try

    End Sub

    'Determines operational status of the Webserver as bool
    Public Function Status() As Boolean

        If ThreadHandler IsNot Nothing Then
            If ThreadHandler.IsAlive = True Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function

    'Sends http header data to client
    Public Sub SendHeader(ByVal sHttpVersion As String, ByVal sMimeHeader As String, ByVal iTotalBytes As Integer, ByVal sStatusCode As String, ByRef httpContext As HttpListenerContext)

        If Len(sMimeHeader) = 0 Then
            sMimeHeader = "text/html"
        End If

        httpContext.Response.ProtocolVersion = Version.Parse(1.1)
        httpContext.Response.StatusCode = 200
        httpContext.Response.StatusDescription = "OK"
        httpContext.Response.AddHeader("Server", "MiniWebServer")
        httpContext.Response.AddHeader("Content-Type", sMimeHeader)
        httpContext.Response.AddHeader("Accept-Ranges", "bytes")
        httpContext.Response.AddHeader("Content-Length", iTotalBytes)

    End Sub

    'Encodes http body data before sending to client
    Public Overloads Sub SendToBrowser(ByVal sData As String, ByRef httpContext As HttpListenerContext)

        SendToBrowser(Encoding.ASCII.GetBytes(sData), httpContext)

    End Sub

    'Sends http body data to client
    Public Overloads Sub SendToBrowser(ByVal bSendData As [Byte](), ByRef httpContext As HttpListenerContext)

        Try

            Dim iNumBytes As Integer = 0

            httpContext.Response.ContentLength64 = bSendData.Length
            httpContext.Response.OutputStream.Write(bSendData, 0, bSendData.Length)
            httpContext.Response.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Function GetMimeType(ByVal fileName As String) As String

        Dim fileExt As String = fileName.Substring(fileName.IndexOf(".") + 1)

        Select Case fileExt
            Case "txt"
                Return "text/txt"
                Exit Select
            Case "html"
                Return "text/html"
                Exit Select
            Case "htm"
                Return "text/htm"
                Exit Select
            Case "php"
                Return "text/html"
                Exit Select
            Case "jpeg"
                Return "image/jpeg"
                Exit Select
            Case "jpg"
                Return "image/jpg"
                Exit Select
            Case "png"
                Return "image/png"
                Exit Select
            Case "gif"
                Return "image/gif"
                Exit Select
            Case "wave"
                Return "audio/wave"
                Exit Select
            Case "wav"
                Return "audio/wav"
                Exit Select
            Case "ogg"
                Return "audio/ogg"
                Exit Select
            Case "mp3"
                Return "audio/mp3"
                Exit Select
            Case "mp4"
                Return "audio/mp4"
                Exit Select
        End Select

        Return "text/html"

    End Function

End Class
