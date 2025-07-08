<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DepartmentRateList
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DepartmentRateList))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbDepartment = New System.Windows.Forms.ComboBox
        Me.GPRATE = New System.Windows.Forms.GroupBox
        Me.chkProcessall = New System.Windows.Forms.CheckBox
        Me.CLB_Process = New System.Windows.Forms.CheckedListBox
        Me.CMBMERCHANT = New System.Windows.Forms.ComboBox
        Me.gridMerchant = New System.Windows.Forms.DataGridView
        Me.gMeRchant = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Grate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtrate = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkchange = New System.Windows.Forms.CheckBox
        Me.cmddelete = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPRATE.SuspendLayout()
        CType(Me.gridMerchant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.PictureBox1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.cmbDepartment)
        Me.BlendPanel1.Controls.Add(Me.GPRATE)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(530, 423)
        Me.BlendPanel1.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.TexPro_V1.My.Resources.Resources.COPY
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(414, 51)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 23)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 651
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 314
        Me.Label2.Text = "Department"
        '
        'cmbDepartment
        '
        Me.cmbDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDepartment.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDepartment.FormattingEnabled = True
        Me.cmbDepartment.Location = New System.Drawing.Point(108, 51)
        Me.cmbDepartment.MaxDropDownItems = 14
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(300, 22)
        Me.cmbDepartment.TabIndex = 313
        '
        'GPRATE
        '
        Me.GPRATE.BackColor = System.Drawing.Color.Transparent
        Me.GPRATE.Controls.Add(Me.chkProcessall)
        Me.GPRATE.Controls.Add(Me.CLB_Process)
        Me.GPRATE.Controls.Add(Me.CMBMERCHANT)
        Me.GPRATE.Controls.Add(Me.gridMerchant)
        Me.GPRATE.Controls.Add(Me.txtrate)
        Me.GPRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPRATE.ForeColor = System.Drawing.Color.Black
        Me.GPRATE.Location = New System.Drawing.Point(16, 79)
        Me.GPRATE.Name = "GPRATE"
        Me.GPRATE.Size = New System.Drawing.Size(495, 303)
        Me.GPRATE.TabIndex = 1
        Me.GPRATE.TabStop = False
        Me.GPRATE.Text = "Details"
        '
        'chkProcessall
        '
        Me.chkProcessall.AutoSize = True
        Me.chkProcessall.BackColor = System.Drawing.Color.Transparent
        Me.chkProcessall.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkProcessall.Location = New System.Drawing.Point(9, 19)
        Me.chkProcessall.Name = "chkProcessall"
        Me.chkProcessall.Size = New System.Drawing.Size(69, 17)
        Me.chkProcessall.TabIndex = 488
        Me.chkProcessall.Text = "Select All"
        Me.chkProcessall.UseVisualStyleBackColor = False
        '
        'CLB_Process
        '
        Me.CLB_Process.CheckOnClick = True
        Me.CLB_Process.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_Process.FormattingEnabled = True
        Me.CLB_Process.Location = New System.Drawing.Point(6, 39)
        Me.CLB_Process.Name = "CLB_Process"
        Me.CLB_Process.ScrollAlwaysVisible = True
        Me.CLB_Process.Size = New System.Drawing.Size(180, 259)
        Me.CLB_Process.TabIndex = 487
        '
        'CMBMERCHANT
        '
        Me.CMBMERCHANT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMERCHANT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMERCHANT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBMERCHANT.FormattingEnabled = True
        Me.CMBMERCHANT.Location = New System.Drawing.Point(191, 18)
        Me.CMBMERCHANT.MaxDropDownItems = 14
        Me.CMBMERCHANT.Name = "CMBMERCHANT"
        Me.CMBMERCHANT.Size = New System.Drawing.Size(200, 22)
        Me.CMBMERCHANT.TabIndex = 315
        '
        'gridMerchant
        '
        Me.gridMerchant.AllowUserToAddRows = False
        Me.gridMerchant.AllowUserToDeleteRows = False
        Me.gridMerchant.AllowUserToResizeColumns = False
        Me.gridMerchant.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.gridMerchant.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridMerchant.BackgroundColor = System.Drawing.Color.White
        Me.gridMerchant.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.gridMerchant.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridMerchant.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridMerchant.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridMerchant.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gMeRchant, Me.Grate})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridMerchant.DefaultCellStyle = DataGridViewCellStyle4
        Me.gridMerchant.GridColor = System.Drawing.SystemColors.ControlText
        Me.gridMerchant.Location = New System.Drawing.Point(191, 39)
        Me.gridMerchant.Margin = New System.Windows.Forms.Padding(2)
        Me.gridMerchant.MultiSelect = False
        Me.gridMerchant.Name = "gridMerchant"
        Me.gridMerchant.RowHeadersVisible = False
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        Me.gridMerchant.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridMerchant.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gridMerchant.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridMerchant.Size = New System.Drawing.Size(298, 259)
        Me.gridMerchant.TabIndex = 4
        Me.gridMerchant.TabStop = False
        '
        'gMeRchant
        '
        Me.gMeRchant.HeaderText = "Merchant"
        Me.gMeRchant.Name = "gMeRchant"
        Me.gMeRchant.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gMeRchant.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.gMeRchant.Width = 200
        '
        'Grate
        '
        DataGridViewCellStyle3.Format = "N2"
        Me.Grate.DefaultCellStyle = DataGridViewCellStyle3
        Me.Grate.HeaderText = "Rate"
        Me.Grate.Name = "Grate"
        Me.Grate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Grate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Grate.Width = 60
        '
        'txtrate
        '
        Me.txtrate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrate.Location = New System.Drawing.Point(391, 19)
        Me.txtrate.Name = "txtrate"
        Me.txtrate.Size = New System.Drawing.Size(60, 22)
        Me.txtrate.TabIndex = 316
        Me.txtrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 19)
        Me.Label1.TabIndex = 312
        Me.Label1.Text = "Department Rate List"
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(350, 12)
        Me.chkchange.Name = "chkchange"
        Me.chkchange.Size = New System.Drawing.Size(15, 14)
        Me.chkchange.TabIndex = 311
        Me.chkchange.UseVisualStyleBackColor = True
        Me.chkchange.Visible = False
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmddelete.Location = New System.Drawing.Point(229, 388)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(72, 24)
        Me.cmddelete.TabIndex = 4
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(152, 388)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(72, 24)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(306, 388)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 24)
        Me.cmdexit.TabIndex = 5
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'DepartmentRateList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 423)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "DepartmentRateList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "DepartmentRateList"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPRATE.ResumeLayout(False)
        Me.GPRATE.PerformLayout()
        CType(Me.gridMerchant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents GPRATE As System.Windows.Forms.GroupBox
    Friend WithEvents gridMerchant As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents CMBMERCHANT As System.Windows.Forms.ComboBox
    Friend WithEvents txtrate As System.Windows.Forms.TextBox
    Friend WithEvents chkProcessall As System.Windows.Forms.CheckBox
    Friend WithEvents CLB_Process As System.Windows.Forms.CheckedListBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents gMeRchant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
