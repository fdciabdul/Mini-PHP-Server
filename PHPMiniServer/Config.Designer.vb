<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Config
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Config))
        Me.radio_1 = New System.Windows.Forms.RadioButton()
        Me.protocol_lb = New System.Windows.Forms.Label()
        Me.port_lb = New System.Windows.Forms.Label()
        Me.http_port_txt = New System.Windows.Forms.TextBox()
        Me.browse_btn = New System.Windows.Forms.Button()
        Me.path_lb = New System.Windows.Forms.Label()
        Me.path_txt = New System.Windows.Forms.TextBox()
        Me.apply_btn = New System.Windows.Forms.Button()
        Me.radio_2 = New System.Windows.Forms.RadioButton()
        Me.ip_lb = New System.Windows.Forms.Label()
        Me.radio_3 = New System.Windows.Forms.RadioButton()
        Me.radio_4 = New System.Windows.Forms.RadioButton()
        Me.radio_4_txt = New System.Windows.Forms.TextBox()
        Me.cancel_btn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.browser_box = New System.Windows.Forms.FolderBrowserDialog()
        Me.radio_1_2 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.https_port_txt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.start_txt = New System.Windows.Forms.TextBox()
        Me.Guna2BorderlessForm1 = New Guna.UI2.WinForms.Guna2BorderlessForm(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'radio_1
        '
        Me.radio_1.AutoSize = True
        Me.radio_1.Checked = True
        Me.radio_1.Location = New System.Drawing.Point(12, 27)
        Me.radio_1.Name = "radio_1"
        Me.radio_1.Size = New System.Drawing.Size(54, 17)
        Me.radio_1.TabIndex = 0
        Me.radio_1.TabStop = True
        Me.radio_1.Text = "HTTP"
        Me.radio_1.UseVisualStyleBackColor = True
        '
        'protocol_lb
        '
        Me.protocol_lb.AutoSize = True
        Me.protocol_lb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.protocol_lb.Location = New System.Drawing.Point(9, 9)
        Me.protocol_lb.Name = "protocol_lb"
        Me.protocol_lb.Size = New System.Drawing.Size(93, 13)
        Me.protocol_lb.TabIndex = 1
        Me.protocol_lb.Text = "Protocol Mode:"
        '
        'port_lb
        '
        Me.port_lb.AutoSize = True
        Me.port_lb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.port_lb.Location = New System.Drawing.Point(9, 191)
        Me.port_lb.Name = "port_lb"
        Me.port_lb.Size = New System.Drawing.Size(83, 13)
        Me.port_lb.TabIndex = 15
        Me.port_lb.Text = "HTTP Port #:"
        '
        'http_port_txt
        '
        Me.http_port_txt.Location = New System.Drawing.Point(96, 188)
        Me.http_port_txt.Name = "http_port_txt"
        Me.http_port_txt.Size = New System.Drawing.Size(57, 20)
        Me.http_port_txt.TabIndex = 14
        '
        'browse_btn
        '
        Me.browse_btn.Location = New System.Drawing.Point(12, 98)
        Me.browse_btn.Name = "browse_btn"
        Me.browse_btn.Size = New System.Drawing.Size(103, 20)
        Me.browse_btn.TabIndex = 13
        Me.browse_btn.Text = "Browse File Path"
        Me.browse_btn.UseVisualStyleBackColor = True
        '
        'path_lb
        '
        Me.path_lb.AutoSize = True
        Me.path_lb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.path_lb.Location = New System.Drawing.Point(9, 55)
        Me.path_lb.Name = "path_lb"
        Me.path_lb.Size = New System.Drawing.Size(187, 13)
        Me.path_lb.TabIndex = 12
        Me.path_lb.Text = "Path to Webserver Root Folder:"
        '
        'path_txt
        '
        Me.path_txt.Location = New System.Drawing.Point(12, 73)
        Me.path_txt.Name = "path_txt"
        Me.path_txt.Size = New System.Drawing.Size(307, 20)
        Me.path_txt.TabIndex = 11
        '
        'apply_btn
        '
        Me.apply_btn.Location = New System.Drawing.Point(145, 81)
        Me.apply_btn.Name = "apply_btn"
        Me.apply_btn.Size = New System.Drawing.Size(103, 23)
        Me.apply_btn.TabIndex = 10
        Me.apply_btn.Text = "Apply Changes"
        Me.apply_btn.UseVisualStyleBackColor = True
        '
        'radio_2
        '
        Me.radio_2.AutoSize = True
        Me.radio_2.Location = New System.Drawing.Point(69, 27)
        Me.radio_2.Name = "radio_2"
        Me.radio_2.Size = New System.Drawing.Size(61, 17)
        Me.radio_2.TabIndex = 16
        Me.radio_2.Text = "HTTPS"
        Me.radio_2.UseVisualStyleBackColor = True
        '
        'ip_lb
        '
        Me.ip_lb.AutoSize = True
        Me.ip_lb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ip_lb.Location = New System.Drawing.Point(9, 15)
        Me.ip_lb.Name = "ip_lb"
        Me.ip_lb.Size = New System.Drawing.Size(72, 13)
        Me.ip_lb.TabIndex = 17
        Me.ip_lb.Text = "IP Address:"
        '
        'radio_3
        '
        Me.radio_3.AutoSize = True
        Me.radio_3.Checked = True
        Me.radio_3.Location = New System.Drawing.Point(12, 33)
        Me.radio_3.Name = "radio_3"
        Me.radio_3.Size = New System.Drawing.Size(72, 17)
        Me.radio_3.TabIndex = 18
        Me.radio_3.TabStop = True
        Me.radio_3.Text = "Automatic"
        Me.radio_3.UseVisualStyleBackColor = True
        '
        'radio_4
        '
        Me.radio_4.AutoSize = True
        Me.radio_4.Location = New System.Drawing.Point(12, 56)
        Me.radio_4.Name = "radio_4"
        Me.radio_4.Size = New System.Drawing.Size(14, 13)
        Me.radio_4.TabIndex = 19
        Me.radio_4.UseVisualStyleBackColor = True
        '
        'radio_4_txt
        '
        Me.radio_4_txt.Location = New System.Drawing.Point(32, 53)
        Me.radio_4_txt.Name = "radio_4_txt"
        Me.radio_4_txt.Size = New System.Drawing.Size(160, 20)
        Me.radio_4_txt.TabIndex = 20
        '
        'cancel_btn
        '
        Me.cancel_btn.Location = New System.Drawing.Point(253, 81)
        Me.cancel_btn.Name = "cancel_btn"
        Me.cancel_btn.Size = New System.Drawing.Size(75, 23)
        Me.cancel_btn.TabIndex = 21
        Me.cancel_btn.Text = "Cancel"
        Me.cancel_btn.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.apply_btn)
        Me.GroupBox1.Controls.Add(Me.radio_4_txt)
        Me.GroupBox1.Controls.Add(Me.cancel_btn)
        Me.GroupBox1.Controls.Add(Me.radio_4)
        Me.GroupBox1.Controls.Add(Me.ip_lb)
        Me.GroupBox1.Controls.Add(Me.radio_3)
        Me.GroupBox1.Location = New System.Drawing.Point(-1, 211)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 112)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'browser_box
        '
        '
        'radio_1_2
        '
        Me.radio_1_2.AutoCheck = False
        Me.radio_1_2.AutoSize = True
        Me.radio_1_2.Enabled = False
        Me.radio_1_2.Location = New System.Drawing.Point(136, 27)
        Me.radio_1_2.Name = "radio_1_2"
        Me.radio_1_2.Size = New System.Drawing.Size(95, 17)
        Me.radio_1_2.TabIndex = 23
        Me.radio_1_2.Text = "HTTP/HTTPS"
        Me.radio_1_2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(163, 191)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "HTTPS Port #:"
        '
        'https_port_txt
        '
        Me.https_port_txt.Location = New System.Drawing.Point(258, 188)
        Me.https_port_txt.Name = "https_port_txt"
        Me.https_port_txt.Size = New System.Drawing.Size(57, 20)
        Me.https_port_txt.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Deafult start file:"
        '
        'start_txt
        '
        Me.start_txt.Location = New System.Drawing.Point(12, 150)
        Me.start_txt.Name = "start_txt"
        Me.start_txt.Size = New System.Drawing.Size(118, 20)
        Me.start_txt.TabIndex = 27
        Me.start_txt.Text = "index.php"
        '
        'Guna2BorderlessForm1
        '
        Me.Guna2BorderlessForm1.ContainerControl = Me
        '
        'Config
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(331, 321)
        Me.Controls.Add(Me.start_txt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.https_port_txt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.radio_1_2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.radio_2)
        Me.Controls.Add(Me.port_lb)
        Me.Controls.Add(Me.http_port_txt)
        Me.Controls.Add(Me.browse_btn)
        Me.Controls.Add(Me.path_lb)
        Me.Controls.Add(Me.path_txt)
        Me.Controls.Add(Me.protocol_lb)
        Me.Controls.Add(Me.radio_1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Config"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Config"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents radio_1 As System.Windows.Forms.RadioButton
    Friend WithEvents protocol_lb As System.Windows.Forms.Label
    Friend WithEvents port_lb As System.Windows.Forms.Label
    Friend WithEvents http_port_txt As System.Windows.Forms.TextBox
    Friend WithEvents browse_btn As System.Windows.Forms.Button
    Friend WithEvents path_lb As System.Windows.Forms.Label
    Friend WithEvents path_txt As System.Windows.Forms.TextBox
    Friend WithEvents apply_btn As System.Windows.Forms.Button
    Friend WithEvents radio_2 As System.Windows.Forms.RadioButton
    Friend WithEvents ip_lb As System.Windows.Forms.Label
    Friend WithEvents radio_3 As System.Windows.Forms.RadioButton
    Friend WithEvents radio_4 As System.Windows.Forms.RadioButton
    Friend WithEvents radio_4_txt As System.Windows.Forms.TextBox
    Friend WithEvents cancel_btn As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents browser_box As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents radio_1_2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents https_port_txt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents start_txt As System.Windows.Forms.TextBox
    Friend WithEvents Guna2BorderlessForm1 As Guna.UI2.WinForms.Guna2BorderlessForm
End Class
