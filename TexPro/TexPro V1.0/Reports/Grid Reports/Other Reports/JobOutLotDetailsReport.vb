
Imports BL

Public Class JobOutLotDetailsReport

    Private Sub JobOutLotDetailsReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobOutLotDetailsReport_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" JOBOUT.JO_no AS JONO, JOBOUT.JO_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ITEMMASTER.ITEM_name AS ITEM, PACKINGSLIP_DESC_JOB.PS_NO AS BALENO, PACKINGSLIP_DESC_JOB.PS_LOTNO AS LOTNO, SUM(PACKINGSLIP_DESC_JOB.PS_MTRS) AS MTRS, SUM(PACKINGSLIP_DESC_JOB.PS_TOTAL) AS PCS ", "", " JOBOUT INNER JOIN JOBOUT_DESC ON JOBOUT.JO_no = JOBOUT_DESC.JO_NO AND JOBOUT.JO_yearid = JOBOUT_DESC.JO_YEARID INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON JOBOUT.JO_MERCHANTID= ITEMMASTER.ITEM_id INNER JOIN PACKINGSLIP_JOB ON JOBOUT_DESC.JO_BALENO = PACKINGSLIP_JOB.PS_NO AND JOBOUT_DESC.JO_YEARID = PACKINGSLIP_JOB.PS_YEARID INNER JOIN PACKINGSLIP_DESC_JOB ON PACKINGSLIP_JOB.PS_NO = PACKINGSLIP_DESC_JOB.PS_NO AND PACKINGSLIP_JOB.PS_YEARID = PACKINGSLIP_DESC_JOB.PS_YEARID ", " and JOBOUT.JO_yearid = " & YearId & " GROUP BY JOBOUT.JO_no, JOBOUT.JO_date, LEDGERS.Acc_cmpname, ITEMMASTER.ITEM_name, PACKINGSLIP_DESC_JOB.PS_NO, PACKINGSLIP_DESC_JOB.PS_LOTNO ")
            gridbilldetails.DataSource = DT
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Job Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Job Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Job Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class