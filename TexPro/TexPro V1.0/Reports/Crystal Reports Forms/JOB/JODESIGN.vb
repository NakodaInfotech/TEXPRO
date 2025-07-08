
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports System.Drawing.Printing

Public Class JODESIGN

    Public FORMULA As String
    Public PERIOD As String
    Public FRMSTRING As String
    Public TOTALMTRS As Double
    Public TOTALPCS As Double
    Public HEADER As Boolean
    Public HIDERATE As Boolean

    Dim RPTJO As New pendingjoreport
    Dim RPTJOOURQUALITY As New PENDINGJOREPORTOURQUALITY

    Dim RPTPARTY As New Jobberwise_pendingjoreport
    Dim RPTITEM As New merchantwise_pendingjoreport
    Dim RPTJOBOUT As New JOBOUTREPORT
    Dim RPTSUMM As New Jobberwise_pendingjoreport
    Dim RPTPSJOB As New psjobreport
    Dim RPTMONTHLY As New Jobberwise_pendingjoreport

    Dim RPTJODTLS As New JobOutDtlsReport
    Dim RPTJOPARTYDTLS As New JobOutPartyDtlsReport
    Dim RPTJOMONTHLY As New JobOutMonthlyReport

    Dim RPTJIDTLS As New JobInDtlsReport
    Dim RPTJIPARTYDTLS As New JobInPartyDtlsReport
    Dim RPTJOFINALCUTTING As New JobFinalCuttingReport


    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions
    Public vendorname As String

    Private Sub JODESIGN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GRNDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            If FRMSTRING = "JOB" Then
                crTables = RPTJOBOUT.Database.Tables
            ElseIf FRMSTRING = "PSJOB" Then
                crTables = RPTPSJOB.Database.Tables
                Dim objprinter As PageSettings = New PageSettings
            ElseIf FRMSTRING = "DETAIL" Then
                crTables = RPTJO.Database.Tables
                If HIDERATE = True Then RPTJO.DataDefinition.FormulaFields("HIDERATE").Text = 1 Else RPTJO.DataDefinition.FormulaFields("HIDERATE").Text = 0
                RPTJO.DataDefinition.FormulaFields("PENDINGMTRS").Text = Val(TOTALMTRS)
                RPTJO.DataDefinition.FormulaFields("PENDINGPCS").Text = Val(TOTALPCS)
            ElseIf FRMSTRING = "DETAILOURQUALITY" Then
                crTables = RPTJOOURQUALITY.Database.Tables
                If HIDERATE = True Then RPTJOOURQUALITY.DataDefinition.FormulaFields("HIDERATE").Text = 1 Else RPTJOOURQUALITY.DataDefinition.FormulaFields("HIDERATE").Text = 0
                RPTJOOURQUALITY.DataDefinition.FormulaFields("PENDINGMTRS").Text = Val(TOTALMTRS)
                RPTJOOURQUALITY.DataDefinition.FormulaFields("PENDINGPCS").Text = Val(TOTALPCS)
            ElseIf FRMSTRING = "JOBFINALCUTTING" Then
                crTables = RPTJOFINALCUTTING.Database.Tables
                If HIDERATE = True Then RPTJOFINALCUTTING.DataDefinition.FormulaFields("HIDERATE").Text = 1 Else RPTJOFINALCUTTING.DataDefinition.FormulaFields("HIDERATE").Text = 0
                RPTJOFINALCUTTING.DataDefinition.FormulaFields("PENDINGMTRS").Text = Val(TOTALMTRS)
                RPTJOFINALCUTTING.DataDefinition.FormulaFields("PENDINGPCS").Text = Val(TOTALPCS)
            ElseIf FRMSTRING = "SUMMARY" Then
                crTables = RPTSUMM.Database.Tables
                If HIDERATE = True Then RPTSUMM.DataDefinition.FormulaFields("HIDERATE").Text = 1 Else RPTSUMM.DataDefinition.FormulaFields("HIDERATE").Text = 0
            ElseIf FRMSTRING = "PARTYWISE" Then
                crTables = RPTPARTY.Database.Tables
            ElseIf FRMSTRING = "ITEM" Then
                crTables = RPTITEM.Database.Tables
            ElseIf FRMSTRING = "MONTHLY" Then
                crTables = RPTMONTHLY.Database.Tables
            ElseIf FRMSTRING = "JODTLS" Then
                crTables = RPTJODTLS.Database.Tables
                RPTJODTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOPARTYWISE" Then
                crTables = RPTJOPARTYDTLS.Database.Tables
                RPTJOPARTYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOMONTHLY" Then
                crTables = RPTJOMONTHLY.Database.Tables
                RPTJOMONTHLY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JIDTLS" Then
                crTables = RPTJIDTLS.Database.Tables
                RPTJIDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JIPARTYWISE" Then
                crTables = RPTJIPARTYDTLS.Database.Tables
                RPTJIPARTYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = FORMULA
            If FRMSTRING = "JOB" Then
                crpo.ReportSource = RPTJOBOUT
            ElseIf FRMSTRING = "PSJOB" Then
                If HEADER = False Then
                    RPTPSJOB.DataDefinition.FormulaFields("HIDEHEADER").Text = 1
                Else
                    RPTPSJOB.DataDefinition.FormulaFields("HIDEHEADER").Text = 0
                End If
                crpo.ReportSource = RPTPSJOB
            ElseIf FRMSTRING = "DETAIL" Then
                crpo.ReportSource = RPTJO
            ElseIf FRMSTRING = "DETAILOURQUALITY" Then
                crpo.ReportSource = RPTJOOURQUALITY
            ElseIf FRMSTRING = "SUMMARY" Then
                crpo.ReportSource = RPTSUMM
            ElseIf FRMSTRING = "PARTYWISE" Then
                crpo.ReportSource = RPTPARTY
            ElseIf FRMSTRING = "ITEM" Then
                crpo.ReportSource = RPTITEM
            ElseIf FRMSTRING = "MONTHLY" Then
                crpo.ReportSource = RPTMONTHLY
            ElseIf FRMSTRING = "JODTLS" Then
                crpo.ReportSource = RPTJODTLS
            ElseIf FRMSTRING = "JOPARTYWISE" Then
                crpo.ReportSource = RPTJOPARTYDTLS
            ElseIf FRMSTRING = "JOMONTHLY" Then
                crpo.ReportSource = RPTJOMONTHLY
            ElseIf FRMSTRING = "JIDTLS" Then
                crpo.ReportSource = RPTJIDTLS
            ElseIf FRMSTRING = "JIPARTYWISE" Then
                crpo.ReportSource = RPTJIPARTYDTLS
            ElseIf FRMSTRING = "JOBFINALCUTTING" Then
                crpo.ReportSource = RPTJOFINALCUTTING
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

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            tempattachment = "JOBS"
            If vendorname <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" acc_email ", "", " LEDGERS ", " and ACC_cmpname='" & vendorname & "' and ACC_cmpid=" & CmpId & " and ACC_LOCATIONid=" & Locationid & " and ACC_YEARid=" & YearId)
                If dt.Rows.Count > 0 Then
                    emailid = dt.Rows(0).Item(0).ToString
                End If
            End If

            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".pdf"
            objmail.subject = "Job Detail Report"
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
            oDfDopt.DiskFileName = Application.StartupPath & "\JOBS.pdf"

            If FRMSTRING = "JOB" Then
                expo = RPTJOBOUT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOBOUT.Export()
            ElseIf FRMSTRING = "PSJOB" Then
                If HEADER = False Then
                    RPTPSJOB.DataDefinition.FormulaFields("HIDEHEADER").Text = 1
                Else
                    RPTPSJOB.DataDefinition.FormulaFields("HIDEHEADER").Text = 0
                End If
                expo = RPTPSJOB.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPSJOB.Export()
            ElseIf FRMSTRING = "DETAIL" Then
                expo = RPTJO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJO.Export()
            ElseIf FRMSTRING = "DETAILOURQUALITY" Then
                expo = RPTJOOURQUALITY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOOURQUALITY.Export()
            ElseIf FRMSTRING = "JOFINALCUTTING" Then
                expo = RPTJOFINALCUTTING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOFINALCUTTING.Export()
            ElseIf FRMSTRING = "SUMMARY" Then
                expo = RPTSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSUMM.Export()
            ElseIf FRMSTRING = "PARTYWISE" Then
                expo = RPTPARTY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPARTY.Export()
            ElseIf FRMSTRING = "ITEM" Then
                expo = RPTITEM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTITEM.Export()
            ElseIf FRMSTRING = "MONTHLY" Then
                expo = RPTMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTMONTHLY.Export()
            ElseIf FRMSTRING = "JODTLS" Then
                expo = RPTJODTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJODTLS.Export()
            ElseIf FRMSTRING = "JOPARTYWISE" Then
                expo = RPTJOPARTYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOPARTYDTLS.Export()
            ElseIf FRMSTRING = "JOMONTHLY" Then
                expo = RPTJOMONTHLY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJOMONTHLY.Export()
            ElseIf FRMSTRING = "JIDTLS" Then
                expo = RPTJIDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJIDTLS.Export()
            ElseIf FRMSTRING = "JIPARTYWISE" Then
                expo = RPTJIPARTYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTJIPARTYDTLS.Export()
            End If

            
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class