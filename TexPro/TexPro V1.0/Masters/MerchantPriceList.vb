
Imports System.ComponentModel
Imports BL

Public Class MerchantPriceList

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean = False

    Sub FillCombo()
        Try
            fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillPIECETYPE(CMBPIECETYPE)
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

    Sub SAVE()
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList


            alParaval.Add(CMBMERCHANT.Text.Trim)
            alParaval.Add(CMBPIECETYPE.Text.Trim)
            alParaval.Add(Val(TXTRATE.Text.Trim))
            alParaval.Add(Val(TXTWHITE.Text.Trim))
            alParaval.Add(Val(TXTCREAM.Text.Trim))
            alParaval.Add(Val(TXTLIGHT.Text.Trim))
            alParaval.Add(Val(TXTDARK.Text.Trim))
            alParaval.Add(Val(TXTEXTRADARK.Text.Trim))
            alParaval.Add(Val(TXTRAINBOW.Text.Trim))
            alParaval.Add(Val(TXTFRESHRATE.Text.Trim))
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim obclsexpns As New ClsMerchantPriceMaster
            obclsexpns.alParaval = alParaval
            IntResult = obclsexpns.SAVE()
            MsgBox("Details Added")
            CMBMERCHANT.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub UPDATERECORD()
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList


            alParaval.Add(CMBMERCHANT.Text.Trim)
            alParaval.Add(CMBPIECETYPE.Text.Trim)
            alParaval.Add(Val(TXTRATE.Text.Trim))
            alParaval.Add(Val(TXTWHITE.Text.Trim))
            alParaval.Add(Val(TXTCREAM.Text.Trim))
            alParaval.Add(Val(TXTLIGHT.Text.Trim))
            alParaval.Add(Val(TXTDARK.Text.Trim))
            alParaval.Add(Val(TXTEXTRADARK.Text.Trim))
            alParaval.Add(Val(TXTRAINBOW.Text.Trim))
            alParaval.Add(Val(TXTFRESHRATE.Text.Trim))
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim obclsexpns As New ClsMerchantPriceMaster
            obclsexpns.alParaval = alParaval
            IntResult = obclsexpns.UPDATE()

            MsgBox("Details Added")
            CMBMERCHANT.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If CMBMERCHANT.Text.Trim.Length = 0 Then
            EP.SetError(CMBMERCHANT, "Fill Merchant Name")
            bln = False
        End If
        If CMBPIECETYPE.Text.Trim.Length = 0 Then
            EP.SetError(CMBPIECETYPE, "Fill Piece Type")
            bln = False
        End If
        If Val(TXTRATE.Text.Trim) <= 0 Then
            EP.SetError(TXTRATE, "Enter Rate")
            bln = False
        End If
        Return bln
    End Function

    Sub clear()
        CMBMERCHANT.Text = ""
        TXTRATE.Clear()
        TXTWHITE.Clear()
        TXTCREAM.Clear()
        TXTLIGHT.Clear()
        TXTDARK.Clear()
        TXTEXTRADARK.Clear()
        TXTRAINBOW.Clear()
        TXTFRESHRATE.Clear()
        EDIT = False
    End Sub

    Private Sub MerchantPriceList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FillCombo()
            fillgrid()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_name, '') AS QUALITYNAME, ISNULL(PIECETYPE_NAME,'') AS PIECETYPE, MERCHANTPRICELIST.MERCHANT_RATE AS RATE, ISNULL(MERCHANTPRICELIST.MERCHANT_WHITE,0) AS WHITE, ISNULL(MERCHANTPRICELIST.MERCHANT_CREAM,0) AS CREAM, ISNULL(MERCHANTPRICELIST.MERCHANT_LIGHT,0) AS LIGHT, ISNULL(MERCHANTPRICELIST.MERCHANT_DARK,0) AS DARK, ISNULL(MERCHANTPRICELIST.MERCHANT_EXTRADARK,0) AS EXTRADARK, ISNULL(MERCHANTPRICELIST.MERCHANT_RAINBOW,0) AS RAINBOW, ISNULL(MERCHANTPRICELIST.MERCHANT_FRESHRATE,0) AS FRESHRATE ", "", " ITEMMASTER INNER JOIN MERCHANTPRICELIST ON ITEMMASTER.ITEM_id = MERCHANTPRICELIST.MERCHANT_ID INNER JOIN PIECETYPEMASTER ON MERCHANTPRICELIST.MERCHANT_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id ", " AND ITEMMASTER.ITEM_YEARID = " & YearId & "")
            GRIDBILLDETAILS.DataSource = DT
            If DT.Rows.Count > 0 Then
                GRIDBILL.FocusedRowHandle = GRIDBILL.RowCount - 1
                GRIDBILL.TopRowIndex = GRIDBILL.RowCount - 15
            End If
            CMBMERCHANT.Text = ""
            CMBPIECETYPE.Text = ""
            TXTRATE.Clear()
            TXTWHITE.Clear()
            TXTCREAM.Clear()
            TXTLIGHT.Clear()
            TXTDARK.Clear()
            TXTEXTRADARK.Clear()
            TXTRAINBOW.Clear()
            TXTFRESHRATE.Clear()
            CMBMERCHANT.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GRIDBILL.DoubleClick
        Try
            GRIDDOUBLECLICK = True
            CMBMERCHANT.Text = GRIDBILL.GetFocusedRowCellValue("QUALITYNAME")
            CMBPIECETYPE.Text = GRIDBILL.GetFocusedRowCellValue("PIECETYPE")
            TXTRATE.Text = Val(GRIDBILL.GetFocusedRowCellValue("RATE"))
            TXTWHITE.Text = Val(GRIDBILL.GetFocusedRowCellValue("WHITE"))
            TXTCREAM.Text = Val(GRIDBILL.GetFocusedRowCellValue("CREAM"))
            TXTLIGHT.Text = Val(GRIDBILL.GetFocusedRowCellValue("LIGHT"))
            TXTDARK.Text = Val(GRIDBILL.GetFocusedRowCellValue("DARK"))
            TXTEXTRADARK.Text = Val(GRIDBILL.GetFocusedRowCellValue("EXTRADARK"))
            TXTRAINBOW.Text = Val(GRIDBILL.GetFocusedRowCellValue("RAINBOW"))
            TXTFRESHRATE.Text = Val(GRIDBILL.GetFocusedRowCellValue("FRESHRATE"))
            CMBMERCHANT.Enabled = False
            CMBPIECETYPE.Enabled = False
            TXTRATE.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDRATE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDBILL.KeyDown
        If e.KeyCode = Keys.Delete Then
            If GRIDBILL.GetFocusedRowCellValue("QUALITYNAME") = "" Then Exit Sub

            'DELETE FROM TABLE ALSO
            Dim TEMPMSG As Integer = MsgBox("Delete Price List Of " & GRIDBILL.GetFocusedRowCellValue("QUALITYNAME") & "?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim DT As New DataTable
                Dim ALPARAVAL As New ArrayList

                ALPARAVAL.Add(GRIDBILL.GetFocusedRowCellValue("QUALITYNAME"))
                ALPARAVAL.Add(GRIDBILL.GetFocusedRowCellValue("PIECETYPE"))
                ALPARAVAL.Add(YearId)

                Dim OBJ As New ClsMerchantPriceMaster
                OBJ.alParaval = ALPARAVAL
                DT = OBJ.DELETE

                fillgrid()
            End If
        End If
    End Sub

    Private Sub CMBMERCHANT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMERCHANT.GotFocus
        Try
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress, TXTWHITE.KeyPress, TXTCREAM.KeyPress, TXTLIGHT.KeyPress, TXTDARK.KeyPress, TXTEXTRADARK.KeyPress, TXTRAINBOW.KeyPress, TXTFRESHRATE.KeyPress
        Try
            numdotkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MerchantPriceList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub CMBMERCHANT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMERCHANT.Validating
        Try
            If CMBMERCHANT.Text.Trim <> "" Then
                itemvalidate(CMBMERCHANT, e, Me, "AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
                If Not CHECKDUPLICATE() Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEMMASTER.ITEM_name, '') AS ITEM_ID ", "", " ITEMMASTER INNER JOIN MERCHANTPRICELIST ON ITEMMASTER.ITEM_id = MERCHANTPRICELIST.MERCHANT_ID INNER JOIN PIECETYPEMASTER ON MERCHANTPRICELIST.MERCHANT_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id ", "  AND ITEMMASTER.ITEM_name='" & CMBMERCHANT.Text.Trim & "' AND PIECETYPE_NAME = '" & CMBPIECETYPE.Text.Trim & "' AND ITEMMASTER.ITEM_YEARID = " & YearId & "")
            If DT.Rows.Count > 0 Then
                MsgBox(" Rate already Filled")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMBPIECETYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPIECETYPE.Enter
        Try
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPIECETYPE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPIECETYPE.Validating
        Try
            If CMBPIECETYPE.Text.Trim <> "" Then
                PIECETYPEvalidate(CMBPIECETYPE, e, Me)
                If Not CHECKDUPLICATE() Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXCEL_Click(sender As Object, e As EventArgs) Handles CMDEXCEL.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Merchant Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                proc.Kill()
            Next
            opti.SheetName = "Merchant Details"
            GRIDBILL.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Merchant Details", GRIDBILL.VisibleColumns.Count + GRIDBILL.GroupCount)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MerchantPriceList_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName <> "DHANLAXMI" Then
                If ClientName <> "TULSI" Then
                    TXTWHITE.Visible = False
                    GWHITE.Visible = False
                    TXTFRESHRATE.Left = TXTRATE.Left + TXTRATE.Width
                Else
                    GWHITE.Caption = "Job Rate"
                    TXTFRESHRATE.Left = TXTWHITE.Left + TXTWHITE.Width
                End If
                TXTCREAM.Visible = False
                GCREAM.Visible = False
                TXTLIGHT.Visible = False
                GLIGHT.Visible = False
                TXTDARK.Visible = False
                GDARK.Visible = False
                TXTEXTRADARK.Visible = False
                GEXTRADARK.Visible = False
                TXTRAINBOW.Visible = False
                GRAINBOW.Visible = False
            Else
                GRATE.Caption = "Medium"
                GFRESHRATE.Visible = False
                TXTFRESHRATE.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validated(sender As Object, e As EventArgs) Handles TXTRATE.Validated
        Try
            If ClientName = "DHANLAXMI" And Val(TXTRATE.Text.Trim) > 0 And GRIDDOUBLECLICK = False Then
                TXTWHITE.Text = Val(TXTRATE.Text)
                TXTCREAM.Text = Val(TXTRATE.Text)
                TXTLIGHT.Text = Val(TXTRATE.Text)
                TXTDARK.Text = Val(TXTRATE.Text)
                TXTEXTRADARK.Text = Val(TXTRATE.Text)
                TXTRAINBOW.Text = Val(TXTRATE.Text)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRAINBOW_Validating(sender As Object, e As CancelEventArgs) Handles TXTRAINBOW.Validating
        Try
            If ClientName <> "DHANLAXMI" Then Exit Sub

            If CMBMERCHANT.Text.Trim = "" Or CMBPIECETYPE.Text.Trim = "" Or Val(TXTRATE.Text.Trim) = 0 Then
                MsgBox("Select Proper Data", MsgBoxStyle.Critical, CmpName)
                CMBMERCHANT.Focus()
                Exit Sub
            End If
            If CMBMERCHANT.Text.Trim <> "" And CMBPIECETYPE.Text.Trim <> "" And Val(TXTRATE.Text.Trim) > 0 Then
                CMBMERCHANT.Enabled = True
                CMBPIECETYPE.Enabled = True
                CMBMERCHANT.Focus()

                If GRIDDOUBLECLICK = False Then
                    SAVE()
                Else
                    UPDATERECORD()
                End If
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, CmpName)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFRESHRATE_Validating(sender As Object, e As CancelEventArgs) Handles TXTFRESHRATE.Validating
        Try
            If ClientName = "DHANLAXMI" Then Exit Sub

            If CMBMERCHANT.Text.Trim = "" Or CMBPIECETYPE.Text.Trim = "" Or Val(TXTRATE.Text.Trim) = 0 Then
                MsgBox("Select Proper Data", MsgBoxStyle.Critical, CmpName)
                CMBMERCHANT.Focus()
                Exit Sub
            End If
            If CMBMERCHANT.Text.Trim <> "" And CMBPIECETYPE.Text.Trim <> "" And Val(TXTRATE.Text.Trim) > 0 Then
                CMBMERCHANT.Enabled = True
                CMBPIECETYPE.Enabled = True
                CMBMERCHANT.Focus()

                If GRIDDOUBLECLICK = False Then
                    SAVE()
                Else
                    UPDATERECORD()
                    GRIDDOUBLECLICK = False
                End If
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical, CmpName)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class