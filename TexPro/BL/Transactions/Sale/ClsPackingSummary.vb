Imports DB
Public Class ClsPackingSummary
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

    Public Function SAVE() As DataTable
        Dim DT As DataTable
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_SALE_PACKINGSUMMARY_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SUMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LONGATION", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@FOLD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWFOLD", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SAMPLEMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHORTPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REJPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FENTMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHORTMTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REJMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GOODCUTMTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@RACKSMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LESSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LESSMTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@READYWIDTH", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLLOTTOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLLOTTOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLLOTTOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLBALETOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLBALETOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLBALETOTALCONVMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLINVTOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLINVTOTALMTRS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TOTALBDECMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBGRAMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AVGDECMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AVGWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AVGGRAMS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1




                'grid LOT
                .Add(New SqlClient.SqlParameter("@LOTSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTRECDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTWT", alParaval(I)))
                I = I + 1


                'grid BALE 

                .Add(New SqlClient.SqlParameter("@BALESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALEPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALEMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALECONVMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALEFROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALEFROMTYPE", alParaval(I)))
                I = I + 1


                'grid INVOICE 
                .Add(New SqlClient.SqlParameter("@INVSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTTINGCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARTONCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FELT", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@BLEACHSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLEACHMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLEACHWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLEACHREEDPICK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLEACHWIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLEACHFOLD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLEACHGRAMS", alParaval(I)))
                I = I + 1


            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update SALE order
            Dim strCommand As String = "SP_TRANS_SALE_PACKINGSUMMARY_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter


                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SUMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LONGATION", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@FOLD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWFOLD", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@SAMPLEMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHORTPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REJPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FENTMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHORTMTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REJMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GOODCUTMTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@RACKSMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LESSPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LESSMTRS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@READYWIDTH", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLLOTTOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLLOTTOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLLOTTOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLBALETOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLBALETOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLBALETOTALCONVMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLINVTOTALPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LBLINVTOTALMTRS", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TOTALBDECMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBGRAMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AVGDECMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AVGWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AVGGRAMS", alParaval(I)))
                I = I + 1



                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1




                'grid LOT
                .Add(New SqlClient.SqlParameter("@LOTSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTRECDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTWT", alParaval(I)))
                I = I + 1


                'grid BALE 

                .Add(New SqlClient.SqlParameter("@BALESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALEPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALEMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALECONVMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALEFROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALEFROMTYPE", alParaval(I)))
                I = I + 1


                'grid INVOICE 
                .Add(New SqlClient.SqlParameter("@INVSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUTTINGCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CARTONCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FELT", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@BLEACHSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLEACHMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLEACHWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLEACHREEDPICK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLEACHWIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLEACHFOLD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BLEACHGRAMS", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPPACKNO", alParaval(I)))
                I = I + 1

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectPACK(ByVal TEMPPACKNO As Integer, ByVal Cmpid As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPS_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("TEMPPACKNO", TEMPPACKNO))
                .Add(New SqlClient.SqlParameter("@CmpID", Cmpid))
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
            Dim strCommand As String = "SP_TRANS_SALE_PACKINGSUMMARY_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@TEMPPACKNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("Userid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(4)))


            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


End Class


