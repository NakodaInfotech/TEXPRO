
Imports BL

Public Class UpdateLotRate

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub TXTLOTNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTLOTNO.KeyPress, TXTLOTNOOP.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTNEWRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTNEWRATE.KeyPress, TXTNEWRATEOP.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTLOTNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTLOTNO.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(GRN_RATE,0) AS RATE", "", "GRN", " AND GRN_NO = " & Val(TXTLOTNO.Text.Trim) & " AND GRN_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTOLDRATE.Text = Val(DT.Rows(0).Item("RATE"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTLOTNOOP_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTLOTNOOP.Validated
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.search("ISNULL(SM_RATE,0) AS RATE", "", "STOCKMASTER", " AND SM_LOTNO = " & Val(TXTLOTNOOP.Text.Trim) & " AND SM_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTOLDRATEOP.Text = Val(DT.Rows(0).Item("RATE"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim BLN As Boolean = True
            If Val(TXTLOTNO.Text.Trim) = 0 Then
                EP.SetError(TXTLOTNO, "Enter Lot No")
                BLN = False
            End If

            If Val(TXTNEWRATE.Text.Trim) = 0 Then
                EP.SetError(TXTNEWRATE, "Enter Rate")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Function ERRORVALIDOP() As Boolean
        Try
            Dim BLN As Boolean = True
            If Val(TXTLOTNOOP.Text.Trim) = 0 Then
                EP.SetError(TXTLOTNOOP, "Enter Lot No")
                BLN = False
            End If

            If Val(TXTNEWRATEOP.Text.Trim) = 0 Then
                EP.SetError(TXTNEWRATEOP, "Enter Rate")
                BLN = False
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMDUPDATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPDATE.Click
        Try
            EP.Clear()
            If Not ERRORVALID Then
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            'UPDATE GRN AND CHECKING ALSO
            Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE GRN SET GRN_RATE = " & Val(TXTNEWRATE.Text.Trim) & " WHERE GRN_NO = " & Val(TXTLOTNO.Text.Trim) & " AND GRN_YEARID = " & YearId, "", "")
            DT = OBJCMN.Execute_Any_String("UPDATE CHECKINGMASTER SET CHECK_RATE = " & Val(TXTNEWRATE.Text.Trim) & " WHERE CHECK_GRNNO = " & Val(TXTLOTNO.Text.Trim) & " AND CHECK_YEARID = " & YearId, "", "")
            DT = OBJCMN.Execute_Any_String("UPDATE MFGMASTER_DESC SET MFG_RATE = " & Val(TXTNEWRATE.Text.Trim) & " WHERE MFG_LOTNO = " & Val(TXTLOTNO.Text.Trim) & " AND MFG_YEARID = " & YearId, "", "")
            MsgBox("Rate Updated")
            CLEAR
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            TXTLOTNO.Clear()
            TXTLOTNOOP.Clear()
            TXTNEWRATE.Clear()
            TXTNEWRATEOP.Clear()
            TXTOLDRATE.Clear()
            TXTOLDRATEOP.Clear()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPDATEOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDUPDATEOP.Click
        Try
            EP.Clear()
            If Not ERRORVALIDOP() Then
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            'UPDATE GRN AND CHECKING ALSO
            Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE STOCKMASTER SET SM_RATE = " & Val(TXTNEWRATEOP.Text.Trim) & " WHERE SM_LOTNO = " & Val(TXTLOTNOOP.Text.Trim) & " AND SM_YEARID = " & YearId, "", "")
            DT = OBJCMN.Execute_Any_String("UPDATE CHECKINGMASTER SET CHECK_RATE = " & Val(TXTNEWRATEOP.Text.Trim) & " WHERE CHECK_LOTNO = " & Val(TXTLOTNOOP.Text.Trim) & " AND CHECK_YEARID = " & YearId, "", "")
            MsgBox("Rate Updated")
            CLEAR()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class