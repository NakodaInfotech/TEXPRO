
Imports BL

Public Class UpdateJobMerchant

    Private Sub cmdcancel_Click(sender As Object, e As EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub UpdateJobMerchant_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If CMBITEMNAME.Text.Trim = "" Then fillitemname(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBQUALITYRATE.Text.Trim = "" Then fillitemname(CMBQUALITYRATE, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            CLEAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            CMBTYPE.SelectedIndex = 0
            TXTENTRYNO.Clear()
            TXTOLDITEMNAME.Clear()
            CMBITEMNAME.Text = ""
            CMBQUALITYRATE.Text = ""
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTENTRYNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTENTRYNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTENTRYNO_Validated(sender As Object, e As EventArgs) Handles TXTENTRYNO.Validated
        Try
            If Val(TXTENTRYNO.Text.Trim) > 0 Then
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                If CMBTYPE.Text = "CUTTING" Then
                    DT = OBJCMN.search("ISNULL(ITEM_NAME,'') AS ITEMNAME", "", "CUTTINGPROCESS INNER JOIN ITEMMASTER ON CP_MERCHANTID = ITEM_ID ", " AND CP_NO = " & Val(TXTENTRYNO.Text.Trim) & " AND CP_YEARID = " & YearId)
                ElseIf CMBTYPE.Text = "MFG" Then
                    DT = OBJCMN.search("ISNULL(ITEM_NAME,'') AS ITEMNAME", "", "MFGMASTER2 INNER JOIN ITEMMASTER ON MFG_MERCHANTID = ITEM_ID ", " AND MFG_NO = " & Val(TXTENTRYNO.Text.Trim) & " AND MFG_YEARID = " & YearId)
                ElseIf CMBTYPE.Text = "FINALPACKING" Then
                    DT = OBJCMN.search("ISNULL(ITEM_NAME,'') AS ITEMNAME", "", "FINALPACKINGSLIP INNER JOIN ITEMMASTER ON FPS_MERCHANTID = ITEM_ID ", " AND FPS_NO = " & Val(TXTENTRYNO.Text.Trim) & " AND FPS_YEARID = " & YearId)
                End If
                If DT.Rows.Count > 0 Then TXTOLDITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPDATE_Click(sender As Object, e As EventArgs) Handles CMDUPDATE.Click
        Try
            If CMBITEMNAME.Text.Trim <> "" And (Val(TXTENTRYNO.Text.Trim) > 0 Or Val(TXTLOTNO.Text.Trim) > 0) And CMBTYPE.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable

                If CMBTYPE.Text = "CUTTING" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE CUTTINGPROCESS SET CP_MERCHANTID = (SELECT ITEM_ID FROM ITEMMASTER WHERE ITEM_YEARID = " & YearId & " AND ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "') WHERE CP_NO = " & Val(TXTENTRYNO.Text.Trim) & " AND CP_YEARID = " & YearId, "", "")
                ElseIf CMBTYPE.Text = "MFG" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE MFGMASTER2 SET MFG_MERCHANTID = (SELECT ITEM_ID FROM ITEMMASTER WHERE ITEM_YEARID = " & YearId & " AND ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "') WHERE MFG_NO = " & Val(TXTENTRYNO.Text.Trim) & " AND MFG_YEARID = " & YearId, "", "")
                ElseIf CMBTYPE.Text = "FINALPACKING" Then
                    If ClientName <> "DHANLAXMI" And ClientName <> "SHUBHLAXMI" Then
                        DT = OBJCMN.Execute_Any_String(" UPDATE FINALPACKINGSLIP SET FPS_MERCHANTID = (SELECT ITEM_ID FROM ITEMMASTER WHERE ITEM_YEARID = " & YearId & " AND ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "') WHERE FPS_NO = " & Val(TXTENTRYNO.Text.Trim) & " AND FPS_YEARID = " & YearId, "", "")
                    Else
                        DT = OBJCMN.Execute_Any_String(" UPDATE FINALPACKINGSLIP SET FPS_MERCHANTID = (SELECT ITEM_ID FROM ITEMMASTER WHERE ITEM_YEARID = " & YearId & " AND ITEM_NAME = '" & CMBQUALITYRATE.Text.Trim & "') WHERE FPS_NO = " & Val(TXTENTRYNO.Text.Trim) & " AND FPS_YEARID = " & YearId, "", "")
                    End If
                    DT = OBJCMN.Execute_Any_String(" UPDATE FINALPACKINGSLIP_DESC SET FPS_ITEMID = (SELECT ITEM_ID FROM ITEMMASTER WHERE ITEM_YEARID = " & YearId & " AND ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "') WHERE FPS_NO = " & Val(TXTENTRYNO.Text.Trim) & " AND FPS_YEARID = " & YearId, "", "")
                ElseIf CMBTYPE.Text.Trim = "GRN AND PACKING" Then
                    DT = OBJCMN.Execute_Any_String(" UPDATE GRN SET GRN_MERCHANTID = (SELECT ITEM_ID FROM ITEMMASTER WHERE ITEM_YEARID = " & YearId & " AND ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "') WHERE GRN_NO = " & Val(TXTLOTNO.Text.Trim) & " AND GRN_YEARID = " & YearId, "", "")
                    DT = OBJCMN.Execute_Any_String(" UPDATE FINALPACKINGSLIP SET FINALPACKINGSLIP.FPS_MERCHANTID = (SELECT ITEM_ID FROM ITEMMASTER WHERE ITEM_YEARID = " & YearId & " AND ITEM_NAME = '" & CMBITEMNAME.Text.Trim & "') FROM FINALPACKINGSLIP INNER JOIN FINALPACKINGSLIP_DESC ON FINALPACKINGSLIP.FPS_NO = FINALPACKINGSLIP_DESC.FPS_NO   AND FINALPACKINGSLIP.FPS_YEARID = FINALPACKINGSLIP_DESC.FPS_YEARID WHERE FINALPACKINGSLIP_DESC.FPS_LOTNO = " & Val(TXTLOTNO.Text.Trim) & " AND FINALPACKINGSLIP.FPS_YEARID = " & YearId, "", "")
                End If
                MsgBox("Entry Updated")
                CLEAR()
                CMBTYPE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UpdateJobMerchant_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                LBLNEWQUALITYRATE.Visible = True
                CMBQUALITYRATE.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTLOTNO_Validated(sender As Object, e As EventArgs) Handles TXTLOTNO.Validated
        Try
            If Val(TXTLOTNO.Text.Trim) > 0 And CMBTYPE.Text = "GRN AND PACKING" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search(" ISNULL(ITEM_NAME,'') AS ITEMNAME ", "", " GRN INNER JOIN ITEMMASTER ON GRN_MERCHANTID = ITEM_ID ", " AND GRN_TYPE = 'G.R.N' AND GRN_NO = " & Val(TXTLOTNO.Text.Trim) & " AND GRN_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then TXTOLDITEMNAME.Text = DT.Rows(0).Item("ITEMNAME")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class