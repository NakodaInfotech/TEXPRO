
Imports BL

Public Class MDIMain

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Sub backup()
        Dim TEMPMSG As Integer = MsgBox("Create Backup?", MsgBoxStyle.YesNo)
        If TEMPMSG = vbYes Then

            'CHECKING FOR BACKUP FOLDER
            If FileIO.FileSystem.DirectoryExists("C:\TEXPRO BACKUP") = False Then FileIO.FileSystem.CreateDirectory("C:\TEXPRO BACKUP")

            'IF SAME DATE'S BACKUP EXIST THEN DELETE IT THEN RECREATE IT
            If FileIO.FileSystem.FileExists("C:\TEXPRO BACKUP\TEXPRO BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak") Then FileIO.FileSystem.DeleteFile("C:\TEXPRO BACKUP\TEXPRO BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak")


            Dim OBJCMN As New ClsCommon
            On Error Resume Next
            Dim DT As DataTable = OBJCMN.Execute_Any_String(" backup database TEXPRO to disk='C:\TEXPRO BACKUP\TEXPRO BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak'", "", "")
            MsgBox("Backup Completed")
        End If

    End Sub

    Private Sub MDIMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim TEMPMSG As Integer = MsgBox("Wish to Exit?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then
                e.Cancel = True
                Exit Sub
            End If
            ' backup()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MDIMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = CmpName & " (" & AccFrom & " - " & AccTo & ")                 USERNAME : " & UserName
        GETCONN()
        fillYEAR()


        'GET COMPANY'S DATA FOR VALIDATIONS OF EWB AND GST
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search("ISNULL(CMP_EWBUSER,'') AS EWBUSER, ISNULL(CMP_EWBPASS,'') AS EWBPASS, ISNULL(CMP_GSTIN,'') AS CMPGSTIN, ISNULL(CMP_ZIPCODE,'') AS CMPPINCODE, ISNULL(CITY_NAME,'') AS CITYNAME, CAST(STATE_NAME AS VARCHAR(5)) AS STATENAME, CAST(STATE_REMARK AS VARCHAR(5)) AS STATECODE, ISNULL(NOOFEWAYBILLS,0) AS EWAYCOUNTER", "", " STATEMASTER INNER JOIN CMPMASTER ON STATE_ID = CMP_STATEID LEFT OUTER JOIN CITYMASTER ON CMP_FROMCITYID = CITY_ID LEFT OUTER JOIN EWAYCOUNTER ON CMP_ID = EWAYCOUNTER.CMPID ", " AND CMP_ID = " & CmpId)
        If DT.Rows.Count > 0 Then
            CMPEWBUSER = DT.Rows(0).Item("EWBUSER")
            CMPEWBPASS = DT.Rows(0).Item("EWBPASS")
            CMPGSTIN = DT.Rows(0).Item("CMPGSTIN")
            CMPPINCODE = DT.Rows(0).Item("CMPPINCODE")
            CMPCITYNAME = DT.Rows(0).Item("CITYNAME")
            CMPSTATENAME = DT.Rows(0).Item("STATENAME")
            CMPSTATECODE = DT.Rows(0).Item("STATECODE")

            DT = OBJCMN.search("ISNULL(SUM(NOOFEWAYBILLS),0) AS EWAYCOUNTER", "", " EWAYCOUNTER ", " AND CMPID = " & CmpId)
            CMPEWAYCOUNTER = Val(DT.Rows(0).Item("EWAYCOUNTER"))
            DT = OBJCMN.search("ISNULL(MAX(DATE), GETDATE()) AS EWAYEXPDATE", "", " EWAYCOUNTER ", " AND CMPID = " & CmpId)
            EWAYEXPDATE = Convert.ToDateTime(DT.Rows(0).Item("EWAYEXPDATE")).Date.AddYears(1)


            DT = OBJCMN.search("ISNULL(SUM(NOOFEINVOICE),0) AS EINVOICECOUNTER", "", " EINVOICECOUNTER ", " AND CMPID = " & CmpId)
            CMPEINVOICECOUNTER = Val(DT.Rows(0).Item("EINVOICECOUNTER"))
            DT = OBJCMN.search("ISNULL(MAX(DATE), GETDATE()) AS EINVOICEEXPDATE", "", " EINVOICECOUNTER ", " AND CMPID = " & CmpId)
            EINVOICEEXPDATE = Convert.ToDateTime(DT.Rows(0).Item("EINVOICEEXPDATE")).Date.AddYears(1)
        End If


        'GET USERGODOWN
        DT = OBJCMN.search("ISNULL(GODOWN_NAME,'') AS USERGODOWN", "", " USERGODOWNTAGGING INNER JOIN USERMASTER ON USERGODOWNTAGGING.GODOWN_USERID = USERMASTER.[User_id]	 INNER JOIN GODOWNMASTER ON USERGODOWNTAGGING.GODOWN_GODOWNID = GODOWNMASTER.GODOWN_id  ", " AND USER_NAME ='" & UserName & "' AND  USERGODOWNTAGGING.GODOWN_CMPID = " & CmpId)
        If DT.Rows.Count > 0 Then USERGODOWN = DT.Rows(0).Item("USERGODOWN")


        INVOICESCREENTYPE = "TOTAL GST"

        SETENABILITY()
    End Sub

    Sub SETENABILITY()
        Try
            Dim objhp As New HomePage
            objhp.MdiParent = Me

            objhp.ACC_CMD.Enabled = False
            'objhp.ITEM_CMD.Enabled = False
            objhp.PUR_CMD.Enabled = False
            objhp.PAYMENT_CMD.Enabled = False
            objhp.CONTRA_CMD.Enabled = False
            objhp.JOURNAL_CMD.Enabled = False
            objhp.RECEIPT_CMD.Enabled = False
            objhp.INV_CMD.Enabled = False

            If UserName = "Admin" Then
                RECODATA_MASTER.Enabled = True
                CMP_MASTER.Enabled = True
                YEAR_MASTER.Enabled = True
                ADMIN_MASTER.Enabled = True
                OPENST.Enabled = True
                MERGE_MASTER.Enabled = True
                USERTRANSFER.Enabled = True
                BLOCKUSER.Enabled = True
                TRANSFERDATA.Enabled = True
                TRANSFERSTOCK.Enabled = True
                USERGODOWN_MASTER.Enabled = True
            Else
                'ONLY TO CHANGE PASSWORD
                ADMIN_MASTER.Enabled = True
                USERADD.Enabled = False
                USEREDIT.Enabled = True
            End If

            For Each DTROW As DataRow In USERRIGHTS.Rows

                'MASTERS
                If DTROW(0).ToString = "GROUP MASTER" Then
                    If DTROW(1).ToString = True Then
                        GROUP_MASTER.Enabled = True
                        GROUPADD.Enabled = True
                    Else
                        GROUPADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GROUP_MASTER.Enabled = True
                        GROUPEDIT.Enabled = True
                    Else
                        GROUPEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "ACCOUNTS MASTER" Then
                    If DTROW(1).ToString = True Then
                        ACC_MASTER.Enabled = True
                        ADDRESS_MASTER.Enabled = True
                        WEAVER_MASTER.Enabled = True
                        ACCADD.Enabled = True
                        ADDRESSADD.Enabled = True
                        WEAVERADD.Enabled = True
                        PRICELIST.Enabled = True
                    Else
                        ACCADD.Enabled = False
                        ADDRESSADD.Enabled = False
                        WEAVERADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        ACC_MASTER.Enabled = True
                        ADDRESS_MASTER.Enabled = True
                        WEAVER_MASTER.Enabled = True
                        ACCEDIT.Enabled = True
                        ADDRESSEDIT.Enabled = True
                        WEAVEREDIT.Enabled = True
                        objhp.ACC_CMD.Enabled = True
                    Else
                        ACCEDIT.Enabled = False
                        ADDRESSEDIT.Enabled = False
                        WEAVEREDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "REGISTER MASTER" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        REG_MASTER.Enabled = True
                    End If


                ElseIf DTROW(0).ToString = "ITEM MASTER" Then
                    If DTROW(1).ToString = True Then
                        MATERIAL_MASTER.Enabled = True
                        CATEGORY_MASTER.Enabled = True
                        SUBCATEGORY_MASTER.Enabled = True
                        FOLD_MASTER.Enabled = True
                        QUALITY_MASTER.Enabled = True
                        COLOR_MASTER.Enabled = True
                        COLORRATE_MASTER.Enabled = True
                        ITEM_MASTER.Enabled = True
                        ISSUEMERCHANT_MASTER.Enabled = True
                        PIECETYPE_MASTER.Enabled = True
                        PROCESS_MASTER.Enabled = True
                        PROCESSCONTRACTORCONFIG_MASTER.Enabled = True
                        HSN_MASTER.Enabled = True
                        PROCESSTYPE_MASTER.Enabled = True
                        CONTRACTOR_MASTER.Enabled = True

                        MATERIALADD.Enabled = True
                        CATEGORYADD.Enabled = True
                        SUBCATEGORYADD.Enabled = True
                        FOLDADD.Enabled = True
                        QUALITYADD.Enabled = True
                        COLORADD.Enabled = True
                        COLORRATEADD.Enabled = True
                        ITEMADD.Enabled = True
                        ISSUEMERCHANTADD.Enabled = True
                        PIECETYPEADD.Enabled = True
                        PROCESSADD.Enabled = True
                        HSNADD.Enabled = True
                        PROCESSTYPEADD.Enabled = True
                        CONTRACTORADD.Enabled = True
                    Else
                        MATERIALADD.Enabled = False
                        CATEGORYADD.Enabled = False
                        SUBCATEGORYADD.Enabled = False
                        FOLDADD.Enabled = False
                        QUALITYADD.Enabled = False
                        COLORADD.Enabled = False
                        COLORRATEADD.Enabled = False
                        ITEMADD.Enabled = False
                        ISSUEMERCHANTADD.Enabled = False
                        PROCESSADD.Enabled = False
                        PIECETYPEADD.Enabled = False
                        HSNADD.Enabled = False
                        PROCESSTYPEADD.Enabled = False
                        CONTRACTORADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        MATERIAL_MASTER.Enabled = True
                        CATEGORY_MASTER.Enabled = True
                        SUBCATEGORY_MASTER.Enabled = True
                        FOLD_MASTER.Enabled = True
                        QUALITY_MASTER.Enabled = True
                        COLOR_MASTER.Enabled = True
                        COLORRATE_MASTER.Enabled = True
                        ITEM_MASTER.Enabled = True
                        ISSUEMERCHANT_MASTER.Enabled = True
                        PROCESS_MASTER.Enabled = True
                        PIECETYPE_MASTER.Enabled = True
                        HSN_MASTER.Enabled = True
                        PROCESSCONTRACTORCONFIG_MASTER.Enabled = True
                        PROCESSTYPE_MASTER.Enabled = True
                        CONTRACTOR_MASTER.Enabled = True

                        MATERIALEDIT.Enabled = True
                        CATEGORYEDIT.Enabled = True
                        SUBCATEGORYEDIT.Enabled = True
                        FOLDEDIT.Enabled = True
                        QUALITYEDIT.Enabled = True
                        COLOREDIT.Enabled = True
                        COLORRATEEDIT.Enabled = True
                        ITEMEDIT.Enabled = True
                        ISSUEMERCHANTEDIT.Enabled = True
                        PIECETYPEEDIT.Enabled = True
                        PROCESSEDIT.Enabled = True
                        HSNEDIT.Enabled = True
                        PROCESSTYPEEDIT.Enabled = True
                        CONTRACTOREDIT.Enabled = True
                    Else
                        MATERIALEDIT.Enabled = False
                        CATEGORYEDIT.Enabled = False
                        SUBCATEGORYEDIT.Enabled = False
                        FOLDEDIT.Enabled = False
                        QUALITYEDIT.Enabled = False
                        COLOREDIT.Enabled = False
                        COLORRATEEDIT.Enabled = False
                        ITEMEDIT.Enabled = False
                        ISSUEMERCHANTEDIT.Enabled = False
                        PIECETYPEEDIT.Enabled = False
                        PROCESSEDIT.Enabled = False
                        HSNEDIT.Enabled = False
                        PROCESSTYPEEDIT.Enabled = False
                        CONTRACTOREDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "MERCHANT MASTER" Then
                    If DTROW(1).ToString = True Then
                        PRINTINGTYPE_MASTER.Enabled = True
                        MERCHANT_MASTER.Enabled = True
                        STAMP_MASTER.Enabled = True

                        PRINTINGTYPEADD.Enabled = True
                        MERCHANTADD.Enabled = True
                        STAMPADD.Enabled = True
                    Else
                        PRINTINGTYPEADD.Enabled = False
                        MERCHANTADD.Enabled = False
                        STAMPADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PRINTINGTYPE_MASTER.Enabled = True
                        MERCHANT_MASTER.Enabled = True
                        STAMP_MASTER.Enabled = True
                        PRINTINGTYPEEDIT.Enabled = True
                        MERCHANTEDIT.Enabled = True
                        STAMPEDIT.Enabled = True
                    Else
                        PRINTINGTYPEEDIT.Enabled = False
                        MERCHANTEDIT.Enabled = False
                        STAMPEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "DESIGN MASTER" Then
                    If ClientName = "SHREENATH" Then
                        DESIGN_MASTER.Text = "Design Master"
                        DESIGNADD.Text = "&Add New Design"
                        DESIGNEDIT.Text = "&Edit Existing Design"
                    End If
                    If DTROW(1).ToString = True Then
                        DESIGN_MASTER.Enabled = True
                        DESIGNADD.Enabled = True
                    Else
                        DESIGNADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DESIGN_MASTER.Enabled = True
                        DESIGNEDIT.Enabled = True
                    Else
                        DESIGNEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "DYEING MASTER" Then
                    If DTROW(1).ToString = True Then
                        DYEING_MASTER.Enabled = True
                        DYEINGADD.Enabled = True
                    Else
                        DYEINGADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DYEING_MASTER.Enabled = True
                        DYEINGEDIT.Enabled = True
                    Else
                        DYEINGEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "MACHINE MASTER" Then
                    If DTROW(1).ToString = True Then
                        MACHINE_MASTER.Enabled = True
                        MACHINEADD.Enabled = True
                    Else
                        MACHINEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        MACHINE_MASTER.Enabled = True
                        MACHINEEDIT.Enabled = True
                    Else
                        MACHINEEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "DEPARTMENT MASTER" Then
                    If DTROW(1).ToString = True Then
                        DEPARTMENT_MASTER.Enabled = True
                        DEPARTMENTADD.Enabled = True
                    Else
                        DEPARTMENTADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DEPARTMENT_MASTER.Enabled = True
                        DEPARTMENTEDIT.Enabled = True
                    Else
                        DEPARTMENTEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "UNIT MASTER" Then
                    If DTROW(1).ToString = True Then
                        UNIT_MASTER.Enabled = True
                        UNITADD.Enabled = True
                    Else
                        UNITADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        UNIT_MASTER.Enabled = True
                        UNITEDIT.Enabled = True
                    Else
                        UNITEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "LOCATION MASTER" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        LOC_MASTER.Enabled = True
                    End If


                ElseIf DTROW(0).ToString = "FORMTYPE MASTER" Then
                    If DTROW(1).ToString = True Then
                        FORMTYPE_MASTER.Enabled = True
                        FORMTYPEADD.Enabled = True
                    Else
                        FORMTYPEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        FORMTYPE_MASTER.Enabled = True
                        FORMTYPEEDIT.Enabled = True
                    Else
                        FORMTYPEEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "TAX MASTER" Then
                    If DTROW(1).ToString = True Then
                        TAX_MASTER.Enabled = True
                        TAXADD.Enabled = True
                    Else
                        TAXADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        TAX_MASTER.Enabled = True
                        TAXEDIT.Enabled = True
                    Else
                        TAXEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "RATE TYPE MASTER" Then
                    If DTROW(1).ToString = True Then
                        RATETYPE_MASTER.Enabled = True
                        EXPENSE_MASTER.Enabled = True
                        RATETYPEADD.Enabled = True
                        EXPENSERATE_MASTER.Enabled = True
                        EXPENSEADD.Enabled = True
                    Else
                        RATETYPEADD.Enabled = False
                        EXPENSEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        RATETYPE_MASTER.Enabled = True
                        EXPENSE_MASTER.Enabled = True
                        RATETYPEEDIT.Enabled = True
                        EXPENSERATE_MASTER.Enabled = True
                        EXPENSEEDIT.Enabled = True
                    Else
                        RATETYPEEDIT.Enabled = False
                        EXPENSEEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "OPENING" Then
                    If DTROW(1).ToString = True Then
                        OPENINGBILL_MASTER.Enabled = True
                        OPENINGBALANCE.Enabled = True
                        OPENINGSTOCKVALUE.Enabled = True
                        OPENST.Enabled = True
                        GREYSTOCK.Enabled = True
                        STORESTOCK.Enabled = True
                        PROCESSSTOCK.Enabled = True
                        BALESTOCK.Enabled = True
                        JOBOUTSTOCK.Enabled = True
                        JOBBALESTOCK.Enabled = True
                        LOOSESTOCK.Enabled = True
                    Else
                        OPENINGBILL_MASTER.Enabled = False
                        OPENINGBALANCE.Enabled = False
                        OPENINGSTOCKVALUE.Enabled = False
                        GREYSTOCK.Enabled = False
                        STORESTOCK.Enabled = False
                        PROCESSSTOCK.Enabled = False
                        BALESTOCK.Enabled = False
                        JOBOUTSTOCK.Enabled = False
                        JOBBALESTOCK.Enabled = False
                        LOOSESTOCK.Enabled = False
                    End If

                    'PURCHASE

                ElseIf DTROW(0).ToString = "PURCHASE ORDER" Then
                    If DTROW(1).ToString = True Then
                        PO_MASTER.Enabled = True
                        GREYPO_MASTER.Enabled = True
                        POCLOSE.Enabled = True
                        GREYPOCLOSE.Enabled = True
                        OPPO_MASTER.Enabled = True
                        POADD.Enabled = True
                        GREYPOADD.Enabled = True
                        OPPOADD.Enabled = True
                    Else
                        POADD.Enabled = False
                        GREYPOADD.Enabled = False
                        OPPOADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PO_MASTER.Enabled = True
                        GREYPO_MASTER.Enabled = True
                        OPPO_MASTER.Enabled = True
                        POEDIT.Enabled = True
                        GREYPOEDIT.Enabled = True
                        OPPOEDIT.Enabled = True
                    Else
                        POEDIT.Enabled = False
                        GREYPOEDIT.Enabled = False
                        OPPOEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "GRN INWARD" Then
                    If DTROW(1).ToString = True Then
                        GRN_MASTER.Enabled = True
                        GRNGREY_MASTER.Enabled = True
                        GRNGREYADD.Enabled = True
                        GRN_TOOL.Enabled = True
                    Else
                        GRNGREYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GRN_TOOL.Enabled = True
                        GRN_MASTER.Enabled = True
                        GRNGREY_MASTER.Enabled = True
                        GRNGREYEDIT.Enabled = True
                    Else
                        GRNGREYEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "GRN" Then
                    If DTROW(1).ToString = True Then
                        GRNINWARD_TOOL.Enabled = True
                        GRN_MASTER.Enabled = True
                        CONSUMPTION_MASTER.Enabled = True
                        LOAN_MASTER.Enabled = True
                        GRNADD.Enabled = True
                        CONSUMEADD.Enabled = True
                        LOANADD.Enabled = True
                    Else
                        GRNADD.Enabled = False
                        CONSUMEADD.Enabled = False
                        LOANADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GRNINWARD_TOOL.Enabled = True
                        GRN_MASTER.Enabled = True
                        GRNEDIT.Enabled = True
                        CONSUMEEDIT.Enabled = True
                        LOANEDIT.Enabled = True
                    Else
                        GRNEDIT.Enabled = False
                        CONSUMEEDIT.Enabled = False
                        LOANEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "GRN JOB" Then
                    If DTROW(1).ToString = True Then
                        GRNJOB_MASTER.Enabled = True
                        GRNJOBADD.Enabled = True
                    Else
                        GRNJOBADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GRNJOB_MASTER.Enabled = True
                        GRNJOBEDIT.Enabled = True
                    Else
                        GRNJOBEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "GRN CHECKING" Then
                    If DTROW(1).ToString = True Then
                        GRNCHECKING_MASTER.Enabled = True
                        CHECK_TOOL.Enabled = True
                        GRNCHECKINGADD.Enabled = True
                        TRANSFER_MASTER.Enabled = True
                        TRANSFERADD.Enabled = True
                        RECTRANSFER_MASTER.Enabled = True
                    Else
                        CHECK_TOOL.Enabled = False
                        GRNCHECKINGADD.Enabled = False
                        TRANSFERADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GRNCHECKING_MASTER.Enabled = True
                        GRNCHECKINGEDIT.Enabled = True
                        TRANSFER_MASTER.Enabled = True
                        TRANSFEREDIT.Enabled = True
                        RECTRANSFER_MASTER.Enabled = True
                    Else
                        GRNCHECKINGEDIT.Enabled = False
                        TRANSFEREDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "GATE PASS" Then
                    If DTROW(1).ToString = True Then
                        GATEPASS_MASTER.Enabled = True
                        GATEPASSADD.Enabled = True
                        GATEPASS_TOOL.Enabled = True
                    Else
                        GATEPASSADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GATEPASS_MASTER.Enabled = True
                        GATEPASSEDIT.Enabled = True
                        GATEPASS_TOOL.Enabled = True
                    Else
                        GATEPASSEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "PURCHASE INVOICE" Then
                    If DTROW(1).ToString = True Then
                        PURINV_MASTER.Enabled = True
                        PURCHASE_TOOL.Enabled = True
                        PURINVADD.Enabled = True
                        objhp.PUR_CMD.Enabled = True
                    Else
                        PURINVADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PURINV_MASTER.Enabled = True
                        PURINVEDIT.Enabled = True
                    Else
                        PURINVEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "PURCHASE RETURN" Then
                    If DTROW(1).ToString = True Then
                        PURRET_MASTER.Enabled = True
                        PURRETADD.Enabled = True
                    Else
                        PURRETADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PURRET_MASTER.Enabled = True
                        PURRETEDIT.Enabled = True
                    Else
                        PURRETEDIT.Enabled = False
                    End If



                    'SALE
                ElseIf DTROW(0).ToString = "SALE ORDER" Then
                    If DTROW(1).ToString = True Then
                        SO_MASTER.Enabled = True
                        'SO_TOOL.Enabled = True
                        SOADD.Enabled = True
                        OPSO_MASTER.Enabled = True
                        OPSOADD.Enabled = True
                    Else
                        SOADD.Enabled = False
                        OPSOADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SO_MASTER.Enabled = True
                        'WO_TOOL.Enabled = True
                        SOEDIT.Enabled = True
                        OPSO_MASTER.Enabled = True
                        OPSOEDIT.Enabled = True
                    Else
                        SOEDIT.Enabled = False
                        OPSOEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "CHALLAN" Then
                    If DTROW(1).ToString = True Then
                        GDN_MASTER.Enabled = True
                        GDN_TOOL.Enabled = True
                        GDNADD.Enabled = True
                    Else
                        GDNADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GDN_MASTER.Enabled = True
                        GDN_TOOL.Enabled = True
                        GDNEDIT.Enabled = True
                    Else
                        GDNEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "SALE INVOICE" Then
                    If DTROW(1).ToString = True Then
                        SALE_MASTER.Enabled = True
                        SALE_TOOL.Enabled = True
                        SALEADD.Enabled = True
                        objhp.INV_CMD.Enabled = True
                    Else
                        SALEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SALE_MASTER.Enabled = True
                        SALEEDIT.Enabled = True
                    Else
                        SALEEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "SALE RETURN" Then
                    If DTROW(1).ToString = True Then
                        SALERET_MASTER.Enabled = True
                        SALERETADD.Enabled = True
                    Else
                        SALERETADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SALERET_MASTER.Enabled = True
                        SALERETEDIT.Enabled = True
                    Else
                        SALERETEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "PROFORMA" Then
                    If DTROW(1).ToString = True Then
                        PROFORMA_MASTER.Enabled = True
                        PROFORMA_TOOL.Enabled = True
                        PROFORMAADD.Enabled = True
                    Else
                        PROFORMAADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PROFORMA_MASTER.Enabled = True
                        PROFORMAEDIT.Enabled = True
                        PROFORMA_TOOL.Enabled = True
                    Else
                        PROFORMAEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "FORM ENTRY" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        FORMENTRY_MASTER.Enabled = True
                    End If


                    'JOB WORK
                ElseIf DTROW(0).ToString = "JOB WORK OUT" Then
                    If DTROW(1).ToString = True Then
                        JWO_MASTER.Enabled = True
                        JWOADD.Enabled = True
                    Else
                        JWOADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        JWO_MASTER.Enabled = True
                        JWOEDIT.Enabled = True
                    Else
                        JWOEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "JOB WORK IN" Then
                    If DTROW(1).ToString = True Then
                        JWI_MASTER.Enabled = True
                        JWIADD.Enabled = True
                    Else
                        JWIADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        JWI_MASTER.Enabled = True
                        JWIEDIT.Enabled = True
                    Else
                        JWIEDIT.Enabled = False
                    End If


                    'PRODUCTION
                ElseIf DTROW(0).ToString = "MFG" Then
                    If DTROW(1).ToString = True Then
                        MFG_MASTER.Enabled = True
                        CUTTING_MASTER.Enabled = True
                        FINALCUTTING_MASTER.Enabled = True
                        MFG2_MASTER.Enabled = True
                        MFG_TOOL.Enabled = True
                        MFGAFTERCUTTING_TOOL.Enabled = True
                        CUTTING_TOOL.Enabled = True
                        MFGADD.Enabled = True
                        CUTTINGADD.Enabled = True
                        FINALCUTTINGADD.Enabled = True
                        FINALCUTTING_TOOL.Enabled = True
                        PACKINGSLIP_TOOL.Enabled = True
                        MFG2ADD.Enabled = True
                    Else
                        MFGADD.Enabled = False
                        CUTTINGADD.Enabled = False
                        FINALCUTTINGADD.Enabled = False
                        MFGAFTERCUTTING_TOOL.Enabled = False
                        FINALCUTTING_TOOL.Enabled = False
                        PACKINGSLIP_TOOL.Enabled = False
                        MFG2ADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        MFG_MASTER.Enabled = True
                        CUTTING_MASTER.Enabled = True
                        FINALCUTTING_MASTER.Enabled = True
                        MFG2_MASTER.Enabled = True
                        MFG_TOOL.Enabled = True
                        CUTTING_TOOL.Enabled = True
                        MFGEDIT.Enabled = True
                        CUTTINGEDIT.Enabled = True
                        FINALCUTTINGEDIT.Enabled = True
                        MFG2EDIT.Enabled = True
                    Else
                        MFGEDIT.Enabled = False
                        CUTTINGEDIT.Enabled = False
                        FINALCUTTINGEDIT.Enabled = False
                        MFG2EDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "PACKING SLIP" Then
                    If DTROW(1).ToString = True Then
                        PSJOB_MASTER.Enabled = True
                        PSFINAL_MASTER.Enabled = True
                        PSJOBADD.Enabled = True
                        PSFINALADD.Enabled = True
                        PACKINGSLIP_TOOL.Enabled = True
                        BALEOPEN_MASTER.Enabled = True
                        BALEOPENADD.Enabled = True
                        PACKINGSUMM_TOOL.Enabled = True
                        PACKINGSUMM_MASTER.Enabled = True
                        PACKINGSUMMADD.Enabled = True
                    Else
                        PSJOBADD.Enabled = False
                        PSFINALADD.Enabled = False
                        BALEOPENADD.Enabled = False
                        PACKINGSUMMADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PSJOB_MASTER.Enabled = True
                        PSFINAL_MASTER.Enabled = True
                        PSJOBEDIT.Enabled = True
                        PSFINALEDIT.Enabled = True
                        BALEOPEN_MASTER.Enabled = True
                        BALEOPENEDIT.Enabled = True
                        PACKINGSUMM_MASTER.Enabled = True
                        PACKINGSUMMEDIT.Enabled = True
                    Else
                        PSJOBEDIT.Enabled = False
                        PSFINALEDIT.Enabled = False
                        BALEOPENEDIT.Enabled = False
                        PACKINGSUMMEDIT.Enabled = False
                    End If



                    'ACCOUNTS
                ElseIf DTROW(0).ToString = "RECEIPT" Then
                    If DTROW(1).ToString = True Then
                        REC_MASTER.Enabled = True
                        MANUALMATCHING_MASTER.Enabled = True
                        RECADD.Enabled = True
                        MANUALMATCHINGADD.Enabled = True
                        objhp.RECEIPT_CMD.Enabled = True
                    Else
                        MANUALMATCHINGADD.Enabled = False
                        RECADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        REC_MASTER.Enabled = True
                        MANUALMATCHING_MASTER.Enabled = True
                        RECEDIT.Enabled = True
                        MANUALMATCHINGEDIT.Enabled = True
                    Else
                        RECEDIT.Enabled = False
                        MANUALMATCHINGEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "PAYMENT" Then
                    If DTROW(1).ToString = True Then
                        PAY_MASTER.Enabled = True
                        PAYADD.Enabled = True
                        objhp.PAYMENT_CMD.Enabled = True
                    Else
                        PAYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PAY_MASTER.Enabled = True
                        PAYEDIT.Enabled = True
                    Else
                        PAYEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "JOURNAL VOUCHER" Then
                    If DTROW(1).ToString = True Then
                        JV_MASTER.Enabled = True
                        JVADD.Enabled = True
                        objhp.JOURNAL_CMD.Enabled = True
                    Else
                        JVADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        JV_MASTER.Enabled = True
                        JVEDIT.Enabled = True
                    Else
                        JVEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "CONTRA VOUCHER" Then
                    If DTROW(1).ToString = True Then
                        CONTRA_MASTER.Enabled = True
                        CONTRAADD.Enabled = True
                        objhp.CONTRA_CMD.Enabled = True
                    Else
                        CONTRAADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        CONTRA_MASTER.Enabled = True
                        CONTRAEDIT.Enabled = True
                    Else
                        CONTRAEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "DEBIT NOTE" Then
                    If DTROW(1).ToString = True Then
                        DEBIT_MASTER.Enabled = True
                        DEBITADD.Enabled = True
                    Else
                        DEBITADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DEBIT_MASTER.Enabled = True
                        DEBITEDIT.Enabled = True
                    Else
                        DEBITEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "CREDIT NOTE" Then
                    If DTROW(1).ToString = True Then
                        CREDIT_MASTER.Enabled = True
                        CREDITADD.Enabled = True
                    Else
                        CREDITADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        CREDIT_MASTER.Enabled = True
                        CREDITEDIT.Enabled = True
                    Else
                        CREDITEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "VOUCHER ENTRY" Then
                    If DTROW(1).ToString = True Then
                        VOUCHER_MASTER.Enabled = True
                        VOUCHERADD.Enabled = True
                    Else
                        VOUCHERADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        VOUCHER_MASTER.Enabled = True
                        VOUCHEREDIT.Enabled = True
                    Else
                        VOUCHEREDIT.Enabled = False
                    End If


                    'REPORTS
                ElseIf DTROW(0).ToString = "PURCHASE REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PUR_REPORTS.Enabled = True
                    End If


                ElseIf DTROW(0).ToString = "SALE REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SALE_REPORTS.Enabled = True
                    End If


                ElseIf DTROW(0).ToString = "JOB REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        JOB_REPORTS.Enabled = True
                    End If


                ElseIf DTROW(0).ToString = "STOCK REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        STOCK_REPORTS.Enabled = True
                    End If


                ElseIf DTROW(0).ToString = "ACCOUNT REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        ACC_REPORTS.Enabled = True
                    End If

                End If
            Next

            'objhp.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillYEAR()
        Try
            Dim objcmn As New ClsCommon
            Dim dt As DataTable
            Dim whereclause As String = ""
            dt = objcmn.search(" distinct user_YEARid", "", "UserMaster", " and User_Name = '" & UserName & "' and user_cmpid = " & CmpId)
            For Each DTROW As DataRow In dt.Rows
                If whereclause = "" Then
                    whereclause = " AND YEAR_ID IN (" & DTROW(0)
                Else
                    whereclause = whereclause & "," & DTROW(0)
                End If
            Next
            whereclause = whereclause & ")"


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CATEGORYADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "CATEGORY"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub MATERIALADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATERIALADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "MATERIAL TYPE"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPADD.Click
        Try
            Dim objGroupMaster As New GroupMaster
            objGroupMaster.MdiParent = Me
            objGroupMaster.Show()
            objGroupMaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewCityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewCityToolStripMenuItem.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "CITYMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewStateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewStateToolStripMenuItem.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "STATEMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewCountryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewCountryToolStripMenuItem.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "COUNTRYMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewAreaToolStripMenuItem.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "AREAMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub AddNewItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMADD.Click
        Try
            Dim objItemMaster As New ItemMaster
            objItemMaster.MdiParent = Me
            objItemMaster.frmstring = "ITEM"
            objItemMaster.Show()
            objItemMaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCADD.Click
        Try
            Dim objAccountMaster As New AccountsMaster
            objAccountMaster.MdiParent = Me
            objAccountMaster.frmstring = "ACCOUNTS"
            objAccountMaster.Show()
            objAccountMaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPEDIT.Click
        Try
            Dim objGroupDetails As New GroupDetails
            objGroupDetails.MdiParent = Me
            objGroupDetails.Show()
            objGroupDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingAccoutsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCEDIT.Click
        Try
            Dim objAccountDetails As New AccountsDetails
            objAccountDetails.MdiParent = Me
            objAccountDetails.frmstring = "ACCOUNTS"
            objAccountDetails.Show()
            objAccountDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMEDIT.Click
        Try
            Dim objItemDetails As New ItemDetails
            objItemDetails.MdiParent = Me
            objItemDetails.FRMSTRING = "ITEM"
            objItemDetails.Show()
            objItemDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CATEGORYEDIT.Click
        Try
            Dim objCategoryDetails As New CategoryDetails
            objCategoryDetails.MdiParent = Me
            objCategoryDetails.frmstring = "CATEGORY"
            objCategoryDetails.Show()
            objCategoryDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub MATERIALEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MATERIALEDIT.Click
        Try
            Dim objCategoryDetails As New CategoryDetails
            objCategoryDetails.MdiParent = Me
            objCategoryDetails.frmstring = "MATERIAL TYPE"
            objCategoryDetails.Show()
            objCategoryDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingAreaToolStripMenuItem.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "AREAMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingCityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingCityToolStripMenuItem.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "CITYMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingStateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingStateToolStripMenuItem.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "STATEMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingCountryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingCountryToolStripMenuItem.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "COUNTRYMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UNITADD.Click
        Try
            Dim objunitmaster As New UnitMaster
            objunitmaster.MdiParent = Me
            objunitmaster.frmString = "UNIT"
            objunitmaster.Show()
            objunitmaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UNITEDIT.Click
        Try
            Dim objUnitDetails As New UnitDetails
            objUnitDetails.MdiParent = Me
            objUnitDetails.frmstring = "UNIT"
            objUnitDetails.Show()
            objUnitDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewPackingUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewPackingUnitToolStripMenuItem.Click
        Try
            Dim objunitmaster As New UnitMaster
            objunitmaster.MdiParent = Me
            objunitmaster.frmString = "PACKINGUNIT"
            objunitmaster.Show()
            objunitmaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingPackingUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingPackingUnitToolStripMenuItem.Click
        Try
            Dim objUnitDetails As New UnitDetails
            objUnitDetails.MdiParent = Me
            objUnitDetails.frmstring = "PACKINGUNIT"
            objUnitDetails.Show()
            objUnitDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewSubPackingUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewSubPackingUnitToolStripMenuItem.Click
        Try
            Dim objunitmaster As New UnitMaster
            objunitmaster.MdiParent = Me
            objunitmaster.frmString = "SUBPACKINGUNIT"
            objunitmaster.Show()
            objunitmaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingSubPackingUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingSubPackingUnitToolStripMenuItem.Click
        Try
            Dim objUnitDetails As New UnitDetails
            objUnitDetails.MdiParent = Me
            objUnitDetails.frmstring = "SUBPACKINGUNIT"
            objUnitDetails.Show()
            objUnitDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub addUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERADD.Click
        Try
            Dim objuser As New UserMaster
            objuser.MdiParent = Me
            objuser.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub editUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USEREDIT.Click
        Try
            Dim objuser As New UserDetails
            objuser.MdiParent = Me
            objuser.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbselectcmp_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        Try
            'close all child forms
            Dim f As Form
            For Each f In MdiChildren
                f.Close()
            Next
            opencmp(e.ClickedItem.ToString())

            Dim objhp As New HomePage
            objhp.MdiParent = Me
            objhp.Show()

            Me.Text = CmpName & " (" & AccFrom & " - " & AccTo & ")"

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Sub opencmp(ByVal CMP As String)
        Try

            Dim objcmn As New ClsCommon
            Dim DT As DataTable

            DT = objcmn.search("CMPMASTER.CMP_NAME, YEARMASTER.YEAR_DBNAME, CMPMASTER.CMP_ID, YEARMASTER.YEAR_STARTDATE, YEARMASTER.YEAR_ENDDATE, YEARMASTER.YEAR_ID", "", " CMPMASTER INNER JOIN YEARMASTER ON YEARMASTER.YEAR_CMPID = CMPMASTER.CMP_ID", " AND CMPMASTER.CMP_NAME = '" & CMP & "'")
            CmpName = DT.Rows(0).Item(0).ToString
            DBName = DT.Rows(0).Item(1).ToString
            CmpId = DT.Rows(0).Item(2).ToString
            AccFrom = DT.Rows(0).Item(3)
            AccTo = DT.Rows(0).Item(4)
            YearId = DT.Rows(0).Item(5).ToString
            Cmppassword.cmdback.Visible = False
            Cmppassword.lblretype.Visible = False
            Cmppassword.txtretypepassword.Visible = False
            Cmppassword.cmdnext.Text = "&Ok"
            Cmppassword.ShowDialog()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRegisterToolStripMenuItem.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "PURCHASE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "SALE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem17.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "JOURNAL"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem19.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "CONTRA"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem21.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "PAYMENT"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem23.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "RECEIPT"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TAXADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAXADD.Click
        Try
            Dim OBJTAX As New Taxmaster
            OBJTAX.MdiParent = Me
            OBJTAX.Show()
            OBJTAX.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TAXEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TAXEDIT.Click
        Try
            Dim OBJTAXDETAILS As New TaxDetails
            OBJTAXDETAILS.MdiParent = Me
            OBJTAXDETAILS.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub FORMTYPEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FORMTYPEADD.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "FORMTYPE"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub FORMTYPEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FORMTYPEEDIT.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "FORMTYPE"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewOctroiTaxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OCTROIADD.Click
        Try
            Dim objunitmaster As New UnitMaster
            objunitmaster.MdiParent = Me
            objunitmaster.frmString = "OCTROIMASTER"
            objunitmaster.Show()
            objunitmaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingOctroiTaxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OCTROIEDIT.Click
        Try
            Dim objUnitDetails As New UnitDetails
            objUnitDetails.MdiParent = Me
            objUnitDetails.frmstring = "OCTROIMASTER"
            objUnitDetails.Show()
            objUnitDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewExciseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCISEADD.Click
        Try
            Dim objexcisemaster As New ExciseMaster
            objexcisemaster.MdiParent = Me
            objexcisemaster.Show()
            objexcisemaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingExciseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCISEEDIT.Click
        Try
            Dim objexciseDetails As New ExciseDetails
            objexciseDetails.MdiParent = Me
            objexciseDetails.Show()
            objexciseDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewExpenseRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewExpenseRegisterToolStripMenuItem.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "EXPENSE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRegisterToolStripMenuItem1.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "CREDITNOTE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRegisterToolStripMenuItem2.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "DEBITNOTE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub QUALITYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QUALITYADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "QUALITY"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub MERCHANTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MERCHANTADD.Click
        Try
            Dim objmerchant As New ItemMaster
            objmerchant.MdiParent = Me
            objmerchant.frmstring = "MERCHANT"
            objmerchant.Show()
            objmerchant.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub COLORADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COLORADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "COLOR"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DEPARTMENTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEPARTMENTADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "DEPARTMENT"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub QUALITYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QUALITYEDIT.Click
        Try
            Dim objCategoryDetails As New CategoryDetails
            objCategoryDetails.MdiParent = Me
            objCategoryDetails.frmstring = "QUALITY"
            objCategoryDetails.Show()
            objCategoryDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub MERCHANTEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MERCHANTEDIT.Click
        Try
            Dim objmerchant As New ItemDetails
            objmerchant.MdiParent = Me
            objmerchant.FRMSTRING = "MERCHANT"
            objmerchant.Show()
            objmerchant.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub COLOREDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COLOREDIT.Click
        Try
            Dim objCategoryDetails As New CategoryDetails
            objCategoryDetails.MdiParent = Me
            objCategoryDetails.frmstring = "COLOR"
            objCategoryDetails.Show()
            objCategoryDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DEPARTMENTEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEPARTMENTEDIT.Click
        Try
            Dim objCategoryDetails As New CategoryDetails
            objCategoryDetails.MdiParent = Me
            objCategoryDetails.frmstring = "DEPARTMENT"
            objCategoryDetails.Show()
            objCategoryDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PRINTINGTYPEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTINGTYPEADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "PRINTING TYPE"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PRINTINGTYPEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTINGTYPEEDIT.Click
        Try
            Dim objCategoryDetails As New CategoryDetails
            objCategoryDetails.MdiParent = Me
            objCategoryDetails.frmstring = "PRINTING TYPE"
            objCategoryDetails.Show()
            objCategoryDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DESIGNADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DESIGNADD.Click
        Try
            If ClientName = "SHREENATH" Then
                Dim objdesign As New DesignMaster
                objdesign.MdiParent = Me
                objdesign.Show()
                objdesign.BringToFront()
            Else
                Dim objdesign As New DesignRecipe
                objdesign.MdiParent = Me
                objdesign.Show()
                objdesign.BringToFront()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub MACHINEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MACHINEADD.Click
        Try
            Dim objmachine As New MachineMaster
            objmachine.MdiParent = Me
            objmachine.Show()
            objmachine.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub MACHINEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MACHINEEDIT.Click
        Try
            Dim objmachine As New MachineDetails
            objmachine.MdiParent = Me
            objmachine.Show()
            objmachine.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub RATETYPEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RATETYPEADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "RATE TYPE"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub RATETYPEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RATETYPEEDIT.Click
        Try
            Dim objCategoryDetails As New CategoryDetails
            objCategoryDetails.MdiParent = Me
            objCategoryDetails.frmstring = "RATE TYPE"
            objCategoryDetails.Show()
            objCategoryDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DYEINGADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DYEINGADD.Click
        Try
            Dim objdesign As New DyeingRecipe
            objdesign.MdiParent = Me
            objdesign.Show()
            objdesign.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SendMailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendMailToolStripMenuItem.Click
        Try
            Dim OBJMAIL As New E_Mail
            OBJMAIL.MdiParent = Me
            OBJMAIL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Try
            Dim OBJSMS As New SendSMS
            OBJSMS.MdiParent = Me
            OBJSMS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingRecipeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DESIGNEDIT.Click
        Try
            Dim OBJDESIGN As New DesignRecipeDetails
            OBJDESIGN.MdiParent = Me
            OBJDESIGN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingRecipeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DYEINGEDIT.Click
        Try
            Dim OBJDYEING As New DyeingRecipeDetails
            OBJDYEING.MdiParent = Me
            OBJDYEING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChangeCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeCompany.Click
        Try
            'close all child forms
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next

            Me.Dispose()
            Cmpdetails.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChangeUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeUserToolStripMenuItem.Click
        Try
            'close all child forms
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next

            Me.Dispose()
            Login.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POADD.Click
        Try
            Dim OBJPO As New PurchaseOrder
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POEDIT.Click
        Try
            Dim OBJPO As New PurchaseOrderDetails
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMPEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMPEDIT.Click
        Try
            Cmpmaster.EDIT = True
            Cmpmaster.TEMPCMPNAME = CmpName
            Cmpmaster.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMPADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMPADD.Click
        Try
            Dim obj As New Cmpmaster
            obj.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRNADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNADD.Click
        Try
            Dim OBJGRN As New GRN
            OBJGRN.MdiParent = Me
            OBJGRN.FRMSTRING = "INWARD"
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNEDIT.Click
        Try
            Dim OBJGRN As New GRNDetails
            OBJGRN.MdiParent = Me
            OBJGRN.FRMSTRING = "INWARD"
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNCHECKINGADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNCHECKINGADD.Click
        Try
            Dim OBJCHECKING As New GRNChecking
            OBJCHECKING.MdiParent = Me
            OBJCHECKING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNCHECKINGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNCHECKINGEDIT.Click
        Try
            Dim OBJCHECKING As New GRNCheckingDetails
            OBJCHECKING.MdiParent = Me
            OBJCHECKING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub WOADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOADD.Click
        Try
            Dim OBJWorkOrder As New SaleOrder
            OBJWorkOrder.MdiParent = Me
            OBJWorkOrder.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PIECETYPEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIECETYPEADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "PIECE TYPE"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PIECETYPEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIECETYPEEDIT.Click
        Try
            Dim objCategoryDetails As New CategoryDetails
            objCategoryDetails.MdiParent = Me
            objCategoryDetails.frmstring = "PIECE TYPE"
            objCategoryDetails.Show()
            objCategoryDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PROCESSEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROCESSEDIT.Click
        Try
            Dim OBJPROC As New ProcessDetails
            OBJPROC.MdiParent = Me
            OBJPROC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROCESSADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROCESSADD.Click
        Try
            Dim OBJPROC As New ProcessMaster
            OBJPROC.MdiParent = Me
            OBJPROC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MFGADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MFGADD.Click
        Try
            Dim OBJMFG As New Mfg
            OBJMFG.MdiParent = Me
            OBJMFG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MFGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MFGEDIT.Click
        Try
            Dim OBJMFG As New MfgDetails
            OBJMFG.MdiParent = Me
            OBJMFG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CUTTINGADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUTTINGADD.Click
        Try
            Dim OBJCUTTING As New CuttingProcess
            OBJCUTTING.MdiParent = Me
            OBJCUTTING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CUTTINGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUTTINGEDIT.Click
        Try
            Dim OBJCUTTING As New CuttingProcessDetails
            OBJCUTTING.MdiParent = Me
            OBJCUTTING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MFG_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MFG_TOOL.Click
        Try
            Dim OBJMFG As New Mfg
            OBJMFG.MdiParent = Me
            OBJMFG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MFGAFTERCUTTING_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MFGAFTERCUTTING_TOOL.Click
        Try
            Dim OBJMFG As New Mfg2
            OBJMFG.MdiParent = Me
            OBJMFG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRN_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRN_TOOL.Click
        Try
            Dim OBJGRN As New GRN
            OBJGRN.MdiParent = Me
            OBJGRN.FRMSTRING = "GRN"
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CUTTING_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUTTING_TOOL.Click
        Try
            Dim OBJCUTTING As New CuttingProcess
            OBJCUTTING.MdiParent = Me
            OBJCUTTING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PSJOBADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PSJOBADD.Click
        Try
            Dim OBJPS As New PackingSlip
            OBJPS.MdiParent = Me
            OBJPS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PSJOBEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PSJOBEDIT.Click
        Try
            Dim OBJPS As New PackingSlipDetails
            OBJPS.MdiParent = Me
            OBJPS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JWOADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JWOADD.Click
        Try
            Dim OBJjo As New JobOut
            OBJjo.MdiParent = Me
            OBJjo.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JWIADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JWIADD.Click
        Try
            Dim OBJji As New JobIn
            OBJji.MdiParent = Me
            OBJji.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewPackingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PSFINALADD.Click
        Try
            Dim OBJji As New finalPackingslip
            OBJji.MdiParent = Me
            OBJji.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNGREYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNGREYADD.Click
        Try
            Dim OBJGRN As New GRN
            OBJGRN.MdiParent = Me
            OBJGRN.FRMSTRING = "GRN"
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNGREYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNGREYEDIT.Click
        Try
            Dim OBJGRN As New GRNDetails
            OBJGRN.MdiParent = Me
            OBJGRN.FRMSTRING = "GRN"
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNJOBADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNJOBADD.Click
        Try
            Dim OBJGRN As New GRN
            OBJGRN.MdiParent = Me
            OBJGRN.FRMSTRING = "GRNJOB"
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNJOBEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNJOBEDIT.Click
        Try
            Dim OBJGRN As New GRNDetails
            OBJGRN.MdiParent = Me
            OBJGRN.FRMSTRING = "GRNJOB"
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewGatePassToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GATEPASSADD.Click
        Try
            Dim OBJGRN As New gatePass
            OBJGRN.MdiParent = Me
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewCuttingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FINALCUTTINGADD.Click
        Try
            Dim OBJGRN As New FinalCuttingProcess
            OBJGRN.MdiParent = Me
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNINWARD_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNINWARD_TOOL.Click
        Try
            Dim OBJGRN As New GRN
            OBJGRN.MdiParent = Me
            OBJGRN.FRMSTRING = "INWARD"
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewConsumeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONSUMEADD.Click
        Try
            Dim OBJGRN As New Consumption
            OBJGRN.MdiParent = Me
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PURINVADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURINVADD.Click
        Try
            Dim OBJGRN As New PurchaseMaster
            OBJGRN.MdiParent = Me
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MFG2ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MFG2ADD.Click
        Try
            Dim OBJMFG As New Mfg2
            OBJMFG.MdiParent = Me
            OBJMFG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GDNADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GDNADD.Click
        Try
            Dim OBJGDN As New GDN
            OBJGDN.MdiParent = Me

            OBJGDN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MFG2EDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MFG2EDIT.Click
        Dim OBJMFGDETAILS As New Mfg2Details
        OBJMFGDETAILS.MdiParent = Me
        OBJMFGDETAILS.Show()
    End Sub

    Private Sub PSFINALEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PSFINALEDIT.Click
        Dim OBJfinalPackingSlipDetails As New finalPackingSlipDetails
        OBJfinalPackingSlipDetails.MdiParent = Me
        OBJfinalPackingSlipDetails.Show()
    End Sub

    Private Sub GATEPASSEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GATEPASSEDIT.Click
        Dim OBJgatepassdetails As New gatepassdetails
        OBJgatepassdetails.MdiParent = Me
        OBJgatepassdetails.Show()
    End Sub

    Private Sub SALEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEADD.Click
        Dim OBJInvoiceMaster As New InvoiceMaster
        OBJInvoiceMaster.MdiParent = Me
        OBJInvoiceMaster.Show()
    End Sub

    Private Sub SALEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALEEDIT.Click
        Try
            Dim OBJINVDETAIL As New InvoiceDetails
            OBJINVDETAIL.MdiParent = Me
            OBJINVDETAIL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewLoanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOANADD.Click
        Try
            Dim OBJLoanMaster As New LoanMaster
            OBJLoanMaster.MdiParent = Me
            OBJLoanMaster.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingLoanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LOANEDIT.Click
        Try
            Dim OBJLoanMaster As New LoanDetail
            OBJLoanMaster.MdiParent = Me
            OBJLoanMaster.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingConsumeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONSUMEEDIT.Click
        Try
            Dim OBJconsumptiondetails As New ConsumptionDetails
            OBJconsumptiondetails.MdiParent = Me
            OBJconsumptiondetails.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FINALCUTTINGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FINALCUTTINGEDIT.Click
        Try
            Dim OBJfinalcuttingdetails As New finalcuttingdetails
            OBJfinalcuttingdetails.MdiParent = Me
            OBJfinalcuttingdetails.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PURINVEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURINVEDIT.Click
        Try
            Dim OBJPUR As New PurchaseDetails
            OBJPUR.MdiParent = Me
            OBJPUR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StoreStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StoreStockToolStripMenuItem.Click
        Try
            Dim OBJPUR As New StoreStockFilter
            OBJPUR.MdiParent = Me
            OBJPUR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEPARTMENTPRICELIST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEPARTMENTPRICELIST.Click
        Try
            Dim OBJPUR As New DepartmentRateList
            OBJPUR.MdiParent = Me
            OBJPUR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MERCHANTPRICELIST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MERCHANTPRICELIST.Click
        Try
            Dim OBJPUR As New DepartmentRateListDetails
            OBJPUR.MdiParent = Me
            OBJPUR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        Try
            Dim OBJPR As New PurchaseRequestDetails
            OBJPR.MdiParent = Me
            OBJPR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DetailsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 
        Try
            Dim OBJQUOT As New PurchaseQuotationDetails
            OBJQUOT.MdiParent = Me
            OBJQUOT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProductionFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductionFilterToolStripMenuItem.Click
        Try
            Dim OBJPO As New mfgfilter
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewProgramToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROGRAMADD.Click
        Try
            Dim OBJprg As New ProgramMaster
            OBJprg.MdiParent = Me
            OBJprg.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROGRAMEDIT.Click
        Try
            Dim OBJprg As New ProgramDetails
            OBJprg.MdiParent = Me
            OBJprg.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JWOEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JWOEDIT.Click
        Try
            Dim OBJprg As New JobOutDetails
            OBJprg.MdiParent = Me
            OBJprg.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JWIEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JWIEDIT.Click
        Try
            Dim OBJprg As New JobInDetails
            OBJprg.MdiParent = Me
            OBJprg.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALE_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALE_TOOL.Click
        Dim OBJInvoiceMaster As New InvoiceMaster
        OBJInvoiceMaster.MdiParent = Me
        OBJInvoiceMaster.Show()
    End Sub

    Private Sub GDN_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GDN_TOOL.Click
        Try
            Dim OBJGDN As New GDN
            OBJGDN.MdiParent = Me
            OBJGDN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LIADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LIADD.Click
        Try
            Dim OBJ As New LabourInward
            OBJ.MdiParent = Me

            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHECK_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHECK_TOOL.Click
        Try
            Dim OBJCHECKING As New GRNChecking
            OBJCHECKING.MdiParent = Me
            OBJCHECKING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROCESSOUTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROCESSOUTADD.Click
        Try
            Dim OBJ As New ProcessOut
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub FINALCUTTING_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FINALCUTTING_TOOL.Click
        Try
            Dim OBJGRN As New FinalCuttingProcess
            OBJGRN.MdiParent = Me
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROCESSINADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROCESSINADD.Click
        Try
            Dim OBJ As New ProcessIn
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PPSADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PPSADD.Click
        Try
            Dim OBJ As New PartyPackingSlip
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GreyStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GREYSTOCK.Click
        Try
            Dim PASS As String = InputBox("Enter Master Password", "TEXPRO")
            If PASS <> "kp3042" Then
                MsgBox("Invalid Password, You are not allowed to Transfer Stock", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim OBJOPENST As New OpeningStock
            OBJOPENST.MdiParent = Me
            OBJOPENST.TYPE = "GREY"
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StoreStockToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STORESTOCK.Click
        Try
            Dim PASS As String = InputBox("Enter Master Password", "TEXPRO")
            If PASS <> "kp3042" Then
                MsgBox("Invalid Password, You are not allowed to Transfer Stock", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim OBJOPENST As New OpeningStock
            OBJOPENST.MdiParent = Me
            OBJOPENST.TYPE = "STORE"
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProcessStockToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROCESSSTOCK.Click
        Try
            Dim PASS As String = InputBox("Enter Master Password", "TEXPRO")
            If PASS <> "kp3042" Then
                MsgBox("Invalid Password, You are not allowed to Transfer Stock", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim OBJOPENST As New OpeningStock
            OBJOPENST.MdiParent = Me
            OBJOPENST.TYPE = "PROCESS"
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BaleStockToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BALESTOCK.Click
        Try
            Dim PASS As String = InputBox("Enter Master Password", "TEXPRO")
            If PASS <> "kp3042" Then
                MsgBox("Invalid Password, You are not allowed to Transfer Stock", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim OBJOPENST As New OpeningStock
            OBJOPENST.MdiParent = Me
            OBJOPENST.TYPE = "BALE"
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobOutStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOBOUTSTOCK.Click
        Try
            Dim PASS As String = InputBox("Enter Master Password", "TEXPRO")
            If PASS <> "kp3042" Then
                MsgBox("Invalid Password, You are not allowed to Transfer Stock", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim OBJOPENST As New OpeningStock
            OBJOPENST.MdiParent = Me
            OBJOPENST.TYPE = "JOBOUT"
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRANSFERDATA.Click
        Try
            Dim OBJOPENST As New YearTransfer
            OBJOPENST.MdiParent = Me
            OBJOPENST.FRMSTRING = "YEARTRANSFER"
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PACKINGSLIP_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PACKINGSLIP_TOOL.Click
        Try
            Dim OBJOPENST As New finalPackingslip
            OBJOPENST.MdiParent = Me
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROFORMAADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROFORMAADD.Click
        Try
            Dim OBJOPENST As New ProformaInvoice
            OBJOPENST.MdiParent = Me
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DepatchFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepatchFilterToolStripMenuItem.Click
        Try
            Dim objgdn As New DespatchFilter
            objgdn.MdiParent = Me
            objgdn.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobBaleStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JOBBALESTOCK.Click
        Try
            Dim PASS As String = InputBox("Enter Master Password", "TEXPRO")
            If PASS <> "kp3042" Then
                MsgBox("Invalid Password, You are not allowed to Transfer Stock", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim OBJOPENST As New OpeningStock
            OBJOPENST.MdiParent = Me
            OBJOPENST.TYPE = "JOBBALE"
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DispatchRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DispatchRegisterToolStripMenuItem.Click
        Try
            Dim objgdn As New DispatchRegisterFilter
            objgdn.MdiParent = Me
            objgdn.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GreyStockRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreyStockRegisterToolStripMenuItem.Click
        Try
            Dim objgdn As New GRNSTOCKFILTER
            objgdn.MdiParent = Me
            objgdn.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub MfgBeforeCuttingRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MfgBeforeCuttingRegisterToolStripMenuItem.Click
        Try
            Dim objgdn As New Mfg1Filter
            objgdn.MdiParent = Me
            objgdn.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub MfgAfterCuttingRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MfgAfterCuttingRegisterToolStripMenuItem.Click
        Try
            Dim objgdn As New mfg2filter
            objgdn.MdiParent = Me
            objgdn.FRMSTRING = "MFG"
            objgdn.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MfgLooseRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MfgLooseRegisterToolStripMenuItem.Click
        Try
            Dim objgdn As New mfg2filter
            objgdn.MdiParent = Me
            objgdn.FRMSTRING = "FCP"
            objgdn.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewOpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BALEOPENADD.Click
        Try
            Dim objBALE As New BaleOpen
            objBALE.MdiParent = Me
            objBALE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewStockToolStripMenuItem.Click
        Try
            Dim PASS As String = InputBox("Enter Master Password", "TEXPRO")
            If PASS <> "infosys123" Then
                MsgBox("Invalid Password, You are not allowed to Adjust Stock", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim objBALE As New StockAdjustment
            objBALE.MdiParent = Me
            objBALE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LotNoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LotNoToolStripMenuItem.Click
        Try
            Dim objBALE As New SwapLotno
            objBALE.MdiParent = Me
            objBALE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MergeParameterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MERGE_MASTER.Click
        Try
            Dim objBALE As New MERGEPARAMETER
            objBALE.MdiParent = Me
            objBALE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROFORMAEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROFORMAEDIT.Click
        Try
            Dim objINVOICE As New ProformaInvoiceDetails
            objINVOICE.MdiParent = Me
            objINVOICE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROFORMA_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROFORMA_TOOL.Click
        Try
            Dim objINVOICE As New ProformaInvoice
            objINVOICE.MdiParent = Me
            objINVOICE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALERETADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALERETADD.Click
        Try
            Dim objSaleReturn As New SalesReturn
            objSaleReturn.MdiParent = Me
            objSaleReturn.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALERETEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALERETEDIT.Click
        Try
            Dim objSaleReturn As New SaleReturnDetail
            objSaleReturn.MdiParent = Me
            objSaleReturn.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ITEMREPORTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMREPORTToolStripMenuItem.Click
        Try
            Dim objItemReport As New ItemFilter
            objItemReport.MdiParent = Me
            objItemReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EXPENSEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXPENSEADD.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "EXPMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EXPENSEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXPENSEEDIT.Click
        Try
            Dim objcitymaster As New CityDetails
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "EXPMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EXPENSERATE_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXPENSERATE_MASTER.Click
        Try
            Dim OBJEXPENSE As New Expense
            OBJEXPENSE.MdiParent = Me
            OBJEXPENSE.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AnalyticalReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalyticalReportToolStripMenuItem.Click
        Try
            Dim OBJCHART As New AnalyticalFilterDispatch
            OBJCHART.MdiParent = Me
            OBJCHART.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingOpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BALEOPENEDIT.Click
        Try
            Dim OBJBALEDETAIL As New BaleOpenDetails
            OBJBALEDETAIL.MdiParent = Me
            OBJBALEDETAIL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub WhiteFoldingStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WhiteFoldingStockToolStripMenuItem.Click
        Try
            Dim OBJCUTTING As New CuttingFilter
            OBJCUTTING.MdiParent = Me
            OBJCUTTING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STAMPADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STAMPADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "STAMP"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TransferStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRANSFERSTOCK.Click
        Try
            Dim OBJOPENST As New YearTransfer
            OBJOPENST.MdiParent = Me
            OBJOPENST.FRMSTRING = "STOCKTRANSFER"
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TransferUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERTRANSFER.Click
        Try
            Dim OBJYEAR As New YearTransfer
            OBJYEAR.FRMSTRING = "USERTRANSFER"
            OBJYEAR.MdiParent = Me
            OBJYEAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LOOSESTOCK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LOOSESTOCK.Click
        Try
            Dim PASS As String = InputBox("Enter Master Password", "TEXPRO")
            If PASS <> "kp3042" Then
                MsgBox("Invalid Password, You are not allowed to Transfer Stock", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim OBJOPENST As New OpeningStock
            OBJOPENST.MdiParent = Me
            OBJOPENST.TYPE = "LOOSE"
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNReportsToolStripMenuItem.Click
        Try
            Dim ObjGRN As New GRNFilter
            ObjGRN.MdiParent = Me
            ObjGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CheckingFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckingFilterToolStripMenuItem.Click
        Try
            Dim Objchk As New CheckingFilter
            Objchk.MdiParent = Me
            Objchk.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FINALSTOCK_REPORT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FINALSTOCK_REPORT.Click
        Try
            Dim objrep As New clsReportDesigner("Final Stock Statement", System.AppDomain.CurrentDomain.BaseDirectory & "Final Stock Statement.xlsx", 2)
            objrep.FINALSTOCK_REPORT_EXCEL(CmpId, Locationid, YearId, "FINAL STOCK STATEMENT")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PartyGroupMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PartyGroupMasterToolStripMenuItem.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "PARTYGROUP"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub BaleStockRegiaterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BaleStockRegiaterToolStripMenuItem.Click
        Try
            Dim OBJBALE As New BaleStockFilter
            OBJBALE.MdiParent = Me
            OBJBALE.Show()
            OBJBALE.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingPartyGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingPartyGroupToolStripMenuItem.Click
        Try
            Dim objCategoryDetails As New CategoryDetails
            objCategoryDetails.MdiParent = Me
            objCategoryDetails.frmstring = "PARTYGROUP"
            objCategoryDetails.Show()
            objCategoryDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ConsumptionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsumptionReportToolStripMenuItem.Click
        Try
            Dim OBJOPENST As New DyeingConsumption
            OBJOPENST.MdiParent = Me
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ExpenseReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpenseReportToolStripMenuItem.Click
        Try
            Dim objcitymaster As New ExpenseFilter
            objcitymaster.MdiParent = Me
            objcitymaster.FRMSTRING = "EXPENSE FILTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub JobOutStockToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JobOutStockToolStripMenuItem1.Click
        Try
            Dim OBJGRN As New PJOfilter
            OBJGRN.MdiParent = Me
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DesignCostToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesignCostToolStripMenuItem.Click
        Try
            Dim objgdn As New DesignCostFilter
            objgdn.MdiParent = Me
            objgdn.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SOEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOEDIT.Click
        Try
            Dim objso As New SaleOrderDetails
            objso.MdiParent = Me
            objso.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ConsumptionReportDesignToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsumptionReportDesignToolStripMenuItem.Click
        Try
            Dim OBJOPENST As New DesignConsumptionFilter
            OBJOPENST.MdiParent = Me
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub QualityWiseRateListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QualityWiseRateListToolStripMenuItem.Click
        Try
            Dim OBJOPENST As New QualityPriceMaster
            OBJOPENST.FRMSTRING = "QUALITY"
            OBJOPENST.MdiParent = Me
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MerchantWisePriceListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MerchantWisePriceListToolStripMenuItem.Click
        Try
            Dim OBJOPENST As New MerchantPriceList
            OBJOPENST.MdiParent = Me
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StoreItemWisePriceListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StoreItemWisePriceListToolStripMenuItem.Click
        Try
            Dim OBJOPENST As New QualityPriceMaster
            OBJOPENST.FRMSTRING = "ITEM"
            OBJOPENST.MdiParent = Me
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DESIGNREG_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DESIGNREG_TOOL.Click
        Try
            Dim OBJDESIGN As New DesignIssueRegister
            OBJDESIGN.MdiParent = Me
            OBJDESIGN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ISSUEMERCHANTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ISSUEMERCHANTADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "ISSUEMERCHANT"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DESIGNREG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DESIGNREG.Click
        Try
            Dim OBJDESIGN As New DesignIssueRegister
            OBJDESIGN.MdiParent = Me
            OBJDESIGN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ISSUEMERCHANTEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ISSUEMERCHANTEDIT.Click
        Try
            Dim objCategoryDetails As New CategoryDetails
            objCategoryDetails.MdiParent = Me
            objCategoryDetails.frmstring = "ISSUEMERCHANT"
            objCategoryDetails.Show()
            objCategoryDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewEntryToolStripMenuItem.Click
        Try
            Dim OBJDESIGN As New DesignIssue
            OBJDESIGN.MdiParent = Me
            OBJDESIGN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingEntryToolStripMenuItem.Click
        Try
            Dim OBJDESIGN As New DesignIssueRegister
            OBJDESIGN.MdiParent = Me
            OBJDESIGN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BLOCKUSER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLOCKUSER.Click
        Try
            Dim OBJUSER As New BlockUser
            OBJUSER.MdiParent = Me
            OBJUSER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BackupCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupCompany.Click
        Try
            backup()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LoanDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoanDetailsToolStripMenuItem.Click
        Try
            Dim OBJLOAN As New LoanFilter
            OBJLOAN.MdiParent = Me
            OBJLOAN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GDNEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GDNEDIT.Click
        Try
            Dim OBJGDN As New GDNDetails
            OBJGDN.MdiParent = Me
            OBJGDN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PendingCostReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendingCostReportToolStripMenuItem.Click
        Try
            Dim OBJPENDING As New PendingCostReport
            OBJPENDING.MdiParent = Me
            OBJPENDING.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRSTOCK_MENU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRSTOCK_MENU.Click
        Try
            Dim OBJGR As New GRStockReport
            OBJGR.MdiParent = Me
            OBJGR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COLORATEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COLORRATEADD.Click
        Try
            Dim OBJCOLOR As New ColorRateMaster
            OBJCOLOR.MdiParent = Me
            OBJCOLOR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub COLORRATEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COLORRATEEDIT.Click
        Try
            Dim OBJCOLOR As New ColorRateDetails
            OBJCOLOR.MdiParent = Me
            OBJCOLOR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ValueLossReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValueLossReportToolStripMenuItem.Click
        Try
            Dim OBJFINAL As New FinalCuttingFilter
            OBJFINAL.MdiParent = Me
            OBJFINAL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateLotRateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateLotRateToolStripMenuItem.Click
        Try
            Dim OBJLOT As New UpdateLotRate
            OBJLOT.MdiParent = Me
            OBJLOT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HSNADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HSNADD.Click
        Try
            Dim OBJHSN As New HSNMaster
            OBJHSN.MdiParent = Me
            OBJHSN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HSNEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HSNEDIT.Click
        Try
            Dim OBJHSN As New HSNDetails
            OBJHSN.MdiParent = Me
            OBJHSN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RECADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECADD.Click
        Try
            Dim OBJREC As New Receipt
            OBJREC.MdiParent = Me
            OBJREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RECEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECEDIT.Click
        Try
            Dim OBJREC As New ReceiptDetails
            OBJREC.MdiParent = Me
            OBJREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYADD.Click
        Try
            Dim OBJPAY As New PaymentMaster
            OBJPAY.MdiParent = Me
            OBJPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYEDIT.Click
        Try
            Dim OBJPAY As New PaymentDetails
            OBJPAY.MdiParent = Me
            OBJPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JVADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JVADD.Click
        Try
            Dim OBJJV As New journal
            OBJJV.MdiParent = Me
            OBJJV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JVEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JVEDIT.Click
        Try
            Dim OBJJV As New JournalDetails
            OBJJV.MdiParent = Me
            OBJJV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONTRAADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTRAADD.Click
        Try
            Dim OBJCON As New ContraEntry
            OBJCON.MdiParent = Me
            OBJCON.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONTRAEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CONTRAEDIT.Click
        Try
            Dim OBJCON As New ContraDetails
            OBJCON.MdiParent = Me
            OBJCON.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CREDITADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREDITADD.Click
        Try
            Dim OBJCN As New CREDITNOTE
            OBJCN.MdiParent = Me
            OBJCN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CREDITEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CREDITEDIT.Click
        Try
            Dim OBJCN As New CreditNoteDetails
            OBJCN.MdiParent = Me
            OBJCN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEBITADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEBITADD.Click
        Try
            Dim OBJDN As New DebitNote
            OBJDN.MdiParent = Me
            OBJDN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DEBITEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEBITEDIT.Click
        Try
            Dim OBJDN As New DebitNoteDetails
            OBJDN.MdiParent = Me
            OBJDN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MANUALMATCHINGADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MANUALMATCHINGADD.Click
        Try
            Dim OBJMATCH As New ManualMatching
            OBJMATCH.MdiParent = Me
            OBJMATCH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MANUALMATCHINGEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MANUALMATCHINGEDIT.Click
        Try
            Dim OBJMATCH As New ManualMatchingDetails
            OBJMATCH.MdiParent = Me
            OBJMATCH.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseRegisterToolStripMenuItem2.Click
        Try
            Dim objpurreg As New PurchaseRegister
            objpurreg.MdiParent = Me
            objpurreg.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub SaleRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleRegisterToolStripMenuItem2.Click
        Try
            Dim objsalereg As New SaleRegister
            objsalereg.MdiParent = Me
            objsalereg.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JournalRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalRegisterToolStripMenuItem2.Click
        Try
            Dim OBJJVREG As New JournalRegister
            OBJJVREG.MdiParent = Me
            OBJJVREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ContraRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContraRegisterToolStripMenuItem2.Click
        Try
            Dim OBJCONTRAREG As New ContraRegister
            OBJCONTRAREG.MdiParent = Me
            OBJCONTRAREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DebitNoteRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebitNoteRegisterToolStripMenuItem.Click
        Try
            Dim OBJDNREG As New DNRegister
            OBJDNREG.MdiParent = Me
            OBJDNREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CreditNoteRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditNoteRegisterToolStripMenuItem.Click
        Try
            Dim OBJCNREG As New CNRegister
            OBJCNREG.MdiParent = Me
            OBJCNREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BankBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BankBookToolStripMenuItem.Click
        Try
            Dim OBJBANKREG As New BankRegister
            OBJBANKREG.MdiParent = Me
            OBJBANKREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CashBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashBookToolStripMenuItem.Click
        Try
            Dim OBJCASHREG As New cashregister1
            OBJCASHREG.MdiParent = Me
            OBJCASHREG.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AdvancesSettlementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdvancesSettlementToolStripMenuItem.Click
        Try
            Dim OBJADV As New Adv_Receivable_settlement
            OBJADV.flag_adv_settlement = True
            OBJADV.MdiParent = Me
            OBJADV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceivableSettlementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceivableSettlementToolStripMenuItem.Click
        Try
            Dim OBJADV As New Adv_Receivable_settlement
            OBJADV.flag_Rec_settlement = True
            OBJADV.MdiParent = Me
            OBJADV.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DayBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayBookToolStripMenuItem.Click
        Try
            Dim OBJDAYBOOK As New DayBook
            OBJDAYBOOK.MdiParent = Me
            OBJDAYBOOK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerOnScreenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerOnScreenToolStripMenuItem.Click
        Try
            Dim objledger As New LedgerSummary
            objledger.MdiParent = Me
            objledger.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgerBookToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgerBookToolStripMenuItem1.Click
        Try
            Dim objledgerbook As New RegisterDetails
            objledgerbook.MdiParent = Me
            objledgerbook.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OutstandingFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutstandingFilterToolStripMenuItem.Click
        Try
            Dim OBJOP As New OutstandingFilter
            OBJOP.MdiParent = Me
            OBJOP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LedgersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LedgersToolStripMenuItem.Click
        Try
            Dim OBJLEDGER As New LedgerFilter
            OBJLEDGER.MdiParent = Me
            OBJLEDGER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GSTTAXFILTER_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GSTTAXFILTER_MASTER.Click
        Try
            Dim OBJTAX As New GSTTaxFilter
            OBJTAX.MdiParent = Me
            OBJTAX.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GroupSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupSummaryToolStripMenuItem.Click
        Try
            Dim OBJGROUP As New GroupRegister
            OBJGROUP.MdiParent = Me
            OBJGROUP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub TrialBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrialBalanceToolStripMenuItem.Click
        Try
            Dim OBJTB As New TB
            OBJTB.MdiParent = Me
            OBJTB.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProfitLossToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfitLossToolStripMenuItem.Click
        Try
            Dim objpl As New PL
            objpl.MdiParent = Me
            objpl.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BalanceSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceSheetToolStripMenuItem.Click
        Try
            Dim OBJBALANCESHEET As New BS
            OBJBALANCESHEET.MdiParent = Me
            OBJBALANCESHEET.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TDSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDSToolStripMenuItem.Click
        Try
            Dim OBJTDS1 As New TDS
            OBJTDS1.MdiParent = Me
            OBJTDS1.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TDSCHALLAN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDSCHALLAN_MASTER.Click
        Try
            Dim OBJTDS As New TDSChallan
            OBJTDS.MdiParent = Me
            OBJTDS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TDSDeductedNotDedictedReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TDSDeductedNotDedictedReportToolStripMenuItem.Click
        Try
            Dim OBJTDS As New TDSDeductedReport
            OBJTDS.MdiParent = Me
            OBJTDS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InterestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InterestToolStripMenuItem.Click
        Try
            Dim OBJINTCALC As New InterestCalc
            OBJINTCALC.MdiParent = Me
            OBJINTCALC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub IntrestCalculatorSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntrestCalculatorSummaryToolStripMenuItem.Click
        Try
            Dim OBJINTCALC As New InterestCalc_Summary
            OBJINTCALC.MdiParent = Me
            OBJINTCALC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceiptAdjustedReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceiptAdjustedReportToolStripMenuItem.Click
        Try
            Dim OBJREC As New filter
            OBJREC.MdiParent = Me
            OBJREC.frmstring = "RECEIPTMONTHLYADJ"
            OBJREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PaymentAdjustedReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentAdjustedReportToolStripMenuItem.Click
        Try
            Dim OBJPAY As New filter
            OBJPAY.MdiParent = Me
            OBJPAY.frmstring = "PAYMENTMONTHLYADJ"
            OBJPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RECODATA_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECODATA_MASTER.Click
        Try
            Dim OBJRECO As New ReconcileData
            OBJRECO.MdiParent = Me
            OBJRECO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DefaultRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultRegisterToolStripMenuItem.Click
        Try
            Dim objCategory As New DefaultRegister
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DefaultTypeRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultTypeRegisterToolStripMenuItem.Click
        Try
            Dim objCategory As New DefaultScreentype
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PURCHASE_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PURCHASE_TOOL.Click
        Try
            Dim OBJPUR As New PurchaseMaster
            OBJPUR.MdiParent = Me
            OBJPUR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPENINGBILL_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPENINGBILL_MASTER.Click
        Try
            Dim OBJOP As New OpeningBills
            OBJOP.FRMSTRING = "OPENINGBILLS"
            OBJOP.MdiParent = Me
            OBJOP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPENINGBALANCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPENINGBALANCE.Click
        Try
            Dim OBJOP As New OpeningBalance
            OBJOP.MdiParent = Me
            OBJOP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPENINGSTOCKVALUE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPENINGSTOCKVALUE.Click
        Try
            Dim OBJOP As New OpeningClosingStock
            OBJOP.MdiParent = Me
            OBJOP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AnalyticalReportConsumptionToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AnalyticalReportConsumptionToolStripMenuItem1.Click
        Try
            Dim OBJCON As New AnalyticalFilterConsumption
            OBJCON.MdiParent = Me
            OBJCON.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CToolStripMenuItem.Click
        Try
            Dim OBJCON As New AnalyticalFilterPurchase
            OBJCON.MdiParent = Me
            OBJCON.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JOBMERCHANT_UPDATE_Click(sender As Object, e As EventArgs) Handles JOBMERCHANT_UPDATE.Click
        Try
            Dim OBJUPDATE As New UpdateJobMerchant
            OBJUPDATE.MdiParent = Me
            OBJUPDATE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROCESSCONTRACTORCONFIG_MASTER_Click(sender As Object, e As EventArgs) Handles PROCESSCONTRACTORCONFIG_MASTER.Click
        Try
            Dim OBJPROCESS As New ProcessContractorConfig
            OBJPROCESS.MdiParent = Me
            OBJPROCESS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FinalPackingFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FinalPackingFilterToolStripMenuItem.Click
        Try
            Dim OBJPACK As New FinalPackingFilter
            OBJPACK.MdiParent = Me
            OBJPACK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JobDetailsToolStripMenuItem.Click
        Try
            Dim OBJJO As New JobOutLotDetailsReport
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PayableOutstandingToolStripMenuItem__Click(sender As Object, e As EventArgs) Handles PayableOutstandingToolStripMenuItem_.Click
        Try
            Dim OBJOUT As New OutstandingFilter
            OBJOUT.FRMSTRING = "PAYOUTSTANDING"
            OBJOUT.MdiParent = Me
            OBJOUT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReceivableOutstandingToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ReceivableOutstandingToolStripMenuItem.Click
        Try
            Dim OBJOUT As New OutstandingFilter
            OBJOUT.FRMSTRING = "RECOUTSTANDING"
            OBJOUT.MdiParent = Me
            OBJOUT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VOUCHERADD_Click(sender As Object, e As EventArgs) Handles VOUCHERADD.Click
        Try
            Dim OBJNP As New ExpenseVoucher
            OBJNP.MdiParent = Me
            OBJNP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub VOUCHEREDIT_Click(sender As Object, e As EventArgs) Handles VOUCHEREDIT.Click
        Try
            Dim OBJNP As New ExpenseVoucherDetails
            OBJNP.MdiParent = Me
            OBJNP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADITEMMENU_Click(sender As Object, e As EventArgs) Handles UPLOADITEMMENU.Click
        Try
            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub
            '************************************ ITEM UPLOAD ****************************
            'upload the files data
            ''Reading from Excel Woorkbook
            Dim cPart As Microsoft.Office.Interop.Excel.Range
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open("D:\" & InputBox("Enter File Name").ToString.Trim, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets("Sheet1")

            'GRID
            Dim ADDITEM As Boolean = True
            Dim TEMPITEMNAME As String = ""

            Dim DTSAVE As New System.Data.DataTable
            DTSAVE.Columns.Add("ITEMNAME")
            DTSAVE.Columns.Add("DEPARTMENT")
            DTSAVE.Columns.Add("UNIT")
            DTSAVE.Columns.Add("HSNCODE")

            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()

            Dim FROMROWNO As Integer = Val(InputBox("Enter Start Row No"))
            Dim TOROWNO As Integer = Val(InputBox("Enter End Row No"))

            For I As Integer = FROMROWNO To TOROWNO

                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVE("ITEMNAME") = oSheet.Range("A" & I.ToString).Text
                Else
                    DTROWSAVE("ITEMNAME") = ""
                End If

                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVE("DEPARTMENT") = oSheet.Range("B" & I.ToString).Text
                Else
                    DTROWSAVE("DEPARTMENT") = ""
                End If

                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVE("UNIT") = oSheet.Range("C" & I.ToString).Text
                Else
                    DTROWSAVE("UNIT") = ""
                End If

                If IsDBNull(oSheet.Range("D" & I.ToString).Text) = False Then
                    DTROWSAVE("HSNCODE") = oSheet.Range("D" & I.ToString).Text
                Else
                    DTROWSAVE("HSNCODE") = ""
                End If


                'CHECK DEPARTMENTMASTER IF NOT PRESENT THEN ADD NEW
                Dim ALPARAVAL As New ArrayList
                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As DataTable = OBJCMN.search("DEPARTMENT_id AS DEPARTMENT", "", "DEPARTMENTMASTER", "AND DEPARTMENT_NAME = '" & DTROWSAVE("DEPARTMENT") & "' AND DEPARTMENT_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW DEPARTMENT
                    Dim OBJDEPARTMENT As New ClsDepartmentMaster
                    OBJDEPARTMENT.alParaval.Add(DTROWSAVE("DEPARTMENT"))
                    OBJDEPARTMENT.alParaval.Add("")
                    OBJDEPARTMENT.alParaval.Add(CmpId)
                    OBJDEPARTMENT.alParaval.Add(0)
                    OBJDEPARTMENT.alParaval.Add(Userid)
                    OBJDEPARTMENT.alParaval.Add(YearId)
                    OBJDEPARTMENT.alParaval.Add(0)
                    OBJDEPARTMENT.alParaval.Add(1)
                    Dim INTRESDEP As Integer = OBJDEPARTMENT.save()
                End If


                'check whether ITEMNAME is already present or not
                DTTABLE = OBJCMN.search("ITEM_NAME AS ITEMNAME", "", "ITEMMASTER", " AND ITEM_NAME = '" & DTROWSAVE("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then GoTo SKIPLINE


                'ADD IN ACCOUNTSMASTER
                ALPARAVAL.Clear()
                Dim OBJSM As New clsItemmaster

                ALPARAVAL.Add("Stores & Supplies - Production")
                ALPARAVAL.Add("")
                ALPARAVAL.Add(UCase(DTROWSAVE("ITEMNAME")))

                ALPARAVAL.Add(DTROWSAVE("DEPARTMENT"))   'DEPARTMENT
                ALPARAVAL.Add(DTROWSAVE("ITEMNAME"))
                ALPARAVAL.Add(DTROWSAVE("UNIT"))   'UNIT
                ALPARAVAL.Add(0)    'OPSTOCK
                ALPARAVAL.Add(0)    'OPVALUE
                ALPARAVAL.Add(0)    'REORDER
                ALPARAVAL.Add(0)    'UPPER
                ALPARAVAL.Add(0)    'LOWER
                ALPARAVAL.Add(DTROWSAVE("HSNCODE"))

                ALPARAVAL.Add("")   'RATETYPE
                ALPARAVAL.Add("")   'GRIDRATE

                ALPARAVAL.Add("")   'REMARKS
                ALPARAVAL.Add("ITEM")
                ALPARAVAL.Add(0)

                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(0)


                OBJSM.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJSM.SAVE()

                DTROWSAVE = DTSAVE.NewRow()

SKIPLINE:
            Next

            oBook.Close()

            Exit Sub

            '************************************ END OF CODE FOR ITEM UPLOAD ****************************

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub WEAVERADD_Click(sender As Object, e As EventArgs) Handles WEAVERADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "WEAVER"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub WEAVEREDIT_Click(sender As Object, e As EventArgs) Handles WEAVEREDIT.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.frmstring = "WEAVER"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PROCESSTYPEADD_Click(sender As Object, e As EventArgs) Handles PROCESSTYPEADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "PROCESSTYPE"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PROCESSTYPEEDIT_Click(sender As Object, e As EventArgs) Handles PROCESSTYPEEDIT.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.frmstring = "PROCESSTYPE"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PACKINGSUMM_TOOL_Click(sender As Object, e As EventArgs) Handles PACKINGSUMM_TOOL.Click
        Try
            Dim OBJSUMM As New PackingSummary
            OBJSUMM.MdiParent = Me
            OBJSUMM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PACKINGSUMMADD_Click(sender As Object, e As EventArgs) Handles PACKINGSUMMADD.Click
        Try
            Dim OBJSUMM As New PackingSummary
            OBJSUMM.MdiParent = Me
            OBJSUMM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PACKINGSUMMEDIT_Click(sender As Object, e As EventArgs) Handles PACKINGSUMMEDIT.Click
        Try
            Dim OBJSUMM As New PackingSummaryDetails
            OBJSUMM.MdiParent = Me
            OBJSUMM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADACCOUNTMENU_Click(sender As Object, e As EventArgs) Handles UPLOADACCOUNTMENU.Click
        Try
            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub

            '************************************ LEDGER UPLOAD ****************************
            'upload the files data
            ''Reading from Excel Woorkbook
            Dim cPart As Microsoft.Office.Interop.Excel.Range
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open("D:\" & InputBox("Enter File Name").ToString.Trim, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets("Sheet1")

            'GRID
            Dim ADDITEM As Boolean = True
            Dim TEMPITEMNAME As String = ""

            Dim DTSAVE As New System.Data.DataTable
            DTSAVE.Columns.Add("CODE")
            DTSAVE.Columns.Add("COMPANYNAME")
            DTSAVE.Columns.Add("ADD1")
            DTSAVE.Columns.Add("ADD2")
            DTSAVE.Columns.Add("ADDRESS")
            DTSAVE.Columns.Add("CITYNAME")
            DTSAVE.Columns.Add("PINNO")
            DTSAVE.Columns.Add("STATE")
            DTSAVE.Columns.Add("COUNTRY")
            DTSAVE.Columns.Add("PHONENO")
            DTSAVE.Columns.Add("MOBILENO")
            DTSAVE.Columns.Add("GSTIN")
            DTSAVE.Columns.Add("GROUPNAME")
            DTSAVE.Columns.Add("PANNO")
            DTSAVE.Columns.Add("BROKER")
            DTSAVE.Columns.Add("TRANSPORT")
            DTSAVE.Columns.Add("EMAIL")

            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()

            Dim FROMROWNO As Integer = Val(InputBox("Enter Start Row No"))
            Dim TOROWNO As Integer = Val(InputBox("Enter End Row No"))

            For I As Integer = FROMROWNO To TOROWNO

                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVE("CODE") = oSheet.Range("A" & I.ToString).Text
                Else
                    DTROWSAVE("CODE") = ""
                End If

                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVE("COMPANYNAME") = oSheet.Range("B" & I.ToString).Text
                Else
                    DTROWSAVE("COMPANYNAME") = ""
                End If

                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVE("ADD1") = oSheet.Range("C" & I.ToString).Text
                Else
                    DTROWSAVE("ADD1") = ""
                End If

                If IsDBNull(oSheet.Range("D" & I.ToString).Text) = False Then
                    DTROWSAVE("ADD2") = oSheet.Range("D" & I.ToString).Text
                Else
                    DTROWSAVE("ADD2") = ""
                End If

                If IsDBNull(oSheet.Range("E" & I.ToString).Text) = False Then
                    DTROWSAVE("ADDRESS") = oSheet.Range("E" & I.ToString).Text
                Else
                    DTROWSAVE("ADDRESS") = ""
                End If

                If IsDBNull(oSheet.Range("F" & I.ToString).Text) = False Then
                    DTROWSAVE("CITYNAME") = oSheet.Range("F" & I.ToString).Text
                Else
                    DTROWSAVE("CITYNAME") = ""
                End If

                If IsDBNull(oSheet.Range("G" & I.ToString).Text) = False Then
                    DTROWSAVE("PINNO") = oSheet.Range("G" & I.ToString).Text
                Else
                    DTROWSAVE("PINNO") = 0
                End If

                If IsDBNull(oSheet.Range("H" & I.ToString).Text) = False Then
                    DTROWSAVE("STATE") = oSheet.Range("H" & I.ToString).Text
                Else
                    DTROWSAVE("STATE") = ""
                End If

                If IsDBNull(oSheet.Range("I" & I.ToString).Text) = False Then
                    DTROWSAVE("COUNTRY") = oSheet.Range("I" & I.ToString).Text
                Else
                    DTROWSAVE("COUNTRY") = ""
                End If

                If IsDBNull(oSheet.Range("J" & I.ToString).Text) = False Then
                    DTROWSAVE("PHONENO") = oSheet.Range("J" & I.ToString).Text
                Else
                    DTROWSAVE("PHONENO") = ""
                End If

                If IsDBNull(oSheet.Range("K" & I.ToString).Text) = False Then
                    DTROWSAVE("MOBILENO") = oSheet.Range("K" & I.ToString).Text
                Else
                    DTROWSAVE("MOBILENO") = 0
                End If


                If IsDBNull(oSheet.Range("L" & I.ToString).Text) = False Then
                    DTROWSAVE("GSTIN") = oSheet.Range("L" & I.ToString).Text
                Else
                    DTROWSAVE("GSTIN") = ""
                End If

                If IsDBNull(oSheet.Range("M" & I.ToString).Text) = False Then
                    DTROWSAVE("GROUPNAME") = oSheet.Range("M" & I.ToString).Text
                Else
                    DTROWSAVE("GROUPNAME") = ""
                End If

                If IsDBNull(oSheet.Range("N" & I.ToString).Text) = False Then
                    DTROWSAVE("PANNO") = oSheet.Range("N" & I.ToString).Text
                Else
                    DTROWSAVE("PANNO") = ""
                End If

                If IsDBNull(oSheet.Range("O" & I.ToString).Text) = False Then
                    DTROWSAVE("BROKER") = oSheet.Range("O" & I.ToString).Text
                Else
                    DTROWSAVE("BROKERR") = ""
                End If

                If IsDBNull(oSheet.Range("P" & I.ToString).Text) = False Then
                    DTROWSAVE("TRANSPORT") = oSheet.Range("P" & I.ToString).Text
                Else
                    DTROWSAVE("TRANSPORT") = ""
                End If

                If IsDBNull(oSheet.Range("Q" & I.ToString).Text) = False Then
                    DTROWSAVE("EMAIL") = oSheet.Range("Q" & I.ToString).Text
                Else
                    DTROWSAVE("EMAIL") = ""
                End If




                Dim ALPARAVAL As New ArrayList
                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As DataTable = OBJCMN.search("CITY_ID AS CITYID", "", "CITYMASTER ", "AND CITY_NAME = '" & DTROWSAVE("CITYNAME") & "' AND CITY_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CITYNAME
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savecity(DTROWSAVE("CITYNAME"), CmpId, Locationid, Userid, YearId, " and city_name = '" & DTROWSAVE("CITYNAME") & "' AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                End If


                DTTABLE = OBJCMN.search("STATE_ID AS STATEID", "", "STATEMASTER ", "AND STATE_NAME = '" & DTROWSAVE("STATE") & "' AND STATE_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW STATE
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savestate(DTROWSAVE("STATE"), CmpId, Locationid, Userid, YearId, " and STATE_name = '" & DTROWSAVE("STATE") & "' AND STATE_YEARID = " & YearId)
                End If


                DTTABLE = OBJCMN.search("COUNTRY_ID AS COUNTRYID", "", "COUNTRYMASTER ", "AND COUNTRY_NAME = '" & DTROWSAVE("COUNTRY") & "' AND COUNTRY_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW COUNTRY
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savecountry(DTROWSAVE("COUNTRY"), CmpId, Locationid, Userid, YearId, " and COUNTRY_name = '" & DTROWSAVE("COUNTRY") & "' AND COUNTRY_YEARID = " & YearId)
                End If


                'check whether ITEMNAME is already present or not
                DTTABLE = OBJCMN.search("ACC_CMPNAME AS COMPANYNAME", "", "LEDGERS ", " AND ACC_CMPNAME = '" & DTROWSAVE("COMPANYNAME") & "' AND ACC_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then GoTo SKIPLINE



                'ADD IN ACCOUNTSMASTER
                ALPARAVAL.Clear()
                Dim OBJSM As New ClsAccountsMaster

                ALPARAVAL.Add(DTROWSAVE("COMPANYNAME"))
                ALPARAVAL.Add("")   'NAME
                ALPARAVAL.Add(DTROWSAVE("GROUPNAME"))
                ALPARAVAL.Add(0)    'OPBAL
                ALPARAVAL.Add("Cr.")
                ALPARAVAL.Add(0)    'INTPER
                ALPARAVAL.Add(0)    'PROFITPER
                ALPARAVAL.Add(DTROWSAVE("ADD1"))
                ALPARAVAL.Add(DTROWSAVE("ADD2"))
                ALPARAVAL.Add("")   'AREA
                ALPARAVAL.Add("")   'STD
                ALPARAVAL.Add(DTROWSAVE("CITYNAME"))
                ALPARAVAL.Add(DTROWSAVE("PINNO"))
                ALPARAVAL.Add(DTROWSAVE("STATE"))
                ALPARAVAL.Add(DTROWSAVE("COUNTRY"))
                ALPARAVAL.Add(0)    'CRDAYS
                ALPARAVAL.Add(0)    'CRLIMIT
                ALPARAVAL.Add("")   'RESI
                ALPARAVAL.Add("")   'ALT
                ALPARAVAL.Add(DTROWSAVE("PHONENO"))
                ALPARAVAL.Add(DTROWSAVE("MOBILENO"))
                ALPARAVAL.Add("")   'FAX
                ALPARAVAL.Add("")   'WEBSITE
                ALPARAVAL.Add(DTROWSAVE("EMAIL"))   'EMAIL

                ALPARAVAL.Add(DTROWSAVE("TRANSPORT"))   'TRANS
                ALPARAVAL.Add(DTROWSAVE("BROKER"))   'AGENT
                ALPARAVAL.Add(0)    'AGENTCOM
                ALPARAVAL.Add(0)    'DISC
                ALPARAVAL.Add(0)    'KMS

                ALPARAVAL.Add(DTROWSAVE("PANNO"))   'PAN
                ALPARAVAL.Add("")   'EXISE
                ALPARAVAL.Add("")   'RANGE
                ALPARAVAL.Add("")   'ADDLESS
                ALPARAVAL.Add("")   'CST
                ALPARAVAL.Add("")   'TIN
                ALPARAVAL.Add("")   'ST
                ALPARAVAL.Add("")   'VAT
                ALPARAVAL.Add(DTROWSAVE("GSTIN"))
                ALPARAVAL.Add("")   'REGISTER
                ALPARAVAL.Add(DTROWSAVE("ADDRESS"))
                ALPARAVAL.Add("")   'SHIPADD
                ALPARAVAL.Add("")   'REMARKS
                ALPARAVAL.Add("")   'PARTYBANK
                ALPARAVAL.Add("")   'ACCTYPE
                ALPARAVAL.Add("")   'ACCNO
                ALPARAVAL.Add("")   'IFSCCODE
                ALPARAVAL.Add("")   'BRANCH
                ALPARAVAL.Add("")   'BANKCITY
                ALPARAVAL.Add("")   'GROUPOFCOMPANIES
                ALPARAVAL.Add(0)   'BLOCKED
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(0)    'TRANSFER
                ALPARAVAL.Add(DTROWSAVE("CODE"))
                ALPARAVAL.Add("")    'PRICELIST
                ALPARAVAL.Add("")    'PACKINGTYPE
                ALPARAVAL.Add("")    'TERM
                ALPARAVAL.Add("")    'SALESMAN


                'TDS
                '*******************************
                ALPARAVAL.Add(0)    'ISTDS
                ALPARAVAL.Add("")   'DEDUCTEETYPER
                ALPARAVAL.Add("")   'TDSFORM
                ALPARAVAL.Add("")   'TDSCOMPANY
                ALPARAVAL.Add(0)    'ISLOWER

                ALPARAVAL.Add("")   'SECTION
                ALPARAVAL.Add(Val(0))   'TDSRATE
                ALPARAVAL.Add(0)    'TDSPER
                ALPARAVAL.Add(0) 'SURCHARGE
                ALPARAVAL.Add(0) 'LIMIT
                '*******************************

                ALPARAVAL.Add(0)    'TDSAC
                ALPARAVAL.Add("NON SEZ")    'SEZTYPE
                ALPARAVAL.Add("")   'NATUREOFPAY
                ALPARAVAL.Add("ACCOUNTS")   'TYPE
                ALPARAVAL.Add("")   'CALC


                OBJSM.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJSM.SAVE()

                DTROWSAVE = DTSAVE.NewRow()

SKIPLINE:
            Next

            oBook.Close()

            Exit Sub

            '************************************ END OF CODE FOR LEDGER UPLOAD ****************************



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TERMSANDCONDITIONS_Click(sender As Object, e As EventArgs) Handles TERMSANDCONDITIONS.Click
        Try
            Dim OBJOPPO As New TermsAndConditions
            OBJOPPO.MdiParent = Me
            OBJOPPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADSIGN_Click(sender As Object, e As EventArgs) Handles UPLOADSIGN.Click
        Try
            Dim OBJOPPO As New UploadSign
            OBJOPPO.MdiParent = Me
            OBJOPPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleInvoiceFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaleInvoiceFilterToolStripMenuItem.Click
        Try
            Dim OBJSALE As New SaleInvoiceFilter
            OBJSALE.MdiParent = Me
            OBJSALE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADSTOCKMENU_Click(sender As Object, e As EventArgs) Handles UPLOADSTOCKMENU.Click
        Try
            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub
            'upload the files data
            ''Reading from Excel Woorkbook
            Dim cPart As Microsoft.Office.Interop.Excel.Range
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open("D:\" & InputBox("Enter File Name").ToString.Trim, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets("Sheet1")

            'GRID
            Dim ADDITEM As Boolean = True
            Dim TEMPITEMNAME As String = ""

            Dim DTSAVE As New System.Data.DataTable

            DTSAVE.Columns.Add("TYPE")
            DTSAVE.Columns.Add("SUBTYPE")
            DTSAVE.Columns.Add("LOTNO")
            DTSAVE.Columns.Add("ITEMNAME")
            DTSAVE.Columns.Add("QUALITY")
            DTSAVE.Columns.Add("PROCESS")
            DTSAVE.Columns.Add("PARTYNAME")
            DTSAVE.Columns.Add("PIECETYPE")
            DTSAVE.Columns.Add("BALENO")
            DTSAVE.Columns.Add("JOBNO")
            DTSAVE.Columns.Add("CUT")
            DTSAVE.Columns.Add("DESIGN")
            DTSAVE.Columns.Add("DYEING")
            DTSAVE.Columns.Add("COLOR")
            DTSAVE.Columns.Add("WT")
            DTSAVE.Columns.Add("RATE")
            DTSAVE.Columns.Add("PCS")
            DTSAVE.Columns.Add("SAREES")
            DTSAVE.Columns.Add("MTRS")
            DTSAVE.Columns.Add("HSNCODE")
            DTSAVE.Columns.Add("GODOWN")

            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()


            Dim FROMROWNO As Integer = Val(InputBox("Enter Start Row No"))
            Dim TOROWNO As Integer = Val(InputBox("Enter End Row No"))

            For I As Integer = FROMROWNO To TOROWNO

                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVE("TYPE") = oSheet.Range("A" & I.ToString).Text
                Else
                    DTROWSAVE("TYPE") = ""
                End If


                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVE("SUBTYPE") = oSheet.Range("B" & I.ToString).Text
                Else
                    DTROWSAVE("SUBTYPE") = ""
                End If


                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVE("LOTNO") = oSheet.Range("C" & I.ToString).Text
                Else
                    DTROWSAVE("LOTNO") = ""
                End If


                If IsDBNull(oSheet.Range("D" & I.ToString).Text) = False Then
                    DTROWSAVE("ITEMNAME") = oSheet.Range("D" & I.ToString).Text
                Else
                    DTROWSAVE("ITEMNAME") = ""
                End If

                If IsDBNull(oSheet.Range("E" & I.ToString).Text) = False Then
                    DTROWSAVE("QUALITY") = oSheet.Range("E" & I.ToString).Text
                Else
                    DTROWSAVE("QUALITY") = ""
                End If

                If IsDBNull(oSheet.Range("F" & I.ToString).Text) = False Then
                    DTROWSAVE("PROCESS") = oSheet.Range("F" & I.ToString).Text
                Else
                    DTROWSAVE("PROCESS") = ""
                End If

                If IsDBNull(oSheet.Range("G" & I.ToString).Text) = False Then
                    DTROWSAVE("PARTYNAME") = oSheet.Range("G" & I.ToString).Text
                Else
                    DTROWSAVE("PARTYNAME") = ""
                End If

                If IsDBNull(oSheet.Range("H" & I.ToString).Text) = False Then
                    DTROWSAVE("PIECETYPE") = oSheet.Range("H" & I.ToString).Text
                Else
                    DTROWSAVE("PIECETYPE") = ""
                End If

                If IsDBNull(oSheet.Range("I" & I.ToString).Text) = False Then
                    DTROWSAVE("BALENO") = oSheet.Range("I" & I.ToString).Text
                Else
                    DTROWSAVE("BALENO") = ""
                End If

                If IsDBNull(oSheet.Range("J" & I.ToString).Text) = False Then
                    DTROWSAVE("JOBNO") = oSheet.Range("J" & I.ToString).Text
                Else
                    DTROWSAVE("JOBNO") = ""
                End If

                If IsDBNull(oSheet.Range("K" & I.ToString).Text) = False Then
                    DTROWSAVE("CUT") = Val(oSheet.Range("K" & I.ToString).Text)
                Else
                    DTROWSAVE("CUT") = 0
                End If

                If IsDBNull(oSheet.Range("L" & I.ToString).Text) = False Then
                    DTROWSAVE("DESIGN") = oSheet.Range("L" & I.ToString).Text
                Else
                    DTROWSAVE("DESIGN") = ""
                End If

                If IsDBNull(oSheet.Range("M" & I.ToString).Text) = False Then
                    DTROWSAVE("DYEING") = oSheet.Range("M" & I.ToString).Text
                Else
                    DTROWSAVE("DYEING") = ""
                End If

                If IsDBNull(oSheet.Range("N" & I.ToString).Text) = False Then
                    DTROWSAVE("COLOR") = oSheet.Range("N" & I.ToString).Text
                Else
                    DTROWSAVE("COLOR") = ""
                End If

                If IsDBNull(oSheet.Range("O" & I.ToString).Text) = False Then
                    DTROWSAVE("WT") = Val(oSheet.Range("O" & I.ToString).Text)
                Else
                    DTROWSAVE("WT") = 0
                End If

                If IsDBNull(oSheet.Range("P" & I.ToString).Text) = False Then
                    DTROWSAVE("RATE") = Val(oSheet.Range("P" & I.ToString).Text)
                Else
                    DTROWSAVE("RATE") = 0
                End If

                If IsDBNull(oSheet.Range("Q" & I.ToString).Text) = False Then
                    DTROWSAVE("PCS") = Val(oSheet.Range("Q" & I.ToString).Text)
                Else
                    DTROWSAVE("PCS") = 0
                End If

                If IsDBNull(oSheet.Range("R" & I.ToString).Text) = False Then
                    DTROWSAVE("SAREES") = Val(oSheet.Range("R" & I.ToString).Text)
                Else
                    DTROWSAVE("SAREES") = 0
                End If

                If IsDBNull(oSheet.Range("S" & I.ToString).Text) = False Then
                    DTROWSAVE("MTRS") = Val(oSheet.Range("S" & I.ToString).Text)
                Else
                    DTROWSAVE("MTRS") = 0
                End If

                If IsDBNull(oSheet.Range("T" & I.ToString).Text) = False Then
                    DTROWSAVE("HSNCODE") = oSheet.Range("T" & I.ToString).Text
                Else
                    DTROWSAVE("HSNCODE") = ""
                End If

                If IsDBNull(oSheet.Range("U" & I.ToString).Text) = False Then
                    DTROWSAVE("GODOWN") = oSheet.Range("U" & I.ToString).Text
                Else
                    DTROWSAVE("GODOWN") = ""
                End If



                If Val(DTROWSAVE("MTRS")) = 0 Then GoTo SKIPLINE


                Dim ALPARAVAL As New ArrayList
                'CHECK WHETHER ITEMNAME IS PRESENT OR NOT IF NOT PRESENT THEN ADD NEW
                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As New DataTable
                If DTROWSAVE("ITEMNAME") <> "" Then
                    DTTABLE = OBJCMN.search("ITEM_ID AS ITEMID", "", "ITEMMASTER ", "AND ITEM_NAME = '" & DTROWSAVE("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                    If DTTABLE.Rows.Count = 0 Then
                        'ADD NEW ITEMNAME 
                        ALPARAVAL.Clear()


                        ALPARAVAL.Add("Finished Goods")
                        ALPARAVAL.Add("")   'CATEGORY
                        ALPARAVAL.Add(DTROWSAVE("ITEMNAME"))        'DISPLAYNAME
                        ALPARAVAL.Add("")   'DEPARTMENT
                        ALPARAVAL.Add(DTROWSAVE("ITEMNAME"))        'CODE
                        ALPARAVAL.Add("")   'UNIT
                        ALPARAVAL.Add(0)    'OPSTOCK
                        ALPARAVAL.Add(0)    'OPVALUE
                        ALPARAVAL.Add(0)    'REORDER
                        ALPARAVAL.Add(0)    'UPPER
                        ALPARAVAL.Add(0)    'LOWER

                        Dim DTHSN As DataTable = OBJCMN.search("ISNULL(HSN_ID, 0) AS HSNCODEID", "", " HSNMASTER", " AND HSN_CODE = '" & DTROWSAVE("HSNCODE") & "' AND HSN_YEARID = " & YearId)
                        If DTHSN.Rows.Count > 0 Then ALPARAVAL.Add(DTROWSAVE("HSNCODE")) Else ALPARAVAL.Add(0) 'HSNCODEID

                        ALPARAVAL.Add("")    'RATETYPE
                        ALPARAVAL.Add("")    'RATE
                        ALPARAVAL.Add("")   'REMARKS
                        ALPARAVAL.Add("MERCHANT")
                        ALPARAVAL.Add(0)   'BLOCKED

                        ALPARAVAL.Add(CmpId)
                        ALPARAVAL.Add(Locationid)
                        ALPARAVAL.Add(Userid)
                        ALPARAVAL.Add(YearId)
                        ALPARAVAL.Add(0)

                        Dim objclsItemMaster As New clsItemmaster
                        objclsItemMaster.alParaval = ALPARAVAL
                        Dim IntResult As Integer = objclsItemMaster.SAVE()

                    End If
                End If



                'QUALITY SAVE
                If DTROWSAVE("QUALITY") <> "" Then
                    DTTABLE = OBJCMN.search("QUALITY_ID AS QUALITYID", "", "QUALITYMASTER", " AND QUALITY_NAME = '" & DTROWSAVE("QUALITY") & "' AND QUALITY_YEARID = " & YearId)
                    If DTTABLE.Rows.Count = 0 Then
                        'ADD NEW QUALITY
                        Dim OBJQUALITY As New ClsQualityMaster
                        OBJQUALITY.alParaval.Add(DTROWSAVE("QUALITY"))
                        OBJQUALITY.alParaval.Add("")
                        OBJQUALITY.alParaval.Add(CmpId)
                        OBJQUALITY.alParaval.Add(Locationid)
                        OBJQUALITY.alParaval.Add(Userid)
                        OBJQUALITY.alParaval.Add(YearId)
                        OBJQUALITY.alParaval.Add(0)

                        Dim INTRESCAT As Integer = OBJQUALITY.save()
                    End If
                End If



                'PIECETYPE SAVE
                If DTROWSAVE("PIECETYPE") <> "" Then
                    DTTABLE = OBJCMN.search("PIECETYPE_ID AS PIECETYPEID", "", "PIECETYPEMASTER", " AND PIECETYPE_NAME = '" & DTROWSAVE("PIECETYPE") & "' AND PIECETYPE_YEARID = " & YearId)
                    If DTTABLE.Rows.Count = 0 Then
                        'ADD NEW PIECETYPE
                        Dim OBJPIECETYPE As New ClsPieceTypeMaster
                        OBJPIECETYPE.alParaval.Add(DTROWSAVE("PIECETYPE"))
                        OBJPIECETYPE.alParaval.Add("")
                        OBJPIECETYPE.alParaval.Add(CmpId)
                        OBJPIECETYPE.alParaval.Add(Locationid)
                        OBJPIECETYPE.alParaval.Add(Userid)
                        OBJPIECETYPE.alParaval.Add(YearId)
                        OBJPIECETYPE.alParaval.Add(0)

                        Dim INTRESCAT As Integer = OBJPIECETYPE.save()
                    End If
                End If



                'ADD IN STOCKMASTER
                ALPARAVAL.Clear()
                Dim OBJSM As New ClsStockMaster

                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(0)

                ALPARAVAL.Add(I)
                ALPARAVAL.Add(AccFrom.Date)

                ALPARAVAL.Add(DTROWSAVE("TYPE"))                'TYPE
                ALPARAVAL.Add(DTROWSAVE("SUBTYPE"))             'SUBTYPE
                ALPARAVAL.Add(DTROWSAVE("LOTNO"))               'LOTNO
                ALPARAVAL.Add(DTROWSAVE("GODOWN"))              'GODOWN
                ALPARAVAL.Add(DTROWSAVE("ITEMNAME"))            'ITEMNAME
                ALPARAVAL.Add(DTROWSAVE("QUALITY"))             'QUALITY
                ALPARAVAL.Add(DTROWSAVE("PROCESS"))             'PROCESS
                ALPARAVAL.Add(DTROWSAVE("PARTYNAME"))           'NAME
                ALPARAVAL.Add(DTROWSAVE("PIECETYPE"))           'PIECETYPE
                ALPARAVAL.Add(DTROWSAVE("BALENO"))              'BALENO
                ALPARAVAL.Add(DTROWSAVE("JOBNO"))               'JOBNO
                ALPARAVAL.Add(Val(DTROWSAVE("CUT")))            'CUT
                ALPARAVAL.Add(DTROWSAVE("DESIGN"))              'DESIGNNO
                ALPARAVAL.Add(DTROWSAVE("DYEING"))              'DYEING
                ALPARAVAL.Add(DTROWSAVE("COLOR"))               'COLOR    
                ALPARAVAL.Add(Val(DTROWSAVE("WT")))             'WT
                ALPARAVAL.Add(Val(DTROWSAVE("RATE")))           'RATE
                ALPARAVAL.Add(Val(DTROWSAVE("PCS")))            'PCS
                ALPARAVAL.Add("PCS")                            'UNIT
                ALPARAVAL.Add(Val(DTROWSAVE("SAREES")))         'SAREE
                ALPARAVAL.Add(Val(DTROWSAVE("MTRS")))           'MTRS
                ALPARAVAL.Add(0)                                'OUTPCS
                ALPARAVAL.Add(0)                                'OUTMTRS
                ALPARAVAL.Add(0)                                'DONE
                ALPARAVAL.Add(0)                                'RETURNPCS

                OBJSM.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJSM.SAVE()

                DTROWSAVE = DTSAVE.NewRow()

SKIPLINE:
            Next
            oBook.Close()

            Exit Sub
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub USERGODOWNADD_Click(sender As Object, e As EventArgs) Handles USERGODOWNADD.Click
        Try
            Dim OBJPROFORMA As New UserGodownTagging
            OBJPROFORMA.MdiParent = Me
            OBJPROFORMA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub USERGODOWNEDIT_Click(sender As Object, e As EventArgs) Handles USERGODOWNEDIT.Click
        Try
            Dim OBJPROFORMA As New UserGodownTaggingDetails
            OBJPROFORMA.MdiParent = Me
            OBJPROFORMA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TRANSFERADD_Click(sender As Object, e As EventArgs) Handles TRANSFERADD.Click
        Try
            Dim OBJTRANSFER As New InterGodownTransfer
            OBJTRANSFER.MdiParent = Me
            OBJTRANSFER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TRANSFEREDIT_Click(sender As Object, e As EventArgs) Handles TRANSFEREDIT.Click
        Try
            Dim OBJTRANSFER As New InterGodownTransferDetails
            OBJTRANSFER.MdiParent = Me
            OBJTRANSFER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GODOWNADD_Click(sender As Object, e As EventArgs) Handles GODOWNADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "GODOWN"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GODOWNEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GODOWNEDIT.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.frmstring = "GODOWN"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub RECTRANSFER_MASTER_Click(sender As Object, e As EventArgs) Handles RECTRANSFER_MASTER.Click
        Try
            Dim OBJTRANSFER As New RecTransferLot
            OBJTRANSFER.MdiParent = Me
            OBJTRANSFER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDDISCLISTADD_Click(sender As Object, e As EventArgs) Handles RDDISCLISTADD.Click
        Try
            Dim OBJDISC As New DiscountMaster
            OBJDISC.MdiParent = Me
            OBJDISC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RDDISCLISTEDIT_Click(sender As Object, e As EventArgs) Handles RDDISCLISTEDIT.Click
        Try
            Dim OBJDISC As New DiscountDetails
            OBJDISC.MdiParent = Me
            OBJDISC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRSTOCK_Click(sender As Object, e As EventArgs) Handles GRSTOCK.Click
        Try
            Dim PASS As String = InputBox("Enter Master Password", "TEXPRO")
            If PASS <> "kp3042" Then
                MsgBox("Invalid Password, You are not allowed to Transfer Stock", MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim OBJOPENST As New OpeningStock
            OBJOPENST.MdiParent = Me
            OBJOPENST.TYPE = "GRSTOCK"
            OBJOPENST.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MDIMain_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                CUTTING_TOOL.Visible = False
                CUTTINGTOOLSTRIP.Visible = False
                MFGAFTERCUTTING_TOOL.Visible = False
                MFGAFTERCUTTINGTOOLSTRIP.Visible = False
                FINALCUTTING_TOOL.Visible = False
                FINALCUTTINGTOOLSTRIP.Visible = False
                PROFORMA_TOOL.Visible = False
                PROFORMATOOLSTRIP.Visible = False
                DESIGNREG_TOOL.Visible = False
                DESIGNREGISTERTOOLSTRIP.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONTRACTORRATEADD_Click(sender As Object, e As EventArgs) Handles CONTRACTORRATEADD.Click
        Try
            Dim OBJWORKER As New ContractorWorkerRate
            OBJWORKER.MdiParent = Me
            OBJWORKER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONTRACTORRATEEDIT_Click(sender As Object, e As EventArgs) Handles CONTRACTORRATEEDIT.Click
        Try
            Dim OBJWORKER As New ContractorWorkerRateDetails
            OBJWORKER.MdiParent = Me
            OBJWORKER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GATEPASS_TOOL_Click(sender As Object, e As EventArgs) Handles GATEPASS_TOOL.Click
        Try
            Dim OBJGRN As New gatePass
            OBJGRN.MdiParent = Me
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PartyLotStatusReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartyLotStatusReportToolStripMenuItem.Click
        Try
            Dim OBJSTATUS As New PartyLotStatusReport
            OBJSTATUS.MdiParent = Me
            OBJSTATUS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CONTRACTORADD_Click(sender As Object, e As EventArgs) Handles CONTRACTORADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "CONTRACTOR"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CONTRACTOREDIT_Click(sender As Object, e As EventArgs) Handles CONTRACTOREDIT.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.frmstring = "CONTRACTOR"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PriceListReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PriceListReportToolStripMenuItem.Click
        Try
            Dim OBJPL As New PriceListFilter
            OBJPL.MdiParent = Me
            OBJPL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LOCKUNLOCKPENDINGENTRIES_MASTER_Click(sender As Object, e As EventArgs) Handles LOCKUNLOCKPENDINGENTRIES_MASTER.Click
        Try
            Dim OBJLOCK As New LockPendingEntries
            OBJLOCK.MdiParent = Me
            OBJLOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobOutPartywiseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JobOutPartywiseToolStripMenuItem.Click
        Try
            Dim OBJJO As New JobOutFilter
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobInPartyWiseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JobInPartyWiseToolStripMenuItem.Click
        Try
            Dim OBJJI As New JobInFilter
            OBJJI.MdiParent = Me
            OBJJI.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StoreInFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StoreInFilterToolStripMenuItem.Click
        Try
            Dim OBJGRN As New StoreInFilter
            OBJGRN.MdiParent = Me
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseInvoiceReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseInvoiceReportsToolStripMenuItem.Click
        Try
            Dim OBJPUR As New PurchaseInvoiceFilter
            OBJPUR.MdiParent = Me
            OBJPUR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POCLOSE_Click(sender As Object, e As EventArgs) Handles POCLOSE.Click
        Try
            Dim OBJPO As New PurchaseOrderClose
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPPOADD_Click(sender As Object, e As EventArgs) Handles OPPOADD.Click
        Try
            Dim OBJPO As New OpeningPurchaseOrder
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPPOEDIT_Click(sender As Object, e As EventArgs) Handles OPPOEDIT.Click
        Try
            Dim OBJPO As New OpeningPurchaseOrderDetails
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseOrderToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PurchaseOrderToolStripMenuItem1.Click
        Try
            Dim OBJPO As New POFilter
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobPackingFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JobPackingFilterToolStripMenuItem.Click
        Try
            Dim OBJPACK As New JobPackingFilter
            OBJPACK.MdiParent = Me
            OBJPACK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GREYPOADD_Click(sender As Object, e As EventArgs) Handles GREYPOADD.Click
        Try
            Dim OBJPO As New GreyPurchaseOrder
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GREYPOEDIT_Click(sender As Object, e As EventArgs) Handles GREYPOEDIT.Click
        Try
            Dim OBJPO As New GreyPurchaseOrderDetails
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GREYPOCLOSE_Click(sender As Object, e As EventArgs) Handles GREYPOCLOSE.Click
        Try
            Dim OBJPO As New GreyPurchaseOrderClose
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DeleteLogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteLogsToolStripMenuItem.Click
        Try
            Dim OBJLOGS As New LogsDelete
            OBJLOGS.MdiParent = Me
            OBJLOGS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateLogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateLogsToolStripMenuItem.Click
        Try
            Dim OBJLOGS As New LogsUpdate
            OBJLOGS.MdiParent = Me
            OBJLOGS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OPSOADD.Click
        Try
            Dim OBJPO As New OpeningSaleOrder
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OPSOEDIT.Click
        Try
            Dim OBJPO As New OpeningSaleOrderDetails
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaleOrderFilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaleOrderFilterToolStripMenuItem.Click
        Try
            Dim OBJSO As New SOFilter
            OBJSO.FRMSTRING = "SO"
            OBJSO.MdiParent = Me
            OBJSO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SUBCATEGORYADD_Click(sender As Object, e As EventArgs) Handles SUBCATEGORYADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "SUBCATEGORY"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FOLDADD_Click(sender As Object, e As EventArgs) Handles FOLDADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "FOLD"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SUBCATEGORYEDIT_Click(sender As Object, e As EventArgs) Handles SUBCATEGORYEDIT.Click
        Try
            Dim objCategoryDetails As New CategoryDetails
            objCategoryDetails.MdiParent = Me
            objCategoryDetails.frmstring = "SUBCATEGORY"
            objCategoryDetails.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FOLDEDIT_Click(sender As Object, e As EventArgs) Handles FOLDEDIT.Click
        Try
            Dim objCategoryDetails As New CategoryDetails
            objCategoryDetails.MdiParent = Me
            objCategoryDetails.frmstring = "FOLD"
            objCategoryDetails.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
