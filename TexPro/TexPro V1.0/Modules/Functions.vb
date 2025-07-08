Imports System.Windows.Forms
Imports System.Net.Mail
'Imports System.Web.Mail
Imports BL

Module Functions

    Function CHECKWHASTAPPEXP() As Boolean
        Dim BLN As Boolean = True
        If Now.Date > WHATSAPPEXPDATE Then
            BLN = False
        End If
        Return BLN
    End Function

    Sub VIEWFORM(ByVal TYPE As String, ByVal EDIT As Boolean, ByVal BILLNO As Integer, ByVal REGTYPE As String)
        Try
            If TYPE = "PURCHASE" Then

                Dim OBJPURCHASE As New PurchaseMaster
                OBJPURCHASE.MdiParent = MDIMain
                OBJPURCHASE.EDIT = EDIT
                OBJPURCHASE.TEMPBILLNO = BILLNO
                OBJPURCHASE.TEMPREGNAME = REGTYPE
                OBJPURCHASE.Show()

            ElseIf TYPE = "SALE" Then

                Dim OBJSALE As New InvoiceMaster
                OBJSALE.MdiParent = MDIMain
                OBJSALE.EDIT = EDIT
                OBJSALE.TEMPINVOICENO = BILLNO
                OBJSALE.TEMPREGNAME = REGTYPE
                OBJSALE.Show()

            ElseIf TYPE = "PAYMENT" Then

                Dim OBJPAYMENT As New PaymentMaster
                OBJPAYMENT.MdiParent = MDIMain
                OBJPAYMENT.EDIT = EDIT
                OBJPAYMENT.TEMPPAYMENTNO = BILLNO
                OBJPAYMENT.TEMPREGNAME = REGTYPE
                OBJPAYMENT.Show()

            ElseIf TYPE = "RECEIPT" Then

                Dim OBJREC As New Receipt
                OBJREC.MdiParent = MDIMain
                OBJREC.EDIT = EDIT
                OBJREC.TEMPRECEIPTNO = BILLNO
                OBJREC.TEMPREGNAME = REGTYPE
                OBJREC.Show()

            ElseIf TYPE = "JOURNAL" Then

                Dim OBJJV As New journal
                OBJJV.MdiParent = MDIMain
                OBJJV.EDIT = EDIT
                OBJJV.tempjvno = BILLNO
                OBJJV.TEMPREGNAME = REGTYPE
                OBJJV.Show()

            ElseIf TYPE = "DEBITNOTE" Then

                Dim OBJDN As New DebitNote
                OBJDN.MdiParent = MDIMain
                OBJDN.edit = EDIT
                OBJDN.TEMPDNNO = BILLNO
                OBJDN.TEMPREGNAME = REGTYPE
                OBJDN.Show()

            ElseIf TYPE = "CREDITNOTE" Then

                Dim OBJCN As New CREDITNOTE
                OBJCN.MdiParent = MDIMain
                OBJCN.edit = EDIT
                OBJCN.TEMPCNNO = BILLNO
                OBJCN.TEMPREGNAME = REGTYPE
                OBJCN.Show()

            ElseIf TYPE = "CONTRA" Then

                Dim OBJCON As New ContraEntry
                OBJCON.MdiParent = MDIMain
                OBJCON.EDIT = EDIT
                OBJCON.tempcontrano = BILLNO
                OBJCON.TEMPREGNAME = REGTYPE
                OBJCON.Show()

            ElseIf TYPE = "EXPENSE" Then

                Dim OBJEXP As New ExpenseVoucher
                OBJEXP.MdiParent = MDIMain
                OBJEXP.EDIT = EDIT
                OBJEXP.TEMPEXPNO = BILLNO
                OBJEXP.TEMPREGNAME = REGTYPE
                OBJEXP.FRMSTRING = "NONPURCHASE"
                OBJEXP.Show()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ErrHandle(ByVal Errcode As Integer) As Boolean
        Dim bln As Boolean = False
        If Errcode = -675406840 Then
            MsgBox("Check Internet Connection")
            bln = True
        End If
        Return bln
    End Function

    Public Sub pcase(ByRef txt As Object)
        ' txt.Text = StrConv(txt.Text, VbStrConv.ProperCase)
    End Sub

    Public Sub uppercase(ByRef txt As Object)
        txt.Text = StrConv(txt.Text, VbStrConv.Uppercase)
    End Sub

    Public Sub lowercase(ByRef txt As Object)
        'txt.Text = StrConv(txt.Text, VbStrConv.Lowercase)
    End Sub

#Region "IN WORDS FUNCTION"

    Function CurrencyToWord(ByVal Num As Decimal) As String

        'I have created this function for converting amount in indian rupees (INR). 
        'You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.

        Dim strNum As String
        Dim strNumDec As String
        Dim StrWord As String
        strNum = Num

        If InStr(1, strNum, ".") <> 0 Then
            strNumDec = Mid(strNum, InStr(1, strNum, ".") + 1)

            If Len(strNumDec) = 1 Then
                strNumDec = strNumDec + "0"
            End If
            If Len(strNumDec) > 2 Then
                strNumDec = Mid(strNumDec, 1, 2)
            End If

            strNum = Mid(strNum, 1, InStr(1, strNum, ".") - 1)
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum)) + IIf(CDbl(strNumDec) > 0, " and Paise" + cWord3(CDbl(strNumDec)), "")
        Else
            StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum))
        End If
        CurrencyToWord = StrWord & " Only"
        Return CurrencyToWord

    End Function

    Function NumToWord(ByVal Num As Decimal) As String

        'I divided this function in two part.
        '1. Three or less digit number.
        '2. more than three digit number.
        Dim strNum As String
        Dim StrWord As String
        strNum = Num

        If Len(strNum) <= 3 Then
            StrWord = cWord3(CDbl(strNum))
        Else
            StrWord = cWordG3(CDbl(Mid(strNum, 1, Len(strNum) - 3))) + " " + cWord3(CDbl(Mid(strNum, Len(strNum) - 2)))
        End If
        NumToWord = StrWord

    End Function

    Function cWordG3(ByVal Num As Decimal) As String

        '2. more than three digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        strNum = Num
        If Len(strNum) Mod 2 <> 0 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            If readNum <> "0" Then
                StrWord = retWord(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 1) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 2)
        End If
        While Not Len(strNum) = 0
            readNum = CDbl(Mid(strNum, 1, 2))
            If readNum <> "0" Then
                StrWord = StrWord + " " + cWord3(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 2) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 3)
        End While
        cWordG3 = StrWord
        Return cWordG3

    End Function

    Function strReplicate(ByVal str As String, ByVal intD As Integer) As String

        'This fucntion padded "0" after the number to evaluate hundred, thousand and on....
        'using this function you can replicate any Charactor with given string.
        strReplicate = ""
        For i As Integer = 1 To intD
            strReplicate = strReplicate + str
        Next
        Return strReplicate

    End Function

    Function cWord3(ByVal Num As Decimal) As String

        '1. Three or less digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        If Num < 0 Then Num = Num * -1
        strNum = Num

        If Len(strNum) = 3 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            StrWord = retWord(readNum) + " Hundred"
            strNum = Mid(strNum, 2, Len(strNum))
        End If

        If Len(strNum) <= 2 Then
            If CDbl(strNum) >= 0 And CDbl(strNum) <= 20 Then
                StrWord = StrWord + " " + retWord(CDbl(strNum))
            Else
                StrWord = StrWord + " " + retWord(CDbl(Mid(strNum, 1, 1) + "0")) + " " + retWord(CDbl(Mid(strNum, 2, 1)))
            End If
        End If

        strNum = CStr(Num)
        cWord3 = StrWord
        Return cWord3

    End Function

    Function retWord(ByVal Num As Decimal) As String
        'This two dimensional array store the primary word convertion of number.
        retWord = ""
        Dim ArrWordList(,) As Object = {{0, ""}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"},
                                        {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"},
                                        {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"},
                                        {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"},
                                        {20, "Twenty"}, {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"},
                                        {70, "Seventy"}, {80, "Eighty"}, {90, "Ninety"}, {100, "Hundred"}, {1000, "Thousand"},
                                        {100000, "Lakh"}, {10000000, "Crore"}}

        For i As Integer = 0 To UBound(ArrWordList)
            If Num = ArrWordList(i, 0) Then
                retWord = ArrWordList(i, 1)
                Exit For
            End If
        Next
        Return retWord

    End Function

#End Region

#Region "FUNCTION FOR COLOR"

    Sub fillCOLOR(ByRef cmbCOLOR As ComboBox, Optional ByVal JOIN As String = "", Optional ByVal WHERE As String = "")
        Try

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search(" DISTINCT COLOR_NAME ", "", " COLORMaster " & JOIN, " and COLOR_cmpid=" & CmpId & " and COLOR_locationid = " & Locationid & " and COLOR_yearid = " & YearId & WHERE)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "COLOR_NAME"
                cmbCOLOR.DataSource = dt
                cmbCOLOR.DisplayMember = "COLOR_NAME"
                cmbCOLOR.Text = ""
            End If
            cmbCOLOR.SelectAll()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLSTAMP(ByRef CMBSTAMP As ComboBox, Optional ByVal WHERE As String = "")
        Try

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search(" DISTINCT STAMP_NAME ", "", " STAMPMaster ", " and STAMP_cmpid=" & CmpId & " and STAMP_locationid = " & Locationid & " and STAMP_yearid = " & YearId & WHERE)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "STAMP_NAME"
                CMBSTAMP.DataSource = dt
                CMBSTAMP.DisplayMember = "STAMP_NAME"
                CMBSTAMP.Text = ""
            End If
            CMBSTAMP.SelectAll()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLPARTYGROUP(ByRef CMBPARTYGROUP As ComboBox, Optional ByVal WHERE As String = "")
        Try

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search(" DISTINCT PG_NAME ", "", " PARTYGROUPMaster ", " and PG_cmpid=" & CmpId & " and PG_locationid = " & Locationid & " and PG_yearid = " & YearId & WHERE)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "PG_NAME"
                CMBPARTYGROUP.DataSource = dt
                CMBPARTYGROUP.DisplayMember = "PG_NAME"
                CMBPARTYGROUP.Text = ""
            End If
            CMBPARTYGROUP.SelectAll()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillEXTRA(ByRef cmbEXTRA As ComboBox, Optional ByVal JOIN As String = "", Optional ByVal WHERE As String = "")
        Try

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search(" DISTINCT EXTRA_NAME ", "", " EXTRAMaster " & JOIN, " and EXTRA_cmpid=" & CmpId & " and EXTRA_locationid = " & Locationid & " and EXTRA_yearid = " & YearId & WHERE)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "EXTRA_NAME"
                cmbEXTRA.DataSource = dt
                cmbEXTRA.DisplayMember = "EXTRA_NAME"
                cmbEXTRA.Text = ""
            End If
            cmbEXTRA.SelectAll()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillCOLORRATE(ByRef cmbCOLORRATE As ComboBox, Optional ByVal JOIN As String = "", Optional ByVal WHERE As String = "")
        Try

            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search(" DISTINCT CR_NO ", "", " COLORRATEMaster " & JOIN, " and CR_cmpid=" & CmpId & " and CR_locationid = " & Locationid & " and CR_yearid = " & YearId & WHERE)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "CR_NO"
                cmbCOLORRATE.DataSource = dt
                cmbCOLORRATE.DisplayMember = "CR_NO"
                cmbCOLORRATE.Text = ""
            End If
            cmbCOLORRATE.SelectAll()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillCONTRACTOR(ByRef cmbCONTRACTOR As ComboBox)
        Try
            If cmbCONTRACTOR.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" CONTRACTOR_NAME ", "", " CONTRACTORMaster ", " and CONTRACTOR_cmpid=" & CmpId & " and CONTRACTOR_locationid = " & Locationid & " and CONTRACTOR_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CONTRACTOR_NAME"
                    cmbCONTRACTOR.DataSource = dt
                    cmbCONTRACTOR.DisplayMember = "CONTRACTOR_NAME"
                    cmbCONTRACTOR.Text = ""
                End If
                cmbCONTRACTOR.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub filldesignation(ByRef cmbdesignation As ComboBox)
        Try
            If cmbdesignation.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" designation_NAME ", "", " designationMaster ", " and designation_cmpid=" & CmpId & " and designation_locationid = " & Locationid & " and designation_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "designation_NAME"
                    cmbdesignation.DataSource = dt
                    cmbdesignation.DisplayMember = "designation_NAME"
                    cmbdesignation.Text = ""
                End If
                cmbdesignation.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillSUPERVISIOR(ByRef cmbSUPERVISIOR As ComboBox)
        Try
            If cmbSUPERVISIOR.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" SUPERVISIOR_NAME ", "", " SUPERVISIORMaster ", " and SUPERVISIOR_cmpid=" & CmpId & " and SUPERVISIOR_locationid = " & Locationid & " and SUPERVISIOR_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "SUPERVISIOR_NAME"
                    cmbSUPERVISIOR.DataSource = dt
                    cmbSUPERVISIOR.DisplayMember = "SUPERVISIOR_NAME"
                    cmbSUPERVISIOR.Text = ""
                End If
                cmbSUPERVISIOR.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillPIECETYPE(ByRef CMBPIECETYPE As ComboBox)
        Try
            If CMBPIECETYPE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PIECETYPE_NAME ", "", " PIECETYPEMaster ", " and PIECETYPE_cmpid=" & CmpId & " and PIECETYPE_locationid = " & Locationid & " and PIECETYPE_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PIECETYPE_NAME"
                    CMBPIECETYPE.DataSource = dt
                    CMBPIECETYPE.DisplayMember = "PIECETYPE_NAME"
                    CMBPIECETYPE.Text = ""
                End If
                CMBPIECETYPE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillscreen(ByRef CMBscreen As ComboBox)
        Try
            If CMBscreen.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" screen_NAME ", "", " screenMaster ", " and screen_cmpid=" & CmpId & " and screen_locationid = " & Locationid & " and screen_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "screen_NAME"
                    CMBscreen.DataSource = dt
                    CMBscreen.DisplayMember = "screen_NAME"
                    CMBscreen.Text = ""
                End If
                CMBscreen.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillDESIGN(ByRef cmbDESIGN As ComboBox, Optional ByVal MERCHANTNAME As String = "")
        Try
            'If cmbDESIGN.Text.Trim = "" Then
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            Dim WHERE As String = ""
            If MERCHANTNAME <> "" Then WHERE = " AND ITEMMASTER.ITEM_NAME='" & MERCHANTNAME & "' "
            dt = objclscommon.search(" DISTINCT DESIGN_NO ", "", "  DESIGNRECIPE INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid ", WHERE & " and DESIGN_cmpid=" & CmpId & " and DESIGN_locationid = " & Locationid & " and DESIGN_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "DESIGN_NO"
                cmbDESIGN.DataSource = dt
                cmbDESIGN.DisplayMember = "DESIGN_NO"
                cmbDESIGN.Text = ""
            End If
            cmbDESIGN.SelectAll()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub filldyeing(ByRef cmbdyeing As ComboBox)
        Try
            If cmbdyeing.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" DISTINCT dyeing_NO ", "", " dyeingRECIPE ", " AND ISNULL(DYEING_BLOCKED,0) = 'FALSE' and dyeing_cmpid=" & CmpId & " and dyeing_locationid = " & Locationid & " and dyeing_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "dyeing_NO"
                    cmbdyeing.DataSource = dt
                    cmbdyeing.DisplayMember = "dyeing_NO"
                    cmbdyeing.Text = ""
                End If
                cmbdyeing.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub COLORvalidate(ByRef cmbCOLOR As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional ByVal JOIN As String = "", Optional ByVal WHERE As String = "")
        Try

            If cmbCOLOR.Text.Trim <> "" Then
                uppercase(cmbCOLOR)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" COLOR_NAME ", "", "COLORMaster" & JOIN, " and COLOR_NAME = '" & cmbCOLOR.Text.Trim & "' and COLOR_cmpid = " & CmpId & " and COLOR_locationid = " & Locationid & " and COLOR_yearid = " & YearId & WHERE)
                If dt.Rows.Count = 0 Then
                    If JOIN <> "" Then
                        MsgBox("MATCHING NOT PRESENT PLEASE ADD THIS MATCHING IN DYEINGRECIPE")
                        cmbCOLOR.Focus()
                        cmbCOLOR.SelectAll()
                        e.Cancel = True
                        Exit Sub
                    End If
                    Dim tempmsg As Integer = MsgBox("Color not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(UCase(cmbCOLOR.Text.Trim))
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)
                        alParaval.Add("")   'COLORTYPE

                        Dim objCOLOR As New ClsColorMaster
                        objCOLOR.alParaval = alParaval
                        Dim IntResult As Integer = objCOLOR.SAVE()
                        'e.Cancel = True
                    Else
                        cmbCOLOR.Focus()
                        cmbCOLOR.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub STAMPVALIDATE(ByRef CMBSTAMP As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional ByVal WHERE As String = "")
        Try

            If CMBSTAMP.Text.Trim <> "" Then
                uppercase(CMBSTAMP)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" STAMP_NAME ", "", "STAMPMaster", " and STAMP_NAME = '" & CMBSTAMP.Text.Trim & "' and STAMP_cmpid = " & CmpId & " and STAMP_locationid = " & Locationid & " and STAMP_yearid = " & YearId & WHERE)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("STAMP not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBSTAMP.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objSTAMP As New ClsStampMaster
                        objSTAMP.alParaval = alParaval
                        Dim IntResult As Integer = objSTAMP.save()
                    Else
                        CMBSTAMP.Focus()
                        CMBSTAMP.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub screenvalidate(ByRef cmbscreen As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If cmbscreen.Text.Trim <> "" Then
                lowercase(cmbscreen)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" screen_NAME ", "", "screenMaster", " and screen_NAME = '" & cmbscreen.Text.Trim & "' and screen_cmpid = " & CmpId & " and screen_locationid = " & Locationid & " and screen_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("screen not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(cmbscreen.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objscreen As New ClsscreenMaster
                        objscreen.alParaval = alParaval
                        Dim IntResult As Integer = objscreen.save()
                        'e.Cancel = True
                    Else
                        cmbscreen.Focus()
                        cmbscreen.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SUPERVISIORvalidate(ByRef cmbSUPERVISIOR As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If cmbSUPERVISIOR.Text.Trim <> "" Then
                lowercase(cmbSUPERVISIOR)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" SUPERVISIOR_NAME ", "", "SUPERVISIORMaster", " and SUPERVISIOR_NAME = '" & cmbSUPERVISIOR.Text.Trim & "' and SUPERVISIOR_cmpid = " & CmpId & " and SUPERVISIOR_locationid = " & Locationid & " and SUPERVISIOR_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("SUPERVISIOR not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(cmbSUPERVISIOR.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objSUPERVISIOR As New ClsSUPERVISIORMaster
                        objSUPERVISIOR.alParaval = alParaval
                        Dim IntResult As Integer = objSUPERVISIOR.save()
                        'e.Cancel = True
                    Else
                        cmbSUPERVISIOR.Focus()
                        cmbSUPERVISIOR.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CONTRACTORvalidate(ByRef cmbCONTRACTOR As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If cmbCONTRACTOR.Text.Trim <> "" Then
                lowercase(cmbCONTRACTOR)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" CONTRACTOR_NAME ", "", "CONTRACTORMaster", " and CONTRACTOR_NAME = '" & cmbCONTRACTOR.Text.Trim & "' and CONTRACTOR_cmpid = " & CmpId & " and CONTRACTOR_locationid = " & Locationid & " and CONTRACTOR_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("CONTRACTOR not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(cmbCONTRACTOR.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objCONTRACTOR As New ClsCONTRACTORMaster
                        objCONTRACTOR.alParaval = alParaval
                        Dim IntResult As Integer = objCONTRACTOR.save()
                        'e.Cancel = True
                    Else
                        cmbCONTRACTOR.Focus()
                        cmbCONTRACTOR.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub designationvalidate(ByRef cmbdesignation As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If cmbdesignation.Text.Trim <> "" Then
                lowercase(cmbdesignation)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" designation_NAME ", "", "designationMaster", " and designation_NAME = '" & cmbdesignation.Text.Trim & "' and designation_cmpid = " & CmpId & " and designation_locationid = " & Locationid & " and designation_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("designation not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(cmbdesignation.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objdesignation As New ClsdesignationMaster
                        objdesignation.alParaval = alParaval
                        Dim IntResult As Integer = objdesignation.save()
                        'e.Cancel = True
                    Else
                        cmbdesignation.Focus()
                        cmbdesignation.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PIECETYPEvalidate(ByRef cmbPIECETYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If cmbPIECETYPE.Text.Trim <> "" Then
                lowercase(cmbPIECETYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PIECETYPE_NAME ", "", "PIECETYPEMaster", " and PIECETYPE_NAME = '" & cmbPIECETYPE.Text.Trim & "' and PIECETYPE_cmpid = " & CmpId & " and PIECETYPE_locationid = " & Locationid & " and PIECETYPE_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("PIECETYPE not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(cmbPIECETYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objPIECETYPE As New ClsPieceTypeMaster
                        objPIECETYPE.alParaval = alParaval
                        Dim IntResult As Integer = objPIECETYPE.save()
                        'e.Cancel = True
                    Else
                        cmbPIECETYPE.Focus()
                        cmbPIECETYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLISSUEMERCHANT(ByRef CMBMERCHANT As ComboBox)
        Try
            If CMBMERCHANT.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" ISSUEMERCHANT_NAME ", "", " ISSUEMERCHANTMaster ", " and ISSUEMERCHANT_cmpid=" & CmpId & " and ISSUEMERCHANT_locationid = " & Locationid & " and ISSUEMERCHANT_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ISSUEMERCHANT_NAME"
                    CMBMERCHANT.DataSource = dt
                    CMBMERCHANT.DisplayMember = "ISSUEMERCHANT_NAME"
                    CMBMERCHANT.Text = ""
                End If
                CMBMERCHANT.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ISSUEMERCHANTVALIDATE(ByRef CMBISSUEMERCHANT As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBISSUEMERCHANT.Text.Trim <> "" Then
                lowercase(CMBISSUEMERCHANT)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" ISSUEMERCHANT_NAME ", "", "ISSUEMERCHANTMASTER", " and ISSUEMERCHANT_NAME = '" & CMBISSUEMERCHANT.Text.Trim & "' and ISSUEMERCHANT_cmpid = " & CmpId & " and ISSUEMERCHANT_locationid = " & Locationid & " and ISSUEMERCHANT_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Merchant not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBISSUEMERCHANT.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objISSUEMERCHANT As New ClsIssueMerchantMaster
                        objISSUEMERCHANT.alParaval = alParaval
                        Dim IntResult As Integer = objISSUEMERCHANT.save()
                        'e.Cancel = True
                    Else
                        CMBISSUEMERCHANT.Focus()
                        CMBISSUEMERCHANT.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

    Function setcolor(ByVal no As Integer) As String
        Try
            Dim str As String = String.Empty
            Dim remainder As Integer
            remainder = no Mod 30
            Select Case remainder
                Case 0
                    str = "Turquoise"
                Case 1
                    str = "LightGreen"
                Case 2
                    str = "LightSkyBlue"
                Case 3
                    str = "Lavender"
                Case 4
                    str = "Plum"
                Case 5
                    str = "Pink"
                Case 6
                    str = "LightCyan"
                Case 7
                    str = "Gold"
                Case 8
                    str = "Silver"
                Case 9
                    str = "Khaki"
                Case 10
                    str = "LIGHTCORAL"
                Case 11
                    str = "MISTYROSE"
                Case 12
                    str = "LIGHTSALMON"
                Case 13
                    str = "SEASHELL"
                Case 14
                    str = "PEACHPUFF"
                Case 15
                    str = "CORNSILK"
                Case 16
                    str = "YELLOWGREEN"
                Case 17
                    str = "HotPink"
                Case 18
                    str = "HONEYDEW"
                Case 19
                    str = "LAVENDER"
                Case 20
                    str = "THISTLE"
                Case 21
                    str = "PINK"
                Case 22
                    str = "GREENYELLOW"
                Case 23
                    str = "SkyBlue"
                Case 24
                    str = "LightCyan"
                Case 25
                    str = "Lime"
                Case 26
                    str = "Wheat"
                Case 27
                    str = "Cornsilk"
                Case 28
                    str = "DarkOrange"
                Case 29
                    str = "PaleVioletRed"
                Case 30
                    str = "LIGHTPINK"

            End Select
            Return str
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Function

    Sub fillform(ByRef CHKFORM As CheckedListBox, ByRef edit As Boolean, Optional ByVal WHERECLAUSE As String = "")
        Try
            If CHKFORM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" form_name ", "", " FORMTYPE", WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "FORM_name"
                    CHKFORM.DataSource = dt
                    CHKFORM.DisplayMember = "FORM_name"
                    If edit = False Then CHKFORM.Text = ""

                End If
                ''CHKFORM.SelectedIndex = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLTAXNAME(ByRef cmbtax As ComboBox, ByRef edit As Boolean)
        Try
            If cmbtax.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" tax_name ", "", " TaxMaster", " and Tax_cmpid=" & CmpId & " AND TAX_LOCATIONID = " & Locationid & " AND TAX_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "tax_name"
                    cmbtax.DataSource = dt
                    cmbtax.DisplayMember = "tax_name"
                    If edit = False Then cmbtax.Text = ""
                End If
                cmbtax.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillOCTROI(ByRef CMBOCTROI As ComboBox, ByRef edit As Boolean)
        Try
            If CMBOCTROI.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" OCTROI_name ", "", " OCTROIMaster", " and OCTROI_cmpid=" & CmpId & " AND OCTROI_LOCATIONID = " & Locationid & " AND OCTROI_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "OCTROI_name"
                    CMBOCTROI.DataSource = dt
                    CMBOCTROI.DisplayMember = "OCTROI_name"
                    If edit = False Then CMBOCTROI.Text = ""
                End If
                CMBOCTROI.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ALPHEBETKEYPRESS(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        If (AscW(han.KeyChar) >= 65 And AscW(han.KeyChar) <= 90) Or (AscW(han.KeyChar) >= 97 And AscW(han.KeyChar) <= 122) Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If
        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub numdot3(ByVal han As KeyPressEventArgs, ByVal txt As TextBox, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        mypos = InStr(1, txt.Text, ".")

        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 46 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If


        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 And mypos <> "0" Then
            If txt.SelectionStart = mypos + 3 Then
                han.KeyChar = ""
            End If
        End If

        If txt.SelectionStart >= mypos Then
            txt.SelectionLength = 1
            han.KeyChar = han.KeyChar
        End If

        If AscW(han.KeyChar) = 46 Then

            'test = True
            mypos = InStr(1, txt.Text, ".")
            If mypos <> "0" Then txt.SelectionStart = mypos
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If

        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub numdot(ByVal han As KeyPressEventArgs, ByVal txt As Object, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        mypos = InStr(1, txt.Text, ".")

        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 46 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If


        If AscW(han.KeyChar) > 47 And AscW(han.KeyChar) < 58 And mypos <> "0" Then
            If txt.SelectionStart = mypos + 2 Then
                han.KeyChar = ""
            End If
        End If

        If txt.SelectionStart >= mypos Then
            txt.SelectionLength = 1
            han.KeyChar = han.KeyChar
        End If

        If AscW(han.KeyChar) = 46 Then

            'test = True
            mypos = InStr(1, txt.Text, ".")
            If mypos <> "0" Then txt.SelectionStart = mypos
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If

        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub numdotkeypress(ByVal han As KeyPressEventArgs, ByVal sen As Object, ByVal frm As System.Windows.Forms.Form)
        Dim mypos As Integer

        If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        ElseIf AscW(han.KeyChar) = 46 Then
            mypos = InStr(1, sen.Text, ".")
            If mypos = 0 Then
                han.KeyChar = han.KeyChar
            Else
                han.KeyChar = ""
            End If
        Else
            han.KeyChar = ""
        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Sub AMOUNTNUMDOTKYEPRESS(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        Try
            Dim mypos As Integer

            If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Or AscW(han.KeyChar) = 45 Then
                han.KeyChar = han.KeyChar
            ElseIf AscW(han.KeyChar) = 46 Or AscW(han.KeyChar) = 45 Then
                mypos = InStr(1, sen.Text, ".")
                If mypos = 0 Then
                    han.KeyChar = han.KeyChar
                Else
                    han.KeyChar = ""
                End If
            Else
                han.KeyChar = ""
            End If

            If AscW(han.KeyChar) = Keys.Escape Then
                frm.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub numkeypress(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)

        If AscW(han.KeyChar) >= 48 And AscW(han.KeyChar) <= 57 Or AscW(han.KeyChar) = 8 Then
            han.KeyChar = han.KeyChar
        Else
            han.KeyChar = ""
        End If

        If AscW(han.KeyChar) = Keys.Escape Then
            frm.Close()
        End If
    End Sub

    Function getmax(ByVal fldname As String, ByVal tbname As String, Optional ByVal whereclause As String = "") As DataTable
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim DTTABLE As DataTable

            Dim objclscommon As New ClsCommon()
            DTTABLE = objclscommon.GETMAXNO(fldname, tbname, whereclause)

            Return DTTABLE
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Function getfirstdate(ByVal cmpid As Integer, Optional ByVal monthname As String = "", Optional ByVal monthno As Integer = 0) As Date
        Try
            Dim objcmn As New ClsCommon
            Dim ddate As Date
            If monthname <> "" And monthno = 0 Then
                If monthname = "April" Then monthno = 4
                If monthname = "May" Then monthno = 5
                If monthname = "June" Then monthno = 6
                If monthname = "July" Then monthno = 7
                If monthname = "August" Then monthno = 8
                If monthname = "September" Then monthno = 9
                If monthname = "October" Then monthno = 10
                If monthname = "November" Then monthno = 11
                If monthname = "December" Then monthno = 12
                If monthname = "January" Then monthno = 1
                If monthname = "February" Then monthno = 2
                If monthname = "March" Then monthno = 3

                If monthno < 4 Then
                    ddate = (objcmn.getfirstdate(Convert.ToDateTime((monthno & "/01/" & Year(AccTo)))))
                Else
                    ddate = (objcmn.getfirstdate(Convert.ToDateTime((monthno & "/01/" & Year(AccFrom)))))
                End If
            End If
            Return ddate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function getlastdate(ByVal cmpid As Integer, Optional ByVal monthname As String = "", Optional ByVal monthno As Integer = 0) As Date
        Try
            Dim objcmn As New ClsCommon
            Dim ddate As Date
            If monthname <> "" And monthno = 0 Then
                If monthname = "April" Then monthno = 4
                If monthname = "May" Then monthno = 5
                If monthname = "June" Then monthno = 6
                If monthname = "July" Then monthno = 7
                If monthname = "August" Then monthno = 8
                If monthname = "September" Then monthno = 9
                If monthname = "October" Then monthno = 10
                If monthname = "November" Then monthno = 11
                If monthname = "December" Then monthno = 12
                If monthname = "January" Then monthno = 1
                If monthname = "February" Then monthno = 2
                If monthname = "March" Then monthno = 3

                If monthno < 4 Then
                    ddate = (objcmn.getlastdate(Convert.ToDateTime((monthno & "/01/" & Year(AccTo)))))
                Else
                    ddate = (objcmn.getlastdate(Convert.ToDateTime((monthno & "/01/" & Year(AccFrom)))))
                End If
            End If
            Return ddate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function datecheck(ByVal dateval As Date) As Boolean
        Dim bln As Boolean = True
        ''If dateval > AccTo Or dateval < AccFrom Then
        ''    bln = False
        ''End If
        Return bln
    End Function

    Sub enterkeypress(ByVal han As KeyPressEventArgs, ByVal frm As System.Windows.Forms.Form)
        If AscW(han.KeyChar) = 13 Then
            SendKeys.Send("{Tab}")
            han.KeyChar = ""
        End If
    End Sub

    Function SENDMSG(ByVal MSG As String, ByVal MOBILENO As String) As String
        'Try
        '    Dim objSMS As New routesmsdll.SMS
        '    If MOBILENO <> "" Then objSMS.MobileNo = MOBILENO

        '    Dim OBJCMN As New ClsCommon
        '    Dim DT As New DataTable

        '    If ClientName = "MOHAN" Then
        '        objSMS.UserName = "nako-mohanfab"
        '        objSMS.Password = "mohanfab"
        '        objSMS.Sender = "MKNITT"
        '    End If

        '    objSMS.Message = MSG
        '    objSMS.IpAddress = "103.16.101.52"
        '    objSMS.dlr = 1
        '    objSMS.MessageType = routesmsdll.MESSAGE_TYPE.mTEXT
        '    Dim response As String = objSMS.sendMessage()
        '    Return (response.ToString.Substring(0, 4))

        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Function

    Sub fillledger(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" acc_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID", " AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "ACC_cmpname"
                    If edit = False Then cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillname(ByRef cmbname As ComboBox, ByRef edit As Boolean, Optional ByVal CONDITION As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search("LEDGERS.ACC_ID, LEDGERS.ACC_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID ", " AND ISNULL(ACC_BLOCKED,'FALSE') = 'FALSE' and LEDGERS.ACC_cmpid=" & CmpId & " and LEDGERS.ACC_Locationid=" & Locationid & " and LEDGERS.ACC_Yearid=" & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DisplayMember = "ACC_cmpname"
                    cmbname.Text = ""
                End If
                cmbname.DataSource = dt
                cmbname.SelectedIndex = -1
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub filltransname(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal CONDITION As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" LEDGERS.ACC_ID, LEDGERS.ACC_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID ", " and LEDGERS.ACC_Yearid=" & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DisplayMember = "ACC_cmpname"
                    cmbname.Text = ""
                End If
                cmbname.DataSource = dt
                cmbname.SelectedIndex = -1
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLSACCODE(ByRef CMBSACCODE As ComboBox, ByRef edit As Boolean)
        Try
            If CMBSACCODE.Text.Trim = "" Then
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable = OBJCMN.search(" HSN_ITEMDESC ", "", " HSNMASTER ", " AND HSN_TYPE = 'Services' and HSN_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "HSN_ITEMDESC"
                    CMBSACCODE.DataSource = dt
                    CMBSACCODE.DisplayMember = "HSN_ITEMDESC"
                    If edit = False Then CMBSACCODE.Text = ""
                End If
                CMBSACCODE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub filldepartment(ByRef CMBDEPARTMENT As ComboBox, ByRef edit As Boolean)
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" DEPARTMENT_name ", "", " DEPARTMENTMaster", " and DEPARTMENT_cmpid=" & CmpId & " AND DEPARTMENT_LOCATIONID = " & Locationid & " AND DEPARTMENT_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "DEPARTMENT_name"
                    CMBDEPARTMENT.DataSource = dt
                    CMBDEPARTMENT.DisplayMember = "DEPARTMENT_name"
                    CMBDEPARTMENT.Text = ""
                End If
                CMBDEPARTMENT.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillQUALITY(ByRef CMBQUALITY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBQUALITY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" QUALITY_name ", "", " QUALITYMaster", " and QUALITY_cmpid=" & CmpId & " AND QUALITY_LOCATIONID = " & Locationid & " AND QUALITY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "QUALITY_name"
                    CMBQUALITY.DataSource = dt
                    CMBQUALITY.DisplayMember = "QUALITY_name"
                    CMBQUALITY.Text = ""
                End If
                CMBQUALITY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillEXPENSE(ByRef CMBEXPENSE As ComboBox, ByRef edit As Boolean)
        Try
            If CMBEXPENSE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" EXP_name ", "", " EXPENSEMaster", " and EXP_cmpid=" & CmpId & " AND EXP_LOCATIONID = " & Locationid & " AND EXP_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "EXP_name"
                    CMBEXPENSE.DataSource = dt
                    CMBEXPENSE.DisplayMember = "EXP_name"
                    CMBEXPENSE.Text = ""
                End If
                CMBEXPENSE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub filljobbername(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal CONDITION As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" LEDGERS.ACC_ID, LEDGERS.ACC_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID ", " and LEDGERS.ACC_cmpid=" & CmpId & " and LEDGERS.ACC_Locationid=" & Locationid & " and LEDGERS.ACC_Yearid=" & YearId & CONDITION)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "ACC_cmpname"
                    cmbname.ValueMember = "ACC_ID"
                    cmbname.Text = ""
                    'If edit = False Then cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub EXPENSEVALIDATE(ByRef CMBEXPENSENAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBEXPENSENAME.Text.Trim <> "" Then
                pcase(CMBEXPENSENAME)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("EXP_name", "", "EXPENSEMaster", " and EXP_name = '" & CMBEXPENSENAME.Text.Trim & "' AND EXP_CMPID = " & CmpId & " AND EXP_LOCATIONID = " & Locationid & " AND EXP_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBEXPENSENAME.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Expense not present, Add New?", MsgBoxStyle.YesNo, " ")
                    If tempmsg = vbYes Then
                        CMBEXPENSENAME.Text = a
                        'Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'EXPENSE MASTER'")
                        'If DTROW(0).Item(1) = False Then
                        '    MsgBox("Insufficient Rights")
                        '    Exit Sub
                        'End If
                        objyearmaster.saveexpense(CMBEXPENSENAME.Text.Trim, CmpId, Locationid, Userid, YearId, " and EXP_name = '" & CMBEXPENSENAME.Text.Trim & "' AND EXP_CMPID = " & CmpId & " AND EXP_LOCATIONID = " & Locationid & " AND EXP_YEARID = " & YearId)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillCATEGORY(ByRef CMBCATEGORY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBCATEGORY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" CATEGORY_name ", "", " CATEGORYMaster", " and CATEGORY_cmpid=" & CmpId & " AND CATEGORY_LOCATIONID = " & Locationid & " AND CATEGORY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "CATEGORY_name"
                    CMBCATEGORY.DataSource = dt
                    CMBCATEGORY.DisplayMember = "CATEGORY_name"
                    CMBCATEGORY.Text = ""
                End If
                CMBCATEGORY.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLSUBCATEGORY(ByRef CMBSUBCATEGORY As ComboBox, ByRef edit As Boolean)
        Try
            If CMBSUBCATEGORY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" SUBCATEGORY_name ", "", " SUBCATEGORYMaster", " and SUBCATEGORY_cmpid=" & CmpId & " AND SUBCATEGORY_LOCATIONID = " & Locationid & " AND SUBCATEGORY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "SUBCATEGORY_name"
                    CMBSUBCATEGORY.DisplayMember = "SUBCATEGORY_name"
                End If
                CMBSUBCATEGORY.DataSource = dt
                CMBSUBCATEGORY.SelectedIndex = -1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLFOLD(ByRef CMBFOLD As ComboBox, ByRef edit As Boolean)
        Try
            If CMBFOLD.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" FOLD_name ", "", " FOLDMaster", " and FOLD_cmpid=" & CmpId & " AND FOLD_LOCATIONID = " & Locationid & " AND FOLD_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "FOLD_name"
                    CMBFOLD.DisplayMember = "FOLD_name"
                End If
                CMBFOLD.DataSource = dt
                CMBFOLD.SelectedIndex = -1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillRATETYPE(ByRef CMBRATETYPE As ComboBox, ByRef edit As Boolean)
        Try
            If CMBRATETYPE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" RATETYPE_name ", "", " RATETYPEMaster", " and RATETYPE_cmpid=" & CmpId & " AND RATETYPE_LOCATIONID = " & Locationid & " AND RATETYPE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "RATETYPE_name"
                    CMBRATETYPE.DataSource = dt
                    CMBRATETYPE.DisplayMember = "RATETYPE_name"
                    If edit = False Then CMBRATETYPE.Text = ""
                End If
                CMBRATETYPE.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLPROCESS(ByRef CMBPROCESS As ComboBox, ByVal TYPE As String, ByRef edit As Boolean)
        Try
            If CMBPROCESS.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" PROCESS_name ", "", " PROCESSMASTER", TYPE & " and PROCESS_cmpid=" & CmpId & " AND PROCESS_LOCATIONID = " & Locationid & " AND PROCESS_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PROCESS_name"
                    CMBPROCESS.DataSource = dt
                    CMBPROCESS.DisplayMember = "PROCESS_name"
                    If edit = False Then CMBPROCESS.Text = ""
                End If
                CMBPROCESS.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillTPIname(ByRef cmbname As ComboBox, ByRef edit As Boolean)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" TPI_name ", "", "TpiMaster ", " and TPI_cmpid=" & CmpId & " and TPI_Locationid=" & Locationid & " and TPI_cmpid=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "TPI_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "TPI_name"
                    If edit = False Then cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLWEAVER(ByRef CMBWEAVER As ComboBox, ByRef edit As Boolean)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBWEAVER.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" WEAVER_name ", "", "WEAVERMaster ", " and WEAVER_YEARID=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "WEAVER_name"
                    CMBWEAVER.DataSource = dt
                    CMBWEAVER.DisplayMember = "WEAVER_name"
                    If edit = False Then CMBWEAVER.Text = ""
                End If
                CMBWEAVER.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillregister(ByRef cmbregister As ComboBox, ByVal condition As String)
        Try
            If cmbregister.Text.Trim = "" Then

                Dim objclscommon As New ClsCommon
                Dim dt As DataTable
                dt = objclscommon.search(" Register_name ", "", "RegisterMaster ", condition & " and Register_cmpid=" & CmpId & " and REGISTER_LOCATIONID = " & Locationid & " AND REGISTER_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Register_name"
                    cmbregister.DataSource = dt
                    cmbregister.DisplayMember = "Register_name"
                    cmbregister.Text = ""
                End If
                cmbregister.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TPIvalidate(ByRef cmbname As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim <> "" Then
                pcase(cmbname)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("TPI_id", "", "TPIMaster", " and TPI_name = '" & cmbname.Text.Trim & "' and TPI_cmpid = " & CmpId & " and TPI_Locationid = " & Locationid & " and TPI_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbname.Text.Trim
                    Dim tempmsg As Integer = MsgBox("TPI not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        cmbname.Text = a
                        Dim objTPImaster As New TPImaster
                        objTPImaster.txtname.Text = cmbname.Text.Trim()
                        objTPImaster.ShowDialog()
                        dt = objclscommon.search("TPI_name", "", "TPIMaster", " and TPI_name = '" & cmbname.Text.Trim & "' and TPI_cmpid = " & CmpId & " and TPI_Locationid = " & Locationid & " and TPI_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbname.DataSource
                            If cmbname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbname.Text.Trim)
                                    cmbname.Text = a
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

    Sub WEAVERvalidate(ByRef CMBWEAVER As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBWEAVER.Text.Trim <> "" Then
                uppercase(CMBWEAVER)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("WEAVER_id", "", "WEAVERMaster", " and WEAVER_NAME = '" & CMBWEAVER.Text.Trim & "' and WEAVER_cmpid = " & CmpId & " and WEAVER_LOCATIONid = " & Locationid & " and WEAVER_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("WEAVER not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBWEAVER.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsWEAVER As New ClsWeaverMaster
                        objclsWEAVER.alParaval = alParaval
                        Dim IntResult As Integer = objclsWEAVER.save()
                    Else
                        CMBWEAVER.Focus()
                        CMBWEAVER.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLPROCESSTYPE(ByRef CMBPROCESSTYPE As ComboBox, ByRef edit As Boolean)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBPROCESSTYPE.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" PROCESSTYPE_name ", "", "PROCESSTYPEMaster ", " and PROCESSTYPE_YEARID=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PROCESSTYPE_name"
                    CMBPROCESSTYPE.DataSource = dt
                    CMBPROCESSTYPE.DisplayMember = "PROCESSTYPE_name"
                    If edit = False Then CMBPROCESSTYPE.Text = ""
                End If
                CMBPROCESSTYPE.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PROCESSTYPEvalidate(ByRef CMBPROCESSTYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBPROCESSTYPE.Text.Trim <> "" Then
                uppercase(CMBPROCESSTYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("PROCESSTYPE_id", "", "PROCESSTYPEMaster", " and PROCESSTYPE_NAME = '" & CMBPROCESSTYPE.Text.Trim & "' and PROCESSTYPE_cmpid = " & CmpId & " and PROCESSTYPE_LOCATIONid = " & Locationid & " and PROCESSTYPE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("PROCESSTYPE not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPROCESSTYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsPROCESSTYPE As New ClsProcessTypeMaster
                        objclsPROCESSTYPE.alParaval = alParaval
                        Dim IntResult As Integer = objclsPROCESSTYPE.SAVE()
                    Else
                        CMBPROCESSTYPE.Focus()
                        CMBPROCESSTYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub namevalidate(ByRef cmbname As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox, ByVal WHERECLAUSE As String, Optional ByVal GROUPNAME As String = "", Optional ByVal TYPE As String = "ACCOUNTS", Optional ByRef TRANSNAME As String = "", Optional ByRef AGENTNAME As String = "", Optional ByRef WHATSAPPNO As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim <> "" Then
                uppercase(cmbname)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("LEDGERS.acc_add, isnull(LEDGERS.ACC_CODE,'') as CODE,LEDGERS_1.ACC_CMPNAME AS TRANSNAME,LEDGERS_2.ACC_CMPNAME AS AGENTNAME ", "", "    LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid ", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and LEDGERS.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.acc_YEARid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbname.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Ledger not present, Add New?", MsgBoxStyle.YesNo, "TEXPRO")
                    If tempmsg = vbYes Then
                        cmbname.Text = a
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsName = cmbname.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.tempTYPE = TYPE

                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("LEDGERS.acc_add, isnull(LEDGERS.ACC_CODE,'') as CODE,LEDGERS_1.ACC_CMPNAME AS TRANSNAME,LEDGERS_2.ACC_CMPNAME AS AGENTNAME, LEDGERS.ACC_ID AS ACCID ", "", "    LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid ", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and LEDGERS.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.acc_YEARid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbname.DataSource
                            If cmbname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ACCID"), cmbname.Text.Trim)
                                    cmbname.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    txtadd.Text = dt.Rows(0).Item(0).ToString
                    If TRANSNAME = "" Then TRANSNAME = dt.Rows(0).Item(2).ToString
                    If AGENTNAME = "" Then AGENTNAME = dt.Rows(0).Item(3).ToString
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub ledgervalidate(ByRef cmbname As ComboBox, ByVal CMBACCCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef txtadd As System.Windows.Forms.TextBox, ByVal WHERECLAUSE As String, Optional ByVal GROUPNAME As String = "", Optional ByVal TYPE As String = "ACCOUNTS", Optional ByRef TRANSNAME As String = "", Optional ByRef AGENTNAME As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim <> "" Then
                uppercase(cmbname)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("LEDGERS.acc_add, isnull(LEDGERS.ACC_CODE,'') as CODE,LEDGERS_1.ACC_CMPNAME AS TRANSNAME,LEDGERS_2.ACC_CMPNAME AS AGENTNAME ", "", "    LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid ", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and LEDGERS.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.acc_YEARid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbname.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Ledger not present, Add New?", MsgBoxStyle.YesNo, "TEXTRADE")
                    If tempmsg = vbYes Then
                        cmbname.Text = a
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsName = cmbname.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.tempTYPE = TYPE

                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("LEDGERS.acc_add, isnull(LEDGERS.ACC_CODE,'') as CODE,LEDGERS_1.ACC_CMPNAME AS TRANSNAME,LEDGERS_2.ACC_CMPNAME AS AGENTNAME, LEDGERS.ACC_ID AS ACCID ", "", "    LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_cmpid = GROUPMASTER.group_cmpid AND LEDGERS.Acc_locationid = GROUPMASTER.group_locationid AND LEDGERS.Acc_yearid = GROUPMASTER.group_yearid AND LEDGERS.Acc_groupid = GROUPMASTER.group_id LEFT OUTER JOIN LEDGERS AS LEDGERS_1 ON LEDGERS.ACC_TRANSID = LEDGERS_1.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_1.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_1.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_1.Acc_yearid LEFT OUTER JOIN LEDGERS AS LEDGERS_2 ON LEDGERS.ACC_AGENTID = LEDGERS_2.Acc_id AND LEDGERS.Acc_cmpid = LEDGERS_2.Acc_cmpid AND LEDGERS.Acc_locationid = LEDGERS_2.Acc_locationid AND LEDGERS.Acc_yearid = LEDGERS_2.Acc_yearid ", " and LEDGERS.acc_cmpname = '" & cmbname.Text.Trim & "' and LEDGERS.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.acc_YEARid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbname.DataSource
                            If cmbname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ACCID"), cmbname.Text.Trim)
                                    cmbname.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    txtadd.Text = dt.Rows(0).Item(0).ToString
                    If TRANSNAME = "" Then TRANSNAME = dt.Rows(0).Item(2).ToString
                    If AGENTNAME = "" Then AGENTNAME = dt.Rows(0).Item(3).ToString
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FORMvalidate(ByRef cmbform As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbform.Text.Trim <> "" Then
                pcase(cmbform)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("FORM_NAME", "", "FORMTYPE", " and FORM_NAME = '" & cmbform.Text.Trim & "' and FORM_cmpid = " & CmpId & " and FORM_Locationid = " & Locationid & " and FORM_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbform.Text.Trim
                    Dim tempmsg As Integer = MsgBox("FORM not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        cmbform.Text = a
                        Dim OBJFORM As New citymaster
                        OBJFORM.frmstring = "FORMTYPE"
                        OBJFORM.txtname.Text = cmbform.Text.Trim()
                        OBJFORM.ShowDialog()
                        dt = objclscommon.search("FORM_name", "", "FORMTYPE", " and FORM_name = '" & cmbform.Text.Trim & "' and FORM_cmpid = " & CmpId & " and FORM_Locationid = " & Locationid & " and FORM_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbform.DataSource
                            If cmbform.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbform.Text.Trim)
                                    cmbform.Text = a
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

    Sub TAXvalidate(ByRef CMBTAX As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBTAX.Text.Trim <> "" Then
                pcase(CMBTAX)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("TAX_NAME", "", "TAXMaster", " and TAX_NAME = '" & CMBTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBTAX.Text.Trim
                    Dim tempmsg As Integer = MsgBox("TAX not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        CMBTAX.Text = a
                        Dim OBJTAX As New Taxmaster
                        OBJTAX.txtname.Text = CMBTAX.Text.Trim()
                        OBJTAX.ShowDialog()
                        dt = objclscommon.search("TAX_name", "", "TAXMaster", " and TAX_name = '" & CMBTAX.Text.Trim & "' and TAX_cmpid = " & CmpId & " and TAX_Locationid = " & Locationid & " and TAX_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBTAX.DataSource
                            If CMBTAX.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBTAX.Text.Trim)
                                    CMBTAX.Text = a
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

    Sub DESIGNvalidate(ByRef CMBDESIGN As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, Optional ByVal MERCHANTNAME As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDESIGN.Text.Trim <> "" Then
                pcase(CMBDESIGN)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                Dim WHERE As String = ""
                If MERCHANTNAME <> "" Then WHERE = " AND ITEMMASTER.ITEM_NAME='" & MERCHANTNAME & "' "
                dt = objclscommon.search("DESIGN_NO ", "", " DESIGNRECIPE INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid ", WHERE & " and DESIGN_NO = '" & CMBDESIGN.Text.Trim & "' and DESIGN_cmpid = " & CmpId & " and DESIGN_Locationid = " & Locationid & " and DESIGN_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBDESIGN.Text.Trim
                    Dim tempmsg As Integer = MsgBox("DESIGN not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        CMBDESIGN.Text = a
                        Dim OBJDESIGN As New DesignRecipe
                        OBJDESIGN.TEMPDESIGNNO = CMBDESIGN.Text.Trim()
                        OBJDESIGN.TEMPMERCHANT = MERCHANTNAME
                        OBJDESIGN.ShowDialog()
                        dt = objclscommon.search("DESIGN_NO ", "", "  DESIGNRECIPE INNER JOIN ITEMMASTER ON DESIGNRECIPE.DESIGN_ITEMID = ITEMMASTER.item_id AND DESIGNRECIPE.DESIGN_CMPID = ITEMMASTER.item_cmpid AND DESIGNRECIPE.DESIGN_LOCATIONID = ITEMMASTER.item_locationid AND DESIGNRECIPE.DESIGN_YEARID = ITEMMASTER.item_yearid ", WHERE & " and DESIGN_NO = '" & CMBDESIGN.Text.Trim & "' and DESIGN_cmpid = " & CmpId & " and DESIGN_Locationid = " & Locationid & " and DESIGN_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBDESIGN.DataSource
                            If CMBDESIGN.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBDESIGN.Text.Trim)
                                    CMBDESIGN.Text = a
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

    Sub dyeingvalidate(ByRef CMBdyeing As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBdyeing.Text.Trim <> "" Then
                pcase(CMBdyeing)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("dyeing_NO", "", "dyeingRECIPE", " and dyeing_NO = '" & CMBdyeing.Text.Trim & "' and dyeing_cmpid = " & CmpId & " and dyeing_Locationid = " & Locationid & " and dyeing_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBdyeing.Text.Trim
                    Dim tempmsg As Integer = MsgBox("dyeing not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        CMBdyeing.Text = a
                        Dim OBJdyeing As New DyeingRecipe
                        OBJdyeing.TEMPDYEINGNO = CMBdyeing.Text.Trim()
                        OBJdyeing.ShowDialog()
                        dt = objclscommon.search("dyeing_NO", "", "dyeingRECIPE", " and dyeing_NO = '" & CMBdyeing.Text.Trim & "' and dyeing_cmpid = " & CmpId & " and dyeing_Locationid = " & Locationid & " and dyeing_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBdyeing.DataSource
                            If CMBdyeing.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBdyeing.Text.Trim)
                                    CMBdyeing.Text = a
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

    Sub DEPARTMENTVALIDATE(ByRef CMBDEPARTMENT As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDEPARTMENT.Text.Trim <> "" Then
                uppercase(CMBDEPARTMENT)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("DEPARTMENT_id", "", "DEPARTMENTMaster", " and DEPARTMENT_NAME = '" & CMBDEPARTMENT.Text.Trim & "' and DEPARTMENT_cmpid = " & CmpId & " and DEPARTMENT_LOCATIONid = " & Locationid & " and DEPARTMENT_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("DEPARTMENT not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBDEPARTMENT.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)
                        alParaval.Add(0)    'INVENTORY

                        Dim objclsDEPARTMENT As New ClsDepartmentMaster
                        objclsDEPARTMENT.alParaval = alParaval
                        Dim IntResult As Integer = objclsDEPARTMENT.save()
                    Else
                        CMBDEPARTMENT.Focus()
                        CMBDEPARTMENT.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLNATURE(ByRef CMBNATURE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" PAY_name ", "", " NATUREOFPAYMENTMaster", "")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "PAY_name"
                CMBNATURE.DataSource = dt
                CMBNATURE.DisplayMember = "PAY_name"
                CMBNATURE.Text = ""
            End If
            CMBNATURE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub NATUREVALIDATE(ByRef CMBNATURE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBNATURE.Text.Trim <> "" Then
                uppercase(CMBNATURE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("PAY_id", "", "NATUREOFPAYMENTMASTER", " and PAY_NAME = '" & CMBNATURE.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("NATURE OF PAYMENT not present, Add New?", MsgBoxStyle.YesNo, "Hospitality")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBNATURE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim OBJNATUREOFPAYMENT As New ClsNatureOfPayment
                        OBJNATUREOFPAYMENT.alParaval = alParaval
                        Dim IntResult As Integer = OBJNATUREOFPAYMENT.SAVE()
                    Else
                        CMBNATURE.Focus()
                        CMBNATURE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillDEDUCTEETYPE(ByRef cmbDEDUCTEE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" DEDUCTEETYPE_name ", "", " DEDUCTEETYPEMaster", "")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "DEDUCTEETYPE_name"
                cmbDEDUCTEE.DataSource = dt
                cmbDEDUCTEE.DisplayMember = "DEDUCTEETYPE_name"
                cmbDEDUCTEE.Text = ""
            End If
            cmbDEDUCTEE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub DEDUCTEETYPEVALIDATE(ByRef CMBDEDUCTEETYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDEDUCTEETYPE.Text.Trim <> "" Then
                uppercase(CMBDEDUCTEETYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("DEDUCTEETYPE_id", "", "DEDUCTEETYPEMASTER", " and DEDUCTEETYPE_NAME = '" & CMBDEDUCTEETYPE.Text.Trim & "'")
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("DEDUCTEETYPE not present, Add New?", MsgBoxStyle.YesNo, "Hospitality")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBDEDUCTEETYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsDEDUCTEETYPE As New ClsDeducteetypeMaster
                        objclsDEDUCTEETYPE.alParaval = alParaval
                        Dim IntResult As Integer = objclsDEDUCTEETYPE.SAVE()
                    Else
                        CMBDEDUCTEETYPE.Focus()
                        CMBDEDUCTEETYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub QUALITYVALIDATE(ByRef CMBQUALITY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBQUALITY.Text.Trim <> "" Then
                uppercase(CMBQUALITY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("QUALITY_id", "", "QUALITYMaster", " and QUALITY_NAME = '" & CMBQUALITY.Text.Trim & "' and QUALITY_cmpid = " & CmpId & " and QUALITY_LOCATIONid = " & Locationid & " and QUALITY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("QUALITY not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBQUALITY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)
                        alParaval.Add(CMBQUALITY.Text.Trim) 'OURQUALITYID
                        alParaval.Add("")       'category

                        Dim objclsQUALITY As New ClsQualityMaster
                        objclsQUALITY.alParaval = alParaval
                        Dim IntResult As Integer = objclsQUALITY.save()
                    Else
                        CMBQUALITY.Focus()
                        CMBQUALITY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PARTYGROUPVALIDATE(ByRef CMBPARTYGROUP As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBPARTYGROUP.Text.Trim <> "" Then
                uppercase(CMBPARTYGROUP)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PG_id", "", "PARTYGROUPMaster", " and PG_NAME = '" & CMBPARTYGROUP.Text.Trim & "' and PG_cmpid = " & CmpId & " and PG_LOCATIONid = " & Locationid & " and PG_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Party Group not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPARTYGROUP.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsparty As New ClsPartyGroupMaster
                        objclsparty.alParaval = alParaval
                        Dim IntResult As Integer = objclsparty.save()
                    Else
                        CMBPARTYGROUP.Focus()
                        CMBPARTYGROUP.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub CATEGORYVALIDATE(ByRef CMBCATEGORY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCATEGORY.Text.Trim <> "" Then
                uppercase(CMBCATEGORY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("CATEGORY_id", "", "CATEGORYMaster", " and CATEGORY_NAME = '" & CMBCATEGORY.Text.Trim & "' and CATEGORY_cmpid = " & CmpId & " and CATEGORY_LOCATIONid = " & Locationid & " and CATEGORY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("CATEGORY not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBCATEGORY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsCATEGORY As New ClsCategoryMaster
                        objclsCATEGORY.alParaval = alParaval
                        Dim IntResult As Integer = objclsCATEGORY.save()
                    Else
                        CMBCATEGORY.Focus()
                        CMBCATEGORY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SUBCATEGORYVALIDATE(ByRef CMBSUBCATEGORY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSUBCATEGORY.Text.Trim <> "" Then
                uppercase(CMBSUBCATEGORY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("SUBCATEGORY_id", "", "SUBCATEGORYMaster", " and SUBCATEGORY_NAME = '" & CMBSUBCATEGORY.Text.Trim & "' and SUBCATEGORY_cmpid = " & CmpId & " and SUBCATEGORY_LOCATIONid = " & Locationid & " and SUBCATEGORY_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("SUBCATEGORY not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBSUBCATEGORY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsSUBCATEGORY As New ClsSubCategoryMaster
                        objclsSUBCATEGORY.alParaval = alParaval
                        Dim IntResult As Integer = objclsSUBCATEGORY.save()
                    Else
                        CMBSUBCATEGORY.Focus()
                        CMBSUBCATEGORY.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FOLDVALIDATE(ByRef CMBFOLD As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBFOLD.Text.Trim <> "" Then
                uppercase(CMBFOLD)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("FOLD_id", "", "FOLDMaster", " and FOLD_NAME = '" & CMBFOLD.Text.Trim & "' and FOLD_cmpid = " & CmpId & " and FOLD_LOCATIONid = " & Locationid & " and FOLD_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("FOLD not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBFOLD.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsFOLD As New ClsFoldMaster
                        objclsFOLD.alParaval = alParaval
                        Dim IntResult As Integer = objclsFOLD.save()
                    Else
                        CMBFOLD.Focus()
                        CMBFOLD.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub RATETYPEVALIDATE(ByRef CMBRATETYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBRATETYPE.Text.Trim <> "" Then
                uppercase(CMBRATETYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("RATETYPE_id", "", "RATETYPEMaster", " and RATETYPE_NAME = '" & CMBRATETYPE.Text.Trim & "' and RATETYPE_cmpid = " & CmpId & " and RATETYPE_LOCATIONid = " & Locationid & " and RATETYPE_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("RATETYPE not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBRATETYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsRATETYPE As New ClsRateTypeMaster
                        objclsRATETYPE.alParaval = alParaval
                        Dim IntResult As Integer = objclsRATETYPE.save()
                    Else
                        CMBRATETYPE.Focus()
                        CMBRATETYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub OCTROIvalidate(ByRef CMBOCTROI As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBOCTROI.Text.Trim <> "" Then
                pcase(CMBOCTROI)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("OCTROI_NAME,OCTROI_octroi", "", "OCTROIMaster", " and OCTROI_NAME = '" & CMBOCTROI.Text.Trim & "' and OCTROI_cmpid = " & CmpId & " and OCTROI_Locationid = " & Locationid & " and OCTROI_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBOCTROI.Text.Trim
                    Dim tempmsg As Integer = MsgBox("OCTROI not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        CMBOCTROI.Text = a
                        Dim OBJOCTROI As New UnitMaster
                        OBJOCTROI.frmString = "OCTROIMASTER"
                        OBJOCTROI.txtname.Text = CMBOCTROI.Text.Trim()
                        OBJOCTROI.ShowDialog()
                        dt = objclscommon.search("OCTROI_name", "", "OCTROIMaster", " and OCTROI_name = '" & CMBOCTROI.Text.Trim & "' and OCTROI_cmpid = " & CmpId & " and OCTROI_Locationid = " & Locationid & " and OCTROI_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBOCTROI.DataSource
                            If CMBOCTROI.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBOCTROI.Text.Trim)
                                    CMBOCTROI.Text = a
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

    Sub fillitemname(ByRef cmbitemname As ComboBox, ByVal CONDITION As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            dt = objclscommon.search(" item_name ", "", " itemMaster inner join MaterialTypeMaster on MaterialTypeMaster.Material_id = ItemMaster.Item_materialtypeid LEFT OUTER JOIN CATEGORYMASTER ON ITEM_CATEGORYID = CATEGORY_ID", CONDITION & " AND ISNULL(ITEMMASTER.ITEM_BLOCKED,0) = 0 and item_Yearid=" & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "item_name"
                cmbitemname.DataSource = dt
                cmbitemname.DisplayMember = "item_name"
                cmbitemname.Text = ""
                uppercase(cmbitemname)
            End If
            cmbitemname.SelectAll()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillunit(ByRef cmbunit As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbunit.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" unit_abbr ", "", " UnitMaster ", " and unit_cmpid=" & CmpId & " and unit_Locationid=" & Locationid & " and unit_Yearid=" & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "unit_abbr"
                    cmbunit.DataSource = dt
                    cmbunit.DisplayMember = "unit_abbr"
                    cmbunit.Text = ""
                End If
                cmbunit.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub itemvalidate(ByRef cmbitemname As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByVal CONDITION As String, ByVal FRMSTRING As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbitemname.Text.Trim <> "" Then
                uppercase(cmbitemname)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("item_name", "", " itemMaster inner join MaterialTypeMaster on MaterialTypeMaster.Material_id = ItemMaster.Item_materialtypeid and MaterialTypeMaster.Material_cmpid = ItemMaster.Item_cmpid and MaterialTypeMaster.Material_Locationid = ItemMaster.Item_Locationid and MaterialTypeMaster.Material_Yearid = ItemMaster.Item_Yearid ", CONDITION & " and  item_name = '" & cmbitemname.Text.Trim & "' and item_cmpid = " & CmpId & " and item_Locationid = " & Locationid & " and item_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbitemname.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Item not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        cmbitemname.Text = a
                        Dim objitemmaster As New ItemMaster
                        objitemmaster.tempItemName = cmbitemname.Text.Trim()
                        If FRMSTRING = "" Then FRMSTRING = "MERCHANT"
                        objitemmaster.frmstring = FRMSTRING
                        objitemmaster.ShowDialog()
                        dt = objclscommon.search("item_name", "", " itemMaster inner join MaterialTypeMaster on MaterialTypeMaster.Material_id = ItemMaster.Item_materialtypeid and MaterialTypeMaster.Material_cmpid = ItemMaster.Item_cmpid and MaterialTypeMaster.Material_Locationid = ItemMaster.Item_Locationid and MaterialTypeMaster.Material_Yearid = ItemMaster.Item_Yearid ", CONDITION & " and  item_name = '" & cmbitemname.Text.Trim & "' and item_cmpid = " & CmpId & " and item_Locationid = " & Locationid & " and item_Yearid = " & YearId)
                        'dt = objclscommon.search("item_name", "", "itemMaster", " and item_name = '" & cmbitemname.Text.Trim & "' and item_cmpid = " & CmpId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbitemname.DataSource
                            If cmbitemname.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbitemname.Text.Trim)
                                    cmbitemname.Text = a
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

    Sub unitvalidate(ByRef cmbunit As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            Cursor.Current = Cursors.WaitCursor
            If cmbunit.Text.Trim <> "" Then
                lowercase(cmbunit)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" unit_abbr ", "", "UnitMaster", " and unit_abbr = '" & cmbunit.Text.Trim & "' and unit_cmpid = " & CmpId & " and unit_Locationid = " & Locationid & " and unit_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = cmbunit.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Unit not present, Add New?", MsgBoxStyle.YesNo, "Tex Pro")
                    If tempmsg = vbYes Then
                        cmbunit.Text = a
                        Dim objunitmaster As New UnitMaster
                        objunitmaster.frmString = "UNIT"
                        objunitmaster.txtabbr.Text = cmbunit.Text.Trim()
                        objunitmaster.ShowDialog()
                        dt = objclscommon.search(" unit_abbr ", "", "UnitMaster", " and unit_abbr = '" & cmbunit.Text.Trim & "' and unit_cmpid = " & CmpId & " and unit_Locationid = " & Locationid & " and unit_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = cmbunit.DataSource
                            If cmbunit.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(cmbunit.Text.Trim)
                                    cmbunit.Text = a
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

    Sub ACCCODEVALIDATE(ByRef CMBCODE As ComboBox, ByVal CMBACCNAME As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form, ByRef TXTADD As System.Windows.Forms.TextBox, Optional ByVal WHERECLAUSE As String = "", Optional ByVal GROUPNAME As String = "")
        Try
            If CMBCODE.Text.Trim <> "" Then
                pcase(CMBCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("acc_CMPNAME, ACC_ADD", "", "Ledgers inner join groupmaster on groupmaster.group_id = ledgers.acc_groupid and groupmaster.group_cmpid = ledgers.acc_cmpid and groupmaster.group_locationid = ledgers.acc_locationid and groupmaster.group_yearid = ledgers.acc_yearid", " and acc_cODE = '" & CMBCODE.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & WHERECLAUSE)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Ledger not present, Add New?", MsgBoxStyle.YesNo, "")
                    If tempmsg = vbYes Then
                        Dim objVendormaster As New AccountsMaster
                        objVendormaster.frmstring = "ACCOUNTS"
                        objVendormaster.tempAccountsCode = CMBCODE.Text.Trim()
                        objVendormaster.TEMPGROUPNAME = GROUPNAME
                        objVendormaster.ShowDialog()
                        dt = objclscommon.search("ACC_CODE", "", "Ledgers inner join groupmaster on groupmaster.group_id = ledgers.acc_groupid and groupmaster.group_cmpid = ledgers.acc_cmpid and groupmaster.group_locationid = ledgers.acc_locationid and groupmaster.group_yearid = ledgers.acc_yearid", " and acc_cODE = '" & CMBCODE.Text.Trim & "' and acc_cmpid = " & CmpId & " and acc_LOCATIONid = " & Locationid & " and acc_YEARid = " & YearId & WHERECLAUSE)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As DataTable
                            Dim a As String = CMBCODE.Text.Trim
                            dt1 = CMBCODE.DataSource
                            If CMBCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBCODE.Text.Trim)
                                    CMBCODE.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                Else
                    CMBACCNAME.Text = dt.Rows(0).Item(0)
                    TXTADD.Text = dt.Rows(0).Item(1)
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub fillACCCODE(ByRef CMBCODE As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" ACC_CODE ", "", " LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID ", " and ACC_cmpid=" & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & CONDITION)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "ACC_CODE"
                CMBCODE.DataSource = dt
                CMBCODE.DisplayMember = "ACC_CODE"
                CMBCODE.Text = ""
            End If
            CMBCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillagentledger(ByRef cmbname As ComboBox, ByRef edit As Boolean, ByVal WHERECLAUSE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search("ACC_ID, acc_cmpname ", "", "LEDGERS INNER JOIN GROUPMASTER ON GROUP_ID = ACC_GROUPID AND GROUP_CMPID = ACC_CMPID AND GROUP_LOCATIONID = ACC_LOCATIONID AND GROUP_YEARID = ACC_YEARID", " AND ACC_CMPID = " & CmpId & " AND ACC_LOCATIONID = " & Locationid & " AND ACC_YEARID = " & YearId & WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ACC_cmpname"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "ACC_cmpname"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub HSNITEMDESCVALIDATE(ByRef CMBHSNCODE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBHSNCODE.Text.Trim <> "" Then
                uppercase(CMBHSNCODE)
                Dim OBJCMN As New ClsCommonMaster
                Dim dt As DataTable
                dt = OBJCMN.search("   ISNULL(HSN_CODE, '') AS HSNCODE", "", "  HSNMASTER ", "and  HSN_CODE = '" & CMBHSNCODE.Text.Trim & "' and HSN_Yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBHSNCODE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("HSN/SAC Code Not present, Add New?", MsgBoxStyle.YesNo, CmpName)
                    If tempmsg = vbYes Then
                        CMBHSNCODE.Text = a
                        Dim OBJDELIVERY As New HSNMaster
                        OBJDELIVERY.tempHSNCODE = CMBHSNCODE.Text.Trim()

                        OBJDELIVERY.ShowDialog()
                        dt = OBJCMN.search("   ISNULL(HSN_CODE, '') AS HSNCODE", "", "  HSNMASTER ", " and  HSN_CODE = '" & CMBHSNCODE.Text.Trim & "' and HSN_Yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBHSNCODE.DataSource
                            If CMBHSNCODE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBHSNCODE.Text.Trim)
                                    CMBHSNCODE.Text = a
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
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillTERM(ByRef CMBTERM As ComboBox, ByRef edit As Boolean)
        Try
            If CMBTERM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                Dim WHERECLAUSE As String = ""
                dt = objclscommon.search(" TERM_NAME ", "", "TERMMaster", WHERECLAUSE & " and TERM_cmpid=" & CmpId & " AND TERM_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "TERM_NAME"
                    CMBTERM.DataSource = dt
                    CMBTERM.DisplayMember = "TERM_NAME"
                    If edit = False Then CMBTERM.Text = ""
                End If
                CMBTERM.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TERMVALIDATE(ByRef CMBTERM As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBTERM.Text.Trim <> "" Then
                uppercase(CMBTERM)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" TERM_NAME ", "", " TERMMASTER", " and TERM_NAME = '" & CMBTERM.Text.Trim & "' and TERM_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Term not present, Add New?", MsgBoxStyle.YesNo, "TEXTRADE")
                    If tempmsg = vbYes Then
                        Dim a As String = CMBTERM.Text.Trim
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBTERM.Text.Trim)
                        alParaval.Add(0)    'CRDAYS
                        alParaval.Add(0)    'OTHER PER
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)


                        Dim objRACK As New ClsTermMaster
                        objRACK.alParaval = alParaval
                        Dim IntResult As Integer = objRACK.SAVE()


                        dt = objclscommon.search(" TERM_ID AS ID, TERM_NAME AS NAME ", "", " TERMMASTER", " and TERM_NAME = '" & CMBTERM.Text.Trim & "' and TERM_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBTERM.DataSource
                            If CMBTERM.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ID"), CMBTERM.Text.Trim)
                                    CMBTERM.Text = a
                                End If
                            End If
                        End If

                    Else
                        CMBTERM.Focus()
                        CMBTERM.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If


        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLGROUPCOMPANY(ByRef CMBGRPCOMPANY As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGRPCOMPANY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" GOC_ID AS ID , GOC_NAME AS NAME ", "", "GROUPOFCOMPANIESMASTER", " And GOC_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "NAME"
                    CMBGRPCOMPANY.DataSource = dt
                    CMBGRPCOMPANY.DisplayMember = "NAME"
                    CMBGRPCOMPANY.ValueMember = "ID"
                    CMBGRPCOMPANY.SelectedItem = Nothing
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub GROUPCOMPANYVALIDATE(ByRef CMBGRPCOMPANY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBGRPCOMPANY.Text.Trim <> "" Then
                uppercase(CMBGRPCOMPANY)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" GOC_NAME ", "", " GROUPOFCOMPANIESMASTER ", " and GOC_NAME = '" & CMBGRPCOMPANY.Text.Trim & "' and GOC_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Company not present, Add New?", MsgBoxStyle.YesNo, "TEXTRADE")
                    If tempmsg = vbYes Then
                        Dim a As String = CMBGRPCOMPANY.Text.Trim
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBGRPCOMPANY.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)


                        Dim objRACK As New ClsGroupOfCompanies
                        objRACK.alParaval = alParaval
                        Dim IntResult As Integer = objRACK.SAVE()


                        dt = objclscommon.search(" GOC_ID AS ID, GOC_NAME AS NAME ", "", " GROUPOFCOMPANIESMASTER", " and GOC_NAME = '" & CMBGRPCOMPANY.Text.Trim & "' and GOC_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBGRPCOMPANY.DataSource
                            If CMBGRPCOMPANY.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ID"), CMBGRPCOMPANY.Text.Trim)
                                    CMBGRPCOMPANY.Text = a
                                End If
                            End If
                        End If

                    Else
                        CMBGRPCOMPANY.Focus()
                        CMBGRPCOMPANY.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLGODOWN(ByRef CMBGODOWN As ComboBox, ByRef edit As Boolean)
        Try
            If CMBGODOWN.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                Dim WHERECLAUSE As String = ""
                dt = objclscommon.search(" GODOWN_name ", "", " GODOWNMaster", WHERECLAUSE & " AND GODOWN_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "GODOWN_name"
                    CMBGODOWN.DataSource = dt
                    CMBGODOWN.DisplayMember = "GODOWN_name"
                    If edit = False Then CMBGODOWN.Text = ""
                End If
                CMBGODOWN.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GODOWNVALIDATE(ByRef CMBGODOWN As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGODOWN.Text.Trim <> "" Then
                uppercase(CMBGODOWN)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("GODOWN_id", "", "GODOWNMaster", " and GODOWN_NAME = '" & CMBGODOWN.Text.Trim & "' and GODOWN_cmpid = " & CmpId & " and GODOWN_LOCATIONid = " & Locationid & " and GODOWN_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("GODOWN not present, Add New?", MsgBoxStyle.YesNo, "TEXTRADE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(UCase(CMBGODOWN.Text.Trim))
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objclsGODOWN As New ClsGodownMaster
                        objclsGODOWN.alParaval = alParaval
                        Dim IntResult As Integer = objclsGODOWN.save()
                    Else
                        CMBGODOWN.Focus()
                        CMBGODOWN.SelectAll()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLPACKINGTYPE(ByRef CMBGRPCOMPANY As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBGRPCOMPANY.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" PACKINGTYPE_ID AS ID , PACKINGTYPE_NAME AS NAME ", "", "PACKINGTYPEMASTER", " And PACKINGTYPE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "NAME"
                    CMBGRPCOMPANY.DataSource = dt
                    CMBGRPCOMPANY.DisplayMember = "NAME"
                    CMBGRPCOMPANY.ValueMember = "ID"
                    CMBGRPCOMPANY.SelectedItem = Nothing
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PACKINGTYPEVALIDATE(ByRef CMBPACKINGTYPE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBPACKINGTYPE.Text.Trim <> "" Then
                uppercase(CMBPACKINGTYPE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PACKINGTYPE_NAME ", "", " PACKINGTYPEMASTER ", " and PACKINGTYPE_NAME = '" & CMBPACKINGTYPE.Text.Trim & "' and PACKINGTYPE_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("Packing Type not present, Add New?", MsgBoxStyle.YesNo, "TEXTRADE")
                    If tempmsg = vbYes Then
                        Dim a As String = CMBPACKINGTYPE.Text.Trim
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPACKINGTYPE.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(0)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objRACK As New ClsPackingTypeMaster
                        objRACK.alParaval = alParaval
                        Dim IntResult As Integer = objRACK.save()


                        dt = objclscommon.search(" PACKINGTYPE_ID AS ID, PACKINGTYPE_NAME AS NAME ", "", " PACKINGTYPEMASTER", " and PACKINGTYPE_NAME = '" & CMBPACKINGTYPE.Text.Trim & "' and PACKINGTYPE_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBPACKINGTYPE.DataSource
                            If CMBPACKINGTYPE.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("ID"), CMBPACKINGTYPE.Text.Trim)
                                    CMBPACKINGTYPE.Text = a
                                End If
                            End If
                        End If

                    Else
                        CMBPACKINGTYPE.Focus()
                        CMBPACKINGTYPE.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLBANK(ByRef CMBBANK As ComboBox)
        Try
            If CMBBANK.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PARTYBANK_name ", "", " PARTYBANKMaster ", " and PARTYBANK_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "PARTYBANK_name"
                    CMBBANK.DataSource = dt
                    CMBBANK.DisplayMember = "PARTYBANK_name"
                    CMBBANK.Text = ""
                End If
                CMBBANK.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PARTYBANKvalidate(ByRef CMBPARTYBANK As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try

            If CMBPARTYBANK.Text.Trim <> "" Then
                uppercase(CMBPARTYBANK)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" PARTYBANK_name ", "", "PARTYBANKMaster", " and PARTYBANK_name = '" & CMBPARTYBANK.Text.Trim & "' and PARTYBANK_cmpid = " & CmpId & " and PARTYBANK_locationid = " & Locationid & " and PARTYBANK_yearid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim tempmsg As Integer = MsgBox("PARTYBANK Name not present, Add New?", MsgBoxStyle.YesNo, "BROKERMATE")
                    If tempmsg = vbYes Then
                        Dim alParaval As New ArrayList

                        alParaval.Add(CMBPARTYBANK.Text.Trim)
                        alParaval.Add("")
                        alParaval.Add(CmpId)
                        alParaval.Add(Locationid)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)
                        alParaval.Add(0)

                        Dim objPIECETYPE As New ClsPARTYBANKMaster
                        objPIECETYPE.alParaval = alParaval
                        Dim IntResult As Integer = objPIECETYPE.save()
                        'e.Cancel = True
                    Else
                        CMBPARTYBANK.Focus()
                        CMBPARTYBANK.SelectAll()
                        e.Cancel = True
                    End If
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLSALESMAN(ByRef CMBSALESMAN As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSALESMAN.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" SALESMAN_NAME ", "", " SALESMANMASTER ", " AND SALESMAN_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "SALESMAN_NAME"
                    CMBSALESMAN.DataSource = dt
                    CMBSALESMAN.DisplayMember = "SALESMAN_NAME"
                    CMBSALESMAN.Text = ""
                End If
                CMBSALESMAN.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SALESMANVALIDATE(ByRef CMBSALESMAN As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSALESMAN.Text.Trim <> "" Then
                uppercase(CMBSALESMAN)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search(" SALESMAN_NAME ", "", " SALESMANMASTER ", " AND SALESMAN_NAME = '" & CMBSALESMAN.Text.Trim & "' AND SALESMAN_YEARid = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBSALESMAN.Text.Trim
                    Dim tempmsg As Integer = MsgBox("Salesman not present, Add New?", MsgBoxStyle.YesNo, "TEXTRADE")
                    If tempmsg = vbYes Then
                        CMBSALESMAN.Text = a
                        Dim OBJSALES As New SalesmanMaster
                        OBJSALES.TEMPNAME = CMBSALESMAN.Text.Trim()
                        OBJSALES.ShowDialog()
                        dt = objclscommon.search(" SALESMAN_NAME ", "", " SALESMANMASTER ", " AND SALESMAN_NAME = '" & CMBSALESMAN.Text.Trim & "' AND SALESMAN_YEARid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBSALESMAN.DataSource
                            If CMBSALESMAN.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(CMBSALESMAN.Text.Trim)
                                    CMBSALESMAN.Text = a
                                End If
                            End If
                        End If
                        e.Cancel = True
                    Else
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            GoTo line1
            Throw ex
        End Try
    End Sub

    Sub FILLDISCOUNT(ByRef CMBDISCOUNT As ComboBox)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBDISCOUNT.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" DISC_NAME ", "", " DISCOUNTMASTER ", " AND DISC_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "DISC_NAME"
                    CMBDISCOUNT.DataSource = dt
                    CMBDISCOUNT.DisplayMember = "DISC_NAME"
                    CMBDISCOUNT.Text = ""
                End If
                CMBDISCOUNT.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#Region "FUNCTION FOR LOCATION"

    Sub fillcity(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" city_name ", "", " CityMaster", " and city_cmpid=" & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "city_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "city_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CITYVALIDATE(ByRef CMBCITY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCITY.Text.Trim <> "" Then
                pcase(CMBCITY)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("city_name", "", "CityMaster", " and city_name = '" & CMBCITY.Text.Trim & "' AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBCITY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("City not present, Add New?", MsgBoxStyle.YesNo, " ")
                    If tempmsg = vbYes Then
                        CMBCITY.Text = a
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        objyearmaster.savecity(CMBCITY.Text.Trim, CmpId, Locationid, Userid, YearId, " and city_name = '" & CMBCITY.Text.Trim & "' AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLAREA(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" AREA_name ", "", " AREAMaster", " and AREA_cmpid=" & CmpId & " AND AREA_LOCATIONID = " & Locationid & " AND AREA_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "AREA_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "AREA_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub AREAVALIDATE(ByRef CMBAREA As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBAREA.Text.Trim <> "" Then
                pcase(CMBAREA)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("AREA_name", "", "AREAMaster", " and AREA_name = '" & CMBAREA.Text.Trim & "' AND AREA_CMPID = " & CmpId & " AND AREA_LOCATIONID = " & Locationid & " AND AREA_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBAREA.Text.Trim
                    Dim tempmsg As Integer = MsgBox("AREA not present, Add New?", MsgBoxStyle.YesNo, " ")
                    If tempmsg = vbYes Then
                        CMBAREA.Text = a
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        objyearmaster.savearea(CMBAREA.Text.Trim, CmpId, Locationid, Userid, YearId, " and AREA_name = '" & CMBAREA.Text.Trim & "' AND AREA_CMPID = " & CmpId & " AND AREA_LOCATIONID = " & Locationid & " AND AREA_YEARID = " & YearId)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillCOUNTRY(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" COUNTRY_name ", "", " COUNTRYMaster", " and COUNTRY_cmpid=" & CmpId & " AND COUNTRY_LOCATIONID = " & Locationid & " AND COUNTRY_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "COUNTRY_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "COUNTRY_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub COUNTRYVALIDATE(ByRef CMBCOUNTRY As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBCOUNTRY.Text.Trim <> "" Then
                pcase(CMBCOUNTRY)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("COUNTRY_name", "", "COUNTRYMaster", " and COUNTRY_name = '" & CMBCOUNTRY.Text.Trim & "' AND COUNTRY_CMPID = " & CmpId & " AND COUNTRY_LOCATIONID = " & Locationid & " AND COUNTRY_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBCOUNTRY.Text.Trim
                    Dim tempmsg As Integer = MsgBox("COUNTRY not present, Add New?", MsgBoxStyle.YesNo, " ")
                    If tempmsg = vbYes Then
                        CMBCOUNTRY.Text = a
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        objyearmaster.savecountry(CMBCOUNTRY.Text.Trim, CmpId, Locationid, Userid, YearId, " and COUNTRY_name = '" & CMBCOUNTRY.Text.Trim & "' AND COUNTRY_CMPID = " & CmpId & " AND COUNTRY_LOCATIONID = " & Locationid & " AND COUNTRY_YEARID = " & YearId)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillSTATE(ByRef cmbname As ComboBox)
        Try
            If cmbname.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" STATE_name ", "", " STATEMaster", " and STATE_cmpid=" & CmpId & " AND STATE_LOCATIONID = " & Locationid & " AND STATE_YEARID = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "STATE_name"
                    cmbname.DataSource = dt
                    cmbname.DisplayMember = "STATE_name"
                    cmbname.Text = ""
                End If
                cmbname.SelectAll()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub STATEVALIDATE(ByRef CMBSTATE As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBSTATE.Text.Trim <> "" Then
                pcase(CMBSTATE)
                Dim objclscommon As New ClsCommonMaster
                Dim objyearmaster As New ClsYearMaster
                Dim dt As DataTable
                dt = objclscommon.search("STATE_name", "", "STATEMaster", " and STATE_name = '" & CMBSTATE.Text.Trim & "' AND STATE_CMPID = " & CmpId & " AND STATE_LOCATIONID = " & Locationid & " AND STATE_YEARID = " & YearId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBSTATE.Text.Trim
                    Dim tempmsg As Integer = MsgBox("STATE not present, Add New?", MsgBoxStyle.YesNo, " ")
                    If tempmsg = vbYes Then
                        CMBSTATE.Text = a
                        Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'LOCATION MASTER'")
                        If DTROW(0).Item(1) = False Then
                            MsgBox("Insufficient Rights")
                            Exit Sub
                        End If
                        objyearmaster.savestate(CMBSTATE.Text.Trim, CmpId, Locationid, Userid, YearId, " and STATE_name = '" & CMBSTATE.Text.Trim & "' AND STATE_CMPID = " & CmpId & " AND STATE_LOCATIONID = " & Locationid & " AND STATE_YEARID = " & YearId)
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

#Region "FUNCTION FOR EMAIL"

    Sub sendemail(ByVal toMail As String, ByVal tempattachment As String, ByVal mailbody As String, ByVal subject As String, Optional ByVal ALATTACHMENT As ArrayList = Nothing, Optional ByVal NOOFATTACHMENTS As Integer = 0, Optional ByVal TEMPATTACHMENT1 As String = "", Optional ByVal TEMPATTACHMENT2 As String = "", Optional ByVal TEMPATTACHMENT3 As String = "", Optional ByVal TEMPATTACHMENT4 As String = "", Optional ByVal TEMPATTACHMENT5 As String = "", Optional ByVal TEMPATTACHMENT6 As String = "")

        'Dim mailBody As String
        Try
            Cursor.Current = Cursors.WaitCursor

            'create the mail message
            Dim mail As New MailMessage
            Dim MAILATTACHMENT As Attachment

            'set the addresses
            mail.From = New MailAddress("siddhivinayaksynthetics@gmail.com", CmpName)
            'mail.From = New MailAddress("gulkitjain@gmail.com", "TexPro V1.0")

            mail.To.Add(toMail)
            'set the content
            mail.Subject = subject
            mail.Body = mailbody
            mail.IsBodyHtml = True
            If NOOFATTACHMENTS <= 1 Then
                If tempattachment <> Nothing Then
                    MAILATTACHMENT = New Attachment(tempattachment)
                    mail.Attachments.Add(MAILATTACHMENT)
                Else
                    MAILATTACHMENT = New Attachment(ALATTACHMENT(0))
                    mail.Attachments.Add(MAILATTACHMENT)
                End If
            Else
                For I As Integer = 0 To NOOFATTACHMENTS - 1
                    MAILATTACHMENT = New Attachment(ALATTACHMENT(I))
                    mail.Attachments.Add(MAILATTACHMENT)
                Next
            End If


            'send the message
            Dim smtp As New SmtpClient

            'set username and password
            Dim nc As New System.Net.NetworkCredential


            'GET SMTP, EMAILADD AND PASSWORD FROM USERMASTER
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("USER_SMTP AS SMTP, USER_SMTPEMAIL AS EMAIL, USER_SMTPPASS AS PASS", "", " USERMASTER", " AND USER_NAME = '" & UserName & "' and USER_CMPID = " & CmpId)
            If DT.Rows.Count > 0 Then
                If DT.Rows(0).Item("SMTP") = "" Then smtp.Host = "smtp.gmail.com" Else smtp.Host = DT.Rows(0).Item("SMTP")
                'smtp.Port = (25)
                smtp.Port = (587)

                smtp.EnableSsl = True

                nc.UserName = DT.Rows(0).Item("EMAIL")
                nc.Password = DT.Rows(0).Item("PASS")
            Else

                smtp.Host = "smtp.gmail.com"
                'smtp.Port = (25)
                smtp.Port = (587)
                smtp.EnableSsl = True

                nc.UserName = "gulkitjain@gmail.com"
                nc.Password = "gulkit3042"

            End If


            'smtp.Timeout = 20000
            smtp.Timeout = 50000

            smtp.Credentials = nc
            smtp.Send(mail)
            mail.Dispose()

        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

#End Region

    Function checkrowlinedel(ByVal gridsrno As Integer, ByVal txtno As TextBox) As Boolean
        Dim bln As Boolean = True
        If gridsrno = Val(txtno.Text.Trim) Then
            bln = False
        End If
        Return bln
    End Function

    Sub commakeypress(ByVal han As KeyPressEventArgs, ByVal sen As Control, ByVal frm As System.Windows.Forms.Form)
        If AscW(han.KeyChar) = 44 Then
            han.KeyChar = ""
        End If
    End Sub

    Sub fillUSER(ByRef CMBUSER As ComboBox, Optional ByVal CONDITION As String = "")
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.search(" DISTINCT User_Name as [UserName]", "", "USERMASTER", " and USERMASTER.USER_cmpid= " & CmpId & " ORDER BY USER_NAME ")
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "USERNAME"
                CMBUSER.DataSource = dt
                CMBUSER.DisplayMember = "USERNAME"
                CMBUSER.Text = ""
            End If
            CMBUSER.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub USERvalidate(ByRef CMBUSER As ComboBox, ByRef e As System.ComponentModel.CancelEventArgs, ByRef frm As System.Windows.Forms.Form)
        Try
            Cursor.Current = Cursors.WaitCursor
            If CMBUSER.Text.Trim <> "" Then
                uppercase(CMBUSER)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("User_Name ", "", " USERMASTER ", "   and User_Name = '" & CMBUSER.Text.Trim & "' and USER_cmpid = " & CmpId)
                If dt.Rows.Count = 0 Then
                    Dim a As String = CMBUSER.Text.Trim
                    Dim tempmsg As Integer = MsgBox("USER not present, Add New?", MsgBoxStyle.YesNo, "TEXTRADE")
                    If tempmsg = vbYes Then
                        CMBUSER.Text = a
                        Dim objuser As New UserMaster
                        'objuser.TEMPUSER = CMBUSER.Text.Trim()
                        ' OBJDESIGN.TEMPMERCHANT = CMBMERCHANT.Text.Trim()
                        objuser.ShowDialog()
                        dt = objclscommon.search("User_Name ", "", " USERMASTER", " and User_Name = '" & CMBUSER.Text.Trim & "'  and User_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            Dim dt1 As New DataTable
                            dt1 = CMBUSER.DataSource
                            If CMBUSER.DataSource <> Nothing Then
line1:
                                If dt1.Rows.Count > 0 Then
                                    dt1.Rows.Add(dt.Rows(0).Item("USER"), CMBUSER.Text.Trim)
                                    CMBUSER.Text = a
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

    Sub FILLFORMTYPE(ByRef CMBFORM As ComboBox, ByRef edit As Boolean, Optional ByVal WHERECLAUSE As String = "")
        Try
            If CMBFORM.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                dt = objclscommon.search(" form_name ", "", " FORMTYPE", WHERECLAUSE)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "FORM_name"
                    CMBFORM.DataSource = dt
                    CMBFORM.DisplayMember = "FORM_name"
                    If edit = False Then CMBFORM.Text = ""
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Module
