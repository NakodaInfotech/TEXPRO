<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GRNDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GRNDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.chkItem = New System.Windows.Forms.CheckBox()
        Me.chkParty = New System.Windows.Forms.CheckBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWEAVER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSENDERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBROKER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOURQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMERCHANT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAVGGRAMS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBALES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUNCHECKED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHECKMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHORTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grejected = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GACCEPTED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTRANSPORT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLABTEST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.TOOLMAIL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLEXCEL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.GPONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Controls.Add(Me.chkItem)
        Me.BlendPanel1.Controls.Add(Me.chkParty)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.cmbtype)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(371, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 14)
        Me.Label4.TabIndex = 805
        Me.Label4.Text = "Copies"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(265, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 14)
        Me.Label9.TabIndex = 803
        Me.Label9.Text = "To"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(412, 2)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 804
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(167, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 14)
        Me.Label10.TabIndex = 802
        Me.Label10.Text = "From"
        '
        'TXTTO
        '
        Me.TXTTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.Location = New System.Drawing.Point(286, 1)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(57, 22)
        Me.TXTTO.TabIndex = 801
        Me.TXTTO.TabStop = False
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTFROM
        '
        Me.TXTFROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.Location = New System.Drawing.Point(202, 1)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(57, 22)
        Me.TXTFROM.TabIndex = 800
        Me.TXTFROM.TabStop = False
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkItem
        '
        Me.chkItem.AutoSize = True
        Me.chkItem.BackColor = System.Drawing.Color.Transparent
        Me.chkItem.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkItem.ForeColor = System.Drawing.Color.Black
        Me.chkItem.Location = New System.Drawing.Point(653, 30)
        Me.chkItem.Name = "chkItem"
        Me.chkItem.Size = New System.Drawing.Size(82, 18)
        Me.chkItem.TabIndex = 653
        Me.chkItem.Text = "Item Wise"
        Me.chkItem.UseVisualStyleBackColor = False
        Me.chkItem.Visible = False
        '
        'chkParty
        '
        Me.chkParty.AutoSize = True
        Me.chkParty.BackColor = System.Drawing.Color.Transparent
        Me.chkParty.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkParty.ForeColor = System.Drawing.Color.Black
        Me.chkParty.Location = New System.Drawing.Point(751, 30)
        Me.chkParty.Name = "chkParty"
        Me.chkParty.Size = New System.Drawing.Size(83, 18)
        Me.chkParty.TabIndex = 652
        Me.chkParty.Text = "Party Wise"
        Me.chkParty.UseVisualStyleBackColor = False
        Me.chkParty.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(620, 541)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 651
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
        Me.cmdok.Location = New System.Drawing.Point(534, 541)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 650
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Enabled = False
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(835, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 14)
        Me.Label14.TabIndex = 649
        Me.Label14.Text = "Type"
        '
        'cmbtype
        '
        Me.cmbtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtype.BackColor = System.Drawing.Color.White
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.Enabled = False
        Me.cmbtype.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"G.R.N", "Inwards", "Job Work"})
        Me.cmbtype.Location = New System.Drawing.Point(872, 28)
        Me.cmbtype.MaxDropDownItems = 14
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(84, 22)
        Me.cmbtype.TabIndex = 648
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(17, 54)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1205, 481)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.GNAME, Me.GGODOWN, Me.GWEAVER, Me.GSENDERNAME, Me.GBROKER, Me.GITEMNAME, Me.GQUALITY, Me.GOURQUALITY, Me.GMERCHANT, Me.GAVGGRAMS, Me.GBALES, Me.GRATE, Me.GQTY, Me.GTOTALMTRS, Me.GPARTYMTRS, Me.GUNCHECKED, Me.GCHECKMTRS, Me.GSHORTAGE, Me.grejected, Me.GACCEPTED, Me.GTRANSPORT, Me.GLRNO, Me.GDESC, Me.GLABTEST, Me.GPONO})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Images = Me.imageList1
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridbill.OptionsSelection.MultiSelect = True
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "GRNNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 1
        Me.gsrno.Width = 41
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 2
        '
        'GNAME
        '
        Me.GNAME.Caption = "Supplier Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 210
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        '
        'GWEAVER
        '
        Me.GWEAVER.Caption = "Weaver"
        Me.GWEAVER.FieldName = "WEAVER"
        Me.GWEAVER.Name = "GWEAVER"
        Me.GWEAVER.Visible = True
        Me.GWEAVER.VisibleIndex = 5
        Me.GWEAVER.Width = 150
        '
        'GSENDERNAME
        '
        Me.GSENDERNAME.Caption = "Sender Name"
        Me.GSENDERNAME.FieldName = "SENDERNAME"
        Me.GSENDERNAME.Name = "GSENDERNAME"
        Me.GSENDERNAME.Visible = True
        Me.GSENDERNAME.VisibleIndex = 4
        Me.GSENDERNAME.Width = 200
        '
        'GBROKER
        '
        Me.GBROKER.Caption = "Broker"
        Me.GBROKER.FieldName = "BROKER"
        Me.GBROKER.Name = "GBROKER"
        Me.GBROKER.Visible = True
        Me.GBROKER.VisibleIndex = 6
        Me.GBROKER.Width = 150
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 7
        Me.GITEMNAME.Width = 200
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 8
        Me.GQUALITY.Width = 150
        '
        'GOURQUALITY
        '
        Me.GOURQUALITY.Caption = "Self Quality"
        Me.GOURQUALITY.FieldName = "OURQUALITY"
        Me.GOURQUALITY.Name = "GOURQUALITY"
        Me.GOURQUALITY.Width = 150
        '
        'GMERCHANT
        '
        Me.GMERCHANT.Caption = "Quality (Rate)"
        Me.GMERCHANT.FieldName = "MERCHANT"
        Me.GMERCHANT.Name = "GMERCHANT"
        Me.GMERCHANT.Visible = True
        Me.GMERCHANT.VisibleIndex = 9
        Me.GMERCHANT.Width = 150
        '
        'GAVGGRAMS
        '
        Me.GAVGGRAMS.Caption = "Gms"
        Me.GAVGGRAMS.DisplayFormat.FormatString = "0.000"
        Me.GAVGGRAMS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAVGGRAMS.FieldName = "AVGGRAMS"
        Me.GAVGGRAMS.Name = "GAVGGRAMS"
        Me.GAVGGRAMS.Visible = True
        Me.GAVGGRAMS.VisibleIndex = 10
        '
        'GBALES
        '
        Me.GBALES.Caption = "Bales"
        Me.GBALES.DisplayFormat.FormatString = "0"
        Me.GBALES.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALES.FieldName = "BALES"
        Me.GBALES.Name = "GBALES"
        Me.GBALES.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBALES.Visible = True
        Me.GBALES.VisibleIndex = 12
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 11
        '
        'GQTY
        '
        Me.GQTY.Caption = "Total Qty"
        Me.GQTY.DisplayFormat.FormatString = "0.00"
        Me.GQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GQTY.FieldName = "QTY"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GQTY.Visible = True
        Me.GQTY.VisibleIndex = 13
        Me.GQTY.Width = 80
        '
        'GTOTALMTRS
        '
        Me.GTOTALMTRS.AppearanceCell.BackColor = System.Drawing.Color.MistyRose
        Me.GTOTALMTRS.AppearanceCell.Options.UseBackColor = True
        Me.GTOTALMTRS.Caption = "Total Mtrs."
        Me.GTOTALMTRS.DisplayFormat.FormatString = "0.00"
        Me.GTOTALMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALMTRS.FieldName = "MTRS"
        Me.GTOTALMTRS.Name = "GTOTALMTRS"
        Me.GTOTALMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALMTRS.Visible = True
        Me.GTOTALMTRS.VisibleIndex = 14
        Me.GTOTALMTRS.Width = 80
        '
        'GPARTYMTRS
        '
        Me.GPARTYMTRS.AppearanceCell.BackColor = System.Drawing.Color.Coral
        Me.GPARTYMTRS.AppearanceCell.Options.UseBackColor = True
        Me.GPARTYMTRS.Caption = "Party Mtrs"
        Me.GPARTYMTRS.DisplayFormat.FormatString = "0.00"
        Me.GPARTYMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPARTYMTRS.FieldName = "PARTYMTRS"
        Me.GPARTYMTRS.Name = "GPARTYMTRS"
        Me.GPARTYMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPARTYMTRS.Visible = True
        Me.GPARTYMTRS.VisibleIndex = 15
        '
        'GUNCHECKED
        '
        Me.GUNCHECKED.AppearanceCell.BackColor = System.Drawing.Color.Khaki
        Me.GUNCHECKED.AppearanceCell.Options.UseBackColor = True
        Me.GUNCHECKED.Caption = "Un Checked"
        Me.GUNCHECKED.DisplayFormat.FormatString = "0.00"
        Me.GUNCHECKED.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GUNCHECKED.FieldName = "UNCHECKED"
        Me.GUNCHECKED.Name = "GUNCHECKED"
        Me.GUNCHECKED.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GUNCHECKED.Visible = True
        Me.GUNCHECKED.VisibleIndex = 16
        Me.GUNCHECKED.Width = 80
        '
        'GCHECKMTRS
        '
        Me.GCHECKMTRS.AppearanceCell.BackColor = System.Drawing.Color.Moccasin
        Me.GCHECKMTRS.AppearanceCell.Options.UseBackColor = True
        Me.GCHECKMTRS.Caption = "Check Mtrs"
        Me.GCHECKMTRS.DisplayFormat.FormatString = "0.00"
        Me.GCHECKMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCHECKMTRS.FieldName = "checkmtrs"
        Me.GCHECKMTRS.Name = "GCHECKMTRS"
        Me.GCHECKMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GCHECKMTRS.Visible = True
        Me.GCHECKMTRS.VisibleIndex = 17
        Me.GCHECKMTRS.Width = 80
        '
        'GSHORTAGE
        '
        Me.GSHORTAGE.AppearanceCell.BackColor = System.Drawing.Color.LightCyan
        Me.GSHORTAGE.AppearanceCell.Options.UseBackColor = True
        Me.GSHORTAGE.Caption = "Shortage"
        Me.GSHORTAGE.DisplayFormat.FormatString = "0.00"
        Me.GSHORTAGE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSHORTAGE.FieldName = "SHORTAGE"
        Me.GSHORTAGE.Name = "GSHORTAGE"
        Me.GSHORTAGE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSHORTAGE.Visible = True
        Me.GSHORTAGE.VisibleIndex = 18
        '
        'grejected
        '
        Me.grejected.AppearanceCell.BackColor = System.Drawing.Color.LightCoral
        Me.grejected.AppearanceCell.Options.UseBackColor = True
        Me.grejected.Caption = "Rej. Mtrs"
        Me.grejected.DisplayFormat.FormatString = "0.00"
        Me.grejected.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.grejected.FieldName = "rejmtrs"
        Me.grejected.Name = "grejected"
        Me.grejected.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.grejected.Visible = True
        Me.grejected.VisibleIndex = 19
        Me.grejected.Width = 80
        '
        'GACCEPTED
        '
        Me.GACCEPTED.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GACCEPTED.AppearanceCell.Options.UseBackColor = True
        Me.GACCEPTED.Caption = "Accepted Mtrs"
        Me.GACCEPTED.DisplayFormat.FormatString = "0.00"
        Me.GACCEPTED.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GACCEPTED.FieldName = "ACCEPTED"
        Me.GACCEPTED.Name = "GACCEPTED"
        Me.GACCEPTED.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GACCEPTED.Visible = True
        Me.GACCEPTED.VisibleIndex = 20
        '
        'GTRANSPORT
        '
        Me.GTRANSPORT.Caption = "Transport"
        Me.GTRANSPORT.FieldName = "TRANSPORT"
        Me.GTRANSPORT.Name = "GTRANSPORT"
        Me.GTRANSPORT.Width = 130
        '
        'GLRNO
        '
        Me.GLRNO.Caption = "Lr No."
        Me.GLRNO.FieldName = "LRNO"
        Me.GLRNO.Name = "GLRNO"
        Me.GLRNO.Width = 100
        '
        'GDESC
        '
        Me.GDESC.Caption = "Lab Report"
        Me.GDESC.FieldName = "GRIDREMARKS"
        Me.GDESC.Name = "GDESC"
        Me.GDESC.Visible = True
        Me.GDESC.VisibleIndex = 21
        Me.GDESC.Width = 150
        '
        'GLABTEST
        '
        Me.GLABTEST.Caption = "Lab Test"
        Me.GLABTEST.FieldName = "LABTEST"
        Me.GLABTEST.Name = "GLABTEST"
        Me.GLABTEST.Visible = True
        Me.GLABTEST.VisibleIndex = 22
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.PrintToolStripButton, Me.TOOLMAIL, Me.TOOLEXCEL, Me.TOOLREFRESH, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton1.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'TOOLMAIL
        '
        Me.TOOLMAIL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLMAIL.Image = Global.TexPro_V1.My.Resources.Resources.MAIL_IMAGE
        Me.TOOLMAIL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLMAIL.Name = "TOOLMAIL"
        Me.TOOLMAIL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLMAIL.Text = "Mail Invoice Directly"
        '
        'TOOLEXCEL
        '
        Me.TOOLEXCEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLEXCEL.Image = Global.TexPro_V1.My.Resources.Resources.Excel_icon
        Me.TOOLEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLEXCEL.Name = "TOOLEXCEL"
        Me.TOOLEXCEL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLEXCEL.Text = "&Print"
        '
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.TexPro_V1.My.Resources.Resources.refresh1
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "ToolStripButton2"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(19, 34)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(133, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a GRN to Change"
        '
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'GPONO
        '
        Me.GPONO.Caption = "PO No"
        Me.GPONO.FieldName = "PONO"
        Me.GPONO.Name = "GPONO"
        Me.GPONO.Visible = True
        Me.GPONO.VisibleIndex = 23
        '
        'GRNDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GRNDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "GRN Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TOOLEXCEL As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbl As System.Windows.Forms.Label
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents GTOTALMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHECKMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grejected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSPORT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents chkParty As System.Windows.Forms.CheckBox
    Friend WithEvents chkItem As System.Windows.Forms.CheckBox
    Friend WithEvents TOOLREFRESH As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GUNCHECKED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACCEPTED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHORTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAVGGRAMS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSENDERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBROKER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWEAVER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMERCHANT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TXTTO As TextBox
    Friend WithEvents TXTFROM As TextBox
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents PRINTDOC As Drawing.Printing.PrintDocument
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents TOOLMAIL As ToolStripButton
    Friend WithEvents GDESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLABTEST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOURQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPONO As DevExpress.XtraGrid.Columns.GridColumn
End Class
