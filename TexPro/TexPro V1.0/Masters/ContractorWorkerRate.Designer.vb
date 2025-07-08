<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContractorWorkerRate
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
        Me.TXTNIGHTRATE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TXTDAYRATE = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.CMBCONTRACTOR = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBPROCESS = New System.Windows.Forms.ComboBox()
        Me.TXTWORKER = New System.Windows.Forms.TextBox()
        Me.LBLWORKER = New System.Windows.Forms.Label()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CMDDELETE = New System.Windows.Forms.Button()
        Me.LBLRATE = New System.Windows.Forms.Label()
        Me.TXTRATE = New System.Windows.Forms.TextBox()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.EP = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BlendPanel1.SuspendLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTNIGHTRATE)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.TXTDAYRATE)
        Me.BlendPanel1.Controls.Add(Me.Label18)
        Me.BlendPanel1.Controls.Add(Me.Label38)
        Me.BlendPanel1.Controls.Add(Me.CMBCONTRACTOR)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CMBPROCESS)
        Me.BlendPanel1.Controls.Add(Me.TXTWORKER)
        Me.BlendPanel1.Controls.Add(Me.LBLWORKER)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CMDDELETE)
        Me.BlendPanel1.Controls.Add(Me.LBLRATE)
        Me.BlendPanel1.Controls.Add(Me.TXTRATE)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(315, 251)
        Me.BlendPanel1.TabIndex = 0
        '
        'TXTNIGHTRATE
        '
        Me.TXTNIGHTRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTNIGHTRATE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTNIGHTRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNIGHTRATE.Location = New System.Drawing.Point(106, 129)
        Me.TXTNIGHTRATE.Name = "TXTNIGHTRATE"
        Me.TXTNIGHTRATE.Size = New System.Drawing.Size(54, 22)
        Me.TXTNIGHTRATE.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(11, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 14)
        Me.Label3.TabIndex = 720
        Me.Label3.Text = "Night Shift Rate"
        '
        'TXTDAYRATE
        '
        Me.TXTDAYRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTDAYRATE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTDAYRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDAYRATE.Location = New System.Drawing.Point(106, 101)
        Me.TXTDAYRATE.Name = "TXTDAYRATE"
        Me.TXTDAYRATE.Size = New System.Drawing.Size(54, 22)
        Me.TXTDAYRATE.TabIndex = 4
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label18.Location = New System.Drawing.Point(20, 105)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(82, 14)
        Me.Label18.TabIndex = 718
        Me.Label18.Text = "Day Shift Rate"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label38.Location = New System.Drawing.Point(40, 49)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(62, 14)
        Me.Label38.TabIndex = 716
        Me.Label38.Text = "Contractor"
        '
        'CMBCONTRACTOR
        '
        Me.CMBCONTRACTOR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCONTRACTOR.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCONTRACTOR.BackColor = System.Drawing.Color.White
        Me.CMBCONTRACTOR.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CMBCONTRACTOR.FormattingEnabled = True
        Me.CMBCONTRACTOR.Location = New System.Drawing.Point(106, 45)
        Me.CMBCONTRACTOR.MaxDropDownItems = 14
        Me.CMBCONTRACTOR.Name = "CMBCONTRACTOR"
        Me.CMBCONTRACTOR.Size = New System.Drawing.Size(153, 22)
        Me.CMBCONTRACTOR.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(54, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 14)
        Me.Label2.TabIndex = 640
        Me.Label2.Text = "Process"
        '
        'CMBPROCESS
        '
        Me.CMBPROCESS.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBPROCESS.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBPROCESS.BackColor = System.Drawing.Color.White
        Me.CMBPROCESS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPROCESS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBPROCESS.FormattingEnabled = True
        Me.CMBPROCESS.Location = New System.Drawing.Point(106, 17)
        Me.CMBPROCESS.MaxDropDownItems = 14
        Me.CMBPROCESS.Name = "CMBPROCESS"
        Me.CMBPROCESS.Size = New System.Drawing.Size(153, 22)
        Me.CMBPROCESS.TabIndex = 0
        '
        'TXTWORKER
        '
        Me.TXTWORKER.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTWORKER.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTWORKER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTWORKER.Location = New System.Drawing.Point(106, 73)
        Me.TXTWORKER.Name = "TXTWORKER"
        Me.TXTWORKER.Size = New System.Drawing.Size(54, 22)
        Me.TXTWORKER.TabIndex = 2
        Me.TXTWORKER.Visible = False
        '
        'LBLWORKER
        '
        Me.LBLWORKER.AutoSize = True
        Me.LBLWORKER.BackColor = System.Drawing.Color.Transparent
        Me.LBLWORKER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLWORKER.ForeColor = System.Drawing.Color.Black
        Me.LBLWORKER.Location = New System.Drawing.Point(57, 77)
        Me.LBLWORKER.Name = "LBLWORKER"
        Me.LBLWORKER.Size = New System.Drawing.Size(45, 14)
        Me.LBLWORKER.TabIndex = 158
        Me.LBLWORKER.Text = "Worker"
        Me.LBLWORKER.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LBLWORKER.Visible = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXIT.Location = New System.Drawing.Point(160, 201)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 9
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDCLEAR.ForeColor = System.Drawing.Color.Black
        Me.CMDCLEAR.Location = New System.Drawing.Point(74, 201)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 8
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDDELETE
        '
        Me.CMDDELETE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDDELETE.ForeColor = System.Drawing.Color.Black
        Me.CMDDELETE.Location = New System.Drawing.Point(160, 167)
        Me.CMDDELETE.Name = "CMDDELETE"
        Me.CMDDELETE.Size = New System.Drawing.Size(80, 28)
        Me.CMDDELETE.TabIndex = 7
        Me.CMDDELETE.Text = "&Delete"
        Me.CMDDELETE.UseVisualStyleBackColor = True
        '
        'LBLRATE
        '
        Me.LBLRATE.AutoSize = True
        Me.LBLRATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLRATE.ForeColor = System.Drawing.Color.Black
        Me.LBLRATE.Location = New System.Drawing.Point(167, 77)
        Me.LBLRATE.Name = "LBLRATE"
        Me.LBLRATE.Size = New System.Drawing.Size(32, 14)
        Me.LBLRATE.TabIndex = 152
        Me.LBLRATE.Text = "Rate"
        Me.LBLRATE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LBLRATE.Visible = False
        '
        'TXTRATE
        '
        Me.TXTRATE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTRATE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRATE.Location = New System.Drawing.Point(205, 73)
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(54, 22)
        Me.TXTRATE.TabIndex = 3
        Me.TXTRATE.Visible = False
        '
        'CMDOK
        '
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(74, 167)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 6
        Me.CMDOK.Text = "&Save"
        Me.CMDOK.UseVisualStyleBackColor = True
        '
        'EP
        '
        Me.EP.BlinkRate = 0
        Me.EP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EP.ContainerControl = Me
        '
        'ContractorWorkerRate
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(315, 251)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ContractorWorkerRate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Contractor Worker Rate"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.EP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As BlendPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents CMBPROCESS As ComboBox
    Friend WithEvents TXTWORKER As TextBox
    Friend WithEvents LBLWORKER As Label
    Friend WithEvents CMDEXIT As Button
    Friend WithEvents CMDCLEAR As Button
    Friend WithEvents CMDDELETE As Button
    Friend WithEvents LBLRATE As Label
    Friend WithEvents TXTRATE As TextBox
    Friend WithEvents CMDOK As Button
    Friend WithEvents Label38 As Label
    Friend WithEvents CMBCONTRACTOR As ComboBox
    Friend WithEvents EP As ErrorProvider
    Friend WithEvents TXTNIGHTRATE As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TXTDAYRATE As TextBox
    Friend WithEvents Label18 As Label
End Class
