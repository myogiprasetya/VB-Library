Imports System.Management

Namespace MYP100JECT.Library.Computer
    Public Class NetwokInterface

        Public Function GetMACAddress() As String
            Dim Address As String = String.Empty

            For Each ManagementObject As ManagementObject In New ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances()
                If CBool(ManagementObject("IPEnabled")) Then
                    Address = CStr(ManagementObject("MacAddress")).Replace(":", String.Empty)
                End If

                ManagementObject.Dispose()
            Next

            Return Address
        End Function
    End Class
End Namespace
