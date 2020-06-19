Namespace MYP100JECT.Library
    Public Class FTP
        Private IPAddress As String
        Private Username As String
        Private Password As String

        Public Sub New(IPAddress As String, Username As String, Password As String)
            With Me
                .IPAddress = IPAddress
                .Username = Username
                .Password = Password
            End With
        End Sub

        Public Function GetFile(SourcePath As String, SavePath As String) As Object
            Try
                My.Computer.Network.DownloadFile("ftp://" + IPAddress + "/" + SourcePath, SavePath, Username, Password)

                Return True
            Catch ex As Exception
                Return ex
            End Try
        End Function
    End Class
End Namespace
