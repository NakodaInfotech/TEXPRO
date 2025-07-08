
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Windows.Forms
Imports BL

Public Class Stocks_Approved

    Public selformula_approved As String         'For select formula
    Dim tempattachment As String        'For Mail
    Dim rptpo As New stock_PartyWise_approved
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions
    Public heading As String

    Private Sub Stocks_ApprovedForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            crTables = rptpo.Database.Tables
            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************************ END *******************

            crpo.SelectionFormula = selformula_approved
            rptpo.DataDefinition.FormulaFields("formula_heading").Text = "'" & heading & "'"
            crpo.ReportSource = rptpo
            crpo.Zoom(100)
            crpo.Refresh()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            tempattachment = "Approved_Stock_Summary"
            'SendMail
            Try
                Dim objmail As New SendMail
                objmail.attachment = tempattachment
                objmail.Show(Me)
                objmail.BringToFront()
            Catch ex As Exception
                If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
            End Try
            Windows.Forms.Cursor.Current = Cursors.Arrow
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub Transfer()
        Try
            oDfDopt.DiskFileName = Application.StartupPath & "\Approved_Stock_Summary.pdf"
            expo = rptpo.ExportOptions
            expo.ExportDestinationType = ExportDestinationType.DiskFile
            expo.ExportFormatType = ExportFormatType.PortableDocFormat
            expo.DestinationOptions = oDfDopt
            rptpo.Export()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Stocks_Approved_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
End Class