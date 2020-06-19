Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Imports Newtonsoft.Json

Imports WireRodTransactionApplication.MYP100JECT.Library.Server

Namespace MYP100JECT.Library.XtraGrid
    Public Class Control
        Public Shared Sub SetSource(GridControl As GridControl, GridView As GridView, Data As String, TotalColumn As Integer)
            If CBool(Configs.System.Connection.Check()) Then
                With New Data(Data)
                    If .ReadStatus() = 200 Then
                        GridControl.DataSource = Nothing

                        GridView.Columns.Clear()

                        If .ReadDataCount > 0 Then
                            GridControl.DataSource = JsonConvert.DeserializeObject(Of DataTable)(.ReadData().ToString())
                        Else
                            Dim DataTable As New DataTable

                            For Counter As Integer = 0 To TotalColumn - 1
                                DataTable.Columns.Add()
                            Next

                            GridControl.DataSource = DataTable
                        End If
                    End If
                End With
            End If
        End Sub
    End Class
End Namespace
