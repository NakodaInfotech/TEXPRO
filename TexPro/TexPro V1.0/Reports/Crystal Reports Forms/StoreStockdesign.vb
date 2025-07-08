
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports BL

Public Class StoreStockdesign

    Public selfor_ss As String
    Public PERIOD As String
    Public FRMSTRING As String
    Public FROMDATE As String = ""
    Public TODATE As String = ""
    Public OPENINGDATE As String
    Public CONSUMESUMM As Integer = 0

    Dim rptstore As New storestockreport
    Dim RPTDEPARTMENTDTLS As New DepartmentWiseDetailReport
    Dim RPTDEPARTMENTSUMM As New DepartmentWiseSummary
    Dim RPTDEPARTMENTDTLSPURRATE As New DepartmentWiseDetailsReport_PurRate
    Dim RPTDEPARTMENTSUMMPURRATE As New DepartmentWiseSummary_PurRate
    Dim RPTDEPARTMENTCONSUME As New DepartmentWiseConsumeReport

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

            If FRMSTRING = "DEPARTMENTDETAIL" Then
                crTables = RPTDEPARTMENTDTLS.Database.Tables
            ElseIf FRMSTRING = "DEPARTMENTSUMMARY" Then
                crTables = RPTDEPARTMENTSUMM.Database.Tables
            ElseIf FRMSTRING = "DEPARTMENTDETAILPURRATE" Then
                crTables = RPTDEPARTMENTDTLSPURRATE.Database.Tables
            ElseIf FRMSTRING = "DEPARTMENTSUMMPURRATE" Then
                crTables = RPTDEPARTMENTSUMMPURRATE.Database.Tables
            ElseIf FRMSTRING = "DETAILS" Then
                crTables = rptstore.Database.Tables
            ElseIf FRMSTRING = "DEPARTMENTCONSUME" Then
                crTables = RPTDEPARTMENTCONSUME.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            If FRMSTRING = "DEPARTMENTDETAIL" Then
                RPTDEPARTMENTDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If FROMDATE <> "" Then
                    RPTDEPARTMENTDTLS.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                    RPTDEPARTMENTDTLS.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                Else
                    RPTDEPARTMENTDTLS.DataDefinition.FormulaFields("FROMDATE").Text = "''"
                    RPTDEPARTMENTDTLS.DataDefinition.FormulaFields("TODATE").Text = "''"
                End If

                crpo.SelectionFormula = selfor_ss
                crpo.ReportSource = RPTDEPARTMENTDTLS

            ElseIf FRMSTRING = "DEPARTMENTSUMMARY" Then
                RPTDEPARTMENTSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If FROMDATE <> "" Then
                    RPTDEPARTMENTSUMM.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                    RPTDEPARTMENTSUMM.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                Else
                    RPTDEPARTMENTSUMM.DataDefinition.FormulaFields("FROMDATE").Text = "''"
                    RPTDEPARTMENTSUMM.DataDefinition.FormulaFields("TODATE").Text = "''"
                End If

                crpo.SelectionFormula = selfor_ss
                crpo.ReportSource = RPTDEPARTMENTSUMM

            ElseIf FRMSTRING = "DEPARTMENTDETAILPURRATE" Then
                RPTDEPARTMENTDTLSPURRATE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If FROMDATE <> "" Then
                    RPTDEPARTMENTDTLSPURRATE.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                    RPTDEPARTMENTDTLSPURRATE.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                Else
                    RPTDEPARTMENTDTLSPURRATE.DataDefinition.FormulaFields("FROMDATE").Text = "''"
                    RPTDEPARTMENTDTLSPURRATE.DataDefinition.FormulaFields("TODATE").Text = "''"
                End If

                crpo.SelectionFormula = selfor_ss
                crpo.ReportSource = RPTDEPARTMENTDTLSPURRATE

            ElseIf FRMSTRING = "DEPARTMENTSUMMPURRATE" Then
                RPTDEPARTMENTSUMMPURRATE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                If FROMDATE <> "" Then
                    RPTDEPARTMENTSUMMPURRATE.DataDefinition.FormulaFields("FROMDATE").Text = "'" & Format(Convert.ToDateTime(FROMDATE).Date, "MM/dd/yyyy") & "'"
                    RPTDEPARTMENTSUMMPURRATE.DataDefinition.FormulaFields("TODATE").Text = "'" & Format(Convert.ToDateTime(TODATE).Date, "MM/dd/yyyy") & "'"
                Else
                    RPTDEPARTMENTSUMMPURRATE.DataDefinition.FormulaFields("FROMDATE").Text = "''"
                    RPTDEPARTMENTSUMMPURRATE.DataDefinition.FormulaFields("TODATE").Text = "''"
                End If

                crpo.SelectionFormula = selfor_ss
                crpo.ReportSource = RPTDEPARTMENTSUMMPURRATE

            ElseIf FRMSTRING = "DETAILS" Then
                rptstore.DataDefinition.FormulaFields("period").Text = "'" & PERIOD & "'"
                rptstore.DataDefinition.FormulaFields("OPENINGDATE").Text = "#" & OPENINGDATE & "#"
                rptstore.DataDefinition.FormulaFields("FROMDATE").Text = "#" & FROMDATE & "#"
                rptstore.DataDefinition.FormulaFields("TODATE").Text = "#" & TODATE & "#"

                crpo.SelectionFormula = selfor_ss
                crpo.ReportSource = rptstore

            ElseIf FRMSTRING = "DEPARTMENTCONSUME" Then
                RPTDEPARTMENTCONSUME.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTDEPARTMENTCONSUME.DataDefinition.FormulaFields("SUMMARY").Text = Val(CONSUMESUMM)
                crpo.SelectionFormula = selfor_ss
                crpo.ReportSource = RPTDEPARTMENTCONSUME
            End If


            '************************ END *******************

            crpo.Zoom(85)
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
            tempattachment = "STORE STOCK " & PERIOD
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
            oDfDopt.DiskFileName = Application.StartupPath & "\STORE STOCK " & PERIOD & ".pdf"
            If FRMSTRING = "DEPARTMENTDETAIL" Then
                expo = RPTDEPARTMENTDTLS.ExportOptions
            ElseIf FRMSTRING = "DEPARTMENTSUMMARY" Then
                expo = RPTDEPARTMENTSUMM.ExportOptions
            ElseIf FRMSTRING = "DEPARTMENTDETAILPURRATE" Then
                expo = RPTDEPARTMENTDTLSPURRATE.ExportOptions
            ElseIf FRMSTRING = "DEPARTMENTSUMMPURRATE" Then
                expo = RPTDEPARTMENTSUMMPURRATE.ExportOptions
            ElseIf FRMSTRING = "DETAILS" Then
                expo = rptstore.ExportOptions
            ElseIf FRMSTRING = "DEPARTMENTCONSUME" Then
                expo = RPTDEPARTMENTCONSUME.ExportOptions
            End If

            expo.ExportDestinationType = ExportDestinationType.DiskFile
            expo.ExportFormatType = ExportFormatType.PortableDocFormat
            expo.DestinationOptions = oDfDopt

            If FRMSTRING = "DEPARTMENTDETAIL" Then
                RPTDEPARTMENTDTLS.Export()
            ElseIf FRMSTRING = "DEPARTMENTSUMMARY" Then
                RPTDEPARTMENTSUMM.Export()
            ElseIf FRMSTRING = "DEPARTMENTDETAILPURRATE" Then
                RPTDEPARTMENTDTLSPURRATE.Export()
            ElseIf FRMSTRING = "DEPARTMENTSUMMPURRATE" Then
                RPTDEPARTMENTSUMMPURRATE.Export()
            ElseIf FRMSTRING = "DETAILS" Then
                rptstore.Export()
            ElseIf FRMSTRING = "DEPARTMENTCONSUME" Then
                RPTDEPARTMENTCONSUME.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub StoreStockdesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
End Class