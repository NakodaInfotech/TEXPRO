<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AnalyticalFilterPurchase
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RDBTOPAGENT = New System.Windows.Forms.RadioButton()
        Me.TXTMTRSGREATER = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RDBTOPITEM = New System.Windows.Forms.RadioButton()
        Me.TXTTOP = New System.Windows.Forms.TextBox()
        Me.CMBAGENT = New System.Windows.Forms.ComboBox()
        Me.RDBTOPPARTY = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.cmbmerchant = New System.Windows.Forms.ComboBox()
        Me.lblvendorname = New System.Windows.Forms.Label()
        Me.cmdshowreport = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.RDBTOPDEPARTMENT = New System.Windows.Forms.RadioButton()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.RDBTOPDEPARTMENT)
        Me.BlendPanel1.Controls.Add(Me.CMBDEPARTMENT)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.RDBTOPAGENT)
        Me.BlendPanel1.Controls.Add(Me.TXTMTRSGREATER)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.RDBTOPITEM)
        Me.BlendPanel1.Controls.Add(Me.TXTTOP)
        Me.BlendPanel1.Controls.Add(Me.CMBAGENT)
        Me.BlendPanel1.Controls.Add(Me.RDBTOPPARTY)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.cmbmerchant)
        Me.BlendPanel1.Controls.Add(Me.lblvendorname)
        Me.BlendPanel1.Controls.Add(Me.cmdshowreport)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(341, 375)
        Me.BlendPanel1.TabIndex = 1
        '
        'CMBDEPARTMENT
        '
        Me.CMBDEPARTMENT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDEPARTMENT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDEPARTMENT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDEPARTMENT.FormattingEnabled = True
        Me.CMBDEPARTMENT.Location = New System.Drawing.Point(104, 78)
        Me.CMBDEPARTMENT.MaxDropDownItems = 14
        Me.CMBDEPARTMENT.Name = "CMBDEPARTMENT"
        Me.CMBDEPARTMENT.Size = New System.Drawing.Size(207, 22)
        Me.CMBDEPARTMENT.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(30, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 538
        Me.Label2.Text = "Department"
        '
        'RDBTOPAGENT
        '
        Me.RDBTOPAGENT.AutoSize = True
        Me.RDBTOPAGENT.BackColor = System.Drawing.Color.Transparent
        Me.RDBTOPAGENT.Location = New System.Drawing.Point(169, 196)
        Me.RDBTOPAGENT.Name = "RDBTOPAGENT"
        Me.RDBTOPAGENT.Size = New System.Drawing.Size(77, 19)
        Me.RDBTOPAGENT.TabIndex = 12
        Me.RDBTOPAGENT.Text = "Top Agent"
        Me.RDBTOPAGENT.UseVisualStyleBackColor = False
        '
        'TXTMTRSGREATER
        '
        Me.TXTMTRSGREATER.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTMTRSGREATER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMTRSGREATER.Location = New System.Drawing.Point(104, 134)
        Me.TXTMTRSGREATER.Name = "TXTMTRSGREATER"
        Me.TXTMTRSGREATER.Size = New System.Drawing.Size(77, 22)
        Me.TXTMTRSGREATER.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(39, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 14)
        Me.Label1.TabIndex = 536
        Me.Label1.Text = "Qty > Then"
        '
        'RDBTOPITEM
        '
        Me.RDBTOPITEM.AutoSize = True
        Me.RDBTOPITEM.BackColor = System.Drawing.Color.Transparent
        Me.RDBTOPITEM.Location = New System.Drawing.Point(60, 196)
        Me.RDBTOPITEM.Name = "RDBTOPITEM"
        Me.RDBTOPITEM.Size = New System.Drawing.Size(71, 19)
        Me.RDBTOPITEM.TabIndex = 9
        Me.RDBTOPITEM.Text = "Top Item"
        Me.RDBTOPITEM.UseVisualStyleBackColor = False
        '
        'TXTTOP
        '
        Me.TXTTOP.BackColor = System.Drawing.Color.White
        Me.TXTTOP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOP.ForeColor = System.Drawing.Color.Black
        Me.TXTTOP.Location = New System.Drawing.Point(60, 221)
        Me.TXTTOP.Name = "TXTTOP"
        Me.TXTTOP.Size = New System.Drawing.Size(29, 22)
        Me.TXTTOP.TabIndex = 13
        Me.TXTTOP.Text = "10"
        Me.TXTTOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBAGENT
        '
        Me.CMBAGENT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBAGENT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBAGENT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBAGENT.FormattingEnabled = True
        Me.CMBAGENT.Location = New System.Drawing.Point(104, 106)
        Me.CMBAGENT.MaxDropDownItems = 14
        Me.CMBAGENT.Name = "CMBAGENT"
        Me.CMBAGENT.Size = New System.Drawing.Size(207, 22)
        Me.CMBAGENT.TabIndex = 4
        '
        'RDBTOPPARTY
        '
        Me.RDBTOPPARTY.AutoSize = True
        Me.RDBTOPPARTY.BackColor = System.Drawing.Color.Transparent
        Me.RDBTOPPARTY.Checked = True
        Me.RDBTOPPARTY.Location = New System.Drawing.Point(60, 171)
        Me.RDBTOPPARTY.Name = "RDBTOPPARTY"
        Me.RDBTOPPARTY.Size = New System.Drawing.Size(76, 19)
        Me.RDBTOPPARTY.TabIndex = 8
        Me.RDBTOPPARTY.Text = "Top Party"
        Me.RDBTOPPARTY.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(29, 110)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 14)
        Me.Label12.TabIndex = 530
        Me.Label12.Text = "Agent Name"
        '
        'txtadd
        '
        Me.txtadd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.Location = New System.Drawing.Point(187, 135)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(20, 22)
        Me.txtadd.TabIndex = 444
        Me.txtadd.Visible = False
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(104, 22)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(207, 22)
        Me.cmbname.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(63, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 14)
        Me.Label8.TabIndex = 433
        Me.Label8.Text = "Name"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtto)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dtfrom)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.chkdate)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(30, 261)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
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
        Me.dtfrom.TabIndex = 1
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
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Checked = True
        Me.chkdate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(17, -2)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 0
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'cmbmerchant
        '
        Me.cmbmerchant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbmerchant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbmerchant.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbmerchant.FormattingEnabled = True
        Me.cmbmerchant.Location = New System.Drawing.Point(104, 50)
        Me.cmbmerchant.MaxDropDownItems = 14
        Me.cmbmerchant.Name = "cmbmerchant"
        Me.cmbmerchant.Size = New System.Drawing.Size(207, 22)
        Me.cmbmerchant.TabIndex = 1
        '
        'lblvendorname
        '
        Me.lblvendorname.AutoSize = True
        Me.lblvendorname.BackColor = System.Drawing.Color.Transparent
        Me.lblvendorname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvendorname.ForeColor = System.Drawing.Color.Black
        Me.lblvendorname.Location = New System.Drawing.Point(35, 54)
        Me.lblvendorname.Name = "lblvendorname"
        Me.lblvendorname.Size = New System.Drawing.Size(67, 14)
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
        Me.cmdshowreport.Location = New System.Drawing.Point(83, 325)
        Me.cmdshowreport.Name = "cmdshowreport"
        Me.cmdshowreport.Size = New System.Drawing.Size(84, 28)
        Me.cmdshowreport.TabIndex = 15
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
        Me.cmdexit.Location = New System.Drawing.Point(173, 325)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(84, 28)
        Me.cmdexit.TabIndex = 16
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'RDBTOPDEPARTMENT
        '
        Me.RDBTOPDEPARTMENT.AutoSize = True
        Me.RDBTOPDEPARTMENT.BackColor = System.Drawing.Color.Transparent
        Me.RDBTOPDEPARTMENT.Location = New System.Drawing.Point(169, 171)
        Me.RDBTOPDEPARTMENT.Name = "RDBTOPDEPARTMENT"
        Me.RDBTOPDEPARTMENT.Size = New System.Drawing.Size(111, 19)
        Me.RDBTOPDEPARTMENT.TabIndex = 539
        Me.RDBTOPDEPARTMENT.Text = "Top Department"
        Me.RDBTOPDEPARTMENT.UseVisualStyleBackColor = False
        '
        'AnalyticalFilterPurchase
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(341, 375)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "AnalyticalFilterPurchase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Analytical Filter Purchase"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As BlendPanel
    Friend WithEvents CMBDEPARTMENT As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents RDBTOPAGENT As RadioButton
    Friend WithEvents TXTMTRSGREATER As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RDBTOPITEM As RadioButton
    Friend WithEvents TXTTOP As TextBox
    Friend WithEvents CMBAGENT As ComboBox
    Friend WithEvents RDBTOPPARTY As RadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents txtadd As TextBox
    Friend WithEvents cmbname As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents chkdate As CheckBox
    Friend WithEvents cmbmerchant As ComboBox
    Friend WithEvents lblvendorname As Label
    Friend WithEvents cmdshowreport As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents RDBTOPDEPARTMENT As RadioButton
End Class
