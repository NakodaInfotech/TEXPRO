<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CuttingFilter
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CHKVALUE = New System.Windows.Forms.CheckBox
        Me.TXTLOTNO = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CMBJOB = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CMBDESIGN = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.RBSUPERSUMMERY = New System.Windows.Forms.RadioButton
        Me.RDBJOB = New System.Windows.Forms.RadioButton
        Me.RDBMERCHANT = New System.Windows.Forms.RadioButton
        Me.Rdbsummary = New System.Windows.Forms.RadioButton
        Me.rdbdetail = New System.Windows.Forms.RadioButton
        Me.cmbMerchant = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.cmdshowreport = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.lblheading = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKVALUE)
        Me.BlendPanel1.Controls.Add(Me.TXTLOTNO)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Controls.Add(Me.CMBJOB)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.CMBDESIGN)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox3)
        Me.BlendPanel1.Controls.Add(Me.cmbMerchant)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.cmdshowreport)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lblheading)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(339, 336)
        Me.BlendPanel1.TabIndex = 6
        '
        'CHKVALUE
        '
        Me.CHKVALUE.AutoSize = True
        Me.CHKVALUE.BackColor = System.Drawing.Color.Transparent
        Me.CHKVALUE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKVALUE.ForeColor = System.Drawing.Color.Black
        Me.CHKVALUE.Location = New System.Drawing.Point(199, 96)
        Me.CHKVALUE.Name = "CHKVALUE"
        Me.CHKVALUE.Size = New System.Drawing.Size(86, 18)
        Me.CHKVALUE.TabIndex = 107
        Me.CHKVALUE.Text = "With Value"
        Me.CHKVALUE.UseVisualStyleBackColor = False
        '
        'TXTLOTNO
        '
        Me.TXTLOTNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTLOTNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOTNO.Location = New System.Drawing.Point(84, 92)
        Me.TXTLOTNO.Name = "TXTLOTNO"
        Me.TXTLOTNO.Size = New System.Drawing.Size(84, 22)
        Me.TXTLOTNO.TabIndex = 440
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(38, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 14)
        Me.Label5.TabIndex = 441
        Me.Label5.Text = "Lot No."
        '
        'CMBJOB
        '
        Me.CMBJOB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBJOB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBJOB.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBJOB.FormattingEnabled = True
        Me.CMBJOB.Location = New System.Drawing.Point(224, 66)
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
        Me.Label4.Location = New System.Drawing.Point(196, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 14)
        Me.Label4.TabIndex = 439
        Me.Label4.Text = "Job"
        '
        'CMBDESIGN
        '
        Me.CMBDESIGN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDESIGN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDESIGN.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDESIGN.FormattingEnabled = True
        Me.CMBDESIGN.Location = New System.Drawing.Point(84, 66)
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
        Me.Label1.Location = New System.Drawing.Point(37, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 14)
        Me.Label1.TabIndex = 437
        Me.Label1.Text = "Design"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RBSUPERSUMMERY)
        Me.GroupBox3.Controls.Add(Me.RDBJOB)
        Me.GroupBox3.Controls.Add(Me.RDBMERCHANT)
        Me.GroupBox3.Controls.Add(Me.Rdbsummary)
        Me.GroupBox3.Controls.Add(Me.rdbdetail)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(27, 125)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(280, 100)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Reports"
        '
        'RBSUPERSUMMERY
        '
        Me.RBSUPERSUMMERY.AutoSize = True
        Me.RBSUPERSUMMERY.Location = New System.Drawing.Point(16, 72)
        Me.RBSUPERSUMMERY.Name = "RBSUPERSUMMERY"
        Me.RBSUPERSUMMERY.Size = New System.Drawing.Size(95, 18)
        Me.RBSUPERSUMMERY.TabIndex = 7
        Me.RBSUPERSUMMERY.Text = "Quality Wise"
        Me.RBSUPERSUMMERY.UseVisualStyleBackColor = True
        '
        'RDBJOB
        '
        Me.RDBJOB.AutoSize = True
        Me.RDBJOB.Location = New System.Drawing.Point(110, 48)
        Me.RDBJOB.Name = "RDBJOB"
        Me.RDBJOB.Size = New System.Drawing.Size(74, 18)
        Me.RDBJOB.TabIndex = 2
        Me.RDBJOB.Text = "Job Wise"
        Me.RDBJOB.UseVisualStyleBackColor = True
        '
        'RDBMERCHANT
        '
        Me.RDBMERCHANT.AutoSize = True
        Me.RDBMERCHANT.Location = New System.Drawing.Point(110, 24)
        Me.RDBMERCHANT.Name = "RDBMERCHANT"
        Me.RDBMERCHANT.Size = New System.Drawing.Size(107, 18)
        Me.RDBMERCHANT.TabIndex = 4
        Me.RDBMERCHANT.Text = "Merchant Wise"
        Me.RDBMERCHANT.UseVisualStyleBackColor = True
        '
        'Rdbsummary
        '
        Me.Rdbsummary.AutoSize = True
        Me.Rdbsummary.Location = New System.Drawing.Point(16, 48)
        Me.Rdbsummary.Name = "Rdbsummary"
        Me.Rdbsummary.Size = New System.Drawing.Size(74, 18)
        Me.Rdbsummary.TabIndex = 3
        Me.Rdbsummary.Text = "Summary"
        Me.Rdbsummary.UseVisualStyleBackColor = True
        '
        'rdbdetail
        '
        Me.rdbdetail.AutoSize = True
        Me.rdbdetail.Checked = True
        Me.rdbdetail.Location = New System.Drawing.Point(16, 24)
        Me.rdbdetail.Name = "rdbdetail"
        Me.rdbdetail.Size = New System.Drawing.Size(65, 18)
        Me.rdbdetail.TabIndex = 0
        Me.rdbdetail.TabStop = True
        Me.rdbdetail.Text = "Details"
        Me.rdbdetail.UseVisualStyleBackColor = True
        '
        'cmbMerchant
        '
        Me.cmbMerchant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMerchant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMerchant.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMerchant.FormattingEnabled = True
        Me.cmbMerchant.Location = New System.Drawing.Point(84, 40)
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
        Me.Label2.Location = New System.Drawing.Point(24, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 14)
        Me.Label2.TabIndex = 435
        Me.Label2.Text = "Merchant"
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
        Me.GroupBox1.Location = New System.Drawing.Point(27, 234)
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
        Me.chkdate.Location = New System.Drawing.Point(10, 0)
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
        Me.cmdshowreport.Location = New System.Drawing.Point(93, 295)
        Me.cmdshowreport.Name = "cmdshowreport"
        Me.cmdshowreport.Size = New System.Drawing.Size(75, 28)
        Me.cmdshowreport.TabIndex = 8
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
        Me.cmdexit.Location = New System.Drawing.Point(174, 299)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 24)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lblheading
        '
        Me.lblheading.AutoSize = True
        Me.lblheading.BackColor = System.Drawing.Color.Transparent
        Me.lblheading.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblheading.Location = New System.Drawing.Point(15, 2)
        Me.lblheading.Name = "lblheading"
        Me.lblheading.Size = New System.Drawing.Size(171, 29)
        Me.lblheading.TabIndex = 315
        Me.lblheading.Text = "Cutting Register"
        '
        'CuttingFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(339, 336)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CuttingFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cutting Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMBJOB As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMBDESIGN As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RBSUPERSUMMERY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBJOB As System.Windows.Forms.RadioButton
    Friend WithEvents RDBMERCHANT As System.Windows.Forms.RadioButton
    Friend WithEvents Rdbsummary As System.Windows.Forms.RadioButton
    Friend WithEvents rdbdetail As System.Windows.Forms.RadioButton
    Friend WithEvents cmbMerchant As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents cmdshowreport As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lblheading As System.Windows.Forms.Label
    Friend WithEvents TXTLOTNO As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CHKVALUE As System.Windows.Forms.CheckBox
End Class
