<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DesignIssue
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DesignIssue))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTAMOUNT = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TXTTABLERATE = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXTMACRATE = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TXTSMALLRATE = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tstxtbillno = New System.Windows.Forms.TextBox()
        Me.TXTISSUENO = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTPHOTOIMGPATH = New System.Windows.Forms.TextBox()
        Me.TXTBILLDATE = New System.Windows.Forms.MaskedTextBox()
        Me.CMDVIEW = New System.Windows.Forms.Button()
        Me.TXTRECDATE = New System.Windows.Forms.MaskedTextBox()
        Me.cmdremove = New System.Windows.Forms.Button()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.cmdupload = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PBPHOTO = New System.Windows.Forms.PictureBox()
        Me.TXTBILLNO = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTBIG = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTSMALL1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTMACHINE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTTABLE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTSKETCHNO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CMBMERCHANT = New System.Windows.Forms.ComboBox()
        Me.ISSDATE = New System.Windows.Forms.DateTimePicker()
        Me.TXTDESIGNNO = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TXTREMARKS = New System.Windows.Forms.TextBox()
        Me.cmdclear = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.tooldelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolprevious = New System.Windows.Forms.ToolStripButton()
        Me.toolnext = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PBPHOTO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTAMOUNT)
        Me.BlendPanel1.Controls.Add(Me.Label17)
        Me.BlendPanel1.Controls.Add(Me.TXTTABLERATE)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.TXTMACRATE)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.TXTSMALLRATE)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.tstxtbillno)
        Me.BlendPanel1.Controls.Add(Me.TXTISSUENO)
        Me.BlendPanel1.Controls.Add(Me.Label13)
        Me.BlendPanel1.Controls.Add(Me.TXTPHOTOIMGPATH)
        Me.BlendPanel1.Controls.Add(Me.TXTBILLDATE)
        Me.BlendPanel1.Controls.Add(Me.CMDVIEW)
        Me.BlendPanel1.Controls.Add(Me.TXTRECDATE)
        Me.BlendPanel1.Controls.Add(Me.cmdremove)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.cmdupload)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.PBPHOTO)
        Me.BlendPanel1.Controls.Add(Me.TXTBILLNO)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.TXTBIG)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.TXTSMALL1)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTMACHINE)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTTABLE)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTSKETCHNO)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.CMBMERCHANT)
        Me.BlendPanel1.Controls.Add(Me.ISSDATE)
        Me.BlendPanel1.Controls.Add(Me.TXTDESIGNNO)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.cmdclear)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(708, 483)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTAMOUNT
        '
        Me.TXTAMOUNT.BackColor = System.Drawing.Color.Linen
        Me.TXTAMOUNT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAMOUNT.Location = New System.Drawing.Point(258, 294)
        Me.TXTAMOUNT.Name = "TXTAMOUNT"
        Me.TXTAMOUNT.ReadOnly = True
        Me.TXTAMOUNT.Size = New System.Drawing.Size(84, 22)
        Me.TXTAMOUNT.TabIndex = 710
        Me.TXTAMOUNT.TabStop = False
        Me.TXTAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(207, 298)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 14)
        Me.Label17.TabIndex = 711
        Me.Label17.Text = "Amount"
        '
        'TXTTABLERATE
        '
        Me.TXTTABLERATE.BackColor = System.Drawing.Color.White
        Me.TXTTABLERATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTABLERATE.Location = New System.Drawing.Point(104, 294)
        Me.TXTTABLERATE.Name = "TXTTABLERATE"
        Me.TXTTABLERATE.Size = New System.Drawing.Size(84, 22)
        Me.TXTTABLERATE.TabIndex = 14
        Me.TXTTABLERATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(37, 298)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 14)
        Me.Label16.TabIndex = 709
        Me.Label16.Text = "Table Rate"
        '
        'TXTMACRATE
        '
        Me.TXTMACRATE.BackColor = System.Drawing.Color.White
        Me.TXTMACRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMACRATE.Location = New System.Drawing.Point(258, 266)
        Me.TXTMACRATE.Name = "TXTMACRATE"
        Me.TXTMACRATE.Size = New System.Drawing.Size(84, 22)
        Me.TXTMACRATE.TabIndex = 13
        Me.TXTMACRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(199, 270)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 14)
        Me.Label15.TabIndex = 707
        Me.Label15.Text = "Mac Rate"
        '
        'TXTSMALLRATE
        '
        Me.TXTSMALLRATE.BackColor = System.Drawing.Color.White
        Me.TXTSMALLRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSMALLRATE.Location = New System.Drawing.Point(104, 266)
        Me.TXTSMALLRATE.Name = "TXTSMALLRATE"
        Me.TXTSMALLRATE.Size = New System.Drawing.Size(84, 22)
        Me.TXTSMALLRATE.TabIndex = 12
        Me.TXTSMALLRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(36, 270)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 14)
        Me.Label14.TabIndex = 705
        Me.Label14.Text = "Small Rate"
        '
        'tstxtbillno
        '
        Me.tstxtbillno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tstxtbillno.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tstxtbillno.Location = New System.Drawing.Point(219, 1)
        Me.tstxtbillno.Name = "tstxtbillno"
        Me.tstxtbillno.Size = New System.Drawing.Size(66, 23)
        Me.tstxtbillno.TabIndex = 23
        Me.tstxtbillno.TabStop = False
        Me.tstxtbillno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTISSUENO
        '
        Me.TXTISSUENO.BackColor = System.Drawing.Color.Linen
        Me.TXTISSUENO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTISSUENO.Location = New System.Drawing.Point(104, 34)
        Me.TXTISSUENO.Name = "TXTISSUENO"
        Me.TXTISSUENO.ReadOnly = True
        Me.TXTISSUENO.Size = New System.Drawing.Size(84, 23)
        Me.TXTISSUENO.TabIndex = 702
        Me.TXTISSUENO.TabStop = False
        Me.TXTISSUENO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(64, 38)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 15)
        Me.Label13.TabIndex = 703
        Me.Label13.Text = "Sr. No"
        '
        'TXTPHOTOIMGPATH
        '
        Me.TXTPHOTOIMGPATH.BackColor = System.Drawing.Color.White
        Me.TXTPHOTOIMGPATH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPHOTOIMGPATH.ForeColor = System.Drawing.Color.Black
        Me.TXTPHOTOIMGPATH.Location = New System.Drawing.Point(369, 357)
        Me.TXTPHOTOIMGPATH.Name = "TXTPHOTOIMGPATH"
        Me.TXTPHOTOIMGPATH.Size = New System.Drawing.Size(22, 23)
        Me.TXTPHOTOIMGPATH.TabIndex = 675
        Me.TXTPHOTOIMGPATH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTPHOTOIMGPATH.Visible = False
        '
        'TXTBILLDATE
        '
        Me.TXTBILLDATE.AllowPromptAsInput = False
        Me.TXTBILLDATE.Location = New System.Drawing.Point(104, 237)
        Me.TXTBILLDATE.Mask = "00/00/0000"
        Me.TXTBILLDATE.Name = "TXTBILLDATE"
        Me.TXTBILLDATE.Size = New System.Drawing.Size(84, 23)
        Me.TXTBILLDATE.TabIndex = 10
        Me.TXTBILLDATE.ValidatingType = GetType(Date)
        '
        'CMDVIEW
        '
        Me.CMDVIEW.BackColor = System.Drawing.Color.Transparent
        Me.CMDVIEW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDVIEW.FlatAppearance.BorderSize = 0
        Me.CMDVIEW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDVIEW.ForeColor = System.Drawing.Color.Black
        Me.CMDVIEW.Location = New System.Drawing.Point(569, 375)
        Me.CMDVIEW.Name = "CMDVIEW"
        Me.CMDVIEW.Size = New System.Drawing.Size(80, 28)
        Me.CMDVIEW.TabIndex = 22
        Me.CMDVIEW.Text = "&View"
        Me.CMDVIEW.UseVisualStyleBackColor = False
        '
        'TXTRECDATE
        '
        Me.TXTRECDATE.Location = New System.Drawing.Point(104, 208)
        Me.TXTRECDATE.Mask = "00/00/0000"
        Me.TXTRECDATE.Name = "TXTRECDATE"
        Me.TXTRECDATE.Size = New System.Drawing.Size(84, 23)
        Me.TXTRECDATE.TabIndex = 8
        '
        'cmdremove
        '
        Me.cmdremove.BackColor = System.Drawing.Color.Transparent
        Me.cmdremove.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdremove.FlatAppearance.BorderSize = 0
        Me.cmdremove.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdremove.ForeColor = System.Drawing.Color.Black
        Me.cmdremove.Location = New System.Drawing.Point(483, 375)
        Me.cmdremove.Name = "cmdremove"
        Me.cmdremove.Size = New System.Drawing.Size(80, 28)
        Me.cmdremove.TabIndex = 21
        Me.cmdremove.Text = "&Remove"
        Me.cmdremove.UseVisualStyleBackColor = False
        '
        'TXTADD
        '
        Me.TXTADD.BackColor = System.Drawing.Color.White
        Me.TXTADD.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADD.Location = New System.Drawing.Point(324, 381)
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(39, 22)
        Me.TXTADD.TabIndex = 701
        Me.TXTADD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTADD.Visible = False
        '
        'cmdupload
        '
        Me.cmdupload.BackColor = System.Drawing.Color.Transparent
        Me.cmdupload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdupload.FlatAppearance.BorderSize = 0
        Me.cmdupload.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdupload.ForeColor = System.Drawing.Color.Black
        Me.cmdupload.Location = New System.Drawing.Point(397, 375)
        Me.cmdupload.Name = "cmdupload"
        Me.cmdupload.Size = New System.Drawing.Size(80, 28)
        Me.cmdupload.TabIndex = 20
        Me.cmdupload.Text = "&Upload"
        Me.cmdupload.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(47, 241)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 14)
        Me.Label3.TabIndex = 700
        Me.Label3.Text = "Bill Date"
        '
        'PBPHOTO
        '
        Me.PBPHOTO.BackColor = System.Drawing.Color.Transparent
        Me.PBPHOTO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PBPHOTO.Location = New System.Drawing.Point(372, 50)
        Me.PBPHOTO.Name = "PBPHOTO"
        Me.PBPHOTO.Size = New System.Drawing.Size(300, 300)
        Me.PBPHOTO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBPHOTO.TabIndex = 674
        Me.PBPHOTO.TabStop = False
        '
        'TXTBILLNO
        '
        Me.TXTBILLNO.BackColor = System.Drawing.Color.White
        Me.TXTBILLNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBILLNO.Location = New System.Drawing.Point(258, 237)
        Me.TXTBILLNO.Name = "TXTBILLNO"
        Me.TXTBILLNO.Size = New System.Drawing.Size(84, 22)
        Me.TXTBILLNO.TabIndex = 11
        Me.TXTBILLNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(212, 241)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 14)
        Me.Label10.TabIndex = 698
        Me.Label10.Text = "Bill No"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(47, 212)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 14)
        Me.Label2.TabIndex = 696
        Me.Label2.Text = "Rec Date"
        '
        'TXTBIG
        '
        Me.TXTBIG.BackColor = System.Drawing.Color.White
        Me.TXTBIG.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBIG.Location = New System.Drawing.Point(258, 121)
        Me.TXTBIG.Name = "TXTBIG"
        Me.TXTBIG.Size = New System.Drawing.Size(84, 22)
        Me.TXTBIG.TabIndex = 5
        Me.TXTBIG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTBIG.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(232, 125)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 14)
        Me.Label8.TabIndex = 694
        Me.Label8.Text = "Big"
        Me.Label8.Visible = False
        '
        'TXTSMALL1
        '
        Me.TXTSMALL1.BackColor = System.Drawing.Color.White
        Me.TXTSMALL1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSMALL1.Location = New System.Drawing.Point(104, 150)
        Me.TXTSMALL1.Name = "TXTSMALL1"
        Me.TXTSMALL1.Size = New System.Drawing.Size(84, 22)
        Me.TXTSMALL1.TabIndex = 4
        Me.TXTSMALL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(55, 154)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 14)
        Me.Label7.TabIndex = 692
        Me.Label7.Text = "Small 1"
        '
        'TXTMACHINE
        '
        Me.TXTMACHINE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTMACHINE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMACHINE.Location = New System.Drawing.Point(104, 121)
        Me.TXTMACHINE.Name = "TXTMACHINE"
        Me.TXTMACHINE.Size = New System.Drawing.Size(84, 22)
        Me.TXTMACHINE.TabIndex = 3
        Me.TXTMACHINE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(48, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 14)
        Me.Label6.TabIndex = 690
        Me.Label6.Text = "Machine"
        '
        'TXTTABLE
        '
        Me.TXTTABLE.BackColor = System.Drawing.Color.White
        Me.TXTTABLE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTABLE.Location = New System.Drawing.Point(258, 150)
        Me.TXTTABLE.Name = "TXTTABLE"
        Me.TXTTABLE.Size = New System.Drawing.Size(84, 22)
        Me.TXTTABLE.TabIndex = 6
        Me.TXTTABLE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(219, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 14)
        Me.Label4.TabIndex = 688
        Me.Label4.Text = "Table"
        '
        'TXTSKETCHNO
        '
        Me.TXTSKETCHNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTSKETCHNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSKETCHNO.Location = New System.Drawing.Point(258, 63)
        Me.TXTSKETCHNO.Name = "TXTSKETCHNO"
        Me.TXTSKETCHNO.Size = New System.Drawing.Size(84, 22)
        Me.TXTSKETCHNO.TabIndex = 1
        Me.TXTSKETCHNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(196, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 14)
        Me.Label1.TabIndex = 681
        Me.Label1.Text = "Sketch No"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(63, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 14)
        Me.Label5.TabIndex = 679
        Me.Label5.Text = "Name"
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(104, 92)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(238, 22)
        Me.CMBNAME.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(44, 183)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 14)
        Me.Label11.TabIndex = 677
        Me.Label11.Text = "Merchant"
        '
        'CMBMERCHANT
        '
        Me.CMBMERCHANT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMERCHANT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMERCHANT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBMERCHANT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBMERCHANT.FormattingEnabled = True
        Me.CMBMERCHANT.Location = New System.Drawing.Point(104, 179)
        Me.CMBMERCHANT.MaxDropDownItems = 14
        Me.CMBMERCHANT.Name = "CMBMERCHANT"
        Me.CMBMERCHANT.Size = New System.Drawing.Size(238, 22)
        Me.CMBMERCHANT.TabIndex = 7
        '
        'ISSDATE
        '
        Me.ISSDATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ISSDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.ISSDATE.Location = New System.Drawing.Point(104, 63)
        Me.ISSDATE.Name = "ISSDATE"
        Me.ISSDATE.Size = New System.Drawing.Size(84, 22)
        Me.ISSDATE.TabIndex = 0
        '
        'TXTDESIGNNO
        '
        Me.TXTDESIGNNO.BackColor = System.Drawing.Color.White
        Me.TXTDESIGNNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESIGNNO.Location = New System.Drawing.Point(258, 208)
        Me.TXTDESIGNNO.Name = "TXTDESIGNNO"
        Me.TXTDESIGNNO.Size = New System.Drawing.Size(84, 22)
        Me.TXTDESIGNNO.TabIndex = 9
        Me.TXTDESIGNNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(193, 212)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 14)
        Me.Label12.TabIndex = 630
        Me.Label12.Text = "Design No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(36, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 14)
        Me.Label9.TabIndex = 622
        Me.Label9.Text = "Issue Date"
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(110, 443)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 18
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.TXTREMARKS)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(39, 340)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(318, 63)
        Me.GroupBox5.TabIndex = 15
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'TXTREMARKS
        '
        Me.TXTREMARKS.ForeColor = System.Drawing.Color.DimGray
        Me.TXTREMARKS.Location = New System.Drawing.Point(5, 16)
        Me.TXTREMARKS.MaxLength = 500
        Me.TXTREMARKS.Multiline = True
        Me.TXTREMARKS.Name = "TXTREMARKS"
        Me.TXTREMARKS.Size = New System.Drawing.Size(307, 40)
        Me.TXTREMARKS.TabIndex = 0
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.Color.Transparent
        Me.cmdclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdclear.FlatAppearance.BorderSize = 0
        Me.cmdclear.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.Black
        Me.cmdclear.Location = New System.Drawing.Point(199, 409)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(80, 28)
        Me.cmdclear.TabIndex = 17
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
        Me.cmdok.Location = New System.Drawing.Point(110, 409)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 16
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
        Me.cmdexit.Location = New System.Drawing.Point(199, 443)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 19
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripButton, Me.SaveToolStripButton, Me.tooldelete, Me.toolStripSeparator, Me.toolprevious, Me.toolnext, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(708, 25)
        Me.ToolStrip1.TabIndex = 610
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
        Me.toolprevious.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.toolprevious.Image = Global.TexPro_V1.My.Resources.Resources.POINT02
        Me.toolprevious.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolprevious.Name = "toolprevious"
        Me.toolprevious.Size = New System.Drawing.Size(75, 22)
        Me.toolprevious.Text = "Previous"
        '
        'toolnext
        '
        Me.toolnext.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        'DesignIssue
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(708, 483)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DesignIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Design Issue"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PBPHOTO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TXTSKETCHNO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CMBMERCHANT As System.Windows.Forms.ComboBox
    Friend WithEvents ISSDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTDESIGNNO As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TXTREMARKS As System.Windows.Forms.TextBox
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents tooldelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTBILLNO As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTBIG As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTSMALL1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTMACHINE As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTTABLE As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents TXTADD As System.Windows.Forms.TextBox
    Friend WithEvents TXTBILLDATE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TXTRECDATE As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TXTPHOTOIMGPATH As System.Windows.Forms.TextBox
    Friend WithEvents CMDVIEW As System.Windows.Forms.Button
    Friend WithEvents cmdremove As System.Windows.Forms.Button
    Friend WithEvents cmdupload As System.Windows.Forms.Button
    Friend WithEvents PBPHOTO As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TXTISSUENO As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tstxtbillno As System.Windows.Forms.TextBox
    Friend WithEvents toolprevious As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolnext As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TXTTABLERATE As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents TXTMACRATE As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents TXTSMALLRATE As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents TXTAMOUNT As TextBox
    Friend WithEvents Label17 As Label
End Class
