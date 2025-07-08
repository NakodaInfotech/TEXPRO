﻿
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class SaleInvoiceDesign

    Public FRMSTRING As String
    Public WHERECLAUSE As String
    Public SELECTEDRATE As String
    Public PLREMARKS As String
    Public PLDESC As String
    Public PERIOD As String
    Public COMMISSIONONRECDAMT As Boolean
    Public FROMDATE As Date
    Public TODATE As Date
    Public RECDAMT As Decimal
    Public COMMPER As Double
    Public PENDINGSO As String
    Public NEWPAGE As Boolean
    Public BALERATE As Double = 0.0
    Public ROLLRATE As Double = 0.0

    Dim RPTCOVERNOTE As New CoverNoteReport
    Dim RPTCOMM As New InvoiceAgentCommReport
    Dim RPTCOMMSUMM As New InvoiceAgentCommSummReport
    Dim RPTAGENTENTRYWISE As New InvoiceAgentPartyEntryWiseReport
    Dim RPTJOBBERDTLS As New InvoiceAgentWiseDetails
    Dim RPTJOBBERSUMM As New InvoiceAgentWiseSummary
    Dim RPTSHADEDTLS As New InvoiceColorWiseDetails
    Dim RPTSHADESUMM As New InvoiceColorWiseSummary
    Dim RPTDESIGNDTLS As New InvoiceDesignWiseDetails
    Dim RPTDESIGNSUMM As New InvoiceDesignWiseSummary
    Dim RPTDOCDTLS As New InvoiceDocumentWiseDetails
    Dim RPTENTRYWISE As New InvoiceEntryWiseReport
    Dim RPTITEMDTLS As New InvoiceItemWiseDetails
    Dim RPTITEMSUMM As New InvoiceItemWiseSummary
    Dim RPTCHARGESDTLS As New InvoiceChargesWiseDetails
    Dim RPTCHARGESSUMM As New InvoiceChargesWiseSummary
    Dim RPTMONTHLY As New InvoiceMonthWise
    Dim RPTPARTYENTRYWISE As New InvoicePartyEntryWiseReport
    Dim RPTPARTYDTLS As New InvoicePartyWiseDetails
    Dim RPTPARTYSUMM As New InvoicePartyWiseSummary
    Dim RPTQUALITYDTLS As New InvoiceQualityWiseDetails
    Dim RPTQUALITYSUMM As New InvoiceQualityWiseSummary
    Dim RPTREFDTLS As New InvoiceRefNoWiseDetails
    Dim RPTTRANSDTLS As New InvoiceTransWiseDetails
    Dim RPTTRANSSUMM As New InvoiceTransWiseSummary
    Dim RPTITEMWISEGROUP As New InvoiceItemWiseGroupReport


    Dim RPTSOSTATUS As New SOStatusReport
    Dim RPTSOSTATUSDTLS As New SOStatusDetailsReport
    Dim RPTSOSTATUSITEM As New SOItemStatusReport


    Dim RPTPENDING As New GRNPendingCheck

    Dim RPTLABEL As New StickerLabelReport

    Public POSOFRMSTRING As String

    Private Sub SaleInvoiceDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Cursor.Current = Cursors.WaitCursor

            If POSOFRMSTRING = "PO" Then Me.Text = "Purchase Order"
            If POSOFRMSTRING = "SO" Then Me.Text = "Sale Order"

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

            If FRMSTRING = "PARTYWISEDTLS" Then crTables = RPTPARTYDTLS.Database.Tables
            If FRMSTRING = "PARTYWISESUMM" Then crTables = RPTPARTYSUMM.Database.Tables

            If FRMSTRING = "JOBBERWISEDTLS" Then crTables = RPTJOBBERDTLS.Database.Tables
            If FRMSTRING = "JOBBERWISESUMM" Then crTables = RPTJOBBERSUMM.Database.Tables

            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTITEMDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTITEMSUMM.Database.Tables
            If FRMSTRING = "ITEMWISEGROUP" Then crTables = RPTITEMWISEGROUP.Database.Tables

            If FRMSTRING = "QUALITYWISEDTLS" Then crTables = RPTQUALITYDTLS.Database.Tables
            If FRMSTRING = "QUALITYWISESUMM" Then crTables = RPTQUALITYSUMM.Database.Tables

            If FRMSTRING = "DESIGNWISEDTLS" Then crTables = RPTDESIGNDTLS.Database.Tables
            If FRMSTRING = "DESIGNWISESUMM" Then crTables = RPTDESIGNSUMM.Database.Tables

            If FRMSTRING = "SHADEWISEDTLS" Then crTables = RPTSHADEDTLS.Database.Tables
            If FRMSTRING = "SHADEWISESUMM" Then crTables = RPTSHADESUMM.Database.Tables

            If FRMSTRING = "CHARGESWISEDTLS" Then crTables = RPTCHARGESDTLS.Database.Tables
            If FRMSTRING = "CHARGESWISESUMM" Then crTables = RPTCHARGESSUMM.Database.Tables


            If FRMSTRING = "TRANSWISEDTLS" Then crTables = RPTTRANSDTLS.Database.Tables
            If FRMSTRING = "TRANSWISESUMM" Then crTables = RPTTRANSSUMM.Database.Tables


            If FRMSTRING = "DOCUMENT" Then crTables = RPTDOCDTLS.Database.Tables
            If FRMSTRING = "REFFNO" Then crTables = RPTREFDTLS.Database.Tables
            If FRMSTRING = "COMMISSION" Then crTables = RPTCOMM.Database.Tables
            If FRMSTRING = "COMMSUMM" Then crTables = RPTCOMMSUMM.Database.Tables

            If FRMSTRING = "COVERNOTE" Then crTables = RPTCOVERNOTE.Database.Tables
            If FRMSTRING = "LABEL" Then crTables = RPTLABEL.Database.Tables
            If FRMSTRING = "ENTRYWISE" Then crTables = RPTENTRYWISE.Database.Tables
            If FRMSTRING = "PARTYENTRYWISE" Then crTables = RPTPARTYENTRYWISE.Database.Tables
            If FRMSTRING = "AGENTENTRYWISE" Then crTables = RPTAGENTENTRYWISE.Database.Tables

            If FRMSTRING = "MONTHLY" Then crTables = RPTMONTHLY.Database.Tables
            If FRMSTRING = "PENDING" Then crTables = RPTPENDING.Database.Tables


            If FRMSTRING = "SOSTATUS" Then crTables = RPTSOSTATUS.Database.Tables
            If FRMSTRING = "SOSTATUSDTLS" Then crTables = RPTSOSTATUSDTLS.Database.Tables
            If FRMSTRING = "SOSTATUSITEM" Then crTables = RPTSOSTATUSITEM.Database.Tables


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = WHERECLAUSE

            If FRMSTRING = "PARTYWISEDTLS" Then
                crpo.ReportSource = RPTPARTYDTLS
                RPTPARTYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYWISESUMM" Then
                crpo.ReportSource = RPTPARTYSUMM
                RPTPARTYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOBBERWISEDTLS" Then
                crpo.ReportSource = RPTJOBBERDTLS
                RPTJOBBERDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOBBERWISESUMM" Then
                crpo.ReportSource = RPTJOBBERSUMM
                RPTJOBBERSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                crpo.ReportSource = RPTITEMDTLS
                RPTITEMDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                crpo.ReportSource = RPTITEMSUMM
                RPTITEMSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYWISEDTLS" Then
                crpo.ReportSource = RPTQUALITYDTLS
                RPTQUALITYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYWISESUMM" Then
                crpo.ReportSource = RPTQUALITYSUMM
                RPTQUALITYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNWISEDTLS" Then
                crpo.ReportSource = RPTDESIGNDTLS
                RPTDESIGNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNWISESUMM" Then
                crpo.ReportSource = RPTDESIGNSUMM
                RPTDESIGNSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SHADEWISEDTLS" Then
                crpo.ReportSource = RPTSHADEDTLS
                RPTSHADEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SHADEWISESUMM" Then
                crpo.ReportSource = RPTSHADESUMM
                RPTSHADESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "CHARGESWISEDTLS" Then
                crpo.ReportSource = RPTCHARGESDTLS
                RPTCHARGESDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "CHARGESWISESUMM" Then
                crpo.ReportSource = RPTCHARGESSUMM
                RPTCHARGESSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "TRANSWISEDTLS" Then
                crpo.ReportSource = RPTTRANSDTLS
                RPTTRANSDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "TRANSWISESUMM" Then
                crpo.ReportSource = RPTTRANSSUMM
                RPTTRANSSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "MONTHLY" Then
                crpo.ReportSource = RPTMONTHLY
            ElseIf FRMSTRING = "ENTRYWISE" Then
                crpo.ReportSource = RPTENTRYWISE
                RPTENTRYWISE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYENTRYWISE" Then
                crpo.ReportSource = RPTPARTYENTRYWISE
                RPTPARTYENTRYWISE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTPARTYENTRYWISE.GroupFooterSection1.SectionFormat.EnableNewPageAfter = NEWPAGE
            ElseIf FRMSTRING = "AGENTENTRYWISE" Then
                crpo.ReportSource = RPTAGENTENTRYWISE
                RPTAGENTENTRYWISE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTAGENTENTRYWISE.GroupFooterSection4.SectionFormat.EnableNewPageAfter = NEWPAGE
            ElseIf FRMSTRING = "PENDING" Then
                crpo.ReportSource = RPTPENDING
                RPTPENDING.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DOCUMENT" Then
                crpo.ReportSource = RPTDOCDTLS
                RPTDOCDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "REFFNO" Then
                crpo.ReportSource = RPTREFDTLS
                RPTREFDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "COMMISSION" Then
                crpo.ReportSource = RPTCOMM
                RPTCOMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCOMM.DataDefinition.FormulaFields("COMMPER").Text = COMMPER
                If COMMISSIONONRECDAMT = True Then
                    RPTCOMM.DataDefinition.FormulaFields("CALCON").Text = "'" & RECDAMT & "'"
                End If
            ElseIf FRMSTRING = "COMMSUMM" Then
                crpo.ReportSource = RPTCOMMSUMM
                RPTCOMMSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTCOMMSUMM.DataDefinition.FormulaFields("COMMPER").Text = COMMPER
                If COMMISSIONONRECDAMT = True Then
                    RPTCOMMSUMM.DataDefinition.FormulaFields("CALCON").Text = "'" & RECDAMT & "'"
                End If
            ElseIf FRMSTRING = "COVERNOTE" Then
                crpo.ReportSource = RPTCOVERNOTE
            ElseIf FRMSTRING = "LABEL" Then
                crpo.ReportSource = RPTLABEL

            ElseIf FRMSTRING = "ITEMWISEGROUP" Then
                crpo.ReportSource = RPTITEMWISEGROUP
                RPTITEMWISEGROUP.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"


            ElseIf FRMSTRING = "SOSTATUS" Then
                crpo.ReportSource = RPTSOSTATUS
                RPTSOSTATUS.DataDefinition.FormulaFields("TYPE").Text = "'" & PENDINGSO & "'"
                RPTSOSTATUS.DataDefinition.FormulaFields("CLIENTNAME").Text = "'" & ClientName & "'"
            ElseIf FRMSTRING = "SOSTATUSDTLS" Then
                crpo.ReportSource = RPTSOSTATUSDTLS
                RPTSOSTATUSDTLS.DataDefinition.FormulaFields("CLIENTNAME").Text = "'" & ClientName & "'"
            ElseIf FRMSTRING = "SOSTATUSITEM" Then
                crpo.ReportSource = RPTSOSTATUSITEM
                RPTSOSTATUSITEM.DataDefinition.FormulaFields("TYPE").Text = "'" & PENDINGSO & "'"
                RPTSOSTATUSITEM.DataDefinition.FormulaFields("CLIENTNAME").Text = "'" & ClientName & "'"

            End If

            crpo.Zoom(100)
            crpo.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub SaleInvoiceDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim TEMPATTACHMENT As String = "REPORT"
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & TEMPATTACHMENT & ".PDF"
            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.Show()
            objmail.BringToFront()
            Windows.Forms.Cursor.Current = Cursors.Arrow
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions
            oDfDopt.DiskFileName = Application.StartupPath & "\REPORT.pdf"

            If FRMSTRING = "PARTYWISEDTLS" Then
                expo = RPTPARTYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYDTLS.Export()
            ElseIf FRMSTRING = "PARTYWISESUMM" Then
                expo = RPTPARTYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYSUMM.Export()
            ElseIf FRMSTRING = "JOBBERWISEDTLS" Then
                expo = RPTJOBBERDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBBERDTLS.Export()
            ElseIf FRMSTRING = "JOBBERWISESUMM" Then
                expo = RPTJOBBERSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBBERSUMM.Export()
            ElseIf FRMSTRING = "TRANSWISEDTLS" Then
                expo = RPTTRANSDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTTRANSDTLS.Export()
            ElseIf FRMSTRING = "TRANSWISESUMM" Then
                expo = RPTTRANSSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTTRANSSUMM.Export()

            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                expo = RPTITEMDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMDTLS.Export()
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                expo = RPTITEMSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMSUMM.Export()
            ElseIf FRMSTRING = "QUALITYWISEDTLS" Then
                expo = RPTQUALITYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTQUALITYDTLS.Export()
            ElseIf FRMSTRING = "QUALITYWISESUMM" Then
                expo = RPTQUALITYSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTQUALITYSUMM.Export()
            ElseIf FRMSTRING = "DESIGNWISEDTLS" Then
                expo = RPTDESIGNDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDESIGNDTLS.Export()
            ElseIf FRMSTRING = "DESIGNWISESUMM" Then
                expo = RPTDESIGNSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDESIGNSUMM.Export()
            ElseIf FRMSTRING = "SHADEWISEDTLS" Then
                expo = RPTSHADEDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSHADEDTLS.Export()
            ElseIf FRMSTRING = "SHADEWISESUMM" Then
                expo = RPTSHADESUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSHADESUMM.Export()

            ElseIf FRMSTRING = "CHARGESWISEDTLS" Then
                expo = RPTCHARGESDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCHARGESDTLS.Export()
            ElseIf FRMSTRING = "CHARGESWISESUMM" Then
                expo = RPTCHARGESSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCHARGESSUMM.Export()
            ElseIf FRMSTRING = "MONTHLY" Then
                expo = RPTMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMONTHLY.Export()
            ElseIf FRMSTRING = "ENTRYWISE" Then
                expo = RPTENTRYWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTENTRYWISE.Export()
            ElseIf FRMSTRING = "PARTYENTRYWISE" Then
                expo = RPTPARTYENTRYWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTYENTRYWISE.Export()
            ElseIf FRMSTRING = "AGENTENTRYWISE" Then
                expo = RPTAGENTENTRYWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTAGENTENTRYWISE.Export()
            ElseIf FRMSTRING = "PENDING" Then
                expo = RPTPENDING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPENDING.Export()
            ElseIf FRMSTRING = "DOCUMENT" Then
                expo = RPTDOCDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDOCDTLS.Export()
            ElseIf FRMSTRING = "REFFNO" Then
                expo = RPTREFDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTREFDTLS.Export()
            ElseIf FRMSTRING = "COMMISSION" Then
                expo = RPTCOMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCOMM.Export()
            ElseIf FRMSTRING = "COMMSUMM" Then
                expo = RPTCOMMSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCOMMSUMM.Export()
            ElseIf FRMSTRING = "ITEMWISEGROUP" Then
                expo = RPTITEMWISEGROUP.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEMWISEGROUP.Export()


            ElseIf FRMSTRING = "SOSTATUS" Then
                expo = RPTSOSTATUS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSOSTATUS.Export()
            ElseIf FRMSTRING = "SOSTATUSDTLS" Then
                expo = RPTSOSTATUSDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSOSTATUSDTLS.Export()
            ElseIf FRMSTRING = "SOSTATUSITEM" Then
                expo = RPTSOSTATUSITEM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSOSTATUSITEM.Export()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class