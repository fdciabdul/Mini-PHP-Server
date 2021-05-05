Imports System.IO
Imports System.Windows.Forms

Public Class Config

    Private output_txt As RichTextBox

    'Constructor which assign a output_box for info reporting
    Public Sub New(ByRef output_txt As RichTextBox)

        InitializeComponent()

        Me.output_txt = output_txt

        'Configure Config UI based on program settings
        If My.Settings.protocol = radio_1.Text Then
            radio_1.Checked = True
            radio_2.Checked = False
        Else
            radio_1.Checked = False
            radio_2.Checked = True
        End If
        path_txt.Text = My.Settings.filePath
        start_txt.Text = My.Settings.startFile
        http_port_txt.Text = My.Settings.httpPortNum
        https_port_txt.Text = My.Settings.httpsPortNum
        If My.Settings.IPauto = True Then
            radio_3.Checked = True
            radio_4.Checked = False
        Else
            radio_3.Checked = False
            radio_4.Checked = True
        End If
        radio_4_txt.Text = My.Settings.IPaddress

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles protocol_lb.Click

    End Sub

    Private Sub port_txt_TextChanged(sender As Object, e As EventArgs) Handles http_port_txt.TextChanged

    End Sub

    'Apply changes made in the Config UI to program settings
    Private Sub Apply_Click(sender As Object, e As EventArgs) Handles apply_btn.Click

        Try

            If (radio_1.Checked = True) And (radio_2.Checked = False) Then
                My.Settings.protocol = radio_1.Text
            ElseIf (radio_2.Checked = True) And (radio_1.Checked = False) Then
                My.Settings.protocol = radio_2.Text
            Else
                Throw New System.Exception("Invalid Protocol")
            End If

            If Convert.ToInt32(http_port_txt.Text) <= 65535 Then
                My.Settings.httpPortNum = Convert.ToInt32(http_port_txt.Text)
            Else
                Throw New System.Exception("Invalid HTTP Port")
            End If

            If Convert.ToInt32(https_port_txt.Text) <= 65535 Then
                My.Settings.httpsPortNum = Convert.ToInt32(https_port_txt.Text)
            Else
                Throw New System.Exception("Invalid HTTPS Port")
            End If

            If Directory.Exists(path_txt.Text) Then
                My.Settings.filePath = path_txt.Text
            Else
                Throw New System.Exception("Invalid Path")
            End If

            If (radio_3.Checked = True) And (radio_4.Checked = False) Then
                My.Settings.IPaddress = ""
                My.Settings.IPauto = True
            ElseIf (radio_4.Checked = True) And (radio_3.Checked = False) Then
                My.Settings.IPaddress = radio_4_txt.Text
                My.Settings.IPauto = False
            Else
                Throw New System.Exception("Invalid Protocol")
            End If

            My.Settings.startFile = start_txt.Text

            output_txt.AppendText(vbNewLine & "INFO: Settings applied, start/restart to take effect")

        Catch ex As Exception

            output_txt.AppendText(vbNewLine & "ERROR: " & ex.Message)

        End Try

    End Sub

    Private Sub Browse_Click(sender As Object, e As EventArgs) Handles browse_btn.Click

        Dim result As DialogResult = browser_box.ShowDialog()

        If (result = DialogResult.OK) Then

            path_txt.Text = browser_box.SelectedPath

        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles radio_1.CheckedChanged

    End Sub

    Private Sub RadioButton1_CheckedChanged_1(sender As Object, e As EventArgs) Handles radio_3.CheckedChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles radio_4_txt.TextChanged

    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles cancel_btn.Click

        Me.Close()

    End Sub

    Private Sub Config_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub browser_box_HelpRequest(sender As Object, e As EventArgs) Handles browser_box.HelpRequest

    End Sub
End Class