
Imports System.Windows.Forms
Imports BL

Public Class BaleOpenDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub MfgDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub MfgDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PACKING SLIP'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and DBO.BALEOPEN.BO_CMPID=" & CmpId & " and DBO.BALEOPEN.BO_locationid=" & Locationid & " and DBO.BALEOPEN.BO_yearid=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" BALEOPEN.BO_NO AS SRNO, BALEOPEN.BO_DATE AS DATE, BALEOPEN.BO_BALENO AS PSNO, BALEOPEN.BO_TYPE AS TYPE, ITEMMASTER.item_name AS MERCHANT, LEDGERS.Acc_cmpname AS NAME, BALEOPEN.BO_REMARKS AS REMARKS ", "", " BALEOPEN LEFT OUTER JOIN ITEMMASTER ON BALEOPEN.BO_MERCHANTID = ITEMMASTER.item_id AND BALEOPEN.BO_CMPID = ITEMMASTER.item_cmpid AND BALEOPEN.BO_LOCATIONID = ITEMMASTER.item_locationid AND BALEOPEN.BO_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN LEDGERS ON BALEOPEN.BO_LEDGERID = LEDGERS.Acc_id AND BALEOPEN.BO_CMPID = LEDGERS.Acc_cmpid AND BALEOPEN.BO_LOCATIONID = LEDGERS.Acc_locationid AND BALEOPEN.BO_YEARID = LEDGERS.Acc_yearid  ", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
              showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Bale Open Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Bale Open Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Bale Open Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
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

    Sub showform(ByVal editval As Boolean, ByVal BONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJBO As New BaleOpen
                OBJBO.MdiParent = MDIMain
                OBJBO.EDIT = editval
                OBJBO.TEMPBONO = BONO
                OBJBO.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class