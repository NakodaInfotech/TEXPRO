
Imports BL
Imports System.IO
Imports System.ComponentModel

Public Class GRN

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADdoubleclick, GRIDBLEACHDOUBLECLICK As Boolean
    Public partychallan, partyinv, transref As String      'used for refno, challan, inv while edit mode
    Public edit As Boolean          'used for editing
    Public tempgrnno As Integer     'used for poation no while editing
    Public temptypename As String     'used for poation no while editing
    Dim temprow, TEMPBLEACHROW As Integer
    Dim tempUPLOADrow As Integer
    Public Shared selectPOtable As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Public FRMSTRING As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()
        EP.Clear()
        tstxtbillno.Clear()
        txtgrnno.Clear()

        If ALLOWMANUALLOTNO = True Then
            txtgrnno.ReadOnly = False
            txtgrnno.BackColor = Color.LemonChiffon
        Else
            txtgrnno.ReadOnly = True
            txtgrnno.BackColor = Color.Linen
        End If
        gridgrn.ReadOnly = False

        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""
        cmbname.Enabled = True
        cmbname.Text = ""
        CMBWEAVER.Text = ""
        CMBBROKER.Text = ""
        CMBSENDER.Text = ""
        CMBQUALITY.Text = ""
        TXTRATE.Clear()
        TXTGREYWIDTH.Clear()

        dtpchallan.Value = Mydate
        txtchallan.Clear()
        TXTEWBNO.Clear()
        txtpono.Clear()
        podate.Value = Mydate
        If cmbtype.Items.Count > 0 Then cmbtype.SelectedIndex = (0)

        txtadd.Clear()
        grndate.Value = Mydate

        cmbtrans.Text = ""
        txtlrno.Clear()
        lrdate.Value = Mydate
        txttransref.Clear()
        txttransremarks.Clear()

        txtremarks.Clear()

        chkadjustment.Checked = False
        txtuploadsrno.Clear()
        txtuploadname.Clear()
        txtuploadremarks.Clear()
        gridupload.RowCount = 0
        txtimgpath.Clear()
        TXTNEWIMGPATH.Clear()
        TXTFILENAME.Clear()
        PBSoftCopy.ImageLocation = ""


        lbllocked.Visible = False
        PBlock.Visible = False

        'clearing itemgrid textboxes and combos
        txtsrno.Clear()
        cmbitemname.Text = ""
        txtgridremarks.Clear()
        CMBQUALITY.Text = ""
        TXTREED.Clear()
        TXTPICK.Clear()
        cmbcolor.Text = ""
        CMBLABTEST.Text = ""
        txtqty.Clear()
        If ClientName = "SHUBHLAXMI" Then cmbqtyunit.Text = "PCS" Else cmbqtyunit.Text = ""
        TXTMTRS.Clear()
        TXTWT.Clear()
        gridgrn.RowCount = 0
        cmbtrans.Text = ""
        txtlrno.Clear()

        TXTBALENOS.Clear()
        TXTREADYWIDTH.Clear()
        TXTFINISH.Clear()
        CMBMERCHANT.Text = ""
        TXTSAMPLES.Clear()
        TXTPACKINGREMARKS.Clear()
        CMBPARTYMERCHANT.Text = ""

        TXTBSRNO.Text = GRIDBLEACH.RowCount + 1
        TXTBDECMTRS.Clear()
        TXTBWT.Clear()
        TXTBREEDPICK.Clear()
        TXTBWIDTH.Clear()
        TXTBFOLD.Clear()
        TXTBGRAMS.Clear()
        TXTTOTALBDECMTRS.Clear()
        TXTTOTALBWT.Clear()
        TXTTOTALBGRAMS.Clear()
        TXTAVGDECMTRS.Clear()
        TXTAVGWT.Clear()
        TXTAVGGRAMS.Clear()
        GRIDBLEACH.RowCount = 0
        CMBCATEGORY.Text = ""

        cmdselectPO.Enabled = True
        gridDoubleClick = False
        gridUPLOADdoubleclick = False

        If FRMSTRING = "GRN" Then
            cmbtype.Text = "G.R.N"
            If ClientName = "MONOGRAM" Then
                cmbitemname.Text = "GREY MATERIAL"
                cmbqtyunit.Text = "PCS"
            End If
            GLABTEST.Visible = False
            CMBLABTEST.Visible = False
            GQUALITY.Width = 260
            CMBQUALITY.Width = 260

        ElseIf FRMSTRING = "GRNJOB" Then
            cmbtype.Text = "Job Work"
        Else
            cmbtype.Text = "Inwards"
            CMBQUALITY.Visible = False
            TXTMTRS.Visible = False
            gdesc.Width = 320
            txtgridremarks.Width = 320
            GQUALITY.Visible = False
            GLABTEST.Visible = True
            CMBLABTEST.Visible = True
            gqtyunit.Width = 120
            cmbqtyunit.Width = 120
            GMTRS.Visible = False
            LBLWEAVER.Visible = False
            CMBWEAVER.Visible = False
            LBLBROKER.Visible = False
            CMBBROKER.Visible = False
            LBLSENDER.Visible = False
            CMBSENDER.Visible = False
            LBLBALES.Visible = False
            TXTTOTALBALES.Visible = False
            LBLQUALITYRATE.Visible = False
            CMBMERCHANT.Visible = False
            LBLCATEGORY.Visible = False
            CMBCATEGORY.Visible = False
        End If
        getmaxno()


        LBLTOTALMTRS.Text = 0
        TXTTOTALBALES.Clear()
        lbltotalqty.Text = 0
        LBLTOTALWT.Text = 0

        GRIDORDER.RowCount = 0


        If gridgrn.RowCount > 0 Then
            txtsrno.Text = Val(gridgrn.Rows(gridgrn.RowCount - 1).Cells(0).Value) + 1
        Else
            txtsrno.Text = 1
        End If


        If gridupload.RowCount > 0 Then
            txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(0).Value) + 1
        Else
            txtuploadsrno.Text = 1
        End If

    End Sub

    Sub total()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALWT.Text = 0.0
            lbltotalqty.Text = 0.0

            TXTTOTALBDECMTRS.Text = 0.0
            TXTTOTALBWT.Text = 0.0
            TXTTOTALBGRAMS.Text = 0.0
            TXTAVGDECMTRS.Text = 0.0
            TXTAVGWT.Text = 0.0
            TXTAVGGRAMS.Text = 0.0

            For Each ROW As DataGridViewRow In gridgrn.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    lbltotalqty.Text = Format(Val(lbltotalqty.Text) + Val(ROW.Cells(gQty.Index).EditedFormattedValue), "0.00")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                End If
            Next

            For Each ROW As DataGridViewRow In GRIDBLEACH.Rows
                If ROW.Cells(BSRNO.Index).Value <> Nothing Then
                    TXTTOTALBDECMTRS.Text = Format(Val(TXTTOTALBDECMTRS.Text) + Val(ROW.Cells(BMTRS.Index).EditedFormattedValue), "0.00")
                    TXTTOTALBWT.Text = Format(Val(TXTTOTALBWT.Text) + Val(ROW.Cells(BWT.Index).EditedFormattedValue), "0.000")

                    ROW.Cells(BGRAMS.Index).Value = Format(Val(ROW.Cells(BWT.Index).EditedFormattedValue) / Val(ROW.Cells(BMTRS.Index).EditedFormattedValue), "0.000")
                    ROW.Cells(BGRAMS.Index).Value = Format(Val(ROW.Cells(BGRAMS.Index).EditedFormattedValue) + Val(ROW.Cells(BGRAMS.Index).EditedFormattedValue) * ((100 - Val(ROW.Cells(BFOLD.Index).EditedFormattedValue)) / 100), "0.000")

                    TXTTOTALBGRAMS.Text = Format(Val(TXTTOTALBGRAMS.Text) + Val(ROW.Cells(BGRAMS.Index).EditedFormattedValue), "0.000")
                End If
            Next

            TXTAVGDECMTRS.Text = Format(Val(TXTTOTALBDECMTRS.Text) / Val(GRIDBLEACH.RowCount), "0.00")
            TXTAVGWT.Text = Format(Val(TXTTOTALBWT.Text) / Val(GRIDBLEACH.RowCount), "0.000")
            TXTAVGGRAMS.Text = Format(Val(TXTTOTALBGRAMS.Text) / Val(GRIDBLEACH.RowCount), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        'cmbtype.Enabled = True
        edit = False
        cmbname.Focus()
    End Sub

    Private Sub grndate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles grndate.Validating
        If Not datecheck(grndate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(grn_no),0) + 1 ", "GRN", " AND GRN_TYPE='" & cmbtype.Text & "' AND grn_cmpid=" & CmpId & " and grn_locationid=" & Locationid & " and grn_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtgrnno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub txtuploadsrno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuploadsrno.KeyPress
        enterkeypress(e, Me)
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True
            If cmbtype.Text.Trim.Length = 0 Then
                EP.SetError(cmbtype, "Enter Register Name")
                bln = False
            End If
            If cmbname.Text.Trim.Length = 0 Then
                EP.SetError(cmbname, " Please Fill Company Name ")
                bln = False
            End If


            If UserName <> "Admin" And ClientName <> "DHANLAXMI" And ClientName <> "SHUBHLAXMI" Then
                If lbllocked.Visible = True Then
                    EP.SetError(lbllocked, "Checking Done, Delete Checking First")
                    bln = False
                End If
            End If


            If gridgrn.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            'coz if it it other item type then mtrs will be blank
            'if want to enable then check for materialtype
            For Each row As DataGridViewRow In gridgrn.Rows
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("MATERIAL_NAME", "", "  ITEMMASTER INNER JOIN MATERIALTYPEMASTER ON ITEMMASTER.item_materialtypeid = MATERIALTYPEMASTER.material_id AND ITEMMASTER.item_cmpid = MATERIALTYPEMASTER.material_cmpid AND ITEMMASTER.item_locationid = MATERIALTYPEMASTER.material_locationid AND ITEMMASTER.item_yearid = MATERIALTYPEMASTER.material_yearid ", " AND ITEMMASTER.ITEM_NAME = '" & row.Cells(gitemname.Index).Value & "' AND ITEM_CMPID = " & CmpId & " AND ITEM_LOCATIONID = " & Locationid & " AND ITEM_YEARID = " & YearId)
                If Val(row.Cells(GMTRS.Index).Value) = 0 And (DT.Rows(0).Item(0) = "Raw Material" Or DT.Rows(0).Item(0) = "Semi Finished Goods" Or DT.Rows(0).Item(0) = "Finished Goods") Then
                    EP.SetError(TabControl1, "MTRS Cannot be kept Blank")
                    bln = False
                End If
            Next

            If Val(txtgrnno.Text.Trim) = 0 Then
                EP.SetError(txtgrnno, "Invalid Lot No")
                bln = False
            End If

            If ALLOWMANUALLOTNO = True And FRMSTRING = "G.R.N" Then
                If Val(txtgrnno.Text.Trim) <> 0 And edit = False Then
                    Dim OBJCMN As New ClsCommon
                    Dim dttable As DataTable = OBJCMN.search(" ISNULL(GRN.GRN_NO,0)  AS LOTNO", "", " GRN ", " AND GRN.GRN_TYPE ='G.R.N' AND GRN.GRN_NO=" & txtgrnno.Text.Trim & " AND GRN.GRN_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        EP.SetError(txtgrnno, "Lot No Already Exists")
                        bln = False
                    End If
                End If
            End If


            'FOR ORDER CHECKING, FIRST REMOVE GDNQTY
            Dim TEMPORDERROWNO As Integer = -1
            Dim TEMPORDERMATCH As Boolean = False
            If GRIDORDER.RowCount > 0 Then

                For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                    ORDROW.Cells(OGRNQTY.Index).Value = 0
                    ORDROW.Cells(OGRNMTRS.Index).Value = 0
                Next

                'GET MULTISONO
                Dim MULTISONO() As String = (From row As DataGridViewRow In GRIDORDER.Rows.Cast(Of DataGridViewRow)() Where Not row.IsNewRow Select CStr(row.Cells(OFROMNO.Index).Value)).Distinct.ToArray
                txtpono.Clear()
                For Each a As String In MULTISONO
                    If txtpono.Text = "" Then
                        txtpono.Text = a
                    Else
                        txtpono.Text = txtpono.Text & "," & a
                    End If
                Next


                Dim TEMPOURQUALITY As String = ""
                TEMPORDERROWNO = -1

                For Each ROW As DataGridViewRow In gridgrn.Rows


                    'FETCH OURQUALITY
                    Dim OBJCMN As New ClsCommon
                    Dim DTQUALITY As DataTable = OBJCMN.search(" ISNULL(OURQUALITYMASTER.QUALITY_name,'') AS OURQUALITY ", "", " QUALITYMASTER LEFT OUTER JOIN QUALITYMASTER AS OURQUALITYMASTER ON QUALITYMASTER.QUALITY_OURQUALITYID = OURQUALITYMASTER.QUALITY_ID ", " AND QUALITYMASTER.QUALITY_NAME = '" & ROW.Cells(GQUALITY.Index).Value & "' AND QUALITYMASTER.QUALITY_YEARID = " & YearId)
                    If DTQUALITY.Rows.Count > 0 Then TEMPOURQUALITY = DTQUALITY.Rows(0).Item("OURQUALITY")


                    Dim TEMPBALANCEPCS As Integer = Val(ROW.Cells(gQty.Index).Value)
                    Dim TEMPBALANCEMTRS As Double = Val(ROW.Cells(GMTRS.Index).Value)

                    For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                        If ROW.Cells(gitemname.Index).Value = ORDROW.Cells(OITEMNAME.Index).Value And TEMPOURQUALITY = ORDROW.Cells(OQUALITY.Index).Value Then
                            TEMPORDERMATCH = True
                            'IF ITEM IS MATCHED BUT THE QTY IS FULL THEN WE NEED TO KEEP THIS ROWNO IN TEMP AND NEED TO CHECK FURTHER ALSO
                            'IF WE GET ANY NEW MATHING THEN WE NEED TO INSERT THERE
                            'IF NO MATCHING IS FOUND IN FURTHER ROWS THEN WE NEED TO ADD QTY IN THIS TEMPROW
                            If Val(ORDROW.Cells(OGRNQTY.Index).Value) >= Val(ORDROW.Cells(OPCS.Index).Value) Then
                                TEMPORDERROWNO = ORDROW.Index
                                GoTo CHECKNEXTLINE
                            End If


                            'additional code
                            If Val(ORDROW.Cells(OGRNQTY.Index).Value) = 0 And Val(TEMPBALANCEPCS) >= Val(ORDROW.Cells(OPCS.Index).Value) Then
                                ORDROW.Cells(OGRNQTY.Index).Value = Val(ORDROW.Cells(OPCS.Index).Value)
                                TEMPBALANCEPCS = Val(TEMPBALANCEPCS) - Val(ORDROW.Cells(OPCS.Index).Value)
                                ORDROW.Cells(OGRNMTRS.Index).Value = Val(ORDROW.Cells(OMTRS.Index).Value)
                                TEMPBALANCEMTRS = Val(TEMPBALANCEMTRS) - Val(ORDROW.Cells(OMTRS.Index).Value)
                                TEMPORDERROWNO = ORDROW.Index
                            Else
                                ORDROW.Cells(OGRNQTY.Index).Value = Val(ORDROW.Cells(OGRNQTY.Index).Value) + Val(TEMPBALANCEPCS)
                                ORDROW.Cells(OGRNMTRS.Index).Value = Val(ORDROW.Cells(OGRNMTRS.Index).Value) + Val(TEMPBALANCEMTRS)
                                TEMPORDERROWNO = -1
                                Exit For

                            End If

CHECKNEXTLINE:
                        End If
                    Next
                    'IF NO FURTHER MACHING IS FOUND BUT WE HAVE TEMPORDERROWNO THEN ADD VALUE IN THAT ROW
                    If TEMPORDERROWNO >= 0 And TEMPBALANCEPCS > 0 Then
                        GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGRNQTY.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGRNQTY.Index).Value) + Val(TEMPBALANCEPCS)
                        GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGRNMTRS.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGRNMTRS.Index).Value) + Val(TEMPBALANCEMTRS)
                        TEMPORDERROWNO = -1
                    End If
                    If TEMPORDERMATCH = False Then
                        ROW.DefaultCellStyle.BackColor = Color.LightGreen
                        If MsgBox("There are Items which are not Present in Selected Order, Wish to Proceed", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            EP.SetError(cmbname, "There are Items which are not Present in Selected Order")
                            bln = False
                        End If
                    End If
                    TEMPORDERMATCH = False
                Next
            End If



            If (ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI") And CMBMERCHANT.Text.Trim = "" And FRMSTRING = "G.R.N" Then
                EP.SetError(CMBMERCHANT, "Select Quality")
                bln = False
            End If

            If ClientName = "DHANLAXMI" And TXTREADYWIDTH.Text.Trim = "" And FRMSTRING = "G.R.N" Then
                EP.SetError(cmbname, "Enter Ready Width")
                bln = False
            End If

            If Not datecheck(grndate.Value) Then bln = False
            If Not datecheck(dtpchallan.Value) Then bln = False

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

            If txtgrnno.ReadOnly = False Then
                alParaval.Add(Val(txtgrnno.Text.Trim))
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(cmbtype.Text.Trim)
            alParaval.Add(grndate.Value)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(CMBWEAVER.Text.Trim)
            alParaval.Add(CMBBROKER.Text.Trim)
            alParaval.Add(CMBSENDER.Text.Trim)
            alParaval.Add(Val(TXTRATE.Text.Trim))
            alParaval.Add(TXTGREYWIDTH.Text.Trim)
            alParaval.Add(txtchallan.Text.Trim)
            alParaval.Add(Format(dtpchallan.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(TXTEWBNO.Text.Trim)
            alParaval.Add(txtpono.Text.Trim)
            alParaval.Add(Format(podate.Value.Date, "MM/dd/yyyy"))


            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtlrno.Text.Trim)
            alParaval.Add(lrdate.Value)
            alParaval.Add(txttransref.Text.Trim)
            alParaval.Add(txttransremarks.Text.Trim)

            alParaval.Add(Val(lbltotalqty.Text))
            alParaval.Add(TXTTOTALBALES.Text.Trim)
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLTOTALWT.Text))
            If chkadjustment.Checked = True Then
                alParaval.Add(1)
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(txtremarks.Text.Trim)

            alParaval.Add(TXTBALENOS.Text.Trim)
            alParaval.Add(TXTREADYWIDTH.Text.Trim)
            alParaval.Add(TXTFINISH.Text.Trim)
            alParaval.Add(CMBMERCHANT.Text.Trim)
            alParaval.Add(TXTSAMPLES.Text.Trim)
            alParaval.Add(TXTPACKINGREMARKS.Text.Trim)
            alParaval.Add(CMBPARTYMERCHANT.Text.Trim)

            alParaval.Add(Val(TXTTOTALBDECMTRS.Text.Trim))
            alParaval.Add(Val(TXTTOTALBWT.Text.Trim))
            alParaval.Add(Val(TXTTOTALBGRAMS.Text.Trim))
            alParaval.Add(Val(TXTAVGDECMTRS.Text.Trim))
            alParaval.Add(Val(TXTAVGWT.Text.Trim))
            alParaval.Add(Val(TXTAVGGRAMS.Text.Trim))


            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim ITEMNAME As String = ""
            Dim gridremarks As String = ""
            Dim QUALITY As String = ""
            Dim REED As String = ""
            Dim PICK As String = ""
            Dim COLOR As String = ""
            Dim LABTEST As String = ""
            Dim qty As String = ""
            Dim qtyunit As String = ""
            Dim BALES As String = ""
            Dim MTRS As String = ""
            Dim WT As String = ""
            Dim poNO As String = ""         'value of poNO
            Dim pogridsrno As String = ""   'value of poGRIDSRNO
            Dim CHECKEDQTY As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim GRNDONE As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim RETURNQTY As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim CHECKDONE As String = ""      'WHETHER GRN IS DONE FOR THIS LINE


            For Each row As Windows.Forms.DataGridViewRow In gridgrn.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value.ToString
                        ITEMNAME = row.Cells(gitemname.Index).Value.ToString
                        gridremarks = row.Cells(gdesc.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        REED = row.Cells(GREED.Index).Value.ToString
                        PICK = row.Cells(GPICK.Index).Value.ToString
                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        LABTEST = row.Cells(GLABTEST.Index).Value.ToString
                        qty = Val(row.Cells(gQty.Index).Value)
                        qtyunit = row.Cells(gqtyunit.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value
                        WT = row.Cells(GWT.Index).Value

                        If row.Cells(gpono.Index).Value <> Nothing Then
                            poNO = row.Cells(gpono.Index).Value
                        Else
                            poNO = "0"
                        End If

                        If row.Cells(gpogridsrno.Index).Value <> Nothing Then
                            pogridsrno = row.Cells(gpogridsrno.Index).Value
                        Else
                            pogridsrno = 0
                        End If

                        CHECKEDQTY = row.Cells(GCHECKEDQTY.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            GRNDONE = "1"
                        Else
                            GRNDONE = "0"
                        End If
                        RETURNQTY = row.Cells(GRETURNQTY.Index).Value
                        If Convert.ToBoolean(row.Cells(GCHECKDONE.Index).Value) = True Then
                            CHECKDONE = "1"
                        Else
                            CHECKDONE = "0"
                        End If

                    Else

                        gridsrno = gridsrno & "|" & row.Cells(gsrno.Index).Value
                        ITEMNAME = ITEMNAME & "|" & row.Cells(gitemname.Index).Value
                        gridremarks = gridremarks & "|" & row.Cells(gdesc.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        REED = REED & "|" & row.Cells(GREED.Index).Value.ToString
                        PICK = PICK & "|" & row.Cells(GPICK.Index).Value.ToString
                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        LABTEST = LABTEST & "|" & row.Cells(GLABTEST.Index).Value.ToString
                        qty = qty & "|" & Val(row.Cells(gQty.Index).Value)
                        qtyunit = qtyunit & "|" & row.Cells(gqtyunit.Index).Value
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value
                        WT = WT & "|" & row.Cells(GWT.Index).Value

                        If row.Cells(gpono.Index).Value <> Nothing Then
                            poNO = poNO & "|" & row.Cells(gpono.Index).Value
                        Else
                            poNO = poNO & "|" & " 0"
                        End If

                        If row.Cells(gpogridsrno.Index).Value <> Nothing Then
                            pogridsrno = pogridsrno & "|" & Val(row.Cells(gpogridsrno.Index).Value)
                        Else
                            pogridsrno = pogridsrno & "|" & " 0"
                        End If

                        CHECKEDQTY = CHECKEDQTY & "|" & row.Cells(GCHECKEDQTY.Index).Value

                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            GRNDONE = GRNDONE & "|" & "1"
                        Else
                            GRNDONE = GRNDONE & "|" & "0"
                        End If

                        RETURNQTY = RETURNQTY & "|" & row.Cells(GRETURNQTY.Index).Value

                        If Convert.ToBoolean(row.Cells(GCHECKDONE.Index).Value) = True Then
                            CHECKDONE = CHECKDONE & "|" & "1"
                        Else
                            CHECKDONE = CHECKDONE & "|" & "0"
                        End If

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMNAME)
            alParaval.Add(gridremarks)
            alParaval.Add(QUALITY)
            alParaval.Add(REED)
            alParaval.Add(PICK)
            alParaval.Add(COLOR)
            alParaval.Add(LABTEST)
            alParaval.Add(qty)
            alParaval.Add(qtyunit)
            alParaval.Add(MTRS)
            alParaval.Add(WT)
            alParaval.Add(poNO)
            alParaval.Add(pogridsrno)
            alParaval.Add(CHECKEDQTY)
            alParaval.Add(GRNDONE)
            alParaval.Add(CHECKEDQTY)
            alParaval.Add(CHECKDONE)



            Dim griduploadsrno As String = ""
            Dim imgpath As String = ""
            Dim uploadremarks As String = ""
            Dim name As String = ""
            Dim NEWIMGPATH As String = ""
            Dim FILENAME As String = ""

            'Saving Upload Grid
            For Each row As Windows.Forms.DataGridViewRow In gridupload.Rows
                If row.Cells(0).Value <> Nothing Then
                    If griduploadsrno = "" Then
                        griduploadsrno = row.Cells(0).Value.ToString
                        uploadremarks = row.Cells(1).Value.ToString
                        name = row.Cells(2).Value.ToString
                        imgpath = row.Cells(3).Value.ToString
                        NEWIMGPATH = row.Cells(GNEWIMGPATH.Index).Value.ToString

                    Else
                        griduploadsrno = griduploadsrno & "|" & row.Cells(0).Value.ToString
                        uploadremarks = uploadremarks & "|" & row.Cells(1).Value.ToString
                        name = name & "|" & row.Cells(2).Value.ToString
                        imgpath = imgpath & "|" & row.Cells(3).Value.ToString
                        NEWIMGPATH = NEWIMGPATH & "|" & row.Cells(GNEWIMGPATH.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(griduploadsrno)
            alParaval.Add(uploadremarks)
            alParaval.Add(name)
            alParaval.Add(imgpath)
            alParaval.Add(NEWIMGPATH)
            alParaval.Add(FILENAME)



            Dim BLEACHSRNO As String = ""
            Dim BLEACHMTRS As String = ""
            Dim BLEACHWT As String = ""
            Dim BLEACHREEDPICK As String = ""
            Dim BLEACHWIDTH As String = ""
            Dim BLEACHFOLD As String = ""
            Dim BLEACHGRAMS As String = ""

            'Saving Upload Grid
            For Each ROW As Windows.Forms.DataGridViewRow In GRIDBLEACH.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If BLEACHSRNO = "" Then
                        BLEACHSRNO = Val(ROW.Cells(BSRNO.Index).Value)
                        BLEACHMTRS = Val(ROW.Cells(BMTRS.Index).Value)
                        BLEACHWT = Val(ROW.Cells(BWT.Index).Value)
                        BLEACHREEDPICK = ROW.Cells(BREEDPICK.Index).Value
                        BLEACHWIDTH = Val(ROW.Cells(BWIDTH.Index).Value)
                        BLEACHFOLD = Val(ROW.Cells(BFOLD.Index).Value)
                        BLEACHGRAMS = Val(ROW.Cells(BGRAMS.Index).Value)
                    Else
                        BLEACHSRNO = BLEACHSRNO & "|" & Val(ROW.Cells(BSRNO.Index).Value)
                        BLEACHMTRS = BLEACHMTRS & "|" & Val(ROW.Cells(BMTRS.Index).Value)
                        BLEACHWT = BLEACHWT & "|" & Val(ROW.Cells(BWT.Index).Value)
                        BLEACHREEDPICK = BLEACHREEDPICK & "|" & ROW.Cells(BREEDPICK.Index).Value
                        BLEACHWIDTH = BLEACHWIDTH & "|" & Val(ROW.Cells(BWIDTH.Index).Value)
                        BLEACHFOLD = BLEACHFOLD & "|" & Val(ROW.Cells(BFOLD.Index).Value)
                        BLEACHGRAMS = BLEACHGRAMS & "|" & Val(ROW.Cells(BGRAMS.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(BLEACHSRNO)
            alParaval.Add(BLEACHMTRS)
            alParaval.Add(BLEACHWT)
            alParaval.Add(BLEACHREEDPICK)
            alParaval.Add(BLEACHWIDTH)
            alParaval.Add(BLEACHFOLD)
            alParaval.Add(BLEACHGRAMS)




            Dim ORDERGRIDSRNO As String = ""
            Dim ORDERITEMNAME As String = ""
            Dim ORDERQUALITY As String = ""
            Dim ORDERPCS As String = ""
            Dim ORDERMTRS As String = ""
            Dim ORDERFROMNO As String = ""
            Dim ORDERFROMSRNO As String = ""
            Dim ORDERFROMTYPE As String = ""
            Dim ORDERGRNPCS As String = ""
            Dim ORDERGRNMTRS As String = ""
            Dim ORDERRATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDORDER.Rows
                If row.Cells(0).Value <> Nothing AndAlso Val(row.Cells(OGRNQTY.Index).Value) > 0 Then

                    If ORDERGRIDSRNO = "" Then
                        ORDERGRIDSRNO = Val(row.Cells(OSRNO.Index).Value)
                        ORDERITEMNAME = row.Cells(OITEMNAME.Index).Value.ToString
                        ORDERQUALITY = row.Cells(OQUALITY.Index).Value.ToString
                        ORDERPCS = Val(row.Cells(OPCS.Index).Value)
                        ORDERMTRS = Val(row.Cells(OMTRS.Index).Value)
                        ORDERFROMNO = Val(row.Cells(OFROMNO.Index).Value)
                        ORDERFROMSRNO = Val(row.Cells(OFROMSRNO.Index).Value)
                        ORDERFROMTYPE = row.Cells(OFROMTYPE.Index).Value.ToString
                        ORDERGRNPCS = Val(row.Cells(OGRNQTY.Index).Value)
                        ORDERGRNMTRS = Val(row.Cells(OGRNMTRS.Index).Value)
                        ORDERRATE = Val(row.Cells(ORATE.Index).Value)
                    Else
                        ORDERGRIDSRNO = ORDERGRIDSRNO & "|" & Val(row.Cells(OSRNO.Index).Value)
                        ORDERITEMNAME = ORDERITEMNAME & "|" & row.Cells(OITEMNAME.Index).Value.ToString
                        ORDERQUALITY = ORDERQUALITY & "|" & row.Cells(OQUALITY.Index).Value.ToString
                        ORDERPCS = ORDERPCS & "|" & Val(row.Cells(OPCS.Index).Value)
                        ORDERMTRS = ORDERMTRS & "|" & Val(row.Cells(OMTRS.Index).Value)
                        ORDERFROMNO = ORDERFROMNO & "|" & Val(row.Cells(OFROMNO.Index).Value)
                        ORDERFROMSRNO = ORDERFROMSRNO & "|" & Val(row.Cells(OFROMSRNO.Index).Value)
                        ORDERFROMTYPE = ORDERFROMTYPE & "|" & row.Cells(OFROMTYPE.Index).Value.ToString
                        ORDERGRNPCS = ORDERGRNPCS & "|" & Val(row.Cells(OGRNQTY.Index).Value)
                        ORDERGRNMTRS = ORDERGRNMTRS & "|" & Val(row.Cells(OGRNMTRS.Index).Value)
                        ORDERRATE = ORDERRATE & "|" & Val(row.Cells(ORATE.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(ORDERGRIDSRNO)
            alParaval.Add(ORDERITEMNAME)
            alParaval.Add(ORDERQUALITY)
            alParaval.Add(ORDERPCS)
            alParaval.Add(ORDERMTRS)
            alParaval.Add(ORDERFROMNO)
            alParaval.Add(ORDERFROMSRNO)
            alParaval.Add(ORDERFROMTYPE)
            alParaval.Add(ORDERGRNPCS)
            alParaval.Add(ORDERGRNMTRS)
            alParaval.Add(ORDERRATE)



            Dim objclsGRN As New ClsGrn()
            objclsGRN.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objclsGRN.SAVE()
                MsgBox("Details Added")
                txtgrnno.Text = DTTABLE.Rows(0).Item(0)
            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempgrnno)

                IntResult = objclsGRN.UPDATE()
                MsgBox("Details Updated")

            End If
            edit = False


            PRINTREPORT()


            'COPY SCANNED DOCS FILES 
            For Each ROW As DataGridViewRow In gridupload.Rows
                If FileIO.FileSystem.DirectoryExists(Application.StartupPath & "\UPLOADDOCS") = False Then
                    FileIO.FileSystem.CreateDirectory(Application.StartupPath & "\UPLOADDOCS")
                End If
                If FileIO.FileSystem.FileExists(Application.StartupPath & "\UPLOADDOCS") = False Then
                    System.IO.File.Copy(ROW.Cells(GIMGPATH.Index).Value, ROW.Cells(GNEWIMGPATH.Index).Value, True)
                End If
            Next


            CLEAR()
            cmbname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub GRN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If errorvalid() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1 Then
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2 Then
            TabControl1.SelectedIndex = (1)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D3 Then
            TabControl1.SelectedIndex = (2)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D4 Then
            TabControl1.SelectedIndex = (3)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D5 Then
            TabControl1.SelectedIndex = (4)
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then
            gridgrn.Focus()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.P And e.Alt = True Then
            Call PrintToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GRN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If AscW(e.KeyChar) <> 33 Then
            chkchange.CheckState = CheckState.Checked
        End If
    End Sub

    Private Sub GRN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            If FRMSTRING = "INWARD" Then
                DTROW = USERRIGHTS.Select("FormName = 'GRN'")
            ElseIf FRMSTRING = "GRN" Then
                DTROW = USERRIGHTS.Select("FormName = 'GRN INWARD'")
            ElseIf FRMSTRING = "GRNJOB" Then
                DTROW = USERRIGHTS.Select("FormName = 'GRN JOB'")
            End If
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            If cmbtype.Items.Count > 0 Then cmbtype.SelectedIndex = (0)

            FILLCMB()
            CLEAR()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objclsGRN As New ClsGrn()
                Dim dttable As New DataTable

                dttable = objclsGRN.selectGRN(tempgrnno, CmpId, Locationid, YearId, cmbtype.Text)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows
                        cmbtype.Text = Convert.ToString(dr("TYPE"))

                        txtgrnno.Text = tempgrnno
                        txtgrnno.ReadOnly = True

                        grndate.Value = Format(Convert.ToDateTime(dr("GRNDATE")).Date, "dd/MM/yyyy")
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        CMBWEAVER.Text = Convert.ToString(dr("WEAVER").ToString)
                        CMBBROKER.Text = Convert.ToString(dr("BROKER").ToString)
                        CMBSENDER.Text = Convert.ToString(dr("SENDER").ToString)
                        CMBCATEGORY.Text = Convert.ToString(dr("CATEGORY").ToString)

                        TXTRATE.Text = Val(dr("RATE"))

                        TXTGREYWIDTH.Text = dr("GREYWIDTH")
                        txtchallan.Text = Convert.ToString(dr("CHALLANNO").ToString)
                        partychallan = txtchallan.Text.Trim
                        dtpchallan.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        TXTEWBNO.Text = dr("EWBNO")

                        txtpono.Text = Convert.ToString(dr("PONO").ToString)
                        podate.Value = Format(Convert.ToDateTime(dr("PODATE")).Date, "dd/MM/yyyy")


                        cmbtrans.Text = dr("TRANSNAME").ToString
                        txttransref.Text = dr("transrefno").ToString
                        txtlrno.Text = dr("LRNO").ToString
                        lrdate.Text = Format(Convert.ToDateTime(dr("LRDATE")).Date, "dd/MM/yyyy")
                        txttransremarks.Text = dr("transremarks").ToString

                        TXTTOTALBALES.Text = Format(Val(dr("TOTALBALES")), "0.00")
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)


                        TXTBALENOS.Text = Convert.ToString(dr("BALENOS").ToString)
                        TXTREADYWIDTH.Text = Convert.ToString(dr("READYWIDTH").ToString)
                        TXTFINISH.Text = Convert.ToString(dr("FINISH").ToString)
                        CMBMERCHANT.Text = Convert.ToString(dr("MERCHANTNO").ToString)
                        TXTSAMPLES.Text = Convert.ToString(dr("SAMPLES").ToString)
                        TXTPACKINGREMARKS.Text = Convert.ToString(dr("PACKINGREMARKS").ToString)
                        CMBPARTYMERCHANT.Text = Convert.ToString(dr("PARTYMERCHANTNO").ToString)


                        'Item Grid
                        gridgrn.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEMNAME").ToString, dr("DESC").ToString, dr("QUALITY").ToString, dr("REED").ToString, dr("PICK").ToString, dr("COLOR"), dr("LABTEST"), Val(dr("qty")), dr("QTYUNIT").ToString, Format(dr("MTRS"), "0.00"), Format(dr("WT"), "0.00"), dr("GRIDPONO"), dr("GRIDPOSRNO"), dr("CHECKEDQTY"), dr("GRIDDONE").ToString, dr("RETURNQTY"), dr("CHECKDONE").ToString)

                        If Convert.ToBoolean(dr("ADJUSTMENT")) = True Then
                            chkadjustment.Checked = True
                        Else
                            chkadjustment.Checked = False
                        End If
                        If Convert.ToBoolean(dr("CHECKDONE")) = True Then
                            gridgrn.Rows(gridgrn.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            gridgrn.ReadOnly = True
                        End If

                    Next
                    cmbtype.Enabled = False

                End If


                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" GRN_GRIDSRNO AS GRIDSRNO, GRN_REMARKS AS REMARKS, GRN_NAME AS NAME, GRN_IMGPATH AS IMGPATH, GRN_NEWIMGPATH AS NEWIMGPATH", "", " GRN_UPLOAD", " AND GRN_NO = " & tempgrnno & " AND GRN_CMPID = " & CmpId & " AND GRN_LOCATIONID = " & Locationid & " AND GRN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        gridupload.Rows.Add(DTR("GRIDSRNO"), DTR("REMARKS"), DTR("NAME"), DTR("IMGPATH"), DTR("NEWIMGPATH"))
                    Next
                End If

                dttable = OBJCMN.search(" ISNULL(GRN_GRIDSRNO, 0) AS BSRNO, ISNULL(GRN_DECMTRS, 0) AS BMTRS, ISNULL(GRN_WT, 0) AS BWT, ISNULL(GRN_REEDPICK, '') AS BREEDPICK, ISNULL(GRN_WIDTH, 0) AS BWIDTH, ISNULL(GRN_FOLD, 0) AS BFOLD, ISNULL(GRN_GRAMS, 0) AS BGRAMS ", "", " GRN_BLEACHDESC ", " AND GRN_NO = " & tempgrnno & " AND GRN_TYPE = '" & cmbtype.Text.Trim & "' AND GRN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        GRIDBLEACH.Rows.Add(DTR("BSRNO"), Val(DTR("BMTRS")), Format(Val(DTR("BWT")), "0.000"), DTR("BREEDPICK"), Val(DTR("BWIDTH")), Val(DTR("BFOLD")), Format(Val(DTR("BGRAMS")), "0.000"))
                    Next
                End If
                total()


                'ORDER GRID
                'Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search(" GRN_PODETAILS.GRN_GRIDSRNO AS GRIDSRNO, ITEMMASTER.item_name AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_NAME,'') AS QUALITY, GRN_PODETAILS.GRN_ORDERPCS AS ORDERQTY, ISNULL(GRN_PODETAILS.GRN_ORDERMTRS,0) AS ORDERMTRS, GRN_PODETAILS.GRN_FROMNO AS FROMNO, GRN_PODETAILS.GRN_FROMSRNO AS FROMSRNO, GRN_PODETAILS.GRN_FROMTYPE AS FROMTYPE, GRN_PODETAILS.GRN_PCS AS GRNQTY, ISNULL(GRN_PODETAILS.GRN_MTRS,0) AS GRNMTRS, ISNULL(GRN_PODETAILS.GRN_RATE,0) AS RATE ", "", " GRN_PODETAILS INNER JOIN ITEMMASTER ON GRN_PODETAILS.GRN_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN QUALITYMASTER ON GRN_PODETAILS.GRN_QUALITYID = QUALITYMASTER.QUALITY_ID ", " AND GRN_PODETAILS.GRN_NO = " & tempgrnno & " AND GRN_PODETAILS.GRN_TYPE = '" & cmbtype.Text.Trim & "'  AND GRN_PODETAILS.GRN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DTR As DataRow In dttable.Rows
                        GRIDORDER.Rows.Add(Val(DTR("GRIDSRNO")), DTR("ITEMNAME"), DTR("QUALITY"), Val(DTR("ORDERQTY")), Val(DTR("ORDERMTRS")), Val(DTR("FROMNO")), Val(DTR("FROMSRNO")), DTR("FROMTYPE"), Val(DTR("GRNQTY")), Val(DTR("GRNMTRS")), Val(DTR("RATE")))
                    Next
                End If
                getsrno(GRIDORDER)


                If GRIDORDER.RowCount = 0 Then
                    cmdselectPO.Enabled = True
                    cmbname.Enabled = True
                Else
                    cmdselectPO.Enabled = False
                    cmbname.Enabled = False
                End If

                chkchange.CheckState = CheckState.Checked
            End If

            If gridgrn.RowCount > 0 Then
                txtsrno.Text = Val(gridgrn.Rows(gridgrn.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub FILLCMB()
        Try
            If cmbname.Text.Trim = "" Then
                If FRMSTRING = "GRN" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS' ") Else fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS' ")
            End If
            If CMBBROKER.Text.Trim = "" Then fillname(CMBBROKER, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
            fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            fillCATEGORY(CMBCATEGORY, edit)

            If CMBMERCHANT.Text.Trim = "" Then
                If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then fillitemname(CMBMERCHANT, " AND CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "' AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'") Else fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            End If

            If CMBPARTYMERCHANT.Text.Trim = "" Then fillitemname(CMBPARTYMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If FRMSTRING = "GRN" Then If cmbitemname.Text.Trim = "" Then cmbitemname.Text = "GREY MATERIAL"
            fillQUALITY(CMBQUALITY, edit)
            fillunit(cmbqtyunit)
            fillCOLOR(cmbcolor)
            If CMBWEAVER.Text.Trim = "" Then FILLWEAVER(CMBWEAVER, edit)
            FILLGODOWN(CMBGODOWN, False)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMERCHANT.Enter
        Try
            If CMBMERCHANT.Text.Trim = "" Then
                If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then fillitemname(CMBMERCHANT, " AND CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "' AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'") Else fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMERCHANT.Validating
        Try
            If CMBMERCHANT.Text.Trim <> "" Then itemvalidate(CMBMERCHANT, e, Me, " AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' OR ITEMMASTER.ITEM_FRMSTRING = 'ITEM')", "MERCHANT")
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

            Dim objgrndetails As New GRNDetails
            objgrndetails.MdiParent = MDIMain
            objgrndetails.FRMSTRING = FRMSTRING
            objgrndetails.Show()
            objgrndetails.BringToFront()
            'Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then fillname(cmbtrans, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' and ")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'", "Sundry Creditors", "TRANSPORT")
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

    Sub uploadgetsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            Dim i As Integer = 0
            For Each row As DataGridViewRow In grid.Rows
                If row.Visible = True Then
                    row.Cells(GGRIDUPLOADSRNO.Index).Value = i + 1
                    i = i + 1
                End If
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtchallan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtchallan.Validating
        Try

            If txtchallan.Text.Trim.Length > 0 Then
                'If (edit = False) Or (edit = True And LCase(partychallan) <> LCase(txtchallan.Text.Trim)) Then
                '    'for search
                '    Dim objclscommon As New ClsCommon()
                '    Dim dt As New DataTable
                '    dt = objclscommon.search(" GRN.GRN_challanno, LEDGERS.ACC_cmpname", "", " GRN inner join LEDGERS on LEDGERS.ACC_id = GRN.GRN_ledgerid AND LEDGERS.ACC_CMPid = GRN.GRN_CMPid AND LEDGERS.ACC_LOCATIONid = GRN.GRN_lOCATIONid AND LEDGERS.ACC_YEARid = GRN.GRN_YEARid", " and GRN.GRN_challanno = '" & txtchallan.Text.Trim & "' and LEDGERS.ACC_cmpname = '" & cmbname.Text.Trim & "' AND GRN_CMPID =" & CmpId & " AND GRN_LOCATIONID =" & Locationid & " AND GRN_YEARID =" & YearId)
                '    If dt.Rows.Count > 0 Then
                '        MsgBox("Challan No. Already Exists", MsgBoxStyle.Critical, "Tex Pro")
                '        e.Cancel = True
                '    End If
                'End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub dtpchallan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpchallan.Validating
        If Not datecheck(dtpchallan.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmdselectpo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectPO.Click
        Try
            'If cmbtype.Text.Trim <> "Inwards" Then Exit Sub

            If cmbname.Text.Trim = "" Then
                MsgBox("Select Party Name", MsgBoxStyle.Critical)
                cmbname.Focus()
                Exit Sub
            End If

            Dim DTPO As New DataTable
            Dim OBJSELECTPO As New SelectPO
            OBJSELECTPO.FRMSTRING = cmbtype.Text.Trim
            OBJSELECTPO.PARTYNAME = cmbname.Text.Trim
            OBJSELECTPO.ShowDialog()
            DTPO = OBJSELECTPO.DT

            If DTPO.Rows.Count > 0 Then

                ''  GETTING DISTINCT PONO NO IN TEXTBOX
                Dim DV As DataView = DTPO.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "PONO")
                For Each DTR As DataRow In NEWDT.Rows
                    If txtpono.Text.Trim = "" Then
                        txtpono.Text = DTR("PONO").ToString
                    Else
                        txtpono.Text = txtpono.Text & "," & DTR("PONO").ToString
                    End If
                Next

                fillledger(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY = '" & DTPO.Rows(0).Item("GROUPNAME") & "' ")
                cmbname.Text = DTPO.Rows(0).Item("NAME")

                podate.Value = DTPO.Rows(0).Item("PODATE")
                txtpono.Enabled = False


                'BEFORE ADDING THE ROW IN ORDERDER GRID CHECK WHETHER SAME ORDERNO AN SRNO IS PRESENT IN GRID OR NOT
                For Each DTROW As DataRow In DTPO.Rows
                    For Each ROW As DataGridViewRow In GRIDORDER.Rows
                        If Val(ROW.Cells(OFROMNO.Index).Value) = Val(DTROW("PONO")) And Val(ROW.Cells(OFROMSRNO.Index).Value) = Val(DTROW("GRIDSRNO")) And ROW.Cells(OFROMTYPE.Index).Value = DTROW("TYPE") Then GoTo NEXTLINE
                    Next
                    GRIDORDER.Rows.Add(0, DTROW("ITEMNAME"), DTROW("QUALITY"), Val(DTROW("QTY")), Val(DTROW("MTRS")), DTROW("PONO"), DTROW("GRIDSRNO"), DTROW("TYPE"), 0, 0, Val(DTROW("RATE")))
                    If cmbtype.Text.Trim = "Inwards" Then gridgrn.Rows.Add(0, DTROW("ITEMNAME"), "", "", "", "", "", "APPROVED", Val(DTROW("QTY")), "Kgs", 0, 0, DTROW("PONO"), DTROW("GRIDSRNO"), 0, 0, 0, 0)
NEXTLINE:
                Next
                getsrno(GRIDORDER)
                getsrno(gridgrn)

            End If

            cmdselectPO.Enabled = True
            total()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                gridgrn.RowCount = 0
                tempgrnno = Val(tstxtbillno.Text)
                If tempgrnno > 0 Then
                    edit = True
                    GRN_Load(sender, e)
                Else
                    CLEAR()
                    edit = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()

        gridgrn.Enabled = True

        If gridDoubleClick = False Then
            gridgrn.Rows.Add(Val(txtsrno.Text.Trim), cmbitemname.Text.Trim, txtgridremarks.Text.Trim, CMBQUALITY.Text.Trim, Val(TXTREED.Text.Trim), Val(TXTPICK.Text.Trim), cmbcolor.Text.Trim, CMBLABTEST.Text.Trim, Val(txtqty.Text.Trim), cmbqtyunit.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), 0, 0, 0, 0, 0, 0)
            getsrno(gridgrn)
        ElseIf gridDoubleClick = True Then
            gridgrn.Item(gsrno.Index, temprow).Value = Val(txtsrno.Text.Trim)
            gridgrn.Item(gitemname.Index, temprow).Value = cmbitemname.Text.Trim
            gridgrn.Item(gdesc.Index, temprow).Value = txtgridremarks.Text.Trim
            gridgrn.Item(GQUALITY.Index, temprow).Value = CMBQUALITY.Text.Trim
            gridgrn.Item(GREED.Index, temprow).Value = TXTREED.Text.Trim
            gridgrn.Item(GPICK.Index, temprow).Value = TXTPICK.Text.Trim
            gridgrn.Item(gcolor.Index, temprow).Value = cmbcolor.Text.Trim
            gridgrn.Item(GLABTEST.Index, temprow).Value = CMBLABTEST.Text.Trim
            gridgrn.Item(gQty.Index, temprow).Value = Val(txtqty.Text.Trim)
            gridgrn.Item(gqtyunit.Index, temprow).Value = cmbqtyunit.Text.Trim
            gridgrn.Item(GMTRS.Index, temprow).Value = Format(Val(TXTMTRS.Text.Trim), "0.00")
            gridgrn.Item(GWT.Index, temprow).Value = Format(Val(TXTWT.Text.Trim), "0.00")
            gridDoubleClick = False
        End If

        total()

        gridgrn.FirstDisplayedScrollingRowIndex = gridgrn.RowCount - 1

        txtsrno.Clear()
        cmbitemname.Text = ""
        txtgridremarks.Clear()
        CMBQUALITY.Text = ""
        TXTREED.Clear()
        TXTPICK.Clear()
        cmbcolor.Text = ""
        CMBLABTEST.Text = ""
        txtqty.Clear()
        cmbqtyunit.Text = ""
        TXTMTRS.Clear()
        TXTWT.Clear()
        txtsrno.Text = gridgrn.RowCount + 1
        cmbitemname.Focus()

    End Sub

    Sub FILLBLEACHGRID()

        If GRIDBLEACHDOUBLECLICK = False Then
            GRIDBLEACH.Rows.Add(Val(TXTBSRNO.Text.Trim), Val(TXTBDECMTRS.Text.Trim), Format(Val(TXTBWT.Text.Trim), "0.000"), TXTBREEDPICK.Text.Trim, Val(TXTBWIDTH.Text.Trim), Val(TXTBFOLD.Text.Trim), Format(Val(TXTBGRAMS.Text.Trim)), "0.000")
            getsrno(GRIDBLEACH)
        ElseIf GRIDBLEACHDOUBLECLICK = True Then
            GRIDBLEACH.Item(BSRNO.Index, TEMPBLEACHROW).Value = Val(TXTBSRNO.Text.Trim)
            GRIDBLEACH.Item(BMTRS.Index, TEMPBLEACHROW).Value = Val(TXTBDECMTRS.Text.Trim)
            GRIDBLEACH.Item(BWT.Index, TEMPBLEACHROW).Value = Format(Val(TXTBWT.Text.Trim), "0.000")
            GRIDBLEACH.Item(BREEDPICK.Index, TEMPBLEACHROW).Value = TXTBREEDPICK.Text.Trim
            GRIDBLEACH.Item(BWIDTH.Index, TEMPBLEACHROW).Value = Val(TXTBWIDTH.Text.Trim)
            GRIDBLEACH.Item(BFOLD.Index, TEMPBLEACHROW).Value = Val(TXTBFOLD.Text.Trim)
            GRIDBLEACH.Item(BGRAMS.Index, TEMPBLEACHROW).Value = Format(Val(TXTBGRAMS.Text.Trim), "0.000")
            GRIDBLEACHDOUBLECLICK = False
        End If

        total()

        GRIDBLEACH.FirstDisplayedScrollingRowIndex = GRIDBLEACH.RowCount - 1

        TXTBSRNO.Text = GRIDBLEACH.RowCount + 1
        TXTBDECMTRS.Clear()
        TXTBWT.Clear()
        TXTBREEDPICK.Clear()
        TXTBWIDTH.Clear()
        'TXTBFOLD.Clear()
        TXTBGRAMS.Clear()
        TXTBDECMTRS.Focus()

    End Sub

    Sub fillgridscan()
        Try
            If gridUPLOADdoubleclick = False Then

                gridupload.Rows.Add(Val(txtuploadsrno.Text.Trim), txtuploadremarks.Text.Trim, txtuploadname.Text.Trim, txtimgpath.Text.Trim, TXTNEWIMGPATH.Text.Trim, TXTFILENAME.Text.Trim)
                uploadgetsrno(gridupload)

            ElseIf gridUPLOADdoubleclick = True Then

                gridupload.Item(0, tempUPLOADrow).Value = txtuploadsrno.Text.Trim
                gridupload.Item(1, tempUPLOADrow).Value = txtuploadremarks.Text.Trim
                gridupload.Item(2, tempUPLOADrow).Value = txtuploadname.Text.Trim
                gridupload.Item(3, tempUPLOADrow).Value = txtimgpath.Text.Trim
                gridupload.Item(GNEWIMGPATH.Index, tempUPLOADrow).Value = TXTNEWIMGPATH.Text.Trim
                gridupload.Item(GFILENAME.Index, tempUPLOADrow).Value = TXTFILENAME.Text.Trim

                gridUPLOADdoubleclick = False

            End If
            gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click

        If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.png;*.pdf)|*.bmp;*.jpeg;*.png;*.pdf"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        TXTFILENAME.Text = OpenFileDialog1.SafeFileName
        txtimgpath.Text = OpenFileDialog1.FileName
        TXTNEWIMGPATH.Text = Application.StartupPath & "\UPLOADDOCS\" & txtgrnno.Text.Trim & txtuploadsrno.Text.Trim & TXTFILENAME.Text.Trim
        On Error Resume Next

        If txtimgpath.Text.Trim.Length <> 0 Then
            PBSoftCopy.ImageLocation = txtimgpath.Text.Trim
            PBSoftCopy.Load(txtimgpath.Text.Trim)
            txtuploadsrno.Focus()
        End If
    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If txtimgpath.Text.Trim <> "" And txtuploadname.Text.Trim <> "" Then
                fillgridscan()
                txtuploadremarks.Clear()
                txtuploadname.Clear()
                txtimgpath.Clear()
                PBSoftCopy.ImageLocation = ""
                txtuploadsrno.Focus()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value <> Nothing Then
                gridUPLOADdoubleclick = True
                tempUPLOADrow = e.RowIndex
                txtuploadsrno.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value
                txtuploadremarks.Text = gridupload.Rows(e.RowIndex).Cells(GREMARKS.Index).Value
                txtuploadname.Text = gridupload.Rows(e.RowIndex).Cells(GNAME.Index).Value
                txtimgpath.Text = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                TXTNEWIMGPATH.Text = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                TXTFILENAME.Text = gridupload.Rows(e.RowIndex).Cells(GFILENAME.Index).Value
                txtuploadsrno.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then
            Dim TEMPMSG As Integer = MsgBox("This Will Delete File, Wish to Proceed?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                If FileIO.FileSystem.FileExists(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value) Then FileIO.FileSystem.DeleteFile(gridupload.Rows(gridupload.CurrentRow.Index).Cells(GNEWIMGPATH.Index).Value)
                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                uploadgetsrno(gridupload)
            End If
        End If
    End Sub

    Private Sub gridupload_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.RowEnter
        Try
            If gridupload.RowCount > 0 Then
                If Not FileIO.FileSystem.FileExists(gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value) Then
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                Else
                    PBSoftCopy.ImageLocation = gridupload.Rows(e.RowIndex).Cells(GNEWIMGPATH.Index).Value
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtuploadsrno.GotFocus
        If gridUPLOADdoubleclick = False Then
            If gridupload.RowCount > 0 Then
                txtuploadsrno.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(GGRIDUPLOADSRNO.Index).Value) + 1
            Else
                txtuploadsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub gridgrn_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgrn.CellDoubleClick
        Try
            EDITROW()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If lbllocked.Visible = True And ClientName <> "TULSI" Then Exit Sub

            If gridgrn.CurrentRow.Index >= 0 And gridgrn.Item(gsrno.Index, gridgrn.CurrentRow.Index).Value <> Nothing Then
                gridDoubleClick = True

                txtsrno.Text = gridgrn.Item(gsrno.Index, gridgrn.CurrentRow.Index).Value.ToString
                cmbitemname.Text = gridgrn.Item(gitemname.Index, gridgrn.CurrentRow.Index).Value.ToString
                txtgridremarks.Text = gridgrn.Item(gdesc.Index, gridgrn.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = gridgrn.Item(GQUALITY.Index, gridgrn.CurrentRow.Index).Value.ToString
                TXTREED.Text = gridgrn.Item(GREED.Index, gridgrn.CurrentRow.Index).Value.ToString
                TXTPICK.Text = gridgrn.Item(GPICK.Index, gridgrn.CurrentRow.Index).Value.ToString
                cmbcolor.Text = gridgrn.Item(gcolor.Index, gridgrn.CurrentRow.Index).Value.ToString
                CMBLABTEST.Text = gridgrn.Item(GLABTEST.Index, gridgrn.CurrentRow.Index).Value.ToString
                txtqty.Text = gridgrn.Item(gQty.Index, gridgrn.CurrentRow.Index).Value.ToString
                cmbqtyunit.Text = gridgrn.Item(gqtyunit.Index, gridgrn.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = gridgrn.Item(GMTRS.Index, gridgrn.CurrentRow.Index).Value.ToString
                TXTWT.Text = gridgrn.Item(GWT.Index, gridgrn.CurrentRow.Index).Value.ToString

                temprow = gridgrn.CurrentRow.Index
                cmbitemname.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            gridgrn.RowCount = 0
            temptypename = cmbtype.Text.Trim

            tempgrnno = Val(txtgrnno.Text) - 1
            If tempgrnno > 0 Then
                edit = True
                GRN_Load(sender, e)
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

    Private Sub cmbtype_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.Enter
        Try
            getmaxno()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtype_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtype.Validating
        Try
            If cmbtype.Text.Trim.Length > 0 And edit = False Then
                getmaxno()
                cmbtype.Enabled = False
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
            tempgrnno = Val(txtgrnno.Text) + 1
            temptypename = cmbtype.Text.Trim
            getmaxno()
            CLEAR()
            If Val(txtgrnno.Text) - 1 >= tempgrnno Then
                edit = True
                GRN_Load(sender, e)
            Else
                CLEAR()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        If cmbtype.Text.Trim = "Inwards" Then numdotkeypress(e, sender, Me) Else numdot(e, sender, Me)
    End Sub

    Private Sub txtTOTALBALES_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTOTALBALES.KeyPress
        numdot(e, TXTTOTALBALES, Me)
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub podate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles podate.Validating
        If Not datecheck(podate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try

            Dim done As Boolean
            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTTABLE As New DataTable
                DTTABLE = getmax(" GRN_done ", " GRN_DESC", " and GRN_no=" & txtgrnno.Text.Trim & " AND GRN_cmpid=" & CmpId & " AND GRN_LOCATIONID = " & Locationid & " AND GRN_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then
                    done = DTTABLE.Rows(0).Item(0)
                End If
                If done = True Then
                    MsgBox("Checking Raised Delete Checking First", MsgBoxStyle.Critical)
                Else

                    TEMPMSG = MsgBox("Delete GRN?", MsgBoxStyle.YesNo)
                    If TEMPMSG = vbYes Then
                        Dim alParaval As New ArrayList
                        alParaval.Add(txtgrnno.Text.Trim)
                        alParaval.Add(cmbtype.Text.Trim)
                        alParaval.Add(Userid)
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(YearId)

                        Dim Clsgrn As New ClsGrn()
                        Clsgrn.alParaval = alParaval
                        IntResult = Clsgrn.Delete()
                        MsgBox("GRN Deleted")
                        CLEAR()
                        edit = False
                    End If
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbqtyunit.GotFocus
        Try
            If cmbqtyunit.Text.Trim = "" Then fillunit(cmbqtyunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbqtyunit.Validating
        Try
            If cmbqtyunit.Text.Trim <> "" Then unitvalidate(cmbqtyunit, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridgrn_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridgrn.CellValidating
        Try
            Dim colNum As Integer = gridgrn.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GMTRS.Index, GWT.Index, gQty.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If gridgrn.CurrentCell.Value = Nothing Then gridgrn.CurrentCell.Value = "0.00"
                        gridgrn.CurrentCell.Value = Convert.ToDecimal(gridgrn.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        total()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridgrn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridgrn.KeyDown

        Try
            If e.KeyCode = Keys.Delete And gridgrn.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                If lbllocked.Visible = True Then Exit Sub

                gridgrn.Rows.RemoveAt(gridgrn.CurrentRow.Index)
                getsrno(gridgrn)
                total()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbcolor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcolor.GotFocus
        Try
            Cursor.Current = Cursors.WaitCursor
            fillCOLOR(cmbcolor)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmbcolor_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcolor.Validating
        Try
            Cursor.Current = Cursors.WaitCursor
            COLORvalidate(cmbcolor, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub TXTREED_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTREED.KeyPress, TXTADDROWS.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPICK_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTPICK.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMBBROKER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBBROKER.Enter
        Try
            If CMBBROKER.Text.Trim = "" Then fillname(CMBBROKER, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBBROKER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBBROKER.Validating
        Try
            If CMBBROKER.Text.Trim <> "" Then namevalidate(CMBBROKER, e, Me, TXTWEAVERADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' ", "Sundry Creditors", "AGENT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMTRS.KeyPress, TXTRATE.KeyPress, TXTBDECMTRS.KeyPress, TXTBWT.KeyPress, TXTBWIDTH.KeyPress, TXTBFOLD.KeyPress, TXTBGRAMS.KeyPress, TXTWT.KeyPress
        numdot(e, sender, Me)
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then
                If FRMSTRING = "GRN" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS'") Else fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS'")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then
                If FRMSTRING = "GRN" Then namevalidate(cmbname, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS' ", "Sundry Debtors", "ACCOUNTS", cmbtrans.Text, CMBBROKER.Text) Else namevalidate(cmbname, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'  AND ISNULL(LEDGERS.ACC_TYPE,'ACCOUNTS') = 'ACCOUNTS' ", "Sundry Creditors", "ACCOUNTS", cmbtrans.Text, CMBBROKER.Text)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTWT.Validated
        Try
            If cmbitemname.Text.Trim <> "" And Val(txtqty.Text.Trim) > 0 And cmbqtyunit.Text.Trim <> "" Then
                fillgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub pbcopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbcopy.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            If gridDoubleClick = True Then
                MsgBox("Copy function is disabled in grid line edit mode")
                txtsrno.Focus()
                Exit Sub
            End If

            If gridgrn.RowCount > 0 Then
                'Dim tempmsg As Integer = MsgBox("Copy selected Item?", MsgBoxStyle.YesNo)
                'If tempmsg = vbYes Then

                For Each ROW As DataGridViewRow In gridgrn.SelectedRows
                    txtsrno.Text = gridgrn.RowCount + 1
                    cmbitemname.Text = ROW.Cells(gitemname.Index).Value.ToString
                    txtgridremarks.Text = ROW.Cells(gdesc.Index).Value.ToString
                    CMBQUALITY.Text = ROW.Cells(GQUALITY.Index).Value.ToString
                    TXTREED.Text = ROW.Cells(GREED.Index).Value.ToString
                    TXTPICK.Text = ROW.Cells(GPICK.Index).Value.ToString
                    cmbcolor.Text = ROW.Cells(gcolor.Index).Value.ToString
                    CMBLABTEST.Text = ROW.Cells(GLABTEST.Index).Value.ToString
                    txtqty.Text = ROW.Cells(gQty.Index).Value.ToString
                    cmbqtyunit.Text = ROW.Cells(gqtyunit.Index).Value.ToString
                    TXTMTRS.Text = ROW.Cells(GMTRS.Index).Value.ToString
                    TXTWT.Text = ROW.Cells(GWT.Index).Value.ToString

                    txtqty.Focus()
                Next

                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillQUALITY(CMBQUALITY, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbQUALITY_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then QUALITYVALIDATE(CMBQUALITY, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDVIEW.Click
        Try
            If txtimgpath.Text.Trim <> "" Then
                If Path.GetExtension(txtimgpath.Text.Trim) = ".pdf" Then
                    System.Diagnostics.Process.Start(txtimgpath.Text.Trim)
                Else
                    Dim objVIEW As New ViewImage
                    objVIEW.pbsoftcopy.ImageLocation = PBSoftCopy.ImageLocation
                    objVIEW.ShowDialog()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then PRINTREPORT()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            If MsgBox("Wish to Print GRN?", MsgBoxStyle.YesNo) = vbYes Then
                Dim OBJGRN As New GRNDesign
                OBJGRN.GRNNO = Val(txtgrnno.Text.Trim)
                OBJGRN.FRMSTRING = "GRN"
                OBJGRN.MdiParent = MDIMain
                OBJGRN.selfor_GRN = "{GRN.GRN_NO}=" & Val(txtgrnno.Text.Trim) & " AND {GRN.GRN_TYPE} = '" & cmbtype.Text.Trim & "' and {GRN.GRN_yearid}=" & YearId
                OBJGRN.vendorname = cmbname.Text.Trim
                OBJGRN.Show()
            End If

            'INSTRUCTION REPORT
            If ClientName = "TULSI" Or ClientName = "SHREENATH" Or cmbtype.Text.Trim <> "G.R.N" Then Exit Sub
            If MsgBox("Wish To Print Instruction Report?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            Dim OBJGRNINS As New GRNDesign
            OBJGRNINS.GRNNO = Val(txtgrnno.Text.Trim)
            OBJGRNINS.FRMSTRING = "GRNINS"
            OBJGRNINS.MdiParent = MDIMain
            OBJGRNINS.selfor_GRN = "{GRN.GRN_NO}=" & Val(txtgrnno.Text.Trim) & " AND {GRN.GRN_TYPE} = '" & cmbtype.Text.Trim & "' and {GRN.GRN_yearid}=" & YearId
            OBJGRNINS.vendorname = cmbname.Text.Trim
            OBJGRNINS.Show()

            If ClientName <> "SHUBHLAXMI" Then Exit Sub
            If MsgBox("Wish To Print Grey Wt Report?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            OBJGRNINS = New GRNDesign
            OBJGRNINS.GRNNO = Val(txtgrnno.Text.Trim)
            OBJGRNINS.FRMSTRING = "GRNWTREPORT"
            OBJGRNINS.MdiParent = MDIMain
            OBJGRNINS.selfor_GRN = "{GRN.GRN_NO}=" & Val(txtgrnno.Text.Trim) & " AND {GRN.GRN_TYPE} = '" & cmbtype.Text.Trim & "' and {GRN.GRN_yearid}=" & YearId
            OBJGRNINS.vendorname = cmbname.Text.Trim
            OBJGRNINS.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSENDER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBSENDER.Enter
        Try
            If CMBSENDER.Text.Trim = "" Then fillname(CMBSENDER, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSENDER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBSENDER.Validating
        Try
            If CMBSENDER.Text.Trim <> "" Then namevalidate(CMBSENDER, e, Me, TXTWEAVERADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWEAVER_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBWEAVER.Enter
        Try
            If CMBWEAVER.Text.Trim = "" Then FILLWEAVER(CMBWEAVER, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWEAVER_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBWEAVER.Validating
        Try
            If CMBWEAVER.Text.Trim <> "" Then WEAVERvalidate(CMBWEAVER, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitemname.Enter
        Try
            If cmbitemname.Text.Trim = "" Then fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitemname.Validating
        Try
            If cmbitemname.Text.Trim <> "" Then itemvalidate(cmbitemname, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'", "ITEM")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtgrnno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtgrnno.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub txtgrnno_Validating(sender As Object, e As CancelEventArgs) Handles txtgrnno.Validating
        Try
            If Val(txtgrnno.Text.Trim) <> 0 And edit = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.search(" ISNULL(GRN.GRN_NO,0)  AS GRNNO", "", " GRN ", "  AND GRN.GRN_NO=" & txtgrnno.Text.Trim & " AND GRN.GRN_TYPE = '" & cmbtype.Text.Trim & "' AND GRN.GRN_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Lot No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRN_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                If FRMSTRING = "GRN" Then gdesc.HeaderText = "Design Nos" Else gdesc.HeaderText = "Lab Report"
                TXTREADYWIDTH.BackColor = Color.LemonChiffon

                TXTBDECMTRS.BackColor = Color.LemonChiffon
                TXTBWT.BackColor = Color.LemonChiffon
                TXTBREEDPICK.BackColor = Color.LemonChiffon
                TXTBWIDTH.BackColor = Color.LemonChiffon
                TXTBFOLD.BackColor = Color.LemonChiffon
                CMBMERCHANT.BackColor = Color.LemonChiffon
            End If
            If FRMSTRING = "INWARD" Then
                LBLLOTNO.Text = "GRN No"
                Me.Text = "Store Inward"
                OQUALITY.Visible = False
                OMTRS.Visible = False
                OGRNMTRS.Visible = False
            ElseIf FRMSTRING = "GRN" Then
                LBLLOTNO.Text = "Lot No"
            End If
            If UserName = "Admin" Then CMBGODOWN.Enabled = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBGRAMS_Validating(sender As Object, e As CancelEventArgs) Handles TXTBGRAMS.Validating
        Try
            If Val(TXTBDECMTRS.Text.Trim) > 0 And Val(TXTBWT.Text.Trim) > 0 And TXTBREEDPICK.Text.Trim <> "" And Val(TXTBWIDTH.Text.Trim) > 0 And Val(TXTBFOLD.Text.Trim) > 0 Then
                FILLBLEACHGRID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBLEACH_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDBLEACH.CellDoubleClick
        Try
            If GRIDBLEACH.CurrentRow.Index >= 0 And GRIDBLEACH.Item(BSRNO.Index, GRIDBLEACH.CurrentRow.Index).Value <> Nothing Then
                GRIDBLEACHDOUBLECLICK = True

                TXTBSRNO.Text = Val(GRIDBLEACH.Item(BSRNO.Index, GRIDBLEACH.CurrentRow.Index).Value)
                TXTBDECMTRS.Text = Val(GRIDBLEACH.Item(BMTRS.Index, GRIDBLEACH.CurrentRow.Index).Value)
                TXTBWT.Text = Val(GRIDBLEACH.Item(BWT.Index, GRIDBLEACH.CurrentRow.Index).Value)
                TXTBREEDPICK.Text = GRIDBLEACH.Item(BREEDPICK.Index, GRIDBLEACH.CurrentRow.Index).Value.ToString
                TXTBWIDTH.Text = Val(GRIDBLEACH.Item(BWIDTH.Index, GRIDBLEACH.CurrentRow.Index).Value)
                TXTBFOLD.Text = Val(GRIDBLEACH.Item(BFOLD.Index, GRIDBLEACH.CurrentRow.Index).Value)
                TXTBGRAMS.Text = Val(GRIDBLEACH.Item(BGRAMS.Index, GRIDBLEACH.CurrentRow.Index).Value)

                TEMPBLEACHROW = GRIDBLEACH.CurrentRow.Index
                TXTBDECMTRS.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBLEACH_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDBLEACH.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBLEACH.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                'cmbitemname.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDBLEACHDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDBLEACH.Rows.RemoveAt(GRIDBLEACH.CurrentRow.Index)
                getsrno(GRIDBLEACH)
                total()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub BLEACHCALC()
        Try
            If Val(TXTBDECMTRS.Text.Trim) > 0 And Val(TXTBWT.Text.Trim) > 0 And Val(TXTBFOLD.Text.Trim) > 0 Then
                TXTBGRAMS.Text = Format(Val(TXTBWT.Text.Trim) / Val(TXTBDECMTRS.Text.Trim), "0.000")
                TXTBGRAMS.Text = Format(Val(TXTBGRAMS.Text.Trim) + Val(TXTBGRAMS.Text) * ((100 - Val(TXTBFOLD.Text.Trim)) / 100), "0.000")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBFOLD_Validated(sender As Object, e As EventArgs) Handles TXTBFOLD.Validated, TXTBDECMTRS.Validated, TXTBWT.Validated
        BLEACHCALC()
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

    Private Sub CMBPARTYMERCHANT_Enter(sender As Object, e As EventArgs) Handles CMBPARTYMERCHANT.Enter
        Try
            If CMBPARTYMERCHANT.Text.Trim = "" Then fillitemname(CMBPARTYMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPARTYMERCHANT_Validating(sender As Object, e As CancelEventArgs) Handles CMBPARTYMERCHANT.Validating
        Try
            If CMBPARTYMERCHANT.Text.Trim <> "" Then itemvalidate(CMBPARTYMERCHANT, e, Me, " AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' OR ITEMMASTER.ITEM_FRMSTRING = 'ITEM')", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Enter(sender As Object, e As EventArgs) Handles CMBCATEGORY.Enter
        Try
            If CMBCATEGORY.Text.Trim = "" Then fillCATEGORY(CMBCATEGORY, edit)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCATEGORY_Validating(sender As Object, e As CancelEventArgs) Handles CMBCATEGORY.Validating
        Try
            If CMBCATEGORY.Text.Trim <> "" Then CATEGORYVALIDATE(CMBCATEGORY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTADDROWS_Validated(sender As Object, e As EventArgs) Handles TXTADDROWS.Validated
        Try
            If Val(TXTADDROWS.Text.Trim) > 0 Then
                If MsgBox("Add Rows?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                For I As Integer = 1 To Val(TXTADDROWS.Text.Trim)
                    GRIDBLEACH.Rows.Add(0, 0, 0, "", 0, 0, 0)
                Next
                getsrno(GRIDBLEACH)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBLEACH_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDBLEACH.CellValidating
        Try

            Dim COLNUM As Integer = GRIDBLEACH.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case COLNUM

                Case BMTRS.Index, BWT.Index, BFOLD.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDBLEACH.CurrentCell.Value = Nothing Then GRIDBLEACH.CurrentCell.Value = "0.00"
                        GRIDBLEACH.CurrentCell.Value = Convert.ToDecimal(GRIDBLEACH.Item(COLNUM, e.RowIndex).Value)
                        total()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If


            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDORDER_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDORDER.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDORDER.RowCount > 0 Then
                GRIDORDER.Rows.RemoveAt(GRIDORDER.CurrentRow.Index)
                getsrno(GRIDORDER)
                total()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class