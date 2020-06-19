Namespace MYP100JECT.Library.Computer
    Public Class Process
        Private Declare Function ShowWindow Lib "user32" (ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
        Private Declare Function SetForegroundWindow Lib "user32" (ByVal hWnd As IntPtr) As Boolean

        Private NameValue As String
        Private LocationValue As String

        Public Function Name(Value As String) As Process
            NameValue = Value

            Return Me
        End Function

        Public Function Location(Value As String) As Process
            LocationValue = Value

            Return Me
        End Function

        Public Sub Run()
            If NameValue <> String.Empty Then
                Diagnostics.Process.Start(NameValue)
            End If

            If LocationValue <> String.Empty Then
                Diagnostics.Process.Start(LocationValue)
            End If
        End Sub

        Public Sub Show(Maximize As Boolean)
            If NameValue IsNot Nothing Then
                For Each Process As Diagnostics.Process In Diagnostics.Process.GetProcessesByName(NameValue)
                    If Maximize = True Then
                        ShowWindow(Process.MainWindowHandle, 3)
                    Else
                        ShowWindow(Process.MainWindowHandle, 5)
                    End If

                    SetForegroundWindow(Process.MainWindowHandle)
                Next
            End If
        End Sub

        Public Sub Show()
            If NameValue IsNot Nothing Then
                For Each Process As Diagnostics.Process In Diagnostics.Process.GetProcessesByName(NameValue)
                    ShowWindow(Process.MainWindowHandle, 5)

                    SetForegroundWindow(Process.MainWindowHandle)
                Next
            End If
        End Sub
    End Class
End Namespace
