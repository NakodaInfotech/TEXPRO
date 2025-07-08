
Imports BL
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrintingLinks

Public Class PartyLotStatusReport

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub CLEAR()
        Try
            cmbname.Text = ""
            GRIDUNCHECKEDDETAILS.DataSource = Nothing
            GRIDCHECKEDDETAILS.DataSource = Nothing
            GRIDMFGDETAILS.DataSource = Nothing
            GRIDBALEDETAILS.DataSource = Nothing

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        cmbname.Focus()
    End Sub

    Private Sub CMDSHOWDETAILS_Click(sender As Object, e As EventArgs) Handles CMDSHOWDETAILS.Click
        Try
            'If cmbname.Text.Trim = "" Then Exit Sub

            Dim OBJCMN As New ClsCommon
            Dim WHERECLAUSE As String = ""
            Dim CHECKWHERECLAUSE As String = ""
            Dim MFGWHERECLAUSE As String = ""
            If cmbname.Text.Trim <> "" Then
                WHERECLAUSE = WHERECLAUSE & " AND NAME = '" & cmbname.Text.Trim & "'"
                CHECKWHERECLAUSE = CHECKWHERECLAUSE & " AND LEDGERNAME = '" & cmbname.Text.Trim & "'"
                MFGWHERECLAUSE = MFGWHERECLAUSE & " AND T.NAME = '" & cmbname.Text.Trim & "'"
            End If

            'FETCH UNCHECKED STOCK
            Dim DTUNCHECK As DataTable = OBJCMN.Execute_Any_String("SELECT [Lot No.] AS LOTNO,  Date AS [DATE], SUM(Qty) AS PCS, SUM(Mtrs) AS MTRS, SENDER AS SENDERNAME, Quality AS QUALITY FROM GRN_VIEW WHERE (YEARID = " & YearId & ") AND (CHECKDONE = 'A') " & WHERECLAUSE & " GROUP BY [Lot No.],  Date, SENDER, Quality ORDER BY [Lot No.]", "", "")
            GRIDUNCHECKEDDETAILS.DataSource = DTUNCHECK


            'FETCH CHECKED STOCK
            Dim DTCHECK As DataTable = OBJCMN.Execute_Any_String("SELECT [Lot No] AS LOTNO,  CAST(Date AS DATE) AS [DATE], SUM(PCS) AS PCS, SUM(Mtrs) AS MTRS, NAME AS SENDERNAME, Quality AS QUALITY FROM CHECK_VIEW WHERE (YEARID = " & YearId & ")  " & CHECKWHERECLAUSE & " GROUP BY  [Lot No] ,  CAST(Date AS DATE), NAME, Quality ORDER BY [Lot No]", "", "")
            GRIDCHECKEDDETAILS.DataSource = DTCHECK



            'FETCH MFG STOCK

            Dim DTMFG As New DataTable
            If ClientName = "SHUBHLAXMI" Then
                DTMFG = OBJCMN.Execute_Any_String("SELECT VIEW_SUMMARY_MFG1.LOTNO, M.DATE,  T.NAME, SUM(VIEW_SUMMARY_MFG1.PCS) AS BALPCS, SUM(MTRS) AS MTRS , M.PROCESSNAME, T.QUALITY FROM VIEW_SUMMARY_MFG1 CROSS APPLY (SELECT TOP 1 * FROM GREYDETAIL_VIEW WHERE CMPID = " & CmpId & " AND YEARID = " & YearId & " AND BALPCS > 0 AND LOTNO = VIEW_SUMMARY_MFG1.LOTNO AND YEARID = VIEW_SUMMARY_MFG1.YEARID ) AS T CROSS APPLY  (SELECT TOP 1 PROCESS_NAME AS PROCESSNAME, MFGMASTER.MFG_DATE AS DATE FROM MFGMASTER INNER JOIN MFGMASTER_DESC ON MFGMASTER.MFG_NO = MFGMASTER_DESC.MFG_NO AND MFGMASTER.MFG_YEARID = MFGMASTER_DESC.MFG_YEARID INNER JOIN PROCESSMASTER ON MFG_TOPROCESSID  = PROCESSMASTER.PROCESS_ID WHERE MFGMASTER.MFG_CMPID = " & CmpId & " AND MFGMASTER.MFG_YEARID = " & YearId & "  AND MFGMASTER_DESC.MFG_LOTNO = VIEW_SUMMARY_MFG1.LOTNO AND MFGMASTER.MFG_YEARID = VIEW_SUMMARY_MFG1.YEARID ORDER BY MFGMASTER.MFG_NO DESC) AS M WHERE VIEW_SUMMARY_MFG1.CMPID = " & CmpId & " AND VIEW_SUMMARY_MFG1.YEARID = " & YearId & MFGWHERECLAUSE & " GROUP BY VIEW_SUMMARY_MFG1.LOTNO, M.DATE, T.NAME, PROCESSNAME, T.QUALITY HAVING SUM(PCS) > 1 ORDER BY LOTNO ", "", "")
            Else
                DTMFG = OBJCMN.Execute_Any_String("Select VIEW_SUMMARY_MFG1.LOTNO, M.DATE,  T.NAME, SUM(VIEW_SUMMARY_MFG1.PCS) AS BALPCS, SUM(MTRS) As MTRS , M.PROCESSNAME, T.QUALITY FROM VIEW_SUMMARY_MFG1 CROSS APPLY (Select TOP 1 * FROM GREYDETAIL_VIEW WHERE CMPID = " & CmpId & " AND YEARID = " & YearId & " And BALPCS > 0 And LOTNO = VIEW_SUMMARY_MFG1.LOTNO And YEARID = VIEW_SUMMARY_MFG1.YEARID ) As T CROSS APPLY  (Select TOP 1 PROCESS_NAME As PROCESSNAME, MFGMASTER.MFG_DATE AS DATE FROM MFGMASTER INNER JOIN MFGMASTER_DESC On MFGMASTER.MFG_NO = MFGMASTER_DESC.MFG_NO And MFGMASTER.MFG_YEARID = MFGMASTER_DESC.MFG_YEARID INNER JOIN PROCESSMASTER On MFG_TOPROCESSID  = PROCESSMASTER.PROCESS_ID WHERE MFGMASTER.MFG_CMPID = " & CmpId & " AND MFGMASTER.MFG_YEARID = " & YearId & "  And MFGMASTER_DESC.MFG_LOTNO = VIEW_SUMMARY_MFG1.LOTNO And MFGMASTER.MFG_YEARID = VIEW_SUMMARY_MFG1.YEARID ORDER BY MFGMASTER.MFG_NO DESC) As M WHERE VIEW_SUMMARY_MFG1.CMPID = " & CmpId & " AND VIEW_SUMMARY_MFG1.YEARID = " & YearId & MFGWHERECLAUSE & " GROUP BY VIEW_SUMMARY_MFG1.LOTNO, M.DATE, T.NAME, PROCESSNAME, T.QUALITY HAVING SUM(MTRS) > 1 ORDER BY LOTNO ", "", "")
            End If
            GRIDMFGDETAILS.DataSource = DTMFG


            'FETCH BALE STOCK
            Dim DTBALE As DataTable = OBJCMN.Execute_Any_String("Select LOTNO, Date, SUM(PCS) As PCS, SUM(MTRS) As MTRS, BALENO, MERCHANT FROM BALESTOCK_VIEW WHERE YEARID = " & YearId & WHERECLAUSE & " GROUP BY LOTNO, DATE, BALENO, MERCHANT ORDER BY LOTNO", "", "")
            GRIDBALEDETAILS.DataSource = DTBALE

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PartyLotStatusReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXCEL_Click(sender As Object, e As EventArgs) Handles CMDPRINT.Click
        Try

            'SAVE ALL THE CHECKED GRID IN TEMPTABLE AND THEN PRINT IT
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPLOTSTATUS WHERE YEARID = " & YearId, "", "")
            If CHKUNCHECKED.CheckState = CheckState.Checked Then
                For I As Integer = 0 To GRIDUNCHECKED.RowCount - 1
                    Dim DTROW As DataRow = GRIDUNCHECKED.GetDataRow(I)
                    DT = OBJCMN.Execute_Any_String("INSERT INTO TEMPLOTSTATUS VALUES ('A-UNCHECKED'," & Val(DTROW("LOTNO")) & ",'" & Format(Convert.ToDateTime(DTROW("DATE")).Date, "MM/dd/yyyy") & "'," & Val(DTROW("PCS")) & "," & Val(DTROW("MTRS")) & ",'" & DTROW("SENDERNAME") & "','" & DTROW("QUALITY") & "','',0,''," & CmpId & "," & YearId & ")", "", "")
                Next
            End If


            If CHKCHECK.CheckState = CheckState.Checked Then
                For I As Integer = 0 To GRIDCHECKED.RowCount - 1
                    Dim DTROW As DataRow = GRIDCHECKED.GetDataRow(I)
                    DT = OBJCMN.Execute_Any_String("INSERT INTO TEMPLOTSTATUS VALUES ('B-CHECKED'," & Val(DTROW("LOTNO")) & ",'" & Format(Convert.ToDateTime(DTROW("DATE")).Date, "MM/dd/yyyy") & "'," & Val(DTROW("PCS")) & "," & Val(DTROW("MTRS")) & ",'" & DTROW("SENDERNAME") & "','" & DTROW("QUALITY") & "','',0,''," & CmpId & "," & YearId & ")", "", "")
                Next
            End If



            If CHKMFGSTOCK.CheckState = CheckState.Checked Then
                For I As Integer = 0 To GRIDMFG.RowCount - 1
                    Dim DTROW As DataRow = GRIDMFG.GetDataRow(I)
                    DT = OBJCMN.Execute_Any_String("INSERT INTO TEMPLOTSTATUS VALUES ('C-MFGSTOCK'," & Val(DTROW("LOTNO")) & ",'" & Format(Convert.ToDateTime(DTROW("DATE")).Date, "MM/dd/yyyy") & "'," & Val(DTROW("BALPCS")) & "," & Val(DTROW("MTRS")) & ",'','" & DTROW("QUALITY") & "','" & DTROW("PROCESSNAME") & "',0,''," & CmpId & "," & YearId & ")", "", "")
                Next
            End If


            If CHKBALESTOCK.CheckState = CheckState.Checked Then
                For I As Integer = 0 To GRIDBALE.RowCount - 1
                    Dim DTROW As DataRow = GRIDBALE.GetDataRow(I)
                    DT = OBJCMN.Execute_Any_String("INSERT INTO TEMPLOTSTATUS VALUES ('D-BALESTOCK'," & Val(DTROW("LOTNO")) & ",'" & Format(Convert.ToDateTime(DTROW("DATE")).Date, "MM/dd/yyyy") & "'," & Val(DTROW("PCS")) & "," & Val(DTROW("MTRS")) & ",'','',''," & Val(DTROW("BALENO")) & ",'" & DTROW("MERCHANT") & "'," & CmpId & "," & YearId & ")", "", "")
                Next
            End If

            Dim OBJPRINT As New mfgdesign
            OBJPRINT.frmstring = "PARTYLOTSTATUS"
            OBJPRINT.selfor_po = " {TEMPLOTSTATUS.YEARID} = " & YearId
            OBJPRINT.PARTYNAME = cmbname.Text.Trim
            OBJPRINT.PERIOD = Format(AccFrom.Date, "dd/MM/yyyy") & " - " & Format(AccTo.Date, "dd/MM/yyyy")
            OBJPRINT.MdiParent = MDIMain
            OBJPRINT.Show()



            '    Dim PATH As String = Application.StartupPath & "\Lot Status.XLS"
            '    Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            '    opti.ShowGridLines = True

            '    For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '        proc.Kill()
            '    Next
            '    opti.SheetName = "Lot Status"
            '    Dim compositeLink As New CompositeLinkBase
            '    Dim printingSystem As New PrintingSystemBase

            '    compositeLink.PrintingSystemBase = printingSystem

            '    Dim link1 As New PrintableComponentLinkBase
            '    Dim link2 As New PrintableComponentLinkBase
            '    Dim link3 As New PrintableComponentLinkBase
            '    Dim link4 As New PrintableComponentLinkBase

            '    link1.Component = CType(GRIDUNCHECKEDDETAILS, IPrintable)
            '    link2.Component = CType(GRIDCHECKEDDETAILS, IPrintable)
            '    link3.Component = CType(GRIDMFGDETAILS, IPrintable)
            '    link4.Component = CType(GRIDBALEDETAILS, IPrintable)

            '    compositeLink.Links.Add(link1)
            '    compositeLink.Links.Add(link2)
            '    compositeLink.Links.Add(link3)
            '    compositeLink.Links.Add(link4)

            '    opti.ExportMode = XlsxExportMode.SingleFilePageByPage
            '    compositeLink.ExportToXls(PATH, opti)
            '    EXCELCMPHEADER(PATH, "Lot Status", GRIDBALE.VisibleColumns.Count + GRIDBALE.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class