
Imports BL
Imports System.Windows.Forms

Public Class gatepassdetails

    Public edit As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
   
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GRNDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub GRNDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GATE PASS'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.GATEPASS.GP_yearid=" & YearId & "  ORDER BY  SRNO, GATEPASS_DESC.GP_GRIDSRNO ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("  GATEPASS.GP_no AS SRNO, GATEPASS.GP_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(TRANSLEDGERS.ACC_CMPNAME,'') AS TRANSNAME, GATEPASS_DESC.GP_LOTNO AS LOTNO, GATEPASS_DESC.GP_DONO AS DONO, GATEPASS_DESC.GP_DODATE AS DODATE, GATEPASS_DESC.GP_DAYS AS DAYS, GATEPASS_DESC.GP_REJPCS AS REJPCS, ISNULL(GATEPASS_DESC.GP_REJMTRS,0) AS REJMTRS, GATEPASS_DESC.GP_AMT AS AMT, GATEPASS_DESC.GP_CHKAMT AS CHKAMT ", "", "  GATEPASS INNER JOIN GATEPASS_DESC ON GATEPASS.GP_no = GATEPASS_DESC.GP_no AND GATEPASS.GP_yearid = GATEPASS_DESC.GP_yearid INNER JOIN LEDGERS ON GATEPASS_DESC.GP_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GP_TRANSLEDGERID = TRANSLEDGERS.ACC_ID", tepmcondition)
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
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
                Dim objCHECKINGMASTER As New gatePass
                objCHECKINGMASTER.MdiParent = MDIMain
                objCHECKINGMASTER.edit = editval
                objCHECKINGMASTER.tempgpno = GRNNO
                objCHECKINGMASTER.Show()
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

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\GATEPASS Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "GATEPASS Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "GATEPASS Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class