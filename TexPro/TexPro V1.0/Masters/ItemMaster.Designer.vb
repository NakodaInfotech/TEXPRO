<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemMaster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemMaster))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.GPRATE = New System.Windows.Forms.GroupBox()
        Me.cmbratetype = New System.Windows.Forms.ComboBox()
        Me.txtrate = New System.Windows.Forms.TextBox()
        Me.GRIDRATE = New System.Windows.Forms.DataGridView()
        Me.gratetype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gpitem = New System.Windows.Forms.GroupBox()
        Me.LBLOURQUALITY = New System.Windows.Forms.Label()
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox()
        Me.LBLNAME = New System.Windows.Forms.Label()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CHKBLOCKED = New System.Windows.Forms.CheckBox()
        Me.TXTHSNCODE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.CMBDEPARTMENT = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTOPVALUE = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtlower = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTOPSTOCK = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtupper = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbunit = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbcategory = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblcategory = New System.Windows.Forms.Label()
        Me.txtreorder = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbmaterial = New System.Windows.Forms.ComboBox()
        Me.lblmaterial = New System.Windows.Forms.Label()
        Me.cmbitemname = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.lbl = New System.Windows.Forms.Label()
        Me.chkchange = New System.Windows.Forms.CheckBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CMBSUBCATEGORY = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CMBFOLD = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        Me.GPRATE.SuspendLayout()
        CType(Me.GRIDRATE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpitem.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.GPRATE)
        Me.BlendPanel1.Controls.Add(Me.gpitem)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(937, 488)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTADD
        '
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.Location = New System.Drawing.Point(288, 12)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(80, 22)
        Me.TXTADD.TabIndex = 437
        Me.TXTADD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTADD.Visible = False
        '
        'GPRATE
        '
        Me.GPRATE.BackColor = System.Drawing.Color.Transparent
        Me.GPRATE.Controls.Add(Me.cmbratetype)
        Me.GPRATE.Controls.Add(Me.txtrate)
        Me.GPRATE.Controls.Add(Me.GRIDRATE)
        Me.GPRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPRATE.ForeColor = System.Drawing.Color.Black
        Me.GPRATE.Location = New System.Drawing.Point(16, 272)
        Me.GPRATE.Name = "GPRATE"
        Me.GPRATE.Size = New System.Drawing.Size(350, 164)
        Me.GPRATE.TabIndex = 1
        Me.GPRATE.TabStop = False
        Me.GPRATE.Text = "Rate Details"
        '
        'cmbratetype
        '
        Me.cmbratetype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbratetype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbratetype.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbratetype.FormattingEnabled = True
        Me.cmbratetype.Location = New System.Drawing.Point(11, 21)
        Me.cmbratetype.MaxDropDownItems = 14
        Me.cmbratetype.Name = "cmbratetype"
        Me.cmbratetype.Size = New System.Drawing.Size(200, 22)
        Me.cmbratetype.TabIndex = 0
        '
        'txtrate
        '
        Me.txtrate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrate.Location = New System.Drawing.Point(211, 21)
        Me.txtrate.Name = "txtrate"
        Me.txtrate.Size = New System.Drawing.Size(100, 22)
        Me.txtrate.TabIndex = 1
        Me.txtrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.GRIDRATE.Location = New System.Drawing.Point(11, 43)
        Me.GRIDRATE.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDRATE.MultiSelect = False
        Me.GRIDRATE.Name = "GRIDRATE"
        Me.GRIDRATE.ReadOnly = True
        Me.GRIDRATE.RowHeadersVisible = False
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDRATE.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDRATE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDRATE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDRATE.Size = New System.Drawing.Size(328, 115)
        Me.GRIDRATE.TabIndex = 2
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
        'gpitem
        '
        Me.gpitem.BackColor = System.Drawing.Color.Transparent
        Me.gpitem.Controls.Add(Me.CMBFOLD)
        Me.gpitem.Controls.Add(Me.Label10)
        Me.gpitem.Controls.Add(Me.CMBSUBCATEGORY)
        Me.gpitem.Controls.Add(Me.Label9)
        Me.gpitem.Controls.Add(Me.LBLOURQUALITY)
        Me.gpitem.Controls.Add(Me.CMBQUALITY)
        Me.gpitem.Controls.Add(Me.LBLNAME)
        Me.gpitem.Controls.Add(Me.CMBNAME)
        Me.gpitem.Controls.Add(Me.Label1)
        Me.gpitem.Controls.Add(Me.CHKBLOCKED)
        Me.gpitem.Controls.Add(Me.TXTHSNCODE)
        Me.gpitem.Controls.Add(Me.Label2)
        Me.gpitem.Controls.Add(Me.CMBCODE)
        Me.gpitem.Controls.Add(Me.CMBDEPARTMENT)
        Me.gpitem.Controls.Add(Me.Label8)
        Me.gpitem.Controls.Add(Me.TXTOPVALUE)
        Me.gpitem.Controls.Add(Me.Label7)
        Me.gpitem.Controls.Add(Me.txtlower)
        Me.gpitem.Controls.Add(Me.Label6)
        Me.gpitem.Controls.Add(Me.TXTOPSTOCK)
        Me.gpitem.Controls.Add(Me.Label4)
        Me.gpitem.Controls.Add(Me.txtupper)
        Me.gpitem.Controls.Add(Me.Label5)
        Me.gpitem.Controls.Add(Me.cmbunit)
        Me.gpitem.Controls.Add(Me.Label15)
        Me.gpitem.Controls.Add(Me.cmbcategory)
        Me.gpitem.Controls.Add(Me.Label18)
        Me.gpitem.Controls.Add(Me.Label3)
        Me.gpitem.Controls.Add(Me.lblcategory)
        Me.gpitem.Controls.Add(Me.txtreorder)
        Me.gpitem.Controls.Add(Me.Label11)
        Me.gpitem.Controls.Add(Me.cmbmaterial)
        Me.gpitem.Controls.Add(Me.lblmaterial)
        Me.gpitem.Controls.Add(Me.cmbitemname)
        Me.gpitem.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpitem.ForeColor = System.Drawing.Color.Black
        Me.gpitem.Location = New System.Drawing.Point(19, 34)
        Me.gpitem.Name = "gpitem"
        Me.gpitem.Size = New System.Drawing.Size(872, 232)
        Me.gpitem.TabIndex = 0
        Me.gpitem.TabStop = False
        Me.gpitem.Text = "Item Details"
        '
        'LBLOURQUALITY
        '
        Me.LBLOURQUALITY.AutoSize = True
        Me.LBLOURQUALITY.BackColor = System.Drawing.Color.Transparent
        Me.LBLOURQUALITY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLOURQUALITY.ForeColor = System.Drawing.Color.Black
        Me.LBLOURQUALITY.Location = New System.Drawing.Point(23, 194)
        Me.LBLOURQUALITY.Name = "LBLOURQUALITY"
        Me.LBLOURQUALITY.Size = New System.Drawing.Size(71, 15)
        Me.LBLOURQUALITY.TabIndex = 662
        Me.LBLOURQUALITY.Text = "Self Quality"
        Me.LBLOURQUALITY.Visible = False
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.BackColor = System.Drawing.Color.White
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(98, 190)
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(318, 22)
        Me.CMBQUALITY.TabIndex = 7
        Me.CMBQUALITY.Visible = False
        '
        'LBLNAME
        '
        Me.LBLNAME.AutoSize = True
        Me.LBLNAME.BackColor = System.Drawing.Color.Transparent
        Me.LBLNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNAME.ForeColor = System.Drawing.Color.Black
        Me.LBLNAME.Location = New System.Drawing.Point(24, 165)
        Me.LBLNAME.Name = "LBLNAME"
        Me.LBLNAME.Size = New System.Drawing.Size(70, 15)
        Me.LBLNAME.TabIndex = 436
        Me.LBLNAME.Text = "Party Name"
        Me.LBLNAME.Visible = False
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.White
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(98, 161)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(193, 23)
        Me.CMBNAME.TabIndex = 6
        Me.CMBNAME.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(385, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 14)
        Me.Label1.TabIndex = 355
        Me.Label1.Text = "Press 'F1' To Select HSN/SAC"
        '
        'CHKBLOCKED
        '
        Me.CHKBLOCKED.AutoSize = True
        Me.CHKBLOCKED.BackColor = System.Drawing.Color.Transparent
        Me.CHKBLOCKED.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKBLOCKED.Location = New System.Drawing.Point(491, 136)
        Me.CHKBLOCKED.Name = "CHKBLOCKED"
        Me.CHKBLOCKED.Size = New System.Drawing.Size(69, 18)
        Me.CHKBLOCKED.TabIndex = 14
        Me.CHKBLOCKED.Text = "Blocked"
        Me.CHKBLOCKED.UseVisualStyleBackColor = False
        '
        'TXTHSNCODE
        '
        Me.TXTHSNCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTHSNCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHSNCODE.Location = New System.Drawing.Point(388, 133)
        Me.TXTHSNCODE.Name = "TXTHSNCODE"
        Me.TXTHSNCODE.ReadOnly = True
        Me.TXTHSNCODE.Size = New System.Drawing.Size(80, 22)
        Me.TXTHSNCODE.TabIndex = 13
        Me.TXTHSNCODE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(296, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 14)
        Me.Label2.TabIndex = 352
        Me.Label2.Text = "HSN / SAC Code"
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(98, 79)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(80, 22)
        Me.CMBCODE.TabIndex = 2
        '
        'CMBDEPARTMENT
        '
        Me.CMBDEPARTMENT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDEPARTMENT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDEPARTMENT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDEPARTMENT.FormattingEnabled = True
        Me.CMBDEPARTMENT.Location = New System.Drawing.Point(388, 52)
        Me.CMBDEPARTMENT.MaxDropDownItems = 14
        Me.CMBDEPARTMENT.Name = "CMBDEPARTMENT"
        Me.CMBDEPARTMENT.Size = New System.Drawing.Size(183, 22)
        Me.CMBDEPARTMENT.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(313, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 14)
        Me.Label8.TabIndex = 348
        Me.Label8.Text = "Department"
        '
        'TXTOPVALUE
        '
        Me.TXTOPVALUE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOPVALUE.Location = New System.Drawing.Point(491, 106)
        Me.TXTOPVALUE.Name = "TXTOPVALUE"
        Me.TXTOPVALUE.Size = New System.Drawing.Size(80, 22)
        Me.TXTOPVALUE.TabIndex = 12
        Me.TXTOPVALUE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(430, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 14)
        Me.Label7.TabIndex = 346
        Me.Label7.Text = "Pack Rate"
        '
        'txtlower
        '
        Me.txtlower.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlower.Location = New System.Drawing.Point(98, 133)
        Me.txtlower.Name = "txtlower"
        Me.txtlower.Size = New System.Drawing.Size(80, 22)
        Me.txtlower.TabIndex = 5
        Me.txtlower.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(25, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 14)
        Me.Label6.TabIndex = 322
        Me.Label6.Text = "Lower Limit"
        '
        'TXTOPSTOCK
        '
        Me.TXTOPSTOCK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOPSTOCK.Location = New System.Drawing.Point(388, 106)
        Me.TXTOPSTOCK.Name = "TXTOPSTOCK"
        Me.TXTOPSTOCK.Size = New System.Drawing.Size(38, 22)
        Me.TXTOPSTOCK.TabIndex = 11
        Me.TXTOPSTOCK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(332, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 14)
        Me.Label4.TabIndex = 344
        Me.Label4.Text = "Op Stock"
        '
        'txtupper
        '
        Me.txtupper.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtupper.Location = New System.Drawing.Point(98, 106)
        Me.txtupper.Name = "txtupper"
        Me.txtupper.Size = New System.Drawing.Size(80, 22)
        Me.txtupper.TabIndex = 4
        Me.txtupper.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 14)
        Me.Label5.TabIndex = 320
        Me.Label5.Text = "Upper Limit"
        '
        'cmbunit
        '
        Me.cmbunit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbunit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbunit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbunit.FormattingEnabled = True
        Me.cmbunit.Location = New System.Drawing.Point(216, 79)
        Me.cmbunit.MaxDropDownItems = 14
        Me.cmbunit.Name = "cmbunit"
        Me.cmbunit.Size = New System.Drawing.Size(75, 22)
        Me.cmbunit.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(181, 83)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 14)
        Me.Label15.TabIndex = 340
        Me.Label15.Text = "UOM"
        '
        'cmbcategory
        '
        Me.cmbcategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcategory.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcategory.FormattingEnabled = True
        Me.cmbcategory.Location = New System.Drawing.Point(388, 25)
        Me.cmbcategory.MaxDropDownItems = 14
        Me.cmbcategory.Name = "cmbcategory"
        Me.cmbcategory.Size = New System.Drawing.Size(183, 22)
        Me.cmbcategory.TabIndex = 8
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(29, 83)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 14)
        Me.Label18.TabIndex = 342
        Me.Label18.Text = "Short Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(55, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 14)
        Me.Label3.TabIndex = 308
        Me.Label3.Text = "Name"
        '
        'lblcategory
        '
        Me.lblcategory.AutoSize = True
        Me.lblcategory.BackColor = System.Drawing.Color.Transparent
        Me.lblcategory.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcategory.Location = New System.Drawing.Point(332, 29)
        Me.lblcategory.Name = "lblcategory"
        Me.lblcategory.Size = New System.Drawing.Size(53, 14)
        Me.lblcategory.TabIndex = 309
        Me.lblcategory.Text = "Category"
        '
        'txtreorder
        '
        Me.txtreorder.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtreorder.Location = New System.Drawing.Point(388, 79)
        Me.txtreorder.Name = "txtreorder"
        Me.txtreorder.Size = New System.Drawing.Size(80, 22)
        Me.txtreorder.TabIndex = 10
        Me.txtreorder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(299, 83)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 14)
        Me.Label11.TabIndex = 332
        Me.Label11.Text = "Re-Order Level"
        '
        'cmbmaterial
        '
        Me.cmbmaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbmaterial.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbmaterial.FormattingEnabled = True
        Me.cmbmaterial.Items.AddRange(New Object() {"Raw Material", "Semi Finished Goods", "Finished Goods", "Capital Goods", "Stores & Supplies - Production", "Pakaging Material", "Misc."})
        Me.cmbmaterial.Location = New System.Drawing.Point(98, 25)
        Me.cmbmaterial.MaxDropDownItems = 14
        Me.cmbmaterial.Name = "cmbmaterial"
        Me.cmbmaterial.Size = New System.Drawing.Size(193, 22)
        Me.cmbmaterial.TabIndex = 0
        '
        'lblmaterial
        '
        Me.lblmaterial.AutoSize = True
        Me.lblmaterial.BackColor = System.Drawing.Color.Transparent
        Me.lblmaterial.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmaterial.Location = New System.Drawing.Point(13, 29)
        Me.lblmaterial.Name = "lblmaterial"
        Me.lblmaterial.Size = New System.Drawing.Size(81, 14)
        Me.lblmaterial.TabIndex = 314
        Me.lblmaterial.Text = "Material Type"
        '
        'cmbitemname
        '
        Me.cmbitemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbitemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbitemname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbitemname.FormattingEnabled = True
        Me.cmbitemname.Location = New System.Drawing.Point(98, 52)
        Me.cmbitemname.MaxDropDownItems = 14
        Me.cmbitemname.Name = "cmbitemname"
        Me.cmbitemname.Size = New System.Drawing.Size(193, 22)
        Me.cmbitemname.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(372, 272)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(236, 164)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(6, 17)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(224, 141)
        Me.txtremarks.TabIndex = 0
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 7)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(96, 19)
        Me.lbl.TabIndex = 312
        Me.lbl.Text = "Item Master"
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(267, 15)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 311
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(271, 448)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 4
        Me.cmddelete.Text = "Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(185, 448)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(357, 448)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 5
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'CMBSUBCATEGORY
        '
        Me.CMBSUBCATEGORY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSUBCATEGORY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSUBCATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSUBCATEGORY.FormattingEnabled = True
        Me.CMBSUBCATEGORY.Location = New System.Drawing.Point(665, 25)
        Me.CMBSUBCATEGORY.MaxDropDownItems = 14
        Me.CMBSUBCATEGORY.Name = "CMBSUBCATEGORY"
        Me.CMBSUBCATEGORY.Size = New System.Drawing.Size(183, 22)
        Me.CMBSUBCATEGORY.TabIndex = 15
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(587, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 14)
        Me.Label9.TabIndex = 664
        Me.Label9.Text = "Sub Category"
        '
        'CMBFOLD
        '
        Me.CMBFOLD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBFOLD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBFOLD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBFOLD.FormattingEnabled = True
        Me.CMBFOLD.Location = New System.Drawing.Point(665, 52)
        Me.CMBFOLD.MaxDropDownItems = 14
        Me.CMBFOLD.Name = "CMBFOLD"
        Me.CMBFOLD.Size = New System.Drawing.Size(183, 22)
        Me.CMBFOLD.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(632, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 14)
        Me.Label10.TabIndex = 666
        Me.Label10.Text = "Fold"
        '
        'ItemMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(937, 488)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ItemMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Master"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GPRATE.ResumeLayout(False)
        Me.GPRATE.PerformLayout()
        CType(Me.GRIDRATE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpitem.ResumeLayout(False)
        Me.gpitem.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmbcategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblcategory As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents txtreorder As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtlower As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtupper As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbmaterial As System.Windows.Forms.ComboBox
    Friend WithEvents lblmaterial As System.Windows.Forms.Label
    Friend WithEvents cmbunit As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents GPRATE As System.Windows.Forms.GroupBox
    Friend WithEvents gpitem As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbitemname As System.Windows.Forms.ComboBox
    Friend WithEvents TXTOPVALUE As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTOPSTOCK As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMBDEPARTMENT As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GRIDRATE As System.Windows.Forms.DataGridView
    Friend WithEvents txtrate As System.Windows.Forms.TextBox
    Friend WithEvents cmbratetype As System.Windows.Forms.ComboBox
    Friend WithEvents CMBCODE As System.Windows.Forms.ComboBox
    Friend WithEvents gratetype As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TXTHSNCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CHKBLOCKED As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LBLNAME As Label
    Friend WithEvents CMBNAME As ComboBox
    Friend WithEvents TXTADD As TextBox
    Friend WithEvents LBLOURQUALITY As Label
    Friend WithEvents CMBQUALITY As ComboBox
    Friend WithEvents CMBFOLD As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents CMBSUBCATEGORY As ComboBox
    Friend WithEvents Label9 As Label
End Class
