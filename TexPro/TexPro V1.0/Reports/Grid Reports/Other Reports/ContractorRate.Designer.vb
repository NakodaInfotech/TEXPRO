<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContractorRate
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
        Me.CMDPRINT = New System.Windows.Forms.Button
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GCONTRACTOR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GMERCHANT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDESIGN = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCOLORS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cmdexit = New System.Windows.Forms.Button
        Me.lblheading = New System.Windows.Forms.Label
        Me.GHELPERS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCOST = New DevExpress.XtraGrid.Columns.GridColumn
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDPRINT)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.lblheading)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1094, 573)
        Me.BlendPanel1.TabIndex = 5
        '
        'CMDPRINT
        '
        Me.CMDPRINT.BackColor = System.Drawing.Color.Transparent
        Me.CMDPRINT.BackgroundImage = Global.TexPro_V1.My.Resources.Resources.Excel_icon
        Me.CMDPRINT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDPRINT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDPRINT.FlatAppearance.BorderSize = 0
        Me.CMDPRINT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDPRINT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDPRINT.Location = New System.Drawing.Point(1042, 9)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(25, 25)
        Me.CMDPRINT.TabIndex = 502
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(28, 37)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1039, 498)
        Me.gridbilldetails.TabIndex = 495
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCONTRACTOR, Me.GMERCHANT, Me.GDESIGN, Me.GCOLORS, Me.GMTRS, Me.GRATE, Me.GAMT, Me.GHELPERS, Me.GCOST})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupedColumns = True
        '
        'GCONTRACTOR
        '
        Me.GCONTRACTOR.Caption = "Contractor"
        Me.GCONTRACTOR.FieldName = "CONTRACTOR"
        Me.GCONTRACTOR.Name = "GCONTRACTOR"
        Me.GCONTRACTOR.OptionsColumn.AllowEdit = False
        Me.GCONTRACTOR.Visible = True
        Me.GCONTRACTOR.VisibleIndex = 0
        Me.GCONTRACTOR.Width = 220
        '
        'GMERCHANT
        '
        Me.GMERCHANT.Caption = "Merchant Name"
        Me.GMERCHANT.FieldName = "MERCHANT"
        Me.GMERCHANT.Name = "GMERCHANT"
        Me.GMERCHANT.OptionsColumn.AllowEdit = False
        Me.GMERCHANT.Visible = True
        Me.GMERCHANT.VisibleIndex = 1
        Me.GMERCHANT.Width = 200
        '
        'GDESIGN
        '
        Me.GDESIGN.Caption = "Design"
        Me.GDESIGN.FieldName = "DESIGNNO"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.OptionsColumn.AllowEdit = False
        Me.GDESIGN.Visible = True
        Me.GDESIGN.VisibleIndex = 2
        '
        'GCOLORS
        '
        Me.GCOLORS.Caption = "Colors"
        Me.GCOLORS.FieldName = "COLORS"
        Me.GCOLORS.Name = "GCOLORS"
        Me.GCOLORS.OptionsColumn.AllowEdit = False
        Me.GCOLORS.Visible = True
        Me.GCOLORS.VisibleIndex = 3
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Mtrs"
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.OptionsColumn.AllowEdit = False
        Me.GMTRS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 4
        Me.GMTRS.Width = 100
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.OptionsColumn.AllowEdit = False
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 5
        '
        'GAMT
        '
        Me.GAMT.Caption = "Amount"
        Me.GAMT.DisplayFormat.FormatString = "0.00"
        Me.GAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAMT.FieldName = "AMT"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.OptionsColumn.AllowEdit = False
        Me.GAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GAMT.Visible = True
        Me.GAMT.VisibleIndex = 6
        Me.GAMT.Width = 90
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
        Me.cmdexit.Location = New System.Drawing.Point(511, 542)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 24)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'lblheading
        '
        Me.lblheading.AutoSize = True
        Me.lblheading.BackColor = System.Drawing.Color.Transparent
        Me.lblheading.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheading.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblheading.Location = New System.Drawing.Point(16, 10)
        Me.lblheading.Name = "lblheading"
        Me.lblheading.Size = New System.Drawing.Size(147, 23)
        Me.lblheading.TabIndex = 315
        Me.lblheading.Text = "Contractor Detail"
        '
        'GHELPERS
        '
        Me.GHELPERS.Caption = "Helpers"
        Me.GHELPERS.FieldName = "HELPERS"
        Me.GHELPERS.Name = "GHELPERS"
        Me.GHELPERS.Visible = True
        Me.GHELPERS.VisibleIndex = 7
        '
        'GCOST
        '
        Me.GCOST.Caption = "Cost"
        Me.GCOST.DisplayFormat.FormatString = "0.00"
        Me.GCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOST.FieldName = "COST"
        Me.GCOST.Name = "GCOST"
        Me.GCOST.OptionsColumn.AllowEdit = False
        Me.GCOST.Visible = True
        Me.GCOST.VisibleIndex = 8
        '
        'ContractorRate
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1094, 573)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ContractorRate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Contractor Rate"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDPRINT As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lblheading As System.Windows.Forms.Label
    Friend WithEvents GCONTRACTOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOLORS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMERCHANT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHELPERS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOST As DevExpress.XtraGrid.Columns.GridColumn
End Class
