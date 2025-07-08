
Imports DB

Public Class ClsColorMaster

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

    Public Function SAVE() As Integer
        Dim intResult As Integer

        Try

            'save COLORMaster
            Dim strCommand As String = "SP_MASTER_COLORMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@COLORname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@COLORTYPE", alParaval(7)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer

        Try

            'save COLORMaster
            Dim strCommand As String = "SP_MASTER_COLORMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@COLORname", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@COLORTYPE", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@COLORid", alParaval(8)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function DELETE() As DataTable
        Try
            Dim strCommand As String = "SP_MASTER_COLORMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@COLORNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@yearID", alParaval(2)))
            End With
            Dim DT As DataTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
