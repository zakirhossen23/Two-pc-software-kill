Imports System.Net.Sockets
Imports System.Text

Public Class FrmUsersActivity
    Private Sub FrmUsersActivity_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SendMessageToServer("kill")
    End Sub
    Sub SendMessageToServer(message As String)
        Using client As New TcpClient(IpTXT.Text, 13000)
            ' Get a client stream for writing.
            Using stream As NetworkStream = client.GetStream()
                ' Send a message to the server.
                Dim msg As Byte() = Encoding.ASCII.GetBytes(message)
                stream.Write(msg, 0, msg.Length)
                Console.WriteLine($"Sent: {message}")

                Dim responseMessage As String = "Server received your message."
                Dim responseBytes As Byte() = Encoding.ASCII.GetBytes(responseMessage)
                stream.Write(responseBytes, 0, responseBytes.Length)
            End Using
        End Using
    End Sub
End Class
