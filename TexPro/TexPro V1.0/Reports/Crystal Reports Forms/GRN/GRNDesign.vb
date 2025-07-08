
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports System.IO

Public Class GRNDesign

    Public selfor_GRN As String
    Public FRMSTRING As String

    Dim RPTGRN As New GRNReport
    Dim RPTGRNINSTRUCTION As New GRNInstructionReport
    Dim RPTGRNWTREPORT As New GRNGreyWtReport


    Dim rptquot As New PurchaseQuotReport
    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions
    Public vendorname As String


    Public GRNNO As Integer
    Public GRNTYPE As String
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing


    Private Sub GRNDesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

            If FRMSTRING = "GRN" Then
                crTables = RPTGRN.Database.Tables
            ElseIf FRMSTRING = "GRNINS" Then
                crTables = RPTGRNINSTRUCTION.Database.Tables
            ElseIf FRMSTRING = "GRNWTREPORT" Then
                crTables = RPTGRNWTREPORT.Database.Tables
            Else
                crTables = rptquot.Database.Tables
            End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = selfor_GRN
            If FRMSTRING = "GRN" Then
                crpo.ReportSource = RPTGRN
            ElseIf FRMSTRING = "GRNINS" Then
                crpo.ReportSource = RPTGRNINSTRUCTION
            ElseIf FRMSTRING = "GRNWTREPORT" Then
                crpo.ReportSource = RPTGRNWTREPORT
            Else
                crpo.ReportSource = rptquot
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

            strsearch = "  {GRN.GRN_NO}= " & GRNNO & " AND {GRN.GRN_TYPE} = '" & GRNTYPE & "' and {GRN.GRN_YEARID} = " & YearId

            Dim OBJ As New Object
            If FRMSTRING = "GRN" Then
                OBJ = New GRNReport
            ElseIf FRMSTRING = "GRNINS" Then
                OBJ = New GRNInstructionReport
            ElseIf FRMSTRING = "GRNWTREPORT" Then
                OBJ = New GRNGreyWtReport
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
                oDfDopt.DiskFileName = Application.StartupPath & "\GRN_" & GRNNO & ".pdf"

                'CHECK WHETHER FILE IS PRESENT OR NOT, IF PRESENT THEN DELETE FIRST AND THEN EXPORT
                If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)
                If FRMSTRING = "GRN" Then OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                expo = OBJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
                If FRMSTRING = "GRN" Then OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
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
            If FRMSTRING = "GRN" Or FRMSTRING = "GRNINS" Then
                tempattachment = "GRN No." & GRNNO
            Else
                tempattachment = "Quot No." & GRNNO
            End If
            If vendorname <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" acc_email ", "", " LEDGERS ", " and ACC_cmpname='" & vendorname & "' and ACC_cmpid=" & CmpId & " and ACC_LOCATIONid=" & Locationid & " and ACC_YEARid=" & YearId)
                If dt.Rows.Count > 0 Then
                    emailid = dt.Rows(0).Item(0).ToString
                End If
            End If

            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".pdf"
            objmail.subject = "GRN Report"
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
            oDfDopt.DiskFileName = Application.StartupPath & "\GRN No." & GRNNO & ".pdf"
            If FRMSTRING = "GRN" Then
                expo = RPTGRN.ExportOptions
                RPTGRN.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
            ElseIf FRMSTRING = "GRNINS" Then
                expo = RPTGRNINSTRUCTION.ExportOptions
            ElseIf FRMSTRING = "GRNWTREPORT" Then
                expo = RPTGRNWTREPORT.ExportOptions
            Else
                oDfDopt.DiskFileName = Application.StartupPath & "\Quot No." & GRNNO & ".pdf"
                expo = rptquot.ExportOptions
            End If
            expo.ExportDestinationType = ExportDestinationType.DiskFile
            expo.ExportFormatType = ExportFormatType.PortableDocFormat
            expo.DestinationOptions = oDfDopt
            If FRMSTRING = "GRN" Then
                RPTGRN.Export()
                RPTGRN.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
            ElseIf FRMSTRING = "GRNINS" Then
                RPTGRNINSTRUCTION.Export()
            ElseIf FRMSTRING = "GRNWTREPORT" Then
                RPTGRNWTREPORT.Export()
            Else
                rptquot.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class