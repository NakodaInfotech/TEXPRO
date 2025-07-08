
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class PurchaseOrderClose

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PurchaseOrderClose_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Space And e.Control = True Then
                'SELECT ALL DATA
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CLOSED") = Not Convert.ToBoolean(dtrow("CLOSED"))
                Next
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PurchaseOrderClose_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE ORDER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search("*", "", " (SELECT PURCHASEORDER.PO_NO AS PONO, PURCHASEORDER.PO_DATE AS PODATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(PURCHASEORDER.PO_REFNO, '0') AS REFNO, ISNULL(PURCHASEORDER.PO_REMARKS, '') AS REMARKS, PURCHASEORDER_DESC.PO_GRIDSRNO AS POGRIDSRNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(PURCHASEORDER_DESC.PO_GRIDREMARKS, '') AS GRIDREMARKS, ISNULL(PURCHASEORDER_DESC.PO_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(PURCHASEORDER_DESC.PO_RATE, 0) AS RATE, ISNULL(PURCHASEORDER_DESC.PO_AMT, 0) AS AMT, ISNULL(PURCHASEORDER_DESC.PO_RECDQTY, 0) AS RECDQTY, ISNULL(PURCHASEORDER_DESC.PO_DONE, 0) AS GRIDPODONE, ISNULL(PURCHASEORDER_DESC.PO_CLOSED, 0) AS CLOSED, (PURCHASEORDER_DESC.PO_QTY-PURCHASEORDER_DESC.PO_RECDQTY) AS BALPCS, 'PURCHASEORDER' AS TYPE FROM PURCHASEORDER INNER JOIN PURCHASEORDER_DESC ON PURCHASEORDER.PO_NO = PURCHASEORDER_DESC.PO_NO AND PURCHASEORDER.PO_YEARID = PURCHASEORDER_DESC.PO_YEARID INNER JOIN ITEMMASTER ON PURCHASEORDER_DESC.PO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN UNITMASTER ON PURCHASEORDER_DESC.PO_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN LEDGERS ON PURCHASEORDER.PO_LEDGERID = LEDGERS.Acc_id WHERE PURCHASEORDER_DESC.PO_CLOSED = 'FALSE' and (PURCHASEORDER_DESC.PO_QTY-PURCHASEORDER_DESC.PO_RECDQTY)>0 AND dbo.PURCHASEORDER.PO_yearid=" & YearId & " UNION ALL SELECT OPENINGPURCHASEORDER.OPO_NO AS PONO, OPENINGPURCHASEORDER.OPO_DATE AS PODATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(OPENINGPURCHASEORDER.OPO_REFNO, '0') AS REFNO, ISNULL(OPENINGPURCHASEORDER.OPO_REMARKS, '') AS REMARKS, OPENINGPURCHASEORDER_DESC.OPO_GRIDSRNO AS POGRIDSRNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(OPENINGPURCHASEORDER_DESC.OPO_GRIDREMARKS, '') AS GRIDREMARKS, ISNULL(OPENINGPURCHASEORDER_DESC.OPO_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(OPENINGPURCHASEORDER_DESC.OPO_RATE, 0) AS RATE, ISNULL(OPENINGPURCHASEORDER_DESC.OPO_AMT, 0) AS AMT, ISNULL(OPENINGPURCHASEORDER_DESC.OPO_RECDQTY, 0) AS RECDQTY, ISNULL(OPENINGPURCHASEORDER_DESC.OPO_DONE, 0) AS GRIDPODONE, ISNULL(OPENINGPURCHASEORDER_DESC.OPO_CLOSED, 0) AS CLOSED, (OPENINGPURCHASEORDER_DESC.OPO_QTY-OPENINGPURCHASEORDER_DESC.OPO_RECDQTY) AS BALPCS, 'OPENING' AS TYPE FROM OPENINGPURCHASEORDER INNER JOIN OPENINGPURCHASEORDER_DESC ON OPENINGPURCHASEORDER.OPO_NO = OPENINGPURCHASEORDER_DESC.OPO_NO AND OPENINGPURCHASEORDER.OPO_YEARID = OPENINGPURCHASEORDER_DESC.OPO_YEARID INNER JOIN ITEMMASTER ON OPENINGPURCHASEORDER_DESC.OPO_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON OPENINGPURCHASEORDER.OPO_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN UNITMASTER ON OPENINGPURCHASEORDER_DESC.OPO_QTYUNITID = UNITMASTER.unit_id  WHERE OPENINGPURCHASEORDER_DESC.OPO_CLOSED = 'FALSE' and (OPENINGPURCHASEORDER_DESC.OPO_QTY-OPENINGPURCHASEORDER_DESC.OPO_RECDQTY)>0 AND dbo.OPENINGPURCHASEORDER.OPO_yearid=" & YearId & ") AS T", " ORDER BY PONO, POGRIDSRNO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Dim OBJCMN As New ClsCommon
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim DTROW As DataRow = gridbill.GetDataRow(I)
                If Convert.ToBoolean(DTROW("CLOSED")) = True Then
                    If DTROW("TYPE") = "PURCHASEORDER" Then Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE PURCHASEORDER_DESC SET PO_CLOSED = 1 WHERE PO_NO = " & Val(DTROW("PONO")) & " AND PO_GRIDSRNO = " & Val(DTROW("POGRIDSRNO")) & " AND PO_YEARID = " & YearId, "", "") Else Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE OPENINGPURCHASEORDER_DESC SET OPO_CLOSED = 1 WHERE OPO_NO = " & Val(DTROW("PONO")) & " AND OPO_GRIDSRNO = " & Val(DTROW("POGRIDSRNO")) & " AND OPO_YEARID = " & YearId, "", "")
                End If
            Next
            MsgBox("Entries Updated")
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CLOSED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Purchase Order Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Purchase Order Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase Order Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Purchase Order Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CLOSED") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class