
Imports BL

Public Class FinalPackingSlipGridDetails

    Public edit As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub FinalPackingSlipGridDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub FinalPackingSlipGridDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            fillgrid()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" FINALPACKINGSLIP.FPS_NO AS SRNO, FINALPACKINGSLIP.FPS_DATE AS DATE, FINALPACKINGSLIP.FPS_FBNO AS FBNO, LEDGERS.Acc_cmpname AS NAME, PROCESSMASTER.PROCESS_NAME AS PROCESS, ITEMMASTER_1.item_name AS MERCHANT, DYEINGRECIPE.DYEING_NO AS DYEINGNO, FINALPACKINGSLIP.FPS_JOBNO AS JOBNO, FINALPACKINGSLIP.FPS_ORDERNO AS ORDERNO, FINALPACKINGSLIP.FPS_PROGNO AS PROGNO, FINALPACKINGSLIP_DESC.FPS_LOTNO AS LOTNO, SUM(FINALPACKINGSLIP_DESC.FPS_TOTAL) AS PCS, SUM(FINALPACKINGSLIP_DESC.FPS_MTRS) AS MTRS, ISNULL(FINALPACKINGSLIP.FPS_EXPENSEREPORT,0) AS EXPENSEREPORT, ISNULL(DYEINGRECIPE.DYEING_IMGPATH,'') AS IMGPATH, ISNULL(DYEINGRECIPE.DYEING_OURLOCATION,'') AS OURLOCATION, ISNULL(PROCESSTYPEMASTER.PROCESSTYPE_NAME,'') AS PROCESSTYPE, ISNULL(FINALPACKINGSLIP.FPS_PACKEDBY,'') AS PACKEDBY, ISNULL(DESIGNRECIPE.DESIGN_NO, '') AS DESIGNNO, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR,  ITEMMASTER.item_name AS GRIDMERCHANT ", "", " FINALPACKINGSLIP INNER JOIN PROCESSMASTER ON FINALPACKINGSLIP.FPS_PROCESSID = PROCESSMASTER.PROCESS_ID INNER JOIN FINALPACKINGSLIP_DESC ON FINALPACKINGSLIP.FPS_NO = FINALPACKINGSLIP_DESC.FPS_NO AND FINALPACKINGSLIP.FPS_YEARID = FINALPACKINGSLIP_DESC.FPS_YEARID LEFT OUTER JOIN DYEINGRECIPE ON FINALPACKINGSLIP.FPS_DYEINGID = DYEINGRECIPE.DYEING_ID LEFT OUTER JOIN ITEMMASTER AS ITEMMASTER_1 ON FINALPACKINGSLIP.FPS_MERCHANTID = ITEMMASTER_1.item_id LEFT OUTER JOIN LEDGERS ON FINALPACKINGSLIP.FPS_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN PROCESSTYPEMASTER ON FINALPACKINGSLIP.FPS_PROCESSTYPEID = PROCESSTYPEMASTER.PROCESSTYPE_ID LEFT OUTER JOIN COLORMASTER ON FINALPACKINGSLIP_DESC.FPS_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN DESIGNRECIPE ON FINALPACKINGSLIP_DESC.FPS_DESIGNID = DESIGNRECIPE.DESIGN_ID LEFT OUTER JOIN ITEMMASTER ON FINALPACKINGSLIP_DESC.FPS_ITEMID = ITEMMASTER.item_id", " and dbo.FINALPACKINGSLIP.FPS_yearid=" & YearId & " GROUP BY FINALPACKINGSLIP.FPS_NO, FINALPACKINGSLIP.FPS_DATE, FINALPACKINGSLIP.FPS_FBNO, LEDGERS.Acc_cmpname, PROCESSMASTER.PROCESS_NAME, ITEMMASTER_1.item_name, DYEINGRECIPE.DYEING_NO, FINALPACKINGSLIP.FPS_JOBNO, FINALPACKINGSLIP.FPS_ORDERNO, FINALPACKINGSLIP.FPS_PROGNO, FINALPACKINGSLIP_DESC.FPS_LOTNO, ISNULL(FINALPACKINGSLIP.FPS_EXPENSEREPORT,0), ISNULL(DYEINGRECIPE.DYEING_IMGPATH,''), ISNULL(DYEINGRECIPE.DYEING_OURLOCATION,''), ISNULL(PROCESSTYPEMASTER.PROCESSTYPE_NAME,''), ISNULL(FINALPACKINGSLIP.FPS_PACKEDBY,''), ISNULL(DESIGNRECIPE.DESIGN_NO, ''), ISNULL(COLORMASTER.COLOR_name, ''), ITEMMASTER.ITEM_NAME order by dbo.FINALPACKINGSLIP.FPS_no")
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

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLEXCEL.Click
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

    Private Sub TOOLREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class