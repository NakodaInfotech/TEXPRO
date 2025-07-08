<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockGridReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockGridReport))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.cmdshow = New System.Windows.Forms.Button
        Me.chkdate = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtto = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtfrom = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gitemname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPcs = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gunit = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Gmtrs = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdbDespatch = New System.Windows.Forms.RadioButton
        Me.rdbin = New System.Windows.Forms.RadioButton
        Me.Rdbout = New System.Windows.Forms.RadioButton
        Me.rdbBale = New System.Windows.Forms.RadioButton
        Me.rdbprocess = New System.Windows.Forms.RadioButton
        Me.rdbReject = New System.Windows.Forms.RadioButton
        Me.rdbApproved = New System.Windows.Forms.RadioButton
        Me.RdbOnApproval = New System.Windows.Forms.RadioButton
        Me.cmdexit = New System.Windows.Forms.Button
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdshow)
        Me.BlendPanel1.Controls.Add(Me.chkdate)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.GroupBox1)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(905, 519)
        Me.BlendPanel1.TabIndex = 1
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdshow.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Image = Global.TexPro_V1.My.Resources.Resources.VIEW
        Me.cmdshow.Location = New System.Drawing.Point(416, 49)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(75, 28)
        Me.cmdshow.TabIndex = 447
        Me.cmdshow.UseVisualStyleBackColor = False
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(120, 32)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(52, 18)
        Me.chkdate.TabIndex = 445
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtto)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtfrom)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(112, 35)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(280, 43)
        Me.GroupBox2.TabIndex = 446
        Me.GroupBox2.TabStop = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(189, 18)
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
        Me.Label1.Location = New System.Drawing.Point(161, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 14)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(50, 18)
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
        Me.Label7.Location = New System.Drawing.Point(9, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "From :"
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(112, 84)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(788, 386)
        Me.gridbilldetails.TabIndex = 435
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.Gname, Me.gitemname, Me.GQUALITY, Me.GPcs, Me.gunit, Me.Gmtrs})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "SRNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 46
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 1
        Me.gdate.Width = 68
        '
        'Gname
        '
        Me.Gname.Caption = "Name"
        Me.Gname.FieldName = "NAME"
        Me.Gname.Name = "Gname"
        Me.Gname.Visible = True
        Me.Gname.VisibleIndex = 2
        Me.Gname.Width = 207
        '
        'gitemname
        '
        Me.gitemname.Caption = "Item Name"
        Me.gitemname.FieldName = "ITEMNAME"
        Me.gitemname.ImageIndex = 1
        Me.gitemname.Name = "gitemname"
        Me.gitemname.Visible = True
        Me.gitemname.VisibleIndex = 3
        Me.gitemname.Width = 106
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 4
        Me.GQUALITY.Width = 119
        '
        'GPcs
        '
        Me.GPcs.Caption = "Pcs"
        Me.GPcs.DisplayFormat.FormatString = "0"
        Me.GPcs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPcs.FieldName = "PCS"
        Me.GPcs.Name = "GPcs"
        Me.GPcs.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GPcs.Visible = True
        Me.GPcs.VisibleIndex = 5
        '
        'gunit
        '
        Me.gunit.Caption = "Unit"
        Me.gunit.FieldName = "UNIT"
        Me.gunit.Name = "gunit"
        Me.gunit.Visible = True
        Me.gunit.VisibleIndex = 6
        Me.gunit.Width = 59
        '
        'Gmtrs
        '
        Me.Gmtrs.Caption = "Mtrs"
        Me.Gmtrs.DisplayFormat.FormatString = "0.00"
        Me.Gmtrs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Gmtrs.FieldName = "MTRS"
        Me.Gmtrs.Name = "Gmtrs"
        Me.Gmtrs.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.Gmtrs.Visible = True
        Me.Gmtrs.VisibleIndex = 7
        Me.Gmtrs.Width = 90
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(905, 25)
        Me.ToolStrip1.TabIndex = 434
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rdbDespatch)
        Me.GroupBox1.Controls.Add(Me.rdbin)
        Me.GroupBox1.Controls.Add(Me.Rdbout)
        Me.GroupBox1.Controls.Add(Me.rdbBale)
        Me.GroupBox1.Controls.Add(Me.rdbprocess)
        Me.GroupBox1.Controls.Add(Me.rdbReject)
        Me.GroupBox1.Controls.Add(Me.rdbApproved)
        Me.GroupBox1.Controls.Add(Me.RdbOnApproval)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(103, 212)
        Me.GroupBox1.TabIndex = 433
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reports"
        '
        'rdbDespatch
        '
        Me.rdbDespatch.AutoSize = True
        Me.rdbDespatch.Location = New System.Drawing.Point(12, 188)
        Me.rdbDespatch.Name = "rdbDespatch"
        Me.rdbDespatch.Size = New System.Drawing.Size(76, 18)
        Me.rdbDespatch.TabIndex = 7
        Me.rdbDespatch.Text = "Despatch"
        Me.rdbDespatch.UseVisualStyleBackColor = True
        '
        'rdbin
        '
        Me.rdbin.AutoSize = True
        Me.rdbin.Location = New System.Drawing.Point(12, 165)
        Me.rdbin.Name = "rdbin"
        Me.rdbin.Size = New System.Drawing.Size(57, 18)
        Me.rdbin.TabIndex = 6
        Me.rdbin.Text = "Job In"
        Me.rdbin.UseVisualStyleBackColor = True
        '
        'Rdbout
        '
        Me.Rdbout.AutoSize = True
        Me.Rdbout.Location = New System.Drawing.Point(12, 141)
        Me.Rdbout.Name = "Rdbout"
        Me.Rdbout.Size = New System.Drawing.Size(65, 18)
        Me.Rdbout.TabIndex = 5
        Me.Rdbout.Text = "Job Out"
        Me.Rdbout.UseVisualStyleBackColor = True
        '
        'rdbBale
        '
        Me.rdbBale.AutoSize = True
        Me.rdbBale.Location = New System.Drawing.Point(12, 117)
        Me.rdbBale.Name = "rdbBale"
        Me.rdbBale.Size = New System.Drawing.Size(81, 18)
        Me.rdbBale.TabIndex = 4
        Me.rdbBale.Text = "Bale Stock"
        Me.rdbBale.UseVisualStyleBackColor = True
        '
        'rdbprocess
        '
        Me.rdbprocess.AutoSize = True
        Me.rdbprocess.Location = New System.Drawing.Point(12, 93)
        Me.rdbprocess.Name = "rdbprocess"
        Me.rdbprocess.Size = New System.Drawing.Size(84, 18)
        Me.rdbprocess.TabIndex = 3
        Me.rdbprocess.Text = "On Process"
        Me.rdbprocess.UseVisualStyleBackColor = True
        '
        'rdbReject
        '
        Me.rdbReject.AutoSize = True
        Me.rdbReject.Location = New System.Drawing.Point(12, 69)
        Me.rdbReject.Name = "rdbReject"
        Me.rdbReject.Size = New System.Drawing.Size(72, 18)
        Me.rdbReject.TabIndex = 2
        Me.rdbReject.Text = "Rejected"
        Me.rdbReject.UseVisualStyleBackColor = True
        '
        'rdbApproved
        '
        Me.rdbApproved.AutoSize = True
        Me.rdbApproved.Checked = True
        Me.rdbApproved.Location = New System.Drawing.Point(12, 45)
        Me.rdbApproved.Name = "rdbApproved"
        Me.rdbApproved.Size = New System.Drawing.Size(56, 18)
        Me.rdbApproved.TabIndex = 1
        Me.rdbApproved.TabStop = True
        Me.rdbApproved.Text = "Check"
        Me.rdbApproved.UseVisualStyleBackColor = True
        '
        'RdbOnApproval
        '
        Me.RdbOnApproval.AutoSize = True
        Me.RdbOnApproval.Location = New System.Drawing.Point(12, 21)
        Me.RdbOnApproval.Name = "RdbOnApproval"
        Me.RdbOnApproval.Size = New System.Drawing.Size(74, 18)
        Me.RdbOnApproval.TabIndex = 0
        Me.RdbOnApproval.Text = "Un Check"
        Me.RdbOnApproval.UseVisualStyleBackColor = True
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.TexPro_V1.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(416, 476)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 24)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'stockFilter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 519)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Name = "stockFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "stockFilter"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents RdbOnApproval As System.Windows.Forms.RadioButton
    Friend WithEvents rdbReject As System.Windows.Forms.RadioButton
    Friend WithEvents rdbApproved As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gitemname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gunit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gmtrs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPcs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents rdbprocess As System.Windows.Forms.RadioButton
    Friend WithEvents chkdate As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdshow As System.Windows.Forms.Button
    Friend WithEvents rdbDespatch As System.Windows.Forms.RadioButton
    Friend WithEvents rdbin As System.Windows.Forms.RadioButton
    Friend WithEvents Rdbout As System.Windows.Forms.RadioButton
    Friend WithEvents rdbBale As System.Windows.Forms.RadioButton
End Class
