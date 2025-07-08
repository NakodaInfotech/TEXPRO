
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports BL

Public Class saledesign

    Dim RPTINVOICE As New InvoiceReport
    Dim RPTINVOICE_MONOGRAM As New InvoiceReport_MONOGRAM
    Dim RPTINVOICE_DHANLAXMI As New InvoiceReport_DHANLAXMI
    Dim RPTINVOICE_TOTALTRANSA4 As New InvoiceReport_TOTALTRANSA4

    Dim RPTPARTYDTLS As New InvoicePartyWiseDetails
    Dim RPTPARTYSUMM As New InvoicePartyWiseSummary
    Dim RPTAGENTDTLS As New InvoiceAgentWiseDetails
    Dim RPTAGENTSUMM As New InvoiceAgentWiseSummary
    Dim RPTITEMDTLS As New InvoiceItemWiseDetails
    Dim RPTITEMSUMM As New InvoiceItemWiseSummary
    Dim RPTQUALITYDTLS As New InvoiceQualityWiseDetails
    Dim RPTQUALITYSUMM As New InvoiceQualityWiseSummary
    Dim RPTDESIGNDTLS As New InvoiceDesignWiseDetails
    Dim RPTDESIGNSUMM As New InvoiceDesignWiseSummary
    Dim RPTSHADEDTLS As New InvoiceColorWiseDetails
    Dim RPTSHADESUMM As New InvoiceColorWiseSummary
    Dim RPTTRANSDTLS As New InvoiceTransWiseDetails
    Dim RPTTRANSSUMM As New InvoiceTransWiseSummary

    Public WHERECLAUSE As String
    Public BLANKPAPER As Boolean = False
    Public IGSTFORMAT As Boolean = False

    Public PERIOD As String
    Public strsumm As String
    Public FRMSTRING As String
    Public registername As String
    Public FROMDATE As Date
    Public TODATE As Date
    Public strsearch As String
    Public INVNO As Integer
    Public COMM As Double

    Public INVOICECOPYNAME As String
    Public PARTYNAME As String
    Public AGENTNAME As String
    Public INVOICETRANS As Boolean
    Public DIRECTMAIL As Boolean = False
    Public PRINTSETTING As Object = Nothing
    Public AVG82, AVG100 As Double


    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Public DIRECTPRINT As Boolean = False
    Public NOOFCOPIES As Integer = 1

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, FROMDATE)
        a2 = DatePart(DateInterval.Month, FROMDATE)
        a3 = DatePart(DateInterval.Year, FROMDATE)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, TODATE)
        a12 = DatePart(DateInterval.Month, TODATE)
        a13 = DatePart(DateInterval.Year, TODATE)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub saledesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            If DIRECTPRINT = True Then
                PRINTDIRECTLYTOPRINTER()
                Exit Sub
            End If

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


            If FRMSTRING = "PARTYWISEDTLS" Then crTables = RPTPARTYDTLS.Database.Tables
            If FRMSTRING = "PARTYWISESUMM" Then crTables = RPTPARTYSUMM.Database.Tables

            If FRMSTRING = "JOBBERWISEDTLS" Then crTables = RPTAGENTDTLS.Database.Tables
            If FRMSTRING = "JOBBERWISESUMM" Then crTables = RPTAGENTSUMM.Database.Tables

            If FRMSTRING = "ITEMWISEDTLS" Then crTables = RPTITEMDTLS.Database.Tables
            If FRMSTRING = "ITEMWISESUMM" Then crTables = RPTITEMSUMM.Database.Tables

            If FRMSTRING = "QUALITYWISEDTLS" Then crTables = RPTQUALITYDTLS.Database.Tables
            If FRMSTRING = "QUALITYWISESUMM" Then crTables = RPTQUALITYSUMM.Database.Tables

            If FRMSTRING = "DESIGNWISEDTLS" Then crTables = RPTDESIGNDTLS.Database.Tables
            If FRMSTRING = "DESIGNWISESUMM" Then crTables = RPTDESIGNSUMM.Database.Tables

            If FRMSTRING = "SHADEWISEDTLS" Then crTables = RPTSHADEDTLS.Database.Tables
            If FRMSTRING = "SHADEWISESUMM" Then crTables = RPTSHADESUMM.Database.Tables

            If FRMSTRING = "TRANSWISEDTLS" Then crTables = RPTTRANSDTLS.Database.Tables
            If FRMSTRING = "TRANSWISESUMM" Then crTables = RPTTRANSSUMM.Database.Tables

            If FRMSTRING = "INVOICE" Then

                If INVOICETRANS = True Then
                    crTables = RPTINVOICE_TOTALTRANSA4.Database.Tables
                    GoTo SKIPINVOICE
                End If

                If ClientName = "MONOGRAM" Then
                    crTables = RPTINVOICE_MONOGRAM.Database.Tables
                ElseIf ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                    crTables = RPTINVOICE_DHANLAXMI.Database.Tables
                Else
                    crTables = RPTINVOICE.Database.Tables
                End If
            End If


SKIPINVOICE:

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            '************************ END *******************
            getFromToDate()

            If FRMSTRING <> "INVOICE" Then
                crParameterDiscreteValue.Value = CmpId
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@CMPID")
                crParameterValues = crParameterFieldDefinition.CurrentValues

                crParameterValues.Clear()
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterDiscreteValue.Value = Locationid
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@LOCATIONID")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)


                crParameterDiscreteValue.Value = YearId
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@YEARID")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            End If

            CRPO.SelectionFormula = strsearch

            If FRMSTRING = "INVOICE" Then
                If INVOICETRANS = True Then
                    CRPO.ReportSource = RPTINVOICE_TOTALTRANSA4
                    CRPO.Zoom(100)
                    CRPO.Refresh()
                    Exit Sub
                End If

                If ClientName = "MONOGRAM" Then
                    CRPO.ReportSource = RPTINVOICE_MONOGRAM
                    RPTINVOICE_MONOGRAM.DataDefinition.FormulaFields("INVOICECOPYNAME").Text = "'" & INVOICECOPYNAME & "'"
                    If BLANKPAPER = True Then RPTINVOICE_MONOGRAM.DataDefinition.FormulaFields("WHITELABEL").Text = 1 Else RPTINVOICE_MONOGRAM.DataDefinition.FormulaFields("WHITELABEL").Text = 0
                ElseIf ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                    CRPO.ReportSource = RPTINVOICE_DHANLAXMI
                    RPTINVOICE_DHANLAXMI.DataDefinition.FormulaFields("INVOICECOPYNAME").Text = "'" & INVOICECOPYNAME & "'"
                    If BLANKPAPER = True Then RPTINVOICE_DHANLAXMI.DataDefinition.FormulaFields("WHITELABEL").Text = 1 Else RPTINVOICE_DHANLAXMI.DataDefinition.FormulaFields("WHITELABEL").Text = 0
                    If AVG82 > 0 Then RPTINVOICE_DHANLAXMI.DataDefinition.FormulaFields("AVG82").Text = AVG82
                    If AVG100 > 0 Then RPTINVOICE_DHANLAXMI.DataDefinition.FormulaFields("AVG100").Text = AVG100
                Else
                    CRPO.ReportSource = RPTINVOICE
                    RPTINVOICE.DataDefinition.FormulaFields("INVOICECOPYNAME").Text = "'" & INVOICECOPYNAME & "'"
                    If BLANKPAPER = True Then RPTINVOICE.DataDefinition.FormulaFields("WHITELABEL").Text = 1 Else RPTINVOICE.DataDefinition.FormulaFields("WHITELABEL").Text = 0
                End If

            ElseIf FRMSTRING = "PARTYWISEDTLS" Then
                CRPO.ReportSource = RPTPARTYDTLS
                RPTPARTYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PARTYWISESUMM" Then
                CRPO.ReportSource = RPTPARTYSUMM
                RPTPARTYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOBBERWISEDTLS" Then
                CRPO.ReportSource = RPTAGENTDTLS
                RPTAGENTDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOBBERWISESUMM" Then
                CRPO.ReportSource = RPTAGENTDTLS
                RPTAGENTSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISEDTLS" Then
                CRPO.ReportSource = RPTITEMDTLS
                RPTITEMDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "ITEMWISESUMM" Then
                CRPO.ReportSource = RPTITEMSUMM
                RPTITEMSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYWISEDTLS" Then
                CRPO.ReportSource = RPTQUALITYDTLS
                RPTQUALITYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "QUALITYWISESUMM" Then
                CRPO.ReportSource = RPTQUALITYSUMM
                RPTQUALITYSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNWISEDTLS" Then
                CRPO.ReportSource = RPTDESIGNDTLS
                RPTDESIGNDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNWISESUMM" Then
                CRPO.ReportSource = RPTDESIGNSUMM
                RPTDESIGNSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SHADEWISEDTLS" Then
                CRPO.ReportSource = RPTSHADEDTLS
                RPTSHADEDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "SHADEWISESUMM" Then
                CRPO.ReportSource = RPTSHADESUMM
                RPTSHADESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "TRANSWISEDTLS" Then
                CRPO.ReportSource = RPTTRANSDTLS
                RPTTRANSDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "TRANSWISESUMM" Then
                CRPO.ReportSource = RPTTRANSSUMM
                RPTTRANSSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            End If

            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path for loading report.",
                    MsgBoxStyle.Critical, "Load Report Error")

        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

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

            strsearch = strsearch & " {INVOICEMASTER.INVOICE_no}= " & Val(INVNO) & " AND {REGISTERMASTER.REGISTER_NAME} = '" & registername & "' AND {INVOICEMASTER.INVOICE_yearid} = " & YearId
            CRPO.SelectionFormula = strsearch

            Dim OBJ As New Object
            If FRMSTRING = "INVOICE" Then

                If INVOICETRANS = True Then
                    OBJ = New InvoiceReport_TOTALTRANSA4
                    GoTo SKIPINVOICE
                End If

                If ClientName = "MONOGRAM" Then
                    OBJ = New InvoiceReport_MONOGRAM

                ElseIf ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                    OBJ = New InvoiceReport_DHANLAXMI

                    'GET LOTWT FROM DATABASE
                    Dim OBJCMN As New ClsCommon
                    Dim DTWT As DataTable = OBJCMN.search(" ISNULL(INVOICE_LOTWT,0) AS WT", "", " INVOICEMASTER_LOTDESC INNER JOIN REGISTERMASTER ON INVOICE_REGISTERID = REGISTER_ID ", " AND INVOICE_NO = " & Val(INVNO) & " AND REGISTER_NAME = '" & registername & "' AND INVOICE_YEARID = " & YearId)
                    If DTWT.Rows.Count > 0 Then
                        OBJ.DataDefinition.FormulaFields("AVG82").Text = Format(Val(DTWT.Rows(0).Item("WT")) * 82, "0.00")
                        OBJ.DataDefinition.FormulaFields("AVG100").Text = Format(Val(DTWT.Rows(0).Item("WT")) * 100, "0.00")
                    End If

                Else
                    OBJ = New InvoiceReport
                End If
                OBJ.DataDefinition.FormulaFields("INVOICECOPYNAME").Text = "'" & INVOICECOPYNAME & "'"
                If BLANKPAPER = True Then OBJ.DataDefinition.FormulaFields("WHITELABEL").Text = 1 Else OBJ.DataDefinition.FormulaFields("WHITELABEL").Text = 0

            End If

SKIPINVOICE:
            crTables = OBJ.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJ.RecordSelectionFormula = strsearch

            If DIRECTMAIL = False Then
                OBJ.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
                OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
            Else
                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions
                oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE_" & INVNO & ".pdf"
                OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                expo = OBJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
                OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Dim emailid1 As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()

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

            Dim tempattachment As String

            Dim objmail As New SendMail

            If FRMSTRING = "" Then
                tempattachment = "SALEDETAILS"
                objmail.subject = "Invoice Details"

            ElseIf FRMSTRING = "INVOICE" Then
                tempattachment = "INVOICE"
                objmail.subject = "Invoice"

            Else
                tempattachment = "SALESUMMARY"
                objmail.subject = "Invoice Summary"

            End If

            'Dim OBJCMN As New ClsCommon
            'Dim dt As DataTable = OBJCMN.search("ACC_EMAIL AS EMAILID", "", "LEDGERS", " and ACC_CMPNAME = '" & PARTYNAME & "' AND ACC_YEARID=" & YearId)
            'If dt.Rows.Count > 0 Then objmail.cmbfirstadd.Text = dt.Rows(0).Item("EMAILID")


            objmail.attachment = tempattachment
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"


            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            If emailid1 <> "" Then
                objmail.cmbsecondadd.Text = emailid1
            End If
            objmail.Show()
            objmail.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            If FRMSTRING = "INVOICE" Then

                If INVOICETRANS = True Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE.PDF"
                    expo = RPTINVOICE_TOTALTRANSA4.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_TOTALTRANSA4.Export()
                    Exit Sub
                End If

                oDfDopt.DiskFileName = Application.StartupPath & "\INVOICE.PDF"

                If ClientName = "MONOGRAM" Then
                    RPTINVOICE_MONOGRAM.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                    expo = RPTINVOICE_MONOGRAM.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_MONOGRAM.Export()
                    RPTINVOICE_MONOGRAM.DataDefinition.FormulaFields("SENDMAIL").Text = "0"

                ElseIf ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                    RPTINVOICE_DHANLAXMI.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                    expo = RPTINVOICE_DHANLAXMI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE_DHANLAXMI.Export()
                    RPTINVOICE_DHANLAXMI.DataDefinition.FormulaFields("SENDMAIL").Text = "0"

                Else
                    expo = RPTINVOICE.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTINVOICE.Export()
                End If


            ElseIf FRMSTRING = "PARTYWISEDTLS" Then
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
                expo = RPTAGENTDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTAGENTDTLS.Export()
            ElseIf FRMSTRING = "JOBBERWISESUMM" Then
                expo = RPTAGENTSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTAGENTSUMM.Export()
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
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    
End Class