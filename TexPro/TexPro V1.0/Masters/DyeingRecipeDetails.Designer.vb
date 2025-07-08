<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DyeingRecipeDetails
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
        Me.TXTOURLOCATION = New System.Windows.Forms.TextBox()
        Me.txtimgpath = New System.Windows.Forms.TextBox()
        Me.cmdadd = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.cmdedit = New System.Windows.Forms.Button()
        Me.pbimage = New System.Windows.Forms.PictureBox()
        Me.gridrecipe = New DevExpress.XtraGrid.GridControl()
        Me.griddetails = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gitemname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gqty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridmatching = New DevExpress.XtraGrid.GridControl()
        Me.matchingview = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GGRIDSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMatching = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gridname = New DevExpress.XtraGrid.GridControl()
        Me.gridledger = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GDYEINGNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDYEINGID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtremarks = New System.Windows.Forms.TextBox()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.pbimage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridrecipe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridmatching, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.matchingview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.GroupBox5)
        Me.BlendPanel1.Controls.Add(Me.TXTOURLOCATION)
        Me.BlendPanel1.Controls.Add(Me.txtimgpath)
        Me.BlendPanel1.Controls.Add(Me.cmdadd)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.cmdedit)
        Me.BlendPanel1.Controls.Add(Me.pbimage)
        Me.BlendPanel1.Controls.Add(Me.gridrecipe)
        Me.BlendPanel1.Controls.Add(Me.gridmatching)
        Me.BlendPanel1.Controls.Add(Me.gridname)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(995, 530)
        Me.BlendPanel1.TabIndex = 2
        '
        'TXTOURLOCATION
        '
        Me.TXTOURLOCATION.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTOURLOCATION.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TXTOURLOCATION.Location = New System.Drawing.Point(723, 319)
        Me.TXTOURLOCATION.Multiline = True
        Me.TXTOURLOCATION.Name = "TXTOURLOCATION"
        Me.TXTOURLOCATION.Size = New System.Drawing.Size(45, 22)
        Me.TXTOURLOCATION.TabIndex = 443
        Me.TXTOURLOCATION.Visible = False
        '
        'txtimgpath
        '
        Me.txtimgpath.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtimgpath.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtimgpath.Location = New System.Drawing.Point(681, 319)
        Me.txtimgpath.Multiline = True
        Me.txtimgpath.Name = "txtimgpath"
        Me.txtimgpath.Size = New System.Drawing.Size(45, 22)
        Me.txtimgpath.TabIndex = 442
        Me.txtimgpath.Visible = False
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.Color.Transparent
        Me.cmdadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdadd.FlatAppearance.BorderSize = 0
        Me.cmdadd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdadd.Location = New System.Drawing.Point(671, 285)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(78, 25)
        Me.cmdadd.TabIndex = 440
        Me.cmdadd.Text = "Add New"
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(755, 285)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(78, 25)
        Me.cmdexit.TabIndex = 441
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDREFRESH.Location = New System.Drawing.Point(666, 32)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(78, 25)
        Me.CMDREFRESH.TabIndex = 439
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'cmdedit
        '
        Me.cmdedit.BackColor = System.Drawing.Color.Transparent
        Me.cmdedit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdedit.FlatAppearance.BorderSize = 0
        Me.cmdedit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdedit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdedit.Location = New System.Drawing.Point(749, 32)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(78, 25)
        Me.cmdedit.TabIndex = 438
        Me.cmdedit.Text = "Edit"
        Me.cmdedit.UseVisualStyleBackColor = False
        '
        'pbimage
        '
        Me.pbimage.BackColor = System.Drawing.Color.Transparent
        Me.pbimage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbimage.Location = New System.Drawing.Point(661, 63)
        Me.pbimage.Name = "pbimage"
        Me.pbimage.Size = New System.Drawing.Size(160, 194)
        Me.pbimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbimage.TabIndex = 437
        Me.pbimage.TabStop = False
        '
        'gridrecipe
        '
        Me.gridrecipe.Location = New System.Drawing.Point(182, 275)
        Me.gridrecipe.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridrecipe.MainView = Me.griddetails
        Me.gridrecipe.Name = "gridrecipe"
        Me.gridrecipe.Size = New System.Drawing.Size(473, 216)
        Me.gridrecipe.TabIndex = 320
        Me.gridrecipe.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.griddetails})
        '
        'griddetails
        '
        Me.griddetails.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Appearance.Row.Options.UseFont = True
        Me.griddetails.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gitemname, Me.gqty})
        Me.griddetails.GridControl = Me.gridrecipe
        Me.griddetails.Name = "griddetails"
        Me.griddetails.OptionsBehavior.Editable = False
        Me.griddetails.OptionsCustomization.AllowColumnMoving = False
        Me.griddetails.OptionsCustomization.AllowGroup = False
        Me.griddetails.OptionsView.ShowGroupPanel = False
        '
        'gitemname
        '
        Me.gitemname.Caption = "Item Name"
        Me.gitemname.FieldName = "ITEMNAME"
        Me.gitemname.Name = "gitemname"
        Me.gitemname.Visible = True
        Me.gitemname.VisibleIndex = 0
        Me.gitemname.Width = 233
        '
        'gqty
        '
        Me.gqty.Caption = "Qty / Unit"
        Me.gqty.FieldName = "QTY"
        Me.gqty.Name = "gqty"
        Me.gqty.Visible = True
        Me.gqty.VisibleIndex = 1
        Me.gqty.Width = 70
        '
        'gridmatching
        '
        Me.gridmatching.Location = New System.Drawing.Point(182, 32)
        Me.gridmatching.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridmatching.MainView = Me.matchingview
        Me.gridmatching.Name = "gridmatching"
        Me.gridmatching.Size = New System.Drawing.Size(473, 228)
        Me.gridmatching.TabIndex = 319
        Me.gridmatching.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.matchingview})
        '
        'matchingview
        '
        Me.matchingview.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.matchingview.Appearance.Row.Options.UseFont = True
        Me.matchingview.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GGRIDSRNO, Me.GMatching})
        Me.matchingview.GridControl = Me.gridmatching
        Me.matchingview.Name = "matchingview"
        Me.matchingview.OptionsBehavior.Editable = False
        Me.matchingview.OptionsCustomization.AllowColumnMoving = False
        Me.matchingview.OptionsCustomization.AllowGroup = False
        Me.matchingview.OptionsView.ShowGroupPanel = False
        '
        'GGRIDSRNO
        '
        Me.GGRIDSRNO.Caption = "Sr. No."
        Me.GGRIDSRNO.FieldName = "GRIDSRNO"
        Me.GGRIDSRNO.Name = "GGRIDSRNO"
        Me.GGRIDSRNO.Visible = True
        Me.GGRIDSRNO.VisibleIndex = 0
        Me.GGRIDSRNO.Width = 52
        '
        'GMatching
        '
        Me.GMatching.Caption = "Matching"
        Me.GMatching.FieldName = "COLOR"
        Me.GMatching.Name = "GMatching"
        Me.GMatching.Visible = True
        Me.GMatching.VisibleIndex = 1
        Me.GMatching.Width = 133
        '
        'gridname
        '
        Me.gridname.Location = New System.Drawing.Point(23, 32)
        Me.gridname.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridname.MainView = Me.gridledger
        Me.gridname.Name = "gridname"
        Me.gridname.Size = New System.Drawing.Size(140, 459)
        Me.gridname.TabIndex = 318
        Me.gridname.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridledger})
        '
        'gridledger
        '
        Me.gridledger.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridledger.Appearance.Row.Options.UseFont = True
        Me.gridledger.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GDYEINGNO, Me.GDYEINGID})
        Me.gridledger.GridControl = Me.gridname
        Me.gridledger.Name = "gridledger"
        Me.gridledger.OptionsBehavior.Editable = False
        Me.gridledger.OptionsCustomization.AllowColumnMoving = False
        Me.gridledger.OptionsCustomization.AllowGroup = False
        Me.gridledger.OptionsView.ShowAutoFilterRow = True
        Me.gridledger.OptionsView.ShowGroupPanel = False
        '
        'GDYEINGNO
        '
        Me.GDYEINGNO.Caption = "CHART NO"
        Me.GDYEINGNO.FieldName = "DYEINGNO"
        Me.GDYEINGNO.Name = "GDYEINGNO"
        Me.GDYEINGNO.Visible = True
        Me.GDYEINGNO.VisibleIndex = 0
        '
        'GDYEINGID
        '
        Me.GDYEINGID.Caption = "DYEINGID"
        Me.GDYEINGID.FieldName = "DYEINGID"
        Me.GDYEINGID.Name = "GDYEINGID"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(20, 13)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(171, 14)
        Me.Label21.TabIndex = 317
        Me.Label21.Text = "Double Click on Design to Edit"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.txtremarks)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(666, 380)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(197, 111)
        Me.GroupBox5.TabIndex = 445
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Remarks"
        '
        'txtremarks
        '
        Me.txtremarks.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtremarks.ForeColor = System.Drawing.Color.DimGray
        Me.txtremarks.Location = New System.Drawing.Point(6, 18)
        Me.txtremarks.Multiline = True
        Me.txtremarks.Name = "txtremarks"
        Me.txtremarks.Size = New System.Drawing.Size(185, 85)
        Me.txtremarks.TabIndex = 0
        '
        'DyeingRecipeDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(995, 530)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "DyeingRecipeDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Dyeing Recipe Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.pbimage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridrecipe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridmatching, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.matchingview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents pbimage As System.Windows.Forms.PictureBox
    Private WithEvents gridrecipe As DevExpress.XtraGrid.GridControl
    Private WithEvents griddetails As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gitemname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gqty As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridmatching As DevExpress.XtraGrid.GridControl
    Private WithEvents matchingview As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GGRIDSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMatching As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridname As DevExpress.XtraGrid.GridControl
    Private WithEvents gridledger As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GDYEINGNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GDYEINGID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TXTOURLOCATION As System.Windows.Forms.TextBox
    Friend WithEvents txtimgpath As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtremarks As TextBox
End Class
