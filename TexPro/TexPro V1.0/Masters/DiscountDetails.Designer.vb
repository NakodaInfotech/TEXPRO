<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DiscountDetails
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
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.GRIDDISCNAMEDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDDISCNAME = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GDISCNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDISCID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.griddetails = New DevExpress.XtraGrid.GridControl()
        Me.GRIDDISCRATE = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmbformname = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDDISCNAMEDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDDISCNAME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDDISCRATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbformname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.GRIDDISCNAMEDETAILS)
        Me.BlendPanel1.Controls.Add(Me.griddetails)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(752, 581)
        Me.BlendPanel1.TabIndex = 1
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(379, 550)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 431
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(293, 550)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 430
        Me.cmdok.Text = "&Edit"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GRIDDISCNAMEDETAILS
        '
        Me.GRIDDISCNAMEDETAILS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDDISCNAMEDETAILS.Location = New System.Drawing.Point(24, 21)
        Me.GRIDDISCNAMEDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDDISCNAMEDETAILS.MainView = Me.GRIDDISCNAME
        Me.GRIDDISCNAMEDETAILS.Name = "GRIDDISCNAMEDETAILS"
        Me.GRIDDISCNAMEDETAILS.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemComboBox1, Me.RepositoryItemCheckEdit2})
        Me.GRIDDISCNAMEDETAILS.Size = New System.Drawing.Size(296, 501)
        Me.GRIDDISCNAMEDETAILS.TabIndex = 6
        Me.GRIDDISCNAMEDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDDISCNAME})
        '
        'GRIDDISCNAME
        '
        Me.GRIDDISCNAME.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDDISCNAME.Appearance.Row.Options.UseFont = True
        Me.GRIDDISCNAME.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GDISCNAME, Me.GDISCID})
        Me.GRIDDISCNAME.GridControl = Me.GRIDDISCNAMEDETAILS
        Me.GRIDDISCNAME.Name = "GRIDDISCNAME"
        Me.GRIDDISCNAME.OptionsBehavior.Editable = False
        Me.GRIDDISCNAME.OptionsCustomization.AllowGroup = False
        Me.GRIDDISCNAME.OptionsView.ColumnAutoWidth = False
        Me.GRIDDISCNAME.OptionsView.ShowGroupPanel = False
        '
        'GDISCNAME
        '
        Me.GDISCNAME.Caption = "Discount Name"
        Me.GDISCNAME.FieldName = "DISCNAME"
        Me.GDISCNAME.Name = "GDISCNAME"
        Me.GDISCNAME.Visible = True
        Me.GDISCNAME.VisibleIndex = 0
        Me.GDISCNAME.Width = 250
        '
        'GDISCID
        '
        Me.GDISCID.Caption = "DISCID"
        Me.GDISCID.FieldName = "DISCID"
        Me.GDISCID.Name = "GDISCID"
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemComboBox1.DropDownRows = 10
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        Me.RepositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.RepositoryItemComboBox1.ValidateOnEnterKey = True
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'griddetails
        '
        Me.griddetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Location = New System.Drawing.Point(325, 21)
        Me.griddetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.griddetails.MainView = Me.GRIDDISCRATE
        Me.griddetails.Name = "griddetails"
        Me.griddetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.cmbformname, Me.RepositoryItemCheckEdit1})
        Me.griddetails.Size = New System.Drawing.Size(400, 501)
        Me.griddetails.TabIndex = 5
        Me.griddetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDDISCRATE})
        '
        'GRIDDISCRATE
        '
        Me.GRIDDISCRATE.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDDISCRATE.Appearance.Row.Options.UseFont = True
        Me.GRIDDISCRATE.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GITEMNAME, Me.GRATE})
        Me.GRIDDISCRATE.GridControl = Me.griddetails
        Me.GRIDDISCRATE.Name = "GRIDDISCRATE"
        Me.GRIDDISCRATE.OptionsBehavior.Editable = False
        Me.GRIDDISCRATE.OptionsCustomization.AllowGroup = False
        Me.GRIDDISCRATE.OptionsView.ColumnAutoWidth = False
        Me.GRIDDISCRATE.OptionsView.ShowGroupPanel = False
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 0
        Me.GITEMNAME.Width = 250
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 1
        Me.GRATE.Width = 100
        '
        'cmbformname
        '
        Me.cmbformname.AutoHeight = False
        Me.cmbformname.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbformname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cmbformname.DropDownRows = 10
        Me.cmbformname.Name = "cmbformname"
        Me.cmbformname.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cmbformname.ValidateOnEnterKey = True
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'DiscountDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(752, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DiscountDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Discount Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        CType(Me.GRIDDISCNAMEDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDDISCNAME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDDISCRATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbformname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As BlendPanel
    Friend WithEvents cmdexit As Button
    Friend WithEvents cmdok As Button
    Friend WithEvents GRIDDISCNAMEDETAILS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDDISCNAME As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GDISCNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents griddetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDDISCRATE As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbformname As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GDISCID As DevExpress.XtraGrid.Columns.GridColumn
End Class
