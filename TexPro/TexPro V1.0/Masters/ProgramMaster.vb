
Imports BL
Imports System.Windows.Forms
Public Class ProgramMaster

    'following two variables is only for used in edit mode....
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim gridDoubleClick As Boolean
    Dim tempRow As Integer

    Public edit As Boolean
    Public TEMPPRGNO As String
    Public tempMsg As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " AND (GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'  or GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS') ", "Sundry Creditors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbdyeingno_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDYEINGNO.Enter
        Try
            If CMBDYEINGNO.Text.Trim = "" Then filldyeing(CMBDYEINGNO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbdyeingno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDYEINGNO.Validating
        Try
            If CMBDYEINGNO.Text.Trim <> "" Then dyeingvalidate(CMBDYEINGNO, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub




    Sub clear()

        tstxtbillno.Clear()

        prgdate.Value = Mydate

        EP.Clear()
        txtsrno.Clear()
        CMBDYEINGNO.Text = ""

        txtqty.Clear()

        CMBDYEINGNO.Text = ""
        cmbquality.Text = ""
        txtorderno.Clear()
        cmbprocess.Text = "DYEING"

        cmbname.Text = ""
        gridPrg.RowCount = 0
        lbltotalqty.Text = 0.0


        gridDoubleClick = False



        getmax_PRG_no() 'this function is for to get max value from the Purchase PRGuisition table

        If gridPrg.RowCount > 0 Then
            txtsrno.Text = Val(gridPrg.Rows(gridPrg.RowCount - 1).Cells(gsrno.Index).Value) + 1
        Else
            txtsrno.Text = 1
        End If

    End Sub
    Private Sub CMBPROCESS_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprocess.GotFocus
        Try
            If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " AND PROCESSMASTER.PROCESS_TYPE='MFG'", False)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Sub getmax_PRG_no()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(PRG_no),0) + 1 ", "PRGMaster", " AND PRG_cmpid=" & CmpId & " and PRG_LOCATIONID=" & Locationid & " and PRG_YEARID=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtprgno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(gsrno.Index).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub CMBPROCESS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprocess.Validated
        Try
            If cmbprocess.Text.Trim <> "" Then cmbprocess.Enabled = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub fillgrid()
        gridPrg.Enabled = True
        If gridDoubleClick = False Then
            gridPrg.Rows.Add(Val(txtsrno.Text.Trim), CMBDYEINGNO.Text.Trim, Val(txtqty.Text.Trim), 0, 0)
            getsrno(gridPrg)
        ElseIf gridDoubleClick = True Then
            gridPrg.Item(gsrno.Index, tempRow).Value = Val(txtsrno.Text.Trim)
            gridPrg.Item(gdyeingno.Index, tempRow).Value = CMBDYEINGNO.Text.Trim
            gridPrg.Item(gQty.Index, tempRow).Value = Val(txtqty.Text.Trim)

            gridDoubleClick = False

        End If

        gridPrg.FirstDisplayedScrollingRowIndex = gridPrg.RowCount - 1

        txtsrno.Clear()
        CMBDYEINGNO.Text = ""
        txtqty.Clear()
        txtsrno.Focus()

    End Sub

    Sub qtytotal()
        lbltotalqty.Text = "0.00"
        For Each row As DataGridViewRow In gridPrg.Rows
            If Val(row.Cells(gQty.Index).Value) <> 0 Then
                lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(row.Cells(gQty.Index).Value), "0.00")

            End If
        Next
    End Sub

    Private Sub gridPRG_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridPrg.CellDoubleClick

        If e.RowIndex = -1 Then
            Exit Sub
        End If

        If e.RowIndex >= 0 And gridPrg.Item(gsrno.Index, e.RowIndex).Value <> Nothing Then
            If Convert.ToBoolean(gridPrg.Item(GDONE.Index, e.RowIndex).Value) = False Then
                gridDoubleClick = True
                txtsrno.Text = gridPrg.Item(gsrno.Index, e.RowIndex).Value
                CMBDYEINGNO.Text = gridPrg.Item(gdyeingno.Index, e.RowIndex).Value

                txtqty.Text = gridPrg.Item(gQty.Index, e.RowIndex).Value

                tempRow = e.RowIndex
                txtsrno.Focus()
            Else
                MsgBox("Item Locked. First Delete Entry From Quotation")
            End If
        End If
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(cmbprocess.Text.Trim)
            alParaval.Add(prgdate.Value)
            alParaval.Add(txtorderno.Text.Trim)
            alParaval.Add(cmbquality.Text.Trim)
            alParaval.Add(cmbname.Text.Trim)

            alParaval.Add(lbltotalqty.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim dyeingno As String = ""

            Dim qty As String = ""
            Dim READYQTY As String = ""
            Dim DONE As String = ""
  

            For Each row As Windows.Forms.DataGridViewRow In gridPrg.Rows
                If row.Cells(gsrno.Index).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value
                        dyeingno = row.Cells(gdyeingno.Index).Value.ToString

                        qty = row.Cells(gQty.Index).Value
                        READYQTY = row.Cells(greadyqty.Index).Value
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If

                    Else
                        gridsrno = gridsrno & "," & row.Cells(gsrno.Index).Value
                        dyeingno = dyeingno & "," & row.Cells(gdyeingno.Index).Value.ToString

                        qty = qty & "," & row.Cells(gQty.Index).Value
                        READYQTY = READYQTY & "," & row.Cells(greadyqty.Index).Value
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = DONE & "," & 1
                        Else
                            DONE = DONE & "," & 0
                        End If

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(dyeingno)

            alParaval.Add(qty)
            alParaval.Add(READYQTY)
            alParaval.Add(DONE)
          

            Dim objclsPRG As New ClsPRG
            objclsPRG.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsPRG.save()
                MessageBox.Show("Details Added")
            Else
                alParaval.Add(TEMPPRGNO)
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsPRG.Update()
                MsgBox("Details Updated")
            End If
            edit = False
            Dim TEMPMSG As Integer
            TEMPMSG = MsgBox("WISH TO PRINT", MsgBoxStyle.YesNo)

            If TEMPMSG = vbYes Then
                'Dim OBJGN As New PRGDesign
                'OBJGN.PRGNO = txtPRGno.Text
                'OBJGN.MdiParent = MDIMain
                'OBJGN.selfor_po = "{PRGMaster.PRG_no}=" & txtPRGno.Text & " and {PRGMaster.PRG_cmpid}=" & CmpId & " and {PRGMaster.PRG_locationid}=" & Locationid & " and {PRGMaster.PRG_yearid}=" & YearId
                'OBJGN.Show()
            End If
            edit = False
            clear()
            cmbname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If cmbname.Text.Trim.Length = 0 Then
            EP.SetError(cmbname, "Enter PRG. by")
            bln = False
        End If

      

        If gridPrg.RowCount = 0 Then
            EP.SetError(txtqty, "Enter Item Details")
            bln = False
        End If

      

    

        If Not datecheck(prgdate.Value) Then bln = False
        Return bln
    End Function

    Private Sub PurchasePRGuisition_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D Then       'for Delete
            Call cmddelete_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub PurchasePRGuisition_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub PRGmaster_load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'MFG'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)



            filldyeing(CMBDYEINGNO)
            fillQUALITY(cmbquality, edit)
            If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " AND PROCESSMASTER.PROCESS_TYPE='MFG'", False)

            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList
                Dim objclsPRG As New ClsPRG

                ALPARAVAL.Add(TEMPPRGNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                objclsPRG.alParaval = ALPARAVAL
                Dim dt As DataTable = objclsPRG.selectPRG()

                If dt.Rows.Count > 0 Then
                    For Each dr As DataRow In dt.Rows

                        txtprgno.Text = TEMPPRGNO
                        prgdate.Value = Convert.ToDateTime(dr("PRGDATE"))
                        cmbname.Text = Convert.ToString(dr("NAME"))
                        cmbquality.Text = Convert.ToString(dr("QUALITY"))
                        cmbprocess.Text = Convert.ToString(dr("PROCESS"))
                        txtorderno.Text = Convert.ToString(dr("ORDERNO"))
                        gridPrg.Rows.Add(dr("gridsrno").ToString, dr("dyeingno").ToString, dr("QTY").ToString, dr("READYQTY").ToString, dr("DONE").ToString)

                    Next
                    gridPrg.FirstDisplayedScrollingRowIndex = gridPrg.RowCount - 1
                End If

                chkchange.CheckState = CheckState.Checked
                qtytotal()
            End If

            'If gridDoubleClick = False Then
            If gridPrg.RowCount > 0 Then
                txtsrno.Text = Val(gridPrg.Rows(gridPrg.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If gridDoubleClick = False Then
            If gridPrg.RowCount > 0 Then
                txtsrno.Text = Val(gridPrg.Rows(gridPrg.RowCount - 1).Cells(gsrno.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        numdot(e, txtqty, Me)
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If edit = True Then
                Dim BLN As Boolean = True
                Dim TEMPMSG As Integer = MsgBox("Delete PRG?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    'Dim ALPARAVAL As New ArrayList
                    'Dim OBJPR As New ClsPRG

                    'ALPARAVAL.Add(TEMPPRGNO)
                    'ALPARAVAL.Add(CmpId)
                    'ALPARAVAL.Add(Locationid)
                    'ALPARAVAL.Add(YearId)

                    'OBJPR.alParaval = ALPARAVAL
                    'Dim IntResult As Integer = OBJPR.Delete()
                    'MsgBox("Purchase PRGuest Deleted")
                    'clear()

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objprdetails As New ProgramDetails
            objprdetails.MdiParent = MDIMain
            objprdetails.Show()
            objprdetails.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        TEMPPRGNO = Val(txtprgno.Text) - 1
        clear()
        If TEMPPRGNO > 0 Then
            edit = True
            PRGmaster_load(sender, e)
        Else
            clear()
            edit = False
        End If
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        TEMPPRGNO = Val(txtprgno.Text) + 1
        getmax_PRG_no()
        clear()
        If Val(txtprgno.Text) - 1 >= TEMPPRGNO Then
            edit = True
            PRGmaster_load(sender, e)
        Else
            clear()
            edit = False
        End If
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub PRGdate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles prgdate.Validating
        If Not datecheck(prgdate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub


    Private Sub gridpurchasePRG_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridPrg.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridPrg.RowCount > 0 Then


                gridPrg.Rows.RemoveAt(gridPrg.CurrentRow.Index)
                qtytotal()
                getsrno(gridPrg)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub


    Private Sub cmbdyeingno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMBDYEINGNO.KeyPress
        commakeypress(e, CMBDYEINGNO, Me)
    End Sub

    Private Sub tstxtbillno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        TEMPPRGNO = Val(tstxtbillno.Text)
        clear()
        If TEMPPRGNO > 0 Then
            edit = True
            PRGmaster_load(sender, e)
        Else
            clear()
            edit = False
        End If
    End Sub



    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then
                'Dim OBJGN As New PRGDesign
                'OBJGN.PRGNO = TEMPPRGNO
                'OBJGN.MdiParent = MDIMain
                'OBJGN.selfor_po = "{PRGMaster.PRG_no}=" & TEMPPRGNO & " and {PRGMaster.PRG_cmpid}=" & CmpId & " and {PRGMaster.PRG_locationid}=" & Locationid & " and {PRGMaster.PRG_yearid}=" & YearId
                'OBJGN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

  
    
    Private Sub txtqty_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqty.Validated
        Try
            If CMBDYEINGNO.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 Then
                fillgrid()
                qtytotal()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class