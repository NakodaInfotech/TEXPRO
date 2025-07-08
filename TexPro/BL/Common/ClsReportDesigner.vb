
Imports Excel
'Imports DB
'Imports AsianERPBL.ModGeneral
'Imports AsianERPBL.Account
Imports System.Data

Public Class clsReportDesigner
    'Private objDBOperation As DB.DBOperation

    'Public objUserDetails As ObjUser
    'Private objRepCenter As New clsRepCenter
    Dim dsResult As New DataSet
    Public ALPARAVAL As New ArrayList
    Dim dv As New DataView

    Public Sub New()
        Try
            'objDBOperation = New DB.DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region " INTERNAL MANAGEMENT DECLARATIONS ............. "


#Region "Private Declarations..."
    Private objColumn As New Hashtable
    Private objSheet As Excel.Worksheet
    Private objExcel As Excel.Application
    Private objBook As Excel.Workbook
    'Private objUser As New clsUser
    Private RowIndex As Integer
    Private currentColumn As String
    Private _Report_Title As String
    Private _SaveFilePath As String
    Private _PreviewOption As Integer
#End Region

    Public Sub New(ByVal Report_Title As String, ByVal SaveFilePath As String, ByVal PreivewOption As Integer)
        Dim proc As System.Diagnostics.Process
        Try
            _Report_Title = Report_Title
            _SaveFilePath = SaveFilePath
            _PreviewOption = PreivewOption
            Try
                For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
                    proc.Kill()
                Next
            Catch ex As Exception

            End Try
            ' try{
            '    foreach (Process thisproc in Process.GetProcessesByName(processName)) {
            'if(!thisproc.CloseMainWindow()){
            '//If closing is not successful or no desktop window handle, then force termination.
            'thisproc.Kill();
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetWorkSheet()
        Try
            objExcel = New Excel.Application
            If Not objExcel Is Nothing Then
                objBook = objExcel.Workbooks.Add
                objSheet = DirectCast(objBook.ActiveSheet, Excel.Worksheet)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Quit()
        Try
            objSheet = Nothing
            objBook.Close()
            ReleaseObject(objBook)
            objExcel.Quit()
            ReleaseObject(objExcel)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub SaveAndClose()
        Try
            objExcel.AlertBeforeOverwriting = False
            objExcel.DisplayAlerts = False
            objSheet.SaveAs(_SaveFilePath)

            If _PreviewOption = 1 Then 'Open In Web Browser                
                objBook.WebPagePreview()
            ElseIf _PreviewOption = 2 Then 'Open In Excel                
                objExcel.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Try
                If _PreviewOption <> 2 Then Quit()
            Catch ex As Exception
            End Try
        End Try
    End Sub

    Private Sub SetColumn(ByVal Key As String, ByVal ForColumn As String)
        Try
            objColumn.Add(Key, ForColumn)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReSetColumn()
        Try
            objColumn.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private ReadOnly Property Column(ByVal Key As String) As String
        Get
            Try
                Return objColumn.Item(Key).ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    Private ReadOnly Property Range(ByVal Key As String) As String
        Get
            Try
                Return objColumn.Item(Key).ToString & RowIndex.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    Private Sub Write(ByVal Text As Object, ByVal Range As String, ByVal Align As XlHAlign, _
        Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
        Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            objSheet.Range(Range).FormulaR1C1 = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            objSheet.Range(Range).HorizontalAlignment = Align
            If FontBold Then objSheet.Range(Range).Font.Bold = True
            If FontSize > 0 Then objSheet.Range(Range).Font.Size = FontSize
            If WrapText Then objSheet.Range(Range).WrapText = True
            If fontItalic Then objSheet.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FORMULA(ByVal Text As Object, ByVal Range As String, ByVal Align As XlHAlign, _
       Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
       Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            objSheet.Range(Range).Formula = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            objSheet.Range(Range).HorizontalAlignment = Align
            If FontBold Then objSheet.Range(Range).Font.Bold = True
            If FontSize > 0 Then objSheet.Range(Range).Font.Size = FontSize
            If WrapText Then objSheet.Range(Range).WrapText = True
            If fontItalic Then objSheet.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LOCKCELLS(ByVal VALUE As Boolean, ByVal Range As String, Optional ByVal ToRange As String = Nothing)
        Try
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Locked = VALUE
            Else
                objSheet.Range(Range).Locked = VALUE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetBorder(ByVal RowIndex As Integer, Optional ByVal Range As String = Nothing, Optional ByVal ToRange As String = Nothing)

        Dim intI As Integer = 0
        ''RowIndex = 0
        'obj()
        'objSheet.Selec
        'objExcel.Selection("A1:N17").ToString()
        objSheet.Range(Range, ToRange).Select()
        objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        'For intI = 1 To RowIndex
        '    objSheet.Range(Range, ToRange).Select()
        '    objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        '    intI += 1
        'Next
    End Sub

    Private Sub SetColumnWidth(ByVal Range As String, ByVal width As Integer)
        'objSheet.Range(Range).BorderAround()
        objSheet.Range(Range).ColumnWidth = width
        '  = objSheet.Range(Range).Select()
        'objSheet.Range(Range).EditionOptions(XlEditionType.xlPublisher, XlEditionOptionsOption.xlAutomaticUpdate, , , XlPictureAppearance.xlScreen, XlPictureAppearance.xlScreen)
    End Sub

    Private Function NextColumn() As String
        Dim nxtColumn As String = String.Empty
        Try
            Dim i As Integer = 0
            Dim length As Integer = currentColumn.Length
            For i = length - 1 To 0 Step -1
                If Not (currentColumn(i).ToString.ToUpper = "Z") Then
                    Dim substr As String = String.Empty
                    If i > 0 Then
                        substr = currentColumn.Substring(0, i)
                    End If
                    nxtColumn = Convert.ToString(Convert.ToChar(Convert.ToInt32(currentColumn(i)) + 1)) & nxtColumn
                    nxtColumn = substr & nxtColumn
                    Exit For
                ElseIf currentColumn(i).ToString.ToUpper = "Z" Then
                    nxtColumn = "A" & nxtColumn
                End If
                If i = 0 Then
                    If Convert.ToString(currentColumn(i)).ToUpper = "Z" Then
                        nxtColumn = "A" & nxtColumn
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
        currentColumn = nxtColumn
        Return nxtColumn
    End Function

    Private Sub MeargeCell(ByVal StartCol As String, ByVal StartRow As String, ByVal EndCol As String, ByVal EndRow As String)
        Try

            'objSheet.Range(StartCol & StartRow & ":" & EndCol & EndRow).Merge()
            objSheet.Range(StartCol, EndCol).Merge()

            'With objSheet.Selection                
            '    .WrapText = False
            '    .Orientation = 0
            '    .AddIndent = False
            '    .IndentLevel = 0
            '    .ShrinkToFit = False                
            '    .MergeCells = True
            'End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Sample"

    Public Function RPT_SampleGeneral_Loading(ByVal intPDIID As Integer, ByVal strPUser As String) As Object
        Try
            Dim id As Integer = 0
            Dim intJ As Integer = 0
            Dim intTotal As Integer = 0
            Dim intSrNo As Integer = 0
            Dim intRowStart, intRowEnd As Integer
            Dim drRow As DataRow
            Dim drNew As System.Data.DataRow = Nothing
            Dim dtTable As New System.Data.DataTable
            Dim dtSetItem As New System.Data.DataTable
            Dim dtChild As New System.Data.DataTable
            Dim objDispatch As New Object()

            'BrandPromotion.clsSampleDispatch()
            'Dim Tot1, Tot2, tot3, Tot4 As Double
            'Dim Gt1, Gt2, Gt3 As Double
            'Dim dvTemp As DataView
            'dtTable = objDispatch.DispatchChitReport(intPDIID)
            'If dtTable.Rows.Count = 0 Then Return Nothing
            'dtChild = objDispatch.DispatchChitReportCHILD(intPDIID)
            'dtSetItem = objDispatch.DispatchChitReportItem(intPDIID)




            SetWorkSheet()
            SetColumn("1", "A")
            SetColumn("2", "B")
            SetColumn("3", "C")
            SetColumn("4", "D")
            SetColumn("5", "E")
            SetColumn("6", "F")
            SetColumn("7", "G")
            SetColumn("8", "H")
            SetColumn("9", "I")
            'SetColumn("10", "J")
            'SetColumn("11", "K")
            'SetColumn("12", "L")
            'SetColumn("13", "M")
            'SetColumn("14", "N")
            'SetColumn("15", "O")
            SetColumnWidth("A1", 50)

            objSheet.Range("A1").Select()
            objSheet.Range("A1").BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )

            '''''''''''Report Title
            RowIndex += 3
            Write(_Report_Title, Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            RowIndex += 1
            Write("FER 2006 Regulation 27(1)(b) and (c)", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            RowIndex += 1
            Write("WEEKLY / MONTLY RETURN FOR SALES OF FOREIGN CURRENCIES(OURFLOWS) ", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 0)
            '''''''''''Report Title Over
            RowIndex += 1
            Write("TEMPLATE - VERSION 1.0", Range("4"), XlHAlign.xlHAlignLeft, Range("5"), , 0)

            RowIndex += 1
            'Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), , 0)
            Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("Week / Month ending", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Year", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Bureaux / Money remitters name", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1


            Write("Purpose of Funds", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            Write("USD", Range("2"), XlHAlign.xlHAlignLeft, , True, )
            Write("Stg", Range("3"), XlHAlign.xlHAlignLeft, , True, )
            Write("EURO", Range("4"), XlHAlign.xlHAlignLeft, , True, )
            Write("KShs", Range("5"), XlHAlign.xlHAlignLeft, , True, )
            Write("Tz", Range("6"), XlHAlign.xlHAlignLeft, , True, )
            Write("SAR", Range("7"), XlHAlign.xlHAlignLeft, , True, )
            Write("Other(in USD)8", Range("8"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("1. Domestic Transactions", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a)Transaction between Ugandan Residents", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b)Currency Holdings / Deposits e.g. Savings", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("2. Exports of Goods", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Gold Exports (non-monetary gold)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Repairs on goods", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Goods procured in ports by carriers", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(d) Goods for processing", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(e) Coffee and other Exports", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("3. Income Receipts", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Interest received on External assets", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Dividends / profits received", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Wages / Salaries", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("4. Service Receipts", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Transportation", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a1) Freight", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a2) Passenger", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a3) Other", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Communication services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Construction services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(d) Insurance & Re-inssurance", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(e) Financial services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f) Travel", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f1) Business / Official", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f2) Education", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f3) Medical", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(f4) Other Personal", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(g) Computer and information services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(h) Royalties and license fees", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(i) Other business services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(j) Personal, cultural, and recreational serives", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(k) Government services, n.i.e.", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("5. Transfers", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) NGO inflows", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Government Grants", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Worker's remittances", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(d) Other transfers", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("6. Foreign Direct Equity Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("7. Portfolio Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Government", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Bank", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(c) Other", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("8. Loans", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Loan Received", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a1) By commercial Banks", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a2) Others", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(i) Private", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(ii) Goverment", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(b) Loan Repayment (Principal)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Bank / bureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Interbureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Other (Please specify)", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("UGANDA SHILLING EQUIVALENT", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("* Other currencies traded should be reported in USDollar equivalent.", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("This return should be submitted not later than three o'clock in the afternoon of every first business day following the week and not later than five days after the end of the month to which it pertains.", Range("1"), XlHAlign.xlHAlignLeft, , True, )


            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Private Sub FetchData(ByVal fromDate As Date, ByVal toDate As Date, ByVal sp_name As String)
        Try
            'Dim conn As New SqlClient.SqlConnection("Data Source=DELL-B0BA70D352\SQLDELL;Initial Catalog=Forex;Integrated Security=True;uid=sa;pwd=admin123;")
            'Dim conn As New SqlClient.SqlConnection("Data Source=.\SQLDELL;Initial Catalog=Project;Integrated Security=True;")
            Dim conn As New SqlClient.SqlConnection(System.Configuration.ConfigurationSettings.AppSettings("ConnectionString").ToString())


            Dim comm As New SqlClient.SqlCommand()
            conn.Open()
            comm.Connection = conn
            comm.CommandType = CommandType.StoredProcedure
            comm.CommandText = sp_name
            comm.Parameters.Add(New SqlClient.SqlParameter("@FromDate", fromDate))
            comm.Parameters.Add(New SqlClient.SqlParameter("@ToDate", toDate))
            comm.CommandTimeout = 1000
            Dim adap As New SqlClient.SqlDataAdapter(comm)
            adap.Fill(dsResult)
            conn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillAmount()
        Try

            If dv.Count > 0 Then
                For index As Integer = 1 To dv.Count
                    If dv.Item(index - 1)("CurrencyId") = 1 Then
                        Write(dv.Item(index - 1)("Amount"), Range("2"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 2 Then
                        Write(dv.Item(index - 1)("Amount"), Range("3"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 3 Then
                        Write(dv.Item(index - 1)("Amount"), Range("4"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 4 Then
                        Write(dv.Item(index - 1)("Amount"), Range("5"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 5 Then
                        Write(dv.Item(index - 1)("Amount"), Range("6"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 7 Then
                        Write(dv.Item(index - 1)("Amount"), Range("7"), XlHAlign.xlHAlignLeft, , False, )
                    ElseIf dv.Item(index - 1)("CurrencyId") = 9 Then
                        Write(dv.Item(index - 1)("Amount"), Range("2"), XlHAlign.xlHAlignLeft, , False, )
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function RPT_Sales_Report(ByVal fromDate As Date, ByVal toDate As Date) As Object
        Try
            Me.FetchData(fromDate, toDate, "SP_SELECTSO_FOR_EDIT")

            SetWorkSheet()
            SetColumn("1", "A")
            SetColumn("2", "B")
            SetColumn("3", "C")
            SetColumn("4", "D")
            SetColumn("5", "E")
            SetColumn("6", "F")
            SetColumn("7", "G")
            SetColumn("8", "H")
            SetColumn("9", "I")

            SetColumnWidth("A1", 50)
            objSheet.Range("A1").Select()
            objSheet.Range("A1").BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )

            '''''''''''Report Title
            RowIndex += 3
            Write("FORM P(Sales)", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            RowIndex += 1
            Write("FER 2006 Regulation 27(1)(b) and (c)", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, , True)
            RowIndex += 1
            Write("WEEKLY / MONTLY RETURN FOR SALES OF FOREIGN CURRENCIES(OURFLOWS) ", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 0)
            '''''''''''Report Title Over
            RowIndex += 1
            Write("TEMPLATE - VERSION 1.0", Range("4"), XlHAlign.xlHAlignLeft, Range("5"), , 0)

            RowIndex += 1
            'Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), , 0)
            Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("Week / Month ending", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Year", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Bureaux / Money remitters name", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1


            Write("Purpose of Funds", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            Write("USD", Range("2"), XlHAlign.xlHAlignLeft, , True, )
            Write("Stg", Range("3"), XlHAlign.xlHAlignLeft, , True, )
            Write("EURO", Range("4"), XlHAlign.xlHAlignLeft, , True, )
            Write("KShs", Range("5"), XlHAlign.xlHAlignLeft, , True, )
            Write("Tz", Range("6"), XlHAlign.xlHAlignLeft, , True, )
            Write("SAR", Range("7"), XlHAlign.xlHAlignLeft, , True, )
            Write("Other(in USD)8", Range("8"), XlHAlign.xlHAlignLeft, , True, )

            dv = dsResult.Tables(0).DefaultView

            RowIndex += 1
            Write("1. Domestic Transactions", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a)Transaction between Ugandan Residents", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransBetweenUgandaRes'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b)Currency Holdings / Deposits e.g. Savings", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CurrencyHoldingDiposits'"
            Me.FillAmount()

            RowIndex += 1
            Write("2. Import of Goods", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("(a) Govt imports (Incl. Govt. Projects)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GovtImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Private Imports (Incl. Parastatal & NGOs)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='PrivateImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(i) Oil Imports", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='OilImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(ii) Gold Imports", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GoldImports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(iii) Repairs", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='Repairs'"
            Me.FillAmount()

            RowIndex += 1
            Write("(iv) Goods procured in ports by carriers", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='GoodsProPortsByCarrier'"
            Me.FillAmount()

            RowIndex += 1
            Write("(v) Goods for processing", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GoodsForProcessig'"
            Me.FillAmount()

            RowIndex += 1
            Write("Income Payments", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("(a) Interest received on External liabilities", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='InterestPaidOnExternalLib'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Dividends / profits paid", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='DividentProfitPaid'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Wages / Salaries", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='WagesSalaries'"
            Me.FillAmount()

            RowIndex += 1
            Write("Service Receipts", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Transportation", Range("1"), XlHAlign.xlHAlignLeft, , False, )


            RowIndex += 1
            Write("(a1) Freight", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransFreight'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a2) Passenger", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransPassanger'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a3) Other", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransOther'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Communication services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CommunicationService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Construction services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='ConstructionService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(d) Insurance & Re-inssurance", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='InsuranceDeInsu'"
            Me.FillAmount()

            RowIndex += 1
            Write("(e) Financial services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='FinancialService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f) Travel", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransBetweenUgandaRes'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f1) Business / Official", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelBusinessOfficial'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f2) Education", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelEducation'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f3) Medical", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelMedical'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f4) Other Personal", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelOtherPersonal'"
            Me.FillAmount()

            RowIndex += 1
            Write("(g) Computer and information services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CompAndInfoService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(h) Royalties and licence fees", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='RoyaliAndLicenceFees'"
            Me.FillAmount()

            RowIndex += 1
            Write("(i) Other business services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='OtherBusinessService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(j) Personal, cultural, and recreational serives", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='PersonalCultAndReceService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(k) Government services, n.i.e.", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GovtServices'"
            Me.FillAmount()

            RowIndex += 1
            Write("Transfers", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(a) NGO Outflows", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransNGOOutFlows'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Government Grants", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransGovtGrants'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Worker's remittances", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='TransWorkerRemitance'"
            Me.FillAmount()

            RowIndex += 1
            Write("(d) Other transfers", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='TransOtherTransfer'"
            Me.FillAmount()

            RowIndex += 1
            Write("Foreign Direct Equity Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='ForeignDirectEquityInvestment'"
            Me.FillAmount()

            RowIndex += 1
            Write("Portfolio Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("(a) By Government", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='PortInvestByGovernment'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) By Bank", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='PortInvestByBanks'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) By Other", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='PortInvestByOthers'"
            Me.FillAmount()

            RowIndex += 1
            Write("Loans", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(a) Loans Extended abroad", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("(a1) By commercial Banks", Range("1"), XlHAlign.xlHAlignLeft, , False, )


            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByCommBankShortTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByCommBankLongTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a2) Others", Range("1"), XlHAlign.xlHAlignLeft, , False, )


            RowIndex += 1
            Write("(i) Private", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByPrivateShortTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByPrivateLongTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("(ii) Goverment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='LoanOtherGovernment'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Loan Repayment (Principal)", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='LoanRepaymentPrincipal'"
            Me.FillAmount()

            RowIndex += 1
            Write("Bank / bureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='BankBureaux'"
            Me.FillAmount()

            RowIndex += 1
            Write("Inerbank", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='InterBank'"
            Me.FillAmount()

            RowIndex += 1
            Write("Interbureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='InterBureaux'"
            Me.FillAmount()

            RowIndex += 1
            Write("UGANDA SHILLING EQUIVALENT", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("* Other currencies traded should be reported in USDollar equivalent.", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("This return should be submitted not later than three o'clock in the afternoon of every first business day following the week and not later than five days after the end of the month to which it pertains.", Range("1"), XlHAlign.xlHAlignLeft, , True, )


            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing

    End Function

    Public Function RPT_Purchase_Report(ByVal fromDate As Date, ByVal toDate As Date) As Object
        Try
            Me.FetchData(fromDate, toDate, "SP_TradingPurchase_Report")
            Dim id As Integer = 0
            Dim intJ As Integer = 0
            Dim intTotal As Integer = 0
            Dim intSrNo As Integer = 0
            Dim drNew As System.Data.DataRow = Nothing
            Dim dtTable As New System.Data.DataTable
            Dim dtSetItem As New System.Data.DataTable
            Dim dtChild As New System.Data.DataTable
            Dim objDispatch As New Object()

            SetWorkSheet()
            SetColumn("1", "A")
            SetColumn("2", "B")
            SetColumn("3", "C")
            SetColumn("4", "D")
            SetColumn("5", "E")
            SetColumn("6", "F")
            SetColumn("7", "G")
            SetColumn("8", "H")
            SetColumn("9", "I")

            'Dim objCurrencyList As System.Collections.Generic.List(Of AccountingLinq.MasterCurrency) = New AccountingBL.MasterBL.MasterCurrencyBL().Search()

            'SetColumnWidth("A1", 50)

            'objSheet.Range("A1").Select()
            'objSheet.Range("A1").BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )

            '''''''''''Report Title
            RowIndex += 3
            Write("FORM R(Case Purchase)", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            RowIndex += 1
            Write("FER 2006 Regulation 27(1)(b) and (c)", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            RowIndex += 1
            Write("WEEKLY / MONTLY RETURN FOR SALES OF FOREIGN CURRENCIES(OURFLOWS) ", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 0)
            '''''''''''Report Title Over
            RowIndex += 1
            Write("TEMPLATE - VERSION 1.0", Range("4"), XlHAlign.xlHAlignLeft, Range("5"), , 0)

            RowIndex += 1
            Write("Date of period", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("Week / Month ending", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Year", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("Bureaux / Money remitters name", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1

            Write("Purpose of Funds", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            'Write(objCurrencyList(0).CurrencyName, Range("2"), XlHAlign.xlHAlignLeft, , True, )
            'Write(objCurrencyList(1).CurrencyName, Range("3"), XlHAlign.xlHAlignLeft, , True, )
            'Write(objCurrencyList(2).CurrencyName, Range("4"), XlHAlign.xlHAlignLeft, , True, )
            'Write(objCurrencyList(3).CurrencyName, Range("5"), XlHAlign.xlHAlignLeft, , True, )
            'Write(objCurrencyList(4).CurrencyName, Range("6"), XlHAlign.xlHAlignLeft, , True, )
            'Write(objCurrencyList(5).CurrencyName, Range("7"), XlHAlign.xlHAlignLeft, , True, )
            'Write(objCurrencyList(6).CurrencyName, Range("8"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("1. Domestic Transactions", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a)Transaction between Ugandan Residents", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransBetweenUgandaRes'"
            Me.FillAmount()
            'objSaleList.Where(
            RowIndex += 1
            Write("(b)Currency Holdings / Deposits e.g. Savings", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CurrencyHoldingDiposits'"
            Me.FillAmount()

            RowIndex += 1
            Write("2. Exports of Goods", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Gold Exports (non-monetary gold)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GoldExports'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Repairs on goods", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='RepairsOnGoods'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Goods procured in ports by carriers", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GoodsProcured'"
            Me.FillAmount()

            RowIndex += 1
            Write("(d) Goods for processing", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GoodsOfProcessing'"
            Me.FillAmount()

            RowIndex += 1
            Write("(e) Coffee and other Exports", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CoffeeOther'"
            Me.FillAmount()

            RowIndex += 1
            Write("3. Income Receipts", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Interest received on External assets", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='InterestReceived'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Dividends / profits received", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='DividentProfitReceived'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Wages / Salaries", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='WagesSalaries'"
            Me.FillAmount()

            RowIndex += 1
            Write("4. Service Receipts", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Transportation", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(a1) Freight", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransFreight'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a2) Passenger", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransPassanger'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a3) Other", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransOther'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Communication services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CommunicationService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Construction services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='ConstructionService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(d) Insurance & Re-inssurance", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='InsuranceReInsu'"
            Me.FillAmount()

            RowIndex += 1
            Write("(e) Financial services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='FinancialService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f) Travel", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(f1) Business / Official", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelBusinessOfficial'"
            Me.FillAmount()

            RowIndex += 1
            Write("(f2) Education", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelEducation'"
            Me.FillAmount()


            RowIndex += 1
            Write("(f3) Medical", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelMedical'"
            Me.FillAmount()


            RowIndex += 1
            Write("(f4) Other Personal", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TravelOtherPersonal'"
            Me.FillAmount()

            RowIndex += 1
            Write("(g) Computer and information services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='CompAndInfoService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(h) Royalties and license fees", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='RoyaliAndLicenceFees'"
            Me.FillAmount()

            RowIndex += 1
            Write("(i) Other business services", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='OtherBusinessService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(j) Personal, cultural, and recreational serives", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='PersonalCultAndReceService'"
            Me.FillAmount()

            RowIndex += 1
            Write("(k) Government services, n.i.e.", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='GovtServices'"
            Me.FillAmount()

            RowIndex += 1
            Write("5. Transfers", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) NGO inflows", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransNGOInFlows'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Government Grants", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransGovtGrants'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Worker's remittances", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransWorkerRemitance'"
            Me.FillAmount()

            RowIndex += 1
            Write("(d) Other transfers", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='TransOtherTransfer'"
            Me.FillAmount()

            RowIndex += 1
            Write("6. Foreign Direct Equity Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName=''"
            Me.FillAmount()

            RowIndex += 1
            Write("7. Portfolio Investment", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Government", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='PortInvestByGovernment'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Bank", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='PortInvestByBanks'"
            Me.FillAmount()

            RowIndex += 1
            Write("(c) Other", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='PortInvestByOthers'"
            Me.FillAmount()

            RowIndex += 1
            Write("8. Loans", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("(a) Loan Received", Range("1"), XlHAlign.xlHAlignLeft, , True, )

            RowIndex += 1
            Write("(a1) By commercial Banks", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByCommBankShortTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByCommBankLongTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("(a2) Others", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            RowIndex += 1
            Write("(i) Private", Range("1"), XlHAlign.xlHAlignLeft, , False, )

            RowIndex += 1
            Write("Short term (<1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByPrivateShortTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("Long term (>1 year)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanByPrivateLongTerm'"
            Me.FillAmount()

            RowIndex += 1
            Write("(ii) Goverment", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanOtherGovernment'"
            Me.FillAmount()

            RowIndex += 1
            Write("(b) Loan Repayment (Principal)", Range("1"), XlHAlign.xlHAlignLeft, , False, )
            dv.RowFilter = "ColName='LoanRepaymentPrincipal'"
            Me.FillAmount()

            RowIndex += 1
            Write("Bank / bureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='BankBureaux'"
            Me.FillAmount()
            ''''''''''''''''''''''''''''''''''''''''''''''InterBank
            RowIndex += 1
            Write("Interbureaux", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName='InterBureaux'"
            Me.FillAmount()

            RowIndex += 1
            Write("Other (Please specify)", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            dv.RowFilter = "ColName=''"
            Me.FillAmount()

            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("UGANDA SHILLING EQUIVALENT", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("* Other currencies traded should be reported in USDollar equivalent.", Range("1"), XlHAlign.xlHAlignLeft, , True, )
            RowIndex += 1
            Write("This return should be submitted not later than three o'clock in the afternoon of every first business day following the week and not later than five days after the end of the month to which it pertains.", Range("1"), XlHAlign.xlHAlignLeft, , True, )


            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    'Private Function RPT_Purchase_Report_Data() As DataSet

    '    Dim objDbOperation As DBLayer.DB_Operation = New DBLayer.DB_Operation()

    '    Dim strSql As String
    '    strSql = "SELECT * FROM TradingSales"
    '    Return objDbOperation.ExecuteQuery(strSql)

    'End Function

#End Region

#Region "CMPHEADER"

    Sub CMPHEADER(ByVal CMPID As Integer, ByVal REPORTTITLE As String, Optional ByVal PERIOD As String = "")
        Try
            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write(REPORTTITLE, Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write(PERIOD, Range("1"), XlHAlign.xlHAlignCenter, Range("6"), False, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("6").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("6").ToString & 8).Application.ActiveWindow.FreezePanes = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "OPENING REPORT"

    Public Function OPENING_Report(ByVal TYPE As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer, ByVal CONDITION As String) As Object
        Try
            Dim objCMN As New ClsCommon

            Dim dttable As New System.Data.DataTable
            dttable = objCMN.search("   ISNULL(STOCKMASTER.SM_GRIDSRNO, 0) AS GRIDSRNO,  STOCKMASTER.SM_LOTNO AS LOTNO,STOCKMASTER.SM_DATE AS DATE, STOCKMASTER.SM_TYPE AS TYPE, STOCKMASTER.SM_SUBTYPE AS SUBTYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(PROCESSMASTER.PROCESS_NAME, '') AS PROCESS, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(DESIGNRECIPE.DESIGN_NO, '') AS DESIGN, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(PIECETYPEMASTER.PIECETYPE_name, '') AS PIECETYPE, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(DYEINGRECIPE.DYEING_NO, '') AS DYEING, ISNULL(STOCKMASTER.SM_BALENO, '') AS BALENO, ISNULL(STOCKMASTER.SM_JOBNO, '') AS JOBNO, ISNULL(STOCKMASTER.SM_CUT, 0) AS CUT, ISNULL(STOCKMASTER.SM_SAREE, 0) AS SAREE,ISNULL(STOCKMASTER.SM_wt, 0) AS wt,ISNULL(STOCKMASTER.SM_PCS, 0) AS PCS, ISNULL(STOCKMASTER.SM_MTRS, 0) AS MTRS, ISNULL(STOCKMASTER.SM_RECDPCS,0) AS OUTPCS, ISNULL(STOCKMASTER.SM_RECDMTRS,0) AS OUTMTRS,  ISNULL(STOCKMASTER.SM_DONE,0) AS DONE,  ISNULL(STOCKMASTER.SM_RETURNPCS,0) AS RETURNPCS ", "", "  STOCKMASTER LEFT OUTER JOIN DYEINGRECIPE ON STOCKMASTER.SM_DYEINGID = DYEINGRECIPE.DYEING_ID AND STOCKMASTER.SM_CMPID = DYEINGRECIPE.DYEING_CMPID AND STOCKMASTER.SM_LOCATIONID = DYEINGRECIPE.DYEING_LOCATIONID AND STOCKMASTER.SM_YEARID = DYEINGRECIPE.DYEING_YEARID LEFT OUTER JOIN PIECETYPEMASTER ON STOCKMASTER.SM_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id AND STOCKMASTER.SM_CMPID = PIECETYPEMASTER.PIECETYPE_cmpid AND STOCKMASTER.SM_LOCATIONID = PIECETYPEMASTER.PIECETYPE_locationid AND STOCKMASTER.SM_YEARID = PIECETYPEMASTER.PIECETYPE_yearid LEFT OUTER JOIN QUALITYMASTER ON STOCKMASTER.SM_QUALITYID = QUALITYMASTER.QUALITY_id AND STOCKMASTER.SM_CMPID = QUALITYMASTER.QUALITY_cmpid AND STOCKMASTER.SM_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND STOCKMASTER.SM_YEARID = QUALITYMASTER.QUALITY_yearid LEFT OUTER JOIN PROCESSMASTER ON STOCKMASTER.SM_YEARID = PROCESSMASTER.PROCESS_YEARID AND STOCKMASTER.SM_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND STOCKMASTER.SM_CMPID = PROCESSMASTER.PROCESS_CMPID AND STOCKMASTER.SM_PROCESSID = PROCESSMASTER.PROCESS_ID LEFT OUTER JOIN DESIGNRECIPE ON STOCKMASTER.SM_DESIGNID = DESIGNRECIPE.DESIGN_ID AND STOCKMASTER.SM_ITEMID = DESIGNRECIPE.DESIGN_ITEMID AND STOCKMASTER.SM_CMPID = DESIGNRECIPE.DESIGN_CMPID AND STOCKMASTER.SM_LOCATIONID = DESIGNRECIPE.DESIGN_LOCATIONID AND STOCKMASTER.SM_YEARID = DESIGNRECIPE.DESIGN_YEARID LEFT OUTER JOIN LEDGERS ON STOCKMASTER.SM_LEDGERID = LEDGERS.Acc_id AND STOCKMASTER.SM_CMPID = LEDGERS.Acc_cmpid AND STOCKMASTER.SM_LOCATIONID = LEDGERS.Acc_locationid AND STOCKMASTER.SM_YEARID = LEDGERS.Acc_yearid LEFT OUTER JOIN UNITMASTER ON STOCKMASTER.SM_UNITID = UNITMASTER.unit_id AND STOCKMASTER.SM_CMPID = UNITMASTER.unit_cmpid AND STOCKMASTER.SM_LOCATIONID = UNITMASTER.unit_locationid AND STOCKMASTER.SM_YEARID = UNITMASTER.unit_yearid LEFT OUTER JOIN COLORMASTER ON STOCKMASTER.SM_COLORID = COLORMASTER.COLOR_id AND STOCKMASTER.SM_CMPID = COLORMASTER.COLOR_cmpid AND STOCKMASTER.SM_LOCATIONID = COLORMASTER.COLOR_locationid AND STOCKMASTER.SM_YEARID = COLORMASTER.COLOR_yearid LEFT OUTER JOIN ITEMMASTER ON STOCKMASTER.SM_ITEMID = ITEMMASTER.item_id AND STOCKMASTER.SM_CMPID = ITEMMASTER.item_cmpid AND STOCKMASTER.SM_LOCATIONID = ITEMMASTER.item_locationid AND STOCKMASTER.SM_YEARID = ITEMMASTER.item_yearid ", " AND STOCKMASTER.SM_TYPE = '" & TYPE & "' AND STOCKMASTER.SM_CMPID = " & CMPID & " AND STOCKMASTER.SM_LOCATIONID  = " & LOCATIONID & " AND STOCKMASTER.SM_YEARID = " & YEARID & " ORDER BY [GRIDSRNO]")


            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 6)
            Next

            SetColumnWidth("I1", 10)
            SetColumnWidth("J1", 10)
            SetColumnWidth("T1", 10)
            SetColumnWidth("P1", 10)


            '''''''''''Report Title

            RowIndex += 1
            Write("OPENING REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range("16"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("16"))



            RowIndex += 2
            Write("SR", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("LOTNO", Range("2"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
            Write("MERCHANT", Range("5"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            Write("Quality", Range("9"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            Write("PROCESS", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("BALE", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("JOBNO", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CUT", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("PCS", Range("15"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("MTRS", Range("16"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("16"))

            Dim SRNO As Integer = 0
            For Each dr As DataRow In dttable.Select(CONDITION)
                RowIndex += 1
                SRNO = SRNO + 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignCenter, , False, 10)
                Write(dr("LOTNO"), Range("2"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                Write(dr("ITEMNAME"), Range("5"), XlHAlign.xlHAlignLeft, Range("8"), False, 10)
                Write(dr("QUALITY"), Range("9"), XlHAlign.xlHAlignLeft, Range("10"), False, 10)
                Write(dr("PROCESS"), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("BALENO"), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("JOBNO"), Range("13"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(dr("CUT"), "0.00"), Range("14"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(dr("PCS"), "0.00"), Range("15"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(dr("MTRS"), "0.00"), Range("16"), XlHAlign.xlHAlignRight, , False, 10)

            Next
            'For i As Integer = 1 To 16
            '    LOCKCELLS(False, Range(i))
            'Next


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - SRNO, Range("1"))
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex - SRNO, Range("4"))
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex - SRNO, Range("8"))
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex - SRNO, Range("10"))
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex - SRNO, Range("11"))
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex - SRNO, Range("12"))
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex - SRNO, Range("13"))
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex - SRNO, Range("14"))
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex - SRNO, Range("15"))
            SetBorder(RowIndex, objColumn.Item("16").ToString & RowIndex - SRNO, Range("16"))

            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("14"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("14"))
            Write(dttable.Compute("sum(PCS)", ""), Range("15"), XlHAlign.xlHAlignRight, , True, 10)
            Write(dttable.Compute("sum(MTRS)", ""), Range("16"), XlHAlign.xlHAlignRight, , True, 10)
            'FORMULA("=SUM(" & objColumn.Item("15").ToString & RowIndex - dttable.Rows.Count & ":" & objColumn.Item("15").ToString & RowIndex - 1 & ")", Range("16"), XlHAlign.xlHAlignRight, , True, 10)
            If TYPE = "GREY" Then
                'VISIBILITY FALSE
                SetColumnWidth(Range("5"), 0)
                SetColumnWidth(Range("6"), 0)
                SetColumnWidth(Range("7"), 0)
                SetColumnWidth(Range("8"), 0)
                SetColumnWidth(Range("11"), 0)
                SetColumnWidth(Range("12"), 0)
                SetColumnWidth(Range("13"), 0)
                SetColumnWidth(Range("14"), 0)
            End If


            'With objSheet.PageSetup
            '    .TopMargin = 144
            '    .LeftMargin = 50.4
            '    .RightMargin = 0
            '    .BottomMargin = 0
            '    .Zoom = False
            '    .FitToPagesTall = 1
            '    .FitToPagesWide = 1
            'End With

            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("16").ToString & RowIndex + 2)
            'objSheet.Protect("infosys123")
            SaveAndClose()


        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing

    End Function

#End Region

#Region "MFG CONSUMPTION"

    Public Function MFG_CONSUMPTION_EXCEL(ByVal whereclause As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer, ByVal CONDITION As String, ByVal NOTCONDITION As String, Optional ByVal FRMSTRING As String = "DETAIL") As Object
        Try
            Dim objCMN As New ClsCommon
            Dim a As Integer = 0
            Dim dt As System.Data.DataTable
            If FRMSTRING = "DETAIL" Then
                dt = objCMN.search(" MFGMASTER.MFG_DATE AS DATE, MFGMASTER_DESC.MFG_LOTNO AS LOTNO, SUM(MFGMASTER_DESC.MFG_RECDMTRS) AS MTRS,  sum(MFGMASTER_DESC.MFG_inpcs) AS PCS, GREYDETAIL_VIEW.WT AS WT, QUALITYMASTER.QUALITY_name AS QUALITY, MFGMASTER.MFG_CMPID AS CMPID, MFGMASTER.MFG_LOCATIONID AS LOCATIONID, MFGMASTER.MFG_YEARID AS YEARID, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2,PROCESSMASTER_1.PROCESS_NAME,MFGMASTER_DESC.MFG_DONE ", "", " CMPMASTER INNER JOIN MFGMASTER INNER JOIN MFGMASTER_DESC ON MFGMASTER.MFG_NO = MFGMASTER_DESC.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_DESC.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_DESC.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_DESC.MFG_YEARID ON CMPMASTER.cmp_id = MFGMASTER.MFG_CMPID LEFT OUTER JOIN PROCESSMASTER ON MFGMASTER.MFG_FROMPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PROCESSMASTER AS PROCESSMASTER_1 ON MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER_1.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER_1.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER_1.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER_1.PROCESS_YEARID LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid And MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid LEFT OUTER JOIN GREYDETAIL_VIEW ON MFGMASTER_DESC.MFG_LOTNO = GREYDETAIL_VIEW.LOTNO AND MFGMASTER_DESC.MFG_YEARID = GREYDETAIL_VIEW.YEARID", whereclause & CONDITION & " GROUP BY MFGMASTER_DESC.MFG_LOTNO, MFGMASTER.MFG_DATE, GREYDETAIL_VIEW.WT, QUALITYMASTER.QUALITY_name, MFGMASTER.MFG_CMPID, MFGMASTER.MFG_LOCATIONID, MFGMASTER.MFG_YEARID, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2,PROCESSMASTER_1.PROCESS_NAME,MFGMASTER_DESC.MFG_DONE ")
            Else
                dt = objCMN.search(" MFGMASTER.MFG_DATE AS DATE, MFGMASTER_DESC.MFG_LOTNO AS LOTNO, SUM(MFGMASTER_DESC.MFG_RECDMTRS) AS MTRS,  sum(MFGMASTER_DESC.MFG_inpcs) AS PCS, SUM(MFGMASTER_DESC.MFG_WT) AS WT, QUALITYMASTER.QUALITY_name AS QUALITY, MFGMASTER.MFG_CMPID AS CMPID, MFGMASTER.MFG_LOCATIONID AS LOCATIONID, MFGMASTER.MFG_YEARID AS YEARID, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2,PROCESSMASTER_1.PROCESS_NAME,MFGMASTER_DESC.MFG_DONE ", "", " CMPMASTER INNER JOIN MFGMASTER INNER JOIN MFGMASTER_DESC ON MFGMASTER.MFG_NO = MFGMASTER_DESC.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_DESC.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_DESC.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_DESC.MFG_YEARID ON CMPMASTER.cmp_id = MFGMASTER.MFG_CMPID LEFT OUTER JOIN PROCESSMASTER ON MFGMASTER.MFG_FROMPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PROCESSMASTER AS PROCESSMASTER_1 ON MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER_1.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER_1.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER_1.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER_1.PROCESS_YEARID LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid And MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid", whereclause & CONDITION & " GROUP BY MFGMASTER_DESC.MFG_LOTNO, MFGMASTER.MFG_DATE, QUALITYMASTER.QUALITY_name, MFGMASTER.MFG_CMPID, MFGMASTER.MFG_LOCATIONID, MFGMASTER.MFG_YEARID, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2,PROCESSMASTER_1.PROCESS_NAME,MFGMASTER_DESC.MFG_DONE ")

            End If
            If dt.Rows.Count > 0 Then

                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For i As Integer = 1 To 26
                    SetColumnWidth(Range(i), 8)
                Next

                SetColumnWidth("R1", 7)
                SetColumnWidth("T1", 7)
                SetColumnWidth("U1", 10)


                '''''''''''Report Title
                'CMPNAME
                RowIndex += 1
                Write(dt.Rows(0).Item("cmp_name"), Range("1"), XlHAlign.xlHAlignCenter, Range("15"), True, 14)
                SetBorder(RowIndex, Range("1"), Range("15"))

                'ADD1
                RowIndex += 1
                Write(dt.Rows(0).Item("cmp_add1"), Range("1"), XlHAlign.xlHAlignCenter, Range("15"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("15"))

                'ADD2
                RowIndex += 1
                Write(dt.Rows(0).Item("cmp_add2"), Range("1"), XlHAlign.xlHAlignCenter, Range("15"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("15"))

                RowIndex += 1
                Write("MFG DETAIL", Range("1"), XlHAlign.xlHAlignCenter, Range("15"), True, 12)
                SetBorder(RowIndex, Range("1"), Range("15"))


                RowIndex += 1
                Write("LOT NO", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("DATE", Range("2"), XlHAlign.xlHAlignCenter, Range("3"), True, 10)
                Write("PCS", Range("4"), XlHAlign.xlHAlignCenter, Range("5"), True, 10)
                Write("QUALITY", Range("6"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
                Write("WT / MTRS", Range("11"), XlHAlign.xlHAlignCenter, Range("12"), True, 10)
                Write("MTRS", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("WT", Range("14"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
                Write("PROCESS", Range("15"), XlHAlign.xlHAlignCenter, , True, 10)

                'FREEZE  ROWS
                objSheet.Range(objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("15").ToString & RowIndex + 1).Select()
                objSheet.Range(objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("15").ToString & RowIndex + 1).Application.ActiveWindow.FreezePanes = True

                SetBorder(RowIndex, Range("1"), Range("15"))

                Dim SRNO As Integer = 0
                Dim PROCESSN As String
                For Each dr As DataRow In dt.Select("")
                    RowIndex += 1
                    SRNO = SRNO + 1
                    Write(dr("LOTNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(dr("DATE"), Range("2"), XlHAlign.xlHAlignLeft, Range("3"), False, 10)
                    Write(dr("PCS"), Range("4"), XlHAlign.xlHAlignRight, Range("5"), False, 10)
                    Write(dr("QUALITY"), Range("6"), XlHAlign.xlHAlignLeft, Range("10"), False, 10)
                    Write(Format(Val(dr("WT")), "0.000"), Range("11"), XlHAlign.xlHAlignRight, Range("12"), False, 10)
                    Write(Format(Val(dr("MTRS")), "0.00"), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(Val(dr("WT")) * Val(dr("MTRS")), "0.000"), Range("14"), XlHAlign.xlHAlignRight, , False, 10)
                    If PROCESSN <> dr("PROCESS_NAME") Then
                        Write(dr("PROCESS_NAME"), Range("15"), XlHAlign.xlHAlignRight, , False, 10)
                        PROCESSN = dr("PROCESS_NAME")
                    End If
                Next

                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - SRNO - 1, Range("1"))
                SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex - SRNO - 1, Range("3"))
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex - SRNO - 1, Range("5"))
                SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex - SRNO - 1, Range("10"))
                SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex - SRNO - 1, Range("12"))
                SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex - SRNO - 1, Range("13"))
                SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex - SRNO - 1, Range("14"))
                SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex - SRNO - 1, Range("15"))


                RowIndex += 1
                Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("1"), True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("15"))
                Dim TOTALWT, TOTALPCS, TOTALMTRS As Double

                Write(dt.Compute("sum(PCS)", ""), Range("4"), XlHAlign.xlHAlignRight, Range("5"), True, 10)
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("5"))
                FORMULA("=SUM(" & objColumn.Item("14").ToString & 7 & ":" & objColumn.Item("14").ToString & RowIndex - 1 & ")", Range("14"), XlHAlign.xlHAlignRight, , True, 10)

                'Write(dt.Compute("sum(WT)", ""), Range("14"), XlHAlign.xlHAlignRight, Range("14"), True, 10)
                TOTALWT = dt.Compute("sum(WT)", "")
                TOTALPCS = dt.Compute("sum(PCS)", "")
                TOTALMTRS = dt.Compute("sum(MTRS)", "")
                SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, Range("15"))
                Write(dt.Compute("sum(MTRS)", ""), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, Range("13"))

                RowIndex += 1
                CONDITION = Replace(CONDITION, "MFGMASTER_DESC.MFG_DONE", "MFGMASTER.MFG_DONE")
                dt = objCMN.search("    ISNULL(ITEMMASTER.item_name, '') AS ITEMNAME, SUM(MFGMASTER_CONSUMED.MFG_ACTQTY) AS QTY,SUM(MFGMASTER_CONSUMED.MFG_ACTQTY)*ITEMMASTER_RATEDESC.ITEM_rate as RATE ", "", "    MFGMASTER INNER JOIN MFGMASTER_CONSUMED ON MFGMASTER.MFG_NO = MFGMASTER_CONSUMED.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_CONSUMED.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_CONSUMED.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_CONSUMED.MFG_YEARID INNER JOIN ITEMMASTER ON MFGMASTER_CONSUMED.MFG_ITEMID = ITEMMASTER.item_id AND MFGMASTER_CONSUMED.MFG_CMPID = ITEMMASTER.item_cmpid AND MFGMASTER_CONSUMED.MFG_LOCATIONID = ITEMMASTER.item_locationid AND MFGMASTER_CONSUMED.MFG_YEARID = ITEMMASTER.item_yearid INNER JOIN ITEMMASTER_RATEDESC ON ITEMMASTER.item_id = ITEMMASTER_RATEDESC.ITEM_ID AND ITEMMASTER.item_cmpid = ITEMMASTER_RATEDESC.ITEM_CMPID AND ITEMMASTER.item_locationid = ITEMMASTER_RATEDESC.ITEM_LOCATIONID AND ITEMMASTER.item_yearid = ITEMMASTER_RATEDESC.ITEM_YEARID INNER JOIN RATETYPEMASTER ON ITEMMASTER_RATEDESC.ITEM_RATETYPEID = RATETYPEMASTER.RATETYPE_id AND ITEMMASTER_RATEDESC.ITEM_CMPID = RATETYPEMASTER.RATETYPE_cmpid AND ITEMMASTER_RATEDESC.ITEM_LOCATIONID = RATETYPEMASTER.RATETYPE_locationid AND ITEMMASTER_RATEDESC.ITEM_YEARID = RATETYPEMASTER.RATETYPE_yearid LEFT OUTER JOIN PROCESSMASTER ON MFGMASTER.MFG_FROMPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PROCESSMASTER AS PROCESSMASTER_1 ON MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER_1.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER_1.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER_1.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER_1.PROCESS_YEARID LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid", whereclause & CONDITION & " GROUP BY ITEMMASTER.item_name,ITEMMASTER_RATEDESC.ITEM_rate ")
                If dt.Rows.Count > 0 Then
                    SetBorder(RowIndex, Range("1"), Range("8"))
                    RowIndex += 1

                    Write("ITEM NAME", Range("1"), XlHAlign.xlHAlignCenter, Range("5"), True, 10)
                    Write("QTY", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
                    Write("/PCS", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
                    Write("/WT", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                    Write("/MTRS", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
                    Write("AMT", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
                    SetBorder(RowIndex, Range("1"), Range("10"))
                End If
                SRNO = 0

                For Each dr As DataRow In dt.Select("")
                    RowIndex += 1
                    SRNO = SRNO + 1
                    Write(dr("ITEMNAME"), Range("1"), XlHAlign.xlHAlignLeft, Range("5"), False, 10)
                    Write(dr("QTY"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALPCS, "0.000"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALWT, "0.000"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALMTRS, "0.000"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("RATE"), "0.000"), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Next
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - SRNO - 1, Range("5"))
                SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex - SRNO - 1, Range("6"))
                SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex - SRNO - 1, Range("7"))
                SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex - SRNO - 1, Range("8"))
                SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex - SRNO - 1, Range("9"))
                SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex - SRNO - 1, Range("10"))

                RowIndex += 1
                Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("1"), True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("4"))


                Write(dt.Compute("sum(QTY)", ""), Range("6"), XlHAlign.xlHAlignRight, Range("6"), True, 10)
                SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, Range("6"))
                Write(dt.Compute("sum(RATE) ", ""), Range("10"), XlHAlign.xlHAlignRight, Range("10"), True, 10)
                SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, Range("10"))

                Write("Cost/Mtr ", Range("11"), XlHAlign.xlHAlignLeft, , True, 10)
                FORMULA("=(" & objColumn.Item("10").ToString & RowIndex & "/" & Val(TOTALMTRS) & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
                objSheet.Range(objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.000"


                'TOTAL NOT CONSUMPTION
                RowIndex += 2
                Write("PREVIOUS CONSUMPTION", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                dt = objCMN.search(" MFGMASTER.MFG_DATE AS DATE, MFGMASTER_DESC.MFG_LOTNO AS LOTNO, SUM(MFGMASTER_DESC.MFG_RECDMTRS) AS MTRS,  MFGMASTER.MFG_TOTALPCS AS PCS, SUM(MFGMASTER_DESC.MFG_WT) AS WT, QUALITYMASTER.QUALITY_name AS QUALITY, MFGMASTER.MFG_CMPID AS CMPID, MFGMASTER.MFG_LOCATIONID AS LOCATIONID, MFGMASTER.MFG_YEARID AS YEARID, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2 ", "", " CMPMASTER INNER JOIN MFGMASTER INNER JOIN MFGMASTER_DESC ON MFGMASTER.MFG_NO = MFGMASTER_DESC.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_DESC.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_DESC.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_DESC.MFG_YEARID ON CMPMASTER.cmp_id = MFGMASTER.MFG_CMPID LEFT OUTER JOIN PROCESSMASTER ON MFGMASTER.MFG_FROMPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PROCESSMASTER AS PROCESSMASTER_1 ON MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER_1.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER_1.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER_1.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER_1.PROCESS_YEARID LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid And MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid", whereclause & NOTCONDITION & " GROUP BY MFGMASTER_DESC.MFG_LOTNO, MFGMASTER.MFG_DATE, QUALITYMASTER.QUALITY_name, MFGMASTER.MFG_CMPID, MFGMASTER.MFG_LOCATIONID, MFGMASTER.MFG_YEARID, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2, MFGMASTER.MFG_TOTALPCS ")
                If dt.Rows.Count > 0 Then
                    TOTALWT = dt.Compute("sum(WT)", "")
                    TOTALPCS = dt.Compute("sum(PCS)", "")
                    TOTALMTRS = dt.Compute("sum(MTRS)", "")
                End If
                dt = objCMN.search("  ISNULL(ITEMMASTER.item_name,'') AS ITEMNAME, SUM(MFGMASTER_CONSUMED.MFG_ACTQTY) AS QTY ", "", "   MFGMASTER INNER JOIN MFGMASTER_CONSUMED ON MFGMASTER.MFG_NO = MFGMASTER_CONSUMED.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_CONSUMED.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_CONSUMED.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_CONSUMED.MFG_YEARID INNER JOIN ITEMMASTER ON MFGMASTER_CONSUMED.MFG_ITEMID = ITEMMASTER.item_id AND MFGMASTER_CONSUMED.MFG_CMPID = ITEMMASTER.item_cmpid AND MFGMASTER_CONSUMED.MFG_LOCATIONID = ITEMMASTER.item_locationid AND  MFGMASTER_CONSUMED.MFG_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PROCESSMASTER ON MFGMASTER.MFG_FROMPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PROCESSMASTER AS PROCESSMASTER_1 ON MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER_1.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER_1.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER_1.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER_1.PROCESS_YEARID LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid ", whereclause & NOTCONDITION & " GROUP BY ITEMMASTER.item_name ")
                If dt.Rows.Count > 0 Then
                    SetBorder(RowIndex, Range("1"), Range("8"))
                    RowIndex += 1

                    Write("ITEM NAME", Range("1"), XlHAlign.xlHAlignCenter, Range("5"), True, 10)
                    Write("QTY", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
                    Write("/PCS", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
                    Write("/WT", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                    Write("/MTRS", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
                    SetBorder(RowIndex, Range("1"), Range("9"))
                End If
                SRNO = 0

                For Each dr As DataRow In dt.Select("")
                    RowIndex += 1
                    SRNO = SRNO + 1
                    Write(dr("ITEMNAME"), Range("1"), XlHAlign.xlHAlignLeft, Range("5"), False, 10)
                    Write(dr("QTY"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALPCS, "0.000"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALWT, "0.000"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALMTRS, "0.000"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Next
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - SRNO - 1, Range("5"))
                SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex - SRNO - 1, Range("6"))
                SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex - SRNO - 1, Range("7"))
                SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex - SRNO - 1, Range("8"))
                SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex - SRNO - 1, Range("9"))




                'TOTAL CONSUMPTION
                RowIndex += 2
                Write("TILL DATE CONSUMPTION", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                dt = objCMN.search(" MFGMASTER.MFG_DATE AS DATE, MFGMASTER_DESC.MFG_LOTNO AS LOTNO, SUM(MFGMASTER_DESC.MFG_RECDMTRS) AS MTRS,  MFGMASTER.MFG_TOTALPCS AS PCS, SUM(MFGMASTER_DESC.MFG_WT) AS WT, QUALITYMASTER.QUALITY_name AS QUALITY, MFGMASTER.MFG_CMPID AS CMPID, MFGMASTER.MFG_LOCATIONID AS LOCATIONID, MFGMASTER.MFG_YEARID AS YEARID, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2 ", "", " CMPMASTER INNER JOIN MFGMASTER INNER JOIN MFGMASTER_DESC ON MFGMASTER.MFG_NO = MFGMASTER_DESC.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_DESC.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_DESC.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_DESC.MFG_YEARID ON CMPMASTER.cmp_id = MFGMASTER.MFG_CMPID LEFT OUTER JOIN PROCESSMASTER ON MFGMASTER.MFG_FROMPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PROCESSMASTER AS PROCESSMASTER_1 ON MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER_1.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER_1.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER_1.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER_1.PROCESS_YEARID LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid And MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid", whereclause & " GROUP BY MFGMASTER_DESC.MFG_LOTNO, MFGMASTER.MFG_DATE, QUALITYMASTER.QUALITY_name, MFGMASTER.MFG_CMPID, MFGMASTER.MFG_LOCATIONID, MFGMASTER.MFG_YEARID, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2, MFGMASTER.MFG_TOTALPCS ")
                If dt.Rows.Count > 0 Then
                    TOTALWT = dt.Compute("sum(WT)", "")
                    TOTALPCS = dt.Compute("sum(PCS)", "")
                    TOTALMTRS = dt.Compute("sum(MTRS)", "")
                End If
                dt = objCMN.search("  ITEMMASTER.item_name AS ITEMNAME, SUM(MFGMASTER_CONSUMED.MFG_ACTQTY) AS QTY ", "", "   MFGMASTER INNER JOIN MFGMASTER_CONSUMED ON MFGMASTER.MFG_NO = MFGMASTER_CONSUMED.MFG_NO AND MFGMASTER.MFG_CMPID = MFGMASTER_CONSUMED.MFG_CMPID AND MFGMASTER.MFG_LOCATIONID = MFGMASTER_CONSUMED.MFG_LOCATIONID AND MFGMASTER.MFG_YEARID = MFGMASTER_CONSUMED.MFG_YEARID INNER JOIN ITEMMASTER ON MFGMASTER_CONSUMED.MFG_ITEMID = ITEMMASTER.item_id AND MFGMASTER_CONSUMED.MFG_CMPID = ITEMMASTER.item_cmpid AND MFGMASTER_CONSUMED.MFG_LOCATIONID = ITEMMASTER.item_locationid AND  MFGMASTER_CONSUMED.MFG_YEARID = ITEMMASTER.item_yearid LEFT OUTER JOIN PROCESSMASTER ON MFGMASTER.MFG_FROMPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID LEFT OUTER JOIN PROCESSMASTER AS PROCESSMASTER_1 ON MFGMASTER.MFG_TOPROCESSID = PROCESSMASTER_1.PROCESS_ID AND MFGMASTER.MFG_CMPID = PROCESSMASTER_1.PROCESS_CMPID AND MFGMASTER.MFG_LOCATIONID = PROCESSMASTER_1.PROCESS_LOCATIONID AND MFGMASTER.MFG_YEARID = PROCESSMASTER_1.PROCESS_YEARID LEFT OUTER JOIN QUALITYMASTER ON MFGMASTER.MFG_QUALITYID = QUALITYMASTER.QUALITY_id AND MFGMASTER.MFG_CMPID = QUALITYMASTER.QUALITY_cmpid AND MFGMASTER.MFG_LOCATIONID = QUALITYMASTER.QUALITY_locationid AND MFGMASTER.MFG_YEARID = QUALITYMASTER.QUALITY_yearid ", whereclause & " GROUP BY ITEMMASTER.item_name ")
                If dt.Rows.Count > 0 Then
                    SetBorder(RowIndex, Range("1"), Range("8"))
                    RowIndex += 1

                    Write("ITEM NAME", Range("1"), XlHAlign.xlHAlignCenter, Range("5"), True, 10)
                    Write("QTY", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
                    Write("/PCS", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
                    Write("/WT", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                    Write("/MTRS", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
                    SetBorder(RowIndex, Range("1"), Range("9"))
                End If
                SRNO = 0

                For Each dr As DataRow In dt.Select("")
                    RowIndex += 1
                    SRNO = SRNO + 1
                    Write(dr("ITEMNAME"), Range("1"), XlHAlign.xlHAlignLeft, Range("5"), False, 10)
                    Write(dr("QTY"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALPCS, "0.000"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALWT, "0.000"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(Format(dr("QTY") / TOTALMTRS, "0.000"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Next
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - SRNO - 1, Range("5"))
                SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex - SRNO - 1, Range("6"))
                SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex - SRNO - 1, Range("7"))
                SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex - SRNO - 1, Range("8"))
                SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex - SRNO - 1, Range("9"))





                objSheet.Range(objColumn.Item("15").ToString & 1, objColumn.Item("15").ToString & RowIndex).Font.Size = 10
                objSheet.Range(objColumn.Item("15").ToString & 1, objColumn.Item("15").ToString & RowIndex).NumberFormat = "0.00"

                objBook.Application.ActiveWindow.Zoom = 85

                'With objSheet.PageSetup
                '    .Orientation = XlPageOrientation.xlPortrait
                '    .TopMargin = 20
                '    .LeftMargin = 10
                '    .RightMargin = 5
                '    .BottomMargin = 0
                '    .Zoom = False
                '    .FitToPagesTall = 100
                '    .FitToPagesWide = 1
                'End With

                SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("15").ToString & RowIndex + 2)
                'objSheet.Protect("infosys123")
                SaveAndClose()
            Else
                MsgBox("No Record Found")
            End If


        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

    Public Function MFG_CONTRACTORBILL_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, CONTRACTORNAME As String, WHERECLAUSE As String) As Object
        Try
            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next



            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("4"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("4"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("4"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("4"))

            RowIndex += 1
            Write("BILL FROM (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("4"))

            RowIndex += 1
            Write(CONTRACTORNAME, Range("1"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("4"))


            RowIndex += 1
            Write("COLOURS", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("MTRS", Range("2"), XlHAlign.xlHAlignCenter, Range("2"), True, 10)
            Write("RATE", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 10)
            Write("AMOUNT", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("4").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("4").ToString & 8).Application.ActiveWindow.FreezePanes = True


            'COLOR RATE
            DT = OBJCMN.search(" COLORS, MTRS, RATE, ROUND((RATE * MTRS),2) AS AMT", "", " (SELECT COLORRATEMASTER.CR_NO AS COLORS, SUM(MFGMASTER2_DESC.MFG_RECDMTRS) AS MTRS, COLORRATEMASTER.CR_RATE AS RATE FROM MFGMASTER2 INNER JOIN MFGMASTER2_DESC ON MFGMASTER2.MFG_YEARID = MFGMASTER2_DESC.MFG_YEARID AND MFGMASTER2.MFG_NO = MFGMASTER2_DESC.MFG_NO INNER JOIN CONTRACTORMASTER ON MFGMASTER2_DESC.MFG_CONTRACTORID = CONTRACTORMASTER.CONTRACTOR_id INNER JOIN COLORRATEMASTER ON MFGMASTER2.MFG_COLORS = COLORRATEMASTER.CR_NO AND MFGMASTER2.MFG_TOPROCESSID = COLORRATEMASTER.CR_PROCESSID AND MFGMASTER2.MFG_YEARID = COLORRATEMASTER.CR_yearid INNER JOIN PROCESSMASTER ON MFGMASTER2.MFG_TOPROCESSID = PROCESSMASTER.PROCESS_ID WHERE MFGMASTER2.MFG_YEARID = " & YEARID & " AND CONTRACTORMASTER.CONTRACTOR_NAME = '" & CONTRACTORNAME & "'  " & WHERECLAUSE & " GROUP BY COLORRATEMASTER.CR_NO, COLORRATEMASTER.CR_RATE) AS T  ", " ORDER BY COLORS")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(Val(DTROW("COLORS")), Range("1"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("MTRS")), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("RATE")), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("AMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
            Next


            'CLOSING
            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("2").ToString & 8 & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 8 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            objSheet.Range(Range("1"), Range("4")).Interior.Color = RGB(255, 165, 0)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)


            Dim COLORTOTAL As Integer = RowIndex

            'WORKER RATE
            RowIndex += 1
            DT = OBJCMN.search(" WORKER, MTRS, RATE, ROUND((RATE * MTRS),2) AS AMT", "", " (SELECT CONTRACTORWORKERRATE.CR_WORKER AS WORKER, SUM(MFGMASTER2_DESC.MFG_RECDMTRS) AS MTRS, CONTRACTORWORKERRATE.CR_RATE AS RATE FROM MFGMASTER2 INNER JOIN MFGMASTER2_DESC ON MFGMASTER2.MFG_YEARID = MFGMASTER2_DESC.MFG_YEARID AND MFGMASTER2.MFG_NO = MFGMASTER2_DESC.MFG_NO INNER JOIN CONTRACTORMASTER ON MFGMASTER2_DESC.MFG_CONTRACTORID = CONTRACTORMASTER.CONTRACTOR_id INNER JOIN CONTRACTORWORKERRATE ON MFGMASTER2.MFG_WORKER = CONTRACTORWORKERRATE.CR_WORKER AND MFGMASTER2.MFG_TOPROCESSID = CONTRACTORWORKERRATE.CR_PROCESSID AND MFGMASTER2.MFG_YEARID = CONTRACTORWORKERRATE.CR_yearid INNER JOIN PROCESSMASTER ON MFGMASTER2.MFG_TOPROCESSID = PROCESSMASTER.PROCESS_ID WHERE MFGMASTER2.MFG_YEARID = " & YEARID & " AND CONTRACTORMASTER.CONTRACTOR_NAME = '" & CONTRACTORNAME & "'  " & WHERECLAUSE & " GROUP BY CONTRACTORWORKERRATE.CR_WORKER, CONTRACTORWORKERRATE.CR_RATE) AS T  ", " ORDER BY WORKER")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(Val(DTROW("WORKER")), Range("1"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("MTRS")), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("RATE")), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("AMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            'WORKER RATE TOTAL
            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("2").ToString & COLORTOTAL + 1 & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & COLORTOTAL + 1 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            objSheet.Range(Range("1"), Range("4")).Interior.Color = RGB(255, 165, 0)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)



            'DAYS
            RowIndex += 1
            DT = OBJCMN.search(" DISTINCT COUNT(MFG_DATE) AS TOTALDAYS, 100 AS RATE", "", " MFGMASTER2 INNER JOIN MFGMASTER2_DESC ON MFGMASTER2.MFG_YEARID = MFGMASTER2_DESC.MFG_YEARID AND MFGMASTER2.MFG_NO = MFGMASTER2_DESC.MFG_NO INNER JOIN CONTRACTORMASTER ON MFGMASTER2_DESC.MFG_CONTRACTORID = CONTRACTORMASTER.CONTRACTOR_id INNER JOIN CONTRACTORWORKERRATE ON MFGMASTER2.MFG_WORKER = CONTRACTORWORKERRATE.CR_WORKER AND MFGMASTER2.MFG_TOPROCESSID = CONTRACTORWORKERRATE.CR_PROCESSID AND MFGMASTER2.MFG_YEARID = CONTRACTORWORKERRATE.CR_yearid INNER JOIN PROCESSMASTER ON MFGMASTER2.MFG_TOPROCESSID = PROCESSMASTER.PROCESS_ID ", " AND MFGMASTER2.MFG_YEARID = " & YEARID & " AND CONTRACTORMASTER.CONTRACTOR_NAME = '" & CONTRACTORNAME & "'  " & WHERECLAUSE)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write("DAYS", Range("1"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TOTALDAYS")), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("RATE")), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TOTALDAYS")) * Val(DTROW("RATE")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
            Next


            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("2").ToString & COLORTOTAL - 1 & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & COLORTOTAL - 1 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            objSheet.Range(Range("1"), Range("4")).Interior.Color = RGB(255, 165, 0)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)



            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#Region "PURCHASE REQUEST REPORT"

    Public Function RPT_PR_Report(ByVal PREQNO As Integer, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer, ByVal CONDITION As String, ByVal ISGREY As Boolean) As Object
        Try
            Dim objCMN As New ClsCommon
            Dim OBJPURREQ As New ClsPurchaseRequest

            ALPARAVAL.Add(PREQNO)
            ALPARAVAL.Add(CMPID)
            ALPARAVAL.Add(LOCATIONID)
            ALPARAVAL.Add(YEARID)
            OBJPURREQ.alParaval = ALPARAVAL

            Dim dT As System.Data.DataTable = OBJPURREQ.selectPURREQ
            Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_DISPLAYEDNAME AS CMPNAME, CMP_ADD1 AS ADDRESS1, CMP_ADD2 AS ADDRESS2 ", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 6)
            Next

            SetColumnWidth("Q1", 7)
            SetColumnWidth("S1", 7)
            SetColumnWidth("T1", 10)


            '''''''''''Report Title
            'CMPNAME
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("20"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("20"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADDRESS1"), Range("1"), XlHAlign.xlHAlignCenter, Range("20"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("20"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADDRESS2"), Range("1"), XlHAlign.xlHAlignCenter, Range("20"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("20"))

            RowIndex += 1
            Write("PURCHASE REQUEST", Range("1"), XlHAlign.xlHAlignCenter, Range("20"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("20"))


            RowIndex += 1
            Write("Request No:" & "     ", Range("1"), XlHAlign.xlHAlignLeft, Range("2"), True, 10)
            Write("PREQ - " & dT.Rows(0).Item("REQNO"), Range("3"), XlHAlign.xlHAlignLeft, Range("8"), False, 10)
            Write(dT.Rows(0).Item("REQNO"), Range("21"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Request By:" & "     ", Range("14"), XlHAlign.xlHAlignLeft, Range("15"), True, 10)
            Write(dT.Rows(0).Item("REQUESTBY"), Range("16"), XlHAlign.xlHAlignLeft, Range("20"), False, 10)


            RowIndex += 1
            Write("Request Date:", Range("1"), XlHAlign.xlHAlignLeft, Range("2"), True, 10)
            Write(dT.Rows(0).Item("REQDATE"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
            Write("Deaprtment:" & "     ", Range("14"), XlHAlign.xlHAlignLeft, Range("15"), True, 10)
            Write(dT.Rows(0).Item("department"), Range("16"), XlHAlign.xlHAlignLeft, Range("20"), False, 10)

            RowIndex += 1
            Write("Valid Till:", Range("1"), XlHAlign.xlHAlignLeft, Range("2"), True, 10)
            Write(dT.Rows(0).Item("VALIDDATE"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - 2, Range("20"))

            RowIndex += 2
            Write("Please send the Quotation for the below listed Items", Range("1"), XlHAlign.xlHAlignLeft, Range("14"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("20"))

            RowIndex += 2
            Write("Sr.", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Item Name", Range("2"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            Write("Description", Range("7"), XlHAlign.xlHAlignCenter, Range("11"), True, 10)
            Write("Quality", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Reed", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Pick", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Color", Range("15"), XlHAlign.xlHAlignCenter, Range("16"), True, 10)
            Write("Qty", Range("17"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Unit", Range("18"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("19"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Amt.", Range("20"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("20"))

            Dim SRNO As Integer = 0
            For Each dr As DataRow In dT.Select(CONDITION)
                RowIndex += 1
                SRNO = SRNO + 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignCenter, , False, 10)
                Write(dr("ITEMNAME"), Range("2"), XlHAlign.xlHAlignLeft, Range("6"), False, 10)
                Write(dr("DESC"), Range("7"), XlHAlign.xlHAlignLeft, Range("11"), False, 10)
                Write(dr("QUALITY"), Range("12"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(dr("REED"), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("PICK"), Range("14"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("COLOR"), Range("15"), XlHAlign.xlHAlignLeft, Range("16"), False, 10)
                Write(Format(dr("QTY"), "0.00"), Range("17"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("QTYUNIT"), Range("18"), XlHAlign.xlHAlignLeft, , False, 10)
                LOCKCELLS(False, Range("19"))
                FORMULA("=" & objColumn.Item("17").ToString & RowIndex & "*" & objColumn.Item("19").ToString & RowIndex, Range("20"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("GRIDSRNO"), Range("21"), XlHAlign.xlHAlignRight, , False, 10)
            Next


            'IF GRWY MATERIAL THEN NO NEED OF THESE COLUMS
            If ISGREY = False Then
                SetColumnWidth(Range("12"), 0)
                SetColumnWidth(Range("13"), 0)
                SetColumnWidth(Range("14"), 0)
                SetColumnWidth(Range("15"), 0)
                SetColumnWidth(Range("16"), 0)
            End If

            'writing no or rows in U7
            Write(RowIndex - 12, objColumn.Item("21").ToString & 7, XlHAlign.xlHAlignLeft, , False, 10)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - SRNO, Range("1"))
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex - SRNO, Range("6"))
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex - SRNO, Range("11"))
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex - SRNO, Range("12"))
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex - SRNO, Range("13"))
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex - SRNO, Range("14"))
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex - SRNO, Range("15"))
            SetBorder(RowIndex, objColumn.Item("16").ToString & RowIndex - SRNO, Range("16"))
            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex - SRNO, Range("17"))
            SetBorder(RowIndex, objColumn.Item("18").ToString & RowIndex - SRNO, Range("18"))
            SetBorder(RowIndex, objColumn.Item("19").ToString & RowIndex - SRNO, Range("19"))
            SetBorder(RowIndex, objColumn.Item("20").ToString & RowIndex - SRNO, Range("20"))

            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("16"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("16"))
            'Write(dT.Compute("sum(qty)", ""), Range("17"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("17").ToString & RowIndex - dT.Rows.Count & ":" & objColumn.Item("17").ToString & RowIndex - 1 & ")", Range("17"), XlHAlign.xlHAlignRight, , True, 10)

            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex, Range("17"))
            SetBorder(RowIndex, objColumn.Item("18").ToString & RowIndex, Range("19"))
            'FORMULA("=SUM(" & objColumn.Item("19").ToString & RowIndex - dT.Rows.Count & ":" & objColumn.Item("19").ToString & RowIndex - 1 & ")", Range("19"), XlHAlign.xlHAlignRight, , True, 10)
            'SetBorder(RowIndex, objColumn.Item("19").ToString & RowIndex, Range("19"))
            FORMULA("=SUM(" & objColumn.Item("20").ToString & RowIndex - dT.Rows.Count & ":" & objColumn.Item("20").ToString & RowIndex - 1 & ")", Range("20"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("20").ToString & RowIndex, Range("20"))


            RowIndex += 1
            Write("Remarks", Range("1"), XlHAlign.xlHAlignLeft, Range("20"), True, 10)

            RowIndex += 1
            Write(Replace(dT.Rows(0).Item("REMARKS"), vbCrLf, "         "), Range("1"), XlHAlign.xlHAlignLeft, Range("20"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("20"))

            RowIndex += 2
            Write("User Description :", Range("1"), XlHAlign.xlHAlignLeft, Range("20"), True, 10)

            RowIndex += 1
            Write("", Range("1"), XlHAlign.xlHAlignLeft, Range("20"), True, 10)
            LOCKCELLS(False, Range("1"), Range("20"))


            RowIndex += 2
            Write("Note : Please fill your Rates for each mentioned Item in Rate Column and specify Special Notes in User Description Part", Range("1"), XlHAlign.xlHAlignLeft, Range("20"), True, 10)

            objSheet.Range(objColumn.Item("19").ToString & 1, objColumn.Item("19").ToString & RowIndex).Font.Size = 10
            objSheet.Range(objColumn.Item("19").ToString & 1, objColumn.Item("19").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("20").ToString & 1, objColumn.Item("20").ToString & RowIndex).NumberFormat = "0.00"

            'VISIBILITY FALSE
            SetColumnWidth(Range("21"), 0)



            'With objSheet.PageSetup
            '    .TopMargin = 144
            '    .LeftMargin = 50.4
            '    .RightMargin = 0
            '    .BottomMargin = 0
            '    .Zoom = False
            '    .FitToPagesTall = 1
            '    .FitToPagesWide = 1
            'End With

            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("20").ToString & RowIndex + 2)
            objSheet.Protect("infosys123")
            SaveAndClose()


        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing

    End Function

#End Region

#Region "DETAILS REPORT"

    Public Function DETAILS(ByRef dt As System.Data.DataTable, ByRef dt1 As System.Data.DataTable, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer, ByVal CONDITION As String, ByVal FORM As String) As Object
        Try
            Dim objCMN As New ClsCommon
            Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_DISPLAYEDNAME AS CMPNAME, CMP_ADD1 AS ADDRESS1, CMP_ADD2 AS ADDRESS2 ", "", " CMPMASTER", " AND CMP_ID = " & CMPID)
            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next

            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 9)
            Next

            SetColumnWidth("Q1", 7)
            SetColumnWidth("S1", 7)
            SetColumnWidth("T1", 10)


            '''''''''''Report Title
            'CMPNAME
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("20"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("20"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADDRESS1"), Range("1"), XlHAlign.xlHAlignCenter, Range("20"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("20"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADDRESS2"), Range("1"), XlHAlign.xlHAlignCenter, Range("20"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("20"))

            RowIndex += 1
            Write(FORM, Range("1"), XlHAlign.xlHAlignCenter, Range("20"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("20"))

            RowIndex += 2
            Dim rge As Integer = 0
            For j = 0 To dt1.Rows.Count - 1
                rge = rge + dt1.Rows(j).Item(2)
                If dt1.Rows(j).Item(2) > 0 Then
                    If dt1.Rows(j).Item(2) = 1 Then
                        Write(dt1.Rows(j).Item(1), Range(rge), XlHAlign.xlHAlignCenter, , True, 10)
                    Else
                        Write(dt1.Rows(j).Item(1), Range(rge - Val(dt1.Rows(j).Item(2)) + 1), XlHAlign.xlHAlignCenter, Range(rge), True, 10)

                    End If
                End If
            Next
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("20"))


            For I = 0 To dt.Rows.Count - 1
                RowIndex += 1
                rge = 0
                For j = 0 To dt1.Rows.Count - 1
                    If dt1.Rows(j).Item(2) > 0 Then
                        'Write(dt.Rows(i).Item(j), Range(j), XlHAlign.xlHAlignCenter, , False, 10)
                        rge = rge + dt1.Rows(j).Item(2)
                        If dt1.Rows(j).Item(2) = 1 Then
                            Write(dt.Rows(I).Item(j), Range(rge), XlHAlign.xlHAlignCenter, , False, 10)
                        Else
                            Write(dt.Rows(I).Item(j), Range(rge - Val(dt1.Rows(j).Item(2)) + 1), XlHAlign.xlHAlignCenter, Range(rge), False, 10)

                        End If
                    End If
                Next
            Next



            'writing no or rows in U7
            Write(RowIndex - 12, objColumn.Item("21").ToString & 7, XlHAlign.xlHAlignLeft, , False, 10)


            'VISIBILITY FALSE
            SetColumnWidth(Range("21"), 0)



            'With objSheet.PageSetup
            '    .TopMargin = 144
            '    .LeftMargin = 50.4
            '    .RightMargin = 0
            '    .BottomMargin = 0
            '    .Zoom = False
            '    .FitToPagesTall = 100
            '    .FitToPagesWide = 1
            'End With

            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("20").ToString & RowIndex + 2)
            objSheet.Protect("infosys123")
            SaveAndClose()


        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing

    End Function

#End Region

#Region "EXPENSE REPORT"

    Public Function EXPENSE_REPORT_EXCEL(ByVal DT As System.Data.DataTable, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer, Optional ByVal HEADER As String = "", Optional ByVal CONDITION As String = "") As Object
        Try

            Dim objCMN As New ClsCommon
            Dim LASTROW As Integer = 1
            Dim GMTRSTOTAL As Double = 0.0
            If DT.Rows.Count > 0 Then


                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next

                For I As Integer = 27 To 50
                    SetColumn(I, "A" & Chr(64 + (I - 26)))
                Next

                RowIndex = 1
                For i As Integer = 1 To 50
                    SetColumnWidth(Range(i), 12)
                Next
                SetColumnWidth(Range(1), 18)

                Dim T As Integer = 2    'FOR TOTAL COLUMS COUNT

                'FOR EXPENSENAME
                'Dim DTEXP As System.Data.DataTable = objCMN.search(" EXP_NAME AS EXPNAME", "", " EXPENSEMASTER ", " AND EXP_ID IN (SELECT EXP_ID FROM EXPENSE_DESC WHERE EXP_CMPID = " & CMPID & " AND EXP_LOCATIONID = " & LOCATIONID & " AND EXP_YEARID = " & YEARID & ") AND EXP_CMPID = " & CMPID & " AND EXP_LOCATIONID = " & LOCATIONID & " AND EXP_YEARID = " & YEARID)
                Dim DTEXP As System.Data.DataTable = objCMN.search(" ISNULL(EXP_NAME,'') AS EXPNAME", "", " EXPENSEMASTER ", " AND EXP_YEARID = " & YEARID)
                If DTEXP.Rows.Count > 0 Then

                    'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
                    'COZ HERE WE DONT KNOW NO OF COLUMS
                    RowIndex += 5
                    Write("Merchant", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                    For Each DREXP As DataRow In DTEXP.Rows
                        Write(DREXP("EXPNAME"), Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                        T = T + 1
                    Next
                    Write("Total", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(T.ToString).ToString & RowIndex)

                End If

                SetColumnWidth(Range((T + 1).ToString), 0)

                'GET DISTINCT PROCESS NAME 
                Dim DV As DataView = DT.DefaultView
                Dim NEWDT As System.Data.DataTable = DV.ToTable(True, "PROCESS")
                For Each DTR As DataRow In NEWDT.Rows

                    RowIndex += 1
                    Write(DTR("PROCESS"), Range("1"), XlHAlign.xlHAlignCenter, , True, 10)


                    Dim MERCHANTNAME As New ArrayList

                    'GET MERCHANT IN THAT PROCESS
                    Dim MNAME As String = ""
                    For Each ITEMDR As System.Data.DataRow In DT.Select("PROCESS = '" & DTR("PROCESS") & "'")

                        If MERCHANTNAME.Contains(ITEMDR("MERCHANT")) = False Then
                            'GET TOTAL PRODUCTION DONE IN THAT PROESS FOR PARTICULAR MERCHANT
                            Dim MTRSDT As System.Data.DataTable = objCMN.search(" SUM(TOTALMTRS) AS TOTALMTRS, PROCESS, MERCHANT, CMPID, LOCATIONID, YEARID ", "", " (SELECT SUM(FINALPACKINGSLIP.FPS_TOTALMTRS) AS TOTALMTRS, 'JOB IN' AS PROCESS, ITEMMASTER.item_name AS MERCHANT, FINALPACKINGSLIP.FPS_DATE AS DATE, FINALPACKINGSLIP.FPS_CMPID AS CMPID, FINALPACKINGSLIP.FPS_LOCATIONID AS LOCATIONID, FINALPACKINGSLIP.FPS_YEARID AS YEARID FROM  FINALPACKINGSLIP INNER JOIN PROCESSMASTER ON FINALPACKINGSLIP.FPS_PROCESSID = PROCESSMASTER.PROCESS_ID AND FINALPACKINGSLIP.FPS_CMPID = PROCESSMASTER.PROCESS_CMPID AND FINALPACKINGSLIP.FPS_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND FINALPACKINGSLIP.FPS_YEARID = PROCESSMASTER.PROCESS_YEARID INNER JOIN ITEMMASTER ON FINALPACKINGSLIP.FPS_MERCHANTID = ITEMMASTER.item_id AND FINALPACKINGSLIP.FPS_CMPID = ITEMMASTER.item_cmpid AND FINALPACKINGSLIP.FPS_LOCATIONID = ITEMMASTER.item_locationid And FINALPACKINGSLIP.FPS_YEARID = ITEMMASTER.item_yearid WHERE (PROCESSMASTER.PROCESS_NAME = 'FINAL CUTTING') AND (FINALPACKINGSLIP.FPS_EXPENSEREPORT = 1) GROUP BY PROCESSMASTER.PROCESS_NAME, ITEMMASTER.item_name, FINALPACKINGSLIP.FPS_DATE, FINALPACKINGSLIP.FPS_CMPID, FINALPACKINGSLIP.FPS_LOCATIONID, FINALPACKINGSLIP.FPS_YEARID UNION ALL SELECT SUM(PACKINGSLIP_JOB.PS_TOTALMTRS) AS TOTALMTRS, 'JOB OUT (EMB)' AS PROCESS, ITEMMASTER.item_name AS MERCHANT, PACKINGSLIP_JOB.PS_DATE AS DATE, PACKINGSLIP_JOB.PS_CMPID AS CMPID, PACKINGSLIP_JOB.PS_LOCATIONID AS LOCATIONID, PACKINGSLIP_JOB.PS_YEARID AS YEARID FROM  PACKINGSLIP_JOB INNER JOIN PROCESSMASTER ON PACKINGSLIP_JOB.PS_PROCESSID = PROCESSMASTER.PROCESS_ID AND PACKINGSLIP_JOB.PS_CMPID = PROCESSMASTER.PROCESS_CMPID AND PACKINGSLIP_JOB.PS_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND PACKINGSLIP_JOB.PS_YEARID = PROCESSMASTER.PROCESS_YEARID INNER JOIN ITEMMASTER ON PACKINGSLIP_JOB.PS_ITEMID = ITEMMASTER.item_id WHERE (PACKINGSLIP_JOB.PS_EXPENSEREPORT = 1) GROUP BY PROCESSMASTER.PROCESS_NAME, ITEMMASTER.item_name, PACKINGSLIP_JOB.PS_DATE, PACKINGSLIP_JOB.PS_CMPID, PACKINGSLIP_JOB.PS_LOCATIONID, PACKINGSLIP_JOB.PS_YEARID UNION ALL SELECT     SUM(FINALPACKINGSLIP.FPS_TOTALMTRS) AS TOTALMTRS, 'LUMP FINISH' AS PROCESS, ITEMMASTER.ITEM_name AS MERCHANT, FINALPACKINGSLIP.FPS_DATE AS DATE, FINALPACKINGSLIP.FPS_CMPID AS CMPID, FINALPACKINGSLIP.FPS_LOCATIONID AS LOCATIONID, FINALPACKINGSLIP.FPS_YEARID AS YEARID FROM FINALPACKINGSLIP INNER JOIN PROCESSMASTER ON FINALPACKINGSLIP.FPS_PROCESSID = PROCESSMASTER.PROCESS_ID AND FINALPACKINGSLIP.FPS_CMPID = PROCESSMASTER.PROCESS_CMPID AND FINALPACKINGSLIP.FPS_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND FINALPACKINGSLIP.FPS_YEARID = PROCESSMASTER.PROCESS_YEARID INNER JOIN ITEMMASTER ON FINALPACKINGSLIP.FPS_MERCHANTID= ITEMMASTER.ITEM_id AND FINALPACKINGSLIP.FPS_CMPID = ITEMMASTER.ITEM_cmpid AND FINALPACKINGSLIP.FPS_LOCATIONID = ITEMMASTER.ITEM_locationid And FINALPACKINGSLIP.FPS_YEARID = ITEMMASTER.ITEM_yearid WHERE PROCESS_NAME = 'WHITE FOLDING' GROUP BY PROCESSMASTER.PROCESS_NAME, ITEMMASTER.ITEM_name, FINALPACKINGSLIP.FPS_DATE, FINALPACKINGSLIP.FPS_CMPID, FINALPACKINGSLIP.FPS_LOCATIONID, FINALPACKINGSLIP.FPS_YEARID  UNION ALL SELECT SUM(MFGMASTER2.MFG_TOTALRECDMTRS) AS TOTALMTRS, PROCESSMASTER.PROCESS_NAME AS PROCESS, ITEMMASTER.item_name AS MERCHANT, MFGMASTER2.MFG_DATE AS DATE, MFG_CMPID AS CMPID, MFG_LOCATIONID AS LOCATIONID, MFG_YEARID  AS YEARID FROM MFGMASTER2 INNER JOIN PROCESSMASTER ON MFGMASTER2.MFG_TOPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER2.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER2.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER2.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID INNER JOIN ITEMMASTER ON MFGMASTER2.MFG_MERCHANTID = ITEMMASTER.item_id AND MFGMASTER2.MFG_CMPID = ITEMMASTER.item_cmpid AND MFGMASTER2.MFG_LOCATIONID = ITEMMASTER.item_locationid AND MFGMASTER2.MFG_YEARID = ITEMMASTER.item_yearid GROUP BY PROCESSMASTER.PROCESS_NAME , ITEMMASTER.item_name , MFGMASTER2.MFG_DATE, MFG_CMPID , MFG_LOCATIONID , MFG_YEARID UNION ALL SELECT SUM(MFGMASTER.MFG_TOTALMTRS) AS TOTALMTRS, 'DYEING' AS PROCESS, ITEMMASTER.item_name AS MERCHANT, MFGMASTER.MFG_DATE AS DATE, MFGMASTER.MFG_CMPID AS CMPID, MFGMASTER.MFG_LOCATIONID AS LOCATIONID, MFGMASTER.MFG_YEARID AS YEARID  FROM  MFGMASTER INNER JOIN PROCESSMASTER ON MFGMASTER.MFG_TOPROCESSID= PROCESSMASTER.PROCESS_ID  INNER JOIN ITEMMASTER ON MFGMASTER.MFG_MERCHANTID = ITEMMASTER.item_id INNER JOIN EXPENSE_DESC ON EXP_QUALITYID = MFG_MERCHANTID AND EXP_PROCESSID = MFG_TOPROCESSID WHERE (PROCESSMASTER.PROCESS_NAME = 'DYEING')  GROUP BY PROCESSMASTER.PROCESS_NAME, ITEMMASTER.item_name, MFGMASTER.MFG_DATE, MFGMASTER.MFG_CMPID, MFGMASTER.MFG_LOCATIONID, MFGMASTER.MFG_YEARID) AS T ", CONDITION & " AND T.PROCESS = '" & DTR("PROCESS") & "' AND T.MERCHANT = '" & ITEMDR("MERCHANT") & "' AND T.CMPID = " & CMPID & " AND T.LOCATIONID = " & LOCATIONID & " AND T.YEARID = " & YEARID & " GROUP BY PROCESS, MERCHANT, CMPID, LOCATIONID, YEARID ORDER BY T.PROCESS, T.MERCHANT ")
                            For Each MTRSDR As System.Data.DataRow In MTRSDT.Rows

                                'objSheet.Rows(RowIndex, 1).HEIGHT = 5

                                RowIndex += 1
                                Write(ITEMDR("MERCHANT"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                                FORMULA("=ROUND(SUM(" & objColumn.Item("2").ToString & RowIndex & ":" & objColumn.Item((T - 1).ToString).ToString & RowIndex & "),2)", Range(T.ToString), XlHAlign.xlHAlignRight, , True, 9)

                                RowIndex += 1
                                Write(MTRSDR("TOTALMTRS"), Range("1"), XlHAlign.xlHAlignRight, , False, 9)

                                'FOR GRANDTOTAL
                                GMTRSTOTAL = GMTRSTOTAL + Val(MTRSDR("TOTALMTRS"))

                                'TOTAL
                                FORMULA("=ROUND(SUM(" & objColumn.Item("2").ToString & RowIndex & ":" & objColumn.Item((T - 1).ToString).ToString & RowIndex & "),2)", Range(T.ToString), XlHAlign.xlHAlignRight, , True, 9)

                                'WRITTEN TO GIVE CONDTION ON TOTAL
                                'DO NOT DELETE DONE BY GULKIT
                                Write(DTR("PROCESS"), Range((T + 1).ToString), XlHAlign.xlHAlignLeft, , False, 9)


                                LASTROW = RowIndex

                                RowIndex -= 1
                                'ADD IN EXPENSE COLUMN
                                'FIRST SEACH THE COLUMN (MATCH IT WITH THE EXPENSE NAME IN DT)
                                For I As Integer = 2 To T - 1
                                    If objSheet.Cells(6, I).VALUE.ToString = ITEMDR("EXPENSENAME") Then
                                        Write(ITEMDR("RATE"), Range(I.ToString), XlHAlign.xlHAlignRight, , False, 9)
                                        RowIndex += 1
                                        Write(ITEMDR("RATE") * Val(MTRSDR("TOTALMTRS")), Range(I.ToString), XlHAlign.xlHAlignRight, , False, 9)
                                    End If
                                Next

                                RowIndex = LASTROW
                                MERCHANTNAME.Add(ITEMDR("MERCHANT"))
                                SetBorder(RowIndex - 1, objColumn.Item("1").ToString & RowIndex - 1, objColumn.Item(T.ToString).ToString & RowIndex)
                            Next
                        Else
                            LASTROW = RowIndex
                            RowIndex -= 1
                            'ADD IN EXPENSE COLUMN
                            'FIRST SEACH THE COLUMN (MATCH IT WITH THE EXPENSE NAME IN DT)
                            For I As Integer = 2 To T - 1
                                If objSheet.Cells(RowIndex, I).VALUE = Nothing Then Write("0", Range(I.ToString), XlHAlign.xlHAlignRight, , False, 9)
                                If objSheet.Cells(6, I).VALUE.ToString = ITEMDR("EXPENSENAME") Then
                                    Write(ITEMDR("RATE"), Range(I.ToString), XlHAlign.xlHAlignRight, , False, 9)
                                End If
                            Next
                            RowIndex = LASTROW
                            For I As Integer = 2 To T - 1
                                Write(Val(objSheet.Cells(RowIndex - 1, I).VALUE) * Val(objSheet.Cells(RowIndex, 1).VALUE), Range(I.ToString), XlHAlign.xlHAlignRight, , False, 9)
                            Next
                            MNAME = ITEMDR("MERCHANT")

                        End If

                    Next

                    RowIndex += 1

                    Write("Total", Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    For I As Integer = 1 To T
                        FORMULA("=SUMIFS(" & objColumn.Item(I.ToString).ToString & 7 & ":" & objColumn.Item(I.ToString).ToString & RowIndex - 1 & "," & objColumn.Item((T + 1).ToString).ToString & 7 & ":" & objColumn.Item((T + 1).ToString).ToString & RowIndex - 1 & ",""=" & DTR("PROCESS") & """)", Range(I.ToString), XlHAlign.xlHAlignRight, , True, 9)
                    Next
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(T.ToString).ToString & RowIndex)
                    RowIndex += 1

                Next


                Write("Grand Total     : " & Format(Val(GMTRSTOTAL), "0.00"), Range("1"), XlHAlign.xlHAlignRight, , True, 9)
                For I As Integer = 2 To T
                    FORMULA("=SUMIFS(" & objColumn.Item(I.ToString).ToString & 7 & ":" & objColumn.Item(I.ToString).ToString & RowIndex - 2 & "," & objColumn.Item((T + 1).ToString).ToString & 7 & ":" & objColumn.Item((T + 1).ToString).ToString & RowIndex - 2 & ",""<>"")", Range(I.ToString), XlHAlign.xlHAlignRight, , True, 9)
                Next
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(T.ToString).ToString & RowIndex)


                objSheet.Range(objColumn.Item((T - 1).ToString).ToString & 1, objColumn.Item((T - 1).ToString).ToString & LASTROW).NumberFormat = "0.00"


                LASTROW = RowIndex




                '''''''''''Report Title
                'CMPNAME

                RowIndex = 2
                Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(T.ToString), True, 14)
                SetBorder(RowIndex, Range("1"), Range(T.ToString))

                'ADD1
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(T.ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(T.ToString))

                'ADD2
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(T.ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(T.ToString))


                RowIndex += 1
                Write(HEADER, Range("1"), XlHAlign.xlHAlignCenter, Range(T.ToString), True, 12)
                SetBorder(RowIndex, Range("1"), Range(T.ToString))



                'FREEZE TOP 6 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 7, objColumn.Item(T.ToString).ToString & 7).Select()
                objSheet.Range(objColumn.Item("1").ToString & 7, objColumn.Item(T.ToString).ToString & 7).Application.ActiveWindow.FreezePanes = True

                'FREEZE 1ST COLUMN
                objSheet.Range(objColumn.Item("1").ToString & 1, objColumn.Item("1").ToString & LASTROW).Select()
                objSheet.Range(objColumn.Item("1").ToString & 1, objColumn.Item("1").ToString & 200).Application.ActiveWindow.FreezePanes = True


                objBook.Application.ActiveWindow.Zoom = 100

                'With objSheet.PageSetup
                '    .Orientation = XlPageOrientation.xlLandscape
                '    '.TopMargin = 144
                '    '.LeftMargin = 50.4
                '    '.RightMargin = 0
                '    '.BottomMargin = 0
                '    '.Zoom = False
                '    '.FitToPagesTall = 1
                '    '.FitToPagesWide = 1
                'End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function EXPENSESUMMARY_REPORT_EXCEL(ByVal DT As System.Data.DataTable, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer, Optional ByVal HEADER As String = "", Optional ByVal CONDITION As String = "") As Object
        Try

            Dim objCMN As New ClsCommon
            Dim LASTROW As Integer = 1
            Dim GMTRSTOTAL As Double = 0.0
            If DT.Rows.Count > 0 Then


                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next

                For I As Integer = 27 To 50
                    SetColumn(I, "A" & Chr(64 + (I - 26)))
                Next

                RowIndex = 1
                For i As Integer = 1 To 50
                    SetColumnWidth(Range(i), 12)
                Next
                SetColumnWidth(Range(1), 18)

                Dim T As Integer = 2    'FOR TOTAL COLUMS COUNT

                'FOR EXPENSENAME
                'Dim DTEXP As System.Data.DataTable = objCMN.search(" EXP_NAME AS EXPNAME", "", " EXPENSEMASTER ", " AND EXP_ID IN (SELECT EXP_ID FROM EXPENSE_DESC WHERE EXP_CMPID = " & CMPID & " AND EXP_LOCATIONID = " & LOCATIONID & " AND EXP_YEARID = " & YEARID & ") AND EXP_CMPID = " & CMPID & " AND EXP_LOCATIONID = " & LOCATIONID & " AND EXP_YEARID = " & YEARID)
                Dim DTEXP As System.Data.DataTable = objCMN.search(" ISNULL(EXP_NAME,'') AS EXPNAME", "", " EXPENSEMASTER ", " AND EXP_CMPID = " & CMPID & " AND EXP_LOCATIONID = " & LOCATIONID & " AND EXP_YEARID = " & YEARID)
                If DTEXP.Rows.Count > 0 Then

                    'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
                    'COZ HERE WE DONT KNOW NO OF COLUMS
                    RowIndex += 5
                    Write("PROCESSES", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                    For Each DREXP As DataRow In DTEXP.Rows
                        Write(DREXP("EXPNAME"), Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                        T = T + 1
                    Next
                    Write("Total", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9)
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(T.ToString).ToString & RowIndex)

                End If

                SetColumnWidth(Range((T + 1).ToString), 0)

                'GET DISTINCT PROCESS NAME 
                Dim DV As DataView = DT.DefaultView
                Dim NEWDT As System.Data.DataTable = DV.ToTable(True, "PROCESS")
                For Each DTR As DataRow In NEWDT.Rows

                    RowIndex += 1
                    Write(DTR("PROCESS"), Range("1"), XlHAlign.xlHAlignCenter, , True, 10)


                    Dim MERCHANTNAME As New ArrayList

                    'GET MERCHANT IN THAT PROCESS
                    Dim MNAME As String = ""
                    For Each ITEMDR As System.Data.DataRow In DT.Select("PROCESS = '" & DTR("PROCESS") & "'")

                        If MERCHANTNAME.Contains(ITEMDR("MERCHANT")) = False Then
                            'GET TOTAL PRODUCTION DONE IN THAT PROESS FOR PARTICULAR MERCHANT
                            Dim MTRSDT As System.Data.DataTable = objCMN.search(" SUM(TOTALMTRS) AS TOTALMTRS, PROCESS, MERCHANT, CMPID, LOCATIONID, YEARID ", "", " (SELECT SUM(FINALPACKINGSLIP.FPS_TOTALMTRS) AS TOTALMTRS, 'JOB IN' AS PROCESS, ITEMMASTER.item_name AS MERCHANT, FINALPACKINGSLIP.FPS_DATE AS DATE, FINALPACKINGSLIP.FPS_CMPID AS CMPID, FINALPACKINGSLIP.FPS_LOCATIONID AS LOCATIONID, FINALPACKINGSLIP.FPS_YEARID AS YEARID FROM  FINALPACKINGSLIP INNER JOIN PROCESSMASTER ON FINALPACKINGSLIP.FPS_PROCESSID = PROCESSMASTER.PROCESS_ID AND FINALPACKINGSLIP.FPS_CMPID = PROCESSMASTER.PROCESS_CMPID AND FINALPACKINGSLIP.FPS_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND FINALPACKINGSLIP.FPS_YEARID = PROCESSMASTER.PROCESS_YEARID INNER JOIN ITEMMASTER ON FINALPACKINGSLIP.FPS_MERCHANTID = ITEMMASTER.item_id AND FINALPACKINGSLIP.FPS_CMPID = ITEMMASTER.item_cmpid AND FINALPACKINGSLIP.FPS_LOCATIONID = ITEMMASTER.item_locationid And FINALPACKINGSLIP.FPS_YEARID = ITEMMASTER.item_yearid WHERE (PROCESSMASTER.PROCESS_NAME = 'FINAL CUTTING') AND (FINALPACKINGSLIP.FPS_EXPENSEREPORT = 1) GROUP BY PROCESSMASTER.PROCESS_NAME, ITEMMASTER.item_name, FINALPACKINGSLIP.FPS_DATE, FINALPACKINGSLIP.FPS_CMPID, FINALPACKINGSLIP.FPS_LOCATIONID, FINALPACKINGSLIP.FPS_YEARID UNION ALL SELECT     SUM(FINALPACKINGSLIP.FPS_TOTALMTRS) AS TOTALMTRS, 'LUMP FINISH' AS PROCESS, ITEMMASTER.ITEM_name AS MERCHANT, FINALPACKINGSLIP.FPS_DATE AS DATE, FINALPACKINGSLIP.FPS_CMPID AS CMPID, FINALPACKINGSLIP.FPS_LOCATIONID AS LOCATIONID, FINALPACKINGSLIP.FPS_YEARID AS YEARID FROM FINALPACKINGSLIP INNER JOIN PROCESSMASTER ON FINALPACKINGSLIP.FPS_PROCESSID = PROCESSMASTER.PROCESS_ID AND FINALPACKINGSLIP.FPS_CMPID = PROCESSMASTER.PROCESS_CMPID AND FINALPACKINGSLIP.FPS_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND FINALPACKINGSLIP.FPS_YEARID = PROCESSMASTER.PROCESS_YEARID INNER JOIN ITEMMASTER ON FINALPACKINGSLIP.FPS_MERCHANTID= ITEMMASTER.ITEM_id AND FINALPACKINGSLIP.FPS_CMPID = ITEMMASTER.ITEM_cmpid AND FINALPACKINGSLIP.FPS_LOCATIONID = ITEMMASTER.ITEM_locationid And FINALPACKINGSLIP.FPS_YEARID = ITEMMASTER.ITEM_yearid WHERE PROCESS_NAME = 'WHITE FOLDING' GROUP BY PROCESSMASTER.PROCESS_NAME, ITEMMASTER.ITEM_name, FINALPACKINGSLIP.FPS_DATE, FINALPACKINGSLIP.FPS_CMPID, FINALPACKINGSLIP.FPS_LOCATIONID, FINALPACKINGSLIP.FPS_YEARID  UNION ALL SELECT SUM(MFGMASTER2.MFG_TOTALRECDMTRS) AS TOTALMTRS, PROCESSMASTER.PROCESS_NAME AS PROCESS, ITEMMASTER.item_name AS MERCHANT, MFGMASTER2.MFG_DATE AS DATE, MFG_CMPID AS CMPID, MFG_LOCATIONID AS LOCATIONID, MFG_YEARID  AS YEARID FROM MFGMASTER2 INNER JOIN PROCESSMASTER ON MFGMASTER2.MFG_TOPROCESSID = PROCESSMASTER.PROCESS_ID AND MFGMASTER2.MFG_CMPID = PROCESSMASTER.PROCESS_CMPID AND MFGMASTER2.MFG_LOCATIONID = PROCESSMASTER.PROCESS_LOCATIONID AND MFGMASTER2.MFG_YEARID = PROCESSMASTER.PROCESS_YEARID INNER JOIN ITEMMASTER ON MFGMASTER2.MFG_MERCHANTID = ITEMMASTER.item_id AND MFGMASTER2.MFG_CMPID = ITEMMASTER.item_cmpid AND MFGMASTER2.MFG_LOCATIONID = ITEMMASTER.item_locationid AND MFGMASTER2.MFG_YEARID = ITEMMASTER.item_yearid GROUP BY PROCESSMASTER.PROCESS_NAME , ITEMMASTER.item_name , MFGMASTER2.MFG_DATE, MFG_CMPID , MFG_LOCATIONID , MFG_YEARID ) AS T ", CONDITION & " AND T.PROCESS = '" & DTR("PROCESS") & "' AND T.MERCHANT = '" & ITEMDR("MERCHANT") & "' AND T.CMPID = " & CMPID & " AND T.LOCATIONID = " & LOCATIONID & " AND T.YEARID = " & YEARID & " GROUP BY PROCESS, MERCHANT, CMPID, LOCATIONID, YEARID ORDER BY T.PROCESS, T.MERCHANT ")
                            For Each MTRSDR As System.Data.DataRow In MTRSDT.Rows

                                'objSheet.Rows(RowIndex, 1).HEIGHT = 5

                                RowIndex += 1
                                Write(ITEMDR("MERCHANT"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                                FORMULA("=ROUND(SUM(" & objColumn.Item("2").ToString & RowIndex & ":" & objColumn.Item((T - 1).ToString).ToString & RowIndex & "),2)", Range(T.ToString), XlHAlign.xlHAlignRight, , True, 9)

                                objSheet.Rows(RowIndex).rowheight = 0

                                RowIndex += 1
                                Write(MTRSDR("TOTALMTRS"), Range("1"), XlHAlign.xlHAlignRight, , False, 9)

                                'FOR GRANDTOTAL
                                GMTRSTOTAL = GMTRSTOTAL + MTRSDR("TOTALMTRS")

                                'TOTAL
                                FORMULA("=ROUND(SUM(" & objColumn.Item("2").ToString & RowIndex & ":" & objColumn.Item((T - 1).ToString).ToString & RowIndex & "),2)", Range(T.ToString), XlHAlign.xlHAlignRight, , True, 9)

                                'WRITTEN TO GIVE CONDTION ON TOTAL
                                'DO NOT DELETE DONE BY GULKIT
                                Write(DTR("PROCESS"), Range((T + 1).ToString), XlHAlign.xlHAlignLeft, , False, 9)
                                objSheet.Rows(RowIndex).rowheight = 0


                                LASTROW = RowIndex

                                RowIndex -= 1
                                'ADD IN EXPENSE COLUMN
                                'FIRST SEACH THE COLUMN (MATCH IT WITH THE EXPENSE NAME IN DT)
                                For I As Integer = 2 To T - 1
                                    If objSheet.Cells(6, I).VALUE = ITEMDR("EXPENSENAME") Then
                                        Write(ITEMDR("RATE"), Range(I.ToString), XlHAlign.xlHAlignRight, , False, 9)
                                        RowIndex += 1
                                        Write(ITEMDR("RATE") * Val(MTRSDR("TOTALMTRS")), Range(I.ToString), XlHAlign.xlHAlignRight, , False, 9)
                                    End If
                                Next

                                RowIndex = LASTROW
                                MERCHANTNAME.Add(ITEMDR("MERCHANT"))
                                SetBorder(RowIndex - 1, objColumn.Item("1").ToString & RowIndex - 1, objColumn.Item(T.ToString).ToString & RowIndex)
                            Next
                        Else
                            LASTROW = RowIndex
                            RowIndex -= 1
                            'ADD IN EXPENSE COLUMN
                            'FIRST SEACH THE COLUMN (MATCH IT WITH THE EXPENSE NAME IN DT)
                            For I As Integer = 2 To T - 1
                                If objSheet.Cells(RowIndex, I).VALUE = Nothing Then Write("0", Range(I.ToString), XlHAlign.xlHAlignRight, , False, 9)
                                If objSheet.Cells(6, I).VALUE = ITEMDR("EXPENSENAME") Then
                                    Write(ITEMDR("RATE"), Range(I.ToString), XlHAlign.xlHAlignRight, , False, 9)
                                End If
                            Next
                            RowIndex = LASTROW
                            For I As Integer = 2 To T - 1
                                Write(Val(objSheet.Cells(RowIndex - 1, I).VALUE) * Val(objSheet.Cells(RowIndex, 1).VALUE), Range(I.ToString), XlHAlign.xlHAlignRight, , False, 9)
                            Next
                            MNAME = ITEMDR("MERCHANT")

                        End If

                    Next

                    RowIndex += 1

                    Write("Total", Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    For I As Integer = 1 To T
                        FORMULA("=SUMIFS(" & objColumn.Item(I.ToString).ToString & 7 & ":" & objColumn.Item(I.ToString).ToString & RowIndex - 1 & "," & objColumn.Item((T + 1).ToString).ToString & 7 & ":" & objColumn.Item((T + 1).ToString).ToString & RowIndex - 1 & ",""=" & DTR("PROCESS") & """)", Range(I.ToString), XlHAlign.xlHAlignRight, , True, 9)
                    Next
                    SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(T.ToString).ToString & RowIndex)
                    RowIndex += 1

                Next


                Write("Grand Total     : " & Format(Val(GMTRSTOTAL), "0.00"), Range("1"), XlHAlign.xlHAlignRight, , True, 9)
                For I As Integer = 2 To T
                    FORMULA("=SUMIFS(" & objColumn.Item(I.ToString).ToString & 7 & ":" & objColumn.Item(I.ToString).ToString & RowIndex - 2 & "," & objColumn.Item((T + 1).ToString).ToString & 7 & ":" & objColumn.Item((T + 1).ToString).ToString & RowIndex - 2 & ",""<>"")", Range(I.ToString), XlHAlign.xlHAlignRight, , True, 9)
                Next
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(T.ToString).ToString & RowIndex)


                objSheet.Range(objColumn.Item((T - 1).ToString).ToString & 1, objColumn.Item((T - 1).ToString).ToString & LASTROW).NumberFormat = "0.00"


                LASTROW = RowIndex




                '''''''''''Report Title
                'CMPNAME

                RowIndex = 2
                Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(T.ToString), True, 14)
                SetBorder(RowIndex, Range("1"), Range(T.ToString))

                'ADD1
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(T.ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(T.ToString))

                'ADD2
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(T.ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(T.ToString))


                RowIndex += 1
                Write(HEADER, Range("1"), XlHAlign.xlHAlignCenter, Range(T.ToString), True, 12)
                SetBorder(RowIndex, Range("1"), Range(T.ToString))



                'FREEZE TOP 6 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 7, objColumn.Item(T.ToString).ToString & 7).Select()
                objSheet.Range(objColumn.Item("1").ToString & 7, objColumn.Item(T.ToString).ToString & 7).Application.ActiveWindow.FreezePanes = True

                'FREEZE 1ST COLUMN
                objSheet.Range(objColumn.Item("1").ToString & 1, objColumn.Item("1").ToString & LASTROW).Select()
                objSheet.Range(objColumn.Item("1").ToString & 1, objColumn.Item("1").ToString & 200).Application.ActiveWindow.FreezePanes = True


                objBook.Application.ActiveWindow.Zoom = 100

                'With objSheet.PageSetup
                '    .Orientation = XlPageOrientation.xlLandscape
                '    '.TopMargin = 144
                '    '.LeftMargin = 50.4
                '    '.RightMargin = 0
                '    '.BottomMargin = 0
                '    '.Zoom = False
                '    '.FitToPagesTall = 1
                '    '.FitToPagesWide = 1
                'End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region


#Region "ANALYTICAL REPORT"

    Public Function CHART_REPORT_EXCEL(ByVal DT As System.Data.DataTable, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer, Optional ByVal HEADER As String = "", Optional ByVal FRMSTRING As String = "", Optional ByVal PERIOD As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 20)


            If FRMSTRING = "PARTYWISE" Then
                HEADER = "PARTY WISE CHART REPORT"
            ElseIf FRMSTRING = "CITYWISE" Then
                HEADER = "CITY WISE CHART REPORT"
            ElseIf FRMSTRING = "AGENTWISE" Then
                HEADER = "AGENT WISE CHART REPORT"
            ElseIf FRMSTRING = "CONSUMPTIONDEPARTMENTWISE" Then
                HEADER = "DEPARTMENT WISE CONSUMPTION CHART REPORT"
            ElseIf FRMSTRING = "CONSUMPTIONITEMWISE" Then
                HEADER = "ITEM WISE CONSUMPTION CHART REPORT"
            ElseIf FRMSTRING = "CONSUMPTIONMONTHLY" Then
                HEADER = "MONTHLY CONSUMPTION CHART REPORT"
            ElseIf FRMSTRING = "PURPARTYWISE" Then
                HEADER = "PARTY WISE CHART REPORT"
            ElseIf FRMSTRING = "PURITEMWISE" Then
                HEADER = "ITEM WISE CHART REPORT"
            ElseIf FRMSTRING = "PURAGENTWISE" Then
                HEADER = "AGENT WISE CHART REPORT"
            ElseIf FRMSTRING = "PURDEPARTMENTWISE" Then
                HEADER = "DEPARTMENT WISE CHART REPORT"
            End If
            CMPHEADER(CMPID, HEADER & " (" & PERIOD & ")")


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)

            RowIndex += 2
            If FRMSTRING = "PARTYWISE" Then
                Write("Party Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "CITYWISE" Then
                Write("City Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "AGENTWISE" Then
                Write("Agent Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "CONSUMPTIONDEPARTMENTWISE" Then
                Write("Department Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "CONSUMPTIONITEMWISE" Then
                Write("Item Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "CONSUMPTIONMONTHLY" Then
                Write("Month Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "PURDEPARTMENTWISE" Then
                Write("Department Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "PURITEMWISE" Then
                Write("Item Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "PURAGENTWISE" Then
                Write("Agent Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            ElseIf FRMSTRING = "PURPARTYWISE" Then
                Write("Party Name", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            End If


            If FRMSTRING = "PARTYWISE" Or FRMSTRING = "CITYWISE" Or FRMSTRING = "AGENTWISE" Then
                Write("Mtrs", Range("2"), XlHAlign.xlHAlignRight, , True, 11)
            Else
                Write("Qty", Range("2"), XlHAlign.xlHAlignRight, , True, 11)
            End If

            Write("Pcs", Range("3"), XlHAlign.xlHAlignRight, , True, 11)
            Write("Amount", Range("4"), XlHAlign.xlHAlignRight, , True, 11)


            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW(0), Range("1"), XlHAlign.xlHAlignLeft, , False, 11)
                Write(DTROW(1), Range("2"), XlHAlign.xlHAlignRight, , False, 11)
                Write(DTROW(2), Range("3"), XlHAlign.xlHAlignRight, , False, 11)
                Write(DTROW(3), Range("4"), XlHAlign.xlHAlignRight, , False, 11)
            Next
            SetBorder(RowIndex, objColumn.Item("1").ToString & 7, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 7, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 7, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 7, objColumn.Item("4").ToString & RowIndex)

            RowIndex += 1
            Write("Total", Range("1"), XlHAlign.xlHAlignRight, , False, 11)
            FORMULA("=SUM(" & objColumn.Item("2").ToString & 7 & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 7 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 7 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 11)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)

            objSheet.Range(objColumn.Item("2").ToString & 7, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 7, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("4").ToString & 7, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & 8).Select()


            'GENERATING CHART
            'create chart objects
            Dim oChart As Excel.Chart
            Dim MyCharts As Excel.ChartObjects
            Dim MyCharts1 As Excel.ChartObject
            MyCharts = objSheet.ChartObjects
            'set chart location
            MyCharts1 = MyCharts.Add(215, 135, 1200, 350)
            oChart = MyCharts1.Chart
            'use the follwoing line if u want to draw chart on the default location
            'ochart.Location(Excel.XlChartLocation.xlLocationAsObject, OBJSHEET.Name)
            With oChart
                'set data range for chart
                Dim chartRange As Excel.Range
                chartRange = objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("2").ToString & RowIndex - 1)
                .SetSourceData(chartRange)
                'set how you want to draw chart i.e column wise or row wise
                .PlotBy = Excel.XlRowCol.xlColumns
                'set data lables for bars
                .ApplyDataLabels(Excel.XlDataLabelsType.xlDataLabelsShowNone)
                'set legend to be displayed or not
                .HasLegend = False
                'set legend location if legent is true
                '.Legend.Position = Excel.XlLegendPosition.xlLegendPositionRight
                'select chart type
                '.ChartType = Excel.XlChartType.xl3DBarClustered
                'chart title
                .HasTitle = True
                .ChartTitle.Text = "Analytical Chart"
                'set titles for Axis values and categories
                Dim xlAxisCategory, xlAxisValue As Excel.Axes
                xlAxisCategory = CType(oChart.Axes(, Excel.XlAxisGroup.xlPrimary), Excel.Axes)
                xlAxisCategory.Item(Excel.XlAxisType.xlCategory).HasTitle = True
                xlAxisCategory.Item(Excel.XlAxisType.xlCategory).AxisTitle.Characters.Text = objSheet.Range(objColumn.Item("1").ToString & 7).Value
                xlAxisValue = CType(oChart.Axes(, Excel.XlAxisGroup.xlPrimary), Excel.Axes)
                xlAxisValue.Item(Excel.XlAxisType.xlValue).HasTitle = True
                xlAxisValue.Item(Excel.XlAxisType.xlValue).AxisTitle.Characters.Text = "Mtrs"
            End With

            objBook.Application.ActiveWindow.Zoom = 80

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region


#Region "STOCK ON HAND REPORT"

    Public Function FINALSTOCK_REPORT_EXCEL(ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer, Optional ByVal HEADER As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            SetColumnWidth(Range("1"), 26)
            SetColumnWidth(Range("2"), 13)
            SetColumnWidth(Range("3"), 3)
            SetColumnWidth(Range("4"), 26)
            SetColumnWidth(Range("5"), 13)

            Dim OBJCMN As New ClsCommon
            Dim NEWDT As System.Data.DataTable

            CMPHEADER(CMPID, HEADER, MonthName(Now.Date.Month) & "-" & Now.Year)

            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)

            RowIndex += 3

            '******************************  TOTAL GREY RECD  **************************************
            Write("TOTAL GREY RECEIVED", Range("1"), XlHAlign.xlHAlignLeft, , False, 12)

            'GET TOTAL GREY RECD FROM CHECKING (ADD TOTAL BALANCE MTRS + UNCHECKED STOCK)
            NEWDT = OBJCMN.search(" ISNULL(SUM(T.BALMTRS),0) + ISNULL(SUM(T.UNCHECKED),0) AS GREYRECD ", "", " (SELECT SUM(CHECK_BALMTRS ) AS BALMTRS, 0 AS UNCHECKED FROM CHECKINGMASTER INNER JOIN GRN ON grn_no = CHECK_LOTNO AND grn_yearid = CHECK_YEARID AND CHECKINGMASTER.CHECK_TYPE = GRN.GRN_TYPE WHERE CHECK_YEARID = " & YEARID & " UNION ALL SELECT 0 AS BALMTRS, SUM(GRN_MTRS) AS UNCHECKED FROM GRN_DESC WHERE GRN_YEARID = " & YEARID & " AND GRN_CHECKDONE = 'False' AND GRN_GRIDTYPE = 'G.R.N') AS T ", "")
            Write(Format(Val(NEWDT.Rows(0).Item("GREYRECD")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 12)
            '***************************************************************************************

            '******************************  TOTAL RECD SAME AS TOTAL **************************************
            Write("TOTAL RECEIVED", Range("4"), XlHAlign.xlHAlignLeft, , False, 12)
            FORMULA("=" & objColumn.Item("2").ToString & RowIndex + 3, Range("5"), XlHAlign.xlHAlignRight, , False, 12)
            '***************************************************************************************





            RowIndex += 1
            '******************************  OPENING BALANCE FROM OPBALAMTRS OF CURRENT YEAR ********
            Write("OPENING BALANCE", Range("1"), XlHAlign.xlHAlignLeft, , False, 12)

            'GET OP BALANCE OF CURRENT YEAR FROM OPENINGMTRS
            NEWDT = OBJCMN.search(" ISNULL(OP_BALMTRS,0) AS BALMTRS", "", " OPENINGMTRS ", " AND OP_CMPID = " & CMPID & " AND OP_LOCATIONID = " & LOCATIONID & " AND OP_YEARID = " & YEARID)
            Write(Format(Val(NEWDT.Rows(0).Item("BALMTRS")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 12)
            '***************************************************************************************


            '******************************  TOTAL DESP FROM  ********
            Write("TOTAL DESPATCHED", Range("4"), XlHAlign.xlHAlignLeft, , False, 12)
            NEWDT = OBJCMN.search(" ISNULL(SUM(GDN_PSDESC.GDN_MTRS),0) AS MTRS", "", " GDN LEFT OUTER JOIN GDN_PSDESC ON GDN.GDN_no = GDN_PSDESC.GDN_NO AND GDN.GDN_YEARID = GDN_PSDESC.GDN_YEARID  ", " AND (ISNULL(GDN_PSDESC.GDN_type, '') IN ('BALE', 'FINALPACKING')) AND GDN.GDN_YEARID = " & YEARID)
            Write(Format(Val(NEWDT.Rows(0).Item("MTRS")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 12)
            '***************************************************************************************


            RowIndex += 1
            '******************************  SALE RETURN MTRS FROM SALE RETURN OF CURRENT YEAR ********
            Write("SALE RETURN", Range("1"), XlHAlign.xlHAlignLeft, , False, 12)

            'GET SALE RETURN 
            NEWDT = OBJCMN.search(" ISNULL(SUM(SALE_TOTALMTRS),0) AS TOTALMTRS", "", " SALERETURN ", " AND SALE_YEARID = " & YEARID)
            Write(Format(Val(NEWDT.Rows(0).Item("TOTALMTRS")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 12)
            '***************************************************************************************


            '******************************  JETPUR DESP FROM  ********
            Write("JETPUR DISPATCH", Range("4"), XlHAlign.xlHAlignLeft, , False, 12)
            Write("0.00", Range("5"), XlHAlign.xlHAlignRight, , False, 12)
            '***************************************************************************************







            RowIndex += 1
            '********************************* GET TOTAL ******************************************************
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("2").ToString & 8 & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 12)

            Write("TOTAL", Range("4"), XlHAlign.xlHAlignLeft, , True, 12)
            FORMULA("=(" & objColumn.Item("5").ToString & RowIndex - 3 & "-(" & objColumn.Item("5").ToString & RowIndex - 2 & "+" & objColumn.Item("5").ToString & RowIndex - 1 & "))", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            '***************************************************************************************





            RowIndex += 2
            Write("STOCK DETAILS", Range("1"), XlHAlign.xlHAlignLeft, , True, 12)
            '***************************************************************************************


            RowIndex += 1
            Write("GREY CHECKED", Range("1"), XlHAlign.xlHAlignLeft, , False, 12)
            NEWDT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS CHECKMTRS ", "", " CHECK_VIEW ", " AND YEARID = " & YEARID)
            Write(Format(Val(NEWDT.Rows(0).Item("CHECKMTRS")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 12)
            '***************************************************************************************



            RowIndex += 1
            Write("GREY UNCHECKED", Range("1"), XlHAlign.xlHAlignLeft, , False, 12)
            NEWDT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS UNCHECKMTRS ", "", " GRN_VIEW ", " AND YEARID = " & YEARID & " AND CHECKDONE = 'A' ")
            Write(Format(Val(NEWDT.Rows(0).Item("UNCHECKMTRS")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 12)
            '***************************************************************************************


            RowIndex += 1
            Write("WHITE FOLDING", Range("1"), XlHAlign.xlHAlignLeft, , False, 12)
            NEWDT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS MTRS ", "", " CUTTING_VIEW ", " AND YEARID = " & YEARID)
            Write(Format(Val(NEWDT.Rows(0).Item("MTRS")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 12)
            '***************************************************************************************


            RowIndex += 1
            Write("PROCESS STOCK", Range("1"), XlHAlign.xlHAlignLeft, , False, 12)

            'NO DATE FILTER IS APPLIED HERE (DONE BY GULKIT AS TOTAL IS NOT POSSIBLE IN CRYSTAL REPORT)
            'DONE BY GULKIT (TOTAL IS WRONG)
            'NEWDT = OBJCMN.search(" ROUND(SUM(MTRS),2) AS MTRS ", "", " VIEW_SUMMARY_MFG1 ", " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & " HAVING  ROUND(SUM(MTRS),2) >0")
            NEWDT = OBJCMN.search(" ROUND(ISNULL(SUM(FINAL.PENDINGMTRS),0),2) AS MTRS ", "", " (SELECT  T.LOTNO, SUM(INMTRS) AS INMTRS, SUM(OUTMTRS) AS OUTMTRS ,(SUM(INMTRS)- SUM(OUTMTRS)) AS PENDINGMTRS   FROM (SELECT LOTNO, SUM(MTRS) AS INMTRS,0 AS OUTMTRS, 0 AS PENDINGMTRS, YEARID  FROM VIEW_SUMMARY_MFG1 WHERE MTRS > 0 AND YEARID = " & YEARID & " GROUP BY YEARID, LOTNO  UNION ALL SELECT LOTNO, 0 AS INMTRS, SUM(MTRS) * (-1) AS OUTMTRS, 0 AS PENDINGMTRS, YEARID  FROM VIEW_SUMMARY_MFG1 WHERE MTRS < 0 AND YEARID = " & YEARID & " GROUP BY YEARID, LOTNO ) AS T GROUP BY T.LOTNO HAVING (SUM(INMTRS)- SUM(OUTMTRS)) > 1 ) AS FINAL  ", " HAVING ROUND(SUM(FINAL.PENDINGMTRS) ,2) >0")
            Write(Format(Val(NEWDT.Rows(0).Item("MTRS")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 12)
            '***************************************************************************************


            RowIndex += 1
            Write("SAREE FOLDING STOCK", Range("1"), XlHAlign.xlHAlignLeft, , False, 12)
            NEWDT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS MTRS ", "", " MEMO_STOCK ", " AND YEARID = " & YEARID & " HAVING  ROUND(SUM(MTRS),2) >0")
            Write(Format(Val(NEWDT.Rows(0).Item("MTRS")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 12)
            '***************************************************************************************


            RowIndex += 1
            Write("READY BALE STOCK", Range("1"), XlHAlign.xlHAlignLeft, , False, 12)
            NEWDT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS MTRS ", "", " BALESTOCK_VIEW ", " AND TYPE IN ('BALE', 'FINALPACKING') AND CHALLANNO = 0 AND YEARID = " & YEARID)
            Write(Format(Val(NEWDT.Rows(0).Item("MTRS")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 12)
            '***************************************************************************************


            RowIndex += 1
            Write("JOB BALE STOCK", Range("1"), XlHAlign.xlHAlignLeft, , False, 12)
            NEWDT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS MTRS ", "", " BALESTOCK_VIEW ", " AND TYPE IN ('JOBBALE', 'PSJOB') AND CHALLANNO = 0 AND YEARID = " & YEARID)
            Write(Format(Val(NEWDT.Rows(0).Item("MTRS")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 12)
            '***************************************************************************************


            RowIndex += 1
            Write("OUTSIDE JOB BALANCE", Range("1"), XlHAlign.xlHAlignLeft, , False, 12)
            'DONE BY GULKIT (TOTAL IS WRONG)
            'NEWDT = OBJCMN.search(" SUM(MTRS) AS MTRS ", "", " jobout_view ", " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID)
            NEWDT = OBJCMN.search(" ISNULL(SUM(FINAL.PENDINGMTRS),0) MTRS ", "", " (SELECT T.JOBNO  , SUM(MTRS) AS INMTRS, SUM(MTRS) AS OUTMTRS ,(SUM(MTRS)- SUM(OUTMTRS)) AS PENDINGMTRS, SUM(T.PCS) AS INPCS, SUM(OUTPCS) AS OUTPCS   , (SUM(PCS)- SUM(OUTPCS)) AS PENDINGPSC FROM (SELECT JOBNO, SUM(MTRS) AS MTRS,0 AS OUTMTRS, 0 AS PENDINGMTRS, SUM(PCS) AS PCS, 0 AS OUTPCS , 0 AS PENDINGPCS, YEARID  FROM JOBOUT_VIEW WHERE MTRS > 0  GROUP BY JOBNO, YEARID  UNION ALL SELECT JOBNO, 0 AS MTRS, SUM(MTRS) * (-1) AS OUTMTRS, 0 AS PENDINGMTRS, 0 AS PCS, SUM(PCS) * (-1) AS OUTPCS, 0 AS PENDINGPCS , YEARID  FROM JOBOUT_VIEW WHERE MTRS < 0  GROUP BY JOBNO, YEARID ) AS T WHERE(T.YEARID = " & YEARID & ") GROUP BY T.JOBNO  HAVING (SUM(MTRS)- SUM(OUTMTRS)) > 1 ) AS FINAL  ", "")
            Write(Format(Val(NEWDT.Rows(0).Item("MTRS")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 12)
            '***************************************************************************************


            RowIndex += 1
            Write("LOOSE STOCK-FRESH", Range("1"), XlHAlign.xlHAlignLeft, , False, 12)
            Write("0", Range("2"), XlHAlign.xlHAlignRight, , False, 12)

            Write("EXCESS STOCK", Range("4"), XlHAlign.xlHAlignLeft, , True, 12)
            FORMULA("=(B26-E12)", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            '***************************************************************************************

            RowIndex += 1
            Write("LOOSE STOCK-SECOND", Range("1"), XlHAlign.xlHAlignLeft, , False, 12)
            Write("0", Range("2"), XlHAlign.xlHAlignRight, , False, 12)

            RowIndex += 1
            Write("SECOND / FENT", Range("1"), XlHAlign.xlHAlignLeft, , False, 12)
            Write("0", Range("2"), XlHAlign.xlHAlignRight, , False, 12)


            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("2").ToString & 14 & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 12)

            Write("TOTAL", Range("4"), XlHAlign.xlHAlignLeft, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 12 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            '***************************************************************************************



            'SetBorder(RowIndex, objColumn.Item("1").ToString & 7, objColumn.Item("1").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("2").ToString & 7, objColumn.Item("2").ToString & RowIndex)

            'RowIndex += 1
            'Write("Total", Range("1"), XlHAlign.xlHAlignRight, , False, 11)
            'FORMULA("=SUM(" & objColumn.Item("2").ToString & 7 & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 11)
            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)

            objSheet.Range(objColumn.Item("2").ToString & 7, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 7, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "STORE STOCK - AVG PUR"

    Public Function STORESTOCKDTLS_AVGPUR_REPORT_EXCEL(ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CHKSTATE As Boolean, Optional ByVal HEADER As String = "", Optional ByVal PERIOD As String = "", Optional ByVal WHERECLAUSE As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next
            'SetColumnWidth("1", 10)


            RowIndex = 1
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("12"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("12"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("12"))

            RowIndex += 1
            Write(HEADER, Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("12"))


            RowIndex += 1
            Write(PERIOD, Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("12"))


            'FREEZE TOP 8 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("12").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("12").ToString & 8).Application.ActiveWindow.FreezePanes = True

            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("12").ToString & RowIndex + 1)

            RowIndex += 1
            Write("ITEM NAME", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("RATE", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("OPENING", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("VALUE", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("INWARD", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("VALUE", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("OUTWARD", Range("7"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("VALUE", Range("8"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("DESPATCH", Range("9"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("VALUE", Range("10"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("BALANCE", Range("11"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("VALUE", Range("12"), XlHAlign.xlHAlignLeft, , False, 10)

            Dim DT As System.Data.DataTable
            Dim OPENING, INWARD, OUTWARD, DESPATCH, BALANCE, RATE As Double
            Dim OPENINGTOTAL, INWARDTOTAL, OUTWARDTOTAL, DESPATCHTOTAL, BALANCETOTAL As Double
            Dim OPENINGVALUETOTAL, INWARDVALUETOTAL, OUTWARDVALUETOTAL, DESPATCHVALUETOTAL, BALANCEVALUETOTAL As Double
            Dim STARTROW As Integer = 7
            Dim DEPTNAME As String = ""


            OPENINGTOTAL = 0
            OPENINGVALUETOTAL = 0
            INWARDTOTAL = 0
            INWARDVALUETOTAL = 0
            OUTWARDTOTAL = 0
            OUTWARDVALUETOTAL = 0
            DESPATCHTOTAL = 0
            DESPATCHVALUETOTAL = 0
            BALANCETOTAL = 0
            BALANCEVALUETOTAL = 0

            'DONE BY GULKIT, WE HAVE REMOVED DATE FILTER, COZ IF WE SET DATE FILTER THEN ANY ITEM WHICH IS BEOFORE THIS PERIOD AND NOT IN THIS PERIOD 
            'WHICH HAS OPENING THAT WONT COME
            'Dim DTITEM As System.Data.DataTable = OBJCMN.search("ISNULL(ITEMNAME,'') AS ITEMNAME, ISNULL(DEPARTMENT,'') AS DEPARTMENT", "", " STORESTOCK_DETAILS ", " AND INVENTORY = 'True' AND DATE >= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND DATE<= '" & Format(TODATE, "MM/dd/yyyy") & "' AND YEARID = " & YEARID & "  GROUP BY ITEMNAME, DEPARTMENT ORDER BY  CASE DEPARTMENT when 'MERCERISING' then 1 when 'BLEACHING' then 2 when 'DYEING' then 3 when 'AJAR WASHING' then 4 when 'AGER WASHING' then 5 when 'BOILER' then 6 when 'FINISHING' then 7 when 'FELT' then 8 when 'PROCIOAN GUM PASTE' then 9 when 'PROCIOAN PRINTING' then 10 when 'WAX COATING' then 11 when 'PIGMENT PRINTING' then 12 when 'QUEERING' then 13 when 'PACKING' then 14 when 'ACCOUNTS' then 15 else 16  End")
            Dim DTITEM As System.Data.DataTable = OBJCMN.search("ISNULL(ITEMNAME,'') AS ITEMNAME, ISNULL(DEPARTMENT,'') AS DEPARTMENT", "", " STORESTOCK_DETAILS ", WHERECLAUSE & " AND INVENTORY = 'True' AND YEARID = " & YEARID & "  GROUP BY ITEMNAME, DEPARTMENT ORDER BY  CASE DEPARTMENT when 'MERCERISING' then 1 when 'BLEACHING' then 2 when 'DYEING' then 3 when 'AJAR WASHING' then 4 when 'AGER WASHING' then 5 when 'BOILER' then 6 when 'FINISHING' then 7 when 'FELT' then 8 when 'PROCION GUM PASTE' then 9 when 'PROCION PRINTING' then 10 when 'WAX COATING' then 11 when 'PIGMENT PRINTING' then 12 when 'QUEERING' then 13 when 'PACKING' then 14 when 'ACCOUNTS' then 15 else 16  End, ITEMNAME ")
            If DTITEM.Rows.Count > 0 Then
                For Each DRITEM As DataRow In DTITEM.Rows

                    OPENING = 0
                    INWARD = 0
                    OUTWARD = 0
                    DESPATCH = 0
                    BALANCE = 0
                    RATE = 0


                    'GET PURCHASE AVG RATE
                    'DT = OBJCMN.search(" ISNULL(AVG( ROUND(((((PURCHASEMASTER_DESC.BILL_amt/ BILL_BILLAMT)*(BILL_GRANDTOTAL - BILL_BILLAMT)) + BILL_amt)/BILL_QTY),2)),0) AS RATE ", "", " PURCHASEMASTER_DESC INNER JOIN PURCHASEMASTER ON PURCHASEMASTER_DESC.BILL_no = PURCHASEMASTER.BILL_NO AND PURCHASEMASTER_DESC.BILL_REGISTERID = PURCHASEMASTER.BILL_REGISTERID INNER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id ", " AND ITEM_NAME = '" & DRITEM("ITEMNAME") & "' AND CAST(BILL_DATE AS DATE)>= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(BILL_DATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_YEARID = " & YEARID)
                    'WE HAVE CHANGED AVG RATE TO GRIDTOTAL AS PER JITU BHAI'S REQUEST
                    DT = OBJCMN.search(" ISNULL(ROUND(SUM(BILL_GRIDTOTAL)/SUM(BILL_QTY),2),0) AS RATE ", "", " PURCHASEMASTER_DESC INNER JOIN PURCHASEMASTER ON PURCHASEMASTER_DESC.BILL_no = PURCHASEMASTER.BILL_NO AND PURCHASEMASTER_DESC.BILL_REGISTERID = PURCHASEMASTER.BILL_REGISTERID INNER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id ", " AND ITEM_NAME = '" & DRITEM("ITEMNAME") & "' AND CAST(BILL_DATE AS DATE)>= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(BILL_DATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_YEARID = " & YEARID)
                    If DT.Rows.Count > 0 Then
                        If Val(DT.Rows(0).Item(0)) > 0 Then RATE = Format(Val(DT.Rows(0).Item(0)), "0.00") Else GoTo LINE1
                    Else
LINE1:
                        'FETCH DEFAULT RATE
                        DT = OBJCMN.search(" TOP 1 ITEMMASTER_RATEDESC.ITEM_RATE AS RATE ", "", " ITEMMASTER_RATEDESC INNER JOIN ITEMMASTER ON ITEMMASTER_RATEDESC.ITEM_ID = ITEMMASTER.item_id  INNER JOIN PURCHASEMASTER_DESC ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id INNER JOIN PURCHASEMASTER ON PURCHASEMASTER_DESC.BILL_INITIALS = PURCHASEMASTER.BILL_INITIALS AND PURCHASEMASTER_DESC.BILL_yearid = PURCHASEMASTER.BILL_YEARID ", " AND ITEM_NAME = '" & DRITEM("ITEMNAME") & "' AND ITEMMASTER.ITEM_YEARID = " & YEARID)
                        If DT.Rows.Count > 0 Then RATE = Format(Val(DT.Rows(0).Item(0)), "0.00") Else RATE = 0
                    End If


                    'GET OPENING
                    If CHKSTATE = True Then
                        DT = OBJCMN.search(" ISNULL(SUM(BALANCE),0) AS OPENING", "", " STORESTOCK_DETAILS ", " AND ITEMNAME = '" & DRITEM("ITEMNAME") & "' AND DATE < '" & Format(FROMDATE, "MM/dd/yyyy") & "'  AND YEARID = " & YEARID)
                        If DT.Rows.Count > 0 Then
                            OPENING = Format(Val(DT.Rows(0).Item("OPENING")), "0.00")
                            OPENINGVALUETOTAL += Format(Val(DT.Rows(0).Item("OPENING")) * RATE, "0.00")
                            OPENINGTOTAL += Format(Val(DT.Rows(0).Item("OPENING")), "0.00")
                        End If
                    End If
                    If CHKSTATE = False Or (CHKSTATE = True And Val(OPENING) = 0) Then
                        DT = OBJCMN.search(" ISNULL(SUM(OPENING),0) AS OPENING", "", " STORESTOCK_DETAILS ", " AND ITEMNAME = '" & DRITEM("ITEMNAME") & "' AND CAST(DATE AS DATE)= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND YEARID = " & YEARID)
                        If DT.Rows.Count > 0 Then
                            OPENING = Format(Val(DT.Rows(0).Item(0)), "0.00")
                            OPENINGVALUETOTAL += Format(Val(DT.Rows(0).Item(0)) * RATE, "0.00")
                            OPENINGTOTAL += Format(Val(DT.Rows(0).Item(0)), "0.00")
                        End If
                    End If

                    'GET INWARD
                    DT = OBJCMN.search(" ISNULL(SUM(INWARDS),0) AS INWARD", "", " STORESTOCK_DETAILS ", " AND ITEMNAME = '" & DRITEM("ITEMNAME") & "' AND CAST(DATE AS DATE)>= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(DATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "' AND YEARID = " & YEARID)
                    If DT.Rows.Count > 0 Then
                        INWARD = Format(Val(DT.Rows(0).Item(0)), "0.00")
                        INWARDVALUETOTAL += Format(Val(DT.Rows(0).Item(0)) * RATE, "0.00")
                        INWARDTOTAL += Format(Val(DT.Rows(0).Item(0)), "0.00")
                    End If


                    'GET OUTWARD
                    DT = OBJCMN.search(" ISNULL(SUM(RETURNING),0) AS OUTWARD", "", " STORESTOCK_DETAILS ", " AND ITEMNAME = '" & DRITEM("ITEMNAME") & "' AND CAST(DATE AS DATE)>= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(DATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "' AND YEARID = " & YEARID)
                    If DT.Rows.Count > 0 Then
                        OUTWARD = Format(Val(DT.Rows(0).Item(0)), "0.00")
                        OUTWARDVALUETOTAL += Format(Val(DT.Rows(0).Item(0)) * RATE, "0.00")
                        OUTWARDTOTAL += Format(Val(DT.Rows(0).Item(0)), "0.00")
                    End If


                    'GET DESPATCH
                    DT = OBJCMN.search(" ISNULL(SUM(DESPATCH),0) AS DESPATCH", "", " STORESTOCK_DETAILS ", " AND ITEMNAME = '" & DRITEM("ITEMNAME") & "' AND CAST(DATE AS DATE)>= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(DATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "' AND YEARID = " & YEARID)
                    If DT.Rows.Count > 0 Then
                        DESPATCH = Format(Val(DT.Rows(0).Item(0)), "0.00")
                        DESPATCHVALUETOTAL += Format(Val(DT.Rows(0).Item(0)) * RATE, "0.00")
                        DESPATCHTOTAL += Format(Val(DT.Rows(0).Item(0)), "0.00")
                    End If


                    'GET BALANCE
                    'DT = OBJCMN.search(" ISNULL(SUM(BALANCE),0) AS BALANCE", "", " STORESTOCK_DETAILS ", " AND ITEMNAME = '" & DRITEM("ITEMNAME") & "' AND CAST(DATE AS DATE)>= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(DATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "' AND YEARID = " & YEARID)
                    BALANCE = Format((Val(OPENING) + Val(INWARD)) - ((Val(OUTWARD) * (-1)) + (Val(DESPATCH) * (-1))), "0.00")
                    'BALANCEVALUETOTAL += Format((Val(OPENING) + Val(INWARD)) - ((Val(OUTWARD) * (-1)) + (Val(DESPATCH) * (-1))) * RATE, "0.00")
                    BALANCETOTAL += Format((Val(OPENING) + Val(INWARD)) - ((Val(OUTWARD) * (-1)) + (Val(DESPATCH) * (-1))), "0.00")


                    If DEPTNAME = "" Or DEPTNAME <> DRITEM("DEPARTMENT") Then

                        'TOTAL OF DEPARTMENT
                        If DEPTNAME <> "" And DEPTNAME <> DRITEM("DEPARTMENT") Then
                            RowIndex += 1
                            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                            FORMULA("=SUM(" & objColumn.Item("3").ToString & STARTROW & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 11)
                            FORMULA("=SUM(" & objColumn.Item("4").ToString & STARTROW & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 11)
                            FORMULA("=SUM(" & objColumn.Item("5").ToString & STARTROW & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 11)
                            FORMULA("=SUM(" & objColumn.Item("6").ToString & STARTROW & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 11)
                            FORMULA("=SUM(" & objColumn.Item("7").ToString & STARTROW & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 11)
                            FORMULA("=SUM(" & objColumn.Item("8").ToString & STARTROW & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 11)
                            FORMULA("=SUM(" & objColumn.Item("9").ToString & STARTROW & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 11)
                            FORMULA("=SUM(" & objColumn.Item("10").ToString & STARTROW & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 11)
                            FORMULA("=SUM(" & objColumn.Item("11").ToString & STARTROW & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 11)
                            FORMULA("=SUM(" & objColumn.Item("12").ToString & STARTROW & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 11)
                            STARTROW = RowIndex + 1
                        End If

                        RowIndex += 2
                        Write(DRITEM("DEPARTMENT"), Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                        DEPTNAME = DRITEM("DEPARTMENT")
                    End If

                    If Val(OPENING) > 0 Or Val(INWARD) > 0 Or Val(OUTWARD) > 0 Or Val(DESPATCH) > 0 Or Val(BALANCE) > 0 Then
                        RowIndex += 1
                        Write(DRITEM("ITEMNAME"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(RATE, Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(OPENING, Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(OPENING * RATE, Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(INWARD, Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(INWARD * RATE, Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(OUTWARD, Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(OUTWARD * RATE, Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DESPATCH, Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DESPATCH * RATE, Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(BALANCE, Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(BALANCE * RATE, Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                        BALANCEVALUETOTAL += Format(BALANCE * RATE, "0.00")
                    End If
                Next
            End If


            'TOTAL OF LAST DEPARTMENT
            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & STARTROW & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & STARTROW & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & STARTROW & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & STARTROW & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & STARTROW & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & STARTROW & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & STARTROW & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & STARTROW & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & STARTROW & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & STARTROW & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 11)




            'GRAND TOTAL
            RowIndex += 2
            Write("GRANDTOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 11)
            Write(OPENINGTOTAL, Range("3"), XlHAlign.xlHAlignRight, , True, 11)
            Write(OPENINGVALUETOTAL, Range("4"), XlHAlign.xlHAlignRight, , True, 11)
            Write(INWARDTOTAL, Range("5"), XlHAlign.xlHAlignRight, , True, 11)
            Write(INWARDVALUETOTAL, Range("6"), XlHAlign.xlHAlignRight, , True, 11)
            Write(OUTWARDTOTAL, Range("7"), XlHAlign.xlHAlignRight, , True, 11)
            Write(OUTWARDVALUETOTAL, Range("8"), XlHAlign.xlHAlignRight, , True, 11)
            Write(DESPATCHTOTAL, Range("9"), XlHAlign.xlHAlignRight, , True, 11)
            Write(DESPATCHVALUETOTAL, Range("10"), XlHAlign.xlHAlignRight, , True, 11)
            Write(BALANCETOTAL, Range("11"), XlHAlign.xlHAlignRight, , True, 11)
            Write(BALANCEVALUETOTAL, Range("12"), XlHAlign.xlHAlignRight, , True, 11)
            SetBorder(RowIndex, Range("1"), Range("12"))


            'SetBorder(RowIndex, objColumn.Item("1").ToString & 7, objColumn.Item("1").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("2").ToString & 7, objColumn.Item("2").ToString & RowIndex)

            'RowIndex += 1
            'Write("Total", Range("1"), XlHAlign.xlHAlignRight, , False, 11)
            'FORMULA("=SUM(" & objColumn.Item("2").ToString & 7 & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 11)
            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)

            objSheet.Range(objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("12").ToString & 8, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.00"


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function STORESTOCKSUMM_AVGPUR_REPORT_EXCEL(ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CHKSTATE As Boolean, Optional ByVal HEADER As String = "", Optional ByVal PERIOD As String = "", Optional ByVal WHERECLAUSE As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next
            'SetColumnWidth("1", 10)


            RowIndex = 1
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("12"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("12"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("12"))

            RowIndex += 1
            Write(HEADER, Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("12"))


            RowIndex += 1
            Write(PERIOD, Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("12"))


            'FREEZE TOP 8 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("12").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("12").ToString & 8).Application.ActiveWindow.FreezePanes = True

            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("12").ToString & RowIndex + 1)

            RowIndex += 1
            Write("ITEM NAME", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("RATE", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("OPENING", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("VALUE", Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("INWARD", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("VALUE", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("OUTWARD", Range("7"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("VALUE", Range("8"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("DESPATCH", Range("9"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("VALUE", Range("10"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("BALANCE", Range("11"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("VALUE", Range("12"), XlHAlign.xlHAlignLeft, , False, 10)

            Dim DT As System.Data.DataTable
            Dim OPENING, INWARD, OUTWARD, DESPATCH, BALANCE, RATE As Double
            Dim OPENINGVALUE, INWARDVALUE, OUTWARDVALUE, DESPATCHVALUE, BALANCEVALUE As Double
            Dim OPENINGTOTAL, INWARDTOTAL, OUTWARDTOTAL, DESPATCHTOTAL, BALANCETOTAL As Double
            Dim OPENINGVALUETOTAL, INWARDVALUETOTAL, OUTWARDVALUETOTAL, DESPATCHVALUETOTAL, BALANCEVALUETOTAL As Double
            Dim STARTROW As Integer = 7
            Dim DEPTNAME As String = ""

            OPENINGTOTAL = 0
            OPENINGVALUETOTAL = 0
            INWARDTOTAL = 0
            INWARDVALUETOTAL = 0
            OUTWARDTOTAL = 0
            OUTWARDVALUETOTAL = 0
            DESPATCHTOTAL = 0
            DESPATCHVALUETOTAL = 0
            BALANCETOTAL = 0
            BALANCEVALUETOTAL = 0


            'DONE BY GULKIT, WE HAVE REMOVED DATE FILTER, COZ IF WE SET DATE FILTER THEN ANY ITEM WHICH IS BEOFORE THIS PERIOD AND NOT IN THIS PERIOD 
            'WHICH HAS OPENING THAT WONT COME
            'Dim DTITEM As System.Data.DataTable = OBJCMN.search("ISNULL(ITEMNAME,'') AS ITEMNAME, ISNULL(DEPARTMENT,'') AS DEPARTMENT", "", " STORESTOCK_DETAILS ", " AND INVENTORY = 'True' AND DATE >= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND DATE<= '" & Format(TODATE, "MM/dd/yyyy") & "' AND YEARID = " & YEARID & "  GROUP BY ITEMNAME, DEPARTMENT ORDER BY  CASE DEPARTMENT when 'MERCERISING' then 1 when 'BLEACHING' then 2 when 'DYEING' then 3 when 'AJAR WASHING' then 4 when 'AGER WASHING' then 5 when 'BOILER' then 6 when 'FINISHING' then 7 when 'FELT' then 8 when 'PROCIOAN GUM PASTE' then 9 when 'PROCIOAN PRINTING' then 10 when 'WAX COATING' then 11 when 'PIGMENT PRINTING' then 12 when 'QUEERING' then 13 when 'PACKING' then 14 when 'ACCOUNTS' then 15 else 16  End")
            Dim DTITEM As System.Data.DataTable = OBJCMN.search("ISNULL(ITEMNAME,'') AS ITEMNAME, ISNULL(DEPARTMENT,'') AS DEPARTMENT", "", " STORESTOCK_DETAILS ", WHERECLAUSE & " AND INVENTORY = 'True' AND YEARID = " & YEARID & "  GROUP BY ITEMNAME, DEPARTMENT ORDER BY  CASE DEPARTMENT when 'MERCERISING' then 1 when 'BLEACHING' then 2 when 'DYEING' then 3 when 'AJAR WASHING' then 4 when 'AGER WASHING' then 5 when 'BOILER' then 6 when 'FINISHING' then 7 when 'FELT' then 8 when 'PROCION GUM PASTE' then 9 when 'PROCION PRINTING' then 10 when 'WAX COATING' then 11 when 'PIGMENT PRINTING' then 12 when 'QUEERING' then 13 when 'PACKING' then 14 when 'ACCOUNTS' then 15 else 16  End, ITEMNAME ")
            If DTITEM.Rows.Count > 0 Then
                For Each DRITEM As DataRow In DTITEM.Rows

                    OPENING = 0
                    OPENINGVALUE = 0
                    INWARD = 0
                    INWARDVALUE = 0
                    OUTWARD = 0
                    OUTWARDVALUE = 0
                    DESPATCH = 0
                    DESPATCHVALUE = 0
                    BALANCE = 0
                    BALANCEVALUE = 0
                    RATE = 0

                    If DEPTNAME = "" Or DEPTNAME <> DRITEM("DEPARTMENT") Then

                        RowIndex += 1
                        Write(DEPTNAME, Range("1"), XlHAlign.xlHAlignLeft, , True, 10)

                        'TOTAL OF DEPARTMENT
                        If DEPTNAME <> "" And DEPTNAME <> DRITEM("DEPARTMENT") Then
                            RowIndex += 1
                            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                            Write(OPENINGTOTAL, Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                            Write(OPENINGVALUETOTAL, Range("4"), XlHAlign.xlHAlignRight, , True, 10)
                            Write(INWARDTOTAL, Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                            Write(INWARDVALUETOTAL, Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                            Write(OUTWARDTOTAL, Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                            Write(OUTWARDVALUETOTAL, Range("8"), XlHAlign.xlHAlignRight, , True, 10)
                            Write(DESPATCHTOTAL, Range("9"), XlHAlign.xlHAlignRight, , True, 10)
                            Write(DESPATCHVALUETOTAL, Range("10"), XlHAlign.xlHAlignRight, , True, 10)
                            Write(BALANCETOTAL, Range("11"), XlHAlign.xlHAlignRight, , True, 10)
                            Write(BALANCEVALUETOTAL, Range("12"), XlHAlign.xlHAlignRight, , True, 10)
                            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
                            STARTROW = RowIndex + 1
                        End If

                        OPENINGTOTAL = 0
                        OPENINGVALUETOTAL = 0
                        INWARDTOTAL = 0
                        INWARDVALUETOTAL = 0
                        OUTWARDTOTAL = 0
                        OUTWARDVALUETOTAL = 0
                        DESPATCHTOTAL = 0
                        DESPATCHVALUETOTAL = 0
                        BALANCETOTAL = 0
                        BALANCEVALUETOTAL = 0

                        
                        DEPTNAME = DRITEM("DEPARTMENT")
                    End If

                    'GET PURCHASE AVG RATE
                    'DT = OBJCMN.search(" ISNULL(AVG( ROUND(((((PURCHASEMASTER_DESC.BILL_amt/ BILL_BILLAMT)*(BILL_GRANDTOTAL - BILL_BILLAMT)) + BILL_amt)/BILL_QTY),2)),0) AS RATE ", "", " PURCHASEMASTER_DESC INNER JOIN PURCHASEMASTER ON PURCHASEMASTER_DESC.BILL_no = PURCHASEMASTER.BILL_NO AND PURCHASEMASTER_DESC.BILL_REGISTERID = PURCHASEMASTER.BILL_REGISTERID INNER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id ", " AND ITEM_NAME = '" & DRITEM("ITEMNAME") & "' AND CAST(BILL_DATE AS DATE)>= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(BILL_DATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_YEARID = " & YEARID)
                    'WE HAVE CHANGED AVG RATE TO GRIDTOTAL AS PER JITU BHAI'S REQUEST
                    DT = OBJCMN.search(" ISNULL(ROUND(SUM(BILL_GRIDTOTAL)/SUM(BILL_QTY),2),0) AS RATE ", "", " PURCHASEMASTER_DESC INNER JOIN PURCHASEMASTER ON PURCHASEMASTER_DESC.BILL_no = PURCHASEMASTER.BILL_NO AND PURCHASEMASTER_DESC.BILL_REGISTERID = PURCHASEMASTER.BILL_REGISTERID INNER JOIN ITEMMASTER ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id ", " AND ITEM_NAME = '" & DRITEM("ITEMNAME") & "' AND CAST(BILL_DATE AS DATE)>= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(BILL_DATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "' AND PURCHASEMASTER.BILL_YEARID = " & YEARID)
                    If DT.Rows.Count > 0 Then
                        If Val(DT.Rows(0).Item(0)) > 0 Then RATE = Format(Val(DT.Rows(0).Item(0)), "0.00") Else GoTo LINE1
                    Else
LINE1:
                        'FETCH DEFAULT RATE
                        DT = OBJCMN.search(" TOP 1 ITEMMASTER_RATEDESC.ITEM_RATE AS RATE ", "", " ITEMMASTER_RATEDESC INNER JOIN ITEMMASTER ON ITEMMASTER_RATEDESC.ITEM_ID = ITEMMASTER.item_id  INNER JOIN PURCHASEMASTER_DESC ON PURCHASEMASTER_DESC.BILL_ITEMID = ITEMMASTER.item_id INNER JOIN PURCHASEMASTER ON PURCHASEMASTER_DESC.BILL_INITIALS = PURCHASEMASTER.BILL_INITIALS AND PURCHASEMASTER_DESC.BILL_yearid = PURCHASEMASTER.BILL_YEARID ", " AND ITEM_NAME = '" & DRITEM("ITEMNAME") & "' AND ITEMMASTER.ITEM_YEARID = " & YEARID)
                        If DT.Rows.Count > 0 Then RATE = Format(Val(DT.Rows(0).Item(0)), "0.00") Else RATE = 0
                    End If


                    'GET OPENING
                    If CHKSTATE = True Then
                        DT = OBJCMN.search(" ISNULL(SUM(BALANCE),0) AS OPENING", "", " STORESTOCK_DETAILS ", " AND ITEMNAME = '" & DRITEM("ITEMNAME") & "' AND DATE < '" & Format(FROMDATE, "MM/dd/yyyy") & "'  AND YEARID = " & YEARID)
                        If DT.Rows.Count > 0 Then
                            OPENING = Format(Val(DT.Rows(0).Item("OPENING")), "0.00")
                            OPENINGVALUE = Format(Val(DT.Rows(0).Item("OPENING")) * RATE, "0.00")
                            OPENINGTOTAL += Format(Val(DT.Rows(0).Item("OPENING")), "0.00")
                            OPENINGVALUETOTAL += Format(Val(DT.Rows(0).Item("OPENING")) * RATE, "0.00")
                        End If
                    End If
                    If CHKSTATE = False Or (CHKSTATE = True And Val(OPENING) = 0) Then
                        DT = OBJCMN.search(" ISNULL(SUM(OPENING),0) AS OPENING", "", " STORESTOCK_DETAILS ", " AND ITEMNAME = '" & DRITEM("ITEMNAME") & "' AND CAST(DATE AS DATE)= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND YEARID = " & YEARID)
                        If DT.Rows.Count > 0 Then
                            OPENING = Format(Val(DT.Rows(0).Item(0)), "0.00")
                            OPENINGVALUE = Format(Val(DT.Rows(0).Item(0)) * RATE, "0.00")
                            OPENINGTOTAL += Format(Val(DT.Rows(0).Item(0)), "0.00")
                            OPENINGVALUETOTAL += Format(Val(DT.Rows(0).Item(0)) * RATE, "0.00")
                        End If
                    End If

                    'GET INWARD
                    DT = OBJCMN.search(" ISNULL(SUM(INWARDS),0) AS INWARD", "", " STORESTOCK_DETAILS ", " AND ITEMNAME = '" & DRITEM("ITEMNAME") & "' AND CAST(DATE AS DATE)>= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(DATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "' AND YEARID = " & YEARID)
                    If DT.Rows.Count > 0 Then
                        INWARD = Format(Val(DT.Rows(0).Item(0)), "0.00")
                        INWARDVALUE = Format(Val(DT.Rows(0).Item(0)) * RATE, "0.00")
                        INWARDTOTAL += Format(Val(DT.Rows(0).Item(0)), "0.00")
                        INWARDVALUETOTAL += Format(Val(DT.Rows(0).Item(0)) * RATE, "0.00")
                    End If


                    'GET OUTWARD
                    DT = OBJCMN.search(" ISNULL(SUM(RETURNING),0) AS OUTWARD", "", " STORESTOCK_DETAILS ", " AND ITEMNAME = '" & DRITEM("ITEMNAME") & "' AND CAST(DATE AS DATE)>= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(DATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "' AND YEARID = " & YEARID)
                    If DT.Rows.Count > 0 Then
                        OUTWARD = Format(Val(DT.Rows(0).Item(0)), "0.00")
                        OUTWARDVALUE = Format(Val(DT.Rows(0).Item(0)) * RATE, "0.00")
                        OUTWARDTOTAL += Format(Val(DT.Rows(0).Item(0)), "0.00")
                        OUTWARDVALUETOTAL += Format(Val(DT.Rows(0).Item(0)) * RATE, "0.00")
                    End If


                    'GET DESPATCH
                    DT = OBJCMN.search(" ISNULL(SUM(DESPATCH),0) AS DESPATCH", "", " STORESTOCK_DETAILS ", " AND ITEMNAME = '" & DRITEM("ITEMNAME") & "' AND CAST(DATE AS DATE)>= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(DATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "' AND YEARID = " & YEARID)
                    If DT.Rows.Count > 0 Then
                        DESPATCH = Format(Val(DT.Rows(0).Item(0)), "0.00")
                        DESPATCHVALUE = Format(Val(DT.Rows(0).Item(0)) * RATE, "0.00")
                        DESPATCHTOTAL += Format(Val(DT.Rows(0).Item(0)), "0.00")
                        DESPATCHVALUETOTAL += Format(Val(DT.Rows(0).Item(0)) * RATE, "0.00")
                    End If


                    'GET BALANCE
                    'DT = OBJCMN.search(" ISNULL(SUM(BALANCE),0) AS BALANCE", "", " STORESTOCK_DETAILS ", " AND ITEMNAME = '" & DRITEM("ITEMNAME") & "' AND CAST(DATE AS DATE)>= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(DATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "' AND YEARID = " & YEARID)
                    BALANCE = Format((Val(OPENING) + Val(INWARD)) - ((Val(OUTWARD) * (-1)) + (Val(DESPATCH) * (-1))), "0.00")
                    BALANCEVALUE = Format((Val(OPENINGVALUE) + Val(INWARDVALUE)) - ((Val(OUTWARDVALUE) * (-1)) + (Val(DESPATCHVALUE) * (-1))), "0.00")
                    BALANCETOTAL += Format((Val(OPENING) + Val(INWARD)) - ((Val(OUTWARD) * (-1)) + (Val(DESPATCH) * (-1))), "0.00")
                    BALANCEVALUETOTAL += Format((Val(OPENINGVALUE) + Val(INWARDVALUE)) - ((Val(OUTWARDVALUE) * (-1)) + (Val(DESPATCHVALUE) * (-1))), "0.00")

                Next
            End If


            'TOTAL OF LAST DEPARTMENT
            RowIndex += 1
            Write(DEPTNAME, Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write(OPENINGTOTAL, Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            Write(OPENINGVALUETOTAL, Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            Write(INWARDTOTAL, Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            Write(INWARDVALUETOTAL, Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            Write(OUTWARDTOTAL, Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            Write(OUTWARDVALUETOTAL, Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            Write(DESPATCHTOTAL, Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            Write(DESPATCHVALUETOTAL, Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            Write(BALANCETOTAL, Range("11"), XlHAlign.xlHAlignRight, , True, 10)
            Write(BALANCEVALUETOTAL, Range("12"), XlHAlign.xlHAlignRight, , True, 10)

            'SetBorder(RowIndex, objColumn.Item("1").ToString & 7, objColumn.Item("1").ToString & RowIndex)
            'SetBorder(RowIndex, objColumn.Item("2").ToString & 7, objColumn.Item("2").ToString & RowIndex)

            RowIndex += 1
            Write("Total", Range("1"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 8 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 8 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 8 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 8 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 8 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 8 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 8 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 8 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 8 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 11)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 8 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 11)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)

            objSheet.Range(objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("12").ToString & 8, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.00"


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PURCHASE TAX DETAILS REPORT"

    Public Function PURCHASE_TAX_DETAILS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim objCMN As New ClsCommon
            'Dim DTVAL As System.Data.DataTable
            Dim DT As System.Data.DataTable = objCMN.search(" * ", "", " (SELECT HOTELBOOKINGMASTER.BOOKING_PURBILLINITIALS AS BILLNO, HOTELBOOKINGMASTER.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOTELBOOKINGMASTER.BOOKING_PURGRANDTOTAL AS GRANDTOTAL, HOTELBOOKINGMASTER.BOOKING_PURSUBTOTAL AS NETT, HOTELBOOKINGMASTER.BOOKING_PURNETTAMT AS SUBTOTAL, HOTELBOOKINGMASTER.BOOKING_PURTAXID AS TAXID, HOTELBOOKINGMASTER.BOOKING_PURTAX AS TAXAMT, HOTELBOOKINGMASTER.BOOKING_PURADDTAXID AS ADDTAXID, HOTELBOOKINGMASTER.BOOKING_PURADDTAX AS ADDTAXAMT, HOTELBOOKINGMASTER.BOOKING_PUROTHERCHGS AS OTHERCHGS, HOTELBOOKINGMASTER.BOOKING_PURROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOTELBOOKINGMASTER.BOOKING_NO AS BILL, 'HOTELBOOKING' AS TYPE, BOOKING_CMPID AS CMPID, BOOKING_LOCATIONID AS LOCATIONID, BOOKING_YEARID AS YEARID FROM HOTELBOOKINGMASTER INNER JOIN CMPMASTER ON HOTELBOOKINGMASTER.BOOKING_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN LEDGERS ON HOTELBOOKINGMASTER.BOOKING_YEARID = LEDGERS.Acc_yearid AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOTELBOOKINGMASTER.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOTELBOOKINGMASTER.BOOKING_PURLEDGERID = LEDGERS.Acc_id WHERE HOTELBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE' AND HOTELBOOKINGMASTER.BOOKING_AMD_DONE = 'FALSE' UNION ALL Select DISTINCT HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS BILLNO, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_SUBTOTAL AS NETT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NETT AS SUBTOTAL, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TAXID AS TAXID, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXID AS ADDTAXID, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ADDTAXAMT AS ADDTAXAMT, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NO AS BILL, 'PACKAGE' AS TYPE, HOLIDAYPACKAGEMASTER.BOOKING_CMPID AS CMPID, HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AS LOCATIONID, HOLIDAYPACKAGEMASTER.BOOKING_YEARID AS YEARID FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS INNER JOIN CMPMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN HOLIDAYPACKAGEMASTER ON HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_NO = HOLIDAYPACKAGEMASTER.BOOKING_NO AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_CMPID = HOLIDAYPACKAGEMASTER.BOOKING_CMPID AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = HOLIDAYPACKAGEMASTER.BOOKING_LOCATIONID AND HOLIDAYPACKAGEMASTER_PURCHASEDETAILS.BOOKING_YEARID = HOLIDAYPACKAGEMASTER.BOOKING_YEARID WHERE (HOLIDAYPACKAGEMASTER.BOOKING_CANCELLED = 'FALSE') AND (HOLIDAYPACKAGEMASTER.BOOKING_AMD_DONE = 'FALSE') UNION ALL Select DISTINCT INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURBILLINITIALS AS BILLNO, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_GTOTAL AS GRANDTOTAL, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_SUBTOTAL AS NETT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NETT AS SUBTOTAL, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXID AS TAXID, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_TAXAMT AS TAXAMT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ADDTAXID AS ADDTAXID, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ADDTAXAMT AS ADDTAXAMT, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_OTHERCHGS AS OTHERCHGS, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS, INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO AS BILL, 'INTERNATIONAL' AS TYPE, INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AS CMPID, INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AS LOCATIONID, INTERNATIONALBOOKINGMASTER.BOOKING_YEARID AS YEARID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS INNER JOIN CMPMASTER ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = CMPMASTER.cmp_id INNER JOIN LEDGERS ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_PURLEDGERID = LEDGERS.Acc_id AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = LEDGERS.Acc_cmpid AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = LEDGERS.Acc_locationid AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = LEDGERS.Acc_yearid INNER JOIN INTERNATIONALBOOKINGMASTER ON INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_NO = INTERNATIONALBOOKINGMASTER.BOOKING_NO AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_CMPID = INTERNATIONALBOOKINGMASTER.BOOKING_CMPID AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_LOCATIONID = INTERNATIONALBOOKINGMASTER.BOOKING_LOCATIONID AND INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS.BOOKING_YEARID = INTERNATIONALBOOKINGMASTER.BOOKING_YEARID WHERE (INTERNATIONALBOOKINGMASTER.BOOKING_CANCELLED = 'FALSE') AND (INTERNATIONALBOOKINGMASTER.BOOKING_AMD_DONE = 'FALSE')) AS T ", CONDITION & " ORDER BY T.TYPE,T.DATE, T.BILL ")
            'Dim DT As System.Data.DataTable = objCMN.search(" PURCHASEMASTER.BILL_NO AS BILLNO, PURCHASEMASTER.BILL_DATE AS DATE, VENDORMASTER.VENDOR_cmpname AS NAME, PURCHASEMASTER.BILL_GRANDTOTAL AS GRANDTOTAL, PURCHASEMASTER.BILL_NETT AS NETT, (PURCHASEMASTER.BILL_NETT + PURCHASEMASTER.BILL_EXCISEAMT + PURCHASEMASTER.BILL_EDUCESSAMT + PURCHASEMASTER.BILL_HSECESSAMT) AS SUBTOTAL, ISNULL(PURCHASEMASTER.BILL_EXCISEID,'') AS EXCISEID, ISNULL(PURCHASEMASTER.BILL_EXCISEAMT,0) AS EXCISEAMT, ISNULL(PURCHASEMASTER.BILL_EDUCESSAMT,0) AS EDUCESSAMT, ISNULL(PURCHASEMASTER.BILL_HSECESSAMT,0) AS HSECESSAMT , ISNULL(PURCHASEMASTER.BILL_TAXID,'') AS TAXID, ISNULL(PURCHASEMASTER.BILL_TAXAMT,0) AS TAXAMT , ISNULL(PURCHASEMASTER.BILL_ADDTAXID,'') AS ADDTAXID, ISNULL(PURCHASEMASTER.BILL_ADDTAXAMT,0) AS ADDTAXAMT , PURCHASEMASTER.BILL_FREIGHT AS FREIGHT, PURCHASEMASTER.BILL_OCTROIAMT AS OCTROIAMT, PURCHASEMASTER.BILL_INSAMT AS INSAMT, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS ", "", " PURCHASEMASTER INNER JOIN CMPMASTER ON PURCHASEMASTER.BILL_CMPID = CMPMASTER.cmp_id INNER JOIN VENDORMASTER ON VENDORMASTER.VENDOR_id = PURCHASEMASTER.BILL_LEDGERID AND VENDORMASTER.VENDOR_cmpid = PURCHASEMASTER.BILL_CMPID AND VENDORMASTER.VENDOR_locationid = PURCHASEMASTER.BILL_LOCATIONID AND VENDORMASTER.VENDOR_yearid = PURCHASEMASTER.BILL_YEARID", CONDITION & " ORDER BY BILL_NO")

            If DT.Rows.Count > 0 Then


                'FOR TAXAMT
                Dim DTTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_PURTAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_TAXID  FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS UNION ALL  SELECT BOOKING_TAXID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTTAX.Rows.Count > 0 Then
                    For Each DRTAX As DataRow In DTTAX.Rows
                        DT.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                        DT.Columns.Add(DRTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("TAXID = " & DRTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_TAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL")
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0
                            'For i As Integer = 16 To DT.Columns.Count - 1
                            '    If IsDBNull(DR(i)) = False Then DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DR("SUBTOTAL " & DRTAX("TAXNAME"))) + Convert.ToDouble(DR(i))
                            'Next
                            'DR("SUBTOTAL " & DRTAX("TAXNAME")) = DR("SUBTOTAL " & DRTAX("TAXNAME")) + DR("NETT")
                            DR(DRTAX("TAXNAME")) = DR("TAXAMT")
                        Next
                    Next
                End If



                'FOR ADDTAXAMT
                Dim COLINDEX As Integer = 0
                Dim DTADDTAX As System.Data.DataTable = objCMN.search(" DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER ", " AND TAX_ID IN (SELECT BOOKING_PURADDTAXID FROM HOTELBOOKINGMASTER UNION ALL SELECT BOOKING_ADDTAXID  FROM HOLIDAYPACKAGEMASTER_PURCHASEDETAILS UNION ALL  SELECT BOOKING_ADDTAXID FROM INTERNATIONALBOOKINGMASTER_PURCHASEDETAILS) AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
                If DTADDTAX.Rows.Count > 0 Then
                    For Each DRADDTAX As DataRow In DTADDTAX.Rows
                        COLINDEX = DT.Columns.IndexOf(DRADDTAX("TAXNAME"))
                        If COLINDEX = 0 Then DT.Columns.Add(DRADDTAX("TAXNAME"))
                        For Each DR As DataRow In DT.Select("ADDTAXID = " & DRADDTAX("TAXID") & " OR TAXID = " & DRADDTAX("TAXID"))
                            'DTVAL = objCMN.search("PURCHASEMASTER.BILL_ADDTAXAMT AS TAXAMT", "", " PURCHASEMASTER", " AND BILL_NO = " & DR("BILLNO") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                            If IsDBNull(DR(DRADDTAX("TAXNAME"))) = False Then
                                DR(DRADDTAX("TAXNAME")) = Val(DR(DRADDTAX("TAXNAME"))) + DR("ADDTAXAMT")
                            Else
                                DR(DRADDTAX("TAXNAME")) = DR("ADDTAXAMT")
                            End If
                        Next
                    Next
                End If



                SetWorkSheet()
                For I As Integer = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For i As Integer = 1 To 26
                    SetColumnWidth(Range(i), 11)
                Next

                SetColumnWidth("A1", 6)
                SetColumnWidth("B1", 10)
                SetColumnWidth("C1", 30)



                'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
                'COZ HERE WE DONT KNOW NO OF COLUMS
                RowIndex += 6
                Write("Inv No.", Range("1"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("G. Total", Range("4"), XlHAlign.xlHAlignCenter, , True, 9)
                Write("Nett Total", Range("5"), XlHAlign.xlHAlignCenter, , True, 9)
                Dim T As Integer = 6
                For S As Integer = 21 To DT.Columns.Count - 1
                    Write(DT.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                    T = T + 1
                Next
                Write("Other Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)
                T = T + 1
                Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 9, True)


                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex)


                For Each dr As DataRow In DT.Rows
                    RowIndex += 1
                    Write(dr("BILLNO"), Range("1"), XlHAlign.xlHAlignCenter, , False, 9)
                    Write(dr("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                    Write(dr("GRANDTOTAL"), Range("4"), XlHAlign.xlHAlignRight, , False, 9)
                    Write(dr("NETT"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                    Dim R As Integer = 6
                    For I As Integer = 21 To DT.Columns.Count - 1
                        Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                        objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                        R = R + 1
                    Next

                    Write(dr("OTHERCHGS"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1

                    Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 9)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

                Next

                For I As Integer = 1 To DT.Columns.Count - 14
                    SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DT.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
                Next


                RowIndex += 1
                Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("3"), True, 9)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("3"))

                Write(DT.Compute("sum(GRANDTOTAL)", ""), Range("4"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
                Write(DT.Compute("sum(NETT)", ""), Range("5"), XlHAlign.xlHAlignRight, Range("5"), True, 9)
                SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, Range("4"))
                SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))

                Dim M As Integer = 6
                For I As Integer = 21 To DT.Columns.Count - 1
                    FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DT.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 9)
                    SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                    M = M + 1
                Next

                Write(DT.Compute("sum(OTHERCHGS)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
                Write(DT.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 9)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


                'RowIndex += 1
                'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 9)
                'Write(DT.Rows(0).Item("STATUS"), Range("14"), XlHAlign.xlHAlignLeft, Range("25"), True, 9)
                'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

                objSheet.Range(objColumn.Item("4").ToString & 1, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
                objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


                SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & RowIndex + 2)


                '''''''''''Report Title
                'CMPNAME
                RowIndex = 2
                Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 14)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD1
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'ADD2
                RowIndex += 1
                Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 9)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))


                RowIndex += 1
                Write("Purchase-TAX DETAILS REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DT.Columns.Count) - 14).ToString), True, 12)
                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                SetBorder(RowIndex, Range("1"), Range(((DT.Columns.Count) - 14).ToString))

                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Select()
                objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DT.Columns.Count) - 14).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


                objBook.Application.ActiveWindow.Zoom = 95

                'With objSheet.PageSetup
                '    .Orientation = XlPageOrientation.xlLandscape
                '    .TopMargin = 144
                '    .LeftMargin = 50.4
                '    .RightMargin = 0
                '    .BottomMargin = 0
                '    .Zoom = False
                '    .FitToPagesTall = 1
                '    .FitToPagesWide = 1
                'End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SALES TAX SUMMARY REPORT"

    Public Function SALES_TAX_SUMMARY_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            Dim DTMONTH As New System.Data.DataTable
            DTMONTH.Columns.Add("MONTH")

            DTMONTH.Rows.Add(4)
            DTMONTH.Rows.Add(5)
            DTMONTH.Rows.Add(6)
            DTMONTH.Rows.Add(7)
            DTMONTH.Rows.Add(8)
            DTMONTH.Rows.Add(9)
            DTMONTH.Rows.Add(10)
            DTMONTH.Rows.Add(11)
            DTMONTH.Rows.Add(12)
            DTMONTH.Rows.Add(1)
            DTMONTH.Rows.Add(2)
            DTMONTH.Rows.Add(3)

            DTMONTH.Columns.Add("GRANDTOTAL")
            DTMONTH.Columns.Add("NETTAMT")


            Dim objCMN As New ClsCommon
            Dim DTVAL As System.Data.DataTable
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_GRANDTOTAL),0) AS GRANDTOTAL, ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_SUBTOTAL),0) AS NETTAMT", "", " HOTELBOOKINGMASTER", " AND BOOKING_BOOKTYPE = 'BOOKING' AND MONTH(BOOKING_DATE) = " & Val(DR("MONTH")) & " AND BOOKING_CMPID = " & CMPID & " AND BOOKING_LOCATIONID = " & LOCATIONID & " AND BOOKING_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("GRANDTOTAL") = Convert.ToDouble(DTVAL.Rows(0).Item("GRANDTOTAL"))
                    DR("NETTAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("NETTAMT"))
                Else
                    DR("GRANDTOTAL") = 0.0
                    DR("NETTAMT") = 0.0
                End If
            Next


            'FOR EXCISE AMT
            'Dim DTEXCISE As System.Data.DataTable = objCMN.search("DISTINCT EXCISE_ID AS EXCISEID, EXCISE_NAME AS EXCISENAME, EXCISE_EDU AS EDU, EXCISE_HSE AS HSE", "", " EXCISEMASTER RIGHT OUTER JOIN INVOICEMASTER ON EXCISEMASTER.EXCISE_yearid = INVOICEMASTER.INVOICE_YEARID AND EXCISEMASTER.EXCISE_locationid = INVOICEMASTER.INVOICE_LOCATIONID AND EXCISEMASTER.EXCISE_cmpid = INVOICEMASTER.INVOICE_CMPID AND EXCISEMASTER.EXCISE_id = INVOICEMASTER.INVOICE_EXCISEID ", " AND EXCISE_CMPID = " & CMPID & " AND EXCISE_LOCATIONID = " & LOCATIONID & " AND EXCISE_YEARID = " & YEARID)
            'If DTEXCISE.Rows.Count > 0 Then
            '    For Each DREXCISE As DataRow In DTEXCISE.Rows
            '        DTMONTH.Columns.Add("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales")
            '        DTMONTH.Columns.Add("Edu Cess @" & DREXCISE("EDU") & "%- Sales")
            '        DTMONTH.Columns.Add("S & H @" & DREXCISE("HSE") & "%- Sales")
            '        For Each DR As DataRow In DTMONTH.Rows
            '            DTVAL = objCMN.search(" ISNULL(SUM(INVOICEMASTER.INVOICE_EXCISEAMT),0) AS EXCISEAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_EDUCESSAMT),0) AS EDUCESSAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_HSECESSAMT),0) AS HSECESSAMT", "", " INVOICEMASTER", " AND INVOICE_EXCISEID = " & DTEXCISE.Rows(0).Item("EXCISEID") & " AND MONTH(INVOICE_DATE) = " & Val(DR("MONTH")) & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '            If DTVAL.Rows.Count > 0 Then
            '                DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("EXCISEAMT"))
            '                DR("Edu Cess @" & DREXCISE("EDU") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("EDUCESSAMT"))
            '                DR("S & H @" & DREXCISE("HSE") & "%- Sales") = Convert.ToDouble(DTVAL.Rows(0).Item("HSECESSAMT"))
            '            Else
            '                DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Sales") = 0.0
            '                DR("Edu Cess @" & DREXCISE("EDU") & "%- Sales") = 0.0
            '                DR("S & H @" & DREXCISE("HSE") & "%- Sales") = 0.0
            '            End If
            '        Next
            '    Next
            'End If



            'FOR TAXAMT
            Dim DTTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN HOTELBOOKINGMASTER ON TAXMASTER.TAX_yearid = HOTELBOOKINGMASTER.BOOKING_YEARID AND TAXMASTER.TAX_locationid = HOTELBOOKINGMASTER.BOOKING_LOCATIONID AND TAXMASTER.TAX_cmpid = HOTELBOOKINGMASTER.BOOKING_CMPID AND TAXMASTER.TAX_id = HOTELBOOKINGMASTER.BOOKING_TAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTTAX.Rows.Count > 0 Then
                For Each DRTAX As DataRow In DTTAX.Rows
                    DTMONTH.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                    DTMONTH.Columns.Add(DRTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_SUBTOTAL),0) AS SUBTOTAL, ISNULL(SUM(HOTELBOOKINGMASTER.BOOKING_TAX),0) AS TAXAMT ", "", " HOTELBOOKINGMASTER", " AND HOTELBOOKINGMASTER.BOOKING_TAXID = " & DRTAX("TAXID") & " AND HOTELBOOKINGMASTER.BOOKING_BOOKTYPE = 'BOOKING' AND MONTH(HOTELBOOKINGMASTER.BOOKING_DATE) = " & Val(DR("MONTH")) & " AND HOTELBOOKINGMASTER.BOOKING_CMPID = " & CMPID & " AND HOTELBOOKINGMASTER.BOOKING_LOCATIONID = " & LOCATIONID & " AND HOTELBOOKINGMASTER.BOOKING_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("SUBTOTAL"))
                            DR(DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("TAXAMT"))
                        Else
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0.0
                            DR(DRTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


            ''FOR ADDTAXAMT
            'Dim DTADDTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN INVOICEMASTER ON TAXMASTER.TAX_yearid = INVOICEMASTER.INVOICE_YEARID AND TAXMASTER.TAX_locationid = INVOICEMASTER.INVOICE_LOCATIONID AND TAXMASTER.TAX_cmpid = INVOICEMASTER.INVOICE_CMPID AND TAXMASTER.TAX_id = INVOICEMASTER.INVOICE_ADDTAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            'If DTADDTAX.Rows.Count > 0 Then
            '    For Each DRADDTAX As DataRow In DTADDTAX.Rows
            '        DTMONTH.Columns.Add(DRADDTAX("TAXNAME"))
            '        For Each DR As DataRow In DTMONTH.Rows
            '            DTVAL = objCMN.search("ISNULL(SUM(INVOICEMASTER.INVOICE_ADDTAXAMT),0) AS ADDTAXAMT", "", " INVOICEMASTER", " AND INVOICE_ADDTAXID = " & DRADDTAX("TAXID") & " AND MONTH(INVOICE_DATE)= " & DR("MONTH") & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '            If DTVAL.Rows.Count > 0 Then
            '                DR(DRADDTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("ADDTAXAMT"))
            '            Else
            '                DR(DRADDTAX("TAXNAME")) = 0.0
            '            End If
            '        Next
            '    Next
            'End If


            'DTMONTH.Columns.Add("FREIGHT")
            'DTMONTH.Columns.Add("OCTROIAMT")
            'DTMONTH.Columns.Add("INSAMT")
            'DTMONTH.Columns.Add("ROUNDOFF")
            'For Each DR As DataRow In DTMONTH.Rows
            '    DTVAL = objCMN.search(" ISNULL(SUM(INVOICEMASTER.INVOICE_FREIGHT),0) AS FREIGHT, ISNULL(SUM(INVOICEMASTER.INVOICE_OCTROIAMT),0) AS OCTROIAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_INSAMT),0) AS INSAMT, ISNULL(SUM(INVOICEMASTER.INVOICE_ROUNDOFF),0) AS ROUNDOFF", "", " INVOICEMASTER", " AND MONTH(INVOICE_DATE) = " & Val(DR("MONTH")) & " AND INVOICE_CMPID = " & CMPID & " AND INVOICE_LOCATIONID = " & LOCATIONID & " AND INVOICE_YEARID = " & YEARID)
            '    If DTVAL.Rows.Count > 0 Then
            '        DR("FREIGHT") = Convert.ToDouble(DTVAL.Rows(0).Item("FREIGHT"))
            '        DR("OCTROIAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("OCTROIAMT"))
            '        DR("INSAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("INSAMT"))
            '        DR("ROUNDOFF") = Convert.ToDouble(DTVAL.Rows(0).Item("ROUNDOFF"))
            '    Else
            '        DR("FREIGHT") = 0.0
            '        DR("OCTROIAMT") = 0.0
            '        DR("INSAMT") = 0.0
            '        DR("ROUNDOFF") = 0.0
            '    End If
            'Next



            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("A1", 11)



            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            RowIndex += 6
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("G. Total", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Nett Total", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Dim T As Integer = 4
            For S As Integer = 3 To DTMONTH.Columns.Count - 5
                Write(DTMONTH.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
                T = T + 1
            Next
            'Write("Freight", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Octroi", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Inspection Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            'T = T + 1
            'Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTMONTH.Columns.Count).ToString).ToString & RowIndex)


            For Each dr As DataRow In DTMONTH.Rows
                RowIndex += 1
                Write(MonthName(dr("MONTH")), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(dr("GRANDTOTAL"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("NETTAMT"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Dim R As Integer = 4
                For I As Integer = 3 To DTMONTH.Columns.Count - 5
                    Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1
                Next

                'Write(dr("FREIGHT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("OCTROIAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("INSAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                'R = R + 1

                'Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                'objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

            Next

            For I As Integer = 1 To DTMONTH.Columns.Count
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DTMONTH.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))


            Dim M As Integer = 2
            For I As Integer = 1 To DTMONTH.Columns.Count - 1
                FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DTMONTH.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
            Next

            'Write(DTMONTH.Compute("sum(FREIGHT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(OCTROIAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(INSAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


            'RowIndex += 1
            'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            'Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & RowIndex + 2)


            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            RowIndex += 1
            Write("SALES-TAX SUMMARY REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


            objBook.Application.ActiveWindow.Zoom = 95

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 144
            '    .LeftMargin = 50.4
            '    .RightMargin = 0
            '    .BottomMargin = 0
            '    .Zoom = False
            '    .FitToPagesTall = 1
            '    .FitToPagesWide = 1
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PURCHASE TAX SUMMARY REPORT"

    Public Function PURCHASE_TAX_SUMMARY_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            Dim DTMONTH As New System.Data.DataTable
            DTMONTH.Columns.Add("MONTH")

            DTMONTH.Rows.Add(4)
            DTMONTH.Rows.Add(5)
            DTMONTH.Rows.Add(6)
            DTMONTH.Rows.Add(7)
            DTMONTH.Rows.Add(8)
            DTMONTH.Rows.Add(9)
            DTMONTH.Rows.Add(10)
            DTMONTH.Rows.Add(11)
            DTMONTH.Rows.Add(12)
            DTMONTH.Rows.Add(1)
            DTMONTH.Rows.Add(2)
            DTMONTH.Rows.Add(3)

            DTMONTH.Columns.Add("GRANDTOTAL")
            DTMONTH.Columns.Add("NETTAMT")


            Dim objCMN As New ClsCommon
            Dim DTVAL As System.Data.DataTable
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_GRANDTOTAL),0) AS GRANDTOTAL, ISNULL(SUM(PURCHASEMASTER.BILL_NETT),0) AS NETTAMT", "", " PURCHASEMASTER", " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("GRANDTOTAL") = Convert.ToDouble(DTVAL.Rows(0).Item("GRANDTOTAL"))
                    DR("NETTAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("NETTAMT"))
                Else
                    DR("GRANDTOTAL") = 0.0
                    DR("NETTAMT") = 0.0
                End If
            Next


            'FOR EXCISE AMT
            Dim DTEXCISE As System.Data.DataTable = objCMN.search("DISTINCT EXCISE_ID AS EXCISEID, EXCISE_NAME AS EXCISENAME, EXCISE_EDU AS EDU, EXCISE_HSE AS HSE", "", " EXCISEMASTER RIGHT OUTER JOIN PURCHASEMASTER ON EXCISEMASTER.EXCISE_yearid = PURCHASEMASTER.BILL_YEARID AND EXCISEMASTER.EXCISE_locationid = PURCHASEMASTER.BILL_LOCATIONID AND EXCISEMASTER.EXCISE_cmpid = PURCHASEMASTER.BILL_CMPID AND EXCISEMASTER.EXCISE_id = PURCHASEMASTER.BILL_EXCISEID ", " AND EXCISE_CMPID = " & CMPID & " AND EXCISE_LOCATIONID = " & LOCATIONID & " AND EXCISE_YEARID = " & YEARID)
            If DTEXCISE.Rows.Count > 0 Then
                For Each DREXCISE As DataRow In DTEXCISE.Rows
                    DTMONTH.Columns.Add("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase")
                    DTMONTH.Columns.Add("Edu Cess @" & DREXCISE("EDU") & "%- Purchase")
                    DTMONTH.Columns.Add("S & H @" & DREXCISE("HSE") & "%- Purchase")
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_EXCISEAMT),0) AS EXCISEAMT, ISNULL(SUM(PURCHASEMASTER.BILL_EDUCESSAMT),0) AS EDUCESSAMT, ISNULL(SUM(PURCHASEMASTER.BILL_HSECESSAMT),0) AS HSECESSAMT", "", " PURCHASEMASTER", " AND BILL_EXCISEID = " & DTEXCISE.Rows(0).Item("EXCISEID") & " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("EXCISEAMT"))
                            DR("Edu Cess @" & DREXCISE("EDU") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("EDUCESSAMT"))
                            DR("S & H @" & DREXCISE("HSE") & "%- Purchase") = Convert.ToDouble(DTVAL.Rows(0).Item("HSECESSAMT"))
                        Else
                            DR("Exice Duty @" & DREXCISE("EXCISENAME") & "%- Purchase") = 0.0
                            DR("Edu Cess @" & DREXCISE("EDU") & "%- Purchase") = 0.0
                            DR("S & H @" & DREXCISE("HSE") & "%- Purchase") = 0.0
                        End If
                    Next
                Next
            End If



            'FOR TAXAMT
            Dim DTTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN PURCHASEMASTER ON TAXMASTER.TAX_yearid = PURCHASEMASTER.BILL_YEARID AND TAXMASTER.TAX_locationid = PURCHASEMASTER.BILL_LOCATIONID AND TAXMASTER.TAX_cmpid = PURCHASEMASTER.BILL_CMPID AND TAXMASTER.TAX_id = PURCHASEMASTER.BILL_TAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTTAX.Rows.Count > 0 Then
                For Each DRTAX As DataRow In DTTAX.Rows
                    DTMONTH.Columns.Add("SUBTOTAL " & DRTAX("TAXNAME"))
                    DTMONTH.Columns.Add(DRTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_SUBTOTAL),0) AS SUBTOTAL, ISNULL(SUM(PURCHASEMASTER.BILL_TAXAMT),0) AS TAXAMT ", "", " PURCHASEMASTER", " AND BILL_TAXID = " & DTTAX.Rows(0).Item("TAXID") & " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("SUBTOTAL"))
                            DR(DRTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("TAXAMT"))
                        Else
                            DR("SUBTOTAL " & DRTAX("TAXNAME")) = 0.0
                            DR(DRTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


            'FOR ADDTAXAMT
            Dim DTADDTAX As System.Data.DataTable = objCMN.search("DISTINCT TAX_ID AS TAXID, TAX_NAME AS TAXNAME", "", " TAXMASTER RIGHT OUTER JOIN PURCHASEMASTER ON TAXMASTER.TAX_yearid = PURCHASEMASTER.BILL_YEARID AND TAXMASTER.TAX_locationid = PURCHASEMASTER.BILL_LOCATIONID AND TAXMASTER.TAX_cmpid = PURCHASEMASTER.BILL_CMPID AND TAXMASTER.TAX_id = PURCHASEMASTER.BILL_ADDTAXID ", " AND TAX_CMPID = " & CMPID & " AND TAX_LOCATIONID = " & LOCATIONID & " AND TAX_YEARID = " & YEARID)
            If DTADDTAX.Rows.Count > 0 Then
                For Each DRADDTAX As DataRow In DTADDTAX.Rows
                    DTMONTH.Columns.Add(DRADDTAX("TAXNAME"))
                    For Each DR As DataRow In DTMONTH.Rows
                        DTVAL = objCMN.search("ISNULL(SUM(PURCHASEMASTER.BILL_ADDTAXAMT),0) AS ADDTAXAMT", "", " PURCHASEMASTER", " AND BILL_ADDTAXID = " & DRADDTAX("TAXID") & " AND MONTH(BILL_DATE)= " & DR("MONTH") & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                        If DTVAL.Rows.Count > 0 Then
                            DR(DRADDTAX("TAXNAME")) = Convert.ToDouble(DTVAL.Rows(0).Item("ADDTAXAMT"))
                        Else
                            DR(DRADDTAX("TAXNAME")) = 0.0
                        End If
                    Next
                Next
            End If


            DTMONTH.Columns.Add("FREIGHT")
            DTMONTH.Columns.Add("OCTROIAMT")
            DTMONTH.Columns.Add("INSAMT")
            DTMONTH.Columns.Add("ROUNDOFF")
            For Each DR As DataRow In DTMONTH.Rows
                DTVAL = objCMN.search(" ISNULL(SUM(PURCHASEMASTER.BILL_FREIGHT),0) AS FREIGHT, ISNULL(SUM(PURCHASEMASTER.BILL_OCTROIAMT),0) AS OCTROIAMT, ISNULL(SUM(PURCHASEMASTER.BILL_INSAMT),0) AS INSAMT, ISNULL(SUM(PURCHASEMASTER.BILL_ROUNDOFF),0) AS ROUNDOFF", "", " PURCHASEMASTER", " AND MONTH(BILL_DATE) = " & Val(DR("MONTH")) & " AND BILL_CMPID = " & CMPID & " AND BILL_LOCATIONID = " & LOCATIONID & " AND BILL_YEARID = " & YEARID)
                If DTVAL.Rows.Count > 0 Then
                    DR("FREIGHT") = Convert.ToDouble(DTVAL.Rows(0).Item("FREIGHT"))
                    DR("OCTROIAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("OCTROIAMT"))
                    DR("INSAMT") = Convert.ToDouble(DTVAL.Rows(0).Item("INSAMT"))
                    DR("ROUNDOFF") = Convert.ToDouble(DTVAL.Rows(0).Item("ROUNDOFF"))
                Else
                    DR("FREIGHT") = 0.0
                    DR("OCTROIAMT") = 0.0
                    DR("INSAMT") = 0.0
                    DR("ROUNDOFF") = 0.0
                End If
            Next



            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("A1", 11)



            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            RowIndex += 6
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("G. Total", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Nett Total", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Dim T As Integer = 4
            For S As Integer = 3 To DTMONTH.Columns.Count - 5
                Write(DTMONTH.Columns(S).ColumnName, Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
                T = T + 1
            Next
            Write("Freight", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Octroi", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Inspection Charges", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)
            T = T + 1
            Write("Round Off", Range(T.ToString), XlHAlign.xlHAlignCenter, , True, 10, True)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTMONTH.Columns.Count).ToString).ToString & RowIndex)


            For Each dr As DataRow In DTMONTH.Rows
                RowIndex += 1
                Write(MonthName(dr("MONTH")), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(dr("GRANDTOTAL"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(dr("NETTAMT"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Dim R As Integer = 4
                For I As Integer = 3 To DTMONTH.Columns.Count - 5
                    Write(dr(I), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                    objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                    R = R + 1
                Next

                Write(dr("FREIGHT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("OCTROIAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("INSAMT"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"
                R = R + 1

                Write(dr("ROUNDOFF"), Range(R.ToString), XlHAlign.xlHAlignRight, , False, 10)
                objSheet.Range(objColumn.Item(R.ToString).ToString & 1, objColumn.Item(R.ToString).ToString & RowIndex).NumberFormat = "0.00"

            Next

            For I As Integer = 1 To DTMONTH.Columns.Count
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & RowIndex - DTMONTH.Rows.Count, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))


            Dim M As Integer = 2
            For I As Integer = 1 To DTMONTH.Columns.Count - 1
                FORMULA("=SUM(" & objColumn.Item(M.ToString).ToString & RowIndex - DTMONTH.Rows.Count & ":" & objColumn.Item(M.ToString).ToString & RowIndex - 1 & ")", Range(M.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
                M = M + 1
            Next

            'Write(DTMONTH.Compute("sum(FREIGHT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(OCTROIAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(INSAMT)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))
            'M = M + 1
            'Write(DTMONTH.Compute("sum(ROUNDOFF)", ""), Range(M.ToString), XlHAlign.xlHAlignRight, Range(M.ToString), True, 10)
            'SetBorder(RowIndex, objColumn.Item(M.ToString).ToString & RowIndex, Range(M.ToString))


            'RowIndex += 1
            'Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            'Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            'SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("2").ToString & 1, objColumn.Item("2").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("3").ToString & 1, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & RowIndex + 2)


            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = objCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            RowIndex += 1
            Write("PURCHASE-TAX SUMMARY REPORT", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTMONTH.Columns.Count)).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            SetBorder(RowIndex, Range("1"), Range(((DTMONTH.Columns.Count)).ToString))

            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTMONTH.Columns.Count)).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True


            objBook.Application.ActiveWindow.Zoom = 95

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 144
            '    .LeftMargin = 50.4
            '    .RightMargin = 0
            '    .BottomMargin = 0
            '    .Zoom = False
            '    .FitToPagesTall = 1
            '    .FitToPagesWide = 1
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "GROUP WISE TRANS DETAILS REPORT"

    Public Function GROUP_TRANS_DETAILS_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 11)
            Next

            SetColumnWidth("B1", 40)


            'CMPHEADER
            CMPHEADER(CMPID, "GROUP-WISE TRANSACTION REPORT")



            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            RowIndex += 1
            Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Name", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Type", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Bll No", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Debit", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Credit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            Dim ALCOL(1) As String
            ALCOL(0) = ("ACC_INITIALS")
            ALCOL(1) = ("ACC_BILLNO")

            Dim OBJGROUP As New ClsCommon
            Dim DTALL As System.Data.DataTable = OBJGROUP.search("ACC_BILLDATE AS [DATE], NAME, ACC_TYPE AS [TYPE], ACC_BILLNO, ACC_INITIALS , DR,CR, PRIMARYGROUP ", "", " REGISTER ", CONDITION & " AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & " ORDER BY ACC_BILLDATE")
            Dim DTMAIN As System.Data.DataTable = DTALL.DefaultView.ToTable(True, ALCOL)
            Dim DR() As System.Data.DataRow = DTMAIN.Select("ACC_INITIALS <> '0'", "ACC_BILLNO ASC")
            Dim DR1() As System.Data.DataRow
            For I As Integer = 0 To DR.GetUpperBound(0)

                DR1 = DTALL.Select("ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'")

                Dim DTINITIALPARTY As System.Data.DataTable = OBJGROUP.search(" TOP(1) NAME", "", " REGISTER", " and acc_cmpid = " & CMPID & " and YEARID = " & YEARID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND name NOT IN (SELECT name FROM REGISTER WHERE REGISTER.acc_cmpid = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND REGISTER.YEARID = " & YEARID & CONDITION & ")  and acc_INITIALS = '" & DR(I)("ACC_INITIALS") & "'")
                If DTINITIALPARTY.Rows.Count > 0 Then
                    RowIndex += 2
                    Write(Format(Convert.ToDateTime(DR1(0)("DATE")).Date, "dd/MM/yyyy"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTINITIALPARTY.Rows(0).Item("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DR1(0)("TYPE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DR1(0)("ACC_INITIALS"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTALL.Compute("SUM(CR)", "ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTALL.Compute("SUM(DR)", "ACC_INITIALS = '" & DR(I)("ACC_INITIALS") & "'"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)

                    For A As Integer = 0 To DR1.GetUpperBound(0)

                        RowIndex += 1
                        Write(Format(Convert.ToDateTime(DR1(A)("DATE")).Date, "dd/MM/yyyy"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write("     " & DR1(A)("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10, , True)
                        Write(DR1(A)("TYPE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DR1(A)("ACC_INITIALS"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DR1(A)("DR"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DR1(A)("cr"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Next
                End If

            Next



            For I As Integer = 1 To 6
                SetBorder(RowIndex, objColumn.Item(I.ToString).ToString & 7, objColumn.Item(I.ToString).ToString & RowIndex + 1)
            Next


            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("4"))

            FORMULA("=SUM(" & objColumn.Item("5").ToString & 7 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, Range("5"))

            FORMULA("=SUM(" & objColumn.Item("6").ToString & 7 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, Range("6"))


            objSheet.Range(objColumn.Item("5").ToString & 1, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 1, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("6").ToString & RowIndex + 1)


            objBook.Application.ActiveWindow.Zoom = 95

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 144
            '    .LeftMargin = 50.4
            '    .RightMargin = 0
            '    .BottomMargin = 0
            '    .Zoom = False
            '    .FitToPagesTall = 1
            '    .FitToPagesWide = 1
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "TRIALBALANCE"

    Public Function TRIALBALANCE_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("9"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            RowIndex += 1
            Write("TRIAL-BALANCE", Range("1"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("9"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("9").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("9").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("9").ToString & RowIndex + 1)

            RowIndex += 2
            Write("Name", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
            Write("O/P Dr", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("O/P Cr", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Debit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Credit", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Closing Dr", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Closing Cr", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)


            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " TEMPTRIALBALANCEPRINT", " ORDER BY ROWNO")

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("NAME"), Range("1"), XlHAlign.xlHAlignLeft, Range("3"), False, 10)
                If DTROW("OPENINGDR") > 0 Then
                    Write(Format(Val(DTROW("OPENINGDR")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If DTROW("OPENINGCR") > 0 Then
                    Write(Format(Val(DTROW("OPENINGCR")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                Write(Format(Val(DTROW("DEBIT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)

                If DTROW("CLOSINGDR") > 0 Then
                    Write(Format(Val(DTROW("CLOSINGDR")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If DTROW("CLOSINGCR") > 0 Then
                    Write(Format(Val(DTROW("CLOSINGCR")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                End If
                If Left(DTROW("NAME"), 1) = " " And Left(DTROW("NAME"), 6) <> "      " Then
                    objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green)
                ElseIf Left(DTROW("NAME"), 1) <> " " Then
                    objSheet.Range(objColumn.Item("1").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Maroon)
                End If

            Next

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 95

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            '    .FitToPagesTall = 1
            '    .FitToPagesWide = 1
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "PURCHASE SUMMARY (REGISTER WISE)"

    Public Function REGISTERPURCHASESUMM_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTREG As New System.Data.DataTable

            RowIndex += 6
            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))

            Dim R As Integer = 2

            DTREG = OBJCMN.search("REGISTER_NAME AS REGNAME", "", "REGISTERMASTER", " AND REGISTER_TYPE = 'PURCHASE' AND REGISTER_YEARID = " & YEARID)
            If DTREG.Rows.Count > 0 Then
                R = 2
                For Each DTREGROW As System.Data.DataRow In DTREG.Rows
                    Write(DTREGROW("REGNAME"), Range(R.ToString), XlHAlign.xlHAlignCenter, , False, 10)
                    SetBorder(RowIndex, objColumn.Item(R.ToString).ToString & RowIndex, Range(R.ToString))
                    R += 1
                Next
            End If
            Write("TOTAL PURCHASE", Range((DTREG.Rows.Count + 2).ToString), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item((DTREG.Rows.Count + 2).ToString).ToString & RowIndex, Range((DTREG.Rows.Count + 2).ToString))


            Dim J As Integer = 0
            For I = 4 To 15

                'FOR GETTING MONTH
                J = I
                If J > 12 Then
                    J -= 12
                End If


                RowIndex += 1
                Write(MonthName(J), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)

                DT = OBJCMN.search(" SUM(REPORT_SP_ACCOUNTS_PURCHASESUMMARY.CREDIT) AS AMOUNT, [REGISTER NAME] AS REGNAME ", "", " REPORT_SP_ACCOUNTS_PURCHASESUMMARY ", CONDITION & " AND MONTH(DATE) = " & J & " AND YEARID = " & YEARID & "  GROUP BY [REGISTER NAME]")
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        For P As Integer = 2 To DTREG.Rows.Count + 1
                            If objSheet.Range(objColumn.Item(P.ToString).ToString & 7).Text = DTROW("REGNAME") Then
                                Write(DTROW("AMOUNT"), Range(P.ToString), XlHAlign.xlHAlignRight, , False, 10)
                            End If
                        Next
                    Next
                End If

            Next

            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTREG.Rows.Count + 2).ToString).ToString & RowIndex)

            For P = 8 To RowIndex - 1
                FORMULA("=SUM(" & objColumn.Item("2").ToString & P & ":" & objColumn.Item(((DTREG.Rows.Count) + 1).ToString).ToString & P & ")", objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & P, XlHAlign.xlHAlignRight, , True, 10)
            Next

            For P = 1 To DTREG.Rows.Count + 2
                If P > 1 Then FORMULA("=SUM(" & objColumn.Item(P.ToString).ToString & RowIndex - 1 & ":" & objColumn.Item(P.ToString).ToString & 8 & ")", Range(P.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(P.ToString).ToString & 7, objColumn.Item(P.ToString).ToString & RowIndex)
            Next


            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            RowIndex += 1
            Write("PURCHASE SUMMARY", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True

            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & RowIndex + 1)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 5
            '    .RightMargin = 5
            '    .BottomMargin = 10
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SALE SUMMARY (REGISTER WISE)"

    Public Function REGISTERSALESUMM_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTREG As New System.Data.DataTable

            RowIndex += 6
            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))

            Dim R As Integer = 2

            DTREG = OBJCMN.search("REGISTER_NAME AS REGNAME", "", "REGISTERMASTER", " AND REGISTER_TYPE = 'SALE' AND REGISTER_CMPID = " & CMPID & " AND REGISTER_LOCATIONID = " & LOCATIONID & " AND REGISTER_YEARID = " & YEARID)
            If DTREG.Rows.Count > 0 Then
                R = 2
                For Each DTREGROW As System.Data.DataRow In DTREG.Rows
                    Write(DTREGROW("REGNAME"), Range(R.ToString), XlHAlign.xlHAlignCenter, , False, 10)
                    SetBorder(RowIndex, objColumn.Item(R.ToString).ToString & RowIndex, Range(R.ToString))
                    R += 1
                Next
            End If
            Write("TOTAL SALES", Range((DTREG.Rows.Count + 2).ToString), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item((DTREG.Rows.Count + 2).ToString).ToString & RowIndex, Range((DTREG.Rows.Count + 2).ToString))


            Dim J As Integer = 0
            For I = 4 To 15

                'FOR GETTING MONTH
                J = I
                If J > 12 Then
                    J -= 12
                End If


                RowIndex += 1
                Write(MonthName(J), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)

                DT = OBJCMN.search(" SUM(REPORT_SP_ACCOUNTS_INVOICESUMMARY.CREDIT) AS AMOUNT, [REGISTER NAME] AS REGNAME ", "", " REPORT_SP_ACCOUNTS_INVOICESUMMARY ", CONDITION & " AND MONTH(DATE) = " & J & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & "  GROUP BY [REGISTER NAME]")
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        For P As Integer = 2 To DTREG.Rows.Count + 1
                            If objSheet.Range(objColumn.Item(P.ToString).ToString & 7).Text = DTROW("REGNAME") Then
                                Write(DTROW("AMOUNT"), Range(P.ToString), XlHAlign.xlHAlignRight, , False, 10)
                            End If
                        Next
                    Next
                End If

            Next

            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTREG.Rows.Count + 2).ToString).ToString & RowIndex)

            For P = 8 To RowIndex - 1
                FORMULA("=SUM(" & objColumn.Item("2").ToString & P & ":" & objColumn.Item(((DTREG.Rows.Count) + 1).ToString).ToString & P & ")", objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & P, XlHAlign.xlHAlignRight, , True, 10)
            Next

            For P = 1 To DTREG.Rows.Count + 2
                If P > 1 Then FORMULA("=SUM(" & objColumn.Item(P.ToString).ToString & RowIndex - 1 & ":" & objColumn.Item(P.ToString).ToString & 8 & ")", Range(P.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(P.ToString).ToString & 7, objColumn.Item(P.ToString).ToString & RowIndex)
            Next

            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            RowIndex += 1
            Write("SALE SUMMARY", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True

            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & RowIndex + 1)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 5
            '    .RightMargin = 5
            '    .BottomMargin = 10
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "GST REPORTS"

    Public Function GSTSUMMARY_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("7"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("7"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("7"))

            RowIndex += 1
            Write("GST SUMMARY (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("7"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("7").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("7").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("7").ToString & RowIndex + 1)

            RowIndex += 2
            Write("", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("TAXABLE AMT", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)

            'FIRST GET OPENING WITH RESPECT TO FROM DATE
            'FOR NOW OPENING WILL BE BLANK
            RowIndex += 1
            Write("OPENING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)

            Dim TAXABLEAMT, TAXABLEAMTNP, CGST, CGSTNP, SGST, SGSTNP, IGST, IGSTNP As Double, WHERECLAUSE As String
            TAXABLEAMT = 0
            TAXABLEAMTNP = 0
            CGST = 0
            CGSTNP = 0
            SGST = 0
            SGSTNP = 0
            IGST = 0
            IGSTNP = 0

            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"

            'PURCHASE + CREDIT NOTE (REGISTERED)
            RowIndex += 1
            Write("PURCHASE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" (CASE WHEN ISNULL(BILL_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(SUM(BILL_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(BILL_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(BILL_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(BILL_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(BILL_TOTALIGSTAMT),0) AS IGST ", "", " PURCHASEMASTER INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID ", WHERECLAUSE & " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(BILL_RCM,0) = 'FALSE' GROUP BY ISNULL(BILL_SCREENTYPE,'LINE GST')")
            If DT.Rows.Count > 0 Then
                TAXABLEAMT = Val(DT.Rows(0).Item("TAXABLEAMT"))
                CGST = Val(DT.Rows(0).Item("CGST"))
                SGST = Val(DT.Rows(0).Item("SGST"))
                IGST = Val(DT.Rows(0).Item("IGST"))
            End If

            DTNP = OBJCMN.search("  ISNULL(SUM(NP_TOTALTAXABLEAMT),0) AS TAXABLEAMT, ISNULL(SUM(NP_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(NP_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(NP_TOTALIGSTAMT),0) AS IGST ", "", " NONPURCHASE  INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID", WHERECLAUSE & " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "'  AND NP_YEARID = " & YEARID & " AND ISNULL(NP_RCM,0) = 'FALSE'")
            If DTNP.Rows.Count > 0 Then
                TAXABLEAMTNP = Val(DTNP.Rows(0).Item("TAXABLEAMT"))
                CGSTNP = Val(DTNP.Rows(0).Item("CGST"))
                SGSTNP = Val(DTNP.Rows(0).Item("SGST"))
                IGSTNP = Val(DTNP.Rows(0).Item("IGST"))
            End If

            Write(TAXABLEAMT + TAXABLEAMTNP, Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            Write(CGST + CGSTNP, Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            Write(SGST + SGSTNP, Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            Write(CGST + CGSTNP + SGST + SGSTNP, Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            Write(IGST + IGSTNP, Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            Write(CGST + CGSTNP + SGST + SGSTNP + IGST + IGSTNP, Range("7"), XlHAlign.xlHAlignRight, , True, 10)



            TAXABLEAMT = 0
            TAXABLEAMTNP = 0
            CGST = 0
            CGSTNP = 0
            SGST = 0
            SGSTNP = 0
            IGST = 0
            IGSTNP = 0


            'PURCHASE + CREDIT NOTE (URD)
            RowIndex += 1
            Write("PURCHASE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" (CASE WHEN ISNULL(BILL_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(SUM(BILL_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(BILL_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(BILL_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(BILL_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(BILL_TOTALIGSTAMT),0) AS IGST ", "", " PURCHASEMASTER  INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID", WHERECLAUSE & " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(BILL_RCM,0) = 'TRUE' GROUP BY ISNULL(BILL_SCREENTYPE,'LINE GST')")
            If DT.Rows.Count > 0 Then
                TAXABLEAMT = Val(DT.Rows(0).Item("TAXABLEAMT"))
                CGST = Val(DT.Rows(0).Item("CGST"))
                SGST = Val(DT.Rows(0).Item("SGST"))
                IGST = Val(DT.Rows(0).Item("IGST"))
            End If

            DTNP = OBJCMN.search(" ISNULL(SUM(NP_TOTALTAXABLEAMT),0) AS TAXABLEAMT, ISNULL(SUM(NP_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(NP_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(NP_TOTALIGSTAMT),0) AS IGST ", "", " NONPURCHASE  INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID", WHERECLAUSE & " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "'AND NP_YEARID = " & YEARID & " AND ISNULL(NP_RCM,0) = 'TRUE'")
            If DTNP.Rows.Count > 0 Then
                TAXABLEAMTNP = Val(DTNP.Rows(0).Item("TAXABLEAMT"))
                CGSTNP = Val(DTNP.Rows(0).Item("CGST"))
                SGSTNP = Val(DTNP.Rows(0).Item("SGST"))
                IGSTNP = Val(DTNP.Rows(0).Item("IGST"))
            End If

            Write(TAXABLEAMT + TAXABLEAMTNP, Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            Write(CGST + CGSTNP, Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            Write(SGST + SGSTNP, Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            Write(CGST + CGSTNP + SGST + SGSTNP, Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            Write(IGST + IGSTNP, Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            Write(CGST + CGSTNP + SGST + SGSTNP + IGST + IGSTNP, Range("7"), XlHAlign.xlHAlignRight, , True, 10)




            TAXABLEAMT = 0
            TAXABLEAMTNP = 0
            CGST = 0
            CGSTNP = 0
            SGST = 0
            SGSTNP = 0
            IGST = 0
            IGSTNP = 0

            'SALE + DEBIT NOTE (REGISTERED)
            RowIndex += 1
            Write("SALE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search(" (CASE WHEN ISNULL(INVOICE_SCREENTYPE,'LINE GST') ='LINE GST' THEN ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(INVOICE_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID ", " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') <> '' GROUP BY ISNULL(INVOICE_SCREENTYPE,'LINE GST') ")
            DT = OBJCMN.search("ISNULL(SUM(T.TAXABLEAMT ),0) AS TAXABLEAMT, ISNULL(SUM(T.CGST),0) AS CGST, ISNULL(SUM(T.SGST),0) AS SGST, ISNULL(SUM(T.IGST),0) AS IGST", "", " (SELECT (CASE WHEN ISNULL(INVOICE_SCREENTYPE,'LINE GST') ='LINE GST' THEN ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(INVOICE_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID WHERE INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & WHERECLAUSE & " AND ISNULL(ACC_GSTIN,'') <> '' GROUP BY ISNULL(INVOICE_SCREENTYPE,'LINE GST') ) AS T", "")
            If DT.Rows.Count > 0 Then
                Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            End If


            'SALE + DEBIT NOTE (B TO C)
            RowIndex += 1
            Write("SALE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            'DT = OBJCMN.search(" (CASE WHEN ISNULL(INVOICE_SCREENTYPE,'LINE GST') ='LINE GST' THEN ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(INVOICE_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID ", " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = '' GROUP BY ISNULL(INVOICE_SCREENTYPE,'LINE GST') ")
            DT = OBJCMN.search("isnull(SUM(T.TAXABLEAMT ),0)AS TAXABLEAMT, isnull(SUM(T.CGST),0) AS CGST, isnull(SUM(T.SGST),0) AS SGST, isnull(SUM(T.IGST),0) AS IGST", "", " (SELECT (CASE WHEN ISNULL(INVOICE_SCREENTYPE,'LINE GST') ='LINE GST' THEN ISNULL(SUM(INVOICE_TOTALTAXABLEAMT),0) ELSE ISNULL(SUM(INVOICE_SUBTOTAL),0) END) AS TAXABLEAMT, ISNULL(SUM(INVOICE_TOTALCGSTAMT),0) AS CGST, ISNULL(SUM(INVOICE_TOTALSGSTAMT),0) AS SGST, ISNULL(SUM(INVOICE_TOTALIGSTAMT),0) AS IGST FROM INVOICEMASTER INNER JOIN LEDGERS ON INVOICE_LEDGERID = ACC_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID WHERE INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & WHERECLAUSE & " AND ISNULL(ACC_GSTIN,'') = '' GROUP BY ISNULL(INVOICE_SCREENTYPE,'LINE GST') ) AS T", "")
            If DT.Rows.Count > 0 Then
                Write(Val(DT.Rows(0).Item("TAXABLEAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")), Range("3"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("SGST")), Range("4"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("IGST")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DT.Rows(0).Item("CGST")) + Val(DT.Rows(0).Item("SGST")) + Val(DT.Rows(0).Item("IGST")), Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            End If


            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 9 & ":" & objColumn.Item("3").ToString & 10 & ") - SUM(" & objColumn.Item("3").ToString & 11 & ":" & objColumn.Item("3").ToString & 12 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & 10 & ") - SUM(" & objColumn.Item("4").ToString & 11 & ":" & objColumn.Item("4").ToString & 12 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & 10 & ") - SUM(" & objColumn.Item("5").ToString & 11 & ":" & objColumn.Item("5").ToString & 12 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 9 & ":" & objColumn.Item("6").ToString & 10 & ") - SUM(" & objColumn.Item("6").ToString & 11 & ":" & objColumn.Item("6").ToString & 12 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & 10 & ") - SUM(" & objColumn.Item("7").ToString & 11 & ":" & objColumn.Item("7").ToString & 12 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTSALEDETAILS_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("3"), 25)
            SetColumnWidth(Range("4"), 15)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("14"))

            RowIndex += 1
            Write("GST SALE DETAILS (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("14"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("14"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("14").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("14").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("14").ToString & RowIndex + 1)

            RowIndex += 2
            Write("INV NO", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("INV DT", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("NAME", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GSTIN", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("STATE", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CITY", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("QTY", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAXABLE AMT", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("OTHER CHGS", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("14"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"


            'SALE + DEBIT NOTE (REGISTERED)
            RowIndex += 1
            Write("SALE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" INVOICEMASTER.INVOICE_NO AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0) AS QTY, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) END) AS TAXABLEAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS CGST, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS SGST, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS IGST, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN (ISNULL(INVOICEMASTER.INVOICE_CHARGES, 0) + ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0)) ELSE ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0) END) AS ROUNDOFF, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') <> '' ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            'SALE + DEBIT NOTE (B TO C)
            RowIndex += 2
            Write("SALE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" INVOICEMASTER.INVOICE_NO AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(INVOICEMASTER.INVOICE_TOTALMTRS, 0) AS QTY, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) END) AS TAXABLEAMT, ISNULL(INVOICEMASTER.INVOICE_TOTALCGSTAMT, 0) AS CGST, ISNULL(INVOICEMASTER.INVOICE_TOTALSGSTAMT, 0) AS SGST, ISNULL(INVOICEMASTER.INVOICE_TOTALIGSTAMT, 0) AS IGST, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN (ISNULL(INVOICEMASTER.INVOICE_CHARGES, 0) + ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0)) ELSE ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0) END) AS ROUNDOFF, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id  LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID ", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = ''  ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, Range("4"), True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 9 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 9 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 9 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 9 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("13").ToString & 9 & ":" & objColumn.Item("13").ToString & RowIndex - 1 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("14").ToString & 9 & ":" & objColumn.Item("14").ToString & RowIndex - 1 & ")", Range("14"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & RowIndex, objColumn.Item("14").ToString & RowIndex)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 8, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 8, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & 8, objColumn.Item("14").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTPURCHASEDETAILS_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("3"), 25)
            SetColumnWidth(Range("4"), 15)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("13"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("13"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("13"))

            RowIndex += 1
            Write("GST PURCHASE DETAILS (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("13"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("13"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("13").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("13").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("13").ToString & RowIndex + 1)

            RowIndex += 2
            Write("BILL NO", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("BILL DT", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("NAME", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GSTIN", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("STATE", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CITY", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAXABLE AMT", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CGST", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SGST", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TAX C+S", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("IGST", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("OTHER CHGS", Range("12"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL", Range("13"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"


            'PURCHASE (REGISTERED)
            RowIndex += 1
            Write("PURCHASE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" PURCHASEMASTER.BILL_PARTYBILLNO AS INVNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, (CASE WHEN ISNULL(PURCHASEMASTER.BILL_SCREENTYPE,'LINE GST')='LINE GST' THEN ISNULL(PURCHASEMASTER.BILL_TOTALTAXABLEAMT, 0) ELSE ISNULL(PURCHASEMASTER.BILL_SUBTOTAL, 0) END) AS TAXABLEAMT, ISNULL(PURCHASEMASTER.BILL_TOTALCGSTAMT, 0) AS CGST, ISNULL(PURCHASEMASTER.BILL_TOTALSGSTAMT, 0) AS SGST, ISNULL(PURCHASEMASTER.BILL_TOTALIGSTAMT, 0) AS IGST, (ISNULL(PURCHASEMASTER.BILL_CHARGES, 0)+ISNULL(PURCHASEMASTER.BILL_ROUNDOFF, 0)) AS ROUNDOFF, ISNULL(PURCHASEMASTER.BILL_GRANDTOTAL, 0) AS GRANDTOTAL  ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID", WHERECLAUSE & " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(PURCHASEMASTER.BILL_RCM,'FALSE') = 'FALSE'  ORDER BY PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_PARTYBILLNO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            Next


            'NONPURCHASE (REGISTERED)
            RowIndex += 2
            Write("NONPURCHASE (REGISTERED)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" NONPURCHASE.NP_REFNO AS INVNO, NONPURCHASE.NP_PARTYBILLDATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(NP_TOTALTAXABLEAMT,0) AS TAXABLEAMT, ISNULL(NONPURCHASE.NP_TOTALCGSTAMT, 0) AS CGST, ISNULL(NONPURCHASE.NP_TOTALSGSTAMT, 0) AS SGST, ISNULL(NONPURCHASE.NP_TOTALIGSTAMT, 0) AS IGST, ISNULL(NONPURCHASE.NP_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(NONPURCHASE.NP_GRANDTOTAL, 0) AS GRANDTOTAL  ", "", " NONPURCHASE INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID", WHERECLAUSE & " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND NP_YEARID = " & YEARID & " AND ISNULL(NONPURCHASE.NP_RCM,'FALSE') = 'FALSE'  ORDER BY NONPURCHASE.NP_PARTYBILLDATE, NONPURCHASE.NP_REFNO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            'PURCHASE (URD)
            RowIndex += 2
            Write("PURCHASE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" PURCHASEMASTER.BILL_PARTYBILLNO AS INVNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, (CASE WHEN ISNULL(PURCHASEMASTER.BILL_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(PURCHASEMASTER.BILL_TOTALTAXABLEAMT, 0) ELSE ISNULL(PURCHASEMASTER.BILL_SUBTOTAL, 0) END) AS TAXABLEAMT, ISNULL(PURCHASEMASTER.BILL_TOTALCGSTAMT, 0) AS CGST, ISNULL(PURCHASEMASTER.BILL_TOTALSGSTAMT, 0) AS SGST, ISNULL(PURCHASEMASTER.BILL_TOTALIGSTAMT, 0) AS IGST, ISNULL(PURCHASEMASTER.BILL_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(PURCHASEMASTER.BILL_GRANDTOTAL, 0) AS GRANDTOTAL  ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = BILL_REGISTERID", WHERECLAUSE & " AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND BILL_YEARID = " & YEARID & " AND ISNULL(PURCHASEMASTER.BILL_RCM,'FALSE') = 'TRUE' ORDER BY PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_PARTYBILLNO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            Next


            'NONPURCHASE (URD)
            RowIndex += 2
            Write("NONPURCHASE (URD)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            DT = OBJCMN.search(" NONPURCHASE.NP_REFNO AS INVNO, NONPURCHASE.NP_PARTYBILLDATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, ISNULL(CITYMASTER.CITY_NAME, '') AS CITY, ISNULL(NONPURCHASE.NP_TOTALTAXABLEAMT, 0) AS TAXABLEAMT, ISNULL(NONPURCHASE.NP_TOTALCGSTAMT, 0) AS CGST, ISNULL(NONPURCHASE.NP_TOTALSGSTAMT, 0) AS SGST, ISNULL(NONPURCHASE.NP_TOTALIGSTAMT, 0) AS IGST, ISNULL(NONPURCHASE.NP_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(NONPURCHASE.NP_GRANDTOTAL, 0) AS GRANDTOTAL  ", "", " NONPURCHASE INNER JOIN LEDGERS ON NONPURCHASE.NP_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID LEFT OUTER JOIN CITYMASTER ON CITY_ID = LEDGERS.ACC_CITYID  INNER JOIN REGISTERMASTER ON REGISTER_ID = NP_REGISTERID", WHERECLAUSE & " AND NP_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND NP_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND NP_YEARID = " & YEARID & " AND ISNULL(NONPURCHASE.NP_RCM,'FALSE') = 'TRUE'  ORDER BY NONPURCHASE.NP_PARTYBILLDATE, NONPURCHASE.NP_REFNO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GSTIN"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CITY"), Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGST")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGST")) + Val(DTROW("SGST")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGST")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("ROUNDOFF")), Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("GRANDTOTAL")), Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            Next



            'CLOSING
            RowIndex += 1
            Write("CLOSING", Range("1"), XlHAlign.xlHAlignLeft, Range("4"), True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 9 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 9 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 9 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & 9 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("13").ToString & 9 & ":" & objColumn.Item("13").ToString & RowIndex - 1 & ")", Range("13"), XlHAlign.xlHAlignRight, , True, 12)


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, objColumn.Item("13").ToString & RowIndex)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 8, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 8, objColumn.Item("13").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTB2B_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 17)
            SetColumnWidth(Range("4"), 17)
            SetColumnWidth(Range("5"), 17)
            SetColumnWidth(Range("8"), 17)
            SetColumnWidth(Range("9"), 10)
            SetColumnWidth(Range("10"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For B2B (4)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("No Of Receipients", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("No Of Invoices", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Invoice Value", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Taxable Value", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("11")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUMPRODUCT((" & objColumn.Item("2").ToString & 5 & ":" & objColumn.Item("2").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("2").ToString & 5 & ":" & objColumn.Item("2").ToString & 40000 & "," & objColumn.Item("2").ToString & 5 & ":" & objColumn.Item("2").ToString & 40000 & "&""""))", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 5 & ":" & objColumn.Item("4").ToString & 40000 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 5 & ":" & objColumn.Item("10").ToString & 40000 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 5 & ":" & objColumn.Item("11").ToString & 40000 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("4").ToString & 3, objColumn.Item("4").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 3, objColumn.Item("10").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)



            RowIndex += 1
            Write("GSTIN/UIN Of Receipients", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Invoice No", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Date", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Value", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Reverse Charge", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Type", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("E-Commerce GSTIN", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("11"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)

            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"

            'SALE(REGISTERED)
            DT = OBJCMN.search(" INVOICEMASTER.INVOICE_INITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICE_SUBTOTAL,0) END) AS TAXABLEAMT, 0 AS GSTPER, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL  ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') <> '' ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("GSTIN"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("INVNO"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GRANDTOTAL"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("N", Range("6"), XlHAlign.xlHAlignCenter, , False, 10)
                Write("REGULAR", Range("7"), XlHAlign.xlHAlignCenter, , False, 10)
                Write("", Range("8"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET GSTPER FROM 1ST RECORD OF INVOICEDESC AND FETCH FROM HSNCODE
                Dim OBJGST As System.Data.DataTable = OBJCMN.search("HSN_IGST AS GSTPER", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID", WHERECLAUSE & " AND INVOICE_INITIALS = '" & DTROW("INVNO") & "' AND INVOICE_YEARID = " & YEARID)
                If OBJGST.Rows.Count > 0 Then Write(Val(OBJGST.Rows(0).Item("GSTPER")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("11"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 5, objColumn.Item("11").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTB2CL_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("3"), 17)
            SetColumnWidth(Range("4"), 17)
            SetColumnWidth(Range("6"), 17)
            SetColumnWidth(Range("8"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For B2CL (5)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("No Of Invoices", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Total Invoice Value", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("8")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUMPRODUCT(1/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&"""")," & objColumn.Item("3").ToString & 5 & ":" & objColumn.Item("3").ToString & 40000 & ")", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 5 & ":" & objColumn.Item("6").ToString & 40000 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 5 & ":" & objColumn.Item("7").ToString & 40000 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("3").ToString & 3, objColumn.Item("3").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("6").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



            RowIndex += 1
            Write("Invoice No", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice Value", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("E-Commerce GSTIN", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)

            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"

            'SALE(URD)
            DT = OBJCMN.search(" INVOICEMASTER.INVOICE_INITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICE_SUBTOTAL,0) END) AS TAXABLEAMT, 0 AS GSTPER, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL  ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = '' AND ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) > 250000 ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("INVNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("DATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("GRANDTOTAL"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET GSTPER FROM 1ST RECORD OF INVOICEDESC AND FETCH FROM HSNCODE
                Dim OBJGST As System.Data.DataTable = OBJCMN.search("HSN_IGST AS GSTPER", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID ", WHERECLAUSE & " AND INVOICE_INITIALS = '" & DTROW("INVNO") & "' AND INVOICE_YEARID = " & YEARID)
                If OBJGST.Rows.Count > 0 Then Write(Val(OBJGST.Rows(0).Item("GSTPER")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTB2CS_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 17)
            SetColumnWidth(Range("4"), 17)
            SetColumnWidth(Range("6"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For B2CS (7)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("Total Taxable Value", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("6")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("6")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 5 & ":" & objColumn.Item("4").ToString & 40000 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 5 & ":" & objColumn.Item("5").ToString & 40000 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("4").ToString & 3, objColumn.Item("4").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)



            RowIndex += 1
            Write("Type", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("E-Commerce GSTIN", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"


            'SALE(URD)<250000
            DT = OBJCMN.search(" INVOICEMASTER.INVOICE_INITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICE_SUBTOTAL,0) END) AS TAXABLEAMT, 0 AS GSTPER, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL  ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID ", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = '' ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write("OE", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET GSTPER FROM 1ST RECORD OF INVOICEDESC AND FETCH FROM HSNCODE
                Dim OBJGST As System.Data.DataTable = OBJCMN.search("HSN_IGST AS GSTPER", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID", WHERECLAUSE & " AND INVOICE_INITIALS = '" & DTROW("INVNO") & "' AND INVOICE_YEARID = " & YEARID)
                If OBJGST.Rows.Count > 0 Then Write(Val(OBJGST.Rows(0).Item("GSTPER")), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTCDNR_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 25)
            Next

            SetColumnWidth(Range("6"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("GSTIN/UIN of Recipient", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice/Advance Receipt Number", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Invoice/Advance Receipt date", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Note/Refund Voucher Number", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Note/Refund Voucher date", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Document Type", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Reason For Issuing document", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("7")).Interior.Color = RGB(250, 240, 230)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"


            'CREDITNOTE / DEBITNOTE / SALERETURN
            DT = OBJCMN.search("*", " (SELECT LEDGERS.ACC_GSTIN AS GSTIN, (CASE WHEN CREDITNOTEMASTER.CN_BILLNO = '' THEN CN_PARTYREFNO ELSE CREDITNOTEMASTER.CN_BILLNO END) AS INVINITIALS, (CASE WHEN CN_BILLNO = '' THEN CN_date ELSE COALESCE (INVOICEMASTER.INVOICE_DATE, OPENINGBILL.BILL_DATE) END) AS INVDATE, CREDITNOTEMASTER.CN_initials AS CNINITIALS, CREDITNOTEMASTER.CN_date AS CNDATE, 'C' AS DOCTYPE, '01-Sales Return' AS REASON, CN_cmpid AS CMPID, CN_yearid AS YEARID FROM CREDITNOTEMASTER INNER JOIN LEDGERS ON CREDITNOTEMASTER.CN_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN INVOICEMASTER ON CREDITNOTEMASTER.CN_yearid = INVOICEMASTER.INVOICE_YEARID AND CREDITNOTEMASTER.CN_BILLNO = INVOICEMASTER.INVOICE_INITIALS LEFT OUTER JOIN OPENINGBILL ON CREDITNOTEMASTER.CN_yearid = OPENINGBILL.BILL_YEARID AND CREDITNOTEMASTER.CN_BILLNO = OPENINGBILL.BILL_INITIALS UNION ALL SELECT LEDGERS.ACC_GSTIN AS GSTIN, DN_initials AS INVINITIALS, DN_date  AS INVDATE, DEBITNOTEMASTER.DN_initials AS DNINITIALS, DEBITNOTEMASTER.DN_date AS DNDATE, 'D' AS DOCTYPE, '07-Others' AS REASON, DN_cmpid AS CMPID, DN_yearid AS YEARID FROM DEBITNOTEMASTER INNER JOIN LEDGERS ON DEBITNOTEMASTER.DN_LEDGERID = LEDGERS.Acc_id UNION ALL SELECT LEDGERS.ACC_GSTIN AS GSTIN, (CASE WHEN ISNULL(SALERETURN.SALRET_INVOICENO, '') = '' THEN CAST(SALRET_NO AS VARCHAR(10)) ELSE ISNULL(COALESCE(INVOICEMASTER.INVOICE_INITIALS, OPENINGBILL.BILL_INITIALS),'SR-' + CAST(SALERETURN.SALRET_NO AS VARCHAR(10))) END) AS INVINITIALS, (CASE WHEN ISNULL(SALRET_INVOICENO,'') = '' THEN SALRET_date ELSE ISNULL(COALESCE (INVOICEMASTER.INVOICE_DATE, OPENINGBILL.BILL_DATE), SALRET_DATE) END) AS INVDATE, 'SR-' + CAST(SALERETURN.SALRET_NO AS VARCHAR(10)) AS CNINITIALS, SALERETURN.SALRET_DATE AS CNDATE, 'C' AS DOCTYPE, '01-Sales Return' AS REASON, SALRET_cmpid AS CMPID, SALRET_yearid AS YEARID FROM SALERETURN INNER JOIN LEDGERS ON SALERETURN.SALRET_ledgerid = LEDGERS.Acc_id LEFT OUTER JOIN OPENINGBILL ON SALERETURN.SALRET_yearid = OPENINGBILL.BILL_YEARID AND CAST(SALERETURN.SALRET_INVOICENO AS INT) = OPENINGBILL.BILL_NO AND SALERETURN.SALRET_INVOICEREGID = OPENINGBILL.BILL_REGISTERID LEFT OUTER JOIN INVOICEMASTER ON SALERETURN.SALRET_yearid = INVOICEMASTER.INVOICE_YEARID AND CAST(SALERETURN.SALRET_INVOICENO AS INT) = INVOICEMASTER.INVOICE_NO AND SALERETURN.SALRET_INVOICEREGID = INVOICEMASTER.INVOICE_REGISTERID) AS T ", " AND T.YEARID = " & YEARID & " AND T.GSTIN <> "" ORDER BY T.CNDATE")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("GSTIN"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("INVINITIALS"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("INVDATE"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("CNINITIALS"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTCDNUR_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 17)
            SetColumnWidth(Range("4"), 17)
            SetColumnWidth(Range("6"), 17)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For B2CS (7)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("Total Taxable Value", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("6")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("6")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 5 & ":" & objColumn.Item("4").ToString & 40000 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 5 & ":" & objColumn.Item("5").ToString & 40000 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("4").ToString & 3, objColumn.Item("4").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)



            RowIndex += 1
            Write("Type", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Place Of Supply", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Rate", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("E-Commerce GSTIN", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"


            'SALE(URD)<250000
            DT = OBJCMN.search(" INVOICEMASTER.INVOICE_INITIALS AS INVNO, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(LEDGERS.ACC_GSTIN, '') AS GSTIN, ISNULL(STATEMASTER.STATE_REMARK, '') AS STATECODE, ISNULL(STATEMASTER.STATE_NAME, '') AS STATE, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN ISNULL(INVOICEMASTER.INVOICE_TOTALTAXABLEAMT, 0) ELSE ISNULL(INVOICE_SUBTOTAL,0) END) AS TAXABLEAMT, 0 AS GSTPER, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL  ", "", " INVOICEMASTER INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN STATEMASTER ON STATE_ID = LEDGERS.ACC_STATEID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID ", WHERECLAUSE & " AND INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICE_YEARID = " & YEARID & " AND ISNULL(ACC_GSTIN,'') = '' ORDER BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_NO")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write("OE", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("STATECODE") & "-" & DTROW("STATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET GSTPER FROM 1ST RECORD OF INVOICEDESC AND FETCH FROM HSNCODE
                Dim OBJGST As System.Data.DataTable = OBJCMN.search("HSN_IGST AS GSTPER", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICE_REGISTERID", WHERECLAUSE & " AND INVOICE_INITIALS = '" & DTROW("INVNO") & "' AND INVOICE_YEARID = " & YEARID)
                If OBJGST.Rows.Count > 0 Then Write(Val(OBJGST.Rows(0).Item("GSTPER")), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GSTHSN_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal INVOICESCREENTYPE As String, Optional ByVal REGNAME As String = "") As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 17)
            Next

            SetColumnWidth(Range("1"), 25)
            SetColumnWidth(Range("2"), 25)
            SetColumnWidth(Range("7"), 20)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable

            Write("Summary For HSN (12)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            objSheet.Range(Range("1"), Range("1")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(0, 128, 255)

            RowIndex += 1
            Write("No Of HSN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Total Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Integrated Tax", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Central Tax", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total State/UT Tax", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Cess", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)
            objSheet.Range(Range("1"), Range("10")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(0, 128, 255)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


            RowIndex += 1
            FORMULA("=SUMPRODUCT((" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "<>"""")/COUNTIF(" & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "," & objColumn.Item("1").ToString & 5 & ":" & objColumn.Item("1").ToString & 40000 & "&""""))", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 5 & ":" & objColumn.Item("5").ToString & 40000 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 5 & ":" & objColumn.Item("6").ToString & 40000 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 5 & ":" & objColumn.Item("7").ToString & 40000 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 5 & ":" & objColumn.Item("8").ToString & 40000 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & 5 & ":" & objColumn.Item("9").ToString & 40000 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 5 & ":" & objColumn.Item("10").ToString & 40000 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)

            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("6").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 3, objColumn.Item("7").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 3, objColumn.Item("8").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 3, objColumn.Item("9").ToString & 3).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 3, objColumn.Item("10").ToString & 3).NumberFormat = "0.00"


            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)



            RowIndex += 1
            Write("HSN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("Description", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("UQC", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Qty", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Total Value", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Taxable Value", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Integrated Tax Amount", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Central Tax Amount", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("State/UT Tax Amount", Range("9"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("Cess Amount", Range("10"), XlHAlign.xlHAlignCenter, , True, 10)

            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(250, 240, 230)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)


            Dim WHERECLAUSE As String = ""
            If REGNAME <> "" Then WHERECLAUSE = " AND REGISTERMASTER.REGISTER_NAME = '" & REGNAME & "'"


            'SALE(REGISTERED)
            DT = OBJCMN.search(" ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_ITEMDESC, '') AS HSNDESC, SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_MTRS, 0)) AS QTY, ROUND(SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_GRIDTOTAL, 0)),0) AS GRANDTOTAL, SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_TAXABLEAMT, 0)) AS TAXABLEAMT, SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_IGSTAMT, 0)) AS IGSTAMT, SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_CGSTAMT, 0)) AS CGSTAMT, SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_SGSTAMT, 0)) AS SGSTAMT  ", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID  INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICEMASTER_DESC.INVOICE_REGISTERID ", WHERECLAUSE & " AND INVOICEMASTER.INVOICE_DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " GROUP BY ISNULL(HSNMASTER.HSN_CODE, ''), ISNULL(HSNMASTER.HSN_ITEMDESC, ''), ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST')")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("HSNCODE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("HSNDESC"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DTROW("QTY")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)


                'Dim DTINV As New System.Data.DataTable
                'WE CAN NOT GET GRAND TOTAL IN ABOVE QUERY COZ THIS WIL CALC GRANDTOTAL MULTIPLE TIMES COZ WE HAVE JOIN WITH INVOICEDESC
                'BELOW CODE WASS TAKING TIME 
                'If INVOICESCREENTYPE = "LINE GST" Then
                'Else
                '    DTINV = OBJCMN.search("DISTINCT INVOICEMASTER.INVOICE_NO  ROUND(SUM(ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0)),0) AS GRANDTOTAL, (CASE WHEN ISNULL(INVOICEMASTER.INVOICE_SCREENTYPE,'LINE GST') = 'LINE GST' THEN SUM(ISNULL(INVOICEMASTER_DESC.INVOICE_TAXABLEAMT, 0)) ELSE SUM(ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0)) END) AS TAXABLEAMT,", "", " INVOICEMASTER_DESC INNER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID ", " AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " AND HSN_CODE = '" & DTROW("HSNCODE") & "'")
                'End If

                Write(Val(DTROW("GRANDTOTAL")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("TAXABLEAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("IGSTAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("CGSTAMT")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DTROW("SGSTAMT")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("10"), XlHAlign.xlHAlignRight, , False, 10)
            Next

            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"



            SetBorder(RowIndex, objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 5, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 5, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 5, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 5, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 5, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 5, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 5, objColumn.Item("10").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "CST REPORTS"

    Public Function CSTSALE_EXCEL(ByVal WHERECLAUSE As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            SetColumnWidth(Range(4), 40)
            SetColumnWidth(Range(5), 30)



            RowIndex = 1
            Write("SALES DETAILS", Range("1"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("10"))

            RowIndex += 1
            Write("Invoice No.", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            Write("Invoice Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Purchaser Tin No.", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Purchaser Name", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("State", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Goods with HSN", Range("6"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Value of Goods", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Tax", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Total", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Form Type", Range("10"), XlHAlign.xlHAlignLeft, , True, 10)
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("10"))


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " REPORT_SP_ACCOUNTS_INVOICESUMMARY ", WHERECLAUSE & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("BILL NO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd/MM/yyyy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYCSTNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYSTATENAME"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("COTTON BALES", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("SUBTOTAL")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TOTALTAX")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("FORMTYPE"), Range("10"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("10"))
            Next

            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"
            objSheet.Range(Range("9")).NumberFormat = "0.00"

            objSheet.Range(objColumn.Item("1").ToString & 3, objColumn.Item("1").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("2").ToString & 3, objColumn.Item("2").ToString & RowIndex).Interior.Color = RGB(255, 204, 153)
            objSheet.Range(objColumn.Item("3").ToString & 3, objColumn.Item("3").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("4").ToString & 3, objColumn.Item("4").ToString & RowIndex).Interior.Color = RGB(153, 204, 255)
            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & RowIndex).Interior.Color = RGB(51, 204, 204)
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("9").ToString & RowIndex).Interior.Color = RGB(204, 255, 255)
            objSheet.Range(objColumn.Item("10").ToString & 3, objColumn.Item("10").ToString & RowIndex).Interior.Color = RGB(51, 204, 204)


            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 2, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 2, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 2, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 2, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 2, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 2, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 2, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 2, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 2, objColumn.Item("10").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100



            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function CSTPURCHASE_EXCEL(ByVal WHERECLAUSE As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            SetColumnWidth(Range(4), 40)
            SetColumnWidth(Range(5), 30)


            RowIndex = 1
            Write("PURCHASE DETAILS", Range("1"), XlHAlign.xlHAlignLeft, Range("10"), True, 10)
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("10"))

            RowIndex += 1
            Write("Invoice No.", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            Write("Invoice Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Seller Tin No.", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Seller Name", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("State", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Goods with HSN", Range("6"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Value of Goods", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Tax", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Total", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Form Type", Range("10"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, Range("1"), Range("10"))
            objSheet.Range(Range("1"), Range("10")).Interior.Color = RGB(191, 191, 191)


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " REPORT_SP_ACCOUNTS_PURCHASESUMMARY ", WHERECLAUSE & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("PARTYBILLNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("PARTYBILLDATE")).Date, "dd/MM/yyyy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYCSTNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYSTATENAME"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("COTTON BALES", Range("6"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("SUBTOTAL")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TOTALTAX")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("FORMTYPE"), Range("10"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("10"))
            Next

            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"
            objSheet.Range(Range("9")).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 2, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 2, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 2, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 2, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 2, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 2, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 2, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 2, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 2, objColumn.Item("10").ToString & RowIndex)

            objSheet.Range(objColumn.Item("1").ToString & 3, objColumn.Item("1").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("2").ToString & 3, objColumn.Item("2").ToString & RowIndex).Interior.Color = RGB(255, 204, 153)
            objSheet.Range(objColumn.Item("3").ToString & 3, objColumn.Item("3").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("4").ToString & 3, objColumn.Item("4").ToString & RowIndex).Interior.Color = RGB(153, 204, 255)
            objSheet.Range(objColumn.Item("5").ToString & 3, objColumn.Item("5").ToString & RowIndex).Interior.Color = RGB(51, 204, 204)
            objSheet.Range(objColumn.Item("6").ToString & 3, objColumn.Item("9").ToString & RowIndex).Interior.Color = RGB(204, 255, 255)
            objSheet.Range(objColumn.Item("10").ToString & 3, objColumn.Item("10").ToString & RowIndex).Interior.Color = RGB(51, 204, 204)

            objBook.Application.ActiveWindow.Zoom = 100



            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function CFORMAPPLICATION(ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            objSheet.Name = "SOR"

            SetColumnWidth(Range(10), 20)
            SetColumnWidth(Range(11), 20)


            Dim OBJCMN As New ClsCommon
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" cmp_displayedname AS NAME, cmp_cstno AS CSTNO, cmp_email AS EMAILID, cmp_tel AS MOBILENO ", "", " CMPMASTER ", " AND CMP_ID = " & CMPID)
            Dim DT As System.Data.DataTable = OBJCMN.search(" LEDGERS.Acc_cmpname AS NAME, ISNULL(STATEMASTER.state_name, '') AS STATE, ISNULL(LEDGERS.Acc_tinno, '') AS CSTNO, COUNT(DISTINCT PURCHASEMASTER.BILL_INITIALS) AS NOOFTRANS, SUM(PURCHASEMASTER.BILL_BILLAMT) AS GRANDTOTAL, ISNULL(LEDGERS.Acc_email, '') AS EMAIL, ISNULL(LEDGERS.Acc_mobile, '') AS MOBILENO ", "", " PURCHASEMASTER INNER JOIN PURCHASEMASTER_FORMTYPE ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_FORMTYPE.BILL_NO AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_FORMTYPE.BILL_REGISTERID AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_FORMTYPE.BILL_YEARID INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN FORMTYPE ON PURCHASEMASTER_FORMTYPE.BILL_FORMID = FORMTYPE.FORM_ID LEFT OUTER JOIN STATEMASTER ON LEDGERS.Acc_stateid = STATEMASTER.state_id ", " AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " AND FORM_NAME = 'C FORM' AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' GROUP BY LEDGERS.Acc_cmpname, ISNULL(STATEMASTER.state_name, ''), ISNULL(LEDGERS.Acc_tinno, ''), ISNULL(LEDGERS.Acc_email, ''), ISNULL(LEDGERS.Acc_mobile, '') ORDER BY LEDGERS.ACC_CMPNAME")



            RowIndex = 1
            Write("Statement of Requirement of Statutory Forms", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 9)
            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("11"))
            RowIndex += 1

            Write("(To Be Filled in Capital Letters)", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 9)
            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("11"))
            RowIndex += 1


            Write("Name of the Form Issueing Dealer", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 9, True)
            objSheet.Range(Range("1"), Range("2")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("1"), Range("2")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("2"))

            Write(DTCMP.Rows(0).Item("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("7"), True, 9)
            SetBorder(RowIndex, Range("3"), Range("7"))

            Write("Email Id", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 9)
            objSheet.Range(Range("8"), Range("8")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("8"), Range("8")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write(DTCMP.Rows(0).Item("EMAILID"), Range("9"), XlHAlign.xlHAlignLeft, Range("10"), False, 9)
            SetBorder(RowIndex, Range("9"), Range("10"))

            Write("Ver 1.4.0", Range("11"), XlHAlign.xlHAlignLeft, Range("11"), False, 9)
            objSheet.Range(Range("11"), Range("11")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("11"), Range("11")).Font.Color = RGB(0, 0, 255)
            SetBorder(RowIndex, Range("11"), Range("11"))
            RowIndex += 1


            Write("CST TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 9, True)
            objSheet.Range(Range("1"), Range("2")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("1"), Range("2")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("2"))

            Write(DTCMP.Rows(0).Item("CSTNO"), Range("3"), XlHAlign.xlHAlignLeft, Range("5"), True, 9)
            SetBorder(RowIndex, Range("3"), Range("5"))

            Write("Location Of Main POB", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 9, True)
            objSheet.Range(Range("6"), Range("6")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("6"), Range("6")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("6"), Range("6"))


            Write("01-Mazgoan", Range("7"), XlHAlign.xlHAlignLeft, Range("8"), True, 9)
            SetBorder(RowIndex, Range("7"), Range("8"))

            Write("Period", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 9)
            objSheet.Range(Range("9"), Range("9")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("9"), Range("9")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex + 1)

            Write("From Date (DD/MM/YY)", Range("10"), XlHAlign.xlHAlignLeft, Range("10"), True, 9)
            objSheet.Range(Range("10"), Range("10")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("10"), Range("10")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("10"), Range("10"))


            Write("To Date (DD/MM/YY)", Range("11"), XlHAlign.xlHAlignLeft, Range("11"), True, 9)
            objSheet.Range(Range("11"), Range("11")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("11"), Range("11")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("11"), Range("11"))
            RowIndex += 1


            Write("Date Of Application (dd-mmm-yy)", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 9, True)
            objSheet.Range(Range("1"), Range("2")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("2"))

            Write("", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 9, True)
            SetBorder(RowIndex, Range("3"), Range("4"))

            objSheet.Range(Range("5"), Range("5")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("5"), Range("5"))

            Write("Mobile No", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 9, True)
            objSheet.Range(Range("6"), Range("6")).Interior.Color = RGB(198, 239, 206)
            objSheet.Range(Range("6"), Range("6")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("6"), Range("6"))

            Write(DTCMP.Rows(0).Item("MOBILENO"), Range("7"), XlHAlign.xlHAlignLeft, Range("8"), True, 9)
            SetBorder(RowIndex, Range("7"), Range("8"))

            objSheet.Range(Range("9"), Range("9")).Interior.Color = RGB(198, 239, 206)

            Write(FROMDATE.Date, Range("10"), XlHAlign.xlHAlignLeft, Range("10"), False, 9)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write(Format(TODATE.Date, "dd/MM/yy"), Range("11"), XlHAlign.xlHAlignLeft, Range("11"), False, 9)
            SetBorder(RowIndex, Range("11"), Range("11"))
            RowIndex += 1


            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(198, 239, 206)
            Write("Form Type", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 9, True)
            SetBorder(RowIndex, Range("1"), Range("1"))

            Write("Name of the Form Accepting Dealer", Range("2"), XlHAlign.xlHAlignCenter, Range("3"), True, 9, True)
            SetBorder(RowIndex, Range("2"), Range("3"))

            Write("State of the form Accepting Dealer", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 9, True)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("CST TIN of the Form Accepting Dealer", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 9, True)
            SetBorder(RowIndex, Range("5"), Range("5"))

            Write("Period of Transaction", Range("6"), XlHAlign.xlHAlignCenter, Range("7"), True, 9, True)
            SetBorder(RowIndex, Range("6"), Range("7"))

            Write("Total No Of Transactions", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 9, True)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("Total Value Of Transaction Including Tax", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 9, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Email Id of Accepting Dealer", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 9, True)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write("Mobile No Of Accepting Dealer", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 9, True)
            SetBorder(RowIndex, Range("11"), Range("11"))
            RowIndex += 1


            objSheet.Range(Range("1"), Range("11")).Interior.Color = RGB(198, 239, 206)
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 9, True)
            SetBorder(RowIndex, Range("1"), Range("1"))

            Write("2", Range("2"), XlHAlign.xlHAlignCenter, Range("3"), True, 9, True)
            SetBorder(RowIndex, Range("2"), Range("3"))

            Write("3", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 9, True)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("4", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 9, True)
            SetBorder(RowIndex, Range("5"), Range("5"))

            Write("5 (From)", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 9, True)
            SetBorder(RowIndex, Range("6"), Range("6"))

            Write("6 (To)", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 9, True)
            SetBorder(RowIndex, Range("7"), Range("7"))

            Write("7", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 9, True)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("8", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 9, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("9", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 9, True)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write("10", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 9, True)
            SetBorder(RowIndex, Range("11"), Range("11"))

            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write("C-FORM", Range("1"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, Range("3"), True, 9)
                Write(DTROW("STATE"), Range("4"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("CSTNO"), Range("5"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(FROMDATE.Date, Range("6"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(Format(TODATE.Date, "dd/MM/yy"), Range("7"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(Val(DTROW("NOOFTRANS")), Range("8"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("GRANDTOTAL")), Range("9"), XlHAlign.xlHAlignRight, , True, 9)
                Write(DTROW("EMAIL"), Range("10"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("MOBILENO"), Range("11"), XlHAlign.xlHAlignLeft, , True, 9)
                SetBorder(RowIndex, Range("1"), Range("11"))
            Next

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            objBook.Application.ActiveWindow.Zoom = 100
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function CFORMAPPLICATION1(ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 10)
            Next

            objSheet.Name = "C FORM DETAILS"

            SetColumnWidth(Range(1), 5)
            'SetColumnWidth(Range(11), 20)


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search(" LEDGERS.Acc_tinno AS TINNO, CAST(PURCHASEMASTER.BILL_PARTYBILLNO AS VARCHAR(20)) AS BILLNO, PURCHASEMASTER.BILL_PARTYBILLDATE AS BILLDATE, PURCHASEMASTER.BILL_BILLAMT AS BILLAMT, PURCHASEMASTER_CHGS.BILL_AMT AS TAXES, PURCHASEMASTER.BILL_GRANDTOTAL AS GRANDTOTAL, PURCHASEMASTER.BILL_TOTALMTRS AS TOTALWT  ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN PURCHASEMASTER_FORMTYPE ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_FORMTYPE.BILL_NO AND  PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_FORMTYPE.BILL_REGISTERID AND  PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_FORMTYPE.BILL_YEARID INNER JOIN FORMTYPE ON PURCHASEMASTER_FORMTYPE.BILL_FORMID = FORMTYPE.FORM_ID INNER JOIN PURCHASEMASTER_CHGS ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_CHGS.BILL_yearid ", " AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " AND PURCHASEMASTER_CHGS.BILL_TAXID > 0 AND FORM_NAME = 'C FORM' AND BILL_PARTYBILLDATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND BILL_PARTYBILLDATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "' ORDER BY LEDGERS.ACC_CMPNAME, PURCHASEMASTER.BILL_PARTYBILLDATE")



            RowIndex = 1
            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(0, 255, 255)
            Write("C/F Form Invoice Wise Details", Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("12"))

            Write("Ver 1.4.0", Range("13"), XlHAlign.xlHAlignLeft, Range("14"), False, 9)
            SetBorder(RowIndex, Range("13"), Range("14"))
            RowIndex += 1


            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(0, 255, 255)
            Write("Linking Fields", Range("1"), XlHAlign.xlHAlignCenter, Range("5"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("5"))

            Write("Common Fields", Range("6"), XlHAlign.xlHAlignLeft, Range("14"), False, 9)
            SetBorder(RowIndex, Range("6"), Range("14"))
            RowIndex += 1


            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(0, 255, 255)
            Write("Sno", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 9, True)
            SetBorder(RowIndex, Range("1"), Range("1"))

            Write("Form Type Requested", Range("2"), XlHAlign.xlHAlignCenter, Range("2"), True, 9, True)
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write("CST TIN of Form Accepting Dealer", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 9, True)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("Period Of TRansaction (DD-MM-YY)", Range("4"), XlHAlign.xlHAlignCenter, Range("5"), True, 9, True)
            SetBorder(RowIndex, Range("4"), Range("5"))

            Write("Invoice No", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 9, True)
            SetBorder(RowIndex, Range("6"), Range("6"))

            Write("Invoice Date (DD-MM-YY)", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 9, True)
            SetBorder(RowIndex, Range("7"), Range("7"))

            Write("Nett Value Of Invoice", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 9, True)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("Tax Amount", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 9, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Gross Value Of Invoice", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 9, True)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write("Description Of Goods", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 9, True)
            SetBorder(RowIndex, Range("11"), Range("11"))

            Write("Quantity Of Goods", Range("12"), XlHAlign.xlHAlignCenter, Range("12"), True, 9, True)
            SetBorder(RowIndex, Range("12"), Range("12"))

            Write("Purpose of Purchase", Range("13"), XlHAlign.xlHAlignCenter, Range("13"), True, 9, True)
            SetBorder(RowIndex, Range("13"), Range("13"))

            Write("Remarks", Range("14"), XlHAlign.xlHAlignCenter, Range("14"), True, 9, True)
            SetBorder(RowIndex, Range("14"), Range("14"))
            RowIndex += 1

            objSheet.Range(Range("1"), Range("14")).Interior.Color = RGB(0, 255, 255)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("From", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 9, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("To", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 9, True)
            SetBorder(RowIndex, Range("5"), Range("5"))

            SetBorder(RowIndex, Range("6"), Range("6"))
            SetBorder(RowIndex, Range("7"), Range("7"))
            SetBorder(RowIndex, Range("8"), Range("8"))
            SetBorder(RowIndex, Range("9"), Range("9"))
            SetBorder(RowIndex, Range("10"), Range("10"))
            SetBorder(RowIndex, Range("11"), Range("11"))
            SetBorder(RowIndex, Range("12"), Range("12"))
            SetBorder(RowIndex, Range("13"), Range("13"))
            SetBorder(RowIndex, Range("14"), Range("14"))


            Dim a As Integer = 1
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1

                Write(a, Range("1"), XlHAlign.xlHAlignRight, , True, 9)
                Write("C-FORM", Range("2"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("TINNO"), Range("3"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(FROMDATE.Date, Range("4"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(TODATE.Date, Range("5"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("BILLNO"), Range("6"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("BILLDATE"), Range("7"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(Val(DTROW("BILLAMT")), Range("8"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("TAXES")), Range("9"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("GRANDTOTAL")), Range("10"), XlHAlign.xlHAlignRight, , True, 9)
                Write("YARN", Range("11"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(Val(DTROW("TOTALWT")), Range("12"), XlHAlign.xlHAlignRight, , True, 9)
                Write("Resale", Range("13"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("14"), XlHAlign.xlHAlignLeft, , True, 9)
                SetBorder(RowIndex, Range("1"), Range("14"))
                a += 1
            Next

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            objBook.Application.ActiveWindow.Zoom = 100
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "VAT REPORTS"

    Public Function VATSALE_EXCEL(ByVal WHERECLAUSE As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object

        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 17)
            Next

            SetColumnWidth(Range(3), 40)


            RowIndex = 1
            Write("FORM 201A", Range("1"), XlHAlign.xlHAlignLeft, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            RowIndex += 1
            Write("Tax Invoice No.", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("Name with RC No. of the registered dealer to whom goods sold", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10, True)
            SetBorder(RowIndex, Range("3"), Range("4"))
            Write("Turnover of Sale of taxable goods", Range("5"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, True)
            SetBorder(RowIndex, Range("5"), Range("9"))
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)


            RowIndex += 1
            Write("Sale of Goods to registered dealer", Range("1"), XlHAlign.xlHAlignLeft, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)


            RowIndex += 1
            Write("Tax Invoice No.(201A)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Name", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("R.C. No", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Goods with HSN", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Value of Goods", Range("6"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Tax", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Additional Tax", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Total", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("9"))


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " REPORT_SP_ACCOUNTS_INVOICESUMMARY ", WHERECLAUSE & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("BILL NO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd/MM/yyyy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYVATNO"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("COTTON BALES", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("SUBTOTAL")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("ADDTAXAMT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("9"))
            Next

            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"
            objSheet.Range(Range("9")).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 4, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 4, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 4, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 4, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 4, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 4, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 4, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 4, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 4, objColumn.Item("9").ToString & RowIndex)

            objSheet.Range(objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex).Interior.Color = RGB(255, 204, 153)
            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).Interior.Color = RGB(153, 204, 255)
            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("9").ToString & RowIndex).Interior.Color = RGB(204, 255, 255)


            objBook.Application.ActiveWindow.Zoom = 100



            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function VATPURCHASE_EXCEL(ByVal WHERECLAUSE As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next

            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 17)
            Next

            SetColumnWidth(Range(3), 40)


            RowIndex = 1
            Write("FORM 201B", Range("1"), XlHAlign.xlHAlignLeft, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))

            RowIndex += 1
            Write("Tax Invoice No.", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("Name with RC No. of the registered dealer from whom goods purchased", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10, True)
            SetBorder(RowIndex, Range("3"), Range("4"))
            Write("Turnover of Purchase of taxable goods", Range("5"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, True)
            SetBorder(RowIndex, Range("5"), Range("9"))
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)


            RowIndex += 1
            Write("Purchase of Goods from registered dealer", Range("1"), XlHAlign.xlHAlignLeft, Range("9"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("9"))
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)


            RowIndex += 1
            Write("Tax Invoice No.(201A)", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Date", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Name", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("R.C. No", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Goods with HSN", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Value of Goods", Range("6"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Tax", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Additional Tax", Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Total", Range("9"), XlHAlign.xlHAlignLeft, , True, 10)
            objSheet.Range(Range("1"), Range("9")).Interior.Color = RGB(191, 191, 191)
            SetBorder(RowIndex, Range("1"), Range("9"))


            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " REPORT_SP_ACCOUNTS_PURCHASESUMMARY ", WHERECLAUSE & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID)
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("PARTYBILLNO"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Convert.ToDateTime(DTROW("PARTYBILLDATE")).Date, "dd/MM/yyyy"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("PARTYVATNO"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("COTTON BALES", Range("5"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("SUBTOTAL")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("ADDTAXAMT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("9"))
            Next

            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"
            objSheet.Range(Range("9")).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 4, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 4, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 4, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 4, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 4, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 4, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 4, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 4, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 4, objColumn.Item("9").ToString & RowIndex)

            objSheet.Range(objColumn.Item("1").ToString & 5, objColumn.Item("1").ToString & RowIndex).Interior.Color = RGB(255, 153, 204)
            objSheet.Range(objColumn.Item("2").ToString & 5, objColumn.Item("2").ToString & RowIndex).Interior.Color = RGB(255, 204, 153)
            objSheet.Range(objColumn.Item("3").ToString & 5, objColumn.Item("3").ToString & RowIndex).Interior.Color = RGB(153, 204, 255)
            objSheet.Range(objColumn.Item("4").ToString & 5, objColumn.Item("9").ToString & RowIndex).Interior.Color = RGB(204, 255, 255)


            objBook.Application.ActiveWindow.Zoom = 100



            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()
        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "TAX REPORTS"

    Public Function TAXREPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal PERIOD As String, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 12)
            Next

            SetColumnWidth(Range(1), 30)


            ' **************************** CMPHEADER *************************
            Dim OBJCMN As New ClsCommon
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))




            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 9, objColumn.Item("8").ToString & 9).Select()
            objSheet.Range(objColumn.Item("1").ToString & 9, objColumn.Item("8").ToString & 9).Application.ActiveWindow.FreezePanes = True

            ' **************************** CMPHEADER *************************


            RowIndex += 1
            Write(PERIOD, Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))

            RowIndex += 2
            Write("PURCHASE", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(213, 228, 248)
            SetBorder(RowIndex, Range("1"), Range("8"))

            RowIndex += 1
            Write("Type Of Purchase", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Gross Amount", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("1"), Range("2"))
            Write("Other Charges", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Tax %", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("V.A.T.", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("C.S.T.", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("Round Off", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("Nett Amount", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, Range("8"), Range("8"))

            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(213, 228, 248)

            Dim DT As System.Data.DataTable = OBJCMN.search(" A.REGNAME, SUM(A.GROSSAMT) AS GROSSAMT, sum(A.CHARGES) as CHARGES, A.TAX, SUM(A.VAT) AS VAT, SUM(A.CST) AS CST, SUM(A.ROUNDOFF) AS ROUNDOFF, SUM(A.NETTAMT) AS NETTAMT, A.CMPID, A.YEARID ", "", " (SELECT T.DATE, T.BILLINITIALS, T.REGNAME, T.GROSSAMT, SUM(T.CHARGES) AS CHARGES, SUM(T.TAX) AS TAX, SUM(T.VAT) AS VAT, SUM(T.CST) AS CST, T.ROUNDOFF, T.NETTAMT, T.CMPID, T.YEARID FROM (SELECT PURCHASEMASTER.BILL_PARTYBILLDATE AS [DATE], PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS, REGISTERMASTER.register_name AS REGNAME, PURCHASEMASTER.BILL_BILLAMT AS GROSSAMT, ISNULL(SUM(PURCHASEMASTER_CHGS.BILL_AMT),0) AS CHARGES, 0 AS TAX,0 AS VAT,0 AS CST, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, PURCHASEMASTER.BILL_GRANDTOTAL AS NETTAMT, PURCHASEMASTER.BILL_CMPID AS CMPID, PURCHASEMASTER.BILL_YEARID AS YEARID FROM PURCHASEMASTER LEFT OUTER JOIN PURCHASEMASTER_CHGS ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_CHGS.BILL_yearid INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id WHERE (ISNULL(BILL_TAXID,0) = 0) GROUP BY PURCHASEMASTER.BILL_PARTYBILLDATE ,PURCHASEMASTER.BILL_INITIALS,REGISTERMASTER.register_name, PURCHASEMASTER.BILL_BILLAMT, PURCHASEMASTER.BILL_ROUNDOFF, PURCHASEMASTER.BILL_GRANDTOTAL, PURCHASEMASTER.BILL_CMPID , PURCHASEMASTER.BILL_YEARID UNION ALL  SELECT PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS,REGISTERMASTER.register_name AS REGNAME, PURCHASEMASTER.BILL_BILLAMT AS GROSSAMT, 0 AS CHARGES, tax_tax AS TAX, SUM(PURCHASEMASTER_CHGS.BILL_AMT) AS VAT, 0 AS CST, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF, PURCHASEMASTER.BILL_GRANDTOTAL AS NETTAMT, PURCHASEMASTER.BILL_CMPID AS CMPID, PURCHASEMASTER.BILL_YEARID AS YEARID FROM PURCHASEMASTER INNER JOIN PURCHASEMASTER_CHGS ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_CHGS.BILL_yearid INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id INNER JOIN TAXMASTER ON PURCHASEMASTER_CHGS.BILL_TAXID = TAXMASTER.tax_id WHERE TAX_ISVAT = 'True' GROUP BY PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_INITIALS, REGISTERMASTER.register_name, PURCHASEMASTER.BILL_BILLAMT, PURCHASEMASTER.BILL_ROUNDOFF, PURCHASEMASTER.BILL_GRANDTOTAL, tax_tax , PURCHASEMASTER.BILL_CMPID , PURCHASEMASTER.BILL_YEARID UNION ALL SELECT PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_INITIALS AS BILLINITIALS, REGISTERMASTER.register_name AS REGNAME, PURCHASEMASTER.BILL_BILLAMT AS GROSSAMT, 0 AS CHARGES, tax_tax AS TAX, 0 AS VAT, SUM(PURCHASEMASTER_CHGS.BILL_AMT) AS CST, PURCHASEMASTER.BILL_ROUNDOFF AS ROUNDOFF,PURCHASEMASTER.BILL_GRANDTOTAL AS NETTAMT, PURCHASEMASTER.BILL_CMPID AS CMPID, PURCHASEMASTER.BILL_YEARID AS YEARID FROM PURCHASEMASTER INNER JOIN PURCHASEMASTER_CHGS ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID AND PURCHASEMASTER.BILL_YEARID = PURCHASEMASTER_CHGS.BILL_yearid INNER JOIN REGISTERMASTER ON PURCHASEMASTER.BILL_REGISTERID = REGISTERMASTER.register_id INNER JOIN TAXMASTER ON PURCHASEMASTER_CHGS.BILL_TAXID = TAXMASTER.tax_id WHERE tax_ISCST = 'True' GROUP BY PURCHASEMASTER.BILL_PARTYBILLDATE, PURCHASEMASTER.BILL_INITIALS, REGISTERMASTER.register_name, PURCHASEMASTER.BILL_BILLAMT, PURCHASEMASTER.BILL_ROUNDOFF, PURCHASEMASTER.BILL_GRANDTOTAL, tax_tax , PURCHASEMASTER.BILL_CMPID , PURCHASEMASTER.BILL_YEARID ) AS T  " & WHERECLAUSE & " GROUP BY T.DATE, T.BILLINITIALS, T.REGNAME, T.CMPID, T.YEARID, T.GROSSAMT, T.ROUNDOFF, T.NETTAMT) AS A ", " GROUP BY A.REGNAME, A.TAX, A.CMPID,A.YEARID ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("REGNAME"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("GROSSAMT")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CHARGES")), "0.00"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAX")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("VAT")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CST")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("ROUNDOFF")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("NETTAMT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))
            Next
            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("2").ToString & 9 & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 9 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 9 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 9 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 9 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))



            'SALE DETAILS
            RowIndex += 2
            Write("SALE", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            Dim SSTART As Integer = RowIndex
            objSheet.Range(Range("1"), Range("8")).Interior.Color = RGB(213, 228, 248)
            SetBorder(RowIndex, Range("1"), Range("8"))
            DT = OBJCMN.search("A.REGNAME, SUM(A.GROSSAMT) AS GROSSAMT, sum(A.CHARGES) as CHARGES, A.TAX, SUM(A.VAT) AS VAT, SUM(A.CST) AS CST, SUM(A.ROUNDOFF) AS ROUNDOFF, SUM(A.NETTAMT) AS NETTAMT, A.CMPID, A.YEARID ", "", " (SELECT T.DATE, T.BILLINITIALS, T.REGNAME, T.GROSSAMT, SUM(T.CHARGES) AS CHARGES, SUM(T.TAX) AS TAX, SUM(T.VAT) AS VAT, SUM(T.CST) AS CST, T.ROUNDOFF, T.NETTAMT, T.CMPID, T.YEARID FROM (SELECT    INVOICEMASTER.INVOICE_DATE AS [DATE], INVOICEMASTER.INVOICE_INITIALS AS BILLINITIALS, REGISTERMASTER.register_name AS REGNAME, INVOICEMASTER.INVOICE_AMOUNT AS GROSSAMT, ISNULL(SUM(INVOICEMASTER_CHGS.INVOICE_AMT),0) AS CHARGES,0 AS TAX,0 AS VAT,0 AS CST, INVOICEMASTER.INVOICE_ROUNDOFF AS ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL AS NETTAMT, INVOICEMASTER.INVOICE_CMPID AS CMPID, INVOICEMASTER.INVOICE_YEARID AS YEARID FROM INVOICEMASTER LEFT OUTER JOIN INVOICEMASTER_CHGS ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_CHGS.INVOICE_no AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_CHGS.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_CHGS.INVOICE_yearid INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id WHERE (ISNULL(INVOICE_TAXID ,0)= 0)  GROUP BY INVOICEMASTER.INVOICE_DATE ,INVOICEMASTER.INVOICE_INITIALS,REGISTERMASTER.register_name, INVOICEMASTER.INVOICE_AMOUNT, INVOICEMASTER.INVOICE_ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL, INVOICEMASTER.INVOICE_CMPID , INVOICEMASTER.INVOICE_YEARID UNION ALL  SELECT INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_INITIALS AS BILLINITIALS,REGISTERMASTER.register_name AS REGNAME, INVOICEMASTER.INVOICE_AMOUNT AS GROSSAMT, 0 AS CHARGES, tax_tax AS TAX, SUM(INVOICEMASTER_CHGS.INVOICE_AMT) AS VAT, 0 AS CST, INVOICEMASTER.INVOICE_ROUNDOFF AS ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL AS NETTAMT, INVOICEMASTER.INVOICE_CMPID AS CMPID, INVOICEMASTER.INVOICE_YEARID AS YEARID FROM INVOICEMASTER INNER JOIN INVOICEMASTER_CHGS ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_CHGS.INVOICE_no AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_CHGS.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_CHGS.INVOICE_yearid INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id INNER JOIN TAXMASTER ON INVOICEMASTER_CHGS.INVOICE_TAXID = TAXMASTER.tax_id WHERE tax_ISVAT = 'True' GROUP BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_INITIALS, REGISTERMASTER.register_name, INVOICEMASTER.INVOICE_AMOUNT, INVOICEMASTER.INVOICE_ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL, tax_tax , INVOICEMASTER.INVOICE_CMPID , INVOICEMASTER.INVOICE_YEARID UNION ALL SELECT INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_INITIALS AS BILLINITIALS, REGISTERMASTER.register_name AS REGNAME, INVOICEMASTER.INVOICE_AMOUNT AS GROSSAMT, 0 AS CHARGES, tax_tax AS TAX, 0 AS VAT, SUM(INVOICEMASTER_CHGS.INVOICE_AMT) AS CST, INVOICEMASTER.INVOICE_ROUNDOFF AS ROUNDOFF,INVOICEMASTER.INVOICE_GRANDTOTAL AS NETTAMT, INVOICEMASTER.INVOICE_CMPID AS CMPID, INVOICEMASTER.INVOICE_YEARID AS YEARID FROM INVOICEMASTER INNER JOIN INVOICEMASTER_CHGS ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_CHGS.INVOICE_no AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_CHGS.INVOICE_REGISTERID AND INVOICEMASTER.INVOICE_YEARID = INVOICEMASTER_CHGS.INVOICE_yearid INNER JOIN REGISTERMASTER ON INVOICEMASTER.INVOICE_REGISTERID = REGISTERMASTER.register_id INNER JOIN TAXMASTER ON INVOICEMASTER_CHGS.INVOICE_TAXID = TAXMASTER.tax_id WHERE tax_ISCST = 'True' GROUP BY INVOICEMASTER.INVOICE_DATE, INVOICEMASTER.INVOICE_INITIALS, REGISTERMASTER.register_name, INVOICEMASTER.INVOICE_AMOUNT, INVOICEMASTER.INVOICE_ROUNDOFF, INVOICEMASTER.INVOICE_GRANDTOTAL, tax_tax , INVOICEMASTER.INVOICE_CMPID , INVOICEMASTER.INVOICE_YEARID ) AS T  " & WHERECLAUSE & " GROUP BY T.DATE, T.BILLINITIALS, T.REGNAME, T.CMPID, T.YEARID, T.GROSSAMT, T.ROUNDOFF, T.NETTAMT) AS A ", " GROUP BY A.REGNAME, A.TAX, A.CMPID,A.YEARID ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(DTROW("REGNAME"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Format(Val(DTROW("GROSSAMT")), "0.00"), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CHARGES")), "0.00"), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAX")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("VAT")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("CST")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("ROUNDOFF")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("NETTAMT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))
            Next

            objSheet.Range(Range("4")).NumberFormat = "0.00"
            objSheet.Range(Range("5")).NumberFormat = "0.00"
            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(Range("7")).NumberFormat = "0.00"
            objSheet.Range(Range("8")).NumberFormat = "0.00"

            RowIndex += 1
            FORMULA("=SUM(" & objColumn.Item("2").ToString & SSTART & ":" & objColumn.Item("2").ToString & RowIndex - 1 & ")", Range("2"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & SSTART & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & SSTART & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & SSTART & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & SSTART & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & SSTART & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & SSTART & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))

            SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 9, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 9, objColumn.Item("8").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100



            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function J1REPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 18)
            Next


            RowIndex += 1
            Write("Sales Annexure", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("Period From", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 12)
            objSheet.Range(Range("3"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("3"))
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("Period To", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            objSheet.Range(Range("4"), Range("4")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("4"))
            SetBorder(RowIndex, Range("5"), Range("6"))


            RowIndex += 1
            Write("TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write(FROMDATE.Date, Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 12)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write(TODATE.Date, Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("Applicable", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            objSheet.Range(Range("5"), Range("5")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("5"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("6"))

            RowIndex += 1
            Write("CUSTOMER-WISE VAT SALES", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            RowIndex += 1
            Write("If you have more that 4999 entries then upload more than one sheet", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            objSheet.Range(Range("1"), Range("6")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("6"))


            RowIndex += 1
            Write("Sr.No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("TIN of Customer", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("Nett Taxable Amount Rs.", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("V.A.T. Amount Rs.", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("Gross Total Rs.", Range("5"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("6"))


            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("2", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("3", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("4", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("5", Range("5"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("6"))


            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search(" LEDGERS.Acc_tinno AS TINNO, SUM(INVOICEMASTER.INVOICE_AMOUNT) AS TOTALAMT, 0 AS TAXAMT, SUM(INVOICEMASTER.INVOICE_GRANDTOTAL) AS GTOTAL", "", " INVOICEMASTER INNER JOIN INVOICEMASTER_CHGS ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_CHGS.INVOICE_no AND INVOICEMASTER.INVOICE_REGISTERID = INVOICEMASTER_CHGS.INVOICE_REGISTERID INNER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id INNER JOIN TAXMASTER ON INVOICEMASTER_CHGS.INVOICE_TAXID = TAXMASTER.tax_id INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICEMASTER.INVOICE_REGISTERID", WHERECLAUSE & " AND TAX_ISVAT = 'True' AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " GROUP BY LEDGERS.Acc_tinno, Acc_cmpname ORDER BY LEDGERS.Acc_cmpname ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 12)
                Write(DTROW("TINNO"), Range("2"), XlHAlign.xlHAlignLeft, , False, 12, True)
                Write(Format(Val(DTROW("TOTALAMT")), "0.00"), Range("3"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("GTOTAL")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, Range("6"), False, 12)
                objSheet.Range(Range("5"), Range("6")).Interior.Color = RGB(198, 239, 206)
                SetBorder(RowIndex, Range("1"), Range("6"))
                SRNO += 1
            Next
            RowIndex += 1
            Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , True, 12)
            Write("Gross Total", Range("2"), XlHAlign.xlHAlignLeft, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 9 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, Range("6"), True, 12)
            objSheet.Range(Range("3"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("6"))


            objSheet.Range(objColumn.Item("3").ToString & 9, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function J2REPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 18)
            Next


            RowIndex += 1
            Write("Purchase Annexure", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("Period From", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 12)
            objSheet.Range(Range("3"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("3"))
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("Period To", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            objSheet.Range(Range("4"), Range("4")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("4"))
            SetBorder(RowIndex, Range("5"), Range("6"))


            RowIndex += 1
            Write("TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write(FROMDATE.Date, Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 12)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write(TODATE.Date, Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("Applicable", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            objSheet.Range(Range("5"), Range("5")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("5"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("6"))

            RowIndex += 1
            Write("SUPPLIERS-WISE VAT PURCHASE", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            RowIndex += 1
            Write("If you have more that 4999 entries then upload more than one sheet", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            objSheet.Range(Range("1"), Range("6")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("6"))


            RowIndex += 1
            Write("Sr.No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("TIN of Suppliers", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("Nett Taxable Amount Rs.", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("V.A.T. Amount Rs.", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("Gross Total Rs.", Range("5"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("6"))


            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("2", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("3", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("4", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("5", Range("5"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("6"))


            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search(" LEDGERS.Acc_tinno AS TINNO, SUM(PURCHASEMASTER.BILL_BILLAMT) AS TOTALAMT, SUM(PURCHASEMASTER.BILL_TOTALTAXAMT) AS TAXAMT, SUM(PURCHASEMASTER.BILL_GRANDTOTAL) AS GTOTAL", "", " PURCHASEMASTER INNER JOIN PURCHASEMASTER_CHGS ON PURCHASEMASTER.BILL_NO = PURCHASEMASTER_CHGS.BILL_no AND PURCHASEMASTER.BILL_REGISTERID = PURCHASEMASTER_CHGS.BILL_REGISTERID INNER JOIN LEDGERS ON PURCHASEMASTER.BILL_LEDGERID = LEDGERS.Acc_id INNER JOIN TAXMASTER ON PURCHASEMASTER_CHGS.BILL_TAXID = TAXMASTER.tax_id INNER JOIN REGISTERMASTER ON REGISTER_ID = PURCHASEMASTER.BILL_REGISTERID", WHERECLAUSE & " AND TAX_ISVAT = 'True' AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " GROUP BY LEDGERS.Acc_tinno, Acc_cmpname ORDER BY LEDGERS.Acc_cmpname ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 12)
                Write(DTROW("TINNO"), Range("2"), XlHAlign.xlHAlignLeft, , False, 12, True)
                Write(Format(Val(DTROW("TOTALAMT")), "0.00"), Range("3"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("4"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("GTOTAL")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, Range("6"), False, 12)
                objSheet.Range(Range("5"), Range("6")).Interior.Color = RGB(198, 239, 206)
                SetBorder(RowIndex, Range("1"), Range("6"))
                SRNO += 1
            Next
            RowIndex += 1
            Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , True, 12)
            Write("Gross Total", Range("2"), XlHAlign.xlHAlignLeft, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("3").ToString & 9 & ":" & objColumn.Item("3").ToString & RowIndex - 1 & ")", Range("3"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & 9 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & 9 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, Range("6"), True, 12)
            objSheet.Range(Range("3"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("6"))


            objSheet.Range(objColumn.Item("3").ToString & 9, objColumn.Item("3").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 9, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function GREPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 18)
            Next
            SetColumnWidth(Range("2"), 60)


            RowIndex += 1
            Write("ANNEXURE-G", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 15)
            SetBorder(RowIndex, Range("1"), Range("8"))

            RowIndex += 1
            Write("TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            objSheet.Range(Range("2"), Range("2")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write("Period", Range("5"), XlHAlign.xlHAlignCenter, , True, 12)
            Write(FROMDATE.Date, Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            objSheet.Range(Range("6"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("6"), Range("6"))

            Write("To", Range("7"), XlHAlign.xlHAlignCenter, , True, 12)
            Write(TODATE.Date, Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            objSheet.Range(Range("8"), Range("8")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("8"), Range("8"))


            RowIndex += 1
            Write("Enter Declaration wise Top 4999 seperately in descending order and put Total of Remaining in 5000th row", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            objSheet.Range(Range("1"), Range("8")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("8"))


            RowIndex += 1
            Write("Details of Declarations or Certificates Received", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))


            RowIndex += 1
            Write("Sr.No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Name of the Dealer who has issued Declaration or Certificated", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("TIN / RC No", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Declaration or Cretificate Type", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("Issuing State", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("Declaration No", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("Gross Amt as per Invoice covered by Declaration (Net of goods returned) (Rs.)", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 12, True)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("Amount for which Declaration received (Rs.)", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 12, True)
            SetBorder(RowIndex, Range("8"), Range("8"))


            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("2", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("3", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("4", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("5", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("6", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("7", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("8", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("8"), Range("8"))


            'FREEZE TOP 8 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & 8).Application.ActiveWindow.FreezePanes = True



            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " (select NAME, CSTNO, FORMNAME, STATENAME, FORMNO,SUM(AMT) AS AMT from CFORMVIEW where YEARID = " & YEARID & " and CFORMVIEW.FORMNAME = 'C FORM' and TYPE = 'SALE' AND FORMNO <> ''  " & WHERECLAUSE & " GROUP BY NAME, CSTNO, FORMNAME, STATENAME, FORMNO UNION ALL select NAME, CSTNO, FORMNAME, STATENAME, FORMNO,SUM(AMT) AS AMT from CFORMVIEW where YEARID = " & YEARID & " and CFORMVIEW.FORMNAME = 'E1 FORM' and TYPE = 'PURCHASE' AND FORMNO <> '' " & WHERECLAUSE & " GROUP BY NAME, CSTNO, FORMNAME, STATENAME, FORMNO) AS T ", "")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 12)
                Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 12, True)
                Write(DTROW("CSTNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 12)
                Write(DTROW("FORMNAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 12)
                Write(DTROW("STATENAME"), Range("5"), XlHAlign.xlHAlignLeft, , False, 12)
                Write(DTROW("FORMNO"), Range("6"), XlHAlign.xlHAlignLeft, , False, 12)
                Write(Format(Val(DTROW("AMT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("AMT")), "0.00"), Range("8"), XlHAlign.xlHAlignRight, , False, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))
                SRNO += 1
            Next
            RowIndex += 1
            Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , True, 12)
            Write("Total", Range("2"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 8 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 8 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            objSheet.Range(Range("7"), Range("8")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("8"))


            objSheet.Range(objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0"
            objSheet.Range(objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function IREPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 13)
            Next
            SetColumnWidth(Range("1"), 5)
            SetColumnWidth(Range("2"), 60)
            SetColumnWidth(Range("5"), 8)
            SetColumnWidth(Range("6"), 9)


            RowIndex += 1
            Write("ANNEXURE-I", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 15)
            SetBorder(RowIndex, Range("1"), Range("11"))

            RowIndex += 1
            Write("TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            objSheet.Range(Range("2"), Range("2")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write("Period", Range("4"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            Write(FROMDATE.Date, Range("6"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            objSheet.Range(Range("6"), Range("7")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("6"), Range("7"))

            Write("To", Range("8"), XlHAlign.xlHAlignCenter, , True, 12)
            Write(TODATE.Date, Range("9"), XlHAlign.xlHAlignCenter, Range("11"), True, 12)
            objSheet.Range(Range("9"), Range("11")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("9"), Range("11"))


            RowIndex += 1
            Write("Enter Declaration wise Top 4999 seperately in descending order and put Total of Remaining in 5000th row", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 12)
            objSheet.Range(Range("1"), Range("11")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("11"))


            RowIndex += 1
            Write("Details of Declarations or Certificates not Received Under Cenrtal Sales Tax Act, 1956. (Other than Local Form-H)", Range("1"), XlHAlign.xlHAlignCenter, Range("11"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("11"))


            RowIndex += 1
            Write("Sr.No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Name of the Dealer who has issued Declaration or Certificated", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("CST TIN No", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Declaration or Cretificate Type", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("Invoice No", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12, True)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("Invoice Date", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12, True)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("Taxable Amount (Rs.) (Net)", Range("7"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("Tax Amount (Rs.)", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 12, True)
            SetBorder(RowIndex, Range("8"), Range("8"))
            Write("Rate of Tax", Range("9"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("9"), Range("9"))
            Write("Amount of Tax (Column 7*9*%)", Range("10"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("10"), Range("10"))
            Write("Differential tax liability (Rs.) (Col 10 - Col 8)", Range("11"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("11"), Range("11"))


            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("2", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("3", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("4", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("5", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("6", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("6"), Range("6"))
            Write("7", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 12)
            SetBorder(RowIndex, Range("7"), Range("7"))
            Write("8", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("8"), Range("8"))
            Write("9", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 12)
            SetBorder(RowIndex, Range("9"), Range("9"))
            Write("10", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 12)
            SetBorder(RowIndex, Range("10"), Range("10"))
            Write("11", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 12)
            SetBorder(RowIndex, Range("11"), Range("11"))


            'FREEZE TOP 8 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & 8).Application.ActiveWindow.FreezePanes = True



            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search("*", "", " (select NAME, CSTNO, FORMNAME, CAST(BILL AS VARCHAR(30)) AS BILLINITIALS, DATE, AMT, TAXAMT, TAXPER, BILL, QUARTERNAME from CFORMVIEW where YEARID = " & YEARID & " and CFORMVIEW.FORMNAME = 'C FORM' and TYPE = 'SALE' AND (FORMNO = '' OR (FORMNO <> '' AND RECDATE > '" & Format(TODATE.Date, "MM/dd/yyyy") & "'))  UNION ALL select NAME, CSTNO, FORMNAME, CFORMVIEW.BILLINITIALS, DATE, AMT, TAXAMT, TAXPER, BILL, QUARTERNAME from CFORMVIEW where YEARID = " & YEARID & " and CFORMVIEW.FORMNAME = 'E1 FORM' and TYPE = 'PURCHASE' AND (FORMNO = '' OR (FORMNO <> '' AND RECDATE > '" & Format(TODATE.Date, "MM/dd/yyyy") & "'))) AS T ", " ORDER BY T.FORMNAME,T.QUARTERNAME, T.NAME, T.DATE, T.BILL ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 12)
                Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 12, True)
                Write(DTROW("CSTNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 12)
                Write(DTROW("FORMNAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 12)
                Write(DTROW("BILLINITIALS"), Range("5"), XlHAlign.xlHAlignRight, , False, 12)
                Write(DTROW("DATE"), Range("6"), XlHAlign.xlHAlignLeft, , False, 12)
                Write(Format(Val(DTROW("AMT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 12)
                Write("0", Range("8"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("TAXPER")), "0.00"), Range("9"), XlHAlign.xlHAlignRight, , False, 12)
                FORMULA("=ROUND((" & objColumn.Item("7").ToString & RowIndex & "*" & objColumn.Item("9").ToString & RowIndex & ")/100,0)", Range("10"), XlHAlign.xlHAlignRight, , False, 12)
                FORMULA("=ROUND((" & objColumn.Item("7").ToString & RowIndex & "*" & objColumn.Item("9").ToString & RowIndex & ")/100,0)", Range("11"), XlHAlign.xlHAlignRight, , False, 12)
                objSheet.Range(Range("10"), Range("11")).Interior.Color = RGB(198, 239, 206)
                SetBorder(RowIndex, Range("1"), Range("11"))
                SRNO += 1
            Next
            RowIndex += 1
            Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , True, 12)
            Write("Total", Range("2"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & 8 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & 8 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & 8 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 12)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & 8 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 12)
            objSheet.Range(Range("7"), Range("11")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("11"))


            objSheet.Range(objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function J6REPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 15)
            Next
            SetColumnWidth(Range("1"), 5)
            SetColumnWidth(Range("2"), 60)
            SetColumnWidth(Range("5"), 8)


            RowIndex += 1
            Write("ANNEXURE-J (SECTION 6)", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 15)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("TIN", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            objSheet.Range(Range("2"), Range("2")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("1"))
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write("Period", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 12)
            Write(FROMDATE.Date, Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 12)
            objSheet.Range(Range("4"), Range("4")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("To", Range("5"), XlHAlign.xlHAlignCenter, , True, 12)
            Write(TODATE.Date, Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            objSheet.Range(Range("6"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("6"), Range("6"))


            RowIndex += 1
            Write("EnteSupplier Wise Transactions Under CST Act, 1956", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            RowIndex += 1
            Write("Enter Gross Amount wise Top 999 Separately in descending order and put Total of Remaining in 1000th row", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            objSheet.Range(Range("1"), Range("6")).Font.Color = RGB(255, 0, 0)
            SetBorder(RowIndex, Range("1"), Range("6"))


            RowIndex += 1
            Write("Sr.No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("Name of Supplier", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("TIN No Supplier (If Any)", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("Transaction Type", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("Any Other Cost of Purchase", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12, True)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("Gross Amount (Rs.)", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12, True)
            SetBorder(RowIndex, Range("6"), Range("6"))


            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("1"))
            Write("2", Range("2"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("2"), Range("2"))
            Write("3", Range("3"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("3"), Range("3"))
            Write("4", Range("4"), XlHAlign.xlHAlignCenter, , True, 12, True)
            SetBorder(RowIndex, Range("4"), Range("4"))
            Write("5", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            SetBorder(RowIndex, Range("5"), Range("5"))
            Write("6", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("6"), Range("6"))


            'FREEZE TOP 8 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & 8).Application.ActiveWindow.FreezePanes = True



            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search(" NAME, CSTNO, SUM(AMT) AS AMOUNT ", "", " CFORMVIEW ", " AND TYPE = 'PURCHASE' AND FORMNAME = 'E1 FORM' AND YEARID = " & YEARID & WHERECLAUSE & " GROUP BY NAME, CSTNO ORDER BY NAME ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 12)
                Write(DTROW("NAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 12, True)
                Write(DTROW("CSTNO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 12)
                Write("Purchase u/s 6(2)", Range("4"), XlHAlign.xlHAlignLeft, , False, 12)
                Write("0", Range("5"), XlHAlign.xlHAlignRight, , False, 12)
                Write(Format(Val(DTROW("AMOUNT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 12)
                SetBorder(RowIndex, Range("1"), Range("6"))
                SRNO += 1
            Next

            RowIndex += 1
            Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , True, 12)
            Write("Total", Range("2"), XlHAlign.xlHAlignCenter, Range("5"), True, 12)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & 8 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            objSheet.Range(objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function SALES231REPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 10)
            Next

            SetColumnWidth(Range("4"), 40)
            SetColumnWidth(Range("5"), 20)
            SetColumnWidth(Range("18"), 72)


            RowIndex += 1
            Write("Annexure of Sales under M.V.A.T. Act, 2002 (See Rule 17, 17A, 18 and 45)", Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            objSheet.Range(Range("1"), Range("18")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("18"))

            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("3"), True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("3"))

            Write("M.V.A.T. R.C. No.", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("8"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("8"), Range("10"))

            Write("C.S.T. R.C. No.", Range("11"), XlHAlign.xlHAlignCenter, Range("16"), True, 10)
            objSheet.Range(Range("11"), Range("16")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("11"), Range("16"))

            Write("", Range("17"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("17"), Range("18"))


            RowIndex += 1
            Write("2", Range("1"), XlHAlign.xlHAlignCenter, Range("3"), True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("3"))

            Write("Name of the Dealer", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("7"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("7"), Range("18"))


            RowIndex += 1
            Write("3", Range("1"), XlHAlign.xlHAlignCenter, objColumn.Item("3").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), objColumn.Item("3").ToString & RowIndex + 1)

            Write("Type Of Return", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("7"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("7"), Range("10"))


            Write("Whether First Return?", Range("11"), XlHAlign.xlHAlignCenter, Range("17"), True, 10)
            objSheet.Range(Range("11"), Range("17")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("11"), Range("17"))

            Write("", Range("18"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("18"), Range("18"))



            RowIndex += 1
            Write("Periodicity Of Return", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("7"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("7"), Range("10"))


            Write("Whether Last Return?", Range("11"), XlHAlign.xlHAlignCenter, Range("17"), True, 10)
            objSheet.Range(Range("11"), Range("17")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("11"), Range("17"))

            Write("", Range("18"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("18"), Range("18"))


            RowIndex += 1
            Write("4", Range("1"), XlHAlign.xlHAlignCenter, objColumn.Item("3").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), objColumn.Item("3").ToString & RowIndex + 1)

            Write("Period Covered By Annexure", Range("4"), XlHAlign.xlHAlignCenter, objColumn.Item("6").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), objColumn.Item("6").ToString & RowIndex + 1)

            Write("From", Range("7"), XlHAlign.xlHAlignCenter, objColumn.Item("7").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("7"), Range("7")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("7"), objColumn.Item("7").ToString & RowIndex + 1)

            Write("Date", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            objSheet.Range(Range("8"), Range("8")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("Month", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            objSheet.Range(Range("9"), Range("9")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Year", Range("10"), XlHAlign.xlHAlignCenter, Range("11"), True, 10)
            objSheet.Range(Range("10"), Range("11")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("10"), Range("11"))

            Write("To", Range("12"), XlHAlign.xlHAlignCenter, objColumn.Item("12").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("12"), Range("12")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("12"), objColumn.Item("12").ToString & RowIndex + 1)

            Write("Date", Range("13"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            objSheet.Range(Range("13"), Range("14")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("13"), Range("14"))

            Write("Month", Range("15"), XlHAlign.xlHAlignCenter, Range("16"), True, 10)
            objSheet.Range(Range("15"), Range("16")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("15"), Range("16"))

            Write("Year", Range("17"), XlHAlign.xlHAlignCenter, Range("17"), True, 10)
            objSheet.Range(Range("17"), Range("17")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("17"), Range("17"))


            Write("", Range("18"), XlHAlign.xlHAlignCenter, objColumn.Item("18").ToString & RowIndex + 1, True, 10)
            SetBorder(RowIndex, Range("18"), objColumn.Item("18").ToString & RowIndex + 1)


            RowIndex += 2
            Write("Transactionwise Sales Details", Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            objSheet.Range(Range("1"), Range("18")).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, Range("1"), Range("18"))


            RowIndex += 1
            Write("Gross Total", Range("1"), XlHAlign.xlHAlignRight, Range("5"), True, 10)
            objSheet.Range(Range("1"), Range("18")).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, Range("1"), Range("5"))


            FORMULA("=ROUND(SUM(" & objColumn.Item("6").ToString & 12 & ":" & objColumn.Item("6").ToString & RowIndex + 104857 & "),2)", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("6"), Range("6"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("7").ToString & 12 & ":" & objColumn.Item("7").ToString & RowIndex + 104857 & "),2)", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("7"), Range("7"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("8").ToString & 12 & ":" & objColumn.Item("8").ToString & RowIndex + 104857 & "),2)", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("8"), Range("8"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("9").ToString & 12 & ":" & objColumn.Item("9").ToString & RowIndex + 104857 & "),2)", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("9"), Range("9"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("10").ToString & 12 & ":" & objColumn.Item("10").ToString & RowIndex + 104857 & "),2)", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("10"), Range("10"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("11").ToString & 12 & ":" & objColumn.Item("11").ToString & RowIndex + 104857 & "),2)", Range("11"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("11"), Range("11"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("12").ToString & 12 & ":" & objColumn.Item("12").ToString & RowIndex + 104857 & "),2)", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("12"), Range("12"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("13").ToString & 12 & ":" & objColumn.Item("13").ToString & RowIndex + 104857 & "),2)", Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("13"), Range("13"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("14").ToString & 12 & ":" & objColumn.Item("14").ToString & RowIndex + 104857 & "),2)", Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("14"), Range("14"))


            Write("", Range("15"), XlHAlign.xlHAlignRight, Range("18"), True, 10)
            SetBorder(RowIndex, Range("15"), Range("18"))


            RowIndex += 1
            Write("Sr. No.", Range("1"), XlHAlign.xlHAlignCenter, objColumn.Item("1").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("1"), Range("17")).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, Range("1"), objColumn.Item("1").ToString & RowIndex + 1)

            Write("Invoice No.", Range("2"), XlHAlign.xlHAlignCenter, objColumn.Item("2").ToString & RowIndex + 1, True, 10)
            SetBorder(RowIndex, Range("2"), objColumn.Item("2").ToString & RowIndex + 1)

            Write("Date Of Invoice", Range("3"), XlHAlign.xlHAlignCenter, objColumn.Item("3").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("3"), objColumn.Item("3").ToString & RowIndex + 1)

            Write("Name", Range("4"), XlHAlign.xlHAlignCenter, objColumn.Item("4").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("4"), objColumn.Item("4").ToString & RowIndex + 1)

            Write("TIN Of Purchaser (If Any)", Range("5"), XlHAlign.xlHAlignCenter, objColumn.Item("5").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("5"), objColumn.Item("5").ToString & RowIndex + 1)

            Write("Taxable Value Or Value of Composition u/s 42(3),(3A), (4)", Range("6"), XlHAlign.xlHAlignCenter, Range("7"), True, 10, True)
            SetBorder(RowIndex, Range("6"), Range("7"))

            Write("Nett Rs.", objColumn.Item("6").ToString & RowIndex + 1, XlHAlign.xlHAlignCenter, objColumn.Item("6").ToString & RowIndex + 1, True, 10, True)
            objSheet.Range(objColumn.Item("6").ToString & RowIndex + 1, objColumn.Item("7").ToString & RowIndex + 1).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)

            Write("Tax (If Any)", objColumn.Item("7").ToString & RowIndex + 1, XlHAlign.xlHAlignCenter, objColumn.Item("7").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex + 1, objColumn.Item("7").ToString & RowIndex + 1)

            Write("Value Inclusive of Tax Rs.", Range("8"), XlHAlign.xlHAlignCenter, objColumn.Item("8").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("8"), objColumn.Item("8").ToString & RowIndex + 1)

            Write("Value of Compisition u/s 42 (1), (2) Rs.", Range("9"), XlHAlign.xlHAlignCenter, objColumn.Item("9").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("9"), objColumn.Item("9").ToString & RowIndex + 1)

            Write("Tax Free Sales Rs.", Range("10"), XlHAlign.xlHAlignCenter, objColumn.Item("10").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("10"), objColumn.Item("10").ToString & RowIndex + 1)

            Write("Exempted Sales u/s 41 & 8 Rs.", Range("11"), XlHAlign.xlHAlignCenter, objColumn.Item("11").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("11"), objColumn.Item("11").ToString & RowIndex + 1)

            Write("Labour Charges Rs.", Range("12"), XlHAlign.xlHAlignCenter, objColumn.Item("12").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("12"), objColumn.Item("12").ToString & RowIndex + 1)

            Write("Other Charges (Rs.)", Range("13"), XlHAlign.xlHAlignCenter, objColumn.Item("13").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("13"), objColumn.Item("13").ToString & RowIndex + 1)

            Write("Gross Total (Rs.)", Range("14"), XlHAlign.xlHAlignCenter, objColumn.Item("14").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("14"), objColumn.Item("14").ToString & RowIndex + 1)

            Write("Action", Range("15"), XlHAlign.xlHAlignCenter, objColumn.Item("15").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("15"), objColumn.Item("15").ToString & RowIndex + 1)

            Write("Return Form No", Range("16"), XlHAlign.xlHAlignCenter, objColumn.Item("16").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("16"), objColumn.Item("16").ToString & RowIndex + 1)

            Write("Transaction Code", Range("17"), XlHAlign.xlHAlignCenter, objColumn.Item("17").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("17"), objColumn.Item("17").ToString & RowIndex + 1)

            Write("Description of Transaction Type", Range("18"), XlHAlign.xlHAlignCenter, objColumn.Item("18").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("18"), objColumn.Item("18").ToString & RowIndex + 1)


            'GET DATA
            RowIndex += 1
            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search(" INVOICE_NO AS INVOICENO, INVOICE_DATE AS DATE, ACC_CMPNAME AS PARTYNAME, Acc_VATNO AS TINNO, INVOICE_AMOUNT AS NETTAMT, 0 AS TAXAMT, ROUND((INVOICE_CHARGES + INVOICE_ROUNDOFF),2) AS OTHERCHGS, INVOICE_GRANDTOTAL AS GRANDTOTAL, (CASE WHEN LEDGERS.Acc_tinno = '' THEN 200 ELSE 100 END) AS CODE, (CASE WHEN LEDGERS.Acc_tinno = '' THEN 'Sales to Non-TIN Holder (Within the State or Interstate)' ELSE 'Sales to TIN Holder (Within the State or Interstate Excluding Against Forms / Declaration)' END) AS CODEDESC", "", " INVOICEMASTER INNER JOIN LEDGERS ON Acc_id = INVOICE_LEDGERID INNER JOIN REGISTERMASTER ON REGISTER_ID = INVOICEMASTER.INVOICE_REGISTERID ", WHERECLAUSE & " AND INVOICEMASTER.INVOICE_YEARID = " & YEARID & " ORDER BY DATE, INVOICENO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("INVOICENO"), Range("2"), XlHAlign.xlHAlignRight, , False, 10, True)
                Write(DTROW("DATE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(DTROW("PARTYNAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(DTROW("TINNO"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(Format(Val(DTROW("NETTAMT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("OTHERCHGS")), "0.00"), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("GRANDTOTAL")), "0.00"), Range("14"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("15"), XlHAlign.xlHAlignRight, , False, 10)
                Write("231", Range("16"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CODE"), Range("17"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CODEDESC"), Range("18"), XlHAlign.xlHAlignLeft, , False, 10)

                SetBorder(RowIndex, Range("1"), Range("18"))
                SRNO += 1
            Next

            objSheet.Range(objColumn.Item("6").ToString & 12, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 12, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 12, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 12, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 12, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 12, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("12").ToString & 12, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("13").ToString & 12, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("14").ToString & 12, objColumn.Item("14").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 12, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 12, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 12, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 12, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 12, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 12, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 12, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 12, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 12, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 12, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 12, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 12, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 12, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & 12, objColumn.Item("14").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("15").ToString & 12, objColumn.Item("15").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("16").ToString & 12, objColumn.Item("16").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("17").ToString & 12, objColumn.Item("17").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("18").ToString & 12, objColumn.Item("18").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100


            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function PURCHASE231REPORT_EXCEL(ByVal WHERECLAUSE As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 2 To 26
                SetColumnWidth(Range(i), 10)
            Next

            SetColumnWidth(Range("4"), 40)
            SetColumnWidth(Range("5"), 20)
            SetColumnWidth(Range("18"), 72)


            RowIndex += 1
            Write("Annexure of Purchase under M.V.A.T. Act, 2002 (See Rule 17, 17A, 18 and 45)", Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            objSheet.Range(Range("1"), Range("18")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("18"))

            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignCenter, Range("3"), True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("3"))

            Write("M.V.A.T. R.C. No.", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("7"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("7"), Range("10"))

            Write("C.S.T. R.C. No.", Range("11"), XlHAlign.xlHAlignCenter, Range("16"), True, 10)
            objSheet.Range(Range("11"), Range("16")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("11"), Range("16"))

            Write("", Range("17"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("17"), Range("18"))


            RowIndex += 1
            Write("2", Range("1"), XlHAlign.xlHAlignCenter, Range("3"), True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), Range("3"))

            Write("Name of the Dealer", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("7"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("7"), Range("18"))


            RowIndex += 1
            Write("3", Range("1"), XlHAlign.xlHAlignCenter, objColumn.Item("3").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), objColumn.Item("3").ToString & RowIndex + 1)

            Write("Type Of Return", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("7"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("7"), Range("10"))


            Write("Whether First Return?", Range("11"), XlHAlign.xlHAlignCenter, Range("17"), True, 10)
            objSheet.Range(Range("11"), Range("17")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("11"), Range("17"))

            Write("", Range("18"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("18"), Range("18"))



            RowIndex += 1
            Write("Periodicity Of Return", Range("4"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), Range("6"))

            Write("", Range("7"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            SetBorder(RowIndex, Range("7"), Range("10"))


            Write("Whether Last Return?", Range("11"), XlHAlign.xlHAlignCenter, Range("17"), True, 10)
            objSheet.Range(Range("11"), Range("17")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("11"), Range("17"))

            Write("", Range("18"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            SetBorder(RowIndex, Range("18"), Range("18"))


            RowIndex += 1
            Write("4", Range("1"), XlHAlign.xlHAlignCenter, objColumn.Item("3").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("1"), Range("3")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("1"), objColumn.Item("3").ToString & RowIndex + 1)

            Write("Period Covered By Annexure", Range("4"), XlHAlign.xlHAlignCenter, objColumn.Item("6").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("4"), Range("6")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("4"), objColumn.Item("6").ToString & RowIndex + 1)

            Write("From", Range("7"), XlHAlign.xlHAlignCenter, objColumn.Item("7").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("7"), Range("7")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("7"), objColumn.Item("7").ToString & RowIndex + 1)

            Write("Date", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            objSheet.Range(Range("8"), Range("8")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("Month", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10)
            objSheet.Range(Range("9"), Range("9")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Year", Range("10"), XlHAlign.xlHAlignCenter, Range("11"), True, 10)
            objSheet.Range(Range("10"), Range("11")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("10"), Range("11"))

            Write("To", Range("12"), XlHAlign.xlHAlignCenter, objColumn.Item("12").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("12"), Range("12")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("12"), objColumn.Item("12").ToString & RowIndex + 1)

            Write("Date", Range("13"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            objSheet.Range(Range("13"), Range("14")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("13"), Range("14"))

            Write("Month", Range("15"), XlHAlign.xlHAlignCenter, Range("16"), True, 10)
            objSheet.Range(Range("15"), Range("16")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("15"), Range("16"))

            Write("Year", Range("17"), XlHAlign.xlHAlignCenter, Range("17"), True, 10)
            objSheet.Range(Range("17"), Range("17")).Interior.Color = RGB(198, 239, 206)
            SetBorder(RowIndex, Range("17"), Range("17"))


            Write("", Range("18"), XlHAlign.xlHAlignCenter, objColumn.Item("18").ToString & RowIndex + 1, True, 10)
            SetBorder(RowIndex, Range("18"), objColumn.Item("18").ToString & RowIndex + 1)


            RowIndex += 2
            Write("Transactionwise Purchase Details", Range("1"), XlHAlign.xlHAlignCenter, Range("18"), True, 10)
            objSheet.Range(Range("1"), Range("18")).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, Range("1"), Range("18"))


            RowIndex += 1
            Write("Gross Total", Range("1"), XlHAlign.xlHAlignRight, Range("5"), True, 10)
            objSheet.Range(Range("1"), Range("18")).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, Range("1"), Range("5"))


            FORMULA("=ROUND(SUM(" & objColumn.Item("6").ToString & 12 & ":" & objColumn.Item("6").ToString & RowIndex + 104857 & "),2)", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("6"), Range("6"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("7").ToString & 12 & ":" & objColumn.Item("7").ToString & RowIndex + 104857 & "),2)", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("7"), Range("7"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("8").ToString & 12 & ":" & objColumn.Item("8").ToString & RowIndex + 104857 & "),2)", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("8"), Range("8"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("9").ToString & 12 & ":" & objColumn.Item("9").ToString & RowIndex + 104857 & "),2)", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("9"), Range("9"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("10").ToString & 12 & ":" & objColumn.Item("10").ToString & RowIndex + 104857 & "),2)", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("10"), Range("10"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("11").ToString & 12 & ":" & objColumn.Item("11").ToString & RowIndex + 104857 & "),2)", Range("11"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("11"), Range("11"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("12").ToString & 12 & ":" & objColumn.Item("12").ToString & RowIndex + 104857 & "),2)", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("12"), Range("12"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("13").ToString & 12 & ":" & objColumn.Item("13").ToString & RowIndex + 104857 & "),2)", Range("13"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("13"), Range("13"))

            FORMULA("=ROUND(SUM(" & objColumn.Item("14").ToString & 12 & ":" & objColumn.Item("14").ToString & RowIndex + 104857 & "),2)", Range("14"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, Range("14"), Range("14"))



            Write("", Range("15"), XlHAlign.xlHAlignRight, Range("18"), True, 10)
            SetBorder(RowIndex, Range("15"), Range("18"))


            RowIndex += 1
            Write("Sr. No.", Range("1"), XlHAlign.xlHAlignCenter, objColumn.Item("1").ToString & RowIndex + 1, True, 10)
            objSheet.Range(Range("1"), Range("17")).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, Range("1"), objColumn.Item("1").ToString & RowIndex + 1)

            Write("Invoice No.", Range("2"), XlHAlign.xlHAlignCenter, objColumn.Item("2").ToString & RowIndex + 1, True, 10)
            SetBorder(RowIndex, Range("2"), objColumn.Item("2").ToString & RowIndex + 1)

            Write("Date Of Invoice", Range("3"), XlHAlign.xlHAlignCenter, objColumn.Item("3").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("3"), objColumn.Item("3").ToString & RowIndex + 1)

            Write("Name", Range("4"), XlHAlign.xlHAlignCenter, objColumn.Item("4").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("4"), objColumn.Item("4").ToString & RowIndex + 1)

            Write("TIN Of Seller (If Any)", Range("5"), XlHAlign.xlHAlignCenter, objColumn.Item("5").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("5"), objColumn.Item("5").ToString & RowIndex + 1)

            Write("Taxable Value Or Value of Composition u/s 42(3),(3A), (4)", Range("6"), XlHAlign.xlHAlignCenter, Range("7"), True, 10, True)
            SetBorder(RowIndex, Range("6"), Range("7"))

            Write("Nett Rs.", objColumn.Item("6").ToString & RowIndex + 1, XlHAlign.xlHAlignCenter, objColumn.Item("6").ToString & RowIndex + 1, True, 10, True)
            objSheet.Range(objColumn.Item("6").ToString & RowIndex + 1, objColumn.Item("7").ToString & RowIndex + 1).Interior.Color = RGB(242, 242, 242)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)

            Write("Tax (If Any)", objColumn.Item("7").ToString & RowIndex + 1, XlHAlign.xlHAlignCenter, objColumn.Item("7").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex + 1, objColumn.Item("7").ToString & RowIndex + 1)

            Write("Value Inclusive of Tax Rs.", Range("8"), XlHAlign.xlHAlignCenter, objColumn.Item("8").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("7"), objColumn.Item("8").ToString & RowIndex + 1)

            Write("Value of Compisition u/s 42 (1), (2) Rs.", Range("9"), XlHAlign.xlHAlignCenter, objColumn.Item("9").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("9"), objColumn.Item("9").ToString & RowIndex + 1)

            Write("Tax Free Sales Rs.", Range("10"), XlHAlign.xlHAlignCenter, objColumn.Item("10").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("10"), objColumn.Item("10").ToString & RowIndex + 1)

            Write("Exempted Sales u/s 41 & 8 Rs.", Range("11"), XlHAlign.xlHAlignCenter, objColumn.Item("11").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("11"), objColumn.Item("11").ToString & RowIndex + 1)

            Write("Labour Charges Rs.", Range("12"), XlHAlign.xlHAlignCenter, objColumn.Item("12").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("12"), objColumn.Item("12").ToString & RowIndex + 1)

            Write("Other Charges (Rs.)", Range("13"), XlHAlign.xlHAlignCenter, objColumn.Item("13").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("13"), objColumn.Item("13").ToString & RowIndex + 1)

            Write("Gross Total (Rs.)", Range("14"), XlHAlign.xlHAlignCenter, objColumn.Item("14").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("14"), objColumn.Item("14").ToString & RowIndex + 1)

            Write("Action", Range("15"), XlHAlign.xlHAlignCenter, objColumn.Item("15").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("15"), objColumn.Item("15").ToString & RowIndex + 1)

            Write("Return Form No", Range("16"), XlHAlign.xlHAlignCenter, objColumn.Item("16").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("16"), objColumn.Item("16").ToString & RowIndex + 1)

            Write("Transaction Code", Range("17"), XlHAlign.xlHAlignCenter, objColumn.Item("17").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("17"), objColumn.Item("17").ToString & RowIndex + 1)

            Write("Description of Transaction Type", Range("18"), XlHAlign.xlHAlignCenter, objColumn.Item("18").ToString & RowIndex + 1, True, 10, True)
            SetBorder(RowIndex, Range("18"), objColumn.Item("18").ToString & RowIndex + 1)


            'GET DATA
            RowIndex += 1
            Dim OBJCMN As New ClsCommon
            Dim SRNO As Integer = 1
            Dim DT As System.Data.DataTable = OBJCMN.search(" BILL_PARTYBILLNO AS INVOICENO, BILL_PARTYBILLDATE AS DATE, ACC_CMPNAME AS PARTYNAME, Acc_VATNO AS TINNO, BILL_BILLAMT AS NETTAMT, BILL_TOTALTAXAMT AS TAXAMT, ROUND((BILL_TOTALCHGSAMT + BILL_ROUNDOFF),2) AS OTHERCHGS, BILL_GRANDTOTAL AS GRANDTOTAL, (CASE WHEN LEDGERS.Acc_tinno = '' THEN 20 ELSE 10 END) AS CODE, (CASE WHEN LEDGERS.Acc_tinno = '' THEN 'Within the State URD Purchases' ELSE 'Within the State Purchases from  RD' END) AS CODEDESC, REGISTERMASTER.REGISTER_NAME AS REGNAME ", "", " PURCHASEMASTER INNER JOIN LEDGERS ON Acc_id = BILL_LEDGERID  INNER JOIN REGISTERMASTER ON REGISTER_ID = PURCHASEMASTER.BILL_REGISTERID ", WHERECLAUSE & " AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " ORDER BY DATE, INVOICENO ")
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(SRNO, Range("1"), XlHAlign.xlHAlignRight, , False, 10)
                Write(DTROW("INVOICENO"), Range("2"), XlHAlign.xlHAlignRight, , False, 10, True)
                Write(DTROW("DATE"), Range("3"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(DTROW("PARTYNAME"), Range("4"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(DTROW("TINNO"), Range("5"), XlHAlign.xlHAlignLeft, , False, 10, True)
                Write(Format(Val(DTROW("NETTAMT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("TAXAMT")), "0.00"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("9"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("10"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("11"), XlHAlign.xlHAlignRight, , False, 10)
                Write("0", Range("12"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("OTHERCHGS")), "0.00"), Range("13"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Format(Val(DTROW("GRANDTOTAL")), "0.00"), Range("14"), XlHAlign.xlHAlignRight, , False, 10)
                Write("", Range("15"), XlHAlign.xlHAlignRight, , False, 10)
                Write("231", Range("16"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CODE"), Range("17"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("CODEDESC"), Range("18"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(DTROW("REGNAME"), Range("19"), XlHAlign.xlHAlignLeft, , False, 10)

                SetBorder(RowIndex, Range("1"), Range("18"))
                SRNO += 1
            Next

            objSheet.Range(objColumn.Item("6").ToString & 12, objColumn.Item("6").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("7").ToString & 12, objColumn.Item("7").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("8").ToString & 12, objColumn.Item("8").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("9").ToString & 12, objColumn.Item("9").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("10").ToString & 12, objColumn.Item("10").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("11").ToString & 12, objColumn.Item("11").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("12").ToString & 12, objColumn.Item("12").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("13").ToString & 12, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("14").ToString & 12, objColumn.Item("14").ToString & RowIndex).NumberFormat = "0.00"

            SetBorder(RowIndex, objColumn.Item("1").ToString & 12, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 12, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 12, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 12, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 12, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 12, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 12, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 12, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 12, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 12, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 12, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 12, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("13").ToString & 12, objColumn.Item("13").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("14").ToString & 12, objColumn.Item("14").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("15").ToString & 12, objColumn.Item("15").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("16").ToString & 12, objColumn.Item("16").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("17").ToString & 12, objColumn.Item("17").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("18").ToString & 12, objColumn.Item("18").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("19").ToString & 12, objColumn.Item("19").ToString & RowIndex)

            objBook.Application.ActiveWindow.Zoom = 100


            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "TDS REPORTS"

    Public Function TDSCHALLANDETAILS(ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next

            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            objSheet.Name = "CHALLAN DETAILS"
            SetColumnWidth(Range(8), 25)


            Dim OBJCMN As New ClsCommon
            'WE NEED TO GROUP
            'Dim DT As System.Data.DataTable = OBJCMN.search(" T.DATE, T.NAME, T.[BILLINITIALS], T.BILLAMT, T.TDSAMT, ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') AS CHALLANNO, TDSCHALLAN.TDSCHA_CHALLANDATE AS CHALLANDATE, ISNULL(TDSCHALLAN.TDSCHA_CHQNO, '') AS CHQNO, ISNULL(TDSCHALLAN.TDSCHA_BANKNAME, '') AS BANKNAME, ISNULL(ACCOUNTSMASTER_TDS.ACC_SECTION,'') AS SECTION   ", "", " (SELECT [DATE], NAME, BILLINITIALS, BILLAMT, TDSAMT, CHALLANNO, CHALLANDATE, CHQNO, BANKNAME, BILL, YEARID, TDSLEDGER FROM TDSCHALLANVIEW WHERE YEARID = " & YEARID & " AND DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "') AS T LEFT OUTER JOIN TDSCHALLAN ON T.YEARID = TDSCHALLAN.TDSCHA_YEARID AND T.[BILLINITIALS] = TDSCHALLAN.TDSCHA_BILLNO INNER JOIN ACCOUNTSMASTER ON ACC_CMPNAME = T.NAME AND ACCOUNTSMASTER.ACC_YEARID = T.YEARID LEFT OUTER JOIN ACCOUNTSMASTER_TDS ON ACCOUNTSMASTER.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID ", " AND ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') <> ''  ORDER BY T.BILL")
            Dim DT As System.Data.DataTable = OBJCMN.search(" SUM(T.TDSAMT) AS TDSAMT, ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') AS CHALLANNO, TDSCHALLAN.TDSCHA_CHALLANDATE AS CHALLANDATE, ISNULL(TDSCHALLAN.TDSCHA_CHQNO, '') AS CHQNO, ISNULL(TDSCHALLAN.TDSCHA_BANKNAME, '') AS BANKNAME, ISNULL(ACCOUNTSMASTER_TDS.ACC_SECTION,'') AS SECTION ", "", " (SELECT [DATE], NAME, BILLINITIALS, BILLAMT, TDSAMT, CHALLANNO, CHALLANDATE, CHQNO, BANKNAME, BILL, YEARID, TDSLEDGER FROM TDSCHALLANVIEW WHERE YEARID = " & YEARID & " AND DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "') AS T LEFT OUTER JOIN TDSCHALLAN ON T.YEARID = TDSCHALLAN.TDSCHA_YEARID AND T.[BILLINITIALS] = TDSCHALLAN.TDSCHA_BILLNO INNER JOIN ACCOUNTSMASTER ON ACC_CMPNAME = T.NAME AND ACCOUNTSMASTER.ACC_YEARID = T.YEARID LEFT OUTER JOIN ACCOUNTSMASTER_TDS ON ACCOUNTSMASTER.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID ", " AND ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') <> ''  GROUP BY ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') , TDSCHALLAN.TDSCHA_CHALLANDATE , ISNULL(TDSCHALLAN.TDSCHA_CHQNO, '') , ISNULL(TDSCHALLAN.TDSCHA_BANKNAME, '') , ISNULL(ACCOUNTSMASTER_TDS.ACC_SECTION,'') ORDER BY TDSCHALLAN.TDSCHA_CHALLANDATE ")

            RowIndex = 1
            objSheet.Range(Range("1"), Range("14")).Font.Color = RGB(255, 255, 255)

            objSheet.Range(Range("1"), Range("1")).Interior.Color = RGB(255, 0, 0)
            Write("Challan Serial No. (401)", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10, True)
            SetBorder(RowIndex, Range("1"), Range("1"))


            objSheet.Range(Range("2"), Range("6")).Interior.Color = RGB(102, 102, 153)
            Write("Income Tax (402)", Range("2"), XlHAlign.xlHAlignCenter, Range("2"), True, 10, True)
            SetBorder(RowIndex, Range("2"), Range("2"))

            Write("Interest (403)", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 10, True)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("Fees (404)", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 10, True)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("Others/Penalty (405)", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 10, True)
            SetBorder(RowIndex, Range("5"), Range("5"))

            Write("Total Tax Deposited/ Book Adjustment (406)", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 10, True)
            SetBorder(RowIndex, Range("6"), Range("6"))



            objSheet.Range(Range("7"), Range("7")).Interior.Color = RGB(255, 0, 0)
            Write("Whether deposited by book Adjustment Yes/No (407)", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 10, True)
            SetBorder(RowIndex, Range("7"), Range("7"))



            objSheet.Range(Range("8"), Range("8")).Interior.Color = RGB(102, 102, 153)
            Write("BSR Code (408)", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10, True)
            SetBorder(RowIndex, Range("8"), Range("8"))



            objSheet.Range(Range("9"), Range("10")).Interior.Color = RGB(255, 0, 0)
            Write("Date on which Tax Deposited/ Date of Transfer voucher (410)", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Challan Serial No./DDO Serial No. of Form no. 24G (409)", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 10, True)
            SetBorder(RowIndex, Range("10"), Range("10"))



            objSheet.Range(Range("11"), Range("11")).Interior.Color = RGB(102, 102, 153)
            Write("Receipt No. of form 24G (408)", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 10, True)
            SetBorder(RowIndex, Range("11"), Range("11"))



            objSheet.Range(Range("12"), Range("12")).Interior.Color = RGB(255, 0, 0)
            Write("Minor Head of Challan (411)", Range("12"), XlHAlign.xlHAlignCenter, Range("12"), True, 10, True)
            SetBorder(RowIndex, Range("12"), Range("12"))



            objSheet.Range(Range("13"), Range("14")).Interior.Color = RGB(102, 102, 153)
            Write("Cheque/DD No.", Range("13"), XlHAlign.xlHAlignCenter, Range("13"), True, 10, True)
            SetBorder(RowIndex, Range("13"), Range("13"))

            Write("Section Code For Own Record (It will be import in Remark)", Range("14"), XlHAlign.xlHAlignCenter, Range("14"), True, 10, True)
            SetBorder(RowIndex, Range("14"), Range("14"))



            Dim a As Integer = 1
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                Write(a, Range("1"), XlHAlign.xlHAlignRight, , True, 10)
                Write(Val(DTROW("TDSAMT")), Range("2"), XlHAlign.xlHAlignRight, , True, 10)
                Write("", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("", Range("4"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("", Range("5"), XlHAlign.xlHAlignLeft, , True, 10)
                Write(Val(DTROW("TDSAMT")), Range("6"), XlHAlign.xlHAlignRight, , True, 10)
                Write("No", Range("7"), XlHAlign.xlHAlignLeft, , True, 10)
                Write(DTROW("BANKNAME"), Range("8"), XlHAlign.xlHAlignLeft, , True, 10)
                Write(Convert.ToDateTime(DTROW("CHALLANDATE")).Date, Range("9"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTROW("CHALLANNO"), Range("10"), XlHAlign.xlHAlignRight, , True, 10)
                Write("", Range("11"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("200", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
                Write(DTROW("CHQNO"), Range("13"), XlHAlign.xlHAlignLeft, , True, 10)
                Write(DTROW("SECTION"), Range("14"), XlHAlign.xlHAlignLeft, , True, 10)
                SetBorder(RowIndex, Range("1"), Range("14"))
                a += 1
            Next

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            objBook.Application.ActiveWindow.Zoom = 100
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function TDSDEDUCTEEDETAILS(ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            objSheet.Name = "DEDUCTEE DETAILS"



            Dim OBJCMN As New ClsCommon
            Dim DT As System.Data.DataTable = OBJCMN.search(" ISNULL(ACCOUNTSMASTER_TDS.ACC_SECTION,'') AS SECTION, ACCOUNTSMASTER.Acc_panno AS PANNO,  T.NAME,T.DATE,  T.BILLAMT, ROUND(((T.TDSAMT/ T.BILLAMT) * 100),0) AS TAXPER,  T.TDSAMT, ACCOUNTSMASTER.Acc_add1  AS BLDGNAME, '' AS STREETNAME, ISNULL(area_name,'') AS AREANAME, ISNULL(CITY_NAME,'') AS CITYNAME, Acc_zipcode AS PIN, ISNULL(STATE_NAME,'') AS STATENAME, ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') AS CHALLANNO, TDSCHALLAN.TDSCHA_CHALLANDATE AS CHALLANDATE, ISNULL(TDSCHALLAN.TDSCHA_CHQNO, '') AS CHQNO, ISNULL(TDSCHALLAN.TDSCHA_BANKNAME, '') AS BANKNAME ", "", " (SELECT [DATE], NAME, BILLINITIALS, BILLAMT, TDSAMT, CHALLANNO, CHALLANDATE, CHQNO, BANKNAME, BILL, YEARID, TDSLEDGER FROM TDSCHALLANVIEW  WHERE YEARID = " & YEARID & " AND DATE >= '" & Format(FROMDATE.Date, "MM/dd/yyyy") & "' AND DATE <= '" & Format(TODATE.Date, "MM/dd/yyyy") & "') AS T  LEFT OUTER JOIN TDSCHALLAN ON T.YEARID = TDSCHALLAN.TDSCHA_YEARID AND T.[BILLINITIALS] = TDSCHALLAN.TDSCHA_BILLNO INNER JOIN ACCOUNTSMASTER ON ACC_CMPNAME = T.NAME AND ACCOUNTSMASTER.ACC_YEARID = T.YEARID LEFT OUTER JOIN ACCOUNTSMASTER_TDS ON ACCOUNTSMASTER.ACC_ID = ACCOUNTSMASTER_TDS.ACC_ID LEFT OUTER JOIN AREAMASTER ON Acc_areaid = area_id LEFT OUTER JOIN CITYMASTER ON Acc_cityid = city_id LEFT OUTER JOIN STATEMASTER ON Acc_stateid = state_id ", " AND ISNULL(TDSCHALLAN.TDSCHA_CHALLANNO, '') <> '' ORDER BY TDSCHALLAN.TDSCHA_CHALLANDATE, TDSCHALLAN.TDSCHA_CHALLANNO, T.BILL")

            RowIndex = 1
            objSheet.Range(Range("1"), Range("23")).Font.Color = RGB(255, 255, 255)
            objSheet.Range(Range("1"), Range("2")).Interior.Color = RGB(255, 0, 0)
            Write("Challan Serial No.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10, True)
            SetBorder(RowIndex, Range("1"), Range("1"))

            Write("Section Code", Range("2"), XlHAlign.xlHAlignCenter, Range("2"), True, 10, True)
            SetBorder(RowIndex, Range("2"), Range("2"))



            objSheet.Range(Range("3"), Range("5")).Interior.Color = RGB(102, 102, 153)
            Write("Type Of Rent", Range("3"), XlHAlign.xlHAlignCenter, Range("3"), True, 10, True)
            SetBorder(RowIndex, Range("3"), Range("3"))

            Write("PAN Reference No. (In case of No PAN)", Range("4"), XlHAlign.xlHAlignCenter, Range("4"), True, 10, True)
            SetBorder(RowIndex, Range("4"), Range("4"))

            Write("Deductee Reference no. If Available (413)", Range("5"), XlHAlign.xlHAlignCenter, Range("5"), True, 10, True)
            SetBorder(RowIndex, Range("5"), Range("5"))



            objSheet.Range(Range("6"), Range("11")).Interior.Color = RGB(255, 0, 0)
            Write("Deductee Code (414)", Range("6"), XlHAlign.xlHAlignCenter, Range("6"), True, 10, True)
            SetBorder(RowIndex, Range("6"), Range("6"))

            Write("Permanent Account Number (PAN) of deductee (415)", Range("7"), XlHAlign.xlHAlignCenter, Range("7"), True, 10, True)
            SetBorder(RowIndex, Range("7"), Range("7"))

            Write("Name of Deductee (416)", Range("8"), XlHAlign.xlHAlignCenter, Range("8"), True, 10, True)
            SetBorder(RowIndex, Range("8"), Range("8"))

            Write("Date on which Amount paid / credited (418)", Range("9"), XlHAlign.xlHAlignCenter, Range("9"), True, 10, True)
            SetBorder(RowIndex, Range("9"), Range("9"))

            Write("Date on which tax deducted (422)", Range("10"), XlHAlign.xlHAlignCenter, Range("10"), True, 10, True)
            SetBorder(RowIndex, Range("10"), Range("10"))

            Write("Amount of Payment (Rs.) (419)", Range("11"), XlHAlign.xlHAlignCenter, Range("11"), True, 10, True)
            SetBorder(RowIndex, Range("11"), Range("11"))



            objSheet.Range(Range("12"), Range("23")).Interior.Color = RGB(102, 102, 153)
            Write("Rate at which tax deducted (423)", Range("12"), XlHAlign.xlHAlignCenter, Range("12"), True, 10, True)
            SetBorder(RowIndex, Range("12"), Range("12"))

            Write("Amount of tax deducted", Range("13"), XlHAlign.xlHAlignCenter, Range("13"), True, 10, True)
            SetBorder(RowIndex, Range("13"), Range("13"))

            Write("Total Tax Deposited (421)", Range("14"), XlHAlign.xlHAlignCenter, Range("14"), True, 10, True)
            SetBorder(RowIndex, Range("14"), Range("14"))

            Write("Reason for Non-deduction / Lower Deduction, if any (424)", Range("15"), XlHAlign.xlHAlignCenter, Range("15"), True, 10, True)
            SetBorder(RowIndex, Range("15"), Range("15"))

            Write("Certificate No. u/s 197 issued by the AO for non deduction/ lower deduction (425)", Range("16"), XlHAlign.xlHAlignCenter, Range("16"), True, 10, True)
            SetBorder(RowIndex, Range("16"), Range("16"))

            Write("Deductee Flat No.", Range("17"), XlHAlign.xlHAlignCenter, Range("17"), True, 10, True)
            SetBorder(RowIndex, Range("17"), Range("17"))

            Write("Deductee Building Name", Range("18"), XlHAlign.xlHAlignCenter, Range("18"), True, 10, True)
            SetBorder(RowIndex, Range("18"), Range("18"))

            Write("Deductee Street Name", Range("19"), XlHAlign.xlHAlignCenter, Range("19"), True, 10, True)
            SetBorder(RowIndex, Range("19"), Range("19"))

            Write("Deductee Area", Range("20"), XlHAlign.xlHAlignCenter, Range("20"), True, 10, True)
            SetBorder(RowIndex, Range("20"), Range("20"))

            Write("Deductee City/Town", Range("21"), XlHAlign.xlHAlignCenter, Range("21"), True, 10, True)
            SetBorder(RowIndex, Range("21"), Range("21"))

            Write("Deductee PIN", Range("22"), XlHAlign.xlHAlignCenter, Range("22"), True, 10, True)
            SetBorder(RowIndex, Range("22"), Range("22"))

            Write("Deductee State", Range("23"), XlHAlign.xlHAlignCenter, Range("23"), True, 10, True)
            SetBorder(RowIndex, Range("23"), Range("23"))


            Dim a As Integer = 0
            Dim CNO As String = ""
            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                If CNO <> DTROW("CHALLANNO") Then
                    a += 1
                    CNO = DTROW("CHALLANNO")
                End If
                Write(a, Range("1"), XlHAlign.xlHAlignRight, , True, 9)
                Write(DTROW("SECTION"), Range("2"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("3"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("4"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("5"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("6"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("PANNO"), Range("7"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("NAME"), Range("8"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("DATE"), Range("9"), XlHAlign.xlHAlignRight, , True, 9)
                Write(DTROW("DATE"), Range("10"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("BILLAMT")), Range("11"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("TAXPER")), Range("12"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("TDSAMT")), Range("13"), XlHAlign.xlHAlignRight, , True, 9)
                Write(Val(DTROW("TDSAMT")), Range("14"), XlHAlign.xlHAlignRight, , True, 9)
                Write("", Range("15"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("16"), XlHAlign.xlHAlignLeft, , True, 9)
                Write("", Range("17"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("BLDGNAME"), Range("18"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("STREETNAME"), Range("19"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("AREANAME"), Range("20"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("CITYNAME"), Range("21"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("PIN"), Range("22"), XlHAlign.xlHAlignLeft, , True, 9)
                Write(DTROW("STATENAME"), Range("23"), XlHAlign.xlHAlignLeft, , True, 9)
                SetBorder(RowIndex, Range("1"), Range("23"))
            Next

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    .CenterHorizontally = True
            'End With

            objBook.Application.ActiveWindow.Zoom = 100
            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "STATEMENTOFACCOUNTS"

    Public Function STATEMENTOFACCOUNTS_EXCEL(ByVal DV As System.Data.DataView, ByVal NAME As String, ByVal OPDRCR As String, ByVal OPENING As Double, ByVal CLODRCR As String, ByVal CLOSING As Double, ByVal PERIOD As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 12)
            Next

            SetColumnWidth(Range(1), 46)
            SetColumnWidth(Range(2), 7)
            SetColumnWidth(Range(3), 9)
            SetColumnWidth(Range(4), 9)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("STATEMENT OF ACCOUTS", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            Dim DTLEDGER As System.Data.DataTable = OBJCMN.search(" ISNULL(Acc_panno,'') AS PANNO, ISNULL(CITY_NAME,'') AS CITYNAME ", "", " LEDGERS LEFT OUTER JOIN CITYMASTER ON ACC_CITYID = CITY_ID ", " AND ACC_CMPNAME = '" & NAME & "' AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND ACC_YEARID = " & YEARID)
            RowIndex += 1
            Write("NAME" & "          :  " & NAME & "   -   " & UCase(DTLEDGER.Rows(0).Item("CITYNAME")), Range("1"), XlHAlign.xlHAlignLeft, Range("6"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("PAN NO" & "        :  " & DTLEDGER.Rows(0).Item("PANNO"), Range("1"), XlHAlign.xlHAlignLeft, Range("6"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("PERIOD" & "        :  " & PERIOD, Range("1"), XlHAlign.xlHAlignLeft, Range("1"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("6").ToString & 10).Select()
            objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("6").ToString & 10).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)



            RowIndex += 1
            Write("DESCRIPTION", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TYPE", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("BILL", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DATE", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DEBIT", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CREDIT", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            RowIndex += 1
            Write("OPENING BALANCE ", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            If OPDRCR = "Dr" Then
                Write(OPENING, Range("5"), XlHAlign.xlHAlignRight, Range("5"), False, 10)
            Else
                Write(OPENING, Range("6"), XlHAlign.xlHAlignRight, Range("6"), False, 10)
            End If
            SetBorder(RowIndex, Range("5"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("6"))


            Dim STARTROWNO As Integer = RowIndex + 1
            Dim DT As System.Data.DataTable = DV.Table


            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                If DTROW("TYPE") = "SALE" Then
                    Write(DTROW("REGTYPE") & "; Due Dt:" & Format(Convert.ToDateTime(DTROW("DUEDATE")).Date, "dd/MM/yyyy"), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                Else
                    Write(Convert.ToString(DTROW("REMARKS").ToString), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                End If
                Write(DTROW("TYPE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                Write(DTROW("BILL NO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                Write(Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd/MM/yyyy"), Range("4"), XlHAlign.xlHAlignCenter, , False, 9)
                Write(Format(Val(DTROW("DEBIT")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
            Next

            RowIndex += 1
            Write("TOTAL    : ", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("4"))
            FORMULA("=SUM(" & objColumn.Item("5").ToString & STARTROWNO & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , False, 9)
            SetBorder(RowIndex, Range("5"), Range("5"))
            FORMULA("=SUM(" & objColumn.Item("6").ToString & STARTROWNO & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , False, 9)
            SetBorder(RowIndex, Range("6"), Range("6"))

            RowIndex += 1
            Write("CLOSING BALANCE    : ", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("4"))
            If CLODRCR = "Dr" Then
                Write(CLOSING, Range("5"), XlHAlign.xlHAlignRight, Range("5"), False, 9)
                SetBorder(RowIndex, Range("5"), Range("5"))
            Else
                Write(CLOSING, Range("6"), XlHAlign.xlHAlignRight, Range("6"), False, 9)
                SetBorder(RowIndex, Range("6"), Range("6"))
            End If



            'SET FONT
            objSheet.Range(objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex).Font.Name = "Trebuchet MS"
            objSheet.Range(objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex).Font.Size = 9


            SetBorder(RowIndex, objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & STARTROWNO, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & STARTROWNO, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & STARTROWNO, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & STARTROWNO, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex)


            objSheet.Range(Range("5")).NumberFormat = "0.00"
            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("1").ToString & 1, objColumn.Item("6").ToString & RowIndex).Select()

            objBook.Application.ActiveWindow.Zoom = 100



            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    '.Zoom = False
            '    '.FitToPagesTall = 1
            '    .FitToPagesWide = 1
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function STATEMENTOFACCOUNTSDETAILS_EXCEL(ByVal DV As System.Data.DataView, ByVal NAME As String, ByVal OPDRCR As String, ByVal OPENING As Double, ByVal CLODRCR As String, ByVal CLOSING As Double, ByVal PERIOD As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 12)
            Next

            SetColumnWidth(Range(1), 46)
            SetColumnWidth(Range(2), 7)
            SetColumnWidth(Range(3), 9)
            SetColumnWidth(Range(4), 9)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("STATEMENT OF ACCOUTS (DETAILS)", Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            Dim DTLEDGER As System.Data.DataTable = OBJCMN.search(" ISNULL(Acc_panno,'') AS PANNO, ISNULL(CITY_NAME,'') AS CITYNAME ", "", " LEDGERS LEFT OUTER JOIN CITYMASTER ON ACC_CITYID = CITY_ID ", " AND ACC_CMPNAME = '" & NAME & "' AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND ACC_YEARID = " & YEARID)
            RowIndex += 1
            Write("NAME" & "          :  " & NAME & "   -   " & UCase(DTLEDGER.Rows(0).Item("CITYNAME")), Range("1"), XlHAlign.xlHAlignLeft, Range("6"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("PAN NO" & "        :  " & DTLEDGER.Rows(0).Item("PANNO"), Range("1"), XlHAlign.xlHAlignLeft, Range("6"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write("PERIOD" & "        :  " & PERIOD, Range("1"), XlHAlign.xlHAlignLeft, Range("1"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("6").ToString & 10).Select()
            objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("6").ToString & 10).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("6").ToString & RowIndex + 1)



            RowIndex += 1
            Write("DESCRIPTION", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TYPE", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("BILL", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DATE", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DEBIT", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CREDIT", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)


            RowIndex += 1
            Write("OPENING BALANCE ", Range("1"), XlHAlign.xlHAlignLeft, Range("1"), False, 10)
            SetBorder(RowIndex, Range("1"), Range("1"))
            If OPDRCR = "Dr" Then
                Write(OPENING, Range("5"), XlHAlign.xlHAlignRight, Range("5"), False, 10)
            Else
                Write(OPENING, Range("6"), XlHAlign.xlHAlignRight, Range("6"), False, 10)
            End If
            SetBorder(RowIndex, Range("5"), Range("5"))
            SetBorder(RowIndex, Range("6"), Range("6"))


            Dim STARTROWNO As Integer = RowIndex + 1
            Dim DT As System.Data.DataTable = DV.Table


            For Each DTROW As DataRow In DT.Rows
                RowIndex += 1
                If DTROW("TYPE") = "SALE" Then
                    Write(DTROW("REGTYPE") & "; Due Dt: " & Format(Convert.ToDateTime(DTROW("DUEDATE")).Date, "dd/MM/yyyy") & "; Bales: " & Val(DTROW("TOTALBALES")) & "; Lot No: " & DTROW("LOTNO") & "; " & DTROW("STATION") & "; P.R.No: " & DTROW("PRNO") & "; NW: " & Val(DTROW("NETTWT")) & "; Rt:" & Format(((Val(DTROW("SUBTOTAL")) / 0.2812) / Val(DTROW("NETTWT"))) * 100, "0"), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                Else
                    Write(Convert.ToString(DTROW("REMARKS").ToString), Range("1"), XlHAlign.xlHAlignLeft, , False, 9)
                End If
                Write(DTROW("TYPE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 9)
                Write(DTROW("BILL NO"), Range("3"), XlHAlign.xlHAlignLeft, , False, 9)
                Write(Format(Convert.ToDateTime(DTROW("DATE")).Date, "dd/MM/yyyy"), Range("4"), XlHAlign.xlHAlignCenter, , False, 9)
                Write(Format(Val(DTROW("DEBIT")), "0.00"), Range("5"), XlHAlign.xlHAlignRight, , False, 9)
                Write(Format(Val(DTROW("CREDIT")), "0.00"), Range("6"), XlHAlign.xlHAlignRight, , False, 9)
            Next

            RowIndex += 1
            Write("TOTAL    : ", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("4"))
            FORMULA("=SUM(" & objColumn.Item("5").ToString & STARTROWNO & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , False, 9)
            SetBorder(RowIndex, Range("5"), Range("5"))
            FORMULA("=SUM(" & objColumn.Item("6").ToString & STARTROWNO & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , False, 9)
            SetBorder(RowIndex, Range("6"), Range("6"))

            RowIndex += 1
            Write("CLOSING BALANCE    : ", Range("1"), XlHAlign.xlHAlignRight, Range("4"), True, 9)
            SetBorder(RowIndex, Range("1"), Range("4"))
            If CLODRCR = "Dr" Then
                Write(CLOSING, Range("5"), XlHAlign.xlHAlignRight, Range("5"), False, 9)
                SetBorder(RowIndex, Range("5"), Range("5"))
            Else
                Write(CLOSING, Range("6"), XlHAlign.xlHAlignRight, Range("6"), False, 9)
                SetBorder(RowIndex, Range("6"), Range("6"))
            End If



            'SET FONT
            objSheet.Range(objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex).Font.Name = "Trebuchet MS"
            objSheet.Range(objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex).Font.Size = 9


            SetBorder(RowIndex, objColumn.Item("1").ToString & STARTROWNO, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & STARTROWNO, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & STARTROWNO, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & STARTROWNO, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & STARTROWNO, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & STARTROWNO, objColumn.Item("6").ToString & RowIndex)


            objSheet.Range(Range("5")).NumberFormat = "0.00"
            objSheet.Range(Range("6")).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("1").ToString & 1, objColumn.Item("6").ToString & RowIndex).Select()

            objBook.Application.ActiveWindow.Zoom = 100



            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 10
            '    .RightMargin = 10
            '    .BottomMargin = 10
            '    '.Zoom = False
            '    '.FitToPagesTall = 1
            '    .FitToPagesWide = 1
            '    .CenterHorizontally = True
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "BANKRECO"

    Public Function BANKRECO(ByVal NAME As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim OBJRECO As New ClsBankReco
            Dim OBJCMN As New ClsCommon
            Dim ALPARAVAL As New ArrayList
            Dim I As Integer = 0

            ALPARAVAL.Add(NAME)
            ALPARAVAL.Add(FROMDATE)
            ALPARAVAL.Add(TODATE)
            ALPARAVAL.Add(CMPID)
            ALPARAVAL.Add(LOCATIONID)
            ALPARAVAL.Add(YEARID)

            OBJRECO.alParaval = ALPARAVAL
            Dim DT As System.Data.DataTable = OBJRECO.GETDATA()
            Dim DTTOTAL As System.Data.DataTable = OBJRECO.GETTOTAL
            If DT.Rows.Count > 0 Then

                SetWorkSheet()
                For I = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For I = 1 To 26
                    SetColumnWidth(Range(I), 14)
                Next


                ' **************************** CMPHEADER *************************
                Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

                RowIndex = 2
                Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD1
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD2
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))




                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Select()
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Application.ActiveWindow.FreezePanes = True

                ' **************************** CMPHEADER *************************




                RowIndex += 2
                Write("Name : " & NAME, Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Run Date : " & Now.Date, Range("6"), XlHAlign.xlHAlignLeft, Range("8"), False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                RowIndex += 1
                Write("Bank Reconciliation Statement from " & FROMDATE & " to " & TODATE, Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                'HEADERS
                RowIndex += 2
                Write("Booking No", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Date", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
                Write("Chq No", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Reco Date", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Amount", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Balance", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



                RowIndex += 2
                Write("Bank Balance as per Ledger Book", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BOOKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BOOKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)


                'AS PER JEETU
                'GET ALL DEBIT AMOUNT RECOED
                'I = 0
                'RowIndex += 1
                'Write("Chques Deposited and Cleared :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                'RowIndex += 1
                'For Each DTROW As DataRow In DT.Rows
                '    If Val(DTROW("DR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                '        I += 1
                '        RowIndex += 1
                '        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                '        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("RECODATE"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("DR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                '    End If
                'Next

                'RowIndex += 1
                'Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                'FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                'SetBorder(RowIndex, Range("1"), Range("8"))



                'AS PER JEETU
                'GET ALL CREDIT AMOUNT
                'I = 0
                'RowIndex += 2
                'Write("Chques Issused and Presented :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                'RowIndex += 1
                'For Each DTROW As DataRow In DT.Rows
                '    If Val(DTROW("CR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                '        I += 1
                '        RowIndex += 1
                '        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                '        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                '        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("RECODATE"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                '        Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                '    End If
                'Next


                'RowIndex += 1
                'Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                'FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , False, 10)
                'SetBorder(RowIndex, Range("1"), Range("8"))




                'GET ALL DEBIT AMOUNT
                I = 0
                RowIndex += 1
                Write("Chques Deposited but not Cleared :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                RowIndex += 1
                For Each DTROW As DataRow In DT.Rows

                    If Val(DTROW("DR")) <> 0 And IsDBNull(DTROW("RECODATE")) = True Then
                        I += 1
                        RowIndex += 1
                        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DTROW("DR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    ElseIf Val(DTROW("DR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                        If Convert.ToDateTime(DTROW("RECODATE")).Date > TODATE.Date Then
                            I += 1
                            RowIndex += 1
                            Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                            Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                            Write(DTROW("DR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                        End If
                    End If
                Next


                RowIndex += 1
                Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))



                'GET ALL CREDIT AMOUNT
                I = 0
                RowIndex += 2
                Write("Chques Issused but not Presented :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                RowIndex += 1
                For Each DTROW As DataRow In DT.Rows
                    If Val(DTROW("CR")) <> 0 And IsDBNull(DTROW("RECODATE")) = True Then
                        I += 1
                        RowIndex += 1
                        Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                        Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                        Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                        Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    ElseIf Val(DTROW("CR")) <> 0 And IsDBNull(DTROW("RECODATE")) = False Then
                        If Convert.ToDateTime(DTROW("RECODATE")).Date > TODATE.Date Then
                            I += 1
                            RowIndex += 1
                            Write(DTROW("BILLINITIALS"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("BILLDATE"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                            Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                            Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                            Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                        End If
                    End If
                Next


                RowIndex += 1
                Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))


                RowIndex += 2
                Write("Balance as Per Bank Book :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BANKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BANKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)


                SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("4").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("7").ToString & 9, objColumn.Item("7").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("8").ToString & 9, objColumn.Item("8").ToString & RowIndex)



                objBook.Application.ActiveWindow.Zoom = 95

                'With objSheet.PageSetup
                '    .Orientation = XlPageOrientation.xlPortrait
                '    .TopMargin = 144
                '    .LeftMargin = 50.4
                '    .RightMargin = 0
                '    .BottomMargin = 0
                '    .Zoom = False
                '    .FitToPagesTall = 1
                '    .FitToPagesWide = 1
                'End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function BANKSTATEMENT(ByVal NAME As String, ByVal FROMDATE As Date, ByVal TODATE As Date, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            Dim OBJRECO As New ClsBankReco
            Dim OBJCMN As New ClsCommon
            Dim ALPARAVAL As New ArrayList
            Dim I As Integer = 0
            Dim BALANCE As Double = 0

            Dim DT As System.Data.DataTable = OBJCMN.search("DISTINCT RecoDate AS RECODATE, acc_initials AS BILLINITIALS, AGAINST AS NAME, ChqNo AS CHQNO, dr AS DR, cr AS CR", "", " BANKRECO", " AND BANKRECO.NAME = '" & NAME & "' AND ACC_CMPID = " & CMPID & " AND ACC_LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & " AND CAST(RECODATE AS DATE) >= '" & Format(FROMDATE, "MM/dd/yyyy") & "' AND CAST(RECODATE AS DATE) <= '" & Format(TODATE, "MM/dd/yyyy") & "'  ORDER BY RECODATE")


            ALPARAVAL.Add(NAME)
            ALPARAVAL.Add(FROMDATE)
            ALPARAVAL.Add(TODATE)
            ALPARAVAL.Add(CMPID)
            ALPARAVAL.Add(LOCATIONID)
            ALPARAVAL.Add(YEARID)

            OBJRECO.alParaval = ALPARAVAL
            Dim DTTOTAL As System.Data.DataTable = OBJRECO.GETTOTAL
            If DT.Rows.Count > 0 Then

                SetWorkSheet()
                For I = 1 To 26
                    SetColumn(I, Chr(64 + I))
                Next


                RowIndex = 1
                For I = 1 To 26
                    SetColumnWidth(Range(I), 14)
                Next


                ' **************************** CMPHEADER *************************
                Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

                RowIndex = 2
                Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD1
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))

                'ADD2
                RowIndex += 1
                Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))




                'FREEZE TOP 7 ROWS
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Select()
                objSheet.Range(objColumn.Item("1").ToString & 10, objColumn.Item("8").ToString & 10).Application.ActiveWindow.FreezePanes = True

                ' **************************** CMPHEADER *************************




                RowIndex += 2
                Write("Name : " & NAME, Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
                Write("Run Date : " & Now.Date, Range("6"), XlHAlign.xlHAlignLeft, Range("8"), False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                RowIndex += 1
                Write("Bank Statement from " & FROMDATE & " to " & TODATE, Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                SetBorder(RowIndex, Range("1"), Range("8"))


                'HEADERS
                RowIndex += 2
                Write("Date", Range("1"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Booking No", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Name", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
                Write("Chq No", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Debit", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Credit", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
                Write("Balance", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



                RowIndex += 2
                Write("Bank Balance as per Bank Pass Book", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BOOKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BOOKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                BALANCE = Val(DTTOTAL.Rows(0).Item("BOOKBAL"))


                'GET ALL DEBIT AMOUNT
                I = 0
                Dim RDATE As Date = Now.Date
                Dim FROW As Boolean = True
                Dim FROMNO As Integer = 0
                RowIndex += 1
                For Each DTROW As DataRow In DT.Rows
                    I += 1
                    RowIndex += 1
                    'GET REOCDATE ONLY ONCE
                    If RDATE <> DTROW("RECODATE") Then
                        If FROW = False Then
                            RowIndex += 1
                            Write(DTROW("RECODATE"), Range("5"), XlHAlign.xlHAlignRight, , True, 10)
                            FORMULA("=SUM(" & objColumn.Item("6").ToString & FROMNO & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 12)
                            FORMULA("=SUM(" & objColumn.Item("7").ToString & FROMNO & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 12)

                            'SET BALANCE
                            BALANCE = (BALANCE + Val(objSheet.Range(Range("7"), Range("7")).Text)) - Val(objSheet.Range(Range("6"), Range("6")).Text)

                            Write(Format(BALANCE, "0.00"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                            SetBorder(RowIndex, Range("1"), Range("8"))
                        End If

                        RowIndex += 2
                        Write(DTROW("RECODATE"), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
                        RDATE = DTROW("RECODATE")
                        'GET TOTAL OF THE PARTICULAR DATE IF NOT FIRST ROW

                        FROMNO = RowIndex
                    End If
                    Write(DTROW("BILLINITIALS"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                    Write(DTROW("NAME"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                    Write(DTROW("CHQNO"), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("DR"), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    Write(DTROW("CR"), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                    FROW = False
                Next


                RowIndex += 1
                Write("Total :", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - I & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 12)
                SetBorder(RowIndex, Range("1"), Range("8"))




                RowIndex += 2
                Write("Balance as Per Bank Book :", Range("1"), XlHAlign.xlHAlignLeft, Range("3"), True, 10)
                Write(Format(Val(DTTOTAL.Rows(0).Item("BANKBAL")), "0.00") & "  " & DTTOTAL.Rows(0).Item("BANKDRCR"), Range("8"), XlHAlign.xlHAlignRight, , True, 12)


                SetBorder(RowIndex, objColumn.Item("1").ToString & 9, objColumn.Item("1").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("2").ToString & 9, objColumn.Item("2").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("3").ToString & 9, objColumn.Item("4").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("5").ToString & 9, objColumn.Item("5").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("6").ToString & 9, objColumn.Item("6").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("7").ToString & 9, objColumn.Item("7").ToString & RowIndex)
                SetBorder(RowIndex, objColumn.Item("8").ToString & 9, objColumn.Item("8").ToString & RowIndex)



                objBook.Application.ActiveWindow.Zoom = 95

                'With objSheet.PageSetup
                '    .Orientation = XlPageOrientation.xlPortrait
                '    .TopMargin = 144
                '    .LeftMargin = 50.4
                '    .RightMargin = 0
                '    .BottomMargin = 0
                '    .Zoom = False
                '    .FitToPagesTall = 1
                '    .FitToPagesWide = 1
                'End With

                SaveAndClose()

            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

End Class
