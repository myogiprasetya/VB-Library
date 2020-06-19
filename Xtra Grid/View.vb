Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid

Namespace MYP100JECT.Library.XtraGrid
    Public Class View
        Private GridView As GridView

        Public Sub New(GridView As GridView)
            Me.GridView = GridView
        End Sub

        Public Sub Column(Index As Integer, Caption As String, Width As Integer, HorzAlignment As HorzAlignment, Visible As Boolean)
            With GridView
                With .Columns(Index)
                    .Caption = Caption
                    .Width = Width
                    .AppearanceHeader.TextOptions.HAlignment = HorzAlignment
                    .AppearanceCell.TextOptions.HAlignment = HorzAlignment
                    .Visible = Visible
                End With
            End With
        End Sub

        Public Sub CustomBestFitColumn()
            GridView.OptionsView.ColumnAutoWidth = True
        End Sub
    End Class
End Namespace

