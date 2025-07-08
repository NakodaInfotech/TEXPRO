
Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class MfgDetails

    Public edit As Boolean
    Dim temppreqno As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public WHERECLAUSE As String = ""

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

            fillgrid(" AND MFGMASTER.MFG_yearid=" & YearId & WHERECLAUSE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" MFGMASTER.MFG_NO AS MFGNO, MFGMASTER.MFG_DATE AS DATE, FROMPROCESS.PROCESS_NAME AS FROMPROCESS, TOPROCESS.PROCESS_NAME AS TOPROCESS, ITEMMASTER.item_name AS ITEMNAME,  QUALITYMASTER.QUALITY_name AS QUALITY, MFGMASTER.MFG_REED AS REED, MFGMASTER.MFG_PICK AS PICK, COLORMASTER.COLOR_name AS COLOR, SUM(MFGMASTER_DESC.MFG_INPCS) AS TOTALPCS,  SUM(MFGMASTER_DESC.MFG_INMTRS) AS TOTALMTRS, SUM(MFGMASTER_DESC.MFG_RECDMTRS) AS RECDMTRS, MFGMASTER.MFG_TOTALDIFF AS DIFF, MFGMASTER.MFG_TOTALWT AS WT,  ISNULL(ROUND(SUM(MFGMASTER_DESC.MFG_INMTRS) * GREYDETAIL_VIEW.WT, 3), 0) AS TOTALWTMTRS, MFGMASTER_DESC.MFG_DONE AS MFGDONE, MFGMASTER_DESC.MFG_LOTNO AS LOTNO,  ISNULL(MFGMASTER.MFG_PRGNO, '') AS PRGNO, ISNULL(DYEINGRECIPE.DYEING_NO, '') AS CHARTNO, ISNULL(COLORMASTER1.COLOR_name, '') AS COLORNAME, ISNULL(MERCHANTMASTER.item_name, '')  AS MERCHANT, ISNULL(MFGMASTER.MFG_SHIFT, 'Day') AS SHIFT, ISNULL(MFGMASTER.MFG_DEGREE, '') AS DEGREE, ISNULL(MFGMASTER.MFG_REMARKS, '') AS REMARKS,  ISNULL(CONTRACTORMASTER.CONTRACTOR_name, '') AS CONTRACTOR, ISNULL(USERMASTER.User_Name, '') AS MODIFIEDBY ", "", " MFGMASTER INNER JOIN MFGMASTER_DESC ON MFGMASTER.MFG_NO = MFGMASTER_DESC.MFG_NO AND MFGMASTER.MFG_YEARID = MFGMASTER_DESC.MFG_YEARID LEFT OUTER JOIN COLORMASTER AS COLORMASTER1 ON MFGMASTER.MFG_SHADEID = COLORMASTER1.COLOR_id LEFT OUTER JOIN DYEINGRECIPE ON MFGMASTER.MFG_CHARTID = DYEINGRECIPE.DYEING_ID LEFT OUTER JOIN ITEMMASTER AS MERCHANTMASTER ON MFGMASTER.MFG_MERCHANTID = MERCHANTMASTER.item_id LEFT OUTER JOIN ITEMMASTER ON MFGMASTER.MFG_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER AS COLORMASTER ON MFGMASTER_DESC.MFG_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN PROCESSMASTER AS FROMPROCESS ON MFGMASTER.MFG_FROMPROCESSID = FROMPROCESS.PROCESS_ID LEFT OUTER JOIN PROCESSMASTER AS TOPROCESS ON MFGMASTER.MFG_TOPROCESSID = TOPROCESS.PROCESS_ID LEFT OUTER JOIN CONTRACTORMASTER ON MFGMASTER.MFG_CONTRACTORID = CONTRACTORMASTER.CONTRACTOR_id LEFT OUTER JOIN (SELECT DISTINCT LOTNO, WT, YEARID FROM            GREYDETAIL_VIEW AS GREYDETAIL_VIEW_1) AS GREYDETAIL_VIEW ON MFGMASTER_DESC.MFG_LOTNO = GREYDETAIL_VIEW.LOTNO AND  MFGMASTER_DESC.MFG_YEARID = GREYDETAIL_VIEW.YEARID LEFT OUTER JOIN USERMASTER ON MFGMASTER.MFG_MODIFIEDBY = USERMASTER.User_id ", tepmcondition & " GROUP BY MFGMASTER.MFG_NO , MFGMASTER.MFG_DATE , FROMPROCESS.PROCESS_NAME , TOPROCESS.PROCESS_NAME , ITEMMASTER.item_name , QUALITYMASTER.QUALITY_name , MFGMASTER.MFG_REED , MFGMASTER.MFG_PICK , COLORMASTER.COLOR_name , MFGMASTER.MFG_TOTALPCS , MFGMASTER.MFG_TOTALDIFF , MFGMASTER.MFG_TOTALWT , MFGMASTER_DESC.MFG_DONE ,MFGMASTER_DESC.MFG_LOTNO , ISNULL(MFGMASTER.MFG_PRGNO, ''), ISNULL(DYEINGRECIPE.DYEING_NO, ''), ISNULL(COLORMASTER1.COLOR_name, ''), ISNULL(MERCHANTMASTER.ITEM_NAME,''), ISNULL(MFG_SHIFT,'Day'), ISNULL(MFG_DEGREE,''), ISNULL(MFG_REMARKS,''), ISNULL(CONTRACTORMASTER.CONTRACTOR_NAME,''), GREYDETAIL_VIEW.WT, ISNULL(USERMASTER.User_Name, '') ORDER BY MFGMASTER.MFG_NO")
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
                Dim OBJMFG As New Mfg
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

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("MFGDONE")) = "Checked" Then
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

            Dim PATH As String = Application.StartupPath & "\Mfg Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Mfg Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Mfg Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        fillgrid(" and dbo.MFGMASTER.MFG_yearid=" & YearId)
    End Sub

    Private Sub ToolStripdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripdelete.Click
        Try
            DELETE(False, gridbill.GetFocusedRowCellValue("MFGNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DELETE(ByVal EDIT As Boolean, ByVal TEMPMFGNO As Integer)
        Dim IntResult As Integer
        Try

            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTTABLE As New DataTable
                DTTABLE = getmax(" MFG_done ", " MFGMASTER_DESC", "  AND MFG_done=1 and MFG_no=" & TEMPMFGNO & " AND MFG_cmpid=" & CmpId & " AND MFG_LOCATIONID = " & Locationid & " AND MFG_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then
                    MsgBox("PROCESS Raised Delete PROCESS First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim TEMPMSG As Integer = MsgBox("Delete MFG?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TEMPMFGNO)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)

                    Dim OBJMFG As New ClsMfg()
                    OBJMFG.alParaval = alParaval
                    IntResult = OBJMFG.Delete()
                    MsgBox("MFG Deleted")
                    fillgrid(" and dbo.MFGMASTER.MFG_CMPID=" & CmpId & " and dbo.MFGMASTER.MFG_locationid=" & Locationid & " and dbo.MFGMASTER.MFG_yearid=" & YearId)

                    EDIT = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLCONSUME_Click(sender As Object, e As EventArgs) Handles TOOLCONSUME.Click
        Try
            Dim OBJCONSUME As New MfgConsumptionDetails
            OBJCONSUME.MdiParent = MDIMain
            OBJCONSUME.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLADJUSTMENT.Click
        Try
            Dim IntResult As Integer
            Dim TEMPMSG As Integer = MsgBox("Lot Adjust?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then

                Dim alParaval As New ArrayList
                alParaval.Add(TXTLOTNO.Text)
                alParaval.Add(CmpId)
                alParaval.Add(Locationid)
                alParaval.Add(YearId)

                Dim OBJMFG As New ClsMfg()
                OBJMFG.alParaval = alParaval
                IntResult = OBJMFG.adjustment()
                MsgBox("Lot Adjusted")

                fillgrid(" and dbo.MFGMASTER.MFG_CMPID=" & CmpId & " and dbo.MFGMASTER.MFG_locationid=" & Locationid & " and dbo.MFGMASTER.MFG_yearid=" & YearId)

                edit = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTLOTNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTLOTNO.Validating
        Try
            If TXTLOTNO.Text <> "" Then
                fillgrid(" AND MFGMASTER_DESC.MFG_LOTNO=" & TXTLOTNO.Text & " and dbo.MFGMASTER.MFG_CMPID=" & CmpId & " and dbo.MFGMASTER.MFG_locationid=" & Locationid & " and dbo.MFGMASTER.MFG_yearid=" & YearId)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MfgDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "MONOGRAM" Then GWT.Visible = False Else GTOTALWTMTRS.Visible = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class