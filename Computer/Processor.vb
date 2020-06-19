Imports System.Management

Namespace MYP100JECT.Library.Computer
    Public Class Processor

        Public Function GetId() As String
            With New ManagementObjectSearcher(New SelectQuery("Win32_Processor"))
                Dim Value As String = String.Empty

                For Each ManagementObject As ManagementObject In .Get()
                    Value = CStr(ManagementObject("processorId"))
                Next

                Return Value
            End With
        End Function
    End Class
End Namespace
