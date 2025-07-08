
Imports BL

Public Class DiscountMaster

    Public EDIT As Boolean              'Used for edit
    Public TEMPDISCNAME As String           'Used for edit name
    Public TEMPID As Integer            'Used for edit id
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer

    Sub FILLCMB()
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search("DISC_NAME", "", " DISCOUNTMASTER ", " and DISC_yearid = " & YearId)
        If DT.Rows.Count > 0 Then
            DT.DefaultView.Sort = "DISC_NAME"
            CMBDISCNAME.DataSource = DT
            CMBDISCNAME.DisplayMember = "DISC_NAME"
            CMBDISCNAME.Text = TEMPDISCNAME
        End If
        If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
    End Sub

    Private Sub DicountMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLCMB()
            CMBDISCNAME.Text = TEMPDISCNAME

            If EDIT = True Then
                Dim OBJDISC As New ClsDiscountMaster()
                OBJDISC.alParaval.Add(TEMPID)
                OBJDISC.alParaval.Add(CmpId)
                OBJDISC.alParaval.Add(Locationid)
                OBJDISC.alParaval.Add(YearId)
                Dim DTTABLE As DataTable = OBJDISC.SELECTDISCOUNT()
                If DTTABLE.Rows.Count > 0 Then
                    For Each dr As DataRow In DTTABLE.Rows
                        TEMPDISCNAME = dr("DISCNAME").ToString
                        TEMPID = dr("DISCID").ToString
                        GRIDDISC.Rows.Add(Val(dr("GRIDSRNO")), dr("ITEMNAME"), Val(dr("RATE")))
                    Next
                End If

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If
            Dim IntResult As Integer

            Dim alParaval As New ArrayList

            alParaval.Add(UCase(CMBDISCNAME.Text.Trim))
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim GRIDSRNO As String = ""
            Dim ITEMNAME As String = ""
            Dim RATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDDISC.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(GSRNO.Index).Value)
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        RATE = Val(row.Cells(GRATE.Index).Value)
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value.ToString
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                    End If
                End If
            Next


            alParaval.Add(GRIDSRNO)
            alParaval.Add(ITEMNAME)
            alParaval.Add(RATE)

            Dim objDESIGN As New ClsDiscountMaster
            objDESIGN.alParaval = alParaval

            If EDIT = False Then
                IntResult = objDESIGN.SAVE()
                MsgBox("Details Added")
            Else
                alParaval.Add(TEMPID)
                IntResult = objDESIGN.UPDATE()
                MsgBox("Details Updated")
            End If
            EDIT = False

            Clear()
            EDIT = False
            CMBDISCNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub Clear()
        Try
            CMBDISCNAME.Text = ""
            TXTSRNO.Clear()
            CMBITEMNAME.Text = ""
            TXTRATE.Clear()
            GRIDDISC.RowCount = 0
            TEMPDISCNAME = ""
            TEMPID = 0

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DicountMaster_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            If CMBDISCNAME.Text.Trim <> "" Then
                pcase(CMBDISCNAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (EDIT = False) Or (EDIT = True And LCase(CMBDISCNAME.Text) <> LCase(TEMPDISCNAME)) Then
                    dt = objclscommon.search("DISC_NAME", "", " DISCOUNTMASTER ", " And DISC_NAME = '" & CMBDISCNAME.Text.Trim & "' AND DISC_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Discount Already Exists", MsgBoxStyle.Critical, "TEXPRO")
                        BLN = False
                    End If
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function errorvalid() As Boolean

        Dim bln As Boolean = True

        If CMBDISCNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBDISCNAME, "Fill Design No")
            bln = False
        End If

        If GRIDDISC.RowCount = 0 Then
            EP.SetError(CMBDISCNAME, "Fill Details in Grid")
            bln = False
        End If

        If Not CHECKDUPLICATE() Then
            EP.SetError(CMBDISCNAME, "Design Already Exists")
            bln = False
        End If

        Return bln
    End Function

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDISCNAME_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDISCNAME.Enter
        Try
            If CMBDISCNAME.Text.Trim = "" Then CMBDISCNAME.SelectAll()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDISCNAME_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBDISCNAME.Validating
        Try
            If CMBDISCNAME.Text.Trim <> "" Then
                uppercase(CMBDISCNAME)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (EDIT = False) Or (EDIT = True And LCase(CMBDISCNAME.Text) <> LCase(TEMPDISCNAME)) Then
                    dt = objclscommon.search("DISC_NAME", "", " DISCOUNTMASTER ", " AND DISC_NAME = '" & CMBDISCNAME.Text.Trim & "' AND DISC_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Discount Already Exists", MsgBoxStyle.Critical, "TEXPRO")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then itemvalidate(CMBITEMNAME, e, Me, " AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' OR ITEMMASTER.ITEM_FRMSTRING = 'ITEM')", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        If GRIDDOUBLECLICK = False Then
            GRIDDISC.Rows.Add(Val(TXTSRNO.Text.Trim), CMBITEMNAME.Text.Trim, Val(TXTRATE.Text.Trim))
            getsrno(GRIDDISC)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDDISC.Item(GSRNO.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDDISC.Item(GITEMNAME.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
            GRIDDISC.Item(GRATE.Index, TEMPROW).Value = Val(TXTRATE.Text.Trim)
            TEMPROW = GRIDDISC.CurrentRow.Index
            TXTSRNO.Focus()
            GRIDDOUBLECLICK = False
        End If
        CMBITEMNAME.Text = ""
        TXTRATE.Clear()
        GRIDDISC.ClearSelection()
        CMBITEMNAME.Focus()
    End Sub

    Private Sub TXTRATE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTRATE.Validated
        Try
            'WE HAVE REMOVED VALIDATION OF RATE>0 AS WE NEED 0 RATE ALSO
            If CMBITEMNAME.Text.Trim <> "" Then
                If Not CHECKITEM() Then
                    MsgBox("Item already Present in Grid below")
                    Exit Sub
                End If
                fillgrid()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function CHECKITEM() As Boolean
        Try
            Dim bln As Boolean = True
            For Each row As DataGridViewRow In GRIDDISC.Rows
                If (GRIDDOUBLECLICK = True And TEMPROW <> row.Index) Or GRIDDOUBLECLICK = False Then
                    If CMBITEMNAME.Text.Trim = row.Cells(GITEMNAME.Index).Value Then bln = False
                End If
            Next
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub GRIDDISC_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDDISC.CellDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso GRIDDISC.Item("GITEMNAME", e.RowIndex).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TEMPROW = e.RowIndex
                TXTSRNO.Text = Val(GRIDDISC.Item("GSRNO", e.RowIndex).Value)
                CMBITEMNAME.Text = GRIDDISC.Item("GITEMNAME", e.RowIndex).Value
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPROCESS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDDISC.KeyDown
        If e.KeyCode = Keys.Delete And GRIDDISC.RowCount > 0 Then
            If GRIDDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            GRIDDISC.Rows.RemoveAt(GRIDDISC.CurrentRow.Index)
            getsrno(GRIDDISC)
        End If

    End Sub

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Try

            If EDIT = True Then

                Dim objcls As New ClsDiscountMaster()
                If MsgBox("Wish To Delete?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim alParaval As New ArrayList
                alParaval.Add(TEMPID)
                alParaval.Add(CmpId)
                alParaval.Add(Locationid)
                alParaval.Add(YearId)
                objcls.alParaval = alParaval
                Dim DT As DataTable = objcls.Delete()
                MsgBox(DT.Rows(0).Item(0))
                Clear()
                EDIT = False

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class