
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class SaleOrderDesign

    Public FORMULA As String = ""
    Public PARTYNAME As String = ""
    Public AGENTNAME As String = ""
    Public SHIPTONAME As String = ""
    Public FRMSTRING As String = ""
    Public SONO As Integer = 0

    Dim RPTSO As New SaleOrderReport
    Dim TEMPATTACHMENT As String

    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions


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

            If FRMSTRING = "SOREPORT" Then
                crTables = RPTSO.Database.Tables
            End If
            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = FORMULA

            If FRMSTRING = "SOREPORT" Then
                crpo.ReportSource = RPTSO
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
            Transfer()
            TEMPATTACHMENT = "saleOrder"
            If PARTYNAME <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" acc_email AS EMAILID ", "", " LEDGERS ", " and ACC_cmpname='" & PARTYNAME & "' and ACC_YEARid=" & YearId)
                If dt.Rows.Count > 0 Then emailid = dt.Rows(0).Item("EMAILID").ToString
            End If

            Dim objmail As New SendMail
            objmail.attachment = TEMPATTACHMENT
            If emailid <> "" Then objmail.cmbfirstadd.Text = emailid
            objmail.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub Transfer()
        Try
            oDfDopt.DiskFileName = Application.StartupPath & "\SALOERDER.pdf"
            If FRMSTRING = "SOREPORT" Then
                expo = RPTSO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTSO.Export()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub SaleOrderDesign_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
End Class