
Imports System.Windows.Forms
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ItemReport

    Dim TEMPGRNNO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public selfor_ss As String
    Public PERIOD As String
    Public DETAIL As Boolean = False
    Public FROMDATE As String
    Public TODATE As String

    Private Sub Item_Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillgrid(" and DBO.GRN.GRN_yearid=" & YearId & " and GRN.GRN_TYPE = 'Inwards' and " & selfor_ss & "")
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

    Private Sub Item_Report_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Sub fillgrid(ByVal selfor_ss)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim WCLAUSE As String = ""
            If CHKALL.CheckState = CheckState.Unchecked Then WCLAUSE = " AND DEPARTMENT_INVENTORY = 'True'"
            Dim dt As DataTable = objclsCMST.search(" DISTINCT GRN.grn_no AS GRNNO, GRN.grn_date AS GRNDATE, GRN.grn_challanno AS CHALLANNO, GRN.grn_challandt AS CHALLANDATE, CAST(GRN_DESC.GRN_GRIDREMARKS AS VARCHAR(MAX)) AS [DESC], GRN_DESC.GRN_QTY AS QTY, LEDGERS.Acc_name AS PARTYNAME, ITEMMASTER.item_name AS ITEMNAME, ITEMMASTER_RATEDESC.ITEM_RATE AS MASTERRATE, PURCHASEMASTER_DESC.BILL_no AS BILLNO, PURCHASEMASTER_DESC.BILL_rate AS PARTYBILLRATE,(CASE WHEN BILL_DISPER > 0 THEN ROUND(PURCHASEMASTER_DESC.BILL_rate - (BILL_RATE * BILL_DISPER /100) ,2) ELSE  ROUND(PURCHASEMASTER_DESC.BILL_rate - (BILL_RATE * ((BILL_DISAMT / BILL_BILLAMT) * 100) / 100), 2) END ) AS DISCRATE, ROUND(ROUND(PURCHASEMASTER_DESC.BILL_RATE, 2),2) AS GROSSRATE,  ROUND((CASE WHEN BILL_DISPER > 0 THEN ROUND(PURCHASEMASTER_DESC.BILL_rate - (BILL_RATE * BILL_DISPER /100) ,2) ELSE  ROUND(PURCHASEMASTER_DESC.BILL_rate - (BILL_RATE * ((BILL_DISAMT / BILL_BILLAMT) * 100) / 100), 2)END ) + ((CASE WHEN BILL_DISPER > 0 THEN ROUND(PURCHASEMASTER_DESC.BILL_rate - (BILL_RATE * BILL_DISPER /100) ,2) ELSE  ROUND(PURCHASEMASTER_DESC.BILL_rate - (BILL_RATE * ((BILL_DISAMT / BILL_BILLAMT) * 100) / 100), 2)END )  * TAXMASTER.TAX_TAX /100) , 2)  AS NETTRATE, ROUND((ROUND(PURCHASEMASTER_DESC.BILL_RATE, 2) * GRN_DESC.GRN_QTY),2) AS TOTAL, ROUND((CASE WHEN BILL_DISPER > 0 THEN ROUND(PURCHASEMASTER_DESC.BILL_rate - (BILL_RATE * BILL_DISPER /100) ,2) ELSE  ROUND(PURCHASEMASTER_DESC.BILL_rate - (BILL_RATE * ((BILL_DISAMT / BILL_BILLAMT )*100) /100) ,2)   END ) + ((CASE WHEN BILL_DISPER > 0 THEN ROUND(PURCHASEMASTER_DESC.BILL_rate - (BILL_RATE * BILL_DISPER /100) ,2) ELSE  ROUND(PURCHASEMASTER_DESC.BILL_rate - (BILL_RATE * ((BILL_DISAMT / BILL_BILLAMT )*100) /100) ,2)   END )  * TAXMASTER.TAX_TAX /100) , 2) * (BILL_QTY) AS NETTAMT, ISNULL(CATEGORYMASTER.category_name, '') AS CATEGORY, ISNULL(DEPARTMENTMASTER.DEPARTMENT_name,'') AS DEPARTMENT ", "", " ITEMMASTER INNER JOIN GRN_DESC ON ITEMMASTER.item_id = GRN_DESC.GRN_ITEMID INNER JOIN GRN INNER JOIN LEDGERS ON GRN.grn_ledgerid = LEDGERS.Acc_id ON GRN_DESC.GRN_NO = GRN.grn_no AND GRN_DESC.GRN_YEARID = GRN.grn_yearid AND GRN_DESC.GRN_GRIDTYPE = GRN.GRN_TYPE LEFT OUTER JOIN PURCHASEMASTER_DESC INNER JOIN PURCHASEMASTER ON PURCHASEMASTER_DESC.BILL_no = PURCHASEMASTER.BILL_NO AND PURCHASEMASTER_DESC.BILL_yearid = PURCHASEMASTER.BILL_YEARID LEFT OUTER JOIN TAXMASTER ON PURCHASEMASTER.BILL_TAXID = TAXMASTER.tax_id ON GRN_DESC.GRN_ITEMID = PURCHASEMASTER_DESC.BILL_ITEMID AND GRN.grn_no = PURCHASEMASTER_DESC.BILL_GRNNO AND GRN.grn_yearid = PURCHASEMASTER_DESC.BILL_yearid LEFT OUTER JOIN DEPARTMENTMASTER ON ITEMMASTER.item_departmentid = DEPARTMENTMASTER.DEPARTMENT_id LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id LEFT OUTER JOIN ITEMMASTER_RATEDESC ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID ", selfor_ss & WCLAUSE)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
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
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJMFG As New GRN
                OBJMFG.MdiParent = MDIMain
                OBJMFG.edit = editval
                OBJMFG.tempgrnno = GRNNO
                OBJMFG.FRMSTRING = "INWARD"
                OBJMFG.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("GRNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            showform(True, gridbill.GetFocusedRowCellValue("GRNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        Try
            Dim DT As DataTable = gridbilldetails.DataSource
            If e.RowHandle >= 0 Then
                Dim ROW As DataRow = DT.Rows(e.RowHandle)
                'If ROW("MFGDONE") = "TRUE" Then
                '    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                '    e.Appearance.BackColor = Color.Yellow
                'End If
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

            Dim PATH As String = Application.StartupPath & "\Item Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Item Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Item REport", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKALL.CheckedChanged
        Try
            fillgrid("and DBO.GRN.GRN_CMPID=" & CmpId & " and DBO.GRN.GRN_locationid=" & Locationid & " and DBO.GRN.GRN_yearid=" & YearId & " and GRN.GRN_TYPE = 'Inwards' and " & selfor_ss)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class