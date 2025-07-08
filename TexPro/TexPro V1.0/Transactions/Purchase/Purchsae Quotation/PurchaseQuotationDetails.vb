
Imports BL
Imports System.Windows.Forms

Public Class PurchaseQuotationDetails

    Public edit As Boolean
    Dim temppreqno As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PurchaseQuotationDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub PurchaseQuotationDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE QUOTATION'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.PURCHASEQUOTATION.QUOTATION_CMPID=" & CmpId & " and dbo.PURCHASEQUOTATION.QUOTATION_locationid=" & Locationid & " and dbo.PURCHASEQUOTATION.QUOTATION_yearid=" & YearId & " order by dbo.PURCHASEQUOTATION.QUOTATION_no, PURCHASEQUOTATION_DESC.QUOTATION_GRIDSRNO ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" PURCHASEQUOTATION.QUOTATION_NO AS SRNO, PURCHASEQUOTATION.quotation_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name,'') AS QUALITY, ISNULL(PURCHASEQUOTATION_DESC.QUOTATION_REED,'') AS REED, ISNULL(PURCHASEQUOTATION_DESC.QUOTATION_PICK,'') AS PICK, ISNULL(COLORMASTER.COLOR_name,'') AS COLOR, PURCHASEQUOTATION_DESC.QUOTATION_QTY AS QTY, ISNULL(UNITMASTER.unit_abbr,'') AS UNIT, PURCHASEQUOTATION_DESC.QUOTATION_RATE AS RATE, PURCHASEQUOTATION_DESC.QUOTATION_AMT AS AMT ", "", "  LEDGERS INNER JOIN PURCHASEQUOTATION ON LEDGERS.Acc_id = PURCHASEQUOTATION.quotation_ledgerid AND LEDGERS.Acc_cmpid = PURCHASEQUOTATION.quotation_cmpid AND LEDGERS.Acc_locationid = PURCHASEQUOTATION.quotation_locationid AND LEDGERS.Acc_yearid = PURCHASEQUOTATION.quotation_yearid INNER JOIN PURCHASEQUOTATION_DESC ON PURCHASEQUOTATION.QUOTATION_NO = PURCHASEQUOTATION_DESC.QUOTATION_NO AND PURCHASEQUOTATION.quotation_cmpid = PURCHASEQUOTATION_DESC.QUOTATION_CMPID AND PURCHASEQUOTATION.quotation_locationid = PURCHASEQUOTATION_DESC.QUOTATION_LOCATIONID AND PURCHASEQUOTATION.quotation_yearid = PURCHASEQUOTATION_DESC.QUOTATION_YEARID LEFT OUTER JOIN UNITMASTER ON PURCHASEQUOTATION_DESC.QUOTATION_YEARID = UNITMASTER.unit_yearid AND PURCHASEQUOTATION_DESC.QUOTATION_LOCATIONID = UNITMASTER.unit_locationid AND PURCHASEQUOTATION_DESC.QUOTATION_CMPID = UNITMASTER.unit_cmpid AND PURCHASEQUOTATION_DESC.QUOTATION_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN COLORMASTER ON PURCHASEQUOTATION_DESC.QUOTATION_YEARID = COLORMASTER.COLOR_yearid AND PURCHASEQUOTATION_DESC.QUOTATION_LOCATIONID = COLORMASTER.COLOR_locationid AND PURCHASEQUOTATION_DESC.QUOTATION_CMPID = COLORMASTER.COLOR_cmpid AND PURCHASEQUOTATION_DESC.QUOTATION_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN QUALITYMASTER ON PURCHASEQUOTATION_DESC.QUOTATION_YEARID = QUALITYMASTER.QUALITY_yearid AND PURCHASEQUOTATION_DESC.QUOTATION_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND PURCHASEQUOTATION_DESC.QUOTATION_CMPID = QUALITYMASTER.QUALITY_cmpid AND PURCHASEQUOTATION_DESC.QUOTATION_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN ITEMMASTER ON PURCHASEQUOTATION_DESC.QUOTATION_ITEMID = ITEMMASTER.item_id AND PURCHASEQUOTATION_DESC.QUOTATION_CMPID = ITEMMASTER.item_cmpid AND PURCHASEQUOTATION_DESC.QUOTATION_LOCATIONID = ITEMMASTER.item_locationid AND PURCHASEQUOTATION_DESC.QUOTATION_YEARID = ITEMMASTER.item_yearid", tepmcondition)
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal QUOTNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objQUOT As New PurchaseQuotation
                objQUOT.MdiParent = MDIMain
                objQUOT.edit = editval
                objQUOT.tempquotationno = QUOTNO
                objQUOT.Show()
                Me.Close()
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

            Dim PATH As String = Application.StartupPath & "\Purchase Quotation Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Purchase Quotation Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase Quotation Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class