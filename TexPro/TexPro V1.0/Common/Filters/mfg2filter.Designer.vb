<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mfg2filter
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMBDEPARTMENT = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMBPIECETYPE = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GPDESIGN = New System.Windows.Forms.GroupBox()
        Me.CHKSELECTDESIGN = New System.Windows.Forms.CheckBox()
        Me.GRIDDESIGNDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDDESIGN = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GDESIGNCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKVALUE = New System.Windows.Forms.CheckBox()
        Me.CMBJOB = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CHKCONSUMPTION = New System.Windows.Forms.CheckBox()
        Me.ChkStock = New System.Windows.Forms.CheckBox()
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RDBDESIGN = New System.Windows.Forms.RadioButton()
        Me.RDBSUMMWITHIMG = New System.Windows.Forms.RadioButton()
        Me.RBMERCHANTSUPERSUMM = New System.Windows.Forms.RadioButton()
        Me.RDBLABOURCOST = New System.Windows.Forms.RadioButton()
        Me.RBSUPERSUMMARY = New System.Windows.Forms.RadioButton()
        Me.RDOMERCHANTSUMMARY = New System.Windows.Forms.RadioButton()
        Me.RDBJOB = New System.Windows.Forms.RadioButton()
        Me.RDBMERCHANT = New System.Windows.Forms.RadioButton()
        Me.rdblabour = New System.Windows.Forms.RadioButton()
        Me.RDBMONTHLY = New System.Windows.Forms.RadioButton()
        Me.Rdbsummary = New System.Windows.Forms.RadioButton()
        Me.rdbdetail = New System.Windows.Forms.RadioButton()
        Me.cmbMerchant = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbprocess = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.cmdshowreport = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.lblheading = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        Me.GPDESIGN.SuspendLayout()
        CType(Me.GRIDDESIGNDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDDESIGN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBDEPARTMENT)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.CMBPIECETYPE)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.GPDESIGN)
        Me.BlendPanel1.Controls.Add(Me.CHKVALUE)
        Me.BlendPanel1.Controls.Add(Me.CMBJOB)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.CHKCONSUMPTION)
        Me.BlendPanel1.Controls.Add(Me.ChkStock)
        Me.BlendPanel1.Controls.Add(Me.CMBDESIGN)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox3)
        Me.BlendPanel1.Controls.Add(Me.cmbMerchant)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.cmbprocess)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.cmdshowreport)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lblheading)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(728, 510)
        Me.BlendPanel1.TabIndex = 5
        '
        'CMBDEPARTMENT
        '
        Me.CMBDEPARTMENT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDEPARTMENT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDEPARTMENT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDEPARTMENT.FormattingEnabled = True
        Me.CMBDEPARTMENT.Location = New System.Drawing.Point(84, 131)
        Me.CMBDEPARTMENT.MaxDropDownItems = 14
        Me.CMBDEPARTMENT.Name = "CMBDEPARTMENT"
        Me.CMBDEPARTMENT.Size = New System.Drawing.Size(215, 22)
        Me.CMBDEPARTMENT.TabIndex = 762
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(10, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 14)
        Me.Label6.TabIndex = 763
        Me.Label6.Text = "Department"
        '
        'CMBPIECETYPE
        '
        Me.CMBPIECETYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPIECETYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPIECETYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPIECETYPE.FormattingEnabled = True
        Me.CMBPIECETYPE.Location = New System.Drawing.Point(373, 47)
        Me.CMBPIECETYPE.MaxDropDownItems = 14
        Me.CMBPIECETYPE.Name = "CMBPIECETYPE"
        Me.CMBPIECETYPE.Size = New System.Drawing.Size(230, 22)
        Me.CMBPIECETYPE.TabIndex = 753
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(314, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 14)
        Me.Label5.TabIndex = 754
        Me.Label5.Text = "Piece Type"
        '
        'GPDESIGN
        '
        Me.GPDESIGN.BackColor = System.Drawing.Color.Transparent
        Me.GPDESIGN.Controls.Add(Me.CHKSELECTDESIGN)
        Me.GPDESIGN.Controls.Add(Me.GRIDDESIGNDETAILS)
        Me.GPDESIGN.Location = New System.Drawing.Point(464, 80)
        Me.GPDESIGN.Name = "GPDESIGN"
        Me.GPDESIGN.Size = New System.Drawing.Size(264, 404)
        Me.GPDESIGN.TabIndex = 761
        Me.GPDESIGN.TabStop = False
        Me.GPDESIGN.Text = "Design"
        '
        'CHKSELECTDESIGN
        '
        Me.CHKSELECTDESIGN.AutoSize = True
        Me.CHKSELECTDESIGN.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTDESIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTDESIGN.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTDESIGN.Location = New System.Drawing.Point(33, 23)
        Me.CHKSELECTDESIGN.Name = "CHKSELECTDESIGN"
        Me.CHKSELECTDESIGN.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTDESIGN.TabIndex = 0
        Me.CHKSELECTDESIGN.Text = "Select All"
        Me.CHKSELECTDESIGN.UseVisualStyleBackColor = False
        '
        'GRIDDESIGNDETAILS
        '
        Me.GRIDDESIGNDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDDESIGNDETAILS.Location = New System.Drawing.Point(6, 22)
        Me.GRIDDESIGNDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDDESIGNDETAILS.MainView = Me.GRIDDESIGN
        Me.GRIDDESIGNDETAILS.Name = "GRIDDESIGNDETAILS"
        Me.GRIDDESIGNDETAILS.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit5})
        Me.GRIDDESIGNDETAILS.Size = New System.Drawing.Size(246, 376)
        Me.GRIDDESIGNDETAILS.TabIndex = 1
        Me.GRIDDESIGNDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDDESIGN})
        '
        'GRIDDESIGN
        '
        Me.GRIDDESIGN.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDDESIGN.Appearance.Row.Options.UseFont = True
        Me.GRIDDESIGN.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GDESIGNCHK, Me.GDESIGNNO})
        Me.GRIDDESIGN.GridControl = Me.GRIDDESIGNDETAILS
        Me.GRIDDESIGN.Name = "GRIDDESIGN"
        Me.GRIDDESIGN.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDDESIGN.OptionsView.ColumnAutoWidth = False
        Me.GRIDDESIGN.OptionsView.ShowAutoFilterRow = True
        Me.GRIDDESIGN.OptionsView.ShowGroupPanel = False
        '
        'GDESIGNCHK
        '
        Me.GDESIGNCHK.ColumnEdit = Me.RepositoryItemCheckEdit5
        Me.GDESIGNCHK.FieldName = "CHK"
        Me.GDESIGNCHK.Name = "GDESIGNCHK"
        Me.GDESIGNCHK.OptionsColumn.ShowCaption = False
        Me.GDESIGNCHK.Visible = True
        Me.GDESIGNCHK.VisibleIndex = 0
        Me.GDESIGNCHK.Width = 35
        '
        'RepositoryItemCheckEdit5
        '
        Me.RepositoryItemCheckEdit5.AutoHeight = False
        Me.RepositoryItemCheckEdit5.Name = "RepositoryItemCheckEdit5"
        Me.RepositoryItemCheckEdit5.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.ImageIndex = 0
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.OptionsColumn.AllowEdit = False
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 1
        Me.GDESIGNNO.Width = 165
        '
        'CHKVALUE
        '
        Me.CHKVALUE.AutoSize = True
        Me.CHKVALUE.BackColor = System.Drawing.Color.Transparent
        Me.CHKVALUE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKVALUE.ForeColor = System.Drawing.Color.Black
        Me.CHKVALUE.Location = New System.Drawing.Point(43, 383)
        Me.CHKVALUE.Name = "CHKVALUE"
        Me.CHKVALUE.Size = New System.Drawing.Size(86, 18)
        Me.CHKVALUE.TabIndex = 440
        Me.CHKVALUE.Text = "With Value"
        Me.CHKVALUE.UseVisualStyleBackColor = False
        '
        'CMBJOB
        '
        Me.CMBJOB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBJOB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBJOB.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBJOB.FormattingEnabled = True
        Me.CMBJOB.Location = New System.Drawing.Point(224, 103)
        Me.CMBJOB.MaxDropDownItems = 14
        Me.CMBJOB.Name = "CMBJOB"
        Me.CMBJOB.Size = New System.Drawing.Size(75, 22)
        Me.CMBJOB.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(196, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 14)
        Me.Label4.TabIndex = 439
        Me.Label4.Text = "Job"
        '
        'CHKCONSUMPTION
        '
        Me.CHKCONSUMPTION.AutoSize = True
        Me.CHKCONSUMPTION.BackColor = System.Drawing.Color.Transparent
        Me.CHKCONSUMPTION.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKCONSUMPTION.ForeColor = System.Drawing.Color.Black
        Me.CHKCONSUMPTION.Location = New System.Drawing.Point(143, 168)
        Me.CHKCONSUMPTION.Name = "CHKCONSUMPTION"
        Me.CHKCONSUMPTION.Size = New System.Drawing.Size(126, 18)
        Me.CHKCONSUMPTION.TabIndex = 6
        Me.CHKCONSUMPTION.Text = "Consumption  Cost"
        Me.CHKCONSUMPTION.UseVisualStyleBackColor = False
        '
        'ChkStock
        '
        Me.ChkStock.AutoSize = True
        Me.ChkStock.BackColor = System.Drawing.Color.Transparent
        Me.ChkStock.Checked = True
        Me.ChkStock.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkStock.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkStock.ForeColor = System.Drawing.Color.Black
        Me.ChkStock.Location = New System.Drawing.Point(65, 168)
        Me.ChkStock.Name = "ChkStock"
        Me.ChkStock.Size = New System.Drawing.Size(54, 18)
        Me.ChkStock.TabIndex = 5
        Me.ChkStock.Text = "Stock"
        Me.ChkStock.UseVisualStyleBackColor = False
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(84, 103)
        Me.CMBDESIGN.MaxDropDownItems = 14
        Me.CMBDESIGN.Name = "CMBDESIGN"
        Me.CMBDESIGN.Size = New System.Drawing.Size(83, 22)
        Me.CMBDESIGN.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(37, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 14)
        Me.Label1.TabIndex = 437
        Me.Label1.Text = "Design"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RDBDESIGN)
        Me.GroupBox3.Controls.Add(Me.RDBSUMMWITHIMG)
        Me.GroupBox3.Controls.Add(Me.RBMERCHANTSUPERSUMM)
        Me.GroupBox3.Controls.Add(Me.RDBLABOURCOST)
        Me.GroupBox3.Controls.Add(Me.RBSUPERSUMMARY)
        Me.GroupBox3.Controls.Add(Me.RDOMERCHANTSUMMARY)
        Me.GroupBox3.Controls.Add(Me.RDBJOB)
        Me.GroupBox3.Controls.Add(Me.RDBMERCHANT)
        Me.GroupBox3.Controls.Add(Me.rdblabour)
        Me.GroupBox3.Controls.Add(Me.RDBMONTHLY)
        Me.GroupBox3.Controls.Add(Me.Rdbsummary)
        Me.GroupBox3.Controls.Add(Me.rdbdetail)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(27, 196)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(431, 181)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Reports"
        '
        'RDBDESIGN
        '
        Me.RDBDESIGN.AutoSize = True
        Me.RDBDESIGN.Location = New System.Drawing.Point(362, 75)
        Me.RDBDESIGN.Name = "RDBDESIGN"
        Me.RDBDESIGN.Size = New System.Drawing.Size(63, 18)
        Me.RDBDESIGN.TabIndex = 11
        Me.RDBDESIGN.Text = "Design"
        Me.RDBDESIGN.UseVisualStyleBackColor = True
        '
        'RDBSUMMWITHIMG
        '
        Me.RDBSUMMWITHIMG.AutoSize = True
        Me.RDBSUMMWITHIMG.Location = New System.Drawing.Point(256, 99)
        Me.RDBSUMMWITHIMG.Name = "RDBSUMMWITHIMG"
        Me.RDBSUMMWITHIMG.Size = New System.Drawing.Size(126, 18)
        Me.RDBSUMMWITHIMG.TabIndex = 10
        Me.RDBSUMMWITHIMG.Text = "Summary With Img"
        Me.RDBSUMMWITHIMG.UseVisualStyleBackColor = True
        Me.RDBSUMMWITHIMG.Visible = False
        '
        'RBMERCHANTSUPERSUMM
        '
        Me.RBMERCHANTSUPERSUMM.AutoSize = True
        Me.RBMERCHANTSUPERSUMM.Location = New System.Drawing.Point(16, 147)
        Me.RBMERCHANTSUPERSUMM.Name = "RBMERCHANTSUPERSUMM"
        Me.RBMERCHANTSUPERSUMM.Size = New System.Drawing.Size(185, 18)
        Me.RBMERCHANTSUPERSUMM.TabIndex = 9
        Me.RBMERCHANTSUPERSUMM.Text = "Merchant Wise Cost Summary"
        Me.RBMERCHANTSUPERSUMM.UseVisualStyleBackColor = True
        Me.RBMERCHANTSUPERSUMM.Visible = False
        '
        'RDBLABOURCOST
        '
        Me.RDBLABOURCOST.AutoSize = True
        Me.RDBLABOURCOST.Location = New System.Drawing.Point(16, 99)
        Me.RDBLABOURCOST.Name = "RDBLABOURCOST"
        Me.RDBLABOURCOST.Size = New System.Drawing.Size(146, 18)
        Me.RDBLABOURCOST.TabIndex = 8
        Me.RDBLABOURCOST.Text = "Labour wise color cost"
        Me.RDBLABOURCOST.UseVisualStyleBackColor = True
        Me.RDBLABOURCOST.Visible = False
        '
        'RBSUPERSUMMARY
        '
        Me.RBSUPERSUMMARY.AutoSize = True
        Me.RBSUPERSUMMARY.Location = New System.Drawing.Point(16, 123)
        Me.RBSUPERSUMMARY.Name = "RBSUPERSUMMARY"
        Me.RBSUPERSUMMARY.Size = New System.Drawing.Size(172, 18)
        Me.RBSUPERSUMMARY.TabIndex = 7
        Me.RBSUPERSUMMARY.Text = "Design Wise Cost Summary"
        Me.RBSUPERSUMMARY.UseVisualStyleBackColor = True
        Me.RBSUPERSUMMARY.Visible = False
        '
        'RDOMERCHANTSUMMARY
        '
        Me.RDOMERCHANTSUMMARY.AutoSize = True
        Me.RDOMERCHANTSUMMARY.Location = New System.Drawing.Point(16, 75)
        Me.RDOMERCHANTSUMMARY.Name = "RDOMERCHANTSUMMARY"
        Me.RDOMERCHANTSUMMARY.Size = New System.Drawing.Size(167, 18)
        Me.RDOMERCHANTSUMMARY.TabIndex = 6
        Me.RDOMERCHANTSUMMARY.Text = "Merchant Summary (Stock)"
        Me.RDOMERCHANTSUMMARY.UseVisualStyleBackColor = True
        '
        'RDBJOB
        '
        Me.RDBJOB.AutoSize = True
        Me.RDBJOB.Location = New System.Drawing.Point(362, 27)
        Me.RDBJOB.Name = "RDBJOB"
        Me.RDBJOB.Size = New System.Drawing.Size(43, 18)
        Me.RDBJOB.TabIndex = 2
        Me.RDBJOB.Text = "Job"
        Me.RDBJOB.UseVisualStyleBackColor = True
        '
        'RDBMERCHANT
        '
        Me.RDBMERCHANT.AutoSize = True
        Me.RDBMERCHANT.Location = New System.Drawing.Point(256, 51)
        Me.RDBMERCHANT.Name = "RDBMERCHANT"
        Me.RDBMERCHANT.Size = New System.Drawing.Size(76, 18)
        Me.RDBMERCHANT.TabIndex = 4
        Me.RDBMERCHANT.Text = "Merchant"
        Me.RDBMERCHANT.UseVisualStyleBackColor = True
        '
        'rdblabour
        '
        Me.rdblabour.AutoSize = True
        Me.rdblabour.Location = New System.Drawing.Point(362, 51)
        Me.rdblabour.Name = "rdblabour"
        Me.rdblabour.Size = New System.Drawing.Size(62, 18)
        Me.rdblabour.TabIndex = 5
        Me.rdblabour.Text = "Labour"
        Me.rdblabour.UseVisualStyleBackColor = True
        '
        'RDBMONTHLY
        '
        Me.RDBMONTHLY.AutoSize = True
        Me.RDBMONTHLY.Location = New System.Drawing.Point(256, 27)
        Me.RDBMONTHLY.Name = "RDBMONTHLY"
        Me.RDBMONTHLY.Size = New System.Drawing.Size(69, 18)
        Me.RDBMONTHLY.TabIndex = 1
        Me.RDBMONTHLY.Text = "Monthly"
        Me.RDBMONTHLY.UseVisualStyleBackColor = True
        '
        'Rdbsummary
        '
        Me.Rdbsummary.AutoSize = True
        Me.Rdbsummary.Location = New System.Drawing.Point(16, 51)
        Me.Rdbsummary.Name = "Rdbsummary"
        Me.Rdbsummary.Size = New System.Drawing.Size(113, 18)
        Me.Rdbsummary.TabIndex = 3
        Me.Rdbsummary.Text = "Summary (Stock)"
        Me.Rdbsummary.UseVisualStyleBackColor = True
        '
        'rdbdetail
        '
        Me.rdbdetail.AutoSize = True
        Me.rdbdetail.Checked = True
        Me.rdbdetail.Location = New System.Drawing.Point(16, 27)
        Me.rdbdetail.Name = "rdbdetail"
        Me.rdbdetail.Size = New System.Drawing.Size(104, 18)
        Me.rdbdetail.TabIndex = 0
        Me.rdbdetail.TabStop = True
        Me.rdbdetail.Text = "Details (Stock)"
        Me.rdbdetail.UseVisualStyleBackColor = True
        '
        'cmbMerchant
        '
        Me.cmbMerchant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMerchant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMerchant.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMerchant.FormattingEnabled = True
        Me.cmbMerchant.Location = New System.Drawing.Point(84, 75)
        Me.cmbMerchant.MaxDropDownItems = 14
        Me.cmbMerchant.Name = "cmbMerchant"
        Me.cmbMerchant.Size = New System.Drawing.Size(215, 22)
        Me.cmbMerchant.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(24, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 14)
        Me.Label2.TabIndex = 435
        Me.Label2.Text = "Merchant"
        '
        'cmbprocess
        '
        Me.cmbprocess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbprocess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbprocess.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbprocess.FormattingEnabled = True
        Me.cmbprocess.Location = New System.Drawing.Point(84, 47)
        Me.cmbprocess.MaxDropDownItems = 14
        Me.cmbprocess.Name = "cmbprocess"
        Me.cmbprocess.Size = New System.Drawing.Size(215, 22)
        Me.cmbprocess.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(34, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 14)
        Me.Label8.TabIndex = 433
        Me.Label8.Text = "Process"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtfrom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.chkdate)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(27, 414)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 432
        Me.GroupBox1.TabStop = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(189, 20)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(161, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 14)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(50, 20)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtfrom.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(9, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "From :"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Checked = True
        Me.chkdate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(10, -2)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 0
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'cmdshowreport
        '
        Me.cmdshowreport.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowreport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowreport.FlatAppearance.BorderSize = 0
        Me.cmdshowreport.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowreport.ForeColor = System.Drawing.Color.Black
        Me.cmdshowreport.Location = New System.Drawing.Point(91, 479)
        Me.cmdshowreport.Name = "cmdshowreport"
        Me.cmdshowreport.Size = New System.Drawing.Size(84, 28)
        Me.cmdshowreport.TabIndex = 8
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
        Me.cmdexit.Location = New System.Drawing.Point(180, 479)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lblheading
        '
        Me.lblheading.AutoSize = True
        Me.lblheading.BackColor = System.Drawing.Color.Transparent
        Me.lblheading.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblheading.Location = New System.Drawing.Point(15, 6)
        Me.lblheading.Name = "lblheading"
        Me.lblheading.Size = New System.Drawing.Size(286, 29)
        Me.lblheading.TabIndex = 315
        Me.lblheading.Text = "Mfg (After Cutting) Register"
        '
        'mfg2filter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 510)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "mfg2filter"
        Me.Text = "Mfg. (After cutting) Register"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GPDESIGN.ResumeLayout(False)
        Me.GPDESIGN.PerformLayout()
        CType(Me.GRIDDESIGNDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDDESIGN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdbsummary As System.Windows.Forms.RadioButton
    Friend WithEvents rdbdetail As System.Windows.Forms.RadioButton
    Friend WithEvents cmbMerchant As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbprocess As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents cmdshowreport As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lblheading As System.Windows.Forms.Label
    Friend WithEvents CMBDESIGN As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMBJOB As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RBSUPERSUMMARY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBLABOURCOST As System.Windows.Forms.RadioButton
    Friend WithEvents RBMERCHANTSUPERSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents CHKCONSUMPTION As System.Windows.Forms.CheckBox
    Friend WithEvents ChkStock As System.Windows.Forms.CheckBox
    Friend WithEvents RDOMERCHANTSUMMARY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBJOB As System.Windows.Forms.RadioButton
    Friend WithEvents RDBMERCHANT As System.Windows.Forms.RadioButton
    Friend WithEvents rdblabour As System.Windows.Forms.RadioButton
    Friend WithEvents RDBMONTHLY As System.Windows.Forms.RadioButton
    Friend WithEvents CHKVALUE As System.Windows.Forms.CheckBox
    Friend WithEvents RDBSUMMWITHIMG As RadioButton
    Friend WithEvents CMBPIECETYPE As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GPDESIGN As GroupBox
    Friend WithEvents CHKSELECTDESIGN As CheckBox
    Private WithEvents GRIDDESIGNDETAILS As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDDESIGN As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GDESIGNCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RDBDESIGN As RadioButton
    Friend WithEvents CMBDEPARTMENT As ComboBox
    Friend WithEvents Label6 As Label
End Class
