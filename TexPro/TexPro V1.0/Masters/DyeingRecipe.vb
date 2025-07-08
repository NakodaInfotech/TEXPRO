
Imports BL
Imports System.IO

Public Class DyeingRecipe

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim congridDoubleClick As Boolean
    Public edit As Boolean          'used for editing
    Public TEMPDYEINGID As String
    Public TEMPDYEINGNO As String
    Dim temprow As Integer
    Dim dt_consume As New DataTable
    Dim OLDIMGPATH As String = ""
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public Shared dt_SELECT As New DataTable

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click
        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png)|*.bmp;*.jpeg;*.png"
        OpenFileDialog1.ShowDialog()
        TXTPHOTOIMGPATH.Text = OpenFileDialog1.FileName
        On Error Resume Next
        If TXTPHOTOIMGPATH.Text.Trim.Length <> 0 Then PBPHOTO.ImageLocation = TXTPHOTOIMGPATH.Text.Trim
    End Sub

    Private Sub DyeingRecipe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'for Saving
                Call cmdok_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for CLEAR
                Call PBCOPYCHART_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DYEINGRecipe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'DYEING MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            dt_consume.Reset()
            dt_consume.Columns.Add("srno")
            dt_consume.Columns.Add("consrno")
            dt_consume.Columns.Add("itemname")
            dt_consume.Columns.Add("QTY")
            dt_consume.Columns.Add("UNIT")
            dt_consume.Columns.Add("NOCALC")
            dt_consume.Columns.Add("rate")


            fillcmb()
            cmbdyeingno.Text = TEMPDYEINGNO

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objclsJO As New ClsDyeingRecipe()
                Dim dttable As New DataTable

                dttable = objclsJO.selectDYEING(TEMPDYEINGNO, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows
                        TEMPDYEINGID = dr("DYEINGid").ToString
                        cmbprocess.Text = dr("PROCESS").ToString
                        TXTGMS.Text = Val(dr("GMS"))

                        If IsDBNull(dttable.Rows(0).Item("IMGPATH")) = False Then
                            PBPHOTO.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH"), Byte())))
                            TXTPHOTOIMGPATH.Text = dttable.Rows(0).Item("IMGPATH").ToString
                        Else
                            PBPHOTO.Image = Nothing
                        End If

                        GRIDRECIPE.Rows.Add(Val(dr("GRIDSRNO").ToString), dr("color").ToString, Val(dr("PERPCS").ToString), Val(dr("totalcost").ToString))
                        txtremarks.Text = dr("REMARKS")
                        CHKBLOCKED.Checked = Convert.ToBoolean(dr("BLOCKED"))
                    Next
                End If

                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" DYEINGRECIPE_CONSUMPTION.DYEING_SRNO AS SRNO, DYEINGRECIPE_CONSUMPTION.DYEING_CONSRNO AS CONSRNO, ITEMMASTER.item_name AS ITEMNAME, DYEINGRECIPE_CONSUMPTION.DYEING_QTY AS QTY,  UNITMASTER.UNIT_ABBR AS UNIT, ISNULL(DYEINGRECIPE_CONSUMPTION.DYEING_NOCALC,0) AS NOCALC, DYEINGRECIPE_CONSUMPTION.DYEING_RATE AS RATE ", "", "  DYEINGRECIPE_CONSUMPTION INNER JOIN ITEMMASTER ON DYEINGRECIPE_CONSUMPTION.DYEING_ITEMID = ITEMMASTER.item_id AND DYEINGRECIPE_CONSUMPTION.DYEING_CMPID = ITEMMASTER.item_cmpid AND DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID = ITEMMASTER.item_locationid AND DYEINGRECIPE_CONSUMPTION.DYEING_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN UNITMASTER ON DYEINGRECIPE_CONSUMPTION.DYEING_UNITID = UNITMASTER.UNIT_id AND DYEINGRECIPE_CONSUMPTION.DYEING_CMPID = UNITMASTER.UNIT_cmpid AND DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID = UNITMASTER.UNIT_locationid AND DYEINGRECIPE_CONSUMPTION.DYEING_YEARID = UNITMASTER.UNIT_yearid ", " AND DYEINGRECIPE_CONSUMPTION.DYEING_ID = " & TEMPDYEINGID & " AND DYEINGRECIPE_CONSUMPTION.DYEING_CMPID = " & CmpId & " AND DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID  = " & Locationid & " AND DYEINGRECIPE_CONSUMPTION.DYEING_YEARID = " & YearId & " ORDER BY SRNO,CONSRNO")
                If dttable.Rows.Count > 0 Then
                    For Each DR As DataRow In dttable.Rows
                        dt_consume.Rows.Add(DR("SRNO").ToString, DR("CONSRNO").ToString, DR("ITEMNAME").ToString, Format(Val(DR("QTY")), "0.000"), DR("UNIT").ToString, DR("NOCALC"), Format(Val(DR("RATE")), "0.000"))
                    Next
                End If

                chkchange.CheckState = CheckState.Checked

            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmdremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdremove.Click
        Try
            PBPHOTO.Image = Nothing
            TXTPHOTOIMGPATH.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(cmbdyeingno.Text.Trim)
            alParaval.Add(cmbprocess.Text.Trim)
            alParaval.Add(Val(TXTGMS.Text.Trim))

            If PBPHOTO.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBPHOTO.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CHKBLOCKED.Checked)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim MATCHING As String = ""
            Dim Per As String = ""
            Dim totalcost As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDRECIPE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value
                        MATCHING = row.Cells(gMatching.Index).Value.ToString
                        Per = row.Cells(GPERPCS.Index).Value
                        totalcost = row.Cells(gtotalCost.Index).Value
                    Else
                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        MATCHING = MATCHING & "|" & row.Cells(gMatching.Index).Value.ToString
                        Per = Per & "|" & row.Cells(gPerPcs.Index).Value
                        totalcost = totalcost & "|" & row.Cells(gtotalCost.Index).Value
                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(MATCHING)
            alParaval.Add(Per)
            alParaval.Add(totalcost)

            Dim gridno As String = ""
            Dim congridno As String = ""
            Dim itemname As String = ""
            Dim QTY As String = ""
            Dim NOCALC As String = ""
            Dim rate As String = ""
            Dim UNIT As String = ""

            For i As Integer = 0 To dt_consume.Rows.Count - 1
                If dt_consume.Rows(i).Item(0) <> Nothing Then
                    If gridno = "" Then
                        gridno = Val(dt_consume.Rows(i).Item("srno"))
                        congridno = Val(dt_consume.Rows(i).Item("consrno"))
                        itemname = dt_consume.Rows(i).Item("itemname")
                        QTY = Val(dt_consume.Rows(i).Item("QTY"))
                        UNIT = dt_consume.Rows(i).Item("UNIT")
                        NOCALC = Convert.ToBoolean(dt_consume.Rows(i).Item("NOCALC"))
                        rate = Val(dt_consume.Rows(i).Item("rate"))

                    Else


                        gridno = gridno & "|" & Val(dt_consume.Rows(i).Item("srno"))
                        congridno = congridno & "|" & Val(dt_consume.Rows(i).Item("consrno"))
                        itemname = itemname & "|" & (dt_consume.Rows(i).Item("itemname"))
                        QTY = QTY & "|" & Val(dt_consume.Rows(i).Item("QTY"))
                        UNIT = UNIT & "|" & dt_consume.Rows(i).Item("UNIT")
                        NOCALC = NOCALC & "|" & Convert.ToBoolean(dt_consume.Rows(i).Item("NOCALC"))
                        rate = rate & "|" & Val(dt_consume.Rows(i).Item("rate"))

                    End If
                End If
            Next

            alParaval.Add(gridno)
            alParaval.Add(congridno)
            alParaval.Add(itemname)
            alParaval.Add(QTY)
            alParaval.Add(UNIT)
            alParaval.Add(NOCALC)
            alParaval.Add(rate)

            Dim objDYEING As New ClsDyeingRecipe
            objDYEING.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objDYEING.SAVE()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPDYEINGID)
                IntResult = objDYEING.UPDATE()
                MsgBox("Details Updated")
            End If
            edit = False

            clear()
            edit = False
            cmbdyeingno.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Function errorvalid() As Boolean

        Dim bln As Boolean = True

        If cmbdyeingno.Text.Trim.Length = 0 Then
            EP.SetError(cmbdyeingno, "Fill Chart No")
            bln = False
        End If

        If (ClientName = "DHANLAXMI" Or ClientName = "MONOGRAM") And Val(TXTGMS.Text.Trim) = 0 Then
            EP.SetError(TXTGMS, "Enter Gms")
            bln = False
        End If

        If GRIDRECIPE.RowCount = 0 Then
            EP.SetError(txttotalcost, "Fill Recipe")
            bln = False
        End If


        'SET SRNO OF ALL THE ITEMS IN DT_CONSUME WITH RESPECT TO MAINSRNO
        For Each ROW As DataGridViewRow In GRIDRECIPE.Rows
            SETCONSUMESRNO(ROW.Cells(gsrno.Index).Value)
        Next

        Return bln
    End Function

    Sub SETCONSUMESRNO(ROWNO)
        Dim I As Integer = 0
        'For Each DTROW As DataRow In dt_consume.Select("srno=" & Val(ROWNO))
        '    I += 1
        '    DTROW("CONSRNO") = I
        'Next

        For j As Integer = 0 To dt_consume.Rows.Count - 1
            If dt_consume.Rows(j).Item(0) = ROWNO Then
                I += 1
                dt_consume.Rows(j).Item("CONSRNO") = I
            End If
        Next
    End Sub

    Sub clear()

        CHKBLOCKED.Checked = False
        TXTITEMSTOCK.Clear()
        TXTGMS.Clear()
        cmbdyeingno.Text = ""
        cmbmatching.Text = ""
        cmbitemname.Text = ""
        txtconsrno.Text = "1"
        txtsrno.Text = "1"
        txtperpcs.Clear()
        cmbprocess.Text = "DYEING"
        cmbmatching.Text = ""
        txttotalcost.Text = ""
        PBPHOTO.ImageLocation = ""
        CHKNOCALC.CheckState = CheckState.Unchecked
        dt_consume.Reset()
        dt_consume.Columns.Add("srno")
        dt_consume.Columns.Add("consrno")
        dt_consume.Columns.Add("itemname")
        dt_consume.Columns.Add("QTY")
        dt_consume.Columns.Add("UNIT")
        dt_consume.Columns.Add("NOCALC")
        dt_consume.Columns.Add("rate")
        gridconsume.RowCount = 0
        TXTPHOTOIMGPATH.Clear()
        congridDoubleClick = False
        gridDoubleClick = False

        txtremarks.Clear()

        'clearing grid
        GRIDRECIPE.RowCount = 0

    End Sub

    Sub fillcmb()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable


        dt = objclscommon.search("color_name", "", "ColorMaster", " and Color_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Color_name"
            cmbmatching.DataSource = dt
            cmbmatching.DisplayMember = "Color_name"
            cmbmatching.Text = ""
        End If

        fillunit(cmbunit)
        If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " AND PROCESSMASTER.PROCESS_TYPE='MFG'", edit)
        cmbprocess.Text = "DYEING"

        dt = objclscommon.search("DYEING_No", "", "DYEINGRecipe", " And DYEING_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "DYEING_No"
            cmbdyeingno.DataSource = dt
            cmbdyeingno.DisplayMember = "DYEING_No"
            cmbdyeingno.Text = ""
        End If


        dt = objclscommon.search("item_name", "", "ItemMaster", " and ITEM_FRMSTRING = 'ITEM' AND Item_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Item_name"
            cmbitemname.DataSource = dt
            cmbitemname.DisplayMember = "Item_name"
            cmbitemname.Text = ""
        End If


    End Sub

    Private Sub cmbitemname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.GotFocus
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " and ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " and ITEM_FRMSTRING = 'ITEM'", "ITEM")
            If cmbitemname.Text.Trim <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search("  ITEMMASTER_RATEDESC.ITEM_RATE ", "", "   ITEMMASTER INNER JOIN ITEMMASTER_RATEDESC ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID INNER JOIN RATETYPEMASTER ON ITEMMASTER_RATEDESC.ITEM_RATETYPEID = RATETYPEMASTER.RATETYPE_id ", " and ITEMMASTER.item_name = '" & cmbitemname.Text.Trim & "' and RATETYPEMASTER.RATETYPE_name='MASTER RATE' And ITEMMASTER.item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then txtrate.Text = dt.Rows(0).Item(0)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbDYEINGno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdyeingno.GotFocus
        Try
            If cmbdyeingno.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" DISTINCT DYEING_No", "", " DYEINGRecipe ", "  and DYEING_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "DYEING_No"
                    cmbdyeingno.DataSource = dt
                    cmbdyeingno.DisplayMember = "DYEING_No"
                    cmbdyeingno.Text = ""
                End If
                cmbdyeingno.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txttotalCOST_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txttotalcost.Validating
        Try
            If cmbmatching.Text.Trim <> "" Then
                If Not checkITEM("Receipe") Then
                    MsgBox("Item already Present in Grid below ")
                    Exit Sub
                End If

                fillgrid()
                cmbmatching.Text = ""
                txtperpcs.Clear()
                txttotalcost.Clear()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function checkITEM(ByVal grid As String) As Boolean
        Try
            Dim bln As Boolean = True
            If grid = "Receipe" Then
                For Each row As DataGridViewRow In GRIDRECIPE.Rows
                    If (gridDoubleClick = True And temprow <> row.Index) Or gridDoubleClick = False Then
                        If cmbmatching.Text.Trim = row.Cells(gMatching.Index).Value Then bln = False
                    End If
                Next

            End If
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillgrid()
        If gridDoubleClick = False Then
            GRIDRECIPE.Rows.Add(txtsrno.Text, cmbmatching.Text.Trim, txtperpcs.Text, Val(txttotalcost.Text))
            getsrno(GRIDRECIPE)

        ElseIf gridDoubleClick = True Then
            GRIDRECIPE.Item("Gsrno", temprow).Value = txtsrno.Text
            GRIDRECIPE.Item("Gmatching", temprow).Value = cmbmatching.Text.Trim
            GRIDRECIPE.Item("GperPCS", temprow).Value = txtperpcs.Text.Trim
            GRIDRECIPE.Item("Gtotalcost", temprow).Value = Val(txttotalcost.Text.Trim)
            gridDoubleClick = False
        End If
        GRIDRECIPE.FirstDisplayedScrollingRowIndex = GRIDRECIPE.RowCount - 1

        GRIDRECIPE.Rows(GRIDRECIPE.RowCount - 1).Selected = True
        GRIDRECIPE.CurrentCell = GRIDRECIPE.Item(0, GRIDRECIPE.RowCount - 1)
        txtsrno.Text = GRIDRECIPE.RowCount + 1

        gridconsume.RowCount = 0
        txtconsrno.Text = gridconsume.RowCount + 1

        txtperpcs.Clear()

        cmbmatching.Text = ""
        txttotalcost.Text = ""
        cmbitemname.Focus()

    End Sub

    Sub fillcongrid()
        If congridDoubleClick = False Then
            gridconsume.Rows.Add(txtconsrno.Text, cmbitemname.Text.Trim, Val(TXTQTY.Text), cmbunit.Text.Trim, CHKNOCALC.Checked, Val(txtrate.Text.Trim), GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(gsrno.Index).Value)
            dt_consume.Rows.Add(GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(0).Value, Val(txtconsrno.Text), cmbitemname.Text.Trim, Val(TXTQTY.Text), cmbunit.Text.Trim, CHKNOCALC.Checked, Val(txtrate.Text.Trim))
            getsrno(gridconsume)

        ElseIf congridDoubleClick = True Then
            For I As Integer = 0 To dt_consume.Rows.Count - 1
                If gridconsume.Item("Gconsrno", temprow).Value = dt_consume.Rows(I).Item("CONSRNO") And gridconsume.Item("GRECsrno", temprow).Value = dt_consume.Rows(I).Item("SRNO") Then
                    dt_consume.Rows(I).Item("itemname") = cmbitemname.Text
                    dt_consume.Rows(I).Item("QTY") = TXTQTY.Text.Trim
                    dt_consume.Rows(I).Item("UNIT") = cmbunit.Text.Trim
                    dt_consume.Rows(I).Item("NOCALC") = CHKNOCALC.Checked
                    dt_consume.Rows(I).Item("rate") = txtrate.Text.Trim
                End If
            Next
LINE1:
            gridconsume.Item("Gconsrno", temprow).Value = txtconsrno.Text
            gridconsume.Item("Gitemname", temprow).Value = cmbitemname.Text.Trim
            gridconsume.Item("GQTY", temprow).Value = TXTQTY.Text.Trim
            gridconsume.Item("gUNIT", temprow).Value = cmbunit.Text.Trim
            gridconsume.Item("GNOCALC", temprow).Value = CHKNOCALC.Checked
            gridconsume.Item("Grate", temprow).Value = txtrate.Text.Trim

            congridDoubleClick = False
        End If
        txtconsrno.Text = gridconsume.RowCount + 1
        cmbitemname.Text = ""

        TXTQTY.Clear()
        txtrate.Clear()

        cmbitemname.Focus()
    End Sub

    Sub total()
        If GRIDRECIPE.RowCount > 0 Then GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(gtotalCost.Index).Value = 0
        For Each row As DataGridViewRow In gridconsume.Rows
            GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(gtotalCost.Index).Value = GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(gtotalCost.Index).Value + (Val(row.Cells(gRate.Index).Value) * Val(row.Cells(gqty.Index).Value))
        Next
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

    Private Sub GRIDRECIPE_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRECIPE.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDRECIPE.Item("Gmatching", e.RowIndex).Value <> Nothing Then
                gridDoubleClick = True
                temprow = e.RowIndex
                txtsrno.Text = GRIDRECIPE.Item("Gsrno", e.RowIndex).Value

                cmbmatching.Text = GRIDRECIPE.Item("Gmatching", e.RowIndex).Value
                txtperpcs.Text = GRIDRECIPE.Item("GperPCS", e.RowIndex).Value
                txttotalcost.Text = GRIDRECIPE.Item("GTOTALcost", e.RowIndex).Value
                cmbitemname.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDRECIPE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDRECIPE.KeyDown
        If e.KeyCode = Keys.Delete Then
LINE1:
            For I As Integer = 0 To dt_consume.Rows.Count - 1
                If GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells("GSRNO").Value = Val(dt_consume.Rows(I).Item("SRNO")) Then
                    dt_consume.Rows.RemoveAt(I)
                    GoTo LINE1
                End If
            Next
            For I As Integer = 0 To dt_consume.Rows.Count - 1
                If GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells("GSRNO").Value < Val(dt_consume.Rows(I).Item("SRNO")) Then
                    dt_consume.Rows(I).Item("SRNO") = Val(dt_consume.Rows(I).Item("SRNO")) - 1

                End If
            Next
            GRIDRECIPE.Rows.RemoveAt(GRIDRECIPE.CurrentRow.Index)
            gridconsume.RowCount = 0

            getsrno(GRIDRECIPE)
        End If
    End Sub

    Private Sub cmbmatching_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmatching.GotFocus
        Try
            If cmbmatching.Text.Trim = "" Then fillCOLOR(cmbmatching)
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbmatching_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmatching.Validating
        Try

            If cmbmatching.Text.Trim <> "" Then
                COLORvalidate(cmbmatching, e, Me)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If TXTPHOTOIMGPATH.Text.Trim <> "" Then
                If Path.GetExtension(TXTPHOTOIMGPATH.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(TXTPHOTOIMGPATH.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.Image = PBPHOTO.Image
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrate.Validated
        Try
            If cmbitemname.Text.Trim <> "" Then
                If Not checkITEM("") Then
                    MsgBox("Item already Present in Grid below OR Total QTY Exceed")
                    Exit Sub
                End If

                fillcongrid()
                total()
                cmbitemname.Text = ""
                TXTQTY.Clear()
                txtrate.Clear()
                'cmbunit.Text = ""

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDRECIPE_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRECIPE.CellClick
        If GRIDRECIPE.Rows.Count > 0 Then
            gridconsume.RowCount = 0
            congridDoubleClick = False
            For i As Integer = 0 To dt_consume.Rows.Count - 1
                If dt_consume.Rows(i).Item(0) = GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(0).Value Then
                    gridconsume.Rows.Add(dt_consume.Rows(i).Item("CONSRNO"), dt_consume.Rows(i).Item("ITEMNAME"), dt_consume.Rows(i).Item("QTY"), dt_consume.Rows(i).Item("UNIT"), Convert.ToBoolean(dt_consume.Rows(i).Item("NOCALC")), dt_consume.Rows(i).Item("RATE"), dt_consume.Rows(i).Item("SRNO"))
                End If
            Next
            txtconsrno.Text = gridconsume.RowCount + 1
        End If
    End Sub

    Private Sub txtconsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtconsrno.GotFocus
        If gridconsume.RowCount > 0 Then
            txtconsrno.Text = Val(gridconsume.Rows(gridconsume.RowCount - 1).Cells(0).Value) + 1
        Else
            txtconsrno.Text = 1
        End If
    End Sub

    Private Sub txtsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsrno.GotFocus
        If GRIDRECIPE.RowCount > 0 Then
            txtsrno.Text = Val(GRIDRECIPE.Rows(GRIDRECIPE.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If
    End Sub

    Private Sub gridconsume_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridconsume.CellDoubleClick
        Try
            If e.RowIndex >= 0 And gridconsume.Item("GITEMNAME", e.RowIndex).Value <> Nothing Then
                congridDoubleClick = True
                temprow = e.RowIndex
                txtconsrno.Text = gridconsume.Item("Gconsrno", e.RowIndex).Value
                cmbitemname.Text = gridconsume.Item("GITEMNAME", e.RowIndex).Value
                TXTQTY.Text = gridconsume.Item("GQTY", e.RowIndex).Value
                cmbunit.Text = gridconsume.Item("GUNIT", e.RowIndex).Value
                CHKNOCALC.Checked = Convert.ToBoolean(gridconsume.Item("GNOCALC", e.RowIndex).Value)
                txtrate.Text = gridconsume.Item("GRATE", e.RowIndex).Value

                cmbitemname.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridconsume_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridconsume.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim del As Boolean = False
            If gridconsume.RowCount > 0 Then
                Dim row As Integer = gridconsume.Rows(gridconsume.CurrentRow.Index).Cells("GCONSRNO").Value
                For I As Integer = 0 To dt_consume.Rows.Count - 1
                    If GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells("GSRNO").Value = Val(dt_consume.Rows(I).Item("SRNO")) And gridconsume.Rows(gridconsume.CurrentRow.Index).Cells("GCONSRNO").Value = Val(dt_consume.Rows(I).Item("CONSRNO")) Then
                        If del = False Then
                            dt_consume.Rows.RemoveAt(I)
                            gridconsume.Rows.RemoveAt(gridconsume.CurrentRow.Index)
                            del = True
                            GoTo line1
                        End If
                    End If
                Next
line1:
                For I As Integer = 0 To dt_consume.Rows.Count - 1
                    If GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells("GSRNO").Value = Val(dt_consume.Rows(I).Item("SRNO")) And del = True And row < Val(dt_consume.Rows(I).Item("CONSRNO")) Then
                        dt_consume.Rows(I).Item("CONSRNO") = dt_consume.Rows(I).Item("CONSRNO") - 1
                    End If
                Next
                getsrno(gridconsume)
                total()
            End If
        End If
    End Sub

    Private Sub txtQTY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdot3(e, TXTQTY, Me)
    End Sub

    Private Sub TXTRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress, txtperpcs.KeyPress
        numdot(e, sender, Me)
    End Sub

    Private Sub cmbDYEINGno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdyeingno.Validating
        If cmbdyeingno.Text.Trim <> "" Then
            pcase(cmbdyeingno)
            Dim objclscommon As New ClsCommonMaster
            If (edit = False) Or (edit = True And LCase(cmbdyeingno.Text) <> LCase(TEMPDYEINGNO)) Then
                Dim dt As DataTable = objclscommon.search("DYEING_no", "", "DYEINGrecipe", " and DYEING_no = '" & cmbdyeingno.Text.Trim & "' And DYEING_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("DYEING Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub cmbunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.GotFocus
        Try
            If cmbunit.Text.Trim = "" Then fillunit(cmbunit)
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
        Try
            If cmbunit.Text.Trim <> "" Then unitvalidate(cmbunit, e, Me)
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validated(sender As Object, e As EventArgs) Handles cmbitemname.Validated
        Try
            TXTITEMSTOCK.Clear()
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String("SELECT ROUND(BALANCE,2) AS TOTALWT FROM STORESTOCK WHERE YEARID = " & YearId & " AND ITEMNAME = '" & cmbitemname.Text.Trim & "'", "", "")
            If DT.Rows.Count > 0 Then TXTITEMSTOCK.Text = Val(DT.Rows(0).Item("TOTALWT"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PBCOPYCHART_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBCOPYCHART.Click
        Try
            If (ClientName = "DHANLAXMI" Or ClientName = "MONOGRAM") And Val(TXTGMS.Text.Trim) <= 0 Then
                MsgBox("Enter Gms", MsgBoxStyle.Critical)
                TXTGMS.Focus()
                Exit Sub
            End If

            dt_SELECT.Clear()
            Dim OBJSELECTPO As New SelectDyeing
            OBJSELECTPO.ShowDialog()
            Dim objclscommon As New ClsCommonMaster
            For I As Integer = 0 To dt_SELECT.Rows.Count - 1
                GRIDRECIPE.Rows.Add(GRIDRECIPE.RowCount + 1, dt_SELECT.Rows(I).Item("MATCHING"), dt_SELECT.Rows(I).Item("PERPCS"), dt_SELECT.Rows(I).Item("TOTALCOST"))
                Dim dt As DataTable = objclscommon.search(" ITEMMASTER.item_name AS ITEMNAME, DYEINGRECIPE_CONSUMPTION.DYEING_QTY AS QTY, UNITMASTER.UNIT_ABBR AS UNIT,  ISNULL(DYEINGRECIPE_CONSUMPTION.DYEING_NOCALC,0) AS NOCALC, DYEINGRECIPE_CONSUMPTION.DYEING_RATE AS RATE", "", "    DYEINGRECIPE_CONSUMPTION INNER JOIN ITEMMASTER ON DYEINGRECIPE_CONSUMPTION.DYEING_ITEMID = ITEMMASTER.item_id AND DYEINGRECIPE_CONSUMPTION.DYEING_CMPID = ITEMMASTER.item_cmpid AND DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID = ITEMMASTER.item_locationid AND DYEINGRECIPE_CONSUMPTION.DYEING_YEARID = ITEMMASTER.item_yearid INNER JOIN UNITMASTER ON DYEINGRECIPE_CONSUMPTION.DYEING_UNITID = UNITMASTER.UNIT_id AND DYEINGRECIPE_CONSUMPTION.DYEING_CMPID = UNITMASTER.UNIT_cmpid AND DYEINGRECIPE_CONSUMPTION.DYEING_LOCATIONID = UNITMASTER.UNIT_locationid AND DYEINGRECIPE_CONSUMPTION.DYEING_YEARID = UNITMASTER.UNIT_yearid  ", "  AND DYEING_SRNO=" & dt_SELECT.Rows(I).Item("GRIDSRNO") & " AND DYEING_ID=" & dt_SELECT.Rows(I).Item("DYEINGID") & " and DYEING_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    For J As Integer = 0 To dt.Rows.Count - 1
                        If ClientName = "DHANLAXMI" Or ClientName = "MONOGRAM" Then
                            dt_consume.Rows.Add(GRIDRECIPE.RowCount, J + 1, dt.Rows(J).Item("ITEMNAME"), Format((Val(TXTGMS.Text.Trim) * Val(dt.Rows(J).Item("QTY"))) / Val(dt_SELECT.Rows(0).Item("GMS")), "0.000"), dt.Rows(J).Item("UNIT"), Convert.ToBoolean(dt.Rows(J).Item("NOCALC")), Val(dt.Rows(J).Item("RATE")))
                        Else
                            dt_consume.Rows.Add(GRIDRECIPE.RowCount, J + 1, dt.Rows(J).Item("ITEMNAME"), Val(dt.Rows(J).Item("QTY")), dt.Rows(J).Item("UNIT"), Convert.ToBoolean(dt.Rows(J).Item("NOCALC")), Val(dt.Rows(J).Item("RATE")))
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub pbcopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbcopy.Click
        If GRIDRECIPE.RowCount > 0 Then
            For Each ROW As DataGridViewRow In GRIDRECIPE.SelectedRows

                txtsrno.Text = GRIDRECIPE.RowCount + 1

                cmbmatching.Text = ROW.Cells("GMATCHING").Value
                txtperpcs.Text = ROW.Cells("Gperpcs").Value
                txttotalcost.Text = ROW.Cells("GTOTALCOST").Value
                Dim DT1 As New DataTable
                DT1.Columns.Add("srno")
                DT1.Columns.Add("consrno")
                DT1.Columns.Add("itemname")
                DT1.Columns.Add("qty")
                DT1.Columns.Add("unit")
                DT1.Columns.Add("NOCALC")
                DT1.Columns.Add("rate")
                For I As Integer = 0 To dt_consume.Rows.Count - 1
                    If dt_consume.Rows(I).Item("SRNO") = ROW.Cells("GSRNO").Value Then
                        DT1.Rows.Add(txtsrno.Text, I + 1, dt_consume.Rows(I).Item("ITEMNAME"), dt_consume.Rows(I).Item("QTY"), dt_consume.Rows(I).Item("UNIT"), Convert.ToBoolean(dt_consume.Rows(I).Item("NOCALC")), dt_consume.Rows(I).Item("RATE"))
                    End If
                Next
                For I As Integer = 0 To DT1.Rows.Count - 1
                    dt_consume.Rows.Add(txtsrno.Text, I + 1, DT1.Rows(I).Item("ITEMNAME"), DT1.Rows(I).Item("QTY"), DT1.Rows(I).Item("UNIT"), Convert.ToBoolean(DT1.Rows(I).Item("NOCALC")), DT1.Rows(I).Item("RATE"))
                Next
            Next


        End If
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then
                If MsgBox("Wish To Delete Dyeing Recipe?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim OBJDYEING As New ClsDyeingRecipe
                OBJDYEING.alParaval.Add(TEMPDYEINGID)
                OBJDYEING.alParaval.Add(YearId)
                Dim DT As DataTable = OBJDYEING.Delete()
                MsgBox(DT.Rows(0).Item(0))
                edit = False
                clear()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGMS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTGMS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub DyeingRecipe_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "DHANLAXMI" Or ClientName = "MONOGRAM" Then
                gPerPcs.HeaderText = "Per Mtrs"
                LBLGM.Visible = True
                TXTGMS.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class