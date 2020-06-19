Namespace MYP100JECT.Library.Formating
    Public Class DateTime
        Private Value As System.DateTime
        Public Sub New()
            Value = Now
        End Sub

        Public Sub New(DateTime As Object)
            With CDate(DateTime)
                Value = New System.DateTime(.Year, .Month, .Day, .Hour, .Minute, .Second)
            End With
        End Sub

        Public Sub New(DateTime As String)
            With CDate(DateTime)
                Value = New System.DateTime(.Year, .Month, .Day, .Hour, .Minute, .Second)
            End With
        End Sub

        Public Sub New(DateTime As String, Format As String)
            Select Case Format
                Case "dd-MM-yyyy"
                    Value = New System.DateTime(
                        CInt(DateTime.Trim().Split("-"c)(2)),
                        CInt(DateTime.Trim().Split("-"c)(1)),
                        CInt(DateTime.Trim().Split("-"c)(0)),
                        0, 0, 0
                    )
                Case "dd-MM-yyyy HH:mm:ss"
                    Value = New System.DateTime(
                        CInt(DateTime.Trim().Split(" "c)(0).Split("-"c)(2)),
                        CInt(DateTime.Trim().Split(" "c)(0).Split("-"c)(1)),
                        CInt(DateTime.Trim().Split(" "c)(0).Split("-"c)(0)),
                        CInt(DateTime.Trim().Split(" "c)(1).Split(":"c)(0)),
                        CInt(DateTime.Trim().Split(" "c)(1).Split(":"c)(1)),
                        CInt(DateTime.Trim().Split(" "c)(1).Split(":"c)(2))
                    )
            End Select
        End Sub

        Public Sub New(DateTime As System.DateTime)
            Value = DateTime
        End Sub

        Public Function GetFirstDate() As System.DateTime
            Return New System.DateTime(Value.Year, Value.Month, 1)
        End Function

        Public Function GetLastDate() As System.DateTime
            Return New System.DateTime(Value.Year, Value.Month, System.DateTime.DaysInMonth(Value.Year, Value.Month))
        End Function

        Public Function GetDate() As System.DateTime
            Return Value
        End Function

        Public Function GetMonthAlphabet() As String
            Select Case Value.Month
                Case 1
                    Return "A"
                Case 2
                    Return "B"
                Case 3
                    Return "C"
                Case 4
                    Return "D"
                Case 5
                    Return "E"
                Case 6
                    Return "F"
                Case 7
                    Return "G"
                Case 8
                    Return "H"
                Case 9
                    Return "I"
                Case 10
                    Return "J"
                Case 11
                    Return "K"
                Case 12
                    Return "L"
                Case Else
                    Return CStr(False)
            End Select
        End Function

        Public Function GetStringInYear(Index As Integer, Length As Integer) As String
            Return CStr(Value.Year).Substring(Index, Length)
        End Function
    End Class
End Namespace