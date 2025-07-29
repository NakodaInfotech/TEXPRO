
Imports BL
Imports System.Net
Imports System.ComponentModel
Imports System.IO

Public Class GDN

    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Dim gridUPLOADdoubleclick As Boolean
    Public edit As Boolean          'used for editing
    Public tempgdnno As Integer     'used for poation no while editing
    Dim temprow As Integer
    Dim tempUPLOADrow As Integer
    Public Shared selectgdntable As New DataTable
    Public Shared selectpstable As New DataTable
    Dim dt_ps As New DataTable
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        FILLCMB()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        EP.Clear()

        cmbname.Text = ""
        TXTMULTISONO.Clear()
        tstxtbillno.Clear()
        TXTBALENO.Clear()
        TXTLRNO.Clear()

        txtadd.Clear()
        gdndate.Value = Mydate
        txtpono.Clear()
        txtconsignee.Clear()
        CMBSHIPTO.Text = ""
        CMBAGENT.Text = ""
        CMBCITY.Text = ""
        TXTSONO.Clear()

        CMBTRANS.Text = ""
        CMBLOCALTRANS.Text = ""
        TXTVEHICLENO.Clear()

        txtremarks.Clear()
        CHKNOTRETURN.CheckState = CheckState.Unchecked


        dt_ps.Reset()
        dt_ps.Columns.Add("srno")
        dt_ps.Columns.Add("psno")
        dt_ps.Columns.Add("fbno")
        dt_ps.Columns.Add("quality")
        dt_ps.Columns.Add("pcs")
        dt_ps.Columns.Add("mtrs")
        dt_ps.Columns.Add("sono")
        dt_ps.Columns.Add("sogridsrno")
        lbllocked.Visible = False
        PBlock.Visible = False

        'clearing itemgrid textboxes and combos

        gridps.RowCount = 0
        gridgdn.RowCount = 0

        cmdselectps.Enabled = True
        gridDoubleClick = False
        gridUPLOADdoubleclick = False
        GETMAXNO()


        CMBHSNCODE.Text = ""
        TXTSUBTOTAL.Clear()
        TXTCGSTPER.Clear()
        TXTCGSTAMT.Clear()
        TXTSGSTPER.Clear()
        TXTSGSTAMT.Clear()
        TXTIGSTPER.Clear()
        TXTIGSTAMT.Clear()
        txtroundoff.Clear()
        txtgrandtotal.Clear()
        TXTINWORDS.Clear()

        If CMPCITYNAME <> "" Then CMBFROMCITY.Text = CMPCITYNAME Else CMBFROMCITY.Text = ""
        TXTEWAYBILLNO.Clear()
        TXTPRODDESC.Clear()

        LBLTOTALMTRS.Text = 0
        LBLTOTALPCS.Text = 0
        GRIDORDER.RowCount = 0

    End Sub

    Sub TOTAL()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALPCS.Text = 0.0


            For Each ROW As DataGridViewRow In gridps.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(Gmtrs.Index).EditedFormattedValue), "0.00")
                    LBLTOTALPCS.Text = Format(Val(LBLTOTALPCS.Text) + Val(ROW.Cells(Gpcs.Index).EditedFormattedValue), "0.00")
                End If
            Next


            TXTCGSTAMT.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTCGSTPER.Text.Trim)) / 100, "0.00")
            TXTSGSTAMT.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTSGSTPER.Text.Trim)) / 100, "0.00")
            TXTIGSTAMT.Text = Format((Val(TXTSUBTOTAL.Text.Trim) * Val(TXTIGSTPER.Text.Trim)) / 100, "0.00")

            txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim), "0")
            txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT.Text.Trim) + Val(TXTSGSTAMT.Text.Trim) + Val(TXTIGSTAMT.Text.Trim)), "0.00")
            If Val(txtgrandtotal.Text) > 0 Then TXTINWORDS.Text = CurrencyToWord(txtgrandtotal.Text)
            BALECOUNT()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub BALECOUNT()
        Try
            LBLTOTALBALES.Text = 0
            Dim dic As New Dictionary(Of String, Integer)()
            Dim cellValue As String
            For i = 0 To gridps.Rows.Count - 1
                If Not gridps.Rows(i).IsNewRow Then
                    cellValue = gridps(Gbaleno.Index, i).EditedFormattedValue.ToString()
                    If cellValue <> "" Then
                        If Not dic.ContainsKey(cellValue) Then
                            dic.Add(cellValue, 1)
                        Else
                            dic(cellValue) += 1
                        End If
                    End If
                End If
            Next
            LBLTOTALBALES.Text = Val(dic.Count)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        edit = False
        cmbname.Focus()
    End Sub

    Private Sub grndate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles gdndate.Validating
        If Not datecheck(gdndate.Value) Then
            MsgBox("Date Not in Current Accounting Year")
            e.Cancel = True
        End If
    End Sub

    Sub GETMAXNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(gdn_no),0) + 1 ", "gdn", " AND gdn_cmpid=" & CmpId & " and gdn_locationid=" & Locationid & " and gdn_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            txtgdnno.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True
            If cmbname.Text.Trim.Length = 0 And ClientName <> "DHANLAXMI" Then
                EP.SetError(cmbname, " Please Fill Company Name ")
                bln = False
            End If

            If CMBAGENT.Text.Trim.Length = 0 Then
                EP.SetError(CMBAGENT, " Please Select Agent")
                bln = False
            End If
            If CMBTRANS.Text.Trim.Length = 0 Then
                EP.SetError(CMBTRANS, " Please Fill Transport Name ")
                bln = False
            End If
            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, "Invoice Made, Delete Invoice First")
                bln = False
            End If
            If gridps.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            If CMBCITY.Text.Trim = "" And ClientName <> "TULSI" And ClientName <> "SHREENATH" Then
                EP.SetError(CMBCITY, "Enter Delivery Place")
                bln = False
            End If



            'FOR ORDER CHECKING, FIRST REMOVE GDNQTY
            Dim TEMPORDERROWNO As Integer = -1
            Dim TEMPORDERMATCH As Boolean = False
            If GRIDORDER.RowCount > 0 Then

                For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                    ORDROW.Cells(OGDNBALES.Index).Value = 0
                Next


                For Each CHROW As DataGridViewRow In gridgdn.Rows
                    CHROW.Cells(GGDNSONO.Index).Value = 0
                    CHROW.Cells(GGDNSOSRNO.Index).Value = 0
                Next

                'GET MULTISONO
                Dim MULTISONO() As String = (From row As DataGridViewRow In GRIDORDER.Rows.Cast(Of DataGridViewRow)() Where Not row.IsNewRow Select CStr(row.Cells(OFROMNO.Index).Value)).Distinct.ToArray
                TXTMULTISONO.Clear()
                For Each a As String In MULTISONO
                    If TXTMULTISONO.Text = "" Then
                        TXTMULTISONO.Text = a
                    Else
                        TXTMULTISONO.Text = TXTMULTISONO.Text & "," & a
                    End If
                Next


                For Each ROW As DataGridViewRow In gridps.Rows
                    For Each ORDROW As DataGridViewRow In GRIDORDER.Rows

                        If ROW.Cells(CMBPARTYNAME.Index).Value = ORDROW.Cells(OPARTYNAME.Index).Value And ROW.Cells(gpsMerchant.Index).Value = ORDROW.Cells(OITEMNAME.Index).Value Then
                            TEMPORDERMATCH = True
                            'IF PARTYNAME AND ITEM IS MATCHED BUT THE QTY IS FULL THEN WE NEED TO KEEP THIS ROWNO IN TEMP AND NEED TO CHECK FURTHER ALSO
                            'IF WE GET ANY NEW MATHING THEN WE NEED TO INSERT THERE
                            'IF NO MATCHING IS FOUND IN FURTHER ROWS THEN WE NEED TO ADD QTY IN THIS TEMPROW
                            If Val(ORDROW.Cells(OGDNBALES.Index).Value) >= Val(ORDROW.Cells(OBALES.Index).Value) Then
                                TEMPORDERROWNO = ORDROW.Index
                                GoTo CHECKNEXTLINEMTRS
                            End If
                            ORDROW.Cells(OGDNBALES.Index).Value = Val(ORDROW.Cells(OGDNBALES.Index).Value) + 1
                            ROW.Cells(grate.Index).Value = Val(ORDROW.Cells(ORATE.Index).Value)
                            ROW.Cells(GGDNSONO.Index).Value = Val(ORDROW.Cells(OFROMNO.Index).Value)
                            ROW.Cells(GGDNSOSRNO.Index).Value = Val(ORDROW.Cells(OFROMSRNO.Index).Value)
                            TEMPORDERROWNO = -1
                            Exit For
CHECKNEXTLINEMTRS:
                        End If
                    Next
                    'IF NO FURTHER MACHING IS FOUND BUT WE HAVE TEMPORDERROWNO THEN ADD VALUE IN THAT ROW
                    If TEMPORDERROWNO >= 0 Then
                        GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGDNBALES.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGDNBALES.Index).Value) + 1
                        ROW.Cells(grate.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(ORATE.Index).Value)
                        ROW.Cells(GGDNSONO.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OFROMNO.Index).Value)
                        ROW.Cells(GGDNSOSRNO.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OFROMSRNO.Index).Value)
                        TEMPORDERROWNO = -1
                    End If
                    If TEMPORDERMATCH = False Then
                        ROW.DefaultCellStyle.BackColor = Color.LightGreen

                        'SALEORDER MANDATORY 
                        If ClientName = "AVIS" Or ClientName = "NAYRA" Or ClientName = "SIDDHGIRI" Or ClientName = "SUPRIYA" Then
                            EP.SetError(cmbname, "There are Items which are not Present in Selected Order")
                            bln = False
                        Else
                            If MsgBox("There are Items which are not Present in Selected Order, Wish to Proceed", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                EP.SetError(cmbname, "There are Items which are not Present in Selected Order")
                                bln = False
                            End If
                        End If
                    End If
                    TEMPORDERMATCH = False
                Next

            End If





            If Not datecheck(gdndate.Value) Then bln = False

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Private Sub cmdselectOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectOrder.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            selectgdntable.Clear()
            Dim OBJSELECTPO As New SelectWOforGDN
            OBJSELECTPO.ShowDialog()
            Dim i As Integer = 0
            If selectgdntable.Rows.Count > 0 Then
                chkchange.Checked = True
                If edit = False Then gridgdn.RowCount = 0
                For i = 0 To selectgdntable.Rows.Count - 1
                    cmbname.Text = selectgdntable.Rows(i).Item("CMPNAME")
                    TXTSONO.Text = selectgdntable.Rows(i).Item("SONO")
                    txtconsignee.Text = selectgdntable.Rows(i).Item("consignee")
                    CMBAGENT.Text = selectgdntable.Rows(i).Item("agent")
                    txtpono.Text = selectgdntable.Rows(i).Item("pono")
                    DISPATCHDATE.Value = Convert.ToDateTime(selectgdntable.Rows(i).Item("podate"))
                    gridgdn.Rows.Add(i + 1, selectgdntable.Rows(i).Item("PIECETYPE"), selectgdntable.Rows(i).Item("ITEMNAME"), Format(Val(selectgdntable.Rows(i).Item("CUT")), "0.00"), selectgdntable.Rows(i).Item("DESIGN"), selectgdntable.Rows(i).Item("COLOR"), selectgdntable.Rows(i).Item("gridremarks"), selectgdntable.Rows(i).Item("bales"), Format(Val(selectgdntable.Rows(i).Item("PCS")), "0.00"), Format(Val(selectgdntable.Rows(i).Item("RATE")), "0.00"), Format(Val(selectgdntable.Rows(i).Item("AMT")), "0.00"), Val(selectgdntable.Rows(i).Item("SONO")), Val(selectgdntable.Rows(i).Item("GRIDSRNO")))
                Next
                gridgdn.FirstDisplayedScrollingRowIndex = gridgdn.RowCount - 1

                cmbname.Focus()
            End If
            total()

        Catch ex As Exception
            Throw ex
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

    Private Sub cmdselectps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdselectps.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim baleno As String = ""
            For Each row As Windows.Forms.DataGridViewRow In gridps.Rows
                If row.Cells(0).Value <> Nothing Then
                    If baleno = "" Then
                        baleno = row.Cells(Gbaleno.Index).Value.ToString
                    Else
                        baleno = baleno & "," & row.Cells(Gbaleno.Index).Value.ToString
                    End If
                End If
            Next
            If baleno <> "" Then
                baleno = "(" & baleno & ")"
            Else
                baleno = "(0)"
            End If

            selectpstable.Clear()
            Dim OBJSELECTPO As New SelectPs
            OBJSELECTPO.baleno = baleno
            OBJSELECTPO.PARTYNAME = cmbname.Text.Trim
            OBJSELECTPO.FRMSTR = "BALE"
            OBJSELECTPO.ShowDialog()



            If selectpstable.Rows.Count > 0 Then
                chkchange.Checked = True

                For i As Integer = 0 To selectpstable.Rows.Count - 1
                    If ClientName = "DHANLAXMI" Then selectpstable.Rows(i).Item("FBNO") = ""
                    gridps.Rows.Add(0, selectpstable.Rows(i).Item("BALENO"), selectpstable.Rows(i).Item("FBNO"), selectpstable.Rows(i).Item("piecetype"), selectpstable.Rows(i).Item("MERCHANT"), selectpstable.Rows(i).Item("cut"), selectpstable.Rows(i).Item("QUALITY"), Val(selectpstable.Rows(i).Item("PCS")), Format(Val(selectpstable.Rows(i).Item("MTRS")), "0.00"), Format(Val(selectpstable.Rows(i).Item("wt")), "0.00"), "", selectpstable.Rows(i).Item("NAME"), 0, selectpstable.Rows(i).Item("TYPE"), 0, 0)
                Next
                gridps.FirstDisplayedScrollingRowIndex = gridps.RowCount - 1
                getsrno(gridps)
                cmbname.Focus()
            End If
            TOTAL()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
            If CMBLOCALTRANS.Text.Trim = "" Then fillname(CMBLOCALTRANS, edit, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            If CMBSHIPTO.Text.Trim = "" Then fillname(CMBSHIPTO, edit, " AND GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, False, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'AGENT'")
            If CMBCITY.Text.Trim = "" Then fillcity(CMBCITY)
            If CMBFROMCITY.Text.Trim = "" Then fillcity(CMBFROMCITY)

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String(" SELECT ACC_CMPNAME AS NAME FROM LEDGERS INNER JOIN GROUPMASTER ON ACC_GROUPID = GROUP_ID WHERE ACC_YEARID = " & YearId & " ORDER BY NAME", "", "")
            If DT.Rows.Count > 0 Then
                CMBPARTYNAME.Items.Clear()
                For Each DTROW As DataRow In DT.Rows
                    CMBPARTYNAME.Items.Add(DTROW("NAME"))
                Next
            End If

            Dim DT1 As New DataTable
            If ClientName = "TULSI" Or ClientName = "SHREENATH" Then
                DT1 = OBJCMN.Execute_Any_String(" SELECT ITEM_NAME AS MERCHANT FROM ITEMMASTER WHERE ITEM_FRMSTRING='MERCHANT' AND ITEM_YEARID = " & YearId & " ORDER BY ITEM_NAME", "", "")
            Else
                DT1 = OBJCMN.Execute_Any_String(" SELECT ITEM_NAME AS MERCHANT FROM ITEMMASTER WHERE  ITEM_YEARID = " & YearId & " ORDER BY ITEM_NAME", "", "")
            End If
            If DT1.Rows.Count > 0 Then
                gpsMerchant.Items.Clear()
                For Each DTROW As DataRow In DT1.Rows
                    gpsMerchant.Items.Add(DTROW("MERCHANT"))
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHSNCODE.Enter
        Try
            If CMBHSNCODE.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHSNCODE.Validating
        Try
            If CMBHSNCODE.Text.Trim <> "" Then HSNITEMDESCVALIDATE(CMBHSNCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBHSNCODE.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try
            'TXTHSNCODE.Clear()
            TXTCGSTPER.Clear()
            TXTCGSTAMT.Clear()
            TXTSGSTPER.Clear()
            TXTSGSTAMT.Clear()
            TXTIGSTPER.Clear()
            TXTIGSTAMT.Clear()


            If CMBHSNCODE.Text.Trim <> "" And gdndate.Value.Date >= "01/07/2017" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(HSN_CGST, 0) AS CGSTPER, ISNULL(HSN_SGST, 0) AS SGSTPER, ISNULL(HSN_IGST, 0) AS IGSTPER ", "", " HSNMASTER ", " AND HSNMASTER.HSN_CODE = '" & CMBHSNCODE.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                If DT.Rows.Count > 0 Then
                    'TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                    If cmbname.Text.Trim <> "" Then
                        If TXTSTATECODE.Text.Trim = CMPSTATECODE Then
                            TXTIGSTPER.Text = 0
                            TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                            TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                        Else
                            TXTCGSTPER.Text = 0
                            TXTSGSTPER.Text = 0
                            TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                        End If
                    End If


                End If
                TOTAL()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLHSNITEMDESC(ByRef CMBHSNCODE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ISNULL(HSN_CODE, '') AS HSNCODE ", "", " HSNMASTER ", " AND HSN_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HSNCODE"
                CMBHSNCODE.DataSource = dt
                CMBHSNCODE.DisplayMember = "HSNCODE"
            End If
            CMBHSNCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GDN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If errorvalid() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.NumPad1 Then
                TabControl1.SelectedIndex = 0
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.NumPad2 Then
                TabControl1.SelectedIndex = 1
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.NumPad3 Then
                TabControl1.SelectedIndex = 2
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                Call PrintToolStripButton_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolPREVIOUS_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_CLICK(sender, e)
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GDN_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'CHALLAN'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            CLEAR()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim objclsGDN As New ClsGDN()
                Dim dttable As New DataTable

                dttable = objclsGDN.selectGDN(tempgdnno, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then
                    For Each dr As DataRow In dttable.Rows

                        txtgdnno.Text = tempgdnno
                        cmbname.Text = Convert.ToString(dr("NAME").ToString)
                        gdndate.Value = Format(Convert.ToDateTime(dr("GDNDATE")).Date, "dd/MM/yyyy")
                        TXTSONO.Text = Convert.ToString(dr("ORDERNO").ToString)
                        txtpono.Text = Convert.ToString(dr("PONO").ToString)
                        DISPATCHDATE.Value = Format(Convert.ToDateTime(dr("DISPATCHDATE")).Date, "dd/MM/yyyy")
                        CMBTRANS.Text = dr("TRANSNAME").ToString
                        CMBLOCALTRANS.Text = dr("LOCALTRANSNAME").ToString
                        TXTVEHICLENO.Text = dr("VEHICLENO").ToString
                        CMBSHIPTO.Text = Convert.ToString(dr("CONSIGNEE").ToString)
                        CMBAGENT.Text = Convert.ToString(dr("AGENTNAME").ToString)
                        CMBCITY.Text = dr("CITYNAME")
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        CHKNOTRETURN.Checked = Convert.ToBoolean(dr("NOTRETURN"))
                        TXTMULTISONO.Text = Convert.ToString(dr("MULTISONO").ToString)
                        CMBFROMCITY.Text = dr("FROMCITY")
                        TXTEWAYBILLNO.Text = dr("EWAYBILLNO")
                        TXTPRODDESC.Text = dr("PRODDESC")
                        CMBHSNCODE.Text = dr("HSNCODE")
                        TXTSTATECODE.Text = dr("STATECODE")
                        TXTSUBTOTAL.Text = Val(dr("SUBTOTAL"))
                        TXTCGSTPER.Text = Val(dr("CGSTPER"))
                        TXTCGSTAMT.Text = Val(dr("CGSTAMT"))
                        TXTSGSTPER.Text = Val(dr("SGSTPER"))
                        TXTSGSTAMT.Text = Val(dr("SGSTAMT"))
                        TXTIGSTPER.Text = Val(dr("IGSTPER"))
                        TXTIGSTAMT.Text = Val(dr("IGSTAMT"))
                        txtroundoff.Text = Val(dr("ROUNDOFF"))
                        txtgrandtotal.Text = Val(dr("GRANDTOTAL"))


                        gridps.Rows.Add(dr("GRIDSRNO"), dr("PSNO"), dr("FBNO"), dr("PIECETYPE"), dr("MERCHANT"), dr("CUT"), dr("QUALITY"), dr("PCS"), dr("MTRS"), dr("WT"), dr("LRNO"), dr("BILLNO"), dr("PARTYNAME"), dr("GRIDDONE"), dr("TYPE"), Val(dr("GDNSONO")), Val(dr("GDNSOSRNO")))
                        If Convert.ToBoolean(dr("GRIDDONE")) = True Then
                            gridps.Rows(gridps.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If


                    Next

                    'ORDER GRID
                    Dim OBJCMN As New ClsCommon
                    dttable = OBJCMN.search(" ISNULL(GDN_SODETAILS.GDN_GRIDSRNO, 0) AS OSRNO, ISNULL(LEDGERS.ACC_CMPNAME,'') AS OPARTYNAME, ISNULL(ITEMMASTER.item_name, '') AS OITEMNAME, ISNULL(GDN_SODETAILS.GDN_BALES, 0) AS OBALES, ISNULL(GDN_SODETAILS.GDN_SONO,0) AS OFROMNO, ISNULL(GDN_SODETAILS.GDN_SOSRNO, 0) AS OFROMSRNO, ISNULL(GDN_SODETAILS.GDN_TYPE, '') AS OFROMTYPE, ISNULL(GDN_SODETAILS.GDN_GDNBALES, 0) AS OGDNBALES, ISNULL(GDN_SODETAILS.GDN_RATE, 0) AS ORATE ", "", " GDN_SODETAILS INNER JOIN LEDGERS ON GDN_SODETAILS.GDN_LEDGERID = LEDGERS.ACC_ID INNER JOIN ITEMMASTER ON GDN_SODETAILS.GDN_ITEMID = ITEMMASTER.item_id ", " AND GDN_SODETAILS.GDN_NO = " & Val(tempgdnno) & " AND GDN_SODETAILS.GDN_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            GRIDORDER.Rows.Add(Val(DTR("OSRNO")), DTR("OPARTYNAME"), DTR("OITEMNAME"), Val(DTR("OBALES")), Val(DTR("OFROMNO")), Val(DTR("OFROMSRNO")), DTR("OFROMTYPE"), Val(DTR("OGDNBALES")), Val(DTR("ORATE")))
                        Next
                    End If
                    getsrno(GRIDORDER)


                    TOTAL()
                End If

                chkchange.CheckState = CheckState.Checked
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList


            alParaval.Add(gdndate.Value)
            alParaval.Add(cmbname.Text.Trim)
            alParaval.Add(TXTSONO.Text.Trim)
            If CMBSHIPTO.Visible = True Then alParaval.Add(CMBSHIPTO.Text.Trim) Else alParaval.Add(txtconsignee.Text.Trim)
            alParaval.Add(CMBAGENT.Text.Trim)
            alParaval.Add(CMBCITY.Text.Trim)
            alParaval.Add(txtpono.Text.Trim)
            alParaval.Add(DISPATCHDATE.Value)
            alParaval.Add(CMBTRANS.Text.Trim)
            alParaval.Add(CMBLOCALTRANS.Text.Trim)
            alParaval.Add(TXTVEHICLENO.Text.Trim)
            alParaval.Add(Val(LBLTOTALPCS.Text))
            alParaval.Add(Val(LBLTOTALMTRS.Text))
            alParaval.Add(Val(LBLTOTALBALES.Text))
            alParaval.Add(txtremarks.Text.Trim)

            If CHKNOTRETURN.CheckState = CheckState.Checked Then alParaval.Add(1) Else alParaval.Add(0)

            alParaval.Add(0)


            alParaval.Add(CMBFROMCITY.Text.Trim)
            alParaval.Add(TXTEWAYBILLNO.Text.Trim)
            alParaval.Add(TXTPRODDESC.Text.Trim)
            alParaval.Add(CMBHSNCODE.Text.Trim)
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))
            alParaval.Add(Val(TXTCGSTPER.Text.Trim))
            alParaval.Add(Val(TXTCGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTSGSTPER.Text.Trim))
            alParaval.Add(Val(TXTSGSTAMT.Text.Trim))
            alParaval.Add(Val(TXTIGSTPER.Text.Trim))
            alParaval.Add(Val(TXTIGSTAMT.Text.Trim))
            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(txtgrandtotal.Text.Trim))
            alParaval.Add(TXTINWORDS.Text.Trim)
            alParaval.Add(TXTMULTISONO.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim GRIDSRNO As String = ""
            Dim PIECETYPE As String = ""
            Dim ITEMNAME As String = ""
            Dim CUT As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim gridremarks As String = ""
            Dim bales As String = ""
            Dim QTY As String = ""
            Dim RATE As String = ""
            Dim AMT As String = ""
            Dim SONO As String = ""             'WHETHER GRN IS DONE FOR THIS LINE
            Dim SOGRIDSRNO As String = ""             'WHETHER GRN IS DONE FOR THIS LINE
            'Dim TYPE As String = ""



            For Each row As Windows.Forms.DataGridViewRow In gridgdn.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = row.Cells(GSRNO.Index).Value.ToString
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = row.Cells(GMERCHANT.Index).Value.ToString
                        CUT = row.Cells(GCUT.Index).Value.ToString
                        DESIGN = row.Cells(GDESIGN.Index).Value.ToString

                        COLOR = row.Cells(gcolor.Index).Value.ToString
                        gridremarks = row.Cells(GGRIDREMARKS.Index).Value.ToString
                        bales = row.Cells(GBALES.Index).Value.ToString
                        QTY = row.Cells(GQTY.Index).Value.ToString
                        RATE = row.Cells(grate.Index).Value.ToString
                        AMT = row.Cells(gamt.Index).Value.ToString
                        SONO = row.Cells(gsono.Index).Value.ToString
                        SOGRIDSRNO = row.Cells(gsogridsrno.Index).Value.ToString


                    Else

                        GRIDSRNO = GRIDSRNO & "|" & row.Cells(GSRNO.Index).Value.ToString
                        PIECETYPE = PIECETYPE & "|" & row.Cells(GPIECETYPE.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GMERCHANT.Index).Value.ToString
                        CUT = CUT & "|" & row.Cells(GCUT.Index).Value.ToString
                        DESIGN = DESIGN & "|" & row.Cells(GDESIGN.Index).Value.ToString

                        COLOR = COLOR & "|" & row.Cells(gcolor.Index).Value.ToString
                        gridremarks = gridremarks & "|" & row.Cells(GGRIDREMARKS.Index).Value.ToString
                        bales = bales & "|" & row.Cells(GBALES.Index).Value.ToString
                        QTY = QTY & "|" & row.Cells(GQTY.Index).Value.ToString
                        RATE = RATE & "|" & row.Cells(grate.Index).Value.ToString
                        AMT = AMT & "|" & row.Cells(gamt.Index).Value.ToString

                        SONO = SONO & "|" & row.Cells(gsono.Index).Value.ToString
                        SOGRIDSRNO = SOGRIDSRNO & "|" & row.Cells(gsono.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(PIECETYPE)
            alParaval.Add(ITEMNAME)
            alParaval.Add(CUT)
            alParaval.Add(DESIGN)

            alParaval.Add(COLOR)
            alParaval.Add(gridremarks)
            alParaval.Add(bales)
            alParaval.Add(QTY)
            alParaval.Add(RATE)
            alParaval.Add(AMT)
            alParaval.Add(SONO)
            alParaval.Add(SOGRIDSRNO)

            Dim SRNO As String = ""
            Dim BALENO As String = ""
            Dim FBNO As String = ""
            Dim PSPIECETYPE As String = ""
            Dim PSMERCHANT As String = ""
            Dim PSCUT As String = ""
            Dim QUALITY As String = ""
            Dim PCS As String = ""
            Dim MTRS As String = ""
            Dim wt As String = ""
            Dim LRNO As String = ""
            Dim BILLNO As String = ""
            Dim PARTYNAME As String = ""
            Dim DONE As String = ""             'WHETHER GRN IS DONE FOR THIS LINE
            Dim TYPE As String = ""
            Dim GDNSONO As String = ""             'WHETHER GRN IS DONE FOR THIS LINE
            Dim GDNSOSRNO As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridps.Rows
                If row.Cells(0).Value <> Nothing Then
                    If SRNO = "" Then
                        SRNO = row.Cells(gPSsrno.Index).Value.ToString
                        BALENO = row.Cells(Gbaleno.Index).Value.ToString
                        FBNO = row.Cells(GFBNO.Index).Value.ToString
                        PSPIECETYPE = row.Cells(gpspiecetype.Index).Value.ToString
                        PSMERCHANT = row.Cells(gpsMerchant.Index).Value.ToString
                        PSCUT = row.Cells(gpscut.Index).Value.ToString
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        PCS = row.Cells(Gpcs.Index).Value.ToString
                        MTRS = row.Cells(Gmtrs.Index).Value.ToString
                        wt = row.Cells(GWT.Index).Value.ToString
                        If row.Cells(GLRNO.Index).Value <> Nothing Then LRNO = row.Cells(GLRNO.Index).Value Else LRNO = ""
                        BILLNO = row.Cells(GBILLNO.Index).Value.ToString
                        PARTYNAME = row.Cells(CMBPARTYNAME.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = "1"
                        Else
                            DONE = "0"
                        End If
                        TYPE = row.Cells(GTYPE.Index).Value.ToString

                        GDNSONO = row.Cells(GGDNSONO.Index).Value.ToString
                        GDNSOSRNO = row.Cells(GGDNSOSRNO.Index).Value.ToString

                    Else
                        SRNO = SRNO & "|" & row.Cells(gPSsrno.Index).Value.ToString
                        BALENO = BALENO & "|" & row.Cells(Gbaleno.Index).Value.ToString
                        FBNO = FBNO & "|" & row.Cells(GFBNO.Index).Value.ToString
                        PSPIECETYPE = PSPIECETYPE & "|" & row.Cells(gpspiecetype.Index).Value.ToString
                        PSMERCHANT = PSMERCHANT & "|" & row.Cells(gpsMerchant.Index).Value.ToString
                        PSCUT = PSCUT & "|" & row.Cells(gpscut.Index).Value.ToString
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        PCS = PCS & "|" & row.Cells(Gpcs.Index).Value.ToString
                        MTRS = MTRS & "|" & row.Cells(Gmtrs.Index).Value.ToString
                        wt = wt & "|" & row.Cells(GWT.Index).Value.ToString
                        If row.Cells(GLRNO.Index).Value <> Nothing Then LRNO = LRNO & "|" & row.Cells(GLRNO.Index).Value Else LRNO = LRNO & "|" & row.Cells(GLRNO.Index).Value
                        BILLNO = BILLNO & "|" & row.Cells(GBILLNO.Index).Value.ToString
                        PARTYNAME = PARTYNAME & "|" & row.Cells(CMBPARTYNAME.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If
                        TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value.ToString

                        GDNSONO = GDNSONO & "|" & row.Cells(GGDNSONO.Index).Value.ToString
                        GDNSOSRNO = GDNSOSRNO & "|" & row.Cells(GGDNSOSRNO.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(SRNO)
            alParaval.Add(BALENO)
            alParaval.Add(FBNO)
            alParaval.Add(PSPIECETYPE)
            alParaval.Add(PSMERCHANT)
            alParaval.Add(PSCUT)
            alParaval.Add(QUALITY)
            alParaval.Add(PCS)
            alParaval.Add(MTRS)
            alParaval.Add(wt)
            alParaval.Add(LRNO)
            alParaval.Add(BILLNO)
            alParaval.Add(PARTYNAME)
            alParaval.Add(DONE)
            alParaval.Add(TYPE)
            alParaval.Add(GDNSONO)
            alParaval.Add(GDNSOSRNO)


            Dim OSGRIDSRNO As String = ""
            Dim OSNAME As String = ""
            Dim OSITEMNAME As String = ""
            Dim OSBALES As String = ""
            Dim OSSONO As String = ""
            Dim OSSOSRNO As String = ""
            Dim OSTYPE As String = ""
            Dim OSGDNBALES As String = ""
            Dim OSRATE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDORDER.Rows
                If row.Cells(0).Value <> Nothing AndAlso Val(row.Cells(OGDNBALES.Index).Value) > 0 Then

                    If OSGRIDSRNO = "" Then
                        OSGRIDSRNO = Val(row.Cells(OSRNO.Index).Value)
                        OSNAME = row.Cells(OPARTYNAME.Index).Value.ToString
                        OSITEMNAME = row.Cells(OITEMNAME.Index).Value.ToString
                        OSBALES = Val(row.Cells(OBALES.Index).Value)
                        OSSONO = Val(row.Cells(OFROMNO.Index).Value)
                        OSSOSRNO = Val(row.Cells(OFROMSRNO.Index).Value)
                        OSTYPE = row.Cells(OFROMTYPE.Index).Value.ToString
                        OSGDNBALES = Val(row.Cells(OGDNBALES.Index).Value)
                        OSRATE = Val(row.Cells(ORATE.Index).Value)


                    Else

                        OSGRIDSRNO = OSGRIDSRNO & "|" & Val(row.Cells(OSRNO.Index).Value)
                        OSNAME = OSNAME & "|" & row.Cells(OPARTYNAME.Index).Value.ToString
                        OSITEMNAME = OSITEMNAME & "|" & row.Cells(OITEMNAME.Index).Value.ToString
                        OSBALES = OSBALES & "|" & Val(row.Cells(OBALES.Index).Value)
                        OSSONO = OSSONO & "|" & Val(row.Cells(OFROMNO.Index).Value)
                        OSSOSRNO = OSSOSRNO & "|" & Val(row.Cells(OFROMSRNO.Index).Value)
                        OSTYPE = OSTYPE & "|" & row.Cells(OFROMTYPE.Index).Value.ToString
                        OSGDNBALES = OSGDNBALES & "|" & Val(row.Cells(OGDNBALES.Index).Value)
                        OSRATE = OSRATE & "|" & Val(row.Cells(ORATE.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(OSGRIDSRNO)
            alParaval.Add(OSNAME)
            alParaval.Add(OSITEMNAME)
            alParaval.Add(OSBALES)
            alParaval.Add(OSSONO)
            alParaval.Add(OSSOSRNO)
            alParaval.Add(OSTYPE)
            alParaval.Add(OSGDNBALES)
            alParaval.Add(OSRATE)




            Dim objclsgdn As New ClsGDN()
            objclsgdn.alParaval = alParaval
            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DT As DataTable = objclsgdn.SAVE()
                MsgBox("Details Added")
                PRINTREPORT(DT.Rows(0).Item(0))

            ElseIf edit = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempgdnno)

                IntResult = objclsgdn.UPDATE()
                MsgBox("Details Updated")
                PRINTREPORT(tempgdnno)

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

    Private Sub gridgdn_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridgdn.CellClick
        Dim N As String = ""

        Dim tempindex As Integer
        Dim i As Integer


        For i = 0 To gridgdn.RowCount - 1
            With gridgdn.Rows(i).Cells(0)
                If .Value = True And gridgdn.Rows(i).ReadOnly = False Then N = gridgdn.Item(1, i).Value.ToString
            End With
        Next

        If e.RowIndex >= 0 Then
            With gridgdn.Rows(e.RowIndex).Cells(0)
                If .Value = True And .ReadOnly = False Then
                    .Value = False
                Else
                    If ((gridgdn.Item(1, e.RowIndex).Value.ToString = N) Or N = Nothing) Then
                        .Value = True
                        tempindex = e.RowIndex
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub toolPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            gridgdn.RowCount = 0
            tempgdnno = Val(txtgdnno.Text) - 1
            If tempgdnno > 0 Then
                edit = True
                GDN_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_CLICK(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            gridgdn.RowCount = 0
            tempgdnno = Val(txtgdnno.Text) + 1
            getmaxno()
            clear()
            If Val(txtgdnno.Text) - 1 >= tempgdnno Then
                edit = True
                GDN_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                gridgdn.RowCount = 0
                tempgdnno = Val(tstxtbillno.Text)
                If tempgdnno > 0 Then
                    edit = True
                    GDN_Load(sender, e)
                Else
                    clear()
                    edit = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal GDNNO As Integer)
        Try

            If MsgBox("Print Challan?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim OBJGDN As New GDNDESIGN
                If ClientName = "TULSI" Or ClientName = "SHREENATH" Then
                    If MsgBox("Print for Transport?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then OBJGDN.SHOWTRANS = True Else OBJGDN.SHOWTRANS = False
                End If
                OBJGDN.MdiParent = MDIMain
                OBJGDN.FORMULA = "{GDN.GDN_no}=" & Val(GDNNO) & " and {GDN.GDN_cmpid}=" & CmpId & " and {GDN.GDN_locationid}=" & Locationid & " and {GDN.GDN_yearid}=" & YearId
                OBJGDN.Show()
            End If


            If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Or ClientName = "MONOGRAM" Then
                If MsgBox("Print Challan For EWB?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim OBJGDN As New GDNDESIGN
                OBJGDN.FRMSTRING = "GDNEWB"
                OBJGDN.MdiParent = MDIMain
                OBJGDN.FORMULA = "{GDN.GDN_no}=" & Val(GDNNO) & " and {GDN.GDN_yearid}=" & YearId
                OBJGDN.Show()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If edit = True Then
                PRINTREPORT(tempgdnno)
                PRINTEWB()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objpodtls As New GDNDetails
            objpodtls.MdiParent = MDIMain
            objpodtls.Show()
            objpodtls.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANS_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBTRANS.Enter
        Try
            If CMBTRANS.Text.Trim = "" Then fillname(CMBTRANS, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBTRANS.Validating
        Try
            If CMBTRANS.Text.Trim <> "" Then namevalidate(CMBTRANS, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'", "Sundry Creditors")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Enter
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbname.Validated
        Try
            If cmbname.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(AGENTLEDGERS.Acc_cmpname,'') AS AGENTNAME, ISNULL(CITYMASTER.CITY_NAME,'') AS CITYNAME, ISNULL(STATEMASTER.state_remark, '') AS STATECODE ", "", " LEDGERS LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON LEDGERS.ACC_TRANSID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS AGENTLEDGERS ON LEDGERS.ACC_AGENTID = AGENTLEDGERS.Acc_id LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " AND LEDGERS.ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 AndAlso CMBAGENT.Text.Trim = "" Then CMBAGENT.Text = DT.Rows(0).Item("AGENTNAME")
                If DT.Rows.Count > 0 AndAlso CMBCITY.Text.Trim = "" Then CMBCITY.Text = DT.Rows(0).Item("CITYNAME")
                TXTSTATECODE.Text = DT.Rows(0).Item("STATECODE")
                If CMBSHIPTO.Text.Trim = "" Then CMBSHIPTO.Text = cmbname.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbname.Validating
        Try
            If cmbname.Text.Trim <> "" Then namevalidate(cmbname, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "Sundry Debtors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTJOB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTJOB.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Dim baleno As String = ""
            For Each row As Windows.Forms.DataGridViewRow In gridps.Rows
                If row.Cells(0).Value <> Nothing Then
                    If baleno = "" Then
                        baleno = row.Cells(Gbaleno.Index).Value.ToString
                    Else
                        baleno = baleno & "," & row.Cells(Gbaleno.Index).Value.ToString
                    End If
                End If
            Next
            If baleno <> "" Then
                baleno = "(" & baleno & ")"
            Else
                baleno = "(0)"
            End If

            selectpstable.Clear()
            Dim OBJSELECTPO As New SelectPs
            OBJSELECTPO.baleno = baleno
            OBJSELECTPO.FRMSTR = "JOB"
            OBJSELECTPO.ShowDialog()


            If selectpstable.Rows.Count > 0 Then
                chkchange.Checked = True
                'Dim a As String

                For i As Integer = 0 To selectpstable.Rows.Count - 1
                    gridps.Rows.Add(0, selectpstable.Rows(i).Item("BALENO"), selectpstable.Rows(i).Item("FBNO"), selectpstable.Rows(i).Item("piecetype"), selectpstable.Rows(i).Item("MERCHANT"), selectpstable.Rows(i).Item("cut"), selectpstable.Rows(i).Item("QUALITY"), Val(selectpstable.Rows(i).Item("PCS")), Format(Val(selectpstable.Rows(i).Item("MTRS")), "0.00"), Format(Val(selectpstable.Rows(i).Item("wt")), "0.00"), "", "", selectpstable.Rows(i).Item("NAME"), 0, selectpstable.Rows(i).Item("TYPE"), 0, 0)

                Next
                gridps.FirstDisplayedScrollingRowIndex = gridps.RowCount - 1
                getsrno(gridps)
                cmbname.Focus()
            End If
            total()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridps_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles gridps.CellValidating
        Try
            ''  CODE FOR NUMERIC CHECK ONLY
            Dim colNum As Integer = gridps.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GLRNO.Index
                    Dim TEMPBALENO As String = ""
                    For I As Integer = gridps.CurrentRow.Index + 1 To gridps.RowCount - 1
                        If I = gridps.CurrentRow.Index + 1 Then TEMPBALENO = gridps.Item(Gbaleno.Index, I - 1).Value
                        If gridps.Item(Gbaleno.Index, I).Value = TEMPBALENO Then gridps.Item(GLRNO.Index, I).Value = gridps.Item(GLRNO.Index, I - 1).EditedFormattedValue
                    Next

                Case CMBPARTYNAME.Index
                    If ClientName = "TULSI" Then
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable = OBJCMN.search(" LEDGERS.Acc_cmpname AS NAME, AGENTLEDGERS.Acc_cmpname AS AGENTNAME, TRANSLEDGERS.Acc_cmpname AS TRANSNAME", "", " LEDGERS INNER JOIN LEDGERS AS AGENTLEDGERS ON LEDGERS.Acc_AGENTID = AGENTLEDGERS.ACC_ID INNER JOIN LEDGERS AS TRANSLEDGERS ON LEDGERS.Acc_TRANSID = TRANSLEDGERS.ACC_ID ", " AND LEDGERS.Acc_yearid  = " & YearId & " AND LEDGERS.Acc_cmpname = '" & gridps.CurrentRow.Cells(CMBPARTYNAME.Index).EditedFormattedValue & "'")
                        If DT.Rows.Count > 0 Then
                            CMBTRANS.Text = DT.Rows(0).Item("TRANSNAME")
                            CMBAGENT.Text = DT.Rows(0).Item("AGENTNAME")
                        End If
                    End If

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridps_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridps.KeyDown

        Try
            If e.KeyCode = Keys.Delete And gridps.RowCount > 0 Then
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                gridps.Rows.RemoveAt(gridps.CurrentRow.Index)
                total()
                getsrno(gridps)
                total()
            ElseIf e.KeyCode = Keys.F9 And gridps.CurrentRow.Index > 0 Then
                If gridps.Item(GLRNO.Index, gridps.CurrentRow.Index - 1).Value <> "" Then gridps.Item(GLRNO.Index, gridps.CurrentRow.Index).Value = gridps.Item(GLRNO.Index, gridps.CurrentRow.Index - 1).Value

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub TXTBALENO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBALENO.Validating
        Try
            If TXTBALENO.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TOP 1 GDN_NO AS GDNNO ", "", " GDN_PSDESC", " AND GDN_CMPID = " & CmpId & " AND GDN_LOCATIONID = " & Locationid & " AND GDN_YEARID = " & YearId & " AND GDN_PSNO = '" & TXTBALENO.Text.Trim & "'")
                If DT.Rows.Count > 0 Then
                    tstxtbillno.Text = DT.Rows(0).Item(0)
                    Call tstxtbillno_Validating(sender, e)
                Else
                    MsgBox("Bale No not Present", MsgBoxStyle.Critical)
                    TXTBALENO.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTLRNO_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTLRNO.Validating
        Try
            If TXTLRNO.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" TOP 1 GDN_NO AS GDNNO ", "", " GDN_PSDESC", " AND GDN_YEARID = " & YearId & " AND GDN_LRNO = '" & TXTLRNO.Text.Trim & "'")
                If DT.Rows.Count > 0 Then
                    tstxtbillno.Text = DT.Rows(0).Item(0)
                    Call tstxtbillno_Validating(sender, e)
                Else
                    MsgBox("LR No not Present", MsgBoxStyle.Critical)
                    TXTLRNO.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If edit = True Then

                If lbllocked.Visible = True Then
                    MsgBox("Proforma Raised. Delete Proforma First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If TXTEWAYBILLNO.Text.Trim <> "" Then
                    MsgBox("Eway Bill Raised, Remove Eway Bill First", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                TEMPMSG = MsgBox("Delete CHALLAN?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(txtgdnno.Text.Trim)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(Userid)
                    alParaval.Add(YearId)

                    Dim Clsgrn As New ClsGDN()
                    Clsgrn.alParaval = alParaval
                    IntResult = Clsgrn.Delete()
                    MsgBox("CHALLAN Deleted")
                    clear()
                    edit = False
                End If
            Else
                MsgBox("CHALLAN CAN BE DELETE ONLY ON EDIT MODE")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub CMBAGENT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBAGENT.Enter
        Try
            If CMBAGENT.Text.Trim = "" Then fillname(CMBAGENT, False, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBAGENT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBAGENT.Validating
        Try
            If CMBAGENT.Text.Trim <> "" Then namevalidate(CMBAGENT, e, Me, txtadd, " AND GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'AGENT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GDN_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName <> "TULSI" And ClientName <> "SHREENATH" Then
                cmdselectOrder.Visible = False
                CMDSELECTJOB.Visible = False
                cmdselectps.Text = "Select PS"
                If ClientName = "DHANLAXMI" Then
                    cmbname.BackColor = Color.White
                    GFBNO.Visible = True
                    CMBPARTYNAME.Width = 250
                End If
                txtconsignee.Visible = False
                CMBSHIPTO.Visible = True
            Else
                LBLDELIVERY.Visible = False
                CMBCITY.Visible = False
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCITY_Enter(sender As Object, e As EventArgs) Handles CMBCITY.Enter
        Try
            If CMBCITY.Text.Trim = "" Then fillcity(CMBCITY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEWB_Click(sender As Object, e As EventArgs) Handles TOOLEWB.Click
        Try
            If edit = False Then Exit Sub
            GENERATEEWB()
            PRINTEWB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GENERATEEWB()
        Try
            If ALLOWEWAYBILL = False Then Exit Sub
            If cmbname.Text.Trim = "" Then Exit Sub

            If Val(TXTCGSTAMT.Text.Trim) = 0 And Val(TXTSGSTAMT.Text.Trim) = 0 And Val(TXTIGSTAMT.Text.Trim) = 0 Then Exit Sub

            If CMBFROMCITY.Text.Trim = "" Then
                MsgBox("Enter From City", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If CMBCITY.Text.Trim = "" Then
                MsgBox("Enter to City", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Generate E-Way Bill?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If TXTEWAYBILLNO.Text.Trim <> "" Then
                MsgBox("E-Way Bill No Already Generated", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'BEFORE GENERATING EWAY BILL WE NEED TO VALIDATE WHETHER ALL THE DATA ARE PRESENT OR NOT
            'IF DATA IS NOT PRESENT THEN VALIDATE
            'DATA TO BE CHECKED 
            '   1)CMPEWBUSER | CMPEWBPASS | CMPGSTIN | CMPPINCODE | CMPCITY | CMPSTATE | 
            '   2)PARTYGSTIN | PARTYCITY | PARTYPINCODE | PARTYSTATE | PARTYSTATECODE | PARTYKMS
            '   3)CGST OR SGST OR IGST (ALWAYS USE MTR IN QTYUNIT)
            If CMPEWBUSER = "" Or CMPEWBPASS = "" Or CMPGSTIN = "" Or CMPPINCODE = "" Or CMPCITYNAME = "" Or CMPSTATENAME = "" Then
                MsgBox(" Company Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim TEMPCMPADD1 As String = ""
            Dim TEMPCMPADD2 As String = ""
            Dim PARTYGSTIN As String = ""
            Dim PARTYPINCODE As String = ""
            Dim PARTYSTATECODE As String = ""
            Dim PARTYSTATENAME As String = ""
            Dim SHIPTOGSTIN As String = ""
            Dim SHIPTOSTATECODE As String = ""
            Dim SHIPTOSTATENAME As String = ""
            Dim PARTYKMS As Double = 0
            Dim PARTYADD1 As String = ""
            Dim PARTYADD2 As String = ""
            Dim TRANSGSTIN As String = ""

            Dim OBJCMN As New ClsCommon
            'CMP ADDRESS DETAILS
            Dim DT As DataTable = OBJCMN.search(" ISNULL(CMP_DISPATCHFROM, '') AS ADD1, ISNULL(CMP_ADD2,'') AS ADD2 ", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
            TEMPCMPADD1 = DT.Rows(0).Item("ADD1")
            TEMPCMPADD2 = DT.Rows(0).Item("ADD2")


            'PARTY GST DETAILS 
            DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN, ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2 ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & cmbname.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows(0).Item("GSTIN") = "" Or DT.Rows(0).Item("PINCODE") = "" Or DT.Rows(0).Item("STATENAME") = "" Or DT.Rows(0).Item("STATECODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
                MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                Exit Sub
            Else
                PARTYGSTIN = DT.Rows(0).Item("GSTIN")
                SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                PARTYSTATENAME = DT.Rows(0).Item("STATENAME")
                PARTYSTATECODE = DT.Rows(0).Item("STATECODE")
                SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                PARTYADD1 = DT.Rows(0).Item("ADD1")
                PARTYADD2 = DT.Rows(0).Item("ADD2")
            End If


            'FETCH PINCODE / KMS / ADD1 / ADD2 OF SHIPTO IF IT IS NOT SAME AS CMBNAME
            If CMBSHIPTO.Text.Trim <> "" AndAlso cmbname.Text.Trim <> CMBSHIPTO.Text.Trim Then
                DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN,  ISNULL(ACC_ZIPCODE,'') AS PINCODE, ISNULL(ACC_KMS,0) AS KMS, ISNULL(ACC_ADD1,'') AS ADD1, ISNULL(ACC_ADD2,'') AS ADD2, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(CAST(STATE_REMARK AS VARCHAR(20)),'') AS STATECODE ", "", " LEDGERS LEFT OUTER JOIN STATEMASTER ON ACC_STATEID = STATE_ID ", " AND ACC_CMPNAME = '" & CMBSHIPTO.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows(0).Item("PINCODE") = "" Or Val(DT.Rows(0).Item("KMS")) = 0 Then
                    MsgBox(" Party Details are not filled properly ", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    SHIPTOGSTIN = DT.Rows(0).Item("GSTIN")
                    PARTYPINCODE = DT.Rows(0).Item("PINCODE")
                    PARTYKMS = Val(DT.Rows(0).Item("KMS"))
                    PARTYADD1 = DT.Rows(0).Item("ADD1")
                    PARTYADD2 = DT.Rows(0).Item("ADD2")
                    SHIPTOSTATENAME = DT.Rows(0).Item("STATENAME")
                    SHIPTOSTATECODE = DT.Rows(0).Item("STATECODE")
                End If
            End If


            'TRANSPORT GSTING IS NOT MANDATORY
            'FOR LOCAL TRANSPORT THERE IS NO GSTIN
            'TRANSPORT GSTIN IF TRANSPORT IS PRESENT
            If CMBTRANS.Text.Trim <> "" Then
                DT = OBJCMN.search(" ISNULL(ACC_GSTIN, '') AS GSTIN ", "", " LEDGERS ", " AND ACC_CMPNAME = '" & CMBTRANS.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TRANSGSTIN = DT.Rows(0).Item("GSTIN")
                'FOR LOCAL TRANSPORT THERE IS NO GSTIN
                'If TRANSGSTIN = "" Then
                '    MsgBox("Enter Transport GSTIN", MsgBoxStyle.Critical)
                '    Exit Sub
                'End If
            End If



            'CHECKING COUNTER AND VALIDATE WHETHER EWAY BILL WILL BE ALLOWED OR NOT, FOR EACH EWAY BILL WE NEED TO 2 API COUNTS (1 FOR TOKEN AND ANOTHER FOR EWB)
            If CMPEWAYCOUNTER = 0 Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on +919987603607", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'GET USED EWAYCOUNTER
            Dim USEDEWAYCOUNTER As Integer = 0
            DT = OBJCMN.search("COUNT(COUNTERID) AS EWAYCOUNT", "", "EWAYENTRY", " AND CMPID =" & CmpId)
            If DT.Rows.Count > 0 Then USEDEWAYCOUNTER = Val(DT.Rows(0).Item("EWAYCOUNT"))

            'IF COUNTERS ARE FINISJED
            If CMPEWAYCOUNTER - USEDEWAYCOUNTER <= 0 Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on +919987603607", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF DATE HAS EXPIRED
            If Now.Date > EWAYEXPDATE Then
                MsgBox("EWay Bill Package has Expired, Kindly contact Nakoda Infotech on +919987603607", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'IF BALANCECOUNTERS ARE .10 THEN INTIMATE
            If CMPEWAYCOUNTER - USEDEWAYCOUNTER < Format((CMPEWAYCOUNTER * 0.1), "0") Then
                MsgBox("Only " & (CMPEWAYCOUNTER - USEDEWAYCOUNTER) & " API's Left, Kindly contact Nakoda Infotech for Renewal of EWB Package", MsgBoxStyle.Critical)
            End If


            'FOR GENERATING EWAY BILL WE NEED TO FIRST GENERATE THE TOKEN
            'THIS IS FOR SANDBOX TEST
            'Dim URL As New Uri("http://testapi.taxprogsp.co.in/ewaybillapi/dec/v1.03/authenticate?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&ewbpwd=" & CMPEWBPASS)
            Dim URL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/auth?action=ACCESSTOKEN&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&ewbpwd=" & CMPEWBPASS)

            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)

            REQUEST.Method = "GET"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()

            'IF STATUS IS NOT 1 THEN TOKEN IS NOT GENERATED
            Dim STARTPOS As Integer = 0
            Dim TEMPSTATUS As String = ""
            Dim TOKEN As String = ""
            Dim ENDPOS As Integer = 0

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("status") + Len("STATUS") + 3
            TEMPSTATUS = REQUESTEDTEXT.Substring(STARTPOS, 1)
            If TEMPSTATUS = "1" Then TEMPSTATUS = "SUCCESS" Else TEMPSTATUS = "FAILED"




            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("authtoken") + Len("AUTHTOKEN") + 3
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS) - 1
            TOKEN = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            'ADD DATA IN EWAYENTRY
            'DONT ADD IN EWAYENTRY, DONE BY GULKIT, IF FAILED THEN ADD
            'DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


            'ONCE WE REC THE TOKEN WE WILL CREATE EWAY BILL
            'IF STATUS IS FAILED THEN ERROR MESSAGE
            If TEMPSTATUS = "FAILED" Then
                MsgBox("Unable to create Eway Bill", MsgBoxStyle.Critical)
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(txtgdnno.Text.Trim) & ",'CHALLAN','" & TOKEN & "','','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End If



            'GENERATING EWAY BILL 
            'FOR SANBOX TEST
            'Dim FURL As New Uri("http://testapi.taxprogsp.co.in/ewaybillapi/dec/v1.03/ewayapi?action=GENEWAYBILL&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&authtoken=" & TOKEN)
            Dim FURL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/ewayapi?action=GENEWAYBILL&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&authtoken=" & TOKEN)
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/json"


                Dim j As String = ""

                j = "{"
                j = j & """supplyType"":""O"","
                j = j & """subSupplyType"":""4"","
                j = j & """subSupplyDesc"":"""","
                j = j & """docType"":""CHL"","

                j = j & """docNo"":""" & txtgdnno.Text.Trim & """" & ","
                j = j & """docDate"":""" & gdndate.Value.Date & """" & ","
                j = j & """fromGstin"":""" & CMPGSTIN & """" & ","
                j = j & """fromTrdName"":""" & CmpName & """" & ","
                j = j & """fromAddr1"":""" & TEMPCMPADD1 & """" & ","
                j = j & """fromAddr2"":""" & TEMPCMPADD2 & """" & ","
                j = j & """fromPlace"":""" & CMBFROMCITY.Text.Trim & """" & ","
                j = j & """fromPincode"":""" & CMPPINCODE & """" & ","
                j = j & """actFromStateCode"":""" & CMPSTATECODE & """" & ","
                j = j & """fromStateCode"":""" & CMPSTATECODE & """" & ","
                j = j & """toGstin"":""" & PARTYGSTIN & """" & ","
                j = j & """toTrdName"":""" & cmbname.Text.Trim & """" & ","
                j = j & """toAddr1"":""" & PARTYADD1 & """" & ","
                j = j & """toAddr2"":""" & PARTYADD2 & """" & ","
                j = j & """toPlace"":""" & CMBSHIPTO.Text.Trim & "-" & SHIPTOGSTIN & CMBCITY.Text.Trim & """" & ","
                j = j & """toPincode"":""" & PARTYPINCODE & """" & ","
                j = j & """actToStateCode"":""" & SHIPTOSTATECODE & """" & ","
                j = j & """toStateCode"":""" & PARTYSTATECODE & """" & ","

                j = j & """transactionType"":""2"","
                j = j & """dispatchFromGSTIN"":""" & CMPGSTIN & """" & ","
                j = j & """dispatchFromTradeName"":""" & CmpName & """" & ","
                j = j & """shipToGSTIN"":""" & SHIPTOGSTIN & """" & ","
                j = j & """shipToTradeName"":""" & CMBSHIPTO.Text.Trim & """" & ","
                j = j & """otherValue"":""0"","



                j = j & """totalValue"":""" & Val(TXTSUBTOTAL.Text.Trim) & """" & ","
                j = j & """cgstValue"":""" & Val(TXTCGSTAMT.Text.Trim) & """" & ","
                j = j & """sgstValue"":""" & Val(TXTSGSTAMT.Text.Trim) & """" & ","
                j = j & """igstValue"":""" & Val(TXTIGSTAMT.Text.Trim) & """" & ","

                j = j & """cessValue"":""" & "0" & """" & ","
                j = j & """cessNonAdvolValue"":""" & "0" & """" & ","
                j = j & """totInvValue"":""" & Val(txtgrandtotal.Text.Trim) & """" & ","
                j = j & """transporterId"":""" & TRANSGSTIN & """" & ","
                j = j & """transporterName"":""" & CMBTRANS.Text.Trim & """" & ","


                If TXTVEHICLENO.Text.Trim = "" Then
                    j = j & """transDocNo"":"""","
                    j = j & """transMode"":"""","
                    j = j & """transDistance"":""" & PARTYKMS & """" & ","
                    j = j & """transDocDate"":"""","
                    j = j & """vehicleNo"":"""","
                    j = j & """vehicleType"":"""","
                Else
                    j = j & """transDocNo"":"""","
                    j = j & """transMode"":""" & "1" & """" & ","
                    j = j & """transDistance"":""" & PARTYKMS & """" & ","
                    j = j & """transDocDate"":"""","
                    j = j & """vehicleNo"":""" & TXTVEHICLENO.Text.Trim & """" & ","
                    j = j & """vehicleType"":""" & "R" & """" & ","
                End If


                j = j & """itemList"":[{"

                j = j & """productName"":""" & "BLEACHED COTTON FABRICS" & """" & ","
                j = j & """productDesc"":""" & TXTPRODDESC.Text.Trim & """" & ","
                j = j & """hsnCode"":""" & CMBHSNCODE.Text.Trim & """" & ","
                j = j & """quantity"":""" & Val(LBLTOTALMTRS.Text.Trim) & """" & ","
                j = j & """qtyUnit"":""" & "MTR" & """" & ","
                j = j & """cgstRate"":""" & Val(TXTCGSTPER.Text.Trim) & """" & ","
                j = j & """sgstRate"":""" & Val(TXTSGSTPER.Text.Trim) & """" & ","
                j = j & """igstRate"":""" & Val(TXTIGSTPER.Text.Trim) & """" & ","
                j = j & """cessRate"":""" & "0" & """" & ","
                j = j & """cessNonAdvol"":""" & "0" & """" & ","
                j = j & """taxableAmount"":""" & Val(TXTSUBTOTAL.Text.Trim) & """"
                j = j & " }"


                j = j & " ]}"

                Dim stream As Stream = REQUEST.GetRequestStream()
                Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(j)
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()

            Catch ex As WebException
                'RESPONSE = ex.Response
                'MsgBox("Error While Generating EWB, Please check the Data Properly")
                ''ADD DATA IN EWAYENTRY
                'DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(TXTINVOICENO.Text.Trim) & ",'INVOICE','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


                RESPONSE = ex.Response
                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(txtgdnno.Text.Trim) & ",'CHALLAN','" & TOKEN & "','','FAILED', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                READER = New StreamReader(RESPONSE.GetResponseStream())
                REQUESTEDTEXT = READER.ReadToEnd()
                Dim ERRORMSG As String = ""
                STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("message") + Len("message") + 5
                ENDPOS = REQUESTEDTEXT.ToLower.IndexOf("}", STARTPOS) - 2
                ERRORMSG = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)
                MsgBox("Error While Generating EWB, " & ERRORMSG)

                Exit Sub
            End Try

            READER = New StreamReader(RESPONSE.GetResponseStream())
            REQUESTEDTEXT = READER.ReadToEnd()




            Dim EWBNO As String = ""

            STARTPOS = REQUESTEDTEXT.ToLower.IndexOf("ewayBillNo") + Len("ewayBillNo") + 5
            ENDPOS = REQUESTEDTEXT.ToLower.IndexOf(",", STARTPOS)
            EWBNO = REQUESTEDTEXT.Substring(STARTPOS, ENDPOS - STARTPOS)

            TXTEWAYBILLNO.Text = EWBNO

            'WE NEED TO UPDATE THIS EWBNO IN DATABASE ALSO
            DT = OBJCMN.Execute_Any_String("UPDATE GDN SET GDN_EWAYBILLNO = '" & TXTEWAYBILLNO.Text.Trim & "' WHERE GDN_NO = " & Val(txtgdnno.Text.Trim) & " AND GDN_YEARID = " & YearId, "", "")

            'ADD DATA IN EWAYENTRY
            DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(txtgdnno.Text.Trim) & ",'CHALLAN','" & TOKEN & "','" & EWBNO & "','" & TEMPSTATUS & "', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTEWB()
        Try

            If PRINTEWAYBILL = False Then Exit Sub
            If edit = False Then Exit Sub
            If TXTEWAYBILLNO.Text.Trim = "" Then Exit Sub


            If MsgBox("Print EWB?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim TOKENNO As String = ""
            Dim EWBNO As String = ""

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" ISNULL(TOKENNO, '') AS TOKENNO, ISNULL(EWBNO, '') AS EWBNO ", "", " EWAYENTRY ", " AND EWBNO = '" & TXTEWAYBILLNO.Text.Trim & "' And YearId = " & YearId)
            If DT.Rows.Count = 0 Then Exit Sub
            TOKENNO = DT.Rows(0).Item("TOKENNO")
            EWBNO = DT.Rows(0).Item("EWBNO")

            'Dim URL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/authenticate?action=ACCESSTOKEN&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&username=" & CMPEWBUSER & "&ewbpwd=" & CMPEWBPASS)
            Dim URL As New Uri("https://einvapi.charteredinfo.com/v1.03/dec/ewayapi?action=GetEwayBill&aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN & "&authtoken=" & TOKENNO & "&ewbNo=" & EWBNO)


            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            Dim REQUEST As WebRequest
            Dim RESPONSE As WebResponse
            REQUEST = WebRequest.CreateDefault(URL)
            REQUEST.Method = "Get"
            Try
                RESPONSE = REQUEST.GetResponse()
            Catch ex As WebException
                RESPONSE = ex.Response
            End Try
            Dim READER As StreamReader = New StreamReader(RESPONSE.GetResponseStream())
            Dim REQUESTEDTEXT As String = READER.ReadToEnd()
            Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(REQUESTEDTEXT)

            Dim FURL As New Uri("https://einvapi.charteredinfo.com/aspapi/v1.0/printewb?aspid=1602611918&password=infosys123&gstin=" & CMPGSTIN)
            REQUEST = WebRequest.CreateDefault(FURL)
            REQUEST.Method = "POST"
            Try
                REQUEST.ContentType = "application/x-www-form-urlencoded"
                REQUEST.ContentLength = buffer.Length

                Dim stream As Stream = REQUEST.GetRequestStream()
                stream.Write(buffer, 0, buffer.Length)

                'POST request absenden
                RESPONSE = REQUEST.GetResponse()
                Dim STRREADER As Stream = RESPONSE.GetResponseStream()
                Dim BINREADER As New BinaryReader(STRREADER)
                Dim BFFER As Byte() = BINREADER.ReadBytes(CInt(RESPONSE.ContentLength))
                File.WriteAllBytes(Application.StartupPath & "\EWB_" & TXTEWAYBILLNO.Text.Trim & ".pdf", BFFER)
                Process.Start(Application.StartupPath & "\EWB_" & TXTEWAYBILLNO.Text.Trim & ".pdf")

                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(txtgdnno.Text.Trim) & ",'CHALLAN','" & TOKENNO & "','" & EWBNO & "','PRINT SUCCESS1', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(txtgdnno.Text.Trim) & ",'CHALLAN','" & TOKENNO & "','" & EWBNO & "','PRINT SUCCESS2', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")

            Catch ex As WebException
                RESPONSE = ex.Response
                MsgBox("Error While Printing EWB, Please check the Data Properly")
                'ADD DATA IN EWAYENTRY
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(txtgdnno.Text.Trim) & ",'CHALLAN','" & TOKENNO & "','" & EWBNO & "','PRINT FAILED1', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                DT = OBJCMN.Execute_Any_String("INSERT INTO EWAYENTRY VALUES (" & Val(txtgdnno.Text.Trim) & ",'CHALLAN','" & TOKENNO & "','" & EWBNO & "','PRINT FAILED2', GETDATE(), " & CmpId & "," & Userid & "," & YearId & ")", "", "")
                Exit Sub
            End Try

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBCITY.Validating
        Try
            If CMBCITY.Text.Trim <> "" Then CITYVALIDATE(CMBCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBLOCALTRANS_Enter(sender As Object, e As EventArgs) Handles CMBLOCALTRANS.Enter
        Try
            If CMBLOCALTRANS.Text.Trim = "" Then fillname(CMBLOCALTRANS, edit, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBLOCALTRANS_Validating(sender As Object, e As CancelEventArgs) Handles CMBLOCALTRANS.Validating
        Try
            If CMBLOCALTRANS.Text.Trim <> "" Then namevalidate(CMBLOCALTRANS, e, Me, TXTTRANSADD, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'", "Sundry Creditors")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_Enter(sender As Object, e As EventArgs) Handles CMBFROMCITY.Enter
        Try
            If CMBFROMCITY.Text.Trim = "" Then fillcity(CMBFROMCITY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSUBTOTAL_Validated(sender As Object, e As EventArgs) Handles TXTSUBTOTAL.Validated
        Try
            GETHSNCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFROMCITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBFROMCITY.Validating
        Try
            If CMBFROMCITY.Text.Trim <> "" Then CITYVALIDATE(CMBFROMCITY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHIPTO_Enter(sender As Object, e As EventArgs) Handles CMBSHIPTO.Enter
        Try
            If CMBSHIPTO.Text.Trim = "" Then fillname(CMBSHIPTO, edit, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSO_Click(sender As Object, e As EventArgs) Handles CMDSELECTSO.Click
        Try

            Dim DTSO As New DataTable
            Dim OBJSELECTSO As New SelectSO
            OBJSELECTSO.ShowDialog()
            DTSO = OBJSELECTSO.DT

            If DTSO.Rows.Count > 0 Then

                ''  GETTING DISTINCT CHALLAN NO IN TEXTBOX
                Dim DV As DataView = DTSO.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "SONO")
                For Each DTR As DataRow In NEWDT.Rows
                    If TXTMULTISONO.Text.Trim = "" Then
                        TXTMULTISONO.Text = DTR("SONO").ToString
                    Else
                        TXTMULTISONO.Text = TXTMULTISONO.Text & "," & DTR("SONO").ToString
                    End If
                Next

                'CMBAGENT.Text = DTSO.Rows(0).Item("AGENTNAME")
                If DTSO.Rows(0).Item("TRANSNAME") <> "" And ClientName <> "TULSI" Then CMBTRANS.Text = DTSO.Rows(0).Item("TRANSNAME")
                CMBSHIPTO.Text = DTSO.Rows(0).Item("SHIPTO")


                'BEFORE ADDING THE ROW IN ORDERDER GRID CHECK WHETHER SAME ORDERNO AN SRNO IS PRESENT IN GRID OR NOT
                For Each DTROW As DataRow In DTSO.Rows
                    For Each ROW As DataGridViewRow In GRIDORDER.Rows
                        If Val(ROW.Cells(OFROMNO.Index).Value) = Val(DTROW("SONO")) And Val(ROW.Cells(OFROMSRNO.Index).Value) = Val(DTROW("GRIDSRNO")) And ROW.Cells(OFROMTYPE.Index).Value = DTROW("TYPE") Then GoTo NEXTLINE
                    Next
                    GRIDORDER.Rows.Add(0, DTROW("NAME"), DTROW("ITEMNAME"), Val(DTROW("BALES")), Val(DTROW("SONO")), Val(DTROW("GRIDSRNO")), DTROW("TYPE"), 0, Val(DTROW("RATE")))
NEXTLINE:
                Next
                getsrno(GRIDORDER)

            End If

            cmdselectps.Enabled = True
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHIPTO_Validating(sender As Object, e As CancelEventArgs) Handles CMBSHIPTO.Validating
        Try
            If CMBSHIPTO.Text.Trim <> "" Then namevalidate(CMBSHIPTO, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "Sundry Debtors")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSUBTOTAL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSUBTOTAL.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBSHIPTO_Validated(sender As Object, e As EventArgs) Handles CMBSHIPTO.Validated
        Try
            If CMBSHIPTO.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(CITYMASTER.CITY_NAME,'') AS CITYNAME ", "", " LEDGERS LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID ", " AND LEDGERS.ACC_CMPNAME = '" & CMBSHIPTO.Text.Trim & "' AND LEDGERS.ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then CMBCITY.Text = DT.Rows(0).Item("CITYNAME")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridps_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridps.CellClick
        'Dim N As String = ""

        'Dim tempindex As Integer
        'Dim i As Integer


        'For i = 0 To gridps.RowCount - 1
        '    With gridps.Rows(i).Cells(0)
        '        If .Value = True And gridps.Rows(i).ReadOnly = False Then N = gridps.Item(1, i).Value.ToString
        '    End With
        ''Next

        'If e.RowIndex >= 0 Then
        '    With gridps.Rows(e.RowIndex).Cells(0)
        '        If .Value = True And .ReadOnly = False Then
        '            .Value = False
        '        Else
        '            If ((gridps.Item(1, e.RowIndex).Value.ToString = N) Or N = Nothing) Then
        '                '.Value = True
        '                tempindex = e.RowIndex
        '            End If
        '        End If
        '    End With
        'End If
    End Sub
End Class