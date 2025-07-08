
Imports BL

Public Class ContractorRate

    Public WHERE As String = ""

    Private Sub ContractorRate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            dt = objclsCMST.search(" CONTRACTOR,MERCHANT, DESIGNNO, COLORS, MTRS, RATE, ROUND((RATE * MTRS),2) AS AMT,1 AS HELPERS, ROUND((RATE * MTRS),2) AS COST ", "", " (SELECT CONTRACTORMASTER.CONTRACTOR_name AS CONTRACTOR, COLORRATEMASTER.CR_NO AS COLORS, SUM(MFGMASTER2_DESC.MFG_RECDMTRS) AS MTRS, COLORRATEMASTER.CR_RATE AS RATE, PROCESSMASTER.PROCESS_NAME AS PROCESSNAME, ITEMMASTER.item_name AS MERCHANT, DESIGNRECIPE.DESIGN_NO AS DESIGNNO FROM MFGMASTER2 INNER JOIN MFGMASTER2_DESC ON MFGMASTER2.MFG_CMPID = MFGMASTER2_DESC.MFG_CMPID AND MFGMASTER2.MFG_LOCATIONID = MFGMASTER2_DESC.MFG_LOCATIONID AND MFGMASTER2.MFG_YEARID = MFGMASTER2_DESC.MFG_YEARID AND MFGMASTER2.MFG_NO = MFGMASTER2_DESC.MFG_NO INNER JOIN CONTRACTORMASTER ON MFGMASTER2_DESC.MFG_CONTRACTORID = CONTRACTORMASTER.CONTRACTOR_id AND MFGMASTER2_DESC.MFG_YEARID = CONTRACTORMASTER.CONTRACTOR_yearid AND MFGMASTER2_DESC.MFG_LOCATIONID = CONTRACTORMASTER.CONTRACTOR_locationid AND MFGMASTER2_DESC.MFG_CMPID = CONTRACTORMASTER.CONTRACTOR_cmpid INNER JOIN COLORRATEMASTER ON MFGMASTER2.MFG_COLORS = COLORRATEMASTER.CR_NO AND MFGMASTER2.MFG_TOPROCESSID = COLORRATEMASTER.CR_PROCESSID AND MFGMASTER2.MFG_YEARID = COLORRATEMASTER.CR_yearid INNER JOIN PROCESSMASTER ON MFGMASTER2.MFG_TOPROCESSID = PROCESSMASTER.PROCESS_ID INNER JOIN ITEMMASTER ON MFGMASTER2.MFG_MERCHANTID = ITEMMASTER.item_id INNER JOIN DESIGNRECIPE ON MFGMASTER2.MFG_DESIGNID = DESIGNRECIPE.DESIGN_ID  WHERE " & WHERECLAUSE & " GROUP BY CONTRACTORMASTER.CONTRACTOR_name, COLORRATEMASTER.CR_NO, COLORRATEMASTER.CR_RATE, PROCESSMASTER.PROCESS_NAME, PROCESSMASTER.PROCESS_NAME, ITEMMASTER.item_name, DESIGNRECIPE.DESIGN_NO) AS T ", " ORDER BY  COLORS ")
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

    Private Sub ContractorRate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid(WHERE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gridbill.CellValueChanged
        Try
            If IsDBNull(e.Value) = True Then Exit Sub
            If Val(e.Value) > 0 Then
                Dim ROW As DataRow = gridbill.GetFocusedDataRow
                If Val(ROW("HELPERS")) > 0 Then ROW("COST") = Format(Val(ROW("AMT")) / Val(ROW("HELPERS")), "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class