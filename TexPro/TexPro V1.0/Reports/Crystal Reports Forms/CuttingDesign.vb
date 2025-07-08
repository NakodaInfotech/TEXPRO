
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports BL

Public Class CuttingDesign

    Public CONDITION As String
    Public PERIOD As String
    Public FRMSTRING As String

    Dim RPTCUTTINGDTLS As New CuttingStockDetails
    Dim RPTCUTTINGDTLSVALUE As New CuttingStockDetailsValue
   
    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions

    Private Sub CuttingDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            If FRMSTRING = "CUTTINGDTLS" Then
                crTables = RPTCUTTINGDTLS.Database.Tables
            ElseIf FRMSTRING = "CUTTINGDTLSVALUE" Then
                crTables = RPTCUTTINGDTLSVALUE.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            crpo.SelectionFormula = CONDITION

            If FRMSTRING = "CUTTINGDTLS" Then
                crpo.ReportSource = RPTCUTTINGDTLS
                RPTCUTTINGDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
            ElseIf FRMSTRING = "CUTTINGDTLSVALUE" Then
                crpo.ReportSource = RPTCUTTINGDTLSVALUE
                RPTCUTTINGDTLSVALUE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
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
            tempattachment = "CuttingStock"
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
            oDfDopt.DiskFileName = Application.StartupPath & "\CuttingStock.pdf"
            If FRMSTRING = "CUTTINGDTLS" Then
                expo = RPTCUTTINGDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCUTTINGDTLS.Export()
            ElseIf FRMSTRING = "CUTTINGDTLSVALUE" Then
                expo = RPTCUTTINGDTLSVALUE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCUTTINGDTLSVALUE.Export()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class