<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PJOfilter
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
        Me.cmbColor = New System.Windows.Forms.ComboBox()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKHIDERATE = New System.Windows.Forms.CheckBox()
        Me.GPPARTYNAME = New System.Windows.Forms.GroupBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RDBDETAILSOUTQUALITY = New System.Windows.Forms.RadioButton()
        Me.RBSUMMARY = New System.Windows.Forms.RadioButton()
        Me.RBMONTHLY = New System.Windows.Forms.RadioButton()
        Me.RDBITEM = New System.Windows.Forms.RadioButton()
        Me.RDBPARTYWISEDETAIL = New System.Windows.Forms.RadioButton()
        Me.RDBDETAIL = New System.Windows.Forms.RadioButton()
        Me.lblheading = New System.Windows.Forms.Label()
        Me.cmbDesign = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbQuality = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbitemname = New System.Windows.Forms.ComboBox()
        Me.lblvendorname = New System.Windows.Forms.Label()
        Me.cmdshowreport = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.RBJOBFINALCUTTING = New System.Windows.Forms.RadioButton()
        Me.TXTJOBNO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        Me.GPPARTYNAME.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbColor
        '
        Me.cmbColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbColor.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbColor.FormattingEnabled = True
        Me.cmbColor.Location = New System.Drawing.Point(142, 7)
        Me.cmbColor.MaxDropDownItems = 14
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(114, 22)
        Me.cmbColor.TabIndex = 2
        Me.cmbColor.Visible = False
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTJOBNO)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.CHKHIDERATE)
        Me.BlendPanel1.Controls.Add(Me.GPPARTYNAME)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.lblheading)
        Me.BlendPanel1.Controls.Add(Me.cmbDesign)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.cmbQuality)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.cmbColor)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmbitemname)
        Me.BlendPanel1.Controls.Add(Me.lblvendorname)
        Me.BlendPanel1.Controls.Add(Me.cmdshowreport)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(820, 451)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKHIDERATE
        '
        Me.CHKHIDERATE.AutoSize = True
        Me.CHKHIDERATE.BackColor = System.Drawing.Color.Transparent
        Me.CHKHIDERATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKHIDERATE.ForeColor = System.Drawing.Color.Black
        Me.CHKHIDERATE.Location = New System.Drawing.Point(54, 116)
        Me.CHKHIDERATE.Name = "CHKHIDERATE"
        Me.CHKHIDERATE.Size = New System.Drawing.Size(78, 19)
        Me.CHKHIDERATE.TabIndex = 438
        Me.CHKHIDERATE.Text = "Hide Rate"
        Me.CHKHIDERATE.UseVisualStyleBackColor = False
        '
        'GPPARTYNAME
        '
        Me.GPPARTYNAME.BackColor = System.Drawing.Color.Transparent
        Me.GPPARTYNAME.Controls.Add(Me.gridbilldetails)
        Me.GPPARTYNAME.Controls.Add(Me.CHKSELECTALL)
        Me.GPPARTYNAME.Location = New System.Drawing.Point(364, 19)
        Me.GPPARTYNAME.Name = "GPPARTYNAME"
        Me.GPPARTYNAME.Size = New System.Drawing.Size(415, 359)
        Me.GPPARTYNAME.TabIndex = 437
        Me.GPPARTYNAME.TabStop = False
        Me.GPPARTYNAME.Text = "Party Name"
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(11, 46)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.gridbilldetails.Size = New System.Drawing.Size(394, 307)
        Me.gridbilldetails.TabIndex = 2
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GNAME})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 35
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 1
        Me.GNAME.Width = 300
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(18, 22)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTALL.TabIndex = 0
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.RBJOBFINALCUTTING)
        Me.GroupBox1.Controls.Add(Me.RDBDETAILSOUTQUALITY)
        Me.GroupBox1.Controls.Add(Me.RBSUMMARY)
        Me.GroupBox1.Controls.Add(Me.RBMONTHLY)
        Me.GroupBox1.Controls.Add(Me.RDBITEM)
        Me.GroupBox1.Controls.Add(Me.RDBPARTYWISEDETAIL)
        Me.GroupBox1.Controls.Add(Me.RDBDETAIL)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(30, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(314, 138)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'RDBDETAILSOUTQUALITY
        '
        Me.RDBDETAILSOUTQUALITY.AutoSize = True
        Me.RDBDETAILSOUTQUALITY.BackColor = System.Drawing.Color.Transparent
        Me.RDBDETAILSOUTQUALITY.Location = New System.Drawing.Point(154, 72)
        Me.RDBDETAILSOUTQUALITY.Name = "RDBDETAILSOUTQUALITY"
        Me.RDBDETAILSOUTQUALITY.Size = New System.Drawing.Size(156, 19)
        Me.RDBDETAILSOUTQUALITY.TabIndex = 5
        Me.RDBDETAILSOUTQUALITY.Text = "Detail With Our Quality"
        Me.RDBDETAILSOUTQUALITY.UseVisualStyleBackColor = False
        '
        'RBSUMMARY
        '
        Me.RBSUMMARY.AutoSize = True
        Me.RBSUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.RBSUMMARY.Location = New System.Drawing.Point(24, 47)
        Me.RBSUMMARY.Name = "RBSUMMARY"
        Me.RBSUMMARY.Size = New System.Drawing.Size(76, 19)
        Me.RBSUMMARY.TabIndex = 1
        Me.RBSUMMARY.Text = "Summary"
        Me.RBSUMMARY.UseVisualStyleBackColor = False
        '
        'RBMONTHLY
        '
        Me.RBMONTHLY.AutoSize = True
        Me.RBMONTHLY.BackColor = System.Drawing.Color.Transparent
        Me.RBMONTHLY.Location = New System.Drawing.Point(154, 47)
        Me.RBMONTHLY.Name = "RBMONTHLY"
        Me.RBMONTHLY.Size = New System.Drawing.Size(71, 19)
        Me.RBMONTHLY.TabIndex = 4
        Me.RBMONTHLY.Text = "Monthly"
        Me.RBMONTHLY.UseVisualStyleBackColor = False
        Me.RBMONTHLY.Visible = False
        '
        'RDBITEM
        '
        Me.RDBITEM.AutoSize = True
        Me.RDBITEM.BackColor = System.Drawing.Color.Transparent
        Me.RDBITEM.Location = New System.Drawing.Point(154, 22)
        Me.RDBITEM.Name = "RDBITEM"
        Me.RDBITEM.Size = New System.Drawing.Size(116, 19)
        Me.RDBITEM.TabIndex = 3
        Me.RDBITEM.Text = "Item Wise Detail"
        Me.RDBITEM.UseVisualStyleBackColor = False
        Me.RDBITEM.Visible = False
        '
        'RDBPARTYWISEDETAIL
        '
        Me.RDBPARTYWISEDETAIL.AutoSize = True
        Me.RDBPARTYWISEDETAIL.BackColor = System.Drawing.Color.Transparent
        Me.RDBPARTYWISEDETAIL.Location = New System.Drawing.Point(24, 72)
        Me.RDBPARTYWISEDETAIL.Name = "RDBPARTYWISEDETAIL"
        Me.RDBPARTYWISEDETAIL.Size = New System.Drawing.Size(121, 19)
        Me.RDBPARTYWISEDETAIL.TabIndex = 2
        Me.RDBPARTYWISEDETAIL.Text = "Party Wise Detail"
        Me.RDBPARTYWISEDETAIL.UseVisualStyleBackColor = False
        Me.RDBPARTYWISEDETAIL.Visible = False
        '
        'RDBDETAIL
        '
        Me.RDBDETAIL.AutoSize = True
        Me.RDBDETAIL.BackColor = System.Drawing.Color.Transparent
        Me.RDBDETAIL.Checked = True
        Me.RDBDETAIL.Location = New System.Drawing.Point(24, 22)
        Me.RDBDETAIL.Name = "RDBDETAIL"
        Me.RDBDETAIL.Size = New System.Drawing.Size(58, 19)
        Me.RDBDETAIL.TabIndex = 0
        Me.RDBDETAIL.TabStop = True
        Me.RDBDETAIL.Text = "Detail"
        Me.RDBDETAIL.UseVisualStyleBackColor = False
        '
        'lblheading
        '
        Me.lblheading.AutoSize = True
        Me.lblheading.BackColor = System.Drawing.Color.Transparent
        Me.lblheading.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblheading.Location = New System.Drawing.Point(25, 9)
        Me.lblheading.Name = "lblheading"
        Me.lblheading.Size = New System.Drawing.Size(143, 29)
        Me.lblheading.TabIndex = 315
        Me.lblheading.Text = "Pending Jobs"
        '
        'cmbDesign
        '
        Me.cmbDesign.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDesign.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDesign.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDesign.FormattingEnabled = True
        Me.cmbDesign.Location = New System.Drawing.Point(174, 19)
        Me.cmbDesign.MaxDropDownItems = 14
        Me.cmbDesign.Name = "cmbDesign"
        Me.cmbDesign.Size = New System.Drawing.Size(119, 22)
        Me.cmbDesign.TabIndex = 5
        Me.cmbDesign.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(108, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 14)
        Me.Label6.TabIndex = 436
        Me.Label6.Text = "Design"
        Me.Label6.Visible = False
        '
        'cmbQuality
        '
        Me.cmbQuality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbQuality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbQuality.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbQuality.FormattingEnabled = True
        Me.cmbQuality.Location = New System.Drawing.Point(159, 11)
        Me.cmbQuality.MaxDropDownItems = 14
        Me.cmbQuality.Name = "cmbQuality"
        Me.cmbQuality.Size = New System.Drawing.Size(185, 22)
        Me.cmbQuality.TabIndex = 3
        Me.cmbQuality.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(78, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 435
        Me.Label2.Text = "Quality"
        Me.Label2.Visible = False
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(109, 47)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(195, 23)
        Me.cmbname.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(68, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 15)
        Me.Label8.TabIndex = 433
        Me.Label8.Text = "Name"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(39, 276)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(51, 19)
        Me.chkdate.TabIndex = 4
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtto)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dtfrom)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(31, 282)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(189, 20)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(161, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 14)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(50, 20)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtfrom.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(9, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 14)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "From :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(105, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 14)
        Me.Label1.TabIndex = 421
        Me.Label1.Text = "Color"
        Me.Label1.Visible = False
        '
        'cmbitemname
        '
        Me.cmbitemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbitemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbitemname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbitemname.FormattingEnabled = True
        Me.cmbitemname.Location = New System.Drawing.Point(109, 76)
        Me.cmbitemname.MaxDropDownItems = 14
        Me.cmbitemname.Name = "cmbitemname"
        Me.cmbitemname.Size = New System.Drawing.Size(195, 23)
        Me.cmbitemname.TabIndex = 1
        '
        'lblvendorname
        '
        Me.lblvendorname.AutoSize = True
        Me.lblvendorname.BackColor = System.Drawing.Color.Transparent
        Me.lblvendorname.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvendorname.ForeColor = System.Drawing.Color.Black
        Me.lblvendorname.Location = New System.Drawing.Point(40, 80)
        Me.lblvendorname.Name = "lblvendorname"
        Me.lblvendorname.Size = New System.Drawing.Size(65, 15)
        Me.lblvendorname.TabIndex = 419
        Me.lblvendorname.Text = "Item Name"
        '
        'cmdshowreport
        '
        Me.cmdshowreport.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowreport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowreport.FlatAppearance.BorderSize = 0
        Me.cmdshowreport.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowreport.ForeColor = System.Drawing.Color.Black
        Me.cmdshowreport.Location = New System.Drawing.Point(89, 344)
        Me.cmdshowreport.Name = "cmdshowreport"
        Me.cmdshowreport.Size = New System.Drawing.Size(83, 28)
        Me.cmdshowreport.TabIndex = 6
        Me.cmdshowreport.Text = "&Show Report"
        Me.cmdshowreport.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(180, 344)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 7
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'RBJOBFINALCUTTING
        '
        Me.RBJOBFINALCUTTING.AutoSize = True
        Me.RBJOBFINALCUTTING.BackColor = System.Drawing.Color.Transparent
        Me.RBJOBFINALCUTTING.Location = New System.Drawing.Point(24, 97)
        Me.RBJOBFINALCUTTING.Name = "RBJOBFINALCUTTING"
        Me.RBJOBFINALCUTTING.Size = New System.Drawing.Size(122, 19)
        Me.RBJOBFINALCUTTING.TabIndex = 6
        Me.RBJOBFINALCUTTING.Text = "Job - Final Cutting"
        Me.RBJOBFINALCUTTING.UseVisualStyleBackColor = False
        '
        'TXTJOBNO
        '
        Me.TXTJOBNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTJOBNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTJOBNO.Location = New System.Drawing.Point(221, 105)
        Me.TXTJOBNO.Name = "TXTJOBNO"
        Me.TXTJOBNO.Size = New System.Drawing.Size(83, 22)
        Me.TXTJOBNO.TabIndex = 440
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(173, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 14)
        Me.Label3.TabIndex = 441
        Me.Label3.Text = "Job No."
        '
        'PJOfilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(820, 451)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PJOfilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Pending Job Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GPPARTYNAME.ResumeLayout(False)
        Me.GPPARTYNAME.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbColor As System.Windows.Forms.ComboBox
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmbDesign As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbQuality As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbitemname As System.Windows.Forms.ComboBox
    Friend WithEvents lblvendorname As System.Windows.Forms.Label
    Friend WithEvents cmdshowreport As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lblheading As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RDBITEM As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPARTYWISEDETAIL As System.Windows.Forms.RadioButton
    Friend WithEvents RDBDETAIL As System.Windows.Forms.RadioButton
    Friend WithEvents RBSUMMARY As System.Windows.Forms.RadioButton
    Friend WithEvents RBMONTHLY As System.Windows.Forms.RadioButton
    Friend WithEvents GPPARTYNAME As GroupBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKSELECTALL As CheckBox
    Friend WithEvents RDBDETAILSOUTQUALITY As RadioButton
    Friend WithEvents CHKHIDERATE As CheckBox
    Friend WithEvents RBJOBFINALCUTTING As RadioButton
    Friend WithEvents TXTJOBNO As TextBox
    Friend WithEvents Label3 As Label
End Class
