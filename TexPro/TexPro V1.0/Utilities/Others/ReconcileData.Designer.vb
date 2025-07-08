<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReconcileData
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
        Me.CHKRECOPURCHASE = New System.Windows.Forms.CheckBox()
        Me.CHKRECONONPURCHASE = New System.Windows.Forms.CheckBox()
        Me.CHKRECOINV = New System.Windows.Forms.CheckBox()
        Me.CHKRECOSTOCK = New System.Windows.Forms.CheckBox()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKLOOSESTOCK = New System.Windows.Forms.CheckBox()
        Me.CHKMFG2STOCK = New System.Windows.Forms.CheckBox()
        Me.CHKJOBSTOCK = New System.Windows.Forms.CheckBox()
        Me.CHKBALESTOCK = New System.Windows.Forms.CheckBox()
        Me.CHKMFGSTOCK = New System.Windows.Forms.CheckBox()
        Me.CHKGRSTOCK = New System.Windows.Forms.CheckBox()
        Me.CHKGREYSTOCK = New System.Windows.Forms.CheckBox()
        Me.CHKRECOORDER = New System.Windows.Forms.CheckBox()
        Me.CHKRECOPENDINGDATA = New System.Windows.Forms.CheckBox()
        Me.CHKOPENBALESTOCK = New System.Windows.Forms.CheckBox()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CHKRECOPURCHASE
        '
        Me.CHKRECOPURCHASE.AutoSize = True
        Me.CHKRECOPURCHASE.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOPURCHASE.Location = New System.Drawing.Point(27, 45)
        Me.CHKRECOPURCHASE.Name = "CHKRECOPURCHASE"
        Me.CHKRECOPURCHASE.Size = New System.Drawing.Size(120, 19)
        Me.CHKRECOPURCHASE.TabIndex = 1
        Me.CHKRECOPURCHASE.Text = "Purchase Invoice"
        Me.CHKRECOPURCHASE.UseVisualStyleBackColor = False
        Me.CHKRECOPURCHASE.Visible = False
        '
        'CHKRECONONPURCHASE
        '
        Me.CHKRECONONPURCHASE.AutoSize = True
        Me.CHKRECONONPURCHASE.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECONONPURCHASE.Location = New System.Drawing.Point(27, 70)
        Me.CHKRECONONPURCHASE.Name = "CHKRECONONPURCHASE"
        Me.CHKRECONONPURCHASE.Size = New System.Drawing.Size(146, 19)
        Me.CHKRECONONPURCHASE.TabIndex = 2
        Me.CHKRECONONPURCHASE.Text = "Non-Purchase Invoice"
        Me.CHKRECONONPURCHASE.UseVisualStyleBackColor = False
        Me.CHKRECONONPURCHASE.Visible = False
        '
        'CHKRECOINV
        '
        Me.CHKRECOINV.AutoSize = True
        Me.CHKRECOINV.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOINV.Location = New System.Drawing.Point(27, 20)
        Me.CHKRECOINV.Name = "CHKRECOINV"
        Me.CHKRECOINV.Size = New System.Drawing.Size(92, 19)
        Me.CHKRECOINV.TabIndex = 0
        Me.CHKRECOINV.Text = "Sale Invoice"
        Me.CHKRECOINV.UseVisualStyleBackColor = False
        Me.CHKRECOINV.Visible = False
        '
        'CHKRECOSTOCK
        '
        Me.CHKRECOSTOCK.AutoSize = True
        Me.CHKRECOSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOSTOCK.Location = New System.Drawing.Point(27, 145)
        Me.CHKRECOSTOCK.Name = "CHKRECOSTOCK"
        Me.CHKRECOSTOCK.Size = New System.Drawing.Size(111, 19)
        Me.CHKRECOSTOCK.TabIndex = 5
        Me.CHKRECOSTOCK.Text = "Reconcile Stock"
        Me.CHKRECOSTOCK.UseVisualStyleBackColor = False
        '
        'CMDOK
        '
        Me.CMDOK.Location = New System.Drawing.Point(114, 400)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 6
        Me.CMDOK.Text = "&OK"
        Me.CMDOK.UseVisualStyleBackColor = True
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(200, 400)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 7
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(286, 400)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 8
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKOPENBALESTOCK)
        Me.BlendPanel1.Controls.Add(Me.CHKLOOSESTOCK)
        Me.BlendPanel1.Controls.Add(Me.CHKMFG2STOCK)
        Me.BlendPanel1.Controls.Add(Me.CHKJOBSTOCK)
        Me.BlendPanel1.Controls.Add(Me.CHKBALESTOCK)
        Me.BlendPanel1.Controls.Add(Me.CHKMFGSTOCK)
        Me.BlendPanel1.Controls.Add(Me.CHKGRSTOCK)
        Me.BlendPanel1.Controls.Add(Me.CHKGREYSTOCK)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOORDER)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOPENDINGDATA)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOSTOCK)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOINV)
        Me.BlendPanel1.Controls.Add(Me.CHKRECONONPURCHASE)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOPURCHASE)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(480, 440)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKLOOSESTOCK
        '
        Me.CHKLOOSESTOCK.AutoSize = True
        Me.CHKLOOSESTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKLOOSESTOCK.Location = New System.Drawing.Point(217, 245)
        Me.CHKLOOSESTOCK.Name = "CHKLOOSESTOCK"
        Me.CHKLOOSESTOCK.Size = New System.Drawing.Size(89, 19)
        Me.CHKLOOSESTOCK.TabIndex = 16
        Me.CHKLOOSESTOCK.Text = "Loose Stock"
        Me.CHKLOOSESTOCK.UseVisualStyleBackColor = False
        '
        'CHKMFG2STOCK
        '
        Me.CHKMFG2STOCK.AutoSize = True
        Me.CHKMFG2STOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKMFG2STOCK.Location = New System.Drawing.Point(217, 220)
        Me.CHKMFG2STOCK.Name = "CHKMFG2STOCK"
        Me.CHKMFG2STOCK.Size = New System.Drawing.Size(133, 19)
        Me.CHKMFG2STOCK.TabIndex = 15
        Me.CHKMFG2STOCK.Text = "Mfg Stock (Printing)"
        Me.CHKMFG2STOCK.UseVisualStyleBackColor = False
        '
        'CHKJOBSTOCK
        '
        Me.CHKJOBSTOCK.AutoSize = True
        Me.CHKJOBSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKJOBSTOCK.Location = New System.Drawing.Point(217, 195)
        Me.CHKJOBSTOCK.Name = "CHKJOBSTOCK"
        Me.CHKJOBSTOCK.Size = New System.Drawing.Size(76, 19)
        Me.CHKJOBSTOCK.TabIndex = 14
        Me.CHKJOBSTOCK.Text = "Job Stock"
        Me.CHKJOBSTOCK.UseVisualStyleBackColor = False
        '
        'CHKBALESTOCK
        '
        Me.CHKBALESTOCK.AutoSize = True
        Me.CHKBALESTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKBALESTOCK.Location = New System.Drawing.Point(217, 170)
        Me.CHKBALESTOCK.Name = "CHKBALESTOCK"
        Me.CHKBALESTOCK.Size = New System.Drawing.Size(82, 19)
        Me.CHKBALESTOCK.TabIndex = 13
        Me.CHKBALESTOCK.Text = "Bale Stock"
        Me.CHKBALESTOCK.UseVisualStyleBackColor = False
        '
        'CHKMFGSTOCK
        '
        Me.CHKMFGSTOCK.AutoSize = True
        Me.CHKMFGSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKMFGSTOCK.Location = New System.Drawing.Point(61, 245)
        Me.CHKMFGSTOCK.Name = "CHKMFGSTOCK"
        Me.CHKMFGSTOCK.Size = New System.Drawing.Size(79, 19)
        Me.CHKMFGSTOCK.TabIndex = 12
        Me.CHKMFGSTOCK.Text = "Mfg Stock"
        Me.CHKMFGSTOCK.UseVisualStyleBackColor = False
        '
        'CHKGRSTOCK
        '
        Me.CHKGRSTOCK.AutoSize = True
        Me.CHKGRSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKGRSTOCK.Location = New System.Drawing.Point(61, 195)
        Me.CHKGRSTOCK.Name = "CHKGRSTOCK"
        Me.CHKGRSTOCK.Size = New System.Drawing.Size(73, 19)
        Me.CHKGRSTOCK.TabIndex = 11
        Me.CHKGRSTOCK.Text = "GR Stock"
        Me.CHKGRSTOCK.UseVisualStyleBackColor = False
        '
        'CHKGREYSTOCK
        '
        Me.CHKGREYSTOCK.AutoSize = True
        Me.CHKGREYSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKGREYSTOCK.Location = New System.Drawing.Point(61, 170)
        Me.CHKGREYSTOCK.Name = "CHKGREYSTOCK"
        Me.CHKGREYSTOCK.Size = New System.Drawing.Size(153, 19)
        Me.CHKGREYSTOCK.TabIndex = 9
        Me.CHKGREYSTOCK.Text = "Grey Stock (Unchecked)"
        Me.CHKGREYSTOCK.UseVisualStyleBackColor = False
        '
        'CHKRECOORDER
        '
        Me.CHKRECOORDER.AutoSize = True
        Me.CHKRECOORDER.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOORDER.Location = New System.Drawing.Point(27, 120)
        Me.CHKRECOORDER.Name = "CHKRECOORDER"
        Me.CHKRECOORDER.Size = New System.Drawing.Size(147, 19)
        Me.CHKRECOORDER.TabIndex = 4
        Me.CHKRECOORDER.Text = "Sale | Purchase Order"
        Me.CHKRECOORDER.UseVisualStyleBackColor = False
        '
        'CHKRECOPENDINGDATA
        '
        Me.CHKRECOPENDINGDATA.AutoSize = True
        Me.CHKRECOPENDINGDATA.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOPENDINGDATA.Location = New System.Drawing.Point(27, 95)
        Me.CHKRECOPENDINGDATA.Name = "CHKRECOPENDINGDATA"
        Me.CHKRECOPENDINGDATA.Size = New System.Drawing.Size(187, 19)
        Me.CHKRECOPENDINGDATA.TabIndex = 3
        Me.CHKRECOPENDINGDATA.Text = "Pending Data (GRN / Challan)"
        Me.CHKRECOPENDINGDATA.UseVisualStyleBackColor = False
        Me.CHKRECOPENDINGDATA.Visible = False
        '
        'CHKOPENBALESTOCK
        '
        Me.CHKOPENBALESTOCK.AutoSize = True
        Me.CHKOPENBALESTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKOPENBALESTOCK.Location = New System.Drawing.Point(61, 270)
        Me.CHKOPENBALESTOCK.Name = "CHKOPENBALESTOCK"
        Me.CHKOPENBALESTOCK.Size = New System.Drawing.Size(114, 19)
        Me.CHKOPENBALESTOCK.TabIndex = 17
        Me.CHKOPENBALESTOCK.Text = "Open Bale Stock"
        Me.CHKOPENBALESTOCK.UseVisualStyleBackColor = False
        '
        'ReconcileData
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(480, 440)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ReconcileData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Reconcile Data"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CHKRECOPURCHASE As System.Windows.Forms.CheckBox
    Friend WithEvents CHKRECONONPURCHASE As System.Windows.Forms.CheckBox
    Friend WithEvents CHKRECOINV As System.Windows.Forms.CheckBox
    Friend WithEvents CHKRECOSTOCK As System.Windows.Forms.CheckBox
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CHKRECOPENDINGDATA As System.Windows.Forms.CheckBox
    Friend WithEvents CHKRECOORDER As CheckBox
    Friend WithEvents CHKLOOSESTOCK As CheckBox
    Friend WithEvents CHKMFG2STOCK As CheckBox
    Friend WithEvents CHKJOBSTOCK As CheckBox
    Friend WithEvents CHKBALESTOCK As CheckBox
    Friend WithEvents CHKMFGSTOCK As CheckBox
    Friend WithEvents CHKGRSTOCK As CheckBox
    Friend WithEvents CHKGREYSTOCK As CheckBox
    Friend WithEvents CHKOPENBALESTOCK As CheckBox
End Class
