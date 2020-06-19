Namespace MYP100JECT.Library.Selecting
    Public Class Table
        Public Enum Name
            LabelRebar
            LabelWireRod
        End Enum

        Public Shared Function GetName(Name As Name) As String
            Select Case Name
                Case Name.LabelRebar
                    Return "Prd_Trx_ProduksiProfilRB"
                Case Name.LabelWireRod
                    Return "Prd_Trx_ProduksiWR"
                Case Else
                    Return String.Empty
            End Select
        End Function
    End Class
End Namespace