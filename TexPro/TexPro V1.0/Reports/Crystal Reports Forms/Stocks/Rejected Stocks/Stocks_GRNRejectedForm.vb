
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Windows.Forms
Imports BL

Public Class Stocks_GRNRejectedForm

    Public selformula_onapporve As String     'For select formula
    Dim tempattachment As String        'For Mail
    Dim rptpo As New Stock_Rejected_GrnWise
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions

    Private Sub sendmailtool_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            tempattachment = "On_Approval_Stock_GRNWise"
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
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Sub Transfer()
        Try
            oDfDopt.DiskFileName = Application.StartupPath & "\On_Approval_Stock_GRNWise.pdf"
            expo = rptpo.ExportOptions
            expo.ExportDestinationType = ExportDestinationType.DiskFile
            expo.ExportFormatType = ExportFormatType.PortableDocFormat
            expo.DestinationOptions = oDfDopt
            rptpo.Export()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub Stocks_GRNRejectedForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Stocks_GRNRejectedForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
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

            crpo.SelectionFormula = selformula_onapporve
            crpo.ReportSource = rptpo
            crpo.Zoom(100)
            crpo.Refresh()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class