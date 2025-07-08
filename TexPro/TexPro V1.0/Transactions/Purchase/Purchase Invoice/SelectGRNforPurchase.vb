Imports BL

Public Class SelectGRNforPurchase
    Dim addcol As Integer = 0
    Dim dt As New DataTable
    Dim N As Integer = 0
    Dim tempindex, i As Integer
    Dim col As New DataGridViewCheckBoxColumn  'Dim dt As New DataTable
    Public PARTYNAME As String = ""  'for whereclause in fillgrid
    Public dt1 As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectGRNforPurchase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectGRNforPurchase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = 100
        PurchaseMaster.selectPURtable.Clear()
        fillgrid()
        cmbselect.Text = "GRN No."
        txtsearch.Focus()
    End Sub

    Sub fillgrid(Optional ByVal where As String = "")
        Try
            If PARTYNAME <> "" Then where = where & " AND LEDGERS.ACC_CMPNAME = '" & PARTYNAME & "'"

            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            dt = OBJCMN.search("  GRN.grn_no AS [GRN NO], GRN.grn_date AS DATE, LEDGERS.Acc_cmpname AS NAME, GRN.grn_challanno AS [CH. NO], GRN.grn_challandt AS [CH. DATE], GRN.grn_pono AS [PO NO], GRN.grn_podate AS [PO DATE], LEDGERS_1.Acc_cmpname AS TRANSNAME, GRN.grn_lrno AS LRNO, GRN.grn_lrdate AS LRDATE, GRN.grn_transrefno AS TRANSREFNO, GRN_DESC.GRN_GRIDSRNO AS GRIDSRNO, ITEMMASTER.item_name AS ITEMNAME, QUALITYMASTER.QUALITY_name AS QUALITY, GRN_DESC.GRN_REED AS REED, GRN_DESC.GRN_PICK AS PICK, COLORMASTER.COLOR_name AS COLOR, GRN_DESC.GRN_QTY AS QTY, UNITMASTER.unit_abbr AS UNIT, GRN_DESC.GRN_MTRS AS MTRS, GRN_DESC.GRN_WT AS WT ", "", " GRN INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id INNER JOIN GRN_DESC ON GRN.grn_no = GRN_DESC.GRN_NO AND GRN.grn_yearid = GRN_DESC.GRN_YEARID AND GRN.GRN_TYPE = GRN_DESC.GRN_GRIDTYPE LEFT OUTER JOIN QUALITYMASTER ON GRN_DESC.GRN_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON GRN_DESC.GRN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN COLORMASTER ON GRN_DESC.GRN_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN UNITMASTER ON GRN_DESC.GRN_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON GRN.grn_transledgerid = LEDGERS_1.Acc_id ", " AND GRN.GRN_TYPE = 'Inwards' AND GRN_DESC.GRN_DONE='False' and grn.grn_Yearid = " & YearId & where & "  ORDER BY [GRN No]")

            GRIDGRN.DataSource = dt
            If addcol = 0 Then
                GRIDGRN.Columns.Insert(0, col)
                addcol = 1
            End If
            If dt.Rows.Count > 0 Then
                GRIDGRN.Columns(0).Width = 40     'Check Box
                GRIDGRN.Columns(0).ReadOnly = False

                GRIDGRN.Columns(1).Width = 80     'grnNO
                GRIDGRN.Columns(2).Width = 80   'CUSNAME
                GRIDGRN.Columns(3).Width = 150    'DATE
                GRIDGRN.Columns(4).Width = 60    'CHALLANNO
                GRIDGRN.Columns(5).Width = 80    'CHALLANDATE
                GRIDGRN.Columns(6).Width = 60    'CHALLANDATE
                GRIDGRN.Columns(7).Width = 80    'CHALLANDATE
                GRIDGRN.Columns(8).Visible = False    'CHALLANDATE
                GRIDGRN.Columns(9).Visible = False    'CHALLANDATE
                GRIDGRN.Columns(10).Visible = False    'CHALLANDATE
                GRIDGRN.Columns(11).Visible = False     'CHALLANDATE
                GRIDGRN.Columns(12).Visible = False     'CHALLANDATE
                GRIDGRN.Columns(13).Width = 100 'CHALLANDATE
                GRIDGRN.Columns(14).Width = 100    'CHALLANDATE
                GRIDGRN.Columns(15).Visible = False   'CHALLANDATE
                GRIDGRN.Columns(16).Visible = False    'CHALLANDATE
                GRIDGRN.Columns(17).Visible = False    'CHALLANDATE
                GRIDGRN.Columns(18).Visible = False    'CHALLANDATE
                GRIDGRN.Columns(19).Visible = False     'CHALLANDATE
                GRIDGRN.Columns(20).Visible = False    'CHALLANDATE
                GRIDGRN.Columns(21).Visible = False    'CHALLANDATE
                GRIDGRN.FirstDisplayedScrollingRowIndex = GRIDGRN.RowCount - 1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            dt1.Columns.Add("grnNO")
            dt1.Columns.Add("date")
            dt1.Columns.Add("CUSNAME")
            dt1.Columns.Add("challanNO")
            dt1.Columns.Add("challanDATE")
            dt1.Columns.Add("poNO")
            dt1.Columns.Add("poDATE")
            dt1.Columns.Add("trans")
            dt1.Columns.Add("lrno")
            dt1.Columns.Add("lrdate")
            dt1.Columns.Add("transrefno")
            dt1.Columns.Add("grngridsrno")
            dt1.Columns.Add("Item")
            dt1.Columns.Add("QUALITY")
            dt1.Columns.Add("REED")
            dt1.Columns.Add("PICK")
            dt1.Columns.Add("COLOR")
            dt1.Columns.Add("qty")
            dt1.Columns.Add("qtyunit")
            dt1.Columns.Add("MTRS")
            dt1.Columns.Add("WT")

            For Each row As DataGridViewRow In GRIDGRN.Rows
                If Convert.ToBoolean(row.Cells(0).Value) = True Then
                    dt1.Rows.Add(row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value, row.Cells(10).Value, row.Cells(11).Value, row.Cells(12).Value, row.Cells(13).Value, row.Cells(14).Value, row.Cells(15).Value, row.Cells(16).Value, row.Cells(17).Value, row.Cells(18).Value, row.Cells(19).Value, row.Cells(20).Value, row.Cells(21).Value)
                End If
            Next

            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Private Sub GRIDgrn_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDgrn.CellClick
        Try
            'Dim tempindex As Integer
            ''CHECKING SIMILAR Enquiry Numbers
            'For i = 0 To GRIDGRN.RowCount - 1
            '    With GRIDGRN.Rows(i).Cells(0)
            '        If .Value = True Then
            '            N = GRIDGRN.Item(1, i).Value.ToString
            '        End If
            '    End With
            'Next

            If e.RowIndex >= 0 Then
                With GRIDGRN.Rows(e.RowIndex).Cells(0)
                    If .Value = True Then
                        .Value = False
                    Else
                        'If (GRIDGRN.Item(1, e.RowIndex).Value.ToString = N) Or N = Nothing Then
                        .Value = True

                        '    tempindex = e.RowIndex
                        'End If
                    End If
                End With
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtsearch_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.Validated

        If cmbselect.Text.Trim <> "" And txtsearch.Text.Trim <> "" Then
            If cmbselect.Text = "GRN No." Then
                fillgrid(" and GRN.grn_no=" & Val(txtsearch.Text))
            End If

            If cmbselect.Text = "Vendor Name" Then
                fillgrid(" and LEDGERS.Acc_cmpname='" & txtsearch.Text & "'")
            End If

            If cmbselect.Text = "PO No." Then
                fillgrid(" and GRN.grn_pono='" & txtsearch.Text & "'")
            End If
        Else
            fillgrid()
        End If
    End Sub

    Private Sub gridgrn_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDgrn.CellDoubleClick
        Try
            cmdok_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub chkselectall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkselectall.CheckedChanged
        If chkselectall.Checked = True Then
            For Each row As DataGridViewRow In GRIDgrn.Rows
                row.Cells(0).Value = True
            Next
        Else
            For Each row As DataGridViewRow In GRIDGRN.Rows
                row.Cells(0).Value = False
            Next
        End If
    End Sub
End Class