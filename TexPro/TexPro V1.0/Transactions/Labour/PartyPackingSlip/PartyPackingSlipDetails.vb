Imports BL
Imports System.Windows.Forms
Public Class PartyPackingSlipDetails

    Public edit As Boolean
    Dim TEMPPPSNO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PRequisitionDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub PRequisitionDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        fillgrid(" and dbo.PARTYPACKINGSLIP.PPS_CMPID=" & CmpId & " and dbo.PARTYPACKINGSLIP.PPS_locationid=" & Locationid & " and dbo.PARTYPACKINGSLIP.PPS_yearid=" & YearId & " order by dbo.PARTYPACKINGSLIP.PPS_NO ")
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" PARTYPACKINGSLIP.PPS_NO AS SRNO,  ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS_1.Acc_cmpname, '') AS TRANSNAME, PARTYPACKINGSLIP.PPS_TOTALPCS AS TOTALPCS, PARTYPACKINGSLIP.PPS_TOTALMTRS AS TOTALMTRS, ISNULL(PARTYPACKINGSLIP.PPS_lrno, '') AS LRNO, PARTYPACKINGSLIP.PPS_lrdate AS LRDATE, ISNULL(PARTYPACKINGSLIP.PPS_remarks, '') AS REMARKS, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN ", "", "     PARTYPACKINGSLIP LEFT OUTER JOIN GODOWNMASTER ON PARTYPACKINGSLIP.PPS_GODOWNid = GODOWNMASTER.GODOWN_id AND PARTYPACKINGSLIP.PPS_cmpid = GODOWNMASTER.GODOWN_cmpid AND PARTYPACKINGSLIP.PPS_locationid = GODOWNMASTER.GODOWN_locationid AND PARTYPACKINGSLIP.PPS_yearid = GODOWNMASTER.GODOWN_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON PARTYPACKINGSLIP.PPS_transledgerid = LEDGERS_1.Acc_id AND PARTYPACKINGSLIP.PPS_cmpid = LEDGERS_1.Acc_cmpid AND PARTYPACKINGSLIP.PPS_locationid = LEDGERS_1.Acc_locationid AND PARTYPACKINGSLIP.PPS_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS ON PARTYPACKINGSLIP.PPS_cmpid = LEDGERS.Acc_cmpid AND PARTYPACKINGSLIP.PPS_locationid = LEDGERS.Acc_locationid AND PARTYPACKINGSLIP.PPS_yearid = LEDGERS.Acc_yearid AND PARTYPACKINGSLIP.PPS_ledgerid = LEDGERS.Acc_id ", tepmcondition)
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal PONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New PartyPackingSlip
                objREQ.MdiParent = MDIMain
                objREQ.edit = editval
                objREQ.tempppsno = PONO
                objREQ.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            'If USERADD = False Then
            '    MsgBox("Insufficient Rights")
            '    Exit Sub
            'End If
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

            Dim PATH As String = Application.StartupPath & "\PARTYPACKINGSLIP Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "PARTYPACKINGSLIP Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "PARTYPACKINGSLIP Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class