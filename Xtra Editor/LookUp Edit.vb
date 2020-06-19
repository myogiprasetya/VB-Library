Imports DevExpress

Imports Newtonsoft.Json

Imports WireRodTransactionApplication.MYP100JECT.Library.Server

Namespace MYP100JECT.Library.XtraEditor
    Public Class LookUpEdit
        Public Shared Sub SetSource(LookUpEdit As XtraEditors.LookUpEdit)
            SetSource(LookUpEdit, "Default")
        End Sub

        Public Shared Sub SetSource(LookUpEdit As XtraEditors.LookUpEdit, Value As String)
            If CBool(Configs.System.Connection.Check()) Then
                With New Data(Service.MainReadShiftAll(GetKey()))
                    If CInt(.ReadStatus()) = 200 Then
                        Dim DataTable As DataTable = JsonConvert.DeserializeObject(Of DataTable)(.ReadData().ToString())

                        With LookUpEdit
                            With .Properties
                                .DataSource = DataTable
                                .DropDownRows = DataTable.Rows.Count
                                .ValueMember = DataTable.Columns(0).Caption
                                .DisplayMember = DataTable.Columns(1).Caption

                                .PopulateColumns()

                                .Columns(0).Visible = False
                            End With

                            If Value = "Default" Then
                                .EditValue = DataTable.Rows(0).Item(0)
                            Else
                                .EditValue = Value
                            End If
                        End With
                    End If
                End With
            End If
        End Sub
    End Class
End Namespace
