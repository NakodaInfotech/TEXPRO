Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms

Public Class GRNDETAILDESIGN

    Public selfor_GRN As String
    Public FRMSTRING As String = ""
    Public PERIOD As String = ""
    Public SHOWOURQUALITY As Boolean = False

    Dim rptGRN As New GRNDETAILREPORT



    Dim RPTGREYPO As New GREYSTOCKWITHPOREPORT
    Dim RPTGREYPODTLS As New GREYSTOCKWITHPODETAILSREPORT

    Dim rptCHK As New GREYCHKREPORT
    Dim RPTCHKLEDGER As New GREYCHKLEDGERNAMEREPORT
    Dim RPTCHKVALUE As New GREYCHKREPORTVALUE

    Dim rptCHKsumm As New GREYCHKSUMMARYREPORT
    Dim RPTCHKSUMMVALUE As New GREYCHKSUMMARYREPORTVALUE

    Dim rptUNCHK As New GREYUNCHKREPORT
    Dim RPTUNCHKVALUE As New GREYUNCHKREPORTVALUE

    Dim rptUNCHKsumm As New GREYUNCHKSUMMARYREPORT
    Dim RPTUNCHKSUMMVALUE As New GREYUNCHKSUMMARYREPORTVALUE

    Dim rptM As New GREYMONTHLYTREPORT
    Dim rptPM As New GREYMONTHLYPARTYTREPORT
    Dim RptChkGrn As New CHECKINGALLGRN
    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions
    Public vendorname As String

    Private Sub GRNDETAILDESIGN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                .ServerName = Servername
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With
            If FRMSTRING = "" Then
                crTables = rptGRN.Database.Tables
            ElseIf FRMSTRING = "GREYCHK" Then
                If ClientName = "TULSI" Then
                    crTables = rptCHK.Database.Tables
                Else
                    crTables = RPTCHKLEDGER.Database.Tables
                End If

            ElseIf FRMSTRING = "GREYCHKVALUE" Then
                crTables = RPTCHKVALUE.Database.Tables
            ElseIf FRMSTRING = "GREYCHKSUMMARY" Then
                crTables = rptCHKsumm.Database.Tables
            ElseIf FRMSTRING = "GREYCHKSUMMARYVALUE" Then
                crTables = RPTCHKSUMMVALUE.Database.Tables
            ElseIf FRMSTRING = "GREYUNCHK" Then
                crTables = rptUNCHK.Database.Tables
            ElseIf FRMSTRING = "GREYUNCHKVALUE" Then
                crTables = RPTUNCHKVALUE.Database.Tables
            ElseIf FRMSTRING = "GREYUNCHKSUMMARY" Then
                crTables = rptUNCHKsumm.Database.Tables
            ElseIf FRMSTRING = "GREYUNCHKSUMMARYVALUE" Then
                crTables = RPTUNCHKSUMMVALUE.Database.Tables
            ElseIf FRMSTRING = "MONTHLY" Then
                crTables = rptM.Database.Tables
            ElseIf FRMSTRING = "CHECKINGALLGRN" Then
                crTables = RptChkGrn.Database.Tables
            ElseIf FRMSTRING = "PARTYMONTHLY" Then
                crTables = rptPM.Database.Tables
            ElseIf FRMSTRING = "GREYSTOCKWITHPO" Then
                crTables = RPTGREYPO.Database.Tables
            ElseIf FRMSTRING = "GREYSTOCKWITHPODETAILS" Then
                crTables = RPTGREYPODTLS.Database.Tables
            End If
            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = selfor_GRN

            If FRMSTRING = "" Then
                crpo.ReportSource = rptGRN

            ElseIf FRMSTRING = "GREYCHK" Then
                If ClientName = "TULSI" Then
                    crpo.ReportSource = rptCHK
                    rptCHK.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                    If SHOWOURQUALITY = True Then rptCHK.DataDefinition.FormulaFields("SHOWOURQUALITY").Text = "1"
                Else
                    crpo.ReportSource = RPTCHKLEDGER
                    RPTCHKLEDGER.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                End If

            ElseIf FRMSTRING = "GREYCHKVALUE" Then
                crpo.ReportSource = RPTCHKVALUE
                RPTCHKVALUE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWOURQUALITY = True Then RPTCHKVALUE.DataDefinition.FormulaFields("SHOWOURQUALITY").Text = "1"

            ElseIf FRMSTRING = "GREYCHKSUMMARY" Then
                crpo.ReportSource = rptCHKsumm
                rptCHKsumm.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWOURQUALITY = True Then rptCHKsumm.DataDefinition.FormulaFields("SHOWOURQUALITY").Text = "1"

            ElseIf FRMSTRING = "GREYCHKSUMMARYVALUE" Then
                crpo.ReportSource = RPTCHKSUMMVALUE
                RPTCHKSUMMVALUE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If SHOWOURQUALITY = True Then RPTCHKSUMMVALUE.DataDefinition.FormulaFields("SHOWOURQUALITY").Text = "1"

            ElseIf FRMSTRING = "GREYUNCHK" Then
                rptUNCHK.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = rptUNCHK
                If SHOWOURQUALITY = True Then rptUNCHK.DataDefinition.FormulaFields("SHOWOURQUALITY").Text = "1"

            ElseIf FRMSTRING = "GREYUNCHKVALUE" Then
                RPTUNCHKVALUE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTUNCHKVALUE
                If SHOWOURQUALITY = True Then RPTUNCHKVALUE.DataDefinition.FormulaFields("SHOWOURQUALITY").Text = "1"

            ElseIf FRMSTRING = "GREYUNCHKSUMMARY" Then
                rptUNCHKsumm.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = rptUNCHKsumm
                If SHOWOURQUALITY = True Then rptUNCHKsumm.DataDefinition.FormulaFields("SHOWOURQUALITY").Text = "1"

            ElseIf FRMSTRING = "GREYUNCHKSUMMARYVALUE" Then
                RPTUNCHKSUMMVALUE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTUNCHKSUMMVALUE
                If SHOWOURQUALITY = True Then RPTUNCHKSUMMVALUE.DataDefinition.FormulaFields("SHOWOURQUALITY").Text = "1"

            ElseIf FRMSTRING = "MONTHLY" Then
                rptM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = rptM

            ElseIf FRMSTRING = "CHECKINGALLGRN" Then
                RptChkGrn.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RptChkGrn

            ElseIf FRMSTRING = "PARTYMONTHLY" Then
                rptPM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = rptPM

            ElseIf FRMSTRING = "GREYSTOCKWITHPO" Then
                RPTGREYPO.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTGREYPO

            ElseIf FRMSTRING = "GREYSTOCKWITHPODETAILS" Then
                RPTGREYPODTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTGREYPODTLS

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
            tempattachment = "GRN"
            If vendorname <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" acc_email ", "", " LEDGERS ", " and ACC_cmpname='" & vendorname & "' and ACC_cmpid=" & CmpId & " and ACC_LOCATIONid=" & Locationid & " and ACC_YEARid=" & YearId)
                If dt.Rows.Count > 0 Then
                    emailid = dt.Rows(0).Item(0).ToString
                End If
            End If

            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".pdf"
            objmail.subject = "Grey Stock Report"
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
            oDfDopt.DiskFileName = Application.StartupPath & "\GRN.pdf"
            If FRMSTRING = "" Then
                expo = rptGRN.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptGRN.Export()

            ElseIf FRMSTRING = "GREYCHK" Then
                If ClientName = "TULSI" Then
                    expo = rptCHK.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    rptCHK.Export()
                Else
                    expo = RPTCHKLEDGER.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTCHKLEDGER.Export()
                End If
            ElseIf FRMSTRING = "GREYCHKVALUE" Then
                expo = RPTCHKVALUE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCHKVALUE.Export()

            ElseIf FRMSTRING = "GREYCHKSUMMARY" Then
                expo = rptCHKsumm.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptCHKsumm.Export()

            ElseIf FRMSTRING = "GREYCHKSUMMARYVALUE" Then
                expo = RPTCHKSUMMVALUE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCHKSUMMVALUE.Export()

            ElseIf FRMSTRING = "GREYUNCHK" Then
                expo = rptUNCHK.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptUNCHK.Export()

            ElseIf FRMSTRING = "GREYUNCHKVALUE" Then
                expo = RPTUNCHKVALUE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTUNCHKVALUE.Export()

            ElseIf FRMSTRING = "GREYUNCHKSUMMARY" Then
                expo = rptUNCHKsumm.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptUNCHKsumm.Export()

            ElseIf FRMSTRING = "GREYUNCHKSUMMARYVALUE" Then
                expo = RPTUNCHKSUMMVALUE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTUNCHKSUMMVALUE.Export()

            ElseIf FRMSTRING = "MONTHLY" Then
                expo = rptM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptM.Export()

            ElseIf FRMSTRING = "CHECKINGALLGRN" Then
                expo = RptChkGrn.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RptChkGrn.Export()

            ElseIf FRMSTRING = "PARTYMONTHLY" Then
                expo = rptPM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                rptPM.Export()

            ElseIf FRMSTRING = "GREYSTOCKWITHPO" Then
                expo = RPTGREYPO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGREYPO.Export()

            ElseIf FRMSTRING = "GREYSTOCKWITHPODETAILS" Then
                expo = RPTGREYPODTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTGREYPODTLS.Export()

            End If
          
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class