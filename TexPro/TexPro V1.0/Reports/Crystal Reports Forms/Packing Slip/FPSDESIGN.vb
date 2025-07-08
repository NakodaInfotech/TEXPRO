
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports BL
Imports System.IO

Public Class FPSDESIGN


    Public fspno As Integer
    Public goodcut As Boolean = False
    Public BALEFILTER As String = "FPS"
    Public FRMSTRING As String = ""
    Public SELFORMULA As String
    Public PERIOD As String
    Public VENDORNAME As String = ""

    Dim RPTFPS As New Fpsreport_RND
    Dim RPTFPS_MONOGRAM As New FINALPACKINGSLIP_MONOGRAM
    Dim RPTFPS_DHANLAXMI As New FINALPACKINGSLIP_DHANLAXMI


    Dim RPTPSDETAIL As New JOBPACKINGDETAILREPORT
    Dim RPTPSMERCHANT As New JOBPACKINGMERCHANTREPORT
    Dim RPTPSPARTYDTLS As New JOBPACKINGPARTYREPORT
    Dim RPTPSPARTYMERCHANTSUMM As New JOBPACKINGPARTYMERCHANTREPORT


    Dim RPTBALESTOCK As New BALESTOCK_NORMAL
    Dim RPTBALESTOCKLOT As New BALESTOCK_NORMALLOT
    Dim RPTBALEREGISTER As New BALEREGISTER
    Dim RPTBALESTOCKVALUE As New BALESTOCK_NORMALVALUE

    Dim RPTBALESTOCK_CUT As New BALESTOCK_CUTWISE
    Dim RPTBALESTOCK_MERCHANT As New BALESTOCK_MERCHANTWISE
    Dim RPTBALESTOCK_MERCHANTNOTOTAL As New BALESTOCK_MERCHANTWISEWITHOUTTOTAL
    Dim RPTBALESTOCK_MERCHANT_DETAIL As New BALESTOCK_MERCHANTWISEDETAIL
    Dim RPTBALESTOCK_DESIGN_DETAIL As New BALESTOCK_DESIGNWISE
    Dim RPTBALESTOCK_JOB_DETAIL As New BALESTOCK_JOBWISE
    Dim RPTBALESTOCK_JOB_SUMMARY As New BALESTOCK_JOBWISESUMMARY
    Dim RPTBALESTOCK_DEPT As New BALESTOCK_DEPARTMENTWISE
    Dim RPTBALESTOCK_DEPTSUMM As New BALESTOCK_DEPARTMENTWISESUMM
    Dim RPTBALESTOCK_CATEGORYNOTOTAL As New BALESTOCK_CATEGORYWISEWITHOUTTOTAL
    Dim RPTBALESTOCK_DEPARTMENTNOTOTAL As New BALESTOCK_DEPARTMENTWISEWITHOUTTOTAL
    Dim RPTBALESTOCK_GRADENOTOTAL As New BALESTOCK_GRADEWISEWITHOUTTOTAL

    Dim RPTFPSDTLS As New FPSDetailReport
    Dim RPTFPSITEMDTLS As New FPSItemDetailReport
    Dim RPTFPSITEMSUMM As New FPSItemSummReport
    Dim RPTFPSPROCESSTYPE As New FPSProcessTypeReport
    Dim RPTFPSLOTSUMM As New FPSLotDetailReport
    Dim RPTFPSCATEGORY As New FPSCategoryReport
    Dim RPTFPSDEPARTMENT As New FPSDepartmentReport
    Dim RPTFPSPIECETYPE As New FPSPiecetypeReport


    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions
    Public JOBNO As String = ""

    Public HEADER As Boolean
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public NOOFCOPIES As Integer = 1
    Public PRINTSETTING As Object = Nothing

    Private Sub fspdesign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GRNCheckingDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If DIRECTPRINT = True Then
                PRINTDIRECTLYTOPRINTER()
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "FPS" Then

                If ClientName = "MONOGRAM" Then
                    crTables = RPTFPS_MONOGRAM.Database.Tables
                ElseIf ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                    crTables = RPTFPS_DHANLAXMI.Database.Tables
                Else
                    crTables = RPTFPS.Database.Tables
                End If



            ElseIf FRMSTRING = "FULLDETAILS" Then
                crTables = RPTBALESTOCK.Database.Tables
            ElseIf FRMSTRING = "LOTBALESTOCK" Then
                crTables = RPTBALESTOCKLOT.Database.Tables
            ElseIf FRMSTRING = "BALEREGISTER" Then
                crTables = RPTBALEREGISTER.Database.Tables
            ElseIf FRMSTRING = "FULLDETAILSVALUE" Then
                crTables = RPTBALESTOCKVALUE.Database.Tables
            ElseIf FRMSTRING = "CUTWISE" Then
                crTables = RPTBALESTOCK_CUT.Database.Tables
            ElseIf FRMSTRING = "MERCHANTWISE" Then
                crTables = RPTBALESTOCK_MERCHANT.Database.Tables
            ElseIf FRMSTRING = "MERCHANTWISENOTOTAL" Then
                crTables = RPTBALESTOCK_MERCHANTNOTOTAL.Database.Tables
            ElseIf FRMSTRING = "MERCHANTWISEDETAIL" Then
                crTables = RPTBALESTOCK_MERCHANT_DETAIL.Database.Tables
            ElseIf FRMSTRING = "DESIGNWISEDETAIL" Then
                crTables = RPTBALESTOCK_DESIGN_DETAIL.Database.Tables
            ElseIf FRMSTRING = "DEPTWISEDETAIL" Then
                crTables = RPTBALESTOCK_DEPT.Database.Tables
            ElseIf FRMSTRING = "DEPTWISESUMM" Then
                crTables = RPTBALESTOCK_DEPTSUMM.Database.Tables

            ElseIf FRMSTRING = "CATEGORYWISENOTOTAL" Then
                crTables = RPTBALESTOCK_CATEGORYNOTOTAL.Database.Tables
            ElseIf FRMSTRING = "DEPARTMENTWISENOTOTAL" Then
                crTables = RPTBALESTOCK_DEPARTMENTNOTOTAL.Database.Tables
            ElseIf FRMSTRING = "GRADEWISENOTOTAL" Then
                crTables = RPTBALESTOCK_GRADENOTOTAL.Database.Tables

            ElseIf FRMSTRING = "JOBWISE" Then
                crTables = RPTBALESTOCK_JOB_DETAIL.Database.Tables
            ElseIf FRMSTRING = "JOBSUMM" Then
                crTables = RPTBALESTOCK_JOB_SUMMARY.Database.Tables
            ElseIf FRMSTRING = "RATEREPORT" Then
                crTables = RPTBALESTOCK.Database.Tables

            ElseIf FRMSTRING = "FPSDTLS" Then
                crTables = RPTFPSDTLS.Database.Tables
            ElseIf FRMSTRING = "FPSITEMDTLS" Then
                crTables = RPTFPSITEMDTLS.Database.Tables
            ElseIf FRMSTRING = "FPSITEMSUMM" Then
                crTables = RPTFPSITEMSUMM.Database.Tables
            ElseIf FRMSTRING = "FPSPROCESSTYPE" Then
                crTables = RPTFPSPROCESSTYPE.Database.Tables
            ElseIf FRMSTRING = "FPSLOTSUMM" Then
                crTables = RPTFPSLOTSUMM.Database.Tables
            ElseIf FRMSTRING = "FPSCATEGORY" Then
                crTables = RPTFPSCATEGORY.Database.Tables
            ElseIf FRMSTRING = "FPSDEPARTMENT" Then
                crTables = RPTFPSDEPARTMENT.Database.Tables
            ElseIf FRMSTRING = "FPSPIECETYPE" Then
                crTables = RPTFPSPIECETYPE.Database.Tables


            ElseIf FRMSTRING = "PSDTLS" Then
                crTables = RPTPSDETAIL.Database.Tables
            ElseIf FRMSTRING = "PSMERCHANT" Then
                crTables = RPTPSMERCHANT.Database.Tables
            ElseIf FRMSTRING = "PSPARTYDTLS" Then
                crTables = RPTPSPARTYDTLS.Database.Tables
            ElseIf FRMSTRING = "PSPARTYMERCHANTSUMM" Then
                crTables = RPTPSPARTYMERCHANTSUMM.Database.Tables
            End If


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = SELFORMULA
            If FRMSTRING = "FULLDETAILS" Then
                RPTBALESTOCK.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTBALESTOCK
            ElseIf FRMSTRING = "LOTBALESTOCK" Then
                RPTBALESTOCKLOT.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTBALESTOCKLOT
            ElseIf FRMSTRING = "BALEREGISTER" Then
                RPTBALEREGISTER.DataDefinition.FormulaFields("TITLE").Text = "'SERIAL BALE REGISTER'"
                RPTBALEREGISTER.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTBALEREGISTER
            ElseIf FRMSTRING = "FULLDETAILSVALUE" Then
                RPTBALESTOCKVALUE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTBALESTOCKVALUE
            ElseIf FRMSTRING = "CUTWISE" Then
                RPTBALESTOCK_CUT.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTBALESTOCK_CUT
            ElseIf FRMSTRING = "MERCHANTWISE" Then
                RPTBALESTOCK_MERCHANT.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTBALESTOCK_MERCHANT
            ElseIf FRMSTRING = "MERCHANTWISENOTOTAL" Then
                RPTBALESTOCK_MERCHANTNOTOTAL.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTBALESTOCK_MERCHANTNOTOTAL
            ElseIf FRMSTRING = "MERCHANTWISEDETAIL" Then
                RPTBALESTOCK_MERCHANT_DETAIL.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTBALESTOCK_MERCHANT_DETAIL
            ElseIf FRMSTRING = "DESIGNWISEDETAIL" Then
                RPTBALESTOCK_DESIGN_DETAIL.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTBALESTOCK_DESIGN_DETAIL
            ElseIf FRMSTRING = "DEPTWISEDETAIL" Then
                RPTBALESTOCK_DEPT.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTBALESTOCK_DEPT
            ElseIf FRMSTRING = "DEPTWISESUMM" Then
                RPTBALESTOCK_DEPTSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTBALESTOCK_DEPTSUMM


            ElseIf FRMSTRING = "CATEGORYWISENOTOTAL" Then
                RPTBALESTOCK_CATEGORYNOTOTAL.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTBALESTOCK_CATEGORYNOTOTAL.DataDefinition.FormulaFields("TITLE").Text = "'CATEGORY WISE BALE REGISTER'"
                crpo.ReportSource = RPTBALESTOCK_CATEGORYNOTOTAL
            ElseIf FRMSTRING = "DEPARTMENTWISENOTOTAL" Then
                RPTBALESTOCK_DEPARTMENTNOTOTAL.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTBALESTOCK_DEPARTMENTNOTOTAL.DataDefinition.FormulaFields("TITLE").Text = "'DEPARTMENT WISE BALE REGISTER'"
                crpo.ReportSource = RPTBALESTOCK_DEPARTMENTNOTOTAL
            ElseIf FRMSTRING = "GRADEWISENOTOTAL" Then
                RPTBALESTOCK_GRADENOTOTAL.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                RPTBALESTOCK_GRADENOTOTAL.DataDefinition.FormulaFields("TITLE").Text = "'GRADE WISE BALE REGISTER'"
                crpo.ReportSource = RPTBALESTOCK_GRADENOTOTAL


            ElseIf FRMSTRING = "JOBWISE" Then
                RPTBALESTOCK_JOB_DETAIL.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTBALESTOCK_JOB_DETAIL
            ElseIf FRMSTRING = "JOBSUMM" Then
                RPTBALESTOCK_JOB_SUMMARY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTBALESTOCK_JOB_SUMMARY
            ElseIf FRMSTRING = "RATEREPORT" Then
                RPTBALESTOCK.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTBALESTOCK
            ElseIf FRMSTRING = "FPSDTLS" Then
                RPTFPSDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTFPSDTLS
            ElseIf FRMSTRING = "FPSITEMDTLS" Then
                RPTFPSITEMDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTFPSITEMDTLS
            ElseIf FRMSTRING = "FPSITEMSUMM" Then
                RPTFPSITEMSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTFPSITEMSUMM
            ElseIf FRMSTRING = "FPSPROCESSTYPE" Then
                RPTFPSPROCESSTYPE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTFPSPROCESSTYPE
            ElseIf FRMSTRING = "FPSLOTSUMM" Then
                RPTFPSLOTSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTFPSLOTSUMM
            ElseIf FRMSTRING = "FPSCATEGORY" Then
                RPTFPSCATEGORY.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTFPSCATEGORY
            ElseIf FRMSTRING = "FPSDEPARTMENT" Then
                RPTFPSDEPARTMENT.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTFPSDEPARTMENT
            ElseIf FRMSTRING = "FPSPIECETYPE" Then
                RPTFPSPIECETYPE.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTFPSPIECETYPE
            ElseIf FRMSTRING = "FPS" Then

                If ClientName = "MONOGRAM" Then
                    'GET MULTIPLELOTNOS
                    Dim TEMPLOTNO As String = ""
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("DISTINCT FINALPACKINGSLIP_DESC.FPS_LOTNO AS LOTNO", "", " FINALPACKINGSLIP_DESC", " AND FPS_NO = " & fspno & " AND FPS_YEARID = " & YearId)
                    For Each DTROW As DataRow In DT.Rows
                        If TEMPLOTNO = "" Then TEMPLOTNO = DTROW("LOTNO") Else TEMPLOTNO = TEMPLOTNO & "," & DTROW("LOTNO")
                    Next

                    If HEADER = False Then RPTFPS_MONOGRAM.DataDefinition.FormulaFields("HIDEHEADER").Text = 1 Else RPTFPS_MONOGRAM.DataDefinition.FormulaFields("HIDEHEADER").Text = 0
                    RPTFPS_MONOGRAM.DataDefinition.FormulaFields("MULTILOTNO").Text = "'" & TEMPLOTNO & "'"
                    crpo.ReportSource = RPTFPS_MONOGRAM

                ElseIf ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                    'GET MULTIPLELOTNOS
                    Dim TEMPLOTNO As String = ""
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.search("DISTINCT FINALPACKINGSLIP_DESC.FPS_LOTNO AS LOTNO", "", " FINALPACKINGSLIP_DESC", " AND FPS_NO = " & fspno & " AND FPS_YEARID = " & YearId)
                    For Each DTROW As DataRow In DT.Rows
                        If TEMPLOTNO = "" Then TEMPLOTNO = DTROW("LOTNO") Else TEMPLOTNO = TEMPLOTNO & "," & DTROW("LOTNO")
                    Next

                    If HEADER = False Then RPTFPS_DHANLAXMI.DataDefinition.FormulaFields("HIDEHEADER").Text = 1 Else RPTFPS_DHANLAXMI.DataDefinition.FormulaFields("HIDEHEADER").Text = 0
                    RPTFPS_DHANLAXMI.DataDefinition.FormulaFields("MULTILOTNO").Text = "'" & TEMPLOTNO & "'"
                    crpo.ReportSource = RPTFPS_DHANLAXMI
                Else
                    If goodcut = True Then
                        RPTFPS.GroupHeaderSection7.SectionFormat.EnableSuppress = True
                        RPTFPS.GroupHeaderSection10.SectionFormat.EnableSuppress = False
                        RPTFPS.GroupHeaderSection8.SectionFormat.EnableSuppress = True
                        RPTFPS.GroupHeaderSection9.SectionFormat.EnableSuppress = False
                        RPTFPS.GroupFooterSection3.SectionFormat.EnableSuppress = True
                        RPTFPS.GroupFooterSection7.SectionFormat.EnableSuppress = False
                    End If
                    If HEADER = False Then RPTFPS.DataDefinition.FormulaFields("HIDEHEADER").Text = 1 Else RPTFPS.DataDefinition.FormulaFields("HIDEHEADER").Text = 0
                    RPTFPS.DataDefinition.FormulaFields("JOBNO").Text = "'" & JOBNO & "'"
                    crpo.ReportSource = RPTFPS
                End If

            ElseIf FRMSTRING = "PSDTLS" Then
                RPTPSDETAIL.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTPSDETAIL
            ElseIf FRMSTRING = "PSMERCHANT" Then
                RPTPSMERCHANT.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTPSMERCHANT
            ElseIf FRMSTRING = "PSPARTYDTLS" Then
                RPTPSPARTYDTLS.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTPSPARTYDTLS
            ElseIf FRMSTRING = "PSPARTYMERCHANTSUMM" Then
                RPTPSPARTYMERCHANTSUMM.DataDefinition.FormulaFields("PERIOD").Text = "'" & PERIOD & "'"
                crpo.ReportSource = RPTPSPARTYMERCHANTSUMM
            End If

            crpo.Zoom(100)
            crpo.Refresh()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTDIRECTLYTOPRINTER()
        Try
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            strsearch = " {finalpackingslip.fps_NO}=" & fspno & " and {finalpackingslip.fps_yearid}=" & YearId

            Dim OBJ As New Object
            If FRMSTRING = "FPS" Then

                'GET MULTIPLELOTNOS
                Dim TEMPLOTNO As String = ""
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.search("DISTINCT FINALPACKINGSLIP_DESC.FPS_LOTNO AS LOTNO", "", " FINALPACKINGSLIP_DESC", " AND FPS_NO = " & fspno & " AND FPS_YEARID = " & YearId)
                For Each DTROW As DataRow In DT.Rows
                    If TEMPLOTNO = "" Then TEMPLOTNO = DTROW("LOTNO") Else TEMPLOTNO = TEMPLOTNO & "," & DTROW("LOTNO")
                Next



                If ClientName = "MONOGRAM" Then
                    OBJ = New FINALPACKINGSLIP_MONOGRAM
                    If HEADER = False Then OBJ.DataDefinition.FormulaFields("HIDEHEADER").Text = 1 Else OBJ.DataDefinition.FormulaFields("HIDEHEADER").Text = 0
                    OBJ.DataDefinition.FormulaFields("MULTILOTNO").Text = "'" & TEMPLOTNO & "'"
                ElseIf ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then
                    OBJ = New FINALPACKINGSLIP_DHANLAXMI
                    If HEADER = False Then OBJ.DataDefinition.FormulaFields("HIDEHEADER").Text = 1 Else OBJ.DataDefinition.FormulaFields("HIDEHEADER").Text = 0
                    OBJ.DataDefinition.FormulaFields("MULTILOTNO").Text = "'" & TEMPLOTNO & "'"
                Else
                    OBJ = New fpsreport
                End If
            End If

SKIPINVOICE:
            crTables = OBJ.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJ.RecordSelectionFormula = strsearch

            If DIRECTMAIL = False Then
                'Dim PAPERSIZE As New Printing.PaperSize
                'PAPERSIZE = New Drawing.Printing.PaperSize
                'PAPERSIZE.RawKind = Printing.PaperKind.Custom
                'PAPERSIZE.Width = 900
                'PAPERSIZE.Height = 600
                'PAPERSIZE.PaperName = "Letter"

                OBJ.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
                'OBJ.PrintOptions.PAPERSIZE = PRINTSETTING.PrinterSettings.pAPERSIZE =
                OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
            Else
                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions
                oDfDopt.DiskFileName = Application.StartupPath & "\FPS_" & fspno & ".pdf"

                'CHECK WHETHER FILE IS PRESENT OR NOT, IF PRESENT THEN DELETE FIRST AND THEN EXPORT
                If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)
                expo = OBJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            tempattachment = "Bale Details" & fspno
            Dim objmail As New SendMail
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".pdf"
            objmail.subject = "Bale Details Report"

            If vendorname <> "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable = objclscommon.search(" acc_email ", "", " LEDGERS ", " and ACC_cmpname='" & vendorname & "' and ACC_cmpid=" & CmpId & " and ACC_LOCATIONid=" & Locationid & " and ACC_YEARid=" & YearId)
                If dt.Rows.Count > 0 Then
                    emailid = dt.Rows(0).Item(0).ToString
                End If
            End If

            If emailid <> "" Then
                objmail.cmbfirstadd.Text = emailid
            End If
            objmail.Show()
            objmail.BringToFront()
            Windows.Forms.Cursor.Current = Cursors.Arrow
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub Transfer()
        Try
            oDfDopt.DiskFileName = Application.StartupPath & "\Bale Details" & fspno & ".pdf"

            If FRMSTRING = "FULLDETAILS" Then
                expo = RPTBALESTOCK.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK.Export()
            ElseIf FRMSTRING = "LOTBALESTOCK" Then
                expo = RPTBALESTOCKLOT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCKLOT.Export()
            ElseIf FRMSTRING = "BALEREGISTER" Then
                expo = RPTBALEREGISTER.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK.Export()
            ElseIf FRMSTRING = "FULLDETAILSVALUE" Then
                expo = RPTBALESTOCKVALUE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCKVALUE.Export()
            ElseIf FRMSTRING = "CUTWISE" Then
                expo = RPTBALESTOCK_CUT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK_CUT.Export()
            ElseIf FRMSTRING = "MERCHANTWISE" Then
                expo = RPTBALESTOCK_MERCHANT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK_MERCHANT.Export()
            ElseIf FRMSTRING = "MERCHANTWISENOTOTAL" Then
                expo = RPTBALESTOCK_MERCHANTNOTOTAL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK_MERCHANTNOTOTAL.Export()
            ElseIf FRMSTRING = "MERCHANTWISEDETAIL" Then
                expo = RPTBALESTOCK_MERCHANT_DETAIL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK_MERCHANT_DETAIL.Export()
            ElseIf FRMSTRING = "DESIGNWISEDETAIL" Then
                expo = RPTBALESTOCK_DESIGN_DETAIL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK_DESIGN_DETAIL.Export()
            ElseIf FRMSTRING = "DEPTWISEDETAIL" Then
                expo = RPTBALESTOCK_DEPT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK_DEPT.Export()
            ElseIf FRMSTRING = "DEPTWISESUMM" Then
                expo = RPTBALESTOCK_DEPTSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK_DEPTSUMM.Export()


            ElseIf FRMSTRING = "CATEGORYWISENOTOTAL" Then
                expo = RPTBALESTOCK_CATEGORYNOTOTAL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK_CATEGORYNOTOTAL.Export()
            ElseIf FRMSTRING = "DEPARTMENTWISENOTOTAL" Then
                expo = RPTBALESTOCK_DEPARTMENTNOTOTAL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK_DEPARTMENTNOTOTAL.Export()
            ElseIf FRMSTRING = "GRADEWISENOTOTAL" Then
                expo = RPTBALESTOCK_GRADENOTOTAL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK_GRADENOTOTAL.Export()


            ElseIf FRMSTRING = "JOBWISE" Then
                expo = RPTBALESTOCK_JOB_DETAIL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK_JOB_DETAIL.Export()
            ElseIf FRMSTRING = "JOBSUMM" Then
                expo = RPTBALESTOCK_JOB_SUMMARY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK_JOB_SUMMARY.Export()
            ElseIf FRMSTRING = "RATEREPORT" Then
                expo = RPTBALESTOCK.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTBALESTOCK.Export()
            ElseIf FRMSTRING = "FPSDTLS" Then
                expo = RPTFPSDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTFPSDTLS.Export()
            ElseIf FRMSTRING = "FPSITEMDTLS" Then
                expo = RPTFPSITEMDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTFPSITEMDTLS.Export()
            ElseIf FRMSTRING = "FPSITEMSUMM" Then
                expo = RPTFPSITEMSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTFPSITEMSUMM.Export()
            ElseIf FRMSTRING = "FPSPROCESSTYPE" Then
                expo = RPTFPSPROCESSTYPE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTFPSPROCESSTYPE.Export()
            ElseIf FRMSTRING = "FPSLOTSUMM" Then
                expo = RPTFPSLOTSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTFPSLOTSUMM.Export()
            ElseIf FRMSTRING = "FPSCATEGORY" Then
                expo = RPTFPSCATEGORY.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTFPSCATEGORY.Export()
            ElseIf FRMSTRING = "FPSDEPARTMENT" Then
                expo = RPTFPSDEPARTMENT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTFPSDEPARTMENT.Export()
            ElseIf FRMSTRING = "FPSPIECETYPE" Then
                expo = RPTFPSPIECETYPE.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTFPSPIECETYPE.Export()
            ElseIf FRMSTRING = "FPS" Then

                If ClientName = "MONOGRAM" Then

                    If HEADER = False Then
                        RPTFPS_MONOGRAM.DataDefinition.FormulaFields("HIDEHEADER").Text = 1
                    Else
                        RPTFPS_MONOGRAM.DataDefinition.FormulaFields("HIDEHEADER").Text = 0
                    End If

                    expo = RPTFPS_MONOGRAM.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTFPS_MONOGRAM.Export()

                ElseIf ClientName = "DHANLAXMI" Or ClientName = "SHUBHLAXMI" Then

                    If HEADER = False Then
                        RPTFPS_DHANLAXMI.DataDefinition.FormulaFields("HIDEHEADER").Text = 1
                    Else
                        RPTFPS_DHANLAXMI.DataDefinition.FormulaFields("HIDEHEADER").Text = 0
                    End If

                    expo = RPTFPS_DHANLAXMI.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTFPS_DHANLAXMI.Export()


                Else
                    If goodcut = True Then
                        RPTFPS.GroupHeaderSection7.SectionFormat.EnableSuppress = True
                        RPTFPS.GroupHeaderSection10.SectionFormat.EnableSuppress = False
                        RPTFPS.GroupHeaderSection8.SectionFormat.EnableSuppress = True
                        RPTFPS.GroupHeaderSection9.SectionFormat.EnableSuppress = False
                        RPTFPS.GroupFooterSection3.SectionFormat.EnableSuppress = True
                        RPTFPS.GroupFooterSection7.SectionFormat.EnableSuppress = False
                    End If

                    If HEADER = False Then
                        RPTFPS.DataDefinition.FormulaFields("HIDEHEADER").Text = 1
                    Else
                        RPTFPS.DataDefinition.FormulaFields("HIDEHEADER").Text = 0
                    End If

                    RPTFPS.DataDefinition.FormulaFields("JOBNO").Text = "'" & JOBNO & "'"
                    expo = RPTFPS.ExportOptions
                    expo.ExportDestinationType = ExportDestinationType.DiskFile
                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
                    expo.DestinationOptions = oDfDopt
                    RPTFPS.Export()
                End If


            ElseIf FRMSTRING = "PSDTLS" Then
                expo = RPTPSDETAIL.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPSDETAIL.Export()
            ElseIf FRMSTRING = "PSMERCHANT" Then
                expo = RPTPSMERCHANT.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPSMERCHANT.Export()
            ElseIf FRMSTRING = "PSPARTYDTLS" Then
                expo = RPTPSPARTYDTLS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPSPARTYDTLS.Export()
            ElseIf FRMSTRING = "PSPARTYMERCHANTSUMM" Then
                expo = RPTPSPARTYMERCHANTSUMM.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPSPARTYMERCHANTSUMM.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

End Class