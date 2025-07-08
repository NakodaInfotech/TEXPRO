<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PendingCostReport
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
        Me.cmdok = New System.Windows.Forms.Button
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GFROMPROCESS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOPROCESS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDESIGN = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCONTRACTOR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gpdate = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GJOBNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GSAREE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GLABOURAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDONE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GIMGPATH = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GIMGOURLOCATION = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GAVG = New DevExpress.XtraGrid.Columns.GridColumn
        Me.cmdexit = New System.Windows.Forms.Button
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.TOOLEXCEL = New System.Windows.Forms.ToolStripButton
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1028, 573)
        Me.BlendPanel1.TabIndex = 9
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(436, 537)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(75, 26)
        Me.cmdok.TabIndex = 444
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(25, 41)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(978, 491)
        Me.gridbilldetails.TabIndex = 443
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.GFROMPROCESS, Me.GTOPROCESS, Me.GITEMNAME, Me.GDESIGN, Me.GCONTRACTOR, Me.gpdate, Me.GCOLOR, Me.GJOBNO, Me.GSAREE, Me.GMTRS, Me.GLABOURAMT, Me.GDONE, Me.GIMGPATH, Me.GIMGOURLOCATION, Me.GAVG})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'gsrno
        '
        Me.gsrno.Caption = "Mfg No"
        Me.gsrno.FieldName = "MFGNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 50
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 1
        Me.gdate.Width = 65
        '
        'GFROMPROCESS
        '
        Me.GFROMPROCESS.Caption = "From (Process)"
        Me.GFROMPROCESS.FieldName = "FROMPROCESS"
        Me.GFROMPROCESS.Name = "GFROMPROCESS"
        Me.GFROMPROCESS.Visible = True
        Me.GFROMPROCESS.VisibleIndex = 2
        Me.GFROMPROCESS.Width = 100
        '
        'GTOPROCESS
        '
        Me.GTOPROCESS.Caption = "To (Process)"
        Me.GTOPROCESS.FieldName = "TOPROCESS"
        Me.GTOPROCESS.Name = "GTOPROCESS"
        Me.GTOPROCESS.Visible = True
        Me.GTOPROCESS.VisibleIndex = 3
        Me.GTOPROCESS.Width = 100
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Merchant"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 4
        Me.GITEMNAME.Width = 140
        '
        'GDESIGN
        '
        Me.GDESIGN.Caption = "Design "
        Me.GDESIGN.FieldName = "DESIGN"
        Me.GDESIGN.Name = "GDESIGN"
        Me.GDESIGN.Visible = True
        Me.GDESIGN.VisibleIndex = 5
        Me.GDESIGN.Width = 70
        '
        'GCONTRACTOR
        '
        Me.GCONTRACTOR.Caption = "Contractor"
        Me.GCONTRACTOR.FieldName = "CONTRACTOR"
        Me.GCONTRACTOR.Name = "GCONTRACTOR"
        Me.GCONTRACTOR.Visible = True
        Me.GCONTRACTOR.VisibleIndex = 6
        '
        'gpdate
        '
        Me.gpdate.Caption = "Prd. Date"
        Me.gpdate.FieldName = "PDATE"
        Me.gpdate.Name = "gpdate"
        Me.gpdate.Visible = True
        Me.gpdate.VisibleIndex = 7
        Me.gpdate.Width = 65
        '
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Colors"
        Me.GCOLOR.FieldName = "COLORS"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 8
        Me.GCOLOR.Width = 40
        '
        'GJOBNO
        '
        Me.GJOBNO.Caption = "Job No"
        Me.GJOBNO.FieldName = "JOBNO"
        Me.GJOBNO.Name = "GJOBNO"
        Me.GJOBNO.Visible = True
        Me.GJOBNO.VisibleIndex = 9
        Me.GJOBNO.Width = 60
        '
        'GSAREE
        '
        Me.GSAREE.Caption = "Sarees"
        Me.GSAREE.FieldName = "SAREE"
        Me.GSAREE.Name = "GSAREE"
        Me.GSAREE.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GSAREE.Visible = True
        Me.GSAREE.VisibleIndex = 10
        Me.GSAREE.Width = 50
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Mtrs."
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 11
        Me.GMTRS.Width = 50
        '
        'GLABOURAMT
        '
        Me.GLABOURAMT.Caption = "Amt"
        Me.GLABOURAMT.FieldName = "LABOURAMT"
        Me.GLABOURAMT.Name = "GLABOURAMT"
        Me.GLABOURAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GLABOURAMT.Visible = True
        Me.GLABOURAMT.VisibleIndex = 12
        Me.GLABOURAMT.Width = 60
        '
        'GDONE
        '
        Me.GDONE.Caption = "DONE"
        Me.GDONE.FieldName = "MFGDONE"
        Me.GDONE.Name = "GDONE"
        '
        'GIMGPATH
        '
        Me.GIMGPATH.Caption = "IMGPATH"
        Me.GIMGPATH.FieldName = "IMGPATH"
        Me.GIMGPATH.Name = "GIMGPATH"
        '
        'GIMGOURLOCATION
        '
        Me.GIMGOURLOCATION.Caption = "Ourlocation"
        Me.GIMGOURLOCATION.FieldName = "OURLOCATION"
        Me.GIMGOURLOCATION.Name = "GIMGOURLOCATION"
        '
        'GAVG
        '
        Me.GAVG.Caption = "Avg "
        Me.GAVG.DisplayFormat.FormatString = "0.00"
        Me.GAVG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAVG.FieldName = "AVG"
        Me.GAVG.Name = "GAVG"
        Me.GAVG.Visible = True
        Me.GAVG.VisibleIndex = 13
        Me.GAVG.Width = 60
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(517, 536)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(75, 29)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.TOOLEXCEL, Me.TOOLREFRESH, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1028, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLEXCEL
        '
        Me.TOOLEXCEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLEXCEL.Image = Global.TexPro_V1.My.Resources.Resources.Excel_icon
        Me.TOOLEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLEXCEL.Name = "TOOLEXCEL"
        Me.TOOLEXCEL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLEXCEL.Text = "ToolStripButton2"
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
        'PendingCostReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1028, 573)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PendingCostReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Pending Cost Report"
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
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TOOLEXCEL As System.Windows.Forms.ToolStripButton
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMPROCESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOPROCESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESIGN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCONTRACTOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gpdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOBNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSAREE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLABOURAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDONE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIMGPATH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIMGOURLOCATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAVG As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLREFRESH As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdok As System.Windows.Forms.Button
End Class
