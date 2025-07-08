<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectPs
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CMDSEARCH = New System.Windows.Forms.Button()
        Me.CLB_ITEMNAME = New System.Windows.Forms.CheckedListBox()
        Me.CLB_BALENO = New System.Windows.Forms.CheckedListBox()
        Me.chkall = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmbselect = New System.Windows.Forms.ComboBox()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.gridwo = New System.Windows.Forms.DataGridView()
        Me.txttempname = New System.Windows.Forms.TextBox()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.CLB_LOTNO = New System.Windows.Forms.CheckedListBox()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridwo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CLB_LOTNO)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDSEARCH)
        Me.BlendPanel1.Controls.Add(Me.CLB_ITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.CLB_BALENO)
        Me.BlendPanel1.Controls.Add(Me.chkall)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmbselect)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.gridwo)
        Me.BlendPanel1.Controls.Add(Me.txttempname)
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(992, 566)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.BackColor = System.Drawing.Color.Transparent
        Me.CMDCLEAR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDCLEAR.FlatAppearance.BorderSize = 0
        Me.CMDCLEAR.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDCLEAR.Location = New System.Drawing.Point(757, 42)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(87, 29)
        Me.CMDCLEAR.TabIndex = 527
        Me.CMDCLEAR.TabStop = False
        Me.CMDCLEAR.Text = "&Clear Search"
        Me.CMDCLEAR.UseVisualStyleBackColor = False
        '
        'CMDSEARCH
        '
        Me.CMDSEARCH.BackColor = System.Drawing.Color.Transparent
        Me.CMDSEARCH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSEARCH.FlatAppearance.BorderSize = 0
        Me.CMDSEARCH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSEARCH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDSEARCH.Location = New System.Drawing.Point(757, 12)
        Me.CMDSEARCH.Name = "CMDSEARCH"
        Me.CMDSEARCH.Size = New System.Drawing.Size(87, 29)
        Me.CMDSEARCH.TabIndex = 526
        Me.CMDSEARCH.Text = "&Search"
        Me.CMDSEARCH.UseVisualStyleBackColor = False
        '
        'CLB_ITEMNAME
        '
        Me.CLB_ITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_ITEMNAME.FormattingEnabled = True
        Me.CLB_ITEMNAME.Location = New System.Drawing.Point(503, 9)
        Me.CLB_ITEMNAME.Name = "CLB_ITEMNAME"
        Me.CLB_ITEMNAME.ScrollAlwaysVisible = True
        Me.CLB_ITEMNAME.Size = New System.Drawing.Size(120, 72)
        Me.CLB_ITEMNAME.TabIndex = 525
        Me.CLB_ITEMNAME.TabStop = False
        '
        'CLB_BALENO
        '
        Me.CLB_BALENO.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_BALENO.FormattingEnabled = True
        Me.CLB_BALENO.Location = New System.Drawing.Point(407, 9)
        Me.CLB_BALENO.Name = "CLB_BALENO"
        Me.CLB_BALENO.ScrollAlwaysVisible = True
        Me.CLB_BALENO.Size = New System.Drawing.Size(90, 72)
        Me.CLB_BALENO.TabIndex = 524
        Me.CLB_BALENO.TabStop = False
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.BackColor = System.Drawing.Color.Transparent
        Me.chkall.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkall.Location = New System.Drawing.Point(321, 64)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(72, 18)
        Me.chkall.TabIndex = 3
        Me.chkall.Text = "Select All"
        Me.chkall.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(209, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 14)
        Me.Label1.TabIndex = 256
        Me.Label1.Text = "To"
        Me.Label1.Visible = False
        '
        'TXTTO
        '
        Me.TXTTO.BackColor = System.Drawing.Color.White
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.ForeColor = System.Drawing.Color.Black
        Me.TXTTO.Location = New System.Drawing.Point(231, 64)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(84, 21)
        Me.TXTTO.TabIndex = 2
        Me.TXTTO.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(499, 533)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 6
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmbselect
        '
        Me.cmbselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbselect.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbselect.FormattingEnabled = True
        Me.cmbselect.Items.AddRange(New Object() {"", "Bale No", "Lot No", "Merchant Name"})
        Me.cmbselect.Location = New System.Drawing.Point(25, 65)
        Me.cmbselect.Name = "cmbselect"
        Me.cmbselect.Size = New System.Drawing.Size(72, 21)
        Me.cmbselect.TabIndex = 0
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(413, 533)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 5
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'gridwo
        '
        Me.gridwo.AllowUserToAddRows = False
        Me.gridwo.AllowUserToDeleteRows = False
        Me.gridwo.AllowUserToResizeColumns = False
        Me.gridwo.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.gridwo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridwo.BackgroundColor = System.Drawing.Color.White
        Me.gridwo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridwo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridwo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridwo.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridwo.GridColor = System.Drawing.SystemColors.Control
        Me.gridwo.Location = New System.Drawing.Point(25, 86)
        Me.gridwo.Margin = New System.Windows.Forms.Padding(2)
        Me.gridwo.MultiSelect = False
        Me.gridwo.Name = "gridwo"
        Me.gridwo.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridwo.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.gridwo.RowHeadersVisible = False
        Me.gridwo.RowHeadersWidth = 30
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.gridwo.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridwo.RowTemplate.Height = 20
        Me.gridwo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridwo.Size = New System.Drawing.Size(950, 442)
        Me.gridwo.TabIndex = 4
        '
        'txttempname
        '
        Me.txttempname.BackColor = System.Drawing.Color.White
        Me.txttempname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempname.ForeColor = System.Drawing.Color.Black
        Me.txttempname.Location = New System.Drawing.Point(25, 39)
        Me.txttempname.Name = "txttempname"
        Me.txttempname.ReadOnly = True
        Me.txttempname.Size = New System.Drawing.Size(137, 20)
        Me.txttempname.TabIndex = 254
        Me.txttempname.TabStop = False
        Me.txttempname.Visible = False
        '
        'TXTFROM
        '
        Me.TXTFROM.BackColor = System.Drawing.Color.White
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.ForeColor = System.Drawing.Color.Black
        Me.TXTFROM.Location = New System.Drawing.Point(97, 65)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(110, 21)
        Me.TXTFROM.TabIndex = 1
        '
        'CLB_LOTNO
        '
        Me.CLB_LOTNO.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_LOTNO.FormattingEnabled = True
        Me.CLB_LOTNO.Location = New System.Drawing.Point(629, 9)
        Me.CLB_LOTNO.Name = "CLB_LOTNO"
        Me.CLB_LOTNO.ScrollAlwaysVisible = True
        Me.CLB_LOTNO.Size = New System.Drawing.Size(120, 72)
        Me.CLB_LOTNO.TabIndex = 528
        Me.CLB_LOTNO.TabStop = False
        '
        'SelectPs
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(992, 566)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectPs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "SelectPs"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridwo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Private WithEvents cmbselect As System.Windows.Forms.ComboBox
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents gridwo As System.Windows.Forms.DataGridView
    Friend WithEvents txttempname As System.Windows.Forms.TextBox
    Friend WithEvents TXTFROM As System.Windows.Forms.TextBox
    Friend WithEvents TXTTO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents CLB_BALENO As System.Windows.Forms.CheckedListBox
    Friend WithEvents CLB_ITEMNAME As System.Windows.Forms.CheckedListBox
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents CMDSEARCH As System.Windows.Forms.Button
    Friend WithEvents CLB_LOTNO As CheckedListBox
End Class
