
Imports System.Windows.Forms
Imports BL
Imports System.IO

Public Class Mfg2Details

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

            fillgrid(" and dbo.MFGMASTER2.MFG_yearid=" & YearId & " GROUP BY MFGMASTER2.MFG_NO, MFGMASTER2.MFG_DATE, MFGMASTER2_DESC.MFG_DESC, FROMPROCESS.PROCESS_NAME, TOPROCESS.PROCESS_NAME, ITEMMASTER.item_name, QUALITYMASTER.QUALITY_name, DESIGNRECIPE.DESIGN_NO, MFGMASTER2.MFG_JOBNO, CONTRACTORMASTER.CONTRACTOR_name, MFGMASTER2.MFG_COLORS,MFGMASTER2_DESC.MFG_DONE, DESIGNRECIPE.DESIGN_LOGO, ISNULL(MFGMASTER2.MFG_WORKER,0), ISNULL(MFGMASTER2.MFG_PRESENT,0), ISNULL(DEPARTMENTMASTER.DEPARTMENT_NAME,'') order by dbo.MFGMASTER2.MFG_no")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search("   MFGMASTER2.MFG_NO AS MFGNO, MFGMASTER2.MFG_DATE AS DATE, MFGMASTER2_DESC.MFG_DESC AS PDATE, FROMPROCESS.PROCESS_NAME AS FROMPROCESS, TOPROCESS.PROCESS_NAME AS TOPROCESS, ITEMMASTER.item_name AS ITEMNAME, QUALITYMASTER.QUALITY_name AS QUALITY, DESIGNRECIPE.DESIGN_NO AS DESIGN, MFGMASTER2.MFG_JOBNO AS JOBNO, CONTRACTORMASTER.CONTRACTOR_name AS CONTRACTOR, MFGMASTER2_DESC.MFG_DONE AS MFGDONE, SUM(MFGMASTER2_DESC.MFG_RECDSAREE) AS SAREE, SUM(MFGMASTER2_DESC.MFG_RECDMTRS) AS MTRS, MFGMASTER2.MFG_COLORS AS COLORS, SUM(MFGMASTER2_DESC.MFG_RECDMTRS*MFGMASTER2.MFG_LABOURRATE) + SUM(MFGMASTER2_DESC.MFG_RECDMTRS*MFGMASTER2.MFG_COLORRATE)+SUM(MFGMASTER2.MFG_TOTALEXTRAAMT)  AS LABOURAMT, CASE WHEN (SUM(MFGMASTER2_DESC.MFG_RECDMTRS*MFGMASTER2.MFG_LABOURRATE) + SUM(MFGMASTER2_DESC.MFG_RECDMTRS*MFGMASTER2.MFG_COLORRATE)+SUM(MFGMASTER2.MFG_TOTALEXTRAAMT)) > 0 THEN (SUM(MFGMASTER2_DESC.MFG_RECDMTRS)/ (SUM(MFGMASTER2_DESC.MFG_RECDMTRS*MFGMASTER2.MFG_LABOURRATE) + SUM(MFGMASTER2_DESC.MFG_RECDMTRS*MFGMASTER2.MFG_COLORRATE)+SUM(MFGMASTER2.MFG_TOTALEXTRAAMT))) ELSE 0 END AS [AVG], ISNULL(MFGMASTER2.MFG_WORKER,0) AS WORKER, ISNULL(MFGMASTER2.MFG_PRESENT,0) AS PRESENT, ISNULL(DEPARTMENTMASTER.DEPARTMENT_NAME,'') AS DEPARTMENT ", "", " MFGMASTER2 LEFT OUTER JOIN ITEMMASTER ON MFGMASTER2.MFG_MERCHANTID = ITEMMASTER.item_id LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER2.MFG_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN DESIGNRECIPE ON MFGMASTER2.MFG_DESIGNID = DESIGNRECIPE.DESIGN_ID LEFT OUTER JOIN PROCESSMASTER AS FROMPROCESS ON MFGMASTER2.MFG_FROMPROCESSID = FROMPROCESS.PROCESS_ID LEFT OUTER JOIN PROCESSMASTER AS TOPROCESS ON MFGMASTER2.MFG_TOPROCESSID = TOPROCESS.PROCESS_ID LEFT OUTER JOIN MFGMASTER2_DESC ON MFGMASTER2.MFG_YEARID = MFGMASTER2_DESC.MFG_YEARID AND MFGMASTER2.MFG_NO = MFGMASTER2_DESC.MFG_NO LEFT OUTER JOIN CONTRACTORMASTER ON MFGMASTER2_DESC.MFG_CONTRACTORID = CONTRACTORMASTER.CONTRACTOR_id LEFT OUTER JOIN DEPARTMENTMASTER ON MFGMASTER2.MFG_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_ID", tepmcondition)
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

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
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

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        Try
            Dim DT As DataTable = gridbilldetails.DataSource
            If e.RowHandle >= 0 Then
                Dim ROW As DataRow = DT.Rows(e.RowHandle)
                'If ROW("MFGDONE") = "TRUE" Then
                '    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                '    e.Appearance.BackColor = Color.Yellow
                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Mfg After Cutting Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Mfg After Cutting Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Mfg After Cutting Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and dbo.MFGMASTER2.MFG_yearid=" & YearId & " GROUP BY MFGMASTER2.MFG_NO, MFGMASTER2.MFG_DATE, MFGMASTER2_DESC.MFG_DESC, FROMPROCESS.PROCESS_NAME, TOPROCESS.PROCESS_NAME, ITEMMASTER.item_name, QUALITYMASTER.QUALITY_name, DESIGNRECIPE.DESIGN_NO, MFGMASTER2.MFG_JOBNO, CONTRACTORMASTER.CONTRACTOR_name, MFGMASTER2.MFG_COLORS,MFGMASTER2_DESC.MFG_DONE, DESIGNRECIPE.DESIGN_LOGO, ISNULL(MFGMASTER2.MFG_WORKER,0), ISNULL(MFGMASTER2.MFG_PRESENT,0), ISNULL(DEPARTMENTMASTER.DEPARTMENT_NAME,'') order by dbo.MFGMASTER2.MFG_no")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If gridbill.GetFocusedRowCellValue("DESIGN") <> "" Then

                'GET THE IMAGE FROM DESIGNRECIPE 
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("DESIGN_LOGO AS LOGO", "", "DESIGNRECIPE", " AND DESIGN_NO = '" & gridbill.GetFocusedRowCellValue("DESIGN") & "' AND DESIGN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = Image.FromStream(New IO.MemoryStream(DirectCast(DT.Rows(0).Item("LOGO"), Byte())))
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class