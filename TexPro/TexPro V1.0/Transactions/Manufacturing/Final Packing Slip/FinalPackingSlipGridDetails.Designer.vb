<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FinalPackingSlipGridDetails
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
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMERCHANT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFBNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOBNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPRGNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDYEINGNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GORDERNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFROMPROCESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEXPENSEREPORT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKEXPENSEREPORT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GIMGPATH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOURLOCATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPROCESSTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPACKEDBY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.TOOLEXCEL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.GGRIDMERCHANT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEXPENSEREPORT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 8
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(13, 28)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEXPENSEREPORT})
        Me.gridbilldetails.Size = New System.Drawing.Size(1209, 509)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.GMERCHANT, Me.GGRIDMERCHANT, Me.GDESIGNNO, Me.GCOLOR, Me.GFBNO, Me.GJOBNO, Me.GPCS, Me.GMTRS, Me.GNAME, Me.GLOTNO, Me.GPRGNO, Me.GDYEINGNO, Me.GORDERNO, Me.GFROMPROCESS, Me.GTYPE, Me.GEXPENSEREPORT, Me.GIMGPATH, Me.GOURLOCATION, Me.GPROCESSTYPE, Me.GPACKEDBY})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'gsrno
        '
        Me.gsrno.Caption = "Bale No"
        Me.gsrno.FieldName = "SRNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.OptionsColumn.AllowEdit = False
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 60
        '
        'gdate
        '
        Me.gdate.Caption = "Date"
        Me.gdate.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.gdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.gdate.FieldName = "DATE"
        Me.gdate.Name = "gdate"
        Me.gdate.OptionsColumn.AllowEdit = False
        Me.gdate.Visible = True
        Me.gdate.VisibleIndex = 1
        Me.gdate.Width = 70
        '
        'GMERCHANT
        '
        Me.GMERCHANT.Caption = "Merchant Name"
        Me.GMERCHANT.FieldName = "MERCHANT"
        Me.GMERCHANT.Name = "GMERCHANT"
        Me.GMERCHANT.OptionsColumn.AllowEdit = False
        Me.GMERCHANT.Visible = True
        Me.GMERCHANT.VisibleIndex = 2
        Me.GMERCHANT.Width = 180
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 4
        Me.GDESIGNNO.Width = 100
        '
        'GCOLOR
        '
        Me.GCOLOR.Caption = "Color"
        Me.GCOLOR.FieldName = "COLOR"
        Me.GCOLOR.Name = "GCOLOR"
        Me.GCOLOR.Visible = True
        Me.GCOLOR.VisibleIndex = 5
        Me.GCOLOR.Width = 100
        '
        'GFBNO
        '
        Me.GFBNO.Caption = "F.B. No."
        Me.GFBNO.FieldName = "FBNO"
        Me.GFBNO.Name = "GFBNO"
        Me.GFBNO.OptionsColumn.AllowEdit = False
        Me.GFBNO.Visible = True
        Me.GFBNO.VisibleIndex = 6
        Me.GFBNO.Width = 65
        '
        'GJOBNO
        '
        Me.GJOBNO.Caption = "Job No"
        Me.GJOBNO.FieldName = "JOBNO"
        Me.GJOBNO.Name = "GJOBNO"
        Me.GJOBNO.OptionsColumn.AllowEdit = False
        Me.GJOBNO.Visible = True
        Me.GJOBNO.VisibleIndex = 7
        Me.GJOBNO.Width = 55
        '
        'GPCS
        '
        Me.GPCS.Caption = "Pcs"
        Me.GPCS.DisplayFormat.FormatString = "0"
        Me.GPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPCS.FieldName = "PCS"
        Me.GPCS.Name = "GPCS"
        Me.GPCS.OptionsColumn.AllowEdit = False
        Me.GPCS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPCS.Visible = True
        Me.GPCS.VisibleIndex = 8
        Me.GPCS.Width = 45
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Mtrs"
        Me.GMTRS.DisplayFormat.FormatString = "0.00"
        Me.GMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.OptionsColumn.AllowEdit = False
        Me.GMTRS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 9
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 10
        Me.GNAME.Width = 200
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot no"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.OptionsColumn.AllowEdit = False
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 11
        Me.GLOTNO.Width = 55
        '
        'GPRGNO
        '
        Me.GPRGNO.Caption = "Prog. No."
        Me.GPRGNO.FieldName = "PROGNO"
        Me.GPRGNO.Name = "GPRGNO"
        Me.GPRGNO.OptionsColumn.AllowEdit = False
        Me.GPRGNO.Visible = True
        Me.GPRGNO.VisibleIndex = 12
        Me.GPRGNO.Width = 63
        '
        'GDYEINGNO
        '
        Me.GDYEINGNO.Caption = "Chart No."
        Me.GDYEINGNO.FieldName = "DYEINGNO"
        Me.GDYEINGNO.Name = "GDYEINGNO"
        Me.GDYEINGNO.OptionsColumn.AllowEdit = False
        Me.GDYEINGNO.Visible = True
        Me.GDYEINGNO.VisibleIndex = 13
        '
        'GORDERNO
        '
        Me.GORDERNO.Caption = "Order No."
        Me.GORDERNO.FieldName = "ORDERNO"
        Me.GORDERNO.Name = "GORDERNO"
        Me.GORDERNO.OptionsColumn.AllowEdit = False
        Me.GORDERNO.Visible = True
        Me.GORDERNO.VisibleIndex = 14
        Me.GORDERNO.Width = 65
        '
        'GFROMPROCESS
        '
        Me.GFROMPROCESS.Caption = "From (Process)"
        Me.GFROMPROCESS.FieldName = "PROCESS"
        Me.GFROMPROCESS.Name = "GFROMPROCESS"
        Me.GFROMPROCESS.OptionsColumn.AllowEdit = False
        Me.GFROMPROCESS.Visible = True
        Me.GFROMPROCESS.VisibleIndex = 15
        Me.GFROMPROCESS.Width = 100
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.OptionsColumn.AllowEdit = False
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 16
        Me.GTYPE.Width = 56
        '
        'GEXPENSEREPORT
        '
        Me.GEXPENSEREPORT.Caption = "Expense Report"
        Me.GEXPENSEREPORT.ColumnEdit = Me.CHKEXPENSEREPORT
        Me.GEXPENSEREPORT.FieldName = "EXPENSEREPORT"
        Me.GEXPENSEREPORT.Name = "GEXPENSEREPORT"
        Me.GEXPENSEREPORT.Visible = True
        Me.GEXPENSEREPORT.VisibleIndex = 17
        '
        'CHKEXPENSEREPORT
        '
        Me.CHKEXPENSEREPORT.AutoHeight = False
        Me.CHKEXPENSEREPORT.Name = "CHKEXPENSEREPORT"
        Me.CHKEXPENSEREPORT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GIMGPATH
        '
        Me.GIMGPATH.Caption = "GridColumn1"
        Me.GIMGPATH.FieldName = "IMGPATH"
        Me.GIMGPATH.Name = "GIMGPATH"
        Me.GIMGPATH.OptionsColumn.AllowEdit = False
        '
        'GOURLOCATION
        '
        Me.GOURLOCATION.Caption = "GridColumn1"
        Me.GOURLOCATION.FieldName = "OURLOCATION"
        Me.GOURLOCATION.Name = "GOURLOCATION"
        Me.GOURLOCATION.OptionsColumn.AllowEdit = False
        '
        'GPROCESSTYPE
        '
        Me.GPROCESSTYPE.Caption = "Process Type"
        Me.GPROCESSTYPE.FieldName = "PROCESSTYPE"
        Me.GPROCESSTYPE.Name = "GPROCESSTYPE"
        Me.GPROCESSTYPE.OptionsColumn.AllowEdit = False
        Me.GPROCESSTYPE.Visible = True
        Me.GPROCESSTYPE.VisibleIndex = 18
        '
        'GPACKEDBY
        '
        Me.GPACKEDBY.Caption = "Packed By"
        Me.GPACKEDBY.FieldName = "PACKEDBY"
        Me.GPACKEDBY.Name = "GPACKEDBY"
        Me.GPACKEDBY.Visible = True
        Me.GPACKEDBY.VisibleIndex = 19
        Me.GPACKEDBY.Width = 120
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(620, 543)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(77, 26)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.TOOLREFRESH, Me.TOOLEXCEL, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton1.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.TexPro_V1.My.Resources.Resources.refresh1
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "ToolStripButton4"
        '
        'TOOLEXCEL
        '
        Me.TOOLEXCEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLEXCEL.Image = Global.TexPro_V1.My.Resources.Resources.Excel_icon
        Me.TOOLEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLEXCEL.Name = "TOOLEXCEL"
        Me.TOOLEXCEL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLEXCEL.Text = "ToolStripButton3"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(537, 543)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(77, 26)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GGRIDMERCHANT
        '
        Me.GGRIDMERCHANT.Caption = "Grid Merchant Name"
        Me.GGRIDMERCHANT.FieldName = "GRIDMERCHANT"
        Me.GGRIDMERCHANT.Name = "GGRIDMERCHANT"
        Me.GGRIDMERCHANT.Visible = True
        Me.GGRIDMERCHANT.VisibleIndex = 3
        Me.GGRIDMERCHANT.Width = 180
        '
        'FinalPackingSlipGridDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FinalPackingSlipGridDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Final Packing Slip Grid Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEXPENSEREPORT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMERCHANT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFBNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOBNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPRGNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDYEINGNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMPROCESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEXPENSEREPORT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEXPENSEREPORT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GIMGPATH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOURLOCATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROCESSTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPACKEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents TOOLEXCEL As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmdok As Button
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDMERCHANT As DevExpress.XtraGrid.Columns.GridColumn
End Class
