<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateJobMerchant
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTLOTNO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBTYPE = New System.Windows.Forms.ComboBox()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.TXTOLDITEMNAME = New System.Windows.Forms.TextBox()
        Me.LBLMERCHANT = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTENTRYNO = New System.Windows.Forms.TextBox()
        Me.lblgroup = New System.Windows.Forms.Label()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.CMDUPDATE = New System.Windows.Forms.Button()
        Me.CMBQUALITYRATE = New System.Windows.Forms.ComboBox()
        Me.LBLNEWQUALITYRATE = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBQUALITYRATE)
        Me.BlendPanel1.Controls.Add(Me.LBLNEWQUALITYRATE)
        Me.BlendPanel1.Controls.Add(Me.TXTLOTNO)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel1.Controls.Add(Me.CMBITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.TXTOLDITEMNAME)
        Me.BlendPanel1.Controls.Add(Me.LBLMERCHANT)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTENTRYNO)
        Me.BlendPanel1.Controls.Add(Me.lblgroup)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.CMDUPDATE)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(484, 221)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTLOTNO
        '
        Me.TXTLOTNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTLOTNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLOTNO.Location = New System.Drawing.Point(316, 45)
        Me.TXTLOTNO.Name = "TXTLOTNO"
        Me.TXTLOTNO.Size = New System.Drawing.Size(77, 23)
        Me.TXTLOTNO.TabIndex = 213
        Me.TXTLOTNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(273, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 214
        Me.Label1.Text = "Lot No"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(129, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 15)
        Me.Label2.TabIndex = 212
        Me.Label2.Text = "Type"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"CUTTING", "MFG", "FINALPACKING", "GRN AND PACKING"})
        Me.CMBTYPE.Location = New System.Drawing.Point(162, 17)
        Me.CMBTYPE.MaxDropDownItems = 14
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(231, 22)
        Me.CMBTYPE.TabIndex = 0
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(162, 103)
        Me.CMBITEMNAME.MaxDropDownItems = 14
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(231, 22)
        Me.CMBITEMNAME.TabIndex = 3
        '
        'TXTOLDITEMNAME
        '
        Me.TXTOLDITEMNAME.BackColor = System.Drawing.Color.Linen
        Me.TXTOLDITEMNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOLDITEMNAME.Location = New System.Drawing.Point(162, 74)
        Me.TXTOLDITEMNAME.MaxLength = 8
        Me.TXTOLDITEMNAME.Name = "TXTOLDITEMNAME"
        Me.TXTOLDITEMNAME.ReadOnly = True
        Me.TXTOLDITEMNAME.Size = New System.Drawing.Size(231, 23)
        Me.TXTOLDITEMNAME.TabIndex = 2
        Me.TXTOLDITEMNAME.TabStop = False
        '
        'LBLMERCHANT
        '
        Me.LBLMERCHANT.AutoSize = True
        Me.LBLMERCHANT.BackColor = System.Drawing.Color.Transparent
        Me.LBLMERCHANT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMERCHANT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLMERCHANT.Location = New System.Drawing.Point(47, 78)
        Me.LBLMERCHANT.Name = "LBLMERCHANT"
        Me.LBLMERCHANT.Size = New System.Drawing.Size(113, 15)
        Me.LBLMERCHANT.TabIndex = 209
        Me.LBLMERCHANT.Text = "Old Merchant Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(43, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 15)
        Me.Label4.TabIndex = 207
        Me.Label4.Text = "New Merchant Name"
        '
        'TXTENTRYNO
        '
        Me.TXTENTRYNO.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTENTRYNO.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTENTRYNO.Location = New System.Drawing.Point(162, 45)
        Me.TXTENTRYNO.Name = "TXTENTRYNO"
        Me.TXTENTRYNO.Size = New System.Drawing.Size(77, 23)
        Me.TXTENTRYNO.TabIndex = 1
        Me.TXTENTRYNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblgroup
        '
        Me.lblgroup.AutoSize = True
        Me.lblgroup.BackColor = System.Drawing.Color.Transparent
        Me.lblgroup.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblgroup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblgroup.Location = New System.Drawing.Point(107, 49)
        Me.lblgroup.Name = "lblgroup"
        Me.lblgroup.Size = New System.Drawing.Size(53, 15)
        Me.lblgroup.TabIndex = 206
        Me.lblgroup.Text = "Entry No"
        Me.lblgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(246, 173)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 5
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'CMDUPDATE
        '
        Me.CMDUPDATE.BackColor = System.Drawing.Color.Transparent
        Me.CMDUPDATE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CMDUPDATE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDUPDATE.FlatAppearance.BorderSize = 0
        Me.CMDUPDATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDUPDATE.ForeColor = System.Drawing.Color.Black
        Me.CMDUPDATE.Location = New System.Drawing.Point(160, 173)
        Me.CMDUPDATE.Name = "CMDUPDATE"
        Me.CMDUPDATE.Size = New System.Drawing.Size(80, 28)
        Me.CMDUPDATE.TabIndex = 4
        Me.CMDUPDATE.Text = "&Update"
        Me.CMDUPDATE.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.CMDUPDATE.UseVisualStyleBackColor = False
        '
        'CMBQUALITYRATE
        '
        Me.CMBQUALITYRATE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBQUALITYRATE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBQUALITYRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBQUALITYRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBQUALITYRATE.FormattingEnabled = True
        Me.CMBQUALITYRATE.Location = New System.Drawing.Point(162, 131)
        Me.CMBQUALITYRATE.MaxDropDownItems = 14
        Me.CMBQUALITYRATE.Name = "CMBQUALITYRATE"
        Me.CMBQUALITYRATE.Size = New System.Drawing.Size(231, 22)
        Me.CMBQUALITYRATE.TabIndex = 215
        Me.CMBQUALITYRATE.Visible = False
        '
        'LBLNEWQUALITYRATE
        '
        Me.LBLNEWQUALITYRATE.AutoSize = True
        Me.LBLNEWQUALITYRATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLNEWQUALITYRATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLNEWQUALITYRATE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBLNEWQUALITYRATE.Location = New System.Drawing.Point(63, 135)
        Me.LBLNEWQUALITYRATE.Name = "LBLNEWQUALITYRATE"
        Me.LBLNEWQUALITYRATE.Size = New System.Drawing.Size(97, 15)
        Me.LBLNEWQUALITYRATE.TabIndex = 216
        Me.LBLNEWQUALITYRATE.Text = "New Quality Rate"
        Me.LBLNEWQUALITYRATE.Visible = False
        '
        'UpdateJobMerchant
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(484, 221)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "UpdateJobMerchant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Update Job Merchant"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As BlendPanel
    Friend WithEvents TXTOLDITEMNAME As TextBox
    Friend WithEvents LBLMERCHANT As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTENTRYNO As TextBox
    Friend WithEvents lblgroup As Label
    Friend WithEvents cmdcancel As Button
    Friend WithEvents CMDUPDATE As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents CMBTYPE As ComboBox
    Friend WithEvents CMBITEMNAME As ComboBox
    Friend WithEvents TXTLOTNO As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents CMBQUALITYRATE As ComboBox
    Friend WithEvents LBLNEWQUALITYRATE As Label
End Class
