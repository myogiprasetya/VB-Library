Imports System.Threading

Imports DevExpress.XtraSplashScreen

Imports WireRodTransactionApplication.Views

Namespace MYP100JECT.Library
    Public Class SplashScreen
        Private Delay As Integer

        Public Sub New(Delay As Integer)
            Me.Delay = Delay
        End Sub

        Public Sub Change(Action As String, ProgressStart As Integer, ProgressEnd As Integer)
            With SplashScreenManager.Default
                If ProgressEnd < 100 Then
                    For Counter As Integer = ProgressStart To ProgressEnd
                        .SendCommand(Waiting.SplashScreen.SplashScreenCommand.Action, Action + "... " + CStr(Counter) + "%")
                        .SendCommand(Waiting.SplashScreen.SplashScreenCommand.Progress, Counter)
                        Thread.Sleep(Delay)
                    Next
                End If
            End With
        End Sub

        Public Sub [Stop](Action As String)
            With SplashScreenManager.Default
                .SendCommand(Waiting.SplashScreen.SplashScreenCommand.Action, Action + "... 100%")
                .SendCommand(Waiting.SplashScreen.SplashScreenCommand.Progress, 100)
            End With
        End Sub
    End Class
End Namespace
