Namespace MYP100JECT.Library.Selecting.Label
    Public Class Status
        Public Enum Name
            Active
            Coble
            Rework
            UpgradeDowngrade
            Void
        End Enum

        Public Shared Function GetInitial(Name As Name) As String
            Select Case Name
                Case Name.Active
                    Return "A"
                Case Name.Coble
                    Return "C"
                Case Name.Rework
                    Return "R"
                Case Name.UpgradeDowngrade
                    Return "G"
                Case Name.Void
                    Return "V"
                Case Else
                    Return "A"
            End Select
        End Function
    End Class
End Namespace