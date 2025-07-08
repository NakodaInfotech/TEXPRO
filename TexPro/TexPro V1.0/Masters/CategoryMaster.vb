Imports System.ComponentModel
Imports BL

Public Class CategoryMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public frmString As String       'Used for form Category or GRade
    Public TempName As String        'Used for tempname while edit mode
    Public TempID As Integer         'Used for tempname while edit mode
    Public edit As Boolean           'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            If txtname.Text.Trim = "" Then Exit Sub
            'for search
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (edit = False) Or (edit = True And LCase(TempName) <> LCase(txtname.Text.Trim)) Then
                If frmString = "CATEGORY" Then
                    dt = objclscommon.search("category_name", "", "CategoryMaster", " and category_name = '" & txtname.Text.Trim & "' and category_cmpid =" & CmpId & " and category_Locationid =" & Locationid & " and category_Yearid =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Category Name Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "SUBCATEGORY" Then
                    dt = objclscommon.search("SUBcategory_name", "", "SUBCategoryMaster", " and SUBcategory_name = '" & txtname.Text.Trim & "' and SUBcategory_Yearid =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Sub Category Name Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "FOLD" Then
                    dt = objclscommon.search("FOLD_name", "", "FOLDMaster", " and FOLD_name = '" & txtname.Text.Trim & "' and FOLD_Yearid =" & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Sub Category Name Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "MATERIAL TYPE" Then
                    dt = objclscommon.search("material_name", "", "MaterialTypeMaster", " and material_name = '" & txtname.Text.Trim & "' and material_cmpid = " & CmpId & " and material_Locationid = " & Locationid & " and material_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Material Type Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "QUALITY" Then
                    dt = objclscommon.search("QUALITY_name", "", "QUALITYMaster", " and QUALITY_name = '" & txtname.Text.Trim & "' and QUALITY_cmpid = " & CmpId & " and QUALITY_Locationid = " & Locationid & " and QUALITY_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("QUALITY Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "WEAVER" Then
                    dt = objclscommon.search("WEAVER_name", "", "WEAVERMaster", " and WEAVER_name = '" & txtname.Text.Trim & "' and WEAVER_cmpid = " & CmpId & " and WEAVER_Locationid = " & Locationid & " and WEAVER_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("WEAVER Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "PROCESSTYPE" Then
                    dt = objclscommon.search("PROCESSTYPE_name", "", "PROCESSTYPEMaster", " and PROCESSTYPE_name = '" & txtname.Text.Trim & "' and PROCESSTYPE_cmpid = " & CmpId & " and PROCESSTYPE_Locationid = " & Locationid & " and PROCESSTYPE_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Process Type Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "MERCHANT" Then
                    dt = objclscommon.search("MERCHANT_name", "", "MERCHANTMaster", " and MERCHANT_name = '" & txtname.Text.Trim & "' and MERCHANT_cmpid = " & CmpId & " and MERCHANT_Locationid = " & Locationid & " and MERCHANT_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("MERCHANT Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "COLOR" Then
                    dt = objclscommon.search("COLOR_name", "", "COLORMaster", " and COLOR_name = '" & txtname.Text.Trim & "' and COLOR_cmpid = " & CmpId & " and COLOR_Locationid = " & Locationid & " and COLOR_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("COLOR Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "DEPARTMENT" Then
                    dt = objclscommon.search("DEPARTMENT_name", "", "DEPARTMENTMaster", " and DEPARTMENT_name = '" & txtname.Text.Trim & "' and DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENT_Locationid = " & Locationid & " and DEPARTMENT_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("DEPARTMENT Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "PRINTING TYPE" Then
                    dt = objclscommon.search("PRINTINGTYPE_name", "", "PRINTINGTypeMaster", " and PRINTINGTYPE_name = '" & txtname.Text.Trim & "' and PRINTINGTYPE_cmpid = " & CmpId & " and PRINTINGTYPE_Locationid = " & Locationid & " and PRINTINGTYPE_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("PRINTING Type Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "PIECE TYPE" Then
                    dt = objclscommon.search("PIECETYPE_name", "", "PIECETypeMaster", " and PIECETYPE_name = '" & txtname.Text.Trim & "' and PIECETYPE_cmpid = " & CmpId & " and PIECETYPE_Locationid = " & Locationid & " and PIECETYPE_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Piece Type Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "ISSUEMERCHANT" Then
                    dt = objclscommon.search("ISSUEMERCHANT_name", "", "ISSUEMERCHANTMASTER", " and ISSUEMERCHANT_name = '" & txtname.Text.Trim & "' and ISSUEMERCHANT_cmpid = " & CmpId & " and ISSUEMERCHANT_Locationid = " & Locationid & " and ISSUEMERCHANT_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Merchant Type Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "RATE TYPE" Then
                    dt = objclscommon.search("RATETYPE_name", "", "RATETypeMaster", " and RATETYPE_name = '" & txtname.Text.Trim & "' and RATETYPE_cmpid = " & CmpId & " and RATETYPE_Locationid = " & Locationid & " and RATETYPE_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Rate Type Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "STAMP" Then
                    dt = objclscommon.search("STAMP_name", "", "STAMPMaster", " and STAMP_name = '" & txtname.Text.Trim & "' and STAMP_cmpid = " & CmpId & " and STAMP_Locationid = " & Locationid & " and STAMP_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Stamp Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "PARTYGROUP" Then
                    dt = objclscommon.search("PG_name", "", "PARTYGROUPMASTER", " and PG_name = '" & txtname.Text.Trim & "' and PG_cmpid = " & CmpId & " and PG_Locationid = " & Locationid & " and PG_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("PArty Group Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                        e.Cancel = True
                    End If
                ElseIf frmString = "GODOWN" Then
                    dt = objclscommon.search("GODOWN_name", "", "GODOWNMaster", " and GODOWN_name = '" & txtname.Text.Trim & "' and GODOWN_cmpid = " & CmpId & " and GODOWN_Locationid = " & Locationid & " and GODOWN_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("GODOWN Already Exists", MsgBoxStyle.Critical, "TRXPRO")
                        e.Cancel = True
                    End If
                ElseIf frmString = "CONTRACTOR" Then
                    dt = objclscommon.search("CONTRACTOR_name", "", "CONTRACTORMaster", " and CONTRACTOR_name = '" & txtname.Text.Trim & "' and CONTRACTOR_Yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("CONTRACTOR Already Exists", MsgBoxStyle.Critical, "TEXPRO")
                        e.Cancel = True
                    End If
                End If
            End If
            pcase(txtname)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(txtname.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            If frmString = "CATEGORY" Then
                Dim objclscategorymaster As New ClsCategoryMaster
                objclscategorymaster.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclscategorymaster.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = objclscategorymaster.Update()
                    MsgBox("Details Updated")
                    edit = False

                End If

            ElseIf frmString = "SUBCATEGORY" Then
                Dim objclsSUBcategorymaster As New ClsSubCategoryMaster
                objclsSUBcategorymaster.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclsSUBcategorymaster.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = objclsSUBcategorymaster.Update()
                    MsgBox("Details Updated")
                    edit = False

                End If

            ElseIf frmString = "FOLD" Then
                Dim OBJFOLD As New ClsFoldMaster
                OBJFOLD.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJFOLD.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJFOLD.Update()
                    MsgBox("Details Updated")
                    edit = False

                End If

            ElseIf frmString = "MATERIAL TYPE" Then
                Dim objclsMaterialTypeMaster As New ClsMaterialTypeMaster
                objclsMaterialTypeMaster.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclsMaterialTypeMaster.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = objclsMaterialTypeMaster.Update()
                    MsgBox("Details Updated")
                    edit = False

                End If

            ElseIf frmString = "QUALITY" Then
                Dim OBJ As New ClsQualityMaster

                'FOR OURQUALITY
                If CMBQUALITY.Text.Trim = "" Then
                    alParaval.Add(txtname.Text.Trim)
                Else
                    alParaval.Add(CMBQUALITY.Text.Trim)
                End If
                alParaval.Add(CMBCATEGORY.Text.Trim)
                OBJ.alParaval = alParaval


                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.UPDATE()
                    edit = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "WEAVER" Then
                Dim OBJ As New ClsWeaverMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    edit = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "PROCESSTYPE" Then
                Dim OBJ As New ClsProcessTypeMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.UPDATE()
                    edit = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "MERCHANT" Then
                Dim OBJ As New ClsMerchantMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    edit = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "COLOR" Then
                Dim OBJ As New ClsColorMaster
                OBJ.alParaval = alParaval
                OBJ.alParaval.Add(CMBCOLORTYPE.Text.Trim)

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.SAVE()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.UPDATE()
                    edit = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "DEPARTMENT" Then
                Dim OBJ As New ClsDepartmentMaster
                OBJ.alParaval = alParaval

                alParaval.Add(CHKINVENTORY.Checked)

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    MsgBox("Details Updated")
                    edit = False

                End If

            ElseIf frmString = "PRINTING TYPE" Then
                Dim OBJ As New ClsPrintingTypeMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    MsgBox("Details Updated")
                    edit = False

                End If

            ElseIf frmString = "PIECE TYPE" Then
                Dim OBJ As New ClsPieceTypeMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    MsgBox("Details Updated")
                    edit = False

                End If

            ElseIf frmString = "ISSUEMERCHANT" Then
                Dim OBJ As New ClsIssueMerchantMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    MsgBox("Details Updated")
                    edit = False

                End If

            ElseIf frmString = "RATE TYPE" Then
                Dim OBJ As New ClsRateTypeMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    MsgBox("Details Updated")
                    edit = False

                End If

            ElseIf frmString = "STAMP" Then
                Dim OBJ As New ClsStampMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    edit = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "PARTYGROUP" Then
                Dim OBJ As New ClsPartyGroupMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    edit = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "GODOWN" Then
                Dim OBJ As New ClsGodownMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    edit = False
                    MsgBox("Details Updated")
                End If

            ElseIf frmString = "CONTRACTOR" Then
                Dim OBJ As New ClsCONTRACTORMaster
                OBJ.alParaval = alParaval

                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = OBJ.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(TempID)
                    IntResult = OBJ.Update()
                    edit = False
                    MsgBox("Details Updated")
                End If

            End If

            clear()
            txtname.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            Ep.SetError(txtname, "Fill Name")
            bln = False
        End If

        If ClientName = "DHANLAXMI" And frmString = "COLOR" And CMBCOLORTYPE.Text.Trim = "" Then
            Ep.SetError(CMBCOLORTYPE, "Select Color Type")
            bln = False
        End If
        Return bln
    End Function

    Private Sub CMDDELETE_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try
            If edit = True Then
                If MsgBox("Delete Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                If frmString = "QUALITY" Then
                    Dim OBJQUALITY As New ClsQualityMaster
                    OBJQUALITY.alParaval.Add(TempName)
                    OBJQUALITY.alParaval.Add(CmpId)
                    OBJQUALITY.alParaval.Add(YearId)
                    Dim DTTABLE As DataTable = OBJQUALITY.DELETE()
                    MsgBox(DTTABLE.Rows(0).Item(0))

                ElseIf frmString = "COLOR" Then
                    Dim OBJCOLOR As New ClsColorMaster
                    OBJCOLOR.alParaval.Add(TempName)
                    OBJCOLOR.alParaval.Add(CmpId)
                    OBJCOLOR.alParaval.Add(YearId)
                    Dim DTTABLE As DataTable = OBJCOLOR.DELETE()
                    MsgBox(DTTABLE.Rows(0).Item(0))


                End If
                edit = False
                clear()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub clear()
        txtname.Clear()
        txtremarks.Clear()
        CMBQUALITY.Text = ""
        CMBCATEGORY.Text = ""
    End Sub

    Private Sub CategoryMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        End If
    End Sub

    Private Sub CategoryMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            If frmString = "CATEGORY" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "Category Master"
                lblgroup.Text = "Category"
                lbl.Text = "Enter Category" & vbNewLine & "(e.g.  CHEMICAL,..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" category_name", "", "CategoryMaster", " and category_id = " & TempID & " and category_cmpid = " & CmpId & " and category_locationid = " & Locationid & " and category_yearid = " & YearId)

            ElseIf frmString = "SUBCATEGORY" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "Sub Category Master"
                lblgroup.Text = "Sub Category"
                lbl.Text = "Enter Sub Category"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" SUBcategory_name", "", "SUBCategoryMaster", " and SUBcategory_id = " & TempID & " and SUBcategory_yearid = " & YearId)

            ElseIf frmString = "FOLD" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "Fold Master"
                lblgroup.Text = "Fold"
                lbl.Text = "Enter Fold"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" FOLD_name", "", "FOLDMASTER", " and FOLD_id = " & TempID & " and FOLD_yearid = " & YearId)

            ElseIf frmString = "MATERIAL TYPE" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Material Master"
                lblgroup.Text = "Material"
                lbl.Text = "Enter Material Type " & vbNewLine & "(e.g.  Raw,Trading Material..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" material_name", "", "MaterialTypeMaster", " and material_id = " & TempID & " and material_cmpid = " & CmpId & " and material_Locationid = " & Locationid & " and material_yearid = " & YearId)

            ElseIf frmString = "QUALITY" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "Quality Master"
                lblgroup.Text = "Quality"
                lbl.Text = "Enter Quality" & vbNewLine & "(e.g.  40*60,70*90..., etc. )"
                If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, False)
                LBLOURQUALITY.Visible = True
                CMBQUALITY.Visible = True
                lblcategory.Visible = True
                CMBCATEGORY.Visible = True
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" QUALITYMASTER.QUALITY_name, OURQUALITYMASTER.QUALITY_NAME AS OURQUALITY, ISNULL(CATEGORYMASTER.CATEGORY_NAME,'') AS CATEGORY", "", " QUALITYMaster LEFT OUTER JOIN QUALITYMASTER AS OURQUALITYMASTER ON QUALITYMASTER.QUALITY_OURQUALITYID = OURQUALITYMASTER.QUALITY_ID LEFT OUTER JOIN CATEGORYMASTER ON QUALITYMASTER.QUALITY_CATEGORYID = CATEGORYMASTER.CATEGORY_ID", " and QUALITYMASTER.QUALITY_id = " & TempID & " and QUALITYMASTER.QUALITY_yearid = " & YearId)

            ElseIf frmString = "WEAVER" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "Weaver Master"
                lblgroup.Text = "Weaver"
                lbl.Text = "Enter Weaver"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" WEAVER_name", "", "WEAVERMaster", " and WEAVER_id = " & TempID & " and WEAVER_cmpid = " & CmpId & " and WEAVER_locationid = " & Locationid & " and WEAVER_yearid = " & YearId)

            ElseIf frmString = "PROCESSTYPE" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "Process Type Master"
                lblgroup.Text = "Process Type"
                lbl.Text = "Enter Process Type"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" PROCESSTYPE_name", "", "PROCESSTYPEMaster", " and PROCESSTYPE_id = " & TempID & " and PROCESSTYPE_cmpid = " & CmpId & " and PROCESSTYPE_locationid = " & Locationid & " and PROCESSTYPE_yearid = " & YearId)

            ElseIf frmString = "MERCHANT" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "Merchant Master"
                lblgroup.Text = "Merchant"
                lbl.Text = "Enter Merchant Name" & vbNewLine & "(e.g.  XYZ,ABC..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" MERCHANT_name", "", "MERCHANTMaster", " and MERCHANT_id = " & TempID & " and MERCHANT_cmpid = " & CmpId & " and MERCHANT_locationid = " & Locationid & " and MERCHANT_yearid = " & YearId)

            ElseIf frmString = "COLOR" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "Color Master"
                lblgroup.Text = "Color"
                lbl.Text = "Enter Color" & vbNewLine & "(e.g.  GREEN,BLUE..., etc. )"
                LBLCOLORTYPE.Visible = True
                CMBCOLORTYPE.Visible = True
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" COLOR_name, ISNULL(COLOR_TYPE,'MEDIUM') AS COLORTYPE", "", "COLORMaster", " and COLOR_id = " & TempID & " and COLOR_cmpid = " & CmpId & " and COLOR_locationid = " & Locationid & " and COLOR_yearid = " & YearId)

            ElseIf frmString = "DEPARTMENT" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'DEPARTMENT MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                CHKINVENTORY.Visible = True
                Me.Text = "Department Master"
                lblgroup.Text = "Department"
                lbl.Text = "Enter Department" & vbNewLine & "(e.g.  PRINTING,CUTTING..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" DEPARTMENT_name, ISNULL(DEPARTMENT_INVENTORY,0) AS INVENTORY", "", "DEPARTMENTMaster", " and DEPARTMENT_id = " & TempID & " and DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENT_locationid = " & Locationid & " and DEPARTMENT_yearid = " & YearId)

            ElseIf frmString = "PRINTING TYPE" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "PRINTING Master"
                lblgroup.Text = "Printing Type"
                lbl.Text = "Enter Printing Type " & vbNewLine & "(e.g.  Procian,Pigment..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" PRINTINGTYPE_name", "", "PRINTINGTypeMaster", " and PRINTINGTYPE_id = " & TempID & " and PRINTINGTYPE_cmpid = " & CmpId & " and PRINTINGTYPE_Locationid = " & Locationid & " and PRINTINGTYPE_yearid = " & YearId)

            ElseIf frmString = "PIECE TYPE" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Piece Master"
                lblgroup.Text = "Piece Type"
                lbl.Text = "Enter Piece Type " & vbNewLine & "(e.g.  Fresh,GoodCut..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" PIECETYPE_name", "", "PIECETypeMaster", " and PIECETYPE_id = " & TempID & " and PIECETYPE_cmpid = " & CmpId & " and PIECETYPE_Locationid = " & Locationid & " and pieceTYPE_yearid = " & YearId)


            ElseIf frmString = "ISSUEMERCHANT" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "Issue Merchant Master"
                lblgroup.Text = "Merchant"
                lbl.Text = "Enter Merchant " & vbNewLine & "(e.g.  Golmaal,Rukmani..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" ISSUEMERCHANT_name", "", "ISSUEMERCHANTMaster", " and ISSUEMERCHANT_id = " & TempID & " and ISSUEMERCHANT_cmpid = " & CmpId & " and ISSUEMERCHANT_Locationid = " & Locationid & " and ISSUEMERCHANT_yearid = " & YearId)


            ElseIf frmString = "RATE TYPE" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "RATE TYPE Master"
                lblgroup.Text = "Rate Type"
                lbl.Text = "Enter Rate Type " & vbNewLine & "(e.g.  Sale Rate,Pur Rate..., etc. )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" RATETYPE_name", "", "RATETypeMaster", " and RATETYPE_id = " & TempID & " and RATETYPE_cmpid = " & CmpId & " and RATETYPE_Locationid = " & Locationid & " and RATETYPE_yearid = " & YearId)

            ElseIf frmString = "STAMP" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MERCHANT MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "Stamp Master"
                lblgroup.Text = "Stamp"
                lbl.Text = "Enter Stamp" & vbNewLine & "(e.g.   )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" STAMP_name", "", "STAMPMaster", " and STAMP_id = " & TempID & " and STAMP_cmpid = " & CmpId & " and STAMP_locationid = " & Locationid & " and STAMP_yearid = " & YearId)

            ElseIf frmString = "PARTYGROUP" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'MERCHANT MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)
                Me.Text = "Party Group Master"
                lblgroup.Text = "Party Group"
                lbl.Text = "Enter Party Group" & vbNewLine & "(e.g.   )"
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" PG_name", "", "PARTYGROUPMaster", " and PG_id = " & TempID & " and PG_cmpid = " & CmpId & " and PG_locationid = " & Locationid & " and PG_yearid = " & YearId)

            ElseIf frmString = "GODOWN" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "GODOWN Master"
                lblgroup.Text = "Godown Name"
                lbl.Text = "Enter Godown Name"""
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" GODOWN_name, GODOWN_REMARKS ", "", "GODOWNMaster", " and GODOWN_id = " & TempID & " and GODOWN_cmpid = " & CmpId & " and GODOWN_Locationid = " & Locationid & " and GODOWN_yearid = " & YearId)

            ElseIf frmString = "CONTRACTOR" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)

                Me.Text = "CONTRACTOR Master"
                lblgroup.Text = "CONTRACTOR Name"
                lbl.Text = "Enter CONTRACTOR Name"""
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                If edit = True Then dttable = objCommon.search(" CONTRACTOR_name, CONTRACTOR_REMARKS ", "", "CONTRACTORMaster", " and CONTRACTOR_id = " & TempID & " and CONTRACTOR_cmpid = " & CmpId & " and CONTRACTOR_Locationid = " & Locationid & " and CONTRACTOR_yearid = " & YearId)

            End If

            If dttable.Rows.Count > 0 Then
                txtname.Text = dttable.Rows(0).Item(0).ToString
                If frmString = "DEPARTMENT" Then CHKINVENTORY.Checked = Convert.ToBoolean(dttable.Rows(0).Item("INVENTORY"))
                If frmString = "COLOR" Then CMBCOLORTYPE.Text = dttable.Rows(0).Item("COLORTYPE")
                If frmString = "QUALITY" Then
                    CMBQUALITY.Text = dttable.Rows(0).Item("OURQUALITY")
                    CMBCATEGORY.Text = dttable.Rows(0).Item("CATEGORY")
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub cmbcategory_Enter(sender As Object, e As EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcategory_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then CATEGORYVALIDATE(CMBCATEGORY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class