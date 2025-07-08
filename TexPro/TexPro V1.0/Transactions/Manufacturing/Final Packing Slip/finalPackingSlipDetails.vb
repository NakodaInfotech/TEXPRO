
Imports BL
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid

Public Class finalPackingSlipDetails
    Public edit As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GRNDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            ElseIf e.KeyCode = Keys.O And e.Alt = True Then
                cmdok_Click(sender, e)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRNDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PACKING SLIP'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            CHKHEADER.CheckState = CheckState.Checked

            fillgrid(" and dbo.FINALPACKINGSLIP.FPS_CMPID=" & CmpId & " and dbo.FINALPACKINGSLIP.FPS_yearid=" & YearId & " GROUP BY FINALPACKINGSLIP.FPS_NO, FINALPACKINGSLIP.FPS_DATE, FINALPACKINGSLIP.FPS_FBNO, LEDGERS.Acc_cmpname, PROCESSMASTER.PROCESS_NAME, ITEMMASTER_1.item_name, DYEINGRECIPE.DYEING_NO, FINALPACKINGSLIP.FPS_JOBNO, FINALPACKINGSLIP.FPS_ORDERNO, FINALPACKINGSLIP.FPS_PROGNO, FINALPACKINGSLIP_DESC.FPS_LOTNO, ISNULL(FINALPACKINGSLIP.FPS_EXPENSEREPORT,0), ISNULL(DYEINGRECIPE.DYEING_IMGPATH,''), ISNULL(DYEINGRECIPE.DYEING_OURLOCATION,''), ISNULL(PROCESSTYPEMASTER.PROCESSTYPE_NAME,''), ISNULL(FINALPACKINGSLIP.FPS_PACKEDBY,'') order by dbo.FINALPACKINGSLIP.FPS_no ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search("    FINALPACKINGSLIP.FPS_NO AS SRNO, FINALPACKINGSLIP.FPS_DATE AS DATE, FINALPACKINGSLIP.FPS_FBNO AS FBNO, LEDGERS.Acc_cmpname AS NAME, PROCESSMASTER.PROCESS_NAME AS PROCESS, ITEMMASTER_1.item_name AS MERCHANT, DYEINGRECIPE.DYEING_NO AS DYEINGNO, FINALPACKINGSLIP.FPS_JOBNO AS JOBNO, FINALPACKINGSLIP.FPS_ORDERNO AS ORDERNO, FINALPACKINGSLIP.FPS_PROGNO AS PROGNO, FINALPACKINGSLIP_DESC.FPS_LOTNO AS LOTNO, SUM(FINALPACKINGSLIP_DESC.FPS_TOTAL) AS PCS, SUM(FINALPACKINGSLIP_DESC.FPS_MTRS) AS MTRS, ISNULL(FINALPACKINGSLIP.FPS_EXPENSEREPORT,0) AS EXPENSEREPORT, ISNULL(DYEINGRECIPE.DYEING_IMGPATH,'') AS IMGPATH, ISNULL(DYEINGRECIPE.DYEING_OURLOCATION,'') AS OURLOCATION, ISNULL(PROCESSTYPEMASTER.PROCESSTYPE_NAME,'') AS PROCESSTYPE, ISNULL(FINALPACKINGSLIP.FPS_PACKEDBY,'') AS PACKEDBY ", "", " FINALPACKINGSLIP INNER JOIN PROCESSMASTER ON FINALPACKINGSLIP.FPS_PROCESSID = PROCESSMASTER.PROCESS_ID INNER JOIN FINALPACKINGSLIP_DESC ON FINALPACKINGSLIP.FPS_NO = FINALPACKINGSLIP_DESC.FPS_NO AND FINALPACKINGSLIP.FPS_YEARID = FINALPACKINGSLIP_DESC.FPS_YEARID LEFT OUTER JOIN DYEINGRECIPE ON FINALPACKINGSLIP.FPS_DYEINGID = DYEINGRECIPE.DYEING_ID LEFT OUTER JOIN ITEMMASTER AS ITEMMASTER_1 ON FINALPACKINGSLIP.FPS_MERCHANTID = ITEMMASTER_1.item_id LEFT OUTER JOIN LEDGERS ON FINALPACKINGSLIP.FPS_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN PROCESSTYPEMASTER ON FINALPACKINGSLIP.FPS_PROCESSTYPEID = PROCESSTYPEMASTER.PROCESSTYPE_ID", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal FPSNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objCHECKINGMASTER As New finalPackingslip
                objCHECKINGMASTER.MdiParent = MDIMain
                objCHECKINGMASTER.edit = editval
                objCHECKINGMASTER.tempfpsno = FPSNO
                objCHECKINGMASTER.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gridbill.CellValueChanged
        If IsDBNull(e.Value) = True Then Exit Sub
        Dim ROW As DataRow = gridbill.GetFocusedDataRow
        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable
        On Error Resume Next
        If ROW("EXPENSEREPORT") = True Then
            DT = OBJCMN.Execute_Any_String("UPDATE FINALPACKINGSLIP SET FPS_EXPENSEREPORT = 1 WHERE FPS_NO = " & ROW("SRNO") & " AND FPS_YEARID = " & YearId, "", "")
        Else
            DT = OBJCMN.Execute_Any_String("UPDATE FINALPACKINGSLIP SET FPS_EXPENSEREPORT = 0 WHERE FPS_NO = " & ROW("SRNO") & " AND FPS_YEARID = " & YearId, "", "")
        End If
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("SRNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If ClientName = "TULSI" Or ClientName = "SHREENATH" Or ClientName = "MONOGRAM" Then
                If Val(txtfrom.Text) > 0 And Val(txtto.Text) > 0 Then
                    Dim tempmsg As Integer = MsgBox("Wish To Print? Bale From " & txtfrom.Text & " To " & txtto.Text, MsgBoxStyle.YesNo)
                    If tempmsg = vbYes Then
                        serverprop()
                    End If
                End If

            Else
                If (Val(txtfrom.Text.Trim) = 0 Or Val(txtto.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub


                'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
                If Val(txtfrom.Text.Trim) > 0 And Val(txtto.Text.Trim) > 0 Then
                    If Val(txtfrom.Text.Trim) > Val(txtto.Text.Trim) Then
                        MsgBox("Enter Proper Packing Nos", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If MsgBox("Wish to Print Packing from " & txtfrom.Text.Trim & " To " & txtto.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                        SERVERPROPDIRECT()
                    End If
                Else
                    If MsgBox("Wish to Print Selected Packing ?", MsgBoxStyle.YesNo) = vbYes Then
                        SERVERPROPSELECTED()
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPDIRECT(Optional ByVal INVOICEMAIL As Boolean = False)
        Try
            Dim ALATTACHMENT As New ArrayList
            If INVOICEMAIL = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
            For I As Integer = Val(txtfrom.Text.Trim) To Val(txtto.Text.Trim)
                Dim OBJGRN As New FPSDESIGN
                OBJGRN.MdiParent = MDIMain
                OBJGRN.DIRECTPRINT = True
                OBJGRN.FRMSTRING = "FPS"
                OBJGRN.DIRECTMAIL = INVOICEMAIL
                OBJGRN.HEADER = CHKHEADER.Checked
                OBJGRN.PRINTSETTING = PRINTDIALOG
                OBJGRN.fspno = Val(I)
                OBJGRN.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJGRN.Show()
                OBJGRN.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\FPS_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "FPS"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False)
        Try

            Dim ALATTACHMENT As New ArrayList

            If INVOICEMAIL = False Then If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                Dim OBJGRN As New FPSDESIGN
                OBJGRN.MdiParent = MDIMain
                OBJGRN.DIRECTPRINT = True
                OBJGRN.FRMSTRING = "FPS"
                OBJGRN.DIRECTMAIL = INVOICEMAIL
                OBJGRN.PRINTSETTING = PRINTDIALOG
                OBJGRN.HEADER = CHKHEADER.Checked
                OBJGRN.fspno = Val(ROW("SRNO"))
                OBJGRN.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJGRN.Show()
                OBJGRN.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\FPS_" & Val(ROW("SRNO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "FPS"
                OBJMAIL.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub serverprop()
        For I As Integer = 0 To (txtto.Text - txtfrom.Text)

            Dim OBJ As New Object

            If ClientName = "MONOGRAM" Then
                OBJ = New FINALPACKINGSLIP_MONOGRAM
            ElseIf ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                OBJ = New FINALPACKINGSLIP_DHANLAXMI
            Else
                OBJ = New Fpsreport_RND
            End If

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

            crTables = OBJ.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            'If GRIDFPS.Rows(0).Cells(gpiecetype.Index).Value = "GOOD CUT" Then
            '    rptfsp.GroupHeaderSection7.SectionFormat.EnableSuppress = True
            '    rptfsp.GroupHeaderSection10.SectionFormat.EnableSuppress = False
            '    rptfsp.GroupHeaderSection8.SectionFormat.EnableSuppress = True
            '    rptfsp.GroupHeaderSection9.SectionFormat.EnableSuppress = False
            '    rptfsp.GroupFooterSection3.SectionFormat.EnableSuppress = True
            '    rptfsp.GroupFooterSection7.SectionFormat.EnableSuppress = False

            'End If


            If CHKHEADER.Checked = False Then
                OBJ.DataDefinition.FormulaFields("HIDEHEADER").Text = 1
            Else
                OBJ.DataDefinition.FormulaFields("HIDEHEADER").Text = 0
            End If


            Dim JOBNO As String = ""
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If ClientName = "TULSI" Or ClientName = "SHREENATH" Then
                DT = OBJCMN.search(" DISTINCT   FINALCUTTINGPROCESS.FCP_JOBNO  AS JOBNO ", "", " FINALCUTTINGPROCESS INNER JOIN FINALPACKINGSLIP_DESC ON FINALCUTTINGPROCESS.FCP_NO = FINALPACKINGSLIP_DESC.FPS_MFGNO AND FINALCUTTINGPROCESS.FCP_CMPID = FINALPACKINGSLIP_DESC.FPS_CMPID AND FINALCUTTINGPROCESS.FCP_LOCATIONID = FINALPACKINGSLIP_DESC.FPS_LOCATIONID AND FINALCUTTINGPROCESS.FCP_YEARID = FINALPACKINGSLIP_DESC.FPS_YEARID INNER JOIN FINALPACKINGSLIP ON FINALPACKINGSLIP_DESC.FPS_NO = FINALPACKINGSLIP.FPS_NO AND FINALPACKINGSLIP_DESC.FPS_CMPID = FINALPACKINGSLIP.FPS_CMPID AND FINALPACKINGSLIP_DESC.FPS_LOCATIONID = FINALPACKINGSLIP.FPS_LOCATIONID AND FINALPACKINGSLIP_DESC.FPS_YEARID = FINALPACKINGSLIP.FPS_YEARID INNER JOIN PROCESSMASTER ON FINALPACKINGSLIP.FPS_PROCESSID = PROCESSMASTER.PROCESS_ID AND FINALPACKINGSLIP.FPS_CMPID = PROCESSMASTER.PROCESS_CMPID AND FINALPACKINGSLIP.FPS_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND FINALPACKINGSLIP.FPS_YEARID = PROCESSMASTER.PROCESS_YEARID  ", " AND FINALPACKINGSLIP_DESC.FPS_NO = " & txtfrom.Text + I & " AND PROCESS_NAME = 'FINAL CUTTING' AND FINALPACKINGSLIP_DESC.FPS_CMPID = " & CmpId & " AND FINALPACKINGSLIP_DESC.FPS_LOCATIONID = " & Locationid & " AND FINALPACKINGSLIP_DESC.FPS_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        If JOBNO = "" Then
                            JOBNO = DTROW("JOBNO")
                        Else
                            JOBNO = JOBNO & ", " & DTROW("JOBNO")
                        End If
                    Next
                End If
                OBJ.DataDefinition.FormulaFields("JOBNO").Text = "'" & JOBNO & "'"
            End If

            '************************ END *******************

            If ClientName = "MONOGRAM" Then
                'GET MULTIPLELOTNOS
                Dim TEMPLOTNO As String = ""
                DT = OBJCMN.search("DISTINCT FINALPACKINGSLIP_DESC.FPS_LOTNO AS LOTNO", "", " FINALPACKINGSLIP_DESC", " AND FPS_NO = " & Val(txtfrom.Text + I) & " AND FPS_YEARID = " & YearId)
                For Each DTROW As DataRow In DT.Rows
                    If TEMPLOTNO = "" Then TEMPLOTNO = DTROW("LOTNO") Else TEMPLOTNO = TEMPLOTNO & "," & DTROW("LOTNO")
                Next
                OBJ.DataDefinition.FormulaFields("MULTILOTNO").Text = "'" & TEMPLOTNO & "'"
            End If



            'objgp.MdiParent = MDIMain
            If ClientName = "TULSI" Or ClientName = "SHREENATH" Or ClientName = "MONOGRAM" Then OBJ.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
            OBJ.RecordSelectionFormula = "{finalpackingslip.fps_no} = " & txtfrom.Text + I & " and {finalpackingslip.fps_cmpid}=" & CmpId & " and {finalpackingslip.fps_locationid}=" & Locationid & " and {finalpackingslip.fps_yearid}=" & YearId
            OBJ.PrintToPrinter(1, True, 0, 0)
        Next
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Packing Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Packing Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Packing Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLMAIL_Click(sender As Object, e As EventArgs) Handles TOOLMAIL.Click
        Try
            If (Val(txtfrom.Text.Trim) = 0 Or Val(txtto.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(txtfrom.Text.Trim) > 0 And Val(txtto.Text.Trim) > 0 Then
                If Val(txtfrom.Text.Trim) > Val(txtto.Text.Trim) Then
                    MsgBox("Enter Proper Packing Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail Packing from " & Val(txtfrom.Text.Trim) & " To " & Val(txtto.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected Packing ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDREPORT_Click(sender As Object, e As EventArgs) Handles GRIDREPORT.Click
        Try
            Dim OBJPS As New FinalPackingSlipGridDetails
            OBJPS.MdiParent = MDIMain
            OBJPS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and dbo.FINALPACKINGSLIP.FPS_CMPID=" & CmpId & " and dbo.FINALPACKINGSLIP.FPS_locationid=" & Locationid & " and dbo.FINALPACKINGSLIP.FPS_yearid=" & YearId & " GROUP BY FINALPACKINGSLIP.FPS_NO, FINALPACKINGSLIP.FPS_DATE, FINALPACKINGSLIP.FPS_FBNO, LEDGERS.Acc_cmpname, PROCESSMASTER.PROCESS_NAME, ITEMMASTER_1.item_name, DYEINGRECIPE.DYEING_NO, FINALPACKINGSLIP.FPS_JOBNO, FINALPACKINGSLIP.FPS_ORDERNO, FINALPACKINGSLIP.FPS_PROGNO, FINALPACKINGSLIP_DESC.FPS_LOTNO, ISNULL(FINALPACKINGSLIP.FPS_EXPENSEREPORT,0), ISNULL(DYEINGRECIPE.DYEING_IMGPATH,''), ISNULL(DYEINGRECIPE.DYEING_OURLOCATION,''), ISNULL(PROCESSTYPEMASTER.PROCESSTYPE_NAME,''), ISNULL(FINALPACKINGSLIP.FPS_PACKEDBY,'') order by dbo.FINALPACKINGSLIP.FPS_no ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("EXPENSEREPORT")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.LightGreen
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If gridbill.GetFocusedRowCellValue("OURLOCATION") <> "" Then
                If Path.GetExtension(gridbill.GetFocusedRowCellValue("IMGPATH")) = ".pdf" Then
                    System.Diagnostics.Process.Start(gridbill.GetFocusedRowCellValue("OURLOCATION"))
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.ImageLocation = gridbill.GetFocusedRowCellValue("OURLOCATION")
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class