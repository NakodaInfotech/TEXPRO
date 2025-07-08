Imports DB
Public Class ClsMachineMaster
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

            'save machinemaster
            Dim strCommand As String = "SP_MASTER_machineMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@MACHINENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUPPNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROCESSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANPERMAC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LABPERMAC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COSTPERHR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CAPPERHR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POWERPERHR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AVG", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
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

            'save Taxmaster
            Dim strCommand As String = "SP_MASTER_MACHINEMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@MACHINENAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUPPNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROCESSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANPERMAC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LABPERMAC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COSTPERHR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CAPPERHR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@POWERPERHR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AVG", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@MACHINEID", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function DELETE() As DataTable
        Dim dtTable As New DataTable
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_MACHINEMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@MACHINENO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@MACHINENAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(3)))
            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

#End Region

End Class
