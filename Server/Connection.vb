Imports System.Net.Sockets

Namespace MYP100JECT.Library.Server
    Public Class Connection
        Public Shared Function Check() As Object
            Try
                Dim TcpClient As New TcpClient

                TcpClient.Connect(IPAddress, Port)

                Return True
            Catch ex As Exception
                Return ex
            End Try
        End Function
    End Class
End Namespace


