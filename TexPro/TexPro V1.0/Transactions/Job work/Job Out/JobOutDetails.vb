
Imports BL
Imports System.Windows.Forms
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class JobOutDetails

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
        DTROW = USERRIGHTS.Select("FormName = 'JOB WORK OUT'")
        USERADD = DTROW(0).Item(1)
        USEREDIT = DTROW(0).Item(2)
        USERVIEW = DTROW(0).Item(3)
        USERDELETE = DTROW(0).Item(4)

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        fillgrid(" and dbo.JOBOUT.JO_CMPID=" & CmpId & " and dbo.JOBOUT.JO_locationid=" & Locationid & " and dbo.JOBOUT.JO_yearid=" & YearId & " order by dbo.JOBOUT.JO_no ")
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" JOBOUT.JO_no AS SRNO, JOBOUT.JO_date AS DATE, LEDGERS.Acc_cmpname AS NAME, JOBOUT.JO_TOTALPCS AS PCS, JOBOUT.JO_TOTALMTRS AS MTRS, ISNULL(ITEMMASTER.item_name, '') AS MERCHANT, ISNULL(TRANSLEDGERS.Acc_cmpname,'') AS TRANSNAME, JOBOUT.JO_lrno AS LRNO, JOBOUT.JO_TOTALBALES AS BALES, JOBOUT.JO_RATE AS RATE ", "", " JOBOUT INNER JOIN LEDGERS ON JOBOUT.JO_ledgerid = LEDGERS.Acc_id AND JOBOUT.JO_cmpid = LEDGERS.Acc_cmpid AND JOBOUT.JO_locationid = LEDGERS.Acc_locationid AND JOBOUT.JO_yearid = LEDGERS.Acc_yearid LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON JOBOUT.JO_yearid = TRANSLEDGERS.Acc_yearid AND JOBOUT.JO_locationid = TRANSLEDGERS.Acc_locationid AND JOBOUT.JO_cmpid = TRANSLEDGERS.Acc_cmpid AND JOBOUT.JO_transledgerid = TRANSLEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER ON JOBOUT.JO_MERCHANTID = ITEMMASTER.item_id AND JOBOUT.JO_cmpid = ITEMMASTER.item_cmpid AND JOBOUT.JO_locationid = ITEMMASTER.item_locationid AND JOBOUT.JO_yearid = ITEMMASTER.item_yearid ", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal JONO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New JobOut
                objREQ.MdiParent = MDIMain
                objREQ.edit = editval
                objREQ.tempjono = JONO
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
        If Val(TXTFROM.Text) > 0 And Val(TXTTO.Text) > 0 Then
            Dim tempmsg As Integer = MsgBox("Wish To Print? Bale From " & TXTFROM.Text & " To " & TXTTO.Text, MsgBoxStyle.YesNo)
            If tempmsg = vbYes Then
                serverprop()
            End If
        End If
    End Sub

    Sub serverprop()
        For I As Integer = 0 To (TXTTO.Text - TXTFROM.Text)

            Dim objgp As New JODESIGN
            Dim RPTJPS As New psjobreport
            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table

            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            crTables = RPTJPS.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            'If GRIDFPS.Rows(0).Cells(gpiecetype.Index).Value = "GOOD CUT" Then
            '    RPTJPS.GroupHeaderSection7.SectionFormat.EnableSuppress = True
            '    RPTJPS.GroupHeaderSection10.SectionFormat.EnableSuppress = False
            '    RPTJPS.GroupHeaderSection8.SectionFormat.EnableSuppress = True
            '    RPTJPS.GroupHeaderSection9.SectionFormat.EnableSuppress = False
            '    RPTJPS.GroupFooterSection3.SectionFormat.EnableSuppress = True
            '    RPTJPS.GroupFooterSection7.SectionFormat.EnableSuppress = False

            'End If

            objgp.MdiParent = MDIMain
            objgp.FRMSTRING = "JOB"
            RPTJPS.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
            RPTJPS.RecordSelectionFormula = "{JOBOUT.JO_NO}=" & Val(TXTFROM.Text) + I & " and {JOBOUT.JO_cmpid}=" & CmpId & " and {JOBOUT.JO_locationid}=" & Locationid & " and {JOBOUT.JO_yearid}=" & YearId
            RPTJPS.PrintToPrinter(1, True, 0, 0)
        Next
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and dbo.JOBOUT.JO_CMPID=" & CmpId & " and dbo.JOBOUT.JO_locationid=" & Locationid & " and dbo.JOBOUT.JO_yearid=" & YearId & " order by dbo.JOBOUT.JO_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EXCELTOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELTOOL.Click
        Try

            Dim PATH As String = Application.StartupPath & "\JOBOUT Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "JOBOUT Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "JOBOUT Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class