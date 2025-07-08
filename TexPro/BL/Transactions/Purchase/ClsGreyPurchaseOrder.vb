
Imports DB

Public Class ClsGreyPurchaseOrder


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
        Try
            'save purchase order
            Dim strCommand As String = "SP_TRANS_PURCHASE_GREYPURCHASEORDER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PURCHASEORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@podate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@refNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@quotno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@quotdt", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@discount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalqty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalamt", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DISPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PFPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PFAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TESTCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NETT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCISEID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCISENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCISEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EDUCESSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EDUCESSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSECESSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSECESSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FRPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FREIGHT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OCTROINAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OCTROIAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INSCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@PODONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VERIFIED", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@rate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@amount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@recdqty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNdone", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSED", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BROKER", alParaval(I)))
                I = I + 1

            End With

            Dim DT As DataTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update purchase order
            Dim strCommand As String = "SP_TRANS_PURCHASE_GREYPURCHASEORDER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PURCHASEORDERNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@podate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@refNO", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@quotno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@quotdt", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@discount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalqty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalamt", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@DISPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PFPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PFAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TESTCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NETT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCISEID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCISENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXCISEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EDUCESSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EDUCESSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSECESSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSECESSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDTAXNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ADDTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FRPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FREIGHT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OCTROINAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OCTROIAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INSCHGS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PODONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VERIFIED", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@rate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@amount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@recdqty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNdone", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSED", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INWORDS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BROKER", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTPO(ByVal pono As Integer, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTGREYPO_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@pono", pono))
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

    Public Function DELETE() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TRANS_PURCHASE_GREYPURCHASEORDER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@pono", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
