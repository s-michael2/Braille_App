Imports System.IO.Ports
Imports System.Media ' Required for playing audio

Public Class Form1
    Private WithEvents _serialPort As SerialPort
    Private _isConnected As Boolean = False ' Tracks the connection state

    ' Load available COM ports on form load
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAvailablePorts()
        ButtonSend.Enabled = False ' Disable Send button initially
    End Sub

    Private Sub LoadAvailablePorts()
        Try
            Dim ports As String() = SerialPort.GetPortNames()
            ComboBoxPorts.Items.Clear()
            ComboBoxPorts.Items.AddRange(ports)
            If ports.Length > 0 Then
                ComboBoxPorts.SelectedIndex = 0
            Else
                MessageBox.Show("No COM ports available. Please connect your Arduino and restart the app.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error loading COM ports: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Toggle connect/disconnect
    Private Sub ButtonConnect_Click(sender As Object, e As EventArgs)
        If Not _isConnected Then
            ' Attempt to connect
            If ComboBoxPorts.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a COM port.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Try
                _serialPort = New SerialPort(ComboBoxPorts.SelectedItem.ToString(), 9600) With {
                    .NewLine = vbCrLf
                }
                _serialPort.Open()
                LabelStatus.Text = "Status: Connected"
                LabelStatus.ForeColor = Color.Green
                ButtonConnect.Text = "Disconnect" ' Change button text
                ButtonConnect.BackColor = Color.Red
                ButtonSend.Enabled = True ' Enable Send button
                _isConnected = True ' Update connection state
            Catch ex As UnauthorizedAccessException
                MessageBox.Show("Access to the COM port is denied. Please close any other applications using this port.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show($"Failed to connect: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            ' Attempt to disconnect
            Try
                If _serialPort IsNot Nothing AndAlso _serialPort.IsOpen Then
                    _serialPort.Close()
                    LabelStatus.Text = "Status: Disconnected"
                    LabelStatus.ForeColor = Color.Red
                    ButtonConnect.Text = "Connect" ' Change button text
                    ButtonSend.Enabled = False ' Disable Send button
                    _isConnected = False ' Update connection state
                Else
                    MessageBox.Show("No active connection to disconnect.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show($"Failed to disconnect: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Send input to Arduino and play sound
    Private Sub ButtonSend_Click(sender As Object, e As EventArgs) Handles ButtonSend.Click, ButtonConnect.Click, ButtonConnect.EnabledChanged
        Dim input As String = TextBoxInput.Text.Trim()
        If String.IsNullOrEmpty(input) Then
            MessageBox.Show("Please enter text to send.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        SendCommand(input)
        PlaySound(input) ' Play corresponding sound for the input
    End Sub

    ' Send data to Arduino
    Private Sub SendCommand(command As String)
        Try
            If _serialPort IsNot Nothing AndAlso _serialPort.IsOpen Then
                _serialPort.WriteLine(command)
                LabelStatus.Text = $"Sent: {command}"
            Else
                MessageBox.Show("Not connected to Arduino. Please connect first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Failed to send command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Play sound for the given input
    Private Sub PlaySound(input As String)
        Try
            Dim soundFile As String = $"C:\Users\smich\source\repos\Braille_App_3\Sounds\{input}.wav" ' Assumes sound file is named after the input
            If IO.File.Exists(soundFile) Then
                Dim player As New SoundPlayer(soundFile)
                player.Play()
            Else
                ' Play a default sound if no specific file exists
                Dim defaultSound As String = "Sounds\default.wav"
                If IO.File.Exists(defaultSound) Then
                    Dim player As New SoundPlayer(defaultSound)
                    player.Play()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Failed to play sound: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Close serial port on form closing
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing AndAlso _serialPort.IsOpen Then
            _serialPort.Close()
        End If
    End Sub
End Class