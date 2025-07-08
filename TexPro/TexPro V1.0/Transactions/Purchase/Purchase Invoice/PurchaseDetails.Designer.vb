<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseDetails
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseDetails))
        Me.cmbregister = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolCopy = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gpartybillno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gpartybilldate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grefno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gchallandate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISCAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSPDISCAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTAXABLEAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGSTAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRANDTOTAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLCHECKED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISPUTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.GDEPARTMENT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbregister
        '
        Me.cmbregister.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbregister.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbregister.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbregister.FormattingEnabled = True
        Me.cmbregister.Items.AddRange(New Object() {""})
        Me.cmbregister.Location = New System.Drawing.Point(803, 0)
        Me.cmbregister.Name = "cmbregister"
        Me.cmbregister.Size = New System.Drawing.Size(255, 22)
        Me.cmbregister.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(752, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 14)
        Me.Label1.TabIndex = 313
        Me.Label1.Text = "Register"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton1.Text = "Add New"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.PrintToolStripButton, Me.toolCopy, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = Global.TexPro_V1.My.Resources.Resources.Excel_icon
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'toolCopy
        '
        Me.toolCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCopy.Image = CType(resources.GetObject("toolCopy.Image"), System.Drawing.Image)
        Me.toolCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCopy.Name = "toolCopy"
        Me.toolCopy.Size = New System.Drawing.Size(23, 22)
        Me.toolCopy.Text = "copy Invoice"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 28)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1206, 516)
        Me.gridbilldetails.TabIndex = 318
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.gname, Me.gpartybillno, Me.gpartybilldate, Me.grefno, Me.gchallandate, Me.GITEMNAME, Me.GQTY, Me.GRATE, Me.GAMT, Me.GDISCAMT, Me.GSPDISCAMT, Me.GOTHERAMT, Me.GTAXABLEAMT, Me.GCGSTAMT, Me.GSGSTAMT, Me.GIGSTAMT, Me.GGRIDTOTAL, Me.GGRANDTOTAL, Me.GGRNNO, Me.GBILLCHECKED, Me.GDISPUTE, Me.GDEPARTMENT})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Images = Me.imageList1
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "Sr. No"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.OptionsColumn.AllowEdit = False
        Me.gsrno.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 50
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "Date"
        Me.gdate.Name = "gdate"
        Me.gdate.OptionsColumn.AllowEdit = False
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 1
        Me.gdate.Width = 60
        '
        'gname
        '
        Me.gname.Caption = "Vendor Name"
        Me.gname.FieldName = "Party Name"
        Me.gname.ImageIndex = 0
        Me.gname.Name = "gname"
        Me.gname.OptionsColumn.AllowEdit = False
        Me.gname.Visible = True
        Me.gname.VisibleIndex = 2
        Me.gname.Width = 150
        '
        'gpartybillno
        '
        Me.gpartybillno.Caption = "Party Bill No"
        Me.gpartybillno.FieldName = "PartyBillNo"
        Me.gpartybillno.Name = "gpartybillno"
        Me.gpartybillno.OptionsColumn.AllowEdit = False
        Me.gpartybillno.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gpartybillno.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gpartybillno.Visible = True
        Me.gpartybillno.VisibleIndex = 3
        '
        'gpartybilldate
        '
        Me.gpartybilldate.Caption = "Party Bill Date"
        Me.gpartybilldate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gpartybilldate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gpartybilldate.FieldName = "PartyBillDate"
        Me.gpartybilldate.Name = "gpartybilldate"
        Me.gpartybilldate.OptionsColumn.AllowEdit = False
        Me.gpartybilldate.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.gpartybilldate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.gpartybilldate.Visible = True
        Me.gpartybilldate.VisibleIndex = 4
        '
        'grefno
        '
        Me.grefno.Caption = "Challan No."
        Me.grefno.FieldName = "Challan No."
        Me.grefno.Name = "grefno"
        Me.grefno.OptionsColumn.AllowEdit = False
        Me.grefno.Visible = True
        Me.grefno.VisibleIndex = 5
        '
        'gchallandate
        '
        Me.gchallandate.Caption = "Challan Date"
        Me.gchallandate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gchallandate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gchallandate.FieldName = "Challan Date"
        Me.gchallandate.Name = "gchallandate"
        Me.gchallandate.OptionsColumn.AllowEdit = False
        Me.gchallandate.Visible = True
        Me.gchallandate.VisibleIndex = 6
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 7
        Me.GITEMNAME.Width = 150
        '
        'GQTY
        '
        Me.GQTY.Caption = "Qty"
        Me.GQTY.FieldName = "QTY"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.OptionsColumn.AllowEdit = False
        Me.GQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GQTY.Visible = True
        Me.GQTY.VisibleIndex = 8
        Me.GQTY.Width = 50
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.OptionsColumn.AllowEdit = False
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 9
        Me.GRATE.Width = 50
        '
        'GAMT
        '
        Me.GAMT.Caption = "Amt"
        Me.GAMT.FieldName = "AMT"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.OptionsColumn.AllowEdit = False
        Me.GAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GAMT.Visible = True
        Me.GAMT.VisibleIndex = 10
        Me.GAMT.Width = 70
        '
        'GDISCAMT
        '
        Me.GDISCAMT.Caption = "Disc Amt"
        Me.GDISCAMT.DisplayFormat.FormatString = "0.00"
        Me.GDISCAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDISCAMT.FieldName = "DISCAMT"
        Me.GDISCAMT.Name = "GDISCAMT"
        Me.GDISCAMT.OptionsColumn.AllowEdit = False
        Me.GDISCAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDISCAMT.Visible = True
        Me.GDISCAMT.VisibleIndex = 11
        '
        'GSPDISCAMT
        '
        Me.GSPDISCAMT.Caption = "SP Disc Amt"
        Me.GSPDISCAMT.DisplayFormat.FormatString = "0.00"
        Me.GSPDISCAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSPDISCAMT.FieldName = "SPDISCAMT"
        Me.GSPDISCAMT.Name = "GSPDISCAMT"
        Me.GSPDISCAMT.OptionsColumn.AllowEdit = False
        Me.GSPDISCAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSPDISCAMT.Visible = True
        Me.GSPDISCAMT.VisibleIndex = 12
        '
        'GOTHERAMT
        '
        Me.GOTHERAMT.Caption = "Other Amt"
        Me.GOTHERAMT.DisplayFormat.FormatString = "0.00"
        Me.GOTHERAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOTHERAMT.FieldName = "OTHERAMT"
        Me.GOTHERAMT.Name = "GOTHERAMT"
        Me.GOTHERAMT.OptionsColumn.AllowEdit = False
        Me.GOTHERAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GOTHERAMT.Visible = True
        Me.GOTHERAMT.VisibleIndex = 13
        '
        'GTAXABLEAMT
        '
        Me.GTAXABLEAMT.Caption = "Taxable Amt"
        Me.GTAXABLEAMT.DisplayFormat.FormatString = "0.00"
        Me.GTAXABLEAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTAXABLEAMT.FieldName = "TAXABLEAMT"
        Me.GTAXABLEAMT.Name = "GTAXABLEAMT"
        Me.GTAXABLEAMT.OptionsColumn.AllowEdit = False
        Me.GTAXABLEAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTAXABLEAMT.Visible = True
        Me.GTAXABLEAMT.VisibleIndex = 14
        '
        'GCGSTAMT
        '
        Me.GCGSTAMT.Caption = "CGST Amt"
        Me.GCGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GCGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCGSTAMT.FieldName = "CGSTAMT"
        Me.GCGSTAMT.Name = "GCGSTAMT"
        Me.GCGSTAMT.OptionsColumn.AllowEdit = False
        Me.GCGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCGSTAMT.Visible = True
        Me.GCGSTAMT.VisibleIndex = 15
        '
        'GSGSTAMT
        '
        Me.GSGSTAMT.Caption = "SGST Amt"
        Me.GSGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GSGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSGSTAMT.FieldName = "SGSTAMT"
        Me.GSGSTAMT.Name = "GSGSTAMT"
        Me.GSGSTAMT.OptionsColumn.AllowEdit = False
        Me.GSGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSGSTAMT.Visible = True
        Me.GSGSTAMT.VisibleIndex = 16
        '
        'GIGSTAMT
        '
        Me.GIGSTAMT.Caption = "IGST Amt"
        Me.GIGSTAMT.DisplayFormat.FormatString = "0.00"
        Me.GIGSTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GIGSTAMT.FieldName = "IGSTAMT"
        Me.GIGSTAMT.Name = "GIGSTAMT"
        Me.GIGSTAMT.OptionsColumn.AllowEdit = False
        Me.GIGSTAMT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GIGSTAMT.Visible = True
        Me.GIGSTAMT.VisibleIndex = 17
        '
        'GGRIDTOTAL
        '
        Me.GGRIDTOTAL.Caption = "Grid Total"
        Me.GGRIDTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GGRIDTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGRIDTOTAL.FieldName = "GRIDTOTAL"
        Me.GGRIDTOTAL.Name = "GGRIDTOTAL"
        Me.GGRIDTOTAL.OptionsColumn.AllowEdit = False
        Me.GGRIDTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGRIDTOTAL.Visible = True
        Me.GGRIDTOTAL.VisibleIndex = 18
        '
        'GGRANDTOTAL
        '
        Me.GGRANDTOTAL.Caption = "Grand Total"
        Me.GGRANDTOTAL.FieldName = "GTOTAL"
        Me.GGRANDTOTAL.Name = "GGRANDTOTAL"
        Me.GGRANDTOTAL.OptionsColumn.AllowEdit = False
        Me.GGRANDTOTAL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGRANDTOTAL.Visible = True
        Me.GGRANDTOTAL.VisibleIndex = 19
        '
        'GGRNNO
        '
        Me.GGRNNO.Caption = "GRN No"
        Me.GGRNNO.FieldName = "GRNNO"
        Me.GGRNNO.Name = "GGRNNO"
        Me.GGRNNO.OptionsColumn.AllowEdit = False
        Me.GGRNNO.Visible = True
        Me.GGRNNO.VisibleIndex = 20
        Me.GGRNNO.Width = 50
        '
        'GBILLCHECKED
        '
        Me.GBILLCHECKED.Caption = "Checked"
        Me.GBILLCHECKED.FieldName = "CHECKED"
        Me.GBILLCHECKED.Name = "GBILLCHECKED"
        Me.GBILLCHECKED.Visible = True
        Me.GBILLCHECKED.VisibleIndex = 21
        '
        'GDISPUTE
        '
        Me.GDISPUTE.Caption = "Dispute"
        Me.GDISPUTE.FieldName = "DISPUTED"
        Me.GDISPUTE.Name = "GDISPUTE"
        Me.GDISPUTE.Visible = True
        Me.GDISPUTE.VisibleIndex = 22
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmbregister)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 4
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(620, 550)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 661
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(534, 550)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 660
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GDEPARTMENT
        '
        Me.GDEPARTMENT.Caption = "Department"
        Me.GDEPARTMENT.FieldName = "DEPARTMENT"
        Me.GDEPARTMENT.Name = "GDEPARTMENT"
        Me.GDEPARTMENT.Visible = True
        Me.GDEPARTMENT.VisibleIndex = 23
        Me.GDEPARTMENT.Width = 150
        '
        'PurchaseDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PurchaseDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Purchase Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbregister As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCopy As System.Windows.Forms.ToolStripButton
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gname As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents grefno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents gpartybillno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gpartybilldate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gchallandate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRANDTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GBILLCHECKED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISPUTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDISCAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSPDISCAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTAXABLEAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSTAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDEPARTMENT As DevExpress.XtraGrid.Columns.GridColumn
End Class
