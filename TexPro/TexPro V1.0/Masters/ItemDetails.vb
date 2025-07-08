
Imports BL
Imports System.Windows.Forms

Public Class ItemDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub ItemDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then
            showform(False, "")
        End If
    End Sub

    Private Sub ItemDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If FRMSTRING = "MERCHANT" Then
                Me.Text = "Merchant Details"
                TabControl1.TabPages(0).Text = "Merchant Details"
                lbl.Text = "Double Click on Merchant to Edit"
                TXTQUALITY.Visible = False
                LBLOURQUALITY.Visible = False
                TXTQUALITY.Text = "Finished Goods"
            End If

            fillgriditem()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Sub fillgriditem(Optional ByVal WHERE As String = "")

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        Dim objClsCommon As New ClsCommonMaster
        Dim dttable As DataTable = objClsCommon.search(" Item_Name as NAME, Item_code AS CODE", "", " ItemMaster", " AND ITEM_FRMSTRING = '" & FRMSTRING & "' and Item_cmpid = " & CmpId & " and Item_Locationid = " & Locationid & " and Item_yearid = " & YearId & WHERE & " order by item_name")
        GRIDNAME.DataSource = dttable

    End Sub

    Sub getdetails(ByRef name As String)

        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster
        dttable = objClsCommon.search("  ITEMMASTER.ITEM_ID AS ITEMID, MATERIALTYPEMASTER.material_name AS MATERIALTYPE, ISNULL(CATEGORYMASTER.category_name,'') AS CATEGORY, ITEMMASTER.item_name AS ITEMNAME, ISNULL(ITEMMASTER.item_code,'') AS ITEMCODE, ISNULL(UNITMASTER.unit_abbr,'') AS UNIT, ISNULL(DEPARTMENTMASTER.DEPARTMENT_name,'') AS DEPARTMENT, ITEMMASTER.item_reorder AS REORDER, ITEMMASTER.item_opstock AS OPSTOCK, ITEMMASTER.item_opvalue AS OPVALUE, ITEMMASTER.item_upper AS UPPER, ITEMMASTER.item_lower AS LOWER, ISNULL(ITEMMASTER.item_remarks,'') AS REMARKS, ISNULL(RATETYPEMASTER.RATETYPE_name,'') AS RATETYPE, ISNULL(ITEMMASTER_RATEDESC.ITEM_RATE,0) AS RATE, ISNULL(HSN_CODE, '') AS HSNCODE, ISNULL(QUALITYMASTER.QUALITY_NAME,'') AS OURQUALITY", "", " DEPARTMENTMASTER RIGHT OUTER JOIN ITEMMASTER INNER JOIN MATERIALTYPEMASTER ON ITEMMASTER.item_cmpid = MATERIALTYPEMASTER.material_cmpid AND ITEMMASTER.item_locationid = MATERIALTYPEMASTER.material_locationid AND ITEMMASTER.item_yearid = MATERIALTYPEMASTER.material_yearid AND ITEMMASTER.item_materialtypeid = MATERIALTYPEMASTER.material_id LEFT OUTER JOIN UNITMASTER ON ITEMMASTER.item_yearid = UNITMASTER.unit_yearid AND ITEMMASTER.item_locationid = UNITMASTER.unit_locationid AND ITEMMASTER.item_cmpid = UNITMASTER.unit_cmpid AND ITEMMASTER.item_unitid = UNITMASTER.unit_id LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id AND ITEMMASTER.item_cmpid = CATEGORYMASTER.category_cmpid AND ITEMMASTER.item_locationid = CATEGORYMASTER.category_locationid AND ITEMMASTER.item_yearid = CATEGORYMASTER.category_yearid ON DEPARTMENTMASTER.DEPARTMENT_yearid = ITEMMASTER.item_yearid AND DEPARTMENTMASTER.DEPARTMENT_locationid = ITEMMASTER.item_locationid AND DEPARTMENTMASTER.DEPARTMENT_cmpid = ITEMMASTER.item_cmpid AND DEPARTMENTMASTER.DEPARTMENT_id = ITEMMASTER.item_departmentid LEFT OUTER JOIN RATETYPEMASTER RIGHT OUTER JOIN ITEMMASTER_RATEDESC ON RATETYPEMASTER.RATETYPE_id = ITEMMASTER_RATEDESC.ITEM_RATETYPEID AND RATETYPEMASTER.RATETYPE_cmpid = ITEMMASTER_RATEDESC.ITEM_CMPID AND RATETYPEMASTER.RATETYPE_locationid = ITEMMASTER_RATEDESC.ITEM_LOCATIONID AND RATETYPEMASTER.RATETYPE_yearid = ITEMMASTER_RATEDESC.ITEM_YEARID ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID AND ITEMMASTER.item_cmpid = ITEMMASTER_RATEDESC.ITEM_CMPID AND ITEMMASTER.item_locationid = ITEMMASTER_RATEDESC.ITEM_LOCATIONID AND ITEMMASTER.item_yearid = ITEMMASTER_RATEDESC.ITEM_YEARID LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSN_ID LEFT OUTER JOIN QUALITYMASTER ON ITEMMASTER.ITEM_QUALITYID = QUALITYMASTER.QUALITY_ID ", " and ITEMMASTER.Item_Name = '" & name & "' and ITEMMASTER.Item_yearid = " & YearId)
        cleartextbox()
        If dttable.Rows.Count > 0 Then
            For Each ROW As DataRow In dttable.Rows

                TXTQUALITY.Text = ROW("OURQUALITY")
                txtcategory.Text = ROW("CATEGORY").ToString
                txtitemname.Text = ROW("ITEMNAME").ToString
                txtcode.Text = ROW("ITEMCODE").ToString
                txtunit.Text = ROW("UNIT").ToString
                TXTDEPARTMENT.Text = ROW("DEPARTMENT").ToString
                txtreorder.Text = Val(ROW("REORDER").ToString)
                TXTOPSTOCK.Text = Val(ROW("OPSTOCK").ToString)
                TXTOPVALUE.Text = Val(ROW("OPVALUE").ToString)
                txtupper.Text = Val(ROW("UPPER").ToString)
                txtlower.Text = Val(ROW("LOWER").ToString)
                TXTHSNCODE.Text = ROW("HSNCODE")
                txtremarks.Text = ROW("REMARKS").ToString

                If ROW("RATETYPE") <> "" Then GRIDRATE.Rows.Add(ROW("RATETYPE"), ROW("RATE"))

            Next

        End If

    End Sub

    Sub cleartextbox()
        TXTQUALITY.Clear()
        txtcategory.Clear()
        TXTDEPARTMENT.Clear()
        txtitemname.Clear()
        txtcode.Clear()
        txtunit.Clear()
        txtupper.Clear()
        txtlower.Clear()
        TXTHSNCODE.Clear()
        txtreorder.Clear()
        txtremarks.Clear()
        GRIDRATE.RowCount = 0
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridledger.RowCount > 0) Then
                Dim objItemmaster As New ItemMaster
                objItemmaster.MdiParent = MDIMain
                objItemmaster.edit = editval
                objItemmaster.tempItemName = name
                objItemmaster.frmstring = FRMSTRING
                objItemmaster.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PBEXCEL_Click(sender As Object, e As EventArgs) Handles PBEXCEL.Click
        Try
            Dim OBJITEM As New ItemDetailsReport
            OBJITEM.MdiParent = MDIMain
            OBJITEM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.Click
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridledger.FocusedRowChanged
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgriditem()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "TULSI" Then
                LBLOURQUALITY.Visible = True
                TXTQUALITY.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class