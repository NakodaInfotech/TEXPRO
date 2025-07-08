<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExpenseFilter
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
        Me.BlendPanel2 = New VbPowerPack.BlendPanel
        Me.TXTLOTNO = New System.Windows.Forms.TextBox
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox
        Me.LBLQUALITY = New System.Windows.Forms.Label
        Me.LBLCOLOR = New System.Windows.Forms.Label
        Me.CMBCOLOR = New System.Windows.Forms.ComboBox
        Me.CMBDESIGNNO = New System.Windows.Forms.ComboBox
        Me.LBLDESIGN = New System.Windows.Forms.Label
        Me.TXTCUT = New System.Windows.Forms.TextBox
        Me.LBLCUT = New System.Windows.Forms.Label
        Me.CMBPER = New System.Windows.Forms.ComboBox
        Me.LBLPER = New System.Windows.Forms.Label
        Me.LBLLOT = New System.Windows.Forms.Label
        Me.cmbmerchant = New System.Windows.Forms.ComboBox
        Me.LBLMERCHANT = New System.Windows.Forms.Label
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbprocess = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbratetype = New System.Windows.Forms.ComboBox
        Me.LBLRATE = New System.Windows.Forms.Label
        Me.cmbitemname = New System.Windows.Forms.ComboBox
        Me.LBLITEM = New System.Windows.Forms.Label
        Me.cmdshow = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.RBDETAILS = New System.Windows.Forms.RadioButton
        Me.RBSUMMARY = New System.Windows.Forms.RadioButton
        Me.BlendPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.RBSUMMARY)
        Me.BlendPanel2.Controls.Add(Me.RBDETAILS)
        Me.BlendPanel2.Controls.Add(Me.TXTLOTNO)
        Me.BlendPanel2.Controls.Add(Me.CMBQUALITY)
        Me.BlendPanel2.Controls.Add(Me.LBLQUALITY)
        Me.BlendPanel2.Controls.Add(Me.LBLCOLOR)
        Me.BlendPanel2.Controls.Add(Me.CMBCOLOR)
        Me.BlendPanel2.Controls.Add(Me.CMBDESIGNNO)
        Me.BlendPanel2.Controls.Add(Me.LBLDESIGN)
        Me.BlendPanel2.Controls.Add(Me.TXTCUT)
        Me.BlendPanel2.Controls.Add(Me.LBLCUT)
        Me.BlendPanel2.Controls.Add(Me.CMBPER)
        Me.BlendPanel2.Controls.Add(Me.LBLPER)
        Me.BlendPanel2.Controls.Add(Me.LBLLOT)
        Me.BlendPanel2.Controls.Add(Me.cmbmerchant)
        Me.BlendPanel2.Controls.Add(Me.LBLMERCHANT)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.cmbprocess)
        Me.BlendPanel2.Controls.Add(Me.Label11)
        Me.BlendPanel2.Controls.Add(Me.cmbratetype)
        Me.BlendPanel2.Controls.Add(Me.LBLRATE)
        Me.BlendPanel2.Controls.Add(Me.cmbitemname)
        Me.BlendPanel2.Controls.Add(Me.LBLITEM)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(348, 344)
        Me.BlendPanel2.TabIndex = 441
        '
        'TXTLOTNO
        '
        Me.TXTLOTNO.BackColor = System.Drawing.Color.White
        Me.TXTLOTNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOTNO.Location = New System.Drawing.Point(98, 124)
        Me.TXTLOTNO.Name = "TXTLOTNO"
        Me.TXTLOTNO.Size = New System.Drawing.Size(89, 22)
        Me.TXTLOTNO.TabIndex = 460
        Me.TXTLOTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(98, 180)
        Me.CMBQUALITY.MaxDropDownItems = 14
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(225, 22)
        Me.CMBQUALITY.TabIndex = 458
        '
        'LBLQUALITY
        '
        Me.LBLQUALITY.AutoSize = True
        Me.LBLQUALITY.BackColor = System.Drawing.Color.Transparent
        Me.LBLQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLQUALITY.ForeColor = System.Drawing.Color.Black
        Me.LBLQUALITY.Location = New System.Drawing.Point(50, 184)
        Me.LBLQUALITY.Name = "LBLQUALITY"
        Me.LBLQUALITY.Size = New System.Drawing.Size(46, 14)
        Me.LBLQUALITY.TabIndex = 459
        Me.LBLQUALITY.Text = "Quality"
        '
        'LBLCOLOR
        '
        Me.LBLCOLOR.AutoSize = True
        Me.LBLCOLOR.BackColor = System.Drawing.Color.Transparent
        Me.LBLCOLOR.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCOLOR.ForeColor = System.Drawing.Color.Black
        Me.LBLCOLOR.Location = New System.Drawing.Point(198, 156)
        Me.LBLCOLOR.Name = "LBLCOLOR"
        Me.LBLCOLOR.Size = New System.Drawing.Size(35, 14)
        Me.LBLCOLOR.TabIndex = 457
        Me.LBLCOLOR.Text = "Color"
        '
        'CMBCOLOR
        '
        Me.CMBCOLOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCOLOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCOLOR.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCOLOR.FormattingEnabled = True
        Me.CMBCOLOR.Location = New System.Drawing.Point(234, 152)
        Me.CMBCOLOR.MaxDropDownItems = 14
        Me.CMBCOLOR.Name = "CMBCOLOR"
        Me.CMBCOLOR.Size = New System.Drawing.Size(89, 22)
        Me.CMBCOLOR.TabIndex = 456
        '
        'CMBDESIGNNO
        '
        Me.CMBDESIGNNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGNNO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGNNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGNNO.FormattingEnabled = True
        Me.CMBDESIGNNO.Location = New System.Drawing.Point(98, 152)
        Me.CMBDESIGNNO.MaxDropDownItems = 14
        Me.CMBDESIGNNO.Name = "CMBDESIGNNO"
        Me.CMBDESIGNNO.Size = New System.Drawing.Size(89, 22)
        Me.CMBDESIGNNO.TabIndex = 454
        '
        'LBLDESIGN
        '
        Me.LBLDESIGN.AutoSize = True
        Me.LBLDESIGN.BackColor = System.Drawing.Color.Transparent
        Me.LBLDESIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDESIGN.ForeColor = System.Drawing.Color.Black
        Me.LBLDESIGN.Location = New System.Drawing.Point(33, 156)
        Me.LBLDESIGN.Name = "LBLDESIGN"
        Me.LBLDESIGN.Size = New System.Drawing.Size(63, 14)
        Me.LBLDESIGN.TabIndex = 455
        Me.LBLDESIGN.Text = "Design No"
        '
        'TXTCUT
        '
        Me.TXTCUT.BackColor = System.Drawing.Color.White
        Me.TXTCUT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCUT.Location = New System.Drawing.Point(239, 40)
        Me.TXTCUT.Name = "TXTCUT"
        Me.TXTCUT.Size = New System.Drawing.Size(84, 22)
        Me.TXTCUT.TabIndex = 453
        Me.TXTCUT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLCUT
        '
        Me.LBLCUT.AutoSize = True
        Me.LBLCUT.BackColor = System.Drawing.Color.Transparent
        Me.LBLCUT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCUT.ForeColor = System.Drawing.Color.Black
        Me.LBLCUT.Location = New System.Drawing.Point(209, 44)
        Me.LBLCUT.Name = "LBLCUT"
        Me.LBLCUT.Size = New System.Drawing.Size(24, 14)
        Me.LBLCUT.TabIndex = 452
        Me.LBLCUT.Text = "Cut"
        '
        'CMBPER
        '
        Me.CMBPER.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPER.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPER.FormattingEnabled = True
        Me.CMBPER.Location = New System.Drawing.Point(234, 124)
        Me.CMBPER.MaxDropDownItems = 14
        Me.CMBPER.Name = "CMBPER"
        Me.CMBPER.Size = New System.Drawing.Size(89, 22)
        Me.CMBPER.TabIndex = 449
        '
        'LBLPER
        '
        Me.LBLPER.AutoSize = True
        Me.LBLPER.BackColor = System.Drawing.Color.Transparent
        Me.LBLPER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPER.ForeColor = System.Drawing.Color.Black
        Me.LBLPER.Location = New System.Drawing.Point(209, 128)
        Me.LBLPER.Name = "LBLPER"
        Me.LBLPER.Size = New System.Drawing.Size(24, 14)
        Me.LBLPER.TabIndex = 450
        Me.LBLPER.Text = "Per"
        '
        'LBLLOT
        '
        Me.LBLLOT.AutoSize = True
        Me.LBLLOT.BackColor = System.Drawing.Color.Transparent
        Me.LBLLOT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLLOT.ForeColor = System.Drawing.Color.Black
        Me.LBLLOT.Location = New System.Drawing.Point(55, 128)
        Me.LBLLOT.Name = "LBLLOT"
        Me.LBLLOT.Size = New System.Drawing.Size(41, 14)
        Me.LBLLOT.TabIndex = 448
        Me.LBLLOT.Text = "Lot No"
        '
        'cmbmerchant
        '
        Me.cmbmerchant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbmerchant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbmerchant.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbmerchant.FormattingEnabled = True
        Me.cmbmerchant.Location = New System.Drawing.Point(98, 96)
        Me.cmbmerchant.MaxDropDownItems = 14
        Me.cmbmerchant.Name = "cmbmerchant"
        Me.cmbmerchant.Size = New System.Drawing.Size(225, 22)
        Me.cmbmerchant.TabIndex = 445
        '
        'LBLMERCHANT
        '
        Me.LBLMERCHANT.AutoSize = True
        Me.LBLMERCHANT.BackColor = System.Drawing.Color.Transparent
        Me.LBLMERCHANT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMERCHANT.ForeColor = System.Drawing.Color.Black
        Me.LBLMERCHANT.Location = New System.Drawing.Point(38, 100)
        Me.LBLMERCHANT.Name = "LBLMERCHANT"
        Me.LBLMERCHANT.Size = New System.Drawing.Size(58, 14)
        Me.LBLMERCHANT.TabIndex = 446
        Me.LBLMERCHANT.Text = "Merchant"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Checked = True
        Me.chkdate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(48, 243)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 443
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
        Me.GroupBox1.Location = New System.Drawing.Point(40, 247)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 444
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
        'cmbprocess
        '
        Me.cmbprocess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbprocess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbprocess.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbprocess.FormattingEnabled = True
        Me.cmbprocess.Location = New System.Drawing.Point(98, 68)
        Me.cmbprocess.MaxDropDownItems = 14
        Me.cmbprocess.Name = "cmbprocess"
        Me.cmbprocess.Size = New System.Drawing.Size(225, 22)
        Me.cmbprocess.TabIndex = 440
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(48, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 14)
        Me.Label11.TabIndex = 441
        Me.Label11.Text = "Process"
        '
        'cmbratetype
        '
        Me.cmbratetype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbratetype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbratetype.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbratetype.FormattingEnabled = True
        Me.cmbratetype.Location = New System.Drawing.Point(98, 40)
        Me.cmbratetype.MaxDropDownItems = 14
        Me.cmbratetype.Name = "cmbratetype"
        Me.cmbratetype.Size = New System.Drawing.Size(89, 22)
        Me.cmbratetype.TabIndex = 438
        '
        'LBLRATE
        '
        Me.LBLRATE.AutoSize = True
        Me.LBLRATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLRATE.ForeColor = System.Drawing.Color.Black
        Me.LBLRATE.Location = New System.Drawing.Point(37, 44)
        Me.LBLRATE.Name = "LBLRATE"
        Me.LBLRATE.Size = New System.Drawing.Size(59, 14)
        Me.LBLRATE.TabIndex = 439
        Me.LBLRATE.Text = "Rate Type"
        '
        'cmbitemname
        '
        Me.cmbitemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbitemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbitemname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbitemname.FormattingEnabled = True
        Me.cmbitemname.Location = New System.Drawing.Point(98, 12)
        Me.cmbitemname.MaxDropDownItems = 14
        Me.cmbitemname.Name = "cmbitemname"
        Me.cmbitemname.Size = New System.Drawing.Size(225, 22)
        Me.cmbitemname.TabIndex = 1
        '
        'LBLITEM
        '
        Me.LBLITEM.AutoSize = True
        Me.LBLITEM.BackColor = System.Drawing.Color.Transparent
        Me.LBLITEM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLITEM.ForeColor = System.Drawing.Color.Black
        Me.LBLITEM.Location = New System.Drawing.Point(29, 16)
        Me.LBLITEM.Name = "LBLITEM"
        Me.LBLITEM.Size = New System.Drawing.Size(67, 14)
        Me.LBLITEM.TabIndex = 419
        Me.LBLITEM.Text = "Item Name"
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
        Me.cmdshow.Location = New System.Drawing.Point(98, 301)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(75, 28)
        Me.cmdshow.TabIndex = 7
        Me.cmdshow.UseVisualStyleBackColor = False
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
        Me.cmdexit.Location = New System.Drawing.Point(179, 303)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 29)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'RBDETAILS
        '
        Me.RBDETAILS.AutoSize = True
        Me.RBDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.RBDETAILS.Checked = True
        Me.RBDETAILS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBDETAILS.Location = New System.Drawing.Point(98, 213)
        Me.RBDETAILS.Name = "RBDETAILS"
        Me.RBDETAILS.Size = New System.Drawing.Size(65, 18)
        Me.RBDETAILS.TabIndex = 461
        Me.RBDETAILS.TabStop = True
        Me.RBDETAILS.Text = "Details"
        Me.RBDETAILS.UseVisualStyleBackColor = False
        '
        'RBSUMMARY
        '
        Me.RBSUMMARY.AutoSize = True
        Me.RBSUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.RBSUMMARY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBSUMMARY.Location = New System.Drawing.Point(186, 213)
        Me.RBSUMMARY.Name = "RBSUMMARY"
        Me.RBSUMMARY.Size = New System.Drawing.Size(74, 18)
        Me.RBSUMMARY.TabIndex = 462
        Me.RBSUMMARY.TabStop = True
        Me.RBSUMMARY.Text = "Summary"
        Me.RBSUMMARY.UseVisualStyleBackColor = False
        '
        'ExpenseFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(348, 344)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Name = "ExpenseFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Expense Filter"
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbprocess As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbratetype As System.Windows.Forms.ComboBox
    Friend WithEvents LBLRATE As System.Windows.Forms.Label
    Friend WithEvents cmbitemname As System.Windows.Forms.ComboBox
    Friend WithEvents LBLITEM As System.Windows.Forms.Label
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents LBLLOT As System.Windows.Forms.Label
    Friend WithEvents cmbmerchant As System.Windows.Forms.ComboBox
    Friend WithEvents LBLMERCHANT As System.Windows.Forms.Label
    Friend WithEvents CMBPER As System.Windows.Forms.ComboBox
    Friend WithEvents LBLPER As System.Windows.Forms.Label
    Friend WithEvents LBLCUT As System.Windows.Forms.Label
    Friend WithEvents TXTCUT As System.Windows.Forms.TextBox
    Friend WithEvents LBLCOLOR As System.Windows.Forms.Label
    Friend WithEvents CMBCOLOR As System.Windows.Forms.ComboBox
    Friend WithEvents CMBDESIGNNO As System.Windows.Forms.ComboBox
    Friend WithEvents LBLDESIGN As System.Windows.Forms.Label
    Friend WithEvents CMBQUALITY As System.Windows.Forms.ComboBox
    Friend WithEvents LBLQUALITY As System.Windows.Forms.Label
    Friend WithEvents TXTLOTNO As System.Windows.Forms.TextBox
    Friend WithEvents RBSUMMARY As System.Windows.Forms.RadioButton
    Friend WithEvents RBDETAILS As System.Windows.Forms.RadioButton
End Class
