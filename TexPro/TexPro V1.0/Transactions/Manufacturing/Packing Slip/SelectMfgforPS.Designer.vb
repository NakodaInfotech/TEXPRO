<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectMfgforPS
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
        Me.chkpiecetype = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.clb_piecetype = New System.Windows.Forms.CheckedListBox()
        Me.chkall = New System.Windows.Forms.CheckBox()
        Me.cmbselect = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.txttempname = New System.Windows.Forms.TextBox()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridmfg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.chkpiecetype)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.clb_piecetype)
        Me.BlendPanel1.Controls.Add(Me.chkall)
        Me.BlendPanel1.Controls.Add(Me.cmbselect)
        Me.BlendPanel1.Controls.Add(Me.TextBox1)
        Me.BlendPanel1.Controls.Add(Me.txtsearch)
        Me.BlendPanel1.Controls.Add(Me.Button2)
        Me.BlendPanel1.Controls.Add(Me.Button1)
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
        Me.BlendPanel1.Controls.Add(Me.txttempname)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(874, 618)
        Me.BlendPanel1.TabIndex = 0
        '
        'chkpiecetype
        '
        Me.chkpiecetype.AutoSize = True
        Me.chkpiecetype.BackColor = System.Drawing.Color.Transparent
        Me.chkpiecetype.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkpiecetype.Location = New System.Drawing.Point(23, 59)
        Me.chkpiecetype.Name = "chkpiecetype"
        Me.chkpiecetype.Size = New System.Drawing.Size(69, 17)
        Me.chkpiecetype.TabIndex = 535
        Me.chkpiecetype.TabStop = False
        Me.chkpiecetype.Text = "Select All"
        Me.chkpiecetype.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(20, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 14)
        Me.Label4.TabIndex = 537
        Me.Label4.Text = "Piece Type"
        '
        'clb_piecetype
        '
        Me.clb_piecetype.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.clb_piecetype.FormattingEnabled = True
        Me.clb_piecetype.Location = New System.Drawing.Point(20, 79)
        Me.clb_piecetype.Name = "clb_piecetype"
        Me.clb_piecetype.ScrollAlwaysVisible = True
        Me.clb_piecetype.Size = New System.Drawing.Size(97, 72)
        Me.clb_piecetype.TabIndex = 536
        Me.clb_piecetype.TabStop = False
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.BackColor = System.Drawing.Color.Transparent
        Me.chkall.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.chkall.Location = New System.Drawing.Point(23, 158)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(72, 18)
        Me.chkall.TabIndex = 530
        Me.chkall.Text = "Select All"
        Me.chkall.UseVisualStyleBackColor = False
        '
        'cmbselect
        '
        Me.cmbselect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbselect.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbselect.FormattingEnabled = True
        Me.cmbselect.Items.AddRange(New Object() {"Lot No", "Piece Type", "Job No", "Design No", "Merchant"})
        Me.cmbselect.Location = New System.Drawing.Point(56, 12)
        Me.cmbselect.Name = "cmbselect"
        Me.cmbselect.Size = New System.Drawing.Size(105, 21)
        Me.cmbselect.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(349, 12)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(137, 20)
        Me.TextBox1.TabIndex = 522
        Me.TextBox1.TabStop = False
        Me.TextBox1.Visible = False
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
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(454, 118)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 29)
        Me.Button2.TabIndex = 531
        Me.Button2.TabStop = False
        Me.Button2.Text = "&Clear Search"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(454, 88)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 29)
        Me.Button1.TabIndex = 529
        Me.Button1.Text = "&Search"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'chkmerchant
        '
        Me.chkmerchant.AutoSize = True
        Me.chkmerchant.BackColor = System.Drawing.Color.Transparent
        Me.chkmerchant.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkmerchant.Location = New System.Drawing.Point(318, 59)
        Me.chkmerchant.Name = "chkmerchant"
        Me.chkmerchant.Size = New System.Drawing.Size(69, 17)
        Me.chkmerchant.TabIndex = 525
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
        Me.Label2.Location = New System.Drawing.Point(315, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 14)
        Me.Label2.TabIndex = 534
        Me.Label2.Text = "Merchant"
        '
        'CLB_ITEMNAME
        '
        Me.CLB_ITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_ITEMNAME.FormattingEnabled = True
        Me.CLB_ITEMNAME.Location = New System.Drawing.Point(315, 79)
        Me.CLB_ITEMNAME.Name = "CLB_ITEMNAME"
        Me.CLB_ITEMNAME.ScrollAlwaysVisible = True
        Me.CLB_ITEMNAME.Size = New System.Drawing.Size(120, 72)
        Me.CLB_ITEMNAME.TabIndex = 528
        Me.CLB_ITEMNAME.TabStop = False
        '
        'chkjobno
        '
        Me.chkjobno.AutoSize = True
        Me.chkjobno.BackColor = System.Drawing.Color.Transparent
        Me.chkjobno.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkjobno.Location = New System.Drawing.Point(126, 59)
        Me.chkjobno.Name = "chkjobno"
        Me.chkjobno.Size = New System.Drawing.Size(69, 17)
        Me.chkjobno.TabIndex = 524
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
        Me.Label1.Location = New System.Drawing.Point(123, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 533
        Me.Label1.Text = "Job No"
        '
        'CLB_JOBNO
        '
        Me.CLB_JOBNO.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_JOBNO.FormattingEnabled = True
        Me.CLB_JOBNO.Location = New System.Drawing.Point(123, 79)
        Me.CLB_JOBNO.Name = "CLB_JOBNO"
        Me.CLB_JOBNO.ScrollAlwaysVisible = True
        Me.CLB_JOBNO.Size = New System.Drawing.Size(90, 72)
        Me.CLB_JOBNO.TabIndex = 527
        Me.CLB_JOBNO.TabStop = False
        '
        'chkdesignno
        '
        Me.chkdesignno.AutoSize = True
        Me.chkdesignno.BackColor = System.Drawing.Color.Transparent
        Me.chkdesignno.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdesignno.Location = New System.Drawing.Point(220, 58)
        Me.chkdesignno.Name = "chkdesignno"
        Me.chkdesignno.Size = New System.Drawing.Size(69, 17)
        Me.chkdesignno.TabIndex = 523
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
        Me.Label3.Location = New System.Drawing.Point(217, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 14)
        Me.Label3.TabIndex = 532
        Me.Label3.Text = "Design No"
        '
        'CLB_designno
        '
        Me.CLB_designno.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_designno.FormattingEnabled = True
        Me.CLB_designno.Location = New System.Drawing.Point(217, 78)
        Me.CLB_designno.Name = "CLB_designno"
        Me.CLB_designno.ScrollAlwaysVisible = True
        Me.CLB_designno.Size = New System.Drawing.Size(90, 72)
        Me.CLB_designno.TabIndex = 526
        Me.CLB_designno.TabStop = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(448, 578)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(84, 29)
        Me.cmdexit.TabIndex = 6
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
        Me.cmdok.Location = New System.Drawing.Point(363, 578)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(84, 29)
        Me.cmdok.TabIndex = 3
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridmfg.DefaultCellStyle = DataGridViewCellStyle3
        Me.gridmfg.GridColor = System.Drawing.SystemColors.Control
        Me.gridmfg.Location = New System.Drawing.Point(21, 181)
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
        Me.gridmfg.Size = New System.Drawing.Size(832, 396)
        Me.gridmfg.TabIndex = 2
        '
        'txttempname
        '
        Me.txttempname.BackColor = System.Drawing.Color.White
        Me.txttempname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempname.ForeColor = System.Drawing.Color.Black
        Me.txttempname.Location = New System.Drawing.Point(561, 33)
        Me.txttempname.Name = "txttempname"
        Me.txttempname.ReadOnly = True
        Me.txttempname.Size = New System.Drawing.Size(137, 20)
        Me.txttempname.TabIndex = 3
        Me.txttempname.TabStop = False
        Me.txttempname.Visible = False
        '
        'SelectMfgforPS
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(874, 618)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectMfgforPS"
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
    Friend WithEvents txttempname As System.Windows.Forms.TextBox
    Friend WithEvents chkpiecetype As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents clb_piecetype As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Private WithEvents cmbselect As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkmerchant As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CLB_ITEMNAME As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkjobno As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CLB_JOBNO As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkdesignno As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CLB_designno As System.Windows.Forms.CheckedListBox
End Class
