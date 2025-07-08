Imports Microsoft.Office.Interop
Imports BL
Imports System.Windows.Forms
Public Class CuttingProcessDetails
    Private objSheet As Excel.Worksheet
    Private objExcel As Excel.Application
    Private objBook As Excel.Workbook
    Public edit As Boolean
    Dim tempcpno As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub MfgDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub MfgDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'MFG'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid(" and dbo.CUTTINGPROCESS.CP_CMPID=" & CmpId & " and dbo.CUTTINGPROCESS.CP_locationid=" & Locationid & " and dbo.CUTTINGPROCESS.CP_yearid=" & YearId & " order by dbo.CUTTINGPROCESS.CP_no")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("   CUTTINGPROCESS.CP_NO AS CPNO, CUTTINGPROCESS.CP_DATE AS DATE, FROMPROCESS.PROCESS_NAME AS FROMPROCESS, CUTTINGPROCESS.CP_LOTNO AS LOTNO, QUALITYMASTER.QUALITY_name AS QUALITY, CUTTINGPROCESS.CP_TOTALPCS AS PCS, CUTTINGPROCESS.CP_TOTALPCSMTRS AS PCSMTRS, CUTTINGPROCESS.CP_TOTALSAREE AS SAREE, CUTTINGPROCESS.CP_TOTALMTRS AS MTRS,CUTTINGPROCESS.CP_DONE AS CPDONE, CUTTINGPROCESS.CP_JOBNO AS JOBNO, DESIGNRECIPE.DESIGN_NO AS DESIGNNO, ITEMMASTER.item_name AS MERCHANT, ISNULL(CONTRACTOR_NAME,'') AS CONTRACTOR ", "", " CUTTINGPROCESS INNER JOIN ITEMMASTER ON CUTTINGPROCESS.CP_MERCHANTID = ITEMMASTER.item_id AND CUTTINGPROCESS.CP_CMPID = ITEMMASTER.item_cmpid AND CUTTINGPROCESS.CP_LOCATIONID = ITEMMASTER.item_locationid AND CUTTINGPROCESS.CP_YEARID = ITEMMASTER.item_yearid left outer JOIN DESIGNRECIPE ON CUTTINGPROCESS.CP_DESIGNID = DESIGNRECIPE.DESIGN_ID AND CUTTINGPROCESS.CP_CMPID = DESIGNRECIPE.DESIGN_CMPID AND CUTTINGPROCESS.CP_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND CUTTINGPROCESS.CP_YEARID = DESIGNRECIPE.DESIGN_YEARID LEFT OUTER JOIN QUALITYMASTER ON CUTTINGPROCESS.CP_YEARID = QUALITYMASTER.QUALITY_yearid AND CUTTINGPROCESS.CP_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND CUTTINGPROCESS.CP_CMPID = QUALITYMASTER.QUALITY_cmpid AND CUTTINGPROCESS.CP_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN PROCESSMASTER AS FROMPROCESS ON CUTTINGPROCESS.CP_FROMPROCESSID = FROMPROCESS.PROCESS_ID AND CUTTINGPROCESS.CP_CMPID = FROMPROCESS.PROCESS_CMPID AND CUTTINGPROCESS.CP_LOCATIONID = FROMPROCESS.PROCESS_LOCATIONID AND CUTTINGPROCESS.CP_YEARID = FROMPROCESS.PROCESS_YEARID LEFT OUTER JOIN CONTRACTORMASTER ON CUTTINGPROCESS.CP_CONTRACTORID = CONTRACTOR_ID AND CUTTINGPROCESS.CP_CMPID = CONTRACTOR_CMPID AND CUTTINGPROCESS.CP_LOCATIONID = CONTRACTOR_LOCATIONID AND CUTTINGPROCESS.CP_YEARID = CONTRACTOR_YEARID", tepmcondition)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal CPNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJMFG As New CuttingProcess
                OBJMFG.MdiParent = MDIMain
                OBJMFG.edit = editval
                OBJMFG.TEMPCPNO = CPNO
                OBJMFG.Show()
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

    Private Sub gridBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("CPNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("CPNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            Dim DT As DataTable = gridbilldetails.DataSource
            If e.RowHandle >= 0 Then
                Dim ROW As DataRow = DT.Rows(e.RowHandle)
                'If ROW("MFGDONE") = "TRUE" Then
                '    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                '    e.Appearance.BackColor = Color.Yellow
                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Cutting Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Cutting Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Cutting Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub SetWorkSheet()
        Try
            objExcel = New Excel.Application
            If Not objExcel Is Nothing Then
                objBook = objExcel.Workbooks.Add
                objSheet = DirectCast(objBook.ActiveSheet, Excel.Worksheet)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Quit()
        Try
            objSheet = Nothing
            objBook.Close()
            ReleaseObject(objBook)
            objExcel.Quit()
            ReleaseObject(objExcel)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SaveAndClose()
        Try
            objExcel.AlertBeforeOverwriting = False
            objExcel.DisplayAlerts = False
            'objSheet.SaveAs(Application.StartupPath & "\cutting.XLS")


            objExcel.Visible = True
        Catch ex As Exception
            Throw ex
       
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid(" and dbo.CUTTINGPROCESS.CP_CMPID=" & CmpId & " and dbo.CUTTINGPROCESS.CP_locationid=" & Locationid & " and dbo.CUTTINGPROCESS.CP_yearid=" & YearId & " order by dbo.CUTTINGPROCESS.CP_no")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class