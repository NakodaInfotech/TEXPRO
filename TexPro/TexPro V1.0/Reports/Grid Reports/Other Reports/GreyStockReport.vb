
Imports BL

Public Class GreyStockReport

    Public WHERE As String = ""

    Private Sub GreyStockReport_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" CONTRACTOR,COLORS, MTRS, RATE, ROUND((RATE * MTRS),2) AS AMT ", "", " (SELECT CONTRACTORMASTER.CONTRACTOR_name AS CONTRACTOR, COLORRATEMASTER.CR_NO AS COLORS, SUM(MFGMASTER2_DESC.MFG_RECDMTRS) AS MTRS, COLORRATEMASTER.CR_RATE AS RATE FROM MFGMASTER2 INNER JOIN MFGMASTER2_DESC ON MFGMASTER2.MFG_CMPID = MFGMASTER2_DESC.MFG_CMPID AND MFGMASTER2.MFG_LOCATIONID = MFGMASTER2_DESC.MFG_LOCATIONID AND MFGMASTER2.MFG_YEARID = MFGMASTER2_DESC.MFG_YEARID AND MFGMASTER2.MFG_NO = MFGMASTER2_DESC.MFG_NO INNER JOIN CONTRACTORMASTER ON MFGMASTER2_DESC.MFG_CONTRACTORID = CONTRACTORMASTER.CONTRACTOR_id AND MFGMASTER2_DESC.MFG_YEARID = CONTRACTORMASTER.CONTRACTOR_yearid AND MFGMASTER2_DESC.MFG_LOCATIONID = CONTRACTORMASTER.CONTRACTOR_locationid AND MFGMASTER2_DESC.MFG_CMPID = CONTRACTORMASTER.CONTRACTOR_cmpid INNER JOIN COLORRATEMASTER ON MFGMASTER2.MFG_COLORS = COLORRATEMASTER.CR_NO WHERE " & WHERECLAUSE & " GROUP BY CONTRACTORMASTER.CONTRACTOR_name, COLORRATEMASTER.CR_NO, COLORRATEMASTER.CR_RATE) AS T ", " ORDER BY  COLORS ")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then gridbill.FocusedRowHandle = gridbill.RowCount - 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Contractor Rate Chart.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Contractor Rate Chart"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Contractor Rate Chart", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GreyStockReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid(WHERE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class