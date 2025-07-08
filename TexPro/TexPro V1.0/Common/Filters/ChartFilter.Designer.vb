<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChartFilter
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
        Me.txtadd = New System.Windows.Forms.TextBox
        Me.RBMONTH = New System.Windows.Forms.RadioButton
        Me.RBNAME = New System.Windows.Forms.RadioButton
        Me.RBMERCHANTWISE = New System.Windows.Forms.RadioButton
        Me.cmbname = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbmerchant = New System.Windows.Forms.ComboBox
        Me.LBLMERCHANT = New System.Windows.Forms.Label
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdshow = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.TXTMTRS = New System.Windows.Forms.TextBox
        Me.LBLCUT = New System.Windows.Forms.Label
        Me.BlendPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.TXTMTRS)
        Me.BlendPanel2.Controls.Add(Me.LBLCUT)
        Me.BlendPanel2.Controls.Add(Me.txtadd)
        Me.BlendPanel2.Controls.Add(Me.RBMONTH)
        Me.BlendPanel2.Controls.Add(Me.RBNAME)
        Me.BlendPanel2.Controls.Add(Me.RBMERCHANTWISE)
        Me.BlendPanel2.Controls.Add(Me.cmbname)
        Me.BlendPanel2.Controls.Add(Me.Label8)
        Me.BlendPanel2.Controls.Add(Me.cmbmerchant)
        Me.BlendPanel2.Controls.Add(Me.LBLMERCHANT)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(345, 287)
        Me.BlendPanel2.TabIndex = 0
        '
        'txtadd
        '
        Me.txtadd.BackColor = System.Drawing.Color.White
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.Location = New System.Drawing.Point(298, 86)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(35, 22)
        Me.txtadd.TabIndex = 454
        Me.txtadd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtadd.Visible = False
        '
        'RBMONTH
        '
        Me.RBMONTH.AutoSize = True
        Me.RBMONTH.BackColor = System.Drawing.Color.Transparent
        Me.RBMONTH.Location = New System.Drawing.Point(191, 121)
        Me.RBMONTH.Name = "RBMONTH"
        Me.RBMONTH.Size = New System.Drawing.Size(92, 19)
        Me.RBMONTH.TabIndex = 5
        Me.RBMONTH.TabStop = True
        Me.RBMONTH.Text = "Month Wise"
        Me.RBMONTH.UseVisualStyleBackColor = False
        '
        'RBNAME
        '
        Me.RBNAME.AutoSize = True
        Me.RBNAME.BackColor = System.Drawing.Color.Transparent
        Me.RBNAME.Location = New System.Drawing.Point(61, 146)
        Me.RBNAME.Name = "RBNAME"
        Me.RBNAME.Size = New System.Drawing.Size(85, 19)
        Me.RBNAME.TabIndex = 4
        Me.RBNAME.TabStop = True
        Me.RBNAME.Text = "Party Wise"
        Me.RBNAME.UseVisualStyleBackColor = False
        '
        'RBMERCHANTWISE
        '
        Me.RBMERCHANTWISE.AutoSize = True
        Me.RBMERCHANTWISE.BackColor = System.Drawing.Color.Transparent
        Me.RBMERCHANTWISE.Checked = True
        Me.RBMERCHANTWISE.Location = New System.Drawing.Point(61, 121)
        Me.RBMERCHANTWISE.Name = "RBMERCHANTWISE"
        Me.RBMERCHANTWISE.Size = New System.Drawing.Size(109, 19)
        Me.RBMERCHANTWISE.TabIndex = 3
        Me.RBMERCHANTWISE.TabStop = True
        Me.RBMERCHANTWISE.Text = "Merchant Wise"
        Me.RBMERCHANTWISE.UseVisualStyleBackColor = False
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(90, 22)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(225, 22)
        Me.cmbname.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(46, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 14)
        Me.Label8.TabIndex = 448
        Me.Label8.Text = "Name"
        '
        'cmbmerchant
        '
        Me.cmbmerchant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbmerchant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbmerchant.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbmerchant.FormattingEnabled = True
        Me.cmbmerchant.Location = New System.Drawing.Point(90, 50)
        Me.cmbmerchant.MaxDropDownItems = 14
        Me.cmbmerchant.Name = "cmbmerchant"
        Me.cmbmerchant.Size = New System.Drawing.Size(225, 22)
        Me.cmbmerchant.TabIndex = 1
        '
        'LBLMERCHANT
        '
        Me.LBLMERCHANT.AutoSize = True
        Me.LBLMERCHANT.BackColor = System.Drawing.Color.Transparent
        Me.LBLMERCHANT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMERCHANT.ForeColor = System.Drawing.Color.Black
        Me.LBLMERCHANT.Location = New System.Drawing.Point(30, 54)
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
        Me.chkdate.Location = New System.Drawing.Point(40, 183)
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
        Me.GroupBox1.Location = New System.Drawing.Point(32, 183)
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
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdshow.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Image = Global.TexPro_V1.My.Resources.Resources.showreport
        Me.cmdshow.Location = New System.Drawing.Point(96, 244)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(75, 28)
        Me.cmdshow.TabIndex = 8
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
        Me.cmdexit.Location = New System.Drawing.Point(177, 246)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 29)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TXTMTRS
        '
        Me.TXTMTRS.BackColor = System.Drawing.Color.White
        Me.TXTMTRS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMTRS.Location = New System.Drawing.Point(191, 78)
        Me.TXTMTRS.Name = "TXTMTRS"
        Me.TXTMTRS.Size = New System.Drawing.Size(124, 22)
        Me.TXTMTRS.TabIndex = 2
        Me.TXTMTRS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLCUT
        '
        Me.LBLCUT.AutoSize = True
        Me.LBLCUT.BackColor = System.Drawing.Color.Transparent
        Me.LBLCUT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCUT.ForeColor = System.Drawing.Color.Black
        Me.LBLCUT.Location = New System.Drawing.Point(87, 82)
        Me.LBLCUT.Name = "LBLCUT"
        Me.LBLCUT.Size = New System.Drawing.Size(101, 14)
        Me.LBLCUT.TabIndex = 454
        Me.LBLCUT.Text = "Mtrs greater than"
        '
        'ChartFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(345, 287)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ChartFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Chart Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents cmbmerchant As System.Windows.Forms.ComboBox
    Friend WithEvents LBLMERCHANT As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents RBNAME As System.Windows.Forms.RadioButton
    Friend WithEvents RBMERCHANTWISE As System.Windows.Forms.RadioButton
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents RBMONTH As System.Windows.Forms.RadioButton
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents TXTMTRS As System.Windows.Forms.TextBox
    Friend WithEvents LBLCUT As System.Windows.Forms.Label
End Class
