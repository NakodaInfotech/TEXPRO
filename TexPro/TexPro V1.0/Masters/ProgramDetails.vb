
Imports BL
Imports System.Windows.Forms

Public Class ProgramDetails

    Public edit As Boolean
    Dim TEMPPRGNO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PRequisitionDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub PRequisitionDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        fillgrid(" and dbo.PRGMASTER.PRG_CMPID=" & CmpId & " and dbo.PRGMASTER.PRG_locationid=" & Locationid & " and dbo.PRGMASTER.PRG_yearid=" & YearId & " order by dbo.PRGMASTER.PRG_no ")
    End Sub

    Sub fillgrid(ByVal tepmcondition)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclsCMST.search("   PRGMASTER.PRG_no AS SRNO, PRGMASTER.PRG_date AS DATE, LEDGERS.Acc_cmpname AS NAME, QUALITYMASTER.QUALITY_name AS QUALITY,  PRGMASTER.PRG_ORDERNO AS ORDERNO, DYEINGRECIPE.DYEING_NO AS DYEINGNO, PRGMASTER_DESC.PRG_QTY AS QTY, PRGMASTER_DESC.PRG_READYQTY AS READYQTY ", "", "      PRGMASTER INNER JOIN LEDGERS ON PRGMASTER.PRG_NAMEid = LEDGERS.Acc_id AND PRGMASTER.PRG_cmpid = LEDGERS.Acc_cmpid AND PRGMASTER.PRG_locationid = LEDGERS.Acc_locationid AND PRGMASTER.PRG_yearid = LEDGERS.Acc_yearid INNER JOIN PRGMASTER_DESC ON PRGMASTER.PRG_no = PRGMASTER_DESC.PRG_no AND PRGMASTER.PRG_yearid = PRGMASTER_DESC.PRG_yearid AND PRGMASTER.PRG_cmpid = PRGMASTER_DESC.PRG_cmpid AND PRGMASTER.PRG_locationid = PRGMASTER_DESC.PRG_locationid INNER JOIN DYEINGRECIPE ON PRGMASTER_DESC.PRG_DYEINGID = DYEINGRECIPE.DYEING_ID AND PRGMASTER_DESC.PRG_cmpid = DYEINGRECIPE.DYEING_CMPID AND PRGMASTER_DESC.PRG_locationid = DYEINGRECIPE.DYEING_LOCATIONID AND PRGMASTER_DESC.PRG_yearid = DYEINGRECIPE.DYEING_YEARID INNER JOIN QUALITYMASTER ON PRGMASTER.PRG_QUALITYid = QUALITYMASTER.QUALITY_id AND PRGMASTER.PRG_cmpid = QUALITYMASTER.QUALITY_cmpid AND PRGMASTER.PRG_locationid = QUALITYMASTER.QUALITY_locationid AND PRGMASTER.PRG_yearid = QUALITYMASTER.QUALITY_yearid ", tepmcondition)
            If dt.Rows.Count > 0 Then
                gridbilldetails.DataSource = dt
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal PRGNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objREQ As New ProgramMaster
                objREQ.MdiParent = MDIMain
                objREQ.edit = editval
                objREQ.TEMPPRGNO = PRGNO
                objREQ.Show()
                'Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            'If USERADD = False Then
            '    MsgBox("Insufficient Rights")
            '    Exit Sub
            'End If
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

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\PRG Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "PRG Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "PRG Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class