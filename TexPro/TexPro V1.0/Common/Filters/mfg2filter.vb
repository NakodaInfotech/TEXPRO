
Imports BL

Public Class mfg2filter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Public FRMSTRING As String = "MFG"

    Private Sub Filter_for_Stock_Party_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdshowreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click
        Try
            Dim objstock As New mfgdesign
            Dim formula As String = "1=1"

            If rdbdetail.Checked = True And ChkStock.Checked = True Then GoTo line1

            formula = "{mfg2.YEARID}= " & YearId
line1:
            If cmbprocess.Text.Trim <> "" Then
                If cmbprocess.Text.Trim <> "CUTTING" Then

                    formula = formula & " and {mfg2.Process}='" & cmbprocess.Text.Trim & "'"

                End If
            End If
            If cmbMerchant.Text.Trim <> "" Then formula = formula & " and {mfg2.itemname}='" & cmbMerchant.Text.Trim & "'"
            If CMBDESIGN.Text.Trim <> "" Then formula = formula & " and {mfg2.design}='" & CMBDESIGN.Text.Trim & "'"
            If CMBJOB.Text.Trim <> "" Then formula = formula & " and {mfg2.jobno}='" & CMBJOB.Text.Trim & "'"
            If CMBDEPARTMENT.Text.Trim <> "" Then formula = formula & " and {mfg2.DEPARTMENT}='" & CMBDEPARTMENT.Text.Trim & "'"





            If FRMSTRING = "MFG" Then
                If CHKCONSUMPTION.Checked = False Then
                    If ChkStock.Checked = False Then
                        If rdbdetail.Checked = True Then
                            objstock.frmstring = "MFG2DETAIL"
                        ElseIf Rdbsummary.Checked = True Then
                            objstock.frmstring = "MFG2SUMMARY"
                        ElseIf RDBJOB.Checked = True Then
                            objstock.frmstring = "MFG2JOB"
                        ElseIf RDBMERCHANT.Checked = True Then
                            objstock.frmstring = "MFG2MERCHANT"
                        ElseIf RDBMONTHLY.Checked = True Then
                            objstock.frmstring = "MFG2MONTHLY"
                        ElseIf rdblabour.Checked = True Then
                            objstock.frmstring = "MFG2LABOUR"
                        ElseIf RDOMERCHANTSUMMARY.Checked = True Then
                            objstock.frmstring = "MFG2STOCKSUMMARY"
                        ElseIf RDBDESIGN.Checked = True Then
                            objstock.frmstring = "MFG2DESIGN"
                        End If
                    Else
                        If cmbprocess.Text <> "CUTTING" Then
                            If rdbdetail.Checked = True Then
                                'CHANGED BY GULKIT
                                'NEW REPORT IS MADE IN THE NAME OF MEMO STOCK OPEN THAT
                                If CHKVALUE.CheckState = CheckState.Unchecked Then
                                    objstock.frmstring = "MFG2STOCKDETAIL"
                                Else
                                    objstock.frmstring = "MFG2STOCKDETAILVALUE"
                                End If
                                formula = " {MEMO_STOCK.YEARID}= " & YearId
                                If cmbMerchant.Text.Trim <> "" Then formula = formula & " AND {MEMO_STOCK.MERCHANT}= '" & cmbMerchant.Text.Trim & "'"
                                If cmbprocess.Text.Trim <> "" Then formula = formula & " AND {MEMO_STOCK.Process}='" & cmbprocess.Text.Trim & "'"
                                If CMBJOB.Text.Trim <> "" Then formula = formula & " AND {MEMO_STOCK.JOBNO}='" & CMBJOB.Text.Trim & "'"
                            ElseIf Rdbsummary.Checked = True Then
                                objstock.frmstring = "MFG2STOCKSUMMARY"
                            ElseIf RDBJOB.Checked = True Then
                                objstock.frmstring = "MFG2STOCKJOB"
                            ElseIf RDBMERCHANT.Checked = True Then
                                objstock.frmstring = "MFG2STOCKMERCHANT"
                            ElseIf RDOMERCHANTSUMMARY.Checked = True Then
                                'CHANGED BY GULKIT
                                'NEW REPORT IS MADE IN THE NAME OF MEMO STOCK OPEN THAT
                                objstock.frmstring = "MFG2STOCKMERCHANTSUMMARY"
                                formula = "{MEMO_STOCK.YEARID}= " & YearId
                                If cmbprocess.Text.Trim <> "" Then formula = formula & " AND {MEMO_STOCK.process}= '" & cmbprocess.Text.Trim & "'"
                                If cmbMerchant.Text.Trim <> "" Then formula = formula & " AND {MEMO_STOCK.MERCHANT}= '" & cmbMerchant.Text.Trim & "'"
                                If CMBDESIGN.Text.Trim <> "" Then formula = formula & " AND {MEMO_STOCK.DESIGNNO}= '" & CMBDESIGN.Text.Trim & "'"
                            ElseIf RDBMONTHLY.Checked = True Then
                                objstock.frmstring = "MFG2STOCKMONTHLY"
                            ElseIf rdblabour.Checked = True Then
                                objstock.frmstring = "MFG2STOCKLABOUR"
                            End If
                        Else
                            If rdbdetail.Checked = True Then
                                objstock.frmstring = "CUTTINGSTOCKDETAIL"
                            End If
                        End If

                    End If
                Else
                    'IF COSTING IS TRUE
                    formula = " {mfg2.MFG_CMPID}= " & CmpId & " and {mfg2.MFG_LOCATIONID}= " & Locationid & " and {mfg2.MFG_YEARID}= " & YearId

                    If cmbprocess.Text.Trim <> "" Then formula = formula & " and {PROCESSMASTER.PROCESS_NAME}='" & cmbprocess.Text.Trim & "'"

                    If cmbMerchant.Text.Trim <> "" Then
                        formula = formula & " and {ITEMMASTER.item_name}='" & cmbMerchant.Text.Trim & "'"
                    End If

                    If CMBDESIGN.Text.Trim <> "" Then
                        formula = formula & " and {DESIGNRECIPE.DESIGN_NO}='" & CMBDESIGN.Text.Trim & "'"
                    End If


                    If rdbdetail.Checked = True Then
                        objstock.frmstring = "MFG2CONSUMPTIONDETAILS"
                    ElseIf Rdbsummary.Checked = True Then
                        objstock.frmstring = "MFG2CONSUMPTIONSUMMARY"
                    ElseIf RDBMONTHLY.Checked = True Then
                        objstock.frmstring = "MFG2CONSUMPTIONMONTHLY"

                    ElseIf RBSUPERSUMMARY.Checked = True Then
                        objstock.frmstring = "MFG2COSTSUPERSUMMARY"
                    ElseIf RBMERCHANTSUPERSUMM.Checked = True Then
                        objstock.frmstring = "MFG2COSTMERCHANTSUPERSUMMARY"
                    ElseIf RDBJOB.Checked = True Then
                        objstock.frmstring = "MFG2COSTJOB"
                    ElseIf RDBMERCHANT.Checked = True Then
                        objstock.frmstring = "MFG2COSTMERCHANT"
                    End If
                    formula = Replace(formula, "mfg2.date", "@DATE")
                End If
            ElseIf FRMSTRING = "FCP" Then
                formula = " {mfg2.YEARID}= " & YearId
                If rdbdetail.Checked = True Then
                    objstock.frmstring = "FCPDETAIL"
                ElseIf Rdbsummary.Checked = True Then
                    objstock.frmstring = "FCPSUMMARY"
                ElseIf RDBSUMMWITHIMG.Checked = True Then
                    objstock.frmstring = "FCPSUMMARYIMG"
                    objstock.ITEMNAME = cmbMerchant.Text.Trim
                    'ElseIf RDBJOB.Checked = True Then
                    '    objstock.frmstring = "FCPJOB"
                ElseIf RDBMERCHANT.Checked = True Then
                    objstock.frmstring = "FCPMERCHANT"
                    'ElseIf RDBMONTHLY.Checked = True Then
                    '    objstock.frmstring = "FCPMONTHLY"
                End If
                If ChkStock.Checked = False Then
                    formula = formula & " and {mfg2.TYPE}='FINAL CUTTING'"
                End If


                'FOR DESIGN
                Dim DESIGNCLAUSE As String = ""
                GRIDDESIGN.ClearColumnsFilter()
                For i As Integer = 0 To GRIDDESIGN.RowCount - 1
                    Dim dtrow As DataRow = GRIDDESIGN.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        If DESIGNCLAUSE = "" Then
                            DESIGNCLAUSE = " AND ({mfg2.DESIGNNO} = '" & dtrow("DESIGNNO") & "'"
                        Else
                            DESIGNCLAUSE = DESIGNCLAUSE & " OR {mfg2.DESIGNNO} = '" & dtrow("DESIGNNO") & "'"
                        End If
                    End If
                Next
                If DESIGNCLAUSE <> "" Then
                    DESIGNCLAUSE = DESIGNCLAUSE & ")"
                    formula = formula & DESIGNCLAUSE
                End If

                If cmbMerchant.Text.Trim <> "" Then formula = formula & " and {mfg2.MERCHANT}='" & cmbMerchant.Text.Trim & "'"
                If CMBDESIGN.Text.Trim <> "" Then formula = formula & " and {mfg2.DESIGN}='" & CMBDESIGN.Text.Trim & "'"
                If CMBPIECETYPE.Text.Trim <> "" Then formula = formula & " and {mfg2.PIECETYPE}='" & CMBPIECETYPE.Text.Trim & "'"
            End If

            If FRMSTRING <> "FCP" Then
                If chkdate.Checked = True Then
                    getFromToDate()
                    formula = formula & " and ({@DATE} in date " & fromD & " to date " & toD & ")"
                    objstock.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                Else
                    objstock.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
                End If
            End If

            objstock.MdiParent = MDIMain
            objstock.selfor_po = formula
            objstock.HIDERATE = Not CHKVALUE.Checked
            objstock.Show()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub Filter_for_Stock_Party_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If FRMSTRING = "MFG" Then
                Me.Text = "Memo Register"
                lblheading.Text = "Memo Register"
            ElseIf FRMSTRING = "FCP" Then
                Me.Text = "Loose Register"
                lblheading.Text = "Loose Register"
                rdblabour.Visible = False
                CHKCONSUMPTION.Visible = False
                RDBSUMMWITHIMG.Visible = True
            End If

            fillcombos()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcombos()
        Try
            If cmbprocess.Text.Trim = "" Then FILLPROCESS(cmbprocess, " AND PROCESS_TYPE in ('MFG2','CUTTING')", False)
            If CMBPIECETYPE.Text.Trim = "" Then fillPIECETYPE(CMBPIECETYPE)
            If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, False)

            Dim dt As DataTable
            Dim objclscomm As New ClsCommon()

            If cmbMerchant.Text.Trim = "" Then fillitemname(cmbMerchant, " AND ITEMMASTER.ITEM_FRMSTRING='MERCHANT'")
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, cmbMerchant.Text)

            dt = objclscomm.search(" DISTINCT MFG_JOBNO ", "", " MFGMASTER2 ", " AND MFGMASTER2.MFG_cmpid=" & CmpId & " and MFGMASTER2.MFG_Locationid=" & Locationid & " and MFGMASTER2.MFG_Yearid=" & YearId & " ORDER BY MFGMASTER2.MFG_JOBNO")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "MFG_JOBNO"
                CMBJOB.DataSource = dt
                CMBJOB.DisplayMember = "MFG_JOBNO"
                CMBJOB.Text = ""
            End If
            'If CMB Then


            Dim OBJCMN As New ClsCommon
            Dim WHERECLAUSE As String = ""
            If cmbMerchant.Text.Trim <> "" Then WHERECLAUSE = " AND ITEMMASTER.ITEM_NAME = '" & cmbMerchant.Text.Trim & "'"
            Dim DTDESIGN As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, DESIGNRECIPE.DESIGN_NO AS DESIGNNO ", " ", " DESIGNRECIPE LEFT OUTER JOIN ITEMMASTER ON DESIGN_ITEMID = ITEMMASTER.ITEM_ID", WHERECLAUSE & "  AND DESIGNRECIPE.DESIGN_YEARID = " & YearId & " ORDER BY DESIGNRECIPE.DESIGN_NO")
            GRIDDESIGNDETAILS.DataSource = DTDESIGN
            If DTDESIGN.Rows.Count > 0 Then
                GRIDDESIGN.FocusedRowHandle = GRIDDESIGN.RowCount - 1
                GRIDDESIGN.TopRowIndex = GRIDDESIGN.RowCount - 15
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBDESIGN.GotFocus
        Try
            If CMBDESIGN.Text.Trim = "" Then fillDESIGN(CMBDESIGN, cmbMerchant.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChkStock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkStock.CheckedChanged
        If ChkStock.Checked = True Then
            CHKCONSUMPTION.Checked = False

            rdbdetail.Visible = True
            RDBMONTHLY.Visible = True
            RDBJOB.Visible = True
            rdblabour.Visible = True
            Rdbsummary.Visible = True
            RDBMERCHANT.Visible = True
            RDOMERCHANTSUMMARY.Visible = True
            RDBLABOURCOST.Visible = False
            RBMERCHANTSUPERSUMM.Visible = False
            RBSUPERSUMMARY.Visible = False

            If RBSUPERSUMMARY.Visible = False And ChkStock.Checked = True Then
                rdbdetail.Checked = True
            End If
        End If
    End Sub

    Private Sub CHKCONSUMPTION_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKCONSUMPTION.CheckedChanged
        If CHKCONSUMPTION.Checked = True Then
            ChkStock.Checked = False

            rdbdetail.Visible = True
            RDBMONTHLY.Visible = False
            RDBJOB.Visible = False
            rdblabour.Visible = False
            Rdbsummary.Visible = True
            RDBMERCHANT.Visible = False
            RDOMERCHANTSUMMARY.Visible = False
            RDBLABOURCOST.Visible = True
            RBMERCHANTSUPERSUMM.Visible = True
            RBSUPERSUMMARY.Visible = True

            If RDBMONTHLY.Visible = False And RDBJOB.Visible = False And rdblabour.Visible = False And RDBMERCHANT.Visible = False And RDOMERCHANTSUMMARY.Visible = False And CHKCONSUMPTION.Checked = True Then
                rdbdetail.Checked = True
            End If
            If RBSUPERSUMMARY.Visible = False Then
                RBSUPERSUMMARY.Checked = False
                rdbdetail.Checked = True
            End If
        End If
    End Sub

    Private Sub cmbMerchant_Validated(sender As Object, e As EventArgs) Handles cmbMerchant.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim WHERECLAUSE As String = ""
            If cmbMerchant.Text.Trim <> "" Then WHERECLAUSE = " AND ITEMMASTER.ITEM_NAME = '" & cmbMerchant.Text.Trim & "'"
            Dim DTDESIGN As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, DESIGNRECIPE.DESIGN_NO AS DESIGNNO ", " ", " DESIGNRECIPE LEFT OUTER JOIN ITEMMASTER ON DESIGN_ITEMID = ITEMMASTER.ITEM_ID", WHERECLAUSE & "  AND DESIGNRECIPE.DESIGN_YEARID = " & YearId & " ORDER BY DESIGNRECIPE.DESIGN_NO")
            GRIDDESIGNDETAILS.DataSource = DTDESIGN
            If DTDESIGN.Rows.Count > 0 Then
                GRIDDESIGN.FocusedRowHandle = GRIDDESIGN.RowCount - 1
                GRIDDESIGN.TopRowIndex = GRIDDESIGN.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Enter(sender As Object, e As EventArgs) Handles CMBDEPARTMENT.Enter
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, False)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class