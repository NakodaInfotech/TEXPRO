
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports BL

Public Class consumedesign

    Public selfor_po As String
    Public CONSUMENO As Integer
    Public CONDITION As String
    Public PERIOD As String
    Public FRMSTRING As String
    Public FILTERCOST As Double = 0.0

    Dim rptCONSUME As New consumereport
    Dim RPTPROGCUNSUMPTIONDTLS As New ProgramWiseConsumption
    Dim RPTPROCESSCUNSUMPTIONDTLS As New ProcessWiseConsumption
    Dim RPTPROGCOSTDTLS As New DyeingProgramLotWiseCost_Dtls
    Dim RPTPROGCOSTSUMM As New DyeingProgramLotWiseCost_Summ
    Dim RPTMERCHANTCOSTDTLS As New DyeingMerchantWiseCost_Dtls
    Dim RPTMERCHANTCOSTSUMM As New DyeingMerchantWiseCost_Summ


    Dim RPTJOBCOSTDTLS As New JobWiseConsumption
    Dim RPTJOBDESIGNCOSTDTLS As New JobDesignWiseConsumption
    Dim RPTDESIGNPROCESSCUNSUMPTIONDTLS As New DesignProcessWiseConsumption


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

            If FRMSTRING = "PROGCUNSUMPTIONDTLS" Then
                crTables = RPTPROGCUNSUMPTIONDTLS.Database.Tables
            ElseIf FRMSTRING = "PROCESSCUNSUMPTIONDTLS" Then
                crTables = RPTPROCESSCUNSUMPTIONDTLS.Database.Tables
            ElseIf FRMSTRING = "PROGCOSTDTLS" Then
                crTables = RPTPROGCOSTDTLS.Database.Tables
            ElseIf FRMSTRING = "PROGCOSTSUMM" Then
                crTables = RPTPROGCOSTSUMM.Database.Tables
            ElseIf FRMSTRING = "MERCHANTCOSTDTLS" Then
                crTables = RPTMERCHANTCOSTDTLS.Database.Tables
            ElseIf FRMSTRING = "MERCHANTCOSTSUMM" Then
                crTables = RPTMERCHANTCOSTSUMM.Database.Tables

            ElseIf FRMSTRING = "JOBCOSTDTLS" Then
                crTables = RPTJOBCOSTDTLS.Database.Tables
            ElseIf FRMSTRING = "JOBDESIGNCOSTDTLS" Then
                crTables = RPTJOBDESIGNCOSTDTLS.Database.Tables
            ElseIf FRMSTRING = "DESIGNPROCESSCUNSUMPTIONDTLS" Then
                crTables = RPTDESIGNPROCESSCUNSUMPTIONDTLS.Database.Tables
            Else
                crTables = rptCONSUME.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = CONDITION
            If FRMSTRING = "PROGCUNSUMPTIONDTLS" Then
                crTables = RPTPROGCUNSUMPTIONDTLS.Database.Tables
                crpo.ReportSource = RPTPROGCUNSUMPTIONDTLS
                RPTPROGCUNSUMPTIONDTLS.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PROCESSCUNSUMPTIONDTLS" Then
                crTables = RPTPROCESSCUNSUMPTIONDTLS.Database.Tables
                crpo.ReportSource = RPTPROCESSCUNSUMPTIONDTLS
                RPTPROCESSCUNSUMPTIONDTLS.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PROGCOSTDTLS" Then
                crTables = RPTPROGCOSTDTLS.Database.Tables
                crpo.ReportSource = RPTPROGCOSTDTLS
                RPTPROGCOSTDTLS.DataDefinition.FormulaFields("FILTERCOST").Text = Val(FILTERCOST)
                RPTPROGCOSTDTLS.DataDefinition.FormulaFields("CLIENTNAME").Text = "'" & ClientName & "'"
                RPTPROGCOSTDTLS.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "PROGCOSTSUMM" Then
                crTables = RPTPROGCOSTSUMM.Database.Tables
                crpo.ReportSource = RPTPROGCOSTSUMM
                RPTPROGCOSTSUMM.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
                RPTPROGCOSTSUMM.DataDefinition.FormulaFields("CLIENTNAME").Text = "'" & ClientName & "'"
            ElseIf FRMSTRING = "MERCHANTCOSTDTLS" Then
                crTables = RPTMERCHANTCOSTDTLS.Database.Tables
                crpo.ReportSource = RPTMERCHANTCOSTDTLS
                RPTMERCHANTCOSTDTLS.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "MERCHANTCOSTSUMM" Then
                crTables = RPTMERCHANTCOSTSUMM.Database.Tables
                crpo.ReportSource = RPTMERCHANTCOSTSUMM
                RPTMERCHANTCOSTSUMM.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"

            ElseIf FRMSTRING = "JOBCOSTDTLS" Then
                crTables = RPTJOBCOSTDTLS.Database.Tables
                crpo.ReportSource = RPTJOBCOSTDTLS
                RPTJOBCOSTDTLS.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "JOBDESIGNCOSTDTLS" Then
                crTables = RPTJOBDESIGNCOSTDTLS.Database.Tables
                crpo.ReportSource = RPTJOBDESIGNCOSTDTLS
                RPTJOBDESIGNCOSTDTLS.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "DESIGNPROCESSCUNSUMPTIONDTLS" Then
                crTables = RPTDESIGNPROCESSCUNSUMPTIONDTLS.Database.Tables
                crpo.ReportSource = RPTDESIGNPROCESSCUNSUMPTIONDTLS
                RPTDESIGNPROCESSCUNSUMPTIONDTLS.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
            Else
                crpo.ReportSource = rptCONSUME
            End If

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
            tempattachment = "Checking No." & CONSUMENO
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
            oDfDopt.DiskFileName = Application.StartupPath & "\Checking No." & CONSUMENO & ".pdf"
            expo = rptCONSUME.ExportOptions
            expo.ExportDestinationType = ExportDestinationType.DiskFile
            expo.ExportFormatType = ExportFormatType.PortableDocFormat
            expo.DestinationOptions = oDfDopt
            rptCONSUME.Export()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub consumedesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
End Class