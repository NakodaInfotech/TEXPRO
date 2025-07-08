<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BaleStockFilter
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CLB_CATEGORY = New System.Windows.Forms.CheckedListBox()
        Me.CMBCATEGORY = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CLB_DEPARTMENT = New System.Windows.Forms.CheckedListBox()
        Me.CLB_GRADE = New System.Windows.Forms.CheckedListBox()
        Me.TXTJOBNO = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTMERCHANT = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CHKVALUE = New System.Windows.Forms.CheckBox()
        Me.RDBSTOCKINHAND = New System.Windows.Forms.RadioButton()
        Me.RDBSTOCK = New System.Windows.Forms.RadioButton()
        Me.cmbratetype = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RBDEPARTMENTNOTOTAL = New System.Windows.Forms.RadioButton()
        Me.RBGRADENOTOTAL = New System.Windows.Forms.RadioButton()
        Me.RBCATEGORYNOTOTAL = New System.Windows.Forms.RadioButton()
        Me.RDBLOTDETAILS = New System.Windows.Forms.RadioButton()
        Me.RBDEPTSUMM = New System.Windows.Forms.RadioButton()
        Me.RBDEPTWISE = New System.Windows.Forms.RadioButton()
        Me.RBJOBSUMM = New System.Windows.Forms.RadioButton()
        Me.RBJOBWISE = New System.Windows.Forms.RadioButton()
        Me.RBMERCHANTNOTOTAL = New System.Windows.Forms.RadioButton()
        Me.RDBDESIGN = New System.Windows.Forms.RadioButton()
        Me.RadioMerchantDetail = New System.Windows.Forms.RadioButton()
        Me.RBRATE = New System.Windows.Forms.RadioButton()
        Me.RBMERCHANT = New System.Windows.Forms.RadioButton()
        Me.rdbdetail = New System.Windows.Forms.RadioButton()
        Me.RBCUTWISE = New System.Windows.Forms.RadioButton()
        Me.TXTBALENO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbDesign = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbmerchant = New System.Windows.Forms.ComboBox()
        Me.lblvendorname = New System.Windows.Forms.Label()
        Me.cmdshowreport = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.lblheading = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CLB_SUBCATEGORY = New System.Windows.Forms.CheckedListBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CLB_FOLD = New System.Windows.Forms.CheckedListBox()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label13)
        Me.BlendPanel1.Controls.Add(Me.CLB_FOLD)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.CLB_SUBCATEGORY)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CLB_CATEGORY)
        Me.BlendPanel1.Controls.Add(Me.CMBCATEGORY)
        Me.BlendPanel1.Controls.Add(Me.Label16)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.CLB_DEPARTMENT)
        Me.BlendPanel1.Controls.Add(Me.CLB_GRADE)
        Me.BlendPanel1.Controls.Add(Me.TXTJOBNO)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TXTMERCHANT)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.CHKVALUE)
        Me.BlendPanel1.Controls.Add(Me.RDBSTOCKINHAND)
        Me.BlendPanel1.Controls.Add(Me.RDBSTOCK)
        Me.BlendPanel1.Controls.Add(Me.cmbratetype)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.cmbtype)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.GroupBox3)
        Me.BlendPanel1.Controls.Add(Me.TXTBALENO)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.cmbDesign)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.cmbmerchant)
        Me.BlendPanel1.Controls.Add(Me.lblvendorname)
        Me.BlendPanel1.Controls.Add(Me.cmdshowreport)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lblheading)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(880, 561)
        Me.BlendPanel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(624, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 14)
        Me.Label2.TabIndex = 759
        Me.Label2.Text = "Category"
        '
        'CLB_CATEGORY
        '
        Me.CLB_CATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_CATEGORY.FormattingEnabled = True
        Me.CLB_CATEGORY.Location = New System.Drawing.Point(681, 56)
        Me.CLB_CATEGORY.Name = "CLB_CATEGORY"
        Me.CLB_CATEGORY.ScrollAlwaysVisible = True
        Me.CLB_CATEGORY.Size = New System.Drawing.Size(159, 72)
        Me.CLB_CATEGORY.TabIndex = 758
        Me.CLB_CATEGORY.TabStop = False
        '
        'CMBCATEGORY
        '
        Me.CMBCATEGORY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCATEGORY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCATEGORY.FormattingEnabled = True
        Me.CMBCATEGORY.Location = New System.Drawing.Point(103, 206)
        Me.CMBCATEGORY.MaxDropDownItems = 14
        Me.CMBCATEGORY.Name = "CMBCATEGORY"
        Me.CMBCATEGORY.Size = New System.Drawing.Size(234, 22)
        Me.CMBCATEGORY.TabIndex = 6
        Me.CMBCATEGORY.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(49, 210)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 14)
        Me.Label16.TabIndex = 538
        Me.Label16.Text = "Category"
        Me.Label16.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(359, 138)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 14)
        Me.Label15.TabIndex = 536
        Me.Label15.Text = "Department"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(391, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 14)
        Me.Label11.TabIndex = 526
        Me.Label11.Text = "Grade"
        '
        'CLB_DEPARTMENT
        '
        Me.CLB_DEPARTMENT.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_DEPARTMENT.FormattingEnabled = True
        Me.CLB_DEPARTMENT.Location = New System.Drawing.Point(432, 134)
        Me.CLB_DEPARTMENT.Name = "CLB_DEPARTMENT"
        Me.CLB_DEPARTMENT.ScrollAlwaysVisible = True
        Me.CLB_DEPARTMENT.Size = New System.Drawing.Size(159, 72)
        Me.CLB_DEPARTMENT.TabIndex = 10
        Me.CLB_DEPARTMENT.TabStop = False
        '
        'CLB_GRADE
        '
        Me.CLB_GRADE.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_GRADE.FormattingEnabled = True
        Me.CLB_GRADE.Location = New System.Drawing.Point(432, 56)
        Me.CLB_GRADE.Name = "CLB_GRADE"
        Me.CLB_GRADE.ScrollAlwaysVisible = True
        Me.CLB_GRADE.Size = New System.Drawing.Size(159, 72)
        Me.CLB_GRADE.TabIndex = 9
        Me.CLB_GRADE.TabStop = False
        '
        'TXTJOBNO
        '
        Me.TXTJOBNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTJOBNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTJOBNO.Location = New System.Drawing.Point(103, 234)
        Me.TXTJOBNO.Name = "TXTJOBNO"
        Me.TXTJOBNO.Size = New System.Drawing.Size(89, 22)
        Me.TXTJOBNO.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(59, 238)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 14)
        Me.Label10.TabIndex = 458
        Me.Label10.Text = "Job No"
        '
        'TXTMERCHANT
        '
        Me.TXTMERCHANT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTMERCHANT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMERCHANT.Location = New System.Drawing.Point(103, 122)
        Me.TXTMERCHANT.Name = "TXTMERCHANT"
        Me.TXTMERCHANT.Size = New System.Drawing.Size(234, 22)
        Me.TXTMERCHANT.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(23, 126)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 14)
        Me.Label9.TabIndex = 457
        Me.Label9.Text = "Merchant Like"
        '
        'CHKVALUE
        '
        Me.CHKVALUE.AutoSize = True
        Me.CHKVALUE.BackColor = System.Drawing.Color.Transparent
        Me.CHKVALUE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKVALUE.ForeColor = System.Drawing.Color.Black
        Me.CHKVALUE.Location = New System.Drawing.Point(35, 486)
        Me.CHKVALUE.Name = "CHKVALUE"
        Me.CHKVALUE.Size = New System.Drawing.Size(86, 18)
        Me.CHKVALUE.TabIndex = 14
        Me.CHKVALUE.Text = "With Value"
        Me.CHKVALUE.UseVisualStyleBackColor = False
        '
        'RDBSTOCKINHAND
        '
        Me.RDBSTOCKINHAND.AutoSize = True
        Me.RDBSTOCKINHAND.BackColor = System.Drawing.Color.Transparent
        Me.RDBSTOCKINHAND.Location = New System.Drawing.Point(172, 296)
        Me.RDBSTOCKINHAND.Name = "RDBSTOCKINHAND"
        Me.RDBSTOCKINHAND.Size = New System.Drawing.Size(100, 19)
        Me.RDBSTOCKINHAND.TabIndex = 12
        Me.RDBSTOCKINHAND.Text = "Stock In Hand"
        Me.RDBSTOCKINHAND.UseVisualStyleBackColor = False
        '
        'RDBSTOCK
        '
        Me.RDBSTOCK.AutoSize = True
        Me.RDBSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.RDBSTOCK.Checked = True
        Me.RDBSTOCK.Location = New System.Drawing.Point(92, 296)
        Me.RDBSTOCK.Name = "RDBSTOCK"
        Me.RDBSTOCK.Size = New System.Drawing.Size(73, 19)
        Me.RDBSTOCK.TabIndex = 11
        Me.RDBSTOCK.TabStop = True
        Me.RDBSTOCK.Text = "All Bales"
        Me.RDBSTOCK.UseVisualStyleBackColor = False
        '
        'cmbratetype
        '
        Me.cmbratetype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbratetype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbratetype.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbratetype.FormattingEnabled = True
        Me.cmbratetype.Location = New System.Drawing.Point(103, 178)
        Me.cmbratetype.MaxDropDownItems = 14
        Me.cmbratetype.Name = "cmbratetype"
        Me.cmbratetype.Size = New System.Drawing.Size(233, 22)
        Me.cmbratetype.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(69, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 14)
        Me.Label7.TabIndex = 451
        Me.Label7.Text = "Rate"
        '
        'cmbtype
        '
        Me.cmbtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtype.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtype.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"Final Packing", "Job", "Full"})
        Me.cmbtype.Location = New System.Drawing.Point(103, 38)
        Me.cmbtype.MaxDropDownItems = 14
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(77, 22)
        Me.cmbtype.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(70, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 447
        Me.Label1.Text = "Type"
        '
        'txtadd
        '
        Me.txtadd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.Location = New System.Drawing.Point(317, 38)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(20, 22)
        Me.txtadd.TabIndex = 444
        Me.txtadd.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RBDEPARTMENTNOTOTAL)
        Me.GroupBox3.Controls.Add(Me.RBGRADENOTOTAL)
        Me.GroupBox3.Controls.Add(Me.RBCATEGORYNOTOTAL)
        Me.GroupBox3.Controls.Add(Me.RDBLOTDETAILS)
        Me.GroupBox3.Controls.Add(Me.RBDEPTSUMM)
        Me.GroupBox3.Controls.Add(Me.RBDEPTWISE)
        Me.GroupBox3.Controls.Add(Me.RBJOBSUMM)
        Me.GroupBox3.Controls.Add(Me.RBJOBWISE)
        Me.GroupBox3.Controls.Add(Me.RBMERCHANTNOTOTAL)
        Me.GroupBox3.Controls.Add(Me.RDBDESIGN)
        Me.GroupBox3.Controls.Add(Me.RadioMerchantDetail)
        Me.GroupBox3.Controls.Add(Me.RBRATE)
        Me.GroupBox3.Controls.Add(Me.RBMERCHANT)
        Me.GroupBox3.Controls.Add(Me.rdbdetail)
        Me.GroupBox3.Controls.Add(Me.RBCUTWISE)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(16, 321)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(780, 159)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Reports"
        '
        'RBDEPARTMENTNOTOTAL
        '
        Me.RBDEPARTMENTNOTOTAL.AutoSize = True
        Me.RBDEPARTMENTNOTOTAL.Location = New System.Drawing.Point(531, 45)
        Me.RBDEPARTMENTNOTOTAL.Name = "RBDEPARTMENTNOTOTAL"
        Me.RBDEPARTMENTNOTOTAL.Size = New System.Drawing.Size(206, 18)
        Me.RBDEPARTMENTNOTOTAL.TabIndex = 14
        Me.RBDEPARTMENTNOTOTAL.Text = "Department Wise (Without Total)"
        Me.RBDEPARTMENTNOTOTAL.UseVisualStyleBackColor = True
        '
        'RBGRADENOTOTAL
        '
        Me.RBGRADENOTOTAL.AutoSize = True
        Me.RBGRADENOTOTAL.Location = New System.Drawing.Point(531, 69)
        Me.RBGRADENOTOTAL.Name = "RBGRADENOTOTAL"
        Me.RBGRADENOTOTAL.Size = New System.Drawing.Size(174, 18)
        Me.RBGRADENOTOTAL.TabIndex = 13
        Me.RBGRADENOTOTAL.Text = "Grade Wise (Without Total)"
        Me.RBGRADENOTOTAL.UseVisualStyleBackColor = True
        '
        'RBCATEGORYNOTOTAL
        '
        Me.RBCATEGORYNOTOTAL.AutoSize = True
        Me.RBCATEGORYNOTOTAL.Location = New System.Drawing.Point(531, 21)
        Me.RBCATEGORYNOTOTAL.Name = "RBCATEGORYNOTOTAL"
        Me.RBCATEGORYNOTOTAL.Size = New System.Drawing.Size(187, 18)
        Me.RBCATEGORYNOTOTAL.TabIndex = 12
        Me.RBCATEGORYNOTOTAL.Text = "Category Wise (Without Total)"
        Me.RBCATEGORYNOTOTAL.UseVisualStyleBackColor = True
        '
        'RDBLOTDETAILS
        '
        Me.RDBLOTDETAILS.AutoSize = True
        Me.RDBLOTDETAILS.Location = New System.Drawing.Point(218, 93)
        Me.RDBLOTDETAILS.Name = "RDBLOTDETAILS"
        Me.RDBLOTDETAILS.Size = New System.Drawing.Size(115, 18)
        Me.RDBLOTDETAILS.TabIndex = 11
        Me.RDBLOTDETAILS.Text = "Detail (With Lot)"
        Me.RDBLOTDETAILS.UseVisualStyleBackColor = True
        '
        'RBDEPTSUMM
        '
        Me.RBDEPTSUMM.AutoSize = True
        Me.RBDEPTSUMM.Location = New System.Drawing.Point(360, 93)
        Me.RBDEPTSUMM.Name = "RBDEPTSUMM"
        Me.RBDEPTSUMM.Size = New System.Drawing.Size(134, 18)
        Me.RBDEPTSUMM.TabIndex = 10
        Me.RBDEPTSUMM.Text = "Dept Wise Summary"
        Me.RBDEPTSUMM.UseVisualStyleBackColor = True
        '
        'RBDEPTWISE
        '
        Me.RBDEPTWISE.AutoSize = True
        Me.RBDEPTWISE.Location = New System.Drawing.Point(360, 69)
        Me.RBDEPTWISE.Name = "RBDEPTWISE"
        Me.RBDEPTWISE.Size = New System.Drawing.Size(82, 18)
        Me.RBDEPTWISE.TabIndex = 9
        Me.RBDEPTWISE.Text = "Dept Wise"
        Me.RBDEPTWISE.UseVisualStyleBackColor = True
        '
        'RBJOBSUMM
        '
        Me.RBJOBSUMM.AutoSize = True
        Me.RBJOBSUMM.Location = New System.Drawing.Point(360, 45)
        Me.RBJOBSUMM.Name = "RBJOBSUMM"
        Me.RBJOBSUMM.Size = New System.Drawing.Size(126, 18)
        Me.RBJOBSUMM.TabIndex = 8
        Me.RBJOBSUMM.Text = "Job Wise Summary"
        Me.RBJOBSUMM.UseVisualStyleBackColor = True
        '
        'RBJOBWISE
        '
        Me.RBJOBWISE.AutoSize = True
        Me.RBJOBWISE.Location = New System.Drawing.Point(360, 21)
        Me.RBJOBWISE.Name = "RBJOBWISE"
        Me.RBJOBWISE.Size = New System.Drawing.Size(74, 18)
        Me.RBJOBWISE.TabIndex = 7
        Me.RBJOBWISE.Text = "Job Wise"
        Me.RBJOBWISE.UseVisualStyleBackColor = True
        '
        'RBMERCHANTNOTOTAL
        '
        Me.RBMERCHANTNOTOTAL.AutoSize = True
        Me.RBMERCHANTNOTOTAL.Location = New System.Drawing.Point(19, 93)
        Me.RBMERCHANTNOTOTAL.Name = "RBMERCHANTNOTOTAL"
        Me.RBMERCHANTNOTOTAL.Size = New System.Drawing.Size(192, 18)
        Me.RBMERCHANTNOTOTAL.TabIndex = 3
        Me.RBMERCHANTNOTOTAL.Text = "Merchant Wise (Without Total)"
        Me.RBMERCHANTNOTOTAL.UseVisualStyleBackColor = True
        '
        'RDBDESIGN
        '
        Me.RDBDESIGN.AutoSize = True
        Me.RDBDESIGN.Location = New System.Drawing.Point(218, 69)
        Me.RDBDESIGN.Name = "RDBDESIGN"
        Me.RDBDESIGN.Size = New System.Drawing.Size(131, 18)
        Me.RDBDESIGN.TabIndex = 6
        Me.RDBDESIGN.Text = "Design Wise Detail"
        Me.RDBDESIGN.UseVisualStyleBackColor = True
        '
        'RadioMerchantDetail
        '
        Me.RadioMerchantDetail.AutoSize = True
        Me.RadioMerchantDetail.Location = New System.Drawing.Point(19, 69)
        Me.RadioMerchantDetail.Name = "RadioMerchantDetail"
        Me.RadioMerchantDetail.Size = New System.Drawing.Size(144, 18)
        Me.RadioMerchantDetail.TabIndex = 2
        Me.RadioMerchantDetail.Text = "Merchant Wise Detail"
        Me.RadioMerchantDetail.UseVisualStyleBackColor = True
        '
        'RBRATE
        '
        Me.RBRATE.AutoSize = True
        Me.RBRATE.Location = New System.Drawing.Point(218, 45)
        Me.RBRATE.Name = "RBRATE"
        Me.RBRATE.Size = New System.Drawing.Size(89, 18)
        Me.RBRATE.TabIndex = 5
        Me.RBRATE.Text = "Rate Report"
        Me.RBRATE.UseVisualStyleBackColor = True
        Me.RBRATE.Visible = False
        '
        'RBMERCHANT
        '
        Me.RBMERCHANT.AutoSize = True
        Me.RBMERCHANT.Location = New System.Drawing.Point(218, 21)
        Me.RBMERCHANT.Name = "RBMERCHANT"
        Me.RBMERCHANT.Size = New System.Drawing.Size(107, 18)
        Me.RBMERCHANT.TabIndex = 4
        Me.RBMERCHANT.Text = "Merchant Wise"
        Me.RBMERCHANT.UseVisualStyleBackColor = True
        '
        'rdbdetail
        '
        Me.rdbdetail.AutoSize = True
        Me.rdbdetail.Checked = True
        Me.rdbdetail.Location = New System.Drawing.Point(19, 21)
        Me.rdbdetail.Name = "rdbdetail"
        Me.rdbdetail.Size = New System.Drawing.Size(59, 18)
        Me.rdbdetail.TabIndex = 0
        Me.rdbdetail.TabStop = True
        Me.rdbdetail.Text = "Detail"
        Me.rdbdetail.UseVisualStyleBackColor = True
        '
        'RBCUTWISE
        '
        Me.RBCUTWISE.AutoSize = True
        Me.RBCUTWISE.Location = New System.Drawing.Point(19, 45)
        Me.RBCUTWISE.Name = "RBCUTWISE"
        Me.RBCUTWISE.Size = New System.Drawing.Size(73, 18)
        Me.RBCUTWISE.TabIndex = 1
        Me.RBCUTWISE.Text = "Cut Wise"
        Me.RBCUTWISE.UseVisualStyleBackColor = True
        '
        'TXTBALENO
        '
        Me.TXTBALENO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBALENO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBALENO.Location = New System.Drawing.Point(103, 150)
        Me.TXTBALENO.Name = "TXTBALENO"
        Me.TXTBALENO.Size = New System.Drawing.Size(77, 22)
        Me.TXTBALENO.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(50, 154)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 14)
        Me.Label3.TabIndex = 437
        Me.Label3.Text = "Bale No."
        '
        'cmbDesign
        '
        Me.cmbDesign.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDesign.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDesign.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDesign.FormattingEnabled = True
        Me.cmbDesign.Location = New System.Drawing.Point(103, 262)
        Me.cmbDesign.MaxDropDownItems = 14
        Me.cmbDesign.Name = "cmbDesign"
        Me.cmbDesign.Size = New System.Drawing.Size(89, 22)
        Me.cmbDesign.TabIndex = 8
        Me.cmbDesign.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(57, 266)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 14)
        Me.Label6.TabIndex = 436
        Me.Label6.Text = "Design"
        Me.Label6.Visible = False
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(103, 66)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(233, 22)
        Me.cmbname.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(62, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 14)
        Me.Label8.TabIndex = 433
        Me.Label8.Text = "Name"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Checked = True
        Me.chkdate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(160, 498)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 15
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
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(124, 498)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox2.TabIndex = 16
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
        'cmbmerchant
        '
        Me.cmbmerchant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbmerchant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbmerchant.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbmerchant.FormattingEnabled = True
        Me.cmbmerchant.Location = New System.Drawing.Point(103, 94)
        Me.cmbmerchant.MaxDropDownItems = 14
        Me.cmbmerchant.Name = "cmbmerchant"
        Me.cmbmerchant.Size = New System.Drawing.Size(233, 22)
        Me.cmbmerchant.TabIndex = 2
        '
        'lblvendorname
        '
        Me.lblvendorname.AutoSize = True
        Me.lblvendorname.BackColor = System.Drawing.Color.Transparent
        Me.lblvendorname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvendorname.ForeColor = System.Drawing.Color.Black
        Me.lblvendorname.Location = New System.Drawing.Point(45, 98)
        Me.lblvendorname.Name = "lblvendorname"
        Me.lblvendorname.Size = New System.Drawing.Size(58, 14)
        Me.lblvendorname.TabIndex = 419
        Me.lblvendorname.Text = "Merchant"
        '
        'cmdshowreport
        '
        Me.cmdshowreport.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowreport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowreport.FlatAppearance.BorderSize = 0
        Me.cmdshowreport.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowreport.ForeColor = System.Drawing.Color.Black
        Me.cmdshowreport.Location = New System.Drawing.Point(464, 508)
        Me.cmdshowreport.Name = "cmdshowreport"
        Me.cmdshowreport.Size = New System.Drawing.Size(86, 28)
        Me.cmdshowreport.TabIndex = 17
        Me.cmdshowreport.Text = "&Show Details"
        Me.cmdshowreport.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(556, 508)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(86, 28)
        Me.cmdexit.TabIndex = 18
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lblheading
        '
        Me.lblheading.AutoSize = True
        Me.lblheading.BackColor = System.Drawing.Color.Transparent
        Me.lblheading.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblheading.Location = New System.Drawing.Point(8, 4)
        Me.lblheading.Name = "lblheading"
        Me.lblheading.Size = New System.Drawing.Size(163, 23)
        Me.lblheading.TabIndex = 315
        Me.lblheading.Text = "Bale Stock Register"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(601, 138)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 14)
        Me.Label12.TabIndex = 761
        Me.Label12.Text = "Sub Category"
        '
        'CLB_SUBCATEGORY
        '
        Me.CLB_SUBCATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_SUBCATEGORY.FormattingEnabled = True
        Me.CLB_SUBCATEGORY.Location = New System.Drawing.Point(681, 134)
        Me.CLB_SUBCATEGORY.Name = "CLB_SUBCATEGORY"
        Me.CLB_SUBCATEGORY.ScrollAlwaysVisible = True
        Me.CLB_SUBCATEGORY.Size = New System.Drawing.Size(159, 72)
        Me.CLB_SUBCATEGORY.TabIndex = 760
        Me.CLB_SUBCATEGORY.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(400, 216)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 14)
        Me.Label13.TabIndex = 763
        Me.Label13.Text = "Fold"
        '
        'CLB_FOLD
        '
        Me.CLB_FOLD.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_FOLD.FormattingEnabled = True
        Me.CLB_FOLD.Location = New System.Drawing.Point(432, 212)
        Me.CLB_FOLD.Name = "CLB_FOLD"
        Me.CLB_FOLD.ScrollAlwaysVisible = True
        Me.CLB_FOLD.Size = New System.Drawing.Size(159, 72)
        Me.CLB_FOLD.TabIndex = 762
        Me.CLB_FOLD.TabStop = False
        '
        'BaleStockFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(880, 561)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "BaleStockFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Bale Stock Register"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbdetail As System.Windows.Forms.RadioButton
    Friend WithEvents RBCUTWISE As System.Windows.Forms.RadioButton
    Friend WithEvents TXTBALENO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbDesign As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbmerchant As System.Windows.Forms.ComboBox
    Friend WithEvents lblvendorname As System.Windows.Forms.Label
    Friend WithEvents cmdshowreport As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lblheading As System.Windows.Forms.Label
    Friend WithEvents cmbratetype As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RDBSTOCKINHAND As System.Windows.Forms.RadioButton
    Friend WithEvents RDBSTOCK As System.Windows.Forms.RadioButton
    Friend WithEvents RBRATE As System.Windows.Forms.RadioButton
    Friend WithEvents RBMERCHANT As System.Windows.Forms.RadioButton
    Friend WithEvents RadioMerchantDetail As System.Windows.Forms.RadioButton
    Friend WithEvents RDBDESIGN As System.Windows.Forms.RadioButton
    Friend WithEvents CHKVALUE As System.Windows.Forms.CheckBox
    Friend WithEvents RBMERCHANTNOTOTAL As System.Windows.Forms.RadioButton
    Friend WithEvents TXTMERCHANT As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RBJOBWISE As System.Windows.Forms.RadioButton
    Friend WithEvents RBJOBSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents TXTJOBNO As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CLB_GRADE As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label15 As Label
    Friend WithEvents CLB_DEPARTMENT As CheckedListBox
    Friend WithEvents RBDEPTSUMM As RadioButton
    Friend WithEvents RBDEPTWISE As RadioButton
    Friend WithEvents CMBCATEGORY As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents RDBLOTDETAILS As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents CLB_CATEGORY As CheckedListBox
    Friend WithEvents RBCATEGORYNOTOTAL As RadioButton
    Friend WithEvents RBDEPARTMENTNOTOTAL As RadioButton
    Friend WithEvents RBGRADENOTOTAL As RadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents CLB_SUBCATEGORY As CheckedListBox
    Friend WithEvents Label13 As Label
    Friend WithEvents CLB_FOLD As CheckedListBox
End Class
