<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProformaInvoice
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProformaInvoice))
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMBAGENT = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTBALENO = New System.Windows.Forms.TextBox()
        Me.chkprintsingle = New System.Windows.Forms.CheckBox()
        Me.CMBCONSIGNEE = New System.Windows.Forms.ComboBox()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.txtdeliveryadd = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTGDNNO = New System.Windows.Forms.TextBox()
        Me.lbltotalmtrs = New System.Windows.Forms.Label()
        Me.TXTREFNO = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.podate = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbformno = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbcity = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtpono = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.INVOICEdate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTINVOICENO = New System.Windows.Forms.TextBox()
        Me.cmdselectOrder = New System.Windows.Forms.Button()
        Me.lbllocked = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbltotalamt = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.lbltotalqty = New System.Windows.Forms.Label()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.TOOLDELETE = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.tbitem = New System.Windows.Forms.TabPage()
        Me.gridinvoice = New System.Windows.Forms.DataGridView()
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbaleno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gfbno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GPIECETYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMERCHANT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GCUT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gQuality = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GQTY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GMTRS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gwt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gPer = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.grate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gamt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GDONE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ggdngridsrno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbtransport = New System.Windows.Forms.TabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txttransremarks = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.lrdate = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbtrans = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txttransref = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtlrno = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TXTTRANSADD = New System.Windows.Forms.TextBox()
        Me.txtinwordhse = New System.Windows.Forms.TextBox()
        Me.txtinwordedu = New System.Windows.Forms.TextBox()
        Me.txtinwordexcise = New System.Windows.Forms.TextBox()
        Me.PBlock = New System.Windows.Forms.PictureBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtinwords = New System.Windows.Forms.TextBox()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.chkchange = New System.Windows.Forms.CheckBox()
        Me.cmdEXIT = New System.Windows.Forms.Button()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.tbitem.SuspendLayout()
        CType(Me.gridinvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbtransport.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBAGENT)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.TXTBALENO)
        Me.BlendPanel1.Controls.Add(Me.chkprintsingle)
        Me.BlendPanel1.Controls.Add(Me.CMBCONSIGNEE)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.txtdeliveryadd)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTGDNNO)
        Me.BlendPanel1.Controls.Add(Me.lbltotalmtrs)
        Me.BlendPanel1.Controls.Add(Me.TXTREFNO)
        Me.BlendPanel1.Controls.Add(Me.Label26)
        Me.BlendPanel1.Controls.Add(Me.podate)
        Me.BlendPanel1.Controls.Add(Me.Label20)
        Me.BlendPanel1.Controls.Add(Me.cmbformno)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.cmbcity)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.Label18)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.txtpono)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.INVOICEdate)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTINVOICENO)
        Me.BlendPanel1.Controls.Add(Me.cmdselectOrder)
        Me.BlendPanel1.Controls.Add(Me.lbllocked)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.Label13)
        Me.BlendPanel1.Controls.Add(Me.lbltotalamt)
        Me.BlendPanel1.Controls.Add(Me.Label37)
        Me.BlendPanel1.Controls.Add(Me.lbltotalqty)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.TabControl2)
        Me.BlendPanel1.Controls.Add(Me.TXTTRANSADD)
        Me.BlendPanel1.Controls.Add(Me.txtinwordhse)
        Me.BlendPanel1.Controls.Add(Me.txtinwordedu)
        Me.BlendPanel1.Controls.Add(Me.txtinwordexcise)
        Me.BlendPanel1.Controls.Add(Me.PBlock)
        Me.BlendPanel1.Controls.Add(Me.Label39)
        Me.BlendPanel1.Controls.Add(Me.txtinwords)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.cmdOK)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.cmdEXIT)
        Me.BlendPanel1.Controls.Add(Me.ShapeContainer1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1004, 562)
        Me.BlendPanel1.TabIndex = 3
        '
        'CMBAGENT
        '
        Me.CMBAGENT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBAGENT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBAGENT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBAGENT.FormattingEnabled = True
        Me.CMBAGENT.Location = New System.Drawing.Point(90, 111)
        Me.CMBAGENT.MaxDropDownItems = 14
        Me.CMBAGENT.Name = "CMBAGENT"
        Me.CMBAGENT.Size = New System.Drawing.Size(266, 22)
        Me.CMBAGENT.TabIndex = 4
        Me.CMBAGENT.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(317, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 14)
        Me.Label5.TabIndex = 721
        Me.Label5.Text = "Bale No"
        '
        'TXTBALENO
        '
        Me.TXTBALENO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBALENO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBALENO.Location = New System.Drawing.Point(369, 1)
        Me.TXTBALENO.Name = "TXTBALENO"
        Me.TXTBALENO.Size = New System.Drawing.Size(57, 22)
        Me.TXTBALENO.TabIndex = 720
        Me.TXTBALENO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkprintsingle
        '
        Me.chkprintsingle.AutoSize = True
        Me.chkprintsingle.BackColor = System.Drawing.Color.Transparent
        Me.chkprintsingle.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkprintsingle.Location = New System.Drawing.Point(639, 141)
        Me.chkprintsingle.Name = "chkprintsingle"
        Me.chkprintsingle.Size = New System.Drawing.Size(88, 18)
        Me.chkprintsingle.TabIndex = 737
        Me.chkprintsingle.Text = "Print Single"
        Me.chkprintsingle.UseVisualStyleBackColor = False
        '
        'CMBCONSIGNEE
        '
        Me.CMBCONSIGNEE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCONSIGNEE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCONSIGNEE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCONSIGNEE.FormattingEnabled = True
        Me.CMBCONSIGNEE.Items.AddRange(New Object() {""})
        Me.CMBCONSIGNEE.Location = New System.Drawing.Point(90, 84)
        Me.CMBCONSIGNEE.Name = "CMBCONSIGNEE"
        Me.CMBCONSIGNEE.Size = New System.Drawing.Size(266, 22)
        Me.CMBCONSIGNEE.TabIndex = 3
        '
        'txtadd
        '
        Me.txtadd.ForeColor = System.Drawing.Color.DimGray
        Me.txtadd.Location = New System.Drawing.Point(678, 29)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(77, 22)
        Me.txtadd.TabIndex = 736
        Me.txtadd.TabStop = False
        Me.txtadd.Visible = False
        '
        'txtdeliveryadd
        '
        Me.txtdeliveryadd.ForeColor = System.Drawing.Color.DimGray
        Me.txtdeliveryadd.Location = New System.Drawing.Point(678, 29)
        Me.txtdeliveryadd.Name = "txtdeliveryadd"
        Me.txtdeliveryadd.Size = New System.Drawing.Size(77, 22)
        Me.txtdeliveryadd.TabIndex = 735
        Me.txtdeliveryadd.TabStop = False
        Me.txtdeliveryadd.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(601, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 14)
        Me.Label2.TabIndex = 734
        Me.Label2.Text = "Despatch No"
        Me.Label2.Visible = False
        '
        'TXTGDNNO
        '
        Me.TXTGDNNO.BackColor = System.Drawing.Color.Linen
        Me.TXTGDNNO.Enabled = False
        Me.TXTGDNNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGDNNO.Location = New System.Drawing.Point(678, 58)
        Me.TXTGDNNO.Name = "TXTGDNNO"
        Me.TXTGDNNO.ReadOnly = True
        Me.TXTGDNNO.Size = New System.Drawing.Size(77, 22)
        Me.TXTGDNNO.TabIndex = 4
        Me.TXTGDNNO.TabStop = False
        Me.TXTGDNNO.Visible = False
        '
        'lbltotalmtrs
        '
        Me.lbltotalmtrs.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalmtrs.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalmtrs.ForeColor = System.Drawing.Color.Black
        Me.lbltotalmtrs.Location = New System.Drawing.Point(737, 438)
        Me.lbltotalmtrs.Name = "lbltotalmtrs"
        Me.lbltotalmtrs.Size = New System.Drawing.Size(63, 15)
        Me.lbltotalmtrs.TabIndex = 723
        Me.lbltotalmtrs.Text = "0"
        Me.lbltotalmtrs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTREFNO
        '
        Me.TXTREFNO.BackColor = System.Drawing.Color.Linen
        Me.TXTREFNO.Enabled = False
        Me.TXTREFNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTREFNO.Location = New System.Drawing.Point(837, 84)
        Me.TXTREFNO.Name = "TXTREFNO"
        Me.TXTREFNO.ReadOnly = True
        Me.TXTREFNO.Size = New System.Drawing.Size(84, 22)
        Me.TXTREFNO.TabIndex = 8
        Me.TXTREFNO.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(792, 88)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(42, 14)
        Me.Label26.TabIndex = 722
        Me.Label26.Text = "SO No."
        '
        'podate
        '
        Me.podate.Enabled = False
        Me.podate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.podate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.podate.Location = New System.Drawing.Point(837, 111)
        Me.podate.Name = "podate"
        Me.podate.Size = New System.Drawing.Size(84, 22)
        Me.podate.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(781, 115)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(50, 14)
        Me.Label20.TabIndex = 720
        Me.Label20.Text = "PO Date"
        '
        'cmbformno
        '
        Me.cmbformno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbformno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbformno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbformno.FormattingEnabled = True
        Me.cmbformno.Location = New System.Drawing.Point(425, 111)
        Me.cmbformno.MaxDropDownItems = 14
        Me.cmbformno.Name = "cmbformno"
        Me.cmbformno.Size = New System.Drawing.Size(84, 22)
        Me.cmbformno.TabIndex = 6
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(368, 115)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 14)
        Me.Label16.TabIndex = 712
        Me.Label16.Text = "Form No."
        '
        'cmbcity
        '
        Me.cmbcity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcity.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbcity.FormattingEnabled = True
        Me.cmbcity.Location = New System.Drawing.Point(425, 84)
        Me.cmbcity.MaxDropDownItems = 14
        Me.cmbcity.Name = "cmbcity"
        Me.cmbcity.Size = New System.Drawing.Size(147, 22)
        Me.cmbcity.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(397, 88)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 14)
        Me.Label10.TabIndex = 708
        Me.Label10.Text = "City"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(24, 88)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 14)
        Me.Label18.TabIndex = 706
        Me.Label18.Text = "Consignee"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(50, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 14)
        Me.Label8.TabIndex = 704
        Me.Label8.Text = "Agent"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(42, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 14)
        Me.Label9.TabIndex = 703
        Me.Label9.Text = "Buyer's"
        '
        'txtpono
        '
        Me.txtpono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpono.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpono.Location = New System.Drawing.Point(678, 111)
        Me.txtpono.Name = "txtpono"
        Me.txtpono.Size = New System.Drawing.Size(77, 22)
        Me.txtpono.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(603, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 14)
        Me.Label4.TabIndex = 702
        Me.Label4.Text = "Eway Bill No"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Enabled = False
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Items.AddRange(New Object() {""})
        Me.cmbname.Location = New System.Drawing.Point(90, 58)
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(266, 22)
        Me.cmbname.TabIndex = 1
        '
        'INVOICEdate
        '
        Me.INVOICEdate.CustomFormat = "dd/MM/yyyy"
        Me.INVOICEdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INVOICEdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.INVOICEdate.Location = New System.Drawing.Point(678, 84)
        Me.INVOICEdate.Name = "INVOICEdate"
        Me.INVOICEdate.Size = New System.Drawing.Size(77, 22)
        Me.INVOICEdate.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(644, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 14)
        Me.Label1.TabIndex = 700
        Me.Label1.Text = "Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(794, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 14)
        Me.Label3.TabIndex = 701
        Me.Label3.Text = "Sr No."
        '
        'TXTINVOICENO
        '
        Me.TXTINVOICENO.BackColor = System.Drawing.Color.Linen
        Me.TXTINVOICENO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTINVOICENO.Location = New System.Drawing.Point(837, 58)
        Me.TXTINVOICENO.Name = "TXTINVOICENO"
        Me.TXTINVOICENO.ReadOnly = True
        Me.TXTINVOICENO.Size = New System.Drawing.Size(84, 22)
        Me.TXTINVOICENO.TabIndex = 7
        Me.TXTINVOICENO.TabStop = False
        '
        'cmdselectOrder
        '
        Me.cmdselectOrder.BackColor = System.Drawing.Color.Transparent
        Me.cmdselectOrder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdselectOrder.FlatAppearance.BorderSize = 0
        Me.cmdselectOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdselectOrder.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdselectOrder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdselectOrder.Image = Global.TexPro_V1.My.Resources.Resources.select_gdn
        Me.cmdselectOrder.Location = New System.Drawing.Point(604, 474)
        Me.cmdselectOrder.Name = "cmdselectOrder"
        Me.cmdselectOrder.Size = New System.Drawing.Size(78, 27)
        Me.cmdselectOrder.TabIndex = 2
        Me.cmdselectOrder.UseVisualStyleBackColor = False
        '
        'lbllocked
        '
        Me.lbllocked.AutoSize = True
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocked.ForeColor = System.Drawing.Color.Red
        Me.lbllocked.Location = New System.Drawing.Point(452, 461)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(57, 19)
        Me.lbllocked.TabIndex = 569
        Me.lbllocked.Text = "Locked"
        Me.lbllocked.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(332, 145)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 14)
        Me.Label7.TabIndex = 562
        Me.Label7.Text = "Locked"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(308, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 16)
        Me.Label6.TabIndex = 561
        Me.Label6.Text = "   "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(20, 29)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 26)
        Me.Label13.TabIndex = 679
        Me.Label13.Text = "Proforma"
        '
        'lbltotalamt
        '
        Me.lbltotalamt.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalamt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalamt.ForeColor = System.Drawing.Color.Black
        Me.lbltotalamt.Location = New System.Drawing.Point(872, 439)
        Me.lbltotalamt.Name = "lbltotalamt"
        Me.lbltotalamt.Size = New System.Drawing.Size(63, 15)
        Me.lbltotalamt.TabIndex = 673
        Me.lbltotalamt.Text = "0"
        Me.lbltotalamt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(650, 439)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(31, 14)
        Me.Label37.TabIndex = 672
        Me.Label37.Text = "Total"
        '
        'lbltotalqty
        '
        Me.lbltotalqty.BackColor = System.Drawing.Color.Transparent
        Me.lbltotalqty.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalqty.ForeColor = System.Drawing.Color.Black
        Me.lbltotalqty.Location = New System.Drawing.Point(674, 439)
        Me.lbltotalqty.Name = "lbltotalqty"
        Me.lbltotalqty.Size = New System.Drawing.Size(63, 15)
        Me.lbltotalqty.TabIndex = 671
        Me.lbltotalqty.Text = "0"
        Me.lbltotalqty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(238, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(45, 22)
        Me.tstxtbillno.TabIndex = 14
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.PrintToolStripButton, Me.TOOLDELETE, Me.ToolStripSeparator2, Me.Toolprevious, Me.toolnext, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1004, 25)
        Me.ToolStrip1.TabIndex = 5
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
        'TOOLDELETE
        '
        Me.TOOLDELETE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLDELETE.Image = CType(resources.GetObject("TOOLDELETE.Image"), System.Drawing.Image)
        Me.TOOLDELETE.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLDELETE.Name = "TOOLDELETE"
        Me.TOOLDELETE.Size = New System.Drawing.Size(23, 22)
        Me.TOOLDELETE.Text = "&Delete"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Toolprevious
        '
        Me.Toolprevious.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Toolprevious.Image = CType(resources.GetObject("Toolprevious.Image"), System.Drawing.Image)
        Me.Toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Toolprevious.Name = "Toolprevious"
        Me.Toolprevious.Size = New System.Drawing.Size(73, 22)
        Me.Toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolnext.Image = CType(resources.GetObject("toolnext.Image"), System.Drawing.Image)
        Me.toolnext.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolnext.Name = "toolnext"
        Me.toolnext.Size = New System.Drawing.Size(51, 22)
        Me.toolnext.Text = "Next"
        Me.toolnext.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.tbitem)
        Me.TabControl2.Controls.Add(Me.tbtransport)
        Me.TabControl2.Location = New System.Drawing.Point(12, 145)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(980, 292)
        Me.TabControl2.TabIndex = 9
        '
        'tbitem
        '
        Me.tbitem.Controls.Add(Me.gridinvoice)
        Me.tbitem.Location = New System.Drawing.Point(4, 23)
        Me.tbitem.Name = "tbitem"
        Me.tbitem.Padding = New System.Windows.Forms.Padding(3)
        Me.tbitem.Size = New System.Drawing.Size(972, 265)
        Me.tbitem.TabIndex = 0
        Me.tbitem.Text = "Item Details"
        Me.tbitem.UseVisualStyleBackColor = True
        '
        'gridinvoice
        '
        Me.gridinvoice.AllowUserToAddRows = False
        Me.gridinvoice.AllowUserToDeleteRows = False
        Me.gridinvoice.AllowUserToResizeColumns = False
        Me.gridinvoice.AllowUserToResizeRows = False
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Black
        Me.gridinvoice.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle12
        Me.gridinvoice.BackgroundColor = System.Drawing.Color.White
        Me.gridinvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridinvoice.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridinvoice.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.gridinvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridinvoice.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.gbaleno, Me.gfbno, Me.GPIECETYPE, Me.GMERCHANT, Me.GCUT, Me.gQuality, Me.GQTY, Me.GMTRS, Me.gwt, Me.gPer, Me.grate, Me.gamt, Me.GDONE, Me.ggdngridsrno})
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridinvoice.DefaultCellStyle = DataGridViewCellStyle21
        Me.gridinvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridinvoice.GridColor = System.Drawing.SystemColors.Control
        Me.gridinvoice.Location = New System.Drawing.Point(3, 3)
        Me.gridinvoice.MultiSelect = False
        Me.gridinvoice.Name = "gridinvoice"
        Me.gridinvoice.RowHeadersVisible = False
        Me.gridinvoice.RowHeadersWidth = 30
        Me.gridinvoice.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.White
        Me.gridinvoice.RowsDefaultCellStyle = DataGridViewCellStyle22
        Me.gridinvoice.RowTemplate.Height = 20
        Me.gridinvoice.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridinvoice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridinvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridinvoice.Size = New System.Drawing.Size(966, 259)
        Me.gridinvoice.TabIndex = 0
        Me.gridinvoice.TabStop = False
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr."
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 30
        '
        'gbaleno
        '
        Me.gbaleno.HeaderText = "Bale No."
        Me.gbaleno.Name = "gbaleno"
        Me.gbaleno.ReadOnly = True
        Me.gbaleno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gbaleno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gbaleno.Width = 70
        '
        'gfbno
        '
        Me.gfbno.HeaderText = "FB No."
        Me.gfbno.Name = "gfbno"
        Me.gfbno.ReadOnly = True
        Me.gfbno.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gfbno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gfbno.Visible = False
        Me.gfbno.Width = 60
        '
        'GPIECETYPE
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.GPIECETYPE.DefaultCellStyle = DataGridViewCellStyle14
        Me.GPIECETYPE.HeaderText = "Piece Type"
        Me.GPIECETYPE.Name = "GPIECETYPE"
        Me.GPIECETYPE.ReadOnly = True
        Me.GPIECETYPE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GPIECETYPE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GMERCHANT
        '
        Me.GMERCHANT.HeaderText = "Merchant"
        Me.GMERCHANT.Name = "GMERCHANT"
        Me.GMERCHANT.ReadOnly = True
        Me.GMERCHANT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMERCHANT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMERCHANT.Width = 170
        '
        'GCUT
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GCUT.DefaultCellStyle = DataGridViewCellStyle15
        Me.GCUT.HeaderText = "Cut"
        Me.GCUT.Name = "GCUT"
        Me.GCUT.ReadOnly = True
        Me.GCUT.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GCUT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GCUT.Width = 50
        '
        'gQuality
        '
        Me.gQuality.HeaderText = "Quality"
        Me.gQuality.Name = "gQuality"
        Me.gQuality.ReadOnly = True
        Me.gQuality.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gQuality.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GQTY
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.GQTY.DefaultCellStyle = DataGridViewCellStyle16
        Me.GQTY.HeaderText = "Pcs"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.ReadOnly = True
        Me.GQTY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GQTY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GQTY.Width = 60
        '
        'GMTRS
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.GMTRS.DefaultCellStyle = DataGridViewCellStyle17
        Me.GMTRS.HeaderText = "Mtrs"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.ReadOnly = True
        Me.GMTRS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GMTRS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GMTRS.Width = 70
        '
        'gwt
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.gwt.DefaultCellStyle = DataGridViewCellStyle18
        Me.gwt.HeaderText = "Wt."
        Me.gwt.Name = "gwt"
        Me.gwt.ReadOnly = True
        Me.gwt.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gwt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gwt.Width = 50
        '
        'gPer
        '
        Me.gPer.HeaderText = "Per"
        Me.gPer.Items.AddRange(New Object() {"PCS", "MTRS", "WT", ""})
        Me.gPer.Name = "gPer"
        Me.gPer.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gPer.Width = 60
        '
        'grate
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.grate.DefaultCellStyle = DataGridViewCellStyle19
        Me.grate.HeaderText = "Rate"
        Me.grate.Name = "grate"
        Me.grate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.grate.Width = 70
        '
        'gamt
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.NullValue = "0.00"
        Me.gamt.DefaultCellStyle = DataGridViewCellStyle20
        Me.gamt.HeaderText = "Amt"
        Me.gamt.Name = "gamt"
        Me.gamt.ReadOnly = True
        Me.gamt.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gamt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GDONE
        '
        Me.GDONE.HeaderText = "DONE"
        Me.GDONE.Name = "GDONE"
        Me.GDONE.Visible = False
        '
        'ggdngridsrno
        '
        Me.ggdngridsrno.HeaderText = "ggdngridsrno"
        Me.ggdngridsrno.Name = "ggdngridsrno"
        Me.ggdngridsrno.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ggdngridsrno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ggdngridsrno.Visible = False
        '
        'tbtransport
        '
        Me.tbtransport.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.tbtransport.Controls.Add(Me.Label11)
        Me.tbtransport.Controls.Add(Me.GroupBox2)
        Me.tbtransport.Controls.Add(Me.lrdate)
        Me.tbtransport.Controls.Add(Me.Label17)
        Me.tbtransport.Controls.Add(Me.cmbtrans)
        Me.tbtransport.Controls.Add(Me.Label14)
        Me.tbtransport.Controls.Add(Me.txttransref)
        Me.tbtransport.Controls.Add(Me.Label15)
        Me.tbtransport.Controls.Add(Me.txtlrno)
        Me.tbtransport.Controls.Add(Me.Label27)
        Me.tbtransport.Location = New System.Drawing.Point(4, 23)
        Me.tbtransport.Name = "tbtransport"
        Me.tbtransport.Padding = New System.Windows.Forms.Padding(3)
        Me.tbtransport.Size = New System.Drawing.Size(972, 265)
        Me.tbtransport.TabIndex = 2
        Me.tbtransport.Text = "Transport Details"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(12, 17)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(125, 19)
        Me.Label11.TabIndex = 437
        Me.Label11.Text = "Transport Details"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txttransremarks)
        Me.GroupBox2.Controls.Add(Me.TextBox6)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(106, 109)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(380, 90)
        Me.GroupBox2.TabIndex = 435
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Remarks"
        '
        'txttransremarks
        '
        Me.txttransremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txttransremarks.Location = New System.Drawing.Point(6, 17)
        Me.txttransremarks.Multiline = True
        Me.txttransremarks.Name = "txttransremarks"
        Me.txttransremarks.Size = New System.Drawing.Size(365, 67)
        Me.txttransremarks.TabIndex = 0
        '
        'TextBox6
        '
        Me.TextBox6.ForeColor = System.Drawing.Color.DimGray
        Me.TextBox6.Location = New System.Drawing.Point(6, 17)
        Me.TextBox6.Multiline = True
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(353, 67)
        Me.TextBox6.TabIndex = 0
        '
        'lrdate
        '
        Me.lrdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lrdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.lrdate.Location = New System.Drawing.Point(393, 40)
        Me.lrdate.Name = "lrdate"
        Me.lrdate.Size = New System.Drawing.Size(84, 22)
        Me.lrdate.TabIndex = 433
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(335, 45)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 14)
        Me.Label17.TabIndex = 440
        Me.Label17.Text = "L.R. Date"
        '
        'cmbtrans
        '
        Me.cmbtrans.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtrans.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtrans.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtrans.FormattingEnabled = True
        Me.cmbtrans.Location = New System.Drawing.Point(106, 42)
        Me.cmbtrans.MaxDropDownItems = 14
        Me.cmbtrans.Name = "cmbtrans"
        Me.cmbtrans.Size = New System.Drawing.Size(223, 22)
        Me.cmbtrans.TabIndex = 431
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 45)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 14)
        Me.Label14.TabIndex = 439
        Me.Label14.Text = "Transport Name"
        '
        'txttransref
        '
        Me.txttransref.BackColor = System.Drawing.Color.White
        Me.txttransref.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txttransref.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttransref.Location = New System.Drawing.Point(394, 75)
        Me.txttransref.Name = "txttransref"
        Me.txttransref.Size = New System.Drawing.Size(83, 22)
        Me.txttransref.TabIndex = 434
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(343, 79)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 14)
        Me.Label15.TabIndex = 438
        Me.Label15.Text = "Ref No."
        '
        'txtlrno
        '
        Me.txtlrno.BackColor = System.Drawing.Color.White
        Me.txtlrno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtlrno.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlrno.Location = New System.Drawing.Point(106, 74)
        Me.txtlrno.Name = "txtlrno"
        Me.txtlrno.Size = New System.Drawing.Size(109, 22)
        Me.txtlrno.TabIndex = 432
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label27.Location = New System.Drawing.Point(56, 78)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(46, 14)
        Me.Label27.TabIndex = 436
        Me.Label27.Text = "L.R. No."
        '
        'TXTTRANSADD
        '
        Me.TXTTRANSADD.BackColor = System.Drawing.Color.White
        Me.TXTTRANSADD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTRANSADD.ForeColor = System.Drawing.Color.DimGray
        Me.TXTTRANSADD.Location = New System.Drawing.Point(182, 5)
        Me.TXTTRANSADD.Name = "TXTTRANSADD"
        Me.TXTTRANSADD.ReadOnly = True
        Me.TXTTRANSADD.Size = New System.Drawing.Size(117, 22)
        Me.TXTTRANSADD.TabIndex = 654
        Me.TXTTRANSADD.TabStop = False
        Me.TXTTRANSADD.Visible = False
        '
        'txtinwordhse
        '
        Me.txtinwordhse.BackColor = System.Drawing.Color.White
        Me.txtinwordhse.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinwordhse.ForeColor = System.Drawing.Color.DimGray
        Me.txtinwordhse.Location = New System.Drawing.Point(353, 3)
        Me.txtinwordhse.Name = "txtinwordhse"
        Me.txtinwordhse.ReadOnly = True
        Me.txtinwordhse.Size = New System.Drawing.Size(117, 22)
        Me.txtinwordhse.TabIndex = 651
        Me.txtinwordhse.TabStop = False
        Me.txtinwordhse.Visible = False
        '
        'txtinwordedu
        '
        Me.txtinwordedu.BackColor = System.Drawing.Color.White
        Me.txtinwordedu.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinwordedu.ForeColor = System.Drawing.Color.DimGray
        Me.txtinwordedu.Location = New System.Drawing.Point(332, 3)
        Me.txtinwordedu.Name = "txtinwordedu"
        Me.txtinwordedu.ReadOnly = True
        Me.txtinwordedu.Size = New System.Drawing.Size(117, 22)
        Me.txtinwordedu.TabIndex = 650
        Me.txtinwordedu.TabStop = False
        Me.txtinwordedu.Visible = False
        '
        'txtinwordexcise
        '
        Me.txtinwordexcise.BackColor = System.Drawing.Color.White
        Me.txtinwordexcise.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinwordexcise.ForeColor = System.Drawing.Color.DimGray
        Me.txtinwordexcise.Location = New System.Drawing.Point(295, 3)
        Me.txtinwordexcise.Name = "txtinwordexcise"
        Me.txtinwordexcise.ReadOnly = True
        Me.txtinwordexcise.Size = New System.Drawing.Size(117, 22)
        Me.txtinwordexcise.TabIndex = 649
        Me.txtinwordexcise.TabStop = False
        Me.txtinwordexcise.Visible = False
        '
        'PBlock
        '
        Me.PBlock.BackColor = System.Drawing.Color.Transparent
        Me.PBlock.Image = CType(resources.GetObject("PBlock.Image"), System.Drawing.Image)
        Me.PBlock.Location = New System.Drawing.Point(386, 443)
        Me.PBlock.Name = "PBlock"
        Me.PBlock.Size = New System.Drawing.Size(60, 60)
        Me.PBlock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBlock.TabIndex = 570
        Me.PBlock.TabStop = False
        Me.PBlock.Visible = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(32, 521)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(55, 14)
        Me.Label39.TabIndex = 645
        Me.Label39.Text = "In Words"
        '
        'txtinwords
        '
        Me.txtinwords.BackColor = System.Drawing.Color.White
        Me.txtinwords.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtinwords.ForeColor = System.Drawing.Color.DimGray
        Me.txtinwords.Location = New System.Drawing.Point(90, 517)
        Me.txtinwords.Name = "txtinwords"
        Me.txtinwords.ReadOnly = True
        Me.txtinwords.Size = New System.Drawing.Size(482, 22)
        Me.txtinwords.TabIndex = 644
        Me.txtinwords.TabStop = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmddelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Image = CType(resources.GetObject("cmddelete.Image"), System.Drawing.Image)
        Me.cmddelete.Location = New System.Drawing.Point(644, 507)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(72, 24)
        Me.cmddelete.TabIndex = 13
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(58, 439)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(322, 72)
        Me.GroupBox5.TabIndex = 10
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(5, 16)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(313, 52)
        Me.txtremarks.TabIndex = 0
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 5)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(124, 25)
        Me.lbl.TabIndex = 311
        Me.lbl.Text = "Work Order"
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.Transparent
        Me.cmdOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdOK.FlatAppearance.BorderSize = 0
        Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdOK.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdOK.Image = CType(resources.GetObject("cmdOK.Image"), System.Drawing.Image)
        Me.cmdOK.Location = New System.Drawing.Point(688, 477)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(72, 24)
        Me.cmdOK.TabIndex = 11
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdclear.Image = CType(resources.GetObject("cmdclear.Image"), System.Drawing.Image)
        Me.cmdclear.Location = New System.Drawing.Point(766, 475)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(72, 25)
        Me.cmdclear.TabIndex = 12
        Me.cmdclear.UseVisualStyleBackColor = False
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(104, 20)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 347
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'cmdEXIT
        '
        Me.cmdEXIT.BackColor = System.Drawing.Color.Transparent
        Me.cmdEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdEXIT.FlatAppearance.BorderSize = 0
        Me.cmdEXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdEXIT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEXIT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdEXIT.Image = CType(resources.GetObject("cmdEXIT.Image"), System.Drawing.Image)
        Me.cmdEXIT.Location = New System.Drawing.Point(722, 507)
        Me.cmdEXIT.Name = "cmdEXIT"
        Me.cmdEXIT.Size = New System.Drawing.Size(72, 24)
        Me.cmdEXIT.TabIndex = 14
        Me.cmdEXIT.UseVisualStyleBackColor = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1004, 562)
        Me.ShapeContainer1.TabIndex = 675
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 642
        Me.LineShape1.X2 = 946
        Me.LineShape1.Y1 = 461
        Me.LineShape1.Y2 = 461
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'ProformaInvoice
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1004, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "ProformaInvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Proforma Invoice"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.tbitem.ResumeLayout(False)
        CType(Me.gridinvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbtransport.ResumeLayout(False)
        Me.tbtransport.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PBlock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents lbltotalmtrs As System.Windows.Forms.Label
    Friend WithEvents TXTREFNO As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents podate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbformno As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbcity As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtpono As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents INVOICEdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTINVOICENO As System.Windows.Forms.TextBox
    Friend WithEvents cmdselectOrder As System.Windows.Forms.Button
    Friend WithEvents lbllocked As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbltotalamt As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents lbltotalqty As System.Windows.Forms.Label
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TOOLDELETE As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents tbitem As System.Windows.Forms.TabPage
    Friend WithEvents gridinvoice As System.Windows.Forms.DataGridView
    Friend WithEvents tbtransport As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txttransremarks As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents lrdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbtrans As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txttransref As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtlrno As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TXTTRANSADD As System.Windows.Forms.TextBox
    Friend WithEvents txtinwordhse As System.Windows.Forms.TextBox
    Friend WithEvents txtinwordedu As System.Windows.Forms.TextBox
    Friend WithEvents txtinwordexcise As System.Windows.Forms.TextBox
    Friend WithEvents PBlock As System.Windows.Forms.PictureBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtinwords As System.Windows.Forms.TextBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents cmdEXIT As System.Windows.Forms.Button
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents TXTGDNNO As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtdeliveryadd As System.Windows.Forms.TextBox
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents CMBCONSIGNEE As System.Windows.Forms.ComboBox
    Friend WithEvents chkprintsingle As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTBALENO As System.Windows.Forms.TextBox
    Friend WithEvents GSRNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gbaleno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gfbno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GPIECETYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GMERCHANT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GCUT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gQuality As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GQTY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GMTRS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gwt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gPer As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents grate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gamt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GDONE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ggdngridsrno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CMBAGENT As System.Windows.Forms.ComboBox
End Class
