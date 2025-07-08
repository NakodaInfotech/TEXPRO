<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JobPackingFilter
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
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CLB_DEPARTMENT = New System.Windows.Forms.CheckedListBox()
        Me.CLB_GRADE = New System.Windows.Forms.CheckedListBox()
        Me.TXTMERCHANT = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RDBITEMWISE = New System.Windows.Forms.RadioButton()
        Me.rdbdetail = New System.Windows.Forms.RadioButton()
        Me.TXTBALENO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.RDBPARTYWISEDETAILS = New System.Windows.Forms.RadioButton()
        Me.RDBPARTYMERCHANTSUMM = New System.Windows.Forms.RadioButton()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CLB_CATEGORY)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.CLB_DEPARTMENT)
        Me.BlendPanel1.Controls.Add(Me.CLB_GRADE)
        Me.BlendPanel1.Controls.Add(Me.TXTMERCHANT)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.GroupBox3)
        Me.BlendPanel1.Controls.Add(Me.TXTBALENO)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.cmbmerchant)
        Me.BlendPanel1.Controls.Add(Me.lblvendorname)
        Me.BlendPanel1.Controls.Add(Me.cmdshowreport)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(693, 442)
        Me.BlendPanel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(396, 203)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 14)
        Me.Label2.TabIndex = 757
        Me.Label2.Text = "Category"
        '
        'CLB_CATEGORY
        '
        Me.CLB_CATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_CATEGORY.FormattingEnabled = True
        Me.CLB_CATEGORY.Location = New System.Drawing.Point(450, 199)
        Me.CLB_CATEGORY.Name = "CLB_CATEGORY"
        Me.CLB_CATEGORY.ScrollAlwaysVisible = True
        Me.CLB_CATEGORY.Size = New System.Drawing.Size(159, 72)
        Me.CLB_CATEGORY.TabIndex = 756
        Me.CLB_CATEGORY.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(380, 125)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 14)
        Me.Label15.TabIndex = 755
        Me.Label15.Text = "Department"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(409, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 754
        Me.Label1.Text = "Grade"
        '
        'CLB_DEPARTMENT
        '
        Me.CLB_DEPARTMENT.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_DEPARTMENT.FormattingEnabled = True
        Me.CLB_DEPARTMENT.Location = New System.Drawing.Point(450, 121)
        Me.CLB_DEPARTMENT.Name = "CLB_DEPARTMENT"
        Me.CLB_DEPARTMENT.ScrollAlwaysVisible = True
        Me.CLB_DEPARTMENT.Size = New System.Drawing.Size(159, 72)
        Me.CLB_DEPARTMENT.TabIndex = 753
        Me.CLB_DEPARTMENT.TabStop = False
        '
        'CLB_GRADE
        '
        Me.CLB_GRADE.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_GRADE.FormattingEnabled = True
        Me.CLB_GRADE.Location = New System.Drawing.Point(450, 43)
        Me.CLB_GRADE.Name = "CLB_GRADE"
        Me.CLB_GRADE.ScrollAlwaysVisible = True
        Me.CLB_GRADE.Size = New System.Drawing.Size(159, 72)
        Me.CLB_GRADE.TabIndex = 752
        Me.CLB_GRADE.TabStop = False
        '
        'TXTMERCHANT
        '
        Me.TXTMERCHANT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTMERCHANT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMERCHANT.Location = New System.Drawing.Point(109, 99)
        Me.TXTMERCHANT.Name = "TXTMERCHANT"
        Me.TXTMERCHANT.Size = New System.Drawing.Size(244, 22)
        Me.TXTMERCHANT.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(29, 103)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 14)
        Me.Label9.TabIndex = 455
        Me.Label9.Text = "Merchant Like"
        '
        'txtadd
        '
        Me.txtadd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.Location = New System.Drawing.Point(247, 15)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(77, 22)
        Me.txtadd.TabIndex = 444
        Me.txtadd.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RDBPARTYMERCHANTSUMM)
        Me.GroupBox3.Controls.Add(Me.RDBPARTYWISEDETAILS)
        Me.GroupBox3.Controls.Add(Me.RDBITEMWISE)
        Me.GroupBox3.Controls.Add(Me.rdbdetail)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(54, 283)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(555, 103)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Reports"
        '
        'RDBITEMWISE
        '
        Me.RDBITEMWISE.AutoSize = True
        Me.RDBITEMWISE.Location = New System.Drawing.Point(20, 45)
        Me.RDBITEMWISE.Name = "RDBITEMWISE"
        Me.RDBITEMWISE.Size = New System.Drawing.Size(159, 18)
        Me.RDBITEMWISE.TabIndex = 1
        Me.RDBITEMWISE.Text = "Merchant Wise Summary"
        Me.RDBITEMWISE.UseVisualStyleBackColor = True
        '
        'rdbdetail
        '
        Me.rdbdetail.AutoSize = True
        Me.rdbdetail.Checked = True
        Me.rdbdetail.Location = New System.Drawing.Point(20, 21)
        Me.rdbdetail.Name = "rdbdetail"
        Me.rdbdetail.Size = New System.Drawing.Size(59, 18)
        Me.rdbdetail.TabIndex = 0
        Me.rdbdetail.Text = "Detail"
        Me.rdbdetail.UseVisualStyleBackColor = True
        '
        'TXTBALENO
        '
        Me.TXTBALENO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTBALENO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBALENO.Location = New System.Drawing.Point(109, 127)
        Me.TXTBALENO.Name = "TXTBALENO"
        Me.TXTBALENO.Size = New System.Drawing.Size(87, 22)
        Me.TXTBALENO.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(56, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 14)
        Me.Label3.TabIndex = 437
        Me.Label3.Text = "Bale No."
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(109, 43)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(244, 22)
        Me.cmbname.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(68, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 14)
        Me.Label8.TabIndex = 433
        Me.Label8.Text = "Name"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(95, 218)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 12
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
        Me.GroupBox2.Location = New System.Drawing.Point(85, 219)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox2.TabIndex = 13
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
        Me.cmbmerchant.Location = New System.Drawing.Point(109, 71)
        Me.cmbmerchant.MaxDropDownItems = 14
        Me.cmbmerchant.Name = "cmbmerchant"
        Me.cmbmerchant.Size = New System.Drawing.Size(244, 22)
        Me.cmbmerchant.TabIndex = 1
        '
        'lblvendorname
        '
        Me.lblvendorname.AutoSize = True
        Me.lblvendorname.BackColor = System.Drawing.Color.Transparent
        Me.lblvendorname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvendorname.ForeColor = System.Drawing.Color.Black
        Me.lblvendorname.Location = New System.Drawing.Point(51, 75)
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
        Me.cmdshowreport.Location = New System.Drawing.Point(252, 392)
        Me.cmdshowreport.Name = "cmdshowreport"
        Me.cmdshowreport.Size = New System.Drawing.Size(85, 28)
        Me.cmdshowreport.TabIndex = 14
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
        Me.cmdexit.Location = New System.Drawing.Point(343, 392)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 15
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'RDBPARTYWISEDETAILS
        '
        Me.RDBPARTYWISEDETAILS.AutoSize = True
        Me.RDBPARTYWISEDETAILS.Location = New System.Drawing.Point(20, 69)
        Me.RDBPARTYWISEDETAILS.Name = "RDBPARTYWISEDETAILS"
        Me.RDBPARTYWISEDETAILS.Size = New System.Drawing.Size(119, 18)
        Me.RDBPARTYWISEDETAILS.TabIndex = 2
        Me.RDBPARTYWISEDETAILS.Text = "Party Wise Detail"
        Me.RDBPARTYWISEDETAILS.UseVisualStyleBackColor = True
        '
        'RDBPARTYMERCHANTSUMM
        '
        Me.RDBPARTYMERCHANTSUMM.AutoSize = True
        Me.RDBPARTYMERCHANTSUMM.Location = New System.Drawing.Point(220, 21)
        Me.RDBPARTYMERCHANTSUMM.Name = "RDBPARTYMERCHANTSUMM"
        Me.RDBPARTYMERCHANTSUMM.Size = New System.Drawing.Size(195, 18)
        Me.RDBPARTYMERCHANTSUMM.TabIndex = 3
        Me.RDBPARTYMERCHANTSUMM.Text = "Party - Merchant Wise Summary"
        Me.RDBPARTYMERCHANTSUMM.UseVisualStyleBackColor = True
        '
        'JobPackingFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(693, 442)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "JobPackingFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Job Bale Packing Filter"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As BlendPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents CLB_CATEGORY As CheckedListBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CLB_DEPARTMENT As CheckedListBox
    Friend WithEvents CLB_GRADE As CheckedListBox
    Friend WithEvents TXTMERCHANT As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtadd As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RDBITEMWISE As RadioButton
    Friend WithEvents rdbdetail As RadioButton
    Friend WithEvents TXTBALENO As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbname As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents chkdate As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbmerchant As ComboBox
    Friend WithEvents lblvendorname As Label
    Friend WithEvents cmdshowreport As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents RDBPARTYMERCHANTSUMM As RadioButton
    Friend WithEvents RDBPARTYWISEDETAILS As RadioButton
End Class
