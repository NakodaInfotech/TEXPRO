<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesignIssueRegister
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
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.RBALL = New System.Windows.Forms.RadioButton()
        Me.RBRECD = New System.Windows.Forms.RadioButton()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RBBILLDATE = New System.Windows.Forms.RadioButton()
        Me.RBRECDATE = New System.Windows.Forms.RadioButton()
        Me.RBISSUEDATE = New System.Windows.Forms.RadioButton()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GISSUEDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSKETCHNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMACHINE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSMALL1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBIG = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTABLE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMERCHANT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBILLDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIMGPATH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IMAGEREPO = New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit()
        Me.GISSUENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSMALLRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMACRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTABLERATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PICREPO = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.RBPENDING = New System.Windows.Forms.RadioButton()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMAGEREPO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PICREPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.RBALL)
        Me.BlendPanel1.Controls.Add(Me.RBRECD)
        Me.BlendPanel1.Controls.Add(Me.cmdshow)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.RBPENDING)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1184, 562)
        Me.BlendPanel1.TabIndex = 2
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(509, 527)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 450
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'RBALL
        '
        Me.RBALL.AutoSize = True
        Me.RBALL.BackColor = System.Drawing.Color.Transparent
        Me.RBALL.Location = New System.Drawing.Point(158, 54)
        Me.RBALL.Name = "RBALL"
        Me.RBALL.Size = New System.Drawing.Size(40, 19)
        Me.RBALL.TabIndex = 449
        Me.RBALL.Text = "All"
        Me.RBALL.UseVisualStyleBackColor = False
        '
        'RBRECD
        '
        Me.RBRECD.AutoSize = True
        Me.RBRECD.BackColor = System.Drawing.Color.Transparent
        Me.RBRECD.Location = New System.Drawing.Point(101, 54)
        Me.RBRECD.Name = "RBRECD"
        Me.RBRECD.Size = New System.Drawing.Size(51, 19)
        Me.RBRECD.TabIndex = 448
        Me.RBRECD.Text = "Recd"
        Me.RBRECD.UseVisualStyleBackColor = False
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.Black
        Me.cmdshow.Location = New System.Drawing.Point(739, 48)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(93, 28)
        Me.cmdshow.TabIndex = 447
        Me.cmdshow.Text = "&Show Details"
        Me.cmdshow.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.RBBILLDATE)
        Me.GroupBox2.Controls.Add(Me.RBRECDATE)
        Me.GroupBox2.Controls.Add(Me.RBISSUEDATE)
        Me.GroupBox2.Controls.Add(Me.dtto)
        Me.GroupBox2.Controls.Add(Me.chkdate)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtfrom)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(223, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(510, 47)
        Me.GroupBox2.TabIndex = 446
        Me.GroupBox2.TabStop = False
        '
        'RBBILLDATE
        '
        Me.RBBILLDATE.AutoSize = True
        Me.RBBILLDATE.BackColor = System.Drawing.Color.Transparent
        Me.RBBILLDATE.Location = New System.Drawing.Point(424, 20)
        Me.RBBILLDATE.Name = "RBBILLDATE"
        Me.RBBILLDATE.Size = New System.Drawing.Size(77, 18)
        Me.RBBILLDATE.TabIndex = 452
        Me.RBBILLDATE.Text = "Bill Darte"
        Me.RBBILLDATE.UseVisualStyleBackColor = False
        '
        'RBRECDATE
        '
        Me.RBRECDATE.AutoSize = True
        Me.RBRECDATE.BackColor = System.Drawing.Color.Transparent
        Me.RBRECDATE.Location = New System.Drawing.Point(345, 20)
        Me.RBRECDATE.Name = "RBRECDATE"
        Me.RBRECDATE.Size = New System.Drawing.Size(73, 18)
        Me.RBRECDATE.TabIndex = 451
        Me.RBRECDATE.Text = "Rec Date"
        Me.RBRECDATE.UseVisualStyleBackColor = False
        '
        'RBISSUEDATE
        '
        Me.RBISSUEDATE.AutoSize = True
        Me.RBISSUEDATE.BackColor = System.Drawing.Color.Transparent
        Me.RBISSUEDATE.Checked = True
        Me.RBISSUEDATE.Location = New System.Drawing.Point(257, 20)
        Me.RBISSUEDATE.Name = "RBISSUEDATE"
        Me.RBISSUEDATE.Size = New System.Drawing.Size(84, 18)
        Me.RBISSUEDATE.TabIndex = 450
        Me.RBISSUEDATE.TabStop = True
        Me.RBISSUEDATE.Text = "Issue Date"
        Me.RBISSUEDATE.UseVisualStyleBackColor = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(167, 18)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 1
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(12, 0)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 445
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(139, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 14)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(50, 18)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtfrom.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(9, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "From :"
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(17, 84)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.IMAGEREPO, Me.PICREPO})
        Me.gridbilldetails.Size = New System.Drawing.Size(1150, 435)
        Me.gridbilldetails.TabIndex = 435
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GISSUEDATE, Me.GSKETCHNO, Me.GNAME, Me.GMACHINE, Me.GSMALL1, Me.GBIG, Me.GTABLE, Me.GMERCHANT, Me.GRECDATE, Me.GDESIGN, Me.GBILLNO, Me.GBILLDATE, Me.GREMARKS, Me.GIMGPATH, Me.GISSUENO, Me.GSMALLRATE, Me.GMACRATE, Me.GTABLERATE, Me.GAMOUNT, Me.GMTRS, Me.GCOST})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        '
        'GISSUEDATE
        '
        Me.GISSUEDATE.Caption = "Issue Date"
        Me.GISSUEDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GISSUEDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GISSUEDATE.FieldName = "ISSDATE"
        Me.GISSUEDATE.Name = "GISSUEDATE"
        Me.GISSUEDATE.Visible = True
        Me.GISSUEDATE.VisibleIndex = 0
        Me.GISSUEDATE.Width = 80
        '
        'GSKETCHNO
        '
        Me.GSKETCHNO.Caption = "Sketch No"
        Me.GSKETCHNO.FieldName = "SKETCHNO"
        Me.GSKETCHNO.Name = "GSKETCHNO"
        Me.GSKETCHNO.Visible = True
        Me.GSKETCHNO.VisibleIndex = 1
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 2
        Me.GNAME.Width = 200
        '
        'GMACHINE
        '
        Me.GMACHINE.Caption = "Machine"
        Me.GMACHINE.DisplayFormat.FormatString = "0"
        Me.GMACHINE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMACHINE.FieldName = "MACHINE"
        Me.GMACHINE.Name = "GMACHINE"
        Me.GMACHINE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GMACHINE.Visible = True
        Me.GMACHINE.VisibleIndex = 3
        Me.GMACHINE.Width = 50
        '
        'GSMALL1
        '
        Me.GSMALL1.Caption = "Small 1"
        Me.GSMALL1.DisplayFormat.FormatString = "0"
        Me.GSMALL1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSMALL1.FieldName = "SMALL1"
        Me.GSMALL1.Name = "GSMALL1"
        Me.GSMALL1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSMALL1.Visible = True
        Me.GSMALL1.VisibleIndex = 4
        Me.GSMALL1.Width = 50
        '
        'GBIG
        '
        Me.GBIG.Caption = "Big"
        Me.GBIG.DisplayFormat.FormatString = "0"
        Me.GBIG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBIG.FieldName = "BIG"
        Me.GBIG.Name = "GBIG"
        Me.GBIG.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GBIG.Visible = True
        Me.GBIG.VisibleIndex = 5
        Me.GBIG.Width = 50
        '
        'GTABLE
        '
        Me.GTABLE.Caption = "Table"
        Me.GTABLE.DisplayFormat.FormatString = "0"
        Me.GTABLE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTABLE.FieldName = "TABLE"
        Me.GTABLE.Name = "GTABLE"
        Me.GTABLE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTABLE.Visible = True
        Me.GTABLE.VisibleIndex = 6
        Me.GTABLE.Width = 50
        '
        'GMERCHANT
        '
        Me.GMERCHANT.Caption = "Merchant"
        Me.GMERCHANT.FieldName = "MERCHANT"
        Me.GMERCHANT.Name = "GMERCHANT"
        Me.GMERCHANT.Visible = True
        Me.GMERCHANT.VisibleIndex = 7
        Me.GMERCHANT.Width = 200
        '
        'GRECDATE
        '
        Me.GRECDATE.Caption = "Rec Date"
        Me.GRECDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GRECDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GRECDATE.FieldName = "RECDATE"
        Me.GRECDATE.Name = "GRECDATE"
        Me.GRECDATE.Visible = True
        Me.GRECDATE.VisibleIndex = 8
        Me.GRECDATE.Width = 80
        '
        'GDESIGN
        '
        Me.GDESIGN.Caption = "Design No"
        Me.GDESIGN.FieldName = "DESIGNNO"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.Visible = True
        Me.GDESIGN.VisibleIndex = 9
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "Bill No"
        Me.GBILLNO.FieldName = "BILLNO"
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.Visible = True
        Me.GBILLNO.VisibleIndex = 10
        '
        'GBILLDATE
        '
        Me.GBILLDATE.Caption = "Bill Date"
        Me.GBILLDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GBILLDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GBILLDATE.FieldName = "BILLDATE"
        Me.GBILLDATE.Name = "GBILLDATE"
        Me.GBILLDATE.Visible = True
        Me.GBILLDATE.VisibleIndex = 11
        Me.GBILLDATE.Width = 80
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 12
        Me.GREMARKS.Width = 200
        '
        'GIMGPATH
        '
        Me.GIMGPATH.Caption = "Image"
        Me.GIMGPATH.ColumnEdit = Me.IMAGEREPO
        Me.GIMGPATH.FieldName = "IMGPATH"
        Me.GIMGPATH.Name = "GIMGPATH"
        '
        'IMAGEREPO
        '
        Me.IMAGEREPO.AutoHeight = False
        Me.IMAGEREPO.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.IMAGEREPO.Name = "IMAGEREPO"
        '
        'GISSUENO
        '
        Me.GISSUENO.Caption = "Issue No"
        Me.GISSUENO.FieldName = "ISSUENO"
        Me.GISSUENO.Name = "GISSUENO"
        Me.GISSUENO.Visible = True
        Me.GISSUENO.VisibleIndex = 13
        '
        'GSMALLRATE
        '
        Me.GSMALLRATE.Caption = "Small Rate"
        Me.GSMALLRATE.DisplayFormat.FormatString = "0.00"
        Me.GSMALLRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSMALLRATE.FieldName = "SMALLRATE"
        Me.GSMALLRATE.Name = "GSMALLRATE"
        Me.GSMALLRATE.Visible = True
        Me.GSMALLRATE.VisibleIndex = 14
        '
        'GMACRATE
        '
        Me.GMACRATE.Caption = "Mac Rate"
        Me.GMACRATE.DisplayFormat.FormatString = "0.00"
        Me.GMACRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMACRATE.FieldName = "MACRATE"
        Me.GMACRATE.Name = "GMACRATE"
        Me.GMACRATE.Visible = True
        Me.GMACRATE.VisibleIndex = 15
        '
        'GTABLERATE
        '
        Me.GTABLERATE.Caption = "Table Rate"
        Me.GTABLERATE.DisplayFormat.FormatString = "0.00"
        Me.GTABLERATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTABLERATE.FieldName = "TABLERATE"
        Me.GTABLERATE.Name = "GTABLERATE"
        Me.GTABLERATE.Visible = True
        Me.GTABLERATE.VisibleIndex = 16
        '
        'GAMOUNT
        '
        Me.GAMOUNT.Caption = "Amount"
        Me.GAMOUNT.DisplayFormat.FormatString = "0.00"
        Me.GAMOUNT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMOUNT.FieldName = "AMOUNT"
        Me.GAMOUNT.Name = "GAMOUNT"
        Me.GAMOUNT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GAMOUNT.Visible = True
        Me.GAMOUNT.VisibleIndex = 17
        '
        'PICREPO
        '
        Me.PICREPO.Name = "PICREPO"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1184, 25)
        Me.ToolStrip1.TabIndex = 434
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(595, 527)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'RBPENDING
        '
        Me.RBPENDING.AutoSize = True
        Me.RBPENDING.BackColor = System.Drawing.Color.Transparent
        Me.RBPENDING.Checked = True
        Me.RBPENDING.Location = New System.Drawing.Point(26, 54)
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.Size = New System.Drawing.Size(69, 19)
        Me.RBPENDING.TabIndex = 0
        Me.RBPENDING.TabStop = True
        Me.RBPENDING.Text = "Pending"
        Me.RBPENDING.UseVisualStyleBackColor = False
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Mtrs"
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 18
        '
        'GCOST
        '
        Me.GCOST.Caption = "Cost"
        Me.GCOST.DisplayFormat.FormatString = "0.000"
        Me.GCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOST.FieldName = "COST"
        Me.GCOST.Name = "GCOST"
        Me.GCOST.Visible = True
        Me.GCOST.VisibleIndex = 19
        '
        'DesignIssueRegister
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1184, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DesignIssueRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Design Issue Register"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMAGEREPO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PICREPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RBPENDING As System.Windows.Forms.RadioButton
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents GISSUEDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSKETCHNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMACHINE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSMALL1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBIG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTABLE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMERCHANT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RBRECD As System.Windows.Forms.RadioButton
    Friend WithEvents RBALL As System.Windows.Forms.RadioButton
    Friend WithEvents RBBILLDATE As System.Windows.Forms.RadioButton
    Friend WithEvents RBRECDATE As System.Windows.Forms.RadioButton
    Friend WithEvents RBISSUEDATE As System.Windows.Forms.RadioButton
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents GIMGPATH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IMAGEREPO As DevExpress.XtraEditors.Repository.RepositoryItemImageEdit
    Friend WithEvents PICREPO As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents GISSUENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSMALLRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMACRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTABLERATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOST As DevExpress.XtraGrid.Columns.GridColumn
End Class
