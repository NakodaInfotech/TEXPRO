<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DyeingRecipe
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.LBLGM = New System.Windows.Forms.Label()
        Me.TXTGMS = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTITEMSTOCK = New System.Windows.Forms.TextBox()
        Me.TXTPHOTOIMGPATH = New System.Windows.Forms.TextBox()
        Me.PBCOPYCHART = New System.Windows.Forms.PictureBox()
        Me.cmbprocess = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CHKNOCALC = New System.Windows.Forms.CheckBox()
        Me.cmbunit = New System.Windows.Forms.ComboBox()
        Me.txtconsrno = New System.Windows.Forms.TextBox()
        Me.cmbitemname = New System.Windows.Forms.ComboBox()
        Me.txtrate = New System.Windows.Forms.TextBox()
        Me.TXTQTY = New System.Windows.Forms.TextBox()
        Me.gridconsume = New System.Windows.Forms.DataGridView()
        Me.gconsrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gitemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gunit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GNOCALC = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.gRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grecsrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbdyeingno = New System.Windows.Forms.ComboBox()
        Me.CMDVIEW = New System.Windows.Forms.Button()
        Me.cmdremove = New System.Windows.Forms.Button()
        Me.cmdupload = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PBPHOTO = New System.Windows.Forms.PictureBox()
        Me.GPRATE = New System.Windows.Forms.GroupBox()
        Me.txttotalcost = New System.Windows.Forms.TextBox()
        Me.pbcopy = New System.Windows.Forms.PictureBox()
        Me.txtsrno = New System.Windows.Forms.TextBox()
        Me.txtperpcs = New System.Windows.Forms.TextBox()
        Me.cmbmatching = New System.Windows.Forms.ComboBox()
        Me.GRIDRECIPE = New System.Windows.Forms.DataGridView()
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gMatching = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gPerPcs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gtotalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.chkchange = New System.Windows.Forms.CheckBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CHKBLOCKED = New System.Windows.Forms.CheckBox()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBCOPYCHART, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridconsume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBPHOTO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPRATE.SuspendLayout()
        CType(Me.pbcopy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDRECIPE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkRate = 0
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKBLOCKED)
        Me.BlendPanel1.Controls.Add(Me.LBLGM)
        Me.BlendPanel1.Controls.Add(Me.TXTGMS)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTITEMSTOCK)
        Me.BlendPanel1.Controls.Add(Me.TXTPHOTOIMGPATH)
        Me.BlendPanel1.Controls.Add(Me.PBCOPYCHART)
        Me.BlendPanel1.Controls.Add(Me.cmbprocess)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.cmbdyeingno)
        Me.BlendPanel1.Controls.Add(Me.CMDVIEW)
        Me.BlendPanel1.Controls.Add(Me.cmdremove)
        Me.BlendPanel1.Controls.Add(Me.cmdupload)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.PBPHOTO)
        Me.BlendPanel1.Controls.Add(Me.GPRATE)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(903, 540)
        Me.BlendPanel1.TabIndex = 0
        '
        'LBLGM
        '
        Me.LBLGM.AutoSize = True
        Me.LBLGM.BackColor = System.Drawing.Color.Transparent
        Me.LBLGM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLGM.Location = New System.Drawing.Point(207, 55)
        Me.LBLGM.Name = "LBLGM"
        Me.LBLGM.Size = New System.Drawing.Size(49, 14)
        Me.LBLGM.TabIndex = 674
        Me.LBLGM.Text = "Wt in Kg"
        Me.LBLGM.Visible = False
        '
        'TXTGMS
        '
        Me.TXTGMS.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTGMS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGMS.Location = New System.Drawing.Point(258, 51)
        Me.TXTGMS.Name = "TXTGMS"
        Me.TXTGMS.Size = New System.Drawing.Size(50, 22)
        Me.TXTGMS.TabIndex = 6
        Me.TXTGMS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTGMS.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(418, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 14)
        Me.Label5.TabIndex = 673
        Me.Label5.Text = "Item Stock"
        '
        'TXTITEMSTOCK
        '
        Me.TXTITEMSTOCK.BackColor = System.Drawing.Color.Linen
        Me.TXTITEMSTOCK.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTITEMSTOCK.Location = New System.Drawing.Point(483, 64)
        Me.TXTITEMSTOCK.Name = "TXTITEMSTOCK"
        Me.TXTITEMSTOCK.ReadOnly = True
        Me.TXTITEMSTOCK.Size = New System.Drawing.Size(89, 26)
        Me.TXTITEMSTOCK.TabIndex = 672
        Me.TXTITEMSTOCK.TabStop = False
        Me.TXTITEMSTOCK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTPHOTOIMGPATH
        '
        Me.TXTPHOTOIMGPATH.BackColor = System.Drawing.Color.White
        Me.TXTPHOTOIMGPATH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPHOTOIMGPATH.ForeColor = System.Drawing.Color.Black
        Me.TXTPHOTOIMGPATH.Location = New System.Drawing.Point(636, 629)
        Me.TXTPHOTOIMGPATH.Name = "TXTPHOTOIMGPATH"
        Me.TXTPHOTOIMGPATH.Size = New System.Drawing.Size(22, 23)
        Me.TXTPHOTOIMGPATH.TabIndex = 671
        Me.TXTPHOTOIMGPATH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTPHOTOIMGPATH.Visible = False
        '
        'PBCOPYCHART
        '
        Me.PBCOPYCHART.BackColor = System.Drawing.Color.Transparent
        Me.PBCOPYCHART.Image = Global.TexPro_V1.My.Resources.Resources.COPY
        Me.PBCOPYCHART.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PBCOPYCHART.Location = New System.Drawing.Point(313, 23)
        Me.PBCOPYCHART.Name = "PBCOPYCHART"
        Me.PBCOPYCHART.Size = New System.Drawing.Size(29, 23)
        Me.PBCOPYCHART.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBCOPYCHART.TabIndex = 650
        Me.PBCOPYCHART.TabStop = False
        '
        'cmbprocess
        '
        Me.cmbprocess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbprocess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbprocess.BackColor = System.Drawing.Color.White
        Me.cmbprocess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbprocess.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbprocess.FormattingEnabled = True
        Me.cmbprocess.Location = New System.Drawing.Point(82, 51)
        Me.cmbprocess.MaxDropDownItems = 14
        Me.cmbprocess.Name = "cmbprocess"
        Me.cmbprocess.Size = New System.Drawing.Size(109, 22)
        Me.cmbprocess.TabIndex = 540
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 14)
        Me.Label2.TabIndex = 539
        Me.Label2.Text = "Process"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 14)
        Me.Label3.TabIndex = 308
        Me.Label3.Text = "Chart No."
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CHKNOCALC)
        Me.GroupBox1.Controls.Add(Me.cmbunit)
        Me.GroupBox1.Controls.Add(Me.txtconsrno)
        Me.GroupBox1.Controls.Add(Me.cmbitemname)
        Me.GroupBox1.Controls.Add(Me.txtrate)
        Me.GroupBox1.Controls.Add(Me.TXTQTY)
        Me.GroupBox1.Controls.Add(Me.gridconsume)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(376, 105)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(515, 362)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consumption Detail"
        '
        'CHKNOCALC
        '
        Me.CHKNOCALC.AutoSize = True
        Me.CHKNOCALC.BackColor = System.Drawing.Color.Transparent
        Me.CHKNOCALC.Location = New System.Drawing.Point(308, 22)
        Me.CHKNOCALC.Name = "CHKNOCALC"
        Me.CHKNOCALC.Size = New System.Drawing.Size(63, 18)
        Me.CHKNOCALC.TabIndex = 4
        Me.CHKNOCALC.Text = "No Calc"
        Me.CHKNOCALC.UseVisualStyleBackColor = False
        '
        'cmbunit
        '
        Me.cmbunit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbunit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbunit.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbunit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbunit.FormattingEnabled = True
        Me.cmbunit.Location = New System.Drawing.Point(247, 21)
        Me.cmbunit.MaxDropDownItems = 14
        Me.cmbunit.Name = "cmbunit"
        Me.cmbunit.Size = New System.Drawing.Size(50, 22)
        Me.cmbunit.TabIndex = 3
        '
        'txtconsrno
        '
        Me.txtconsrno.BackColor = System.Drawing.Color.Linen
        Me.txtconsrno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtconsrno.Location = New System.Drawing.Point(7, 21)
        Me.txtconsrno.Name = "txtconsrno"
        Me.txtconsrno.Size = New System.Drawing.Size(40, 22)
        Me.txtconsrno.TabIndex = 0
        Me.txtconsrno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbitemname
        '
        Me.cmbitemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbitemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbitemname.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbitemname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbitemname.FormattingEnabled = True
        Me.cmbitemname.Location = New System.Drawing.Point(47, 21)
        Me.cmbitemname.MaxDropDownItems = 14
        Me.cmbitemname.Name = "cmbitemname"
        Me.cmbitemname.Size = New System.Drawing.Size(150, 22)
        Me.cmbitemname.TabIndex = 1
        '
        'txtrate
        '
        Me.txtrate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrate.Location = New System.Drawing.Point(377, 21)
        Me.txtrate.Name = "txtrate"
        Me.txtrate.Size = New System.Drawing.Size(55, 22)
        Me.txtrate.TabIndex = 5
        Me.txtrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTQTY
        '
        Me.TXTQTY.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTQTY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQTY.Location = New System.Drawing.Point(197, 21)
        Me.TXTQTY.Name = "TXTQTY"
        Me.TXTQTY.Size = New System.Drawing.Size(50, 22)
        Me.TXTQTY.TabIndex = 2
        Me.TXTQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gridconsume
        '
        Me.gridconsume.AllowUserToAddRows = False
        Me.gridconsume.AllowUserToDeleteRows = False
        Me.gridconsume.AllowUserToResizeColumns = False
        Me.gridconsume.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.gridconsume.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridconsume.BackgroundColor = System.Drawing.Color.White
        Me.gridconsume.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridconsume.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridconsume.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridconsume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridconsume.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gconsrno, Me.gitemname, Me.gqty, Me.Gunit, Me.GNOCALC, Me.gRate, Me.grecsrno})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridconsume.DefaultCellStyle = DataGridViewCellStyle6
        Me.gridconsume.GridColor = System.Drawing.SystemColors.ControlText
        Me.gridconsume.Location = New System.Drawing.Point(7, 43)
        Me.gridconsume.Margin = New System.Windows.Forms.Padding(2)
        Me.gridconsume.MultiSelect = False
        Me.gridconsume.Name = "gridconsume"
        Me.gridconsume.ReadOnly = True
        Me.gridconsume.RowHeadersVisible = False
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black
        Me.gridconsume.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.gridconsume.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridconsume.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridconsume.Size = New System.Drawing.Size(455, 311)
        Me.gridconsume.TabIndex = 6
        '
        'gconsrno
        '
        Me.gconsrno.HeaderText = "Sr."
        Me.gconsrno.Name = "gconsrno"
        Me.gconsrno.ReadOnly = True
        Me.gconsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gconsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.gconsrno.Width = 40
        '
        'gitemname
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.gitemname.DefaultCellStyle = DataGridViewCellStyle3
        Me.gitemname.HeaderText = "Item Name"
        Me.gitemname.Name = "gitemname"
        Me.gitemname.ReadOnly = True
        Me.gitemname.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gitemname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.gitemname.Width = 150
        '
        'gqty
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N3"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.gqty.DefaultCellStyle = DataGridViewCellStyle4
        Me.gqty.HeaderText = "Qty"
        Me.gqty.Name = "gqty"
        Me.gqty.ReadOnly = True
        Me.gqty.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gqty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.gqty.Width = 50
        '
        'Gunit
        '
        Me.Gunit.HeaderText = "Unit"
        Me.Gunit.Name = "Gunit"
        Me.Gunit.ReadOnly = True
        Me.Gunit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Gunit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Gunit.Width = 50
        '
        'GNOCALC
        '
        Me.GNOCALC.HeaderText = "No Calc"
        Me.GNOCALC.Name = "GNOCALC"
        Me.GNOCALC.ReadOnly = True
        Me.GNOCALC.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GNOCALC.Width = 80
        '
        'gRate
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = "0.00"
        Me.gRate.DefaultCellStyle = DataGridViewCellStyle5
        Me.gRate.HeaderText = "Rate"
        Me.gRate.Name = "gRate"
        Me.gRate.ReadOnly = True
        Me.gRate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.gRate.Width = 55
        '
        'grecsrno
        '
        Me.grecsrno.HeaderText = "recsrno"
        Me.grecsrno.Name = "grecsrno"
        Me.grecsrno.ReadOnly = True
        Me.grecsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grecsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.grecsrno.Visible = False
        '
        'cmbdyeingno
        '
        Me.cmbdyeingno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbdyeingno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbdyeingno.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbdyeingno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbdyeingno.FormattingEnabled = True
        Me.cmbdyeingno.Location = New System.Drawing.Point(82, 23)
        Me.cmbdyeingno.MaxDropDownItems = 14
        Me.cmbdyeingno.Name = "cmbdyeingno"
        Me.cmbdyeingno.Size = New System.Drawing.Size(226, 22)
        Me.cmbdyeingno.TabIndex = 0
        '
        'CMDVIEW
        '
        Me.CMDVIEW.BackColor = System.Drawing.Color.Transparent
        Me.CMDVIEW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDVIEW.FlatAppearance.BorderSize = 0
        Me.CMDVIEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDVIEW.ForeColor = System.Drawing.Color.Black
        Me.CMDVIEW.Location = New System.Drawing.Point(636, 596)
        Me.CMDVIEW.Name = "CMDVIEW"
        Me.CMDVIEW.Size = New System.Drawing.Size(75, 27)
        Me.CMDVIEW.TabIndex = 535
        Me.CMDVIEW.Text = "&View"
        Me.CMDVIEW.UseVisualStyleBackColor = False
        Me.CMDVIEW.Visible = False
        '
        'cmdremove
        '
        Me.cmdremove.BackColor = System.Drawing.Color.Transparent
        Me.cmdremove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdremove.FlatAppearance.BorderSize = 0
        Me.cmdremove.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdremove.ForeColor = System.Drawing.Color.Black
        Me.cmdremove.Location = New System.Drawing.Point(636, 563)
        Me.cmdremove.Name = "cmdremove"
        Me.cmdremove.Size = New System.Drawing.Size(75, 27)
        Me.cmdremove.TabIndex = 4
        Me.cmdremove.Text = "&Remove"
        Me.cmdremove.UseVisualStyleBackColor = False
        Me.cmdremove.Visible = False
        '
        'cmdupload
        '
        Me.cmdupload.BackColor = System.Drawing.Color.Transparent
        Me.cmdupload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdupload.FlatAppearance.BorderSize = 0
        Me.cmdupload.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdupload.ForeColor = System.Drawing.Color.Black
        Me.cmdupload.Location = New System.Drawing.Point(636, 530)
        Me.cmdupload.Name = "cmdupload"
        Me.cmdupload.Size = New System.Drawing.Size(75, 27)
        Me.cmdupload.TabIndex = 3
        Me.cmdupload.Text = "&Upload"
        Me.cmdupload.UseVisualStyleBackColor = False
        Me.cmdupload.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(546, 508)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 14)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Upload Image"
        Me.Label9.Visible = False
        '
        'PBPHOTO
        '
        Me.PBPHOTO.BackColor = System.Drawing.Color.Transparent
        Me.PBPHOTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBPHOTO.Location = New System.Drawing.Point(470, 528)
        Me.PBPHOTO.Name = "PBPHOTO"
        Me.PBPHOTO.Size = New System.Drawing.Size(160, 161)
        Me.PBPHOTO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBPHOTO.TabIndex = 435
        Me.PBPHOTO.TabStop = False
        Me.PBPHOTO.Visible = False
        '
        'GPRATE
        '
        Me.GPRATE.BackColor = System.Drawing.Color.Transparent
        Me.GPRATE.Controls.Add(Me.txttotalcost)
        Me.GPRATE.Controls.Add(Me.pbcopy)
        Me.GPRATE.Controls.Add(Me.txtsrno)
        Me.GPRATE.Controls.Add(Me.txtperpcs)
        Me.GPRATE.Controls.Add(Me.cmbmatching)
        Me.GPRATE.Controls.Add(Me.GRIDRECIPE)
        Me.GPRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPRATE.ForeColor = System.Drawing.Color.Black
        Me.GPRATE.Location = New System.Drawing.Point(12, 104)
        Me.GPRATE.Name = "GPRATE"
        Me.GPRATE.Size = New System.Drawing.Size(348, 254)
        Me.GPRATE.TabIndex = 1
        Me.GPRATE.TabStop = False
        Me.GPRATE.Text = "Recipe Details"
        '
        'txttotalcost
        '
        Me.txttotalcost.BackColor = System.Drawing.Color.Linen
        Me.txttotalcost.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalcost.Location = New System.Drawing.Point(255, 21)
        Me.txttotalcost.Name = "txttotalcost"
        Me.txttotalcost.Size = New System.Drawing.Size(60, 22)
        Me.txttotalcost.TabIndex = 3
        Me.txttotalcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pbcopy
        '
        Me.pbcopy.BackColor = System.Drawing.Color.Transparent
        Me.pbcopy.Image = Global.TexPro_V1.My.Resources.Resources.COPY
        Me.pbcopy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbcopy.Location = New System.Drawing.Point(313, 20)
        Me.pbcopy.Name = "pbcopy"
        Me.pbcopy.Size = New System.Drawing.Size(29, 23)
        Me.pbcopy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbcopy.TabIndex = 649
        Me.pbcopy.TabStop = False
        '
        'txtsrno
        '
        Me.txtsrno.BackColor = System.Drawing.Color.Linen
        Me.txtsrno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsrno.Location = New System.Drawing.Point(6, 21)
        Me.txtsrno.Name = "txtsrno"
        Me.txtsrno.Size = New System.Drawing.Size(39, 22)
        Me.txtsrno.TabIndex = 0
        Me.txtsrno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtperpcs
        '
        Me.txtperpcs.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtperpcs.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtperpcs.Location = New System.Drawing.Point(175, 21)
        Me.txtperpcs.Name = "txtperpcs"
        Me.txtperpcs.Size = New System.Drawing.Size(80, 22)
        Me.txtperpcs.TabIndex = 2
        Me.txtperpcs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbmatching
        '
        Me.cmbmatching.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbmatching.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbmatching.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbmatching.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbmatching.FormattingEnabled = True
        Me.cmbmatching.Location = New System.Drawing.Point(45, 21)
        Me.cmbmatching.MaxDropDownItems = 14
        Me.cmbmatching.Name = "cmbmatching"
        Me.cmbmatching.Size = New System.Drawing.Size(130, 22)
        Me.cmbmatching.TabIndex = 1
        '
        'GRIDRECIPE
        '
        Me.GRIDRECIPE.AllowUserToAddRows = False
        Me.GRIDRECIPE.AllowUserToDeleteRows = False
        Me.GRIDRECIPE.AllowUserToResizeColumns = False
        Me.GRIDRECIPE.AllowUserToResizeRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDRECIPE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.GRIDRECIPE.BackgroundColor = System.Drawing.Color.White
        Me.GRIDRECIPE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDRECIPE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDRECIPE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.GRIDRECIPE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDRECIPE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.gMatching, Me.gPerPcs, Me.gtotalCost})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDRECIPE.DefaultCellStyle = DataGridViewCellStyle12
        Me.GRIDRECIPE.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDRECIPE.Location = New System.Drawing.Point(5, 43)
        Me.GRIDRECIPE.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDRECIPE.MultiSelect = False
        Me.GRIDRECIPE.Name = "GRIDRECIPE"
        Me.GRIDRECIPE.ReadOnly = True
        Me.GRIDRECIPE.RowHeadersVisible = False
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDRECIPE.RowsDefaultCellStyle = DataGridViewCellStyle13
        Me.GRIDRECIPE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDRECIPE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDRECIPE.Size = New System.Drawing.Size(335, 202)
        Me.GRIDRECIPE.TabIndex = 4
        '
        'gsrno
        '
        Me.gsrno.HeaderText = "Sr."
        Me.gsrno.Name = "gsrno"
        Me.gsrno.ReadOnly = True
        Me.gsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gsrno.Width = 40
        '
        'gMatching
        '
        Me.gMatching.HeaderText = "Color"
        Me.gMatching.Name = "gMatching"
        Me.gMatching.ReadOnly = True
        Me.gMatching.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gMatching.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gMatching.Width = 130
        '
        'gPerPcs
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gPerPcs.DefaultCellStyle = DataGridViewCellStyle10
        Me.gPerPcs.HeaderText = "Per Pcs"
        Me.gPerPcs.Name = "gPerPcs"
        Me.gPerPcs.ReadOnly = True
        Me.gPerPcs.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gPerPcs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gPerPcs.Width = 80
        '
        'gtotalCost
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gtotalCost.DefaultCellStyle = DataGridViewCellStyle11
        Me.gtotalCost.HeaderText = "Cost"
        Me.gtotalCost.Name = "gtotalCost"
        Me.gtotalCost.ReadOnly = True
        Me.gtotalCost.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gtotalCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gtotalCost.Width = 60
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(12, 364)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(236, 111)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(6, 18)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(224, 85)
        Me.txtremarks.TabIndex = 0
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(143, 3)
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
        Me.cmddelete.Location = New System.Drawing.Point(365, 477)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(75, 27)
        Me.cmddelete.TabIndex = 7
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(284, 477)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(75, 27)
        Me.cmdok.TabIndex = 6
        Me.cmdok.Text = "Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(446, 477)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(75, 27)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CHKBLOCKED
        '
        Me.CHKBLOCKED.AutoSize = True
        Me.CHKBLOCKED.BackColor = System.Drawing.Color.Transparent
        Me.CHKBLOCKED.Location = New System.Drawing.Point(483, 27)
        Me.CHKBLOCKED.Name = "CHKBLOCKED"
        Me.CHKBLOCKED.Size = New System.Drawing.Size(67, 19)
        Me.CHKBLOCKED.TabIndex = 675
        Me.CHKBLOCKED.Text = "Blocked"
        Me.CHKBLOCKED.UseVisualStyleBackColor = False
        '
        'DyeingRecipe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 540)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "DyeingRecipe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dyeing Recipe"
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PBCOPYCHART, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gridconsume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBPHOTO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPRATE.ResumeLayout(False)
        Me.GPRATE.PerformLayout()
        CType(Me.pbcopy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDRECIPE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtconsrno As System.Windows.Forms.TextBox
    Friend WithEvents cmbitemname As System.Windows.Forms.ComboBox
    Friend WithEvents txtrate As System.Windows.Forms.TextBox
    Friend WithEvents TXTQTY As System.Windows.Forms.TextBox
    Friend WithEvents gridconsume As System.Windows.Forms.DataGridView
    Friend WithEvents cmbdyeingno As System.Windows.Forms.ComboBox
    Friend WithEvents CMDVIEW As System.Windows.Forms.Button
    Friend WithEvents cmdremove As System.Windows.Forms.Button
    Friend WithEvents cmdupload As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PBPHOTO As System.Windows.Forms.PictureBox
    Friend WithEvents GPRATE As System.Windows.Forms.GroupBox
    Friend WithEvents txttotalcost As System.Windows.Forms.TextBox
    Friend WithEvents txtsrno As System.Windows.Forms.TextBox
    Friend WithEvents txtperpcs As System.Windows.Forms.TextBox
    Friend WithEvents cmbmatching As System.Windows.Forms.ComboBox
    Friend WithEvents GRIDRECIPE As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmbunit As System.Windows.Forms.ComboBox
    Friend WithEvents cmbprocess As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PBCOPYCHART As System.Windows.Forms.PictureBox
    Friend WithEvents pbcopy As System.Windows.Forms.PictureBox
    Friend WithEvents TXTPHOTOIMGPATH As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TXTITEMSTOCK As TextBox
    Friend WithEvents gsrno As DataGridViewTextBoxColumn
    Friend WithEvents gMatching As DataGridViewTextBoxColumn
    Friend WithEvents gPerPcs As DataGridViewTextBoxColumn
    Friend WithEvents gtotalCost As DataGridViewTextBoxColumn
    Friend WithEvents LBLGM As Label
    Friend WithEvents TXTGMS As TextBox
    Friend WithEvents CHKNOCALC As CheckBox
    Friend WithEvents gconsrno As DataGridViewTextBoxColumn
    Friend WithEvents gitemname As DataGridViewTextBoxColumn
    Friend WithEvents gqty As DataGridViewTextBoxColumn
    Friend WithEvents Gunit As DataGridViewTextBoxColumn
    Friend WithEvents GNOCALC As DataGridViewCheckBoxColumn
    Friend WithEvents gRate As DataGridViewTextBoxColumn
    Friend WithEvents grecsrno As DataGridViewTextBoxColumn
    Friend WithEvents CHKBLOCKED As CheckBox
End Class
