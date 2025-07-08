<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockAdjustment
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockAdjustment))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMBGODOWN = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtbalmtrs = New System.Windows.Forms.TextBox()
        Me.txtbalpcs = New System.Windows.Forms.TextBox()
        Me.TXTQUALITY = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabdetails = New System.Windows.Forms.TabPage()
        Me.GRIDSA = New System.Windows.Forms.DataGridView()
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gpiecetype = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMERCHANT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GJOBNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDESIGN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gcolor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GLOTNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GQUALITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gpcs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbltotalpcs = New System.Windows.Forms.Label()
        Me.lbltotalmtrs = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmdcopy = New System.Windows.Forms.Button()
        Me.cmbjobno = New System.Windows.Forms.ComboBox()
        Me.CMBLOTNO = New System.Windows.Forms.ComboBox()
        Me.txtpcs = New System.Windows.Forms.TextBox()
        Me.cmbdesign = New System.Windows.Forms.ComboBox()
        Me.cmbmerchant = New System.Windows.Forms.ComboBox()
        Me.txtmtrs = New System.Windows.Forms.TextBox()
        Me.txtcut = New System.Windows.Forms.TextBox()
        Me.cmbcolor = New System.Windows.Forms.ComboBox()
        Me.cmbpiecetype = New System.Windows.Forms.ComboBox()
        Me.txtsrno = New System.Windows.Forms.TextBox()
        Me.chkchange = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CMBFROM = New System.Windows.Forms.ComboBox()
        Me.SADATE = New System.Windows.Forms.DateTimePicker()
        Me.TXTSANO = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabdetails.SuspendLayout()
        CType(Me.GRIDSA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.CMBGODOWN)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.txtbalmtrs)
        Me.BlendPanel1.Controls.Add(Me.txtbalpcs)
        Me.BlendPanel1.Controls.Add(Me.TXTQUALITY)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmbtype)
        Me.BlendPanel1.Controls.Add(Me.Label32)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.CMBFROM)
        Me.BlendPanel1.Controls.Add(Me.SADATE)
        Me.BlendPanel1.Controls.Add(Me.TXTSANO)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.Label23)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(775, 560)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(438, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 15)
        Me.Label6.TabIndex = 710
        Me.Label6.Text = "Godown"
        '
        'CMBGODOWN
        '
        Me.CMBGODOWN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBGODOWN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBGODOWN.BackColor = System.Drawing.Color.White
        Me.CMBGODOWN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBGODOWN.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBGODOWN.FormattingEnabled = True
        Me.CMBGODOWN.Location = New System.Drawing.Point(493, 30)
        Me.CMBGODOWN.MaxDropDownItems = 14
        Me.CMBGODOWN.Name = "CMBGODOWN"
        Me.CMBGODOWN.Size = New System.Drawing.Size(84, 23)
        Me.CMBGODOWN.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(443, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 15)
        Me.Label3.TabIndex = 708
        Me.Label3.Text = "Bal Pcs"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(436, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 15)
        Me.Label5.TabIndex = 707
        Me.Label5.Text = "Bal Mtrs"
        '
        'txtbalmtrs
        '
        Me.txtbalmtrs.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbalmtrs.Location = New System.Drawing.Point(493, 85)
        Me.txtbalmtrs.Name = "txtbalmtrs"
        Me.txtbalmtrs.ReadOnly = True
        Me.txtbalmtrs.Size = New System.Drawing.Size(60, 23)
        Me.txtbalmtrs.TabIndex = 706
        Me.txtbalmtrs.TabStop = False
        Me.txtbalmtrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtbalpcs
        '
        Me.txtbalpcs.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbalpcs.Location = New System.Drawing.Point(493, 57)
        Me.txtbalpcs.Name = "txtbalpcs"
        Me.txtbalpcs.ReadOnly = True
        Me.txtbalpcs.Size = New System.Drawing.Size(60, 23)
        Me.txtbalpcs.TabIndex = 705
        Me.txtbalpcs.TabStop = False
        Me.txtbalpcs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTQUALITY
        '
        Me.TXTQUALITY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQUALITY.Location = New System.Drawing.Point(247, 56)
        Me.TXTQUALITY.Name = "TXTQUALITY"
        Me.TXTQUALITY.ReadOnly = True
        Me.TXTQUALITY.Size = New System.Drawing.Size(60, 23)
        Me.TXTQUALITY.TabIndex = 671
        Me.TXTQUALITY.TabStop = False
        Me.TXTQUALITY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(101, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 15)
        Me.Label1.TabIndex = 704
        Me.Label1.Text = "Type"
        '
        'cmbtype
        '
        Me.cmbtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.DropDownWidth = 400
        Me.cmbtype.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"GREY CHECKED", "GREY", "STORE", "PROCESS", "BALE", "JOBOUT", "JOBBALE"})
        Me.cmbtype.Location = New System.Drawing.Point(137, 56)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(99, 23)
        Me.cmbtype.TabIndex = 2
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(687, 156)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(0, 15)
        Me.Label32.TabIndex = 702
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabdetails)
        Me.TabControl1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 107)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(747, 347)
        Me.TabControl1.TabIndex = 5
        '
        'tabdetails
        '
        Me.tabdetails.BackColor = System.Drawing.Color.White
        Me.tabdetails.Controls.Add(Me.GRIDSA)
        Me.tabdetails.Controls.Add(Me.lbltotalpcs)
        Me.tabdetails.Controls.Add(Me.lbltotalmtrs)
        Me.tabdetails.Controls.Add(Me.Label26)
        Me.tabdetails.Controls.Add(Me.cmdcopy)
        Me.tabdetails.Controls.Add(Me.cmbjobno)
        Me.tabdetails.Controls.Add(Me.CMBLOTNO)
        Me.tabdetails.Controls.Add(Me.txtpcs)
        Me.tabdetails.Controls.Add(Me.cmbdesign)
        Me.tabdetails.Controls.Add(Me.cmbmerchant)
        Me.tabdetails.Controls.Add(Me.txtmtrs)
        Me.tabdetails.Controls.Add(Me.txtcut)
        Me.tabdetails.Controls.Add(Me.cmbcolor)
        Me.tabdetails.Controls.Add(Me.cmbpiecetype)
        Me.tabdetails.Controls.Add(Me.txtsrno)
        Me.tabdetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabdetails.Location = New System.Drawing.Point(4, 24)
        Me.tabdetails.Name = "tabdetails"
        Me.tabdetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabdetails.Size = New System.Drawing.Size(739, 319)
        Me.tabdetails.TabIndex = 0
        Me.tabdetails.Text = "Item Details"
        Me.tabdetails.ToolTipText = "&1 Shortcut"
        Me.tabdetails.UseVisualStyleBackColor = True
        '
        'GRIDSA
        '
        Me.GRIDSA.AllowUserToAddRows = False
        Me.GRIDSA.AllowUserToDeleteRows = False
        Me.GRIDSA.AllowUserToResizeColumns = False
        Me.GRIDSA.AllowUserToResizeRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDSA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.GRIDSA.BackgroundColor = System.Drawing.Color.White
        Me.GRIDSA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDSA.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDSA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.GRIDSA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDSA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.gpiecetype, Me.GMERCHANT, Me.GJOBNO, Me.GCUT, Me.GDESIGN, Me.gcolor, Me.GLOTNO, Me.GQUALITY, Me.gpcs, Me.GMTRS})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSA.DefaultCellStyle = DataGridViewCellStyle17
        Me.GRIDSA.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDSA.Location = New System.Drawing.Point(1, 26)
        Me.GRIDSA.MultiSelect = False
        Me.GRIDSA.Name = "GRIDSA"
        Me.GRIDSA.RowHeadersVisible = False
        Me.GRIDSA.RowHeadersWidth = 30
        Me.GRIDSA.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDSA.RowsDefaultCellStyle = DataGridViewCellStyle18
        Me.GRIDSA.RowTemplate.Height = 20
        Me.GRIDSA.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDSA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDSA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.GRIDSA.Size = New System.Drawing.Size(732, 270)
        Me.GRIDSA.TabIndex = 11
        '
        'gsrno
        '
        Me.gsrno.HeaderText = "Sr."
        Me.gsrno.Name = "gsrno"
        Me.gsrno.ReadOnly = True
        Me.gsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gsrno.Width = 30
        '
        'gpiecetype
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.gpiecetype.DefaultCellStyle = DataGridViewCellStyle12
        Me.gpiecetype.HeaderText = "Piece Type"
        Me.gpiecetype.Name = "gpiecetype"
        Me.gpiecetype.ReadOnly = True
        Me.gpiecetype.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gpiecetype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GMERCHANT
        '
        Me.GMERCHANT.HeaderText = "Merchant Name"
        Me.GMERCHANT.Name = "GMERCHANT"
        Me.GMERCHANT.ReadOnly = True
        Me.GMERCHANT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMERCHANT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMERCHANT.Width = 150
        '
        'GJOBNO
        '
        Me.GJOBNO.HeaderText = "Job"
        Me.GJOBNO.Name = "GJOBNO"
        Me.GJOBNO.ReadOnly = True
        Me.GJOBNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GJOBNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GJOBNO.Width = 60
        '
        'GCUT
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GCUT.DefaultCellStyle = DataGridViewCellStyle13
        Me.GCUT.HeaderText = "Cut"
        Me.GCUT.Name = "GCUT"
        Me.GCUT.ReadOnly = True
        Me.GCUT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCUT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCUT.Width = 40
        '
        'GDESIGN
        '
        Me.GDESIGN.HeaderText = "Design"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.ReadOnly = True
        Me.GDESIGN.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GDESIGN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GDESIGN.Width = 60
        '
        'gcolor
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.NullValue = Nothing
        Me.gcolor.DefaultCellStyle = DataGridViewCellStyle14
        Me.gcolor.HeaderText = "Color"
        Me.gcolor.Name = "gcolor"
        Me.gcolor.ReadOnly = True
        Me.gcolor.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gcolor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gcolor.Width = 80
        '
        'GLOTNO
        '
        Me.GLOTNO.HeaderText = "Lot No."
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.ReadOnly = True
        Me.GLOTNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GLOTNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GLOTNO.Width = 60
        '
        'GQUALITY
        '
        Me.GQUALITY.HeaderText = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.ReadOnly = True
        Me.GQUALITY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GQUALITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GQUALITY.Visible = False
        '
        'gpcs
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N2"
        Me.gpcs.DefaultCellStyle = DataGridViewCellStyle15
        Me.gpcs.HeaderText = "Pcs"
        Me.gpcs.Name = "gpcs"
        Me.gpcs.ReadOnly = True
        Me.gpcs.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gpcs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gpcs.Width = 60
        '
        'GMTRS
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N2"
        Me.GMTRS.DefaultCellStyle = DataGridViewCellStyle16
        Me.GMTRS.HeaderText = "Mtrs"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.ReadOnly = True
        Me.GMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMTRS.Width = 65
        '
        'lbltotalpcs
        '
        Me.lbltotalpcs.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalpcs.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalpcs.ForeColor = System.Drawing.Color.Black
        Me.lbltotalpcs.Location = New System.Drawing.Point(575, 297)
        Me.lbltotalpcs.Name = "lbltotalpcs"
        Me.lbltotalpcs.Size = New System.Drawing.Size(63, 17)
        Me.lbltotalpcs.TabIndex = 670
        Me.lbltotalpcs.Text = "0"
        Me.lbltotalpcs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbltotalmtrs
        '
        Me.lbltotalmtrs.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalmtrs.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalmtrs.ForeColor = System.Drawing.Color.Black
        Me.lbltotalmtrs.Location = New System.Drawing.Point(644, 297)
        Me.lbltotalmtrs.Name = "lbltotalmtrs"
        Me.lbltotalmtrs.Size = New System.Drawing.Size(63, 17)
        Me.lbltotalmtrs.TabIndex = 669
        Me.lbltotalmtrs.Text = "0"
        Me.lbltotalmtrs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(405, 299)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(33, 15)
        Me.Label26.TabIndex = 667
        Me.Label26.Text = "Total"
        '
        'cmdcopy
        '
        Me.cmdcopy.BackColor = System.Drawing.Color.Transparent
        Me.cmdcopy.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcopy.FlatAppearance.BorderSize = 0
        Me.cmdcopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdcopy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcopy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdcopy.Location = New System.Drawing.Point(994, -4)
        Me.cmdcopy.Name = "cmdcopy"
        Me.cmdcopy.Size = New System.Drawing.Size(19, 29)
        Me.cmdcopy.TabIndex = 480
        Me.cmdcopy.UseVisualStyleBackColor = False
        '
        'cmbjobno
        '
        Me.cmbjobno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbjobno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbjobno.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbjobno.FormattingEnabled = True
        Me.cmbjobno.Location = New System.Drawing.Point(281, 2)
        Me.cmbjobno.Name = "cmbjobno"
        Me.cmbjobno.Size = New System.Drawing.Size(60, 23)
        Me.cmbjobno.TabIndex = 2
        '
        'CMBLOTNO
        '
        Me.CMBLOTNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBLOTNO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBLOTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBLOTNO.FormattingEnabled = True
        Me.CMBLOTNO.Location = New System.Drawing.Point(521, 2)
        Me.CMBLOTNO.Name = "CMBLOTNO"
        Me.CMBLOTNO.Size = New System.Drawing.Size(60, 23)
        Me.CMBLOTNO.TabIndex = 6
        '
        'txtpcs
        '
        Me.txtpcs.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpcs.Location = New System.Drawing.Point(581, 2)
        Me.txtpcs.Name = "txtpcs"
        Me.txtpcs.Size = New System.Drawing.Size(60, 23)
        Me.txtpcs.TabIndex = 7
        Me.txtpcs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbdesign
        '
        Me.cmbdesign.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbdesign.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbdesign.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbdesign.FormattingEnabled = True
        Me.cmbdesign.Location = New System.Drawing.Point(381, 2)
        Me.cmbdesign.Name = "cmbdesign"
        Me.cmbdesign.Size = New System.Drawing.Size(60, 23)
        Me.cmbdesign.TabIndex = 4
        '
        'cmbmerchant
        '
        Me.cmbmerchant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbmerchant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbmerchant.DropDownWidth = 400
        Me.cmbmerchant.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbmerchant.FormattingEnabled = True
        Me.cmbmerchant.Location = New System.Drawing.Point(131, 2)
        Me.cmbmerchant.Name = "cmbmerchant"
        Me.cmbmerchant.Size = New System.Drawing.Size(150, 23)
        Me.cmbmerchant.TabIndex = 1
        '
        'txtmtrs
        '
        Me.txtmtrs.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtmtrs.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmtrs.Location = New System.Drawing.Point(641, 2)
        Me.txtmtrs.Name = "txtmtrs"
        Me.txtmtrs.Size = New System.Drawing.Size(64, 23)
        Me.txtmtrs.TabIndex = 8
        Me.txtmtrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcut
        '
        Me.txtcut.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcut.Location = New System.Drawing.Point(341, 2)
        Me.txtcut.Name = "txtcut"
        Me.txtcut.Size = New System.Drawing.Size(40, 23)
        Me.txtcut.TabIndex = 3
        Me.txtcut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbcolor
        '
        Me.cmbcolor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcolor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcolor.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcolor.FormattingEnabled = True
        Me.cmbcolor.Location = New System.Drawing.Point(441, 2)
        Me.cmbcolor.Name = "cmbcolor"
        Me.cmbcolor.Size = New System.Drawing.Size(80, 23)
        Me.cmbcolor.TabIndex = 5
        '
        'cmbpiecetype
        '
        Me.cmbpiecetype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbpiecetype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbpiecetype.DropDownWidth = 400
        Me.cmbpiecetype.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbpiecetype.FormattingEnabled = True
        Me.cmbpiecetype.Location = New System.Drawing.Point(31, 2)
        Me.cmbpiecetype.Name = "cmbpiecetype"
        Me.cmbpiecetype.Size = New System.Drawing.Size(100, 23)
        Me.cmbpiecetype.TabIndex = 0
        '
        'txtsrno
        '
        Me.txtsrno.BackColor = System.Drawing.Color.Linen
        Me.txtsrno.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsrno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtsrno.Location = New System.Drawing.Point(1, 2)
        Me.txtsrno.Name = "txtsrno"
        Me.txtsrno.ReadOnly = True
        Me.txtsrno.Size = New System.Drawing.Size(30, 23)
        Me.txtsrno.TabIndex = 0
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(734, 30)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 675
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(101, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 15)
        Me.Label4.TabIndex = 667
        Me.Label4.Text = "From"
        '
        'CMBFROM
        '
        Me.CMBFROM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBFROM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBFROM.BackColor = System.Drawing.Color.White
        Me.CMBFROM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBFROM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBFROM.FormattingEnabled = True
        Me.CMBFROM.Location = New System.Drawing.Point(137, 84)
        Me.CMBFROM.MaxDropDownItems = 14
        Me.CMBFROM.Name = "CMBFROM"
        Me.CMBFROM.Size = New System.Drawing.Size(170, 23)
        Me.CMBFROM.TabIndex = 3
        '
        'SADATE
        '
        Me.SADATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SADATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.SADATE.Location = New System.Drawing.Point(638, 84)
        Me.SADATE.Name = "SADATE"
        Me.SADATE.Size = New System.Drawing.Size(91, 23)
        Me.SADATE.TabIndex = 1
        '
        'TXTSANO
        '
        Me.TXTSANO.BackColor = System.Drawing.Color.Linen
        Me.TXTSANO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSANO.Location = New System.Drawing.Point(638, 56)
        Me.TXTSANO.Name = "TXTSANO"
        Me.TXTSANO.ReadOnly = True
        Me.TXTSANO.Size = New System.Drawing.Size(91, 23)
        Me.TXTSANO.TabIndex = 0
        Me.TXTSANO.TabStop = False
        Me.TXTSANO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(592, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 15)
        Me.Label12.TabIndex = 630
        Me.Label12.Text = "Sr. No."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(603, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 15)
        Me.Label9.TabIndex = 622
        Me.Label9.Text = "Date"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(658, 37)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 15)
        Me.Label15.TabIndex = 613
        Me.Label15.Text = "Locked"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(639, 36)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(18, 17)
        Me.Label23.TabIndex = 612
        Me.Label23.Text = "   "
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(473, 497)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 9
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(12, 463)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(318, 86)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(5, 18)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(307, 62)
        Me.txtremarks.TabIndex = 0
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(559, 463)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 8
        Me.cmdclear.Text = "&Clear"
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(473, 463)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 7
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(559, 497)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 10
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(239, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(45, 21)
        Me.tstxtbillno.TabIndex = 10
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(14, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Stock Adjustment"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.tooldelete, Me.toolStripSeparator, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(775, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'OpenToolStripButton
        '
        Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
        Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenToolStripButton.Name = "OpenToolStripButton"
        Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.OpenToolStripButton.Text = "&Open"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
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
        'tooldelete
        '
        Me.tooldelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tooldelete.Image = CType(resources.GetObject("tooldelete.Image"), System.Drawing.Image)
        Me.tooldelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tooldelete.Name = "tooldelete"
        Me.tooldelete.Size = New System.Drawing.Size(23, 22)
        Me.tooldelete.Text = "&Delete"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'toolprevious
        '
        Me.toolprevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolprevious.Image = Global.TexPro_V1.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(74, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolnext.Image = Global.TexPro_V1.My.Resources.Resources.POINT04
        Me.toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolnext.Name = "toolnext"
        Me.toolnext.Size = New System.Drawing.Size(52, 22)
        Me.toolnext.Text = "Next"
        Me.toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'StockAdjustment
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(775, 560)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StockAdjustment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Stock Adjustment"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabdetails.ResumeLayout(False)
        Me.tabdetails.PerformLayout()
        CType(Me.GRIDSA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabdetails As System.Windows.Forms.TabPage
    Friend WithEvents CMBLOTNO As System.Windows.Forms.ComboBox
    Friend WithEvents txtpcs As System.Windows.Forms.TextBox
    Friend WithEvents cmbdesign As System.Windows.Forms.ComboBox
    Friend WithEvents cmbmerchant As System.Windows.Forms.ComboBox
    Friend WithEvents txtmtrs As System.Windows.Forms.TextBox
    Friend WithEvents txtcut As System.Windows.Forms.TextBox
    Friend WithEvents cmbcolor As System.Windows.Forms.ComboBox
    Friend WithEvents cmbpiecetype As System.Windows.Forms.ComboBox
    Friend WithEvents txtsrno As System.Windows.Forms.TextBox
    Friend WithEvents GRIDSA As System.Windows.Forms.DataGridView
    Friend WithEvents lbltotalpcs As System.Windows.Forms.Label
    Friend WithEvents lbltotalmtrs As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmdcopy As System.Windows.Forms.Button
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMBFROM As System.Windows.Forms.ComboBox
    Friend WithEvents SADATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTSANO As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tooldelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbjobno As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents TXTQUALITY As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtbalmtrs As System.Windows.Forms.TextBox
    Friend WithEvents txtbalpcs As System.Windows.Forms.TextBox
    Friend WithEvents gsrno As DataGridViewTextBoxColumn
    Friend WithEvents gpiecetype As DataGridViewTextBoxColumn
    Friend WithEvents GMERCHANT As DataGridViewTextBoxColumn
    Friend WithEvents GJOBNO As DataGridViewTextBoxColumn
    Friend WithEvents GCUT As DataGridViewTextBoxColumn
    Friend WithEvents GDESIGN As DataGridViewTextBoxColumn
    Friend WithEvents gcolor As DataGridViewTextBoxColumn
    Friend WithEvents GLOTNO As DataGridViewTextBoxColumn
    Friend WithEvents GQUALITY As DataGridViewTextBoxColumn
    Friend WithEvents gpcs As DataGridViewTextBoxColumn
    Friend WithEvents GMTRS As DataGridViewTextBoxColumn
    Friend WithEvents Label6 As Label
    Friend WithEvents CMBGODOWN As ComboBox
End Class
