Imports RJCP.IO.Ports ' Using SerialPortStream for serial communication
Imports System.Media ' For sound playback

Public Class Form1
    Private _serialPort As SerialPortStream
    Private _isConnected As Boolean = False ' Tracks the connection state
    Private delayInMilliseconds As Integer = 2000 ' Default to 2 seconds

    ' Load available COM ports on form load
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadAvailablePorts()

        ButtonSend.Enabled = False ' Disable Send button initially
        ' Populate the ComboBox with options
        ComboBoxTime.Items.Add("2 seconds")
        ComboBoxTime.Items.Add("3 seconds")
        ComboBoxTime.Items.Add("5 seconds")
        ComboBoxTime.Items.Add("10 seconds")
        ComboBoxTime.SelectedIndex = 0 ' Set default to "2 seconds"
    End Sub

    ' Load available COM ports
    Private Sub LoadAvailablePorts()
        Try
            ' Use System.IO.Ports.SerialPort to get available COM ports
            Dim ports As String() = System.IO.Ports.SerialPort.GetPortNames()
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

    ' Connect/Disconnect Button
    Private Sub ButtonConnect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click
        If Not _isConnected Then
            ' Connect
            If ComboBoxPorts.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a COM port.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Try
                _serialPort = New SerialPortStream(ComboBoxPorts.SelectedItem.ToString(), 9600)
                _serialPort.Open()
                LabelStatus.Text = "Status: Connected"
                LabelStatus.ForeColor = Color.Green
                ButtonConnect.Text = "Disconnect"
                ButtonConnect.BackColor = Color.PaleVioletRed
                ButtonSend.Enabled = True ' Enable Send button
                _isConnected = True
            Catch ex As Exception
                MessageBox.Show($"Failed to connect: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            ' Disconnect
            Try
                If _serialPort IsNot Nothing AndAlso _serialPort.IsOpen Then
                    _serialPort.Close()
                    LabelStatus.Text = "Status: Disconnected"
                    LabelStatus.ForeColor = Color.Red
                    ButtonConnect.Text = "Connect"
                    ButtonSend.Enabled = False
                    _isConnected = False
                Else
                    MessageBox.Show("No active connection to disconnect.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show($"Failed to disconnect: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Send input to Arduino
    Private Sub ButtonSend_Click(sender As Object, e As EventArgs) Handles ButtonSend.Click
        Dim input As String = TextBoxInput.Text.Trim()
        If String.IsNullOrEmpty(input) Then
            MessageBox.Show("Please enter text to send.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        SendCommand(input)
    End Sub

    ' Send data to Arduino
    Private Sub SendCommand(input As String)
        Try
            For Each character As Char In input
                SendReset() ' Reset the Arduino state

                If _serialPort IsNot Nothing AndAlso _serialPort.IsOpen Then
                    _serialPort.WriteLine(character.ToString()) ' Send character
                    Debug.WriteLine($"Command sent: {character}")

                    WaitForDoneResponse() ' Wait for Arduino's "done"
                    PlaySound(character.ToString()) ' Play sound for the character

                    LabelStatus.Text = $"Sent: {character}" ' Update the UI
                    Application.DoEvents()

                    Threading.Thread.Sleep(delayInMilliseconds) ' Delay between characters
                Else
                    MessageBox.Show("Not connected to Arduino.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show($"Error while sending command: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Wait for "done" response from Arduino
    Private Sub WaitForDoneResponse()
        Try
            If _serialPort IsNot Nothing AndAlso _serialPort.IsOpen Then
                Dim response As String = _serialPort.ReadLine().Trim() ' Read line from Arduino
                Debug.WriteLine($"Response received: {response}")

                If response <> "done" Then
                    Throw New TimeoutException("Invalid response received.")
                End If
            Else
                MessageBox.Show("Serial port is not open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As TimeoutException
            MessageBox.Show($"Timeout while waiting for 'done': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Error while waiting for 'done': {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Reset Arduino state
    Private Sub SendReset()
        Try
            If _serialPort IsNot Nothing AndAlso _serialPort.IsOpen Then
                _serialPort.WriteLine("~ ") ' Send reset command
                WaitForDoneResponse() ' Wait for acknowledgment
                LabelStatus.Text = "Reset triggered"
                Application.DoEvents()
            Else
                MessageBox.Show("Serial port is not open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error while sending reset: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Play sound for a character
    Private Sub PlaySound(input As String)
        Try
            If Char.IsUpper(input(0)) Then
                Dim capitalSound As String = "C:\Users\smich\source\repos\Braille_App_3\Sounds\capital.wav"
                If IO.File.Exists(capitalSound) Then
                    Dim playerC As New SoundPlayer(capitalSound)
                    playerC.PlaySync()
                End If
            End If

            Dim soundFile As String = $"C:\Users\smich\source\repos\Braille_App_3\Sounds\{input.ToLower()}.wav"
            If IO.File.Exists(soundFile) Then
                Dim player As New SoundPlayer(soundFile)
                player.PlaySync()
            End If
        Catch ex As Exception
            MessageBox.Show($"Failed to play sound: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub comboBoxTime_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxTime.SelectedIndexChanged
        Dim selectedTime As String = ComboBoxTime.SelectedItem.ToString()
        delayInMilliseconds = Integer.Parse(selectedTime.Split(" ")(0)) * 1000
    End Sub

    Private Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click
        SendReset() ' Call the SendReset function
        LabelStatus.Text = "Reset triggered" ' Provide user feedback
        Application.DoEvents() ' Refresh the UI immediately
    End Sub

    ' Handle form closing
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If _serialPort IsNot Nothing AndAlso _serialPort.IsOpen Then
            _serialPort.Close()
        End If
    End Sub
End Class