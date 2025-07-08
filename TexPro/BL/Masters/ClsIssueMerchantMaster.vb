
Imports DB

Public Class ClsIssueMerchantMaster

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

#Region "Function"

    Public Function save() As Integer
        Dim intResult As Integer

        Try
            'save TPI Master
            Dim strCommand As String = "SP_MASTER_ISSUEMERCHANT_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@ISSUEMERCHANT", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(6)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function Update() As Integer
        Dim intResult As Integer
        Try
            'update TPIMaster
            Dim strCommand As String = "SP_MASTER_ISSUEMERCHANT_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ISSUEMERCHANT", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@ISSUEMERCHANTID", alParaval(7)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function Delete() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_MASTER_ISSUEMERCHANT_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ISSUEMERCHANTID", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(3)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

End Class
