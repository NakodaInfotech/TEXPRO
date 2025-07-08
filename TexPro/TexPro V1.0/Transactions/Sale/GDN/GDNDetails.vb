
Imports BL
Imports System.Windows.Forms

Public Class GDNDetails

    Public edit As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SALEOrderDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SALEOrderDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'CHALLAN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.gdn.gdn_yearid=" & YearId & " order by dbo.gdn.gdn_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("   GDN.GDN_no AS SRNO, GDN.GDN_date AS DATE, LEDGERS.Acc_cmpname AS CMPNAME,  ADDRESSMASTER.ADDRESS_ALIAS AS CONSIGNEE, LEDGERS_1.Acc_cmpname AS AGENT, GDN.GDN_PONO AS PONO, GDN.GDN_DISPATCHDATE AS DISPATCHDATE, GDN.GDN_totalpcs AS TOTALPCS, (GDN.GDN_TOTALMTRS) AS TOTALMTRS, GDN.GDN_TOTALBALES AS TOTALBALES, GDN.GDN_remarks AS REMARKS, ISNULL(TRANSLEDGERS.ACC_CMPNAME,'') AS TRANSNAME, ISNULL(LOCALTRANSLEDGERS.ACC_CMPNAME,'') AS LOCALTRANSNAME, ISNULL(GDN.GDN_EWAYBILLNO,'') AS EWBNO, GDN.GDN_MULTISONO AS SONO ", "", "     GDN LEFT OUTER JOIN LEDGERS ON GDN.GDN_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON GDN.GDN_AGENTID = LEDGERS_1.Acc_id LEFT OUTER JOIN ADDRESSMASTER ON GDN.GDN_CONSIGNEEID = ADDRESSMASTER.ADDRESS_ID LEFT OUTER JOIN LEDGERS AS LOCALTRANSLEDGERS ON GDN.GDN_LOCALTRANSID = LOCALTRANSLEDGERS.ACC_ID LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON GDN.GDN_TRANSID = TRANSLEDGERS.ACC_ID ", tepmcondition)
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal gdnno As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objgdn As New GDN
                objgdn.MdiParent = MDIMain
                objgdn.edit = editval
                objgdn.tempgdnno = gdnno
                objgdn.Show()
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

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJGDN As New GDNGridDetails
            OBJGDN.MdiParent = MDIMain
            OBJGDN.Show()
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
            PATH = Application.StartupPath & "\Challan Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "Challan Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Challan Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and dbo.gdn.gdn_CMPID=" & CmpId & " and dbo.gdn.gdn_locationid=" & Locationid & " and dbo.gdn.gdn_yearid=" & YearId & " order by dbo.gdn.gdn_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class