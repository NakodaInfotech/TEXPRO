
Imports System.ComponentModel
Imports BL

Public Class StockAdjustment
    Public Shared dt_SELECT As New DataTable

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean

    Public edit As Boolean          'used for editing
    Public tempSAno As Integer     'used for poation no while editing
    Dim temprow As Integer
    Public Shared SELECTMFGTABLE As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        EP.Clear()
        tstxtbillno.Clear()
        CMBFROM.Enabled = True
        SADATE.Value = Mydate
        txtremarks.Clear()

        CMBFROM.Text = ""
        cmbjobno.Text = ""
        cmbmerchant.Text = ""
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""

        GRIDSA.RowCount = 0

        SADATE.Enabled = True
        gridDoubleClick = False
        getmaxno()

        lbltotalmtrs.Text = 0
        lbltotalpcs.Text = 0

        txtsrno.Text = 1
        cmbpiecetype.Text = ""
        cmbmerchant.Text = ""
        cmbjobno.Text = ""
        txtcut.Clear()
        cmbdesign.Text = ""
        cmbcolor.Text = ""
        CMBLOTNO.Text = ""
        txtpcs.Clear()
        txtmtrs.Clear()

        txtbalpcs.Clear()
        txtbalmtrs.Clear()

        lbltotalpcs.Text = 0
        lbltotalmtrs.Text = 0

    End Sub

    Sub TOTAL()
        Try
            lbltotalpcs.Text = 0.0

            lbltotalmtrs.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDSA.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    If Val(ROW.Cells(GCUT.Index).Value) <> 0 Then
                        ROW.Cells(GMTRS.Index).Value = Format(Val(ROW.Cells(gpcs.Index).EditedFormattedValue) * Val(ROW.Cells(GCUT.Index).EditedFormattedValue), "0.00")

                    End If
                    lbltotalpcs.Text = Format(Val(lbltotalpcs.Text) + Val(ROW.Cells(gpcs.Index).Value), "0.00")
                    lbltotalmtrs.Text = Format(Val(lbltotalmtrs.Text) + Val(ROW.Cells(GMTRS.Index).Value), "0.00")
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        edit = False
    End Sub

    Private Sub grndate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SADATE.Validating
        If Not datecheck(SADATE.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SA_no),0) + 1 ", "STOCKADJUSTMENT", " AND SA_cmpid=" & CmpId & " and SA_locationid=" & Locationid & " and SA_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTSANO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Function errorvalid() As Boolean
        Try
            Dim bln As Boolean = True



            For Each row As DataGridViewRow In GRIDSA.Rows
                'If row.Cells(GMTRS.Index).Value = 0 Then
                '    EP.SetError(lbltotalmtrs, "Mtrs cannot be zero?")

                '    bln = False
                'End If
            Next
            If GRIDSA.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If


            If Not datecheck(SADATE.Value) Then bln = False

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(TXTSANO.Text)
            alParaval.Add(cmbtype.Text.Trim)
            alParaval.Add(SADATE.Value)

            alParaval.Add(CMBFROM.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(Val(lbltotalpcs.Text))
            alParaval.Add(Val(lbltotalmtrs.Text))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim GRIDSRNO As String = ""
            Dim PIECETYPE As String = ""
            Dim job As String = ""
            Dim ITEMNAME As String = ""
            Dim WIDTH As String = ""
            Dim CUT As String = ""
            Dim DESIGN As String = ""

            Dim COLOR As String = ""
            Dim QUALITY As String = ""
            Dim PCS As String = ""
            Dim MTRS As String = ""

            Dim LOTNO As String = ""          'WHETHER GRN IS DONE FOR THIS LINE


            For Each row As Windows.Forms.DataGridViewRow In GRIDSA.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = row.Cells(gsrno.Index).Value.ToString
                        PIECETYPE = row.Cells(gpiecetype.Index).Value.ToString
                        ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
                        job = row.Cells(GJOBNO.Index).Value.ToString
                        CUT = row.Cells(GCUT.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString

                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        PCS = row.Cells(gpcs.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value.ToString


                    Else

                        GRIDSRNO = GRIDSRNO & "|" & row.Cells(gsrno.Index).Value
                        PIECETYPE = PIECETYPE & "|" & row.Cells(gpiecetype.Index).Value

                        ITEMNAME = ITEMNAME & "|" & row.Cells(GMERCHANT.Index).Value.ToString
                        job = job & "|" & row.Cells(GJOBNO.Index).Value.ToString
                        CUT = CUT & "|" & row.Cells(GCUT.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString

                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        PCS = PCS & "|" & row.Cells(gpcs.Index).Value.ToString

                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value.ToString


                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(job)
            alParaval.Add(CUT)
            alParaval.Add(DESIGN)

            alParaval.Add(COLOR)
            alParaval.Add(LOTNO)
            alParaval.Add(QUALITY)
            alParaval.Add(PCS)
            alParaval.Add(MTRS)



            Dim objclsSA As New ClsSA()
            objclsSA.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsSA.SAVE()
                MsgBox("Details Added")

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempSAno)

                IntResult = objclsSA.UPDATE()
                MsgBox("Details Updated")

            End If
            edit = False


            CLEAR()
            cmbtype.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub STOCKADJUSTMENT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                '  Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
                'Call cmddelete_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.C Then       'for CLEAR
                ' Call cmdclear_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STOCKADJUSTMENT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub SA_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'MFG'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            CLEAR()


            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCHECKING As New ClsSA()
                Dim ALPARAVAL As New ArrayList

                Dim dttable As New DataTable

                ALPARAVAL.Add(tempSAno)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJCHECKING.alParaval = ALPARAVAL

                dttable = OBJCHECKING.selectSA()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        SADATE.Value = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        cmbtype.Text = Convert.ToString(dr("TYPE").ToString)
                        CMBFROM.Text = Convert.ToString(dr("process").ToString)
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)

                        GRIDSA.Rows.Add(dr("GRIDSRNO").ToString, dr("PIECETYPE"), dr("MERCHANT"), dr("JOBNO").ToString, Format(dr("CUT"), "0.00"), dr("DESIGNNO"), dr("COLOR"), dr("LOTNO"), dr("quality"), Format(dr("PCS"), "0.00"), Format(dr("MTRS"), "0.00"))
                        TXTSANO.Text = tempSAno


                    Next
                    TOTAL()
                End If


                chkchange.CheckState = CheckState.Checked
            End If
            If GRIDSA.RowCount > 0 Then
                txtsrno.Text = Val(GRIDSA.Rows(GRIDSA.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If



        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub fillcmb()
        Try
            If CMBFROM.Text.Trim = "" Then FILLPROCESS(CMBFROM, " AND PROCESSMASTER.PROCESS_TYPE<>'FINAL PACKINGSLIP'", edit)
            fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If cmbpiecetype.Text.Trim = "" Then fillPIECETYPE(cmbpiecetype)
            fillDESIGN(cmbdesign, cmbmerchant.Text)
            fillCOLOR(cmbcolor)
            If cmbjobno.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable = OBJCMN.search(" DISTINCT JOBNO ", "", " PACKINGSLIPVIEW", " AND JOBNO <> '' and yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "JOBNO"
                    cmbjobno.DataSource = dt
                    cmbjobno.DisplayMember = "JOBNO"
                    cmbjobno.Text = ""
                End If
                cmbjobno.SelectAll()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            'Dim objgrndetails As New STOCKADJUSTMENTDetails
            'objgrndetails.MdiParent = MDIMain
            'objgrndetails.Show()
            'objgrndetails.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDSA.RowCount = 0

            tempSAno = Val(TXTSANO.Text) - 1
            If tempSAno > 0 Then
                edit = True
                SA_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            tempSAno = Val(TXTSANO.Text) + 1
            getmaxno()
            CLEAR()
            If Val(TXTSANO.Text) - 1 >= tempSAno Then
                edit = True
                SA_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDSA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSA.KeyDown

        Try
            If e.KeyCode = Keys.Delete And GRIDSA.RowCount > 0 Then

                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDSA.Rows.RemoveAt(GRIDSA.CurrentRow.Index)
                getsrno(GRIDSA)
                TOTAL()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Sub fillgrid()

        GRIDSA.Enabled = True

        If gridDoubleClick = True Then
            GRIDSA.Item(gsrno.Index, temprow).Value = Val(txtsrno.Text.Trim)
            GRIDSA.Item(gpiecetype.Index, temprow).Value = cmbpiecetype.Text.Trim
            GRIDSA.Item(GMERCHANT.Index, temprow).Value = cmbmerchant.Text.Trim

            GRIDSA.Item(GDESIGN.Index, temprow).Value = cmbdesign.Text.Trim
            GRIDSA.Item(GQUALITY.Index, temprow).Value = TXTQUALITY.Text.Trim
            GRIDSA.Item(GJOBNO.Index, temprow).Value = cmbjobno.Text.Trim

            GRIDSA.Item(gcolor.Index, temprow).Value = cmbcolor.Text.Trim
            GRIDSA.Item(GCUT.Index, temprow).Value = txtcut.Text.Trim
            GRIDSA.Item(GLOTNO.Index, temprow).Value = CMBLOTNO.Text.Trim
            GRIDSA.Item(gpcs.Index, temprow).Value = Format(Val(txtpcs.Text.Trim), "0.00")
            GRIDSA.Item(GMTRS.Index, temprow).Value = Format(Val(txtmtrs.Text.Trim), "0.00")
            gridDoubleClick = False
        Else

            GRIDSA.Rows.Add(Val(txtsrno.Text), cmbpiecetype.Text.Trim, cmbmerchant.Text.Trim, cmbjobno.Text.Trim, txtcut.Text.Trim, cmbdesign.Text.Trim, cmbcolor.Text.Trim, CMBLOTNO.Text.Trim, TXTQUALITY.Text.Trim, txtpcs.Text.Trim, Val(txtmtrs.Text.Trim))

        End If

        GRIDSA.FirstDisplayedScrollingRowIndex = GRIDSA.RowCount - 1

        txtsrno.Clear()
        getsrno(GRIDSA)
        cmbcolor.Text = ""
        cmbdesign.Text = ""
        txtpcs.Clear()
        TXTQUALITY.Clear()

        txtcut.Clear()
        txtmtrs.Clear()

        If GRIDSA.RowCount > 0 Then
            txtsrno.Text = Val(GRIDSA.Rows(GRIDSA.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If

        txtsrno.Focus()

    End Sub

    Private Sub GRIDSA_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSA.CellDoubleClick
        If e.RowIndex >= 0 And GRIDSA.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then

            gridDoubleClick = True
            txtsrno.Text = GRIDSA.Item(gsrno.Index, e.RowIndex).Value.ToString
            cmbmerchant.Text = GRIDSA.Item(GMERCHANT.Index, e.RowIndex).Value.ToString
            CMBLOTNO.Text = GRIDSA.Item(GLOTNO.Index, e.RowIndex).Value.ToString
            cmbjobno.Text = GRIDSA.Item(GJOBNO.Index, e.RowIndex).Value.ToString

            cmbpiecetype.Text = GRIDSA.Item(gpiecetype.Index, e.RowIndex).Value.ToString
            cmbdesign.Text = GRIDSA.Item(GDESIGN.Index, e.RowIndex).Value.ToString

            cmbcolor.Text = GRIDSA.Item(gcolor.Index, e.RowIndex).Value.ToString
            txtcut.Text = GRIDSA.Item(GCUT.Index, e.RowIndex).Value.ToString
            txtpcs.Text = GRIDSA.Item(gpcs.Index, e.RowIndex).Value.ToString
            txtmtrs.Text = GRIDSA.Item(GMTRS.Index, e.RowIndex).Value.ToString

            temprow = e.RowIndex
            txtsrno.Focus()
        End If
    End Sub


    Private Sub cmbcolor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcolor.GotFocus
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbcolor.Text.Trim = "" And cmbdesign.Text.Trim <> "" Then
                fillCOLOR(cmbcolor, "  INNER JOIN DESIGNRECIPE_DESC ON COLORMASTER.COLOR_id = DESIGNRECIPE_DESC.DESIGN_MATCHINGID AND COLORMASTER.COLOR_cmpid = DESIGNRECIPE_DESC.DESIGN_CMPID AND COLORMASTER.COLOR_locationid = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND COLORMASTER.COLOR_yearid = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID ", " AND  DESIGNRECIPE.DESIGN_NO='" & cmbdesign.Text & "'")
            Else
                If cmbcolor.Text.Trim = "" Then fillCOLOR(cmbcolor)
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbcolor.Text.Trim <> "" And cmbdesign.Text.Trim <> "" Then
                COLORvalidate(cmbcolor, e, Me, " INNER JOIN DESIGNRECIPE_DESC ON COLORMASTER.COLOR_id = DESIGNRECIPE_DESC.DESIGN_MATCHINGID AND COLORMASTER.COLOR_cmpid = DESIGNRECIPE_DESC.DESIGN_CMPID AND COLORMASTER.COLOR_locationid = DESIGNRECIPE_DESC.DESIGN_LOCATIONID AND COLORMASTER.COLOR_yearid = DESIGNRECIPE_DESC.DESIGN_YEARID INNER JOIN DESIGNRECIPE ON DESIGNRECIPE_DESC.DESIGN_ID = DESIGNRECIPE.DESIGN_ID AND DESIGNRECIPE_DESC.DESIGN_CMPID = DESIGNRECIPE.DESIGN_CMPID AND DESIGNRECIPE_DESC.DESIGN_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND DESIGNRECIPE_DESC.DESIGN_YEARID = DESIGNRECIPE.DESIGN_YEARID", " AND  DESIGNRECIPE.DESIGN_NO='" & cmbdesign.Text & "'")
            Else
                If cmbcolor.Text.Trim <> "" Then COLORvalidate(cmbcolor, e, Me)
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub CMBMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Enter
        Try
            If cmbtype.Text = "STORE" Then

                If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            Else
                If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbmerchant_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Validated
        Try
            If cmbtype.Text = "STORE" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable

                dt = OBJCMN.search(" isnull(-1*sum(QTY),0) ", "  ", " VIEW_STORE_STOCK  ", " and date<='" & Format(SADATE.Value, "MM/dd/yyyy") & "' AND ITEMNAME='" & cmbmerchant.Text & "' and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    txtpcs.Text = dt.Rows(0).Item(0)

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CMBMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmerchant.Validating
        Try
            If cmbtype.Text = "STORE" Then

                If cmbmerchant.Text.Trim = "" Then itemvalidate(cmbmerchant, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
            Else
                If cmbmerchant.Text.Trim <> "" Then itemvalidate(cmbmerchant, e, Me, " AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' OR ITEMMASTER.ITEM_FRMSTRING = 'ITEM')", "MERCHANT")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub cmbdesign_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesign.GotFocus
        Try
            If cmbdesign.Text.Trim = "" Then fillDESIGN(cmbdesign, cmbmerchant.Text)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdesign_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdesign.Validating

        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbdesign.Text.Trim <> "" Then
                pcase(cmbdesign)
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search("DESIGN_NO ", "", " DESIGNRECIPE INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid ", "  and DESIGN_NO = '" & cmbdesign.Text.Trim & "' and DESIGN_cmpid = " & CmpId & " and DESIGN_Locationid = " & Locationid & " and DESIGN_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbdesign.Text.Trim
                    Dim tempmsg As Integer = MsgBox("DESIGN not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        cmbdesign.Text = a
                        Dim OBJDESIGN As New DesignRecipe
                        OBJDESIGN.TEMPDESIGNNO = cmbdesign.Text.Trim()
                        OBJDESIGN.TEMPMERCHANT = cmbmerchant.Text.Trim()
                        OBJDESIGN.ShowDialog()
                        dt = OBJCMN.search("DESIGN_NO ", "", "  DESIGNRECIPE INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid ", "  and DESIGN_NO = '" & cmbdesign.Text.Trim & "' and DESIGN_cmpid = " & CmpId & " and DESIGN_Locationid = " & Locationid & " and DESIGN_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbdesign.DataSource
                            If cmbdesign.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbdesign.Text.Trim)
                                    cmbdesign.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CMBFROM_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROM.Validated
        Try
            If CMBFROM.Text.Trim <> "" Then CMBFROM.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbpiecetype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpiecetype.GotFocus
        Try
            If cmbpiecetype.Text.Trim = "" Then fillPIECETYPE(cmbpiecetype)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbpiecetype_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbpiecetype.Validating
        Try
            If cmbpiecetype.Text.Trim <> "" Then PIECETYPEvalidate(cmbpiecetype, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBJOBNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbjobno.GotFocus
        Try
            If cmbjobno.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search(" DISTINCT JOBNO ", "", " PACKINGSLIPVIEW", " AND PROCESSNAME='" & CMBFROM.Text & "' and yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "JOBNO"
                    cmbjobno.DataSource = dt
                    cmbjobno.DisplayMember = "JOBNO"
                    cmbjobno.Text = ""
                End If
                cmbjobno.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            GRIDSA.RowCount = 0
            tempSAno = Val(tstxtbillno.Text)
            If tempSAno > 0 Then
                edit = True
                SA_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtmtrs_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmtrs.Validating
        Try
            If cmbtype.Text <> "STORE" Then
                If Val(txtmtrs.Text) <> 0 Then
                    fillgrid()


                End If

            Else
                If Val(txtpcs.Text) <> 0 Then
                    fillgrid()


                End If

            End If
            TOTAL()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOTNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBLOTNO.Validating
        Try
            If CMBLOTNO.Text <> "" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search(" DISTINCT QUALITY_NAME ", "", "     QUALITYMASTER INNER JOIN CHECKINGMASTER ON QUALITYMASTER.QUALITY_id = CHECKINGMASTER.CHECK_NEWQUALITYID AND QUALITYMASTER.QUALITY_cmpid = CHECKINGMASTER.CHECK_CMPID AND QUALITYMASTER.QUALITY_locationid = CHECKINGMASTER.CHECK_LOCATIONID AND QUALITYMASTER.QUALITY_yearid = CHECKINGMASTER.CHECK_YEARID ", " AND CHECK_GRNNO=" & CMBLOTNO.Text & " and CHECK_cmpid=" & CmpId & " and CHECK_locationid = " & Locationid & " and CHECK_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    TXTQUALITY.Text = dt.Rows(0).Item(0)
                End If
                If CMBLOTNO.Text <> "" Then

                    'CHECKING WHETHER LOTNO IS ALREADY PRESENT OR NOT
                    dt = OBJCMN.search(" SA_NO AS NO, SA_GRIDSRNO AS GRIDSRNO ", "", " STOCKADJUSTMENT_DESC ", " AND SA_CMPID = " & CmpId & " AND SA_LOCATIONID = " & Locationid & " AND SA_YEARID = " & YearId & " AND SA_LOTNO = " & CMBLOTNO.Text.Trim)
                    If dt.Rows.Count > 0 Then
                        If (edit = False) Or (edit = True And dt.Rows(0).Item("NO") <> tempSAno) Then
                            MsgBox("Lot Already Present in Adjustment No " & dt.Rows(0).Item("NO") & " Line No " & dt.Rows(0).Item("GRIDSRNO"), MsgBoxStyle.Critical)
                            CMBLOTNO.Text = ""
                            Exit Sub
                        End If
                    End If

                    'CHECKING WHETHER LOT IS ALREADY PRESENT IN GRID BELOW
                    For Each ROW As DataGridViewRow In GRIDSA.Rows
                        If ROW.Cells(GLOTNO.Index).Value = CMBLOTNO.Text.Trim Then
                            If gridDoubleClick = False Or (gridDoubleClick = True And temprow <> ROW.Index) Then
                                MsgBox("Lot Already Present in Grid Below", MsgBoxStyle.Critical)
                                CMBLOTNO.Text = ""
                                Exit Sub
                            End If
                        End If
                    Next


                    dt = OBJCMN.search(" isnull(sum(pcs),0),isnull(sum(mtrs),0) ", "  ", " view_summary_mfg1  ", " and date<='" & Format(SADATE.Value, "MM/dd/yyyy") & "' AND lotno=" & CMBLOTNO.Text & " and cmpid=" & CmpId & " and locationid = " & Locationid & " and yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        txtbalpcs.Text = dt.Rows(0).Item(0)
                        txtbalmtrs.Text = dt.Rows(0).Item(1)
                        txtpcs.Text = dt.Rows(0).Item(0)
                        txtmtrs.Text = dt.Rows(0).Item(1)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub cmbtype_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtype.Validating
        If cmbtype.Text = "STORE" Then
            cmbtype.Text = "STORE"
            cmbtype.Enabled = False
            fillitemname(cmbmerchant, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            GMERCHANT.HeaderText = "Item Name"
            cmbjobno.Enabled = False
            CMBFROM.Enabled = False
            cmbpiecetype.Enabled = False
            txtcut.Enabled = False
            cmbdesign.Enabled = False
            cmbcolor.Enabled = False
            CMBLOTNO.Enabled = False
            txtmtrs.ReadOnly = True
        End If
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                If MsgBox("Wish to Delete?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim OBJSA As New ClsSA
                OBJSA.alParaval.Add(tempSAno)
                OBJSA.alParaval.Add(YearId)

                Dim INT As Integer = OBJSA.Delete
                MsgBox("Entry Deleted Successfully")
                edit = False
                CLEAR()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub CMBGODOWN_Enter(sender As Object, e As EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then FILLGODOWN(CMBGODOWN, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(sender As Object, e As CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class