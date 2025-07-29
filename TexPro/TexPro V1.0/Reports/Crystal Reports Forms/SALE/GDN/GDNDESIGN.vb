
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports System.IO

Public Class GDNDESIGN

    Public FORMULA As String
    Public period As String
    Public TOTALPCS As Double = 0
    Public TOTALMTRS As Double = 0
    Public FRMSTRING As String = ""
    Public MONOGRAMQUALITYNAME As String = ""

    Dim RPTGDN As New gdnReport
    Dim RPTGDN_MONOGRAM As New GDNReport_MONOGRAM
    Dim RPTGDN_DHANLAXMI As New GDNReport_DHANLAXMI
    Dim RPTGDN_EWB As New GDNReport_EWB

    Dim RPTPS As New PackingSummReport
    Dim RPTPS_DHANLAXMI As New PackingSummReport_DHANLAXMI
    Dim RPTPS_BLEACHWT As New PackingSummaryBleachWtReport


    Dim RPTSALERETURN As New SaleReturnReport
    Dim RPTJOB As New DispatchJobReport
    Dim RPTGDNCITY As New DispatchCityReport
    Dim RPTGDNTRANSPORT As New DispatchTransportReport
    Dim RPTGDNMONTHLY As New DispatchMONTHLYreport
    Dim RPTGDNDEPTMONTHLY As New DispatchDepartmentMonthlyReport
    Dim RPTGDNMONTHLYPARTYWISE As New DISPATCHMONTHLYPARTYWISEREPORT

    Dim RPTGDNAGENTMONTHLY As New DispatchAgentMonthlyReport
    Dim RPTGDNAGENTMERCHANT As New DispatchAgentMerchantReport
    Dim RPTGDNAGENTPARTY As New DispatchAgentPartyReport

    Dim RPTJOBMONTHLY As New DispatchJobMonthlyReport
    Dim RPTDISPATCHJOBWISE As New DispatchJobWise
    Dim RPTDISPATCHPROGWISE As New DispatchProgWise
    Dim RPTDISPATCH As New DispatchPartyReport
    Dim RPTDISPATCHSUMMBILLNO As New DispatchSummBillNoReport
    Dim RPTDISPATCHD As New DispatchPartyDetailReport
    Dim RPTDISPATCHCATEGORY As New DispatchCategoryWiseReport
    Dim RPTDISPATCHCATEGORYMONTHLY As New DispatchCategoryMonthlySummReport
    Dim RPTDISPATCHDEPT As New DispatchDeptWiseReport
    Dim RPTDISPATCHGRADE As New DispatchGradeWiseReport
    Dim RPTDISPATCHDESIGNBALE As New DispatchDesignBaleReport
    Dim RPTDISPATCHDESIGNBALESUMM As New DispatchDesignBaleSummReport
    Dim RPTJOBDETAIL As New DispatchJobdetailReport
    Dim RPTGDndetail As New gdndetailreport
    Dim RPTGDnpartydetail As New gdndetailpartyreport
    Dim RPTGDnitemdetail As New gdndetailItemreport
    Dim RPTGDnsummary As New gdnSummaryreport
    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions
    Public vendorname As String
    Public SHOWTRANS As Boolean


    Public GDNNO As Integer
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing

    Private Sub GDNDESIGN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GRNDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            If FRMSTRING = "GDNDETAIL" Then
                crTables = RPTGDndetail.Database.Tables
            ElseIf FRMSTRING = "GDNCITY" Then
                crTables = RPTGDNCITY.Database.Tables
            ElseIf FRMSTRING = "GDNTRANSPORT" Then
                crTables = RPTGDNTRANSPORT.Database.Tables
            ElseIf FRMSTRING = "JOBSUMMARY" Then
                crTables = RPTJOB.Database.Tables
            ElseIf FRMSTRING = "JOBDETAIL" Then
                crTables = RPTJOBDETAIL.Database.Tables
            ElseIf FRMSTRING = "JOBMONTHLY" Then
                crTables = RPTJOBMONTHLY.Database.Tables
            ElseIf FRMSTRING = "DISPATCHSUMMARY" Then
                crTables = RPTDISPATCH.Database.Tables
            ElseIf FRMSTRING = "DISPATCHDETAIL" Then
                crTables = RPTDISPATCHD.Database.Tables
            ElseIf FRMSTRING = "DISPATCHMONTHLY" Then
                crTables = RPTGDNMONTHLY.Database.Tables
            ElseIf FRMSTRING = "DISPATCHDEPTMONTHLY" Then
                crTables = RPTGDNDEPTMONTHLY.Database.Tables
            ElseIf FRMSTRING = "DISPATCHMONTHLYPARTYWISE" Then
                crTables = RPTGDNMONTHLYPARTYWISE.Database.Tables
            ElseIf FRMSTRING = "DISPATCHAGENTPARTY" Then
                crTables = RPTGDNAGENTPARTY.Database.Tables
            ElseIf FRMSTRING = "DISPATCHAGENTMONTHLY" Then
                crTables = RPTGDNAGENTMONTHLY.Database.Tables
            ElseIf FRMSTRING = "DISPATCHAGENTMERCHANT" Then
                crTables = RPTGDNAGENTMERCHANT.Database.Tables
            ElseIf FRMSTRING = "DISPATCHSUMMARYBILLNO" Then
                crTables = RPTDISPATCHSUMMBILLNO.Database.Tables
            ElseIf FRMSTRING = "DISPATCHDESIGNBALE" Then
                crTables = RPTDISPATCHDESIGNBALE.Database.Tables
            ElseIf FRMSTRING = "DISPATCHDESIGNBALESUMM" Then
                crTables = RPTDISPATCHDESIGNBALESUMM.Database.Tables
            ElseIf FRMSTRING = "DISPATCHJOBWISE" Then
                crTables = RPTDISPATCHJOBWISE.Database.Tables
            ElseIf FRMSTRING = "DISPATCHPROGWISE" Then
                crTables = RPTDISPATCHPROGWISE.Database.Tables
            ElseIf FRMSTRING = "DISPATCHCATEGORY" Then
                crTables = RPTDISPATCHCATEGORY.Database.Tables
            ElseIf FRMSTRING = "DISPATCHCATEGORYMONTHLY" Then
                crTables = RPTDISPATCHCATEGORYMONTHLY.Database.Tables
            ElseIf FRMSTRING = "DISPATCHDEPT" Then
                crTables = RPTDISPATCHDEPT.Database.Tables
            ElseIf FRMSTRING = "DISPATCHGRADE" Then
                crTables = RPTDISPATCHGRADE.Database.Tables
            ElseIf FRMSTRING = "GDNSUMMARY" Then
                crTables = RPTGDnsummary.Database.Tables
            ElseIf FRMSTRING = "GDNPARTYDETAIL" Then
                crTables = RPTGDnpartydetail.Database.Tables
            ElseIf FRMSTRING = "GDNPARTYSUMMARY" Then
                crTables = RPTGDnsummary.Database.Tables
            ElseIf FRMSTRING = "GDNITEMDETAIL" Then
                crTables = RPTGDnitemdetail.Database.Tables
            ElseIf FRMSTRING = "GDNITEMSUMMARY" Then
                crTables = RPTGDnsummary.Database.Tables
            ElseIf FRMSTRING = "SALERETURN" Then
                crTables = RPTSALERETURN.Database.Tables

            ElseIf FRMSTRING = "BLEACHWTREPORT" Then
                crTables = RPTPS_BLEACHWT.Database.Tables

            ElseIf FRMSTRING = "PACKINGSUMMARY" Then
                If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                    crTables = RPTPS_DHANLAXMI.Database.Tables
                Else
                    crTables = RPTPS.Database.Tables
                End If

            ElseIf FRMSTRING = "GDNEWB" Then
                crTables = RPTGDN_EWB.Database.Tables
            Else
                If ClientName = "MONOGRAM" Then
                    crTables = RPTGDN_MONOGRAM.Database.Tables
                ElseIf ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                    crTables = RPTGDN_DHANLAXMI.Database.Tables
                Else
                    crTables = RPTGDN.Database.Tables
                End If
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = FORMULA
            If FRMSTRING = "GDNDETAIL" Then
                crpo.ReportSource = RPTGDndetail
                RPTGDndetail.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTGDndetail.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTGDndetail.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "GDNSUMMARY" Then
                crpo.ReportSource = RPTGDnsummary
                RPTGDnsummary.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTGDnsummary.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTGDnsummary.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "JOBSUMMARY" Then
                crpo.ReportSource = RPTJOB
                RPTJOB.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTJOB.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTJOB.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "JOBMONTHLY" Then
                crpo.ReportSource = RPTJOBMONTHLY
                RPTJOBMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTJOBMONTHLY.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTJOBMONTHLY.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "JOBDETAIL" Then
                crpo.ReportSource = RPTJOBDETAIL
                RPTJOBDETAIL.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTJOBDETAIL.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTJOBDETAIL.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "DISPATCHSUMMARY" Then
                crpo.ReportSource = RPTDISPATCH
                RPTDISPATCH.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTDISPATCH.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTDISPATCH.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "GDNCITY" Then
                crpo.ReportSource = RPTGDNCITY
                RPTGDNCITY.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTGDNCITY.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTGDNCITY.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "GDNTRANSPORT" Then
                crpo.ReportSource = RPTGDNTRANSPORT
                RPTGDNTRANSPORT.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTGDNTRANSPORT.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTGDNTRANSPORT.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "DISPATCHDETAIL" Then
                crpo.ReportSource = RPTDISPATCHD
                RPTDISPATCHD.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTDISPATCHD.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTDISPATCHD.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "DISPATCHMONTHLY" Then
                crpo.ReportSource = RPTGDNMONTHLY
                RPTGDNMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTGDNMONTHLY.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTGDNMONTHLY.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "DISPATCHDEPTMONTHLY" Then
                crpo.ReportSource = RPTGDNDEPTMONTHLY
                RPTGDNDEPTMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
            ElseIf FRMSTRING = "DISPATCHAGENTMONTHLY" Then
                crpo.ReportSource = RPTGDNAGENTMONTHLY
                RPTGDNAGENTMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTGDNAGENTMONTHLY.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTGDNAGENTMONTHLY.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "DISPATCHAGENTMERCHANT" Then
                crpo.ReportSource = RPTGDNAGENTMERCHANT
                RPTGDNAGENTMERCHANT.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTGDNAGENTMERCHANT.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTGDNAGENTMERCHANT.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "DISPATCHSUMMARYBILLNO" Then
                crpo.ReportSource = RPTDISPATCHSUMMBILLNO
                RPTDISPATCHSUMMBILLNO.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTDISPATCHSUMMBILLNO.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTDISPATCHSUMMBILLNO.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "DISPATCHAGENTPARTY" Then
                crpo.ReportSource = RPTGDNAGENTPARTY
                RPTGDNAGENTPARTY.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTGDNAGENTPARTY.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTGDNAGENTPARTY.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "DISPATCHMONTHLYPARTYWISE" Then
                crpo.ReportSource = RPTGDNMONTHLYPARTYWISE
                RPTGDNMONTHLYPARTYWISE.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTGDNMONTHLYPARTYWISE.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTGDNMONTHLYPARTYWISE.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "DISPATCHDESIGNBALE" Then
                crpo.ReportSource = RPTDISPATCHDESIGNBALE
                RPTDISPATCHDESIGNBALE.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
            ElseIf FRMSTRING = "DISPATCHDESIGNBALESUMM" Then
                crpo.ReportSource = RPTDISPATCHDESIGNBALESUMM
                RPTDISPATCHDESIGNBALESUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
            ElseIf FRMSTRING = "DISPATCHJOBWISE" Then
                crpo.ReportSource = RPTDISPATCHJOBWISE
                RPTDISPATCHJOBWISE.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
            ElseIf FRMSTRING = "DISPATCHPROGWISE" Then
                crpo.ReportSource = RPTDISPATCHPROGWISE
                RPTDISPATCHPROGWISE.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
            ElseIf FRMSTRING = "DISPATCHCATEGORY" Then
                crpo.ReportSource = RPTDISPATCHCATEGORY
                RPTDISPATCHCATEGORY.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTDISPATCHCATEGORY.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTDISPATCHCATEGORY.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "DISPATCHCATEGORYMONTHLY" Then
                crpo.ReportSource = RPTDISPATCHCATEGORYMONTHLY
                RPTDISPATCHCATEGORYMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTDISPATCHCATEGORYMONTHLY.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTDISPATCHCATEGORYMONTHLY.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "DISPATCHDEPT" Then
                crpo.ReportSource = RPTDISPATCHDEPT
                RPTDISPATCHDEPT.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTDISPATCHDEPT.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTDISPATCHDEPT.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "DISPATCHGRADE" Then
                crpo.ReportSource = RPTDISPATCHGRADE
                RPTDISPATCHGRADE.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTDISPATCHGRADE.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTDISPATCHGRADE.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "GDNPARTYDETAIL" Then
                crpo.ReportSource = RPTGDnpartydetail
                RPTGDnpartydetail.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTGDnpartydetail.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTGDnpartydetail.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "GDNPARTYSUMMARY" Then
                crpo.ReportSource = RPTGDnsummary
                RPTGDnsummary.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTGDnsummary.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTGDnsummary.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "GDNITEMDETAIL" Then
                RPTGDnitemdetail.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTGDnitemdetail.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTGDnitemdetail.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
                crpo.ReportSource = RPTGDnitemdetail
            ElseIf FRMSTRING = "GDNITEMSUMMARY" Then
                crpo.ReportSource = RPTGDnsummary
                RPTGDnsummary.DataDefinition.FormulaFields("PERIOD").Text = "'" & period & "'"
                RPTGDnsummary.DataDefinition.FormulaFields("TOTALPCS").Text = TOTALPCS
                RPTGDnsummary.DataDefinition.FormulaFields("TOTALMTRS").Text = TOTALMTRS
            ElseIf FRMSTRING = "SALERETURN" Then
                crpo.ReportSource = RPTSALERETURN
            ElseIf FRMSTRING = "BLEACHWTREPORT" Then
                crpo.ReportSource = RPTPS_BLEACHWT

            ElseIf FRMSTRING = "PACKINGSUMMARY" Then
                If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                    crpo.ReportSource = RPTPS_DHANLAXMI
                Else
                    crpo.ReportSource = RPTPS
                    RPTPS.DataDefinition.FormulaFields("QUALITYNAME").Text = "'" & MONOGRAMQUALITYNAME & "'"
                End If

            ElseIf FRMSTRING = "GDNEWB" Then
                crpo.ReportSource = RPTGDN_EWB
            Else
                If ClientName = "MONOGRAM" Then
                    crpo.ReportSource = RPTGDN_MONOGRAM
                ElseIf ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                    crpo.ReportSource = RPTGDN_DHANLAXMI
                Else
                    crpo.ReportSource = RPTGDN
                    If SHOWTRANS = True Then RPTGDN.DataDefinition.FormulaFields("SHOWTRANS").Text = 1 Else RPTGDN.DataDefinition.FormulaFields("SHOWTRANS").Text = 0
                End If
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

            strsearch = " {PACKINGSUMMARY.PS_no}=" & Val(GDNNO) & " And {PACKINGSUMMARY.PS_YEARID}=" & YearId

            Dim OBJ As New Object
            If FRMSTRING = "PACKINGSUMMARY" Then
                If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                    OBJ = New PackingSummReport_DHANLAXMI
                Else
                    OBJ = New PackingSummReport
                End If
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
                oDfDopt.DiskFileName = Application.StartupPath & "\PACKINGSUMMARY_" & GDNNO & ".pdf"

                'CHECK WHETHER FILE IS PRESENT OR NOT, IF PRESENT THEN DELETE FIRST AND THEN EXPORT
                If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)
                expo = OBJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            tempattachment = "GDN"
            If vendorname <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" acc_email ", "", " LEDGERS ", " and ACC_cmpname='" & vendorname & "' and ACC_cmpid=" & CmpId & " and ACC_LOCATIONid=" & Locationid & " and ACC_YEARid=" & YearId)
                If dt.Rows.Count > 0 Then
                    emailid = dt.Rows(0).Item(0).ToString
                End If
            End If

            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".pdf"
            objmail.subject = "Despatch Report"
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
            oDfDopt.DiskFileName = Application.StartupPath & "\GDN.pdf"

            If FRMSTRING = "GDNDETAIL" Then
                expo = RPTGDndetail.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDndetail.Export()
            ElseIf FRMSTRING = "GDNSUMMARY" Then
                expo = RPTGDnsummary.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDnsummary.Export()
            ElseIf FRMSTRING = "JOBSUMMARY" Then
                expo = RPTJOB.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOB.Export()
            ElseIf FRMSTRING = "JOBMONTHLY" Then
                expo = RPTJOBMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBMONTHLY.Export()
            ElseIf FRMSTRING = "JOBDETAIL" Then
                expo = RPTJOBDETAIL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBDETAIL.Export()
            ElseIf FRMSTRING = "DISPATCHSUMMARY" Then
                expo = RPTDISPATCH.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDISPATCH.Export()
            ElseIf FRMSTRING = "GDNCITY" Then
                expo = RPTGDNCITY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDNCITY.Export()
            ElseIf FRMSTRING = "GDNTRANSPORT" Then
                expo = RPTGDNTRANSPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDNTRANSPORT.Export()
            ElseIf FRMSTRING = "DISPATCHDETAIL" Then
                expo = RPTDISPATCHD.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDISPATCHD.Export()
            ElseIf FRMSTRING = "DISPATCHMONTHLY" Then
                expo = RPTGDNMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDNMONTHLY.Export()
            ElseIf FRMSTRING = "DISPATCHDEPTMONTHLY" Then
                expo = RPTGDNDEPTMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDNDEPTMONTHLY.Export()
            ElseIf FRMSTRING = "DISPATCHAGENTMONTHLY" Then
                expo = RPTGDNAGENTMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDNAGENTMONTHLY.Export()
            ElseIf FRMSTRING = "DISPATCHAGENTMERCHANT" Then
                expo = RPTGDNAGENTMERCHANT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDNAGENTMERCHANT.Export()
            ElseIf FRMSTRING = "DISPATCHSUMMARYBILLNO" Then
                expo = RPTDISPATCHSUMMBILLNO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDISPATCHSUMMBILLNO.Export()
            ElseIf FRMSTRING = "DISPATCHAGENTPARTY" Then
                expo = RPTGDNAGENTPARTY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDNAGENTPARTY.Export()
            ElseIf FRMSTRING = "DISPATCHMONTHLYPARTYWISE" Then
                expo = RPTGDNMONTHLYPARTYWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDNMONTHLYPARTYWISE.Export()
            ElseIf FRMSTRING = "DISPATCHDESIGNBALE" Then
                expo = RPTDISPATCHDESIGNBALE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDISPATCHDESIGNBALE.Export()
            ElseIf FRMSTRING = "DISPATCHDESIGNBALESUMM" Then
                expo = RPTDISPATCHDESIGNBALESUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDISPATCHDESIGNBALESUMM.Export()
            ElseIf FRMSTRING = "DISPATCHJOBWISE" Then
                expo = RPTDISPATCHJOBWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDISPATCHJOBWISE.Export()
            ElseIf FRMSTRING = "DISPATCHPROGWISE" Then
                expo = RPTDISPATCHPROGWISE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDISPATCHPROGWISE.Export()
            ElseIf FRMSTRING = "DISPATCHCATEGORY" Then
                expo = RPTDISPATCHCATEGORY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDISPATCHCATEGORY.Export()
            ElseIf FRMSTRING = "DISPATCHCATEGORYMONTHLY" Then
                expo = RPTDISPATCHCATEGORYMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDISPATCHCATEGORYMONTHLY.Export()
            ElseIf FRMSTRING = "DISPATCHDEPT" Then
                expo = RPTDISPATCHDEPT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDISPATCHDEPT.Export()
            ElseIf FRMSTRING = "DISPATCHGRADE" Then
                expo = RPTDISPATCHGRADE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDISPATCHGRADE.Export()
            ElseIf FRMSTRING = "GDNPARTYDETAIL" Then
                expo = RPTGDnpartydetail.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDnpartydetail.Export()
            ElseIf FRMSTRING = "GDNPARTYSUMMARY" Then
                expo = RPTGDnsummary.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDnsummary.Export()
            ElseIf FRMSTRING = "GDNITEMDETAIL" Then
                expo = RPTGDnitemdetail.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDnitemdetail.Export()
            ElseIf FRMSTRING = "GDNITEMSUMMARY" Then
                expo = RPTGDnsummary.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDnsummary.Export()
            ElseIf FRMSTRING = "SALERETURN" Then
                expo = RPTSALERETURN.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSALERETURN.Export()
            ElseIf FRMSTRING = "BLEACHWTREPORT" Then
                expo = RPTPS_BLEACHWT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPS_BLEACHWT.Export()

            ElseIf FRMSTRING = "PACKINGSUMMARY" Then
                If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                    expo = RPTPS_DHANLAXMI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTPS_DHANLAXMI.Export()
                Else
                    expo = RPTPS.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTPS.Export()
                End If

            ElseIf FRMSTRING = "GDNEWB" Then
                expo = RPTGDN_EWB.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGDN_EWB.Export()
            Else
                If ClientName = "MONOGRAM" Then
                    expo = RPTGDN_MONOGRAM.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTGDN_MONOGRAM.Export()
                ElseIf ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                    expo = RPTGDN_DHANLAXMI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTGDN_DHANLAXMI.Export()
                Else
                    expo = RPTGDN.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    If SHOWTRANS = True Then RPTGDN.DataDefinition.FormulaFields("SHOWTRANS").Text = 1 Else RPTGDN.DataDefinition.FormulaFields("SHOWTRANS").Text = 0
                    RPTGDN.Export()
                End If
            End If


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class