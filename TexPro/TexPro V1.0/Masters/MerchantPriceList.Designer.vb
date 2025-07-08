<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MerchantPriceList
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
        Me.components = New System.ComponentModel.Container()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTFRESHRATE = New System.Windows.Forms.TextBox()
        Me.TXTRAINBOW = New System.Windows.Forms.TextBox()
        Me.TXTEXTRADARK = New System.Windows.Forms.TextBox()
        Me.TXTDARK = New System.Windows.Forms.TextBox()
        Me.TXTLIGHT = New System.Windows.Forms.TextBox()
        Me.TXTCREAM = New System.Windows.Forms.TextBox()
        Me.TXTWHITE = New System.Windows.Forms.TextBox()
        Me.CMDEXCEL = New System.Windows.Forms.Button()
        Me.GRIDBILLDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBILL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPIECETYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWHITE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCREAM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLIGHT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDARK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXTRADARK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRAINBOW = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFRESHRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMBPIECETYPE = New System.Windows.Forms.ComboBox()
        Me.CMBMERCHANT = New System.Windows.Forms.ComboBox()
        Me.TXTRATE = New System.Windows.Forms.TextBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTFRESHRATE)
        Me.BlendPanel1.Controls.Add(Me.TXTRAINBOW)
        Me.BlendPanel1.Controls.Add(Me.TXTEXTRADARK)
        Me.BlendPanel1.Controls.Add(Me.TXTDARK)
        Me.BlendPanel1.Controls.Add(Me.TXTLIGHT)
        Me.BlendPanel1.Controls.Add(Me.TXTCREAM)
        Me.BlendPanel1.Controls.Add(Me.TXTWHITE)
        Me.BlendPanel1.Controls.Add(Me.CMDEXCEL)
        Me.BlendPanel1.Controls.Add(Me.GRIDBILLDETAILS)
        Me.BlendPanel1.Controls.Add(Me.CMBPIECETYPE)
        Me.BlendPanel1.Controls.Add(Me.CMBMERCHANT)
        Me.BlendPanel1.Controls.Add(Me.TXTRATE)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1248, 582)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTFRESHRATE
        '
        Me.TXTFRESHRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTFRESHRATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFRESHRATE.Location = New System.Drawing.Point(1096, 17)
        Me.TXTFRESHRATE.Name = "TXTFRESHRATE"
        Me.TXTFRESHRATE.Size = New System.Drawing.Size(100, 23)
        Me.TXTFRESHRATE.TabIndex = 9
        Me.TXTFRESHRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTRAINBOW
        '
        Me.TXTRAINBOW.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTRAINBOW.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRAINBOW.Location = New System.Drawing.Point(996, 17)
        Me.TXTRAINBOW.Name = "TXTRAINBOW"
        Me.TXTRAINBOW.Size = New System.Drawing.Size(100, 23)
        Me.TXTRAINBOW.TabIndex = 8
        Me.TXTRAINBOW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTEXTRADARK
        '
        Me.TXTEXTRADARK.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTEXTRADARK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTEXTRADARK.Location = New System.Drawing.Point(896, 17)
        Me.TXTEXTRADARK.Name = "TXTEXTRADARK"
        Me.TXTEXTRADARK.Size = New System.Drawing.Size(100, 23)
        Me.TXTEXTRADARK.TabIndex = 7
        Me.TXTEXTRADARK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTDARK
        '
        Me.TXTDARK.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTDARK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDARK.Location = New System.Drawing.Point(796, 17)
        Me.TXTDARK.Name = "TXTDARK"
        Me.TXTDARK.Size = New System.Drawing.Size(100, 23)
        Me.TXTDARK.TabIndex = 6
        Me.TXTDARK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTLIGHT
        '
        Me.TXTLIGHT.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTLIGHT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTLIGHT.Location = New System.Drawing.Point(696, 17)
        Me.TXTLIGHT.Name = "TXTLIGHT"
        Me.TXTLIGHT.Size = New System.Drawing.Size(100, 23)
        Me.TXTLIGHT.TabIndex = 5
        Me.TXTLIGHT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTCREAM
        '
        Me.TXTCREAM.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCREAM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCREAM.Location = New System.Drawing.Point(596, 17)
        Me.TXTCREAM.Name = "TXTCREAM"
        Me.TXTCREAM.Size = New System.Drawing.Size(100, 23)
        Me.TXTCREAM.TabIndex = 4
        Me.TXTCREAM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTWHITE
        '
        Me.TXTWHITE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTWHITE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWHITE.Location = New System.Drawing.Point(496, 17)
        Me.TXTWHITE.Name = "TXTWHITE"
        Me.TXTWHITE.Size = New System.Drawing.Size(100, 23)
        Me.TXTWHITE.TabIndex = 3
        Me.TXTWHITE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMDEXCEL
        '
        Me.CMDEXCEL.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXCEL.FlatAppearance.BorderSize = 0
        Me.CMDEXCEL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXCEL.ForeColor = System.Drawing.Color.Black
        Me.CMDEXCEL.Location = New System.Drawing.Point(491, 544)
        Me.CMDEXCEL.Name = "CMDEXCEL"
        Me.CMDEXCEL.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXCEL.TabIndex = 11
        Me.CMDEXCEL.Text = "Excel"
        Me.CMDEXCEL.UseVisualStyleBackColor = False
        '
        'GRIDBILLDETAILS
        '
        Me.GRIDBILLDETAILS.Location = New System.Drawing.Point(19, 41)
        Me.GRIDBILLDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDBILLDETAILS.MainView = Me.GRIDBILL
        Me.GRIDBILLDETAILS.Name = "GRIDBILLDETAILS"
        Me.GRIDBILLDETAILS.Size = New System.Drawing.Size(1211, 497)
        Me.GRIDBILLDETAILS.TabIndex = 10
        Me.GRIDBILLDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBILL})
        '
        'GRIDBILL
        '
        Me.GRIDBILL.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.Row.Options.UseFont = True
        Me.GRIDBILL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GID, Me.GQUALITY, Me.GPIECETYPE, Me.GRATE, Me.GWHITE, Me.GCREAM, Me.GLIGHT, Me.GDARK, Me.GEXTRADARK, Me.GRAINBOW, Me.GFRESHRATE})
        Me.GRIDBILL.GridControl = Me.GRIDBILLDETAILS
        Me.GRIDBILL.Name = "GRIDBILL"
        Me.GRIDBILL.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDBILL.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDBILL.OptionsBehavior.Editable = False
        Me.GRIDBILL.OptionsView.ColumnAutoWidth = False
        Me.GRIDBILL.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDBILL.OptionsView.ShowAutoFilterRow = True
        Me.GRIDBILL.OptionsView.ShowGroupPanel = False
        '
        'GID
        '
        Me.GID.Caption = "ID"
        Me.GID.DisplayFormat.FormatString = "0"
        Me.GID.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GID.FieldName = "ID"
        Me.GID.ImageIndex = 1
        Me.GID.Name = "GID"
        Me.GID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GID.Width = 81
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITYNAME"
        Me.GQUALITY.ImageIndex = 0
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 0
        Me.GQUALITY.Width = 260
        '
        'GPIECETYPE
        '
        Me.GPIECETYPE.Caption = "Piece Type"
        Me.GPIECETYPE.FieldName = "PIECETYPE"
        Me.GPIECETYPE.Name = "GPIECETYPE"
        Me.GPIECETYPE.Visible = True
        Me.GPIECETYPE.VisibleIndex = 1
        Me.GPIECETYPE.Width = 100
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 2
        Me.GRATE.Width = 100
        '
        'GWHITE
        '
        Me.GWHITE.Caption = "White"
        Me.GWHITE.DisplayFormat.FormatString = "0.00"
        Me.GWHITE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWHITE.FieldName = "WHITE"
        Me.GWHITE.Name = "GWHITE"
        Me.GWHITE.Visible = True
        Me.GWHITE.VisibleIndex = 3
        Me.GWHITE.Width = 100
        '
        'GCREAM
        '
        Me.GCREAM.Caption = "Cream"
        Me.GCREAM.DisplayFormat.FormatString = "0.00"
        Me.GCREAM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCREAM.FieldName = "CREAM"
        Me.GCREAM.Name = "GCREAM"
        Me.GCREAM.Visible = True
        Me.GCREAM.VisibleIndex = 4
        Me.GCREAM.Width = 100
        '
        'GLIGHT
        '
        Me.GLIGHT.Caption = "Light"
        Me.GLIGHT.DisplayFormat.FormatString = "0.00"
        Me.GLIGHT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GLIGHT.FieldName = "LIGHT"
        Me.GLIGHT.Name = "GLIGHT"
        Me.GLIGHT.Visible = True
        Me.GLIGHT.VisibleIndex = 5
        Me.GLIGHT.Width = 100
        '
        'GDARK
        '
        Me.GDARK.Caption = "Dark"
        Me.GDARK.DisplayFormat.FormatString = "0.00"
        Me.GDARK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDARK.FieldName = "DARK"
        Me.GDARK.Name = "GDARK"
        Me.GDARK.Visible = True
        Me.GDARK.VisibleIndex = 6
        Me.GDARK.Width = 100
        '
        'GEXTRADARK
        '
        Me.GEXTRADARK.Caption = "Extra Dark"
        Me.GEXTRADARK.DisplayFormat.FormatString = "0.00"
        Me.GEXTRADARK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GEXTRADARK.FieldName = "EXTRADARK"
        Me.GEXTRADARK.Name = "GEXTRADARK"
        Me.GEXTRADARK.Visible = True
        Me.GEXTRADARK.VisibleIndex = 7
        Me.GEXTRADARK.Width = 100
        '
        'GRAINBOW
        '
        Me.GRAINBOW.Caption = "Rainbow"
        Me.GRAINBOW.DisplayFormat.FormatString = "0.00"
        Me.GRAINBOW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRAINBOW.FieldName = "RAINBOW"
        Me.GRAINBOW.Name = "GRAINBOW"
        Me.GRAINBOW.Visible = True
        Me.GRAINBOW.VisibleIndex = 8
        Me.GRAINBOW.Width = 100
        '
        'GFRESHRATE
        '
        Me.GFRESHRATE.Caption = "Fresh Rate"
        Me.GFRESHRATE.DisplayFormat.FormatString = "0.00"
        Me.GFRESHRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFRESHRATE.FieldName = "FRESHRATE"
        Me.GFRESHRATE.Name = "GFRESHRATE"
        Me.GFRESHRATE.Visible = True
        Me.GFRESHRATE.VisibleIndex = 9
        Me.GFRESHRATE.Width = 100
        '
        'CMBPIECETYPE
        '
        Me.CMBPIECETYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPIECETYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPIECETYPE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBPIECETYPE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPIECETYPE.FormattingEnabled = True
        Me.CMBPIECETYPE.Location = New System.Drawing.Point(296, 17)
        Me.CMBPIECETYPE.MaxDropDownItems = 14
        Me.CMBPIECETYPE.Name = "CMBPIECETYPE"
        Me.CMBPIECETYPE.Size = New System.Drawing.Size(100, 23)
        Me.CMBPIECETYPE.TabIndex = 1
        '
        'CMBMERCHANT
        '
        Me.CMBMERCHANT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBMERCHANT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBMERCHANT.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBMERCHANT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBMERCHANT.FormattingEnabled = True
        Me.CMBMERCHANT.Location = New System.Drawing.Point(36, 17)
        Me.CMBMERCHANT.MaxDropDownItems = 14
        Me.CMBMERCHANT.Name = "CMBMERCHANT"
        Me.CMBMERCHANT.Size = New System.Drawing.Size(260, 23)
        Me.CMBMERCHANT.TabIndex = 0
        '
        'TXTRATE
        '
        Me.TXTRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTRATE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRATE.Location = New System.Drawing.Point(396, 17)
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(100, 23)
        Me.TXTRATE.TabIndex = 2
        Me.TXTRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(577, 544)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 12
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'MerchantPriceList
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1248, 582)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "MerchantPriceList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Merchant Price List"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMBMERCHANT As System.Windows.Forms.ComboBox
    Friend WithEvents TXTRATE As System.Windows.Forms.TextBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CMBPIECETYPE As System.Windows.Forms.ComboBox
    Friend WithEvents EP As System.Windows.Forms.ErrorProvider
    Friend WithEvents GRIDBILLDETAILS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDBILL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPIECETYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDEXCEL As Button
    Friend WithEvents TXTRAINBOW As TextBox
    Friend WithEvents TXTEXTRADARK As TextBox
    Friend WithEvents TXTDARK As TextBox
    Friend WithEvents TXTLIGHT As TextBox
    Friend WithEvents TXTCREAM As TextBox
    Friend WithEvents TXTWHITE As TextBox
    Friend WithEvents GWHITE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCREAM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLIGHT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDARK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXTRADARK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRAINBOW As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTFRESHRATE As TextBox
    Friend WithEvents GFRESHRATE As DevExpress.XtraGrid.Columns.GridColumn
End Class
