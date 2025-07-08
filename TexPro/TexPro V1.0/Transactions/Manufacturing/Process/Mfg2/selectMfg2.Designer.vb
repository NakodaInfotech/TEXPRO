<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class selectMfg2
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
        Me.CHKLOTNO = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CLB_LOTNO = New System.Windows.Forms.CheckedListBox()
        Me.chkall = New System.Windows.Forms.CheckBox()
        Me.cmbselect = New System.Windows.Forms.ComboBox()
        Me.txttempname = New System.Windows.Forms.TextBox()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.CMDCLEARSEARCH = New System.Windows.Forms.Button()
        Me.CMDSEARCH = New System.Windows.Forms.Button()
        Me.chkmerchant = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CLB_ITEMNAME = New System.Windows.Forms.CheckedListBox()
        Me.chkjobno = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CLB_JOBNO = New System.Windows.Forms.CheckedListBox()
        Me.chkdesignno = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CLB_designno = New System.Windows.Forms.CheckedListBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.gridmfg = New System.Windows.Forms.DataGridView()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridmfg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKLOTNO)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.CLB_LOTNO)
        Me.BlendPanel1.Controls.Add(Me.chkall)
        Me.BlendPanel1.Controls.Add(Me.cmbselect)
        Me.BlendPanel1.Controls.Add(Me.txttempname)
        Me.BlendPanel1.Controls.Add(Me.txtsearch)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEARSEARCH)
        Me.BlendPanel1.Controls.Add(Me.CMDSEARCH)
        Me.BlendPanel1.Controls.Add(Me.chkmerchant)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CLB_ITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.chkjobno)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.CLB_JOBNO)
        Me.BlendPanel1.Controls.Add(Me.chkdesignno)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.CLB_designno)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.gridmfg)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(845, 618)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKLOTNO
        '
        Me.CHKLOTNO.AutoSize = True
        Me.CHKLOTNO.BackColor = System.Drawing.Color.Transparent
        Me.CHKLOTNO.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKLOTNO.Location = New System.Drawing.Point(215, 68)
        Me.CHKLOTNO.Name = "CHKLOTNO"
        Me.CHKLOTNO.Size = New System.Drawing.Size(69, 17)
        Me.CHKLOTNO.TabIndex = 520
        Me.CHKLOTNO.TabStop = False
        Me.CHKLOTNO.Text = "Select All"
        Me.CHKLOTNO.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(212, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 14)
        Me.Label4.TabIndex = 522
        Me.Label4.Text = "Lot No"
        '
        'CLB_LOTNO
        '
        Me.CLB_LOTNO.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_LOTNO.FormattingEnabled = True
        Me.CLB_LOTNO.Location = New System.Drawing.Point(212, 88)
        Me.CLB_LOTNO.Name = "CLB_LOTNO"
        Me.CLB_LOTNO.ScrollAlwaysVisible = True
        Me.CLB_LOTNO.Size = New System.Drawing.Size(90, 72)
        Me.CLB_LOTNO.TabIndex = 521
        Me.CLB_LOTNO.TabStop = False
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.BackColor = System.Drawing.Color.Transparent
        Me.chkall.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkall.Location = New System.Drawing.Point(23, 168)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(72, 18)
        Me.chkall.TabIndex = 10
        Me.chkall.Text = "Select All"
        Me.chkall.UseVisualStyleBackColor = False
        '
        'cmbselect
        '
        Me.cmbselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbselect.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbselect.FormattingEnabled = True
        Me.cmbselect.Items.AddRange(New Object() {"Design No", "Job No", "Merchant", "Lot No"})
        Me.cmbselect.Location = New System.Drawing.Point(56, 12)
        Me.cmbselect.Name = "cmbselect"
        Me.cmbselect.Size = New System.Drawing.Size(105, 21)
        Me.cmbselect.TabIndex = 0
        '
        'txttempname
        '
        Me.txttempname.BackColor = System.Drawing.Color.White
        Me.txttempname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempname.ForeColor = System.Drawing.Color.Black
        Me.txttempname.Location = New System.Drawing.Point(349, 12)
        Me.txttempname.Name = "txttempname"
        Me.txttempname.ReadOnly = True
        Me.txttempname.Size = New System.Drawing.Size(137, 20)
        Me.txttempname.TabIndex = 2
        Me.txttempname.TabStop = False
        Me.txttempname.Visible = False
        '
        'txtsearch
        '
        Me.txtsearch.BackColor = System.Drawing.Color.White
        Me.txtsearch.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.ForeColor = System.Drawing.Color.Black
        Me.txtsearch.Location = New System.Drawing.Point(161, 12)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(188, 21)
        Me.txtsearch.TabIndex = 1
        '
        'CMDCLEARSEARCH
        '
        Me.CMDCLEARSEARCH.BackColor = System.Drawing.Color.Transparent
        Me.CMDCLEARSEARCH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDCLEARSEARCH.FlatAppearance.BorderSize = 0
        Me.CMDCLEARSEARCH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEARSEARCH.ForeColor = System.Drawing.Color.Black
        Me.CMDCLEARSEARCH.Location = New System.Drawing.Point(434, 124)
        Me.CMDCLEARSEARCH.Name = "CMDCLEARSEARCH"
        Me.CMDCLEARSEARCH.Size = New System.Drawing.Size(87, 29)
        Me.CMDCLEARSEARCH.TabIndex = 11
        Me.CMDCLEARSEARCH.TabStop = False
        Me.CMDCLEARSEARCH.Text = "&Clear Search"
        Me.CMDCLEARSEARCH.UseVisualStyleBackColor = False
        '
        'CMDSEARCH
        '
        Me.CMDSEARCH.BackColor = System.Drawing.Color.Transparent
        Me.CMDSEARCH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSEARCH.FlatAppearance.BorderSize = 0
        Me.CMDSEARCH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSEARCH.ForeColor = System.Drawing.Color.Black
        Me.CMDSEARCH.Location = New System.Drawing.Point(434, 89)
        Me.CMDSEARCH.Name = "CMDSEARCH"
        Me.CMDSEARCH.Size = New System.Drawing.Size(87, 29)
        Me.CMDSEARCH.TabIndex = 9
        Me.CMDSEARCH.Text = "&Search"
        Me.CMDSEARCH.UseVisualStyleBackColor = False
        '
        'chkmerchant
        '
        Me.chkmerchant.AutoSize = True
        Me.chkmerchant.BackColor = System.Drawing.Color.Transparent
        Me.chkmerchant.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkmerchant.Location = New System.Drawing.Point(311, 68)
        Me.chkmerchant.Name = "chkmerchant"
        Me.chkmerchant.Size = New System.Drawing.Size(69, 17)
        Me.chkmerchant.TabIndex = 5
        Me.chkmerchant.TabStop = False
        Me.chkmerchant.Text = "Select All"
        Me.chkmerchant.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(308, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 14)
        Me.Label2.TabIndex = 519
        Me.Label2.Text = "Merchant"
        '
        'CLB_ITEMNAME
        '
        Me.CLB_ITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_ITEMNAME.FormattingEnabled = True
        Me.CLB_ITEMNAME.Location = New System.Drawing.Point(308, 88)
        Me.CLB_ITEMNAME.Name = "CLB_ITEMNAME"
        Me.CLB_ITEMNAME.ScrollAlwaysVisible = True
        Me.CLB_ITEMNAME.Size = New System.Drawing.Size(120, 72)
        Me.CLB_ITEMNAME.TabIndex = 8
        Me.CLB_ITEMNAME.TabStop = False
        '
        'chkjobno
        '
        Me.chkjobno.AutoSize = True
        Me.chkjobno.BackColor = System.Drawing.Color.Transparent
        Me.chkjobno.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkjobno.Location = New System.Drawing.Point(119, 68)
        Me.chkjobno.Name = "chkjobno"
        Me.chkjobno.Size = New System.Drawing.Size(69, 17)
        Me.chkjobno.TabIndex = 4
        Me.chkjobno.TabStop = False
        Me.chkjobno.Text = "Select All"
        Me.chkjobno.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(116, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 516
        Me.Label1.Text = "Job No"
        '
        'CLB_JOBNO
        '
        Me.CLB_JOBNO.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_JOBNO.FormattingEnabled = True
        Me.CLB_JOBNO.Location = New System.Drawing.Point(116, 88)
        Me.CLB_JOBNO.Name = "CLB_JOBNO"
        Me.CLB_JOBNO.ScrollAlwaysVisible = True
        Me.CLB_JOBNO.Size = New System.Drawing.Size(90, 72)
        Me.CLB_JOBNO.TabIndex = 7
        Me.CLB_JOBNO.TabStop = False
        '
        'chkdesignno
        '
        Me.chkdesignno.AutoSize = True
        Me.chkdesignno.BackColor = System.Drawing.Color.Transparent
        Me.chkdesignno.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdesignno.Location = New System.Drawing.Point(23, 68)
        Me.chkdesignno.Name = "chkdesignno"
        Me.chkdesignno.Size = New System.Drawing.Size(69, 17)
        Me.chkdesignno.TabIndex = 3
        Me.chkdesignno.TabStop = False
        Me.chkdesignno.Text = "Select All"
        Me.chkdesignno.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(20, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 14)
        Me.Label3.TabIndex = 510
        Me.Label3.Text = "Design No"
        '
        'CLB_designno
        '
        Me.CLB_designno.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_designno.FormattingEnabled = True
        Me.CLB_designno.Location = New System.Drawing.Point(20, 88)
        Me.CLB_designno.Name = "CLB_designno"
        Me.CLB_designno.ScrollAlwaysVisible = True
        Me.CLB_designno.Size = New System.Drawing.Size(90, 72)
        Me.CLB_designno.TabIndex = 6
        Me.CLB_designno.TabStop = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(425, 578)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(81, 29)
        Me.cmdexit.TabIndex = 14
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(338, 578)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(81, 29)
        Me.cmdok.TabIndex = 13
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'gridmfg
        '
        Me.gridmfg.AllowUserToAddRows = False
        Me.gridmfg.AllowUserToDeleteRows = False
        Me.gridmfg.AllowUserToResizeColumns = False
        Me.gridmfg.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.gridmfg.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridmfg.BackgroundColor = System.Drawing.Color.White
        Me.gridmfg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridmfg.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridmfg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridmfg.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridmfg.GridColor = System.Drawing.SystemColors.Control
        Me.gridmfg.Location = New System.Drawing.Point(20, 191)
        Me.gridmfg.Margin = New System.Windows.Forms.Padding(2)
        Me.gridmfg.MultiSelect = False
        Me.gridmfg.Name = "gridmfg"
        Me.gridmfg.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridmfg.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.gridmfg.RowHeadersVisible = False
        Me.gridmfg.RowHeadersWidth = 30
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.gridmfg.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridmfg.RowTemplate.Height = 20
        Me.gridmfg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridmfg.Size = New System.Drawing.Size(799, 386)
        Me.gridmfg.TabIndex = 12
        Me.gridmfg.TabStop = False
        '
        'selectMfg2
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(845, 618)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "selectMfg2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Mfg"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridmfg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents gridmfg As System.Windows.Forms.DataGridView
    Friend WithEvents chkdesignno As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CLB_designno As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkjobno As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CLB_JOBNO As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkmerchant As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CLB_ITEMNAME As System.Windows.Forms.CheckedListBox
    Friend WithEvents CMDSEARCH As System.Windows.Forms.Button
    Friend WithEvents CMDCLEARSEARCH As System.Windows.Forms.Button
    Private WithEvents cmbselect As System.Windows.Forms.ComboBox
    Friend WithEvents txttempname As System.Windows.Forms.TextBox
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents CHKLOTNO As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CLB_LOTNO As System.Windows.Forms.CheckedListBox
End Class
