
Imports BL
Imports System.ComponentModel

Public Class ItemMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer
    Public edit As Boolean
    Public tempItemName As String
    Public tempItemCODE As String
    Dim tempItemId As Integer
    Public frmstring As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(cmbmaterial.Text.Trim)
            alParaval.Add(cmbcategory.Text.Trim)
            alParaval.Add(UCase(cmbitemname.Text.Trim))
            alParaval.Add(CMBDEPARTMENT.Text.Trim)
            alParaval.Add(CMBCODE.Text.Trim)
            alParaval.Add(cmbunit.Text.Trim)
            alParaval.Add(TXTOPSTOCK.Text.Trim)
            alParaval.Add(TXTOPVALUE.Text.Trim)
            alParaval.Add(txtreorder.Text.Trim)
            alParaval.Add(txtupper.Text.Trim)
            alParaval.Add(txtlower.Text.Trim)
            alParaval.Add(TXTHSNCODE.Text.Trim)

            'FOR GRIDPARAMETER
            Dim RATETYPE As String = ""
            Dim RATE As String = ""

            For Each ROW As DataGridViewRow In GRIDRATE.Rows
                If ROW.Cells(gratetype.Index).Value <> Nothing Then
                    If RATETYPE = "" Then
                        RATETYPE = ROW.Cells(gratetype.Index).Value.ToString
                        RATE = ROW.Cells(grate.Index).Value
                    Else
                        RATETYPE = RATETYPE & "," & ROW.Cells(gratetype.Index).Value.ToString
                        RATE = RATE & "," & ROW.Cells(grate.Index).Value
                    End If
                End If
            Next


            alParaval.Add(RATETYPE)
            alParaval.Add(RATE)

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(frmstring)
            If CHKBLOCKED.CheckState = CheckState.Checked Then alParaval.Add(1) Else alParaval.Add(0)
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)
            alParaval.Add(CMBQUALITY.Text.Trim)
            alParaval.Add(CMBSUBCATEGORY.Text.Trim)
            alParaval.Add(CMBFOLD.Text.Trim)


            Dim objclsItemMaster As New clsItemmaster
            objclsItemMaster.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsItemMaster.SAVE()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempItemId)
                IntResult = objclsItemMaster.UPDATE()
                MsgBox("Details Updated")

            End If
            edit = False

            clear()
            cmbmaterial.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            pcase(cmbitemname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (edit = False) Or (edit = True And LCase(cmbitemname.Text) <> LCase(tempItemName)) Then
                dt = objclscommon.search("item_name", "", "ItemMaster", " and item_name = '" & cmbitemname.Text.Trim & "' And item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Item Name Already Exists", MsgBoxStyle.Critical, "TEXPRO")
                    BLN = False
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbitemname.Text.Trim.Length = 0 Then
            Ep.SetError(cmbitemname, "Fill Item Name")
            bln = False
        End If

        If CMBDEPARTMENT.Text.Trim.Length = 0 And frmstring = "MERCHANT" Then
            Ep.SetError(CMBDEPARTMENT, "Enter Department Name")
            bln = False
        End If

        If cmbmaterial.Text.Trim.Length = 0 Then
            Ep.SetError(cmbmaterial, "Select Material Type")
            bln = False
        End If

        If ClientName <> "MONOGRAM" And frmstring = "MERCHANT" And cmbcategory.Text.Trim = "" Then
            Ep.SetError(cmbcategory, "Select Category")
            bln = False
        End If

        'HSN NOT MANDATORY
        'If TXTHSNCODE.Text.Trim.Length = 0 Then
        '    Ep.SetError(TXTHSNCODE, "Fill HSN Code")
        '    bln = False
        'End If

        If Not CHECKDUPLICATE() Then
            Ep.SetError(cmbitemname, "Item Name Already Exists")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()

        cmbmaterial.Text = ""
        cmbcategory.Text = ""
        cmbitemname.Text = ""
        CMBDEPARTMENT.Text = ""
        cmbunit.Text = ""
        CMBCODE.Text = ""
        TXTOPSTOCK.Clear()
        TXTOPVALUE.Clear()
        txtlower.Clear()
        txtreorder.Clear()
        txtupper.Clear()
        TXTHSNCODE.Clear()
        CMBNAME.Text = ""
        CMBQUALITY.Text = ""
        CMBSUBCATEGORY.Text = ""
        CMBFOLD.Text = ""

        txtremarks.Clear()
        CHKBLOCKED.CheckState = CheckState.Unchecked

        'clearing grid
        GRIDRATE.RowCount = 0

    End Sub

    Private Sub cmbcategory_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcategory.Validating
        Try
            If cmbcategory.Text.Trim <> "" Then CATEGORYVALIDATE(cmbcategory, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

#Region " Cmb Material"
    Private Sub cmbmaterial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmaterial.GotFocus
        'Try
        '    Dim objclscommon As New ClsCommonMaster
        '    Dim dt As DataTable
        '    dt = objclscommon.search(" material_name ", "", " MaterialTypeMaster", " and material_cmpid=" & CmpId)
        '    If dt.Rows.Count > 0 Then
        '        dt.DefaultView.Sort = "material_name"
        '        cmbmaterial.DataSource = dt
        '        cmbmaterial.DisplayMember = "material_name"
        '        cmbmaterial.Text = ""
        '    End If
        '    cmbmaterial.SelectAll()
        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
    End Sub

    Private Sub cmbmaterial_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmaterial.Validating
        'Try
        '    If cmbmaterial.Text.Trim <> "" Then
        '        pcase(cmbmaterial)
        '        Dim objclscommon As New ClsCommonMaster
        '        Dim dt As DataTable
        '        dt = objclscommon.search("material_name", "", "MaterialTypeMaster", " and material_name = '" & cmbmaterial.Text.Trim & "' and Material_cmpid = " & CmpId)
        '        If dt.Rows.Count = 0 Then
        '            Dim tempmsg As Integer = MsgBox("Material not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
        '            If tempmsg = vbYes Then
        '                Dim alParaval As New ArrayList

        '                alParaval.Add(cmbmaterial.Text.Trim)
        '                alParaval.Add("")
        '                alParaval.Add(CmpId)
        '                alParaval.Add(Locationid)
        '                alParaval.Add(Userid)
        '                alParaval.Add(YearId)
        '                alParaval.Add(0)

        '                Dim objmaterialmaster As New ClsMaterialTypeMaster
        '                objmaterialmaster.alParaval = alParaval
        '                IntResult = objmaterialmaster.save()
        '                e.Cancel = True
        '            Else
        '                e.Cancel = True
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception
        '    If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        'End Try
    End Sub
#End Region

    Private Sub cmbunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.GotFocus
        Try
            If cmbunit.Items.Count > 0 And cmbunit.Text.Trim = "" Then fillunit(cmbunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
        Try
            If cmbunit.Text.Trim <> "" Then unitvalidate(cmbunit, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ItemMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Save
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

    Sub FILLCMB()

        Dim objclscommon As New ClsCommonMaster
        If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'  AND LEDGERS.ACC_TYPE='ACCOUNTS'")

        Dim dt As New DataTable

        dt = objclscommon.search("item_name", "", "ItemMaster", " AND ITEM_FRMSTRING = '" & frmstring & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Item_name"
            cmbitemname.DisplayMember = "Item_name"
            cmbitemname.Text = ""
        End If
        cmbitemname.DataSource = dt


        dt = objclscommon.search("item_CODE", "", "ItemMaster", " AND ITEM_FRMSTRING = '" & frmstring & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Item_CODE"
            CMBCODE.DisplayMember = "Item_CODE"
            CMBCODE.Text = ""
        End If
        CMBCODE.DataSource = dt


        dt = objclscommon.search("department_name", "", "departmentMaster", " and department_cmpid = " & CmpId & " and department_locationid = " & Locationid & " and department_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "department_name"
            CMBDEPARTMENT.DisplayMember = "department_name"
            CMBDEPARTMENT.Text = ""
        End If
        CMBDEPARTMENT.DataSource = dt


        dt = objclscommon.search("unit_name", "", "UnitMaster", " and unit_cmpid = " & CmpId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "unit_name"
            cmbunit.DisplayMember = "unit_name"
            cmbunit.Text = ""
        End If
        cmbunit.DataSource = dt

        fillRATETYPE(cmbratetype, False)
        fillQUALITY(CMBQUALITY, False)
        fillCATEGORY(cmbcategory, False)
        FILLSUBCATEGORY(CMBSUBCATEGORY, False)
        FILLFOLD(CMBFOLD, False)

    End Sub

    Private Sub ItemMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            fillcmb()
            cmbitemname.Text = tempItemName
            CMBCODE.Text = tempItemCODE
            CMBNAME.Text = ""
            CMBQUALITY.Text = ""
            CMBSUBCATEGORY.Text = ""
            CMBFOLD.Text = ""

            If frmstring = "MERCHANT" Then
                Me.Text = "Merchant Master"
                lbl.Text = "Merchant Master"
                gpitem.Text = "Merchant Master"
                cmbmaterial.Visible = False
                lblmaterial.Visible = False
                cmbmaterial.Text = "Finished Goods"
            End If


            If edit = True Then

                Dim dttable As New DataTable
                Dim objCommon As New ClsCommonMaster

                dttable = objCommon.search(" ITEMMASTER.ITEM_ID AS ITEMID, MATERIALTYPEMASTER.material_name AS MATERIALTYPE, ISNULL(CATEGORYMASTER.category_name,'') AS CATEGORY, ITEMMASTER.item_name AS ITEMNAME, ISNULL(ITEMMASTER.item_code,'') AS ITEMCODE, ISNULL(UNITMASTER.unit_abbr,'') AS UNIT, ISNULL(DEPARTMENTMASTER.DEPARTMENT_name,'') AS DEPARTMENT, ITEMMASTER.item_reorder AS REORDER, ITEMMASTER.item_opstock AS OPSTOCK, ITEMMASTER.item_opvalue AS OPVALUE, ITEMMASTER.item_upper AS UPPER, ITEMMASTER.item_lower AS LOWER, ISNULL(ITEMMASTER.item_remarks,'') AS REMARKS, ISNULL(RATETYPEMASTER.RATETYPE_name,'') AS RATETYPE, ISNULL(ITEMMASTER_RATEDESC.ITEM_RATE,0) AS RATE, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(ITEMMASTER.ITEM_BLOCKED,0) AS BLOCKED, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, ISNULL(QUALITYMASTER.QUALITY_NAME,'') AS OURQUALITY, ISNULL(SUBCATEGORYMASTER.SUBCATEGORY_NAME,'') AS SUBCATEGORY, ISNULL(FOLDMASTER.FOLD_NAME,'') AS FOLD ", "", " DEPARTMENTMASTER RIGHT OUTER JOIN ITEMMASTER INNER JOIN MATERIALTYPEMASTER ON ITEMMASTER.item_cmpid = MATERIALTYPEMASTER.material_cmpid AND ITEMMASTER.item_locationid = MATERIALTYPEMASTER.material_locationid AND ITEMMASTER.item_yearid = MATERIALTYPEMASTER.material_yearid AND ITEMMASTER.item_materialtypeid = MATERIALTYPEMASTER.material_id LEFT OUTER JOIN UNITMASTER ON ITEMMASTER.item_yearid = UNITMASTER.unit_yearid AND ITEMMASTER.item_locationid = UNITMASTER.unit_locationid AND ITEMMASTER.item_cmpid = UNITMASTER.unit_cmpid AND ITEMMASTER.item_unitid = UNITMASTER.unit_id LEFT OUTER JOIN CATEGORYMASTER ON ITEMMASTER.item_categoryid = CATEGORYMASTER.category_id AND ITEMMASTER.item_cmpid = CATEGORYMASTER.category_cmpid AND ITEMMASTER.item_locationid = CATEGORYMASTER.category_locationid AND ITEMMASTER.item_yearid = CATEGORYMASTER.category_yearid ON DEPARTMENTMASTER.DEPARTMENT_yearid = ITEMMASTER.item_yearid AND DEPARTMENTMASTER.DEPARTMENT_locationid = ITEMMASTER.item_locationid AND DEPARTMENTMASTER.DEPARTMENT_cmpid = ITEMMASTER.item_cmpid AND DEPARTMENTMASTER.DEPARTMENT_id = ITEMMASTER.item_departmentid LEFT OUTER JOIN RATETYPEMASTER RIGHT OUTER JOIN ITEMMASTER_RATEDESC ON RATETYPEMASTER.RATETYPE_id = ITEMMASTER_RATEDESC.ITEM_RATETYPEID AND RATETYPEMASTER.RATETYPE_cmpid = ITEMMASTER_RATEDESC.ITEM_CMPID AND RATETYPEMASTER.RATETYPE_locationid = ITEMMASTER_RATEDESC.ITEM_LOCATIONID AND RATETYPEMASTER.RATETYPE_yearid = ITEMMASTER_RATEDESC.ITEM_YEARID ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID AND ITEMMASTER.item_cmpid = ITEMMASTER_RATEDESC.ITEM_CMPID AND ITEMMASTER.item_locationid = ITEMMASTER_RATEDESC.ITEM_LOCATIONID AND ITEMMASTER.item_yearid = ITEMMASTER_RATEDESC.ITEM_YEARID LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN LEDGERS ON ITEM_LEDGERID = LEDGERS.ACC_ID LEFT OUTER JOIN QUALITYMASTER ON ITEMMASTER.ITEM_QUALITYID = QUALITYMASTER.QUALITY_ID LEFT OUTER JOIN SUBCATEGORYMASTER ON ITEMMASTER.ITEM_SUBCATEGORYID = SUBCATEGORYMASTER.SUBCATEGORY_ID LEFT OUTER JOIN FOLDMASTER ON ITEMMASTER.ITEM_FOLDID = FOLDMASTER.FOLD_ID", " and ITEMMASTER.Item_Name = '" & tempItemName & "' AND ITEMMASTER.ITEM_FRMSTRING = '" & frmstring & "' and ITEMMASTER.Item_yearid = " & YearId)
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If dttable.Rows.Count > 0 Then
                    For Each ROW As DataRow In dttable.Rows

                        tempItemId = ROW("ITEMID")
                        cmbmaterial.Text = ROW("MATERIALTYPE").ToString
                        cmbcategory.Text = ROW("CATEGORY").ToString
                        cmbitemname.Text = ROW("ITEMNAME").ToString
                        CMBCODE.Text = ROW("ITEMCODE").ToString
                        cmbunit.Text = ROW("UNIT").ToString
                        CMBDEPARTMENT.Text = ROW("DEPARTMENT").ToString
                        txtreorder.Text = Val(ROW("REORDER").ToString)
                        TXTOPSTOCK.Text = Val(ROW("OPSTOCK").ToString)
                        TXTOPVALUE.Text = Val(ROW("OPVALUE").ToString)
                        txtupper.Text = Val(ROW("UPPER").ToString)
                        txtlower.Text = Val(ROW("LOWER").ToString)
                        TXTHSNCODE.Text = ROW("HSNCODE").ToString
                        txtremarks.Text = ROW("REMARKS").ToString
                        CHKBLOCKED.Checked = Convert.ToBoolean(dttable.Rows(0).Item("BLOCKED"))
                        CMBNAME.Text = ROW("NAME")
                        CMBQUALITY.Text = dttable.Rows(0).Item("OURQUALITY")
                        CMBSUBCATEGORY.Text = ROW("SUBCATEGORY")
                        CMBFOLD.Text = ROW("FOLD")

                        If ROW("RATETYPE") <> "" Then GRIDRATE.Rows.Add(ROW("RATETYPE"), ROW("RATE"))

                    Next
                End If


            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmbitemname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.GotFocus
        Try
            If cmbitemname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("item_name", "", " ItemMaster ", " and ITEM_FRMSTRING = '" & frmstring & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Item_name"
                    cmbitemname.DataSource = dt
                    cmbitemname.DisplayMember = "Item_name"
                    cmbitemname.Text = ""
                End If
                cmbitemname.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbitemname.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim OBJITEM As New SelectItem
                OBJITEM.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        If cmbitemname.Text.Trim <> "" Then
            uppercase(cmbitemname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (edit = False) Or (edit = True And LCase(cmbitemname.Text) <> LCase(tempItemName)) Then
                dt = objclscommon.search("item_name", "", "ItemMaster", " and item_name = '" & cmbitemname.Text.Trim & "'  And item_cmpid = " & CmpId & " And item_locationid = " & Locationid & " And item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Item Name Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        '**** code for to delete the selected imtem from item master *****
        ' ****Logic 
        ' looking for in SalesOrder_Desc Table if Item master Name is Exists OR Not
        If USERDELETE = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If
        If cmbitemname.Text.Trim = "" Then
            MsgBox("Item Name Can Not Be Blank ")
            Exit Sub
        End If

        If edit = False Then
            'since user can delete Master only in edit mode
            MsgBox("Item Name Can Delete only in Edit Mode", MsgBoxStyle.Critical, "Tex Pro")
            Exit Sub
        End If


        If cmbitemname.Text.Trim <> "" Then
            If MsgBox("Delete Item ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            pcase(cmbitemname)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search("item_name", "", " dbo.ITEMMASTER RIGHT OUTER JOIN  dbo.SALEORDER_DESC ON dbo.ITEMMASTER.item_id = dbo.SALEORDER_DESC.so_itemid ", " and item_name = '" & cmbitemname.Text.Trim & "' And item_cmpid = " & CmpId & " And item_locationid = " & Locationid & " And item_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Item Name Already Used in Transaction Forms", MsgBoxStyle.Critical, "Tex Pro")
                Exit Sub
            End If


            dt = objclscommon.search("GRN_NO", "", " GRN_DESC ", " AND GRN_ITEMID = " & tempItemId)
            If dt.Rows.Count > 0 Then
                MsgBox("Item Name Already Used in GRN No" & dt.Rows(0).Item(0), MsgBoxStyle.Critical, "Tex Pro")
                Exit Sub
            End If

            dt = objclscommon.search("LOAN_NO", "", " LOANMASTER_DESC ", " AND LOAN_ITEMID = " & tempItemId)
            If dt.Rows.Count > 0 Then
                MsgBox("Item Name Already Used in Loan Enrtry No" & dt.Rows(0).Item(0), MsgBoxStyle.Critical, "Tex Pro")
                Exit Sub
            End If

            dt = objclscommon.search("CONSUME_NO", "", " CONSUMPTION_DESC ", " AND CONSUME_ITEMID = " & tempItemId)
            If dt.Rows.Count > 0 Then
                MsgBox("Item Name Already Used in Consumption No" & dt.Rows(0).Item(0), MsgBoxStyle.Critical, "Tex Pro")
                Exit Sub
            End If

            dt = objclscommon.search("DESIGN_ID", "", " DESIGNRECIPE_CONSUMPTION ", " AND DESIGN_ITEMID = " & tempItemId)
            If dt.Rows.Count > 0 Then
                MsgBox("Item Name Already Used in Design ", MsgBoxStyle.Critical, "Tex Pro")
                Exit Sub
            End If


            ''if above all conditions are false then only user can delete Particular Master
            Dim alParaval As New ArrayList
            alParaval.Add(tempItemId)

            Dim clsitemst As New clsItemmaster
            clsitemst.alParaval = alParaval
            IntResult = clsitemst.Delete()
            MsgBox("Item Name Deleted")
            edit = False
            clear()
        End If

    End Sub

    Private Sub CMBDEPARTMENT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDEPARTMENT.Validating
        Try
            If CMBDEPARTMENT.Text.Trim <> "" Then DEPARTMENTVALIDATE(CMBDEPARTMENT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCODE.GotFocus
        Try
            If CMBCODE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("item_CODE", "", " ItemMaster ", " and ITEM_FRMSTRING = '" & frmstring & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Item_CODE"
                    CMBCODE.DataSource = dt
                    CMBCODE.DisplayMember = "Item_CODE"
                    CMBCODE.Text = ""
                End If
                CMBCODE.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCODE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCODE.Validating
        Try
            If CMBCODE.Text.Trim <> "" Then
                pcase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (edit = False) Or (edit = True And LCase(CMBCODE.Text) <> LCase(tempItemCODE)) Then
                    dt = objclscommon.search("item_CODE", "", "ItemMaster", " and item_CODE = '" & CMBCODE.Text.Trim & "' And item_cmpid = " & CmpId & " And item_locationid = " & Locationid & " And item_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Item Code Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbratetype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbratetype.GotFocus
        Try
            If cmbratetype.Text.Trim = "" Then fillRATETYPE(cmbratetype, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbratetype_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbratetype.Validating
        Try
            If cmbratetype.Text.Trim <> "" Then RATETYPEVALIDATE(cmbratetype, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtrate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrate.Validating
        Try
            If Val(txtrate.Text.Trim) > 0 And cmbratetype.Text.Trim <> "" Then
                If Not checkRATETYPE() Then
                    MsgBox("Rate already Present in Grid below")
                    Exit Sub
                End If

                fillgrid()
                cmbratetype.Text = ""
                txtrate.Clear()
                cmbratetype.Focus()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function checkRATETYPE() As Boolean
        Try
            Dim bln As Boolean = True
            For Each row As DataGridViewRow In GRIDRATE.Rows
                If (gridDoubleClick = True And tempRow <> row.Index) Or gridDoubleClick = False Then
                    If cmbratetype.Text.Trim = row.Cells(gratetype.Index).Value Then bln = False
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillgrid()

        If gridDoubleClick = False Then
            GRIDRATE.Rows.Add(cmbratetype.Text.Trim, Val(txtrate.Text.Trim))
        ElseIf gridDoubleClick = True Then
            GRIDRATE.Item("GRATETYPE", tempRow).Value = cmbratetype.Text.Trim
            GRIDRATE.Item("GRATE", tempRow).Value = Val(txtrate.Text.Trim)
            gridDoubleClick = False
        End If

        GRIDRATE.ClearSelection()

    End Sub

    Private Sub GRIDRATE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRATE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDRATE.Item("GRATETYPE", e.RowIndex).Value <> Nothing Then
                gridDoubleClick = True
                tempRow = e.RowIndex
                cmbratetype.Text = GRIDRATE.Item("GRATETYPE", e.RowIndex).Value
                txtrate.Text = GRIDRATE.Item("GRATE", e.RowIndex).Value
                cmbratetype.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDRATE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDRATE.KeyDown
        If e.KeyCode = Keys.Delete Then
            GRIDRATE.Rows.RemoveAt(GRIDRATE.CurrentRow.Index)
        End If
    End Sub

    Private Sub TXTHSNCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTHSNCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectHSN
                OBJLEDGER.STRSEARCH = " AND HSN_TYPE='GOODS'"
                OBJLEDGER.ShowDialog()

                If OBJLEDGER.TEMPCODE <> "" Then
                    TXTHSNCODE.Text = OBJLEDGER.TEMPCODE
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemMaster_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName <> "MONOGRAM" And frmstring = "MERCHANT" Then cmbcategory.BackColor = Color.LemonChiffon
            If ClientName = "DHANLAXMI" Or ClientName = "TULSI" Then
                LBLNAME.Visible = True
                CMBNAME.Visible = True
            End If
            If ClientName = "TULSI" Then
                LBLOURQUALITY.Visible = True
                CMBQUALITY.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(sender As Object, e As EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Enter(sender As Object, e As EventArgs) Handles cmbcategory.Enter
        Try
            If cmbcategory.Text.Trim = "" Then fillCATEGORY(cmbcategory, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Enter(sender As Object, e As EventArgs) Handles CMBDEPARTMENT.Enter
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(sender As Object, e As EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, edit, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'  AND LEDGERS.ACC_TYPE='ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS' ", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTOPVALUE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTOPVALUE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBSUBCATEGORY_Validating(sender As Object, e As CancelEventArgs) Handles CMBSUBCATEGORY.Validating
        Try
            If CMBSUBCATEGORY.Text.Trim <> "" Then SUBCATEGORYVALIDATE(CMBSUBCATEGORY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFOLD_Validating(sender As Object, e As CancelEventArgs) Handles CMBFOLD.Validating
        Try
            If CMBFOLD.Text.Trim <> "" Then FOLDVALIDATE(CMBFOLD, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFOLD_Enter(sender As Object, e As EventArgs) Handles CMBFOLD.Enter
        Try
            If CMBFOLD.Text.Trim = "" Then FILLFOLD(CMBFOLD, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBSUBCATEGORY_Enter(sender As Object, e As EventArgs) Handles CMBSUBCATEGORY.Enter
        Try
            If CMBSUBCATEGORY.Text.Trim = "" Then FILLSUBCATEGORY(CMBSUBCATEGORY, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class