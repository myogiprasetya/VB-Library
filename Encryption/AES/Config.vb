Imports System.Security.Cryptography
Imports System.Text

Namespace MYP100JECT.Library.Encryption.AES
    Public Class Config

        Public Shared Function Parse(Value As String, Key As String, Encrypt As Boolean) As String
            Try
                Dim RijndaelManaged As New RijndaelManaged
                Dim MD5CryptoServiceProvider As New MD5CryptoServiceProvider

                Dim Hash(31) As Byte
                Dim Temp As Byte() = MD5CryptoServiceProvider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Key))
                Dim Buffer As Byte()
                Dim ICryptoTransform As ICryptoTransform

                Array.Copy(Temp, 0, Hash, 0, 16)
                Array.Copy(Temp, 0, Hash, 15, 16)

                RijndaelManaged.Key = Hash
                RijndaelManaged.Mode = CipherMode.ECB

                If Encrypt = True Then
                    ICryptoTransform = RijndaelManaged.CreateEncryptor
                    Buffer = ASCIIEncoding.ASCII.GetBytes(Value)

                    Return Convert.ToBase64String(ICryptoTransform.TransformFinalBlock(Buffer, 0, Buffer.Length))
                Else
                    ICryptoTransform = RijndaelManaged.CreateDecryptor
                    Buffer = Convert.FromBase64String(Value)

                    Return ASCIIEncoding.ASCII.GetString(ICryptoTransform.TransformFinalBlock(Buffer, 0, Buffer.Length))
                End If
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace