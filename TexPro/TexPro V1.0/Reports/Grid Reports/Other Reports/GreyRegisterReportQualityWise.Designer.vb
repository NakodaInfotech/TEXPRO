<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GreyRegisterReportQualityWise
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GreyRegisterReportQualityWise))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.cmdexit = New System.Windows.Forms.Button
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GQTY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTALMTRS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPARTYMTRS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GUNCHECKED = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCHECKMTRS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSHORTAGE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.grejected = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GACCEPTED = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPARTYPCS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GUNCHECKEDPCS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCHECKPCS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSHORTAGEPCS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GREJPCS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GACCEPTEDPCS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.lbl = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(992, 573)
        Me.BlendPanel1.TabIndex = 7
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(459, 536)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(75, 29)
        Me.cmdexit.TabIndex = 651
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(9, 54)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(975, 471)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GQUALITY, Me.GQTY, Me.GTOTALMTRS, Me.GPARTYMTRS, Me.GUNCHECKED, Me.GCHECKMTRS, Me.GSHORTAGE, Me.grejected, Me.GACCEPTED, Me.GPARTYPCS, Me.GUNCHECKEDPCS, Me.GCHECKPCS, Me.GSHORTAGEPCS, Me.GREJPCS, Me.GACCEPTEDPCS})
        Me.gridbill.CustomizationFormBounds = New System.Drawing.Rectangle(688, 311, 208, 184)
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 0
        Me.GQUALITY.Width = 100
        '
        'GQTY
        '
        Me.GQTY.Caption = "Total Qty"
        Me.GQTY.DisplayFormat.FormatString = "0.00"
        Me.GQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GQTY.FieldName = "QTY"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GQTY.Visible = True
        Me.GQTY.VisibleIndex = 1
        Me.GQTY.Width = 80
        '
        'GTOTALMTRS
        '
        Me.GTOTALMTRS.AppearanceCell.BackColor = System.Drawing.Color.MistyRose
        Me.GTOTALMTRS.AppearanceCell.Options.UseBackColor = True
        Me.GTOTALMTRS.Caption = "Total Mtrs."
        Me.GTOTALMTRS.DisplayFormat.FormatString = "0.00"
        Me.GTOTALMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALMTRS.FieldName = "MTRS"
        Me.GTOTALMTRS.Name = "GTOTALMTRS"
        Me.GTOTALMTRS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTALMTRS.Visible = True
        Me.GTOTALMTRS.VisibleIndex = 2
        Me.GTOTALMTRS.Width = 90
        '
        'GPARTYMTRS
        '
        Me.GPARTYMTRS.AppearanceCell.BackColor = System.Drawing.Color.Coral
        Me.GPARTYMTRS.AppearanceCell.Options.UseBackColor = True
        Me.GPARTYMTRS.Caption = "Party Mtrs"
        Me.GPARTYMTRS.DisplayFormat.FormatString = "0.00"
        Me.GPARTYMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPARTYMTRS.FieldName = "PARTYMTRS"
        Me.GPARTYMTRS.Name = "GPARTYMTRS"
        Me.GPARTYMTRS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GPARTYMTRS.Visible = True
        Me.GPARTYMTRS.VisibleIndex = 3
        Me.GPARTYMTRS.Width = 90
        '
        'GUNCHECKED
        '
        Me.GUNCHECKED.AppearanceCell.BackColor = System.Drawing.Color.Khaki
        Me.GUNCHECKED.AppearanceCell.Options.UseBackColor = True
        Me.GUNCHECKED.Caption = "Un Checked"
        Me.GUNCHECKED.DisplayFormat.FormatString = "0.00"
        Me.GUNCHECKED.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GUNCHECKED.FieldName = "UNCHECKED"
        Me.GUNCHECKED.Name = "GUNCHECKED"
        Me.GUNCHECKED.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GUNCHECKED.Visible = True
        Me.GUNCHECKED.VisibleIndex = 4
        Me.GUNCHECKED.Width = 90
        '
        'GCHECKMTRS
        '
        Me.GCHECKMTRS.AppearanceCell.BackColor = System.Drawing.Color.Moccasin
        Me.GCHECKMTRS.AppearanceCell.Options.UseBackColor = True
        Me.GCHECKMTRS.Caption = "Check Mtrs"
        Me.GCHECKMTRS.DisplayFormat.FormatString = "0.00"
        Me.GCHECKMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCHECKMTRS.FieldName = "checkmtrs"
        Me.GCHECKMTRS.Name = "GCHECKMTRS"
        Me.GCHECKMTRS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GCHECKMTRS.Visible = True
        Me.GCHECKMTRS.VisibleIndex = 5
        Me.GCHECKMTRS.Width = 90
        '
        'GSHORTAGE
        '
        Me.GSHORTAGE.AppearanceCell.BackColor = System.Drawing.Color.LightCyan
        Me.GSHORTAGE.AppearanceCell.Options.UseBackColor = True
        Me.GSHORTAGE.Caption = "Shortage"
        Me.GSHORTAGE.DisplayFormat.FormatString = "0.00"
        Me.GSHORTAGE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSHORTAGE.FieldName = "SHORTAGE"
        Me.GSHORTAGE.Name = "GSHORTAGE"
        Me.GSHORTAGE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GSHORTAGE.Visible = True
        Me.GSHORTAGE.VisibleIndex = 6
        Me.GSHORTAGE.Width = 90
        '
        'grejected
        '
        Me.grejected.AppearanceCell.BackColor = System.Drawing.Color.LightCoral
        Me.grejected.AppearanceCell.Options.UseBackColor = True
        Me.grejected.Caption = "Rej. Mtrs"
        Me.grejected.DisplayFormat.FormatString = "0.00"
        Me.grejected.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.grejected.FieldName = "rejmtrs"
        Me.grejected.Name = "grejected"
        Me.grejected.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.grejected.Visible = True
        Me.grejected.VisibleIndex = 7
        Me.grejected.Width = 90
        '
        'GACCEPTED
        '
        Me.GACCEPTED.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GACCEPTED.AppearanceCell.Options.UseBackColor = True
        Me.GACCEPTED.Caption = "Accepted Mtrs"
        Me.GACCEPTED.DisplayFormat.FormatString = "0.00"
        Me.GACCEPTED.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GACCEPTED.FieldName = "ACCEPTED"
        Me.GACCEPTED.Name = "GACCEPTED"
        Me.GACCEPTED.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GACCEPTED.Visible = True
        Me.GACCEPTED.VisibleIndex = 8
        Me.GACCEPTED.Width = 90
        '
        'GPARTYPCS
        '
        Me.GPARTYPCS.AppearanceCell.BackColor = System.Drawing.Color.Coral
        Me.GPARTYPCS.AppearanceCell.Options.UseBackColor = True
        Me.GPARTYPCS.Caption = "Party Pcs"
        Me.GPARTYPCS.DisplayFormat.FormatString = "0"
        Me.GPARTYPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPARTYPCS.FieldName = "PARTYPCS"
        Me.GPARTYPCS.Name = "GPARTYPCS"
        Me.GPARTYPCS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '
        'GUNCHECKEDPCS
        '
        Me.GUNCHECKEDPCS.AppearanceCell.BackColor = System.Drawing.Color.Khaki
        Me.GUNCHECKEDPCS.AppearanceCell.Options.UseBackColor = True
        Me.GUNCHECKEDPCS.Caption = "UnChecked Pcs"
        Me.GUNCHECKEDPCS.DisplayFormat.FormatString = "0"
        Me.GUNCHECKEDPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GUNCHECKEDPCS.FieldName = "UNCHECKEDPCS"
        Me.GUNCHECKEDPCS.Name = "GUNCHECKEDPCS"
        Me.GUNCHECKEDPCS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '
        'GCHECKPCS
        '
        Me.GCHECKPCS.AppearanceCell.BackColor = System.Drawing.Color.Moccasin
        Me.GCHECKPCS.AppearanceCell.Options.UseBackColor = True
        Me.GCHECKPCS.Caption = "Check Pcs"
        Me.GCHECKPCS.DisplayFormat.FormatString = "0"
        Me.GCHECKPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCHECKPCS.FieldName = "CHECKPCS"
        Me.GCHECKPCS.Name = "GCHECKPCS"
        Me.GCHECKPCS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GCHECKPCS.Width = 60
        '
        'GSHORTAGEPCS
        '
        Me.GSHORTAGEPCS.AppearanceCell.BackColor = System.Drawing.Color.LightCyan
        Me.GSHORTAGEPCS.AppearanceCell.Options.UseBackColor = True
        Me.GSHORTAGEPCS.Caption = "Short Pcs"
        Me.GSHORTAGEPCS.DisplayFormat.FormatString = "0"
        Me.GSHORTAGEPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSHORTAGEPCS.FieldName = "SHORTAGEPCS"
        Me.GSHORTAGEPCS.Name = "GSHORTAGEPCS"
        Me.GSHORTAGEPCS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GSHORTAGEPCS.Width = 60
        '
        'GREJPCS
        '
        Me.GREJPCS.AppearanceCell.BackColor = System.Drawing.Color.LightCoral
        Me.GREJPCS.AppearanceCell.Options.UseBackColor = True
        Me.GREJPCS.Caption = "Rej Pcs"
        Me.GREJPCS.DisplayFormat.FormatString = "0"
        Me.GREJPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GREJPCS.FieldName = "REJPCS"
        Me.GREJPCS.Name = "GREJPCS"
        Me.GREJPCS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GREJPCS.Width = 60
        '
        'GACCEPTEDPCS
        '
        Me.GACCEPTEDPCS.AppearanceCell.BackColor = System.Drawing.Color.LightBlue
        Me.GACCEPTEDPCS.AppearanceCell.Options.UseBackColor = True
        Me.GACCEPTEDPCS.Caption = "Accepted Pcs"
        Me.GACCEPTEDPCS.DisplayFormat.FormatString = "0"
        Me.GACCEPTEDPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GACCEPTEDPCS.FieldName = "ACCEPTEDPCS"
        Me.GACCEPTEDPCS.Name = "GACCEPTEDPCS"
        Me.GACCEPTEDPCS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintToolStripButton, Me.TOOLREFRESH, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(992, 25)
        Me.ToolStrip1.TabIndex = 255
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
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.TexPro_V1.My.Resources.Resources.refresh1
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "ToolStripButton2"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(19, 34)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(133, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a GRN to Change"
        '
        'GreyRegisterReportQualityWise
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(992, 573)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "GreyRegisterReportQualityWise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Grey Register Report - Quality Wise"
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
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNCHECKED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHECKMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHORTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grejected As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACCEPTED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNCHECKEDPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHECKPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHORTAGEPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREJPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GACCEPTEDPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents TOOLREFRESH As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl As System.Windows.Forms.Label
End Class
