<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mfg1Filter
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
        Me.CHKVALUE = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RDBBOTH = New System.Windows.Forms.RadioButton()
        Me.RDBDONE = New System.Windows.Forms.RadioButton()
        Me.RDBINPROCESS = New System.Windows.Forms.RadioButton()
        Me.chkNEGATIVE = New System.Windows.Forms.CheckBox()
        Me.TXTLOTNO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.chkfull = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RDBLOTSUMMARY = New System.Windows.Forms.RadioButton()
        Me.RDBLOTDETAIL = New System.Windows.Forms.RadioButton()
        Me.RDBMONTHLY = New System.Windows.Forms.RadioButton()
        Me.Rdbsummary = New System.Windows.Forms.RadioButton()
        Me.rdbdetail = New System.Windows.Forms.RadioButton()
        Me.cmbQuality = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbprocess = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.startdate = New System.Windows.Forms.DateTimePicker()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.cmdshowreport = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.lblheading = New System.Windows.Forms.Label()
        Me.CHKOURQUALITY = New System.Windows.Forms.CheckBox()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKOURQUALITY)
        Me.BlendPanel1.Controls.Add(Me.CHKVALUE)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.chkNEGATIVE)
        Me.BlendPanel1.Controls.Add(Me.TXTLOTNO)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.dtfrom)
        Me.BlendPanel1.Controls.Add(Me.chkfull)
        Me.BlendPanel1.Controls.Add(Me.GroupBox3)
        Me.BlendPanel1.Controls.Add(Me.cmbQuality)
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
        Me.BlendPanel1.Size = New System.Drawing.Size(331, 437)
        Me.BlendPanel1.TabIndex = 4
        '
        'CHKVALUE
        '
        Me.CHKVALUE.AutoSize = True
        Me.CHKVALUE.BackColor = System.Drawing.Color.Transparent
        Me.CHKVALUE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKVALUE.ForeColor = System.Drawing.Color.Black
        Me.CHKVALUE.Location = New System.Drawing.Point(229, 108)
        Me.CHKVALUE.Name = "CHKVALUE"
        Me.CHKVALUE.Size = New System.Drawing.Size(86, 18)
        Me.CHKVALUE.TabIndex = 440
        Me.CHKVALUE.Text = "With Value"
        Me.CHKVALUE.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.RDBBOTH)
        Me.GroupBox2.Controls.Add(Me.RDBDONE)
        Me.GroupBox2.Controls.Add(Me.RDBINPROCESS)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(167, 172)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(121, 105)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Process"
        '
        'RDBBOTH
        '
        Me.RDBBOTH.AutoSize = True
        Me.RDBBOTH.Checked = True
        Me.RDBBOTH.Location = New System.Drawing.Point(11, 73)
        Me.RDBBOTH.Name = "RDBBOTH"
        Me.RDBBOTH.Size = New System.Drawing.Size(50, 18)
        Me.RDBBOTH.TabIndex = 2
        Me.RDBBOTH.TabStop = True
        Me.RDBBOTH.Text = "Both"
        Me.RDBBOTH.UseVisualStyleBackColor = True
        '
        'RDBDONE
        '
        Me.RDBDONE.AutoSize = True
        Me.RDBDONE.Location = New System.Drawing.Point(11, 49)
        Me.RDBDONE.Name = "RDBDONE"
        Me.RDBDONE.Size = New System.Drawing.Size(98, 18)
        Me.RDBDONE.TabIndex = 1
        Me.RDBDONE.Text = "Process Done"
        Me.RDBDONE.UseVisualStyleBackColor = True
        '
        'RDBINPROCESS
        '
        Me.RDBINPROCESS.AutoSize = True
        Me.RDBINPROCESS.Location = New System.Drawing.Point(11, 25)
        Me.RDBINPROCESS.Name = "RDBINPROCESS"
        Me.RDBINPROCESS.Size = New System.Drawing.Size(80, 18)
        Me.RDBINPROCESS.TabIndex = 0
        Me.RDBINPROCESS.Text = "In Process"
        Me.RDBINPROCESS.UseVisualStyleBackColor = True
        '
        'chkNEGATIVE
        '
        Me.chkNEGATIVE.AutoSize = True
        Me.chkNEGATIVE.BackColor = System.Drawing.Color.Transparent
        Me.chkNEGATIVE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkNEGATIVE.ForeColor = System.Drawing.Color.Black
        Me.chkNEGATIVE.Location = New System.Drawing.Point(176, 136)
        Me.chkNEGATIVE.Name = "chkNEGATIVE"
        Me.chkNEGATIVE.Size = New System.Drawing.Size(43, 18)
        Me.chkNEGATIVE.TabIndex = 8
        Me.chkNEGATIVE.Text = "-Ve"
        Me.chkNEGATIVE.UseVisualStyleBackColor = False
        '
        'TXTLOTNO
        '
        Me.TXTLOTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTLOTNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOTNO.Location = New System.Drawing.Point(87, 103)
        Me.TXTLOTNO.Name = "TXTLOTNO"
        Me.TXTLOTNO.Size = New System.Drawing.Size(83, 22)
        Me.TXTLOTNO.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(39, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 14)
        Me.Label1.TabIndex = 439
        Me.Label1.Text = "Lot No."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(29, 135)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 14)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "Op. Date"
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(87, 131)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtfrom.TabIndex = 3
        '
        'chkfull
        '
        Me.chkfull.AutoSize = True
        Me.chkfull.BackColor = System.Drawing.Color.Transparent
        Me.chkfull.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkfull.ForeColor = System.Drawing.Color.Black
        Me.chkfull.Location = New System.Drawing.Point(176, 108)
        Me.chkfull.Name = "chkfull"
        Me.chkfull.Size = New System.Drawing.Size(47, 18)
        Me.chkfull.TabIndex = 7
        Me.chkfull.Text = "Full"
        Me.chkfull.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RDBLOTSUMMARY)
        Me.GroupBox3.Controls.Add(Me.RDBLOTDETAIL)
        Me.GroupBox3.Controls.Add(Me.RDBMONTHLY)
        Me.GroupBox3.Controls.Add(Me.Rdbsummary)
        Me.GroupBox3.Controls.Add(Me.rdbdetail)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(43, 172)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(121, 145)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Reports"
        '
        'RDBLOTSUMMARY
        '
        Me.RDBLOTSUMMARY.AutoSize = True
        Me.RDBLOTSUMMARY.Location = New System.Drawing.Point(23, 118)
        Me.RDBLOTSUMMARY.Name = "RDBLOTSUMMARY"
        Me.RDBLOTSUMMARY.Size = New System.Drawing.Size(93, 18)
        Me.RDBLOTSUMMARY.TabIndex = 4
        Me.RDBLOTSUMMARY.Text = "Lot Summary"
        Me.RDBLOTSUMMARY.UseVisualStyleBackColor = True
        '
        'RDBLOTDETAIL
        '
        Me.RDBLOTDETAIL.AutoSize = True
        Me.RDBLOTDETAIL.Location = New System.Drawing.Point(23, 97)
        Me.RDBLOTDETAIL.Name = "RDBLOTDETAIL"
        Me.RDBLOTDETAIL.Size = New System.Drawing.Size(82, 18)
        Me.RDBLOTDETAIL.TabIndex = 3
        Me.RDBLOTDETAIL.Text = "Lot History"
        Me.RDBLOTDETAIL.UseVisualStyleBackColor = True
        '
        'RDBMONTHLY
        '
        Me.RDBMONTHLY.AutoSize = True
        Me.RDBMONTHLY.Location = New System.Drawing.Point(23, 73)
        Me.RDBMONTHLY.Name = "RDBMONTHLY"
        Me.RDBMONTHLY.Size = New System.Drawing.Size(69, 18)
        Me.RDBMONTHLY.TabIndex = 2
        Me.RDBMONTHLY.Text = "Monthly"
        Me.RDBMONTHLY.UseVisualStyleBackColor = True
        '
        'Rdbsummary
        '
        Me.Rdbsummary.AutoSize = True
        Me.Rdbsummary.Location = New System.Drawing.Point(23, 49)
        Me.Rdbsummary.Name = "Rdbsummary"
        Me.Rdbsummary.Size = New System.Drawing.Size(74, 18)
        Me.Rdbsummary.TabIndex = 1
        Me.Rdbsummary.Text = "Summary"
        Me.Rdbsummary.UseVisualStyleBackColor = True
        '
        'rdbdetail
        '
        Me.rdbdetail.AutoSize = True
        Me.rdbdetail.Checked = True
        Me.rdbdetail.Location = New System.Drawing.Point(23, 25)
        Me.rdbdetail.Name = "rdbdetail"
        Me.rdbdetail.Size = New System.Drawing.Size(65, 18)
        Me.rdbdetail.TabIndex = 0
        Me.rdbdetail.TabStop = True
        Me.rdbdetail.Text = "Details"
        Me.rdbdetail.UseVisualStyleBackColor = True
        '
        'cmbQuality
        '
        Me.cmbQuality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbQuality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbQuality.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbQuality.FormattingEnabled = True
        Me.cmbQuality.Location = New System.Drawing.Point(87, 75)
        Me.cmbQuality.MaxDropDownItems = 14
        Me.cmbQuality.Name = "cmbQuality"
        Me.cmbQuality.Size = New System.Drawing.Size(214, 22)
        Me.cmbQuality.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(37, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 435
        Me.Label2.Text = "Quality"
        '
        'cmbprocess
        '
        Me.cmbprocess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbprocess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbprocess.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbprocess.FormattingEnabled = True
        Me.cmbprocess.Location = New System.Drawing.Point(87, 47)
        Me.cmbprocess.MaxDropDownItems = 14
        Me.cmbprocess.Name = "cmbprocess"
        Me.cmbprocess.Size = New System.Drawing.Size(213, 22)
        Me.cmbprocess.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(35, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 14)
        Me.Label8.TabIndex = 433
        Me.Label8.Text = "Process"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.startdate)
        Me.GroupBox1.Controls.Add(Me.dtto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.chkdate)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(25, 334)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 432
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(14, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 14)
        Me.Label4.TabIndex = 442
        Me.Label4.Text = "From"
        '
        'startdate
        '
        Me.startdate.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.startdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.startdate.Location = New System.Drawing.Point(54, 20)
        Me.startdate.Name = "startdate"
        Me.startdate.Size = New System.Drawing.Size(83, 22)
        Me.startdate.TabIndex = 1
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(189, 20)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 2
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
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Checked = True
        Me.chkdate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(12, 0)
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
        Me.cmdshowreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdshowreport.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowreport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshowreport.Image = Global.TexPro_V1.My.Resources.Resources.showreport
        Me.cmdshowreport.Location = New System.Drawing.Point(89, 390)
        Me.cmdshowreport.Name = "cmdshowreport"
        Me.cmdshowreport.Size = New System.Drawing.Size(75, 28)
        Me.cmdshowreport.TabIndex = 5
        Me.cmdshowreport.UseVisualStyleBackColor = False
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
        Me.cmdexit.Location = New System.Drawing.Point(170, 394)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 24)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lblheading
        '
        Me.lblheading.AutoSize = True
        Me.lblheading.BackColor = System.Drawing.Color.Transparent
        Me.lblheading.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblheading.Location = New System.Drawing.Point(15, 9)
        Me.lblheading.Name = "lblheading"
        Me.lblheading.Size = New System.Drawing.Size(303, 29)
        Me.lblheading.TabIndex = 315
        Me.lblheading.Text = "Mfg.(Before Cutting) Register"
        '
        'CHKOURQUALITY
        '
        Me.CHKOURQUALITY.AutoSize = True
        Me.CHKOURQUALITY.BackColor = System.Drawing.Color.Transparent
        Me.CHKOURQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKOURQUALITY.ForeColor = System.Drawing.Color.Black
        Me.CHKOURQUALITY.Location = New System.Drawing.Point(178, 283)
        Me.CHKOURQUALITY.Name = "CHKOURQUALITY"
        Me.CHKOURQUALITY.Size = New System.Drawing.Size(89, 18)
        Me.CHKOURQUALITY.TabIndex = 441
        Me.CHKOURQUALITY.Text = "Self Quality"
        Me.CHKOURQUALITY.UseVisualStyleBackColor = False
        '
        'Mfg1Filter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 437)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "Mfg1Filter"
        Me.Text = "Mfg Register"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents cmbQuality As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbprocess As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdshowreport As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lblheading As System.Windows.Forms.Label
    Friend WithEvents RDBMONTHLY As System.Windows.Forms.RadioButton
    Friend WithEvents TXTLOTNO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents startdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkNEGATIVE As System.Windows.Forms.CheckBox
    Friend WithEvents chkfull As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RDBDONE As System.Windows.Forms.RadioButton
    Friend WithEvents RDBINPROCESS As System.Windows.Forms.RadioButton
    Friend WithEvents RDBBOTH As System.Windows.Forms.RadioButton
    Friend WithEvents RDBLOTDETAIL As System.Windows.Forms.RadioButton
    Friend WithEvents RDBLOTSUMMARY As System.Windows.Forms.RadioButton
    Friend WithEvents CHKVALUE As System.Windows.Forms.CheckBox
    Friend WithEvents CHKOURQUALITY As CheckBox
End Class
