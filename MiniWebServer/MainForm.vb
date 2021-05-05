Imports System.Windows.Forms

Public Class MainForm

    Public wbsrv As WebServer
    Public str As String
    Public count As Integer
    'Entry point
    Private Sub MyMainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        output_txt.AppendText("")
        count = 1
        str = ":D test 12345678910"
        Timer1.Enabled = True
        output_txt.AppendText("INFO: PHP Server " & My.Settings.version)
        Threading.Thread.Sleep(5000)
        output_txt.AppendText(vbNewLine & "Created by @fdciabdul")

        'Initalize webserver
        wbsrv = New WebServer(output_txt, Application.StartupPath())

        output_txt.AppendText(vbNewLine & "INFO: Server Ready")

    End Sub

    Private Sub Start_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Restart_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Stop_Click(sender As Object, e As EventArgs)

    End Sub

    'Enables minimizing window to tray icon
    Private Sub MyMainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        If Me.WindowState = FormWindowState.Minimized Then
            tray_icon.Visible = True
            Me.Hide()

        End If

    End Sub

    'Enables opening window from tray icon
    Private Sub Tray_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tray_icon.DoubleClick

        Me.Show()
        Me.WindowState = FormWindowState.Normal
        tray_icon.Visible = False

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        wbsrv.StopWebServer()

    End Sub

    Private Sub Start_Menu_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

        Start_Click(Nothing, Nothing)

    End Sub

    Private Sub Stop_Menu_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click

        Stop_Click(Nothing, Nothing)

    End Sub

    Private Sub Exit_Menu_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click

        output_txt.AppendText(vbNewLine & "INFO: Exiting...")
        Application.Exit()

    End Sub

    Private Sub ConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigToolStripMenuItem.Click

        Dim configform As Form = New Config(Me.output_txt)
        configform.Show()

    End Sub

    Private Sub SSLSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SSLSettingsToolStripMenuItem.Click

        Dim sslform As Form = New SSLSettings
        sslform.Show()

    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click

        Start_Click(Nothing, Nothing)

    End Sub

    Private Sub StopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopToolStripMenuItem.Click

        Stop_Click(Nothing, Nothing)

    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click

        Restart_Click(Nothing, Nothing)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        output_txt.AppendText(vbNewLine & "INFO: Exiting...")
        Application.Exit()

    End Sub

    'Textchanged handler to enable auto scrolling of the output box
    Private Sub output_txt_change(sender As Object, e As EventArgs) Handles output_txt.TextChanged

        output_txt.SelectionStart = output_txt.Text.Length
        output_txt.ScrollToCaret()

    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        If wbsrv.Status() = True Then

            wbsrv.StopWebServer()
            output_txt.AppendText(vbNewLine & "INFO: Webserver stopped")

        ElseIf wbsrv.Status() = False Then

            output_txt.AppendText(vbNewLine & "WARNING: Webserver already stopped")

        Else

            output_txt.AppendText(vbNewLine & "ERROR: Webserver failed to stop")

        End If

    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click

        Stop_Click(Nothing, Nothing)

        Start_Click(Nothing, Nothing)

        If wbsrv.Status() = True Then

            output_txt.AppendText(vbNewLine & "INFO: Webserver started/restarted")

        Else

            output_txt.AppendText(vbNewLine & "ERROR: Webserver failed to restart")

        End If
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click

        If (My.Settings.filePath = "") Or (My.Settings.startFile = "") Or (My.Settings.httpPortNum = Nothing) Or (My.Settings.httpsPortNum = Nothing) Then

            output_txt.AppendText(vbNewLine & "WARNING: Webserver failed to start. Config missing values")

        ElseIf wbsrv.Status() = False Then

            wbsrv.StartWebServer()

        ElseIf wbsrv.Status() = True Then

            output_txt.AppendText(vbNewLine & "WARNING: Webserver failed to start. Server is already running")

        Else

            output_txt.AppendText(vbNewLine & "ERROR: Webserver failed to start")

        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        about.Show()

    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2PictureBox1_Click(sender As Object, e As EventArgs) Handles Guna2PictureBox1.Click

    End Sub
End Class
