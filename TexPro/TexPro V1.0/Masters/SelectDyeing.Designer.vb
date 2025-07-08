<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SelectDyeing
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.gridname = New DevExpress.XtraGrid.GridControl()
        Me.gridledger = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHARTNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMATCHING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDYEINGID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.txttempname = New System.Windows.Forms.TextBox()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gridname)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.txttempname)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(469, 440)
        Me.BlendPanel1.TabIndex = 9
        '
        'gridname
        '
        Me.gridname.Location = New System.Drawing.Point(12, 12)
        Me.gridname.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridname.MainView = Me.gridledger
        Me.gridname.Name = "gridname"
        Me.gridname.Size = New System.Drawing.Size(443, 391)
        Me.gridname.TabIndex = 255
        Me.gridname.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridledger})
        '
        'gridledger
        '
        Me.gridledger.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridledger.Appearance.Row.Options.UseFont = True
        Me.gridledger.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHARTNAME, Me.GMATCHING, Me.GDYEINGID})
        Me.gridledger.GridControl = Me.gridname
        Me.gridledger.Name = "gridledger"
        Me.gridledger.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridledger.OptionsBehavior.Editable = False
        Me.gridledger.OptionsCustomization.AllowColumnMoving = False
        Me.gridledger.OptionsCustomization.AllowGroup = False
        Me.gridledger.OptionsSelection.CheckBoxSelectorColumnWidth = 40
        Me.gridledger.OptionsSelection.MultiSelect = True
        Me.gridledger.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridledger.OptionsView.ColumnAutoWidth = False
        Me.gridledger.OptionsView.ShowAutoFilterRow = True
        Me.gridledger.OptionsView.ShowGroupPanel = False
        '
        'GCHARTNAME
        '
        Me.GCHARTNAME.Caption = "Chart Name"
        Me.GCHARTNAME.FieldName = "CHARTNAME"
        Me.GCHARTNAME.Name = "GCHARTNAME"
        Me.GCHARTNAME.Visible = True
        Me.GCHARTNAME.VisibleIndex = 1
        Me.GCHARTNAME.Width = 250
        '
        'GMATCHING
        '
        Me.GMATCHING.Caption = "Matching"
        Me.GMATCHING.FieldName = "MATCHING"
        Me.GMATCHING.Name = "GMATCHING"
        Me.GMATCHING.Visible = True
        Me.GMATCHING.VisibleIndex = 2
        Me.GMATCHING.Width = 100
        '
        'GDYEINGID
        '
        Me.GDYEINGID.Caption = "Dyering ID"
        Me.GDYEINGID.FieldName = "DYEINGID"
        Me.GDYEINGID.Name = "GDYEINGID"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(237, 409)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 4
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
        Me.cmdok.Location = New System.Drawing.Point(151, 409)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'txttempname
        '
        Me.txttempname.BackColor = System.Drawing.Color.White
        Me.txttempname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttempname.ForeColor = System.Drawing.Color.Black
        Me.txttempname.Location = New System.Drawing.Point(751, 44)
        Me.txttempname.Name = "txttempname"
        Me.txttempname.ReadOnly = True
        Me.txttempname.Size = New System.Drawing.Size(0, 20)
        Me.txttempname.TabIndex = 254
        Me.txttempname.TabStop = False
        Me.txttempname.Visible = False
        '
        'SelectDyeing
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(469, 440)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectDyeing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "SelectDyeing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridname, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridledger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents txttempname As System.Windows.Forms.TextBox
    Private WithEvents gridname As DevExpress.XtraGrid.GridControl
    Private WithEvents gridledger As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHARTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMATCHING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDYEINGID As DevExpress.XtraGrid.Columns.GridColumn
End Class
