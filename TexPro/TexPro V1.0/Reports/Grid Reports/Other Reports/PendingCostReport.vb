
Imports System.Windows.Forms
Imports BL
Imports System.IO

Public Class PendingCostReport

    Public edit As Boolean
    Dim TEMPMFGNO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub MfgDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub MfgDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'MFG'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" AND MFGMASTER2_DESC.MFG_COLAMT = 0 and dbo.MFGMASTER2.MFG_CMPID=" & CmpId & " and dbo.MFGMASTER2.MFG_locationid=" & Locationid & " and dbo.MFGMASTER2.MFG_yearid=" & YearId & " GROUP BY MFGMASTER2.MFG_NO, MFGMASTER2.MFG_DATE, MFGMASTER2_DESC.MFG_DESC, FROMPROCESS.PROCESS_NAME, TOPROCESS.PROCESS_NAME, ITEMMASTER.item_name, QUALITYMASTER.QUALITY_name, DESIGNRECIPE.DESIGN_NO, MFGMASTER2.MFG_JOBNO, CONTRACTORMASTER.CONTRACTOR_name, MFGMASTER2.MFG_COLORS,MFGMASTER2_DESC.MFG_DONE, MFGMASTER2_DESC.MFG_RECDSAREE, MFGMASTER2_DESC.MFG_RECDMTRS, ISNULL(DESIGNRECIPE.DESIGN_IMGPATH,'') , ISNULL(DESIGNRECIPE.DESIGN_OURLOCATION,''), MFGMASTER2_DESC.MFG_COLAMT  order by dbo.MFGMASTER2.MFG_no")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("   MFGMASTER2.MFG_NO AS MFGNO, MFGMASTER2.MFG_DATE AS DATE, MFGMASTER2_DESC.MFG_DESC AS PDATE, FROMPROCESS.PROCESS_NAME AS FROMPROCESS, TOPROCESS.PROCESS_NAME AS TOPROCESS, ITEMMASTER.item_name AS ITEMNAME, QUALITYMASTER.QUALITY_name AS QUALITY, DESIGNRECIPE.DESIGN_NO AS DESIGN, MFGMASTER2.MFG_JOBNO AS JOBNO, CONTRACTORMASTER.CONTRACTOR_name AS CONTRACTOR, MFGMASTER2_DESC.MFG_DONE AS MFGDONE, MFGMASTER2_DESC.MFG_RECDSAREE AS SAREE, MFGMASTER2_DESC.MFG_RECDMTRS AS MTRS, MFGMASTER2.MFG_COLORS AS COLORS, SUM(MFGMASTER2_DESC.MFG_RECDMTRS*MFGMASTER2.MFG_LABOURRATE) + SUM(MFGMASTER2_DESC.MFG_RECDMTRS*MFGMASTER2.MFG_COLORRATE)+SUM(MFGMASTER2.MFG_TOTALEXTRAAMT)  AS LABOURAMT, CASE WHEN (SUM(MFGMASTER2_DESC.MFG_RECDMTRS*MFGMASTER2.MFG_LABOURRATE) + SUM(MFGMASTER2_DESC.MFG_RECDMTRS*MFGMASTER2.MFG_COLORRATE)+SUM(MFGMASTER2.MFG_TOTALEXTRAAMT)) > 0 THEN (SUM(MFGMASTER2_DESC.MFG_RECDMTRS)/ (SUM(MFGMASTER2_DESC.MFG_RECDMTRS*MFGMASTER2.MFG_LABOURRATE) + SUM(MFGMASTER2_DESC.MFG_RECDMTRS*MFGMASTER2.MFG_COLORRATE)+SUM(MFGMASTER2.MFG_TOTALEXTRAAMT))) ELSE 0 END AS [AVG], ISNULL(DESIGNRECIPE.DESIGN_IMGPATH,'') AS IMGPATH, ISNULL(DESIGNRECIPE.DESIGN_OURLOCATION,'') AS OURLOCATION, 0 AS [AVG] ", "", " MFGMASTER2 LEFT OUTER JOIN ITEMMASTER ON MFGMASTER2.MFG_YEARID = ITEMMASTER.item_yearid AND MFGMASTER2.MFG_LOCATIONID = ITEMMASTER.item_locationid AND MFGMASTER2.MFG_CMPID = ITEMMASTER.item_cmpid AND MFGMASTER2.MFG_MERCHANTID = ITEMMASTER.item_id LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER2.MFG_YEARID = QUALITYMASTER.QUALITY_yearid AND MFGMASTER2.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND MFGMASTER2.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER2.MFG_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN DESIGNRECIPE ON MFGMASTER2.MFG_YEARID = DESIGNRECIPE.DESIGN_YEARID AND MFGMASTER2.MFG_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND MFGMASTER2.MFG_CMPID = DESIGNRECIPE.DESIGN_CMPID AND MFGMASTER2.MFG_DESIGNID = DESIGNRECIPE.DESIGN_ID LEFT OUTER JOIN PROCESSMASTER AS FROMPROCESS ON MFGMASTER2.MFG_FROMPROCESSID = FROMPROCESS.PROCESS_ID AND MFGMASTER2.MFG_CMPID = FROMPROCESS.PROCESS_CMPID AND MFGMASTER2.MFG_LOCATIONID = FROMPROCESS.PROCESS_LOCATIONID AND MFGMASTER2.MFG_YEARID = FROMPROCESS.PROCESS_YEARID LEFT OUTER JOIN PROCESSMASTER AS TOPROCESS ON MFGMASTER2.MFG_YEARID = TOPROCESS.PROCESS_YEARID AND MFGMASTER2.MFG_LOCATIONID = TOPROCESS.PROCESS_LOCATIONID AND MFGMASTER2.MFG_CMPID = TOPROCESS.PROCESS_CMPID AND MFGMASTER2.MFG_TOPROCESSID = TOPROCESS.PROCESS_ID LEFT OUTER JOIN MFGMASTER2_DESC ON MFGMASTER2.MFG_YEARID = MFGMASTER2_DESC.MFG_YEARID AND MFGMASTER2.MFG_LOCATIONID = MFGMASTER2_DESC.MFG_LOCATIONID AND MFGMASTER2.MFG_CMPID = MFGMASTER2_DESC.MFG_CMPID AND MFGMASTER2.MFG_NO = MFGMASTER2_DESC.MFG_NO LEFT OUTER JOIN CONTRACTORMASTER ON MFGMASTER2_DESC.MFG_YEARID = CONTRACTORMASTER.CONTRACTOR_yearid AND MFGMASTER2_DESC.MFG_LOCATIONID = CONTRACTORMASTER.CONTRACTOR_locationid AND MFGMASTER2_DESC.MFG_CMPID = CONTRACTORMASTER.CONTRACTOR_cmpid AND MFGMASTER2_DESC.MFG_CONTRACTORID = CONTRACTORMASTER.CONTRACTOR_id ", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal MFGNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJMFG As New Mfg2
                OBJMFG.MdiParent = MDIMain
                OBJMFG.edit = editval
                OBJMFG.TEMPMFGNO = MFGNO
                OBJMFG.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("MFGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("MFGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLEXCEL.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Pending Cost Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Pending Cost Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Pending Cost Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" AND MFGMASTER2_DESC.MFG_COLAMT = 0 and dbo.MFGMASTER2.MFG_CMPID=" & CmpId & " and dbo.MFGMASTER2.MFG_locationid=" & Locationid & " and dbo.MFGMASTER2.MFG_yearid=" & YearId & " GROUP BY MFGMASTER2.MFG_NO, MFGMASTER2.MFG_DATE, MFGMASTER2_DESC.MFG_DESC, FROMPROCESS.PROCESS_NAME, TOPROCESS.PROCESS_NAME, ITEMMASTER.item_name, MFGMASTER2_DESC.MFG_RECDSAREE, MFGMASTER2_DESC.MFG_RECDMTRS, QUALITYMASTER.QUALITY_name, DESIGNRECIPE.DESIGN_NO, MFGMASTER2.MFG_JOBNO, CONTRACTORMASTER.CONTRACTOR_name, MFGMASTER2.MFG_COLORS,MFGMASTER2_DESC.MFG_DONE, ISNULL(DESIGNRECIPE.DESIGN_IMGPATH,''), ISNULL(DESIGNRECIPE.DESIGN_OURLOCATION,''), MFGMASTER2_DESC.MFG_COLAMT  order by dbo.MFGMASTER2.MFG_no")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class