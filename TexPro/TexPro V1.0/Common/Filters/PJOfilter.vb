
Imports BL

Public Class PJOfilter

    Dim fromD
    Dim toD
    Dim a1, a2, a3, a4 As String
    Dim a11, a12, a13, a14 As String

    Private Sub PJOfilter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PJOfilter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            fillcmb()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub fillcmb()
        Try
            If cmbname.Text.Trim = "" Then fillname(cmbname, False, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS'")

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search(" DISTINCT CAST (0 AS BIT) AS CHK, JOBOUT_VIEW.NAME ", " ", " JOBOUT_VIEW ", " AND JOBOUT_VIEW.YEARID = " & YearId & " ORDER BY NAME")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If

            fillitemname(cmbitemname, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            fillQUALITY(cmbQuality, False)
            fillDESIGN(cmbDesign, cmbitemname.Text)
            fillCOLOR(cmbColor)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdshowreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdshowreport.Click

        Dim formula As String

        formula = " {jobout_view.YEARID}= " & YearId

        If cmbname.Text.Trim <> "" Then formula = formula & " and {jobout_view.name}='" & cmbname.Text.Trim & "'"
        If cmbitemname.Text.Trim <> "" Then formula = formula & " and {jobout_view.Itemname}='" & cmbitemname.Text.Trim & "'"
        If Val(TXTJOBNO.Text.Trim) > 0 Then formula = formula & " and {jobout_view.JOBNO}=" & Val(TXTJOBNO.Text.Trim)
        If chkdate.Checked = True Then
            getFromToDate()
            formula = formula & " and {jobout_view.date} in date " & fromD & " to date " & toD & ""
        End If
        Dim objstock As New JODESIGN

        If RDBDETAIL.Checked = True Then objstock.FRMSTRING = "DETAIL"
        If RBSUMMARY.Checked = True Then objstock.FRMSTRING = "SUMMARY"
        If RDBPARTYWISEDETAIL.Checked = True Then objstock.FRMSTRING = "PARTYWISE"
        If RDBITEM.Checked = True Then objstock.FRMSTRING = "ITEM"
        If RBMONTHLY.Checked = True Then objstock.FRMSTRING = "MONTHLY"
        If RDBDETAILSOUTQUALITY.Checked = True Then objstock.FRMSTRING = "DETAILOURQUALITY"
        If RBJOBFINALCUTTING.Checked = True Then objstock.FRMSTRING = "JOBFINALCUTTING"

        'NO DATE FILTER IS APPLIED HERE (DONE BY GULKIT AS TOTAL IS NOT POSSIBLE IN CRYSTAL REPORT)
        Dim OBJCMN As New ClsCommon
        Dim DT As DataTable = OBJCMN.search(" SUM(FINAL.INMTRS) MTRS ,SUM(FINAL.OUTMTRS) OUTMTRS, SUM(FINAL.PENDINGMTRS) PENDINGMTRS, SUM(FINAL.INPCS ) AS PCS, SUM(FINAL.OUTPCS ) AS PCS, SUM(FINAL.PENDINGPSC )  AS PENDINGPCS  ", "", " (SELECT T.JOBNO  , SUM(MTRS) AS INMTRS, SUM(MTRS) AS OUTMTRS ,(SUM(MTRS)- SUM(OUTMTRS)) AS PENDINGMTRS, SUM(T.PCS) AS INPCS, SUM(OUTPCS) AS OUTPCS   , (SUM(PCS)- SUM(OUTPCS)) AS PENDINGPSC FROM (SELECT JOBNO, SUM(MTRS) AS MTRS,0 AS OUTMTRS, 0 AS PENDINGMTRS, SUM(PCS) AS PCS, 0 AS OUTPCS , 0 AS PENDINGPCS, YEARID  FROM JOBOUT_VIEW WHERE MTRS > 0  GROUP BY JOBNO, YEARID  UNION ALL SELECT JOBNO, 0 AS MTRS, SUM(MTRS) * (-1) AS OUTMTRS, 0 AS PENDINGMTRS, 0 AS PCS, SUM(PCS) * (-1) AS OUTPCS, 0 AS PENDINGPCS , YEARID  FROM JOBOUT_VIEW WHERE MTRS < 0  GROUP BY JOBNO, YEARID ) AS T WHERE(T.YEARID = " & YearId & ") GROUP BY T.JOBNO  HAVING (SUM(MTRS)- SUM(OUTMTRS)) > 1 ) AS FINAL  ", " ")
        If DT.Rows.Count > 0 Then
            objstock.TOTALMTRS = DT.Rows(0).Item("PENDINGMTRS")
            objstock.TOTALPCS = DT.Rows(0).Item("PENDINGPCS")
        End If


        'FOR NAME
        Dim NAMECLAUSE As String = ""
        gridbill.ClearColumnsFilter()
        For i As Integer = 0 To gridbill.RowCount - 1
            Dim dtrow As DataRow = gridbill.GetDataRow(i)
            If Convert.ToBoolean(dtrow("CHK")) = True Then
                If NAMECLAUSE = "" Then
                    NAMECLAUSE = " AND ({jobout_view.name} = '" & dtrow("NAME") & "'"
                Else
                    NAMECLAUSE = NAMECLAUSE & " OR {jobout_view.name} = '" & dtrow("NAME") & "'"
                End If
            End If
        Next
        If NAMECLAUSE <> "" Then
            NAMECLAUSE = NAMECLAUSE & ")"
            formula = formula & NAMECLAUSE
        End If

        objstock.MdiParent = MDIMain
        objstock.FORMULA = formula
        objstock.HIDERATE = CHKHIDERATE.Checked

        objstock.Show()
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

End Class