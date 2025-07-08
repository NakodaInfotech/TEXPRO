
Imports BL

Public Class DyeingConsumption

    Public FRMSTRING As String
    Dim edit As Boolean = False
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Sub fillPROG(ByRef cmbProg As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbProg.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" distinct mfg_prgno ", "", " ALLMFGMaster ", " and mfg_cmpid=" & CmpId & " and mfg_Yearid=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "mfg_prgno"
                    cmbProg.DataSource = dt
                    cmbProg.DisplayMember = "mfg_prgno"
                    cmbProg.Text = ""
                End If
                cmbProg.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FillCombo()
        If CMBDYEING.Text.Trim = "" Then filldyeing(CMBDYEING)
        If CMBCOLOR.Text.Trim = "" Then fillCOLOR(CMBCOLOR)
        If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " AND PROCESS_TYPE='MFG'", False)
        If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
    End Sub

    Private Sub CostConsumptionFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fillPROG(CMBPROG)
        FillCombo()
    End Sub

    Private Sub CMBPROG_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMBPROG.KeyPress
        numdotkeypress(e, CMBPROG, Me)
    End Sub

    Private Sub CMBPROG_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPROG.Validating
        Try
            If CMBPROG.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" mfg_prgno ", "", " ALLMFGMaster ", " and mfg_prgno='" & CMBPROG.Text.Trim & "' and mfg_cmpid=" & CmpId & " and mfg_Yearid=" & YearId)
                If dt.Rows.Count = 0 Then
                    MsgBox("invalid Program No")
                    e.Cancel = True
                    Exit Sub
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDYEING_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDYEING.Validating
        Try
            If CMBDYEING.Text.Trim <> "" Then dyeingvalidate(CMBDYEING, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDYEING_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBDYEING.Validated
        If CMBDYEING.Text <> "" Then CMBDYEING.Enabled = False
    End Sub

    Private Sub CMBCOLOR_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBCOLOR.Validating
        Try
            If CMBCOLOR.Text.Trim <> "" Then COLORvalidate(CMBCOLOR, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CostConsumptionFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub getFromToDate()
        a1 = DatePart(DateInterval.Day, dtfrom.Value)
        a2 = DatePart(DateInterval.Month, dtfrom.Value)
        a3 = DatePart(DateInterval.Year, dtfrom.Value)
        fromD = "(" & a3 & "," & a2 & "," & a1 & ")"

        a11 = DatePart(DateInterval.Day, dtto.Value)
        a12 = DatePart(DateInterval.Month, dtto.Value)
        a13 = DatePart(DateInterval.Year, dtto.Value)
        toD = "(" & a13 & "," & a12 & "," & a11 & ")"
    End Sub

    Private Sub CMBMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMERCHANT.Enter
        Try
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMERCHANT.Validating
        Try
            If CMBMERCHANT.Text.Trim <> "" Then itemvalidate(CMBMERCHANT, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try
            Dim OBJCONSUME As New consumedesign
            If RDBPRGDTLS.Checked = True Then
                OBJCONSUME.FRMSTRING = "PROGCUNSUMPTIONDTLS"
            ElseIf RDBPROCESSDTLS.Checked = True Then
                OBJCONSUME.FRMSTRING = "PROCESSCUNSUMPTIONDTLS"
            ElseIf RBPROGRAMCOST.Checked = True Then
                OBJCONSUME.FRMSTRING = "PROGCOSTDTLS"
            ElseIf RBPROGRAMCOSTSUMM.Checked = True Then
                OBJCONSUME.FRMSTRING = "PROGCOSTSUMM"
            ElseIf RBMERCHANTCOSTDTLS.Checked = True Then
                OBJCONSUME.FRMSTRING = "MERCHANTCOSTDTLS"
            ElseIf RBMERCHANTCOSTSUMM.Checked = True Then
                OBJCONSUME.FRMSTRING = "MERCHANTCOSTSUMM"
            End If

            If RDBPRGDTLS.Checked = True Or RDBPROCESSDTLS.Checked = True Then
                OBJCONSUME.CONDITION = "{CONSUMTION_COST_VIEW.YEARID}= " & YearId

                If CMBPROG.Text.Trim <> "" Then OBJCONSUME.CONDITION = OBJCONSUME.CONDITION & " and {CONSUMTION_COST_VIEW.PROGRAM}='" & CMBPROG.Text.Trim & "'"
                If CMBDYEING.Text.Trim <> "" Then OBJCONSUME.CONDITION = OBJCONSUME.CONDITION & " and {CONSUMTION_COST_VIEW.CHART}='" & CMBDYEING.Text.Trim & "'"
                If CMBCOLOR.Text.Trim <> "" Then OBJCONSUME.CONDITION = OBJCONSUME.CONDITION & " and {CONSUMTION_COST_VIEW.COLOR}='" & CMBCOLOR.Text.Trim & "'"
                If cmbprocess.Text.Trim <> "" Then OBJCONSUME.CONDITION = OBJCONSUME.CONDITION & " and {CONSUMTION_COST_VIEW.PROCESS}='" & cmbprocess.Text.Trim & "'"
                If CMBITEMNAME.Text.Trim <> "" Then OBJCONSUME.CONDITION = OBJCONSUME.CONDITION & " and {CONSUMTION_COST_VIEW.ITEMNAME_CONSUME}='" & CMBITEMNAME.Text.Trim & "'"

            ElseIf RBPROGRAMCOST.Checked = True Or RBPROGRAMCOSTSUMM.Checked = True Or RBMERCHANTCOSTDTLS.Checked = True Or RBMERCHANTCOSTSUMM.Checked = True Then
                OBJCONSUME.CONDITION = "{MFGMASTER.MFG_YEARID}= " & YearId

                If CMBPROG.Text.Trim <> "" Then OBJCONSUME.CONDITION = OBJCONSUME.CONDITION & " and {MFGMASTER.MFG_PRGNO}='" & CMBPROG.Text.Trim & "'"
                If CMBDYEING.Text.Trim <> "" Then OBJCONSUME.CONDITION = OBJCONSUME.CONDITION & " and {DYEINGRECIPE.DYEING_NO}='" & CMBDYEING.Text.Trim & "'"
                If CMBCOLOR.Text.Trim <> "" Then OBJCONSUME.CONDITION = OBJCONSUME.CONDITION & " and {COLORMASTER.COLOR_NAME}='" & CMBCOLOR.Text.Trim & "'"
                If CMBMERCHANT.Text.Trim <> "" Then OBJCONSUME.CONDITION = OBJCONSUME.CONDITION & " and {ITEMMASTER.ITEM_NAME}='" & CMBMERCHANT.Text.Trim & "'"
                If cmbprocess.Text.Trim <> "" Then OBJCONSUME.CONDITION = OBJCONSUME.CONDITION & " and {PROCESSMASTER.PROCESS_NAME}='" & cmbprocess.Text.Trim & "'"

            End If

            If chkdate.Checked = True Then
                getFromToDate()
                OBJCONSUME.CONDITION = OBJCONSUME.CONDITION & " and ({@date} in date " & fromD & " to date " & toD & ")"
                OBJCONSUME.PERIOD = Format(dtfrom.Value.Date, "dd/MM/yyyy") & " - " & Format(dtto.Value.Date, "dd/MM/yyyy")
            Else
                OBJCONSUME.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If Val(TXTCOST.Text.Trim) <> 0 Then OBJCONSUME.FILTERCOST = Val(TXTCOST.Text.Trim)
            OBJCONSUME.MdiParent = MDIMain
            OBJCONSUME.Show()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbprocess_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprocess.Enter
        If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " ", False)
    End Sub
End Class