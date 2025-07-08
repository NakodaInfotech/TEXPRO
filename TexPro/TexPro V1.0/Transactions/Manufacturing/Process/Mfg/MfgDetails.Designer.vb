<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MfgDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MfgDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFROMPROCESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOPROCESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPICK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDIFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALWTMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPROGNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHART = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDONE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMERCHANT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHIFT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDEGREE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCONTRACTOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLADJUSTMENT = New System.Windows.Forms.ToolStripButton()
        Me.TXTLOTNO = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLCONSUME = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.GMODIFIEDBY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Controls.Add(Me.Label22)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 568)
        Me.BlendPanel1.TabIndex = 5
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(732, 33)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(120, 14)
        Me.Label21.TabIndex = 441
        Me.Label21.Text = "Locked (MFG Raised)"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Location = New System.Drawing.Point(713, 32)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(18, 16)
        Me.Label22.TabIndex = 440
        Me.Label22.Text = "   "
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(12, 54)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1210, 471)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.GFROMPROCESS, Me.GTOPROCESS, Me.GITEMNAME, Me.GQUALITY, Me.GREED, Me.GPICK, Me.GTOTALPCS, Me.GMTRS, Me.GRECDMTRS, Me.GDIFF, Me.GWT, Me.GTOTALWTMTRS, Me.GLOTNO, Me.GPROGNO, Me.GCHART, Me.GCOLOR, Me.GDONE, Me.GMERCHANT, Me.GSHIFT, Me.GDEGREE, Me.GREMARKS, Me.GCONTRACTOR, Me.GMODIFIEDBY})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.HorzScrollStep = 1
        Me.gridbill.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsPrint.ExpandAllDetails = True
        Me.gridbill.OptionsPrint.PrintPreview = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        '
        'gsrno
        '
        Me.gsrno.Caption = "Mfg No"
        Me.gsrno.FieldName = "MFGNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 50
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 1
        Me.gdate.Width = 70
        '
        'GFROMPROCESS
        '
        Me.GFROMPROCESS.Caption = "From (Process)"
        Me.GFROMPROCESS.FieldName = "FROMPROCESS"
        Me.GFROMPROCESS.Name = "GFROMPROCESS"
        Me.GFROMPROCESS.Visible = True
        Me.GFROMPROCESS.VisibleIndex = 2
        Me.GFROMPROCESS.Width = 90
        '
        'GTOPROCESS
        '
        Me.GTOPROCESS.Caption = "To (Process)"
        Me.GTOPROCESS.FieldName = "TOPROCESS"
        Me.GTOPROCESS.Name = "GTOPROCESS"
        Me.GTOPROCESS.Visible = True
        Me.GTOPROCESS.VisibleIndex = 3
        Me.GTOPROCESS.Width = 90
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Width = 120
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 4
        Me.GQUALITY.Width = 120
        '
        'GREED
        '
        Me.GREED.Caption = "Reed"
        Me.GREED.FieldName = "REED"
        Me.GREED.Name = "GREED"
        Me.GREED.Width = 50
        '
        'GPICK
        '
        Me.GPICK.Caption = "Pick"
        Me.GPICK.FieldName = "PICK"
        Me.GPICK.Name = "GPICK"
        Me.GPICK.Width = 50
        '
        'GTOTALPCS
        '
        Me.GTOTALPCS.Caption = "Pcs"
        Me.GTOTALPCS.FieldName = "TOTALPCS"
        Me.GTOTALPCS.Name = "GTOTALPCS"
        Me.GTOTALPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALPCS.Visible = True
        Me.GTOTALPCS.VisibleIndex = 5
        Me.GTOTALPCS.Width = 49
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "In Mtrs"
        Me.GMTRS.FieldName = "TOTALMTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 6
        Me.GMTRS.Width = 49
        '
        'GRECDMTRS
        '
        Me.GRECDMTRS.Caption = "Out Mtrs"
        Me.GRECDMTRS.FieldName = "RECDMTRS"
        Me.GRECDMTRS.Name = "GRECDMTRS"
        Me.GRECDMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GRECDMTRS.Width = 54
        '
        'GDIFF
        '
        Me.GDIFF.Caption = "Diff"
        Me.GDIFF.FieldName = "DIFF"
        Me.GDIFF.Name = "GDIFF"
        Me.GDIFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDIFF.Visible = True
        Me.GDIFF.VisibleIndex = 7
        Me.GDIFF.Width = 49
        '
        'GWT
        '
        Me.GWT.Caption = "Wt."
        Me.GWT.FieldName = "WT"
        Me.GWT.Name = "GWT"
        Me.GWT.Visible = True
        Me.GWT.VisibleIndex = 8
        Me.GWT.Width = 49
        '
        'GTOTALWTMTRS
        '
        Me.GTOTALWTMTRS.Caption = "Total Wt"
        Me.GTOTALWTMTRS.DisplayFormat.FormatString = "0.000"
        Me.GTOTALWTMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALWTMTRS.FieldName = "TOTALWTMTRS"
        Me.GTOTALWTMTRS.Name = "GTOTALWTMTRS"
        Me.GTOTALWTMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALWTMTRS.Visible = True
        Me.GTOTALWTMTRS.VisibleIndex = 13
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 9
        '
        'GPROGNO
        '
        Me.GPROGNO.Caption = "Prog No"
        Me.GPROGNO.FieldName = "PRGNO"
        Me.GPROGNO.Name = "GPROGNO"
        Me.GPROGNO.Visible = True
        Me.GPROGNO.VisibleIndex = 10
        Me.GPROGNO.Width = 60
        '
        'GCHART
        '
        Me.GCHART.Caption = "Chart No"
        Me.GCHART.FieldName = "CHARTNO"
        Me.GCHART.Name = "GCHART"
        Me.GCHART.Visible = True
        Me.GCHART.VisibleIndex = 11
        Me.GCHART.Width = 65
        '
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Color"
        Me.GCOLOR.FieldName = "COLORNAME"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 12
        Me.GCOLOR.Width = 80
        '
        'GDONE
        '
        Me.GDONE.Caption = "Done"
        Me.GDONE.FieldName = "MFGDONE"
        Me.GDONE.Name = "GDONE"
        Me.GDONE.Visible = True
        Me.GDONE.VisibleIndex = 15
        Me.GDONE.Width = 40
        '
        'GMERCHANT
        '
        Me.GMERCHANT.Caption = "Merchant"
        Me.GMERCHANT.FieldName = "MERCHANT"
        Me.GMERCHANT.Name = "GMERCHANT"
        Me.GMERCHANT.Visible = True
        Me.GMERCHANT.VisibleIndex = 14
        Me.GMERCHANT.Width = 200
        '
        'GSHIFT
        '
        Me.GSHIFT.Caption = "Shift"
        Me.GSHIFT.FieldName = "SHIFT"
        Me.GSHIFT.Name = "GSHIFT"
        Me.GSHIFT.Visible = True
        Me.GSHIFT.VisibleIndex = 16
        '
        'GDEGREE
        '
        Me.GDEGREE.Caption = "Degree"
        Me.GDEGREE.FieldName = "DEGREE"
        Me.GDEGREE.Name = "GDEGREE"
        Me.GDEGREE.Visible = True
        Me.GDEGREE.VisibleIndex = 17
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 18
        Me.GREMARKS.Width = 200
        '
        'GCONTRACTOR
        '
        Me.GCONTRACTOR.Caption = "Contractor"
        Me.GCONTRACTOR.FieldName = "CONTRACTOR"
        Me.GCONTRACTOR.Name = "GCONTRACTOR"
        Me.GCONTRACTOR.Visible = True
        Me.GCONTRACTOR.VisibleIndex = 19
        Me.GCONTRACTOR.Width = 120
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(618, 528)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(75, 29)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ToolStripdelete, Me.PrintToolStripButton, Me.ToolStripButton2, Me.ToolStripSeparator1, Me.TOOLADJUSTMENT, Me.TXTLOTNO, Me.ToolStripSeparator2, Me.TOOLCONSUME, Me.ToolStripSeparator3})
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
        'ToolStripdelete
        '
        Me.ToolStripdelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripdelete.Image = CType(resources.GetObject("ToolStripdelete.Image"), System.Drawing.Image)
        Me.ToolStripdelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripdelete.Name = "ToolStripdelete"
        Me.ToolStripdelete.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripdelete.Text = "C&ut"
        Me.ToolStripdelete.Visible = False
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
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.TexPro_V1.My.Resources.Resources.refresh1
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLADJUSTMENT
        '
        Me.TOOLADJUSTMENT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLADJUSTMENT.Image = Global.TexPro_V1.My.Resources.Resources._assembly
        Me.TOOLADJUSTMENT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLADJUSTMENT.Name = "TOOLADJUSTMENT"
        Me.TOOLADJUSTMENT.Size = New System.Drawing.Size(23, 22)
        Me.TOOLADJUSTMENT.Text = "Lot Adjustment"
        Me.TOOLADJUSTMENT.Visible = False
        '
        'TXTLOTNO
        '
        Me.TXTLOTNO.Name = "TXTLOTNO"
        Me.TXTLOTNO.Size = New System.Drawing.Size(75, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLCONSUME
        '
        Me.TOOLCONSUME.Name = "TOOLCONSUME"
        Me.TOOLCONSUME.Size = New System.Drawing.Size(96, 22)
        Me.TOOLCONSUME.Text = "Consume Details"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(19, 34)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(130, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a Mfg to Change"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(541, 528)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(75, 29)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GMODIFIEDBY
        '
        Me.GMODIFIEDBY.Caption = "Modified By"
        Me.GMODIFIEDBY.FieldName = "MODIFIEDBY"
        Me.GMODIFIEDBY.Name = "GMODIFIEDBY"
        Me.GMODIFIEDBY.Visible = True
        Me.GMODIFIEDBY.VisibleIndex = 20
        Me.GMODIFIEDBY.Width = 100
        '
        'MfgDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 568)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MfgDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Manufacturing Details"
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
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents GFROMPROCESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOPROCESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPICK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRECDMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDIFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDONE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TOOLADJUSTMENT As System.Windows.Forms.ToolStripButton
    Friend WithEvents TXTLOTNO As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GPROGNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHART As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMERCHANT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHIFT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDEGREE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents TOOLCONSUME As ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents GCONTRACTOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALWTMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMODIFIEDBY As DevExpress.XtraGrid.Columns.GridColumn
End Class
