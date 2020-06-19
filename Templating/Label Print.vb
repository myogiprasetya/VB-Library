Imports System.Drawing.Printing

Imports ZXing

Namespace MYP100JECT.Library.Templating
    Public Class LabelPrint
        Public Enum ValueType
            Normal
            Large
        End Enum

        Private PrintPageEventArgs As PrintPageEventArgs

        Public Sub New(PrintPageEventArgs As PrintPageEventArgs)
            Me.PrintPageEventArgs = PrintPageEventArgs
        End Sub

        Public Sub Logo(HorizontalPosition As Integer, VerticalPosition As Integer)
            With PrintPageEventArgs.Graphics
                .DrawString(
                    "MASTER STEEL",
                    New Font("Verdana", 14, FontStyle.Bold),
                    Brushes.Black,
                    HorizontalPosition,
                    VerticalPosition
                )
                .DrawString(
                    "PT The Master Steel Mfc",
                    New Font("Calibri", 11, FontStyle.Bold),
                    Brushes.Black,
                    HorizontalPosition + 2,
                    VerticalPosition + 20
                )
                .DrawImage(
                    My.Resources.Logo,
                    HorizontalPosition + 170,
                    CInt((VerticalPosition + 20) / 2)
                )
            End With
        End Sub

        Public Sub MadeInIndonesia(HorizontalPosition As Integer, VerticalPosition As Integer)
            PrintPageEventArgs.Graphics.DrawString(
                "Made In Indonesia",
                New Font("Calibri", 9, FontStyle.Bold),
                Brushes.Black, HorizontalPosition, VerticalPosition
            )
        End Sub

        Public Sub QR(Value As String, HorizontalPosition As Integer, VerticalPosition As Integer)
            Dim BarcodeWriter As New BarcodeWriter With {
                .Format = BarcodeFormat.QR_CODE,
                .Options = New Common.EncodingOptions With {
                    .Height = 42,
                    .Width = 42,
                    .Margin = 0
                }
            }

            PrintPageEventArgs.Graphics.DrawImage(
                DirectCast(BarcodeWriter.Write(Value), Image),
                HorizontalPosition,
                VerticalPosition
            )
        End Sub

        Public Sub Content(Value As String(,), Space As Integer, HorizontalPosition As Integer, VerticalPosition As Integer)
            For Counter As Integer = 0 To Value.GetLength(0) - 1
                Content(
                    Value(Counter, 0),
                    Value(Counter, 1),
                    12,
                    HorizontalPosition,
                    VerticalPosition + (Counter * Space)
                )
            Next
        End Sub

        Public Sub Content(Value As String(,), FontSize As Integer, Space As Integer, HorizontalPosition As Integer, VerticalPosition As Integer)
            For Counter As Integer = 0 To Value.GetLength(0) - 1
                Content(
                    Value(Counter, 0),
                    Value(Counter, 1),
                    FontSize,
                    HorizontalPosition,
                    VerticalPosition + (Counter * Space)
                )
            Next
        End Sub

        Public Sub Content(Value As String, FontSize As Integer, HorizontalPosition As Integer, VerticalPosition As Integer)
            PrintPageEventArgs.Graphics.DrawString(
                Value,
                New Font("Calibri", FontSize, FontStyle.Bold),
                Brushes.Black,
                HorizontalPosition,
                VerticalPosition
            )
        End Sub

        Public Sub Content(Title As String, Value As String, HorizontalPosition As Integer, VerticalPosition As Integer)
            Content(Title, Value, ValueType.Normal, HorizontalPosition, VerticalPosition)
        End Sub

        Public Sub Content(Title As String, Value As String, FontSize As Integer, HorizontalPosition As Integer, VerticalPosition As Integer)
            Content(Title, Value, FontSize, ValueType.Normal, HorizontalPosition, VerticalPosition)
        End Sub

        Public Sub Content(Title As String, Value As String, ValueType As ValueType, HorizontalPosition As Integer, VerticalPosition As Integer)
            Content(Title, Value, 12, ValueType, HorizontalPosition, VerticalPosition)
        End Sub

        Public Sub Content(Title As String, Value As String, FontSize As Integer, ValueType As ValueType, HorizontalPosition As Integer, VerticalPosition As Integer)
            With PrintPageEventArgs.Graphics
                .DrawString(
                    Title,
                    New Font("Calibri", FontSize, FontStyle.Bold),
                    Brushes.Black,
                    HorizontalPosition,
                    VerticalPosition
                )
                .DrawString(
                    ":",
                    New Font("Calibri", FontSize, FontStyle.Bold),
                    Brushes.Black,
                    HorizontalPosition + 100,
                    VerticalPosition
                )

                Select Case ValueType
                    Case ValueType.Normal
                        .DrawString(
                            Value,
                            New Font("Calibri", FontSize, FontStyle.Bold),
                            Brushes.Black,
                            HorizontalPosition + 110,
                            VerticalPosition
                        )
                    Case ValueType.Large
                        .DrawString(
                            Value,
                            New Font("Calibri", 50, FontStyle.Bold),
                            Brushes.Black,
                            HorizontalPosition + 100,
                            VerticalPosition - 10
                        )
                End Select
            End With
        End Sub
    End Class
End Namespace
