Namespace MYP100JECT.Library.Database
    Public Class ConnectionString
        Private Host As String
        Private Database As String
        Private UserId As String
        Private Password As String

        Public Sub New(Host As String, Database As String, UserId As String, Password As String)
            With Me
                .Host = Host
                .Database = Database
                .UserId = UserId
                .Password = Password
            End With
        End Sub

        Public Function Create() As String
            Return "Data Source=" + Host + "; Initial Catalog=" + Database + ";User ID=" + UserId + ";password=" + Password
        End Function
    End Class
End Namespace
