Imports Newtonsoft.Json.Linq

Imports WireRodTransactionApplication.MYP100JECT.Library.Encryption.AES
Imports WireRodTransactionApplication.MYP100JECT.Library.Selecting

Namespace MYP100JECT.Library.Server
    Public Class Data
        Private Result As String

        Public Sub New()
        End Sub

        Public Sub New(Result As String)
            Me.Result = Result.DecryptAES("TMS-LabelApplication")
        End Sub

        Public Function ReadAll() As String
            Return Result
        End Function

        Public Sub ReadAllToSession(Name As String(), Parameter As String())
            For Counter As Integer = 0 To Parameter.Length - 1
                ReadAllToSession(Name(Counter), Parameter(Counter))
            Next
        End Sub

        Public Sub ReadAllToSession(Name As String, Parameter As String)
            Session.Set(Name, CStr(ReadDataValue({0, Parameter})))
        End Sub

        Public Function ReadByKey(Key As Object) As Object
            Dim Json As JToken = JToken.Parse(Result)

            Try
                Return Json.Item(Key)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function ReadStatus() As Integer
            Return CInt(ReadByKey("Status"))
        End Function

        Public Function ReadData() As Object
            Return ReadByKey("Data")
        End Function

        Public Function ReadDataCount() As Integer
            Dim Json As JToken = JToken.FromObject(ReadByKey("Data"))

            Return Json.Count()
        End Function

        Public Function ReadDataValue(Key As Object) As Object
            Dim Json As JToken = JToken.FromObject(ReadByKey("Data"))

            Return Json.Item(Key)
        End Function

        Public Function ReadDataValue(Key As Object()) As Object
            Dim Result As String = ReadData().ToString()

            For Counter As Integer = 0 To Key.Count() - 1
                Result = JToken.Parse(Result).Item(Key(Counter)).ToString()
            Next

            Return Result
        End Function

        Public Function ReadInformation() As String
            Return CStr(ReadByKey("Information"))
        End Function

        Public Function ReadError() As Exception
            Return CType(ReadByKey("Error"), Exception)
        End Function

        Public Function AccessValidate() As Integer
            Result = Service.MainAccessValidate("Cumiasin79!3%^lldddd65522552$$%))---0``~", GetKey()).DecryptAES("TMS-LabelApplication")

            Return ReadStatus()
        End Function

        Public Sub CreateLog(DataId As String, Action As String, Table As Table.Name)
            Service.MainCreateLog(GetKey(), {
                Session.Get("User Id"),
                CStr(Now),
                My.Application.Info.AssemblyName,
                DataId,
                Action,
                CStr(Table),
                GetKey(KeyType.HDDVolumeSerial),
                GetKey(KeyType.UserName)}
            )
        End Sub
    End Class
End Namespace
