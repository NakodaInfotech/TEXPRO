<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StoreStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StoreStock))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CHKALL = New System.Windows.Forms.CheckBox
        Me.RDSTOCKCONSUMPTION = New System.Windows.Forms.RadioButton
        Me.RDSTOCKVALUE = New System.Windows.Forms.RadioButton
        Me.RDSTOCK = New System.Windows.Forms.RadioButton
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GDEPARTMENT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GOPENING = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GVALUE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GINWARDS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GINVALUE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GRETURNING = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GOUTVALUE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDESPATCH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDESVALUE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBALANCE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBALVALUE = New DevExpress.XtraGrid.Columns.GridColumn
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
        resources.ApplyResources(Me.BlendPanel1, "BlendPanel1")
        Me.BlendPanel1.Controls.Add(Me.CHKALL)
        Me.BlendPanel1.Controls.Add(Me.RDSTOCKCONSUMPTION)
        Me.BlendPanel1.Controls.Add(Me.RDSTOCKVALUE)
        Me.BlendPanel1.Controls.Add(Me.RDSTOCK)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Name = "BlendPanel1"
        '
        'CHKALL
        '
        resources.ApplyResources(Me.CHKALL, "CHKALL")
        Me.CHKALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKALL.Name = "CHKALL"
        Me.CHKALL.UseVisualStyleBackColor = False
        '
        'RDSTOCKCONSUMPTION
        '
        resources.ApplyResources(Me.RDSTOCKCONSUMPTION, "RDSTOCKCONSUMPTION")
        Me.RDSTOCKCONSUMPTION.BackColor = System.Drawing.Color.Transparent
        Me.RDSTOCKCONSUMPTION.Name = "RDSTOCKCONSUMPTION"
        Me.RDSTOCKCONSUMPTION.UseVisualStyleBackColor = False
        '
        'RDSTOCKVALUE
        '
        resources.ApplyResources(Me.RDSTOCKVALUE, "RDSTOCKVALUE")
        Me.RDSTOCKVALUE.BackColor = System.Drawing.Color.Transparent
        Me.RDSTOCKVALUE.Name = "RDSTOCKVALUE"
        Me.RDSTOCKVALUE.UseVisualStyleBackColor = False
        '
        'RDSTOCK
        '
        resources.ApplyResources(Me.RDSTOCK, "RDSTOCK")
        Me.RDSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.RDSTOCK.Name = "RDSTOCK"
        Me.RDSTOCK.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        resources.ApplyResources(Me.gridbilldetails, "gridbilldetails")
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GDEPARTMENT, Me.GITEMNAME, Me.GRATE, Me.GOPENING, Me.GVALUE, Me.GINWARDS, Me.GINVALUE, Me.GRETURNING, Me.GOUTVALUE, Me.GDESPATCH, Me.GDESVALUE, Me.GBALANCE, Me.GBALVALUE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GDEPARTMENT
        '
        resources.ApplyResources(Me.GDEPARTMENT, "GDEPARTMENT")
        Me.GDEPARTMENT.FieldName = "DEPARTMENT"
        Me.GDEPARTMENT.Name = "GDEPARTMENT"
        '
        'GITEMNAME
        '
        resources.ApplyResources(Me.GITEMNAME, "GITEMNAME")
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        '
        'GRATE
        '
        Me.GRATE.AppearanceCell.BackColor = System.Drawing.Color.Linen
        Me.GRATE.AppearanceCell.Options.UseBackColor = True
        resources.ApplyResources(Me.GRATE, "GRATE")
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        '
        'GOPENING
        '
        resources.ApplyResources(Me.GOPENING, "GOPENING")
        Me.GOPENING.DisplayFormat.FormatString = "0.00"
        Me.GOPENING.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOPENING.FieldName = "OPENING"
        Me.GOPENING.Name = "GOPENING"
        Me.GOPENING.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '
        'GVALUE
        '
        Me.GVALUE.AppearanceCell.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.GVALUE.AppearanceCell.Options.UseBackColor = True
        resources.ApplyResources(Me.GVALUE, "GVALUE")
        Me.GVALUE.DisplayFormat.FormatString = "0.00"
        Me.GVALUE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GVALUE.FieldName = "OPVALUE"
        Me.GVALUE.Name = "GVALUE"
        Me.GVALUE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '
        'GINWARDS
        '
        Me.GINWARDS.AppearanceCell.BackColor = System.Drawing.Color.LightGreen
        Me.GINWARDS.AppearanceCell.Options.UseBackColor = True
        resources.ApplyResources(Me.GINWARDS, "GINWARDS")
        Me.GINWARDS.DisplayFormat.FormatString = "0.00"
        Me.GINWARDS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GINWARDS.FieldName = "INWARDS"
        Me.GINWARDS.Name = "GINWARDS"
        Me.GINWARDS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '
        'GINVALUE
        '
        Me.GINVALUE.AppearanceCell.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.GINVALUE.AppearanceCell.Options.UseBackColor = True
        resources.ApplyResources(Me.GINVALUE, "GINVALUE")
        Me.GINVALUE.DisplayFormat.FormatString = "0.00"
        Me.GINVALUE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GINVALUE.FieldName = "INVALUE"
        Me.GINVALUE.Name = "GINVALUE"
        Me.GINVALUE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '
        'GRETURNING
        '
        Me.GRETURNING.AppearanceCell.BackColor = System.Drawing.Color.Orange
        Me.GRETURNING.AppearanceCell.Options.UseBackColor = True
        resources.ApplyResources(Me.GRETURNING, "GRETURNING")
        Me.GRETURNING.DisplayFormat.FormatString = "0.00"
        Me.GRETURNING.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRETURNING.FieldName = "RETURNING"
        Me.GRETURNING.Name = "GRETURNING"
        Me.GRETURNING.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '
        'GOUTVALUE
        '
        Me.GOUTVALUE.AppearanceCell.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.GOUTVALUE.AppearanceCell.Options.UseBackColor = True
        resources.ApplyResources(Me.GOUTVALUE, "GOUTVALUE")
        Me.GOUTVALUE.DisplayFormat.FormatString = "0.00"
        Me.GOUTVALUE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GOUTVALUE.FieldName = "OUTVALUE"
        Me.GOUTVALUE.Name = "GOUTVALUE"
        Me.GOUTVALUE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '
        'GDESPATCH
        '
        Me.GDESPATCH.AppearanceCell.BackColor = System.Drawing.Color.MistyRose
        Me.GDESPATCH.AppearanceCell.Options.UseBackColor = True
        resources.ApplyResources(Me.GDESPATCH, "GDESPATCH")
        Me.GDESPATCH.DisplayFormat.FormatString = "0.00"
        Me.GDESPATCH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDESPATCH.FieldName = "DESPATCH"
        Me.GDESPATCH.Name = "GDESPATCH"
        Me.GDESPATCH.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '
        'GDESVALUE
        '
        Me.GDESVALUE.AppearanceCell.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.GDESVALUE.AppearanceCell.Options.UseBackColor = True
        resources.ApplyResources(Me.GDESVALUE, "GDESVALUE")
        Me.GDESVALUE.DisplayFormat.FormatString = "0.00"
        Me.GDESVALUE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDESVALUE.FieldName = "DESVALUE"
        Me.GDESVALUE.Name = "GDESVALUE"
        Me.GDESVALUE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '
        'GBALANCE
        '
        Me.GBALANCE.AppearanceCell.BackColor = System.Drawing.Color.LightSalmon
        Me.GBALANCE.AppearanceCell.Options.UseBackColor = True
        resources.ApplyResources(Me.GBALANCE, "GBALANCE")
        Me.GBALANCE.DisplayFormat.FormatString = "0.00"
        Me.GBALANCE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALANCE.FieldName = "BALANCE"
        Me.GBALANCE.Name = "GBALANCE"
        Me.GBALANCE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '
        'GBALVALUE
        '
        Me.GBALVALUE.AppearanceCell.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.GBALVALUE.AppearanceCell.Options.UseBackColor = True
        resources.ApplyResources(Me.GBALVALUE, "GBALVALUE")
        Me.GBALVALUE.DisplayFormat.FormatString = "0.00"
        Me.GBALVALUE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBALVALUE.FieldName = "BALVALUE"
        Me.GBALVALUE.Name = "GBALVALUE"
        Me.GBALVALUE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        resources.ApplyResources(Me.cmdexit, "cmdexit")
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.ToolStripButton2})
        resources.ApplyResources(Me.ToolStrip1, "ToolStrip1")
        Me.ToolStrip1.Name = "ToolStrip1"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        resources.ApplyResources(Me.toolStripSeparator, "toolStripSeparator")
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.TexPro_V1.My.Resources.Resources.Excel_icon
        resources.ApplyResources(Me.ToolStripButton2, "ToolStripButton2")
        Me.ToolStripButton2.Name = "ToolStripButton2"
        '
        'StoreStock
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "StoreStock"
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
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOPENING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINWARDS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRETURNING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESPATCH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVALUE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINVALUE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOUTVALUE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESVALUE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALVALUE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDEPARTMENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RDSTOCKCONSUMPTION As System.Windows.Forms.RadioButton
    Friend WithEvents RDSTOCKVALUE As System.Windows.Forms.RadioButton
    Friend WithEvents RDSTOCK As System.Windows.Forms.RadioButton
    Friend WithEvents CHKALL As System.Windows.Forms.CheckBox
End Class
