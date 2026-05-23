
Imports BL

Public Class YearTransfer

    Dim INTRES As Integer
    Dim OBJTRF As New ClsYearTransfer
    Public FRMSTRING As String = ""

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDOK.Click
        Try
            'transfering data from selected cmp
            If GRIDYEAR.SelectedRows.Count = 0 Then
                MsgBox("Select Year", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim SELECTEDYEARID As Integer = 0
            Dim TEMPMSG As Integer = MsgBox("Transfer Data from Selected Year?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                TEMPMSG = MsgBox("Are you sure, wish to Proceed?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then

                    SELECTEDYEARID = GRIDYEAR.CurrentRow.Cells(GYEARID.Index).Value

                    If FRMSTRING = "YEARTRANSFER" Then
                        '********* TRANSFERRING DATA ***********
                        TRANSFERUSER(SELECTEDYEARID)


                        TRANSFERHSN(SELECTEDYEARID)
                        TRANSFERDEPARTMENT(SELECTEDYEARID)
                        TRANSFERDESIGNATION(SELECTEDYEARID)
                        TRANSFERGROUP(SELECTEDYEARID)
                        TRANSFERLOCATION(SELECTEDYEARID)
                        TRANSFERGODOWN(SELECTEDYEARID)

                        TRANSFERPACKING(SELECTEDYEARID)
                        TRANSFERPARTYBANK(SELECTEDYEARID)
                        TRANSFERTERM(SELECTEDYEARID)
                        TRANSFERGOC(SELECTEDYEARID)
                        TRANSFERREGISTER(SELECTEDYEARID)

                        TRANSFERUNIT(SELECTEDYEARID)
                        TRANSFERCOLOR(SELECTEDYEARID)

                        TRANSFERSCREEN(SELECTEDYEARID)
                        TRANSFERCONTRACTOR(SELECTEDYEARID)
                        TRANSFERSUPERVISIOR(SELECTEDYEARID)
                        TRANSFERWEAVER(SELECTEDYEARID)
                        TRANSFERCATEGORY(SELECTEDYEARID)
                        TRANSFERSUBCATEGORY(SELECTEDYEARID)
                        TRANSFERFOLD(SELECTEDYEARID)
                        TRANSFERQUALITY(SELECTEDYEARID)
                        TRANSFERRATETYPE(SELECTEDYEARID)
                        TRANSFERPIECETYPE(SELECTEDYEARID)
                        TRANSFERITEM(SELECTEDYEARID)
                        TRANSFERPROCESS(SELECTEDYEARID)
                        TRANSFERMACHINE(SELECTEDYEARID)
                        TRANSFERDYEING(SELECTEDYEARID)
                        TRANSFERDESIGN(SELECTEDYEARID)
                        TRANSFEREXPENSE(SELECTEDYEARID)

                        TRANSFERDISCOUNT(SELECTEDYEARID)

                        TRANSFERTRANSPORT(SELECTEDYEARID)
                        TRANSFERAGENTS(SELECTEDYEARID)

                        TRANSFERACCOUNTS(SELECTEDYEARID)

                        'DONE BY GULKIT
                        'WE HAVE CALLED THIS TRANSFERITEM TWICE TO UPDATE THE LEDGERS
                        TRANSFERITEM(SELECTEDYEARID)


                        'KEEP AFTER PROCESS
                        TRANSFERCOLORRATE(SELECTEDYEARID)
                        TRANSFERGRN(SELECTEDYEARID)

                        TRANSFERBILLS(SELECTEDYEARID)
                        TRANSFERBALANCE(SELECTEDYEARID)

                        TRANSFERPURORDER(SELECTEDYEARID)
                        TRANSFERGREYPURORDER(SELECTEDYEARID)

                        'TransferProfitLoss(SELECTEDYEARID)
                        '******* TRANSFERRING DATA DONE ********


                        'DO NOT GIVE TRANSFER STOCK HERE
                        'BY GULKIT STRICKTLY
                        'TRANSFERGREYCHECKEDSTOCK(SELECTEDYEARID)

                    ElseIf FRMSTRING = "STOCKTRANSFER" Then

                        Dim PASS As String = InputBox("Enter Master Password", "TEXPRO")
                        If PASS <> "infosys123" Then
                            MsgBox("Invalid Password, You are not allowed to Transfer Stock", MsgBoxStyle.Critical)
                            Exit Sub
                        End If

                        TRANSFERGREYCHECKEDSTOCK(SELECTEDYEARID)
                        TRANSFERGRSTOCK(SELECTEDYEARID)
                        TRANSFERGREYUNCHECKEDSTOCK(SELECTEDYEARID)
                        TRANSFERPROCESSSTOCK(SELECTEDYEARID)

                        'DO NOT TRANSFER CUTTING
                        'BY GULKIT
                        'TRANSFERCUTTINGSTOCK(SELECTEDYEARID)

                        TRANSFERPROCESSMFG2STOCK(SELECTEDYEARID)
                        If ClientName <> "TULSI" Then TRANSFERLOOSESTOCK(SELECTEDYEARID)
                        TRANSFERBALESTOCK(SELECTEDYEARID)
                        TRANSFERJOBSTOCK(SELECTEDYEARID)
                        TRANSFERJOBBALESTOCK(SELECTEDYEARID)
                        TRANSFERSTORESTOCK(SELECTEDYEARID)
                        TRANSFERSTORELOANSTOCK(SELECTEDYEARID)

                    ElseIf FRMSTRING = "USERTRANSFER" Then

                        Dim PASS As String = InputBox("Enter Master Password", "TEXPRO")
                        If PASS <> "infosys123" Then
                            MsgBox("Invalid Password, You are not allowed to Transfer Stock", MsgBoxStyle.Critical)
                            Exit Sub
                        End If
                        TRANSFERUSER(SELECTEDYEARID)

                    End If
                    MsgBox("Transfer Completed Successfully")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YearTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CONVERT(char(11), year_startdate , 6) + ' - ' + CONVERT(char(11), year_enddate , 6) AS YEARNAME, YEAR_ID AS YEARID   ", "", " YEARMASTER", " AND YEAR_STARTDATE <'" & AccFrom.Date & "' AND YEAR_ID <> " & YearId & " AND YEAR_CMPID = " & CmpId & " ORDER BY YEAR_ID DESC ")
            If DT.Rows.Count > 0 Then
                For Each DTROW As DataRow In DT.Rows
                    GRIDYEAR.Rows.Add(DTROW("YEARNAME"), DTROW("YEARID"))
                Next
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "YEARTRANSFER"

    Sub TRANSFERUSER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERUSER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERHSN(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERHSN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDEPARTMENT(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDEPARTMENT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDESIGNATION(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDESIGNATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERGROUP(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGROUP()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERLOCATION(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERLOCATION()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERGODOWN(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGODOWN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPACKING(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPACKING()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPARTYBANK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPARTYBANK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERTERM(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERTERM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERGOC(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGOC()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERREGISTER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERREGISTER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERTRANSPORT(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERACCOUNTS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERAGENTS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERAGENTS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERACCOUNTS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERACCOUNTS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPROCESS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPROCESS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERMACHINE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERMACHINE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCOLOR(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCOLOR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCOLORRATE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCOLORRATE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERGRN(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGRN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSCREEN(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSCREEN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERWEAVER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERWEAVER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSUPERVISIOR(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSUPERVISIOR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERRATETYPE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERRATETYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERQUALITY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERQUALITY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCONTRACTOR(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCONTRACTOR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPIECETYPE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPIECETYPE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCATEGORY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCATEGORY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSUBCATEGORY(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSUBCATEGORY()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERFOLD(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERFOLD()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERITEM(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERITEM()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDYEING(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDYEING()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDESIGN(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDESIGN()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFEREXPENSE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFEREXPENSE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERDISCOUNT(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERDISCOUNT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSOURCE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSOURCE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERUNIT(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERUNIT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERBILLS(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERBILLS()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERBALANCE(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERBALANCE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPURORDER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPURORDER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERGREYPURORDER(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGREYPURORDER()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "STOCK"

    Sub TRANSFERGREYCHECKEDSTOCK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGREYCHECKEDSTOCK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERGRSTOCK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGRSTOCK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERGREYUNCHECKEDSTOCK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERGREYUNCHECKEDSTOCK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPROCESSSTOCK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPROCESSSTOCK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERCUTTINGSTOCK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERCUTTINGSTOCK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERPROCESSMFG2STOCK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERPROCESSMFG2STOCK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERLOOSESTOCK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERLOOSESTOCK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERBALESTOCK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERBALESTOCK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERJOBSTOCK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERJOBSTOCK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERJOBBALESTOCK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERJOBBALESTOCK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSTORESTOCK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSTORESTOCK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TRANSFERSTORELOANSTOCK(ByVal SELECTEDYEARID As Integer)
        Try
            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(SELECTEDYEARID)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            OBJTRF.alParaval = ALPARAVAL
            INTRES = OBJTRF.TRANSFERSTORELOANSTOCK()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region



End Class