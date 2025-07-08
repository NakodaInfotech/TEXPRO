<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LOTDETAILS
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
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGREY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GINWARD = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GISSUEMTRS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBALANCE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cmdexit = New System.Windows.Forms.Button
        Me.lblheading = New System.Windows.Forms.Label
        Me.GProcess = New DevExpress.XtraGrid.Columns.GridColumn
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
        Me.BlendPanel1.Size = New System.Drawing.Size(992, 573)
        Me.BlendPanel1.TabIndex = 4
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
        Me.CMDPRINT.Location = New System.Drawing.Point(955, 10)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(25, 21)
        Me.CMDPRINT.TabIndex = 502
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(23, 37)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(957, 493)
        Me.gridbilldetails.TabIndex = 495
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GLOTNO, Me.GGREY, Me.GINWARD, Me.GISSUEMTRS, Me.GBALANCE, Me.GProcess})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 0
        Me.GLOTNO.Width = 60
        '
        'GGREY
        '
        Me.GGREY.Caption = "Grey Mtrs"
        Me.GGREY.FieldName = "GREYMTRS"
        Me.GGREY.Name = "GGREY"
        Me.GGREY.SummaryItem.FieldName = "OPMTRS"
        Me.GGREY.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GGREY.Visible = True
        Me.GGREY.VisibleIndex = 1
        '
        'GINWARD
        '
        Me.GINWARD.Caption = "IN MTRS"
        Me.GINWARD.FieldName = "INMTRS"
        Me.GINWARD.Name = "GINWARD"
        Me.GINWARD.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GINWARD.Visible = True
        Me.GINWARD.VisibleIndex = 2
        '
        'GISSUEMTRS
        '
        Me.GISSUEMTRS.Caption = "ISSUE MTRS"
        Me.GISSUEMTRS.FieldName = "ISSUE MTRS"
        Me.GISSUEMTRS.Name = "GISSUEMTRS"
        Me.GISSUEMTRS.SummaryItem.FieldName = "ISSUE"
        Me.GISSUEMTRS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GISSUEMTRS.Visible = True
        Me.GISSUEMTRS.VisibleIndex = 3
        '
        'GBALANCE
        '
        Me.GBALANCE.Caption = "BALANCE"
        Me.GBALANCE.FieldName = "BALANCE"
        Me.GBALANCE.Name = "GBALANCE"
        Me.GBALANCE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GBALANCE.Visible = True
        Me.GBALANCE.VisibleIndex = 4
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
        Me.cmdexit.Location = New System.Drawing.Point(460, 538)
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
        Me.lblheading.Location = New System.Drawing.Point(16, 5)
        Me.lblheading.Name = "lblheading"
        Me.lblheading.Size = New System.Drawing.Size(87, 23)
        Me.lblheading.TabIndex = 315
        Me.lblheading.Text = "Lot Detail"
        '
        'GProcess
        '
        Me.GProcess.Caption = "PROCESS"
        Me.GProcess.FieldName = "PROCESS"
        Me.GProcess.Name = "GProcess"
        Me.GProcess.Visible = True
        Me.GProcess.VisibleIndex = 5
        '
        'LOTDETAILS
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(992, 573)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "LOTDETAILS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Lot Details"
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
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGREY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINWARD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSUEMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBALANCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents lblheading As System.Windows.Forms.Label
    Friend WithEvents GProcess As DevExpress.XtraGrid.Columns.GridColumn
End Class
