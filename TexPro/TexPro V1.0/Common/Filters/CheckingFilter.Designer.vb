<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckingFilter
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
        Me.RDBMONTHSUMRY = New System.Windows.Forms.RadioButton()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.RDBQUALITYSUMRY = New System.Windows.Forms.RadioButton()
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.TXTLOT = New System.Windows.Forms.TextBox()
        Me.TXTTEMP = New System.Windows.Forms.TextBox()
        Me.CMBQUALITY = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RDBCHKSUMRY = New System.Windows.Forms.RadioButton()
        Me.RDBPARTYWISEDETAIL = New System.Windows.Forms.RadioButton()
        Me.RDBPARTYSUMRY = New System.Windows.Forms.RadioButton()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.RDBDTLS = New System.Windows.Forms.RadioButton()
        Me.BlendPanel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RDBMONTHSUMRY
        '
        Me.RDBMONTHSUMRY.AutoSize = True
        Me.RDBMONTHSUMRY.BackColor = System.Drawing.Color.Transparent
        Me.RDBMONTHSUMRY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDBMONTHSUMRY.Location = New System.Drawing.Point(151, 47)
        Me.RDBMONTHSUMRY.Name = "RDBMONTHSUMRY"
        Me.RDBMONTHSUMRY.Size = New System.Drawing.Size(143, 19)
        Me.RDBMONTHSUMRY.TabIndex = 456
        Me.RDBMONTHSUMRY.TabStop = True
        Me.RDBMONTHSUMRY.Text = "Month Wise Summary"
        Me.RDBMONTHSUMRY.UseVisualStyleBackColor = False
        Me.RDBMONTHSUMRY.Visible = False
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
        'RDBQUALITYSUMRY
        '
        Me.RDBQUALITYSUMRY.AutoSize = True
        Me.RDBQUALITYSUMRY.BackColor = System.Drawing.Color.Transparent
        Me.RDBQUALITYSUMRY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDBQUALITYSUMRY.Location = New System.Drawing.Point(151, 22)
        Me.RDBQUALITYSUMRY.Name = "RDBQUALITYSUMRY"
        Me.RDBQUALITYSUMRY.Size = New System.Drawing.Size(145, 19)
        Me.RDBQUALITYSUMRY.TabIndex = 5
        Me.RDBQUALITYSUMRY.TabStop = True
        Me.RDBQUALITYSUMRY.Text = "Quality Wise Summary"
        Me.RDBQUALITYSUMRY.UseVisualStyleBackColor = False
        Me.RDBQUALITYSUMRY.Visible = False
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.TXTLOT)
        Me.BlendPanel2.Controls.Add(Me.TXTTEMP)
        Me.BlendPanel2.Controls.Add(Me.CMBQUALITY)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.GroupBox2)
        Me.BlendPanel2.Controls.Add(Me.txtadd)
        Me.BlendPanel2.Controls.Add(Me.cmbname)
        Me.BlendPanel2.Controls.Add(Me.Label8)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(354, 314)
        Me.BlendPanel2.TabIndex = 2
        '
        'TXTLOT
        '
        Me.TXTLOT.BackColor = System.Drawing.Color.White
        Me.TXTLOT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOT.Location = New System.Drawing.Point(311, 89)
        Me.TXTLOT.Name = "TXTLOT"
        Me.TXTLOT.Size = New System.Drawing.Size(10, 22)
        Me.TXTLOT.TabIndex = 463
        Me.TXTLOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTLOT.Visible = False
        '
        'TXTTEMP
        '
        Me.TXTTEMP.BackColor = System.Drawing.Color.White
        Me.TXTTEMP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTEMP.Location = New System.Drawing.Point(308, 47)
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
        Me.CMBQUALITY.Location = New System.Drawing.Point(90, 50)
        Me.CMBQUALITY.MaxDropDownItems = 14
        Me.CMBQUALITY.Name = "CMBQUALITY"
        Me.CMBQUALITY.Size = New System.Drawing.Size(193, 22)
        Me.CMBQUALITY.TabIndex = 458
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(41, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 461
        Me.Label2.Text = "Quality"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.RDBDTLS)
        Me.GroupBox2.Controls.Add(Me.RDBCHKSUMRY)
        Me.GroupBox2.Controls.Add(Me.RDBMONTHSUMRY)
        Me.GroupBox2.Controls.Add(Me.RDBQUALITYSUMRY)
        Me.GroupBox2.Controls.Add(Me.RDBPARTYWISEDETAIL)
        Me.GroupBox2.Controls.Add(Me.RDBPARTYSUMRY)
        Me.GroupBox2.Location = New System.Drawing.Point(22, 89)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(311, 112)
        Me.GroupBox2.TabIndex = 457
        Me.GroupBox2.TabStop = False
        '
        'RDBCHKSUMRY
        '
        Me.RDBCHKSUMRY.AutoSize = True
        Me.RDBCHKSUMRY.BackColor = System.Drawing.Color.Transparent
        Me.RDBCHKSUMRY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDBCHKSUMRY.Location = New System.Drawing.Point(9, 70)
        Me.RDBCHKSUMRY.Name = "RDBCHKSUMRY"
        Me.RDBCHKSUMRY.Size = New System.Drawing.Size(125, 19)
        Me.RDBCHKSUMRY.TabIndex = 457
        Me.RDBCHKSUMRY.TabStop = True
        Me.RDBCHKSUMRY.Text = "Checking Summary"
        Me.RDBCHKSUMRY.UseVisualStyleBackColor = False
        Me.RDBCHKSUMRY.Visible = False
        '
        'RDBPARTYWISEDETAIL
        '
        Me.RDBPARTYWISEDETAIL.AutoSize = True
        Me.RDBPARTYWISEDETAIL.BackColor = System.Drawing.Color.Transparent
        Me.RDBPARTYWISEDETAIL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDBPARTYWISEDETAIL.Location = New System.Drawing.Point(9, 47)
        Me.RDBPARTYWISEDETAIL.Name = "RDBPARTYWISEDETAIL"
        Me.RDBPARTYWISEDETAIL.Size = New System.Drawing.Size(115, 19)
        Me.RDBPARTYWISEDETAIL.TabIndex = 4
        Me.RDBPARTYWISEDETAIL.TabStop = True
        Me.RDBPARTYWISEDETAIL.Text = "Party Wise Detail"
        Me.RDBPARTYWISEDETAIL.UseVisualStyleBackColor = False
        Me.RDBPARTYWISEDETAIL.Visible = False
        '
        'RDBPARTYSUMRY
        '
        Me.RDBPARTYSUMRY.AutoSize = True
        Me.RDBPARTYSUMRY.BackColor = System.Drawing.Color.Transparent
        Me.RDBPARTYSUMRY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDBPARTYSUMRY.Location = New System.Drawing.Point(9, 22)
        Me.RDBPARTYSUMRY.Name = "RDBPARTYSUMRY"
        Me.RDBPARTYSUMRY.Size = New System.Drawing.Size(135, 19)
        Me.RDBPARTYSUMRY.TabIndex = 3
        Me.RDBPARTYSUMRY.Text = "Party Wise Summary"
        Me.RDBPARTYSUMRY.UseVisualStyleBackColor = False
        Me.RDBPARTYSUMRY.Visible = False
        '
        'txtadd
        '
        Me.txtadd.BackColor = System.Drawing.Color.White
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.Location = New System.Drawing.Point(308, 76)
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
        Me.cmbname.Location = New System.Drawing.Point(90, 22)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(193, 22)
        Me.cmbname.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(48, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 14)
        Me.Label8.TabIndex = 448
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
        Me.chkdate.Location = New System.Drawing.Point(47, 215)
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
        Me.GroupBox1.Location = New System.Drawing.Point(37, 215)
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
        Me.cmdshow.Location = New System.Drawing.Point(96, 276)
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
        Me.cmdexit.Location = New System.Drawing.Point(177, 278)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 29)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'RDBDTLS
        '
        Me.RDBDTLS.AutoSize = True
        Me.RDBDTLS.BackColor = System.Drawing.Color.Transparent
        Me.RDBDTLS.Checked = True
        Me.RDBDTLS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RDBDTLS.Location = New System.Drawing.Point(151, 72)
        Me.RDBDTLS.Name = "RDBDTLS"
        Me.RDBDTLS.Size = New System.Drawing.Size(110, 19)
        Me.RDBDTLS.TabIndex = 458
        Me.RDBDTLS.TabStop = True
        Me.RDBDTLS.Text = "Checking Details"
        Me.RDBDTLS.UseVisualStyleBackColor = False
        '
        'CheckingFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(354, 314)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "CheckingFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Checking Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RDBMONTHSUMRY As System.Windows.Forms.RadioButton
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents RDBQUALITYSUMRY As System.Windows.Forms.RadioButton
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents TXTTEMP As System.Windows.Forms.TextBox
    Friend WithEvents CMBQUALITY As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RDBPARTYWISEDETAIL As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPARTYSUMRY As System.Windows.Forms.RadioButton
    Friend WithEvents txtadd As System.Windows.Forms.TextBox
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents RDBCHKSUMRY As System.Windows.Forms.RadioButton
    Friend WithEvents TXTLOT As System.Windows.Forms.TextBox
    Friend WithEvents RDBDTLS As RadioButton
End Class
