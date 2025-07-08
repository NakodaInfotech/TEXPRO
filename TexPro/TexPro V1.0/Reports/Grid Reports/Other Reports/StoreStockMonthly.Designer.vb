<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StoreStockMonthly
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
        Me.TXTCLOSING = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CMDDETAILS = New System.Windows.Forms.Button
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GMONTHNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GINWARDS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GRETURNING = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDESPATCH = New DevExpress.XtraGrid.Columns.GridColumn
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
        Me.BlendPanel1.Controls.Add(Me.TXTCLOSING)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.CMDDETAILS)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(516, 464)
        Me.BlendPanel1.TabIndex = 10
        '
        'TXTCLOSING
        '
        Me.TXTCLOSING.BackColor = System.Drawing.Color.LightGreen
        Me.TXTCLOSING.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCLOSING.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCLOSING.Location = New System.Drawing.Point(416, 426)
        Me.TXTCLOSING.Name = "TXTCLOSING"
        Me.TXTCLOSING.Size = New System.Drawing.Size(83, 22)
        Me.TXTCLOSING.TabIndex = 438
        Me.TXTCLOSING.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(336, 430)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 14)
        Me.Label3.TabIndex = 439
        Me.Label3.Text = "Closing Stock"
        '
        'CMDDETAILS
        '
        Me.CMDDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.CMDDETAILS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDDETAILS.FlatAppearance.BorderSize = 0
        Me.CMDDETAILS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDETAILS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDDETAILS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CMDDETAILS.Location = New System.Drawing.Point(180, 422)
        Me.CMDDETAILS.Name = "CMDDETAILS"
        Me.CMDDETAILS.Size = New System.Drawing.Size(75, 26)
        Me.CMDDETAILS.TabIndex = 257
        Me.CMDDETAILS.Text = "Details"
        Me.CMDDETAILS.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.gridbilldetails.Location = New System.Drawing.Point(17, 38)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(482, 375)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GMONTHNAME, Me.GINWARDS, Me.GRETURNING, Me.GDESPATCH})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GMONTHNAME
        '
        Me.GMONTHNAME.Caption = "Month"
        Me.GMONTHNAME.FieldName = "MONTHNAME"
        Me.GMONTHNAME.Name = "GMONTHNAME"
        Me.GMONTHNAME.Visible = True
        Me.GMONTHNAME.VisibleIndex = 0
        Me.GMONTHNAME.Width = 120
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
        Me.GINWARDS.VisibleIndex = 1
        Me.GINWARDS.Width = 100
        '
        'GRETURNING
        '
        Me.GRETURNING.Caption = "Outward / Loan"
        Me.GRETURNING.DisplayFormat.FormatString = "0.00"
        Me.GRETURNING.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRETURNING.FieldName = "RETURNING"
        Me.GRETURNING.Name = "GRETURNING"
        Me.GRETURNING.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GRETURNING.Visible = True
        Me.GRETURNING.VisibleIndex = 2
        Me.GRETURNING.Width = 100
        '
        'GDESPATCH
        '
        Me.GDESPATCH.AppearanceCell.BackColor = System.Drawing.Color.MistyRose
        Me.GDESPATCH.AppearanceCell.Options.UseBackColor = True
        Me.GDESPATCH.Caption = "Consume"
        Me.GDESPATCH.DisplayFormat.FormatString = "0.00"
        Me.GDESPATCH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDESPATCH.FieldName = "DESPATCH"
        Me.GDESPATCH.Name = "GDESPATCH"
        Me.GDESPATCH.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GDESPATCH.Visible = True
        Me.GDESPATCH.VisibleIndex = 3
        Me.GDESPATCH.Width = 100
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdexit.Location = New System.Drawing.Point(261, 422)
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
        Me.ToolStrip1.Size = New System.Drawing.Size(516, 25)
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
        'StoreStockMonthly
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(516, 464)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "StoreStockMonthly"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Store Stock Monthly"
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
    Friend WithEvents GMONTHNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINWARDS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRETURNING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESPATCH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents CMDDETAILS As System.Windows.Forms.Button
    Friend WithEvents TXTCLOSING As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
