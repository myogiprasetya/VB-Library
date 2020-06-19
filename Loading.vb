Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen

Imports WireRodTransactionApplication.Views

Namespace MYP100JECT.Library
    Public Class Loading
        Private XtraForm As XtraForm

        Public Sub New()
        End Sub

        Public Sub New(XtraForm As XtraForm)
            Me.XtraForm = XtraForm
        End Sub

        Public Sub Action(Action As String)
            Try
                SplashScreenManager.Default.SendCommand(Waiting.Loading.WaitFormCommand.Action, Action)
            Catch ex As Exception
                Run()
                SplashScreenManager.Default.SendCommand(Waiting.Loading.WaitFormCommand.Action, Action)
            End Try
        End Sub

        Public Sub Close()
            Try
                If XtraForm IsNot Nothing Then
                    With XtraForm
                        .UseWaitCursor = False
                        .Cursor = Cursors.Default
                    End With
                End If

                SplashScreenManager.CloseForm()
            Catch ex As Exception
            End Try
        End Sub

        Private Sub Run()
            Try
                If XtraForm IsNot Nothing Then
                    With XtraForm
                        .UseWaitCursor = True
                        .Cursor = Cursors.WaitCursor
                    End With
                End If

                SplashScreenManager.ShowForm(GetType(Waiting.Loading))
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace
