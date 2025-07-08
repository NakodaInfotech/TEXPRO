

Imports System.Windows.Forms
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class BALEDETAILREPORT


    Dim TEMPGRNNO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public selfor_ss As String
    Public PERIOD As String
    Public DETAIL As Boolean = False
    Public FROMDATE As String
    Public TODATE As String

    Private Sub BALEDETAILREPORT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid(" and DBO.BALE_VIEW.CMPID=" & CmpId & " and DBO.BALE_VIEW.locationid=" & Locationid & " and DBO.BALE_VIEW.yearid=" & YearId & " and GRN.GRN_TYPE = 'Inwards' and " & selfor_ss & "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BALEDETAILREPORT_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal selfor_ss)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable

            dt = objclsCMST.search("  DISTINCT GRN.grn_no AS GRNNO, GRN.grn_date AS GRNDATE, GRN.grn_challanno AS CHALLANNO, GRN.grn_challandt AS CHALLANDATE, CAST(GRN_DESC.GRN_GRIDREMARKS AS VARCHAR(MAX)) AS [DESC], GRN_DESC.GRN_QTY AS QTY, LEDGERS.Acc_name AS PARTYNAME, ITEMMASTER.item_name AS ITEMNAME, ITEMMASTER_RATEDESC.ITEM_RATE AS MASTERRATE, PURCHASEMASTER_DESC.BILL_no AS BILLNO, PURCHASEMASTER_DESC.BILL_rate AS PARTYBILLRATE, ROUND(PURCHASEMASTER_DESC.BILL_rate - PURCHASEMASTER.BILL_DISAMT,2) AS DISCRATE, ROUND(PURCHASEMASTER.BILL_SUBTOTAL / GRN_QTY,2) AS GROSSRATE, ROUND(PURCHASEMASTER.BILL_GRANDTOTAL / GRN_QTY,2) AS NETTRATE, PURCHASEMASTER.BILL_GRANDTOTAL AS TOTAL, ISNULL(CATEGORYMASTER.category_name, '') AS CATEGORY ", "", " ITEMMASTER_RATEDESC RIGHT OUTER JOIN CATEGORYMASTER RIGHT OUTER JOIN ITEMMASTER INNER JOIN GRN_DESC ON ITEMMASTER.item_id = GRN_DESC.GRN_ITEMID AND ITEMMASTER.item_cmpid = GRN_DESC.GRN_CMPID AND ITEMMASTER.item_locationid = GRN_DESC.GRN_LOCATIONID AND ITEMMASTER.item_yearid = GRN_DESC.GRN_YEARID INNER JOIN GRN INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id AND GRN.grn_cmpid = LEDGERS.Acc_cmpid AND GRN.grn_locationid = LEDGERS.Acc_locationid AND GRN.grn_yearid = LEDGERS.Acc_yearid ON GRN_DESC.GRN_NO = GRN.grn_no AND GRN_DESC.GRN_CMPID = GRN.grn_cmpid AND GRN_DESC.GRN_LOCATIONID = GRN.grn_locationid AND GRN_DESC.GRN_YEARID = GRN.grn_yearid AND GRN_DESC.GRN_GRIDTYPE = GRN.GRN_TYPE ON CATEGORYMASTER.category_yearid = ITEMMASTER.item_yearid AND CATEGORYMASTER.category_locationid = ITEMMASTER.item_locationid AND CATEGORYMASTER.category_cmpid = ITEMMASTER.item_cmpid AND CATEGORYMASTER.category_id = ITEMMASTER.item_categoryid ON ITEMMASTER_RATEDESC.ITEM_ID = ITEMMASTER.item_id AND ITEMMASTER_RATEDESC.ITEM_CMPID = ITEMMASTER.item_cmpid AND ITEMMASTER_RATEDESC.ITEM_LOCATIONID = ITEMMASTER.item_locationid AND ITEMMASTER_RATEDESC.ITEM_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PURCHASEMASTER_DESC INNER JOIN PURCHASEMASTER ON PURCHASEMASTER_DESC.BILL_no = PURCHASEMASTER.BILL_NO AND PURCHASEMASTER_DESC.BILL_cmpid = PURCHASEMASTER.BILL_CMPID AND PURCHASEMASTER_DESC.BILL_locationid = PURCHASEMASTER.BILL_LOCATIONID AND PURCHASEMASTER_DESC.BILL_yearid = PURCHASEMASTER.BILL_YEARID ON GRN.grn_no = PURCHASEMASTER_DESC.BILL_GRNNO AND GRN.grn_cmpid = PURCHASEMASTER_DESC.BILL_cmpid AND GRN.grn_locationid = PURCHASEMASTER_DESC.BILL_locationid AND GRN.grn_yearid = PURCHASEMASTER_DESC.BILL_yearid ", selfor_ss)

            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            Else
                MsgBox("NO RECORDS !")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal GRNNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJMFG As New GRN
                OBJMFG.MdiParent = MDIMain
                OBJMFG.edit = editval
                OBJMFG.tempgrnno = GRNNO
                OBJMFG.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop()
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


        objgp.MdiParent = MDIMain
        rptfsp.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
        'rptfsp.RecordSelectionFormula = " {packingslip_job.ps_NO}=" & txtfrom.Text + I & " and {packingslip_job.ps_cmpid}=" & CmpId & " and {packingslip_job.ps_locationid}=" & Locationid & " and {packingslip_job.ps_yearid}=" & YearId
        rptfsp.PrintToPrinter(1, True, 0, 0)

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Bale Detail Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Bale Detail Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Bale Detail Report", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class