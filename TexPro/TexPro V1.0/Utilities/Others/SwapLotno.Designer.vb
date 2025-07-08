<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SwapLotno
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
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtlotno = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtswaplotno = New System.Windows.Forms.TextBox
        Me.cmdok = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(44, 38)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 14)
        Me.Label14.TabIndex = 654
        Me.Label14.Text = "Lot no."
        '
        'txtlotno
        '
        Me.txtlotno.BackColor = System.Drawing.Color.White
        Me.txtlotno.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.txtlotno.Location = New System.Drawing.Point(93, 34)
        Me.txtlotno.Name = "txtlotno"
        Me.txtlotno.ReadOnly = True
        Me.txtlotno.Size = New System.Drawing.Size(50, 22)
        Me.txtlotno.TabIndex = 653
        Me.txtlotno.TabStop = False
        Me.txtlotno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(18, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 14)
        Me.Label1.TabIndex = 656
        Me.Label1.Text = "Swap Lotno"
        '
        'txtswaplotno
        '
        Me.txtswaplotno.BackColor = System.Drawing.Color.White
        Me.txtswaplotno.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.txtswaplotno.Location = New System.Drawing.Point(93, 62)
        Me.txtswaplotno.Name = "txtswaplotno"
        Me.txtswaplotno.ReadOnly = True
        Me.txtswaplotno.Size = New System.Drawing.Size(50, 22)
        Me.txtswaplotno.TabIndex = 655
        Me.txtswaplotno.TabStop = False
        Me.txtswaplotno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Image = Global.TexPro_V1.My.Resources.Resources.ok
        Me.cmdok.Location = New System.Drawing.Point(12, 96)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(75, 28)
        Me.cmdok.TabIndex = 657
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Image = Global.TexPro_V1.My.Resources.Resources._Exit
        Me.cmdexit.Location = New System.Drawing.Point(93, 100)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(72, 24)
        Me.cmdexit.TabIndex = 658
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'SwapLotno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(172, 136)
        Me.Controls.Add(Me.cmdok)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtswaplotno)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtlotno)
        Me.Name = "SwapLotno"
        Me.Text = "SwapLotno"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtlotno As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtswaplotno As System.Windows.Forms.TextBox
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
End Class
