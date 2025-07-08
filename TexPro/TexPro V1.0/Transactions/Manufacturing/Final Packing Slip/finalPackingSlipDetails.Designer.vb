<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class finalPackingSlipDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(finalPackingSlipDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.CMDVIEW = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CHKHEADER = New System.Windows.Forms.CheckBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMERCHANT = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.ToolStripdelete = New System.Windows.Forms.ToolStripButton()
        Me.TOOLMAIL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtfrom = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.txtto = New System.Windows.Forms.ToolStripTextBox()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lbl = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.GRIDREPORT = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.CMDVIEW)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CHKHEADER)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Controls.Add(Me.Label22)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(523, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 14)
        Me.Label4.TabIndex = 807
        Me.Label4.Text = "Copies"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(564, 3)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 806
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMDVIEW
        '
        Me.CMDVIEW.BackColor = System.Drawing.Color.Transparent
        Me.CMDVIEW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDVIEW.FlatAppearance.BorderSize = 0
        Me.CMDVIEW.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDVIEW.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDVIEW.Location = New System.Drawing.Point(579, 527)
        Me.CMDVIEW.Name = "CMDVIEW"
        Me.CMDVIEW.Size = New System.Drawing.Size(77, 26)
        Me.CMDVIEW.TabIndex = 745
        Me.CMDVIEW.Text = "&View Image"
        Me.CMDVIEW.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(783, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 14)
        Me.Label1.TabIndex = 744
        Me.Label1.Text = "Expense Report"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.LightGreen
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(763, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 17)
        Me.Label2.TabIndex = 743
        Me.Label2.Text = "   "
        '
        'CHKHEADER
        '
        Me.CHKHEADER.AutoSize = True
        Me.CHKHEADER.BackColor = System.Drawing.Color.Transparent
        Me.CHKHEADER.Location = New System.Drawing.Point(241, 31)
        Me.CHKHEADER.Name = "CHKHEADER"
        Me.CHKHEADER.Size = New System.Drawing.Size(95, 19)
        Me.CHKHEADER.TabIndex = 742
        Me.CHKHEADER.Text = "Print Header"
        Me.CHKHEADER.UseVisualStyleBackColor = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(576, 33)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(144, 14)
        Me.Label21.TabIndex = 441
        Me.Label21.Text = "Locked (Dispatch Raised)"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label22.Location = New System.Drawing.Point(556, 32)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(18, 17)
        Me.Label22.TabIndex = 440
        Me.Label22.Text = "   "
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(13, 56)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEXPENSEREPORT})
        Me.gridbilldetails.Size = New System.Drawing.Size(1209, 466)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.gdate, Me.GMERCHANT, Me.GFBNO, Me.GJOBNO, Me.GPCS, Me.GMTRS, Me.GNAME, Me.GLOTNO, Me.GPRGNO, Me.GDYEINGNO, Me.GORDERNO, Me.GFROMPROCESS, Me.GTYPE, Me.GEXPENSEREPORT, Me.GIMGPATH, Me.GOURLOCATION, Me.GPROCESSTYPE, Me.GPACKEDBY})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridbill.OptionsSelection.MultiSelect = True
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
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
        Me.gsrno.VisibleIndex = 1
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
        Me.gdate.VisibleIndex = 2
        Me.gdate.Width = 70
        '
        'GMERCHANT
        '
        Me.GMERCHANT.Caption = "Merchant Name"
        Me.GMERCHANT.FieldName = "MERCHANT"
        Me.GMERCHANT.Name = "GMERCHANT"
        Me.GMERCHANT.OptionsColumn.AllowEdit = False
        Me.GMERCHANT.Visible = True
        Me.GMERCHANT.VisibleIndex = 3
        Me.GMERCHANT.Width = 180
        '
        'GFBNO
        '
        Me.GFBNO.Caption = "F.B. No."
        Me.GFBNO.FieldName = "FBNO"
        Me.GFBNO.Name = "GFBNO"
        Me.GFBNO.OptionsColumn.AllowEdit = False
        Me.GFBNO.Visible = True
        Me.GFBNO.VisibleIndex = 4
        Me.GFBNO.Width = 65
        '
        'GJOBNO
        '
        Me.GJOBNO.Caption = "Job No"
        Me.GJOBNO.FieldName = "JOBNO"
        Me.GJOBNO.Name = "GJOBNO"
        Me.GJOBNO.OptionsColumn.AllowEdit = False
        Me.GJOBNO.Visible = True
        Me.GJOBNO.VisibleIndex = 5
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
        Me.GPCS.VisibleIndex = 6
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
        Me.GMTRS.VisibleIndex = 7
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 8
        Me.GNAME.Width = 200
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot no"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.OptionsColumn.AllowEdit = False
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 9
        Me.GLOTNO.Width = 55
        '
        'GPRGNO
        '
        Me.GPRGNO.Caption = "Prog. No."
        Me.GPRGNO.FieldName = "PROGNO"
        Me.GPRGNO.Name = "GPRGNO"
        Me.GPRGNO.OptionsColumn.AllowEdit = False
        Me.GPRGNO.Visible = True
        Me.GPRGNO.VisibleIndex = 10
        Me.GPRGNO.Width = 63
        '
        'GDYEINGNO
        '
        Me.GDYEINGNO.Caption = "Chart No."
        Me.GDYEINGNO.FieldName = "DYEINGNO"
        Me.GDYEINGNO.Name = "GDYEINGNO"
        Me.GDYEINGNO.OptionsColumn.AllowEdit = False
        Me.GDYEINGNO.Visible = True
        Me.GDYEINGNO.VisibleIndex = 11
        '
        'GORDERNO
        '
        Me.GORDERNO.Caption = "Order No."
        Me.GORDERNO.FieldName = "ORDERNO"
        Me.GORDERNO.Name = "GORDERNO"
        Me.GORDERNO.OptionsColumn.AllowEdit = False
        Me.GORDERNO.Visible = True
        Me.GORDERNO.VisibleIndex = 12
        Me.GORDERNO.Width = 65
        '
        'GFROMPROCESS
        '
        Me.GFROMPROCESS.Caption = "From (Process)"
        Me.GFROMPROCESS.FieldName = "PROCESS"
        Me.GFROMPROCESS.Name = "GFROMPROCESS"
        Me.GFROMPROCESS.OptionsColumn.AllowEdit = False
        Me.GFROMPROCESS.Visible = True
        Me.GFROMPROCESS.VisibleIndex = 13
        Me.GFROMPROCESS.Width = 100
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.OptionsColumn.AllowEdit = False
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 14
        Me.GTYPE.Width = 56
        '
        'GEXPENSEREPORT
        '
        Me.GEXPENSEREPORT.Caption = "Expense Report"
        Me.GEXPENSEREPORT.ColumnEdit = Me.CHKEXPENSEREPORT
        Me.GEXPENSEREPORT.FieldName = "EXPENSEREPORT"
        Me.GEXPENSEREPORT.Name = "GEXPENSEREPORT"
        Me.GEXPENSEREPORT.Visible = True
        Me.GEXPENSEREPORT.VisibleIndex = 15
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
        Me.GPROCESSTYPE.VisibleIndex = 16
        '
        'GPACKEDBY
        '
        Me.GPACKEDBY.Caption = "Packed By"
        Me.GPACKEDBY.FieldName = "PACKEDBY"
        Me.GPACKEDBY.Name = "GPACKEDBY"
        Me.GPACKEDBY.Visible = True
        Me.GPACKEDBY.VisibleIndex = 17
        Me.GPACKEDBY.Width = 120
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(662, 527)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(77, 26)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.ToolStripdelete, Me.TOOLMAIL, Me.TOOLREFRESH, Me.ToolStripButton3, Me.ToolStripSeparator3, Me.GRIDREPORT, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.txtfrom, Me.ToolStripLabel2, Me.txtto, Me.PrintToolStripButton, Me.ToolStripSeparator1})
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
        'ToolStripdelete
        '
        Me.ToolStripdelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripdelete.Image = CType(resources.GetObject("ToolStripdelete.Image"), System.Drawing.Image)
        Me.ToolStripdelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripdelete.Name = "ToolStripdelete"
        Me.ToolStripdelete.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripdelete.Text = "C&ut"
        '
        'TOOLMAIL
        '
        Me.TOOLMAIL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLMAIL.Image = Global.TexPro_V1.My.Resources.Resources.MAIL_IMAGE
        Me.TOOLMAIL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLMAIL.Name = "TOOLMAIL"
        Me.TOOLMAIL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLMAIL.Text = "Mail Invoice Directly"
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
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.TexPro_V1.My.Resources.Resources.Excel_icon
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripLabel1.Text = "Print From"
        '
        'txtfrom
        '
        Me.txtfrom.Name = "txtfrom"
        Me.txtfrom.Size = New System.Drawing.Size(69, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(19, 22)
        Me.ToolStripLabel2.Text = "To"
        '
        'txtto
        '
        Me.txtto.Name = "txtto"
        Me.txtto.Size = New System.Drawing.Size(69, 25)
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
        Me.lbl.Location = New System.Drawing.Point(22, 33)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(182, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a Final Packing to Change"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(496, 527)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(77, 26)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'GRIDREPORT
        '
        Me.GRIDREPORT.Name = "GRIDREPORT"
        Me.GRIDREPORT.Size = New System.Drawing.Size(67, 22)
        Me.GRIDREPORT.Text = "Grid Report"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'finalPackingSlipDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "finalPackingSlipDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Final Packing Slip Details"
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
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMPROCESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOBNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMERCHANT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripdelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents GFBNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDYEINGNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPRGNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtfrom As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtto As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents CHKHEADER As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TOOLREFRESH As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GEXPENSEREPORT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEXPENSEREPORT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GIMGPATH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOURLOCATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMDVIEW As System.Windows.Forms.Button
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROCESSTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPACKEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents PRINTDOC As Drawing.Printing.PrintDocument
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents TOOLMAIL As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents GRIDREPORT As ToolStripLabel
End Class
