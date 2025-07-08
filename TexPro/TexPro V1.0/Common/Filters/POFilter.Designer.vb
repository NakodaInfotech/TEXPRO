<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POFilter
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
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.GPITEM = New System.Windows.Forms.GroupBox()
        Me.CHKSELECTITEM = New System.Windows.Forms.CheckBox()
        Me.GRIDBILLDETAILSITEM = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBILLITEM = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHKITEM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPPARTYNAME = New System.Windows.Forms.GroupBox()
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RDBALL = New System.Windows.Forms.RadioButton()
        Me.RDBPENDING = New System.Windows.Forms.RadioButton()
        Me.RDBCOMPLETE = New System.Windows.Forms.RadioButton()
        Me.RDBCLOSED = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RDBSTATUSDETAILS = New System.Windows.Forms.RadioButton()
        Me.RDBPARTYDTLS = New System.Windows.Forms.RadioButton()
        Me.RDBPARTYSUMM = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.BlendPanel2.SuspendLayout()
        Me.GPITEM.SuspendLayout()
        CType(Me.GRIDBILLDETAILSITEM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILLITEM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPPARTYNAME.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.GPITEM)
        Me.BlendPanel2.Controls.Add(Me.GPPARTYNAME)
        Me.BlendPanel2.Controls.Add(Me.GroupBox2)
        Me.BlendPanel2.Controls.Add(Me.GroupBox3)
        Me.BlendPanel2.Controls.Add(Me.GroupBox1)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(1234, 399)
        Me.BlendPanel2.TabIndex = 1
        '
        'GPITEM
        '
        Me.GPITEM.BackColor = System.Drawing.Color.Transparent
        Me.GPITEM.Controls.Add(Me.CHKSELECTITEM)
        Me.GPITEM.Controls.Add(Me.GRIDBILLDETAILSITEM)
        Me.GPITEM.Location = New System.Drawing.Point(342, 12)
        Me.GPITEM.Name = "GPITEM"
        Me.GPITEM.Size = New System.Drawing.Size(447, 359)
        Me.GPITEM.TabIndex = 10
        Me.GPITEM.TabStop = False
        Me.GPITEM.Text = "Item Name"
        '
        'CHKSELECTITEM
        '
        Me.CHKSELECTITEM.AutoSize = True
        Me.CHKSELECTITEM.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTITEM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTITEM.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTITEM.Location = New System.Drawing.Point(18, 22)
        Me.CHKSELECTITEM.Name = "CHKSELECTITEM"
        Me.CHKSELECTITEM.Size = New System.Drawing.Size(72, 18)
        Me.CHKSELECTITEM.TabIndex = 0
        Me.CHKSELECTITEM.Text = "Select All"
        Me.CHKSELECTITEM.UseVisualStyleBackColor = False
        '
        'GRIDBILLDETAILSITEM
        '
        Me.GRIDBILLDETAILSITEM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILLDETAILSITEM.Location = New System.Drawing.Point(6, 43)
        Me.GRIDBILLDETAILSITEM.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDBILLDETAILSITEM.MainView = Me.GRIDBILLITEM
        Me.GRIDBILLDETAILSITEM.Name = "GRIDBILLDETAILSITEM"
        Me.GRIDBILLDETAILSITEM.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit4})
        Me.GRIDBILLDETAILSITEM.Size = New System.Drawing.Size(435, 310)
        Me.GRIDBILLDETAILSITEM.TabIndex = 1
        Me.GRIDBILLDETAILSITEM.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBILLITEM})
        '
        'GRIDBILLITEM
        '
        Me.GRIDBILLITEM.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILLITEM.Appearance.Row.Options.UseFont = True
        Me.GRIDBILLITEM.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHKITEM, Me.GITEMNAME})
        Me.GRIDBILLITEM.GridControl = Me.GRIDBILLDETAILSITEM
        Me.GRIDBILLITEM.Name = "GRIDBILLITEM"
        Me.GRIDBILLITEM.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDBILLITEM.OptionsView.ColumnAutoWidth = False
        Me.GRIDBILLITEM.OptionsView.ShowAutoFilterRow = True
        Me.GRIDBILLITEM.OptionsView.ShowGroupPanel = False
        '
        'GCHKITEM
        '
        Me.GCHKITEM.ColumnEdit = Me.RepositoryItemCheckEdit4
        Me.GCHKITEM.FieldName = "CHK"
        Me.GCHKITEM.Name = "GCHKITEM"
        Me.GCHKITEM.OptionsColumn.ShowCaption = False
        Me.GCHKITEM.Visible = True
        Me.GCHKITEM.VisibleIndex = 0
        Me.GCHKITEM.Width = 35
        '
        'RepositoryItemCheckEdit4
        '
        Me.RepositoryItemCheckEdit4.AutoHeight = False
        Me.RepositoryItemCheckEdit4.Name = "RepositoryItemCheckEdit4"
        Me.RepositoryItemCheckEdit4.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.ImageIndex = 0
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 1
        Me.GITEMNAME.Width = 350
        '
        'GPPARTYNAME
        '
        Me.GPPARTYNAME.BackColor = System.Drawing.Color.Transparent
        Me.GPPARTYNAME.Controls.Add(Me.CHKSELECTALL)
        Me.GPPARTYNAME.Controls.Add(Me.gridbilldetails)
        Me.GPPARTYNAME.Location = New System.Drawing.Point(12, 12)
        Me.GPPARTYNAME.Name = "GPPARTYNAME"
        Me.GPPARTYNAME.Size = New System.Drawing.Size(324, 359)
        Me.GPPARTYNAME.TabIndex = 9
        Me.GPPARTYNAME.TabStop = False
        Me.GPPARTYNAME.Text = "Party Name"
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(18, 22)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(72, 18)
        Me.CHKSELECTALL.TabIndex = 0
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(6, 43)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.gridbilldetails.Size = New System.Drawing.Size(313, 310)
        Me.gridbilldetails.TabIndex = 1
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GNAME})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 35
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 1
        Me.GNAME.Width = 230
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.RDBALL)
        Me.GroupBox2.Controls.Add(Me.RDBPENDING)
        Me.GroupBox2.Controls.Add(Me.RDBCOMPLETE)
        Me.GroupBox2.Controls.Add(Me.RDBCLOSED)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(811, 132)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(316, 46)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'RDBALL
        '
        Me.RDBALL.AutoSize = True
        Me.RDBALL.Location = New System.Drawing.Point(234, 19)
        Me.RDBALL.Name = "RDBALL"
        Me.RDBALL.Size = New System.Drawing.Size(38, 18)
        Me.RDBALL.TabIndex = 3
        Me.RDBALL.Text = "All"
        Me.RDBALL.UseVisualStyleBackColor = True
        '
        'RDBPENDING
        '
        Me.RDBPENDING.AutoSize = True
        Me.RDBPENDING.Checked = True
        Me.RDBPENDING.Location = New System.Drawing.Point(6, 19)
        Me.RDBPENDING.Name = "RDBPENDING"
        Me.RDBPENDING.Size = New System.Drawing.Size(64, 18)
        Me.RDBPENDING.TabIndex = 0
        Me.RDBPENDING.TabStop = True
        Me.RDBPENDING.Text = "Pending"
        Me.RDBPENDING.UseVisualStyleBackColor = True
        '
        'RDBCOMPLETE
        '
        Me.RDBCOMPLETE.AutoSize = True
        Me.RDBCOMPLETE.Location = New System.Drawing.Point(81, 19)
        Me.RDBCOMPLETE.Name = "RDBCOMPLETE"
        Me.RDBCOMPLETE.Size = New System.Drawing.Size(78, 18)
        Me.RDBCOMPLETE.TabIndex = 1
        Me.RDBCOMPLETE.Text = "Completed"
        Me.RDBCOMPLETE.UseVisualStyleBackColor = True
        '
        'RDBCLOSED
        '
        Me.RDBCLOSED.AutoSize = True
        Me.RDBCLOSED.Location = New System.Drawing.Point(171, 19)
        Me.RDBCLOSED.Name = "RDBCLOSED"
        Me.RDBCLOSED.Size = New System.Drawing.Size(57, 18)
        Me.RDBCLOSED.TabIndex = 2
        Me.RDBCLOSED.Text = "Closed"
        Me.RDBCLOSED.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RDBSTATUSDETAILS)
        Me.GroupBox3.Controls.Add(Me.RDBPARTYDTLS)
        Me.GroupBox3.Controls.Add(Me.RDBPARTYSUMM)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(811, 21)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(266, 88)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        '
        'RDBSTATUSDETAILS
        '
        Me.RDBSTATUSDETAILS.AutoSize = True
        Me.RDBSTATUSDETAILS.Location = New System.Drawing.Point(26, 61)
        Me.RDBSTATUSDETAILS.Name = "RDBSTATUSDETAILS"
        Me.RDBSTATUSDETAILS.Size = New System.Drawing.Size(180, 18)
        Me.RDBSTATUSDETAILS.TabIndex = 2
        Me.RDBSTATUSDETAILS.Text = "Party Wise Order Status Details"
        Me.RDBSTATUSDETAILS.UseVisualStyleBackColor = True
        '
        'RDBPARTYDTLS
        '
        Me.RDBPARTYDTLS.AutoSize = True
        Me.RDBPARTYDTLS.Location = New System.Drawing.Point(26, 37)
        Me.RDBPARTYDTLS.Name = "RDBPARTYDTLS"
        Me.RDBPARTYDTLS.Size = New System.Drawing.Size(115, 18)
        Me.RDBPARTYDTLS.TabIndex = 1
        Me.RDBPARTYDTLS.Text = "Party Wise Details"
        Me.RDBPARTYDTLS.UseVisualStyleBackColor = True
        '
        'RDBPARTYSUMM
        '
        Me.RDBPARTYSUMM.AutoSize = True
        Me.RDBPARTYSUMM.Checked = True
        Me.RDBPARTYSUMM.Location = New System.Drawing.Point(26, 13)
        Me.RDBPARTYSUMM.Name = "RDBPARTYSUMM"
        Me.RDBPARTYSUMM.Size = New System.Drawing.Size(128, 18)
        Me.RDBPARTYSUMM.TabIndex = 0
        Me.RDBPARTYSUMM.TabStop = True
        Me.RDBPARTYSUMM.Text = "Party Wise Summary"
        Me.RDBPARTYSUMM.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtfrom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.chkdate)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(811, 220)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(189, 20)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(161, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(50, 20)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtfrom.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(9, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 14)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "From :"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(6, 0)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(49, 18)
        Me.chkdate.TabIndex = 0
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(888, 304)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(88, 28)
        Me.cmdshow.TabIndex = 13
        Me.cmdshow.Text = "&Show Details"
        Me.cmdshow.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(982, 304)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 28)
        Me.cmdexit.TabIndex = 14
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'POFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 399)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "POFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Purchase Order Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel2.ResumeLayout(False)
        Me.GPITEM.ResumeLayout(False)
        Me.GPITEM.PerformLayout()
        CType(Me.GRIDBILLDETAILSITEM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILLITEM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPPARTYNAME.ResumeLayout(False)
        Me.GPPARTYNAME.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel2 As BlendPanel
    Friend WithEvents GPITEM As GroupBox
    Friend WithEvents CHKSELECTITEM As CheckBox
    Private WithEvents GRIDBILLDETAILSITEM As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDBILLITEM As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHKITEM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPPARTYNAME As GroupBox
    Friend WithEvents CHKSELECTALL As CheckBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RDBALL As RadioButton
    Friend WithEvents RDBPENDING As RadioButton
    Friend WithEvents RDBCOMPLETE As RadioButton
    Friend WithEvents RDBCLOSED As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RDBPARTYDTLS As RadioButton
    Friend WithEvents RDBPARTYSUMM As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents chkdate As CheckBox
    Friend WithEvents cmdshow As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents RDBSTATUSDETAILS As RadioButton
End Class
