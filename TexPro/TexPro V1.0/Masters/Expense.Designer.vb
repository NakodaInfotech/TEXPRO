<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Expense
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtremarks = New System.Windows.Forms.TextBox
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.TXTSEARCHQUALITY = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXTSEARCHEXPNAME = New System.Windows.Forms.TextBox
        Me.LBLEXP = New System.Windows.Forms.Label
        Me.cmbQuality = New System.Windows.Forms.ComboBox
        Me.CMDCLEAR = New System.Windows.Forms.Button
        Me.cmbexpensename = New System.Windows.Forms.ComboBox
        Me.cmbProcess = New System.Windows.Forms.ComboBox
        Me.txtrate = New System.Windows.Forms.TextBox
        Me.lblmaterial = New System.Windows.Forms.Label
        Me.GRIDRATE = New System.Windows.Forms.DataGridView
        Me.gname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GQuality = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lbl = New System.Windows.Forms.Label
        Me.cmdok = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDRATE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(6, 17)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(321, 59)
        Me.txtremarks.TabIndex = 0
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTSEARCHQUALITY)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTSEARCHEXPNAME)
        Me.BlendPanel1.Controls.Add(Me.LBLEXP)
        Me.BlendPanel1.Controls.Add(Me.cmbQuality)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.cmbexpensename)
        Me.BlendPanel1.Controls.Add(Me.cmbProcess)
        Me.BlendPanel1.Controls.Add(Me.txtrate)
        Me.BlendPanel1.Controls.Add(Me.lblmaterial)
        Me.BlendPanel1.Controls.Add(Me.GRIDRATE)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(579, 562)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTSEARCHQUALITY
        '
        Me.TXTSEARCHQUALITY.BackColor = System.Drawing.Color.White
        Me.TXTSEARCHQUALITY.ForeColor = System.Drawing.Color.DimGray
        Me.TXTSEARCHQUALITY.Location = New System.Drawing.Point(412, 34)
        Me.TXTSEARCHQUALITY.Name = "TXTSEARCHQUALITY"
        Me.TXTSEARCHQUALITY.Size = New System.Drawing.Size(122, 23)
        Me.TXTSEARCHQUALITY.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(362, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 764
        Me.Label1.Text = "Quality"
        '
        'TXTSEARCHEXPNAME
        '
        Me.TXTSEARCHEXPNAME.BackColor = System.Drawing.Color.White
        Me.TXTSEARCHEXPNAME.ForeColor = System.Drawing.Color.DimGray
        Me.TXTSEARCHEXPNAME.Location = New System.Drawing.Point(412, 7)
        Me.TXTSEARCHEXPNAME.Name = "TXTSEARCHEXPNAME"
        Me.TXTSEARCHEXPNAME.Size = New System.Drawing.Size(122, 23)
        Me.TXTSEARCHEXPNAME.TabIndex = 1
        '
        'LBLEXP
        '
        Me.LBLEXP.AutoSize = True
        Me.LBLEXP.BackColor = System.Drawing.Color.Transparent
        Me.LBLEXP.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLEXP.ForeColor = System.Drawing.Color.Black
        Me.LBLEXP.Location = New System.Drawing.Point(325, 11)
        Me.LBLEXP.Name = "LBLEXP"
        Me.LBLEXP.Size = New System.Drawing.Size(85, 15)
        Me.LBLEXP.TabIndex = 762
        Me.LBLEXP.Text = "Expense Name"
        '
        'cmbQuality
        '
        Me.cmbQuality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbQuality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbQuality.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbQuality.FormattingEnabled = True
        Me.cmbQuality.Location = New System.Drawing.Point(214, 62)
        Me.cmbQuality.MaxDropDownItems = 14
        Me.cmbQuality.Name = "cmbQuality"
        Me.cmbQuality.Size = New System.Drawing.Size(220, 22)
        Me.cmbQuality.TabIndex = 4
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.BackColor = System.Drawing.Color.Transparent
        Me.CMDCLEAR.FlatAppearance.BorderSize = 0
        Me.CMDCLEAR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDCLEAR.Location = New System.Drawing.Point(438, 490)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(72, 26)
        Me.CMDCLEAR.TabIndex = 9
        Me.CMDCLEAR.Text = "Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = False
        '
        'cmbexpensename
        '
        Me.cmbexpensename.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbexpensename.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbexpensename.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbexpensename.FormattingEnabled = True
        Me.cmbexpensename.Location = New System.Drawing.Point(14, 62)
        Me.cmbexpensename.MaxDropDownItems = 14
        Me.cmbexpensename.Name = "cmbexpensename"
        Me.cmbexpensename.Size = New System.Drawing.Size(200, 22)
        Me.cmbexpensename.TabIndex = 3
        '
        'cmbProcess
        '
        Me.cmbProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProcess.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProcess.FormattingEnabled = True
        Me.cmbProcess.Location = New System.Drawing.Point(101, 35)
        Me.cmbProcess.MaxDropDownItems = 14
        Me.cmbProcess.Name = "cmbProcess"
        Me.cmbProcess.Size = New System.Drawing.Size(193, 22)
        Me.cmbProcess.TabIndex = 0
        '
        'txtrate
        '
        Me.txtrate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrate.Location = New System.Drawing.Point(434, 62)
        Me.txtrate.Name = "txtrate"
        Me.txtrate.Size = New System.Drawing.Size(100, 22)
        Me.txtrate.TabIndex = 5
        Me.txtrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblmaterial
        '
        Me.lblmaterial.AutoSize = True
        Me.lblmaterial.BackColor = System.Drawing.Color.Transparent
        Me.lblmaterial.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmaterial.Location = New System.Drawing.Point(23, 39)
        Me.lblmaterial.Name = "lblmaterial"
        Me.lblmaterial.Size = New System.Drawing.Size(75, 14)
        Me.lblmaterial.TabIndex = 347
        Me.lblmaterial.Text = "Process Type"
        '
        'GRIDRATE
        '
        Me.GRIDRATE.AllowUserToAddRows = False
        Me.GRIDRATE.AllowUserToDeleteRows = False
        Me.GRIDRATE.AllowUserToResizeColumns = False
        Me.GRIDRATE.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDRATE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDRATE.BackgroundColor = System.Drawing.Color.White
        Me.GRIDRATE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDRATE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDRATE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDRATE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDRATE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gname, Me.GQuality, Me.grate})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDRATE.DefaultCellStyle = DataGridViewCellStyle5
        Me.GRIDRATE.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDRATE.Location = New System.Drawing.Point(14, 84)
        Me.GRIDRATE.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDRATE.MultiSelect = False
        Me.GRIDRATE.Name = "GRIDRATE"
        Me.GRIDRATE.RowHeadersVisible = False
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDRATE.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDRATE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDRATE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDRATE.Size = New System.Drawing.Size(550, 381)
        Me.GRIDRATE.TabIndex = 6
        '
        'gname
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.gname.DefaultCellStyle = DataGridViewCellStyle3
        Me.gname.HeaderText = "Expense Name"
        Me.gname.Name = "gname"
        Me.gname.ReadOnly = True
        Me.gname.Width = 200
        '
        'GQuality
        '
        Me.GQuality.HeaderText = "Quality"
        Me.GQuality.Name = "GQuality"
        Me.GQuality.ReadOnly = True
        Me.GQuality.Width = 220
        '
        'grate
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.grate.DefaultCellStyle = DataGridViewCellStyle4
        Me.grate.HeaderText = "Rate"
        Me.grate.Name = "grate"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(21, 470)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(333, 80)
        Me.GroupBox5.TabIndex = 7
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 7)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(115, 19)
        Me.lbl.TabIndex = 312
        Me.lbl.Text = "Expense Rate"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(360, 490)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(72, 26)
        Me.cmdok.TabIndex = 8
        Me.cmdok.Text = "Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(395, 520)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 26)
        Me.cmdexit.TabIndex = 10
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'Expense
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(579, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "Expense"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Expense Rate"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDRATE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmbProcess As System.Windows.Forms.ComboBox
    Friend WithEvents lblmaterial As System.Windows.Forms.Label
    Friend WithEvents cmbexpensename As System.Windows.Forms.ComboBox
    Friend WithEvents txtrate As System.Windows.Forms.TextBox
    Friend WithEvents GRIDRATE As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmbQuality As System.Windows.Forms.ComboBox
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents gname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GQuality As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TXTSEARCHQUALITY As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTSEARCHEXPNAME As System.Windows.Forms.TextBox
    Friend WithEvents LBLEXP As System.Windows.Forms.Label
End Class
