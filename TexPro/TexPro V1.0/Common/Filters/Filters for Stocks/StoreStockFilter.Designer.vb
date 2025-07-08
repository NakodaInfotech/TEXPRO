<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StoreStockFilter
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
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTISSUETO = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RBDEPTCONSUMEDSUMM = New System.Windows.Forms.RadioButton()
        Me.RBDEPTCONSUMED = New System.Windows.Forms.RadioButton()
        Me.RBDEPARTMENTSUMMPURRATE = New System.Windows.Forms.RadioButton()
        Me.RBDEPARTMENTWISEPURRATE = New System.Windows.Forms.RadioButton()
        Me.RDBDEPRTSUMM = New System.Windows.Forms.RadioButton()
        Me.RBDEPARTMENTWISE = New System.Windows.Forms.RadioButton()
        Me.RBCONSUMED = New System.Windows.Forms.RadioButton()
        Me.RBSTORE = New System.Windows.Forms.RadioButton()
        Me.RBMONTHWISE = New System.Windows.Forms.RadioButton()
        Me.CMDREPORT = New System.Windows.Forms.Button()
        Me.dtopening = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbdepartment = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbratetype = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbitemname = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CLB_DEPARTMENT = New System.Windows.Forms.CheckedListBox()
        Me.BlendPanel1.SuspendLayout()
        Me.BlendPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.BlendPanel2)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(873, 436)
        Me.BlendPanel1.TabIndex = 1
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.Label15)
        Me.BlendPanel2.Controls.Add(Me.CLB_DEPARTMENT)
        Me.BlendPanel2.Controls.Add(Me.Label5)
        Me.BlendPanel2.Controls.Add(Me.TXTISSUETO)
        Me.BlendPanel2.Controls.Add(Me.GroupBox3)
        Me.BlendPanel2.Controls.Add(Me.CMDREPORT)
        Me.BlendPanel2.Controls.Add(Me.dtopening)
        Me.BlendPanel2.Controls.Add(Me.Label4)
        Me.BlendPanel2.Controls.Add(Me.Label3)
        Me.BlendPanel2.Controls.Add(Me.cmbname)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.cmbdepartment)
        Me.BlendPanel2.Controls.Add(Me.Label11)
        Me.BlendPanel2.Controls.Add(Me.cmbratetype)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.cmbitemname)
        Me.BlendPanel2.Controls.Add(Me.Label9)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(873, 436)
        Me.BlendPanel2.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(54, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 14)
        Me.Label5.TabIndex = 643
        Me.Label5.Text = "Issue To"
        '
        'TXTISSUETO
        '
        Me.TXTISSUETO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTISSUETO.Location = New System.Drawing.Point(108, 124)
        Me.TXTISSUETO.Name = "TXTISSUETO"
        Me.TXTISSUETO.Size = New System.Drawing.Size(289, 22)
        Me.TXTISSUETO.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RBDEPTCONSUMEDSUMM)
        Me.GroupBox3.Controls.Add(Me.RBDEPTCONSUMED)
        Me.GroupBox3.Controls.Add(Me.RBDEPARTMENTSUMMPURRATE)
        Me.GroupBox3.Controls.Add(Me.RBDEPARTMENTWISEPURRATE)
        Me.GroupBox3.Controls.Add(Me.RDBDEPRTSUMM)
        Me.GroupBox3.Controls.Add(Me.RBDEPARTMENTWISE)
        Me.GroupBox3.Controls.Add(Me.RBCONSUMED)
        Me.GroupBox3.Controls.Add(Me.RBSTORE)
        Me.GroupBox3.Controls.Add(Me.RBMONTHWISE)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(18, 165)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(460, 157)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Reports"
        '
        'RBDEPTCONSUMEDSUMM
        '
        Me.RBDEPTCONSUMEDSUMM.AutoSize = True
        Me.RBDEPTCONSUMEDSUMM.Location = New System.Drawing.Point(12, 121)
        Me.RBDEPTCONSUMEDSUMM.Name = "RBDEPTCONSUMEDSUMM"
        Me.RBDEPTCONSUMEDSUMM.Size = New System.Drawing.Size(247, 18)
        Me.RBDEPTCONSUMEDSUMM.TabIndex = 8
        Me.RBDEPTCONSUMEDSUMM.Text = "Department Wise Consumption Summary"
        Me.RBDEPTCONSUMEDSUMM.UseVisualStyleBackColor = True
        '
        'RBDEPTCONSUMED
        '
        Me.RBDEPTCONSUMED.AutoSize = True
        Me.RBDEPTCONSUMED.Location = New System.Drawing.Point(12, 97)
        Me.RBDEPTCONSUMED.Name = "RBDEPTCONSUMED"
        Me.RBDEPTCONSUMED.Size = New System.Drawing.Size(195, 18)
        Me.RBDEPTCONSUMED.TabIndex = 3
        Me.RBDEPTCONSUMED.Text = "Department Wise Consumption"
        Me.RBDEPTCONSUMED.UseVisualStyleBackColor = True
        '
        'RBDEPARTMENTSUMMPURRATE
        '
        Me.RBDEPARTMENTSUMMPURRATE.AutoSize = True
        Me.RBDEPARTMENTSUMMPURRATE.Location = New System.Drawing.Point(216, 97)
        Me.RBDEPARTMENTSUMMPURRATE.Name = "RBDEPARTMENTSUMMPURRATE"
        Me.RBDEPARTMENTSUMMPURRATE.Size = New System.Drawing.Size(229, 18)
        Me.RBDEPARTMENTSUMMPURRATE.TabIndex = 7
        Me.RBDEPARTMENTSUMMPURRATE.Text = "Department Wise Summary (Pur Rate)"
        Me.RBDEPARTMENTSUMMPURRATE.UseVisualStyleBackColor = True
        '
        'RBDEPARTMENTWISEPURRATE
        '
        Me.RBDEPARTMENTWISEPURRATE.AutoSize = True
        Me.RBDEPARTMENTWISEPURRATE.Location = New System.Drawing.Point(216, 49)
        Me.RBDEPARTMENTWISEPURRATE.Name = "RBDEPARTMENTWISEPURRATE"
        Me.RBDEPARTMENTWISEPURRATE.Size = New System.Drawing.Size(214, 18)
        Me.RBDEPARTMENTWISEPURRATE.TabIndex = 5
        Me.RBDEPARTMENTWISEPURRATE.Text = "Department Wise Detail (Pur Rate)"
        Me.RBDEPARTMENTWISEPURRATE.UseVisualStyleBackColor = True
        '
        'RDBDEPRTSUMM
        '
        Me.RDBDEPRTSUMM.AutoSize = True
        Me.RDBDEPRTSUMM.Location = New System.Drawing.Point(216, 73)
        Me.RDBDEPRTSUMM.Name = "RDBDEPRTSUMM"
        Me.RDBDEPRTSUMM.Size = New System.Drawing.Size(173, 18)
        Me.RDBDEPRTSUMM.TabIndex = 6
        Me.RDBDEPRTSUMM.Text = "Department Wise Summary"
        Me.RDBDEPRTSUMM.UseVisualStyleBackColor = True
        '
        'RBDEPARTMENTWISE
        '
        Me.RBDEPARTMENTWISE.AutoSize = True
        Me.RBDEPARTMENTWISE.Location = New System.Drawing.Point(216, 24)
        Me.RBDEPARTMENTWISE.Name = "RBDEPARTMENTWISE"
        Me.RBDEPARTMENTWISE.Size = New System.Drawing.Size(158, 18)
        Me.RBDEPARTMENTWISE.TabIndex = 4
        Me.RBDEPARTMENTWISE.Text = "Department Wise Detail"
        Me.RBDEPARTMENTWISE.UseVisualStyleBackColor = True
        '
        'RBCONSUMED
        '
        Me.RBCONSUMED.AutoSize = True
        Me.RBCONSUMED.Location = New System.Drawing.Point(12, 73)
        Me.RBCONSUMED.Name = "RBCONSUMED"
        Me.RBCONSUMED.Size = New System.Drawing.Size(156, 18)
        Me.RBCONSUMED.TabIndex = 2
        Me.RBCONSUMED.Text = "Consumed Stock Details"
        Me.RBCONSUMED.UseVisualStyleBackColor = True
        '
        'RBSTORE
        '
        Me.RBSTORE.AutoSize = True
        Me.RBSTORE.Checked = True
        Me.RBSTORE.Location = New System.Drawing.Point(12, 24)
        Me.RBSTORE.Name = "RBSTORE"
        Me.RBSTORE.Size = New System.Drawing.Size(134, 18)
        Me.RBSTORE.TabIndex = 0
        Me.RBSTORE.TabStop = True
        Me.RBSTORE.Text = "Store Stock On Hand"
        Me.RBSTORE.UseVisualStyleBackColor = True
        '
        'RBMONTHWISE
        '
        Me.RBMONTHWISE.AutoSize = True
        Me.RBMONTHWISE.Location = New System.Drawing.Point(12, 49)
        Me.RBMONTHWISE.Name = "RBMONTHWISE"
        Me.RBMONTHWISE.Size = New System.Drawing.Size(153, 18)
        Me.RBMONTHWISE.TabIndex = 1
        Me.RBMONTHWISE.Text = "Month Wise Store Stock"
        Me.RBMONTHWISE.UseVisualStyleBackColor = True
        '
        'CMDREPORT
        '
        Me.CMDREPORT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREPORT.Location = New System.Drawing.Point(164, 396)
        Me.CMDREPORT.Name = "CMDREPORT"
        Me.CMDREPORT.Size = New System.Drawing.Size(83, 28)
        Me.CMDREPORT.TabIndex = 8
        Me.CMDREPORT.Text = "Show Report"
        Me.CMDREPORT.UseVisualStyleBackColor = True
        '
        'dtopening
        '
        Me.dtopening.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtopening.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtopening.Location = New System.Drawing.Point(328, 388)
        Me.dtopening.Name = "dtopening"
        Me.dtopening.Size = New System.Drawing.Size(83, 22)
        Me.dtopening.TabIndex = 640
        Me.dtopening.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(351, 327)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 14)
        Me.Label4.TabIndex = 641
        Me.Label4.Text = "Opening Date :"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(38, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 14)
        Me.Label3.TabIndex = 639
        Me.Label3.Text = "Party Name"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.BackColor = System.Drawing.Color.White
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(108, 96)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(289, 22)
        Me.cmbname.TabIndex = 3
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(116, 328)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 6
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtfrom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(108, 332)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(161, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 14)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "To :"
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(9, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "From :"
        '
        'cmbdepartment
        '
        Me.cmbdepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbdepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbdepartment.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbdepartment.FormattingEnabled = True
        Me.cmbdepartment.Location = New System.Drawing.Point(108, 68)
        Me.cmbdepartment.MaxDropDownItems = 14
        Me.cmbdepartment.Name = "cmbdepartment"
        Me.cmbdepartment.Size = New System.Drawing.Size(289, 22)
        Me.cmbdepartment.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(34, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 14)
        Me.Label11.TabIndex = 441
        Me.Label11.Text = "Department"
        '
        'cmbratetype
        '
        Me.cmbratetype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbratetype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbratetype.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbratetype.FormattingEnabled = True
        Me.cmbratetype.Location = New System.Drawing.Point(108, 40)
        Me.cmbratetype.MaxDropDownItems = 14
        Me.cmbratetype.Name = "cmbratetype"
        Me.cmbratetype.Size = New System.Drawing.Size(94, 22)
        Me.cmbratetype.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(43, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 14)
        Me.Label2.TabIndex = 439
        Me.Label2.Text = "Rate Type"
        '
        'cmbitemname
        '
        Me.cmbitemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbitemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbitemname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbitemname.FormattingEnabled = True
        Me.cmbitemname.Location = New System.Drawing.Point(108, 12)
        Me.cmbitemname.MaxDropDownItems = 14
        Me.cmbitemname.Name = "cmbitemname"
        Me.cmbitemname.Size = New System.Drawing.Size(289, 22)
        Me.cmbitemname.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(39, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 14)
        Me.Label9.TabIndex = 419
        Me.Label9.Text = "Item Name"
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdshow.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Image = Global.TexPro_V1.My.Resources.Resources.showreport
        Me.cmdshow.Location = New System.Drawing.Point(355, 354)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(75, 28)
        Me.cmdshow.TabIndex = 7
        Me.cmdshow.UseVisualStyleBackColor = False
        Me.cmdshow.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(253, 396)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(402, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 14)
        Me.Label15.TabIndex = 645
        Me.Label15.Text = "Department"
        '
        'CLB_DEPARTMENT
        '
        Me.CLB_DEPARTMENT.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_DEPARTMENT.FormattingEnabled = True
        Me.CLB_DEPARTMENT.Location = New System.Drawing.Point(475, 12)
        Me.CLB_DEPARTMENT.Name = "CLB_DEPARTMENT"
        Me.CLB_DEPARTMENT.ScrollAlwaysVisible = True
        Me.CLB_DEPARTMENT.Size = New System.Drawing.Size(249, 140)
        Me.CLB_DEPARTMENT.TabIndex = 644
        Me.CLB_DEPARTMENT.TabStop = False
        '
        'StoreStockFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(873, 436)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StoreStockFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Store Stock Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents cmbratetype As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbitemname As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RBSTORE As System.Windows.Forms.RadioButton
    Friend WithEvents RBMONTHWISE As System.Windows.Forms.RadioButton
    Friend WithEvents cmbdepartment As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents dtopening As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMDREPORT As System.Windows.Forms.Button
    Friend WithEvents RBCONSUMED As System.Windows.Forms.RadioButton
    Friend WithEvents RBDEPARTMENTWISE As System.Windows.Forms.RadioButton
    Friend WithEvents RDBDEPRTSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBDEPARTMENTWISEPURRATE As System.Windows.Forms.RadioButton
    Friend WithEvents RBDEPARTMENTSUMMPURRATE As System.Windows.Forms.RadioButton
    Friend WithEvents RBDEPTCONSUMED As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTISSUETO As System.Windows.Forms.TextBox
    Friend WithEvents RBDEPTCONSUMEDSUMM As RadioButton
    Friend WithEvents Label15 As Label
    Friend WithEvents CLB_DEPARTMENT As CheckedListBox
End Class
