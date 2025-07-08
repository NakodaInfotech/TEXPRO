<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QualityPriceMaster
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmbQuality = New System.Windows.Forms.ComboBox
        Me.txtrate = New System.Windows.Forms.TextBox
        Me.GRIDRATE = New System.Windows.Forms.DataGridView
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.cmdexit = New System.Windows.Forms.Button
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GQuality = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grate = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.GRIDRATE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbQuality
        '
        Me.cmbQuality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbQuality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbQuality.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbQuality.FormattingEnabled = True
        Me.cmbQuality.Location = New System.Drawing.Point(16, 39)
        Me.cmbQuality.MaxDropDownItems = 14
        Me.cmbQuality.Name = "cmbQuality"
        Me.cmbQuality.Size = New System.Drawing.Size(260, 22)
        Me.cmbQuality.TabIndex = 1
        '
        'txtrate
        '
        Me.txtrate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrate.Location = New System.Drawing.Point(276, 39)
        Me.txtrate.Name = "txtrate"
        Me.txtrate.Size = New System.Drawing.Size(100, 22)
        Me.txtrate.TabIndex = 2
        Me.txtrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GRIDRATE
        '
        Me.GRIDRATE.AllowUserToAddRows = False
        Me.GRIDRATE.AllowUserToDeleteRows = False
        Me.GRIDRATE.AllowUserToResizeColumns = False
        Me.GRIDRATE.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDRATE.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.GRIDRATE.BackgroundColor = System.Drawing.Color.White
        Me.GRIDRATE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDRATE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDRATE.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.GRIDRATE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDRATE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GQuality, Me.grate})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDRATE.DefaultCellStyle = DataGridViewCellStyle9
        Me.GRIDRATE.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDRATE.Location = New System.Drawing.Point(14, 62)
        Me.GRIDRATE.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDRATE.MultiSelect = False
        Me.GRIDRATE.Name = "GRIDRATE"
        Me.GRIDRATE.ReadOnly = True
        Me.GRIDRATE.RowHeadersVisible = False
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDRATE.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.GRIDRATE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDRATE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDRATE.Size = New System.Drawing.Size(390, 437)
        Me.GRIDRATE.TabIndex = 2
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmbQuality)
        Me.BlendPanel1.Controls.Add(Me.txtrate)
        Me.BlendPanel1.Controls.Add(Me.GRIDRATE)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(415, 537)
        Me.BlendPanel1.TabIndex = 2
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(171, 504)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 26)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'GQuality
        '
        Me.GQuality.HeaderText = "Quality"
        Me.GQuality.Name = "GQuality"
        Me.GQuality.ReadOnly = True
        Me.GQuality.Width = 260
        '
        'grate
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.grate.DefaultCellStyle = DataGridViewCellStyle8
        Me.grate.HeaderText = "Rate"
        Me.grate.Name = "grate"
        Me.grate.ReadOnly = True
        '
        'QualityPriceMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(415, 537)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "QualityPriceMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Quality Price List"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GRIDRATE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbQuality As System.Windows.Forms.ComboBox
    Friend WithEvents txtrate As System.Windows.Forms.TextBox
    Friend WithEvents GRIDRATE As System.Windows.Forms.DataGridView
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents GQuality As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
