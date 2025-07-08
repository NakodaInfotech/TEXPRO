
Imports DB

Public Class ClsexciseMaster

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
            'save EXCISEMaster
            Dim strCommand As String = "SP_MASTER_EXCISEMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@EXCISE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Edu", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@hse", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@wef", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@EXCISEremarks", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))

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
            'save EXCISEMaster
            Dim strCommand As String = "SP_MASTER_EXCISEMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@EXCISE", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Edu", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@hse", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@wef", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@EXCISEremarks", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(8)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(9)))

                .Add(New SqlClient.SqlParameter("@EXCISEid", alParaval(10)))

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
            Dim strCommand As String = "SP_MASTER_EXCISEMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@EXCISEMasterName", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@yearID", alParaval(3)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region

End Class
