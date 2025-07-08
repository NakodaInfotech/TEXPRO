<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemReport
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
        Me.cmdexit = New System.Windows.Forms.Button
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GRNNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCHALLANNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GITEM = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCHALLANDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDESC = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GQTY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GGROSSRATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNETTRATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GBILLNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GTOTAL = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNETTAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDEPARTMENT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPARTYRATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GDESCRATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCHQNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GCHQDATE = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GPAIDAMT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.BlendPanel1 = New VbPowerPack.BlendPanel
        Me.CHKALL = New System.Windows.Forms.CheckBox
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(477, 536)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(75, 29)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(13, 50)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1003, 480)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GDATE, Me.GRNNO, Me.GCHALLANNO, Me.GITEM, Me.GCHALLANDATE, Me.GDESC, Me.GQTY, Me.GGROSSRATE, Me.GNETTRATE, Me.GBILLNO, Me.GTOTAL, Me.GNETTAMT, Me.GNAME, Me.GCATEGORY, Me.GDEPARTMENT, Me.GRATE, Me.GPARTYRATE, Me.GDESCRATE, Me.GCHQNO, Me.GCHQDATE, Me.GPAIDAMT})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GDATE
        '
        Me.GDATE.Caption = "GRN Date"
        Me.GDATE.FieldName = "GRNDATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 0
        Me.GDATE.Width = 70
        '
        'GRNNO
        '
        Me.GRNNO.Caption = "G.R.N. No"
        Me.GRNNO.FieldName = "GRNNO"
        Me.GRNNO.Name = "GRNNO"
        Me.GRNNO.Visible = True
        Me.GRNNO.VisibleIndex = 1
        Me.GRNNO.Width = 70
        '
        'GCHALLANNO
        '
        Me.GCHALLANNO.Caption = "Challan No"
        Me.GCHALLANNO.FieldName = "CHALLANNO"
        Me.GCHALLANNO.Name = "GCHALLANNO"
        Me.GCHALLANNO.Visible = True
        Me.GCHALLANNO.VisibleIndex = 2
        '
        'GITEM
        '
        Me.GITEM.Caption = "Item Name"
        Me.GITEM.FieldName = "ITEMNAME"
        Me.GITEM.Name = "GITEM"
        Me.GITEM.Visible = True
        Me.GITEM.VisibleIndex = 3
        Me.GITEM.Width = 180
        '
        'GCHALLANDATE
        '
        Me.GCHALLANDATE.Caption = "Challan Date"
        Me.GCHALLANDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GCHALLANDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCHALLANDATE.FieldName = "CHALLANDATE"
        Me.GCHALLANDATE.Name = "GCHALLANDATE"
        '
        'GDESC
        '
        Me.GDESC.Caption = "Desc"
        Me.GDESC.FieldName = "DESC"
        Me.GDESC.Name = "GDESC"
        Me.GDESC.Width = 100
        '
        'GQTY
        '
        Me.GQTY.Caption = "Qty."
        Me.GQTY.FieldName = "QTY"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GQTY.Visible = True
        Me.GQTY.VisibleIndex = 4
        Me.GQTY.Width = 70
        '
        'GGROSSRATE
        '
        Me.GGROSSRATE.Caption = "Gross Rate"
        Me.GGROSSRATE.DisplayFormat.FormatString = "0.00"
        Me.GGROSSRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GGROSSRATE.FieldName = "GROSSRATE"
        Me.GGROSSRATE.Name = "GGROSSRATE"
        Me.GGROSSRATE.Visible = True
        Me.GGROSSRATE.VisibleIndex = 5
        '
        'GNETTRATE
        '
        Me.GNETTRATE.Caption = "Nett Rate"
        Me.GNETTRATE.DisplayFormat.FormatString = "0.00"
        Me.GNETTRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNETTRATE.FieldName = "NETTRATE"
        Me.GNETTRATE.Name = "GNETTRATE"
        Me.GNETTRATE.Visible = True
        Me.GNETTRATE.VisibleIndex = 6
        '
        'GBILLNO
        '
        Me.GBILLNO.Caption = "Bill No."
        Me.GBILLNO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBILLNO.FieldName = "BILLNO"
        Me.GBILLNO.Name = "GBILLNO"
        Me.GBILLNO.Visible = True
        Me.GBILLNO.VisibleIndex = 7
        '
        'GTOTAL
        '
        Me.GTOTAL.Caption = "Bill Amt."
        Me.GTOTAL.DisplayFormat.FormatString = "0.00"
        Me.GTOTAL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTAL.FieldName = "TOTAL"
        Me.GTOTAL.Name = "GTOTAL"
        Me.GTOTAL.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GTOTAL.Visible = True
        Me.GTOTAL.VisibleIndex = 8
        '
        'GNETTAMT
        '
        Me.GNETTAMT.Caption = "Nett Amt"
        Me.GNETTAMT.DisplayFormat.FormatString = "0.00"
        Me.GNETTAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNETTAMT.FieldName = "NETTAMT"
        Me.GNETTAMT.Name = "GNETTAMT"
        Me.GNETTAMT.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        Me.GNETTAMT.Visible = True
        Me.GNETTAMT.VisibleIndex = 9
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "PARTYNAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 10
        Me.GNAME.Width = 180
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category"
        Me.GCATEGORY.FieldName = "CATEGORY"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.Width = 150
        '
        'GDEPARTMENT
        '
        Me.GDEPARTMENT.Caption = "Department"
        Me.GDEPARTMENT.FieldName = "DEPARTMENT"
        Me.GDEPARTMENT.Name = "GDEPARTMENT"
        Me.GDEPARTMENT.Width = 150
        '
        'GRATE
        '
        Me.GRATE.Caption = "Master Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "MASTERRATE"
        Me.GRATE.Name = "GRATE"
        '
        'GPARTYRATE
        '
        Me.GPARTYRATE.Caption = "Party Rate"
        Me.GPARTYRATE.FieldName = "PARTYBILLRATE"
        Me.GPARTYRATE.Name = "GPARTYRATE"
        '
        'GDESCRATE
        '
        Me.GDESCRATE.Caption = "Disco.Rate"
        Me.GDESCRATE.DisplayFormat.FormatString = "0.00"
        Me.GDESCRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDESCRATE.FieldName = "DISCRATE"
        Me.GDESCRATE.Name = "GDESCRATE"
        '
        'GCHQNO
        '
        Me.GCHQNO.Caption = "Chq No"
        Me.GCHQNO.FieldName = "CHQNO"
        Me.GCHQNO.Name = "GCHQNO"
        Me.GCHQNO.Visible = True
        Me.GCHQNO.VisibleIndex = 11
        '
        'GCHQDATE
        '
        Me.GCHQDATE.Caption = "Chq Date"
        Me.GCHQDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GCHQDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCHQDATE.FieldName = "CHQDATE"
        Me.GCHQDATE.Name = "GCHQDATE"
        Me.GCHQDATE.Visible = True
        Me.GCHQDATE.VisibleIndex = 12
        '
        'GPAIDAMT
        '
        Me.GPAIDAMT.Caption = "Paid Amt"
        Me.GPAIDAMT.DisplayFormat.FormatString = "0.00"
        Me.GPAIDAMT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPAIDAMT.FieldName = "PAIDAMT"
        Me.GPAIDAMT.Name = "GPAIDAMT"
        Me.GPAIDAMT.Visible = True
        Me.GPAIDAMT.VisibleIndex = 13
        Me.GPAIDAMT.Width = 80
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1028, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKALL)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1028, 572)
        Me.BlendPanel1.TabIndex = 8
        '
        'CHKALL
        '
        Me.CHKALL.AutoSize = True
        Me.CHKALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKALL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CHKALL.Location = New System.Drawing.Point(868, 29)
        Me.CHKALL.Name = "CHKALL"
        Me.CHKALL.Size = New System.Drawing.Size(146, 19)
        Me.CHKALL.TabIndex = 261
        Me.CHKALL.Text = "Show All Departments"
        Me.CHKALL.UseVisualStyleBackColor = False
        '
        'ItemReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1028, 572)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ItemReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Item Wise Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GRNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHALLANNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBILLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents GCHALLANDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESCRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROSSRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNETTRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDEPARTMENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKALL As System.Windows.Forms.CheckBox
    Friend WithEvents GCHQNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHQDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPAIDAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNETTAMT As DevExpress.XtraGrid.Columns.GridColumn
End Class
