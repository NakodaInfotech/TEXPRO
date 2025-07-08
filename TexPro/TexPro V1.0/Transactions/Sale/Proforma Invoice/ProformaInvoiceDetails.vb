
Imports BL

Public Class ProformaInvoiceDetails

    Public edit As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ProformaInvoiceDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub PROFORMAINVOICEMASTERDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PROFORMA'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.PROFORMAINVOICEMASTER.INVOICE_CMPID=" & CmpId & " and dbo.PROFORMAINVOICEMASTER.INVOICE_locationid=" & Locationid & " and dbo.PROFORMAINVOICEMASTER.INVOICE_yearid=" & YearId & " order by dbo.PROFORMAINVOICEMASTER.INVOICE_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("   PROFORMAINVOICEMASTER.INVOICE_no AS SRNO, PROFORMAINVOICEMASTER.INVOICE_date AS DATE, LEDGERS.Acc_cmpname AS NAME,  ADDRESSMASTER.ADDRESS_ALIAS AS CONSIGNEE, LEDGERS_1.Acc_cmpname AS AGENT, PROFORMAINVOICEMASTER.INVOICE_totalpcs AS TOTALPCS, (PROFORMAINVOICEMASTER.INVOICE_TOTALMTRS) AS TOTALMTRS, PROFORMAINVOICEMASTER.INVOICE_TOTALAMT AS TOTALAMT ", "", " PROFORMAINVOICEMASTER LEFT OUTER JOIN LEDGERS ON PROFORMAINVOICEMASTER.INVOICE_ledgerid = LEDGERS.Acc_id AND PROFORMAINVOICEMASTER.INVOICE_CMPID = LEDGERS.Acc_cmpid AND PROFORMAINVOICEMASTER.INVOICE_LOCATIONID = LEDGERS.Acc_locationid AND PROFORMAINVOICEMASTER.INVOICE_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON PROFORMAINVOICEMASTER.INVOICE_AGENTID = LEDGERS_1.Acc_id AND PROFORMAINVOICEMASTER.INVOICE_CMPID = LEDGERS_1.Acc_cmpid AND PROFORMAINVOICEMASTER.INVOICE_LOCATIONID = LEDGERS_1.Acc_locationid AND PROFORMAINVOICEMASTER.INVOICE_YEARID = LEDGERS_1.Acc_yearid LEFT OUTER JOIN ADDRESSMASTER ON PROFORMAINVOICEMASTER.INVOICE_CONSIGNEEID = ADDRESSMASTER.ADDRESS_ID AND PROFORMAINVOICEMASTER.INVOICE_CMPID = ADDRESSMASTER.ADDRESS_cmpid AND PROFORMAINVOICEMASTER.INVOICE_LOCATIONID = ADDRESSMASTER.ADDRESS_locationid AND PROFORMAINVOICEMASTER.INVOICE_YEARID = ADDRESSMASTER.ADDRESS_yearid ", tepmcondition)
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal INVOICENO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJINVOICE As New ProformaInvoice
                OBJINVOICE.MdiParent = MDIMain
                OBJINVOICE.edit = editval
                OBJINVOICE.tempinvoiceno = INVOICENO
                OBJINVOICE.Show()
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
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\Proforma Invoice Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Proforma Invoice Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Proforma Invoice Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and dbo.PROFORMAINVOICEMASTER.INVOICE_CMPID=" & CmpId & " and dbo.PROFORMAINVOICEMASTER.INVOICE_locationid=" & Locationid & " and dbo.PROFORMAINVOICEMASTER.INVOICE_yearid=" & YearId & " order by dbo.PROFORMAINVOICEMASTER.INVOICE_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class