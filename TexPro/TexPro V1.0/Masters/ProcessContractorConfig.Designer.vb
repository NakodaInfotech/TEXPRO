<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcessContractorConfig
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
        Me.components = New System.ComponentModel.Container()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMBSUPERVISOR = New System.Windows.Forms.ComboBox()
        Me.CMBCONTRACTOR = New System.Windows.Forms.ComboBox()
        Me.CMDEXCEL = New System.Windows.Forms.Button()
        Me.GRIDBILLDETAILS = New DevExpress.XtraGrid.GridControl()
        Me.GRIDBILL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GPROCESS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCONTRACTOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSUPERVISOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CMBPROCESS = New System.Windows.Forms.ComboBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMBSUPERVISOR)
        Me.BlendPanel1.Controls.Add(Me.CMBCONTRACTOR)
        Me.BlendPanel1.Controls.Add(Me.CMDEXCEL)
        Me.BlendPanel1.Controls.Add(Me.GRIDBILLDETAILS)
        Me.BlendPanel1.Controls.Add(Me.CMBPROCESS)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(642, 571)
        Me.BlendPanel1.TabIndex = 1
        '
        'CMBSUPERVISOR
        '
        Me.CMBSUPERVISOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSUPERVISOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSUPERVISOR.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBSUPERVISOR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSUPERVISOR.FormattingEnabled = True
        Me.CMBSUPERVISOR.Location = New System.Drawing.Point(389, 17)
        Me.CMBSUPERVISOR.MaxDropDownItems = 14
        Me.CMBSUPERVISOR.Name = "CMBSUPERVISOR"
        Me.CMBSUPERVISOR.Size = New System.Drawing.Size(200, 23)
        Me.CMBSUPERVISOR.TabIndex = 319
        '
        'CMBCONTRACTOR
        '
        Me.CMBCONTRACTOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCONTRACTOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCONTRACTOR.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBCONTRACTOR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCONTRACTOR.FormattingEnabled = True
        Me.CMBCONTRACTOR.Location = New System.Drawing.Point(188, 17)
        Me.CMBCONTRACTOR.MaxDropDownItems = 14
        Me.CMBCONTRACTOR.Name = "CMBCONTRACTOR"
        Me.CMBCONTRACTOR.Size = New System.Drawing.Size(200, 23)
        Me.CMBCONTRACTOR.TabIndex = 318
        '
        'CMDEXCEL
        '
        Me.CMDEXCEL.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXCEL.FlatAppearance.BorderSize = 0
        Me.CMDEXCEL.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXCEL.ForeColor = System.Drawing.Color.Black
        Me.CMDEXCEL.Location = New System.Drawing.Point(238, 544)
        Me.CMDEXCEL.Name = "CMDEXCEL"
        Me.CMDEXCEL.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXCEL.TabIndex = 317
        Me.CMDEXCEL.Text = "Excel"
        Me.CMDEXCEL.UseVisualStyleBackColor = False
        '
        'GRIDBILLDETAILS
        '
        Me.GRIDBILLDETAILS.Location = New System.Drawing.Point(21, 40)
        Me.GRIDBILLDETAILS.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GRIDBILLDETAILS.MainView = Me.GRIDBILL
        Me.GRIDBILLDETAILS.Name = "GRIDBILLDETAILS"
        Me.GRIDBILLDETAILS.Size = New System.Drawing.Size(601, 497)
        Me.GRIDBILLDETAILS.TabIndex = 316
        Me.GRIDBILLDETAILS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GRIDBILL})
        '
        'GRIDBILL
        '
        Me.GRIDBILL.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRIDBILL.Appearance.Row.Options.UseFont = True
        Me.GRIDBILL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GPROCESS, Me.GCONTRACTOR, Me.GSUPERVISOR})
        Me.GRIDBILL.GridControl = Me.GRIDBILLDETAILS
        Me.GRIDBILL.Name = "GRIDBILL"
        Me.GRIDBILL.OptionsBehavior.AllowIncrementalSearch = True
        Me.GRIDBILL.OptionsBehavior.AutoExpandAllGroups = True
        Me.GRIDBILL.OptionsBehavior.Editable = False
        Me.GRIDBILL.OptionsView.ColumnAutoWidth = False
        Me.GRIDBILL.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GRIDBILL.OptionsView.ShowAutoFilterRow = True
        Me.GRIDBILL.OptionsView.ShowGroupPanel = False
        '
        'GPROCESS
        '
        Me.GPROCESS.Caption = "Process Name"
        Me.GPROCESS.FieldName = "PROCESS"
        Me.GPROCESS.Name = "GPROCESS"
        Me.GPROCESS.Visible = True
        Me.GPROCESS.VisibleIndex = 0
        Me.GPROCESS.Width = 150
        '
        'GCONTRACTOR
        '
        Me.GCONTRACTOR.Caption = "Contractor Name"
        Me.GCONTRACTOR.FieldName = "CONTRACTOR"
        Me.GCONTRACTOR.Name = "GCONTRACTOR"
        Me.GCONTRACTOR.Visible = True
        Me.GCONTRACTOR.VisibleIndex = 1
        Me.GCONTRACTOR.Width = 200
        '
        'GSUPERVISOR
        '
        Me.GSUPERVISOR.Caption = "Supervisor Name"
        Me.GSUPERVISOR.FieldName = "SUPERVISOR"
        Me.GSUPERVISOR.Name = "GSUPERVISOR"
        Me.GSUPERVISOR.Visible = True
        Me.GSUPERVISOR.VisibleIndex = 2
        Me.GSUPERVISOR.Width = 200
        '
        'CMBPROCESS
        '
        Me.CMBPROCESS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPROCESS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPROCESS.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBPROCESS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPROCESS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPROCESS.FormattingEnabled = True
        Me.CMBPROCESS.Location = New System.Drawing.Point(37, 17)
        Me.CMBPROCESS.MaxDropDownItems = 14
        Me.CMBPROCESS.Name = "CMBPROCESS"
        Me.CMBPROCESS.Size = New System.Drawing.Size(150, 23)
        Me.CMBPROCESS.TabIndex = 0
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(324, 544)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'ProcessContractorConfig
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(642, 571)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ProcessContractorConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Process Conractor Config"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        CType(Me.GRIDBILLDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GRIDBILL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As BlendPanel
    Friend WithEvents CMBSUPERVISOR As ComboBox
    Friend WithEvents CMBCONTRACTOR As ComboBox
    Friend WithEvents CMDEXCEL As Button
    Friend WithEvents GRIDBILLDETAILS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GRIDBILL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GPROCESS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCONTRACTOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSUPERVISOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CMBPROCESS As ComboBox
    Friend WithEvents cmdexit As Button
    Friend WithEvents EP As ErrorProvider
End Class
