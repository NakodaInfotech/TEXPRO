
Imports BL

Public Class POFilter

    Dim edit As Boolean
    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String
    Public FRMSTRING As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Try
            Me.Close()
        Catch ex As Exception
            Throw ex
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

    Private Sub SOFilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SOFilter_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdshow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdshow.Click
        Try

            Dim OBJGRN As New PurchaseOrderDesign
            OBJGRN.MdiParent = MDIMain
            If FRMSTRING = "SO" Then
                OBJGRN.WHERECLAUSE = " {ALLSALEORDER.SO_yearid}=" & YearId
            Else
                OBJGRN.WHERECLAUSE = " {ALLPURCHASEORDER.PO_yearid}=" & YearId
            End If

            If chkdate.Checked = True Then
                getFromToDate()
                OBJGRN.PERIOD = Format(dtfrom.Value, "dd/MM/yyyy") & " - " & Format(dtto.Value, "dd/MM/yyyy")
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@DATE} in date " & fromD & " to date " & toD & ""
            Else
                OBJGRN.PERIOD = Format(AccFrom, "dd/MM/yyyy") & " - " & Format(AccTo, "dd/MM/yyyy")
            End If

            If RDBPARTYSUMM.Checked = True Then
                OBJGRN.FRMSTRING = "POSUMM"
            ElseIf RDBPARTYDTLS.Checked = True Then
                OBJGRN.FRMSTRING = "PODTLS"
            ElseIf RDBSTATUSDETAILS.Checked = True Then
                OBJGRN.FRMSTRING = "POSTATUSDTLS"
            End If


            If RDBPENDING.Checked = True Then
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@BALANCE} > 0 and {ALLPURCHASEORDER_DESC.PO_Closed}=FALSE "
            End If
            If RDBCOMPLETE.Checked = True Then
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {@BALANCE} <= 0 and {ALLPURCHASEORDER_DESC.PO_Closed}=FALSE "
            End If
            If RDBCLOSED.Checked = True Then OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & " and {ALLPURCHASEORDER_DESC.PO_Closed}=true "



            'FOR PARTYNAME
            gridbill.ClearColumnsFilter()
            Dim NAMECLAUSE As String = ""
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If NAMECLAUSE = "" Then
                        NAMECLAUSE = " AND ({LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                    Else
                        NAMECLAUSE = NAMECLAUSE & " OR {LEDGERS.ACC_CMPNAME} = '" & dtrow("NAME") & "'"
                    End If
                End If
            Next
            If NAMECLAUSE <> "" Then
                NAMECLAUSE = NAMECLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & NAMECLAUSE
            End If


            'FOR ITEMNAME
            GRIDBILLITEM.ClearColumnsFilter()
            Dim ITEMCLAUSE As String = ""
            For i As Integer = 0 To GRIDBILLITEM.RowCount - 1
                Dim dtrow As DataRow = GRIDBILLITEM.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    If ITEMCLAUSE = "" Then
                        ITEMCLAUSE = " AND ({ITEMMASTER.ITEM_NAME} = '" & dtrow("ITEMNAME") & "'"
                    Else
                        ITEMCLAUSE = ITEMCLAUSE & " OR {ITEMMASTER.ITEM_NAME} = '" & dtrow("ITEMNAME") & "'"
                    End If
                End If
            Next
            If ITEMCLAUSE <> "" Then
                ITEMCLAUSE = ITEMCLAUSE & ")"
                OBJGRN.WHERECLAUSE = OBJGRN.WHERECLAUSE & ITEMCLAUSE
            End If

            OBJGRN.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, LEDGERS.Acc_cmpname AS NAME ", " ", " LEDGERS INNER JOIN GROUPMASTER ON LEDGERS.Acc_groupid = GROUPMASTER.group_id ", " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Debtors' AND (LEDGERS.ACC_YEARID = '" & YearId & "') ORDER BY LEDGERS.Acc_cmpname")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

            Dim DTITEM As DataTable = OBJCMN.search(" CAST (0 AS BIT) AS CHK, ITEMMASTER.ITEM_NAME AS ITEMNAME ", " ", " ITEMMASTER ", " AND ITEMMASTER.ITEM_YEARID = '" & YearId & "' ORDER BY ITEMMASTER.ITEM_NAME")
            GRIDBILLDETAILSITEM.DataSource = DTITEM
            If DTITEM.Rows.Count > 0 Then
                GRIDBILLITEM.FocusedRowHandle = GRIDBILLITEM.RowCount - 1
                GRIDBILLITEM.TopRowIndex = GRIDBILLITEM.RowCount - 15
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                dtrow("CHK") = CHKSELECTALL.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTITEM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTITEM.CheckedChanged
        Try
            For i As Integer = 0 To GRIDBILLITEM.RowCount - 1
                Dim dtrow As DataRow = GRIDBILLITEM.GetDataRow(i)
                dtrow("CHK") = CHKSELECTITEM.Checked
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class