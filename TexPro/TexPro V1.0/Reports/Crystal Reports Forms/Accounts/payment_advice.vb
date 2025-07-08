
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms.Form
Imports CrystalDecisions.Shared

Public Class payment_advice

    Public payno As Integer
    Public payname As String
    Public REGNAME As String
    Public FRMSTRING As String
    Public LEDGERSNAME As String
    Public NEFTRTGSNORMAL As String = "PARTY"
    Public FROMNO, TONO As Integer
    Public DIRECTPRINT As Boolean = False
    Public WHERECLAUSE As String = ""
    Public PERIOD As String = ""
    Public SHOWNARR As Integer = 0


    Dim obj_paytype As New Paymentreport
    Dim OBJCHQPAY As New ChqPayment
    Dim OBJCHQPAY_HDFC As New ChqPayment_HDFC

    Private Sub payment_advice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control = True And e.KeyCode = Keys.P Then
            CRPO.PrintReport()
        End If
    End Sub

    Private Sub payment_advice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strsearch As String
        strsearch = ""

        Try

            If DIRECTPRINT = True Then
                PRINTDIRECTLYTOPRINTER()
                Exit Sub
            End If

            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = Servername
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "CHQPRINT" Then
                If ClientName = "MONOGRAM" Then
                    crTables = OBJCHQPAY_HDFC.Database.Tables
                Else
                    crTables = OBJCHQPAY.Database.Tables
                End If
            Else
                crTables = obj_paytype.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************

            If FRMSTRING = "CHQPRINT" Then
                strsearch = strsearch & "  {PAYMENTMASTER.PAYMENT_NO}= " & payno & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {PAYMENTMASTER.PAYMENT_CMPID} = " & CmpId & " and {PAYMENTMASTER.PAYMENT_LOCATIONID} = " & Locationid & " and {PAYMENTMASTER.PAYMENT_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                If ClientName = "MONOGRAM" Then
                    CRPO.ReportSource = OBJCHQPAY_HDFC
                Else
                    CRPO.ReportSource = OBJCHQPAY
                End If
            Else
                strsearch = strsearch & "  {PAYMENT_REPORT.PAYMENTNO}= " & payno & " AND {PAYMENT_REPORT.REGNAME}= '" & REGNAME & "' and {LEDGERS.Acc_cmpname} = '" & payname & "' and {PAYMENT_REPORT.CMPID} = " & CmpId & " and {PAYMENT_REPORT.LOCATIONID} = " & Locationid & " and {PAYMENT_REPORT.YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = obj_paytype
            End If

            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.", _
                    MsgBoxStyle.Critical, "Load Report Error")
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim tempattachment As String

        tempattachment = "PAYMENTREPORT"
        Try
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.Show()
            objmail.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
        Windows.Forms.Cursor.Current = Cursors.Arrow
    End Sub

    Sub PRINTDIRECTLYTOPRINTER()

        For I As Integer = FROMNO To TONO

            Dim OBJ As Object

            If ClientName = "MONOGRAM" Then
                OBJ = New ChqPayment_HDFC
            Else
                OBJ = New ChqPayment
            End If

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

            crTables = OBJ.Database.Tables
            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJ.RecordSelectionFormula = " {PAYMENTMASTER.PAYMENT_NO}= " & I & " and {REGISTERMASTER.REGISTER_NAME} = '" & REGNAME & "' and {PAYMENTMASTER.PAYMENT_YEARID} = " & YearId
            OBJ.PrintToPrinter(1, True, 0, 0)

        Next
    End Sub

End Class