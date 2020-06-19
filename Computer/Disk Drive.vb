Imports System.Management

Namespace MYP100JECT.Library.Computer
    Public Class DiskDrive

        Public Function GetVolumeSerial() As String
            Dim ManagementObject As New ManagementObject(String.Format("Win32_LogicalDisk.DeviceId='{0}:'", "C"))

            ManagementObject.Get()

            Return CStr(ManagementObject("VolumeSerialNumber"))
        End Function
    End Class
End Namespace
