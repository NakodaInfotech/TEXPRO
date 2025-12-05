
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class SaleOrderClose

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SaleOrderClose_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub SaleOrderClose_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE ORDER'")
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
            Dim dt As New DataTable
            If RBPENDING.Checked = True Then
                dt = objclsCMST.search(" ALLSALEORDER.SO_NO AS SONO, ALLSALEORDER.SO_DATE AS SODATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(ALLSALEORDER.SO_REMARKS, '') AS REMARKS, ALLSALEORDER_DESC.SO_GRIDSRNO AS SOGRIDSRNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ALLSALEORDER_DESC.SO_BALES, 0) AS QTY, ISNULL(ALLSALEORDER_DESC.SO_RATE, 0) AS RATE, ISNULL(ALLSALEORDER_DESC.SO_OUTBALES, 0) AS RECDPCS, ISNULL(ALLSALEORDER_DESC.SO_CLOSED, 0) AS CLOSED, ALLSALEORDER_DESC.SO_BALES - ALLSALEORDER_DESC.SO_OUTBALES AS BALPCS, ALLSALEORDER.TYPE  ", "", " ALLSALEORDER INNER JOIN ALLSALEORDER_DESC ON ALLSALEORDER.SO_NO = ALLSALEORDER_DESC.SO_NO AND ALLSALEORDER.SO_YEARID = ALLSALEORDER_DESC.SO_YEARID INNER JOIN ITEMMASTER ON ALLSALEORDER_DESC.SO_ITEMID = ITEMMASTER.item_id INNER JOIN LEDGERS ON ALLSALEORDER.SO_LEDGERID = LEDGERS.Acc_id ", " AND ALLSALEORDER_DESC.SO_CLOSED = 'FALSE' and (ALLSALEORDER_DESC.SO_BALES-ALLSALEORDER_DESC.SO_OUTBALES)>0 AND dbo.ALLSALEORDER.SO_yearid= " & YearId & " ORDER BY SONO, SOGRIDSRNO")
            Else
                dt = objclsCMST.search(" ALLSALEORDER.SO_NO AS SONO, ALLSALEORDER.SO_DATE AS SODATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(ALLSALEORDER.SO_REMARKS, '') AS REMARKS, ALLSALEORDER_DESC.SO_GRIDSRNO AS SOGRIDSRNO, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(ALLSALEORDER_DESC.SO_BALES, 0) AS QTY, ISNULL(ALLSALEORDER_DESC.SO_RATE, 0) AS RATE, ISNULL(ALLSALEORDER_DESC.SO_OUTBALES, 0) AS RECDPCS, ISNULL(ALLSALEORDER_DESC.SO_CLOSED, 0) AS CLOSED, ALLSALEORDER_DESC.SO_BALES - ALLSALEORDER_DESC.SO_OUTBALES AS BALPCS, ALLSALEORDER.TYPE  ", "", " ALLSALEORDER INNER JOIN ALLSALEORDER_DESC ON ALLSALEORDER.SO_NO = ALLSALEORDER_DESC.SO_NO AND ALLSALEORDER.SO_YEARID = ALLSALEORDER_DESC.SO_YEARID INNER JOIN ITEMMASTER ON ALLSALEORDER_DESC.SO_ITEMID = ITEMMASTER.item_id INNER JOIN LEDGERS ON ALLSALEORDER.SO_LEDGERID = LEDGERS.Acc_id ", " AND ALLSALEORDER_DESC.SO_CLOSED = 'TRUE' and (ALLSALEORDER_DESC.SO_BALES-ALLSALEORDER_DESC.SO_OUTBALES)>0 AND dbo.ALLSALEORDER.SO_yearid= " & YearId & " ORDER BY SONO, SOGRIDSRNO")
            End If
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

            If RBENTERED.Checked = True Then
                If MsgBox("You have trying to Re-Open Closed Orders, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim DTROW As DataRow = gridbill.GetDataRow(I)
                If RBPENDING.Checked = True Then
                    If Convert.ToBoolean(DTROW("CLOSED")) = True Then
                        If DTROW("TYPE") = "SALEORDER" Then Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE SALEORDER_DESC SET SO_CLOSED = 1 WHERE SO_NO = " & Val(DTROW("SONO")) & " AND SO_GRIDSRNO = " & Val(DTROW("SOGRIDSRNO")) & " AND SO_YEARID = " & YearId, "", "") Else Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE OPENINGSALEORDER_DESC SET OSO_CLOSED = 1 WHERE OSO_NO = " & Val(DTROW("SONO")) & " AND OSO_GRIDSRNO = " & Val(DTROW("SOGRIDSRNO")) & " AND OSO_YEARID = " & YearId, "", "")
                    End If
                Else
                    If Convert.ToBoolean(DTROW("CLOSED")) = True Then
                        If DTROW("TYPE") = "SALEORDER" Then Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE SALEORDER_DESC SET SO_CLOSED = 0 WHERE SO_NO = " & Val(DTROW("SONO")) & " AND SO_GRIDSRNO = " & Val(DTROW("SOGRIDSRNO")) & " AND SO_YEARID = " & YearId, "", "") Else Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE OPENINGSALEORDER_DESC SET OSO_CLOSED = 0 WHERE OSO_NO = " & Val(DTROW("SONO")) & " AND OSO_GRIDSRNO = " & Val(DTROW("SOGRIDSRNO")) & " AND OSO_YEARID = " & YearId, "", "")
                    End If
                End If

            Next
            MsgBox("Entries Updated")
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid("")
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

            Dim PATH As String = Application.StartupPath & "\Sale Order Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Sale Order Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sale Order Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Sale Order Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
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

    Private Sub gridbill_KeyDown(sender As Object, e As KeyEventArgs) Handles gridbill.KeyDown
        Try
            If e.KeyCode = Keys.Space Then
                Dim dtrow As DataRow = gridbill.GetFocusedDataRow()
                dtrow("CLOSED") = Not dtrow("CLOSED")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class