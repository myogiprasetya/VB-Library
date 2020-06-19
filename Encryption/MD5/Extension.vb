Imports System.Security.Cryptography

Namespace MYP100JECT.Library.Encryption.MD5
    Module Extension

        <Runtime.CompilerServices.Extension()>
        Public Function ToMD5(Value As String) As String
            Dim OriginalBytes() As Byte = Encoding.ASCII.GetBytes(Value.Trim)
            Dim MD5HashedBytes() As Byte = (New MD5CryptoServiceProvider).ComputeHash(OriginalBytes)
            Dim Result As String = String.Empty

            For Counter As Integer = 0 To MD5HashedBytes.GetUpperBound(0)
                Dim HexByte As String

                HexByte = MD5HashedBytes(Counter).ToString("X")

                If HexByte.Length = 1 Then
                    Result += "0" + HexByte
                Else
                    Result += HexByte
                End If
            Next

            Return Result.ToUpper()
        End Function
    End Module
End Namespace