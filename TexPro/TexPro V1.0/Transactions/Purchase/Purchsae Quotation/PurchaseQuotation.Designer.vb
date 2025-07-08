<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchaseQuotation
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PurchaseQuotation))
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CMDVIEW = New System.Windows.Forms.Button
        Me.txtuploadpr = New System.Windows.Forms.TextBox
        Me.txtimgpath = New System.Windows.Forms.TextBox
        Me.cmduploadPR = New System.Windows.Forms.Button
        Me.dtvalidtill = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.CMDDOWNLOAD = New System.Windows.Forms.Button
        Me.tstxtbillno = New System.Windows.Forms.TextBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.tooldelete = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.toolprevious = New System.Windows.Forms.ToolStripButton
        Me.toolnext = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox
        Me.cmbcolor = New System.Windows.Forms.ComboBox
        Me.TXTPICK = New System.Windows.Forms.TextBox
        Me.TXTREED = New System.Windows.Forms.TextBox
        Me.cmbitemname = New System.Windows.Forms.ComboBox
        Me.cmbqtyunit = New System.Windows.Forms.ComboBox
        Me.gridQuotation = New System.Windows.Forms.DataGridView
        Me.txtsrno = New System.Windows.Forms.TextBox
        Me.txtqty = New System.Windows.Forms.TextBox
        Me.txtgridremarks = New System.Windows.Forms.TextBox
        Me.txtamount = New System.Windows.Forms.TextBox
        Me.txtrate = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtppartyref = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.PBlock = New System.Windows.Forms.PictureBox
        Me.lbllocked = New System.Windows.Forms.Label
        Me.cmddelete = New System.Windows.Forms.Button
        Me.cmdselectPR = New System.Windows.Forms.Button
        Me.lbltotalamt = New System.Windows.Forms.Label
        Me.cmdremove = New System.Windows.Forms.Button
        Me.cmdupload = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.pbsoftcopy = New System.Windows.Forms.PictureBox
        Me.quotationdate = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtadd = New System.Windows.Forms.TextBox
        Me.cmbname = New System.Windows.Forms.ComboBox
        Me.chkchange = New System.Windows.Forms.CheckBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.cmdedit = New System.Windows.Forms.Button
        Me.txtref = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtremarks = New System.Windows.Forms.TextBox
        Me.cmdclear = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdok = New System.Windows.Forms.Button
        Me.txtPRNO = New System.Windows.Forms.TextBox
        Me.cmdexit = New System.Windows.Forms.Button
        Me.lbltotalqty = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtquotation = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.gsrno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gitemname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gdesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GQUALITY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GREED = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GPICK = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gcolor = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gqtyunit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gamt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grecdqty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GDONE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GPRNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gprgridsrno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.gridQuotation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbsoftcopy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDVIEW)
        Me.BlendPanel1.Controls.Add(Me.txtuploadpr)
        Me.BlendPanel1.Controls.Add(Me.txtimgpath)
        Me.BlendPanel1.Controls.Add(Me.cmduploadPR)
        Me.BlendPanel1.Controls.Add(Me.dtvalidtill)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.CMDDOWNLOAD)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox3)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.dtppartyref)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdselectPR)
        Me.BlendPanel1.Controls.Add(Me.lbltotalamt)
        Me.BlendPanel1.Controls.Add(Me.cmdremove)
        Me.BlendPanel1.Controls.Add(Me.cmdupload)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.pbsoftcopy)
        Me.BlendPanel1.Controls.Add(Me.quotationdate)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.GroupBox4)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.GroupBox7)
        Me.BlendPanel1.Controls.Add(Me.cmdedit)
        Me.BlendPanel1.Controls.Add(Me.txtref)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.txtPRNO)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lbltotalqty)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.txtquotation)
        Me.BlendPanel1.Controls.Add(Me.Label20)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(994, 569)
        Me.BlendPanel1.TabIndex = 2
        '
        'CMDVIEW
        '
        Me.CMDVIEW.BackColor = System.Drawing.Color.Transparent
        Me.CMDVIEW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDVIEW.FlatAppearance.BorderSize = 0
        Me.CMDVIEW.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDVIEW.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDVIEW.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDVIEW.Image = Global.TexPro_V1.My.Resources.Resources.VIEW
        Me.CMDVIEW.Location = New System.Drawing.Point(511, 137)
        Me.CMDVIEW.Name = "CMDVIEW"
        Me.CMDVIEW.Size = New System.Drawing.Size(75, 27)
        Me.CMDVIEW.TabIndex = 533
        Me.CMDVIEW.UseVisualStyleBackColor = False
        '
        'txtuploadpr
        '
        Me.txtuploadpr.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuploadpr.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtuploadpr.Location = New System.Drawing.Point(425, 542)
        Me.txtuploadpr.Multiline = True
        Me.txtuploadpr.Name = "txtuploadpr"
        Me.txtuploadpr.Size = New System.Drawing.Size(45, 22)
        Me.txtuploadpr.TabIndex = 532
        Me.txtuploadpr.Visible = False
        '
        'txtimgpath
        '
        Me.txtimgpath.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtimgpath.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtimgpath.Location = New System.Drawing.Point(718, 38)
        Me.txtimgpath.Multiline = True
        Me.txtimgpath.Name = "txtimgpath"
        Me.txtimgpath.Size = New System.Drawing.Size(45, 22)
        Me.txtimgpath.TabIndex = 531
        Me.txtimgpath.Visible = False
        '
        'cmduploadPR
        '
        Me.cmduploadPR.BackColor = System.Drawing.Color.Transparent
        Me.cmduploadPR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmduploadPR.FlatAppearance.BorderSize = 0
        Me.cmduploadPR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmduploadPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmduploadPR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmduploadPR.Image = Global.TexPro_V1.My.Resources.Resources.upload_pr
        Me.cmduploadPR.Location = New System.Drawing.Point(425, 509)
        Me.cmduploadPR.Name = "cmduploadPR"
        Me.cmduploadPR.Size = New System.Drawing.Size(75, 27)
        Me.cmduploadPR.TabIndex = 530
        Me.cmduploadPR.UseVisualStyleBackColor = False
        '
        'dtvalidtill
        '
        Me.dtvalidtill.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtvalidtill.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtvalidtill.Location = New System.Drawing.Point(373, 139)
        Me.dtvalidtill.Name = "dtvalidtill"
        Me.dtvalidtill.Size = New System.Drawing.Size(82, 22)
        Me.dtvalidtill.TabIndex = 528
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(283, 143)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 14)
        Me.Label11.TabIndex = 529
        Me.Label11.Text = " Quo. Valid Till"
        '
        'CMDDOWNLOAD
        '
        Me.CMDDOWNLOAD.BackColor = System.Drawing.Color.Transparent
        Me.CMDDOWNLOAD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDDOWNLOAD.FlatAppearance.BorderSize = 0
        Me.CMDDOWNLOAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDDOWNLOAD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDOWNLOAD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDDOWNLOAD.Image = Global.TexPro_V1.My.Resources.Resources.download
        Me.CMDDOWNLOAD.Location = New System.Drawing.Point(476, 28)
        Me.CMDDOWNLOAD.Name = "CMDDOWNLOAD"
        Me.CMDDOWNLOAD.Size = New System.Drawing.Size(75, 27)
        Me.CMDDOWNLOAD.TabIndex = 527
        Me.CMDDOWNLOAD.UseVisualStyleBackColor = False
        Me.CMDDOWNLOAD.Visible = False
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(240, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(45, 22)
        Me.tstxtbillno.TabIndex = 526
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.tooldelete, Me.toolStripSeparator, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(994, 25)
        Me.ToolStrip1.TabIndex = 433
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
        Me.toolprevious.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolprevious.Image = Global.TexPro_V1.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(73, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolnext.Image = Global.TexPro_V1.My.Resources.Resources.POINT04
        Me.toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolnext.Name = "toolnext"
        Me.toolnext.Size = New System.Drawing.Size(51, 22)
        Me.toolnext.Text = "Next"
        Me.toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.CMBQUALITY)
        Me.GroupBox3.Controls.Add(Me.cmbcolor)
        Me.GroupBox3.Controls.Add(Me.TXTPICK)
        Me.GroupBox3.Controls.Add(Me.TXTREED)
        Me.GroupBox3.Controls.Add(Me.cmbitemname)
        Me.GroupBox3.Controls.Add(Me.cmbqtyunit)
        Me.GroupBox3.Controls.Add(Me.gridQuotation)
        Me.GroupBox3.Controls.Add(Me.txtsrno)
        Me.GroupBox3.Controls.Add(Me.txtqty)
        Me.GroupBox3.Controls.Add(Me.txtgridremarks)
        Me.GroupBox3.Controls.Add(Me.txtamount)
        Me.GroupBox3.Controls.Add(Me.txtrate)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(17, 174)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(960, 275)
        Me.GroupBox3.TabIndex = 432
        Me.GroupBox3.TabStop = False
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(384, 12)
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(100, 22)
        Me.CMBQUALITY.TabIndex = 15
        '
        'cmbcolor
        '
        Me.cmbcolor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcolor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcolor.FormattingEnabled = True
        Me.cmbcolor.Location = New System.Drawing.Point(584, 12)
        Me.cmbcolor.Name = "cmbcolor"
        Me.cmbcolor.Size = New System.Drawing.Size(80, 22)
        Me.cmbcolor.TabIndex = 7
        '
        'TXTPICK
        '
        Me.TXTPICK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPICK.Location = New System.Drawing.Point(534, 12)
        Me.TXTPICK.Name = "TXTPICK"
        Me.TXTPICK.Size = New System.Drawing.Size(50, 22)
        Me.TXTPICK.TabIndex = 4
        Me.TXTPICK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTREED
        '
        Me.TXTREED.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREED.Location = New System.Drawing.Point(484, 12)
        Me.TXTREED.Name = "TXTREED"
        Me.TXTREED.Size = New System.Drawing.Size(50, 22)
        Me.TXTREED.TabIndex = 3
        Me.TXTREED.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbitemname
        '
        Me.cmbitemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbitemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbitemname.DropDownWidth = 400
        Me.cmbitemname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbitemname.FormattingEnabled = True
        Me.cmbitemname.Location = New System.Drawing.Point(34, 12)
        Me.cmbitemname.Name = "cmbitemname"
        Me.cmbitemname.Size = New System.Drawing.Size(200, 22)
        Me.cmbitemname.TabIndex = 1
        '
        'cmbqtyunit
        '
        Me.cmbqtyunit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbqtyunit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbqtyunit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbqtyunit.FormattingEnabled = True
        Me.cmbqtyunit.Location = New System.Drawing.Point(724, 12)
        Me.cmbqtyunit.Name = "cmbqtyunit"
        Me.cmbqtyunit.Size = New System.Drawing.Size(60, 22)
        Me.cmbqtyunit.TabIndex = 9
        '
        'gridQuotation
        '
        Me.gridQuotation.AllowUserToAddRows = False
        Me.gridQuotation.AllowUserToDeleteRows = False
        Me.gridQuotation.AllowUserToResizeColumns = False
        Me.gridQuotation.AllowUserToResizeRows = False
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Black
        Me.gridQuotation.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle12
        Me.gridQuotation.BackgroundColor = System.Drawing.Color.White
        Me.gridQuotation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridQuotation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridQuotation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.gridQuotation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridQuotation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gsrno, Me.gitemname, Me.gdesc, Me.GQUALITY, Me.GREED, Me.GPICK, Me.gcolor, Me.gQty, Me.gqtyunit, Me.grate, Me.gamt, Me.grecdqty, Me.GDONE, Me.GPRNO, Me.gprgridsrno})
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridQuotation.DefaultCellStyle = DataGridViewCellStyle21
        Me.gridQuotation.GridColor = System.Drawing.SystemColors.Control
        Me.gridQuotation.Location = New System.Drawing.Point(4, 34)
        Me.gridQuotation.MultiSelect = False
        Me.gridQuotation.Name = "gridQuotation"
        Me.gridQuotation.RowHeadersVisible = False
        Me.gridQuotation.RowHeadersWidth = 30
        Me.gridQuotation.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.White
        Me.gridQuotation.RowsDefaultCellStyle = DataGridViewCellStyle22
        Me.gridQuotation.RowTemplate.Height = 20
        Me.gridQuotation.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridQuotation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridQuotation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridQuotation.Size = New System.Drawing.Size(952, 235)
        Me.gridQuotation.TabIndex = 14
        Me.gridQuotation.TabStop = False
        '
        'txtsrno
        '
        Me.txtsrno.BackColor = System.Drawing.Color.White
        Me.txtsrno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsrno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtsrno.Location = New System.Drawing.Point(4, 12)
        Me.txtsrno.Name = "txtsrno"
        Me.txtsrno.ReadOnly = True
        Me.txtsrno.Size = New System.Drawing.Size(30, 22)
        Me.txtsrno.TabIndex = 0
        '
        'txtqty
        '
        Me.txtqty.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqty.Location = New System.Drawing.Point(664, 12)
        Me.txtqty.Name = "txtqty"
        Me.txtqty.Size = New System.Drawing.Size(60, 22)
        Me.txtqty.TabIndex = 8
        Me.txtqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtgridremarks
        '
        Me.txtgridremarks.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtgridremarks.Location = New System.Drawing.Point(234, 12)
        Me.txtgridremarks.Name = "txtgridremarks"
        Me.txtgridremarks.Size = New System.Drawing.Size(150, 22)
        Me.txtgridremarks.TabIndex = 2
        '
        'txtamount
        '
        Me.txtamount.BackColor = System.Drawing.Color.White
        Me.txtamount.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtamount.Location = New System.Drawing.Point(844, 12)
        Me.txtamount.Name = "txtamount"
        Me.txtamount.ReadOnly = True
        Me.txtamount.Size = New System.Drawing.Size(80, 22)
        Me.txtamount.TabIndex = 11
        Me.txtamount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtrate
        '
        Me.txtrate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrate.Location = New System.Drawing.Point(784, 12)
        Me.txtrate.Name = "txtrate"
        Me.txtrate.Size = New System.Drawing.Size(60, 22)
        Me.txtrate.TabIndex = 10
        Me.txtrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(27, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 14)
        Me.Label6.TabIndex = 431
        Me.Label6.Text = "Supplier Name"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(819, 452)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 14)
        Me.Label9.TabIndex = 430
        Me.Label9.Text = "Total Amt."
        '
        'dtppartyref
        '
        Me.dtppartyref.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtppartyref.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtppartyref.Location = New System.Drawing.Point(373, 112)
        Me.dtppartyref.Name = "dtppartyref"
        Me.dtppartyref.Size = New System.Drawing.Size(82, 22)
        Me.dtppartyref.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(281, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 14)
        Me.Label8.TabIndex = 428
        Me.Label8.Text = "Party Quo. Date"
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = Global.TexPro_V1.My.Resources.Resources.lock_copy
        Me.PBlock.Location = New System.Drawing.Point(341, 484)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(68, 72)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 427
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(336, 452)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(82, 29)
        Me.lbllocked.TabIndex = 420
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmddelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Image = Global.TexPro_V1.My.Resources.Resources.Delete
        Me.cmddelete.Location = New System.Drawing.Point(503, 510)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(72, 24)
        Me.cmddelete.TabIndex = 9
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdselectPR
        '
        Me.cmdselectPR.BackColor = System.Drawing.Color.Transparent
        Me.cmdselectPR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdselectPR.FlatAppearance.BorderSize = 0
        Me.cmdselectPR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdselectPR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdselectPR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdselectPR.Image = Global.TexPro_V1.My.Resources.Resources.selectPR
        Me.cmdselectPR.Location = New System.Drawing.Point(425, 477)
        Me.cmdselectPR.Name = "cmdselectPR"
        Me.cmdselectPR.Size = New System.Drawing.Size(72, 27)
        Me.cmdselectPR.TabIndex = 6
        Me.cmdselectPR.UseVisualStyleBackColor = False
        '
        'lbltotalamt
        '
        Me.lbltotalamt.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalamt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalamt.ForeColor = System.Drawing.Color.Black
        Me.lbltotalamt.Location = New System.Drawing.Point(878, 452)
        Me.lbltotalamt.Name = "lbltotalamt"
        Me.lbltotalamt.Size = New System.Drawing.Size(63, 14)
        Me.lbltotalamt.TabIndex = 418
        Me.lbltotalamt.Text = "0"
        Me.lbltotalamt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdremove
        '
        Me.cmdremove.BackColor = System.Drawing.Color.Transparent
        Me.cmdremove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdremove.FlatAppearance.BorderSize = 0
        Me.cmdremove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdremove.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdremove.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdremove.Image = Global.TexPro_V1.My.Resources.Resources.Remove
        Me.cmdremove.Location = New System.Drawing.Point(511, 104)
        Me.cmdremove.Name = "cmdremove"
        Me.cmdremove.Size = New System.Drawing.Size(75, 27)
        Me.cmdremove.TabIndex = 13
        Me.cmdremove.UseVisualStyleBackColor = False
        '
        'cmdupload
        '
        Me.cmdupload.BackColor = System.Drawing.Color.Transparent
        Me.cmdupload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdupload.FlatAppearance.BorderSize = 0
        Me.cmdupload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdupload.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdupload.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdupload.Image = Global.TexPro_V1.My.Resources.Resources.upload
        Me.cmdupload.Location = New System.Drawing.Point(511, 72)
        Me.cmdupload.Name = "cmdupload"
        Me.cmdupload.Size = New System.Drawing.Size(75, 27)
        Me.cmdupload.TabIndex = 12
        Me.cmdupload.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(522, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 14)
        Me.Label4.TabIndex = 417
        Me.Label4.Text = "Soft Copy"
        '
        'pbsoftcopy
        '
        Me.pbsoftcopy.BackColor = System.Drawing.Color.Transparent
        Me.pbsoftcopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbsoftcopy.ErrorImage = Nothing
        Me.pbsoftcopy.InitialImage = Nothing
        Me.pbsoftcopy.Location = New System.Drawing.Point(592, 64)
        Me.pbsoftcopy.Name = "pbsoftcopy"
        Me.pbsoftcopy.Size = New System.Drawing.Size(107, 109)
        Me.pbsoftcopy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbsoftcopy.TabIndex = 416
        Me.pbsoftcopy.TabStop = False
        '
        'quotationdate
        '
        Me.quotationdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quotationdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.quotationdate.Location = New System.Drawing.Point(116, 112)
        Me.quotationdate.Name = "quotationdate"
        Me.quotationdate.Size = New System.Drawing.Size(82, 22)
        Me.quotationdate.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(82, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 14)
        Me.Label7.TabIndex = 415
        Me.Label7.Text = "Date"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.txtadd)
        Me.GroupBox4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(751, 85)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(226, 88)
        Me.GroupBox4.TabIndex = 413
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Address"
        '
        'txtadd
        '
        Me.txtadd.ForeColor = System.Drawing.Color.DimGray
        Me.txtadd.Location = New System.Drawing.Point(6, 14)
        Me.txtadd.Multiline = True
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(214, 69)
        Me.txtadd.TabIndex = 10
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(116, 84)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(187, 22)
        Me.cmbname.TabIndex = 0
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(366, 5)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 402
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Black
        Me.GroupBox7.ForeColor = System.Drawing.Color.Black
        Me.GroupBox7.Location = New System.Drawing.Point(676, 469)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(301, 1)
        Me.GroupBox7.TabIndex = 408
        Me.GroupBox7.TabStop = False
        '
        'cmdedit
        '
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdedit.Location = New System.Drawing.Point(293, 0)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(72, 23)
        Me.cmdedit.TabIndex = 401
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = True
        Me.cmdedit.Visible = False
        '
        'txtref
        '
        Me.txtref.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtref.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtref.Location = New System.Drawing.Point(116, 139)
        Me.txtref.Name = "txtref"
        Me.txtref.Size = New System.Drawing.Size(82, 22)
        Me.txtref.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(32, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 14)
        Me.Label1.TabIndex = 410
        Me.Label1.Text = "Party Quo. No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 29)
        Me.Label2.TabIndex = 314
        Me.Label2.Text = "Quotation"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(17, 464)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(308, 76)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(5, 17)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(297, 54)
        Me.txtremarks.TabIndex = 0
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdclear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdclear.Image = Global.TexPro_V1.My.Resources.Resources.clear
        Me.cmdclear.Location = New System.Drawing.Point(576, 476)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(72, 27)
        Me.cmdclear.TabIndex = 8
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(675, 452)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 14)
        Me.Label10.TabIndex = 407
        Me.Label10.Text = "Total Qty"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.TexPro_V1.My.Resources.Resources.Save
        Me.cmdok.Location = New System.Drawing.Point(503, 479)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(72, 25)
        Me.cmdok.TabIndex = 7
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'txtPRNO
        '
        Me.txtPRNO.BackColor = System.Drawing.Color.White
        Me.txtPRNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPRNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPRNO.Location = New System.Drawing.Point(373, 84)
        Me.txtPRNO.Name = "txtPRNO"
        Me.txtPRNO.Size = New System.Drawing.Size(82, 22)
        Me.txtPRNO.TabIndex = 2
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.TexPro_V1.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(577, 510)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 24)
        Me.cmdexit.TabIndex = 10
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lbltotalqty
        '
        Me.lbltotalqty.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalqty.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalqty.ForeColor = System.Drawing.Color.Black
        Me.lbltotalqty.Location = New System.Drawing.Point(715, 452)
        Me.lbltotalqty.Name = "lbltotalqty"
        Me.lbltotalqty.Size = New System.Drawing.Size(63, 14)
        Me.lbltotalqty.TabIndex = 406
        Me.lbltotalqty.Text = "0"
        Me.lbltotalqty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(324, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 14)
        Me.Label3.TabIndex = 398
        Me.Label3.Text = "P.R. No."
        '
        'txtquotation
        '
        Me.txtquotation.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtquotation.Location = New System.Drawing.Point(889, 63)
        Me.txtquotation.Name = "txtquotation"
        Me.txtquotation.Size = New System.Drawing.Size(82, 22)
        Me.txtquotation.TabIndex = 399
        Me.txtquotation.TabStop = False
        Me.txtquotation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Green
        Me.Label20.Location = New System.Drawing.Point(673, 480)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(171, 60)
        Me.Label20.TabIndex = 403
        Me.Label20.Text = "Enter Quotation Details :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(This detail would be dragged" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in Purchase Order) "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(804, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 14)
        Me.Label5.TabIndex = 400
        Me.Label5.Text = "Quotation No."
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
        'gsrno
        '
        Me.gsrno.HeaderText = "Sr."
        Me.gsrno.Name = "gsrno"
        Me.gsrno.ReadOnly = True
        Me.gsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gsrno.Width = 30
        '
        'gitemname
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.gitemname.DefaultCellStyle = DataGridViewCellStyle14
        Me.gitemname.HeaderText = "Item Name"
        Me.gitemname.Name = "gitemname"
        Me.gitemname.ReadOnly = True
        Me.gitemname.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gitemname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gitemname.Width = 200
        '
        'gdesc
        '
        Me.gdesc.HeaderText = "Description"
        Me.gdesc.Name = "gdesc"
        Me.gdesc.ReadOnly = True
        Me.gdesc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gdesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gdesc.Width = 150
        '
        'GQUALITY
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GQUALITY.DefaultCellStyle = DataGridViewCellStyle15
        Me.GQUALITY.HeaderText = "Quality"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.ReadOnly = True
        Me.GQUALITY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GQUALITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GREED
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GREED.DefaultCellStyle = DataGridViewCellStyle16
        Me.GREED.HeaderText = "Reed"
        Me.GREED.Name = "GREED"
        Me.GREED.ReadOnly = True
        Me.GREED.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GREED.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GREED.Width = 50
        '
        'GPICK
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GPICK.DefaultCellStyle = DataGridViewCellStyle17
        Me.GPICK.HeaderText = "Pick"
        Me.GPICK.Name = "GPICK"
        Me.GPICK.ReadOnly = True
        Me.GPICK.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPICK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GPICK.Width = 50
        '
        'gcolor
        '
        Me.gcolor.HeaderText = "Color"
        Me.gcolor.Name = "gcolor"
        Me.gcolor.ReadOnly = True
        Me.gcolor.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gcolor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gcolor.Width = 80
        '
        'gQty
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.NullValue = Nothing
        Me.gQty.DefaultCellStyle = DataGridViewCellStyle18
        Me.gQty.HeaderText = "Qty."
        Me.gQty.Name = "gQty"
        Me.gQty.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gQty.Width = 60
        '
        'gqtyunit
        '
        Me.gqtyunit.HeaderText = "Qty Unit"
        Me.gqtyunit.Name = "gqtyunit"
        Me.gqtyunit.ReadOnly = True
        Me.gqtyunit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gqtyunit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gqtyunit.Width = 60
        '
        'grate
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle19.NullValue = Nothing
        Me.grate.DefaultCellStyle = DataGridViewCellStyle19
        Me.grate.HeaderText = "Rate"
        Me.grate.Name = "grate"
        Me.grate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.grate.Width = 60
        '
        'gamt
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Calibri", 8.25!)
        DataGridViewCellStyle20.Format = "N2"
        Me.gamt.DefaultCellStyle = DataGridViewCellStyle20
        Me.gamt.HeaderText = "Amt"
        Me.gamt.Name = "gamt"
        Me.gamt.ReadOnly = True
        Me.gamt.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gamt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gamt.Width = 80
        '
        'grecdqty
        '
        Me.grecdqty.HeaderText = "Recd. Qty"
        Me.grecdqty.Name = "grecdqty"
        Me.grecdqty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.grecdqty.Visible = False
        '
        'GDONE
        '
        Me.GDONE.HeaderText = "DONE"
        Me.GDONE.Name = "GDONE"
        Me.GDONE.Visible = False
        '
        'GPRNO
        '
        Me.GPRNO.HeaderText = "PRNO"
        Me.GPRNO.Name = "GPRNO"
        Me.GPRNO.Visible = False
        '
        'gprgridsrno
        '
        Me.gprgridsrno.HeaderText = "PR GRIDSRNO"
        Me.gprgridsrno.Name = "gprgridsrno"
        Me.gprgridsrno.Visible = False
        '
        'PurchaseQuotation
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(994, 569)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PurchaseQuotation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Purchase Quotation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.gridQuotation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbsoftcopy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDVIEW As System.Windows.Forms.Button
    Friend WithEvents txtuploadpr As System.Windows.Forms.TextBox
    Friend WithEvents txtimgpath As System.Windows.Forms.TextBox
    Friend WithEvents cmduploadPR As System.Windows.Forms.Button
    Friend WithEvents dtvalidtill As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CMDDOWNLOAD As System.Windows.Forms.Button
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tooldelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbcolor As System.Windows.Forms.ComboBox
    Friend WithEvents TXTPICK As System.Windows.Forms.TextBox
    Friend WithEvents TXTREED As System.Windows.Forms.TextBox
    Friend WithEvents cmbitemname As System.Windows.Forms.ComboBox
    Friend WithEvents cmbqtyunit As System.Windows.Forms.ComboBox
    Friend WithEvents gridQuotation As System.Windows.Forms.DataGridView
    Friend WithEvents txtsrno As System.Windows.Forms.TextBox
    Friend WithEvents txtqty As System.Windows.Forms.TextBox
    Friend WithEvents txtgridremarks As System.Windows.Forms.TextBox
    Friend WithEvents txtamount As System.Windows.Forms.TextBox
    Friend WithEvents txtrate As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtppartyref As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PBlock As System.Windows.Forms.PictureBox
    Friend WithEvents lbllocked As System.Windows.Forms.Label
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdselectPR As System.Windows.Forms.Button
    Friend WithEvents lbltotalamt As System.Windows.Forms.Label
    Friend WithEvents cmdremove As System.Windows.Forms.Button
    Friend WithEvents cmdupload As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pbsoftcopy As System.Windows.Forms.PictureBox
    Friend WithEvents quotationdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents txtref As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents txtPRNO As System.Windows.Forms.TextBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lbltotalqty As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtquotation As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents CMBQUALITY As System.Windows.Forms.ComboBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents gsrno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gitemname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gdesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GQUALITY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GREED As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPICK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gcolor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gqtyunit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gamt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grecdqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDONE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gprgridsrno As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
