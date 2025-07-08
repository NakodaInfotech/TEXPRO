
Imports System.ComponentModel
Imports BL

Public Class InterGodownTransfer

    Public TEMPGODOWNNO As Integer          'used for editing
    Public EDIT As Boolean          'used for editing
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim ALLOWMANUALJONO As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        EP.Clear()
        TXTGODOWNNO.Clear()

        If ALLOWMANUALJONO = True Then
            TXTGODOWNNO.ReadOnly = False
            TXTGODOWNNO.BackColor = Color.LemonChiffon
        Else
            TXTGODOWNNO.ReadOnly = True
            TXTGODOWNNO.BackColor = Color.Linen
        End If

        If USERGODOWN <> "" Then CMBFROMGODOWN.Text = USERGODOWN

        GRIDTRANSFER.RowCount = 0
        CMBTRANSPORTNAME.Text = ""
        TXTDATE.Text = Mydate
        tstxtbillno.Clear()
        txtremarks.Clear()
        CMDSELECTSTOCK.Enabled = True
        lbllocked.Visible = False
        PBlock.Visible = False
        LBLTOTALMTRS.Text = 0.0
        LBLTOTALPCS.Text = 0.0
        LBLTOTALBALES.Text = 0.0
        TXTREFRENCE.Clear()
        TXTISSUEBY.Clear()
        TXTVEHICLENO.Clear()
        getmaxno()

    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(TRANSFER_no),0) + 1 ", " INTERGODOWNTRANSFER ", " AND TRANSFER_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTGODOWNNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True

            If CMBFROMGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBFROMGODOWN, " Please Fill Godown")
                bln = False
            End If

            If CMBTOGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBTOGODOWN, " Please Fill Godown")
                bln = False
            End If

            If CMBFROMGODOWN.Text.Trim = CMBTOGODOWN.Text.Trim Then
                EP.SetError(CMBFROMGODOWN, " From && To Godown cannot be same")
                bln = False
            End If

            If CMBTRANSPORTNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBTRANSPORTNAME, " Please Fill Transport")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, " Inward Done, Delete Inward First")
                bln = False
            End If

            If GRIDTRANSFER.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Lot Details")
                bln = False
            End If

            If TXTDATE.Text = "__/__/____" Then
                EP.SetError(TXTDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(TXTDATE.Text) Then
                    EP.SetError(TXTDATE, "Date not in Accounting Year")
                    bln = False
                End If
            End If

            If Val(TXTGODOWNNO.Text.Trim) = 0 Then
                EP.SetError(TXTGODOWNNO, "Enter Godown No")
                bln = False
            End If

            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub cmdok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            If TXTGODOWNNO.ReadOnly = False Then
                alParaval.Add(Val(TXTGODOWNNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(TXTDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBFROMGODOWN.Text.Trim)
            alParaval.Add(CMBTOGODOWN.Text.Trim)
            alParaval.Add(CMBTRANSPORTNAME.Text.Trim)
            alParaval.Add(TXTREFRENCE.Text.Trim)
            alParaval.Add(TXTISSUEBY.Text.Trim)
            alParaval.Add(TXTVEHICLENO.Text.Trim)

            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLTOTALBALES.Text))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim gridsrno As String = ""
            Dim PARTYNAME As String = ""
            Dim QUALITY As String = ""
            Dim LOTNO As String = ""
            Dim PCS As String = ""
            Dim MTRS As String = ""
            Dim BALES As String = ""
            Dim LRNO As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDTRANSFER.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(GSRNO.Index).Value)
                        PARTYNAME = row.Cells(GNAME.Index).Value
                        QUALITY = row.Cells(GQUALITY.Index).Value
                        LOTNO = row.Cells(GLOTNO.Index).Value
                        PCS = Val(row.Cells(GPCS.Index).Value)
                        MTRS = Val(row.Cells(GMTRS.Index).Value)
                        BALES = Val(row.Cells(GBALES.Index).Value)
                        LRNO = row.Cells(GLRNO.Index).Value
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value

                    Else
                        gridsrno = gridsrno & "|" & Val(row.Cells(GSRNO.Index).Value)
                        PARTYNAME = PARTYNAME & "|" & row.Cells(GNAME.Index).Value
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value
                        PCS = PCS & "|" & Val(row.Cells(GPCS.Index).Value)
                        MTRS = MTRS & "|" & Val(row.Cells(GMTRS.Index).Value)
                        BALES = BALES & "|" & Val(row.Cells(GBALES.Index).Value)
                        LRNO = LRNO & "|" & row.Cells(GLRNO.Index).Value
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(PARTYNAME)
            alParaval.Add(QUALITY)
            alParaval.Add(LOTNO)
            alParaval.Add(PCS)
            alParaval.Add(MTRS)
            alParaval.Add(BALES)
            alParaval.Add(LRNO)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)



            Dim OBJTRANSFER As New ClsInterGodownTransfer()
            OBJTRANSFER.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJTRANSFER.SAVE()
                MsgBox("Details Added")
                TXTGODOWNNO.Text = DTTABLE.Rows(0).Item(0)

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPGODOWNNO)
                Dim IntResult As Integer = OBJTRANSFER.UPDATE()
                MsgBox("Details Updated")
                EDIT = False
            End If
            PRINTREPORT(TXTGODOWNNO.Text.Trim)
            CLEAR()
            TXTDATE.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub JOBOUT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.P And e.Alt = True Then
            Call PrintToolStripButton_Click(sender, e)
        End If
    End Sub

    Private Sub InterGodownTransfer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN CHECKING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            CLEAR()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJTRANSFER As New ClsInterGodownTransfer()
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPGODOWNNO)
                ALPARAVAL.Add(YearId)
                OBJTRANSFER.alParaval = ALPARAVAL
                Dim dttable As DataTable = OBJTRANSFER.SELECTGODOWN()

                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTGODOWNNO.Text = TEMPGODOWNNO
                        TXTGODOWNNO.ReadOnly = True
                        TXTDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBFROMGODOWN.Text = Convert.ToString(dr("FROMGODOWN").ToString)
                        CMBTOGODOWN.Text = Convert.ToString(dr("TOGODOWN").ToString)
                        CMBTRANSPORTNAME.Text = Convert.ToString(dr("TRANSPORTNAME").ToString)
                        TXTREFRENCE.Text = dr("REFERENCE")
                        TXTISSUEBY.Text = dr("ISSUE")
                        TXTVEHICLENO.Text = dr("VEHICLENO")

                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        LBLTOTALMTRS.Text = Val(dr("TOTALMTRS"))
                        LBLTOTALPCS.Text = Val(dr("TOTALPCS"))
                        LBLTOTALBALES.Text = Val(dr("TOTALBALES"))

                        GRIDTRANSFER.Rows.Add(Val(dr("GRIDSRNO")), dr("PARTYNAME"), dr("QUALITY").ToString, dr("LOTNO").ToString, Format(dr("PCS"), "0.00"), Format(dr("MTRS"), "0.00"), Val(dr("BALES")), dr("LRNO"), Val(dr("FROMNO")), Val(dr("FROMSRNO")), dr("FROMTYPE"))

                        If Convert.ToBoolean(dr("DONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    total()
                    GRIDTRANSFER.FirstDisplayedScrollingRowIndex = GRIDTRANSFER.RowCount - 1
                Else
                    EDIT = False
                    CLEAR()
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub fillcmb()
        Try
            If CMBFROMGODOWN.Text.Trim = "" Then FILLGODOWN(CMBFROMGODOWN, EDIT)
            If CMBTOGODOWN.Text.Trim = "" Then FILLGODOWN(CMBTOGODOWN, EDIT)
            If CMBTRANSPORTNAME.Text.Trim = "" Then filltransname(CMBTRANSPORTNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim OBJTRANSFER As New InterGodownTransferDetails
            OBJTRANSFER.MdiParent = MDIMain
            OBJTRANSFER.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANSPORTNAME.Enter
        Try
            If CMBTRANSPORTNAME.Text.Trim = "" Then fillname(CMBTRANSPORTNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBTRANSPORTNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBTRANSPORTNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANSPORTNAME.Validating
        Try
            If CMBTRANSPORTNAME.Text.Trim <> "" Then namevalidate(CMBTRANSPORTNAME, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "SUNDRY CREDITORS")
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
            GRIDTRANSFER.RowCount = 0
LINE1:
            TEMPGODOWNNO = Val(TXTGODOWNNO.Text) - 1
            If TEMPGODOWNNO > 0 Then
                EDIT = True
                InterGodownTransfer_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDTRANSFER.RowCount = 0 And TEMPGODOWNNO > 1 Then
                TXTGODOWNNO.Text = TEMPGODOWNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
LINE1:
            TEMPGODOWNNO = Val(TXTGODOWNNO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTGODOWNNO.Text.Trim
            CLEAR()
            If Val(TXTGODOWNNO.Text) - 1 >= TEMPGODOWNNO Then
                EDIT = True
                InterGodownTransfer_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDTRANSFER.RowCount = 0 And TEMPGODOWNNO < MAXNO Then
                TXTGODOWNNO.Text = TEMPGODOWNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFROMGODOWN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBFROMGODOWN.Enter
        Try
            If CMBFROMGODOWN.Text.Trim = "" Then FILLGODOWN(CMBFROMGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMGODOWN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBFROMGODOWN.Validating
        Try
            If CMBFROMGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBFROMGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOGODOWN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTOGODOWN.Enter
        Try
            If CMBTOGODOWN.Text.Trim = "" Then FILLGODOWN(CMBTOGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTOGODOWN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTOGODOWN.Validating
        Try
            If CMBTOGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBTOGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPGODOWNNO)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub PRINTREPORT(ByVal GODOWNNO As Integer)
        Try
            If MsgBox("Wish to Print?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJTRANSFER As New GRNCheckingDesign
            OBJTRANSFER.MdiParent = MDIMain
            OBJTRANSFER.FRMSTRING = "TRANSFER"
            OBJTRANSFER.WHERECLAUSE = "{INTERGODOWNTRANSFER.TRANSFER_NO}=" & Val(GODOWNNO) & " and {INTERGODOWNTRANSFER.TRANSFER_yearid}=" & YearId
            OBJTRANSFER.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then

                Dim TEMPMSG As Integer = MsgBox("Wish to Delete?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                Dim ALPARAVAL As New ArrayList
                Dim OBJTRANSFER As New ClsInterGodownTransfer

                ALPARAVAL.Add(TEMPGODOWNNO)
                ALPARAVAL.Add(YearId)
                OBJTRANSFER.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJTRANSFER.Delete()
                MsgBox("Entry Deleted Succesfully")
                EDIT = False
                CLEAR()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtremarks.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then txtremarks.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTDATE.Validating
        Try
            If TXTDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(TXTDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGODOWNNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGODOWNNO.KeyPress
        numkeypress(e, TXTGODOWNNO, Me)
    End Sub

    Private Sub GRIDTRANSFER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDTRANSFER.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDTRANSFER.RowCount > 0 Then
                GRIDTRANSFER.Rows.RemoveAt(GRIDTRANSFER.CurrentRow.Index)
                getsrno(GRIDTRANSFER)
                total()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            Dim DTJO As New DataTable
            Dim OBJSELECT As New SelectLotforTransfer
            OBJSELECT.GODOWN = CMBFROMGODOWN.Text.Trim
            OBJSELECT.ShowDialog()
            DTJO = OBJSELECT.DT
            If DTJO.Rows.Count > 0 Then
                For Each DTROWPS As DataRow In DTJO.Rows

                    'CHECK WHETHER ENTRY IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDTRANSFER.Rows
                        If Val(ROW.Cells(GFROMNO.Index).Value) = Val(DTROWPS("FROMNO")) And Val(ROW.Cells(GFROMSRNO.Index).Value) = Val(DTROWPS("FROMSRNO")) And ROW.Cells(GFROMTYPE.Index).Value = DTROWPS("FROMTYPE") Then GoTo LINE1
                    Next

                    GRIDTRANSFER.Rows.Add(0, DTROWPS("NAME"), DTROWPS("QUALITY"), DTROWPS("LOTNO"), Val(DTROWPS("PCS")), Format(Val(DTROWPS("MTRS")), "0.00"), 0, "", DTROWPS("FROMNO"), DTROWPS("FROMSRNO"), DTROWPS("FROMTYPE"))
LINE1:
                Next
                getsrno(GRIDTRANSFER)
                total()
                GRIDTRANSFER.FirstDisplayedScrollingRowIndex = GRIDTRANSFER.RowCount - 1
            End If
            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALPCS.Text = 0.0
            LBLTOTALBALES.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDTRANSFER.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(ROW.Cells(GPCS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALBALES.Text = Format(Val(LBLTOTALBALES.Text) + Val(ROW.Cells(GBALES.Index).EditedFormattedValue), "0")
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validated(sender As Object, e As EventArgs) Handles tstxtbillno.Validated
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDTRANSFER.RowCount = 0
                TEMPGODOWNNO = Val(tstxtbillno.Text)
                If TEMPGODOWNNO > 0 Then
                    EDIT = True
                    InterGodownTransfer_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub InterGodownTransfer_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If UserName = "Admin" Then CMBFROMGODOWN.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDTRANSFER_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDTRANSFER.CellValidating
        Try
            Dim colNum As Integer = GRIDTRANSFER.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
            Select Case colNum

                Case GBALES.Index
                    Dim dDebit As Integer
                    Dim bValid As Boolean = Integer.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDTRANSFER.CurrentCell.Value = Nothing Then GRIDTRANSFER.CurrentCell.Value = "0"
                        GRIDTRANSFER.CurrentCell.Value = Convert.ToInt32(GRIDTRANSFER.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        total()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select


            Dim TEMPLOTNO As String = ""
            For I As Integer = GRIDTRANSFER.CurrentRow.Index + 1 To GRIDTRANSFER.RowCount - 1
                If I = GRIDTRANSFER.CurrentRow.Index + 1 Then TEMPLOTNO = GRIDTRANSFER.Item(GLOTNO.Index, I - 1).Value
                If GRIDTRANSFER.Item(GLOTNO.Index, I).Value = TEMPLOTNO Then
                    GRIDTRANSFER.Item(GLRNO.Index, I).Value = GRIDTRANSFER.Item(GLRNO.Index, I - 1).EditedFormattedValue
                End If
            Next

            total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class