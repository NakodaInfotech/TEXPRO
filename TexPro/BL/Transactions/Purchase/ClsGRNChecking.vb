
Imports DB

Public Class ClsGRNChecking

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Function SAVE() As Integer
        Dim intResult As Integer
        Try
            'save purchase order
            Dim strCommand As String = "SP_TRANS_PURCHASE_CHECKING_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUPPNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYGROUP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BROKERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENOS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@READYWIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTRACTOR", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALPARTYMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCHECKEDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REJECTEDPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REJECTEDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@returnpcs", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PCSMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCSMTRSWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITYWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKINGCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHORTAGEPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OPSHORTAGE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YARDS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@gridremarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKEDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPROVED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKINGDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HANDCHECKING", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update purchase order
            Dim strCommand As String = "SP_TRANS_PURCHASE_CHECKING_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUPPNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYGROUP", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BROKERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENOS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@READYWIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTRACTOR", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALPARTYMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCHECKEDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REJECTEDPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REJECTEDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@returnpcs", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PCSMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PCSMTRSWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITYWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKINGCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHORTAGEPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OPSHORTAGE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YARDS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKEDMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@APPROVED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKINGDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HANDCHECKING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKINGNO", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectCHECKING(ByVal CHECKINGNO As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTCHECKING_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CHECKINGNO", CHECKINGNO))
                .Add(New SqlClient.SqlParameter("@CmpID", Cmpid))
                .Add(New SqlClient.SqlParameter("@LocationID", LocationID))
                .Add(New SqlClient.SqlParameter("@YearID", YearID))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function Delete() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TRANS_PURCHASE_CHECK_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CHECKINGNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@UserID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(5)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
