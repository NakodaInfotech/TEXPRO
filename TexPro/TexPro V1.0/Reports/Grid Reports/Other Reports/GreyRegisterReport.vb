
Imports BL

Public Class GreyRegisterReport

    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FROMDATE, TODATE As Date

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GRNDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRNDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If FRMSTRING = "GREYPCS" Then
                gridbill.Columns("PARTYMTRS").Visible = False
                gridbill.Columns("UNCHECKED").Visible = False
                gridbill.Columns("checkmtrs").Visible = False
                gridbill.Columns("SHORTAGE").Visible = False
                gridbill.Columns("rejmtrs").Visible = False
                gridbill.Columns("ACCEPTED").Visible = False

                gridbill.Columns("PARTYPCS").Visible = True
                gridbill.Columns("UNCHECKEDPCS").Visible = True
                gridbill.Columns("CHECKPCS").Visible = True
                gridbill.Columns("SHORTAGEPCS").Visible = True
                gridbill.Columns("REJPCS").Visible = True
                gridbill.Columns("ACCEPTEDPCS").Visible = True
            End If

            If FROMDATE.Date <> "12:00 AM" Then WHERECLAUSE = WHERECLAUSE & " AND GRN.grn_date >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND GRN.grn_date <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' "
            fillgrid(WHERECLAUSE & " and grn.grn_type='G.R.N' and dbo.GRN.GRN_yearid=" & YearId & " order by dbo.GRN.GRN_no ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("  GRN.grn_no AS GRNNO, GRN.grn_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ITEMMASTER.item_name AS ITEMNAME, QUALITYMASTER.QUALITY_name AS QUALITY, GRN_DESC.GRN_QTY AS QTY, GRN_DESC.GRN_MTRS AS MTRS, ISNULL(CHECKINGMASTER.CHECK_TOTALPARTYMTRS,0) AS PARTYMTRS, CASE WHEN GRN_DESC.GRN_CHECKDONE = '0' THEN GRN_DESC.GRN_MTRS ELSE 0 END AS UNCHECKED, ISNULL(CHECKINGMASTER.CHECK_TOTALCHECKEDMTRS,0) AS checkmtrs, ISNULL(CHECKINGMASTER.CHECK_REJECTEDMTRS,0) AS rejmtrs, ISNULL(CHECKINGMASTER.CHECK_TOTALDIFF,0) AS SHORTAGE, ISNULL(CHECKINGMASTER.CHECK_BALMTRS,0) AS ACCEPTED, GRN.grn_remarks AS REMARKS, (ISNULL(CHECKINGMASTER.CHECK_REJECTEDPCS ,0) + ISNULL(CHECK_BALPCS ,0))  AS PARTYPCS, CASE WHEN GRN_DESC.GRN_CHECKDONE = '0' THEN GRN_DESC.GRN_QTY ELSE 0 END AS UNCHECKEDPCS, (ISNULL(CHECKINGMASTER.CHECK_REJECTEDPCS ,0) + ISNULL(CHECK_BALPCS ,0)) AS CHECKPCS, ISNULL(CHECKINGMASTER.CHECK_REJECTEDPCS,0) AS REJPCS, CASE WHEN GRN_DESC.GRN_CHECKDONE <> '0' THEN (GRN_DESC.GRN_QTY - (ISNULL(CHECKINGMASTER.CHECK_REJECTEDPCS ,0) + ISNULL(CHECK_BALPCS ,0))) ELSE 0 END AS SHORTAGEPCS, ISNULL(CHECKINGMASTER.CHECK_BALPCS,0) AS ACCEPTEDPCS ", "", " GRN INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id AND GRN.grn_cmpid = LEDGERS.Acc_cmpid AND GRN.grn_locationid = LEDGERS.Acc_locationid AND GRN.grn_yearid = LEDGERS.Acc_yearid INNER JOIN GRN_DESC ON GRN.grn_no = GRN_DESC.GRN_NO AND GRN.grn_cmpid = GRN_DESC.GRN_CMPID AND GRN.GRN_TYPE = GRN_DESC.GRN_GRIDTYPE AND GRN.grn_locationid = GRN_DESC.GRN_LOCATIONID AND GRN.grn_yearid = GRN_DESC.GRN_YEARID LEFT OUTER JOIN CHECKINGMASTER ON GRN.grn_yearid = CHECKINGMASTER.CHECK_YEARID AND GRN.grn_no = CHECKINGMASTER.CHECK_GRNNO LEFT OUTER JOIN QUALITYMASTER ON GRN_DESC.GRN_QUALITYID = QUALITYMASTER.QUALITY_id AND GRN_DESC.GRN_CMPID = QUALITYMASTER.QUALITY_cmpid AND GRN_DESC.GRN_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND GRN_DESC.GRN_YEARID = QUALITYMASTER.QUALITY_yearid LEFT OUTER JOIN ITEMMASTER ON GRN_DESC.GRN_ITEMID = ITEMMASTER.item_id AND GRN_DESC.GRN_CMPID = ITEMMASTER.item_cmpid AND GRN_DESC.GRN_LOCATIONID = ITEMMASTER.item_locationid AND GRN_DESC.GRN_YEARID = ITEMMASTER.item_yearid ", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal GRNNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objGRN As New GRN
                objGRN.MdiParent = MDIMain
                objGRN.edit = editval
                objGRN.tempgrnno = GRNNO

                objGRN.temptypename = "G.R.N"
                objGRN.FRMSTRING = FRMSTRING
                objGRN.Show()
                Me.Close()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("GRNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("GRNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\GRN Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "GRN Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "GRN Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and grn.grn_type='G.R.N' and dbo.GRN.GRN_yearid=" & YearId & " order by dbo.GRN.GRN_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class