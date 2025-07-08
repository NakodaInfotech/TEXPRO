<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MachineMaster
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.gpitem = New System.Windows.Forms.GroupBox
        Me.TXTSUPPNAME = New System.Windows.Forms.TextBox
        Me.TXTLABPERMAC = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TXTPOWERPERHR = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CMBPROCESS = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TXTCOSTPERHR = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TXTAVG = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TXTCAPPERHR = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TXTMANPERMAC = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblcategory = New System.Windows.Forms.Label
        Me.TXTMACNO = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.CMBMACHINENAME = New System.Windows.Forms.ComboBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtremarks = New System.Windows.Forms.TextBox
        Me.lbl = New System.Windows.Forms.Label
        Me.chkchange = New System.Windows.Forms.CheckBox
        Me.cmddelete = New System.Windows.Forms.Button
        Me.cmdok = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        Me.gpitem.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gpitem)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.chkchange)
        Me.BlendPanel1.Controls.Add(Me.cmddelete)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(639, 322)
        Me.BlendPanel1.TabIndex = 0
        '
        'gpitem
        '
        Me.gpitem.BackColor = System.Drawing.Color.Transparent
        Me.gpitem.Controls.Add(Me.TXTSUPPNAME)
        Me.gpitem.Controls.Add(Me.TXTLABPERMAC)
        Me.gpitem.Controls.Add(Me.Label2)
        Me.gpitem.Controls.Add(Me.TXTPOWERPERHR)
        Me.gpitem.Controls.Add(Me.Label1)
        Me.gpitem.Controls.Add(Me.CMBPROCESS)
        Me.gpitem.Controls.Add(Me.Label8)
        Me.gpitem.Controls.Add(Me.TXTCOSTPERHR)
        Me.gpitem.Controls.Add(Me.Label7)
        Me.gpitem.Controls.Add(Me.TXTAVG)
        Me.gpitem.Controls.Add(Me.Label6)
        Me.gpitem.Controls.Add(Me.TXTCAPPERHR)
        Me.gpitem.Controls.Add(Me.Label4)
        Me.gpitem.Controls.Add(Me.TXTMANPERMAC)
        Me.gpitem.Controls.Add(Me.Label5)
        Me.gpitem.Controls.Add(Me.Label3)
        Me.gpitem.Controls.Add(Me.lblcategory)
        Me.gpitem.Controls.Add(Me.TXTMACNO)
        Me.gpitem.Controls.Add(Me.Label11)
        Me.gpitem.Controls.Add(Me.CMBMACHINENAME)
        Me.gpitem.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpitem.ForeColor = System.Drawing.Color.Black
        Me.gpitem.Location = New System.Drawing.Point(23, 43)
        Me.gpitem.Name = "gpitem"
        Me.gpitem.Size = New System.Drawing.Size(592, 178)
        Me.gpitem.TabIndex = 0
        Me.gpitem.TabStop = False
        Me.gpitem.Text = "Machine Details"
        '
        'TXTSUPPNAME
        '
        Me.TXTSUPPNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTSUPPNAME.Location = New System.Drawing.Point(388, 27)
        Me.TXTSUPPNAME.Name = "TXTSUPPNAME"
        Me.TXTSUPPNAME.Size = New System.Drawing.Size(183, 22)
        Me.TXTSUPPNAME.TabIndex = 1
        '
        'TXTLABPERMAC
        '
        Me.TXTLABPERMAC.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLABPERMAC.Location = New System.Drawing.Point(388, 83)
        Me.TXTLABPERMAC.Name = "TXTLABPERMAC"
        Me.TXTLABPERMAC.Size = New System.Drawing.Size(49, 22)
        Me.TXTLABPERMAC.TabIndex = 5
        Me.TXTLABPERMAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(284, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 14)
        Me.Label2.TabIndex = 352
        Me.Label2.Text = "Labour / Machine"
        '
        'TXTPOWERPERHR
        '
        Me.TXTPOWERPERHR.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTPOWERPERHR.Location = New System.Drawing.Point(117, 139)
        Me.TXTPOWERPERHR.Name = "TXTPOWERPERHR"
        Me.TXTPOWERPERHR.Size = New System.Drawing.Size(49, 22)
        Me.TXTPOWERPERHR.TabIndex = 8
        Me.TXTPOWERPERHR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 14)
        Me.Label1.TabIndex = 350
        Me.Label1.Text = "Power Cons. /Hr"
        '
        'CMBPROCESS
        '
        Me.CMBPROCESS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPROCESS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPROCESS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPROCESS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPROCESS.FormattingEnabled = True
        Me.CMBPROCESS.Location = New System.Drawing.Point(117, 55)
        Me.CMBPROCESS.MaxDropDownItems = 14
        Me.CMBPROCESS.Name = "CMBPROCESS"
        Me.CMBPROCESS.Size = New System.Drawing.Size(183, 22)
        Me.CMBPROCESS.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(67, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 14)
        Me.Label8.TabIndex = 348
        Me.Label8.Text = "Process"
        '
        'TXTCOSTPERHR
        '
        Me.TXTCOSTPERHR.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOSTPERHR.Location = New System.Drawing.Point(117, 111)
        Me.TXTCOSTPERHR.Name = "TXTCOSTPERHR"
        Me.TXTCOSTPERHR.Size = New System.Drawing.Size(49, 22)
        Me.TXTCOSTPERHR.TabIndex = 6
        Me.TXTCOSTPERHR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 14)
        Me.Label7.TabIndex = 346
        Me.Label7.Text = "Running Cost / Hr"
        '
        'TXTAVG
        '
        Me.TXTAVG.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTAVG.Location = New System.Drawing.Point(388, 139)
        Me.TXTAVG.Name = "TXTAVG"
        Me.TXTAVG.Size = New System.Drawing.Size(49, 22)
        Me.TXTAVG.TabIndex = 9
        Me.TXTAVG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(244, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(142, 14)
        Me.Label6.TabIndex = 322
        Me.Label6.Text = "Avg. Breakdown Time /Hr"
        '
        'TXTCAPPERHR
        '
        Me.TXTCAPPERHR.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCAPPERHR.Location = New System.Drawing.Point(388, 111)
        Me.TXTCAPPERHR.Name = "TXTCAPPERHR"
        Me.TXTCAPPERHR.Size = New System.Drawing.Size(49, 22)
        Me.TXTCAPPERHR.TabIndex = 7
        Me.TXTCAPPERHR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(311, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 14)
        Me.Label4.TabIndex = 344
        Me.Label4.Text = "Capacity / Hr"
        '
        'TXTMANPERMAC
        '
        Me.TXTMANPERMAC.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMANPERMAC.Location = New System.Drawing.Point(117, 83)
        Me.TXTMANPERMAC.Name = "TXTMANPERMAC"
        Me.TXTMANPERMAC.Size = New System.Drawing.Size(49, 22)
        Me.TXTMANPERMAC.TabIndex = 4
        Me.TXTMANPERMAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 14)
        Me.Label5.TabIndex = 320
        Me.Label5.Text = "Man / Machine"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(76, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 14)
        Me.Label3.TabIndex = 308
        Me.Label3.Text = "Name"
        '
        'lblcategory
        '
        Me.lblcategory.AutoSize = True
        Me.lblcategory.BackColor = System.Drawing.Color.Transparent
        Me.lblcategory.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcategory.Location = New System.Drawing.Point(317, 31)
        Me.lblcategory.Name = "lblcategory"
        Me.lblcategory.Size = New System.Drawing.Size(69, 14)
        Me.lblcategory.TabIndex = 309
        Me.lblcategory.Text = "Supp Name"
        '
        'TXTMACNO
        '
        Me.TXTMACNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMACNO.Location = New System.Drawing.Point(388, 55)
        Me.TXTMACNO.Name = "TXTMACNO"
        Me.TXTMACNO.Size = New System.Drawing.Size(49, 22)
        Me.TXTMACNO.TabIndex = 3
        Me.TXTMACNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(311, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 14)
        Me.Label11.TabIndex = 332
        Me.Label11.Text = "Machine No."
        '
        'CMBMACHINENAME
        '
        Me.CMBMACHINENAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMACHINENAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMACHINENAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBMACHINENAME.FormattingEnabled = True
        Me.CMBMACHINENAME.Location = New System.Drawing.Point(117, 27)
        Me.CMBMACHINENAME.MaxDropDownItems = 14
        Me.CMBMACHINENAME.Name = "CMBMACHINENAME"
        Me.CMBMACHINENAME.Size = New System.Drawing.Size(183, 22)
        Me.CMBMACHINENAME.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(23, 227)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(410, 75)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(6, 18)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(398, 51)
        Me.txtremarks.TabIndex = 0
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(12, 12)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(245, 19)
        Me.lbl.TabIndex = 312
        Me.lbl.Text = "Machine Capacity Configurator"
        '
        'chkchange
        '
        Me.chkchange.AutoSize = True
        Me.chkchange.Location = New System.Drawing.Point(267, 16)
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
        Me.cmddelete.Location = New System.Drawing.Point(535, 238)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(72, 26)
        Me.cmddelete.TabIndex = 3
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
        Me.cmdok.Location = New System.Drawing.Point(459, 238)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(72, 26)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(499, 270)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 26)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'MachineMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(639, 322)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MachineMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Machine Capacity Configurator"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.gpitem.ResumeLayout(False)
        Me.gpitem.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents gpitem As System.Windows.Forms.GroupBox
    Friend WithEvents CMBPROCESS As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTCOSTPERHR As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTAVG As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTCAPPERHR As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTMANPERMAC As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblcategory As System.Windows.Forms.Label
    Friend WithEvents TXTMACNO As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CMBMACHINENAME As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtremarks As System.Windows.Forms.TextBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents chkchange As System.Windows.Forms.CheckBox
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents TXTPOWERPERHR As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXTLABPERMAC As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXTSUPPNAME As System.Windows.Forms.TextBox
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
End Class
