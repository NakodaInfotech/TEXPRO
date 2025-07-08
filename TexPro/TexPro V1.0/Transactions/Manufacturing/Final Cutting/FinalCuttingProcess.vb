

Imports System.ComponentModel
Imports BL

Public Class FinalCuttingProcess

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Dim IntResult As Integer
    Dim gridDoubleClick As Boolean
    Public edit As Boolean          'used for editing
    Public TEMPFCPNO As Integer     'used for poation no while editing
    Public Shared SELECTMFG As New DataTable

    Dim congridDoubleClick As Boolean
    Dim temprow As Integer

    Private Sub TXTMTRS_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTMTRS.Validated
        Try
            If CMBPIECETYPE.Text.Trim <> "" And CMBMERCHANT.Text.Trim <> "" And Val(TXTMTRS.Text) > 0 Then
                fillcongrid()
                TOTAL()
                TXTSAREE.Clear()
                TXTMTRS.Clear()
                txtconsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTMFG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTMFG.Click
        Try

            If (edit = True And USEREDIT = False And USERVIEW = False) Or (edit = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If


            If cmbfrom.Text.Trim = "" Then
                MsgBox("Select Process First", MsgBoxStyle.Critical)
                cmbfrom.Focus()
                Exit Sub
            End If
            SELECTMFG.Clear()
            Dim OBJSELECTMFG As New selectMfg2
            OBJSELECTMFG.PROCESSNAME = cmbfrom.Text.Trim
            OBJSELECTMFG.GODOWN = CMBGODOWN.Text.Trim
            OBJSELECTMFG.Fcutting = True
            OBJSELECTMFG.ShowDialog()


            Dim i As Integer = 0
            If SELECTMFG.Rows.Count > 0 Then
                cmbfrom.Enabled = False
                CMDSELECTMFG.Enabled = False
                chkchange.Checked = True
                'cmbdesignno.Items.Clear()
                If edit = False Then GRIDFCP.RowCount = 0
                Dim design As String = ""
                For i = 0 To SELECTMFG.Rows.Count - 1

                    txtMerchant.Text = SELECTMFG.Rows(i).Item("MERCHANT")
                    CMBMERCHANT.Text = SELECTMFG.Rows(i).Item("MERCHANT")


                    'FETCH CONTRACTOR NAME ONLY FOR SHREENATH, FROM GRN_VIEW (WE HAVE FETCHED NAME IN CONTRACTOR COLUMN)
                    If ClientName = "SHREENATH" Then TXTNAME.Text = SELECTMFG.Rows(i).Item("CONTRACTOR") Else TXTNAME.Text = ""

                    'FETCH CONTRACTOR NAME ONLY FOR TULSI, FROM PACKINGSLIPVIEW (WE HAVE FETCHED NAME IN CONTRACTOR COLUMN ONLY FOR JOBIN)
                    If ClientName = "TULSI" And cmbfrom.Text = "JOB IN" Then TXTNAME.Text = SELECTMFG.Rows(i).Item("CONTRACTOR")


                    txtjobno.Text = SELECTMFG.Rows(i).Item("JOBNO")
                    txttype.Text = SELECTMFG.Rows(i).Item("TYPE")

                    'GET CHALLANNO AND CHALLANDATE FROM GRN
                    If ClientName = "SHREENATH" And txttype.Text = "G.R.N" Then
                        Dim OBJCMN As New ClsCommon
                        Dim DT As DataTable = OBJCMN.search("GRN_CHALLANNO AS CHALLANNO, GRN_CHALLANDT AS CHALLANDATE", "", " GRN ", " AND GRN_NO = " & Val(txtjobno.Text.Trim) & " AND GRN_YEARID = " & YearId)
                        If DT.Rows.Count > 0 Then
                            TXTINVNO.Text = DT.Rows(0).Item("CHALLANNO")
                            INVDATE.Text = Format(Convert.ToDateTime(DT.Rows(0).Item("CHALLANDATE")).Date, "dd/MM/yyyy")
                        End If
                    End If


                    GRIDFCP.Rows.Add(0, SELECTMFG.Rows(i).Item("QUALITY").ToString, SELECTMFG.Rows(i).Item("cut"), SELECTMFG.Rows(i).Item("DESIGN").ToString, SELECTMFG.Rows(i).Item("color"), Format(Val(SELECTMFG.Rows(i).Item("Saree")), "0.00"), Format(Val(SELECTMFG.Rows(i).Item("MTRS")), "0.00"), SELECTMFG.Rows(i).Item("cpno"), SELECTMFG.Rows(i).Item("gridsrno"), SELECTMFG.Rows(i).Item("MFGno"), SELECTMFG.Rows(i).Item("MFGsrno"), SELECTMFG.Rows(i).Item("LOTNO"), SELECTMFG.Rows(i).Item("LOTSRNO"))
                    If SELECTMFG.Rows(i).Item("DESIGN").ToString <> design Then
                        'cmbdesignno.Items.Add(SELECTMFG.Rows(i).Item("DESIGN").ToString)
                        design = SELECTMFG.Rows(i).Item("DESIGN").ToString
                    End If
                Next

                getsrno(GRIDFCP)

                TOTAL()
                txtconsrno.Focus()
            End If
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

    Sub TOTAL()
        Try
            LBLTOTALMTRS.Text = 0.0
            LBLTOTALSAREE.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDFCP.Rows
                If ROW.Cells(gsrno.Index).Value <> Nothing Then
                    LBLTOTALSAREE.Text = Format(Val(LBLTOTALSAREE.Text) + Val(ROW.Cells(Ginsaree.Index).EditedFormattedValue), "0.00")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GINMTRS.Index).EditedFormattedValue), "0.00")
                End If
            Next
            LBLTOTALCUTMTRS.Text = 0.0
            LBLTOTALCUTPCS.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDCONSUME.Rows
                If ROW.Cells(gconsrno.Index).Value <> Nothing Then
                    LBLTOTALCUTPCS.Text = Format(Val(LBLTOTALCUTPCS.Text) + Val(ROW.Cells(gsaree.Index).EditedFormattedValue), "0.00")
                    LBLTOTALCUTMTRS.Text = Format(Val(LBLTOTALCUTMTRS.Text) + Val(ROW.Cells(gMtrs.Index).EditedFormattedValue), "0.00")
                End If
            Next


            If Val(TXTGREYMTRS.Text.Trim) > 0 And Val(LBLTOTALMTRS.Text.Trim) > 0 Then TXTSHORTAGEPER.Text = Format((Val(TXTGREYMTRS.Text.Trim) - Val(LBLTOTALMTRS.Text.Trim)) / Val(TXTGREYMTRS.Text.Trim) * 100, "0.00")
            TXTDIFFMTRS.Text = Format(Val(LBLTOTALCUTMTRS.Text.Trim) - Val(LBLTOTALMTRS.Text.Trim), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTALCONSUMPTION()
        Try
            LBLACTCONSUMEDQTY.Text = 0.0
            LBLACTCONSUMEDAMT.Text = 0.0
            LBLDEFCONSUMEDAMT.Text = 0.0
            LBLDEFCONSUMEDAMT.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDCONSUMPTION.Rows
                If ROW.Cells(GCONSUMEDSRNO.Index).Value <> Nothing Then
                    LBLACTCONSUMEDQTY.Text = Format(Val(LBLACTCONSUMEDQTY.Text) + Val(ROW.Cells(GactQty.Index).EditedFormattedValue), "0.00")
                    LBLACTCONSUMEDAMT.Text = Format(Val(LBLACTCONSUMEDAMT.Text) + Val(ROW.Cells(gActRate.Index).EditedFormattedValue), "0.00")
                    LBLDEFCONSUMEDQTY.Text = Format(Val(LBLDEFCONSUMEDQTY.Text) + Val(ROW.Cells(GdefQTY.Index).EditedFormattedValue), "0.00")
                    LBLDEFCONSUMEDAMT.Text = Format(Val(LBLDEFCONSUMEDAMT.Text) + Val(ROW.Cells(GdefRATE.Index).EditedFormattedValue), "0.00")
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try
            If cmbfrom.Text.Trim = "" Then FILLPROCESS(cmbfrom, " AND (PROCESSMASTER.PROCESS_TYPE='JOB IN' OR PROCESSMASTER.PROCESS_TYPE='MFG2' OR PROCESSMASTER.PROCESS_TYPE='LOOSE STOCK')", edit)
            If cmbunit.Text.Trim = "" Then fillunit(cmbunit)
            If cmbcontractor.Text.Trim = "" Then fillCONTRACTOR(cmbcontractor)
            If cmbsupervisior.Text.Trim = "" Then fillSUPERVISIOR(cmbsupervisior)
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
            If cmbdesignation.Text.Trim = "" Then filldesignation(cmbdesignation)
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'ITEM'")
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillDESIGN(cmbdesignno)
            FILLGODOWN(CMBGODOWN, edit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()

        EP.Clear()

        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""
        tstxtbillno.Clear()
        LBLTOTALSAREE.Text = 0.0
        LBLTOTALMTRS.Text = 0.0
        LBLACTCONSUMEDAMT.Text = 0
        LBLACTCONSUMEDQTY.Text = 0.0
        LBLDEFCONSUMEDAMT.Text = 0.0
        LBLDEFCONSUMEDQTY.Text = 0.0
        txtsrno.Clear()
        CMBPIECETYPE.Text = ""
        txtdefqty.Clear()
        txtactqty.Clear()
        cmbunit.Text = ""
        txtdefrate.Clear()
        TXTACTRATE.Clear()
        GRIDCONSUMPTION.RowCount = 0
        GRIDFCP.RowCount = 0
        GRIDCONSUME.RowCount = 0
        GRIDCONSUMPTION.RowCount = 0
        txtjobno.Clear()
        txtMerchant.Clear()
        txttype.Clear()
        TXTREFNO.Clear()
        TXTNAME.Clear()
        TXTINVNO.Clear()
        INVDATE.Clear()

        cmbfrom.Enabled = True
        CMDSELECTMFG.Enabled = True
        LBLTOTALCUTMTRS.Text = 0
        LBLTOTALCUTPCS.Text = 0
        TXTCUT.Clear()



        TXTFCPNO.Clear()
        FCPdate.Value = Mydate
        cmbfrom.Text = ""
        cmbcontractor.Text = ""
        cmbsupervisior.Text = ""
        txtremarks.Clear()

        lbllocked.Visible = False
        PBlock.Visible = False

        GRIDFCP.RowCount = 0
        CMBPIECETYPE.Text = ""
        CMBMERCHANT.Text = ""

        cmbfrom.Enabled = True
        gridDoubleClick = False
        congridDoubleClick = False
        getmaxno()
        txtsrno.Text = 1

        TXTGREYMTRS.Clear()
        TXTSHORTAGEPER.Clear()
        TXTDIFFMTRS.Clear()


        GRIDFCP.ClearSelection()
        GRIDCONSUME.ClearSelection()

    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(FCP_NO),0) + 1 ", " FINALCUTTINGPROCESS", " AND FCP_cmpid=" & CmpId & " and FCP_locationid=" & Locationid & " and FCP_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTFCPNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub FinalCuttingProcess_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then
                Call CMDSELECTMFG_Click(sender, e)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FinalCuttingProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'MFG'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            fillcmb()
            clear()

            If edit = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCHECKING As New ClsFinalCUTTINGPROCESS()
                Dim ALPARAVAL As New ArrayList

                Dim dttable As New DataTable

                ALPARAVAL.Add(TEMPFCPNO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJCHECKING.alParaval = ALPARAVAL
                dttable = OBJCHECKING.selectFCP()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTFCPNO.Text = TEMPFCPNO
                        FCPdate.Value = Format(Convert.ToDateTime(dr("FCPDATE")).Date, "dd/MM/yyyy")
                        cmbfrom.Text = Convert.ToString(dr("PROCESSNAME").ToString)

                        cmbsupervisior.Text = Convert.ToString(dr("SUPERVISIOR").ToString)
                        cmbcontractor.Text = Convert.ToString(dr("CONTRACTOR").ToString)

                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)
                        txtjobno.Text = dr("JOBNO").ToString
                        txttype.Text = dr("TYPE").ToString
                        txtMerchant.Text = dr("merchant").ToString
                        CMBMERCHANT.Text = dr("merchant").ToString
                        CMBGODOWN.Text = dr("GODOWN").ToString
                        TXTREFNO.Text = dr("REFNO").ToString
                        TXTNAME.Text = dr("NAME").ToString
                        TXTINVNO.Text = dr("INVOICENO").ToString
                        INVDATE.Text = dr("INVDATE").ToString

                        TXTGREYMTRS.Text = Val(dr("GREYMTRS"))
                        TXTSHORTAGEPER.Text = Val(dr("SHORTAGEPER"))
                        TXTDIFFMTRS.Text = Val(dr("DIFFMTRS"))

                        'Item Grid
                        GRIDFCP.Rows.Add(dr("GRIDSRNO").ToString, Convert.ToString(dr("QUALITY").ToString), Convert.ToString(dr("INCUT").ToString), Convert.ToString(dr("DESIGNNO").ToString), dr("COLOR").ToString, Format(dr("INSAREE"), "0.00"), Format(dr("INMTRS"), "0.00"), dr("CpNO"), dr("CPSRNO"), dr("MFGNO"), dr("MFGSRNO"), dr("LOTNO"), dr("LOTSRNO"))

                    Next

                    cmbfrom.Enabled = False

                End If

                Dim OBJCMN As New ClsCommon
                dttable = OBJCMN.search("  FINALCUTTINGPROCESS_CONSUMED.FCP_SRNO AS GRIDSRNO, ITEMMASTER.item_name AS ITEMNAME, FINALCUTTINGPROCESS_CONSUMED.FCP_defQTY AS defQTY, FINALCUTTINGPROCESS_CONSUMED.FCP_ACTQTY AS actQTY, UNITMASTER.unit_abbr AS UNIT, FINALCUTTINGPROCESS_CONSUMED.FCP_DEFRATE AS DEFRATE, FINALCUTTINGPROCESS_CONSUMED.FCP_ACTRATE AS ACTRATE", "", " FINALCUTTINGPROCESS_CONSUMED INNER JOIN ITEMMASTER ON FINALCUTTINGPROCESS_CONSUMED.FCP_ITEMID = ITEMMASTER.item_id AND FINALCUTTINGPROCESS_CONSUMED.FCP_CMPID = ITEMMASTER.item_cmpid AND FINALCUTTINGPROCESS_CONSUMED.FCP_LOCATIONID = ITEMMASTER.item_locationid AND FINALCUTTINGPROCESS_CONSUMED.FCP_YEARID = ITEMMASTER.item_yearid INNER JOIN UNITMASTER ON FINALCUTTINGPROCESS_CONSUMED.FCP_UNITID = UNITMASTER.unit_id AND FINALCUTTINGPROCESS_CONSUMED.FCP_CMPID = UNITMASTER.unit_cmpid AND FINALCUTTINGPROCESS_CONSUMED.FCP_LOCATIONID = UNITMASTER.unit_locationid AND FINALCUTTINGPROCESS_CONSUMED.FCP_YEARID = UNITMASTER.unit_yearid", " AND FINALCUTTINGPROCESS_CONSUMED.FCP_NO = " & TEMPFCPNO & " AND FINALCUTTINGPROCESS_CONSUMED.FCP_CMPID = " & CmpId & " AND FINALCUTTINGPROCESS_CONSUMED.FCP_LOCATIONID  = " & Locationid & " AND FINALCUTTINGPROCESS_CONSUMED.FCP_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    For Each DR As DataRow In dttable.Rows
                        GRIDCONSUMPTION.Rows.Add(DR("GRIDSRNO").ToString, DR("ITEMNAME"), Format(DR("DEFQTY"), "0.00"), Format(DR("ACTQTY"), "0.00"), DR("UNIT"), Format(DR("DEFRATE"), "0.00"), Format(DR("ACTRATE"), "0.00"))
                    Next
                End If

                dttable = OBJCMN.search("   FINALCUTTINGPROCESS_PCSDESC.FCP_CONSRNO AS GRIDSRNO, PIECETYPEMASTER.PIECETYPE_name AS PIECETYPE, ISNULL(ITEMMASTER.ITEM_NAME,'') AS MERCHANT, FINALCUTTINGPROCESS_PCSDESC.FCP_CUT AS CUT, DESIGNRECIPE.DESIGN_NO AS DESIGNNO, FINALCUTTINGPROCESS_PCSDESC.FCP_SAREE AS SAREE, FINALCUTTINGPROCESS_PCSDESC.FCP_MTRS AS MTRS,FINALCUTTINGPROCESS_PCSDESC.FCP_OUTSAREE AS OUTSAREE, FINALCUTTINGPROCESS_PCSDESC.FCP_GRIDDONE AS GRIDDONE ", "", " FINALCUTTINGPROCESS_PCSDESC INNER JOIN PIECETYPEMASTER ON FINALCUTTINGPROCESS_PCSDESC.FCP_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN DESIGNRECIPE ON FINALCUTTINGPROCESS_PCSDESC.FCP_DESIGNID = DESIGNRECIPE.DESIGN_ID LEFT OUTER JOIN ITEMMASTER ON FINALCUTTINGPROCESS_PCSDESC.FCP_ITEMID = ITEMMASTER.ITEM_ID", " AND FINALCUTTINGPROCESS_pcsdesc.FCP_NO = " & TEMPFCPNO & " AND FINALCUTTINGPROCESS_pcsdesc.FCP_YEARID = " & YearId & " ORDER BY FINALCUTTINGPROCESS_PCSDESC.FCP_CONSRNO ")
                If dttable.Rows.Count > 0 Then
                    For Each DR As DataRow In dttable.Rows
                        GRIDCONSUME.Rows.Add(DR("GRIDSRNO").ToString, DR("PIECETYPE"), DR("MERCHANT"), Format(DR("CUT"), "0.00"), DR("DESIGNNO").ToString, DR("SAREE"), Format(DR("MTRS"), "0.00"), DR("OUTSAREE"), DR("GRIDDONE"))
                        If DR("OUTSAREE") > 0 Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                            GRIDCONSUME.Rows(GRIDCONSUME.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        End If
                    Next

                End If
                TOTAL()

                chkchange.CheckState = CheckState.Checked
            End If

            If GRIDCONSUMPTION.RowCount > 0 Then
                txtsrno.Text = Val(GRIDCONSUMPTION.Rows(GRIDCONSUMPTION.RowCount - 1).Cells(GCONSUMEDSRNO.Index).Value) + 1
            Else
                txtsrno.Text = 1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        clear()
        edit = False
        cmbfrom.Focus()
    End Sub

    Private Sub gridconsume_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDCONSUME.CellDoubleClick
        Try
            If e.RowIndex >= 0 And GRIDCONSUME.Item("GPIECETYPE", e.RowIndex).Value <> Nothing Then

                If ClientName <> "SHREENATH" And GRIDCONSUME.Item("GOUTSAREE", e.RowIndex).Value > 0 Then Exit Sub

                congridDoubleClick = True
                temprow = e.RowIndex
                txtconsrno.Text = GRIDCONSUME.Item("Gconsrno", e.RowIndex).Value
                CMBPIECETYPE.Text = GRIDCONSUME.Item("GPIECETYPE", e.RowIndex).Value
                CMBMERCHANT.Text = GRIDCONSUME.Item("GMERCHANT", e.RowIndex).Value
                TXTCUT.Text = GRIDCONSUME.Item("Gcut", e.RowIndex).Value
                cmbdesignno.Text = GRIDCONSUME.Item("Gdesignno", e.RowIndex).Value
                TXTSAREE.Text = GRIDCONSUME.Item("GSAREE", e.RowIndex).Value
                TXTMTRS.Text = GRIDCONSUME.Item("GMTRS", e.RowIndex).Value

                CMBPIECETYPE.Focus()
            Else
                MsgBox("ROW CANNOT BE EDITTED")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridconsume_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDCONSUME.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Convert.ToBoolean(GRIDCONSUME.Rows(GRIDCONSUME.CurrentRow.Index).Cells(GDONE.Index).Value) <> True Then

                GRIDCONSUME.Rows.RemoveAt(GRIDCONSUME.CurrentRow.Index)
                getsrno(GRIDCONSUME)
                TOTAL()
            End If
        End If
    End Sub

    Private Sub GRIDFCP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDFCP.KeyDown
        If e.KeyCode = Keys.Delete Then

            GRIDFCP.Rows.RemoveAt(GRIDFCP.CurrentRow.Index)
            GRIDCONSUME.RowCount = 0
            TOTAL()
            getsrno(GRIDFCP)
        End If
    End Sub

    Sub fillcongrid()

        If congridDoubleClick = False Then

            'DONE BY GULKIT ALLOW TO EXCEED EXTRA SAREE
            'Dim outsaree As Integer
            'outsaree = Val(TXTSAREE.Text)
            'For Each row As DataGridViewRow In gridconsume.Rows
            '    outsaree = outsaree + row.Cells(gsaree.Index).Value
            'Next
            'If outsaree > LBLTOTALSAREE.Text Then
            '    MsgBox("Number of Saree Exceeds")
            '    Exit Sub
            'End If


            GRIDCONSUME.Rows.Add(txtconsrno.Text, CMBPIECETYPE.Text.Trim, CMBMERCHANT.Text.Trim, Val(TXTCUT.Text), cmbdesignno.Text.Trim, Val(TXTSAREE.Text.Trim), Val(TXTMTRS.Text.Trim), 0, 0)
            getsrno(GRIDCONSUME)

        ElseIf congridDoubleClick = True Then

            GRIDCONSUME.Item("Gconsrno", temprow).Value = txtconsrno.Text
            GRIDCONSUME.Item("GPIECETYPE", temprow).Value = CMBPIECETYPE.Text.Trim
            GRIDCONSUME.Item("GMERCHANT", temprow).Value = CMBMERCHANT.Text.Trim
            GRIDCONSUME.Item("Gcut", temprow).Value = TXTCUT.Text.Trim
            GRIDCONSUME.Item("GSAREE", temprow).Value = TXTSAREE.Text.Trim
            GRIDCONSUME.Item("GMTRS", temprow).Value = TXTMTRS.Text.Trim
            GRIDCONSUME.Item("Gdesignno", temprow).Value = cmbdesignno.Text.Trim
            congridDoubleClick = False

        End If

        CMBPIECETYPE.Text = ""
        TXTMTRS.Clear()
        TXTSAREE.Clear()
        txtconsrno.Text = Val(GRIDCONSUME.RowCount + 1)
        CMBPIECETYPE.Focus()
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        If GRIDFCP.RowCount = 0 Then
            EP.SetError(cmbfrom, "Select Mfg")
            bln = False
        End If

        If GRIDCONSUME.RowCount = 0 Then
            EP.SetError(cmbfrom, "Select Mfg")
            bln = False
        End If

        If txtMerchant.Text.Trim = "" Then
            EP.SetError(txtMerchant, "Merchant No cannot be blank")
            bln = False
        End If


        'DONE BY GULKIT FOR TESTING PURPOSE
        'ALLOW MANGESH USER
        If ClientName <> "SHREENATH" Then
            If Val(LBLTOTALCUTPCS.Text) > Val(LBLTOTALSAREE.Text) And UserName <> "Mangesh" Then
                EP.SetError(LBLTOTALCUTPCS, "Sarees cannot be Greater then selected Sarees")
                bln = False
            End If
        End If


        'If gridconsume.RowCount = 0 Then
        '    EP.SetError(TXTMTRS, "Fill Recipe")
        '    bln = False
        'End If
        'If Val(LBLTOTALSAREE.Text) <> Val(LBLTOTALCUTPCS.Text) Then
        '    EP.SetError(LBLTOTALSAREE, "Total Sarees Select Does not match Cut Sarees")
        '    bln = False
        'End If
        'For Each row As DataGridViewRow In gridconsume.Rows
        '    If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
        '        bln = False
        '        EP.SetError(gridconsume, "Item Used Packing, Delete Packing First")

        '    End If
        'Next

        'If lbllocked.Visible = True Then
        '    EP.SetError(lbllocked, "Item Used Packing, Delete Packing First")
        '    bln = False
        'End If

        Return bln
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            EP.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            alParaval.Add(FCPdate.Value)
            alParaval.Add(cmbfrom.Text.Trim)
            alParaval.Add(txtjobno.Text.Trim)
            alParaval.Add(txttype.Text.Trim)
            alParaval.Add(cmbcontractor.Text.Trim)
            alParaval.Add(cmbsupervisior.Text.Trim)
            alParaval.Add(txtMerchant.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(TXTREFNO.Text.Trim)
            alParaval.Add(TXTNAME.Text.Trim)
            alParaval.Add(TXTINVNO.Text.Trim)
            alParaval.Add(INVDATE.Text)

            alParaval.Add(LBLTOTALSAREE.Text.Trim)
            alParaval.Add(LBLTOTALMTRS.Text.Trim)
            alParaval.Add(Val(LBLDEFCONSUMEDQTY.Text))
            alParaval.Add(Val(LBLACTCONSUMEDQTY.Text))
            alParaval.Add(Val(LBLDEFCONSUMEDAMT.Text))
            alParaval.Add(Val(LBLACTCONSUMEDAMT.Text))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim QUALITY As String = ""
            Dim INCUT As String = ""
            Dim DESIGN As String = ""
            Dim COLOR As String = ""
            Dim INSAREE As String = ""
            Dim INMTRS As String = ""
            Dim CUTTINGNO As String = ""
            Dim CUTTINGSRNO As String = ""
            Dim MFGNO As String = ""
            Dim MFGSRNO As String = ""
            Dim LOTNO As String = ""
            Dim LOTSRNO As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDFCP.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(gsrno.Index).Value

                        QUALITY = row.Cells(gquality.Index).Value.ToString
                        INCUT = row.Cells(GINCUT.Index).Value
                        DESIGN = row.Cells(GDESIGN.Index).Value
                        COLOR = row.Cells(gcolor.Index).Value
                        INSAREE = row.Cells(Ginsaree.Index).Value
                        INMTRS = row.Cells(GINMTRS.Index).Value

                        CUTTINGNO = row.Cells(GCUTTINGNO.Index).Value
                        CUTTINGSRNO = row.Cells(GCUTTINGSRNO.Index).Value
                        MFGNO = row.Cells(GMFGNO.Index).Value
                        MFGSRNO = row.Cells(GMFGSRNO.Index).Value
                        LOTNO = row.Cells(GLOTNO.Index).Value
                        LOTSRNO = row.Cells(GLOTSRNO.Index).Value

                    Else

                        gridsrno = gridsrno & "," & row.Cells(gsrno.Index).Value

                        QUALITY = QUALITY & "," & row.Cells(gquality.Index).Value.ToString
                        INCUT = INCUT & "," & row.Cells(GINCUT.Index).Value
                        DESIGN = DESIGN & "," & row.Cells(GDESIGN.Index).Value
                        COLOR = COLOR & "," & row.Cells(gcolor.Index).Value
                        INSAREE = INSAREE & "," & row.Cells(Ginsaree.Index).Value
                        INMTRS = INMTRS & "," & row.Cells(GINMTRS.Index).Value

                        CUTTINGNO = CUTTINGNO & "," & row.Cells(GCUTTINGNO.Index).Value
                        CUTTINGSRNO = CUTTINGSRNO & "," & row.Cells(GCUTTINGSRNO.Index).Value
                        MFGNO = MFGNO & "," & row.Cells(GMFGNO.Index).Value
                        MFGSRNO = MFGSRNO & "," & row.Cells(GMFGSRNO.Index).Value
                        LOTNO = LOTNO & "," & row.Cells(GLOTNO.Index).Value
                        LOTSRNO = LOTSRNO & "," & row.Cells(GLOTSRNO.Index).Value

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(QUALITY)
            alParaval.Add(INCUT)
            alParaval.Add(DESIGN)
            alParaval.Add(COLOR)
            alParaval.Add(INSAREE)
            alParaval.Add(INMTRS)
            alParaval.Add(CUTTINGNO)
            alParaval.Add(CUTTINGSRNO)
            alParaval.Add(MFGNO)
            alParaval.Add(MFGSRNO)
            alParaval.Add(LOTNO)
            alParaval.Add(LOTSRNO)


            Dim CONSUMEDSRNO As String = ""
            Dim ITEMNAME As String = ""
            Dim DEFQTY As String = ""
            Dim ACTQTY As String = ""
            Dim UNIT As String = ""
            Dim DEFRATE As String = ""
            Dim ACTRATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCONSUMPTION.Rows
                If row.Cells(0).Value <> Nothing Then
                    If CONSUMEDSRNO = "" Then
                        CONSUMEDSRNO = row.Cells(GCONSUMEDSRNO.Index).Value.ToString
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        DEFQTY = row.Cells(GdefQTY.Index).Value.ToString
                        ACTQTY = row.Cells(GactQty.Index).Value.ToString
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        DEFRATE = row.Cells(GdefRATE.Index).Value.ToString
                        ACTRATE = row.Cells(gActRate.Index).Value.ToString

                    Else

                        CONSUMEDSRNO = CONSUMEDSRNO & "," & row.Cells(GCONSUMEDSRNO.Index).Value
                        ITEMNAME = ITEMNAME & "," & row.Cells(GITEMNAME.Index).Value
                        DEFQTY = DEFQTY & "," & row.Cells(GdefQTY.Index).Value.ToString
                        ACTQTY = ACTQTY & "," & row.Cells(GactQty.Index).Value.ToString
                        UNIT = UNIT & "," & row.Cells(GUNIT.Index).Value.ToString
                        DEFRATE = DEFRATE & "," & row.Cells(GdefRATE.Index).Value
                        ACTRATE = ACTRATE & "," & row.Cells(gActRate.Index).Value

                    End If
                End If
            Next


            alParaval.Add(CONSUMEDSRNO)
            alParaval.Add(ITEMNAME)
            alParaval.Add(DEFQTY)
            alParaval.Add(ACTQTY)
            alParaval.Add(UNIT)
            alParaval.Add(DEFRATE)
            alParaval.Add(ACTRATE)


            Dim congridno As String = ""
            Dim PIECETYPE As String = ""
            Dim GRIDMERCHANT As String = ""
            Dim cut As String = ""
            Dim designno As String = ""
            Dim SAREE As String = ""
            Dim MTRS As String = ""
            Dim OUTSAREE As String = ""
            Dim DONE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCONSUME.Rows
                If row.Cells(0).Value <> Nothing Then
                    If congridno = "" Then

                        congridno = Val(row.Cells(gconsrno.Index).Value)
                        PIECETYPE = row.Cells(GPIECETYPE.Index).Value
                        GRIDMERCHANT = row.Cells(GMERCHANT.Index).Value
                        cut = Val(row.Cells(GCUT.Index).Value)
                        designno = row.Cells(GDESIGNNO.Index).Value
                        SAREE = Val(row.Cells(gsaree.Index).Value)
                        OUTSAREE = Val(row.Cells(GOUTSAREE.Index).Value)
                        MTRS = Val(row.Cells(gMtrs.Index).Value)
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                    Else

                        congridno = congridno & "," & Val(row.Cells(gconsrno.Index).Value)
                        PIECETYPE = PIECETYPE & "," & row.Cells(GPIECETYPE.Index).Value
                        GRIDMERCHANT = GRIDMERCHANT & "," & row.Cells(GMERCHANT.Index).Value
                        cut = cut & "," & Val(row.Cells(GCUT.Index).Value)
                        designno = designno & "," & row.Cells(GDESIGNNO.Index).Value
                        SAREE = SAREE & "," & Val(row.Cells(gsaree.Index).Value)
                        MTRS = MTRS & "," & Val(row.Cells(gMtrs.Index).Value)
                        OUTSAREE = OUTSAREE & "," & Val(row.Cells(GOUTSAREE.Index).Value)
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then
                            DONE = DONE & "," & "1"
                        Else
                            DONE = DONE & "," & "0"
                        End If
                    End If
                End If
            Next


            alParaval.Add(congridno)
            alParaval.Add(PIECETYPE)
            alParaval.Add(GRIDMERCHANT)
            alParaval.Add(cut)
            alParaval.Add(designno)
            alParaval.Add(SAREE)
            alParaval.Add(MTRS)
            alParaval.Add(OUTSAREE)
            alParaval.Add(DONE)

            'helpers 
            Dim HSRNO As String = ""
            Dim DESIGNATION As String = ""
            Dim HELPERS As String = ""
            Dim HELPERNAMES As String = ""

            For Each row As Windows.Forms.DataGridViewRow In gridhelper.Rows
                If row.Cells(0).Value <> Nothing Then
                    If HSRNO = "" Then
                        HSRNO = row.Cells(GHSRNO.Index).Value.ToString
                        DESIGNATION = row.Cells(gdesignation.Index).Value.ToString
                        HELPERS = row.Cells(ghelpers.Index).Value.ToString
                        HELPERNAMES = row.Cells(gHelperName.Index).Value.ToString

                    Else

                        HSRNO = HSRNO & "," & row.Cells(GHSRNO.Index).Value.ToString
                        DESIGNATION = DESIGNATION & "," & row.Cells(gdesignation.Index).Value.ToString
                        HELPERS = HELPERS & "," & row.Cells(ghelpers.Index).Value.ToString
                        HELPERNAMES = HELPERNAMES & "," & row.Cells(gHelperName.Index).Value.ToString
                    End If
                End If
            Next

            alParaval.Add(HSRNO)
            alParaval.Add(DESIGNATION)
            alParaval.Add(HELPERS)
            alParaval.Add(HELPERNAMES)


            alParaval.Add(Val(TXTGREYMTRS.Text.Trim))
            alParaval.Add(Val(TXTSHORTAGEPER.Text.Trim))
            alParaval.Add(Val(TXTDIFFMTRS.Text.Trim))


            Dim objFCP As New ClsFinalCUTTINGPROCESS
            objFCP.alParaval = alParaval

            If edit = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objFCP.SAVE()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPFCPNO)
                IntResult = objFCP.UPDATE()
                MsgBox("Details Updated")
            End If

            clear()
            edit = False
            cmbfrom.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub txtconsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtconsrno.GotFocus
        If congridDoubleClick = False Then
            If GRIDCONSUME.RowCount > 0 Then
                txtconsrno.Text = Val(GRIDCONSUME.Rows(GRIDCONSUME.RowCount - 1).Cells(gconsrno.Index).Value) + 1
            Else
                txtconsrno.Text = 1
            End If

        End If
    End Sub

    Private Sub TXTSAREE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSAREE.Enter
        If congridDoubleClick = False Then
            If GRIDCONSUME.RowCount > 0 Then
                txtconsrno.Text = Val(GRIDCONSUME.Rows(GRIDCONSUME.RowCount - 1).Cells(gconsrno.Index).Value) + 1
            Else
                txtconsrno.Text = 1
            End If
        End If
    End Sub

    Private Sub TXTSAREE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTSAREE.Validating
        TXTMTRS.Text = Val(TXTCUT.Text.Trim) * Val(TXTSAREE.Text)
    End Sub

    Private Sub cmbpiecetype_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBPIECETYPE.GotFocus
        Try
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbpiecetype_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBPIECETYPE.Validating
        Try
            If CMBPIECETYPE.Text.Trim <> "" Then PIECETYPEvalidate(CMBPIECETYPE, e, Me)
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
            GRIDFCP.RowCount = 0

            TEMPFCPNO = Val(TXTFCPNO.Text) - 1
            If TEMPFCPNO > 0 Then
                edit = True
                FinalCuttingProcess_Load(sender, e)
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

    Private Sub toolnext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            TEMPFCPNO = Val(TXTFCPNO.Text) + 1
            getmaxno()
            clear()
            If Val(TXTFCPNO.Text) - 1 >= TEMPFCPNO Then
                edit = True
                FinalCuttingProcess_Load(sender, e)
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
            GRIDFCP.RowCount = 0
            TEMPFCPNO = Val(tstxtbillno.Text)
            If TEMPFCPNO > 0 Then
                edit = True
                FinalCuttingProcess_Load(sender, e)
            Else
                clear()
                edit = False
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txthelpername_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthelpername.Validated
        Try
            If cmbdesignation.Text.Trim <> "" Then

                'CHECK WHETHER ITEM IS PRESENT IN GRID BELOW OR NOT
                For Each ROW As DataGridViewRow In gridhelper.Rows
                    If (LCase(ROW.Cells(gdesignation.Index).Value) = LCase(cmbdesignation.Text.Trim) And gridDoubleClick = False) Or (LCase(ROW.Cells(gdesignation.Index).Value) = LCase(cmbdesignation.Text.Trim) And gridDoubleClick = True And temprow <> ROW.Index) Then
                        MsgBox("Item Already Present in Grid Below", MsgBoxStyle.Critical)
                        cmbdesignation.Focus()
                        Exit Sub
                    End If
                Next

                fillHELPERSgrid()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
                txthsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txthelpers_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthelpers.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub gridhelper_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridhelper.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridhelper.RowCount > 0 Then
                If gridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                gridhelper.Rows.RemoveAt(gridhelper.CurrentRow.Index)
                getsrno(gridhelper)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBdesignation_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbdesignation.GotFocus
        Try
            If cmbdesignation.Text.Trim = "" Then filldesignation(cmbdesignation)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBdesignation_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdesignation.Validating
        Try
            If cmbdesignation.Text.Trim <> "" Then designationvalidate(cmbdesignation, e, Me)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillHELPERSgrid()

        If gridDoubleClick = False Then
            gridhelper.Rows.Add(Val(txthsrno.Text.Trim), cmbdesignation.Text.Trim, Format(Val(txthelpers.Text.Trim), "0"), txthelpername.Text.Trim)
            getsrno(gridhelper)
        ElseIf gridDoubleClick = True Then
            gridhelper.Item(GHSRNO.Index, temprow).Value = Val(txthsrno.Text.Trim)
            gridhelper.Item(gdesignation.Index, temprow).Value = cmbdesignation.Text.Trim
            gridhelper.Item(ghelpers.Index, temprow).Value = Format(Val(txthelpers.Text.Trim), "0")
            gridhelper.Item(gHelperName.Index, temprow).Value = txthelpername.Text.Trim

            gridDoubleClick = False
        End If

        gridhelper.FirstDisplayedScrollingRowIndex = gridhelper.RowCount - 1
        If gridDoubleClick = False Then
            If gridhelper.RowCount > 0 Then
                txthsrno.Text = Val(gridhelper.Rows(gridhelper.RowCount - 1).Cells(GHSRNO.Index).Value) + 1
            Else
                txthsrno.Text = 1
            End If
        End If

        cmbdesignation.Text = ""
        txthelpername.Clear()
        txthelpers.Clear()
        txthsrno.Focus()

    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objINVDTLS As New finalcuttingdetails
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()
            objINVDTLS.BringToFront()
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click

        Dim IntResult As Integer
        Try

            If edit = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Packing Slip Raised against this Cutting,Please Delete Packing Slip First?")
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete MFG?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TEMPFCPNO)
                    alParaval.Add(txttype.Text)
                    alParaval.Add(CmpId)
                    alParaval.Add(Locationid)
                    alParaval.Add(YearId)
                    alParaval.Add(cmbfrom.Text)

                    Dim OBJMFG As New ClsFinalCUTTINGPROCESS()
                    OBJMFG.alParaval = alParaval
                    IntResult = OBJMFG.Delete()
                    MsgBox("MFG Deleted")
                    clear()
                    edit = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub cmbdesignno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbdesignno.Validating
        Try

            If cmbdesignno.Text.Trim <> "" Then DESIGNvalidate(cmbdesignno, e, Me, CMBMERCHANT.Text.Trim)

            If ClientName <> "SHREENATH" Then
                TXTSAREE.Text = 0
                Dim totalsaree As Double
                If cmbdesignno.Text <> "" Then
                    For Each row As DataGridViewRow In GRIDFCP.Rows
                        If cmbdesignno.Text = row.Cells(GDESIGN.Index).Value Then
                            totalsaree = totalsaree + row.Cells(Ginsaree.Index).Value
                        End If
                    Next
                    For Each row As DataGridViewRow In GRIDCONSUME.Rows
                        If cmbdesignno.Text = row.Cells(GDESIGNNO.Index).Value And gridDoubleClick = False Then
                            totalsaree = totalsaree - row.Cells(gsaree.Index).Value
                        End If
                    Next
                    TXTSAREE.Text = totalsaree
                    If totalsaree = 0 Then
                        If MsgBox("Invalid Design No, Wish To Proceed", MsgBoxStyle.YesNo) = MsgBoxResult.No Then e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub FinalCuttingProcess_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If UserName = "Admin" Then CMBGODOWN.Enabled = True
    End Sub

    Private Sub cmbdesignno_Enter(sender As Object, e As EventArgs) Handles cmbdesignno.Enter
        Try
            If cmbdesignno.Text.Trim = "" Then fillDESIGN(cmbdesignno, CMBMERCHANT.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_Enter(sender As Object, e As EventArgs) Handles TXTCUT.Enter
        TXTCUT.SelectAll()
    End Sub

    Private Sub INVDATE_Validating(sender As Object, e As CancelEventArgs) Handles INVDATE.Validating
        Try
            If INVDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(INVDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMERCHANT.Enter
        Try
            If CMBMERCHANT.Text.Trim = "" Then fillitemname(CMBMERCHANT, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBMERCHANT.Validating
        Try
            If CMBMERCHANT.Text.Trim <> "" Then itemvalidate(CMBMERCHANT, e, Me, " AND (ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT')", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTMTRS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTMTRS.KeyPress, TXTGREYMTRS.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTGREYMTRS_Validated(sender As Object, e As EventArgs) Handles TXTGREYMTRS.Validated
        TOTAL()
    End Sub
End Class