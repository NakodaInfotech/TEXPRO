
Imports BL

Public Class CategoryDetails

    Public frmstring As String      'Used for form Category or GRade

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CategoryDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Then   'for Exit
            showform(False, "", 0)
        End If
    End Sub

    Private Sub CMDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEDIT.Click
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("NAME"), GRIDBILL.GetFocusedRowCellValue("ID"))
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CategoryDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If frmstring = "CATEGORY" Then
                Me.Text = "Category Master"
            ElseIf frmstring = "SUBCATEGORY" Then
                Me.Text = "Sub Category Master"
            ElseIf frmstring = "FOLD" Then
                Me.Text = "Fold Master"
            ElseIf frmstring = "MATERIAL TYPE" Then
                Me.Text = "Material Type Master"
            ElseIf frmstring = "QUALITY" Then
                Me.Text = "Quality Master"
                GOURQUALITY.Visible = True
                GCATEGORY.Visible = True
            ElseIf frmstring = "WEAVER" Then
                Me.Text = "Weaver Master"
            ElseIf frmstring = "PROCESSTYPE" Then
                Me.Text = "Process Type Master"
            ElseIf frmstring = "MERCHANT" Then
                Me.Text = "Merchant Master"
            ElseIf frmstring = "COLOR" Then
                Me.Text = "Color Master"
            ElseIf frmstring = "DEPARTMENT" Then
                Me.Text = "Department Master"
            ElseIf frmstring = "PRINTING TYPE" Then
                Me.Text = "Printing Type Master"
            ElseIf frmstring = "PIECE TYPE" Then
                Me.Text = "Piece Type Master"
            ElseIf frmstring = "ISSUEMERCHANT" Then
                Me.Text = "Issue Merchant Master"
            ElseIf frmstring = "RATE TYPE" Then
                Me.Text = "Rate Type Master"
            ElseIf frmstring = "STAMP" Then
                Me.Text = "Stamp Master"
            ElseIf frmstring = "PARTYGROUP" Then
                Me.Text = "Party Group Master"
            ElseIf frmstring = "GODOWN" Then
                Me.Text = "Godown Master"
            ElseIf frmstring = "CONTRACTOR" Then
                Me.Text = "Contractor Master"
            End If
            fillgrid()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster

        If frmstring = "CATEGORY" Then
            dttable = objClsCommon.search(" category_name AS NAME, category_id AS ID", "", "categorymaster", " and category_cmpid = " & CmpId & " and category_Locationid = " & Locationid & " and category_Yearid = " & YearId & " ORDER BY CATEGORYMASTER.CATEGORY_NAME")
        ElseIf frmstring = "SUBCATEGORY" Then
            dttable = objClsCommon.search(" SUBCATEGORY_name AS NAME, SUBCATEGORY_id AS ID", "", "SUBCATEGORYmaster", " and SUBCATEGORY_cmpid = " & CmpId & " and SUBCATEGORY_Locationid = " & Locationid & " and SUBCATEGORY_Yearid = " & YearId & " ORDER BY SUBCATEGORYMASTER.SUBCATEGORY_NAME")
        ElseIf frmstring = "FOLD" Then
            dttable = objClsCommon.search(" FOLD_name AS NAME, FOLD_id AS ID", "", "FOLDmaster", " and FOLD_cmpid = " & CmpId & " and FOLD_Locationid = " & Locationid & " and FOLD_Yearid = " & YearId & " ORDER BY FOLDMASTER.FOLD_NAME")
        ElseIf frmstring = "MATERIAL TYPE" Then
            dttable = objClsCommon.search(" material_name AS NAME, material_id AS ID", "", "materialtypemaster", " and material_cmpid = " & CmpId & " and material_Locationid = " & Locationid & " and material_Yearid = " & YearId)
        ElseIf frmstring = "QUALITY" Then
            dttable = objClsCommon.search(" QUALITYMASTER.QUALITY_name AS NAME, QUALITYMASTER.QUALITY_id AS ID, OURQUALITYMASTER.QUALITY_NAME AS OURQUALITY, ISNULL(CATEGORYMASTER.CATEGORY_NAME,'') AS CATEGORY", "", "QUALITYmaster LEFT OUTER JOIN QUALITYMASTER AS OURQUALITYMASTER ON QUALITYMASTER.QUALITY_OURQUALITYID = OURQUALITYMASTER.QUALITY_ID LEFT OUTER JOIN CATEGORYMASTER ON QUALITYMASTER.QUALITY_CATEGORYID = CATEGORYMASTER.CATEGORY_ID", " and QUALITYMASTER.QUALITY_Yearid = " & YearId & " ORDER BY QUALITYMASTER.QUALITY_NAME")
        ElseIf frmstring = "WEAVER" Then
            dttable = objClsCommon.search(" WEAVER_name AS NAME, WEAVER_id AS ID", "", "WEAVERmaster", " and WEAVER_cmpid = " & CmpId & " and WEAVER_Locationid = " & Locationid & " and WEAVER_Yearid = " & YearId)
        ElseIf frmstring = "PROCESSTYPE" Then
            dttable = objClsCommon.search(" PROCESSTYPE_name AS NAME, PROCESSTYPE_id AS ID", "", "PROCESSTYPEmaster", " and PROCESSTYPE_cmpid = " & CmpId & " and PROCESSTYPE_Locationid = " & Locationid & " and PROCESSTYPE_Yearid = " & YearId)
        ElseIf frmstring = "MERCHANT" Then
            dttable = objClsCommon.search(" MERCHANT_name AS NAME, MERCHANT_id AS ID", "", "MERCHANTmaster", " and MERCHANT_cmpid = " & CmpId & " and MERCHANT_Locationid = " & Locationid & " and MERCHANT_Yearid = " & YearId)
        ElseIf frmstring = "COLOR" Then
            dttable = objClsCommon.search(" COLOR_name AS NAME, COLOR_id AS ID", "", "COLORmaster", " and COLOR_cmpid = " & CmpId & " and COLOR_Locationid = " & Locationid & " and COLOR_Yearid = " & YearId)
        ElseIf frmstring = "DEPARTMENT" Then
            dttable = objClsCommon.search(" DEPARTMENT_name AS NAME, DEPARTMENT_id AS ID", "", "DEPARTMENTmaster", " and DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENT_Locationid = " & Locationid & " and DEPARTMENT_Yearid = " & YearId)
        ElseIf frmstring = "PRINTING TYPE" Then
            dttable = objClsCommon.search(" PRINTINGTYPE_name AS NAME, PRINTINGTYPE_id AS ID", "", "printingtypemaster", " and PRINTINGTYPE_cmpid = " & CmpId & " and PRINTINGTYPE_Locationid = " & Locationid & " and PRINTINGTYPE_Yearid = " & YearId)
        ElseIf frmstring = "PIECE TYPE" Then
            dttable = objClsCommon.search(" PIECETYPE_name AS NAME, PIECETYPE_id AS ID", "", "PIECEtypemaster", " and PIECETYPE_cmpid = " & CmpId & " and PIECETYPE_Locationid = " & Locationid & " and PIECETYPE_Yearid = " & YearId)
        ElseIf frmstring = "ISSUEMERCHANT" Then
            dttable = objClsCommon.search(" ISSUEMERCHANT_name AS NAME, ISSUEMERCHANT_id AS ID", "", "ISSUEMERCHANTmaster", " and ISSUEMERCHANT_cmpid = " & CmpId & " and ISSUEMERCHANT_Locationid = " & Locationid & " and ISSUEMERCHANT_Yearid = " & YearId)
        ElseIf frmstring = "RATE TYPE" Then
            dttable = objClsCommon.search(" RATETYPE_name AS NAME, RATETYPE_id AS ID", "", "RATEtypemaster", " and RATETYPE_cmpid = " & CmpId & " and RATETYPE_Locationid = " & Locationid & " and RATETYPE_Yearid = " & YearId)
        ElseIf frmstring = "STAMP" Then
            dttable = objClsCommon.search(" STAMP_name AS NAME, STAMP_id AS ID", "", "STAMPmaster", " and STAMP_cmpid = " & CmpId & " and STAMP_Locationid = " & Locationid & " and STAMP_Yearid = " & YearId)
        ElseIf frmstring = "PARTYGROUP" Then
            dttable = objClsCommon.search(" PG_name AS NAME, PG_id AS ID", "", "partygroupmaster", " and PG_cmpid = " & CmpId & " and PG_Locationid = " & Locationid & " and PG_Yearid = " & YearId)
        ElseIf frmstring = "GODOWN" Then
            dttable = objClsCommon.search(" GODOWN_name AS NAME, GODOWN_id AS ID", "", "GODOWNmaster", " and GODOWN_cmpid = " & CmpId & " and GODOWN_Locationid = " & Locationid & " and GODOWN_Yearid = " & YearId)
        ElseIf frmstring = "CONTRACTOR" Then
            dttable = objClsCommon.search(" CONTRACTOR_name AS NAME, CONTRACTOR_id AS ID", "", "CONTRACTORmaster", " and CONTRACTOR_cmpid = " & CmpId & " and CONTRACTOR_Locationid = " & Locationid & " and CONTRACTOR_Yearid = " & YearId)
        End If
        GRIDBILLDETAILS.DataSource = dttable


    End Sub

    Private Sub GRIDBILL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDBILL.DoubleClick
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("NAME"), GRIDBILL.GetFocusedRowCellValue("ID"))
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String, ByVal id As Integer)
        Try
            Dim objCategorymaster As New CategoryMaster
            objCategorymaster.edit = editval
            objCategorymaster.MdiParent = MDIMain
            objCategorymaster.frmString = frmstring
            objCategorymaster.TempName = name
            objCategorymaster.TempID = id
            objCategorymaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDADDNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDADDNEW.Click
        Try
            showform(False, "", 0)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ExcelExport_Click(sender As Object, e As EventArgs) Handles ExcelExport.Click
        Try
            Dim PATH As String = Application.StartupPath & "\" & frmstring & " Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = frmstring & " Details"
            GRIDBILL.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, frmstring & " Details", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)
        Catch ex As Exception
            MsgBox(frmstring & " Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class