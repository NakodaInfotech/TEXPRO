Imports BL

Public Class MERGEPARAMETER

    Public EDIT As Boolean

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            If cmbOldName.Text.Trim = cmbReplace.Text.Trim Then
                MsgBox("Both Name cannot be same", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            Dim alParaval As New ArrayList
            Dim intresult As Integer

            alParaval.Add(cmbtype.Text)
            alParaval.Add(cmbOldName.Text)
            alParaval.Add(cmbReplace.Text)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(YearId)


            Dim OBJMFG As New ClsCommon()
            OBJMFG.alParaval = alParaval
            intresult = OBJMFG.mergeparameter()
            MsgBox("Item Merge Successfully")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmbtype_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.Validated
        Try
            If cmbtype.Text = "MERCHANT" Then
                If cmbOldName.Text.Trim = "" Then fillitemname(cmbOldName, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
                If cmbReplace.Text.Trim = "" Then fillitemname(cmbReplace, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            ElseIf cmbtype.Text = "ITEM NAME" Then
                If cmbOldName.Text.Trim = "" Then fillitemname(cmbOldName, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM NAME'")
                If cmbReplace.Text.Trim = "" Then fillitemname(cmbReplace, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM NAME'")
            ElseIf cmbtype.Text.Trim = "PIECETYPE" Then
                If cmbOldName.Text.Trim = "" Then fillPIECETYPE(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillPIECETYPE(cmbReplace)
            ElseIf cmbtype.Text.Trim = "COLOR" Then
                If cmbOldName.Text.Trim = "" Then fillCOLOR(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillCOLOR(cmbReplace)
            ElseIf cmbtype.Text.Trim = "CONTRACTOR" Then
                If cmbOldName.Text.Trim = "" Then fillCONTRACTOR(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillCONTRACTOR(cmbReplace)
            ElseIf cmbtype.Text.Trim = "SUPERVISOR" Then
                If cmbOldName.Text.Trim = "" Then fillSUPERVISIOR(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillSUPERVISIOR(cmbReplace)
            ElseIf cmbtype.Text.Trim = "AREA" Then
                If cmbOldName.Text.Trim = "" Then FILLAREA(cmbOldName)
                If cmbReplace.Text.Trim = "" Then FILLAREA(cmbReplace)
            ElseIf cmbtype.Text.Trim = "CATEGORY" Then
                If cmbOldName.Text.Trim = "" Then fillCATEGORY(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then fillCATEGORY(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "SUBCATEGORY" Then
                If cmbOldName.Text.Trim = "" Then FILLSUBCATEGORY(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLSUBCATEGORY(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "FOLD" Then
                If cmbOldName.Text.Trim = "" Then FILLFOLD(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then FILLFOLD(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "CITY" Then
                If cmbOldName.Text.Trim = "" Then fillcity(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillcity(cmbReplace)
            ElseIf cmbtype.Text.Trim = "COUNTRY" Then
                If cmbOldName.Text.Trim = "" Then fillCOUNTRY(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillCOUNTRY(cmbReplace)
            ElseIf cmbtype.Text.Trim = "DEPARTMENT" Then
                If cmbOldName.Text.Trim = "" Then filldepartment(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then filldepartment(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "DESIGN" Then
                If cmbOldName.Text.Trim = "" Then fillDESIGN(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillDESIGN(cmbReplace)
            ElseIf cmbtype.Text.Trim = "QUALITY" Then
                If cmbOldName.Text.Trim = "" Then fillQUALITY(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then fillQUALITY(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "RATETYPE" Then
                If cmbOldName.Text.Trim = "" Then fillRATETYPE(cmbOldName, EDIT)
                If cmbReplace.Text.Trim = "" Then fillitemname(cmbReplace, EDIT)
            ElseIf cmbtype.Text.Trim = "CHART" Then
                If cmbOldName.Text.Trim = "" Then filldyeing(cmbOldName)
                If cmbReplace.Text.Trim = "" Then filldyeing(cmbReplace)
            ElseIf cmbtype.Text.Trim = "SCREEN" Then
                If cmbOldName.Text.Trim = "" Then fillscreen(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillscreen(cmbReplace)
            ElseIf cmbtype.Text.Trim = "STATE" Then
                If cmbOldName.Text.Trim = "" Then fillSTATE(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillSTATE(cmbReplace)
            ElseIf cmbtype.Text.Trim = "UNIT" Then
                If cmbOldName.Text.Trim = "" Then fillunit(cmbOldName)
                If cmbReplace.Text.Trim = "" Then fillunit(cmbReplace)
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class