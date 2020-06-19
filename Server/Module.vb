Imports System.Net

Imports WireRodTransactionApplication.MYP100JECT.Library.Computer

Namespace MYP100JECT.Library.Server
    Module [Module]
        Private __Key As String()
        Private __IPAddress As String
        Private __Port As Integer
        Private __ServiceName As String

        Public Service As New Web_Reference.LabelService

        Public Enum KeyType
            HostName
            ProcessorId
            MACAddress
            HDDVolumeSerial
            UserName
        End Enum

        Public Enum ServerType
            [Nothing]
            Cloud
            LocalPublicIP
            LocalPrivateIP
            Localhost
        End Enum

        Public Property Token As String

        Public Property IPAddress As String
            Get
                Return __IPAddress
            End Get
            Set(Value As String)
                __IPAddress = Value

                SetURL()
            End Set
        End Property

        Public Property Port As Integer
            Get
                Return __Port
            End Get
            Set(Value As Integer)
                __Port = Value

                SetURL()
            End Set
        End Property

        Public Property ServiceName As String
            Get
                Return __ServiceName
            End Get
            Set(Value As String)
                __ServiceName = Value

                SetURL()
            End Set
        End Property

        Public Function GetKey() As String()
            Return __Key
        End Function

        Public Function GetKey(Type As KeyType) As String
            Select Case Type
                Case KeyType.HostName
                    Return __Key(0)
                Case KeyType.ProcessorId
                    Return __Key(1)
                Case KeyType.MACAddress
                    Return __Key(2)
                Case KeyType.HDDVolumeSerial
                    Return __Key(3)
                Case KeyType.UserName
                    Return __Key(4)
                Case Else
                    Return String.Empty
            End Select
        End Function

        Public Function GetServerType() As ServerType
            Select Case IPAddress
                Case "103.252.50.154"
                    Return ServerType.Cloud
                Case "203.77.237.178"
                    Return ServerType.LocalPublicIP
                Case "192.168.53.50"
                    Return ServerType.LocalPrivateIP
                Case "localhost"
                    Return ServerType.Localhost
                Case Else
                    Return ServerType.Nothing
            End Select
        End Function

        Public Function GetURL() As String
            Return Service.Url
        End Function

        Private Sub SetURL()
            Service.Url = "http://" + IPAddress + ":" + CStr(Port) + "/" + ServiceName + ".asmx"
        End Sub

        Public Sub SetKey()
            Dim Processor As New Processor
            Dim NetwokInterface As New NetwokInterface
            Dim DiskDrive As New DiskDrive

            __Key = {
                Dns.GetHostName(),
                Processor.GetId(),
                NetwokInterface.GetMACAddress(),
                DiskDrive.GetVolumeSerial(),
                Environment.UserName
            }
        End Sub
    End Module
End Namespace
