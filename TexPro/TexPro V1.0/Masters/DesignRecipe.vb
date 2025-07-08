
Imports BL
Imports System.IO

Public Class DesignRecipe

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim congridDoubleClick As Boolean
    Public edit As Boolean          'used for editing
    Public TEMPDESIGNID As String
    Public TEMPDESIGNNO As String
    Public TEMPMERCHANT As String
    Dim temprow As Integer
    Dim dt_consume As New DataTable
    Public Shared dt_SELECT As New DataTable
    Dim OLDIMGPATH As String = ""
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

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

    Private Sub DesignRecipe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
        End If
    End Sub

    Private Sub DesignRecipe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'DESIGN MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            dt_consume.Reset()
            dt_consume.Columns.Add("srno")
            dt_consume.Columns.Add("consrno")
            dt_consume.Columns.Add("itemname")
            dt_consume.Columns.Add("part")
            dt_consume.Columns.Add("rate")
            dt_consume.Columns.Add("cost")
            dt_consume.Columns.Add("COLOR")
            'clear()
            fillcmb()
            cmbdesignno.Text = TEMPDESIGNNO

            If edit = True Then
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objclsJO As New ClsDesignRecipe()
                Dim dttable As New DataTable

                dttable = objclsJO.selectdesign(TEMPDESIGNNO, TEMPMERCHANT, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows
                        TEMPDESIGNID = dr("designid").ToString
                        cmbprocess.Text = dr("PROCESS").ToString
                        txtremarks.Text = dr("remarks").ToString
                        cmbmerchant.Text = dr("MERCHANT").ToString
                        txtcolBill1.Text = Val(dr("COLBILL1"))
                        txtcolBill2.Text = Val(dr("COLBILL2"))
                        GRIDRECIPE.Rows.Add(Val(dr("GRIDSRNO").ToString), dr("color").ToString, dr("SCREEN").ToString, Val(dr("SHADE").ToString), Val(dr("percent").ToString), Val(dr("totalpart").ToString), Val(dr("totalcost").ToString))

                        If IsDBNull(dttable.Rows(0).Item("IMGPATH")) = False Then
                            PBPHOTO.Image = Image.FromStream(New IO.MemoryStream(DirectCast(dttable.Rows(0).Item("IMGPATH"), Byte())))
                            TXTPHOTOIMGPATH.Text = dttable.Rows(0).Item("IMGPATH").ToString
                        Else
                            PBPHOTO.Image = Nothing
                        End If


                    Next
                End If

                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" DESIGNRECIPE_CONSUMPTION.DESIGN_SRNO AS SRNO, DESIGNRECIPE_CONSUMPTION.DESIGN_CONSRNO AS CONSRNO, ITEMMASTER.item_name AS ITEMNAME, DESIGNRECIPE_CONSUMPTION.DESIGN_PART AS PART, DESIGNRECIPE_CONSUMPTION.DESIGN_RATE AS RATE, DESIGNRECIPE_CONSUMPTION.DESIGN_COST AS COST, COLORMASTER.COLOR_name AS COLOR ", "", "  DESIGNRECIPE_CONSUMPTION INNER JOIN ITEMMASTER ON DESIGNRECIPE_CONSUMPTION.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN COLORMASTER ON DESIGNRECIPE_CONSUMPTION.DESIGN_COLORID = COLORMASTER.COLOR_id AND DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID = COLORMASTER.COLOR_cmpid AND DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID = COLORMASTER.COLOR_locationid AND DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID = COLORMASTER.COLOR_yearid ", " AND DESIGNRECIPE_CONSUMPTION.DESIGN_ID = " & TEMPDESIGNID & " AND DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID = " & CmpId & " AND DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID  = " & Locationid & " AND DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DR As DataRow In dttable.Rows
                        dt_consume.Rows.Add(DR("SRNO").ToString, DR("CONSRNO").ToString, DR("ITEMNAME").ToString, Format(DR("PART"), "0.00"), Format(DR("RATE"), "0.00"), Format(DR("COST"), "0.00"), DR("COLOR").ToString)
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

            alParaval.Add(cmbdesignno.Text.Trim)
            alParaval.Add(cmbmerchant.Text.Trim)
            alParaval.Add(cmbprocess.Text.Trim)

            If PBPHOTO.Image IsNot Nothing Then
                Dim MS As New IO.MemoryStream
                PBPHOTO.Image.Save(MS, Drawing.Imaging.ImageFormat.Png)
                alParaval.Add(MS.ToArray)
            Else
                alParaval.Add(DBNull.Value)
            End If

            alParaval.Add(txtcolBill1.Text.Trim)
            alParaval.Add(txtcolBill2.Text.Trim)

            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim MATCHING As String = ""
            Dim SCREEN As String = ""
            Dim Per As String = ""
            Dim SHADE As String = ""
            Dim totalpart As String = ""
            Dim totalcost As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDRECIPE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value
                        MATCHING = row.Cells(gMatching.Index).Value.ToString
                        SCREEN = row.Cells(gscreen.Index).Value.ToString
                        SHADE = row.Cells(gshade.Index).Value
                        Per = row.Cells(gPer.Index).Value
                        totalpart = row.Cells(Gtotalpart.Index).Value
                        totalcost = row.Cells(gtotalCost.Index).Value

                    Else

                        gridsrno = gridsrno & "," & row.Cells(gsrno.Index).Value
                        MATCHING = MATCHING & "," & row.Cells(gMatching.Index).Value.ToString
                        SCREEN = SCREEN & "," & row.Cells(gscreen.Index).Value.ToString
                        SHADE = SHADE & "," & row.Cells(gshade.Index).Value
                        Per = Per & "," & row.Cells(gPer.Index).Value
                        totalpart = totalpart & "," & row.Cells(Gtotalpart.Index).Value
                        totalcost = totalcost & "," & row.Cells(gtotalCost.Index).Value


                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(MATCHING)
            alParaval.Add(SCREEN)
            alParaval.Add(SHADE)
            alParaval.Add(Per)
            alParaval.Add(totalpart)
            alParaval.Add(totalcost)




            Dim gridno As String = ""
            Dim congridno As String = ""
            Dim itemname As String = ""
            Dim part As String = ""
            Dim rate As String = ""
            Dim cost As String = ""
            Dim COLOR As String = ""

            For i As Integer = 0 To dt_consume.Rows.Count - 1
                If dt_consume.Rows(i).Item(0) <> Nothing Then
                    If gridno = "" Then
                        gridno = Val(dt_consume.Rows(i).Item("srno"))
                        congridno = Val(dt_consume.Rows(i).Item("consrno"))
                        itemname = dt_consume.Rows(i).Item("itemname")
                        part = Val(dt_consume.Rows(i).Item("part"))
                        rate = Val(dt_consume.Rows(i).Item("rate"))
                        cost = Val(dt_consume.Rows(i).Item("cost"))
                        COLOR = dt_consume.Rows(i).Item("COLOR")

                    Else


                        gridno = gridno & "," & Val(dt_consume.Rows(i).Item("srno"))
                        congridno = congridno & "," & Val(dt_consume.Rows(i).Item("consrno"))
                        itemname = itemname & "," & (dt_consume.Rows(i).Item("itemname"))
                        part = part & "," & Val(dt_consume.Rows(i).Item("part"))
                        rate = rate & "," & Val(dt_consume.Rows(i).Item("rate"))
                        cost = cost & "," & Val(dt_consume.Rows(i).Item("cost"))
                        COLOR = COLOR & "," & dt_consume.Rows(i).Item("COLOR")

                    End If
                End If
            Next

            alParaval.Add(gridno)
            alParaval.Add(congridno)
            alParaval.Add(itemname)
            alParaval.Add(part)
            alParaval.Add(rate)
            alParaval.Add(cost)
            alParaval.Add(color)





            Dim objDESIGN As New ClsDesignRecipe
            objDESIGN.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objDESIGN.save()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPDESIGNID)
                IntResult = objDESIGN.update()
                MsgBox("Details Updated")
            End If
            edit = False


            clear()
            edit = False
            cmbdesignno.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Function errorvalid() As Boolean

        Dim bln As Boolean = True

        If cmbdesignno.Text.Trim.Length = 0 Then
            EP.SetError(cmbdesignno, "Fill Design No")
            bln = False
        End If
        If cmbmerchant.Text.Trim.Length = 0 Then
            EP.SetError(cmbmerchant, "Fill MERCHANT")
            bln = False
        End If
        If cmbdesignno.Text.Trim <> "" And cmbmerchant.Text <> "" Then
            pcase(cmbdesignno)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (edit = False) Or (edit = True And LCase(cmbdesignno.Text) <> LCase(TEMPDESIGNNO) And LCase(cmbmerchant.Text) <> LCase(TEMPMERCHANT)) Then
                dt = objclscommon.search("design_no", "", " DESIGNRECIPE INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid", " and design_no = '" & cmbdesignno.Text.Trim & "' and item_name = '" & cmbmerchant.Text.Trim & "' And design_cmpid = " & CmpId & " And design_locationid = " & Locationid & " And design_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("design and Merchant Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                    bln = False

                End If
            End If
        End If

        If GRIDRECIPE.RowCount = 0 Then
            EP.SetError(txttotalpart, "Fill Recipe")
            bln = False
        End If

        Return bln
    End Function

    Sub clear()
        OLDIMGPATH = ""
        cmbmerchant.Text = ""
        cmbdesignno.Text = ""
        cmbmatching.Text = ""
        cmbitemname.Text = ""
        cmbprocess.Text = "PRINTING"
        txtshade.Clear()
        txttotalpart.Clear()
        txtconsrno.Text = "1"
        txtsrno.Text = "1"
        txtpercent.Clear()
        txtshade.Clear()
        TEMPDESIGNNO = ""
        TEMPMERCHANT = ""
        cmbmatching.Text = ""
        txttotalpart.Clear()
        txttotalcost.Text = ""
        PBPHOTO.ImageLocation = ""
        dt_consume.Reset()
        dt_consume.Columns.Add("srno")
        dt_consume.Columns.Add("consrno")
        dt_consume.Columns.Add("itemname")
        dt_consume.Columns.Add("part")
        dt_consume.Columns.Add("rate")
        dt_consume.Columns.Add("cost")
        dt_consume.Columns.Add("COLOR")
        gridconsume.RowCount = 0
        TXTPHOTOIMGPATH.Clear()
        congridDoubleClick = False
        gridDoubleClick = False

        txtremarks.Clear()
        TXTITEMSTOCK.Clear()

        'clearing grid
        GRIDRECIPE.RowCount = 0

    End Sub

    Sub fillcmb()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable


        dt = objclscommon.search("color_name", "", "ColorMaster", " and Color_cmpid = " & CmpId & " and Color_locationid = " & Locationid & " and Color_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Color_name"
            cmbmatching.DataSource = dt
            cmbmatching.DisplayMember = "Color_name"
            cmbmatching.Text = ""
        End If

        If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " AND PROCESSMASTER.PROCESS_TYPE='MFG2'", edit)
        cmbprocess.Text = "PRINTING"

        dt = objclscommon.search("design_No", "", "DesignRecipe", " AND Design_cmpid = " & CmpId & " and Design_locationid = " & Locationid & " and Design_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "Design_No"
            cmbdesignno.DataSource = dt
            cmbdesignno.DisplayMember = "Design_No"
            cmbdesignno.Text = ""
        End If

        fillscreen(cmbscreen)
        fillitemname(cmbmerchant, " AND itemmaster.ITEM_FRMSTRING = 'MERCHANT'")
        dt = objclscommon.search("item_name", "", "ItemMaster", " and ITEM_FRMSTRING = 'ITEM' AND  Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
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
                Dim dt As DataTable
                dt = objclscommon.search("  ITEMMASTER_RATEDESC.ITEM_RATE ", "", "   ITEMMASTER INNER JOIN ITEMMASTER_RATEDESC ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID AND ITEMMASTER.item_cmpid = ITEMMASTER_RATEDESC.ITEM_CMPID AND ITEMMASTER.item_locationid = ITEMMASTER_RATEDESC.ITEM_LOCATIONID AND ITEMMASTER.item_yearid = ITEMMASTER_RATEDESC.ITEM_YEARID INNER JOIN RATETYPEMASTER ON ITEMMASTER_RATEDESC.ITEM_RATETYPEID = RATETYPEMASTER.RATETYPE_id AND ITEMMASTER_RATEDESC.ITEM_CMPID = RATETYPEMASTER.RATETYPE_cmpid AND ITEMMASTER_RATEDESC.ITEM_LOCATIONID = RATETYPEMASTER.RATETYPE_locationid AND ITEMMASTER_RATEDESC.ITEM_YEARID = RATETYPEMASTER.RATETYPE_yearid", " and ITEMMASTER.item_name = '" & cmbitemname.Text.Trim & "' and RATETYPEMASTER.RATETYPE_name='MASTER RATE' And ITEMMASTER.item_cmpid = " & CmpId & " And ITEMMASTER.item_locationid = " & Locationid & " And ITEMMASTER.item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    txtrate.Text = dt.Rows(0).Item(0)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub cmbdesignno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesignno.GotFocus
        Try
            If cmbdesignno.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" DISTINCT Design_No", "", " DesignRecipe ", "  and Design_cmpid = " & CmpId & " and Design_locationid = " & Locationid & " and Design_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Design_No"
                    cmbdesignno.DataSource = dt
                    cmbdesignno.DisplayMember = "Design_No"
                    cmbdesignno.Text = ""
                End If
                cmbdesignno.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txttotalpart_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txttotalpart.Validating
        Try
            If cmbmatching.Text.Trim <> "" Then
                If Not checkITEM("Receipe") Then
                    MsgBox("Item already Present in Grid below ")
                    Exit Sub
                End If

                fillgrid()
                'cmbmatching.Text = ""
                txttotalpart.Clear()


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
                        If cmbmatching.Text.Trim = row.Cells(gMatching.Index).Value And Val(txtshade.Text.Trim) = row.Cells(gshade.Index).Value And cmbscreen.Text.Trim = row.Cells(gscreen.Index).Value Then bln = False
                    End If
                Next
            Else
                Dim part As Integer = Val(txtpart.Text)
                For Each row As DataGridViewRow In gridconsume.Rows
                    If (congridDoubleClick = True And temprow <> row.Index) Or congridDoubleClick = False Then
                        If cmbitemname.Text.Trim = row.Cells(gitemname.Index).Value Then bln = False
                    End If
                    If congridDoubleClick = True Then
                        If temprow = row.Index Then
                            GoTo LINE2
                        End If
                        part = part + Val(row.Cells(gpart.Index).Value)
LINE2:
                    Else
                        part = part + Val(row.Cells(gpart.Index).Value)
                    End If
                    If part > GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(Gtotalpart.Index).Value Then bln = False
                Next
            End If
            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Sub fillgrid()
        If gridDoubleClick = False Then
            GRIDRECIPE.Rows.Add(txtsrno.Text, cmbmatching.Text.Trim, cmbscreen.Text.Trim, Val(txtshade.Text.Trim), Val(txtpercent.Text), Val(txttotalpart.Text.Trim), Val(txttotalcost.Text))
            getsrno(GRIDRECIPE)

        ElseIf gridDoubleClick = True Then
            GRIDRECIPE.Item("Gsrno", temprow).Value = txtsrno.Text
            GRIDRECIPE.Item("Gmatching", temprow).Value = cmbmatching.Text.Trim
            GRIDRECIPE.Item("Gscreen", temprow).Value = cmbscreen.Text.Trim
            GRIDRECIPE.Item("Gshade", temprow).Value = Val(txtshade.Text.Trim)
            GRIDRECIPE.Item("Gper", temprow).Value = txtpercent.Text.Trim
            GRIDRECIPE.Item("Gtotalpart", temprow).Value = Val(txttotalpart.Text.Trim)
            GRIDRECIPE.Item("Gtotalcost", temprow).Value = Val(txttotalcost.Text.Trim)
            gridDoubleClick = False
        End If
        GRIDRECIPE.FirstDisplayedScrollingRowIndex = GRIDRECIPE.RowCount - 1

        GRIDRECIPE.Rows(GRIDRECIPE.RowCount - 1).Selected = True
        GRIDRECIPE.CurrentCell = GRIDRECIPE.Item(0, GRIDRECIPE.RowCount - 1)
        txtsrno.Clear()
        If GRIDRECIPE.RowCount > 0 Then
            txtsrno.Text = Val(GRIDRECIPE.Rows(GRIDRECIPE.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If
        gridconsume.RowCount = 0

        If gridconsume.RowCount > 0 Then
            txtconsrno.Text = Val(gridconsume.Rows(gridconsume.RowCount - 1).Cells(0).Value) + 1
        Else
            txtconsrno.Text = 1
        End If
        txtpercent.Clear()
        txtshade.Clear()

        'cmbmatching.Text = ""
        cmbscreen.Text = ""
        txttotalpart.Clear()
        txttotalcost.Text = ""
        txtconsrno.Focus()
    End Sub
    Sub fillcongrid()
        If congridDoubleClick = False Then
            gridconsume.Rows.Add(txtconsrno.Text, cmbitemname.Text.Trim, Val(txtpart.Text), Val(txtrate.Text.Trim), Val(txtcost.Text.Trim), GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(gsrno.Index).Value, GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(gMatching.Index).Value)
            dt_consume.Rows.Add(GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(0).Value, Val(txtconsrno.Text), cmbitemname.Text.Trim, Val(txtpart.Text), Val(txtrate.Text.Trim), Val(txtcost.Text.Trim), GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(gMatching.Index).Value.ToString)
            getsrno(gridconsume)

        ElseIf congridDoubleClick = True Then
            For I As Integer = 0 To dt_consume.Rows.Count - 1
                If gridconsume.Item("Gconsrno", temprow).Value = dt_consume.Rows(I).Item("CONSRNO") And gridconsume.Item("GRECsrno", temprow).Value = dt_consume.Rows(I).Item("SRNO") Then
                    dt_consume.Rows(I).Item("itemname") = cmbitemname.Text
                    dt_consume.Rows(I).Item("part") = txtpart.Text.Trim
                    dt_consume.Rows(I).Item("rate") = txtrate.Text.Trim
                    dt_consume.Rows(I).Item("cost") = txtcost.Text.Trim
                End If
            Next
LINE1:
            gridconsume.Item("Gconsrno", temprow).Value = txtconsrno.Text
            gridconsume.Item("Gitemname", temprow).Value = cmbitemname.Text.Trim
            gridconsume.Item("Gpart", temprow).Value = txtpart.Text.Trim
            gridconsume.Item("Grate", temprow).Value = txtrate.Text.Trim
            gridconsume.Item("Gcost", temprow).Value = txtcost.Text.Trim
            'dt_consume.Rows.Add(GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(0).Value, Val(txtconsrno.Text), cmbitemname.Text.Trim, Val(txtpart.Text), Val(txtrate.Text.Trim), Val(txtcost.Text.Trim), GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(gMatching.Index).Value.ToString)

            congridDoubleClick = False
        End If
        txtconsrno.Clear()
        cmbitemname.Text = ""
        txtpart.Clear()
        txtcost.Clear()
        txtrate.Clear()

        If gridconsume.RowCount > 0 Then
            txtconsrno.Text = Val(gridconsume.Rows(gridconsume.RowCount - 1).Cells(0).Value) + 1
        Else
            txtconsrno.Text = 1
        End If
        txtconsrno.Focus()
    End Sub

    Sub total()
        If GRIDRECIPE.RowCount > 0 Then GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(gtotalCost.Index).Value = 0
        For Each row As DataGridViewRow In gridconsume.Rows
            GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(gtotalCost.Index).Value = GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(gtotalCost.Index).Value + Val(row.Cells(gcost.Index).Value)
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
                cmbscreen.Text = GRIDRECIPE.Item("Gscreen", e.RowIndex).Value
                txttotalpart.Text = GRIDRECIPE.Item("Gtotalpart", e.RowIndex).Value
                txtshade.Text = GRIDRECIPE.Item("GSHADE", e.RowIndex).Value
                txtpercent.Text = GRIDRECIPE.Item("Gper", e.RowIndex).Value
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

    Private Sub cmbscreen_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbscreen.GotFocus
        Try

            If cmbscreen.Text.Trim = "" Then fillscreen(cmbscreen)
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbscreen_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbscreen.Validating
        Try

            If cmbscreen.Text.Trim <> "" Then
                screenvalidate(cmbscreen, e, Me)
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


    Private Sub txtpart_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpart.Validating
        If Val(txtpart.Text) <> 0 Then
            txtcost.Text = GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(gPer.Index).Value * Val(txtpart.Text) / GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(Gtotalpart.Index).Value / 100 * Val(txtrate.Text)

        Else
            txtcost.Text = Val(txtrate.Text)
        End If

    End Sub



    Private Sub txtcost_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcost.Validated
        Try
            If cmbitemname.Text.Trim <> "" Then
                If Not checkITEM("") Then
                    MsgBox("Item already Present in Grid below OR Total Part Exceed")
                    Exit Sub
                End If

                fillcongrid()
                total()
                cmbitemname.Text = ""
                txtpart.Clear()
                txtrate.Clear()


            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtrate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtrate.Validated
        If Val(txtpart.Text) <> 0 Then
            txtcost.Text = Val(GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(gPer.Index).Value) * Val(txtpart.Text) / GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(Gtotalpart.Index).Value / 100 * Val(txtrate.Text)
        Else
            txtcost.Text = Val(txtrate.Text)
        End If

    End Sub

    Private Sub GRIDRECIPE_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDRECIPE.CellClick
        If GRIDRECIPE.Rows.Count > 0 Then
            gridconsume.RowCount = 0
            congridDoubleClick = False
            For i As Integer = 0 To dt_consume.Rows.Count - 1
                If dt_consume.Rows(i).Item(0) = GRIDRECIPE.Rows(GRIDRECIPE.CurrentRow.Index).Cells(0).Value Then
                    gridconsume.Rows.Add(dt_consume.Rows(i).Item(1), dt_consume.Rows(i).Item(2), dt_consume.Rows(i).Item(3), dt_consume.Rows(i).Item(4), dt_consume.Rows(i).Item(5), dt_consume.Rows(i).Item(0), dt_consume.Rows(i).Item(6))
                End If
            Next
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
                txtpart.Text = gridconsume.Item("Gpart", e.RowIndex).Value
                txtrate.Text = gridconsume.Item("GRATE", e.RowIndex).Value
                txtcost.Text = gridconsume.Item("Gcost", e.RowIndex).Value

                cmbitemname.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub gridconsume_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridconsume.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim del As Boolean = False
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
    End Sub


    Private Sub txtshade_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtshade.KeyPress
        numdot(e, txtshade, Me)
    End Sub

    Private Sub txtpercent_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpercent.KeyPress
        numdot(e, txtpercent, Me)
    End Sub

    Private Sub txttotalpart_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttotalpart.KeyPress
        numdot(e, txttotalpart, Me)

    End Sub

    Private Sub txtpart_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpart.KeyPress
        numdot(e, txtpart, Me)

    End Sub

    Private Sub txtrate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtrate.KeyPress
        numdot(e, txtrate, Me)

    End Sub

    Private Sub txtcost_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcost.KeyPress
        numdot(e, txtcost, Me)

    End Sub



    Private Sub cmbdesignno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdesignno.Validating
        If cmbdesignno.Text.Trim <> "" And cmbmerchant.Text <> "" Then
            pcase(cmbdesignno)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (edit = False) Or (edit = True And LCase(cmbdesignno.Text) <> LCase(TEMPDESIGNNO) And LCase(cmbmerchant.Text) <> LCase(TEMPMERCHANT)) Then
                dt = objclscommon.search("design_no", "", " DESIGNRECIPE INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid", " and design_no = '" & cmbdesignno.Text.Trim & "' and item_name = '" & cmbmerchant.Text.Trim & "' And design_cmpid = " & CmpId & " And design_locationid = " & Locationid & " And design_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("design and Merchant Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                    e.Cancel = True

                End If
            End If
        End If
    End Sub

    Private Sub pbcopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbcopy.Click
        If GRIDRECIPE.RowCount > 0 Then
            For Each ROW As DataGridViewRow In GRIDRECIPE.SelectedRows

                txtsrno.Text = Val(GRIDRECIPE.Rows(GRIDRECIPE.RowCount - 1).Cells(0).Value) + 1

                cmbmatching.Text = ROW.Cells("GMATCHING").Value
                cmbscreen.Text = ROW.Cells("GSCREEN").Value
                txtshade.Text = ROW.Cells("GSHADE").Value
                txtpercent.Text = ROW.Cells("Gper").Value
                txttotalpart.Text = ROW.Cells("GTOTALPART").Value
                txttotalcost.Text = ROW.Cells("GTOTALCOST").Value
                Dim DT1 As New DataTable
                DT1.Columns.Add("srno")
                DT1.Columns.Add("consrno")
                DT1.Columns.Add("itemname")
                DT1.Columns.Add("part")
                DT1.Columns.Add("rate")
                DT1.Columns.Add("cost")
                DT1.Columns.Add("COLOR")
                For I As Integer = 0 To dt_consume.Rows.Count - 1
                    If dt_consume.Rows(I).Item("SRNO") = ROW.Cells("GSRNO").Value Then
                        DT1.Rows.Add(txtsrno.Text, I + 1, dt_consume.Rows(I).Item("ITEMNAME"), dt_consume.Rows(I).Item("PART"), dt_consume.Rows(I).Item("RATE"), dt_consume.Rows(I).Item("COST"), dt_consume.Rows(I).Item("COLOR"))
                    End If
                Next
                For I As Integer = 0 To DT1.Rows.Count - 1
                    dt_consume.Rows.Add(txtsrno.Text, I + 1, DT1.Rows(I).Item("ITEMNAME"), DT1.Rows(I).Item("PART"), DT1.Rows(I).Item("RATE"), DT1.Rows(I).Item("COST"), DT1.Rows(I).Item("COLOR"))
                Next
            Next


        End If
    End Sub
    Private Sub cmbmerchant_enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmerchant.Enter
        Try
            If cmbmerchant.Text.Trim = "" Then fillitemname(cmbmerchant, " AND itemmaster.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbmerchant_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbmerchant.Validating
        Try
            If cmbmerchant.Text.Trim <> "" Then itemvalidate(cmbmerchant, e, Me, " AND itemmaster.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        dt_SELECT.Clear()
        Dim OBJSELECTPO As New selectdesign
        OBJSELECTPO.ShowDialog()
        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable
        For I As Integer = 0 To dt_SELECT.Rows.Count - 1
            GRIDRECIPE.Rows.Add(GRIDRECIPE.RowCount + 1, dt_SELECT.Rows(I).Item("MATCHING"), dt_SELECT.Rows(I).Item("SCREEN"), dt_SELECT.Rows(I).Item("SHADE"), dt_SELECT.Rows(I).Item("PERCENT"), dt_SELECT.Rows(I).Item("TOTALPART"), dt_SELECT.Rows(I).Item("TOTALCOST"))

            dt = objclscommon.search(" ITEMMASTER.item_name, DESIGNRECIPE_CONSUMPTION.DESIGN_PART, DESIGNRECIPE_CONSUMPTION.DESIGN_RATE, DESIGNRECIPE_CONSUMPTION.DESIGN_COST, COLORMASTER.COLOR_name ", "", "    DESIGNRECIPE_CONSUMPTION INNER JOIN ITEMMASTER ON DESIGNRECIPE_CONSUMPTION.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID = ITEMMASTER.item_yearid INNER JOIN COLORMASTER ON DESIGNRECIPE_CONSUMPTION.DESIGN_COLORID = COLORMASTER.COLOR_id AND DESIGNRECIPE_CONSUMPTION.DESIGN_CMPID = COLORMASTER.COLOR_cmpid AND DESIGNRECIPE_CONSUMPTION.DESIGN_LOCATIONID = COLORMASTER.COLOR_locationid AND DESIGNRECIPE_CONSUMPTION.DESIGN_YEARID = COLORMASTER.COLOR_yearid  ", "  AND DESIGN_SRNO=" & dt_SELECT.Rows(I).Item("GRIDSRNO") & " AND DESIGN_ID=" & dt_SELECT.Rows(I).Item("DESIGNID") & " and Design_cmpid = " & CmpId & " and Design_locationid = " & Locationid & " and Design_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                For J As Integer = 0 To dt.Rows.Count - 1
                    dt_consume.Rows.Add(GRIDRECIPE.RowCount, J + 1, dt.Rows(J).Item(0), dt.Rows(J).Item(1), dt.Rows(J).Item(2), dt.Rows(J).Item(3), Format(dt.Rows(J).Item(4), "0.000"))

                Next
            End If
        Next
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbmerchant.Focus()
    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            gridconsume.RowCount = 0
            GRIDRECIPE.RowCount = 0

            TEMPDESIGNID = TEMPDESIGNID - 1
            If TEMPDESIGNID > 0 Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("design_no,isnull(item_name,'') as Itemname ", "", " DESIGNRECIPE left outer JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid", " and design_id = " & TEMPDESIGNID & " And design_cmpid = " & CmpId & " And design_locationid = " & Locationid & " And design_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    TEMPDESIGNNO = dt.Rows(0).Item(0)
                    TEMPMERCHANT = dt.Rows(0).Item(1).ToString

                End If
                edit = True
                DesignRecipe_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub txtcolBill1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcolBill1.KeyPress
        numdot(e, txtcolBill1, Me)
    End Sub

    Private Sub txtcolBill2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcolBill2.KeyPress
        numdot(e, txtcolBill2, Me)
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJDesignRecipeDetails As New DesignRecipeDetails
            OBJDesignRecipeDetails.MdiParent = MDIMain
            OBJDesignRecipeDetails.Show()
            OBJDesignRecipeDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        cmddelete_Click(sender, e)
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        If edit = True Then
            Dim OBJGN As New MasterDesign
            OBJGN.MdiParent = MDIMain
            OBJGN.selfor_po = "{design.process}='" & cmbprocess.Text & "' and  {design.merchant}='" & cmbmerchant.Text.Trim & "' and  {design.designno}='" & cmbdesignno.Text.Trim & "' and {design.yearid}=" & YearId
            OBJGN.Show()
        End If
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then

                If MsgBox("Delete Design?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim OBJDESIGN As New ClsDesignRecipe
                OBJDESIGN.alParaval.Add(TEMPDESIGNID)
                OBJDESIGN.alParaval.Add(YearId)
                Dim DTTABLE As DataTable = OBJDESIGN.DELETE()
                MsgBox(DTTABLE.Rows(0).Item(0))
                edit = False
                clear()
            End If
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
End Class