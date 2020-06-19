Namespace MYP100JECT.Library
    Public Class Session
        Private Shared Session As New Dictionary(Of String, String)

        Public Shared Function [Get](Name As String) As String
            Try
                Return Session(Name)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Sub [Set](Name As String, Value As String)
            [Set](Name, Value, False)
        End Sub

        Public Shared Sub [Set](Name As String, Value As String, Replace As Boolean)
            If Replace = True Then
                Remove(Name)
            End If

            Session.Add(Name, Value)
        End Sub

        Public Shared Sub Remove(Name As String)
            If Session.ContainsKey(Name) Then
                Session.Remove(Name)
            End If
        End Sub

        Public Shared Sub Clear()
            Session.Clear()
        End Sub
    End Class
End Namespace