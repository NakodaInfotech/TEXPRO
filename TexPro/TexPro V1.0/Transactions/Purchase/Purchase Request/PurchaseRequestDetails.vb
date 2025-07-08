
Imports BL
Imports System.Windows.Forms

Public Class PurchaseRequestDetails

    Public edit As Boolean
    Dim temppreqno As Integer
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
        DTROW = USERRIGHTS.Select("FormName = 'PURCHASE REQUEST'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        fillgrid(" and dbo.PURCHASEREQUEST.PREQ_CMPID=" & CmpId & " and dbo.PURCHASEREQUEST.preq_locationid=" & Locationid & " and dbo.PURCHASEREQUEST.preq_yearid=" & YearId & " order by dbo.PURCHASEREQUEST.preq_no, PURCHASEREQUEST_DESC.PREQ_GRIDSRNO ")
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" PURCHASEREQUEST.PREQ_NO AS SRNO, PURCHASEREQUEST.PREQ_DATE AS DATE, PURCHASEREQUEST.PREQ_REQBY AS REQBY, DEPARTMENTMASTER.DEPARTMENT_NAME AS DEPARTMENTNAME, ITEMMASTER.ITEM_NAME AS ITEMNAME, QUALITYMASTER.QUALITY_NAME AS QUALITY, PURCHASEREQUEST_DESC.PREQ_REED AS REED, PURCHASEREQUEST_DESC.PREQ_PICK AS PICK, COLORMASTER.COLOR_NAME AS COLOR, PURCHASEREQUEST_DESC.PREQ_QTY AS QTY, UNITMASTER.unit_abbr AS UNIT ", "", "  PURCHASEREQUEST INNER JOIN PURCHASEREQUEST_DESC ON PURCHASEREQUEST.PREQ_CMPID = PURCHASEREQUEST_DESC.PREQ_CMPID AND PURCHASEREQUEST.PREQ_LOCATIONID = PURCHASEREQUEST_DESC.PREQ_LOCATIONID AND PURCHASEREQUEST.PREQ_YEARID = PURCHASEREQUEST_DESC.PREQ_YEARID AND PURCHASEREQUEST.PREQ_NO = PURCHASEREQUEST_DESC.PREQ_NO INNER JOIN ITEMMASTER ON PURCHASEREQUEST_DESC.PREQ_ITEMID = ITEMMASTER.ITEM_ID AND PURCHASEREQUEST_DESC.PREQ_CMPID = ITEMMASTER.ITEM_CMPID AND PURCHASEREQUEST_DESC.PREQ_LOCATIONID = ITEMMASTER.ITEM_LOCATIONID AND PURCHASEREQUEST_DESC.PREQ_YEARID = ITEMMASTER.ITEM_YEARID LEFT OUTER JOIN UNITMASTER ON PURCHASEREQUEST_DESC.PREQ_YEARID = UNITMASTER.unit_yearid AND PURCHASEREQUEST_DESC.PREQ_LOCATIONID = UNITMASTER.unit_locationid AND PURCHASEREQUEST_DESC.PREQ_CMPID = UNITMASTER.unit_cmpid AND PURCHASEREQUEST_DESC.PREQ_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN COLORMASTER ON PURCHASEREQUEST_DESC.PREQ_YEARID = COLORMASTER.COLOR_YEARID AND PURCHASEREQUEST_DESC.PREQ_LOCATIONID = COLORMASTER.COLOR_LOCATIONID AND PURCHASEREQUEST_DESC.PREQ_CMPID = COLORMASTER.COLOR_CMPID AND PURCHASEREQUEST_DESC.PREQ_COLORID = COLORMASTER.COLOR_ID LEFT OUTER JOIN QUALITYMASTER ON PURCHASEREQUEST_DESC.PREQ_YEARID = QUALITYMASTER.QUALITY_YEARID AND PURCHASEREQUEST_DESC.PREQ_LOCATIONID = QUALITYMASTER.QUALITY_LOCATIONID AND PURCHASEREQUEST_DESC.PREQ_CMPID = QUALITYMASTER.QUALITY_CMPID AND PURCHASEREQUEST_DESC.PREQ_QUALITYID = QUALITYMASTER.QUALITY_ID LEFT OUTER JOIN DEPARTMENTMASTER ON PURCHASEREQUEST.PREQ_DEPARTMENTID = DEPARTMENTMASTER.DEPARTMENT_ID AND PURCHASEREQUEST.PREQ_CMPID = DEPARTMENTMASTER.DEPARTMENT_CMPID AND PURCHASEREQUEST.PREQ_LOCATIONID = DEPARTMENTMASTER.DEPARTMENT_LOCATIONID AND PURCHASEREQUEST.PREQ_YEARID = DEPARTMENTMASTER.DEPARTMENT_YEARID", tepmcondition)
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal REQNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New PurchaseRequest
                objREQ.MdiParent = MDIMain
                objREQ.edit = editval
                objREQ.tempreqno = REQNO
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

            Dim PATH As String = Application.StartupPath & "\Purchase Request Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Purchase Request Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase Request Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class