
Imports BL
Imports System.Windows.Forms
Public Class LabourInwardDetails

    Public edit As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub labourInwardDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub labourInwardDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'LABOUR PROCESS'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.labourInward.li_CMPID=" & CmpId & " and dbo.labourInward.li_locationid=" & Locationid & " and dbo.labourInward.li_yearid=" & YearId & " order by dbo.labourInward.li_no ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("  labourInward.li_no AS labourInwardNO, labourInward.li_date AS DATE, LEDGERS.Acc_cmpname AS NAME, ITEMMASTER.ITEM_name AS ITEMNAME,QUALITYMASTER.QUALITY_name AS QUALITY, labourInward_desc.li_QTY AS QTY, labourInward_desc.li_MTRS AS MTRS, labourInward_desc.li_checkedqty AS checkmtrs,labourInward_desc.li_MTRS-labourInward_desc.li_checkedqty as rejmtrs, LEDGERS_1.Acc_cmpname AS TRANSPORT, labourInward.li_lrno AS LRNO, labourInward.li_REMARKS AS REMARKS", "", "   labourInward INNER JOIN LEDGERS ON labourInward.li_ledgerid = LEDGERS.Acc_id AND labourInward.li_cmpid = LEDGERS.Acc_cmpid AND labourInward.li_locationid = LEDGERS.Acc_locationid AND labourInward.li_yearid = LEDGERS.Acc_yearid INNER JOIN labourInward_desc ON labourInward.li_no = labourInward_desc.li_NO AND labourInward.li_cmpid = labourInward_desc.li_CMPID AND labourInward.li_locationid = labourInward_desc.li_LOCATIONID AND labourInward.li_yearid = labourInward_desc.li_YEARID LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON labourInward.li_transledgerid = LEDGERS_1.Acc_id AND labourInward.li_cmpid = LEDGERS_1.Acc_cmpid AND labourInward.li_locationid = LEDGERS_1.Acc_locationid AND labourInward.li_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN QUALITYMASTER ON labourInward_desc.li_QUALITYID = QUALITYMASTER.QUALITY_id AND labourInward_desc.li_CMPID = QUALITYMASTER.QUALITY_cmpid AND labourInward_desc.li_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND labourInward_desc.li_YEARID = QUALITYMASTER.QUALITY_yearid LEFT OUTER JOIN ITEMMASTER ON labourInward_desc.li_ITEMID = ITEMMASTER.item_id AND labourInward_desc.li_CMPID = ITEMMASTER.item_cmpid AND labourInward_desc.li_LOCATIONID = ITEMMASTER.item_locationid AND labourInward_desc.li_YEARID = ITEMMASTER.item_yearid ", tepmcondition)
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal labourInwardNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objlabourInward As New LabourInward
                objlabourInward.MdiParent = MDIMain
                objlabourInward.edit = editval
                'objlabourInward.templino = labourInwardNO
                objlabourInward.Show()
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
            showform(True, gridbill.GetFocusedRowCellValue("labourInwardNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("labourInwardNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

   

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\labourInward Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "labourInward Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "labourInward Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class