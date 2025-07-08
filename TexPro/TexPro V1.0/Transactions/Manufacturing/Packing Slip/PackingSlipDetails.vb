
Imports System.Windows.Forms
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports DevExpress.XtraGrid.Views.Grid

Public Class PackingSlipDetails

    Public edit As Boolean
    Dim TEMPPSNO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub MfgDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

            fillgrid(" and DBO.PACKINGSLIP_JOB.PS_yearid=" & YearId & " GROUP BY dbo.PACKINGSLIP_JOB.PS_NO, dbo.PACKINGSLIP_JOB.PS_DATE, dbo.PROCESSMASTER.PROCESS_NAME, dbo.PACKINGSLIP_JOB.PS_FBNO, dbo.PACKINGSLIP_JOB.PS_JOBNO, dbo.PACKINGSLIP_JOB.PS_ORDERNO, dbo.PACKINGSLIP_DESC_JOB.PS_LOTNO,ITEMMASTER.item_name, ISNULL(PACKINGSLIP_JOB.PS_EXPENSEREPORT,0), ISNULL(LEDGERS.ACC_CMPNAME ,'') order by DBO.PACKINGSLIP_JOB.PS_no")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search(" PACKINGSLIP_JOB.PS_NO AS PSNO, PACKINGSLIP_JOB.PS_DATE AS DATE, PROCESSMASTER.PROCESS_NAME AS PROCESS, PACKINGSLIP_JOB.PS_FBNO AS FBNO, ISNULL(ITEMMASTER.item_name, '') AS MERCHANT, PACKINGSLIP_JOB.PS_JOBNO AS JOBNO, PACKINGSLIP_JOB.PS_ORDERNO AS ORDERNO, SUM(PACKINGSLIP_DESC_JOB.PS_TOTAL) AS PCS, SUM(PACKINGSLIP_DESC_JOB.PS_MTRS) AS MTRS, PACKINGSLIP_DESC_JOB.PS_LOTNO AS LOTNO, ISNULL(PACKINGSLIP_JOB.PS_EXPENSEREPORT,0) AS EXPENSEREPORT, ISNULL(LEDGERS.ACC_CMPNAME ,'') AS NAME ", "", " PACKINGSLIP_JOB INNER JOIN PACKINGSLIP_DESC_JOB ON PACKINGSLIP_JOB.PS_NO = PACKINGSLIP_DESC_JOB.PS_NO AND  PACKINGSLIP_JOB.PS_CMPID = PACKINGSLIP_DESC_JOB.PS_CMPID AND PACKINGSLIP_JOB.PS_LOCATIONID = PACKINGSLIP_DESC_JOB.PS_LOCATIONID AND PACKINGSLIP_JOB.PS_YEARID = PACKINGSLIP_DESC_JOB.PS_YEARID LEFT OUTER JOIN ITEMMASTER ON PACKINGSLIP_DESC_JOB.PS_YEARID = ITEMMASTER.item_yearid AND PACKINGSLIP_DESC_JOB.PS_LOCATIONID = ITEMMASTER.item_locationid AND PACKINGSLIP_DESC_JOB.PS_CMPID = ITEMMASTER.item_cmpid AND PACKINGSLIP_DESC_JOB.PS_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN PROCESSMASTER ON PACKINGSLIP_JOB.PS_PROCESSID = PROCESSMASTER.PROCESS_ID AND  PACKINGSLIP_JOB.PS_CMPID = PROCESSMASTER.PROCESS_CMPID AND PACKINGSLIP_JOB.PS_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND PACKINGSLIP_JOB.PS_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN LEDGERS ON PACKINGSLIP_JOB.PS_LEDGERID = LEDGERS.ACC_ID", tepmcondition)
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal MFGNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJMFG As New PackingSlip
                OBJMFG.MdiParent = MDIMain
                OBJMFG.edit = editval
                OBJMFG.TEMPPSNO = MFGNO
                OBJMFG.Show()
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

    Private Sub gridbill_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gridbill.CellValueChanged
        If IsDBNull(e.Value) = True Then Exit Sub
        Dim ROW As DataRow = gridbill.GetFocusedDataRow
        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable
        On Error Resume Next
        If ROW("EXPENSEREPORT") = True Then
            DT = OBJCMN.Execute_Any_String("UPDATE PACKINGSLIP_JOB SET PS_EXPENSEREPORT = 1 WHERE PS_NO = " & ROW("PSNO") & " AND PS_YEARID = " & YearId, "", "")
        Else
            DT = OBJCMN.Execute_Any_String("UPDATE PACKINGSLIP_JOB SET PS_EXPENSEREPORT = 0 WHERE PS_NO = " & ROW("PSNO") & " AND PS_YEARID = " & YearId, "", "")
        End If
    End Sub

    Private Sub gridBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("PSNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("PSNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("EXPENSEREPORT")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightGreen
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        If Val(txtfrom.Text) > 0 And Val(txtto.Text) > 0 Then
            Dim tempmsg As Integer = MsgBox("Wish To Print? Bale From " & txtfrom.Text & " To " & txtto.Text, MsgBoxStyle.YesNo)
            If tempmsg = vbYes Then
                serverprop()
            End If
        End If
    End Sub

    Sub serverprop()
        For I As Integer = 0 To (txtto.Text - txtfrom.Text)

            Dim objgp As New JODESIGN
            Dim rptfsp As New psjobreport
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

            crTables = rptfsp.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************************ END *******************

            If CHKHEADER.Checked = False Then
                rptfsp.DataDefinition.FormulaFields("HIDEHEADER").Text = 1
            Else
                rptfsp.DataDefinition.FormulaFields("HIDEHEADER").Text = 0
            End If


            objgp.MdiParent = MDIMain
            rptfsp.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
            rptfsp.RecordSelectionFormula = " {packingslip_job.ps_NO}=" & txtfrom.Text + I & " and {packingslip_job.ps_cmpid}=" & CmpId & " and {packingslip_job.ps_locationid}=" & Locationid & " and {packingslip_job.ps_yearid}=" & YearId
            rptfsp.PrintToPrinter(1, True, 0, 0)
        Next
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try

            Dim PATH As String = Application.StartupPath & "\PackingSlip Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "PackingSlip Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "PackingSlip Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and DBO.PACKINGSLIP_JOB.PS_yearid=" & YearId & " GROUP BY dbo.PACKINGSLIP_JOB.PS_NO, dbo.PACKINGSLIP_JOB.PS_DATE, dbo.PROCESSMASTER.PROCESS_NAME, dbo.PACKINGSLIP_JOB.PS_FBNO, dbo.PACKINGSLIP_JOB.PS_JOBNO, dbo.PACKINGSLIP_JOB.PS_ORDERNO, dbo.PACKINGSLIP_DESC_JOB.PS_LOTNO,ITEMMASTER.item_name, ISNULL(PACKINGSLIP_JOB.PS_EXPENSEREPORT,0), ISNULL(LEDGERS.ACC_CMPNAME ,'') order by DBO.PACKINGSLIP_JOB.PS_no")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class