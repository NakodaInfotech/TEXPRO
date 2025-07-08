
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports BL

Public Class GRNReportDesign

    Public selfor_GRN As String
    Public FRMSTRING As String
    Public GRNNO As Integer

    Dim rptGRNItem As New GRNItemwise
    Dim rptGRNQuality As New GRNQualitywise
    Dim rptGRNParty As New GRNPartywise
    Dim rptGRNMonth As New GRNMonthwise
    Dim rptGRNItemSummary As New GRNItemwiseSummary
    Dim rptGRNQualitySummary As New GRNQualitywiseSummary
    Dim rptGRNPartySummary As New GRNPartywiseSummary

    Dim RPTSTOREDTLS As New GRNStoreDetailsReport
    Dim RPTSTOREITEM As New GRNStoreItemDetailsReport
    Dim RPTSTOREPARTY As New GRNStorePartyDetailsReport


    Dim rptCHECKSUMMARY As New PARTYWISECHECKING_Checking_Summary
    Dim rptPARTYWISESUMMARY As New PARTYWISECHECKING_Summary
    Dim rptPARTYWISEDETAIL As New PARTYWISECHECKING_details
    Dim rptQUALITYWISESUMMARY As New QUALITYWISECHECKING_Summary
    Dim rptMONTHWISESUMMARY As New MONTHWISE_CHECKING
    Dim RPTCHECKDTLS As New GRNCheckingDetailReport

    Dim rptLOTWISE As New LotwiseReport


    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions
    Public vendorname As String

    Public FROMDATE As String
    Public TODATE As String
    Public OPENINGDATE As String
    Public selfor_ss As String
    Public PERIOD As String
    Public summary As Boolean

    Private Sub GRNReportDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GRNReportDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If summary = True Then
                If FRMSTRING = "LOT" Then crTables = rptLOTWISE.Database.Tables
                If FRMSTRING = "ITEM" Then crTables = rptGRNItemSummary.Database.Tables
                If FRMSTRING = "QUALITY" Then crTables = rptGRNQualitySummary.Database.Tables
                If FRMSTRING = "PARTY" Then crTables = rptGRNPartySummary.Database.Tables
                If FRMSTRING = "PARTYWISESUMMARY" Then crTables = rptPARTYWISESUMMARY.Database.Tables
                If FRMSTRING = "QUALITYWISESUMMARY" Then crTables = rptQUALITYWISESUMMARY.Database.Tables
                If FRMSTRING = "PARTYWISEDETAIL" Then crTables = rptPARTYWISEDETAIL.Database.Tables
                If FRMSTRING = "MONTHWISESUMMARY" Then crTables = rptMONTHWISESUMMARY.Database.Tables
                If FRMSTRING = "CHECKSUMMARY" Then crTables = rptCHECKSUMMARY.Database.Tables
            Else
                If FRMSTRING = "ITEM" Then crTables = rptGRNItem.Database.Tables
                If FRMSTRING = "QUALITY" Then crTables = rptGRNQuality.Database.Tables
                If FRMSTRING = "PARTY" Then crTables = rptGRNParty.Database.Tables
                If FRMSTRING = "MONTH" Then crTables = rptGRNMonth.Database.Tables
                If FRMSTRING = "CHECKDETAILS" Then crTables = RPTCHECKDTLS.Database.Tables
                If FRMSTRING = "STOREDETAILS" Then crTables = RPTSTOREDTLS.Database.Tables
                If FRMSTRING = "STOREITEM" Then crTables = RPTSTOREITEM.Database.Tables
                If FRMSTRING = "STOREPARTY" Then crTables = RPTSTOREPARTY.Database.Tables
            End If

            If summary = True Then
                If FRMSTRING = "ITEM" Then
                    crpo.ReportSource = rptGRNItemSummary
                    crTables = rptGRNItemSummary.Database.Tables
                ElseIf FRMSTRING = "QUALITY" Then
                    crpo.ReportSource = rptGRNQualitySummary
                    crTables = rptGRNQualitySummary.Database.Tables
                ElseIf FRMSTRING = "PARTY" Then
                    crpo.ReportSource = rptGRNPartySummary
                    crTables = rptGRNPartySummary.Database.Tables
                ElseIf FRMSTRING = "PARTYWISESUMMARY" Then
                    crpo.ReportSource = rptPARTYWISESUMMARY
                    crTables = rptPARTYWISESUMMARY.Database.Tables
                ElseIf FRMSTRING = "QUALITYWISESUMMARY" Then
                    crpo.ReportSource = rptQUALITYWISESUMMARY
                    crTables = rptQUALITYWISESUMMARY.Database.Tables
                ElseIf FRMSTRING = "PARTYWISEDETAIL" Then
                    crpo.ReportSource = rptPARTYWISEDETAIL
                    crTables = rptPARTYWISEDETAIL.Database.Tables
                ElseIf FRMSTRING = "MONTHWISESUMMARY" Then
                    crpo.ReportSource = rptMONTHWISESUMMARY
                    crTables = rptMONTHWISESUMMARY.Database.Tables
                ElseIf FRMSTRING = "CHECKSUMMARY" Then
                    crpo.ReportSource = rptCHECKSUMMARY
                    crTables = rptCHECKSUMMARY.Database.Tables
                ElseIf FRMSTRING = "LOT" Then
                    crpo.ReportSource = rptLOTWISE
                    crTables = rptLOTWISE.Database.Tables
                End If
            Else
                If FRMSTRING = "ITEM" Then
                    crpo.ReportSource = rptGRNItem
                    crTables = rptGRNItem.Database.Tables
                ElseIf FRMSTRING = "QUALITY" Then
                    crpo.ReportSource = rptGRNQuality
                    crTables = rptGRNQuality.Database.Tables
                ElseIf FRMSTRING = "PARTY" Then
                    crpo.ReportSource = rptGRNParty
                    crTables = rptGRNParty.Database.Tables
                ElseIf FRMSTRING = "MONTH" Then
                    crpo.ReportSource = rptGRNMonth
                    crTables = rptGRNMonth.Database.Tables
                ElseIf FRMSTRING = "CHECKDETAILS" Then
                    crpo.ReportSource = RPTCHECKDTLS
                    crTables = RPTCHECKDTLS.Database.Tables
                ElseIf FRMSTRING = "STOREDETAILS" Then
                    crpo.ReportSource = RPTSTOREDTLS
                    crTables = RPTSTOREDTLS.Database.Tables
                ElseIf FRMSTRING = "STOREITEM" Then
                    crpo.ReportSource = RPTSTOREITEM
                    crTables = RPTSTOREITEM.Database.Tables
                ElseIf FRMSTRING = "STOREPARTY" Then
                    crpo.ReportSource = RPTSTOREPARTY
                    crTables = RPTSTOREPARTY.Database.Tables
                End If
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = selfor_ss

            If summary = True Then
                If FRMSTRING = "ITEM" Then
                    crpo.ReportSource = rptGRNItemSummary
                    rptGRNItemSummary.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                ElseIf FRMSTRING = "QUALITY" Then
                    crpo.ReportSource = rptGRNQualitySummary
                    rptGRNQualitySummary.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                ElseIf FRMSTRING = "PARTY" Then
                    crpo.ReportSource = rptGRNPartySummary
                    rptGRNPartySummary.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"

                ElseIf FRMSTRING = "PARTYWISESUMMARY" Then
                    crpo.ReportSource = rptPARTYWISESUMMARY
                ElseIf FRMSTRING = "QUALITYWISESUMMARY" Then
                    crpo.ReportSource = rptQUALITYWISESUMMARY
                ElseIf FRMSTRING = "PARTYWISEDETAIL" Then
                    crpo.ReportSource = rptPARTYWISEDETAIL
                ElseIf FRMSTRING = "MONTHWISESUMMARY" Then
                    crpo.ReportSource = rptMONTHWISESUMMARY
                ElseIf FRMSTRING = "CHECKSUMMARY" Then
                    crpo.ReportSource = rptCHECKSUMMARY
                ElseIf FRMSTRING = "LOT" Then
                    crpo.ReportSource = rptLOTWISE
                End If
            Else
                If FRMSTRING = "ITEM" Then
                    crpo.ReportSource = rptGRNItem
                    rptGRNItem.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                ElseIf FRMSTRING = "QUALITY" Then
                    crpo.ReportSource = rptGRNQuality
                    rptGRNQuality.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                ElseIf FRMSTRING = "PARTY" Then
                    crpo.ReportSource = rptGRNParty
                    rptGRNParty.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                ElseIf FRMSTRING = "MONTH" Then
                    crpo.ReportSource = rptGRNMonth
                ElseIf FRMSTRING = "CHECKDETAILS" Then
                    crpo.ReportSource = RPTCHECKDTLS
                    RPTCHECKDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                ElseIf FRMSTRING = "STOREDETAILS" Then
                    crpo.ReportSource = RPTSTOREDTLS
                    RPTSTOREDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                ElseIf FRMSTRING = "STOREITEM" Then
                    crpo.ReportSource = RPTSTOREITEM
                    RPTSTOREITEM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                ElseIf FRMSTRING = "STOREPARTY" Then
                    crpo.ReportSource = RPTSTOREPARTY
                    RPTSTOREPARTY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                End If
            End If

            '************************ END *******************
            crpo.SelectionFormula = selfor_ss
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
            tempattachment = "GRN No." & GRNNO
            If vendorname <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" acc_email ", "", " LEDGERS ", " and ACC_cmpname='" & vendorname & "' and ACC_cmpid=" & CmpId & " and ACC_LOCATIONid=" & Locationid & " and ACC_YEARid=" & YearId)
                If dt.Rows.Count > 0 Then
                    emailid = dt.Rows(0).Item(0).ToString
                End If
            End If

            Dim objmail As New SendMail
            objmail.attachment = tempattachment
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
            If summary = True Then
                If FRMSTRING = "ITEM" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\GRN No." & GRNNO & ".pdf"
                    expo = rptGRNItemSummary.ExportOptions
                ElseIf FRMSTRING = "QUALITY" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\GRN No." & GRNNO & ".pdf"
                    expo = rptGRNQualitySummary.ExportOptions
                ElseIf FRMSTRING = "PARTY" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\GRN No." & GRNNO & ".pdf"
                    expo = rptGRNPartySummary.ExportOptions
                ElseIf FRMSTRING = "LOT" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\GRN No." & GRNNO & ".pdf"
                    expo = rptLOTWISE.ExportOptions
                    'ElseIf FRMSTRING = "PARTYWISESUMMARY" Then
                    '    oDfDopt.DiskFileName = Application.StartupPath & "\GRN No." & GRNNO & ".pdf"
                    '    expo = rptGRNPartySummary.ExportOptions
                    'ElseIf FRMSTRING = "QUALITYWISESUMMARY" Then
                    '    oDfDopt.DiskFileName = Application.StartupPath & "\GRN No." & GRNNO & ".pdf"
                    '    expo = rptGRNPartySummary.ExportOptions
                    'ElseIf FRMSTRING = "PARTYWISEDETAIL" Then
                    '    oDfDopt.DiskFileName = Application.StartupPath & "\GRN No." & GRNNO & ".pdf"
                    '    expo = rptGRNPartySummary.ExportOptions
                    'ElseIf FRMSTRING = "MONTHWISESUMMARY" Then
                    '    oDfDopt.DiskFileName = Application.StartupPath & "\GRN No." & GRNNO & ".pdf"
                    '    expo = rptGRNPartySummary.ExportOptions
                    'ElseIf FRMSTRING = "CHECKSUMMARY" Then
                    '    oDfDopt.DiskFileName = Application.StartupPath & "\GRN No." & GRNNO & ".pdf"
                    '    expo = rptGRNPartySummary.ExportOptions

                End If

            Else
                If FRMSTRING = "ITEM" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\GRN No." & GRNNO & ".pdf"
                    expo = rptGRNItem.ExportOptions
                ElseIf FRMSTRING = "QUALITY" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\GRN No." & GRNNO & ".pdf"
                    expo = rptGRNQuality.ExportOptions
                ElseIf FRMSTRING = "PARTY" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\GRN No." & GRNNO & ".pdf"
                    expo = rptGRNParty.ExportOptions
                ElseIf FRMSTRING = "MONTH" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\GRN No." & GRNNO & ".pdf"
                    expo = rptGRNMonth.ExportOptions
                ElseIf FRMSTRING = "CHECKDETAILS" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\Checking Report.pdf"
                    expo = RPTCHECKDTLS.ExportOptions
                End If
            End If
            expo.ExportDestinationType = ExportDestinationType.DiskFile
            expo.ExportFormatType = ExportFormatType.PortableDocFormat
            expo.DestinationOptions = oDfDopt

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class