
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports BL

Public Class mfgdesign

    Public selfor_po As String
    Public DATEBETWEEN As String
    Public frmstring As String
    Public PERIOD As String
    Public positive As Integer = 1
    Public FROMDATE As String
    Public TODATE As String
    Public STARTDATE As String
    Public ITEMNAME As String = ""
    Public LOTNO As String = ""
    Public HIDERATE As Boolean = False
    Public PARTYNAME As String = ""
    Public QUALITYWT As Double = 0
    Public SHOWOURQUALITY As Boolean = False

    Public TOTALPENDING As Double
    Public TOTALINWARD As Double
    Public TOTALOUTWARD As Double

    Dim RPTMFG As New MfgReport
    Dim RPTDYEINGISSUESLIP As New DyeingIssueSlip

    Dim rptmfgfull As New MFGfullREPORT
    Dim rptmfgfullSUMM As New MFGfullsummaryREPORT
    Dim rptmfgfullmonth As New MFGFULLMONTHLYREPORT

    Dim rptmfg1 As New MFGDETAILREPORT
    Dim RPTMFGPCS As New MFGDETAILREPORTPCS
    Dim RPTMFG1VALUE As New MFGDETAILREPORTVALUE

    Dim rptmfg1LOTDETAIL As New MFGLOTREPORT
    Dim rptmfg1SUMM As New MFGSUMMARYREPORT
    Dim rptmfg1MONTHLY As New MFGMONTHLYREPORT
    Dim rptmfg2 As New MFG2report

    Dim rptmfg2DETAIL As New MFG2DETAILREPORT_NEW
    Dim rptmfg2SUMMARY As New MFG2summaryreport_New
    Dim rptmfg2JOB As New MFG2jobreport
    Dim rptmfg2MONTHLY As New MFG2MONTHLYreport_New

    'Dim rptmfg2MERCHANT As New MFG2merchantreport
    Dim rptmfg2MERCHANT As New MFG2merchantreport_New
    ' Dim rptmfg2MONTHLY As New MFG2MONTHLYreport
    'Dim rptmfg2LABOUR As New MFG2labourreport
    Dim rptmfg2LABOUR As New MFG2labourreport_New
    Dim rptlothistory As New LotwiseReport
    Dim rptlotSUMMARY As New LotwiseSummary

    Dim rptCUTTINGSTOCKDETAIL As New CUTTINGSTOCKDETAILreport
    Dim rptmfg2STOCKDETAIL As New MFG2STOCKDETAILreport

    Dim RPTMEMOSTOCK As New MemoStockReport
    Dim RPTMEMOSTOCKVALUE As New MemoStockReportValue


    Dim rptmfg2STOCKSUMMARY As New MFG2STOCKSUMMARYreport
    Dim rptmfg2STOCKMERCHANT As New MFG2STOCKMERCHANTreport
    Dim rptmfg2STOCKMERCHANTsummary As New MFG2STOCKMERCHANTSUMMARYreport
    Dim RPTMEMOSTOCKMERCHATSUMMARY As New MemoStockDesignReport
    Dim rptmfg2STOCKJOB As New MFG2STOCKJOBreport
    Dim rptmfg2STOCKMONTHLY As New MFG2STOCKMONTHLYreport
    Dim rptmfg2STOCKLABOUR As New MFG2STOCKLABOURreport
    Dim RPTMFG2DESIGN As New MFG2DesignWiseReport





    '*********** DESIGN COST REPORTS ********************
    Dim RPTMFG2COSTDETAIL As New MFG2COSTDETAILREPORT
    Dim RPTMFG2COSTSUMMARY As New MFG2COSTSUMMARYREPORT
    Dim RPTMFG2COSTSUPERSUMMARY As New MFG2COSTSUPERSUMMARYREPORT
    Dim RPTMFG2COSTMERCHANTSUPERSUMMARY As New MFG2COSTMERCHANTSUPERSUMMREPORT
    Dim RPTMFG2COSTMERCHANTSCREENSUMMARY As New MFG2COSTMERCHANTSCREENREPORT
    Dim RPTMFG2COSTSCREENSUMMARY As New MFG2COSTSCREENREPORT
    Dim RPTMFG2JOBCOSTSUMMARY As New MFG2JOBWISECOSTSUMMARYREPORT
    Dim RPTMFG2COSTMONTHLY As New MFG2COSTMONTHLYREPORT
    '******************************************************
    '******************************************************



    '************PARTYLOTSTATUS *************
    Dim RPTLOTSTATUS As New PartyLotStatusPrint
    '******************************************************



    Dim rptFCPDETAIL As New LooseStockReport
    Dim RPTFCPDESIGN As New LooseStockDesignReport
    Dim RPTFCPDESIGNIMG As New LooseStockDesignImgReport
    Dim RPTFCPMERCHANT As New LooseStockMerchantReport
    Dim RPTVALUELOSSREPORT As New FCPVALUELOSSREPORT
    ' Dim rptFCPMERCHANT As New FCPMERCHANTREPORT


    'CONTRACTORBILL
    Dim RPTCONTRACTORBILL As New ContractorBillReport



    Dim rptDYEING As New DyeingReport
    Dim rptPROCIAN As New Procianreport
    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions

    Private Sub GPDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
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

            If frmstring = "MFGREPORT" Then
                crTables = RPTMFG.Database.Tables
            ElseIf frmstring = "DYEINGISSUESLIP" Then
                crTables = RPTDYEINGISSUESLIP.Database.Tables
            ElseIf frmstring = "DYEING" Then
                crTables = rptDYEING.Database.Tables
            ElseIf frmstring = "PROCIAN" Then
                crTables = rptPROCIAN.Database.Tables
            ElseIf frmstring = "PROCIANSUMMARY" Then
                'crTables = rptPROCIANSUMMARY.Database.Tables


            ElseIf frmstring = "PARTYLOTSTATUS" Then
                crTables = RPTLOTSTATUS.Database.Tables



            ElseIf frmstring = "MFG2" Then
                crTables = rptmfg2.Database.Tables

            ElseIf frmstring = "MFGDETAIL" Then
                If ClientName = "SHUBHLAXMI" Then
                    crTables = RPTMFGPCS.Database.Tables
                Else
                    crTables = rptmfg1.Database.Tables
                End If

            ElseIf frmstring = "MFGDETAILVALUE" Then
                crTables = RPTMFG1VALUE.Database.Tables

            ElseIf frmstring = "MFGSUMMARY" Then
                crTables = rptmfg1SUMM.Database.Tables
            ElseIf frmstring = "MFGMONTHLY" Then
                crTables = rptmfg1MONTHLY.Database.Tables

            ElseIf frmstring = "MFGFULLSUMMARY" Then
                crTables = rptmfgfullSUMM.Database.Tables
            ElseIf frmstring = "MFGFULLMONTHLY" Then
                crTables = rptmfgfullmonth.Database.Tables
            ElseIf frmstring = "MFGFULLDETAIL" Then
                crTables = rptmfgfull.Database.Tables
            ElseIf frmstring = "MFGLOTDETAIL" Then
                crTables = rptmfg1LOTDETAIL.Database.Tables

            ElseIf frmstring = "MFG2DETAIL" Then
                crTables = rptmfg2DETAIL.Database.Tables
            ElseIf frmstring = "MFG2SUMMARY" Then
                crTables = rptmfg2SUMMARY.Database.Tables
            ElseIf frmstring = "MFG2MERCHANT" Then
                crTables = rptmfg2MERCHANT.Database.Tables
            ElseIf frmstring = "MFG2MONTHLY" Then
                crTables = rptmfg2MONTHLY.Database.Tables
            ElseIf frmstring = "MFG2JOB" Then
                crTables = rptmfg2JOB.Database.Tables
            ElseIf frmstring = "MFG2LABOUR" Then
                crTables = rptmfg2LABOUR.Database.Tables
            ElseIf frmstring = "MFG2DESIGN" Then
                crTables = RPTMFG2DESIGN.Database.Tables


            ElseIf frmstring = "CUTTINGSTOCKDETAIL" Then
                crTables = rptCUTTINGSTOCKDETAIL.Database.Tables


            ElseIf frmstring = "MFG2STOCKDETAIL" Then
                'DONE BY GULKIT
                'crTables = rptmfg2STOCKDETAIL.Database.Tables
                crTables = RPTMEMOSTOCK.Database.Tables

            ElseIf frmstring = "MFG2STOCKDETAILVALUE" Then
                crTables = RPTMEMOSTOCKVALUE.Database.Tables

            ElseIf frmstring = "MFG2STOCKSUMMARY" Then
                crTables = rptmfg2STOCKSUMMARY.Database.Tables
            ElseIf frmstring = "MFG2STOCKMERCHANT" Then
                crTables = rptmfg2STOCKMERCHANT.Database.Tables
            ElseIf frmstring = "MFG2STOCKMERCHANTSUMMARY" Then
                'DONE BY GULKIT
                'crTables = rptmfg2STOCKMERCHANTsummary.Database.Tables
                crTables = RPTMEMOSTOCKMERCHATSUMMARY.Database.Tables
            ElseIf frmstring = "MFG2STOCKJOB" Then
                crTables = rptmfg2STOCKJOB.Database.Tables
            ElseIf frmstring = "MFG2STOCKMONTHLY" Then
                crTables = rptmfg2STOCKMONTHLY.Database.Tables
            ElseIf frmstring = "MFG2STOCKLABOUR" Then
                crTables = rptmfg2STOCKLABOUR.Database.Tables


            ElseIf frmstring = "MFG2COSTDETAILS" Then
                crTables = RPTMFG2COSTDETAIL.Database.Tables
            ElseIf frmstring = "MFG2COSTSUMMARY" Then
                crTables = RPTMFG2COSTSUMMARY.Database.Tables
            ElseIf frmstring = "MFG2COSTSUPERSUMMARY" Then
                crTables = RPTMFG2COSTSUPERSUMMARY.Database.Tables
            ElseIf frmstring = "MFG2COSTMERCHANTSUPERSUMMARY" Then
                crTables = RPTMFG2COSTMERCHANTSUPERSUMMARY.Database.Tables
            ElseIf frmstring = "MFG2COSTMERCHANTSCREENSUMMARY" Then
                crTables = RPTMFG2COSTMERCHANTSCREENSUMMARY.Database.Tables
            ElseIf frmstring = "MFG2COSTSCREENSUMMARY" Then
                crTables = RPTMFG2COSTSCREENSUMMARY.Database.Tables
            ElseIf frmstring = "MFG2COSTMONTHLY" Then
                crTables = RPTMFG2COSTMONTHLY.Database.Tables
            ElseIf frmstring = "MFG2JOBCOSTSUMMARY" Then
                crTables = RPTMFG2JOBCOSTSUMMARY.Database.Tables


            ElseIf frmstring = "FCPDETAIL" Then
                crTables = rptFCPDETAIL.Database.Tables
            ElseIf frmstring = "FCPSUMMARY" Then
                crTables = RPTFCPDESIGN.Database.Tables
            ElseIf frmstring = "FCPSUMMARYIMG" Then
                crTables = RPTFCPDESIGNIMG.Database.Tables
            ElseIf frmstring = "FCPVALUELOSS" Then
                crTables = RPTVALUELOSSREPORT.Database.Tables
            ElseIf frmstring = "FCPMERCHANT" Then
                crTables = rptFCPMERCHANT.Database.Tables

            ElseIf frmstring = "LOTHISTORY" Then
                crTables = rptlothistory.Database.Tables
            ElseIf frmstring = "LOTSUMMARY" Then
                crTables = rptlotSUMMARY.Database.Tables


            ElseIf frmstring = "CONTRACTORBILL" Then
                crTables = RPTCONTRACTORBILL.Database.Tables
            End If



            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next


            If frmstring = "MFGREPORT" Then
                crpo.ReportSource = RPTMFG
            ElseIf frmstring = "DYEINGISSUESLIP" Then
                crpo.ReportSource = RPTDYEINGISSUESLIP
                RPTDYEINGISSUESLIP.DataDefinition.FormulaFields("QUALITYWT").Text = Val(QUALITYWT)
                RPTDYEINGISSUESLIP.DataDefinition.FormulaFields("LOTNO").Text = "'" & LOTNO & "'"
            ElseIf frmstring = "DYEING" Then
                crpo.ReportSource = rptDYEING
            ElseIf frmstring = "PROCIAN" Then
                crpo.ReportSource = rptPROCIAN
            ElseIf frmstring = "PROCIANSUMMARY" Then
                ' crpo.ReportSource = rptPROCIANSUMMARY

            ElseIf frmstring = "PARTYLOTSTATUS" Then
                crpo.ReportSource = RPTLOTSTATUS
                RPTLOTSTATUS.DataDefinition.FormulaFields("TITLE").Text = "'" & PARTYNAME & "'"
                RPTLOTSTATUS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"


            ElseIf frmstring = "MFG2" Then
                crpo.ReportSource = rptmfg2
            ElseIf frmstring = "MFGDETAIL" Then
                If ClientName = "SHUBHLAXMI" Then
                    crpo.ReportSource = RPTMFGPCS
                    RPTMFGPCS.DataDefinition.FormulaFields("postive").Text = Val(positive)
                    RPTMFGPCS.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
                Else
                    crpo.ReportSource = rptmfg1
                    rptmfg1.DataDefinition.FormulaFields("postive").Text = Val(positive)
                    rptmfg1.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
                    If SHOWOURQUALITY = True Then rptmfg1.DataDefinition.FormulaFields("SHOWOURQUALITY").Text = "1"
                End If


            ElseIf frmstring = "MFGDETAILVALUE" Then
                crpo.ReportSource = RPTMFG1VALUE
                RPTMFG1VALUE.DataDefinition.FormulaFields("postive").Text = Val(positive)
                RPTMFG1VALUE.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
                If SHOWOURQUALITY = True Then RPTMFG1VALUE.DataDefinition.FormulaFields("SHOWOURQUALITY").Text = "1"

            ElseIf frmstring = "MFGLOTDETAIL" Then
                crpo.ReportSource = rptmfg1LOTDETAIL
                rptmfg1LOTDETAIL.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
                rptmfg1LOTDETAIL.DataDefinition.FormulaFields("FROMDATE").Text = "#" & FROMDATE & "#"
                rptmfg1LOTDETAIL.DataDefinition.FormulaFields("tilldate").Text = "#" & TODATE & "#"

            ElseIf frmstring = "MFGSUMMARY" Then
                crpo.ReportSource = rptmfg1SUMM
                rptmfg1SUMM.DataDefinition.FormulaFields("postive").Text = Val(positive)
                rptmfg1SUMM.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
                If SHOWOURQUALITY = True Then rptmfg1SUMM.DataDefinition.FormulaFields("SHOWOURQUALITY").Text = "1"

                'ADD DATA IN TEMPLOTSUMMARY TABLE
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPLOTSUMMARY WHERE YEARID = " & YearId, "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO TEMPLOTSUMMARY SELECT LOTNO, ROUND(SUM(PCS),0), ROUND(SUM(MTRS),2), Q.QUALITY, Q.OURQUALITY, CMPID, YEARID FROM VIEW_SUMMARY_MFG1 T CROSS APPLY (SELECT TOP 1 QUALITY, OURQUALITY FROM VIEW_SUMMARY_MFG1 S WHERE S.LOTNO = T.LOTNO AND S.YEARID = T.YEARID ) as Q WHERE YEARID = " & YearId & " GROUP BY LOTNO, Q.QUALITY, Q.OURQUALITY, CMPID, YEARID HAVING ROUND(SUM(MTRS),2)>0 ORDER BY LOTNO", "", "")
                selfor_po = ""

            ElseIf frmstring = "MFGMONTHLY" Then
                crpo.ReportSource = rptmfg1MONTHLY
                rptmfg1MONTHLY.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"

            ElseIf frmstring = "LOTHISTORY" Then
                crpo.ReportSource = rptlothistory
                rptlothistory.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"

            ElseIf frmstring = "LOTSUMMARY" Then
                crpo.ReportSource = rptlotSUMMARY
                rptlotSUMMARY.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"

            ElseIf frmstring = "MFGFULLSUMMARY" Then
                crpo.ReportSource = rptmfgfullSUMM
                rptmfgfullSUMM.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFGFULLMONTHLY" Then
                crpo.ReportSource = rptmfgfullmonth
                rptmfgfullmonth.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"

            ElseIf frmstring = "MFGFULLDETAIL" Then
                crpo.ReportSource = rptmfgfull
                rptmfgfull.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"

            ElseIf frmstring = "MFG2SUMMARY" Then
                crpo.ReportSource = rptmfg2SUMMARY
                rptmfg2SUMMARY.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2DETAIL" Then
                crpo.ReportSource = rptmfg2DETAIL
                rptmfg2DETAIL.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2MERCHANT" Then
                crpo.ReportSource = rptmfg2MERCHANT
                rptmfg2MERCHANT.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2JOB" Then
                crpo.ReportSource = rptmfg2JOB
                rptmfg2JOB.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2LABOUR" Then
                crpo.ReportSource = rptmfg2LABOUR
                rptmfg2LABOUR.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2DESIGN" Then
                crpo.ReportSource = RPTMFG2DESIGN
                RPTMFG2DESIGN.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"


            ElseIf frmstring = "MFG2MONTHLY" Then
                crpo.ReportSource = rptmfg2MONTHLY
                rptmfg2MONTHLY.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "CUTTINGSTOCKDETAIL" Then
                crpo.ReportSource = rptCUTTINGSTOCKDETAIL
                rptCUTTINGSTOCKDETAIL.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2STOCKMERCHANT" Then
                crpo.ReportSource = rptmfg2STOCKMERCHANT
                rptmfg2STOCKMERCHANT.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2STOCKMERCHANTSUMMARY" Then
                'DONE BY GULKIT
                'crpo.ReportSource = rptmfg2STOCKMERCHANTsummary
                'rptmfg2STOCKMERCHANTsummary.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTMEMOSTOCKMERCHATSUMMARY
                RPTMEMOSTOCKMERCHATSUMMARY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2STOCKSUMMARY" Then
                crpo.ReportSource = rptmfg2STOCKSUMMARY
                rptmfg2STOCKSUMMARY.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"

            ElseIf frmstring = "MFG2STOCKDETAIL" Then
                'DONE BY GULKIT
                'crpo.ReportSource = rptmfg2STOCKDETAIL
                'rptmfg2STOCKDETAIL.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTMEMOSTOCK
                RPTMEMOSTOCK.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

            ElseIf frmstring = "MFG2STOCKDETAILVALUE" Then
                crpo.ReportSource = RPTMEMOSTOCKVALUE
                RPTMEMOSTOCKVALUE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"


            ElseIf frmstring = "MFG2STOCKJOB" Then
                crpo.ReportSource = rptmfg2STOCKJOB
                rptmfg2STOCKJOB.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2STOCKLABOUR" Then
                crpo.ReportSource = rptmfg2STOCKLABOUR
                rptmfg2STOCKLABOUR.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2STOCKMONTHLY" Then
                crpo.ReportSource = rptmfg2STOCKMONTHLY
                rptmfg2STOCKMONTHLY.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2COSTSUMMARY" Then
                crpo.ReportSource = RPTMFG2COSTSUMMARY
                RPTMFG2COSTSUMMARY.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2COSTDETAILS" Then
                crpo.ReportSource = RPTMFG2COSTDETAIL
                RPTMFG2COSTDETAIL.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2COSTSUPERSUMMARY" Then
                crpo.ReportSource = RPTMFG2COSTSUPERSUMMARY
                RPTMFG2COSTSUPERSUMMARY.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2COSTMERCHANTSUPERSUMMARY" Then
                crpo.ReportSource = RPTMFG2COSTMERCHANTSUPERSUMMARY
                RPTMFG2COSTMERCHANTSUPERSUMMARY.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2COSTMERCHANTSCREENSUMMARY" Then
                crpo.ReportSource = RPTMFG2COSTMERCHANTSCREENSUMMARY
                RPTMFG2COSTMERCHANTSCREENSUMMARY.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2COSTSCREENSUMMARY" Then
                crpo.ReportSource = RPTMFG2COSTSCREENSUMMARY
                RPTMFG2COSTSCREENSUMMARY.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2COSTMONTHLY" Then
                crpo.ReportSource = RPTMFG2COSTMONTHLY
                RPTMFG2COSTMONTHLY.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "MFG2JOBCOSTSUMMARY" Then
                crpo.ReportSource = RPTMFG2JOBCOSTSUMMARY
                RPTMFG2JOBCOSTSUMMARY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"


            ElseIf frmstring = "FCPVALUELOSS" Then
                crpo.ReportSource = RPTVALUELOSSREPORT
                RPTVALUELOSSREPORT.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
                RPTVALUELOSSREPORT.DataDefinition.FormulaFields("HIDERATE").Text = HIDERATE
            ElseIf frmstring = "FCPSUMMARY" Then
                crpo.ReportSource = RPTFCPDESIGN
                RPTFCPDESIGN.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "FCPSUMMARYIMG" Then
                crpo.ReportSource = RPTFCPDESIGNIMG
                RPTFCPDESIGNIMG.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "FCPDETAIL" Then
                crpo.ReportSource = rptFCPDETAIL
                rptFCPDETAIL.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf frmstring = "FCPMERCHANT" Then
                crpo.ReportSource = rptFCPMERCHANT
                rptFCPMERCHANT.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
                If HIDERATE = True Then RPTFCPMERCHANT.DataDefinition.FormulaFields("HIDERATE").Text = 1 Else RPTFCPMERCHANT.DataDefinition.FormulaFields("HIDERATE").Text = 0

            ElseIf frmstring = "CONTRACTORBILL" Then
                crpo.ReportSource = RPTCONTRACTORBILL
                RPTCONTRACTORBILL.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            End If
            '************************ END *******************
            crpo.SelectionFormula = selfor_po

            crpo.Zoom(100)
            crpo.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim objmail As New SendMail
            If frmstring = "FCPSUMMARYIMG" Then
                tempattachment = ITEMNAME
                objmail.subject = "DESIGN CATALOGUE"
            Else
                tempattachment = "Mfg"
                objmail.subject = "Mfg Report"
            End If
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".pdf"
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
            If frmstring = "FCPSUMMARYIMG" Then oDfDopt.DiskFileName = Application.StartupPath & "\" & ITEMNAME & ".pdf" Else oDfDopt.DiskFileName = Application.StartupPath & "\Mfg.pdf"

            If frmstring = "MFGREPORT" Then
                expo = RPTMFG.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMFG.Export()
            ElseIf frmstring = "DYEINGISSUESLIP" Then
                expo = RPTDYEINGISSUESLIP.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTDYEINGISSUESLIP.Export()
            ElseIf frmstring = "DYEING" Then
                expo = rptDYEING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptDYEING.Export()
            ElseIf frmstring = "PROCIAN" Then
                expo = rptPROCIAN.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptPROCIAN.Export()

            ElseIf frmstring = "PARTYLOTSTATUS" Then
                expo = RPTLOTSTATUS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTLOTSTATUS.Export()


            ElseIf frmstring = "MFG2" Then
                expo = rptmfg2.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg2.Export()
            ElseIf frmstring = "MFGDETAIL" Then
                expo = rptmfg1.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg1.Export()
            ElseIf frmstring = "MFGDETAILVALUE" Then
                expo = RPTMFG1VALUE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMFG1VALUE.Export()
            ElseIf frmstring = "MFGLOTDETAIL" Then
                expo = rptmfg1LOTDETAIL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg1LOTDETAIL.Export()
            ElseIf frmstring = "MFGSUMMARY" Then
                expo = rptmfg1SUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg1SUMM.Export()
            ElseIf frmstring = "MFGMONTHLY" Then
                expo = rptmfg1MONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg1MONTHLY.Export()
            ElseIf frmstring = "LOTHISTORY" Then
                expo = rptlothistory.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptlothistory.Export()
            ElseIf frmstring = "LOTSUMMARY" Then
                expo = rptlotSUMMARY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptlotSUMMARY.Export()
            ElseIf frmstring = "MFGFULLSUMMARY" Then
                expo = rptmfgfullSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfgfullSUMM.Export()
            ElseIf frmstring = "MFGFULLMONTHLY" Then
                expo = rptmfgfullmonth.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfgfullmonth.Export()
            ElseIf frmstring = "MFGFULLDETAIL" Then
                expo = rptmfgfull.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfgfull.Export()
            ElseIf frmstring = "MFG2SUMMARY" Then
                expo = rptmfg2SUMMARY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg2SUMMARY.Export()
            ElseIf frmstring = "MFG2DETAIL" Then
                expo = rptmfg2DETAIL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg2DETAIL.Export()
            ElseIf frmstring = "MFG2MERCHANT" Then
                expo = rptmfg2MERCHANT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg2MERCHANT.Export()
            ElseIf frmstring = "MFG2JOB" Then
                expo = rptmfg2JOB.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg2JOB.Export()
            ElseIf frmstring = "MFG2LABOUR" Then
                expo = rptmfg2LABOUR.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg2LABOUR.Export()
            ElseIf frmstring = "MFG2DESIGN" Then
                expo = RPTMFG2DESIGN.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMFG2DESIGN.Export()

            ElseIf frmstring = "MFG2MONTHLY" Then
                expo = rptmfg2MONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg2MONTHLY.Export()
            ElseIf frmstring = "CUTTINGSTOCKDETAIL" Then
                expo = rptCUTTINGSTOCKDETAIL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptCUTTINGSTOCKDETAIL.Export()
            ElseIf frmstring = "MFG2STOCKMERCHANT" Then
                expo = rptmfg2STOCKMERCHANT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg2STOCKMERCHANT.Export()
            ElseIf frmstring = "MFG2STOCKMERCHANTSUMMARY" Then
                expo = RPTMEMOSTOCKMERCHATSUMMARY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMEMOSTOCKMERCHATSUMMARY.Export()
            ElseIf frmstring = "MFG2STOCKSUMMARY" Then
                expo = rptmfg2STOCKSUMMARY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg2STOCKSUMMARY.Export()
            ElseIf frmstring = "MFG2STOCKDETAIL" Then
                expo = RPTMEMOSTOCK.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMEMOSTOCK.Export()

            ElseIf frmstring = "MFG2STOCKDETAILVALUE" Then
                expo = RPTMEMOSTOCKVALUE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMEMOSTOCKVALUE.Export()


            ElseIf frmstring = "MFG2STOCKJOB" Then
                expo = rptmfg2STOCKJOB.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg2STOCKJOB.Export()
            ElseIf frmstring = "MFG2STOCKLABOUR" Then
                expo = rptmfg2STOCKLABOUR.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg2STOCKLABOUR.Export()
            ElseIf frmstring = "MFG2STOCKMONTHLY" Then
                expo = rptmfg2STOCKMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptmfg2STOCKMONTHLY.Export()
            ElseIf frmstring = "MFG2COSTSUMMARY" Then
                expo = RPTMFG2COSTSUMMARY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMFG2COSTSUMMARY.Export()
            ElseIf frmstring = "MFG2COSTDETAILS" Then
                expo = RPTMFG2COSTDETAIL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMFG2COSTDETAIL.Export()
            ElseIf frmstring = "MFG2COSTSUPERSUMMARY" Then
                expo = RPTMFG2COSTSUPERSUMMARY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMFG2COSTSUPERSUMMARY.Export()
            ElseIf frmstring = "MFG2COSTMERCHANTSUPERSUMMARY" Then
                expo = RPTMFG2COSTMERCHANTSUPERSUMMARY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMFG2COSTMERCHANTSUPERSUMMARY.Export()
            ElseIf frmstring = "MFG2COSTMERCHANTSCREENSUMMARY" Then
                expo = RPTMFG2COSTMERCHANTSCREENSUMMARY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMFG2COSTMERCHANTSCREENSUMMARY.Export()
            ElseIf frmstring = "MFG2COSTSCREENSUMMARY" Then
                expo = RPTMFG2COSTSCREENSUMMARY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMFG2COSTSCREENSUMMARY.Export()
            ElseIf frmstring = "MFG2COSTMONTHLY" Then
                expo = RPTMFG2COSTMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMFG2COSTMONTHLY.Export()
            ElseIf frmstring = "MFG2JOBCOSTSUMMARY" Then
                expo = RPTMFG2JOBCOSTSUMMARY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMFG2JOBCOSTSUMMARY.Export()
            ElseIf frmstring = "FCPVALUELOSS" Then
                expo = RPTVALUELOSSREPORT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTVALUELOSSREPORT.Export()
            ElseIf frmstring = "FCPDETAIL" Then
                expo = rptFCPDETAIL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptFCPDETAIL.Export()
            ElseIf frmstring = "FCPSUMMARY" Then
                expo = RPTFCPDESIGN.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTFCPDESIGN.Export()
            ElseIf frmstring = "FCPSUMMARYIMG" Then
                expo = RPTFCPDESIGNIMG.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTFCPDESIGNIMG.Export()
            ElseIf frmstring = "FCPMERCHANT" Then
                expo = rptFCPMERCHANT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptFCPMERCHANT.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub mfgdesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
End Class