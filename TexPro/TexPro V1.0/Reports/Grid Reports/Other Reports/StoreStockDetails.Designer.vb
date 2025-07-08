<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StoreStockDetails
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GDEPARTMENT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GINWARDS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GINVALUE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GRETURNING = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GOUTVALUE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDESPATCH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDESVALUE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cmdexit = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1110, 562)
        Me.BlendPanel1.TabIndex = 10
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbilldetails.Location = New System.Drawing.Point(12, 38)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1087, 490)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GDEPARTMENT, Me.GITEMNAME, Me.GRATE, Me.GINWARDS, Me.GINVALUE, Me.GRETURNING, Me.GOUTVALUE, Me.GDESPATCH, Me.GDESVALUE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GDEPARTMENT
        '
        Me.GDEPARTMENT.Caption = "Deaprtment"
        Me.GDEPARTMENT.FieldName = "DEPARTMENT"
        Me.GDEPARTMENT.Name = "GDEPARTMENT"
        Me.GDEPARTMENT.Visible = True
        Me.GDEPARTMENT.VisibleIndex = 0
        Me.GDEPARTMENT.Width = 130
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 1
        Me.GITEMNAME.Width = 230
        '
        'GRATE
        '
        Me.GRATE.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GRATE.AppearanceCell.Options.UseBackColor = True
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 2
        Me.GRATE.Width = 80
        '
        'GINWARDS
        '
        Me.GINWARDS.Caption = "Inwards"
        Me.GINWARDS.DisplayFormat.FormatString = "0.00"
        Me.GINWARDS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GINWARDS.FieldName = "INWARDS"
        Me.GINWARDS.Name = "GINWARDS"
        Me.GINWARDS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GINWARDS.Visible = True
        Me.GINWARDS.VisibleIndex = 3
        Me.GINWARDS.Width = 100
        '
        'GINVALUE
        '
        Me.GINVALUE.AppearanceCell.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.GINVALUE.AppearanceCell.Options.UseBackColor = True
        Me.GINVALUE.Caption = "Value"
        Me.GINVALUE.DisplayFormat.FormatString = "0.00"
        Me.GINVALUE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GINVALUE.FieldName = "INVALUE"
        Me.GINVALUE.Name = "GINVALUE"
        Me.GINVALUE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GINVALUE.Visible = True
        Me.GINVALUE.VisibleIndex = 4
        Me.GINVALUE.Width = 100
        '
        'GRETURNING
        '
        Me.GRETURNING.Caption = "Outward"
        Me.GRETURNING.DisplayFormat.FormatString = "0.00"
        Me.GRETURNING.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRETURNING.FieldName = "RETURNING"
        Me.GRETURNING.Name = "GRETURNING"
        Me.GRETURNING.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GRETURNING.Visible = True
        Me.GRETURNING.VisibleIndex = 5
        Me.GRETURNING.Width = 100
        '
        'GOUTVALUE
        '
        Me.GOUTVALUE.AppearanceCell.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.GOUTVALUE.AppearanceCell.Options.UseBackColor = True
        Me.GOUTVALUE.Caption = "Value"
        Me.GOUTVALUE.DisplayFormat.FormatString = "0.00"
        Me.GOUTVALUE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOUTVALUE.FieldName = "OUTVALUE"
        Me.GOUTVALUE.Name = "GOUTVALUE"
        Me.GOUTVALUE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GOUTVALUE.Visible = True
        Me.GOUTVALUE.VisibleIndex = 6
        Me.GOUTVALUE.Width = 100
        '
        'GDESPATCH
        '
        Me.GDESPATCH.AppearanceCell.BackColor = System.Drawing.Color.MistyRose
        Me.GDESPATCH.AppearanceCell.Options.UseBackColor = True
        Me.GDESPATCH.Caption = "Despatch"
        Me.GDESPATCH.DisplayFormat.FormatString = "0.00"
        Me.GDESPATCH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDESPATCH.FieldName = "DESPATCH"
        Me.GDESPATCH.Name = "GDESPATCH"
        Me.GDESPATCH.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GDESPATCH.Visible = True
        Me.GDESPATCH.VisibleIndex = 7
        Me.GDESPATCH.Width = 100
        '
        'GDESVALUE
        '
        Me.GDESVALUE.AppearanceCell.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.GDESVALUE.AppearanceCell.Options.UseBackColor = True
        Me.GDESVALUE.Caption = "Value"
        Me.GDESVALUE.DisplayFormat.FormatString = "0.00"
        Me.GDESVALUE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDESVALUE.FieldName = "DESVALUE"
        Me.GDESVALUE.Name = "GDESVALUE"
        Me.GDESVALUE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GDESVALUE.Visible = True
        Me.GDESVALUE.VisibleIndex = 8
        Me.GDESVALUE.Width = 100
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdexit.Location = New System.Drawing.Point(518, 533)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(75, 26)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1110, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.TexPro_V1.My.Resources.Resources.Excel_icon
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'StoreStockDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1110, 562)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StoreStockDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Store Stock Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GDEPARTMENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINWARDS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINVALUE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRETURNING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOUTVALUE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESPATCH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESVALUE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
End Class
