
Imports BL
Imports System.Windows.Forms
Imports System.Data

Public Class QualityPriceMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer
    Public edit As Boolean = False
    Public tempprocessName As String
    Public tempprocessId As Integer
    Public FRMSTRING As String

    Sub FillCombo()
        Try
            If FRMSTRING = "QUALITY" Then
                fillQUALITY(cmbQuality, False)
            ElseIf FRMSTRING = "MERCHANT" Then
                fillitemname(cmbQuality, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            ElseIf FRMSTRING = "ITEM" Then
                fillitemname(cmbQuality, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub save()
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

          
            alParaval.Add(cmbQuality.Text.Trim)
            alParaval.Add(txtrate.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            If FRMSTRING = "QUALITY" Then
                Dim obclsexpns As New ClsQualityPriceMaster
                obclsexpns.alParaval = alParaval
                IntResult = obclsexpns.save()
            ElseIf FRMSTRING = "MERCHANT" Then
                Dim obclsexpns As New ClsMerchantPriceMaster
                obclsexpns.alParaval = alParaval
                IntResult = obclsexpns.save()
            ElseIf FRMSTRING = "ITEM" Then
                Dim obclsexpns As New ClsItemPriceMaster
                obclsexpns.alParaval = alParaval
                IntResult = obclsexpns.save()
            End If
            MsgBox("Details Added")
            cmbQuality.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub update()
        Try
            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList


            alParaval.Add(cmbQuality.Text.Trim)
            alParaval.Add(txtrate.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            If FRMSTRING = "QUALITY" Then
                Dim obclsexpns As New ClsQualityPriceMaster
                obclsexpns.alParaval = alParaval
                IntResult = obclsexpns.Update()
            ElseIf FRMSTRING = "MERCHANT" Then
                Dim obclsexpns As New ClsMerchantPriceMaster
                obclsexpns.alParaval = alParaval
                IntResult = obclsexpns.Update()
            ElseIf FRMSTRING = "ITEM" Then
                Dim obclsexpns As New ClsItemPriceMaster
                obclsexpns.alParaval = alParaval
                IntResult = obclsexpns.Update()

                Dim TEMPMSG As Integer = MsgBox("Update Rate in all Respective Tables?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    obclsexpns.alParaval = alParaval
                    obclsexpns.UPDATERATE()
                End If

            End If
            MsgBox("Details Added")
            cmbQuality.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If cmbQuality.Text.Trim.Length = 0 Then
            If FRMSTRING = "QUALITY" Then
                Ep.SetError(cmbQuality, "Fill Quality Name")
            ElseIf FRMSTRING = "MERCHANT" Then
                Ep.SetError(cmbQuality, "Fill Merchant Name")
            ElseIf FRMSTRING = "ITEM" Then
                Ep.SetError(cmbQuality, "Fill Item Name")
            End If
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        GRIDRATE.RowCount = 0
        cmbQuality.Text = ""
        txtrate.Clear()
        edit = False
    End Sub

    Private Sub QualityPriceMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'EXPENSE MASTER'")
            'USERADD = DTROW(0).Item(1)
            'USEREDIT = DTROW(0).Item(2)
            'USERVIEW = DTROW(0).Item(3)
            'USERDELETE = DTROW(0).Item(4)

            If FRMSTRING = "QUALITY" Then
                Me.Text = "Quality Price List"
                GQuality.HeaderText = "Quality"
            ElseIf FRMSTRING = "MERCHANT" Then
                Me.Text = "Merchant Price List"
                GQuality.HeaderText = "Merchant"
            ElseIf FRMSTRING = "ITEM" Then
                Me.Text = "Store Item Price List"
                GQuality.HeaderText = "Item Name"
            End If

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                cmbQuality.Text = ""
            End If
            FillCombo()


            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable
            If FRMSTRING = "QUALITY" Then
                DT = OBJCMN.search(" ISNULL(QUALITYMASTER.QUALITY_name, '') AS NAME, QUALITYPRICELIST.QUALITY_RATE AS RATE ", "", " QUALITYMASTER INNER JOIN QUALITYPRICELIST ON QUALITYMASTER.QUALITY_id = QUALITYPRICELIST.QUALITY_ID AND QUALITYMASTER.QUALITY_cmpid = QUALITYPRICELIST.QUALITY_cmpid AND QUALITYMASTER.QUALITY_locationid = QUALITYPRICELIST.QUALITY_locationid AND QUALITYMASTER.QUALITY_yearid = QUALITYPRICELIST.QUALITY_yearid ", "  AND QUALITYMASTER.QUALITY_CMPID = " & CmpId & " AND QUALITYMASTER.QUALITY_LOCATIONID = " & Locationid & " AND QUALITYMASTER.QUALITY_YEARID = " & YearId & "")
            ElseIf FRMSTRING = "MERCHANT" Then
                DT = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_name, '') AS NAME, MERCHANTPRICELIST.MERCHANT_RATE AS RATE ", "", " ITEMMASTER INNER JOIN MERCHANTPRICELIST ON ITEMMASTER.ITEM_id = MERCHANTPRICELIST.MERCHANT_ID AND ITEMMASTER.ITEM_yearid = MERCHANTPRICELIST.MERCHANT_yearid ", " AND ITEMMASTER.ITEM_CMPID = " & CmpId & " AND ITEMMASTER.ITEM_LOCATIONID = " & Locationid & " AND ITEMMASTER.ITEM_YEARID = " & YearId & "")
            ElseIf FRMSTRING = "ITEM" Then
                DT = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_name, '') AS NAME, ITEMPRICELIST.ITEM_RATE AS RATE ", "", " ITEMMASTER INNER JOIN ITEMPRICELIST ON ITEMMASTER.ITEM_id = ITEMPRICELIST.ITEM_ID AND ITEMMASTER.ITEM_yearid = ITEMPRICELIST.ITEM_yearid ", " AND ITEMMASTER.ITEM_CMPID = " & CmpId & " AND ITEMMASTER.ITEM_LOCATIONID = " & Locationid & " AND ITEMMASTER.ITEM_YEARID = " & YearId & "")
            End If
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDRATE.Rows.Add(DTROW("NAME"), DTROW("RATE"))
                Next
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If gridDoubleClick = False Then
            GRIDRATE.Rows.Add(cmbQuality.Text.Trim, Val(txtrate.Text.Trim))
        ElseIf gridDoubleClick = True Then

            GRIDRATE.Rows(tempRow).Cells(GQuality.Index).Value = cmbQuality.Text.Trim
            GRIDRATE.Rows(tempRow).Cells(grate.Index).Value = Format(Val(txtrate.Text.Trim), "0.00")

            gridDoubleClick = False
        End If
        GRIDRATE.FirstDisplayedScrollingRowIndex = GRIDRATE.RowCount - 1
        cmbQuality.Text = ""
        txtrate.Clear()
    End Sub

    Private Sub GRIDRATE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRATE.CellDoubleClick
        If e.RowIndex >= 0 And GRIDRATE.Item(GQuality.Index, e.RowIndex).Value <> Nothing Then
            gridDoubleClick = True
            cmbQuality.Text = GRIDRATE.Item(GQuality.Index, e.RowIndex).Value
            cmbQuality.Enabled = False
            txtrate.Text = GRIDRATE.Item(grate.Index, e.RowIndex).Value
            tempRow = e.RowIndex
            txtrate.Focus()
        End If
    End Sub

    Private Sub GRIDRATE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDRATE.KeyDown
        If e.KeyCode = Keys.Delete Then
            If GRIDRATE.CurrentRow.Index < 0 Then Exit Sub
            'DELETE FROM TABLE ALSO
            Dim TEMPMSG As Integer = MsgBox("Delete Price List Of " & GRIDRATE.CurrentRow.Cells(GQuality.Index).Value & "?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim DT As New DataTable
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(GRIDRATE.CurrentRow.Cells(GQuality.Index).Value)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                If FRMSTRING = "QUALITY" Then
                    Dim OBJ As New ClsQualityPriceMaster
                    OBJ.alParaval = ALPARAVAL
                    DT = OBJ.DELETE()
                ElseIf FRMSTRING = "MERCHANT" Then
                    Dim OBJ As New ClsMerchantPriceMaster
                    OBJ.alParaval = ALPARAVAL
                    DT = OBJ.DELETE
                ElseIf FRMSTRING = "ITEM" Then
                    Dim OBJ As New ClsItemPriceMaster
                    OBJ.alParaval = ALPARAVAL
                    DT = OBJ.DELETE
                End If
                GRIDRATE.Rows.RemoveAt(GRIDRATE.CurrentRow.Index)
            End If
        End If
    End Sub

    Private Sub cmbQuality_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbQuality.GotFocus
        Try
            If FRMSTRING = "QUALITY" Then
                If cmbQuality.Text.Trim = "" Then fillQUALITY(cmbQuality, False)
            ElseIf FRMSTRING = "MERCHANT" Then
                If cmbQuality.Text.Trim = "" Then fillitemname(cmbQuality, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            ElseIf FRMSTRING = "ITEM" Then
                If cmbQuality.Text.Trim = "" Then fillitemname(cmbQuality, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtrate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtrate.Validating
        Try
            If cmbQuality.Text.Trim = "" Or Val(txtrate.Text.Trim) = 0 Then
                MsgBox("Select Proper Data", MsgBoxStyle.Critical, CmpName)
                cmbQuality.Focus()
                Exit Sub
            End If
            If cmbQuality.Text.Trim <> "" And Val(txtrate.Text.Trim) > 0 Then
                cmbQuality.Enabled = True
                cmbQuality.Focus()
                If gridDoubleClick = False Then
                    save()
                Else
                    update()
                End If
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, CmpName)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        Try
            numdotkeypress(e, txtrate, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub QualityPriceMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbQuality_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbQuality.Validating
        Try
            If cmbQuality.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                If FRMSTRING = "QUALITY" Then
                    If cmbQuality.Text.Trim <> "" Then QUALITYVALIDATE(cmbQuality, e, Me)
                    DT = OBJCMN.search(" ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY_ID ", "", " QUALITYMASTER INNER JOIN QUALITYPRICELIST ON QUALITYMASTER.QUALITY_id = QUALITYPRICELIST.QUALITY_ID AND QUALITYMASTER.QUALITY_cmpid = QUALITYPRICELIST.QUALITY_cmpid AND QUALITYMASTER.QUALITY_locationid = QUALITYPRICELIST.QUALITY_locationid AND QUALITYMASTER.QUALITY_yearid = QUALITYPRICELIST.QUALITY_yearid ", "  AND QUALITYMASTER.QUALITY_name='" & cmbQuality.Text.Trim & "' AND QUALITYMASTER.QUALITY_CMPID = " & CmpId & " AND QUALITYMASTER.QUALITY_LOCATIONID = " & Locationid & " AND QUALITYMASTER.QUALITY_YEARID = " & YearId & "")
                ElseIf FRMSTRING = "MERCHANT" Then
                    If cmbQuality.Text.Trim <> "" Then itemvalidate(cmbQuality, e, Me, "AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
                    DT = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_name, '') AS ITEM_ID ", "", " ITEMMASTER INNER JOIN MERCHANTPRICELIST ON ITEMMASTER.ITEM_id = MERCHANTPRICELIST.MERCHANT_ID AND ITEMMASTER.ITEM_cmpid = MERCHANTPRICELIST.MERCHANT_cmpid AND ITEMMASTER.ITEM_locationid = MERCHANTPRICELIST.MERCHANT_locationid AND ITEMMASTER.ITEM_yearid = MERCHANTPRICELIST.MERCHANT_yearid ", "  AND ITEMMASTER.ITEM_name='" & cmbQuality.Text.Trim & "' AND ITEMMASTER.ITEM_CMPID = " & CmpId & " AND ITEMMASTER.ITEM_LOCATIONID = " & Locationid & " AND ITEMMASTER.ITEM_YEARID = " & YearId & "")
                ElseIf FRMSTRING = "ITEM" Then
                    If cmbQuality.Text.Trim <> "" Then itemvalidate(cmbQuality, e, Me, "AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
                    DT = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_name, '') AS ITEM_ID ", "", " ITEMMASTER INNER JOIN ITEMPRICELIST ON ITEMMASTER.ITEM_id = ITEMPRICELIST.ITEM_ID AND ITEMMASTER.ITEM_cmpid = ITEMPRICELIST.ITEM_cmpid AND ITEMMASTER.ITEM_locationid = ITEMPRICELIST.ITEM_locationid AND ITEMMASTER.ITEM_yearid = ITEMPRICELIST.ITEM_yearid ", "  AND ITEMMASTER.ITEM_name='" & cmbQuality.Text.Trim & "' AND ITEMMASTER.ITEM_CMPID = " & CmpId & " AND ITEMMASTER.ITEM_LOCATIONID = " & Locationid & " AND ITEMMASTER.ITEM_YEARID = " & YearId & "")
                End If
                If DT.Rows.Count > 0 Then
                    MsgBox(" Rate already Filled")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class