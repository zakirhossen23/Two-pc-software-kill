Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.Sockets
Imports System.Text

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
    End Sub
    Dim server As TcpListener = Nothing
    Dim backgroundWorker As BackgroundWorker
    Dim port As Integer = 13000
    Sub StartServer()
        backgroundWorker = New BackgroundWorker()
        AddHandler backgroundWorker.DoWork, AddressOf ServerWorker
        AddHandler backgroundWorker.RunWorkerCompleted, AddressOf ServerWorkerCompleted
        backgroundWorker.WorkerSupportsCancellation = True

        ' Start the background worker
        backgroundWorker.RunWorkerAsync()

    End Sub
    Sub StopServer()
        backgroundWorker.CancelAsync()
        If server IsNot Nothing Then
            server.Stop()
        End If
        StatusLbl.Text = ""

    End Sub
    Sub ServerWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        ' Clean up resources, if needed, after the background worker completes
        If server IsNot Nothing Then
            server.Stop()
        End If
    End Sub


    Sub OpenPortInFirewall(portNumber As Integer, type As String)
        Try
            ' Use the Netsh command to add a firewall rule for the specified port
            Dim netshCommand As String = $"netsh advfirewall firewall add rule name=""OpenPort{portNumber}"" dir={type} action=allow protocol=TCP localport={portNumber}"
            Dim processInfo As New ProcessStartInfo("cmd.exe", "/c " & netshCommand)
            processInfo.RedirectStandardOutput = True
            processInfo.UseShellExecute = False
            processInfo.CreateNoWindow = True

            Dim process As New Process()
            process.StartInfo = processInfo
            process.Start()
            Using reader As StreamReader = process.StandardOutput
                Dim output = reader.ReadToEnd()
                Console.WriteLine(output)
            End Using


            process.WaitForExit()
        Catch ex As Exception
            Console.WriteLine($"Error opening port: {ex.Message}")
        End Try
    End Sub
    Sub ServerWorker()
        Try
            ' Set the TcpListener on port 13000.
            Dim publicIp = IPlbl.Text
            Dim localAddr As IPAddress = IPAddress.Parse("127.0.0.1")

            ' TcpListener server = new TcpListener(port);
            server = New TcpListener(localAddr, port)

            ' Start listening for client requests.
            server.Start()
            StatusLbl.Text = "Started!"
            ' Buffer for reading data
            Dim bytes(256) As Byte
            Dim data As String = Nothing

            ' Enter the listening loop.
            While Not backgroundWorker.CancellationPending
                Console.Write("Waiting for a connection... ")

                ' Perform a blocking call to accept requests.
                Dim client As TcpClient = server.AcceptTcpClient()
                StatusLbl.Text = "Recieved!"

                data = Nothing

                ' Get a stream object for reading and writing
                Dim stream As NetworkStream = client.GetStream()

                Dim i As Integer

                ' Loop to receive all the data sent by the client.
                While (InlineAssignHelper(i, stream.Read(bytes, 0, bytes.Length))) <> 0
                    ' Translate data bytes to an ASCII string.
                    data = Encoding.ASCII.GetString(bytes, 0, i)
                    Console.WriteLine($"Received: {data}")

                    ' Process the data sent by the client.
                    data = data.ToUpper()

                    If (data.Contains("KILL")) Then
                        Application.Exit()
                    End If
                    Dim msg As Byte() = Encoding.ASCII.GetBytes(data)

                    ' Send back a response.
                    stream.Write(msg, 0, msg.Length)
                    Console.WriteLine($"Sent: {data}")
                End While

                ' Shutdown and end connection
                client.Close()
            End While
        Catch e As SocketException
            Console.WriteLine($"SocketException: {e}")
        Finally
            ' Stop listening for new clients.
            server.Stop()
        End Try

        Console.WriteLine("Server closing...")
    End Sub

    ' Helper function to simplify inline assignment
    Private Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function
    Sub LoadData()
        Try
            Dim publicIp As String = GetPublicIp().Result
            IPlbl.Text = publicIp
            OpenPortInFirewall(port, "in")
            OpenPortInFirewall(port, "out")
            StartServer()
        Catch ex As Exception
            Console.WriteLine($"Error: {ex.Message}")
        End Try
    End Sub
    Async Function GetPublicIp() As Task(Of String)
        Using client As New WebClient()
            Dim response As String = client.DownloadString("https://httpbin.org/ip")

            ' Parse the JSON response to get the public IP address
            ' Note: In a production scenario, you would use a JSON parsing library.
            Dim startIndex As Integer = response.IndexOf("""origin"":") + """origin"":".Length
            Dim endIndex As Integer = response.IndexOf("}", startIndex)
            Dim publicIp As String = response.Substring(startIndex, endIndex - startIndex - 1).Trim(" "c, """"c)

            Return publicIp
        End Using
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadData()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        StopServer()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim newFrm As New FrmUsersActivity
        newFrm.ShowDialog()
    End Sub
End Class