
Imports BL
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class SaleReturnDetail
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub CMDEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEIXT.Click
        Me.Close()
    End Sub

    Private Sub SaleReturnDetail_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                ' showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                'cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaleReturnDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE RETURN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.SALERETURN.SALE_CMPID=" & CmpId & " and dbo.SALERETURN.SALE_locationid=" & Locationid & " and dbo.SALERETURN.SALE_yearid=" & YearId)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" SALERETURN.SALE_NO AS SRNO, SALERETURN.SALE_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, SALERETURN.SALE_CHALLANID AS CHALLANNO,  SALERETURN.SALE_CHALLANDATE AS CHALLANDATE, SALERETURN.SALE_TOTALPCS AS TOTALPCS, SALERETURN.SALE_TOTALMTRS AS TOTALMTRS, SALERETURN.SALE_REMARKS AS REMARKS ", "", " SALERETURN INNER JOIN LEDGERS ON SALERETURN.SALE_NAMEID = LEDGERS.Acc_id AND SALERETURN.SALE_CMPID = LEDGERS.Acc_cmpid AND SALERETURN.SALE_LOCATIONID = LEDGERS.Acc_locationid AND SALERETURN.SALE_YEARID = LEDGERS.Acc_yearid", tepmcondition)
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal RETURNNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objCHECKINGMASTER As New SalesReturn
                objCHECKINGMASTER.MdiParent = MDIMain
                objCHECKINGMASTER.edit = editval
                objCHECKINGMASTER.TEMPRETURNNO = RETURNNO
                objCHECKINGMASTER.Show()
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

    Private Sub gridbilldetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Sale Return Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Sale Return Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sale Return Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class