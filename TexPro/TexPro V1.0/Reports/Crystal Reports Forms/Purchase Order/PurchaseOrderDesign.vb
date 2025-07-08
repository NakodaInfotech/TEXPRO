
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports System.IO

Public Class PurchaseOrderDesign

    Public FORMULA As String

    Dim RPTGREYPO As New GreyPOReport
    Dim RPTPO As New POReport
    Dim RPTPOPARTYSUMM As New POPartyWiseSummary
    Dim RPTPOPARTYDTLS As New POPartyWiseDetails
    Dim RPTPOSTATUSDTLS As New POStatusDetailsReport

    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions
    Public vendorname As String
    'NEWLY ADDED

    Public FRMSTRING As String
    Public FROMDATE As String
    Public TODATE As String
    Public OPENINGDATE As String
    Public WHERECLAUSE As String
    Public PERIOD As String
    Public PARTYNAME As String
    Public AGENTNAME As String

    Public PONO As Integer
    Public PRINTSETTING As Object = Nothing
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public DIRECTWHATSAPP As Boolean = False
    Public NOOFCOPIES As Integer = 1

    Private Sub PurchaseOrderDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub PurchaseOrderDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If DIRECTPRINT = True Then
                PRINTDIRECTLYTOPRINTER()
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

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

            If FRMSTRING = "GREYPOREPORT" Then
                crTables = RPTGREYPO.Database.Tables
            ElseIf FRMSTRING = "POREPORT" Then
                crTables = RPTPO.Database.Tables
            ElseIf FRMSTRING = "POSUMM" Then
                crTables = RPTPOPARTYSUMM.Database.Tables
            ElseIf FRMSTRING = "PODTLS" Then
                crTables = RPTPOPARTYDTLS.Database.Tables
            ElseIf FRMSTRING = "POSTATUSDTLS" Then
                crTables = RPTPOSTATUSDTLS.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = FORMULA

            If FRMSTRING = "GREYPOREPORT" Then
                crpo.ReportSource = RPTGREYPO
            ElseIf FRMSTRING = "POREPORT" Then
                crpo.ReportSource = RPTPO
            ElseIf FRMSTRING = "POSUMM" Then
                crpo.ReportSource = RPTPOPARTYSUMM
            ElseIf FRMSTRING = "PODTLS" Then
                crpo.ReportSource = RPTPOPARTYDTLS
            ElseIf FRMSTRING = "POSTATUSDTLS" Then
                crpo.ReportSource = RPTPOSTATUSDTLS
            End If



            '************************ END *******************
            crpo.Zoom(100)
            crpo.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTDIRECTLYTOPRINTER()
        Try
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

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


            Dim OBJ As New Object

            If FRMSTRING = "GREYPOREPORT" Then
                OBJ = New GreyPOReport
            ElseIf FRMSTRING = "POREPORT" Then
                OBJ = New POReport
            End If

SKIPINVOICE:
            crTables = OBJ.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJ.RecordSelectionFormula = FORMULA
            OBJ.REFRESH()

            If DIRECTMAIL = False And DIRECTWHATSAPP = False Then
                OBJ.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
                OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
            Else
                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions
                oDfDopt.DiskFileName = Application.StartupPath & "\POREPORT_" & PONO & ".pdf"
                If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)
                expo = OBJ.ExportOptions
                OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
                OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Dim emailid As String = ""
        Dim emailid1 As String = ""
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Transfer()
        Dim tempattachment As String

        Dim objmail As New SendMail

        If PARTYNAME <> "" Then
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search("ACC_EMAIL AS EMAILID", "", "LEDGERS", " and ACC_CMPNAME = '" & PARTYNAME & "' AND ACC_YEARID=" & YearId)
            If dt.Rows.Count > 0 Then
                emailid = dt.Rows(0).Item(0).ToString
            End If
        End If

        If AGENTNAME <> "" Then
            Dim OBJCMN As New ClsCommon
            Dim dt As DataTable = OBJCMN.search("ACC_EMAIL AS EMAILID", "", "LEDGERS", " and ACC_CMPNAME = '" & AGENTNAME & "' AND ACC_YEARID=" & YearId)
            If dt.Rows.Count > 0 Then
                emailid1 = dt.Rows(0).Item(0).ToString
            End If
        End If

        If FRMSTRING = "POREPORT" Then
            tempattachment = "POREPORT"
            objmail.subject = "Purchase Order"
        End If

        Try
            'Dim objmail As New SendMail
            objmail.attachment = tempattachment
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If emailid <> "" Then objmail.cmbfirstadd.Text = emailid
            If emailid1 <> "" Then objmail.cmbsecondadd.Text = emailid1
            objmail.Show()
            objmail.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
        Windows.Forms.Cursor.Current = Cursors.Arrow
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            oDfDopt.DiskFileName = Application.StartupPath & "\POREPORT.PDF"
            If FRMSTRING = "GREYPOREPORT" Then
                expo = RPTGREYPO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGREYPO.Export()
            ElseIf FRMSTRING = "POREPORT" Then
                expo = RPTPO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPO.Export()
            ElseIf FRMSTRING = "POSUMM" Then
                expo = RPTPOPARTYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPOPARTYSUMM.Export()
            ElseIf FRMSTRING = "PODTLS" Then
                expo = RPTPOPARTYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPOPARTYDTLS.Export()
            ElseIf FRMSTRING = "POSTATUSDTLS" Then
                expo = RPTPOSTATUSDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPOSTATUSDTLS.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class