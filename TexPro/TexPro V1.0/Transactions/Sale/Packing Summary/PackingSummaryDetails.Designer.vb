<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PackingSummaryDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PackingSummaryDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSUMNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINALMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLONGATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALBALES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSAMPLEMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFENTMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHORTPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREJECTPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHORTMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREJECTEDMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGOODCUTMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRACKMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLESSPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLESSMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCARTONCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCUTTINGCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFELT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.TOOLMAIL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLEXCEL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLGRIDDTLS = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.BlendPanel1.Size = New System.Drawing.Size(1184, 581)
        Me.BlendPanel1.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(479, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 14)
        Me.Label4.TabIndex = 811
        Me.Label4.Text = "Copies"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(373, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 14)
        Me.Label9.TabIndex = 809
        Me.Label9.Text = "To"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(520, 2)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 810
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(275, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 14)
        Me.Label10.TabIndex = 808
        Me.Label10.Text = "From"
        '
        'TXTTO
        '
        Me.TXTTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.Location = New System.Drawing.Point(394, 1)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(57, 22)
        Me.TXTTO.TabIndex = 807
        Me.TXTTO.TabStop = False
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTFROM
        '
        Me.TXTFROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.Location = New System.Drawing.Point(310, 1)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(57, 22)
        Me.TXTFROM.TabIndex = 806
        Me.TXTFROM.TabStop = False
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(600, 35)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(123, 14)
        Me.Label21.TabIndex = 441
        Me.Label21.Text = "Locked (Challan Raised)"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Location = New System.Drawing.Point(581, 34)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(18, 17)
        Me.Label22.TabIndex = 440
        Me.Label22.Text = "   "
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(22, 57)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1150, 475)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSUMNO, Me.GDATE, Me.GNAME, Me.GPCS, Me.GFINALMTRS, Me.GLONGATION, Me.GTOTALBALES, Me.GSAMPLEMTRS, Me.GFENTMTRS, Me.GSHORTPCS, Me.GREJECTPCS, Me.GSHORTMTRS, Me.GREJECTEDMTRS, Me.GGOODCUTMTRS, Me.GRACKMTRS, Me.GLESSPER, Me.GLESSMTRS, Me.GREMARKS, Me.GCARTONCHGS, Me.GCUTTINGCHGS, Me.GFELT})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridbill.OptionsSelection.MultiSelect = True
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GSUMNO
        '
        Me.GSUMNO.Caption = "Sum. No"
        Me.GSUMNO.FieldName = "TEMPPACKNO"
        Me.GSUMNO.Name = "GSUMNO"
        Me.GSUMNO.Visible = True
        Me.GSUMNO.VisibleIndex = 1
        Me.GSUMNO.Width = 50
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        Me.GDATE.Width = 70
        '
        'GNAME
        '
        Me.GNAME.Caption = " Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 200
        '
        'GFINALMTRS
        '
        Me.GFINALMTRS.Caption = "Final Mtrs"
        Me.GFINALMTRS.FieldName = "FINALMTR"
        Me.GFINALMTRS.Name = "GFINALMTRS"
        Me.GFINALMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GFINALMTRS.Visible = True
        Me.GFINALMTRS.VisibleIndex = 5
        '
        'GLONGATION
        '
        Me.GLONGATION.Caption = "Longation"
        Me.GLONGATION.FieldName = "LONGATION"
        Me.GLONGATION.Name = "GLONGATION"
        Me.GLONGATION.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GLONGATION.Visible = True
        Me.GLONGATION.VisibleIndex = 7
        '
        'GTOTALBALES
        '
        Me.GTOTALBALES.Caption = "Total Bales"
        Me.GTOTALBALES.FieldName = "TOTALBALES"
        Me.GTOTALBALES.Name = "GTOTALBALES"
        Me.GTOTALBALES.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALBALES.Visible = True
        Me.GTOTALBALES.VisibleIndex = 6
        '
        'GSAMPLEMTRS
        '
        Me.GSAMPLEMTRS.Caption = "Sample Mtrs"
        Me.GSAMPLEMTRS.FieldName = "SAMPLEMTRS"
        Me.GSAMPLEMTRS.Name = "GSAMPLEMTRS"
        Me.GSAMPLEMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSAMPLEMTRS.Visible = True
        Me.GSAMPLEMTRS.VisibleIndex = 8
        '
        'GFENTMTRS
        '
        Me.GFENTMTRS.Caption = "Fent Mtrs"
        Me.GFENTMTRS.FieldName = "FENTMTRS"
        Me.GFENTMTRS.Name = "GFENTMTRS"
        Me.GFENTMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GFENTMTRS.Visible = True
        Me.GFENTMTRS.VisibleIndex = 9
        '
        'GSHORTPCS
        '
        Me.GSHORTPCS.Caption = "Short Pcs "
        Me.GSHORTPCS.FieldName = "SHORTPCS"
        Me.GSHORTPCS.Name = "GSHORTPCS"
        Me.GSHORTPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSHORTPCS.Visible = True
        Me.GSHORTPCS.VisibleIndex = 10
        '
        'GREJECTPCS
        '
        Me.GREJECTPCS.Caption = "Rejected Pcs"
        Me.GREJECTPCS.FieldName = "REJPCS"
        Me.GREJECTPCS.Name = "GREJECTPCS"
        Me.GREJECTPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GREJECTPCS.Visible = True
        Me.GREJECTPCS.VisibleIndex = 11
        '
        'GSHORTMTRS
        '
        Me.GSHORTMTRS.Caption = "Short Mtrs"
        Me.GSHORTMTRS.FieldName = "SHORTMTRS"
        Me.GSHORTMTRS.Name = "GSHORTMTRS"
        Me.GSHORTMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSHORTMTRS.Visible = True
        Me.GSHORTMTRS.VisibleIndex = 12
        '
        'GREJECTEDMTRS
        '
        Me.GREJECTEDMTRS.Caption = "Rejected Mtrs"
        Me.GREJECTEDMTRS.FieldName = "REJMTRS"
        Me.GREJECTEDMTRS.Name = "GREJECTEDMTRS"
        Me.GREJECTEDMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GREJECTEDMTRS.Visible = True
        Me.GREJECTEDMTRS.VisibleIndex = 13
        '
        'GGOODCUTMTRS
        '
        Me.GGOODCUTMTRS.Caption = "Good Cut Mtrs"
        Me.GGOODCUTMTRS.FieldName = "GOODCUTMTRS"
        Me.GGOODCUTMTRS.Name = "GGOODCUTMTRS"
        Me.GGOODCUTMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGOODCUTMTRS.Visible = True
        Me.GGOODCUTMTRS.VisibleIndex = 14
        '
        'GRACKMTRS
        '
        Me.GRACKMTRS.Caption = "Rack Mtrs"
        Me.GRACKMTRS.FieldName = "RACKSMTRS"
        Me.GRACKMTRS.Name = "GRACKMTRS"
        Me.GRACKMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GRACKMTRS.Visible = True
        Me.GRACKMTRS.VisibleIndex = 15
        '
        'GLESSPER
        '
        Me.GLESSPER.Caption = "Less Per"
        Me.GLESSPER.FieldName = "LESSPER"
        Me.GLESSPER.Name = "GLESSPER"
        Me.GLESSPER.Visible = True
        Me.GLESSPER.VisibleIndex = 16
        '
        'GLESSMTRS
        '
        Me.GLESSMTRS.Caption = "Less Mtrs"
        Me.GLESSMTRS.FieldName = "LESSMTRS"
        Me.GLESSMTRS.Name = "GLESSMTRS"
        Me.GLESSMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GLESSMTRS.Visible = True
        Me.GLESSMTRS.VisibleIndex = 17
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remark"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 21
        Me.GREMARKS.Width = 182
        '
        'GCARTONCHGS
        '
        Me.GCARTONCHGS.Caption = "Carton Chgs"
        Me.GCARTONCHGS.FieldName = "CARTONCHGS"
        Me.GCARTONCHGS.Name = "GCARTONCHGS"
        Me.GCARTONCHGS.Visible = True
        Me.GCARTONCHGS.VisibleIndex = 18
        '
        'GCUTTINGCHGS
        '
        Me.GCUTTINGCHGS.Caption = "Cutting Chgs"
        Me.GCUTTINGCHGS.FieldName = "CUTTINGCHGS"
        Me.GCUTTINGCHGS.Name = "GCUTTINGCHGS"
        Me.GCUTTINGCHGS.Visible = True
        Me.GCUTTINGCHGS.VisibleIndex = 19
        '
        'GFELT
        '
        Me.GFELT.Caption = "Felt"
        Me.GFELT.FieldName = "FELT"
        Me.GFELT.Name = "GFELT"
        Me.GFELT.Visible = True
        Me.GFELT.VisibleIndex = 20
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(595, 545)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.PrintToolStripButton, Me.TOOLMAIL, Me.TOOLEXCEL, Me.TOOLREFRESH, Me.ToolStripSeparator1, Me.TOOLGRIDDTLS, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1184, 25)
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
        'TOOLGRIDDTLS
        '
        Me.TOOLGRIDDTLS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOOLGRIDDTLS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLGRIDDTLS.Name = "TOOLGRIDDTLS"
        Me.TOOLGRIDDTLS.Size = New System.Drawing.Size(72, 22)
        Me.TOOLGRIDDTLS.Text = "Grid Details"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(19, 34)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(119, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a gdn to Change"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(509, 545)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'GPCS
        '
        Me.GPCS.Caption = "Pcs"
        Me.GPCS.FieldName = "PCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPCS.Visible = True
        Me.GPCS.VisibleIndex = 4
        Me.GPCS.Width = 60
        '
        'PackingSummaryDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1184, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PackingSummaryDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Packing Summary Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As BlendPanel
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents GSUMNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents TOOLEXCEL As ToolStripButton
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents lbl As Label
    Friend WithEvents cmdok As Button
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINALMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLONGATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSAMPLEMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFENTMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHORTPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREJECTPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHORTMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREJECTEDMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGOODCUTMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRACKMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLESSPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLESSMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents TOOLMAIL As ToolStripButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents TXTTO As TextBox
    Friend WithEvents TXTFROM As TextBox
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents PRINTDOC As Drawing.Printing.PrintDocument
    Friend WithEvents TOOLGRIDDTLS As ToolStripButton
    Friend WithEvents GCARTONCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCUTTINGCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFELT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALBALES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
End Class
