<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stocks_Approved
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.crpo = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.sendmailtool = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'crpo
        '
        Me.crpo.ActiveViewIndex = -1
        Me.crpo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crpo.Cursor = System.Windows.Forms.Cursors.Default
        Me.crpo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crpo.EnableDrillDown = False
        Me.crpo.Location = New System.Drawing.Point(0, 25)
        Me.crpo.Name = "crpo"
        Me.crpo.SelectionFormula = ""
        Me.crpo.Size = New System.Drawing.Size(974, 568)
        Me.crpo.TabIndex = 200
        Me.crpo.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crpo.ViewTimeSelectionFormula = ""
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sendmailtool})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(974, 25)
        Me.ToolStrip1.TabIndex = 199
        Me.ToolStrip1.Text = "v"
        '
        'sendmailtool
        '
        Me.sendmailtool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.sendmailtool.Image = Global.TexPro_V1.My.Resources.Resources.sendforms
        Me.sendmailtool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.sendmailtool.Name = "sendmailtool"
        Me.sendmailtool.Size = New System.Drawing.Size(23, 22)
        Me.sendmailtool.Text = "Send E-Mail"
        '
        'Stocks_Approved
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(974, 593)
        Me.Controls.Add(Me.crpo)
        Me.Controls.Add(Me.ToolStrip1)
        Me.KeyPreview = True
        Me.Name = "Stocks_Approved"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Approved Stock"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents crpo As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents sendmailtool As System.Windows.Forms.ToolStripButton
End Class
