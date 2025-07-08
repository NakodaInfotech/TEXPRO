
Imports DB

Public Class ClsGrn

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
        Dim DTTABLE As DataTable
        Try
            'save purchase order
            Dim strCommand As String = "SP_TRANS_PURCHASE_GRN_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BROKER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SENDER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GREYWIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@Challanno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@pono", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@podate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrdate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transrefno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transremarks", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ADJUSTMENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENOS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@READYWIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINISH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MERCHANTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SAMPLES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKINGREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYMERCHANTNO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@gridremarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LABTEST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POgridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKEDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURNQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDUPLOADSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILENAME", alParaval(I)))
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



                'POGRID
                .Add(New SqlClient.SqlParameter("@ORDERGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERGRNPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERGRNMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERRATE", alParaval(I)))
                I = I + 1

            End With

            DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DTTABLE

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update purchase order
            Dim strCommand As String = "SP_TRANS_PURCHASE_GRN_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WEAVER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BROKER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SENDER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GREYWIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@Challanno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWBNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@pono", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@podate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@lrdate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transrefno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transremarks", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBALES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@ADJUSTMENT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALENOS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@READYWIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINISH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MERCHANTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SAMPLES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKINGREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYMERCHANTNO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@gridremarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PICK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LABTEST", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POgridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKEDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURNQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDUPLOADSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADREMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UPLOADNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NEWIMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FILENAME", alParaval(I)))
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

                'POGRID
                .Add(New SqlClient.SqlParameter("@ORDERGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERFROMTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERGRNPCS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERGRNMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERRATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectGRN(ByVal GRNno As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer, ByVal CMBTYPE As String) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTGRN_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@GRNno", GRNno))
                .Add(New SqlClient.SqlParameter("@TYPE", CMBTYPE))
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
            Dim strCommand As String = "SP_TRANS_PURCHASE_GRN_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@GRNno", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@LocationID", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(5)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
