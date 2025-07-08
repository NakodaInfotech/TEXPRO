<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ItemDetails
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.GRIDNAME = New DevExpress.XtraGrid.GridControl()
        Me.gridledger = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PBEXCEL = New System.Windows.Forms.PictureBox()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.cmdadd = New System.Windows.Forms.Button()
        Me.cmdedit = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Details = New System.Windows.Forms.TabPage()
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.TXTHSNCODE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GPRATE = New System.Windows.Forms.GroupBox()
        Me.GRIDRATE = New System.Windows.Forms.DataGridView()
        Me.gratetype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TXTOPSTOCK = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTOPVALUE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTDEPARTMENT = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.txtitemname = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtcategory = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtunit = New System.Windows.Forms.TextBox()
        Me.TXTQUALITY = New System.Windows.Forms.TextBox()
        Me.txtupper = New System.Windows.Forms.TextBox()
        Me.txtcode = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtlower = New System.Windows.Forms.TextBox()
        Me.LBLOURQUALITY = New System.Windows.Forms.Label()
        Me.txtreorder = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBEXCEL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.Details.SuspendLayout()
        Me.BlendPanel2.SuspendLayout()
        Me.GPRATE.SuspendLayout()
        CType(Me.GRIDRATE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GRIDNAME)
        Me.BlendPanel1.Controls.Add(Me.PBEXCEL)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.cmdadd)
        Me.BlendPanel1.Controls.Add(Me.cmdedit)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(984, 586)
        Me.BlendPanel1.TabIndex = 1
        '
        'GRIDNAME
        '
        Me.GRIDNAME.Location = New System.Drawing.Point(12, 33)
        Me.GRIDNAME.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDNAME.MainView = Me.gridledger
        Me.GRIDNAME.Name = "GRIDNAME"
        Me.GRIDNAME.Size = New System.Drawing.Size(501, 513)
        Me.GRIDNAME.TabIndex = 357
        Me.GRIDNAME.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridledger})
        '
        'gridledger
        '
        Me.gridledger.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridledger.Appearance.Row.Options.UseFont = True
        Me.gridledger.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GNAME})
        Me.gridledger.GridControl = Me.GRIDNAME
        Me.gridledger.Name = "gridledger"
        Me.gridledger.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridledger.OptionsBehavior.Editable = False
        Me.gridledger.OptionsCustomization.AllowColumnMoving = False
        Me.gridledger.OptionsCustomization.AllowGroup = False
        Me.gridledger.OptionsView.ColumnAutoWidth = False
        Me.gridledger.OptionsView.ShowAutoFilterRow = True
        Me.gridledger.OptionsView.ShowGroupPanel = False
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 0
        Me.GNAME.Width = 450
        '
        'PBEXCEL
        '
        Me.PBEXCEL.Image = Global.TexPro_V1.My.Resources.Resources.Excel_icon
        Me.PBEXCEL.Location = New System.Drawing.Point(717, 24)
        Me.PBEXCEL.Name = "PBEXCEL"
        Me.PBEXCEL.Size = New System.Drawing.Size(25, 25)
        Me.PBEXCEL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBEXCEL.TabIndex = 356
        Me.PBEXCEL.TabStop = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDREFRESH.Location = New System.Drawing.Point(748, 24)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(72, 25)
        Me.CMDREFRESH.TabIndex = 355
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.Color.Transparent
        Me.cmdadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdadd.FlatAppearance.BorderSize = 0
        Me.cmdadd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdadd.Location = New System.Drawing.Point(294, 552)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(72, 25)
        Me.cmdadd.TabIndex = 96
        Me.cmdadd.Text = "Add New"
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'cmdedit
        '
        Me.cmdedit.BackColor = System.Drawing.Color.Transparent
        Me.cmdedit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdedit.FlatAppearance.BorderSize = 0
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdedit.Location = New System.Drawing.Point(832, 24)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(72, 25)
        Me.cmdedit.TabIndex = 241
        Me.cmdedit.Text = "Edit"
        Me.cmdedit.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(372, 552)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 25)
        Me.cmdexit.TabIndex = 240
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Details)
        Me.TabControl1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(521, 32)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(451, 513)
        Me.TabControl1.TabIndex = 239
        '
        'Details
        '
        Me.Details.Controls.Add(Me.BlendPanel2)
        Me.Details.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Details.Location = New System.Drawing.Point(4, 23)
        Me.Details.Name = "Details"
        Me.Details.Padding = New System.Windows.Forms.Padding(3)
        Me.Details.Size = New System.Drawing.Size(443, 486)
        Me.Details.TabIndex = 0
        Me.Details.Text = "Item Details"
        Me.Details.UseVisualStyleBackColor = True
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.TXTHSNCODE)
        Me.BlendPanel2.Controls.Add(Me.Label5)
        Me.BlendPanel2.Controls.Add(Me.GPRATE)
        Me.BlendPanel2.Controls.Add(Me.TXTOPSTOCK)
        Me.BlendPanel2.Controls.Add(Me.Label1)
        Me.BlendPanel2.Controls.Add(Me.Label3)
        Me.BlendPanel2.Controls.Add(Me.TXTOPVALUE)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.TXTDEPARTMENT)
        Me.BlendPanel2.Controls.Add(Me.GroupBox5)
        Me.BlendPanel2.Controls.Add(Me.txtitemname)
        Me.BlendPanel2.Controls.Add(Me.Label29)
        Me.BlendPanel2.Controls.Add(Me.txtcategory)
        Me.BlendPanel2.Controls.Add(Me.Label31)
        Me.BlendPanel2.Controls.Add(Me.txtunit)
        Me.BlendPanel2.Controls.Add(Me.TXTQUALITY)
        Me.BlendPanel2.Controls.Add(Me.txtupper)
        Me.BlendPanel2.Controls.Add(Me.txtcode)
        Me.BlendPanel2.Controls.Add(Me.Label12)
        Me.BlendPanel2.Controls.Add(Me.Label40)
        Me.BlendPanel2.Controls.Add(Me.Label13)
        Me.BlendPanel2.Controls.Add(Me.Label43)
        Me.BlendPanel2.Controls.Add(Me.txtlower)
        Me.BlendPanel2.Controls.Add(Me.LBLOURQUALITY)
        Me.BlendPanel2.Controls.Add(Me.txtreorder)
        Me.BlendPanel2.Controls.Add(Me.Label4)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(3, 3)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(437, 480)
        Me.BlendPanel2.TabIndex = 0
        '
        'TXTHSNCODE
        '
        Me.TXTHSNCODE.BackColor = System.Drawing.Color.White
        Me.TXTHSNCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHSNCODE.ForeColor = System.Drawing.Color.DimGray
        Me.TXTHSNCODE.Location = New System.Drawing.Point(263, 146)
        Me.TXTHSNCODE.Name = "TXTHSNCODE"
        Me.TXTHSNCODE.ReadOnly = True
        Me.TXTHSNCODE.Size = New System.Drawing.Size(84, 22)
        Me.TXTHSNCODE.TabIndex = 267
        Me.TXTHSNCODE.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(202, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 14)
        Me.Label5.TabIndex = 266
        Me.Label5.Text = "HSN Code"
        '
        'GPRATE
        '
        Me.GPRATE.BackColor = System.Drawing.Color.Transparent
        Me.GPRATE.Controls.Add(Me.GRIDRATE)
        Me.GPRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPRATE.ForeColor = System.Drawing.Color.Black
        Me.GPRATE.Location = New System.Drawing.Point(8, 232)
        Me.GPRATE.Name = "GPRATE"
        Me.GPRATE.Size = New System.Drawing.Size(350, 135)
        Me.GPRATE.TabIndex = 265
        Me.GPRATE.TabStop = False
        Me.GPRATE.Text = "Rate Details"
        '
        'GRIDRATE
        '
        Me.GRIDRATE.AllowUserToAddRows = False
        Me.GRIDRATE.AllowUserToDeleteRows = False
        Me.GRIDRATE.AllowUserToResizeColumns = False
        Me.GRIDRATE.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDRATE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDRATE.BackgroundColor = System.Drawing.Color.White
        Me.GRIDRATE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDRATE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDRATE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDRATE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDRATE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gratetype, Me.grate})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDRATE.DefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDRATE.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDRATE.Location = New System.Drawing.Point(5, 16)
        Me.GRIDRATE.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDRATE.MultiSelect = False
        Me.GRIDRATE.Name = "GRIDRATE"
        Me.GRIDRATE.ReadOnly = True
        Me.GRIDRATE.RowHeadersVisible = False
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDRATE.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDRATE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDRATE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDRATE.Size = New System.Drawing.Size(337, 114)
        Me.GRIDRATE.TabIndex = 0
        '
        'gratetype
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.gratetype.DefaultCellStyle = DataGridViewCellStyle3
        Me.gratetype.HeaderText = "Rate Type"
        Me.gratetype.Name = "gratetype"
        Me.gratetype.ReadOnly = True
        Me.gratetype.Width = 200
        '
        'grate
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.grate.DefaultCellStyle = DataGridViewCellStyle4
        Me.grate.HeaderText = "Rate"
        Me.grate.Name = "grate"
        Me.grate.ReadOnly = True
        '
        'TXTOPSTOCK
        '
        Me.TXTOPSTOCK.BackColor = System.Drawing.Color.White
        Me.TXTOPSTOCK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOPSTOCK.ForeColor = System.Drawing.Color.DimGray
        Me.TXTOPSTOCK.Location = New System.Drawing.Point(263, 173)
        Me.TXTOPSTOCK.Name = "TXTOPSTOCK"
        Me.TXTOPSTOCK.ReadOnly = True
        Me.TXTOPSTOCK.Size = New System.Drawing.Size(84, 22)
        Me.TXTOPSTOCK.TabIndex = 261
        Me.TXTOPSTOCK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(209, 177)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 14)
        Me.Label1.TabIndex = 263
        Me.Label1.Text = "OP Stock"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(202, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 264
        Me.Label3.Text = "Pack Rate"
        '
        'TXTOPVALUE
        '
        Me.TXTOPVALUE.BackColor = System.Drawing.Color.White
        Me.TXTOPVALUE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOPVALUE.ForeColor = System.Drawing.Color.DimGray
        Me.TXTOPVALUE.Location = New System.Drawing.Point(263, 200)
        Me.TXTOPVALUE.Name = "TXTOPVALUE"
        Me.TXTOPVALUE.ReadOnly = True
        Me.TXTOPVALUE.Size = New System.Drawing.Size(84, 22)
        Me.TXTOPVALUE.TabIndex = 262
        Me.TXTOPVALUE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(23, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "Department"
        '
        'TXTDEPARTMENT
        '
        Me.TXTDEPARTMENT.BackColor = System.Drawing.Color.White
        Me.TXTDEPARTMENT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDEPARTMENT.ForeColor = System.Drawing.Color.DimGray
        Me.TXTDEPARTMENT.Location = New System.Drawing.Point(97, 65)
        Me.TXTDEPARTMENT.Name = "TXTDEPARTMENT"
        Me.TXTDEPARTMENT.ReadOnly = True
        Me.TXTDEPARTMENT.Size = New System.Drawing.Size(250, 22)
        Me.TXTDEPARTMENT.TabIndex = 250
        Me.TXTDEPARTMENT.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(8, 368)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(350, 104)
        Me.GroupBox5.TabIndex = 248
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.BackColor = System.Drawing.Color.White
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(5, 16)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.ReadOnly = True
        Me.txtremarks.Size = New System.Drawing.Size(337, 83)
        Me.txtremarks.TabIndex = 3
        '
        'txtitemname
        '
        Me.txtitemname.BackColor = System.Drawing.Color.White
        Me.txtitemname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtitemname.ForeColor = System.Drawing.Color.DimGray
        Me.txtitemname.Location = New System.Drawing.Point(97, 92)
        Me.txtitemname.Name = "txtitemname"
        Me.txtitemname.ReadOnly = True
        Me.txtitemname.Size = New System.Drawing.Size(250, 22)
        Me.txtitemname.TabIndex = 218
        Me.txtitemname.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(42, 42)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 14)
        Me.Label29.TabIndex = 216
        Me.Label29.Text = "Category"
        '
        'txtcategory
        '
        Me.txtcategory.BackColor = System.Drawing.Color.White
        Me.txtcategory.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcategory.ForeColor = System.Drawing.Color.DimGray
        Me.txtcategory.Location = New System.Drawing.Point(97, 38)
        Me.txtcategory.Name = "txtcategory"
        Me.txtcategory.ReadOnly = True
        Me.txtcategory.Size = New System.Drawing.Size(250, 22)
        Me.txtcategory.TabIndex = 219
        Me.txtcategory.TabStop = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(56, 96)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(39, 14)
        Me.Label31.TabIndex = 217
        Me.Label31.Text = "Name"
        '
        'txtunit
        '
        Me.txtunit.BackColor = System.Drawing.Color.White
        Me.txtunit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtunit.ForeColor = System.Drawing.Color.DimGray
        Me.txtunit.Location = New System.Drawing.Point(263, 119)
        Me.txtunit.Name = "txtunit"
        Me.txtunit.ReadOnly = True
        Me.txtunit.Size = New System.Drawing.Size(84, 22)
        Me.txtunit.TabIndex = 243
        Me.txtunit.TabStop = False
        '
        'TXTQUALITY
        '
        Me.TXTQUALITY.BackColor = System.Drawing.Color.White
        Me.TXTQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQUALITY.ForeColor = System.Drawing.Color.DimGray
        Me.TXTQUALITY.Location = New System.Drawing.Point(97, 11)
        Me.TXTQUALITY.Name = "TXTQUALITY"
        Me.TXTQUALITY.ReadOnly = True
        Me.TXTQUALITY.Size = New System.Drawing.Size(250, 22)
        Me.TXTQUALITY.TabIndex = 241
        Me.TXTQUALITY.TabStop = False
        '
        'txtupper
        '
        Me.txtupper.BackColor = System.Drawing.Color.White
        Me.txtupper.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtupper.ForeColor = System.Drawing.Color.DimGray
        Me.txtupper.Location = New System.Drawing.Point(97, 173)
        Me.txtupper.Name = "txtupper"
        Me.txtupper.ReadOnly = True
        Me.txtupper.Size = New System.Drawing.Size(84, 22)
        Me.txtupper.TabIndex = 249
        Me.txtupper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcode
        '
        Me.txtcode.BackColor = System.Drawing.Color.White
        Me.txtcode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcode.ForeColor = System.Drawing.Color.DimGray
        Me.txtcode.Location = New System.Drawing.Point(97, 119)
        Me.txtcode.Name = "txtcode"
        Me.txtcode.ReadOnly = True
        Me.txtcode.Size = New System.Drawing.Size(84, 22)
        Me.txtcode.TabIndex = 240
        Me.txtcode.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(25, 177)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 14)
        Me.Label12.TabIndex = 257
        Me.Label12.Text = "Upper Limit"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.Black
        Me.Label40.Location = New System.Drawing.Point(228, 123)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(33, 14)
        Me.Label40.TabIndex = 239
        Me.Label40.Text = "UOM"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(26, 204)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 14)
        Me.Label13.TabIndex = 258
        Me.Label13.Text = "Lower Limit"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(61, 123)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(34, 14)
        Me.Label43.TabIndex = 236
        Me.Label43.Text = "Code"
        '
        'txtlower
        '
        Me.txtlower.BackColor = System.Drawing.Color.White
        Me.txtlower.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlower.ForeColor = System.Drawing.Color.DimGray
        Me.txtlower.Location = New System.Drawing.Point(97, 200)
        Me.txtlower.Name = "txtlower"
        Me.txtlower.ReadOnly = True
        Me.txtlower.Size = New System.Drawing.Size(84, 22)
        Me.txtlower.TabIndex = 250
        Me.txtlower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLOURQUALITY
        '
        Me.LBLOURQUALITY.AutoSize = True
        Me.LBLOURQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLOURQUALITY.ForeColor = System.Drawing.Color.Black
        Me.LBLOURQUALITY.Location = New System.Drawing.Point(27, 15)
        Me.LBLOURQUALITY.Name = "LBLOURQUALITY"
        Me.LBLOURQUALITY.Size = New System.Drawing.Size(68, 14)
        Me.LBLOURQUALITY.TabIndex = 237
        Me.LBLOURQUALITY.Text = "Our Quality"
        '
        'txtreorder
        '
        Me.txtreorder.BackColor = System.Drawing.Color.White
        Me.txtreorder.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtreorder.ForeColor = System.Drawing.Color.DimGray
        Me.txtreorder.Location = New System.Drawing.Point(97, 146)
        Me.txtreorder.Name = "txtreorder"
        Me.txtreorder.ReadOnly = True
        Me.txtreorder.Size = New System.Drawing.Size(84, 22)
        Me.txtreorder.TabIndex = 255
        Me.txtreorder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(9, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 14)
        Me.Label4.TabIndex = 260
        Me.Label4.Text = "Re-Order Level"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Black
        Me.lbl.Location = New System.Drawing.Point(25, 12)
        Me.lbl.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(158, 14)
        Me.lbl.TabIndex = 232
        Me.lbl.Text = "Double Click on Item to Edit"
        '
        'ItemDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(984, 586)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ItemDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Item Details"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDNAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBEXCEL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.Details.ResumeLayout(False)
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GPRATE.ResumeLayout(False)
        CType(Me.GRIDRATE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Details As System.Windows.Forms.TabPage
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents txtitemname As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtcategory As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtunit As System.Windows.Forms.TextBox
    Friend WithEvents TXTQUALITY As System.Windows.Forms.TextBox
    Friend WithEvents txtcode As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents LBLOURQUALITY As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtupper As System.Windows.Forms.TextBox
    Friend WithEvents txtreorder As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtlower As System.Windows.Forms.TextBox
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTDEPARTMENT As System.Windows.Forms.TextBox
    Friend WithEvents TXTOPSTOCK As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTOPVALUE As System.Windows.Forms.TextBox
    Friend WithEvents GPRATE As System.Windows.Forms.GroupBox
    Friend WithEvents GRIDRATE As System.Windows.Forms.DataGridView
    Friend WithEvents gratetype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TXTHSNCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PBEXCEL As PictureBox
    Private WithEvents GRIDNAME As DevExpress.XtraGrid.GridControl
    Private WithEvents gridledger As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
End Class
