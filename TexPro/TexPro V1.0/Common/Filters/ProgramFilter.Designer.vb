<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProgramFilter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RDBQUALITY = New System.Windows.Forms.RadioButton()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdshow = New System.Windows.Forms.Button()
        Me.BlendPanel2 = New VbPowerPack.BlendPanel()
        Me.CMBPRGCATEGORY = New System.Windows.Forms.ComboBox()
        Me.LBLPRGCATEGORY = New System.Windows.Forms.Label()
        Me.GPITEM = New System.Windows.Forms.GroupBox()
        Me.CHKSELECTITEM = New System.Windows.Forms.CheckBox()
        Me.GRIDBILLDETAILSITEM = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBILLITEM = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHKITEM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupBox2.SuspendLayout()
        Me.BlendPanel2.SuspendLayout()
        Me.GPITEM.SuspendLayout()
        CType(Me.GRIDBILLDETAILSITEM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILLITEM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.RDBQUALITY)
        Me.GroupBox2.Location = New System.Drawing.Point(35, 83)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 56)
        Me.GroupBox2.TabIndex = 457
        Me.GroupBox2.TabStop = False
        '
        'RDBQUALITY
        '
        Me.RDBQUALITY.AutoSize = True
        Me.RDBQUALITY.BackColor = System.Drawing.Color.Transparent
        Me.RDBQUALITY.Checked = True
        Me.RDBQUALITY.Location = New System.Drawing.Point(6, 22)
        Me.RDBQUALITY.Name = "RDBQUALITY"
        Me.RDBQUALITY.Size = New System.Drawing.Size(97, 19)
        Me.RDBQUALITY.TabIndex = 5
        Me.RDBQUALITY.TabStop = True
        Me.RDBQUALITY.Text = "Quality Wise"
        Me.RDBQUALITY.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(219, 532)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(88, 28)
        Me.cmdexit.TabIndex = 465
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdshow
        '
        Me.cmdshow.BackColor = System.Drawing.Color.Transparent
        Me.cmdshow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshow.FlatAppearance.BorderSize = 0
        Me.cmdshow.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdshow.Location = New System.Drawing.Point(125, 532)
        Me.cmdshow.Name = "cmdshow"
        Me.cmdshow.Size = New System.Drawing.Size(88, 28)
        Me.cmdshow.TabIndex = 464
        Me.cmdshow.Text = "&Show Details"
        Me.cmdshow.UseVisualStyleBackColor = False
        '
        'BlendPanel2
        '
        Me.BlendPanel2.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel2.Controls.Add(Me.CMBPRGCATEGORY)
        Me.BlendPanel2.Controls.Add(Me.LBLPRGCATEGORY)
        Me.BlendPanel2.Controls.Add(Me.GPITEM)
        Me.BlendPanel2.Controls.Add(Me.cmdshow)
        Me.BlendPanel2.Controls.Add(Me.cmdexit)
        Me.BlendPanel2.Controls.Add(Me.GroupBox2)
        Me.BlendPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel2.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel2.Name = "BlendPanel2"
        Me.BlendPanel2.Size = New System.Drawing.Size(829, 578)
        Me.BlendPanel2.TabIndex = 2
        '
        'CMBPRGCATEGORY
        '
        Me.CMBPRGCATEGORY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPRGCATEGORY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPRGCATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPRGCATEGORY.FormattingEnabled = True
        Me.CMBPRGCATEGORY.Location = New System.Drawing.Point(107, 55)
        Me.CMBPRGCATEGORY.MaxDropDownItems = 14
        Me.CMBPRGCATEGORY.Name = "CMBPRGCATEGORY"
        Me.CMBPRGCATEGORY.Size = New System.Drawing.Size(183, 22)
        Me.CMBPRGCATEGORY.TabIndex = 671
        '
        'LBLPRGCATEGORY
        '
        Me.LBLPRGCATEGORY.AutoSize = True
        Me.LBLPRGCATEGORY.BackColor = System.Drawing.Color.Transparent
        Me.LBLPRGCATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPRGCATEGORY.Location = New System.Drawing.Point(33, 59)
        Me.LBLPRGCATEGORY.Name = "LBLPRGCATEGORY"
        Me.LBLPRGCATEGORY.Size = New System.Drawing.Size(72, 14)
        Me.LBLPRGCATEGORY.TabIndex = 672
        Me.LBLPRGCATEGORY.Text = "Prg Category"
        '
        'GPITEM
        '
        Me.GPITEM.BackColor = System.Drawing.Color.Transparent
        Me.GPITEM.Controls.Add(Me.CHKSELECTITEM)
        Me.GPITEM.Controls.Add(Me.GRIDBILLDETAILSITEM)
        Me.GPITEM.Location = New System.Drawing.Point(410, 12)
        Me.GPITEM.Name = "GPITEM"
        Me.GPITEM.Size = New System.Drawing.Size(390, 554)
        Me.GPITEM.TabIndex = 466
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
        Me.CHKSELECTITEM.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTITEM.TabIndex = 0
        Me.CHKSELECTITEM.Text = "Select All"
        Me.CHKSELECTITEM.UseVisualStyleBackColor = False
        '
        'GRIDBILLDETAILSITEM
        '
        Me.GRIDBILLDETAILSITEM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILLDETAILSITEM.Location = New System.Drawing.Point(4, 43)
        Me.GRIDBILLDETAILSITEM.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDBILLDETAILSITEM.MainView = Me.GRIDBILLITEM
        Me.GRIDBILLDETAILSITEM.Name = "GRIDBILLDETAILSITEM"
        Me.GRIDBILLDETAILSITEM.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit4})
        Me.GRIDBILLDETAILSITEM.Size = New System.Drawing.Size(385, 505)
        Me.GRIDBILLDETAILSITEM.TabIndex = 1
        Me.GRIDBILLDETAILSITEM.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBILLITEM})
        '
        'GRIDBILLITEM
        '
        Me.GRIDBILLITEM.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILLITEM.Appearance.Row.Options.UseFont = True
        Me.GRIDBILLITEM.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHKITEM, Me.GITEMNAME, Me.GCATEGORY})
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
        Me.GITEMNAME.ImageOptions.ImageIndex = 0
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.OptionsColumn.AllowEdit = False
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 1
        Me.GITEMNAME.Width = 300
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        '
        'ProgramFilter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(829, 578)
        Me.Controls.Add(Me.BlendPanel2)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ProgramFilter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Program Filter"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.BlendPanel2.ResumeLayout(False)
        Me.BlendPanel2.PerformLayout()
        Me.GPITEM.ResumeLayout(False)
        Me.GPITEM.PerformLayout()
        CType(Me.GRIDBILLDETAILSITEM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILLITEM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RDBQUALITY As RadioButton
    Friend WithEvents cmdexit As Button
    Friend WithEvents cmdshow As Button
    Friend WithEvents BlendPanel2 As BlendPanel
    Friend WithEvents GPITEM As GroupBox
    Friend WithEvents CHKSELECTITEM As CheckBox
    Private WithEvents GRIDBILLDETAILSITEM As DevExpress.XtraGrid.GridControl
    Private WithEvents GRIDBILLITEM As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHKITEM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Private WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBPRGCATEGORY As ComboBox
    Friend WithEvents LBLPRGCATEGORY As Label
End Class
