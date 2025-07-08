<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectChecking
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
        Me.Label20 = New System.Windows.Forms.Label()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREJPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALPCS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHECKINGCHGS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFROMNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFROMTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.APPROXDATE = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.Label()
        Me.GREJMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APPROXDATE.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Green
        Me.Label20.Location = New System.Drawing.Point(721, 15)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(205, 14)
        Me.Label20.TabIndex = 404
        Me.Label20.Text = "NOTE : One GRN can be select at a time"
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.Label20)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1064, 581)
        Me.BlendPanel1.TabIndex = 9
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(18, 32)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT, Me.APPROXDATE})
        Me.gridbilldetails.Size = New System.Drawing.Size(1035, 503)
        Me.gridbilldetails.TabIndex = 407
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GLOTNO, Me.GDONO, Me.GDODATE, Me.GNAME, Me.GREJPCS, Me.GREJMTRS, Me.GTOTALPCS, Me.GCHECKINGCHGS, Me.GFROMNO, Me.GFROMTYPE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsCustomization.AllowColumnMoving = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.CHKEDIT
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 30
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.OptionsColumn.AllowEdit = False
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 1
        '
        'GDONO
        '
        Me.GDONO.Caption = "DO No."
        Me.GDONO.FieldName = "DONO"
        Me.GDONO.Name = "GDONO"
        Me.GDONO.OptionsColumn.AllowEdit = False
        Me.GDONO.Visible = True
        Me.GDONO.VisibleIndex = 2
        '
        'GDODATE
        '
        Me.GDODATE.Caption = "DO Date"
        Me.GDODATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDODATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDODATE.FieldName = "DATE"
        Me.GDODATE.Name = "GDODATE"
        Me.GDODATE.OptionsColumn.AllowEdit = False
        Me.GDODATE.Visible = True
        Me.GDODATE.VisibleIndex = 3
        Me.GDODATE.Width = 85
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 4
        Me.GNAME.Width = 200
        '
        'GREJPCS
        '
        Me.GREJPCS.Caption = "Rej Pcs"
        Me.GREJPCS.DisplayFormat.FormatString = "0"
        Me.GREJPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GREJPCS.FieldName = "REJPCS"
        Me.GREJPCS.Name = "GREJPCS"
        Me.GREJPCS.OptionsColumn.AllowEdit = False
        Me.GREJPCS.Visible = True
        Me.GREJPCS.VisibleIndex = 5
        '
        'GTOTALPCS
        '
        Me.GTOTALPCS.Caption = "Total Pcs"
        Me.GTOTALPCS.DisplayFormat.FormatString = "0"
        Me.GTOTALPCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALPCS.FieldName = "TOTALPCS"
        Me.GTOTALPCS.Name = "GTOTALPCS"
        Me.GTOTALPCS.OptionsColumn.AllowEdit = False
        Me.GTOTALPCS.Visible = True
        Me.GTOTALPCS.VisibleIndex = 7
        Me.GTOTALPCS.Width = 85
        '
        'GCHECKINGCHGS
        '
        Me.GCHECKINGCHGS.Caption = "Checking Chgs"
        Me.GCHECKINGCHGS.DisplayFormat.FormatString = "0.00"
        Me.GCHECKINGCHGS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCHECKINGCHGS.FieldName = "CHECKINGCHGS"
        Me.GCHECKINGCHGS.Name = "GCHECKINGCHGS"
        Me.GCHECKINGCHGS.OptionsColumn.AllowEdit = False
        Me.GCHECKINGCHGS.Visible = True
        Me.GCHECKINGCHGS.VisibleIndex = 8
        Me.GCHECKINGCHGS.Width = 100
        '
        'GFROMNO
        '
        Me.GFROMNO.Caption = "From No"
        Me.GFROMNO.DisplayFormat.FormatString = "0"
        Me.GFROMNO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GFROMNO.FieldName = "FROMNO"
        Me.GFROMNO.Name = "GFROMNO"
        Me.GFROMNO.OptionsColumn.AllowEdit = False
        Me.GFROMNO.Visible = True
        Me.GFROMNO.VisibleIndex = 9
        Me.GFROMNO.Width = 85
        '
        'GFROMTYPE
        '
        Me.GFROMTYPE.Caption = "From Type"
        Me.GFROMTYPE.FieldName = "FROMTYPE"
        Me.GFROMTYPE.Name = "GFROMTYPE"
        Me.GFROMTYPE.OptionsColumn.AllowEdit = False
        Me.GFROMTYPE.Visible = True
        Me.GFROMTYPE.VisibleIndex = 10
        Me.GFROMTYPE.Width = 100
        '
        'APPROXDATE
        '
        Me.APPROXDATE.AutoHeight = False
        Me.APPROXDATE.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.APPROXDATE.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.APPROXDATE.Name = "APPROXDATE"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(485, 541)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 406
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(399, 541)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 405
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(21, 15)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(141, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select a GRN for Gate Pass"
        '
        'GREJMTRS
        '
        Me.GREJMTRS.Caption = "Rej Mtrs"
        Me.GREJMTRS.DisplayFormat.FormatString = "0.00"
        Me.GREJMTRS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GREJMTRS.FieldName = "REJMTRS"
        Me.GREJMTRS.Name = "GREJMTRS"
        Me.GREJMTRS.Visible = True
        Me.GREJMTRS.VisibleIndex = 6
        '
        'SelectChecking
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1064, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectChecking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Checking"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APPROXDATE.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents APPROXDATE As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREJPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALPCS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHECKINGCHGS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFROMTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREJMTRS As DevExpress.XtraGrid.Columns.GridColumn
End Class
