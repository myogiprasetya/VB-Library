Imports System.IO
Imports System.Text

Namespace MYP100JECT.Library
    Public Class File
        Public Shared Function Find(FileName As String) As String
            Return Find(Path.GetDirectoryName(Application.ExecutablePath), FileName)
        End Function

        Public Shared Function Find(Directory As String, FileName As String) As String
            Try
                Dim ListFile() As String = New DirectoryInfo(Directory).GetFiles(FileName + "*").OrderByDescending(Function(X) X.LastWriteTime).Select(Function(X) X.FullName).Take(1).ToArray()

                If ListFile.Length > 0 Then
                    Return ListFile(0)
                Else
                    Return "File Not Found"
                End If
            Catch ex As Exception
                Return "File Not Found"
            End Try
        End Function

        Public Shared Sub Create(FileName As String, TextFill As String(), Replace As Boolean)
            Create(Path.GetDirectoryName(Application.ExecutablePath), FileName, TextFill, Replace)
        End Sub

        Public Shared Sub Create(Directory As String, FileName As String, TextFill As String(), Replace As Boolean)
            If Replace = True Then
                Delete(Directory, FileName)
            End If

            Dim FileStream As FileStream = IO.File.Create(Directory + "\" + FileName)

            For Counter As Integer = 0 To TextFill.Length - 1
                Dim TextEncode As Byte() = New UTF8Encoding(True).GetBytes(TextFill(Counter) + vbCrLf)
                FileStream.Write(TextEncode, 0, TextEncode.Length)
            Next

            FileStream.Close()
        End Sub

        Public Shared Sub Rename(OldFileName As String, NewFileName As String)
            Rename(Path.GetDirectoryName(Application.ExecutablePath), OldFileName, NewFileName)
        End Sub

        Public Shared Sub Rename(Directory As String, OldFileName As String, NewFileName As String)
            My.Computer.FileSystem.RenameFile(Directory + "\" + OldFileName, NewFileName)
        End Sub

        Public Shared Sub Delete(FileName As String)
            Delete(Path.GetDirectoryName(Application.ExecutablePath), FileName)
        End Sub

        Public Shared Sub Delete(Directory As String, FileName As String)
            My.Computer.FileSystem.DeleteFile(Directory + "\" + FileName)
        End Sub
    End Class
End Namespace