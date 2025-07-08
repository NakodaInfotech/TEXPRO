
Imports BL

Public Class MfgConsumptionDetails

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

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("  MFGMASTER.MFG_NO AS MFGNO, MFGMASTER.MFG_DATE AS DATE, UPPER(ISNULL(CONTRACTORMASTER.CONTRACTOR_name, '')) AS NAME, ITEMMASTER.item_name AS ITEMNAME, DEPARTMENTMASTER.DEPARTMENT_name AS DEPARTMENT, MFGMASTER_CONSUMED.MFG_DEFQTY AS DEFQTY, MFGMASTER_CONSUMED.MFG_ACTQTY AS ACTQTY, MFGMASTER_CONSUMED.MFG_DEFRATE AS DEFRATE, MFGMASTER_CONSUMED.MFG_ACTRATE AS ACTRATE, UNITMASTER.unit_abbr AS UNIT  ", "", "  MFGMASTER INNER JOIN MFGMASTER_CONSUMED ON MFGMASTER.MFG_NO = MFGMASTER_CONSUMED.MFG_NO AND MFGMASTER.MFG_YEARID = MFGMASTER_CONSUMED.MFG_YEARID INNER JOIN ITEMMASTER ON MFGMASTER_CONSUMED.MFG_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN DEPARTMENTMASTER ON ITEMMASTER.item_departmentid = DEPARTMENTMASTER.DEPARTMENT_id LEFT OUTER JOIN UNITMASTER ON MFGMASTER_CONSUMED.MFG_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN CONTRACTORMASTER ON MFGMASTER.MFG_CONTRACTORID = CONTRACTORMASTER.CONTRACTOR_id  ", " AND MFGMASTER.MFG_YEARID = " & YearId & " ORDER BY MFGMASTER.MFG_NO, MFGMASTER_CONSUMED.MFG_SRNO")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM(ByVal editval As Boolean, ByVal MFGNO As Integer)
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
        FILLGRID()
    End Sub

End Class