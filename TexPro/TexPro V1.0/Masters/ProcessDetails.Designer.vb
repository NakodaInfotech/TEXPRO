<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessDetails
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
        Me.cmdadd = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.CMDREFRESH = New System.Windows.Forms.Button
        Me.cmdedit = New System.Windows.Forms.Button
        Me.gridrecipe = New DevExpress.XtraGrid.GridControl
        Me.griddetails = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.gitemname = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gqty = New DevExpress.XtraGrid.Columns.GridColumn
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn
        Me.gridname = New DevExpress.XtraGrid.GridControl
        Me.gridledger = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GDESIGNNO = New DevExpress.XtraGrid.Columns.GridColumn
        Me.Label21 = New System.Windows.Forms.Label
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridrecipe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.cmdadd)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.cmdedit)
        Me.BlendPanel1.Controls.Add(Me.gridrecipe)
        Me.BlendPanel1.Controls.Add(Me.gridname)
        Me.BlendPanel1.Controls.Add(Me.Label21)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(612, 538)
        Me.BlendPanel1.TabIndex = 2
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.Color.Transparent
        Me.cmdadd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdadd.FlatAppearance.BorderSize = 0
        Me.cmdadd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdadd.Location = New System.Drawing.Point(231, 504)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(78, 25)
        Me.cmdadd.TabIndex = 440
        Me.cmdadd.Text = "&Add New"
        Me.cmdadd.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(309, 504)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(78, 25)
        Me.cmdexit.TabIndex = 441
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDREFRESH.Location = New System.Drawing.Point(436, 18)
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
        Me.cmdedit.Location = New System.Drawing.Point(519, 18)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(78, 25)
        Me.cmdedit.TabIndex = 438
        Me.cmdedit.Text = "&Edit"
        Me.cmdedit.UseVisualStyleBackColor = False
        '
        'gridrecipe
        '
        Me.gridrecipe.Location = New System.Drawing.Point(246, 46)
        Me.gridrecipe.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridrecipe.MainView = Me.griddetails
        Me.gridrecipe.Name = "gridrecipe"
        Me.gridrecipe.Size = New System.Drawing.Size(345, 445)
        Me.gridrecipe.TabIndex = 320
        Me.gridrecipe.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.griddetails})
        '
        'griddetails
        '
        Me.griddetails.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.griddetails.Appearance.Row.Options.UseFont = True
        Me.griddetails.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gitemname, Me.gqty, Me.GUNIT})
        Me.griddetails.GridControl = Me.gridrecipe
        Me.griddetails.Name = "griddetails"
        Me.griddetails.OptionsBehavior.Editable = False
        Me.griddetails.OptionsCustomization.AllowColumnMoving = False
        Me.griddetails.OptionsCustomization.AllowGroup = False
        Me.griddetails.OptionsView.ColumnAutoWidth = False
        Me.griddetails.OptionsView.ShowGroupPanel = False
        '
        'gitemname
        '
        Me.gitemname.Caption = "Item Name"
        Me.gitemname.FieldName = "ITEMNAME"
        Me.gitemname.Name = "gitemname"
        Me.gitemname.Visible = True
        Me.gitemname.VisibleIndex = 0
        Me.gitemname.Width = 190
        '
        'gqty
        '
        Me.gqty.Caption = "Qty"
        Me.gqty.FieldName = "QTY"
        Me.gqty.Name = "gqty"
        Me.gqty.Visible = True
        Me.gqty.VisibleIndex = 1
        Me.gqty.Width = 49
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 2
        Me.GUNIT.Width = 60
        '
        'gridname
        '
        Me.gridname.Location = New System.Drawing.Point(22, 46)
        Me.gridname.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridname.MainView = Me.gridledger
        Me.gridname.Name = "gridname"
        Me.gridname.Size = New System.Drawing.Size(218, 445)
        Me.gridname.TabIndex = 318
        Me.gridname.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridledger})
        '
        'gridledger
        '
        Me.gridledger.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridledger.Appearance.Row.Options.UseFont = True
        Me.gridledger.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GDESIGNNO})
        Me.gridledger.GridControl = Me.gridname
        Me.gridledger.Name = "gridledger"
        Me.gridledger.OptionsBehavior.Editable = False
        Me.gridledger.OptionsCustomization.AllowColumnMoving = False
        Me.gridledger.OptionsCustomization.AllowGroup = False
        Me.gridledger.OptionsView.ShowGroupPanel = False
        '
        'GDESIGNNO
        '
        Me.GDESIGNNO.Caption = "Design No"
        Me.GDESIGNNO.FieldName = "DESIGNNO"
        Me.GDESIGNNO.Name = "GDESIGNNO"
        Me.GDESIGNNO.Visible = True
        Me.GDESIGNNO.VisibleIndex = 0
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(20, 25)
        Me.Label21.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(174, 14)
        Me.Label21.TabIndex = 317
        Me.Label21.Text = "Double Click on Process to Edit"
        '
        'ProcessDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(612, 538)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ProcessDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Process Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridrecipe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.griddetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Private WithEvents gridrecipe As DevExpress.XtraGrid.GridControl
    Private WithEvents griddetails As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gitemname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gqty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents gridname As DevExpress.XtraGrid.GridControl
    Private WithEvents gridledger As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GDESIGNNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label21 As System.Windows.Forms.Label
End Class
