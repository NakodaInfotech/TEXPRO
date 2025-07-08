
Imports DB

Public Class ClsPurchaseMaster

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
        Dim dt As DataTable
        Try
            'save ENQUIRY 
            Dim I As Integer = 0
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter


                '.Add(New SqlClient.SqlParameter("@SCREENTYPE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SERVICETYPE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SACCODE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@RCM", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@INVDATE", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@PARTYBILLNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PARTYBILLDATE", alParaval(I)))
                'I = I + 1


                ''.Add(New SqlClient.SqlParameter("@vendorNAME", alParaval(I)))
                ''I = I + 1
                '.Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@REFFNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@VEHICLENO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TRANSFREIGHT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TRANSCITY", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOCITY", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@EWAYBILLNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@BILLDISPUTE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                'I = I + 1



                ''.Add(New SqlClient.SqlParameter("@ADD", alParaval(I)))
                ''I = I + 1

                ''.Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                ''I = I + 1




                '.Add(New SqlClient.SqlParameter("@DISPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@DISAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PFPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PFAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TESTCHGS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@NETT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@EXCISENAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@EXCISEAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@EDUCESSNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@EDUCESSAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@HSECESSNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@HSECESSAMT", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@ADDTAXNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@ADDTAXAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@FRPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@FREIGHT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@OCTROINAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@OCTROIAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@INSCHGS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@EXCISEID", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALDISCAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALSPDISCAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALOTHERAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALTAXABLEAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALCGSTPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALCGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALSGSTPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALSGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALIGSTPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALIGSTAMT", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@INWORDGTOTAL", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@INWORDEXCISE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@INWORDEDU", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@INWORDHSE", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@BILLAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALTAXAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALOTHERCHGSAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@AMTPAID", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                'I = I + 1
                ''.Add(New SqlClient.SqlParameter("@TDS", alParaval(I)))
                ''I = I + 1

                ''.Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                ''I = I + 1
                ''.Add(New SqlClient.SqlParameter("@VEHICLENO", alParaval(I)))
                ''I = I + 1
                ''.Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                ''I = I + 1
                ''.Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                ''I = I + 1
                ''.Add(New SqlClient.SqlParameter("@TRANSFREIGHT", alParaval(I)))
                ''I = I + 1



                ''.Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                ''I = I + 1
                ''.Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                ''I = I + 1
                ''.Add(New SqlClient.SqlParameter("@refno", alParaval(I)))
                ''I = I + 1


                '.Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@FORMNAME", alParaval(I)))
                'I = I + 1


                ''grid parameters
                '.Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                'I = I + 1


                ''.Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                ''I = I + 1
                ''.Add(New SqlClient.SqlParameter("@PICK", alParaval(I)))
                ''I = I + 1

                '.Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@qtyunit", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                'I = I + 1
                ''.Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                ''I = I + 1
                '.Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@amount", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@DISCPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@DISCAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SPCDISCPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SPCDISCAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@OTHERAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TAXABLEAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@CGSTPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@CGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SGSTPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@IGSTPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@IGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@GRIDTOTAL", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@GRNGRIDSRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                'I = I + 1

                ' '' *****CHARGES GRID********
                '.Add(New SqlClient.SqlParameter("@ESRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@ECHARGES", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@EPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@EAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@ETAXID", alParaval(I)))
                'I = I + 1


                .Add(New SqlClient.SqlParameter("@PURNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCREENTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERVICETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SACCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RCM", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PARTYBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYBILLDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICLENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFREIGHT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWAYBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@EXCISEID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSPDISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALOTHERAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTAXABLEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALIGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALIGSTAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INWORDGTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDEXCISE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDEDU", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDHSE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BILLAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALOTHERCHGSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMTPAID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@TDS", alParaval(I)))
                'I = I + 1

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

                .Add(New SqlClient.SqlParameter("@FORMNAME", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
               
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@amount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPCDISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPCDISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXABLEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1

                '' *****CHARGES GRID********
                .Add(New SqlClient.SqlParameter("@ESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ECHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ETAXID", alParaval(I)))
                I = I + 1

            End With

            dt = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dt

    End Function

    Public Function Update() As Integer
        Dim intResult As Integer
        Try
            'Update Enquiry
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                '.Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@RCM", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@vendorNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@ADD", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@INVDATE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@PARTYBILLNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PARTYBILLDATE", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@FORMNAME", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@BILLAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@DISPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@DISAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PFPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PFAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TESTCHGS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@NETT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@EXCISENAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@EXCISEAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@EDUCESSNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@EDUCESSAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@HSECESSNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@HSECESSAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TAXNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TAXAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@ADDTAXNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@ADDTAXAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@FRPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@FREIGHT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@OCTROINAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@OCTROIAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@INSCHGS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@AMTPAID", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TDS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@VEHICLENO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TRANSFREIGHT", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@EXCISEID", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@INWORDGTOTAL", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@INWORDEXCISE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@INWORDEDU", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@INWORDHSE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@refno", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALDISCAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALOTHERAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALTAXABLEAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALCGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALSGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TOTALIGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                'I = I + 1

                ''grid parameters
                '.Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PICK", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@qtyunit", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@amount", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@DISCPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@DISCAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@OTHERAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TAXABLEAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@CGSTPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@CGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SGSTPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@SGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@IGSTPER", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@IGSTAMT", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@GRIDTOTAL", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@GRNGRIDSRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                'I = I + 1

                .Add(New SqlClient.SqlParameter("@PURNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SCREENTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SERVICETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SACCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RCM", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INVDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PARTYBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYBILLDATE", alParaval(I)))
                I = I + 1


                '.Add(New SqlClient.SqlParameter("@vendorNAME", alParaval(I)))
                'I = I + 1
                .Add(New SqlClient.SqlParameter("@AGENT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REFFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CRDAYS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VEHICLENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSFREIGHT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOCITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EWAYBILLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLCHECKED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLDISPUTE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MANUALGST", alParaval(I)))
                I = I + 1



                '.Add(New SqlClient.SqlParameter("@ADD", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@DUEDATE", alParaval(I)))
                'I = I + 1




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
                .Add(New SqlClient.SqlParameter("@EXCISEID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSPDISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALOTHERAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTAXABLEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALCGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALSGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALIGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALIGSTAMT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@INWORDGTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDEXCISE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDEDU", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDHSE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@BILLAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALTAXAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALOTHERCHGSAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROUNDOFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRANDTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMTPAID", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@TDS", alParaval(I)))
                'I = I + 1

                '.Add(New SqlClient.SqlParameter("@TRANSNAME", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@VEHICLENO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@LRNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@LRDATE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@TRANSFREIGHT", alParaval(I)))
                'I = I + 1



                '.Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@refno", alParaval(I)))
                'I = I + 1


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

                .Add(New SqlClient.SqlParameter("@FORMNAME", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
                I = I + 1


                '.Add(New SqlClient.SqlParameter("@REED", alParaval(I)))
                'I = I + 1
                '.Add(New SqlClient.SqlParameter("@PICK", alParaval(I)))
                'I = I + 1

                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qtyunit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
                I = I + 1
                '.Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                'I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@amount", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPCDISCPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SPCDISCAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TAXABLEAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSTAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRNGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1

                '' *****CHARGES GRID********
                .Add(New SqlClient.SqlParameter("@ESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ECHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ETAXID", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectpurchase() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPURCHASE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(4)))
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

            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@BILLNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(4)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult
    End Function

    Public Function COPY() As Integer
        Dim intResult As Integer
        Try
            'save purchase Requisition
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASEMASTER_COPY"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CPINVOICE_NO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@LOATIONID", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(4)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

#End Region

End Class
