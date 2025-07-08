Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports BL

Public Class LoanDesign

    Dim rptloan As New LoanReport
    Dim RPTBALANCEPARTY As New LoanBalancePartyWise
    Dim RPTBALANCEITEM As New LoanBalanceItemWise

    Public selfor_po As String
    Public loanNO As Integer
    Public FRMSTRING As String
    Public PERIOD As String
    Public SHOWALL As Integer = 0

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
                .ServerName = Servername
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "LOANPARTY" Then
                crTables = RPTBALANCEPARTY.Database.Tables
            ElseIf FRMSTRING = "LOANITEM" Then
                crTables = RPTBALANCEITEM.Database.Tables
            Else
                crTables = rptloan.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            crpo.SelectionFormula = selfor_po


            If FRMSTRING = "LOANPARTY" Then
                RPTBALANCEPARTY.DataDefinition.FormulaFields("SHOWALL").Text = Val(SHOWALL)
                crpo.ReportSource = RPTBALANCEPARTY
            ElseIf FRMSTRING = "LOANITEM" Then
                RPTBALANCEITEM.DataDefinition.FormulaFields("SHOWALL").Text = Val(SHOWALL)
                crpo.ReportSource = RPTBALANCEITEM
            Else
                crpo.ReportSource = rptloan
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
            tempattachment = "Checking No." & loanNO
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
            oDfDopt.DiskFileName = Application.StartupPath & "\Checking No." & loanNO & ".pdf"
            expo = rptloan.ExportOptions
            expo.ExportDestinationType = ExportDestinationType.DiskFile
            expo.ExportFormatType = ExportFormatType.PortableDocFormat
            expo.DestinationOptions = oDfDopt
            rptloan.Export()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub LoanDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
End Class