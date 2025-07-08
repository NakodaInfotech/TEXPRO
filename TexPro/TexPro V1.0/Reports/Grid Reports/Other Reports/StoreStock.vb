
Imports BL

Public Class StoreStock

    Public WHERECLAUSE As String = ""
    Public FRMSTRING As String = ""

    Private Sub StoreStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            Dim WCLAUSE As String = ""
            If CHKALL.CheckState = CheckState.Unchecked Then WCLAUSE = " AND T.INVENTORY = 'True'"
            If FRMSTRING = "STOCKONHAND" Then dt = objclsCMST.search(" * ", "", " ( SELECT DISTINCT STORESTOCK.DEPARTMENT, STORESTOCK.ITEMNAME, ISNULL(RATETYPE_name,'') AS RATETYPE, ISNULL(ITEMMASTER_RATEDESC.ITEM_RATE,0) AS RATE, STORESTOCK.OPENING, (ISNULL(ITEMMASTER_RATEDESC.ITEM_RATE,0) * OPENING) AS OPVALUE, STORESTOCK.INWARDS, (ISNULL(ITEMMASTER_RATEDESC.ITEM_RATE,0) * INWARDS) AS INVALUE, STORESTOCK.RETURNING, (ISNULL(ITEMMASTER_RATEDESC.ITEM_RATE,0) * RETURNING) AS OUTVALUE, STORESTOCK.DESPATCH, (ISNULL(ITEMMASTER_RATEDESC.ITEM_RATE,0) * DESPATCH) AS DESVALUE, STORESTOCK.BALANCE, (ISNULL(ITEMMASTER_RATEDESC.ITEM_RATE,0) * BALANCE) AS BALVALUE, STORESTOCK.INVENTORY, STORESTOCK.CMPID, STORESTOCK.LOCATIONID, STORESTOCK.YEARID FROM STORESTOCK INNER JOIN ITEMMASTER ON STORESTOCK.ITEMNAME = ITEMMASTER.item_name AND STORESTOCK.CMPID = ITEMMASTER.item_cmpid AND STORESTOCK.LOCATIONID = ITEMMASTER.item_locationid AND STORESTOCK.YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN ITEMMASTER_RATEDESC INNER JOIN RATETYPEMASTER ON ITEMMASTER_RATEDESC.ITEM_RATETYPEID = RATETYPEMASTER.RATETYPE_id AND ITEMMASTER_RATEDESC.ITEM_CMPID = RATETYPEMASTER.RATETYPE_cmpid AND ITEMMASTER_RATEDESC.ITEM_LOCATIONID = RATETYPEMASTER.RATETYPE_locationid AND ITEMMASTER_RATEDESC.ITEM_YEARID = RATETYPEMASTER.RATETYPE_yearid ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID AND ITEMMASTER.item_cmpid = ITEMMASTER_RATEDESC.ITEM_CMPID AND ITEMMASTER.item_locationid = ITEMMASTER_RATEDESC.ITEM_LOCATIONID AND ITEMMASTER.item_yearid = ITEMMASTER_RATEDESC.ITEM_YEARID ) AS T ", WHERECLAUSE & WCLAUSE & " AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StoreStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Store Stock Report.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Store Stock Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Store Stock REport", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDSTOCK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDSTOCK.CheckedChanged
        Try
            If RDSTOCK.Checked = True Then
                gridbill.Columns("OPENING").Visible = False
                gridbill.Columns("OPVALUE").Visible = False
                gridbill.Columns("INWARDS").Visible = False
                gridbill.Columns("INVALUE").Visible = False
                gridbill.Columns("RETURNING").Visible = False
                gridbill.Columns("OUTVALUE").Visible = False
                gridbill.Columns("DESPATCH").Visible = False
                gridbill.Columns("DESVALUE").Visible = False
                gridbill.Columns("BALVALUE").Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDSTOCKVALUE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDSTOCKVALUE.CheckedChanged
        Try
            If RDSTOCKVALUE.Checked = True Then
                gridbill.Columns("OPENING").Visible = True
                gridbill.Columns("OPVALUE").Visible = True
                gridbill.Columns("INWARDS").Visible = True
                gridbill.Columns("INVALUE").Visible = True
                gridbill.Columns("RETURNING").Visible = True
                gridbill.Columns("OUTVALUE").Visible = True
                gridbill.Columns("DESPATCH").Visible = True
                gridbill.Columns("DESVALUE").Visible = True
                gridbill.Columns("BALVALUE").Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RDSTOCKCONSUMPTION_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDSTOCKCONSUMPTION.CheckedChanged
        Try
            If RDSTOCKCONSUMPTION.Checked = True Then
                gridbill.Columns("OPENING").Visible = True
                gridbill.Columns("OPVALUE").Visible = False
                gridbill.Columns("INWARDS").Visible = True
                gridbill.Columns("INVALUE").Visible = False
                gridbill.Columns("RETURNING").Visible = True
                gridbill.Columns("OUTVALUE").Visible = False
                gridbill.Columns("DESPATCH").Visible = True
                gridbill.Columns("DESVALUE").Visible = False
                gridbill.Columns("BALVALUE").Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CHKALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKALL.CheckedChanged
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class