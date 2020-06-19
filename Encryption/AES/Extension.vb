Namespace MYP100JECT.Library.Encryption.AES
    Module Extension
        <Runtime.CompilerServices.Extension()>
        Public Function EncryptAES(Value As String, Key As String) As String
            Return Config.Parse(Value, Key, True)
        End Function

        <Runtime.CompilerServices.Extension()>
        Public Function DecryptAES(Value As String, Key As String) As String
            Return Config.Parse(Value, Key, False)
        End Function
    End Module
End Namespace