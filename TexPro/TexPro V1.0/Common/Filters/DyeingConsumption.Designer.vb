<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DyeingConsumption
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
        Me.CMBMERCHANT = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RBMERCHANTCOSTSUMM = New System.Windows.Forms.RadioButton()
        Me.RBMERCHANTCOSTDTLS = New System.Windows.Forms.RadioButton()
        Me.RBPROGRAMCOSTSUMM = New System.Windows.Forms.RadioButton()
        Me.RBPROGRAMCOST = New System.Windows.Forms.RadioButton()
        Me.RDBPROCESSDTLS = New System.Windows.Forms.RadioButton()
        Me.RDBPRGDTLS = New System.Windows.Forms.RadioButton()
        Me.cmbprocess = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LBLCOLOR = New System.Windows.Forms.Label()
        Me.CMBCOLOR = New System.Windows.Forms.ComboBox()
        Me.CMBDYEING = New System.Windows.Forms.ComboBox()
        Me.LBLPER = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMBPROG = New System.Windows.Forms.ComboBox()
        Me.LBLITEM = New System.Windows.Forms.Label()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.TXTCOST = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BlendPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.Label3)
        Me.BlendPanel2.Controls.Add(Me.TXTCOST)
        Me.BlendPanel2.Controls.Add(Me.CMBMERCHANT)
        Me.BlendPanel2.Controls.Add(Me.Label2)
        Me.BlendPanel2.Controls.Add(Me.GroupBox3)
        Me.BlendPanel2.Controls.Add(Me.cmbprocess)
        Me.BlendPanel2.Controls.Add(Me.Label8)
        Me.BlendPanel2.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel2.Controls.Add(Me.Label9)
        Me.BlendPanel2.Controls.Add(Me.LBLCOLOR)
        Me.BlendPanel2.Controls.Add(Me.CMBCOLOR)
        Me.BlendPanel2.Controls.Add(Me.CMBDYEING)
        Me.BlendPanel2.Controls.Add(Me.LBLPER)
        Me.BlendPanel2.Controls.Add(Me.chkdate)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.CMBPROG)
        Me.BlendPanel2.Controls.Add(Me.LBLITEM)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(711, 344)
        Me.BlendPanel2.TabIndex = 442
        '
        'CMBMERCHANT
        '
        Me.CMBMERCHANT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMERCHANT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMERCHANT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBMERCHANT.FormattingEnabled = True
        Me.CMBMERCHANT.Location = New System.Drawing.Point(445, 68)
        Me.CMBMERCHANT.MaxDropDownItems = 14
        Me.CMBMERCHANT.Name = "CMBMERCHANT"
        Me.CMBMERCHANT.Size = New System.Drawing.Size(213, 22)
        Me.CMBMERCHANT.TabIndex = 463
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(350, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 14)
        Me.Label2.TabIndex = 464
        Me.Label2.Text = "Merchant Name"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RBMERCHANTCOSTSUMM)
        Me.GroupBox3.Controls.Add(Me.RBMERCHANTCOSTDTLS)
        Me.GroupBox3.Controls.Add(Me.RBPROGRAMCOSTSUMM)
        Me.GroupBox3.Controls.Add(Me.RBPROGRAMCOST)
        Me.GroupBox3.Controls.Add(Me.RDBPROCESSDTLS)
        Me.GroupBox3.Controls.Add(Me.RDBPRGDTLS)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(88, 142)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(504, 107)
        Me.GroupBox3.TabIndex = 462
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Reports"
        '
        'RBMERCHANTCOSTSUMM
        '
        Me.RBMERCHANTCOSTSUMM.AutoSize = True
        Me.RBMERCHANTCOSTSUMM.Location = New System.Drawing.Point(259, 72)
        Me.RBMERCHANTCOSTSUMM.Name = "RBMERCHANTCOSTSUMM"
        Me.RBMERCHANTCOSTSUMM.Size = New System.Drawing.Size(185, 18)
        Me.RBMERCHANTCOSTSUMM.TabIndex = 6
        Me.RBMERCHANTCOSTSUMM.Text = "Merchant Wise Cost Summary"
        Me.RBMERCHANTCOSTSUMM.UseVisualStyleBackColor = True
        '
        'RBMERCHANTCOSTDTLS
        '
        Me.RBMERCHANTCOSTDTLS.AutoSize = True
        Me.RBMERCHANTCOSTDTLS.Location = New System.Drawing.Point(259, 48)
        Me.RBMERCHANTCOSTDTLS.Name = "RBMERCHANTCOSTDTLS"
        Me.RBMERCHANTCOSTDTLS.Size = New System.Drawing.Size(176, 18)
        Me.RBMERCHANTCOSTDTLS.TabIndex = 5
        Me.RBMERCHANTCOSTDTLS.Text = "Merchant Wise Cost Details"
        Me.RBMERCHANTCOSTDTLS.UseVisualStyleBackColor = True
        '
        'RBPROGRAMCOSTSUMM
        '
        Me.RBPROGRAMCOSTSUMM.AutoSize = True
        Me.RBPROGRAMCOSTSUMM.Location = New System.Drawing.Point(21, 72)
        Me.RBPROGRAMCOSTSUMM.Name = "RBPROGRAMCOSTSUMM"
        Me.RBPROGRAMCOSTSUMM.Size = New System.Drawing.Size(178, 18)
        Me.RBPROGRAMCOSTSUMM.TabIndex = 4
        Me.RBPROGRAMCOSTSUMM.Text = "Program Wise Cost Summary"
        Me.RBPROGRAMCOSTSUMM.UseVisualStyleBackColor = True
        '
        'RBPROGRAMCOST
        '
        Me.RBPROGRAMCOST.AutoSize = True
        Me.RBPROGRAMCOST.Location = New System.Drawing.Point(21, 48)
        Me.RBPROGRAMCOST.Name = "RBPROGRAMCOST"
        Me.RBPROGRAMCOST.Size = New System.Drawing.Size(169, 18)
        Me.RBPROGRAMCOST.TabIndex = 3
        Me.RBPROGRAMCOST.Text = "Program Wise Cost Details"
        Me.RBPROGRAMCOST.UseVisualStyleBackColor = True
        '
        'RDBPROCESSDTLS
        '
        Me.RDBPROCESSDTLS.AutoSize = True
        Me.RDBPROCESSDTLS.Location = New System.Drawing.Point(259, 24)
        Me.RDBPROCESSDTLS.Name = "RDBPROCESSDTLS"
        Me.RDBPROCESSDTLS.Size = New System.Drawing.Size(214, 18)
        Me.RDBPROCESSDTLS.TabIndex = 2
        Me.RDBPROCESSDTLS.Text = "Process Wise Consumption Details"
        Me.RDBPROCESSDTLS.UseVisualStyleBackColor = True
        '
        'RDBPRGDTLS
        '
        Me.RDBPRGDTLS.AutoSize = True
        Me.RDBPRGDTLS.Checked = True
        Me.RDBPRGDTLS.Location = New System.Drawing.Point(21, 24)
        Me.RDBPRGDTLS.Name = "RDBPRGDTLS"
        Me.RDBPRGDTLS.Size = New System.Drawing.Size(210, 18)
        Me.RDBPRGDTLS.TabIndex = 0
        Me.RDBPRGDTLS.TabStop = True
        Me.RDBPRGDTLS.Text = "Program Wise Consumtion Details"
        Me.RDBPRGDTLS.UseVisualStyleBackColor = True
        '
        'cmbprocess
        '
        Me.cmbprocess.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbprocess.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbprocess.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbprocess.FormattingEnabled = True
        Me.cmbprocess.Location = New System.Drawing.Point(445, 12)
        Me.cmbprocess.MaxDropDownItems = 14
        Me.cmbprocess.Name = "cmbprocess"
        Me.cmbprocess.Size = New System.Drawing.Size(213, 22)
        Me.cmbprocess.TabIndex = 460
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(395, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 14)
        Me.Label8.TabIndex = 461
        Me.Label8.Text = "Process"
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(445, 40)
        Me.CMBITEMNAME.MaxDropDownItems = 14
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(213, 22)
        Me.CMBITEMNAME.TabIndex = 458
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(376, 44)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 14)
        Me.Label9.TabIndex = 459
        Me.Label9.Text = "Item Name"
        '
        'LBLCOLOR
        '
        Me.LBLCOLOR.AutoSize = True
        Me.LBLCOLOR.BackColor = System.Drawing.Color.Transparent
        Me.LBLCOLOR.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLCOLOR.ForeColor = System.Drawing.Color.Black
        Me.LBLCOLOR.Location = New System.Drawing.Point(85, 71)
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
        Me.CMBCOLOR.Location = New System.Drawing.Point(122, 67)
        Me.CMBCOLOR.MaxDropDownItems = 14
        Me.CMBCOLOR.Name = "CMBCOLOR"
        Me.CMBCOLOR.Size = New System.Drawing.Size(213, 22)
        Me.CMBCOLOR.TabIndex = 456
        '
        'CMBDYEING
        '
        Me.CMBDYEING.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBDYEING.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBDYEING.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBDYEING.FormattingEnabled = True
        Me.CMBDYEING.Location = New System.Drawing.Point(122, 40)
        Me.CMBDYEING.MaxDropDownItems = 14
        Me.CMBDYEING.Name = "CMBDYEING"
        Me.CMBDYEING.Size = New System.Drawing.Size(213, 22)
        Me.CMBDYEING.TabIndex = 449
        '
        'LBLPER
        '
        Me.LBLPER.AutoSize = True
        Me.LBLPER.BackColor = System.Drawing.Color.Transparent
        Me.LBLPER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPER.ForeColor = System.Drawing.Color.Black
        Me.LBLPER.Location = New System.Drawing.Point(64, 44)
        Me.LBLPER.Name = "LBLPER"
        Me.LBLPER.Size = New System.Drawing.Size(56, 14)
        Me.LBLPER.TabIndex = 450
        Me.LBLPER.Text = "Chart No."
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Checked = True
        Me.chkdate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(96, 251)
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
        Me.GroupBox1.Location = New System.Drawing.Point(88, 255)
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
        'CMBPROG
        '
        Me.CMBPROG.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPROG.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPROG.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPROG.FormattingEnabled = True
        Me.CMBPROG.Location = New System.Drawing.Point(122, 12)
        Me.CMBPROG.MaxDropDownItems = 14
        Me.CMBPROG.Name = "CMBPROG"
        Me.CMBPROG.Size = New System.Drawing.Size(213, 22)
        Me.CMBPROG.TabIndex = 1
        '
        'LBLITEM
        '
        Me.LBLITEM.AutoSize = True
        Me.LBLITEM.BackColor = System.Drawing.Color.Transparent
        Me.LBLITEM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLITEM.ForeColor = System.Drawing.Color.Black
        Me.LBLITEM.Location = New System.Drawing.Point(48, 16)
        Me.LBLITEM.Name = "LBLITEM"
        Me.LBLITEM.Size = New System.Drawing.Size(72, 14)
        Me.LBLITEM.TabIndex = 419
        Me.LBLITEM.Text = "Program No."
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.Black
        Me.cmdshow.Location = New System.Drawing.Point(379, 274)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(86, 28)
        Me.cmdshow.TabIndex = 7
        Me.cmdshow.Text = "&Show Details"
        Me.cmdshow.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(471, 275)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'TXTCOST
        '
        Me.TXTCOST.Location = New System.Drawing.Point(445, 96)
        Me.TXTCOST.Name = "TXTCOST"
        Me.TXTCOST.Size = New System.Drawing.Size(100, 23)
        Me.TXTCOST.TabIndex = 465
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(404, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 14)
        Me.Label3.TabIndex = 466
        Me.Label3.Text = "Cost >"
        '
        'DyeingConsumption
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(711, 344)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DyeingConsumption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dyeing Consumption / Cost Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel2 As VbPowerPack.BlendPanel
    Friend WithEvents LBLCOLOR As System.Windows.Forms.Label
    Friend WithEvents CMBCOLOR As System.Windows.Forms.ComboBox
    Friend WithEvents CMBDYEING As System.Windows.Forms.ComboBox
    Friend WithEvents LBLPER As System.Windows.Forms.Label
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CMBPROG As System.Windows.Forms.ComboBox
    Friend WithEvents LBLITEM As System.Windows.Forms.Label
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CMBITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbprocess As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RDBPROCESSDTLS As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPRGDTLS As System.Windows.Forms.RadioButton
    Friend WithEvents RBPROGRAMCOST As System.Windows.Forms.RadioButton
    Friend WithEvents RBPROGRAMCOSTSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBMERCHANTCOSTSUMM As System.Windows.Forms.RadioButton
    Friend WithEvents RBMERCHANTCOSTDTLS As System.Windows.Forms.RadioButton
    Friend WithEvents CMBMERCHANT As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TXTCOST As TextBox
End Class
