
Imports DB

Public Class ClsDesignRecipe

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Dim intResult As Integer

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

    Public Function save() As Integer

        Try

            'save itemdetails
            Dim strCommand As String = "SP_MASTER_DESIGNRECIPE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@colbill1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@colbill2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
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
                'grid parameter
                I = I + 1
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATCHING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCREEN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@per", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalpart", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalcost", alParaval(I)))
                I = I + 1
                'subgrid parameter
                .Add(New SqlClient.SqlParameter("@gridno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@congridno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@part", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@rate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cost", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function update() As Integer

        Dim strcommand As String = ""

        Try

            strcommand = "SP_MASTER_DESIGNRECIPE_UPDATE"

            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DESIGNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IMGPATH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@colbill1", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@colbill2", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
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
                'grid parameter
                I = I + 1
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MATCHING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCREEN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@per", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalpart", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@totalcost", alParaval(I)))
                I = I + 1
                'subgrid parameter
                .Add(New SqlClient.SqlParameter("@gridno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@congridno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@itemname", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@part", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@rate", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cost", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESIGNID", alParaval(I)))

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function DELETE() As DataTable
        Try
            Dim strCommand As String = "SP_MASTER_DESIGNRECIPE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@DESIGNID", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@yearID", alParaval(1)))
            End With
            Dim DT As DataTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function selectdesign(ByVal designno As String, ByVal MERCHANT As String, ByVal Cmpid As Integer, ByVal LocationID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTDESIGN_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@DESIGNno", designno))
                .Add(New SqlClient.SqlParameter("@MERCHANT", MERCHANT))
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
#End Region


End Class
