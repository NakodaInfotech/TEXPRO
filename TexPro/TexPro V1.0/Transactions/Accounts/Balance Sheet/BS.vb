﻿
Imports BL
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Windows.Forms

Public Class BS

    Dim TOTALNETTPROFIT, TOTALNETTLOSS As Double

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub BalanceSheet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLPL()
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Sub FILLPL()
    '    Try
    '        Dim OBJPL As New ClsProfitLoss
    '        Dim ALPARAVAL As New ArrayList
    '        Dim DT As DataTable

    '        If chkdate.CheckState = CheckState.Checked Then
    '            ALPARAVAL.Add(dtfrom.Value.Date)
    '            ALPARAVAL.Add(dtto.Value.Date)
    '        Else
    '            ALPARAVAL.Add(AccFrom)
    '            ALPARAVAL.Add(AccTo)
    '        End If
    '        ALPARAVAL.Add(CmpId)
    '        ALPARAVAL.Add(Locationid)
    '        ALPARAVAL.Add(YearId)

    '        OBJPL.alParaval = ALPARAVAL


    '        'CODE BY GULKIT
    '        'GET OPSTOCK
    '        Dim OBJCMN As New ClsCommon
    '        Dim OPSTOCK, CLOSTOCK As Double
    '        OPSTOCK = 0
    '        CLOSTOCK = 0
    '        Dim OPSTOCKDT As DataTable = OBJCMN.search(" OPENINGSTOCK, CLOSINGSTOCK", "", " OPENINGCLOSINGSTOCK ", " AND YEARID = " & YearId)
    '        If OPSTOCKDT.Rows.Count > 0 Then
    '            OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("OPENINGSTOCK"))
    '            CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("CLOSINGSTOCK"))
    '        End If

    '        If rdcondensed.Checked = True Then

    '            DT = OBJPL.GETSUMMARY()

    '            gridexpenses.RowCount = 1
    '            gridincome.RowCount = 1


    '            'FORMATTING GRID
    '            For Each DTROW As DataRow In DT.Rows

    '                If DTROW(0) = "Purchase A/C" Or DTROW(0) = "Direct Expenses" Then
    '                    gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
    '                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
    '                End If
    '                '*****************************************************************
    '                '*****************************************************************

    '                If DTROW(0) = "Sales A/C" Or DTROW(0) = "Direct Income" Then
    '                    gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
    '                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
    '                End If

    '                '*****************************************************************
    '                '*****************************************************************
    '                Dim i As Integer

    '                If DTROW(0) = "Gross Profit C/O" Or DTROW(0) = "Gross Loss C/O" Then

    '                    gridexpenses.Rows.Insert(0, "Opening Stock", OPSTOCK)
    '                    gridexpenses.Rows(0).DefaultCellStyle.ForeColor = Color.Maroon
    '                    gridexpenses.Rows(0).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

    '                    'gridincome.Rows.Insert(0, "Opening Stock", "0.00")

    '                    '***** GROSS PROFIT AND LOSS
    '                    'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
    '                    If gridexpenses.RowCount > gridincome.RowCount Then
    '                        For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                            gridincome.Rows.Add("", "", "")
    '                        Next
    '                    ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                        For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                            gridexpenses.Rows.Add("", "", "")
    '                        Next
    '                    End If

    '                    gridincome.Rows.Insert(gridincome.RowCount - 2, "Closing Stock", "0.00")
    '                    gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.ForeColor = Color.Maroon
    '                    gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

    '                End If



    '                If DTROW(0) = "Gross Profit C/O" Then
    '                    gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
    '                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
    '                End If

    '                If DTROW(0) = "Gross Loss C/O" Then
    '                    gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
    '                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
    '                End If

    '                '**************************************************************************************



    '                If DTROW(0) = "Total EXP" Then

    '                    '***** FILLING TOTAL
    '                    'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
    '                    If gridexpenses.RowCount > gridincome.RowCount Then
    '                        For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                            gridincome.Rows.Add("", "", "")
    '                        Next
    '                    ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                        For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                            gridexpenses.Rows.Add("", "", "")
    '                        Next
    '                    End If

    '                    gridexpenses.Rows.Add("===========================", "===============", "===============")
    '                    gridincome.Rows.Add("===========================", "===============", "===============")

    '                    gridexpenses.Rows.Add("Total", Val(DTROW(1)))
    '                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
    '                End If

    '                If DTROW(0) = "Total INC" Then
    '                    gridincome.Rows.Add("Total", Val(DTROW(1)))
    '                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

    '                    gridexpenses.Rows.Add("===========================", "===============", "===============")
    '                    gridincome.Rows.Add("===========================", "===============", "===============")
    '                End If
    '                '***************************************************************************************


    '                If DTROW(0) = "Gross Profit B/F" Or DTROW(0) = "Gross Loss B/F" Then
    '                    '***** GROSS PROFIT AND LOSS
    '                    'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
    '                    If gridexpenses.RowCount > gridincome.RowCount Then
    '                        For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                            gridincome.Rows.Add("", "", "")
    '                        Next
    '                    ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                        For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                            gridexpenses.Rows.Add("", "", "")
    '                        Next
    '                    End If
    '                End If


    '                If DTROW(0) = "Gross Loss B/F" Then
    '                    gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
    '                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
    '                End If

    '                If DTROW(0) = "Gross Profit B/F" Then
    '                    gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
    '                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
    '                End If
    '                '*************************************************************************


    '                If DTROW(0) = "Indirect Expenses" Then
    '                    gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
    '                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
    '                End If

    '                If DTROW(0) = "Indirect Income" Then
    '                    gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
    '                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
    '                End If
    '                '***************************************************************************************


    '                If DTROW(0) = "Nett Profit" Or DTROW(0) = "Nett Loss" Then
    '                    '***** GROSS PROFIT AND LOSS
    '                    'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
    '                    If gridexpenses.RowCount > gridincome.RowCount Then
    '                        For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                            gridincome.Rows.Add("", "", "")
    '                        Next
    '                    ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                        For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                            gridexpenses.Rows.Add("", "", "")
    '                        Next
    '                    End If
    '                End If


    '                If DTROW(0) = "Nett Profit" Then
    '                    gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
    '                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
    '                End If

    '                If DTROW(0) = "Nett Loss" Then
    '                    gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
    '                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
    '                End If
    '                '*************************************************************************


    '                If DTROW(0) = "G. Total EXP" Then

    '                    '***** FILLING TOTAL
    '                    'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
    '                    If gridexpenses.RowCount > gridincome.RowCount Then
    '                        For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                            gridincome.Rows.Add("", "", "")
    '                        Next
    '                    ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                        For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                            gridexpenses.Rows.Add("", "", "")
    '                        Next
    '                    End If

    '                    gridexpenses.Rows.Add("===========================", "===============", "===============")
    '                    gridincome.Rows.Add("===========================", "===============", "===============")

    '                    gridexpenses.Rows.Add("Total", Val(DTROW(1)))
    '                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
    '                End If

    '                If DTROW(0) = "G. Total INC" Then
    '                    gridincome.Rows.Add("Total", Val(DTROW(1)))
    '                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

    '                    gridexpenses.Rows.Add("===========================", "===============", "===============")
    '                    gridincome.Rows.Add("===========================", "===============", "===============")
    '                End If
    '                '***************************************************************************************


    '            Next

    '        ElseIf rddetails.Checked = True Then

    '            DT = OBJPL.GETDETAILS()

    '            gridexpenses.RowCount = 1
    '            gridincome.RowCount = 1
    '            Dim TOTALDREXP, TOTALCREXP, TOTALDRINC, TOTALCRINC, TOTALGROSSPROFIT, TOTALGROSSLOSS As Double


    '            gridexpenses.Rows.Insert(0, "Opening Stock", "0.00")
    '            gridexpenses.Rows(0).DefaultCellStyle.ForeColor = Color.Maroon
    '            gridexpenses.Rows(0).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
    '            gridexpenses.Rows.Insert(1, "", "")


    '            Dim i As Integer = 1
    '            '***** GROSS PROFIT AND LOSS
    '            'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If

    '            'FORMATTING GRID
    '            For Each DTROW As DataRow In DT.Rows
    '                Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

    '                If DTROW("PRIMARYGP") = "Purchase A/C" Or DTROW("PRIMARYGP") = "Direct Expenses" Then
    '                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
    '                        gridexpenses.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

    '                        TOTALDREXP += Val(DTROW("DR"))
    '                        TOTALCREXP += Val(DTROW("CR"))

    '                    ElseIf DTROW("NAME").ToString.Trim <> "" Then
    '                        gridexpenses.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
    '                    Else
    '                        If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
    '                        gridexpenses.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
    '                    End If
    '                End If
    '                '*****************************************************************
    '                '*****************************************************************

    '                If DTROW("PRIMARYGP") = "Sales A/C" Or DTROW("PRIMARYGP") = "Direct Income" Then
    '                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
    '                        gridincome.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

    '                        TOTALDRINC += Val(DTROW("DR"))
    '                        TOTALCRINC += Val(DTROW("CR"))

    '                    ElseIf DTROW("NAME").ToString.Trim <> "" Then
    '                        gridincome.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
    '                    Else
    '                        If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
    '                        gridincome.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
    '                    End If
    '                End If
    '            Next

    '            '*****************************************************************
    '            '*****************************************************************



    '            '***** GROSS PROFIT AND LOSS
    '            'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If


    '            gridincome.Rows.Insert(gridincome.RowCount - 2, "", "")
    '            gridincome.Rows.Insert(gridincome.RowCount - 2, "", "")
    '            gridincome.Rows.Insert(gridincome.RowCount - 2, "Closing Stock", "0.00")
    '            gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.ForeColor = Color.Maroon
    '            gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)

    '            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
    '            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
    '            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
    '            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


    '            If (TOTALDREXP - TOTALCREXP) <= (TOTALCRINC - TOTALDRINC) Then
    '                gridexpenses.Rows.Add("Gross Profit C/O", Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP)))
    '                TOTALGROSSPROFIT = Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
    '                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
    '                TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
    '            Else
    '                gridincome.Rows.Add("Gross Loss C/O", Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC)))
    '                TOTALGROSSLOSS = Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
    '                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
    '                TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
    '            End If
    '            ''**************************************************************************************



    '            '***************************************************************************************
    '            '***** FILLING TOTAL ***********
    '            'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If

    '            gridexpenses.Rows.Add("===========================", "===============", "===============")
    '            gridincome.Rows.Add("===========================", "===============", "===============")

    '            gridexpenses.Rows.Add("Total", Val((TOTALDREXP - TOTALCREXP)))
    '            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    '            gridincome.Rows.Add("Total", Val((TOTALCRINC - TOTALDRINC)))
    '            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    '            gridexpenses.Rows.Add("===========================", "===============", "===============")
    '            gridincome.Rows.Add("===========================", "===============", "===============")
    '            '***************************************************************************************



    '            '***** FILLING TOTAL ***********
    '            'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If


    '            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
    '            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")

    '            If (TOTALDREXP - TOTALCREXP) > (TOTALCRINC - TOTALDRINC) Then
    '                gridexpenses.Rows.Add("Gross Loss B/F", Val(TOTALGROSSLOSS))
    '                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
    '                'TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
    '            Else
    '                gridincome.Rows.Add("Gross Profit B/F", Val(TOTALGROSSPROFIT))
    '                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
    '                'TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
    '            End If
    '            ''*************************************************************************


    '            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
    '            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
    '            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
    '            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


    '            '***** FILLING TOTAL ***********
    '            'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If


    '            TOTALDREXP = 0
    '            TOTALCREXP = 0
    '            TOTALDRINC = 0
    '            TOTALCRINC = 0


    '            'FORMATTING GRID
    '            For Each DTROW As DataRow In DT.Rows
    '                Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

    '                If DTROW("PRIMARYGP") = "Indirect Expenses" Then
    '                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
    '                        gridexpenses.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

    '                        TOTALDREXP += Val(DTROW("DR"))
    '                        TOTALCREXP += Val(DTROW("CR"))

    '                    ElseIf DTROW("NAME").ToString.Trim <> "" Then
    '                        gridexpenses.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
    '                    Else
    '                        If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
    '                        gridexpenses.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
    '                    End If
    '                End If
    '                '*****************************************************************
    '                '*****************************************************************

    '                If DTROW("PRIMARYGP") = "Indirect Income" Then
    '                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
    '                        gridincome.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

    '                        TOTALDRINC += Val(DTROW("DR"))
    '                        TOTALCRINC += Val(DTROW("CR"))

    '                    ElseIf DTROW("NAME").ToString.Trim <> "" Then
    '                        gridincome.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
    '                    Else
    '                        If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
    '                        gridincome.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
    '                    End If
    '                End If
    '            Next

    '            '***** FILLING TOTAL ***********
    '            'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If

    '            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
    '            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
    '            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
    '            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


    '            If ((TOTALCRINC - TOTALDRINC) + TOTALGROSSPROFIT) >= ((TOTALDREXP - TOTALCREXP) + TOTALGROSSLOSS) Then
    '                gridexpenses.Rows.Add("Nett Profit", Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP))))
    '                TOTALNETTPROFIT = Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)))
    '                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
    '            Else
    '                gridincome.Rows.Add("Nett Loss", Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC))))
    '                TOTALNETTLOSS = Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)))
    '                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
    '            End If
    '            ''***************************************************************************************
    '            '***** FILLING TOTAL ***********
    '            'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If

    '            gridexpenses.Rows.Add("===========================", "===============", "===============")
    '            gridincome.Rows.Add("===========================", "===============", "===============")

    '            gridexpenses.Rows.Add("G Total", Val(TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP) + TOTALNETTPROFIT))
    '            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    '            gridincome.Rows.Add("G Total", Val(TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC) + TOTALNETTLOSS))
    '            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    '            gridexpenses.Rows.Add("===========================", "===============", "===============")
    '            gridincome.Rows.Add("===========================", "===============", "===============")
    '            '***************************************************************************************

    '        ElseIf rdledger.Checked = True Then

    '            DT = OBJPL.GETLEDGER()

    '            gridexpenses.RowCount = 1
    '            gridincome.RowCount = 1
    '            Dim TOTALDREXP, TOTALCREXP, TOTALDRINC, TOTALCRINC, TOTALGROSSPROFIT, TOTALGROSSLOSS As Double


    '            gridexpenses.Rows.Insert(0, "Opening Stock", "0.00")
    '            gridexpenses.Rows(0).DefaultCellStyle.ForeColor = Color.Maroon
    '            gridexpenses.Rows(0).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
    '            gridexpenses.Rows.Insert(1, "", "")


    '            Dim i As Integer = 1
    '            '***** GROSS PROFIT AND LOSS
    '            'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If

    '            'FORMATTING GRID
    '            For Each DTROW As DataRow In DT.Rows
    '                Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

    '                If DTROW("PRIMARYGP") = "Purchase A/C" Or DTROW("PRIMARYGP") = "Direct Expenses" Then
    '                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
    '                        gridexpenses.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

    '                        TOTALDREXP += Val(DTROW("DR"))
    '                        TOTALCREXP += Val(DTROW("CR"))

    '                    ElseIf DTROW("NAME").ToString.Trim <> "" Then
    '                        gridexpenses.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
    '                    Else
    '                        If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
    '                        gridexpenses.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
    '                    End If
    '                End If
    '                '*****************************************************************
    '                '*****************************************************************

    '                If DTROW("PRIMARYGP") = "Sales A/C" Or DTROW("PRIMARYGP") = "Direct Income" Then
    '                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
    '                        gridincome.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

    '                        TOTALDRINC += Val(DTROW("DR"))
    '                        TOTALCRINC += Val(DTROW("CR"))

    '                    ElseIf DTROW("NAME").ToString.Trim <> "" Then
    '                        gridincome.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
    '                    Else
    '                        If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
    '                        gridincome.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
    '                    End If
    '                End If
    '            Next

    '            '*****************************************************************
    '            '*****************************************************************



    '            '***** GROSS PROFIT AND LOSS
    '            'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If


    '            gridincome.Rows.Insert(gridincome.RowCount - 2, "", "")
    '            gridincome.Rows.Insert(gridincome.RowCount - 2, "", "")
    '            gridincome.Rows.Insert(gridincome.RowCount - 2, "Closing Stock", "0.00")
    '            gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.ForeColor = Color.Maroon
    '            gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)

    '            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
    '            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
    '            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
    '            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


    '            If (TOTALDREXP - TOTALCREXP) <= (TOTALCRINC - TOTALDRINC) Then
    '                gridexpenses.Rows.Add("Gross Profit C/O", Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP)))
    '                TOTALGROSSPROFIT = Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
    '                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
    '                TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
    '            Else
    '                gridincome.Rows.Add("Gross Loss C/O", Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC)))
    '                TOTALGROSSLOSS = Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
    '                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
    '                TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
    '            End If
    '            ''**************************************************************************************



    '            '***************************************************************************************
    '            '***** FILLING TOTAL ***********
    '            'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If

    '            gridexpenses.Rows.Add("===========================", "===============", "===============")
    '            gridincome.Rows.Add("===========================", "===============", "===============")

    '            gridexpenses.Rows.Add("Total", Val((TOTALDREXP - TOTALCREXP)))
    '            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    '            gridincome.Rows.Add("Total", Val((TOTALCRINC - TOTALDRINC)))
    '            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    '            gridexpenses.Rows.Add("===========================", "===============", "===============")
    '            gridincome.Rows.Add("===========================", "===============", "===============")
    '            '***************************************************************************************



    '            '***** FILLING TOTAL ***********
    '            'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If


    '            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
    '            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")

    '            If (TOTALDREXP - TOTALCREXP) > (TOTALCRINC - TOTALDRINC) Then
    '                gridexpenses.Rows.Add("Gross Loss B/F", Val(TOTALGROSSLOSS))
    '                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
    '                'TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
    '            Else
    '                gridincome.Rows.Add("Gross Profit B/F", Val(TOTALGROSSPROFIT))
    '                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
    '                'TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
    '            End If
    '            ''*************************************************************************


    '            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
    '            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
    '            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
    '            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


    '            '***** FILLING TOTAL ***********
    '            'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If


    '            TOTALDREXP = 0
    '            TOTALCREXP = 0
    '            TOTALDRINC = 0
    '            TOTALCRINC = 0


    '            'FORMATTING GRID
    '            For Each DTROW As DataRow In DT.Rows
    '                Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

    '                If DTROW("PRIMARYGP") = "Indirect Expenses" Then
    '                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
    '                        gridexpenses.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

    '                        TOTALDREXP += Val(DTROW("DR"))
    '                        TOTALCREXP += Val(DTROW("CR"))

    '                    ElseIf DTROW("NAME").ToString.Trim <> "" Then
    '                        gridexpenses.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
    '                    Else
    '                        If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
    '                        gridexpenses.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
    '                    End If
    '                End If
    '                '*****************************************************************
    '                '*****************************************************************

    '                If DTROW("PRIMARYGP") = "Indirect Income" Then
    '                    If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
    '                        gridincome.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

    '                        TOTALDRINC += Val(DTROW("DR"))
    '                        TOTALCRINC += Val(DTROW("CR"))

    '                    ElseIf DTROW("NAME").ToString.Trim <> "" Then
    '                        gridincome.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
    '                    Else
    '                        If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
    '                        gridincome.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
    '                    End If
    '                End If
    '            Next

    '            '***** FILLING TOTAL ***********
    '            'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If

    '            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
    '            gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
    '            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
    '            gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


    '            If ((TOTALCRINC - TOTALDRINC) + TOTALGROSSPROFIT) >= ((TOTALDREXP - TOTALCREXP) + TOTALGROSSLOSS) Then
    '                gridexpenses.Rows.Add("Nett Profit", Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP))))
    '                TOTALNETTPROFIT = Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)))
    '                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
    '            Else
    '                gridincome.Rows.Add("Nett Loss", Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC))))
    '                TOTALNETTLOSS = Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)))
    '                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
    '                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
    '            End If
    '            ''***************************************************************************************
    '            '***** FILLING TOTAL ***********
    '            'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If

    '            gridexpenses.Rows.Add("===========================", "===============", "===============")
    '            gridincome.Rows.Add("===========================", "===============", "===============")

    '            gridexpenses.Rows.Add("G Total", Val(TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP) + TOTALNETTPROFIT))
    '            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    '            gridincome.Rows.Add("G Total", Val(TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC) + TOTALNETTLOSS))
    '            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
    '            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

    '            gridexpenses.Rows.Add("===========================", "===============", "===============")
    '            gridincome.Rows.Add("===========================", "===============", "===============")
    '            '***************************************************************************************

    '            '***** FILLING TOTAL ***********
    '            'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
    '            If gridexpenses.RowCount > gridincome.RowCount Then
    '                For i = 1 To gridexpenses.RowCount - gridincome.RowCount
    '                    gridincome.Rows.Add("", "", "")
    '                Next
    '            ElseIf gridexpenses.RowCount < gridincome.RowCount Then
    '                For i = 1 To gridincome.RowCount - gridexpenses.RowCount
    '                    gridexpenses.Rows.Add("", "", "")
    '                Next
    '            End If

    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Sub FILLPL()
        Try
            Dim OBJPL As New ClsProfitLoss
            Dim ALPARAVAL As New ArrayList
            Dim DT As DataTable
            Dim OBJCMN As New ClsCommon

            If chkdate.CheckState = CheckState.Checked Then
                ALPARAVAL.Add(dtfrom.Value.Date)
                ALPARAVAL.Add(dtto.Value.Date)
            Else
                ALPARAVAL.Add(AccFrom)
                ALPARAVAL.Add(AccTo)
            End If
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJPL.alParaval = ALPARAVAL

            'CODE BY GULKIT
            'GET OPSTOCK
            Dim OPSTOCK, CLOSTOCK As Double
            OPSTOCK = 0
            CLOSTOCK = 0
            Dim OPSTOCKDT As DataTable = OBJCMN.search(" OPENINGSTOCK, CLOSINGSTOCK", "", " OPENINGCLOSINGSTOCK ", " AND YEARID = " & YearId)
            If OPSTOCKDT.Rows.Count > 0 Then
                OPSTOCK = Val(OPSTOCKDT.Rows(0).Item("OPENINGSTOCK"))
                CLOSTOCK = Val(OPSTOCKDT.Rows(0).Item("CLOSINGSTOCK"))
            End If

            If rdcondensed.Checked = True Then

                DT = OBJPL.GETSUMMARY()

                gridexpenses.RowCount = 1
                gridincome.RowCount = 1


                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows

                    If DTROW(0) = "Purchase A/C" Or DTROW(0) = "Direct Expenses" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW(0) = "Sales A/C" Or DTROW(0) = "Direct Income" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    '*****************************************************************
                    '*****************************************************************
                    Dim i As Integer

                    If DTROW(0) = "Gross Profit C/O" Or DTROW(0) = "Gross Loss C/O" Then

                        gridexpenses.Rows.Insert(0, "Opening Stock", OPSTOCK)
                        gridexpenses.Rows(0).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(0).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        'gridincome.Rows.Insert(0, "Opening Stock", "0.00")

                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridincome.Rows.Insert(gridincome.RowCount - 2, "Closing Stock", "0.00", CLOSTOCK)
                        gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                    End If



                    If DTROW(0) = "Gross Profit C/O" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Gross Loss C/O" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    '**************************************************************************************



                    If DTROW(0) = "Total EXP" Then

                        '***** FILLING TOTAL
                        'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")

                        gridexpenses.Rows.Add("Total", Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Total INC" Then
                        gridincome.Rows.Add("Total", Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")
                    End If
                    '***************************************************************************************


                    If DTROW(0) = "Gross Profit B/F" Or DTROW(0) = "Gross Loss B/F" Then
                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If
                    End If


                    If DTROW(0) = "Gross Loss B/F" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Gross Profit B/F" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*************************************************************************


                    If DTROW(0) = "Indirect Expenses" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Indirect Income" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '***************************************************************************************


                    If DTROW(0) = "Nett Profit" Or DTROW(0) = "Nett Loss" Then
                        '***** GROSS PROFIT AND LOSS
                        'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If
                    End If


                    If DTROW(0) = "Nett Profit" Then
                        gridexpenses.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "Nett Loss" Then
                        gridincome.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If
                    '*************************************************************************


                    If DTROW(0) = "G. Total EXP" Then

                        '***** FILLING TOTAL
                        'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                        If gridexpenses.RowCount > gridincome.RowCount Then
                            For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                                gridincome.Rows.Add("", "", "")
                            Next
                        ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                            For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                                gridexpenses.Rows.Add("", "", "")
                            Next
                        End If

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")

                        gridexpenses.Rows.Add("Total", Val(DTROW(1)))
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                    End If

                    If DTROW(0) = "G. Total INC" Then
                        gridincome.Rows.Add("Total", Val(DTROW(1)))
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        gridexpenses.Rows.Add("===========================", "===============", "===============")
                        gridincome.Rows.Add("===========================", "===============", "===============")
                    End If
                    '***************************************************************************************


                Next

            ElseIf rddetails.Checked = True Then

                DT = OBJPL.GETDETAILS()

                gridexpenses.RowCount = 1
                gridincome.RowCount = 1
                Dim TOTALDREXP, TOTALCREXP, TOTALDRINC, TOTALCRINC, TOTALGROSSPROFIT, TOTALGROSSLOSS As Double

                TOTALDREXP += OPSTOCK

                gridexpenses.Rows.Insert(0, "Opening Stock", OPSTOCK)
                gridexpenses.Rows(0).DefaultCellStyle.ForeColor = Color.Maroon
                gridexpenses.Rows(0).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                gridexpenses.Rows.Insert(1, "", "")


                Dim i As Integer = 1
                '***** GROSS PROFIT AND LOSS
                'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows
                    Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

                    If DTROW("PRIMARYGP") = "Purchase A/C" Or DTROW("PRIMARYGP") = "Direct Expenses" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridexpenses.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDREXP += Val(DTROW("DR"))
                            TOTALCREXP += Val(DTROW("CR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridexpenses.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridexpenses.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW("PRIMARYGP") = "Sales A/C" Or DTROW("PRIMARYGP") = "Direct Income" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridincome.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDRINC += Val(DTROW("DR"))
                            TOTALCRINC += Val(DTROW("CR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridincome.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridincome.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                Next

                '*****************************************************************
                '*****************************************************************



                '***** GROSS PROFIT AND LOSS
                'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                TOTALCRINC += CLOSTOCK

                gridincome.Rows.Insert(gridincome.RowCount - 2, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 2, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 2, "Closing Stock", "0.00", CLOSTOCK)
                gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.ForeColor = Color.Maroon
                gridincome.Rows(gridincome.RowCount - 3).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)

                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


                If (TOTALDREXP - TOTALCREXP) <= (TOTALCRINC - TOTALDRINC) Then
                    gridexpenses.Rows.Add("Gross Profit C/O", Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP)))
                    TOTALGROSSPROFIT = Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                Else
                    gridincome.Rows.Add("Gross Loss C/O", Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC)))
                    TOTALGROSSLOSS = Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                End If
                ''**************************************************************************************



                '***************************************************************************************
                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")

                gridexpenses.Rows.Add("Total", Val((TOTALDREXP - TOTALCREXP)))
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridincome.Rows.Add("Total", Val((TOTALCRINC - TOTALDRINC)))
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")
                '***************************************************************************************



                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If


                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")

                If (TOTALDREXP - TOTALCREXP) > (TOTALCRINC - TOTALDRINC) Then
                    gridexpenses.Rows.Add("Gross Loss B/F", Val(TOTALGROSSLOSS))
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    'TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                Else
                    gridincome.Rows.Add("Gross Profit B/F", Val(TOTALGROSSPROFIT))
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    'TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                End If
                ''*************************************************************************


                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If


                TOTALDREXP = 0
                TOTALCREXP = 0
                TOTALDRINC = 0
                TOTALCRINC = 0


                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows
                    Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

                    If DTROW("PRIMARYGP") = "Indirect Expenses" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridexpenses.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDREXP += Val(DTROW("DR"))
                            TOTALCREXP += Val(DTROW("CR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridexpenses.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridexpenses.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW("PRIMARYGP") = "Indirect Income" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridincome.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDRINC += Val(DTROW("DR"))
                            TOTALCRINC += Val(DTROW("CR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridincome.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridincome.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                Next

                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


                If ((TOTALCRINC - TOTALDRINC) + TOTALGROSSPROFIT) >= ((TOTALDREXP - TOTALCREXP) + TOTALGROSSLOSS) Then
                    gridexpenses.Rows.Add("Nett Profit", Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP))))
                    TOTALNETTPROFIT = Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)))
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                Else
                    gridincome.Rows.Add("Nett Loss", Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC))))
                    TOTALNETTLOSS = Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)))
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                End If
                ''***************************************************************************************
                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")

                gridexpenses.Rows.Add("G Total", Val(TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP) + TOTALNETTPROFIT))
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridincome.Rows.Add("G Total", Val(TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC) + TOTALNETTLOSS))
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")
                '***************************************************************************************

            ElseIf rdledger.Checked = True Then

                DT = OBJPL.GETLEDGER()

                gridexpenses.RowCount = 1
                gridincome.RowCount = 1
                Dim TOTALDREXP, TOTALCREXP, TOTALDRINC, TOTALCRINC, TOTALGROSSPROFIT, TOTALGROSSLOSS As Double

                TOTALDREXP += OPSTOCK

                gridexpenses.Rows.Insert(0, "Opening Stock", OPSTOCK)
                gridexpenses.Rows(0).DefaultCellStyle.ForeColor = Color.Maroon
                gridexpenses.Rows(0).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                gridexpenses.Rows.Insert(1, "", "")


                Dim i As Integer = 1
                '***** GROSS PROFIT AND LOSS
                'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows
                    Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

                    If DTROW("PRIMARYGP") = "Purchase A/C" Or DTROW("PRIMARYGP") = "Direct Expenses" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridexpenses.Rows.Add(DTROW("PRIMARYGP"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDREXP += Val(DTROW("CLOBALDR"))
                            TOTALCREXP += Val(DTROW("CLOBALCR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridexpenses.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridexpenses.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW("PRIMARYGP") = "Sales A/C" Or DTROW("PRIMARYGP") = "Direct Income" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridincome.Rows.Add(DTROW("PRIMARYGP"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDRINC += Val(DTROW("CLOBALDR"))
                            TOTALCRINC += Val(DTROW("CLOBALCR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridincome.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridincome.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                Next

                '*****************************************************************
                '*****************************************************************



                '***** GROSS PROFIT AND LOSS
                'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If


                TOTALCRINC += CLOSTOCK

                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "Closing Stock", "0.00", CLOSTOCK)
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)

                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


                If (TOTALDREXP - TOTALCREXP) <= (TOTALCRINC - TOTALDRINC) Then
                    gridexpenses.Rows.Add("Gross Profit C/O", Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP)))
                    TOTALGROSSPROFIT = Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                Else
                    gridincome.Rows.Add("Gross Loss C/O", Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC)))
                    TOTALGROSSLOSS = Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                End If
                ''**************************************************************************************



                '***************************************************************************************
                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")

                gridexpenses.Rows.Add("Total", Val((TOTALDREXP - TOTALCREXP)))
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridincome.Rows.Add("Total", Val((TOTALCRINC - TOTALDRINC)))
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")
                '***************************************************************************************



                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If


                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")

                If (TOTALDREXP - TOTALCREXP) > (TOTALCRINC - TOTALDRINC) Then
                    gridexpenses.Rows.Add("Gross Loss B/F", Val(TOTALGROSSLOSS))
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    'TOTALDREXP += Val((TOTALCRINC - TOTALDRINC) - (TOTALDREXP - TOTALCREXP))
                Else
                    gridincome.Rows.Add("Gross Profit B/F", Val(TOTALGROSSPROFIT))
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                    'TOTALCRINC += Val((TOTALDREXP - TOTALCREXP) - (TOTALCRINC - TOTALDRINC))
                End If
                ''*************************************************************************


                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If


                TOTALDREXP = 0
                TOTALCREXP = 0
                TOTALDRINC = 0
                TOTALCRINC = 0


                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows
                    Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

                    If DTROW("PRIMARYGP") = "Indirect Expenses" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridexpenses.Rows.Add(DTROW("PRIMARYGP"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDREXP += Val(DTROW("CLOBALDR"))
                            TOTALCREXP += Val(DTROW("CLOBALCR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridexpenses.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridexpenses.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                            gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW("PRIMARYGP") = "Indirect Income" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridincome.Rows.Add(DTROW("PRIMARYGP"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDRINC += Val(DTROW("CLOBALDR"))
                            TOTALCRINC += Val(DTROW("CLOBALCR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridincome.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridincome.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("CLOBALDR"), DTROW("CLOBALCR"))
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                            gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                Next

                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridincome.Rows.Insert(gridincome.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")
                gridexpenses.Rows.Insert(gridexpenses.RowCount - 1, "", "")


                If ((TOTALCRINC - TOTALDRINC) + TOTALGROSSPROFIT) >= ((TOTALDREXP - TOTALCREXP) + TOTALGROSSLOSS) Then
                    gridexpenses.Rows.Add("Nett Profit", Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP))))
                    TOTALNETTPROFIT = Val((TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)) - (TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)))
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                Else
                    gridincome.Rows.Add("Nett Loss", Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC))))
                    TOTALNETTLOSS = Val((TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP)) - (TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC)))
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                    gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
                End If
                ''***************************************************************************************
                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")

                gridexpenses.Rows.Add("G Total", Val(TOTALGROSSLOSS + (TOTALDREXP - TOTALCREXP) + TOTALNETTPROFIT))
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridexpenses.Rows(gridexpenses.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridincome.Rows.Add("G Total", Val(TOTALGROSSPROFIT + (TOTALCRINC - TOTALDRINC) + TOTALNETTLOSS))
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridincome.Rows(gridincome.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridexpenses.Rows.Add("===========================", "===============", "===============")
                gridincome.Rows.Add("===========================", "===============", "===============")
                '***************************************************************************************

                '***** FILLING TOTAL ***********
                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridexpenses.RowCount > gridincome.RowCount Then
                    For i = 1 To gridexpenses.RowCount - gridincome.RowCount
                        gridincome.Rows.Add("", "", "")
                    Next
                ElseIf gridexpenses.RowCount < gridincome.RowCount Then
                    For i = 1 To gridincome.RowCount - gridexpenses.RowCount
                        gridexpenses.Rows.Add("", "", "")
                    Next
                End If

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try

            Dim OBJBS As New ClsBalanceSheet
            Dim ALPARAVAL As New ArrayList
            Dim DT As DataTable


            'FOR BALANCE SHEET
            Dim OBJPL As New ClsProfitLoss
            Dim DTPL As New DataTable


            If chkdate.CheckState = CheckState.Checked Then
                ALPARAVAL.Add(dtfrom.Value.Date)
                ALPARAVAL.Add(dtto.Value.Date)
            Else
                ALPARAVAL.Add(AccFrom)
                ALPARAVAL.Add(AccTo)
            End If
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(YearId)

            OBJBS.alParaval = ALPARAVAL
            OBJPL.alParaval = ALPARAVAL

            DTPL = OBJPL.GETSUMMARY()
            Dim DRPL() As DataRow = DTPL.Select("NAME = 'Nett Profit' OR NAME = 'Nett Loss'")

            If rdcondensed.Checked = True Then
                DT = OBJBS.GETSUMMARY()

                gridliabilities.RowCount = 1
                gridassets.RowCount = 1


                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows


                    'LIABILITY GRID
                    If DTROW(0) = "Capital A/C" Or DTROW(0) = "Branch / Divisions" Or DTROW(0) = "Loans" Or DTROW(0) = "Current Liabilities" Or DTROW(0) = "Suspense A/C" Then
                        gridliabilities.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE1
                    End If
                    '*****************************************************************
                    '*****************************************************************


                    If DTROW(0) = "Diff. in Opening A/C" And Format(Val(DTROW(1)), "0.00") > 0 Then
                        gridliabilities.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE1
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW(0) = "Profit" Then
                        If DRPL(0)(0) = "Nett Loss" Then GoTo LINE1
                        gridliabilities.Rows.Add("Profit & Loss", Val(DRPL(0)(1)))
                        Dim ROW() As DataRow = DT.Select("NAME = 'Total Liability'")
                        ROW(0)(1) = ROW(0)(1) + Val(DRPL(0)(1))
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE1
                    End If
                    '*****************************************************************
                    '*****************************************************************



                    '***** FILLING TOTAL
                    Dim i As Integer
                    If DTROW(0) = "Total Liability" Then

                        '***** FILLING TOTAL
                        'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                        If gridliabilities.RowCount > gridassets.RowCount Then
                            For i = 1 To gridliabilities.RowCount - gridassets.RowCount
                                gridassets.Rows.Add("", "", "")
                            Next
                        ElseIf gridliabilities.RowCount < gridassets.RowCount Then
                            For i = 1 To gridassets.RowCount - gridliabilities.RowCount
                                gridliabilities.Rows.Add("", "", "")
                            Next
                        End If

                        gridliabilities.Rows.Add("===========================", "===============", "===============")
                        gridassets.Rows.Add("===========================", "===============", "===============")

                        gridliabilities.Rows.Add("Total", Val(DTROW(1)))
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE1
                    End If




                    'ASSETS GRID
                    If DTROW(0) = "Fixed Assets" Or DTROW(0) = "Investments" Or DTROW(0) = "Current Assets" Or DTROW(0) = "Misc. Expenses" Then
                        gridassets.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE1
                    End If
                    '*****************************************************************
                    '*****************************************************************


                    If DTROW(0) = "Diff. in Opening A/C (Assets)" And Format(Val(DTROW(1)), "0.00") > 0 Then
                        gridassets.Rows.Add(DTROW(0), Val(DTROW(1)))
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE1
                    End If
                    '*****************************************************************
                    '*****************************************************************


                    If DTROW(0) = "Loss" Then
                        If DRPL(0)(0) = "Nett Profit" Then GoTo LINE1
                        gridassets.Rows.Add("Profit & Loss", Val(DRPL(0)(1)))
                        Dim ROW() As DataRow = DT.Select("NAME = 'Total Assets'")
                        ROW(0)(1) = ROW(0)(1) + Val(DRPL(0)(1))
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)
                        GoTo LINE1
                    End If
                    '*****************************************************************
                    '*****************************************************************


                    If DTROW(0) = "Total Assets" Then
                        gridassets.Rows.Add("Total", Val(DTROW(1)))
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                        gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 9, FontStyle.Regular)

                        gridliabilities.Rows.Add("===========================", "===============", "===============")
                        gridassets.Rows.Add("===========================", "===============", "===============")
                        GoTo LINE1
                    End If
                    '***************************************************************************************

LINE1:

                Next

            Else

                If rddetails.Checked = True Then
                    DT = OBJBS.GETDETAILS()
                ElseIf rdledger.Checked = True Then
                    DT = OBJBS.GETLEDGERDETAILS()
                End If
                gridliabilities.RowCount = 1
                gridassets.RowCount = 1
                Dim TOTALDRLIA, TOTALCRLIA, TOTALDRASS, TOTALCRASS As Double


                'FORMATTING GRID
                For Each DTROW As DataRow In DT.Rows
                    Dim SPACE As String = SPACER(Val(DTROW("LEVELNO")))

                    If DTROW("PRIMARYGP") = "Capital A/C" Or DTROW("PRIMARYGP") = "Branch / Divisions" Or DTROW("PRIMARYGP") = "Loans" Or DTROW("PRIMARYGP") = "Current Liabilities" Or DTROW("PRIMARYGP") = "Suspense A/C" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridliabilities.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
                            gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDRLIA += Val(DTROW("DR"))
                            TOTALCRLIA += Val(DTROW("CR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridliabilities.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
                            gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridliabilities.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
                            gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                            gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                    '*****************************************************************
                    '*****************************************************************

                    If DTROW("PRIMARYGP") = "Fixed Assets" Or DTROW("PRIMARYGP") = "Investments" Or DTROW("PRIMARYGP") = "Current Assets" Or DTROW("PRIMARYGP") = "Misc. Expenses" Then
                        If DTROW("NAME").ToString.Trim = "" And DTROW("SECONDARY").ToString.Trim = "" And DTROW("UNDER").ToString.Trim = "" And DTROW("GPNAME").ToString.Trim = "" Then
                            gridassets.Rows.Add(DTROW("PRIMARYGP"), DTROW("DR"), DTROW("CR"))
                            gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDRASS += Val(DTROW("DR"))
                            TOTALCRASS += Val(DTROW("CR"))

                        ElseIf DTROW("NAME").ToString.Trim <> "" Then
                            gridassets.Rows.Add(SPACE & "     " & DTROW("NAME"), DTROW("DR"), DTROW("CR"))
                            gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Regular)
                        Else
                            If Val(DTROW("LEVELNO")) >= 1 Then SPACE = SPACE & " "
                            gridassets.Rows.Add(SPACE & DTROW("GPNAME"), DTROW("DR"), DTROW("CR"))
                            gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Green
                            gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)
                        End If
                    End If
                Next

                Dim i As Integer = 1
                '***** GROSS PROFIT AND LOSS
                'KEEPING A WATCH THAT GP,GL SHOULD COME ON THE SAME LINE
                If gridliabilities.RowCount > gridassets.RowCount Then
                    For i = 1 To gridliabilities.RowCount - gridassets.RowCount
                        gridassets.Rows.Add("", "", "")
                    Next
                ElseIf gridliabilities.RowCount < gridassets.RowCount Then
                    For i = 1 To gridassets.RowCount - gridliabilities.RowCount
                        gridliabilities.Rows.Add("", "", "")
                    Next
                End If

                gridliabilities.Rows.Add("", "", "")
                gridassets.Rows.Add("", "", "")

                'add gp or loss
                If TOTALNETTPROFIT > 0 Then
                    gridliabilities.Rows.Add("Nett Profit", TOTALNETTPROFIT)
                    gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                    gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                    TOTALCRLIA += Val(TOTALNETTPROFIT)
                Else
                    gridassets.Rows.Add("Nett Loss", TOTALNETTLOSS)
                    gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                    gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                    TOTALDRASS += Val(TOTALNETTLOSS)
                End If






                'FORMATTING GRID
                Dim DTROW1() As DataRow = DT.Select("PRIMARYGP = 'Opening A/C'")
                If DTROW1.Length > 0 Then
                    If DTROW1(0)("PRIMARYGP") = "Opening A/C" Then
                        If (Val(DTROW1(0)("CR")) - Val(DTROW1(0)("DR"))) > 0 Then
                            gridliabilities.Rows.Add("Diff. in Opening A/C", (Val(DTROW1(0)("CR")) - Val(DTROW1(0)("DR"))))
                            gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDRLIA += Val(DTROW1(0)("DR"))
                            TOTALCRLIA += Val(DTROW1(0)("CR"))
                        Else
                            gridassets.Rows.Add("Diff. in Opening A/C", (Val(DTROW1(0)("DR")) - Val(DTROW1(0)("CR"))))
                            gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                            gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("CALIBRI", 10, FontStyle.Bold)

                            TOTALDRASS += Val(DTROW1(0)("DR"))
                            TOTALCRASS += Val(DTROW1(0)("CR"))
                        End If
                    End If
                End If
                '*****************************************************************
                '*****************************************************************


                'KEEPING A WATCH THAT TOTAL SHOULD COME ON THE SAME LINE
                If gridliabilities.RowCount > gridassets.RowCount Then
                    For i = 1 To gridliabilities.RowCount - gridassets.RowCount
                        gridassets.Rows.Add("", "", "")
                    Next
                ElseIf gridliabilities.RowCount < gridassets.RowCount Then
                    For i = 1 To gridassets.RowCount - gridliabilities.RowCount
                        gridliabilities.Rows.Add("", "", "")
                    Next
                End If

                gridliabilities.Rows.Add("===========================", "===============", "===============")
                gridassets.Rows.Add("===========================", "===============", "===============")

                gridliabilities.Rows.Add("Total", Val((TOTALCRLIA - TOTALDRLIA)))
                gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridliabilities.Rows(gridliabilities.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridassets.Rows.Add("Total", Val((TOTALDRASS - TOTALCRASS)))
                gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.ForeColor = Color.Maroon
                gridassets.Rows(gridassets.RowCount - 2).DefaultCellStyle.Font = New Font("Calibri", 10, FontStyle.Regular)

                gridliabilities.Rows.Add("===========================", "===============", "===============")
                gridassets.Rows.Add("===========================", "===============", "===============")

            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function SPACER(ByVal LEVEL As Integer) As String
        Dim SPACE As String = ""
        Dim I As Integer = 0
        For I = 0 To LEVEL
            SPACE = SPACE & "   "
        Next
        Return SPACE
    End Function

    Private Sub GRIDLIABILITIES_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridliabilities.CellDoubleClick
        Try
            showform(gridliabilities.Item(0, e.RowIndex).Value.ToString.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridexpenses_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridexpenses.CellDoubleClick
        Try
            showform(gridexpenses.Item(0, e.RowIndex).Value.ToString.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridexpenses_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridexpenses.RowEnter
        If gridincome.RowCount = gridexpenses.RowCount Then gridincome.Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub gridexpenses_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles gridexpenses.Scroll
        gridincome.FirstDisplayedScrollingRowIndex = e.NewValue
    End Sub

    Private Sub gridincome_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridincome.CellDoubleClick
        Try
            showform(gridincome.Item(0, e.RowIndex).Value.ToString.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridincome_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridincome.RowEnter
        If gridincome.RowCount = gridexpenses.RowCount Then gridexpenses.Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub gridincome_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles gridincome.Scroll
        gridexpenses.FirstDisplayedScrollingRowIndex = e.NewValue
    End Sub

    Private Sub GRIDLIABILITIES_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridliabilities.RowEnter
        If gridassets.RowCount = gridliabilities.RowCount Then gridassets.Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub GRIDLIABILITIES_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles gridliabilities.Scroll
        gridassets.FirstDisplayedScrollingRowIndex = e.NewValue
    End Sub

    Private Sub gridassets_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridassets.CellDoubleClick
        Try
            showform(gridassets.Item(0, e.RowIndex).Value.ToString.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridassets_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridassets.RowEnter
        If gridassets.RowCount = gridliabilities.RowCount Then gridliabilities.Rows(e.RowIndex).Selected = True
    End Sub

    Private Sub gridassets_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles gridassets.Scroll
        gridliabilities.FirstDisplayedScrollingRowIndex = e.NewValue
    End Sub

    Private Sub CMDSHOWDETAILS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSHOWDETAILS.Click
        If rdcondensed.Checked = True Or rddetails.Checked = True Or rdledger.Checked = True Then fillgrid()
    End Sub

    Sub showform(ByVal name As String)
        Try
            If name <> "" Then
                Dim objlb As New RegisterDetails
                objlb.cmbname.Text = name
                objlb.fillgrid()
                objlb.MdiParent = MDIMain
                objlb.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            'Dim CONDITION As String = ""
            'If rdcondensed.Checked = True Then
            '    CONDITION = "CONDENSED"
            'ElseIf rddetails.Checked = True Then
            '    CONDITION = "DETAILS"
            'ElseIf rdledger.Checked = True Then
            '    CONDITION = "LEDGERDETAILS"
            'End If
            'If CONDITION <> "" Then

            '    Dim ALPARAVAL As New ArrayList

            '    If chkdate.CheckState = CheckState.Checked Then
            '        ALPARAVAL.Add(dtfrom.Value.Date)
            '        ALPARAVAL.Add(dtto.Value.Date)
            '    Else
            '        ALPARAVAL.Add(AccFrom)
            '        ALPARAVAL.Add(AccTo)
            '    End If
            '    ALPARAVAL.Add(CmpId)
            '    ALPARAVAL.Add(Locationid)
            '    ALPARAVAL.Add(YearId)

            '    Dim OBJRPT As New clsReportDesigner("BALANCE SHEET", System.AppDomain.CurrentDomain.BaseDirectory & "BALANCE SHEET.xlsx", 2)

            '    OBJRPT.ALPARAVAL = ALPARAVAL
            '    OBJRPT.BALANCE_SHEET_EXCEL(CONDITION, CmpId, Locationid, YearId)
            'End If

            Dim TEMPMSG As Integer = MsgBox("Wish to Print?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub

            Dim OBJBS As New ClsBalanceSheet
            OBJBS.DELETE(CmpId)

            For I As Integer = 0 To gridliabilities.RowCount - 2

                Dim ALPARAVAL As New ArrayList
                If gridliabilities.Rows(I).Cells(GLIANAME.Index).Value <> "===========================" And gridliabilities.Rows(I).Cells(GLIANAME.Index).Value <> "" Then
                    If gridliabilities.Rows(I).Cells(GLIANAME.Index).Value <> Nothing Then
                        ALPARAVAL.Add(gridliabilities.Rows(I).Cells(GLIANAME.Index).Value)
                    Else
                        ALPARAVAL.Add("")
                    End If
                Else
                    ALPARAVAL.Add("")
                End If

                If gridliabilities.Rows(I).Cells(GLIADR.Index).Value <> Nothing Then
                    ALPARAVAL.Add(Val(gridliabilities.Rows(I).Cells(GLIADR.Index).Value))
                Else
                    ALPARAVAL.Add("")
                End If

                If gridliabilities.Rows(I).Cells(GLIACR.Index).Value <> Nothing Then
                    ALPARAVAL.Add(Val(gridliabilities.Rows(I).Cells(GLIACR.Index).Value))
                Else
                    ALPARAVAL.Add("")
                End If

                '----------------------------------------------------------------------------------
                If gridassets.Rows(I).Cells(GASSNAME.Index).Value <> "===========================" And gridassets.Rows(I).Cells(GASSNAME.Index).Value <> "" Then
                    If gridassets.Rows(I).Cells(GASSNAME.Index).Value <> Nothing Then
                        ALPARAVAL.Add(gridassets.Rows(I).Cells(GASSNAME.Index).Value)
                    Else
                        ALPARAVAL.Add("")
                    End If
                Else
                    ALPARAVAL.Add("")
                End If

                If gridassets.Rows(I).Cells(GASSDR.Index).Value <> Nothing Then
                    ALPARAVAL.Add(Val(gridassets.Rows(I).Cells(GASSDR.Index).Value))
                Else
                    ALPARAVAL.Add("")
                End If

                If gridassets.Rows(I).Cells(GASSCR.Index).Value <> Nothing Then
                    ALPARAVAL.Add(Val(gridassets.Rows(I).Cells(GASSCR.Index).Value))
                Else
                    ALPARAVAL.Add("")
                End If

                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(I)


                If gridliabilities.Rows(I).Cells(GLIANAME.Index).Value <> "===========================" And gridliabilities.Rows(I).Cells(GLIANAME.Index).Value <> "" Then
                    If gridliabilities.Rows(I).Cells(GLIANAME.Index).Value <> Nothing Then
                        If gridliabilities.Rows(I).DefaultCellStyle.ForeColor = Color.Empty Then
                            ALPARAVAL.Add(0)
                        Else
                            ALPARAVAL.Add(1)
                        End If
                    End If
                Else
                    ALPARAVAL.Add(0)
                End If

                If gridassets.Rows(I).Cells(GASSNAME.Index).Value <> "===========================" And gridassets.Rows(I).Cells(GASSNAME.Index).Value <> "" Then
                    If gridassets.Rows(I).Cells(GASSNAME.Index).Value <> Nothing Then
                        If gridassets.Rows(I).DefaultCellStyle.ForeColor <> Color.Empty Then
                            ALPARAVAL.Add(1)
                        Else
                            ALPARAVAL.Add(0)
                        End If
                    End If
                Else
                    ALPARAVAL.Add(0)
                End If



                OBJBS.alParaval = ALPARAVAL
                OBJBS.SAVE()

            Next

            Dim OBJPLPRINT As New PLDesign
            OBJPLPRINT.MdiParent = MDIMain
            OBJPLPRINT.frmstring = "BALANCESHEET"
            OBJPLPRINT.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BS_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If ClientName = "SVS" Then Me.Close()
    End Sub
End Class