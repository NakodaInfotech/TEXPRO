<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GRNFilter
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
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.CHKSUMMARY = New System.Windows.Forms.CheckBox()
        Me.TXTTEMP = New System.Windows.Forms.TextBox()
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RBGRNQUALITYPCS = New System.Windows.Forms.RadioButton()
        Me.RBGRNQUALITYMTRS = New System.Windows.Forms.RadioButton()
        Me.RBGRNPCS = New System.Windows.Forms.RadioButton()
        Me.RBGRNMTRS = New System.Windows.Forms.RadioButton()
        Me.RDBMONTH = New System.Windows.Forms.RadioButton()
        Me.RDBQUALITY = New System.Windows.Forms.RadioButton()
        Me.RDBPARTY = New System.Windows.Forms.RadioButton()
        Me.RDBITEM = New System.Windows.Forms.RadioButton()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbitemname = New System.Windows.Forms.ComboBox()
        Me.LBLITEM = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.BlendPanel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.CHKSUMMARY)
        Me.BlendPanel2.Controls.Add(Me.TXTTEMP)
        Me.BlendPanel2.Controls.Add(Me.CMBQUALITY)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.GroupBox2)
        Me.BlendPanel2.Controls.Add(Me.txtadd)
        Me.BlendPanel2.Controls.Add(Me.cmbname)
        Me.BlendPanel2.Controls.Add(Me.Label8)
        Me.BlendPanel2.Controls.Add(Me.cmbitemname)
        Me.BlendPanel2.Controls.Add(Me.LBLITEM)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(418, 476)
        Me.BlendPanel2.TabIndex = 1
        '
        'CHKSUMMARY
        '
        Me.CHKSUMMARY.AutoSize = True
        Me.CHKSUMMARY.BackColor = System.Drawing.Color.Transparent
        Me.CHKSUMMARY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSUMMARY.ForeColor = System.Drawing.Color.Black
        Me.CHKSUMMARY.Location = New System.Drawing.Point(39, 116)
        Me.CHKSUMMARY.Name = "CHKSUMMARY"
        Me.CHKSUMMARY.Size = New System.Drawing.Size(73, 18)
        Me.CHKSUMMARY.TabIndex = 463
        Me.CHKSUMMARY.Text = "Summary"
        Me.CHKSUMMARY.UseVisualStyleBackColor = False
        '
        'TXTTEMP
        '
        Me.TXTTEMP.BackColor = System.Drawing.Color.White
        Me.TXTTEMP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTEMP.Location = New System.Drawing.Point(371, 47)
        Me.TXTTEMP.Name = "TXTTEMP"
        Me.TXTTEMP.Size = New System.Drawing.Size(24, 22)
        Me.TXTTEMP.TabIndex = 462
        Me.TXTTEMP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTTEMP.Visible = False
        '
        'CMBQUALITY
        '
        Me.CMBQUALITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBQUALITY.FormattingEnabled = True
        Me.CMBQUALITY.Location = New System.Drawing.Point(106, 80)
        Me.CMBQUALITY.MaxDropDownItems = 14
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(275, 22)
        Me.CMBQUALITY.TabIndex = 458
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(58, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 461
        Me.Label2.Text = "Quality"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.RBGRNQUALITYPCS)
        Me.GroupBox2.Controls.Add(Me.RBGRNQUALITYMTRS)
        Me.GroupBox2.Controls.Add(Me.RBGRNPCS)
        Me.GroupBox2.Controls.Add(Me.RBGRNMTRS)
        Me.GroupBox2.Controls.Add(Me.RDBMONTH)
        Me.GroupBox2.Controls.Add(Me.RDBQUALITY)
        Me.GroupBox2.Controls.Add(Me.RDBPARTY)
        Me.GroupBox2.Controls.Add(Me.RDBITEM)
        Me.GroupBox2.Location = New System.Drawing.Point(25, 129)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 127)
        Me.GroupBox2.TabIndex = 457
        Me.GroupBox2.TabStop = False
        '
        'RBGRNQUALITYPCS
        '
        Me.RBGRNQUALITYPCS.AutoSize = True
        Me.RBGRNQUALITYPCS.BackColor = System.Drawing.Color.Transparent
        Me.RBGRNQUALITYPCS.Location = New System.Drawing.Point(195, 97)
        Me.RBGRNQUALITYPCS.Name = "RBGRNQUALITYPCS"
        Me.RBGRNQUALITYPCS.Size = New System.Drawing.Size(154, 19)
        Me.RBGRNQUALITYPCS.TabIndex = 460
        Me.RBGRNQUALITYPCS.TabStop = True
        Me.RBGRNQUALITYPCS.Text = "GRN Quality Wise (Mtrs)"
        Me.RBGRNQUALITYPCS.UseVisualStyleBackColor = False
        '
        'RBGRNQUALITYMTRS
        '
        Me.RBGRNQUALITYMTRS.AutoSize = True
        Me.RBGRNQUALITYMTRS.BackColor = System.Drawing.Color.Transparent
        Me.RBGRNQUALITYMTRS.Location = New System.Drawing.Point(17, 97)
        Me.RBGRNQUALITYMTRS.Name = "RBGRNQUALITYMTRS"
        Me.RBGRNQUALITYMTRS.Size = New System.Drawing.Size(154, 19)
        Me.RBGRNQUALITYMTRS.TabIndex = 459
        Me.RBGRNQUALITYMTRS.TabStop = True
        Me.RBGRNQUALITYMTRS.Text = "GRN Quality Wise (Mtrs)"
        Me.RBGRNQUALITYMTRS.UseVisualStyleBackColor = False
        '
        'RBGRNPCS
        '
        Me.RBGRNPCS.AutoSize = True
        Me.RBGRNPCS.BackColor = System.Drawing.Color.Transparent
        Me.RBGRNPCS.Location = New System.Drawing.Point(195, 72)
        Me.RBGRNPCS.Name = "RBGRNPCS"
        Me.RBGRNPCS.Size = New System.Drawing.Size(114, 19)
        Me.RBGRNPCS.TabIndex = 458
        Me.RBGRNPCS.TabStop = True
        Me.RBGRNPCS.Text = "GRN Details (Pcs)"
        Me.RBGRNPCS.UseVisualStyleBackColor = False
        '
        'RBGRNMTRS
        '
        Me.RBGRNMTRS.AutoSize = True
        Me.RBGRNMTRS.BackColor = System.Drawing.Color.Transparent
        Me.RBGRNMTRS.Location = New System.Drawing.Point(17, 72)
        Me.RBGRNMTRS.Name = "RBGRNMTRS"
        Me.RBGRNMTRS.Size = New System.Drawing.Size(122, 19)
        Me.RBGRNMTRS.TabIndex = 457
        Me.RBGRNMTRS.TabStop = True
        Me.RBGRNMTRS.Text = "GRN Details (Mtrs)"
        Me.RBGRNMTRS.UseVisualStyleBackColor = False
        '
        'RDBMONTH
        '
        Me.RDBMONTH.AutoSize = True
        Me.RDBMONTH.BackColor = System.Drawing.Color.Transparent
        Me.RDBMONTH.Location = New System.Drawing.Point(195, 47)
        Me.RDBMONTH.Name = "RDBMONTH"
        Me.RDBMONTH.Size = New System.Drawing.Size(90, 19)
        Me.RDBMONTH.TabIndex = 456
        Me.RDBMONTH.TabStop = True
        Me.RDBMONTH.Text = "Month Wise"
        Me.RDBMONTH.UseVisualStyleBackColor = False
        '
        'RDBQUALITY
        '
        Me.RDBQUALITY.AutoSize = True
        Me.RDBQUALITY.BackColor = System.Drawing.Color.Transparent
        Me.RDBQUALITY.Location = New System.Drawing.Point(195, 22)
        Me.RDBQUALITY.Name = "RDBQUALITY"
        Me.RDBQUALITY.Size = New System.Drawing.Size(92, 19)
        Me.RDBQUALITY.TabIndex = 5
        Me.RDBQUALITY.TabStop = True
        Me.RDBQUALITY.Text = "Quality Wise"
        Me.RDBQUALITY.UseVisualStyleBackColor = False
        '
        'RDBPARTY
        '
        Me.RDBPARTY.AutoSize = True
        Me.RDBPARTY.BackColor = System.Drawing.Color.Transparent
        Me.RDBPARTY.Location = New System.Drawing.Point(17, 47)
        Me.RDBPARTY.Name = "RDBPARTY"
        Me.RDBPARTY.Size = New System.Drawing.Size(82, 19)
        Me.RDBPARTY.TabIndex = 4
        Me.RDBPARTY.TabStop = True
        Me.RDBPARTY.Text = "Party Wise"
        Me.RDBPARTY.UseVisualStyleBackColor = False
        '
        'RDBITEM
        '
        Me.RDBITEM.AutoSize = True
        Me.RDBITEM.BackColor = System.Drawing.Color.Transparent
        Me.RDBITEM.Checked = True
        Me.RDBITEM.Location = New System.Drawing.Point(17, 22)
        Me.RDBITEM.Name = "RDBITEM"
        Me.RDBITEM.Size = New System.Drawing.Size(77, 19)
        Me.RDBITEM.TabIndex = 3
        Me.RDBITEM.TabStop = True
        Me.RDBITEM.Text = "Item Wise"
        Me.RDBITEM.UseVisualStyleBackColor = False
        '
        'txtadd
        '
        Me.txtadd.BackColor = System.Drawing.Color.White
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.Location = New System.Drawing.Point(371, 76)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(24, 22)
        Me.txtadd.TabIndex = 454
        Me.txtadd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtadd.Visible = False
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(106, 22)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(275, 22)
        Me.cmbname.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(65, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 14)
        Me.Label8.TabIndex = 448
        Me.Label8.Text = "Name"
        '
        'cmbitemname
        '
        Me.cmbitemname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbitemname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbitemname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbitemname.FormattingEnabled = True
        Me.cmbitemname.Items.AddRange(New Object() {"", "GREY MATERIAL"})
        Me.cmbitemname.Location = New System.Drawing.Point(106, 51)
        Me.cmbitemname.MaxDropDownItems = 14
        Me.cmbitemname.Name = "cmbitemname"
        Me.cmbitemname.Size = New System.Drawing.Size(275, 22)
        Me.cmbitemname.TabIndex = 1
        '
        'LBLITEM
        '
        Me.LBLITEM.AutoSize = True
        Me.LBLITEM.BackColor = System.Drawing.Color.Transparent
        Me.LBLITEM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLITEM.ForeColor = System.Drawing.Color.Black
        Me.LBLITEM.Location = New System.Drawing.Point(37, 55)
        Me.LBLITEM.Name = "LBLITEM"
        Me.LBLITEM.Size = New System.Drawing.Size(63, 14)
        Me.LBLITEM.TabIndex = 446
        Me.LBLITEM.Text = "Item Name"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Checked = True
        Me.chkdate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(77, 372)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(49, 18)
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
        Me.GroupBox1.Location = New System.Drawing.Point(69, 372)
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
        Me.Label1.Size = New System.Drawing.Size(24, 14)
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
        Me.Label7.Size = New System.Drawing.Size(39, 14)
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
        Me.cmdshow.Location = New System.Drawing.Point(133, 433)
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
        Me.cmdexit.Location = New System.Drawing.Point(214, 435)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 29)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'GRNFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(418, 476)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GRNFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "GRN Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents RDBQUALITY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPARTY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBITEM As System.Windows.Forms.RadioButton
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbitemname As System.Windows.Forms.ComboBox
    Friend WithEvents LBLITEM As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents RDBMONTH As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CMBQUALITY As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTTEMP As System.Windows.Forms.TextBox
    Friend WithEvents CHKSUMMARY As System.Windows.Forms.CheckBox
    Friend WithEvents RBGRNPCS As System.Windows.Forms.RadioButton
    Friend WithEvents RBGRNMTRS As System.Windows.Forms.RadioButton
    Friend WithEvents RBGRNQUALITYMTRS As System.Windows.Forms.RadioButton
    Friend WithEvents RBGRNQUALITYPCS As System.Windows.Forms.RadioButton
End Class
