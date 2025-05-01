<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.ConnectionPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.ConnectionTitle = New System.Windows.Forms.Label()
        Me.ButtonSend = New System.Windows.Forms.Button()
        Me.ComboBoxPorts = New System.Windows.Forms.ComboBox()
        Me.ButtonConnect = New System.Windows.Forms.Button()
        Me.ButtonDisconnect = New System.Windows.Forms.Button()
        Me.LabelStatus = New System.Windows.Forms.Label()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.TimerSerial = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TextBoxInput = New System.Windows.Forms.TextBox()
        Me.InputText = New System.Windows.Forms.Label()
        Me.TimeSelection = New System.Windows.Forms.Label()
        Me.ComboBoxTime = New System.Windows.Forms.ComboBox()
        Me.ButtonReset = New System.Windows.Forms.Button()
        Me.WindowHeader = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ConnectionPanel
        '
        Me.ConnectionPanel.BackColor = System.Drawing.Color.White
        Me.ConnectionPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ConnectionPanel.Location = New System.Drawing.Point(0, 0)
        Me.ConnectionPanel.Name = "ConnectionPanel"
        Me.ConnectionPanel.Size = New System.Drawing.Size(1164, 658)
        Me.ConnectionPanel.TabIndex = 0
        '
        'ConnectionTitle
        '
        Me.ConnectionTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ConnectionTitle.AutoSize = True
        Me.ConnectionTitle.BackColor = System.Drawing.Color.White
        Me.ConnectionTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConnectionTitle.ForeColor = System.Drawing.Color.Black
        Me.ConnectionTitle.Location = New System.Drawing.Point(50, 164)
        Me.ConnectionTitle.Name = "ConnectionTitle"
        Me.ConnectionTitle.Size = New System.Drawing.Size(330, 25)
        Me.ConnectionTitle.TabIndex = 0
        Me.ConnectionTitle.Text = "Select port and then hit connect :"
        Me.ConnectionTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonSend
        '
        Me.ButtonSend.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonSend.AutoSize = True
        Me.ButtonSend.BackColor = System.Drawing.Color.Blue
        Me.ButtonSend.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ButtonSend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSend.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSend.ForeColor = System.Drawing.Color.White
        Me.ButtonSend.Location = New System.Drawing.Point(757, 381)
        Me.ButtonSend.Name = "ButtonSend"
        Me.ButtonSend.Size = New System.Drawing.Size(127, 32)
        Me.ButtonSend.TabIndex = 0
        Me.ButtonSend.Text = "Send"
        Me.ButtonSend.UseVisualStyleBackColor = False
        '
        'ComboBoxPorts
        '
        Me.ComboBoxPorts.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ComboBoxPorts.BackColor = System.Drawing.Color.Gray
        Me.ComboBoxPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxPorts.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxPorts.ForeColor = System.Drawing.Color.White
        Me.ComboBoxPorts.FormattingEnabled = True
        Me.ComboBoxPorts.Location = New System.Drawing.Point(388, 164)
        Me.ComboBoxPorts.Name = "ComboBoxPorts"
        Me.ComboBoxPorts.Size = New System.Drawing.Size(129, 28)
        Me.ComboBoxPorts.TabIndex = 0
        '
        'ButtonConnect
        '
        Me.ButtonConnect.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonConnect.AutoSize = True
        Me.ButtonConnect.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.ButtonConnect.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ButtonConnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonConnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonConnect.ForeColor = System.Drawing.Color.White
        Me.ButtonConnect.Location = New System.Drawing.Point(534, 163)
        Me.ButtonConnect.Name = "ButtonConnect"
        Me.ButtonConnect.Size = New System.Drawing.Size(109, 32)
        Me.ButtonConnect.TabIndex = 2
        Me.ButtonConnect.Text = "Connect"
        Me.ButtonConnect.UseVisualStyleBackColor = False
        '
        'ButtonDisconnect
        '
        Me.ButtonDisconnect.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonDisconnect.AutoSize = True
        Me.ButtonDisconnect.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.ButtonDisconnect.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ButtonDisconnect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.ButtonDisconnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.ButtonDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDisconnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDisconnect.ForeColor = System.Drawing.Color.White
        Me.ButtonDisconnect.Location = New System.Drawing.Point(222, 240)
        Me.ButtonDisconnect.Name = "ButtonDisconnect"
        Me.ButtonDisconnect.Size = New System.Drawing.Size(146, 25)
        Me.ButtonDisconnect.TabIndex = 3
        Me.ButtonDisconnect.Text = "Disconnect"
        Me.ButtonDisconnect.UseVisualStyleBackColor = False
        '
        'LabelStatus
        '
        Me.LabelStatus.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelStatus.AutoSize = True
        Me.LabelStatus.BackColor = System.Drawing.Color.White
        Me.LabelStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStatus.ForeColor = System.Drawing.Color.Red
        Me.LabelStatus.Location = New System.Drawing.Point(50, 519)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(186, 24)
        Me.LabelStatus.TabIndex = 4
        Me.LabelStatus.Text = "Status: Disconnected"
        '
        'TextBoxInput
        '
        Me.TextBoxInput.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBoxInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxInput.Location = New System.Drawing.Point(360, 384)
        Me.TextBoxInput.Name = "TextBoxInput"
        Me.TextBoxInput.Size = New System.Drawing.Size(377, 26)
        Me.TextBoxInput.TabIndex = 1
        '
        'InputText
        '
        Me.InputText.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.InputText.AutoSize = True
        Me.InputText.BackColor = System.Drawing.Color.White
        Me.InputText.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InputText.ForeColor = System.Drawing.Color.Black
        Me.InputText.Location = New System.Drawing.Point(21, 384)
        Me.InputText.Margin = New System.Windows.Forms.Padding(0)
        Me.InputText.Name = "InputText"
        Me.InputText.Size = New System.Drawing.Size(329, 25)
        Me.InputText.TabIndex = 5
        Me.InputText.Text = "     Type input and then hit send :"
        Me.InputText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimeSelection
        '
        Me.TimeSelection.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TimeSelection.AutoSize = True
        Me.TimeSelection.BackColor = System.Drawing.Color.White
        Me.TimeSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeSelection.ForeColor = System.Drawing.Color.Black
        Me.TimeSelection.Location = New System.Drawing.Point(50, 252)
        Me.TimeSelection.Name = "TimeSelection"
        Me.TimeSelection.Size = New System.Drawing.Size(724, 25)
        Me.TimeSelection.TabIndex = 6
        Me.TimeSelection.Text = "Select time between letters : (time between letters if typing multiple letters)"
        Me.TimeSelection.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ComboBoxTime
        '
        Me.ComboBoxTime.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ComboBoxTime.BackColor = System.Drawing.Color.Gray
        Me.ComboBoxTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxTime.ForeColor = System.Drawing.Color.White
        Me.ComboBoxTime.FormattingEnabled = True
        Me.ComboBoxTime.Location = New System.Drawing.Point(805, 253)
        Me.ComboBoxTime.Name = "ComboBoxTime"
        Me.ComboBoxTime.Size = New System.Drawing.Size(173, 28)
        Me.ComboBoxTime.TabIndex = 7
        '
        'ButtonReset
        '
        Me.ButtonReset.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ButtonReset.AutoSize = True
        Me.ButtonReset.BackColor = System.Drawing.Color.Red
        Me.ButtonReset.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ButtonReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonReset.ForeColor = System.Drawing.Color.White
        Me.ButtonReset.Location = New System.Drawing.Point(526, 444)
        Me.ButtonReset.Name = "ButtonReset"
        Me.ButtonReset.Size = New System.Drawing.Size(129, 32)
        Me.ButtonReset.TabIndex = 8
        Me.ButtonReset.Text = "Reset Motors"
        Me.ButtonReset.UseVisualStyleBackColor = False
        '
        'WindowHeader
        '
        Me.WindowHeader.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.WindowHeader.AutoSize = True
        Me.WindowHeader.BackColor = System.Drawing.Color.White
        Me.WindowHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WindowHeader.ForeColor = System.Drawing.Color.Black
        Me.WindowHeader.Location = New System.Drawing.Point(442, 30)
        Me.WindowHeader.Name = "WindowHeader"
        Me.WindowHeader.Size = New System.Drawing.Size(366, 37)
        Me.WindowHeader.TabIndex = 9
        Me.WindowHeader.Text = "Braille Learning Device"
        Me.WindowHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1164, 658)
        Me.Controls.Add(Me.WindowHeader)
        Me.Controls.Add(Me.ButtonReset)
        Me.Controls.Add(Me.ComboBoxTime)
        Me.Controls.Add(Me.TimeSelection)
        Me.Controls.Add(Me.InputText)
        Me.Controls.Add(Me.TextBoxInput)
        Me.Controls.Add(Me.LabelStatus)
        Me.Controls.Add(Me.ButtonConnect)
        Me.Controls.Add(Me.ComboBoxPorts)
        Me.Controls.Add(Me.ButtonSend)
        Me.Controls.Add(Me.ConnectionTitle)
        Me.Controls.Add(Me.ConnectionPanel)
        Me.Controls.Add(Me.ButtonDisconnect)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ConnectionPanel As FlowLayoutPanel
    Friend WithEvents ConnectionTitle As Label
    Friend WithEvents ButtonSend As Button
    Friend WithEvents ComboBoxPorts As ComboBox
    Friend WithEvents ButtonConnect As Button
    Friend WithEvents ButtonDisconnect As Button
    Friend WithEvents LabelStatus As Label
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents TimerSerial As Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents TextBoxInput As TextBox
    Friend WithEvents InputText As Label
    Friend WithEvents TimeSelection As Label
    Friend WithEvents ComboBoxTime As ComboBox
    Friend WithEvents ButtonReset As Button
    Friend WithEvents WindowHeader As Label
End Class
