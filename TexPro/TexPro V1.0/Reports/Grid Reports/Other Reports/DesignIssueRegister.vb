﻿
Imports BL
Imports System.IO

Public Class DesignIssueRegister
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub DesignIssueRegister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DesignIssueRegister_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FILLGRID(" and DESIGNISSUEMASTER.DESIGN_YEARID=" & YearId)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID(ByVal WHERECLAUSE As String)
        Try

            Dim ORDERBYCLAUSE As String = ""
            If RBRECDATE.Checked = True Then ORDERBYCLAUSE = " ORDER BY CAST(RIGHT(DESIGNISSUEMASTER.DESIGN_RECDATE,4) + '-' + SUBSTRING(DESIGNISSUEMASTER.DESIGN_RECDATE,4,2) + '-' + LEFT(DESIGNISSUEMASTER.DESIGN_RECDATE,2) AS DATE) " Else ORDERBYCLAUSE = "ORDER BY DESIGNISSUEMASTER.DESIGN_ISSDATE, DESIGNISSUEMASTER.DESIGN_ISSNO"

            Dim objclsCMST As New ClsCommon
            Dim dt As New DataTable
            If RBPENDING.Checked = True Then
                dt = objclsCMST.Execute_Any_String(" SELECT DESIGNISSUEMASTER.DESIGN_ISSNO AS ISSUENO, DESIGNISSUEMASTER.DESIGN_ISSDATE AS ISSDATE, DESIGNISSUEMASTER.DESIGN_SKETCHNO AS SKETCHNO, LEDGERS.Acc_cmpname AS NAME, DESIGNISSUEMASTER.DESIGN_MACHINE AS MACHINE, DESIGNISSUEMASTER.DESIGN_SMALL1 AS SMALL1, DESIGNISSUEMASTER.DESIGN_BIG AS BIG, DESIGNISSUEMASTER.DESIGN_TABLE AS [TABLE], ISSUEMERCHANTMASTER.ISSUEMERCHANT_name AS MERCHANT, CASE WHEN DESIGNISSUEMASTER.DESIGN_RECDATE = '__/__/____' THEN '' ELSE DESIGNISSUEMASTER.DESIGN_RECDATE END AS RECDATE, DESIGNISSUEMASTER.DESIGN_DESIGNNO AS DESIGNNO, CASE WHEN DESIGNISSUEMASTER.DESIGN_BILLDATE  = '__/__/____' THEN '' ELSE DESIGNISSUEMASTER.DESIGN_BILLDATE END AS BILLDATE, DESIGNISSUEMASTER.DESIGN_BILLNO AS BILLNO,  DESIGNISSUEMASTER.DESIGN_REMARKS AS REMARKS, '' AS IMGPATH, ISNULL(DESIGNISSUEMASTER.DESIGN_SMALLRATE,0) AS SMALLRATE, ISNULL(DESIGNISSUEMASTER.DESIGN_MACRATE,0) AS MACRATE, ISNULL(DESIGNISSUEMASTER.DESIGN_TABLERATE,0) AS TABLERATE, ISNULL(DESIGNISSUEMASTER.DESIGN_AMOUNT,0) AS AMOUNT, SUM(MFGMASTER2_DESC.MFG_RECDMTRS) AS MTRS, (CASE WHEN ISNULL(DESIGNISSUEMASTER.DESIGN_AMOUNT,0)  > 0 THEN ROUND(SUM(MFGMASTER2_DESC.MFG_RECDMTRS) / DESIGNISSUEMASTER.DESIGN_AMOUNT,2) ELSE 0 END) AS COST FROM DESIGNISSUEMASTER INNER JOIN LEDGERS ON DESIGNISSUEMASTER.DESIGN_LEDGERID = LEDGERS.Acc_id INNER JOIN ISSUEMERCHANTMASTER ON DESIGNISSUEMASTER.DESIGN_MERCHANTID = ISSUEMERCHANTMASTER.ISSUEMERCHANT_id LEFT OUTER JOIN DESIGNRECIPE ON DESIGNISSUEMASTER.DESIGN_DESIGNNO = DESIGNRECIPE.DESIGN_NO AND DESIGNISSUEMASTER.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID LEFT OUTER JOIN MFGMASTER2 INNER JOIN MFGMASTER2_DESC ON MFGMASTER2.MFG_NO = MFGMASTER2_DESC.MFG_NO AND MFGMASTER2.MFG_YEARID = MFGMASTER2_DESC.MFG_YEARID ON DESIGNRECIPE.DESIGN_ID = MFGMASTER2.MFG_DESIGNID WHERE DESIGNISSUEMASTER.DESIGN_RECDATE = '  /  /' " & WHERECLAUSE & " GROUP BY DESIGNISSUEMASTER.DESIGN_ISSNO, DESIGNISSUEMASTER.DESIGN_ISSDATE, DESIGNISSUEMASTER.DESIGN_SKETCHNO, LEDGERS.Acc_cmpname, DESIGNISSUEMASTER.DESIGN_MACHINE, DESIGNISSUEMASTER.DESIGN_SMALL1, DESIGNISSUEMASTER.DESIGN_BIG, DESIGNISSUEMASTER.DESIGN_TABLE, ISSUEMERCHANTMASTER.ISSUEMERCHANT_name, DESIGNISSUEMASTER.DESIGN_DESIGNNO, DESIGNISSUEMASTER.DESIGN_BILLNO, DESIGNISSUEMASTER.DESIGN_REMARKS, ISNULL(DESIGNISSUEMASTER.DESIGN_SMALLRATE, 0), ISNULL(DESIGNISSUEMASTER.DESIGN_MACRATE, 0), ISNULL(DESIGNISSUEMASTER.DESIGN_TABLERATE, 0), ISNULL(DESIGNISSUEMASTER.DESIGN_AMOUNT, 0), DESIGNISSUEMASTER.DESIGN_RECDATE, DESIGNISSUEMASTER.DESIGN_BILLDATE, DESIGNISSUEMASTER.DESIGN_AMOUNT " & ORDERBYCLAUSE, "", "")
            ElseIf RBRECD.Checked = True Then
                dt = objclsCMST.Execute_Any_String(" SELECT DESIGNISSUEMASTER.DESIGN_ISSNO AS ISSUENO, DESIGNISSUEMASTER.DESIGN_ISSDATE AS ISSDATE, DESIGNISSUEMASTER.DESIGN_SKETCHNO AS SKETCHNO, LEDGERS.Acc_cmpname AS NAME, DESIGNISSUEMASTER.DESIGN_MACHINE AS MACHINE, DESIGNISSUEMASTER.DESIGN_SMALL1 AS SMALL1, DESIGNISSUEMASTER.DESIGN_BIG AS BIG, DESIGNISSUEMASTER.DESIGN_TABLE AS [TABLE], ISSUEMERCHANTMASTER.ISSUEMERCHANT_name AS MERCHANT, CASE WHEN DESIGNISSUEMASTER.DESIGN_RECDATE = '__/__/____' THEN '' ELSE CAST(RIGHT(DESIGNISSUEMASTER.DESIGN_RECDATE,4) + '-' + SUBSTRING(DESIGNISSUEMASTER.DESIGN_RECDATE,4,2) + '-' + LEFT(DESIGNISSUEMASTER.DESIGN_RECDATE,2) AS DATE) END AS RECDATE, DESIGNISSUEMASTER.DESIGN_DESIGNNO AS DESIGNNO, CASE WHEN DESIGNISSUEMASTER.DESIGN_BILLDATE  = '__/__/____' THEN '' ELSE DESIGNISSUEMASTER.DESIGN_BILLDATE END AS BILLDATE, DESIGNISSUEMASTER.DESIGN_BILLNO AS BILLNO,  DESIGNISSUEMASTER.DESIGN_REMARKS AS REMARKS, '' AS IMGPATH, ISNULL(DESIGNISSUEMASTER.DESIGN_SMALLRATE,0) AS SMALLRATE, ISNULL(DESIGNISSUEMASTER.DESIGN_MACRATE,0) AS MACRATE, ISNULL(DESIGNISSUEMASTER.DESIGN_TABLERATE,0) AS TABLERATE, ISNULL(DESIGNISSUEMASTER.DESIGN_AMOUNT,0) AS AMOUNT, SUM(MFGMASTER2_DESC.MFG_RECDMTRS) AS MTRS, (CASE WHEN ISNULL(DESIGNISSUEMASTER.DESIGN_AMOUNT,0)  > 0 THEN ROUND(SUM(MFGMASTER2_DESC.MFG_RECDMTRS) / DESIGNISSUEMASTER.DESIGN_AMOUNT,2) ELSE 0 END) AS COST FROM DESIGNISSUEMASTER INNER JOIN LEDGERS ON DESIGNISSUEMASTER.DESIGN_LEDGERID = LEDGERS.Acc_id INNER JOIN ISSUEMERCHANTMASTER ON DESIGNISSUEMASTER.DESIGN_MERCHANTID = ISSUEMERCHANTMASTER.ISSUEMERCHANT_id LEFT OUTER JOIN DESIGNRECIPE ON DESIGNISSUEMASTER.DESIGN_DESIGNNO = DESIGNRECIPE.DESIGN_NO AND DESIGNISSUEMASTER.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID LEFT OUTER JOIN MFGMASTER2 INNER JOIN MFGMASTER2_DESC ON MFGMASTER2.MFG_NO = MFGMASTER2_DESC.MFG_NO AND MFGMASTER2.MFG_YEARID = MFGMASTER2_DESC.MFG_YEARID ON DESIGNRECIPE.DESIGN_ID = MFGMASTER2.MFG_DESIGNID WHERE DESIGNISSUEMASTER.DESIGN_RECDATE <> '  /  /' " & WHERECLAUSE & " GROUP BY DESIGNISSUEMASTER.DESIGN_ISSNO, DESIGNISSUEMASTER.DESIGN_ISSDATE, DESIGNISSUEMASTER.DESIGN_SKETCHNO, LEDGERS.Acc_cmpname, DESIGNISSUEMASTER.DESIGN_MACHINE, DESIGNISSUEMASTER.DESIGN_SMALL1, DESIGNISSUEMASTER.DESIGN_BIG, DESIGNISSUEMASTER.DESIGN_TABLE, ISSUEMERCHANTMASTER.ISSUEMERCHANT_name, DESIGNISSUEMASTER.DESIGN_DESIGNNO, DESIGNISSUEMASTER.DESIGN_BILLNO, DESIGNISSUEMASTER.DESIGN_REMARKS, ISNULL(DESIGNISSUEMASTER.DESIGN_SMALLRATE, 0), ISNULL(DESIGNISSUEMASTER.DESIGN_MACRATE, 0), ISNULL(DESIGNISSUEMASTER.DESIGN_TABLERATE, 0), ISNULL(DESIGNISSUEMASTER.DESIGN_AMOUNT, 0), DESIGNISSUEMASTER.DESIGN_RECDATE, DESIGNISSUEMASTER.DESIGN_BILLDATE, DESIGNISSUEMASTER.DESIGN_AMOUNT " & ORDERBYCLAUSE, "", "")
            ElseIf RBALL.Checked = True Then
                dt = objclsCMST.Execute_Any_String(" SELECT DESIGNISSUEMASTER.DESIGN_ISSNO AS ISSUENO, DESIGNISSUEMASTER.DESIGN_ISSDATE AS ISSDATE, DESIGNISSUEMASTER.DESIGN_SKETCHNO AS SKETCHNO, LEDGERS.Acc_cmpname AS NAME, DESIGNISSUEMASTER.DESIGN_MACHINE AS MACHINE, DESIGNISSUEMASTER.DESIGN_SMALL1 AS SMALL1, DESIGNISSUEMASTER.DESIGN_BIG AS BIG, DESIGNISSUEMASTER.DESIGN_TABLE AS [TABLE], ISSUEMERCHANTMASTER.ISSUEMERCHANT_name AS MERCHANT, CASE WHEN DESIGNISSUEMASTER.DESIGN_RECDATE = '__/__/____' THEN '' ELSE DESIGNISSUEMASTER.DESIGN_RECDATE END AS RECDATE, DESIGNISSUEMASTER.DESIGN_DESIGNNO AS DESIGNNO, CASE WHEN DESIGNISSUEMASTER.DESIGN_BILLDATE  = '__/__/____' THEN '' ELSE DESIGNISSUEMASTER.DESIGN_BILLDATE END AS BILLDATE, DESIGNISSUEMASTER.DESIGN_BILLNO AS BILLNO,  DESIGNISSUEMASTER.DESIGN_REMARKS AS REMARKS, '' AS IMGPATH, ISNULL(DESIGNISSUEMASTER.DESIGN_SMALLRATE,0) AS SMALLRATE, ISNULL(DESIGNISSUEMASTER.DESIGN_MACRATE,0) AS MACRATE, ISNULL(DESIGNISSUEMASTER.DESIGN_TABLERATE,0) AS TABLERATE, ISNULL(DESIGNISSUEMASTER.DESIGN_AMOUNT,0) AS AMOUNT, SUM(MFGMASTER2_DESC.MFG_RECDMTRS) AS MTRS, (CASE WHEN ISNULL(DESIGNISSUEMASTER.DESIGN_AMOUNT,0)  > 0 THEN ROUND(SUM(MFGMASTER2_DESC.MFG_RECDMTRS) / DESIGNISSUEMASTER.DESIGN_AMOUNT,2) ELSE 0 END) AS COST FROM DESIGNISSUEMASTER INNER JOIN LEDGERS ON DESIGNISSUEMASTER.DESIGN_LEDGERID = LEDGERS.Acc_id INNER JOIN ISSUEMERCHANTMASTER ON DESIGNISSUEMASTER.DESIGN_MERCHANTID = ISSUEMERCHANTMASTER.ISSUEMERCHANT_id LEFT OUTER JOIN DESIGNRECIPE ON DESIGNISSUEMASTER.DESIGN_DESIGNNO = DESIGNRECIPE.DESIGN_NO AND DESIGNISSUEMASTER.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID LEFT OUTER JOIN MFGMASTER2 INNER JOIN MFGMASTER2_DESC ON MFGMASTER2.MFG_NO = MFGMASTER2_DESC.MFG_NO AND MFGMASTER2.MFG_YEARID = MFGMASTER2_DESC.MFG_YEARID ON DESIGNRECIPE.DESIGN_ID = MFGMASTER2.MFG_DESIGNID WHERE 1 = 1 " & WHERECLAUSE & " GROUP BY DESIGNISSUEMASTER.DESIGN_ISSNO, DESIGNISSUEMASTER.DESIGN_ISSDATE, DESIGNISSUEMASTER.DESIGN_SKETCHNO, LEDGERS.Acc_cmpname, DESIGNISSUEMASTER.DESIGN_MACHINE, DESIGNISSUEMASTER.DESIGN_SMALL1, DESIGNISSUEMASTER.DESIGN_BIG, DESIGNISSUEMASTER.DESIGN_TABLE, ISSUEMERCHANTMASTER.ISSUEMERCHANT_name, DESIGNISSUEMASTER.DESIGN_DESIGNNO, DESIGNISSUEMASTER.DESIGN_BILLNO, DESIGNISSUEMASTER.DESIGN_REMARKS, ISNULL(DESIGNISSUEMASTER.DESIGN_SMALLRATE, 0), ISNULL(DESIGNISSUEMASTER.DESIGN_MACRATE, 0), ISNULL(DESIGNISSUEMASTER.DESIGN_TABLERATE, 0), ISNULL(DESIGNISSUEMASTER.DESIGN_AMOUNT, 0), DESIGNISSUEMASTER.DESIGN_RECDATE, DESIGNISSUEMASTER.DESIGN_BILLDATE, DESIGNISSUEMASTER.DESIGN_AMOUNT " & ORDERBYCLAUSE, "", "")
            End If

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

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("ISSUENO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal ISSUENO As String)
        Try
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJDESIGN As New DesignIssue
                OBJDESIGN.MdiParent = MDIMain
                OBJDESIGN.EDIT = editval
                OBJDESIGN.TEMPISSUENO = ISSUENO
                OBJDESIGN.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Design Issue Register.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Design Issue Register"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Design Issue Register", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("ISSUENO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        FILLGRID(" and DESIGNISSUEMASTER.DESIGN_YEARID=" & YearId)
    End Sub

  
End Class