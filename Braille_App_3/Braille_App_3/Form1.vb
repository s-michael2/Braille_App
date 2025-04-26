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
    Private Sub ButtonConnect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click
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
    Private Sub ButtonSend_Click(sender As Object, e As EventArgs) Handles ButtonSend.Click
        Dim input As String = TextBoxInput.Text.Trim()
        If String.IsNullOrEmpty(input) Then
            MessageBox.Show("Please enter text to send.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        SendCommand(input)
        PlaySound(input) ' Play corresponding sound for the input
    End Sub

    ' Send data to Arduino
    ' Send data for each character and update status dynamically
    Private Sub SendCommand(input As String)
        Try
            ' Iterate through each character in the input string
            For Each character As Char In input
                ' Ensure serial port is open before sending
                If _serialPort IsNot Nothing AndAlso _serialPort.IsOpen Then
                    _serialPort.WriteLine(character.ToString()) ' Send the character to Arduino
                    LabelStatus.Text = $"Sent: {character}" ' Update status for each character
                    Application.DoEvents() ' Refresh UI immediately to reflect changes
                    'System.Threading.Thread.Sleep(500) ' Optional delay for each character

                Else
                    MessageBox.Show("Not connected to Arduino. Please connect first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit For ' Stop processing if disconnected
                End If
            Next
        Catch ex As Exception
            MessageBox.Show($"Failed to send command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Play sound for each character in the input string with a delay and special handling for capital letters
    Private Sub PlaySound(input As String)
        Try
            ' Iterate through each character in the input string
            For Each character As Char In input
                ' Add a delay before starting the audio
                System.Threading.Thread.Sleep(1500) ' 1500 milliseconds delay

                ' Play a special sound if the character is a capital letter
                If Char.IsUpper(character) Then
                    Dim capitalSound As String = "C:\Users\smich\source\repos\Braille_App_3\Sounds\capital.wav"
                    If IO.File.Exists(capitalSound) Then
                        Dim player As New SoundPlayer(capitalSound)
                        player.Play() ' Play synchronously to ensure order
                    End If
                End If

                ' Play sound for the individual character
                Dim soundFile As String = $"C:\Users\smich\source\repos\Braille_App_3\Sounds\{Char.ToLower(character)}.wav" ' Convert to lowercase for file naming
                If IO.File.Exists(soundFile) Then
                    Dim player As New SoundPlayer(soundFile)
                    player.PlaySync() ' Play synchronously to ensure order
                Else
                    ' Play a default sound if no specific file exists
                    Dim defaultSound As String = "C:\Users\smich\source\repos\Braille_App_3\Sounds\default.wav"
                    If IO.File.Exists(defaultSound) Then
                        Dim player As New SoundPlayer(defaultSound)
                        player.Play() ' Play synchronously to ensure order
                    End If
                End If
            Next
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