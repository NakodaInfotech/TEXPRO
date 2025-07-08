<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PartyLotStatusReport
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKCHECK = New System.Windows.Forms.CheckBox()
        Me.CHKUNCHECKED = New System.Windows.Forms.CheckBox()
        Me.CMDPRINT = New System.Windows.Forms.Button()
        Me.CMDSHOWDETAILS = New System.Windows.Forms.Button()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.GRIDBALEDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBALE = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BBALENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BMERCHANT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRIDMFGDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDMFG = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.MLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MPROCESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRIDUNCHECKEDDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDUNCHECKED = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ULOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.USENDERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRIDCHECKEDDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDCHECKED = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSENDER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKMFGSTOCK = New System.Windows.Forms.CheckBox()
        Me.CHKBALESTOCK = New System.Windows.Forms.CheckBox()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDBALEDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBALE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDMFGDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDMFG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDUNCHECKEDDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDUNCHECKED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDCHECKEDDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDCHECKED, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKCHECK)
        Me.BlendPanel1.Controls.Add(Me.CHKUNCHECKED)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.CMDSHOWDETAILS)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.GRIDBALEDETAILS)
        Me.BlendPanel1.Controls.Add(Me.GRIDMFGDETAILS)
        Me.BlendPanel1.Controls.Add(Me.GRIDUNCHECKEDDETAILS)
        Me.BlendPanel1.Controls.Add(Me.GRIDCHECKEDDETAILS)
        Me.BlendPanel1.Controls.Add(Me.CHKMFGSTOCK)
        Me.BlendPanel1.Controls.Add(Me.CHKBALESTOCK)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1269, 581)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKCHECK
        '
        Me.CHKCHECK.AutoSize = True
        Me.CHKCHECK.BackColor = System.Drawing.Color.Transparent
        Me.CHKCHECK.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold)
        Me.CHKCHECK.ForeColor = System.Drawing.Color.Black
        Me.CHKCHECK.Location = New System.Drawing.Point(637, 11)
        Me.CHKCHECK.Name = "CHKCHECK"
        Me.CHKCHECK.Size = New System.Drawing.Size(142, 27)
        Me.CHKCHECK.TabIndex = 3
        Me.CHKCHECK.Text = "Checked Stock"
        Me.CHKCHECK.UseVisualStyleBackColor = False
        '
        'CHKUNCHECKED
        '
        Me.CHKUNCHECKED.AutoSize = True
        Me.CHKUNCHECKED.BackColor = System.Drawing.Color.Transparent
        Me.CHKUNCHECKED.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold)
        Me.CHKUNCHECKED.ForeColor = System.Drawing.Color.Black
        Me.CHKUNCHECKED.Location = New System.Drawing.Point(16, 11)
        Me.CHKUNCHECKED.Name = "CHKUNCHECKED"
        Me.CHKUNCHECKED.Size = New System.Drawing.Size(164, 27)
        Me.CHKUNCHECKED.TabIndex = 2
        Me.CHKUNCHECKED.Text = "UnChecked Stock"
        Me.CHKUNCHECKED.UseVisualStyleBackColor = False
        '
        'CMDPRINT
        '
        Me.CMDPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CMDPRINT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDPRINT.FlatAppearance.BorderSize = 0
        Me.CMDPRINT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINT.ForeColor = System.Drawing.Color.Black
        Me.CMDPRINT.Location = New System.Drawing.Point(477, 554)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(80, 28)
        Me.CMDPRINT.TabIndex = 6
        Me.CMDPRINT.Text = "&Print"
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'CMDSHOWDETAILS
        '
        Me.CMDSHOWDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.CMDSHOWDETAILS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSHOWDETAILS.FlatAppearance.BorderSize = 0
        Me.CMDSHOWDETAILS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSHOWDETAILS.ForeColor = System.Drawing.Color.Black
        Me.CMDSHOWDETAILS.Location = New System.Drawing.Point(545, 6)
        Me.CMDSHOWDETAILS.Name = "CMDSHOWDETAILS"
        Me.CMDSHOWDETAILS.Size = New System.Drawing.Size(87, 28)
        Me.CMDSHOWDETAILS.TabIndex = 1
        Me.CMDSHOWDETAILS.Text = "&Show Details"
        Me.CMDSHOWDETAILS.UseVisualStyleBackColor = False
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.BackColor = System.Drawing.Color.Transparent
        Me.CMDCLEAR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDCLEAR.FlatAppearance.BorderSize = 0
        Me.CMDCLEAR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.Black
        Me.CMDCLEAR.Location = New System.Drawing.Point(563, 554)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 7
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXIT.Location = New System.Drawing.Point(649, 554)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 8
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(184, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 15)
        Me.Label4.TabIndex = 503
        Me.Label4.Text = "Party Name"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(254, 9)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(285, 23)
        Me.cmbname.TabIndex = 0
        '
        'GRIDBALEDETAILS
        '
        Me.GRIDBALEDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBALEDETAILS.Location = New System.Drawing.Point(637, 309)
        Me.GRIDBALEDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDBALEDETAILS.MainView = Me.GRIDBALE
        Me.GRIDBALEDETAILS.Name = "GRIDBALEDETAILS"
        Me.GRIDBALEDETAILS.Size = New System.Drawing.Size(615, 239)
        Me.GRIDBALEDETAILS.TabIndex = 498
        Me.GRIDBALEDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBALE})
        '
        'GRIDBALE
        '
        Me.GRIDBALE.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBALE.Appearance.Row.Options.UseFont = True
        Me.GRIDBALE.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.BLOTNO, Me.BDATE, Me.BPCS, Me.BMTRS, Me.BBALENO, Me.BMERCHANT})
        Me.GRIDBALE.GridControl = Me.GRIDBALEDETAILS
        Me.GRIDBALE.Name = "GRIDBALE"
        Me.GRIDBALE.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDBALE.OptionsBehavior.Editable = False
        Me.GRIDBALE.OptionsView.ColumnAutoWidth = False
        Me.GRIDBALE.OptionsView.ShowAutoFilterRow = True
        Me.GRIDBALE.OptionsView.ShowFooter = True
        Me.GRIDBALE.OptionsView.ShowGroupPanel = False
        '
        'BLOTNO
        '
        Me.BLOTNO.Caption = "Lot No"
        Me.BLOTNO.FieldName = "LOTNO"
        Me.BLOTNO.Name = "BLOTNO"
        Me.BLOTNO.Visible = True
        Me.BLOTNO.VisibleIndex = 0
        Me.BLOTNO.Width = 60
        '
        'BDATE
        '
        Me.BDATE.Caption = "Date"
        Me.BDATE.FieldName = "DATE"
        Me.BDATE.Name = "BDATE"
        Me.BDATE.Visible = True
        Me.BDATE.VisibleIndex = 1
        '
        'BPCS
        '
        Me.BPCS.Caption = "Pcs"
        Me.BPCS.DisplayFormat.FormatString = "0"
        Me.BPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BPCS.FieldName = "PCS"
        Me.BPCS.Name = "BPCS"
        Me.BPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.BPCS.Visible = True
        Me.BPCS.VisibleIndex = 2
        Me.BPCS.Width = 60
        '
        'BMTRS
        '
        Me.BMTRS.Caption = "Mtrs"
        Me.BMTRS.DisplayFormat.FormatString = "0.00"
        Me.BMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BMTRS.FieldName = "MTRS"
        Me.BMTRS.Name = "BMTRS"
        Me.BMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.BMTRS.Visible = True
        Me.BMTRS.VisibleIndex = 3
        '
        'BBALENO
        '
        Me.BBALENO.Caption = "Bale No"
        Me.BBALENO.FieldName = "BALENO"
        Me.BBALENO.Name = "BBALENO"
        Me.BBALENO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.BBALENO.Visible = True
        Me.BBALENO.VisibleIndex = 4
        Me.BBALENO.Width = 100
        '
        'BMERCHANT
        '
        Me.BMERCHANT.Caption = "Merchant"
        Me.BMERCHANT.FieldName = "MERCHANT"
        Me.BMERCHANT.Name = "BMERCHANT"
        Me.BMERCHANT.Visible = True
        Me.BMERCHANT.VisibleIndex = 5
        Me.BMERCHANT.Width = 200
        '
        'GRIDMFGDETAILS
        '
        Me.GRIDMFGDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDMFGDETAILS.Location = New System.Drawing.Point(16, 309)
        Me.GRIDMFGDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDMFGDETAILS.MainView = Me.GRIDMFG
        Me.GRIDMFGDETAILS.Name = "GRIDMFGDETAILS"
        Me.GRIDMFGDETAILS.Size = New System.Drawing.Size(615, 239)
        Me.GRIDMFGDETAILS.TabIndex = 497
        Me.GRIDMFGDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDMFG})
        '
        'GRIDMFG
        '
        Me.GRIDMFG.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDMFG.Appearance.Row.Options.UseFont = True
        Me.GRIDMFG.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.MLOTNO, Me.MDATE, Me.MPCS, Me.MMTRS, Me.MQUALITY, Me.MPROCESS})
        Me.GRIDMFG.GridControl = Me.GRIDMFGDETAILS
        Me.GRIDMFG.Name = "GRIDMFG"
        Me.GRIDMFG.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDMFG.OptionsBehavior.Editable = False
        Me.GRIDMFG.OptionsView.ColumnAutoWidth = False
        Me.GRIDMFG.OptionsView.ShowAutoFilterRow = True
        Me.GRIDMFG.OptionsView.ShowFooter = True
        Me.GRIDMFG.OptionsView.ShowGroupPanel = False
        '
        'MLOTNO
        '
        Me.MLOTNO.AppearanceCell.BackColor = System.Drawing.Color.SkyBlue
        Me.MLOTNO.AppearanceCell.Options.UseBackColor = True
        Me.MLOTNO.Caption = "Lot No"
        Me.MLOTNO.FieldName = "LOTNO"
        Me.MLOTNO.Name = "MLOTNO"
        Me.MLOTNO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.MLOTNO.Visible = True
        Me.MLOTNO.VisibleIndex = 0
        Me.MLOTNO.Width = 60
        '
        'MDATE
        '
        Me.MDATE.AppearanceCell.BackColor = System.Drawing.Color.SkyBlue
        Me.MDATE.AppearanceCell.Options.UseBackColor = True
        Me.MDATE.Caption = "Date"
        Me.MDATE.FieldName = "DATE"
        Me.MDATE.Name = "MDATE"
        Me.MDATE.Visible = True
        Me.MDATE.VisibleIndex = 1
        '
        'MPCS
        '
        Me.MPCS.AppearanceCell.BackColor = System.Drawing.Color.SkyBlue
        Me.MPCS.AppearanceCell.Options.UseBackColor = True
        Me.MPCS.Caption = "Pcs"
        Me.MPCS.DisplayFormat.FormatString = "0"
        Me.MPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.MPCS.FieldName = "BALPCS"
        Me.MPCS.Name = "MPCS"
        Me.MPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.MPCS.Visible = True
        Me.MPCS.VisibleIndex = 2
        Me.MPCS.Width = 60
        '
        'MMTRS
        '
        Me.MMTRS.AppearanceCell.BackColor = System.Drawing.Color.SkyBlue
        Me.MMTRS.AppearanceCell.Options.UseBackColor = True
        Me.MMTRS.Caption = "Mtrs"
        Me.MMTRS.DisplayFormat.FormatString = "0.00"
        Me.MMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.MMTRS.FieldName = "MTRS"
        Me.MMTRS.Name = "MMTRS"
        Me.MMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.MMTRS.Visible = True
        Me.MMTRS.VisibleIndex = 3
        '
        'MQUALITY
        '
        Me.MQUALITY.AppearanceCell.BackColor = System.Drawing.Color.SkyBlue
        Me.MQUALITY.AppearanceCell.Options.UseBackColor = True
        Me.MQUALITY.Caption = "Quality"
        Me.MQUALITY.FieldName = "QUALITY"
        Me.MQUALITY.Name = "MQUALITY"
        Me.MQUALITY.Visible = True
        Me.MQUALITY.VisibleIndex = 4
        Me.MQUALITY.Width = 150
        '
        'MPROCESS
        '
        Me.MPROCESS.AppearanceCell.BackColor = System.Drawing.Color.SkyBlue
        Me.MPROCESS.AppearanceCell.Options.UseBackColor = True
        Me.MPROCESS.Caption = "Process"
        Me.MPROCESS.FieldName = "PROCESSNAME"
        Me.MPROCESS.Name = "MPROCESS"
        Me.MPROCESS.Visible = True
        Me.MPROCESS.VisibleIndex = 5
        Me.MPROCESS.Width = 140
        '
        'GRIDUNCHECKEDDETAILS
        '
        Me.GRIDUNCHECKEDDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDUNCHECKEDDETAILS.Location = New System.Drawing.Point(16, 41)
        Me.GRIDUNCHECKEDDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDUNCHECKEDDETAILS.MainView = Me.GRIDUNCHECKED
        Me.GRIDUNCHECKEDDETAILS.Name = "GRIDUNCHECKEDDETAILS"
        Me.GRIDUNCHECKEDDETAILS.Size = New System.Drawing.Size(615, 239)
        Me.GRIDUNCHECKEDDETAILS.TabIndex = 496
        Me.GRIDUNCHECKEDDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDUNCHECKED})
        '
        'GRIDUNCHECKED
        '
        Me.GRIDUNCHECKED.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDUNCHECKED.Appearance.Row.Options.UseFont = True
        Me.GRIDUNCHECKED.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ULOTNO, Me.UDATE, Me.UPCS, Me.UMTRS, Me.USENDERNAME, Me.UQUALITY})
        Me.GRIDUNCHECKED.GridControl = Me.GRIDUNCHECKEDDETAILS
        Me.GRIDUNCHECKED.Name = "GRIDUNCHECKED"
        Me.GRIDUNCHECKED.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDUNCHECKED.OptionsBehavior.Editable = False
        Me.GRIDUNCHECKED.OptionsView.ColumnAutoWidth = False
        Me.GRIDUNCHECKED.OptionsView.ShowAutoFilterRow = True
        Me.GRIDUNCHECKED.OptionsView.ShowFooter = True
        Me.GRIDUNCHECKED.OptionsView.ShowGroupPanel = False
        '
        'ULOTNO
        '
        Me.ULOTNO.AppearanceCell.BackColor = System.Drawing.Color.PaleGreen
        Me.ULOTNO.AppearanceCell.Options.UseBackColor = True
        Me.ULOTNO.Caption = "Lot No"
        Me.ULOTNO.FieldName = "LOTNO"
        Me.ULOTNO.Name = "ULOTNO"
        Me.ULOTNO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.ULOTNO.Visible = True
        Me.ULOTNO.VisibleIndex = 0
        Me.ULOTNO.Width = 60
        '
        'UDATE
        '
        Me.UDATE.AppearanceCell.BackColor = System.Drawing.Color.PaleGreen
        Me.UDATE.AppearanceCell.Options.UseBackColor = True
        Me.UDATE.Caption = "Date"
        Me.UDATE.FieldName = "DATE"
        Me.UDATE.Name = "UDATE"
        Me.UDATE.Visible = True
        Me.UDATE.VisibleIndex = 1
        '
        'UPCS
        '
        Me.UPCS.AppearanceCell.BackColor = System.Drawing.Color.PaleGreen
        Me.UPCS.AppearanceCell.Options.UseBackColor = True
        Me.UPCS.Caption = "Pcs"
        Me.UPCS.DisplayFormat.FormatString = "0"
        Me.UPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.UPCS.FieldName = "PCS"
        Me.UPCS.Name = "UPCS"
        Me.UPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.UPCS.Visible = True
        Me.UPCS.VisibleIndex = 2
        Me.UPCS.Width = 60
        '
        'UMTRS
        '
        Me.UMTRS.AppearanceCell.BackColor = System.Drawing.Color.PaleGreen
        Me.UMTRS.AppearanceCell.Options.UseBackColor = True
        Me.UMTRS.Caption = "Mtrs"
        Me.UMTRS.DisplayFormat.FormatString = "0.00"
        Me.UMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.UMTRS.FieldName = "MTRS"
        Me.UMTRS.Name = "UMTRS"
        Me.UMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.UMTRS.Visible = True
        Me.UMTRS.VisibleIndex = 3
        '
        'USENDERNAME
        '
        Me.USENDERNAME.AppearanceCell.BackColor = System.Drawing.Color.PaleGreen
        Me.USENDERNAME.AppearanceCell.Options.UseBackColor = True
        Me.USENDERNAME.Caption = "Sender Name"
        Me.USENDERNAME.FieldName = "SENDERNAME"
        Me.USENDERNAME.Name = "USENDERNAME"
        Me.USENDERNAME.Visible = True
        Me.USENDERNAME.VisibleIndex = 4
        Me.USENDERNAME.Width = 150
        '
        'UQUALITY
        '
        Me.UQUALITY.AppearanceCell.BackColor = System.Drawing.Color.PaleGreen
        Me.UQUALITY.AppearanceCell.Options.UseBackColor = True
        Me.UQUALITY.Caption = "Quality"
        Me.UQUALITY.FieldName = "QUALITY"
        Me.UQUALITY.Name = "UQUALITY"
        Me.UQUALITY.Visible = True
        Me.UQUALITY.VisibleIndex = 5
        Me.UQUALITY.Width = 150
        '
        'GRIDCHECKEDDETAILS
        '
        Me.GRIDCHECKEDDETAILS.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White
        Me.GRIDCHECKEDDETAILS.EmbeddedNavigator.Appearance.Options.UseBackColor = True
        Me.GRIDCHECKEDDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDCHECKEDDETAILS.Location = New System.Drawing.Point(637, 41)
        Me.GRIDCHECKEDDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDCHECKEDDETAILS.MainView = Me.GRIDCHECKED
        Me.GRIDCHECKEDDETAILS.Name = "GRIDCHECKEDDETAILS"
        Me.GRIDCHECKEDDETAILS.Size = New System.Drawing.Size(615, 239)
        Me.GRIDCHECKEDDETAILS.TabIndex = 495
        Me.GRIDCHECKEDDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDCHECKED})
        '
        'GRIDCHECKED
        '
        Me.GRIDCHECKED.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDCHECKED.Appearance.Row.Options.UseFont = True
        Me.GRIDCHECKED.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GLOTNO, Me.GDATE, Me.GPCS, Me.GMTRS, Me.GSENDER, Me.GQUALITY})
        Me.GRIDCHECKED.GridControl = Me.GRIDCHECKEDDETAILS
        Me.GRIDCHECKED.Name = "GRIDCHECKED"
        Me.GRIDCHECKED.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDCHECKED.OptionsBehavior.Editable = False
        Me.GRIDCHECKED.OptionsView.ColumnAutoWidth = False
        Me.GRIDCHECKED.OptionsView.ShowAutoFilterRow = True
        Me.GRIDCHECKED.OptionsView.ShowFooter = True
        Me.GRIDCHECKED.OptionsView.ShowGroupPanel = False
        '
        'GLOTNO
        '
        Me.GLOTNO.AppearanceCell.BackColor = System.Drawing.Color.PeachPuff
        Me.GLOTNO.AppearanceCell.Options.UseBackColor = True
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 0
        Me.GLOTNO.Width = 60
        '
        'GDATE
        '
        Me.GDATE.AppearanceCell.BackColor = System.Drawing.Color.PeachPuff
        Me.GDATE.AppearanceCell.Options.UseBackColor = True
        Me.GDATE.Caption = "Date"
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        '
        'GPCS
        '
        Me.GPCS.AppearanceCell.BackColor = System.Drawing.Color.PeachPuff
        Me.GPCS.AppearanceCell.Options.UseBackColor = True
        Me.GPCS.Caption = "Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "PCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPCS.Visible = True
        Me.GPCS.VisibleIndex = 2
        Me.GPCS.Width = 60
        '
        'GMTRS
        '
        Me.GMTRS.AppearanceCell.BackColor = System.Drawing.Color.PeachPuff
        Me.GMTRS.AppearanceCell.Options.UseBackColor = True
        Me.GMTRS.Caption = "Mtrs"
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 3
        '
        'GSENDER
        '
        Me.GSENDER.AppearanceCell.BackColor = System.Drawing.Color.PeachPuff
        Me.GSENDER.AppearanceCell.Options.UseBackColor = True
        Me.GSENDER.Caption = "Sender Name"
        Me.GSENDER.FieldName = "SENDERNAME"
        Me.GSENDER.Name = "GSENDER"
        Me.GSENDER.Visible = True
        Me.GSENDER.VisibleIndex = 4
        Me.GSENDER.Width = 150
        '
        'GQUALITY
        '
        Me.GQUALITY.AppearanceCell.BackColor = System.Drawing.Color.PeachPuff
        Me.GQUALITY.AppearanceCell.Options.UseBackColor = True
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 5
        Me.GQUALITY.Width = 150
        '
        'CHKMFGSTOCK
        '
        Me.CHKMFGSTOCK.AutoSize = True
        Me.CHKMFGSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKMFGSTOCK.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold)
        Me.CHKMFGSTOCK.ForeColor = System.Drawing.Color.Black
        Me.CHKMFGSTOCK.Location = New System.Drawing.Point(16, 283)
        Me.CHKMFGSTOCK.Name = "CHKMFGSTOCK"
        Me.CHKMFGSTOCK.Size = New System.Drawing.Size(108, 27)
        Me.CHKMFGSTOCK.TabIndex = 4
        Me.CHKMFGSTOCK.Text = "Mfg Stock"
        Me.CHKMFGSTOCK.UseVisualStyleBackColor = False
        '
        'CHKBALESTOCK
        '
        Me.CHKBALESTOCK.AutoSize = True
        Me.CHKBALESTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKBALESTOCK.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold)
        Me.CHKBALESTOCK.ForeColor = System.Drawing.Color.Black
        Me.CHKBALESTOCK.Location = New System.Drawing.Point(637, 283)
        Me.CHKBALESTOCK.Name = "CHKBALESTOCK"
        Me.CHKBALESTOCK.Size = New System.Drawing.Size(111, 27)
        Me.CHKBALESTOCK.TabIndex = 5
        Me.CHKBALESTOCK.Text = "Bale Stock"
        Me.CHKBALESTOCK.UseVisualStyleBackColor = False
        '
        'PartyLotStatusReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1269, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PartyLotStatusReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Party Lot Status Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDBALEDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBALE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDMFGDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDMFG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDUNCHECKEDDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDUNCHECKED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDCHECKEDDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDCHECKED, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As BlendPanel
    Private WithEvents GRIDCHECKEDDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDCHECKED As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSENDER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GRIDBALEDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDBALE As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BBALENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BMERCHANT As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GRIDMFGDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDMFG As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GRIDUNCHECKEDDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDUNCHECKED As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ULOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents USENDERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MPROCESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbname As ComboBox
    Friend WithEvents CMDSHOWDETAILS As Button
    Friend WithEvents CMDCLEAR As Button
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDPRINT As Button
    Friend WithEvents CHKUNCHECKED As CheckBox
    Friend WithEvents CHKCHECK As CheckBox
    Friend WithEvents CHKMFGSTOCK As CheckBox
    Friend WithEvents CHKBALESTOCK As CheckBox
End Class
