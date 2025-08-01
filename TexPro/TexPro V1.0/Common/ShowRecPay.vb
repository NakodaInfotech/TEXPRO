﻿
Imports BL

Public Class ShowRecPay

    Public PURBILLINITIALS As String
    Public SALEBILLINITIALS As String

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    Private Sub ShowRecPay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.O Then       'for Saving
                Call CMDOK_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ShowRecPay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search(" T.[Bill No] , T.Amt , T.BILLINITIALS, T.REGTYPE , T.TYPE, T.Date ", "", " ( SELECT JOURNALMASTER.JOURNAL_initials AS [Bill No], CASE WHEN SUM(JOURNALMASTER.JOURNAL_debit) > 0 THEN SUM(JOURNALMASTER.JOURNAL_debit) ELSE SUM(JOURNALMASTER.journal_credit) END AS Amt, JOURNALMASTER.JOURNAL_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'JOURNAL' AS TYPE, JOURNALMASTER.JOURNAL_Date AS [Date] FROM JOURNALMASTER INNER JOIN REGISTERMASTER ON JOURNALMASTER.JOURNAL_registerid = REGISTERMASTER.register_id AND JOURNALMASTER.JOURNAL_cmpid = REGISTERMASTER.register_cmpid AND JOURNALMASTER.JOURNAL_locationid = REGISTERMASTER.register_locationid AND JOURNALMASTER.JOURNAL_yearid = RegisterMaster.register_yearid  WHERE JOURNALMASTER.journal_CMPID = " & CmpId & " AND JOURNALMASTER.journal_LOCATIONID = " & Locationid & " AND JOURNALMASTER.journal_YEARID = " & YearId & " AND (JOURNALMASTER.journal_refno = '" & PURBILLINITIALS & "' OR JOURNALMASTER.journal_refno = '" & SALEBILLINITIALS & "') GROUP BY JOURNALMASTER.JOURNAL_no, JOURNALMASTER.JOURNAL_initials, REGISTERMASTER.register_name, JOURNALMASTER.JOURNAL_Date   UNION ALL SELECT PAYMENTMASTER_DESC.PAYMENT_initials AS [Bill No], SUM(PAYMENTMASTER_DESC.PAYMENT_amt) AS Amt, PAYMENTMASTER_DESC.PAYMENT_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'PAYMENT' AS TYPE, PAYMENTMASTER.PAYMENT_date as [Date] FROM PAYMENTMASTER_DESC INNER JOIN PAYMENTMASTER ON PAYMENTMASTER.PAYMENT_NO = PAYMENTMASTER_DESC.PAYMENT_NO AND PAYMENTMASTER.PAYMENT_REGISTERID = PAYMENTMASTER_DESC.PAYMENT_REGISTERID AND PAYMENTMASTER.PAYMENT_CMPID = PAYMENTMASTER_DESC.PAYMENT_CMPID AND PAYMENTMASTER.PAYMENT_LOCATIONID = PAYMENTMASTER_DESC.PAYMENT_LOCATIONID AND PAYMENTMASTER.PAYMENT_YEARID = PAYMENTMASTER_DESC.PAYMENT_YEARID INNER JOIN REGISTERMASTER ON PAYMENTMASTER_DESC.PAYMENT_registerid = REGISTERMASTER.register_id AND PAYMENTMASTER_DESC.PAYMENT_cmpid = REGISTERMASTER.register_cmpid AND PAYMENTMASTER_DESC.PAYMENT_locationid = REGISTERMASTER.register_locationid AND PAYMENTMASTER_DESC.PAYMENT_yearid = RegisterMaster.register_yearid WHERE PAYMENTMASTER.PAYMENT_CMPID = " & CmpId & " AND PAYMENTMASTER.PAYMENT_LOCATIONID = " & Locationid & " AND PAYMENTMASTER.PAYMENT_YEARID = " & YearId & " AND PAYMENTMASTER_DESC.PAYMENT_BILLINITIALS = '" & PURBILLINITIALS & "' GROUP BY PAYMENTMASTER_DESC.PAYMENT_no, PAYMENTMASTER_DESC.PAYMENT_initials, REGISTERMASTER.register_name, PAYMENTMASTER.PAYMENT_date  UNION  ALL SELECT RECEIPTMASTER_DESC.RECEIPT_initials AS [Bill No], SUM(RECEIPTMASTER_DESC.RECEIPT_amt) AS Amt, RECEIPTMASTER_DESC.RECEIPT_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'RECEIPT' AS TYPE, RECEIPTMASTER.RECEIPT_date as [Date] FROM RECEIPTMASTER_DESC INNER JOIN RECEIPTMASTER ON RECEIPTMASTER.RECEIPT_NO = RECEIPTMASTER_DESC.RECEIPT_NO AND RECEIPTMASTER.RECEIPT_REGISTERID = RECEIPTMASTER_DESC.RECEIPT_REGISTERID AND RECEIPTMASTER.RECEIPT_CMPID = RECEIPTMASTER_DESC.RECEIPT_CMPID AND RECEIPTMASTER.RECEIPT_LOCATIONID = RECEIPTMASTER_DESC.RECEIPT_LOCATIONID AND RECEIPTMASTER.RECEIPT_YEARID = RECEIPTMASTER_DESC.RECEIPT_YEARID INNER JOIN REGISTERMASTER ON RECEIPTMASTER_DESC.RECEIPT_registerid = REGISTERMASTER.register_id AND RECEIPTMASTER_DESC.RECEIPT_cmpid = REGISTERMASTER.register_cmpid AND RECEIPTMASTER_DESC.RECEIPT_locationid = REGISTERMASTER.register_locationid AND RECEIPTMASTER_DESC.RECEIPT_yearid = REGISTERMASTER.register_yearid WHERE RECEIPTMASTER.RECEIPT_CMPID = " & CmpId & " AND RECEIPTMASTER.RECEIPT_LOCATIONID = " & Locationid & " AND RECEIPTMASTER.RECEIPT_YEARID = " & YearId & " AND RECEIPTMASTER_DESC.RECEIPT_BILLINITIALS = '" & SALEBILLINITIALS & "' GROUP BY RECEIPTMASTER_DESC.RECEIPT_no, RECEIPTMASTER_DESC.RECEIPT_initials, REGISTERMASTER.register_name, RECEIPTMASTER.RECEIPT_date UNION ALL SELECT CREDITNOTEMASTER.CN_initials AS [Bill No], CREDITNOTEMASTER.CN_GTOTAL AS Amt, CN_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'CREDITNOTE' AS TYPE, CREDITNOTEMASTER.CN_date as [Date] FROM CREDITNOTEMASTER INNER JOIN REGISTERMASTER ON CREDITNOTEMASTER.CN_registerid = REGISTERMASTER.register_id AND CREDITNOTEMASTER.CN_cmpid = REGISTERMASTER.register_cmpid AND CREDITNOTEMASTER.CN_locationid = REGISTERMASTER.register_locationid AND CREDITNOTEMASTER.CN_yearid = REGISTERMASTER.register_yearid WHERE CN_CMPID = " & CmpId & " AND CN_LOCATIONID = " & Locationid & " AND CN_YEARID = " & YearId & " AND CN_BILLNO = '" & SALEBILLINITIALS & "' UNION ALL SELECT DEBITNOTEMASTER.DN_initials AS [Bill No], DEBITNOTEMASTER.DN_GTOTAL AS Amt, DN_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'DEBITNOTE' AS TYPE, DEBITNOTEMASTER.DN_date as [Date] FROM DEBITNOTEMASTER INNER JOIN REGISTERMASTER ON DEBITNOTEMASTER.DN_registerid = REGISTERMASTER.register_id AND DEBITNOTEMASTER.DN_cmpid = REGISTERMASTER.register_cmpid AND DEBITNOTEMASTER.DN_locationid = REGISTERMASTER.register_locationid AND DEBITNOTEMASTER.DN_yearid = REGISTERMASTER.register_yearid WHERE DN_CMPID = " & CmpId & " AND DN_LOCATIONID = " & Locationid & " AND DN_YEARID = " & YearId & " AND DN_BILLNO = '" & PURBILLINITIALS & "') AS T ", "")
            Dim DT As DataTable = OBJCMN.search(" T.[Bill No] , T.Amt , T.BILLINITIALS, T.REGTYPE , T.TYPE, T.Date ", "", " (SELECT JOURNALMASTER.journal_initials AS [Bill No], CASE WHEN SUM(JOURNALMASTER.JOURNAL_debit) > 0 THEN SUM(JOURNALMASTER.JOURNAL_debit) ELSE SUM(JOURNALMASTER.journal_credit) END AS Amt, JOURNALMASTER.journal_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'JOURNAL' AS TYPE, JOURNALMASTER.journal_date AS Date FROM JOURNALMASTER INNER JOIN REGISTERMASTER ON JOURNALMASTER.journal_registerid = REGISTERMASTER.register_id AND JOURNALMASTER.journal_cmpid = REGISTERMASTER.register_cmpid AND JOURNALMASTER.journal_locationid = REGISTERMASTER.register_locationid AND JOURNALMASTER.journal_yearid = REGISTERMASTER.register_yearid WHERE     (JOURNALMASTER.journal_cmpid = " & CmpId & ") AND (JOURNALMASTER.journal_locationid = " & Locationid & "  ) AND (JOURNALMASTER.journal_yearid = " & YearId & " ) AND (JOURNALMASTER.journal_refno = '" & PURBILLINITIALS & "' OR JOURNALMASTER.journal_refno = '" & SALEBILLINITIALS & "') GROUP BY JOURNALMASTER.journal_no, JOURNALMASTER.journal_initials, REGISTERMASTER.register_name, JOURNALMASTER.journal_date UNION  ALL SELECT 'MATCH-' + CAST(MANUALMATCHING_DESC.MATCH_NO AS VARCHAR) AS [Bill No], SUM(MANUALMATCHING_DESC.MATCH_PAIDAMT) AS Amt, MANUALMATCHING_DESC.MATCH_no AS BILLINITIALS, '' AS REGTYPE, 'MATCHING' AS TYPE, MANUALMATCHING.MATCH_date AS Date FROM MANUALMATCHING_DESC INNER JOIN MANUALMATCHING ON MANUALMATCHING.MATCH_no = MANUALMATCHING_DESC.MATCH_no AND MANUALMATCHING.MATCH_cmpid = MANUALMATCHING_DESC.MATCH_cmpid AND MANUALMATCHING.MATCH_locationid = MANUALMATCHING_DESC.MATCH_locationid AND MANUALMATCHING.MATCH_yearid = MANUALMATCHING_DESC.MATCH_yearid WHERE (MANUALMATCHING.MATCH_cmpid = " & CmpId & ") AND (MANUALMATCHING.MATCH_locationid = " & Locationid & ") AND (MANUALMATCHING.MATCH_YEARID = " & YearId & ") AND ((MANUALMATCHING_DESC.MATCH_BILLINITIALS = '" & PURBILLINITIALS & "') OR (MANUALMATCHING_DESC.MATCH_BILLINITIALS = '" & SALEBILLINITIALS & "')) GROUP BY MANUALMATCHING_DESC.MATCH_no, MANUALMATCHING_DESC.MATCH_NO, MANUALMATCHING.MATCH_date  UNION ALL SELECT PAYMENTMASTER_DESC.PAYMENT_initials AS [Bill No], SUM(PAYMENTMASTER_DESC.PAYMENT_amt) AS Amt, PAYMENTMASTER_DESC.PAYMENT_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'PAYMENT' AS TYPE, PAYMENTMASTER.PAYMENT_date AS Date FROM PAYMENTMASTER_DESC INNER JOIN PAYMENTMASTER ON PAYMENTMASTER.PAYMENT_no = PAYMENTMASTER_DESC.PAYMENT_no AND PAYMENTMASTER.PAYMENT_registerid = PAYMENTMASTER_DESC.PAYMENT_registerid AND PAYMENTMASTER.PAYMENT_cmpid = PAYMENTMASTER_DESC.PAYMENT_cmpid AND PAYMENTMASTER.PAYMENT_locationid = PAYMENTMASTER_DESC.PAYMENT_locationid AND PAYMENTMASTER.PAYMENT_yearid = PAYMENTMASTER_DESC.PAYMENT_yearid INNER JOIN REGISTERMASTER ON PAYMENTMASTER_DESC.PAYMENT_registerid = REGISTERMASTER.register_id AND PAYMENTMASTER_DESC.PAYMENT_cmpid = REGISTERMASTER.register_cmpid AND PAYMENTMASTER_DESC.PAYMENT_locationid = REGISTERMASTER.register_locationid AND PAYMENTMASTER_DESC.PAYMENT_yearid = REGISTERMASTER.register_yearid WHERE     (PAYMENTMASTER.PAYMENT_cmpid = " & CmpId & ") AND (PAYMENTMASTER.PAYMENT_locationid = " & Locationid & ") AND (PAYMENTMASTER.PAYMENT_YEARID = " & YearId & ") AND (PAYMENTMASTER_DESC.PAYMENT_BILLINITIALS = '" & PURBILLINITIALS & "') GROUP BY PAYMENTMASTER_DESC.PAYMENT_no, PAYMENTMASTER_DESC.PAYMENT_initials, REGISTERMASTER.register_name, PAYMENTMASTER.PAYMENT_date UNION ALL SELECT RECEIPTMASTER_DESC.receipt_initials AS [Bill No], SUM(RECEIPTMASTER_DESC.receipt_amt) AS Amt, RECEIPTMASTER_DESC.receipt_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'RECEIPT' AS TYPE, RECEIPTMASTER.receipt_date AS Date FROM RECEIPTMASTER_DESC INNER JOIN RECEIPTMASTER ON RECEIPTMASTER.receipt_no = RECEIPTMASTER_DESC.receipt_no AND RECEIPTMASTER.receipt_registerid = RECEIPTMASTER_DESC.receipt_registerid AND RECEIPTMASTER.receipt_cmpid = RECEIPTMASTER_DESC.receipt_cmpid AND RECEIPTMASTER.receipt_locationid = RECEIPTMASTER_DESC.receipt_locationid AND RECEIPTMASTER.receipt_yearid = RECEIPTMASTER_DESC.receipt_yearid INNER JOIN REGISTERMASTER ON RECEIPTMASTER_DESC.receipt_registerid = REGISTERMASTER.register_id AND RECEIPTMASTER_DESC.receipt_cmpid = REGISTERMASTER.register_cmpid AND RECEIPTMASTER_DESC.receipt_locationid = REGISTERMASTER.register_locationid AND RECEIPTMASTER_DESC.receipt_yearid = REGISTERMASTER.register_yearid WHERE     (RECEIPTMASTER.receipt_cmpid = " & CmpId & ") AND (RECEIPTMASTER.receipt_locationid = " & Locationid & ") AND (RECEIPTMASTER.receipt_YEARID = " & YearId & ") AND (RECEIPTMASTER_DESC.RECEIPT_BILLINITIALS = '" & SALEBILLINITIALS & "') GROUP BY RECEIPTMASTER_DESC.receipt_no, RECEIPTMASTER_DESC.receipt_initials, REGISTERMASTER.register_name, RECEIPTMASTER.receipt_date UNION ALL SELECT CREDITNOTEMASTER.CN_initials AS [Bill No], CREDITNOTEMASTER.CN_GTOTAL AS Amt, CREDITNOTEMASTER.CN_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'CREDITNOTE' AS TYPE, CREDITNOTEMASTER.CN_date AS Date FROM CREDITNOTEMASTER INNER JOIN REGISTERMASTER ON CREDITNOTEMASTER.CN_registerid = REGISTERMASTER.register_id AND CREDITNOTEMASTER.CN_cmpid = REGISTERMASTER.register_cmpid AND CREDITNOTEMASTER.CN_locationid = REGISTERMASTER.register_locationid AND CREDITNOTEMASTER.CN_yearid = REGISTERMASTER.register_yearid WHERE (CREDITNOTEMASTER.CN_cmpid = " & CmpId & ") AND (CREDITNOTEMASTER.CN_locationid = " & Locationid & ") AND (CREDITNOTEMASTER.CN_YEARID = " & YearId & ") AND (CREDITNOTEMASTER.CN_BILLNO = '" & SALEBILLINITIALS & "') UNION ALL SELECT DEBITNOTEMASTER.DN_initials AS [Bill No], DEBITNOTEMASTER.DN_GTOTAL AS Amt, DEBITNOTEMASTER.DN_no AS BILLINITIALS, REGISTERMASTER.register_name AS REGTYPE, 'DEBITNOTE' AS TYPE, DEBITNOTEMASTER.DN_date AS Date FROM DEBITNOTEMASTER INNER JOIN REGISTERMASTER ON DEBITNOTEMASTER.DN_registerid = REGISTERMASTER.register_id AND DEBITNOTEMASTER.DN_cmpid = REGISTERMASTER.register_cmpid AND DEBITNOTEMASTER.DN_locationid = REGISTERMASTER.register_locationid AND DEBITNOTEMASTER.DN_yearid = REGISTERMASTER.register_yearid WHERE (DEBITNOTEMASTER.DN_cmpid = " & CmpId & ") AND (DEBITNOTEMASTER.DN_locationid = " & Locationid & ") AND (DEBITNOTEMASTER.DN_YEARID = " & YearId & ") AND (DEBITNOTEMASTER.DN_BILLNO = '" & PURBILLINITIALS & "')) AS T ", "")
            If DT.Rows.Count > 0 Then
                GRIDRECPAY.DataSource = DT
                GRIDRECPAY.Columns(0).Width = 150
                GRIDRECPAY.Columns(1).Width = 150
                GRIDRECPAY.Columns(2).Visible = False
                GRIDRECPAY.Columns(3).Visible = False
                GRIDRECPAY.Columns(4).Visible = False
                GRIDRECPAY.Columns(5).Width = 85

                GRIDRECPAY.Columns(1).DefaultCellStyle.Format = "N2"
                GRIDRECPAY.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GRIDRECPAY.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                TXTTOTAL.Clear()
                For Each ROW As DataGridViewRow In GRIDRECPAY.Rows
                    TXTTOTAL.Text = Format(Val(TXTTOTAL.Text.Trim) + Val(ROW.Cells(1).Value), "0.00")
                Next

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            ' SHOWFORM()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SHOWFORM()
        Try
            For Each ROW As DataGridViewRow In GRIDRECPAY.SelectedRows

                If ROW.Cells(4).Value.ToString = "PAYMENT" Then

                    Dim OBJPAYMENT As New PaymentMaster
                    OBJPAYMENT.MdiParent = MDIMain
                    OBJPAYMENT.edit = True
                    OBJPAYMENT.TEMPPAYMENTNO = ROW.Cells(2).Value.ToString
                    OBJPAYMENT.TEMPREGNAME = ROW.Cells(3).Value.ToString
                    OBJPAYMENT.Show()

                ElseIf ROW.Cells(4).Value.ToString = "RECEIPT" Then

                    Dim OBJREC As New Receipt
                    OBJREC.MdiParent = MDIMain
                    OBJREC.edit = True
                    OBJREC.TEMPRECEIPTNO = ROW.Cells(2).Value.ToString
                    OBJREC.TEMPREGNAME = ROW.Cells(3).Value.ToString
                    OBJREC.Show()
                ElseIf ROW.Cells(4).Value.ToString = "JOURNAL" Then

                    Dim OBJJV As New journal
                    OBJJV.MdiParent = MDIMain
                    OBJJV.edit = True
                    OBJJV.tempjvno = ROW.Cells(2).Value.ToString
                    OBJJV.TEMPREGNAME = ROW.Cells(3).Value.ToString
                    OBJJV.Show()

                ElseIf ROW.Cells(4).Value.ToString = "CREDITNOTE" Then

                    Dim OBJCN As New CREDITNOTE
                    OBJCN.MdiParent = MDIMain
                    OBJCN.edit = True
                    OBJCN.TEMPCNNO = ROW.Cells(2).Value.ToString
                    OBJCN.TEMPREGNAME = ROW.Cells(3).Value.ToString
                    OBJCN.Show()

                ElseIf ROW.Cells(4).Value.ToString = "DEBITNOTE" Then

                    Dim OBJDN As New DebitNote
                    OBJDN.MdiParent = MDIMain
                    OBJDN.edit = True
                    OBJDN.TEMPDNNO = ROW.Cells(2).Value.ToString
                    OBJDN.TEMPREGNAME = ROW.Cells(3).Value.ToString
                    OBJDN.Show()

                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDRECPAY_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRECPAY.CellDoubleClick
        Try
            SHOWFORM()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class