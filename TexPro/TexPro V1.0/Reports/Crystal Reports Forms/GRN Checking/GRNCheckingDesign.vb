

Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports BL
Imports System.IO

Public Class GRNCheckingDesign

    Public WHERECLAUSE As String = ""
    Public VENDORNAME As String = ""

    Dim rptGRNCHECKING As New GRNCheckingreport
    Dim RPTGRNCHECKING_DHANLAXMI As New GRNCheckingreport_DHANLAXMI
    Dim rptreturnGRNCHECKING As New RETURNGRNCheckingreport

    Dim RPTTRANSFER As New InterGodownTransferReport

    Public FRMSTRING As String = ""
    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions

    Public GRNCHECKINGNO As Integer
    Public GRNCHECKINGLOTNO As String
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing

    Private Sub GRNCheckingDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GRNCheckingDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If FRMSTRING = "CHECKING" Then
                If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Or ClientName = "MONOGRAM" Then
                    crTables = RPTGRNCHECKING_DHANLAXMI.Database.Tables
                Else
                    crTables = rptGRNCHECKING.Database.Tables
                End If

            ElseIf FRMSTRING = "TRANSFER" Then
                crTables = RPTTRANSFER.Database.Tables

            ElseIf FRMSTRING = "RETURN" Then
                crTables = rptreturnGRNCHECKING.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = WHERECLAUSE
            If FRMSTRING = "CHECKING" Then
                If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Or ClientName = "MONOGRAM" Then
                    crpo.ReportSource = RPTGRNCHECKING_DHANLAXMI
                Else
                    crpo.ReportSource = rptGRNCHECKING
                End If

            ElseIf FRMSTRING = "TRANSFER" Then
                crpo.ReportSource = RPTTRANSFER

            ElseIf FRMSTRING = "RETURN" Then
                crpo.ReportSource = rptreturnGRNCHECKING

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

            strsearch = " {CHECKINGMASTER.CHECK_no}=" & GRNCHECKINGNO & " and {CHECKINGMASTER.CHECK_yearid}=" & YearId

            Dim OBJ As New Object
            If FRMSTRING = "CHECKING" Then
                If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Or ClientName = "MONOGRAM" Then
                    OBJ = New GRNCheckingreport_DHANLAXMI
                Else
                    OBJ = New GRNCheckingreport
                End If
            ElseIf FRMSTRING = "RETURN" Then
                OBJ = New RETURNGRNCheckingreport
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
                oDfDopt.DiskFileName = Application.StartupPath & "\" & FRMSTRING & "_" & GRNCHECKINGLOTNO & ".pdf"

                'CHECK WHETHER FILE IS PRESENT OR NOT, IF PRESENT THEN DELETE FIRST AND THEN EXPORT
                If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)
                If FRMSTRING = "RETURN" Then OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                expo = OBJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
                If FRMSTRING = "RETURN" Then OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
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

            If vendorname <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" acc_email ", "", " LEDGERS ", " and ACC_cmpname='" & vendorname & "' and ACC_cmpid=" & CmpId & " and ACC_LOCATIONid=" & Locationid & " and ACC_YEARid=" & YearId)
                If dt.Rows.Count > 0 Then
                    emailid = dt.Rows(0).Item(0).ToString
                End If
            End If

            Dim objmail As New SendMail
            If FRMSTRING = "CHECKING" Then
                tempattachment = "Checking No." & GRNCHECKINGLOTNO
                objmail.subject = "GRN Checking Report"

            ElseIf FRMSTRING = "TRANSFER" Then
                tempattachment = "Transfer No." & GRNCHECKINGNO
                objmail.subject = "Transfer Report"

            ElseIf FRMSTRING = "RETURN" Then
                tempattachment = "Do No." & GRNCHECKINGLOTNO
                objmail.subject = "Return DO"

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
            If FRMSTRING = "CHECKING" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Checking No." & GRNCHECKINGLOTNO & ".pdf"
                If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Or ClientName = "MONOGRAM" Then
                    expo = RPTGRNCHECKING_DHANLAXMI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTGRNCHECKING_DHANLAXMI.Export()
                Else
                    expo = rptGRNCHECKING.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptGRNCHECKING.Export()
                End If

            ElseIf FRMSTRING = "TRANSFER" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Transfer No." & GRNCHECKINGNO & ".pdf"
                expo = RPTTRANSFER.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTTRANSFER.Export()

            ElseIf FRMSTRING = "RETURN" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\Do No." & GRNCHECKINGLOTNO & ".pdf"
                rptreturnGRNCHECKING.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                expo = rptreturnGRNCHECKING.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptreturnGRNCHECKING.Export()
                rptreturnGRNCHECKING.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub GRNCheckingDesign_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If FRMSTRING <> "RETURN" Then Exit Sub
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE CHECKINGMASTER SET CHECK_DOPRINTED = 1 WHERE CHECK_NO = " & GRNCHECKINGNO & " AND CHECK_YEARID = " & YearId, "", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class