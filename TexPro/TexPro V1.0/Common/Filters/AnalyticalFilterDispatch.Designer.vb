<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AnalyticalFilterDispatch
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
        Me.CMBTYPE = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RDBTOPAGENT = New System.Windows.Forms.RadioButton()
        Me.TXTMTRSGREATER = New System.Windows.Forms.TextBox()
        Me.RDBTOPSTATE = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RDBTOPCITY = New System.Windows.Forms.RadioButton()
        Me.CMBSTATE = New System.Windows.Forms.ComboBox()
        Me.RDBTOPMERCHANT = New System.Windows.Forms.RadioButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TXTTOP = New System.Windows.Forms.TextBox()
        Me.CMBAGENT = New System.Windows.Forms.ComboBox()
        Me.RDBTOPPARTY = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTMERCHANT = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CMBCITY = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtadd = New System.Windows.Forms.TextBox()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkdate = New System.Windows.Forms.CheckBox()
        Me.cmbmerchant = New System.Windows.Forms.ComboBox()
        Me.lblvendorname = New System.Windows.Forms.Label()
        Me.cmdshowreport = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CLB_CATEGORY = New System.Windows.Forms.CheckedListBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CLB_DEPARTMENT = New System.Windows.Forms.CheckedListBox()
        Me.CLB_GRADE = New System.Windows.Forms.CheckedListBox()
        Me.BlendPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.CLB_CATEGORY)
        Me.BlendPanel1.Controls.Add(Me.Label15)
        Me.BlendPanel1.Controls.Add(Me.Label11)
        Me.BlendPanel1.Controls.Add(Me.CLB_DEPARTMENT)
        Me.BlendPanel1.Controls.Add(Me.CLB_GRADE)
        Me.BlendPanel1.Controls.Add(Me.CMBTYPE)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.RDBTOPAGENT)
        Me.BlendPanel1.Controls.Add(Me.TXTMTRSGREATER)
        Me.BlendPanel1.Controls.Add(Me.RDBTOPSTATE)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.RDBTOPCITY)
        Me.BlendPanel1.Controls.Add(Me.CMBSTATE)
        Me.BlendPanel1.Controls.Add(Me.RDBTOPMERCHANT)
        Me.BlendPanel1.Controls.Add(Me.Label14)
        Me.BlendPanel1.Controls.Add(Me.TXTTOP)
        Me.BlendPanel1.Controls.Add(Me.CMBAGENT)
        Me.BlendPanel1.Controls.Add(Me.RDBTOPPARTY)
        Me.BlendPanel1.Controls.Add(Me.Label12)
        Me.BlendPanel1.Controls.Add(Me.TXTMERCHANT)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.CMBCITY)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.txtadd)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.GroupBox2)
        Me.BlendPanel1.Controls.Add(Me.cmbmerchant)
        Me.BlendPanel1.Controls.Add(Me.lblvendorname)
        Me.BlendPanel1.Controls.Add(Me.cmdshowreport)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(790, 523)
        Me.BlendPanel1.TabIndex = 0
        '
        'CMBTYPE
        '
        Me.CMBTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTYPE.FormattingEnabled = True
        Me.CMBTYPE.Items.AddRange(New Object() {"", "JOB", "ACTUAL DISPATCH"})
        Me.CMBTYPE.Location = New System.Drawing.Point(93, 134)
        Me.CMBTYPE.MaxDropDownItems = 14
        Me.CMBTYPE.Name = "CMBTYPE"
        Me.CMBTYPE.Size = New System.Drawing.Size(207, 22)
        Me.CMBTYPE.TabIndex = 539
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(60, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 14)
        Me.Label3.TabIndex = 540
        Me.Label3.Text = "Type"
        '
        'RDBTOPAGENT
        '
        Me.RDBTOPAGENT.AutoSize = True
        Me.RDBTOPAGENT.BackColor = System.Drawing.Color.Transparent
        Me.RDBTOPAGENT.Location = New System.Drawing.Point(93, 283)
        Me.RDBTOPAGENT.Name = "RDBTOPAGENT"
        Me.RDBTOPAGENT.Size = New System.Drawing.Size(78, 19)
        Me.RDBTOPAGENT.TabIndex = 12
        Me.RDBTOPAGENT.Text = "Top Agent"
        Me.RDBTOPAGENT.UseVisualStyleBackColor = False
        '
        'TXTMTRSGREATER
        '
        Me.TXTMTRSGREATER.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTMTRSGREATER.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMTRSGREATER.Location = New System.Drawing.Point(398, 78)
        Me.TXTMTRSGREATER.Name = "TXTMTRSGREATER"
        Me.TXTMTRSGREATER.Size = New System.Drawing.Size(77, 22)
        Me.TXTMTRSGREATER.TabIndex = 6
        '
        'RDBTOPSTATE
        '
        Me.RDBTOPSTATE.AutoSize = True
        Me.RDBTOPSTATE.BackColor = System.Drawing.Color.Transparent
        Me.RDBTOPSTATE.Location = New System.Drawing.Point(93, 259)
        Me.RDBTOPSTATE.Name = "RDBTOPSTATE"
        Me.RDBTOPSTATE.Size = New System.Drawing.Size(73, 19)
        Me.RDBTOPSTATE.TabIndex = 11
        Me.RDBTOPSTATE.Text = "Top State"
        Me.RDBTOPSTATE.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(329, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 14)
        Me.Label1.TabIndex = 536
        Me.Label1.Text = "Mtrs > Then"
        '
        'RDBTOPCITY
        '
        Me.RDBTOPCITY.AutoSize = True
        Me.RDBTOPCITY.BackColor = System.Drawing.Color.Transparent
        Me.RDBTOPCITY.Location = New System.Drawing.Point(93, 235)
        Me.RDBTOPCITY.Name = "RDBTOPCITY"
        Me.RDBTOPCITY.Size = New System.Drawing.Size(67, 19)
        Me.RDBTOPCITY.TabIndex = 10
        Me.RDBTOPCITY.Text = "Top City"
        Me.RDBTOPCITY.UseVisualStyleBackColor = False
        '
        'CMBSTATE
        '
        Me.CMBSTATE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBSTATE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBSTATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBSTATE.FormattingEnabled = True
        Me.CMBSTATE.Location = New System.Drawing.Point(93, 106)
        Me.CMBSTATE.MaxDropDownItems = 14
        Me.CMBSTATE.Name = "CMBSTATE"
        Me.CMBSTATE.Size = New System.Drawing.Size(207, 22)
        Me.CMBSTATE.TabIndex = 3
        '
        'RDBTOPMERCHANT
        '
        Me.RDBTOPMERCHANT.AutoSize = True
        Me.RDBTOPMERCHANT.BackColor = System.Drawing.Color.Transparent
        Me.RDBTOPMERCHANT.Location = New System.Drawing.Point(93, 211)
        Me.RDBTOPMERCHANT.Name = "RDBTOPMERCHANT"
        Me.RDBTOPMERCHANT.Size = New System.Drawing.Size(98, 19)
        Me.RDBTOPMERCHANT.TabIndex = 9
        Me.RDBTOPMERCHANT.Text = "Top Merchant"
        Me.RDBTOPMERCHANT.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(56, 110)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(33, 14)
        Me.Label14.TabIndex = 532
        Me.Label14.Text = "State"
        '
        'TXTTOP
        '
        Me.TXTTOP.BackColor = System.Drawing.Color.White
        Me.TXTTOP.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTOP.ForeColor = System.Drawing.Color.Black
        Me.TXTTOP.Location = New System.Drawing.Point(93, 308)
        Me.TXTTOP.Name = "TXTTOP"
        Me.TXTTOP.Size = New System.Drawing.Size(29, 22)
        Me.TXTTOP.TabIndex = 13
        Me.TXTTOP.Text = "10"
        Me.TXTTOP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CMBAGENT
        '
        Me.CMBAGENT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBAGENT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBAGENT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBAGENT.FormattingEnabled = True
        Me.CMBAGENT.Location = New System.Drawing.Point(398, 22)
        Me.CMBAGENT.MaxDropDownItems = 14
        Me.CMBAGENT.Name = "CMBAGENT"
        Me.CMBAGENT.Size = New System.Drawing.Size(207, 22)
        Me.CMBAGENT.TabIndex = 4
        '
        'RDBTOPPARTY
        '
        Me.RDBTOPPARTY.AutoSize = True
        Me.RDBTOPPARTY.BackColor = System.Drawing.Color.Transparent
        Me.RDBTOPPARTY.Checked = True
        Me.RDBTOPPARTY.Location = New System.Drawing.Point(93, 187)
        Me.RDBTOPPARTY.Name = "RDBTOPPARTY"
        Me.RDBTOPPARTY.Size = New System.Drawing.Size(75, 19)
        Me.RDBTOPPARTY.TabIndex = 8
        Me.RDBTOPPARTY.TabStop = True
        Me.RDBTOPPARTY.Text = "Top Party"
        Me.RDBTOPPARTY.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(326, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 14)
        Me.Label12.TabIndex = 530
        Me.Label12.Text = "Agent Name"
        '
        'TXTMERCHANT
        '
        Me.TXTMERCHANT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTMERCHANT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMERCHANT.Location = New System.Drawing.Point(398, 50)
        Me.TXTMERCHANT.Name = "TXTMERCHANT"
        Me.TXTMERCHANT.Size = New System.Drawing.Size(207, 22)
        Me.TXTMERCHANT.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(319, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 14)
        Me.Label9.TabIndex = 453
        Me.Label9.Text = "Merchant Like"
        '
        'CMBCITY
        '
        Me.CMBCITY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCITY.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCITY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCITY.FormattingEnabled = True
        Me.CMBCITY.Location = New System.Drawing.Point(93, 78)
        Me.CMBCITY.MaxDropDownItems = 14
        Me.CMBCITY.Name = "CMBCITY"
        Me.CMBCITY.Size = New System.Drawing.Size(207, 22)
        Me.CMBCITY.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(64, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 14)
        Me.Label7.TabIndex = 451
        Me.Label7.Text = "City"
        '
        'txtadd
        '
        Me.txtadd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtadd.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtadd.Location = New System.Drawing.Point(611, 22)
        Me.txtadd.Name = "txtadd"
        Me.txtadd.Size = New System.Drawing.Size(20, 22)
        Me.txtadd.TabIndex = 444
        Me.txtadd.Visible = False
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Location = New System.Drawing.Point(93, 22)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(207, 22)
        Me.cmbname.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(52, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 14)
        Me.Label8.TabIndex = 433
        Me.Label8.Text = "Name"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtto)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dtfrom)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.chkdate)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(115, 348)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(280, 53)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        '
        'dtto
        '
        Me.dtto.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtto.Location = New System.Drawing.Point(189, 20)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(83, 22)
        Me.dtto.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(161, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 14)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "To :"
        '
        'dtfrom
        '
        Me.dtfrom.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtfrom.Location = New System.Drawing.Point(50, 20)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(83, 22)
        Me.dtfrom.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(9, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 14)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "From :"
        '
        'chkdate
        '
        Me.chkdate.AutoSize = True
        Me.chkdate.BackColor = System.Drawing.Color.Transparent
        Me.chkdate.Checked = True
        Me.chkdate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkdate.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkdate.ForeColor = System.Drawing.Color.Black
        Me.chkdate.Location = New System.Drawing.Point(17, -2)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Size = New System.Drawing.Size(49, 18)
        Me.chkdate.TabIndex = 0
        Me.chkdate.Text = "Date"
        Me.chkdate.UseVisualStyleBackColor = False
        '
        'cmbmerchant
        '
        Me.cmbmerchant.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbmerchant.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbmerchant.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbmerchant.FormattingEnabled = True
        Me.cmbmerchant.Location = New System.Drawing.Point(93, 50)
        Me.cmbmerchant.MaxDropDownItems = 14
        Me.cmbmerchant.Name = "cmbmerchant"
        Me.cmbmerchant.Size = New System.Drawing.Size(207, 22)
        Me.cmbmerchant.TabIndex = 1
        '
        'lblvendorname
        '
        Me.lblvendorname.AutoSize = True
        Me.lblvendorname.BackColor = System.Drawing.Color.Transparent
        Me.lblvendorname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvendorname.ForeColor = System.Drawing.Color.Black
        Me.lblvendorname.Location = New System.Drawing.Point(35, 54)
        Me.lblvendorname.Name = "lblvendorname"
        Me.lblvendorname.Size = New System.Drawing.Size(54, 14)
        Me.lblvendorname.TabIndex = 419
        Me.lblvendorname.Text = "Merchant"
        '
        'cmdshowreport
        '
        Me.cmdshowreport.BackColor = System.Drawing.Color.Transparent
        Me.cmdshowreport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdshowreport.FlatAppearance.BorderSize = 0
        Me.cmdshowreport.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdshowreport.ForeColor = System.Drawing.Color.Black
        Me.cmdshowreport.Location = New System.Drawing.Point(168, 413)
        Me.cmdshowreport.Name = "cmdshowreport"
        Me.cmdshowreport.Size = New System.Drawing.Size(84, 28)
        Me.cmdshowreport.TabIndex = 15
        Me.cmdshowreport.Text = "&Show Report"
        Me.cmdshowreport.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(258, 413)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(84, 28)
        Me.cmdexit.TabIndex = 16
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(567, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 14)
        Me.Label2.TabIndex = 765
        Me.Label2.Text = "Category"
        '
        'CLB_CATEGORY
        '
        Me.CLB_CATEGORY.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_CATEGORY.FormattingEnabled = True
        Me.CLB_CATEGORY.Location = New System.Drawing.Point(621, 106)
        Me.CLB_CATEGORY.Name = "CLB_CATEGORY"
        Me.CLB_CATEGORY.ScrollAlwaysVisible = True
        Me.CLB_CATEGORY.Size = New System.Drawing.Size(159, 72)
        Me.CLB_CATEGORY.TabIndex = 764
        Me.CLB_CATEGORY.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(325, 188)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 14)
        Me.Label15.TabIndex = 763
        Me.Label15.Text = "Department"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(357, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 14)
        Me.Label11.TabIndex = 762
        Me.Label11.Text = "Grade"
        '
        'CLB_DEPARTMENT
        '
        Me.CLB_DEPARTMENT.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_DEPARTMENT.FormattingEnabled = True
        Me.CLB_DEPARTMENT.Location = New System.Drawing.Point(398, 184)
        Me.CLB_DEPARTMENT.Name = "CLB_DEPARTMENT"
        Me.CLB_DEPARTMENT.ScrollAlwaysVisible = True
        Me.CLB_DEPARTMENT.Size = New System.Drawing.Size(159, 72)
        Me.CLB_DEPARTMENT.TabIndex = 761
        Me.CLB_DEPARTMENT.TabStop = False
        '
        'CLB_GRADE
        '
        Me.CLB_GRADE.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.CLB_GRADE.FormattingEnabled = True
        Me.CLB_GRADE.Location = New System.Drawing.Point(398, 106)
        Me.CLB_GRADE.Name = "CLB_GRADE"
        Me.CLB_GRADE.ScrollAlwaysVisible = True
        Me.CLB_GRADE.Size = New System.Drawing.Size(159, 72)
        Me.CLB_GRADE.TabIndex = 760
        Me.CLB_GRADE.TabStop = False
        '
        'AnalyticalFilterDispatch
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(790, 523)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "AnalyticalFilterDispatch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Analytical Filter Dispatch"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As BlendPanel
    Friend WithEvents CMBSTATE As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents CMBAGENT As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents CMBCITY As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtadd As TextBox
    Friend WithEvents RDBTOPPARTY As RadioButton
    Friend WithEvents cmbname As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents chkdate As CheckBox
    Friend WithEvents cmbmerchant As ComboBox
    Friend WithEvents lblvendorname As Label
    Friend WithEvents cmdshowreport As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents TXTMTRSGREATER As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RDBTOPAGENT As RadioButton
    Friend WithEvents RDBTOPSTATE As RadioButton
    Friend WithEvents RDBTOPCITY As RadioButton
    Friend WithEvents RDBTOPMERCHANT As RadioButton
    Friend WithEvents TXTTOP As TextBox
    Friend WithEvents TXTMERCHANT As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents CMBTYPE As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CLB_CATEGORY As CheckedListBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents CLB_DEPARTMENT As CheckedListBox
    Friend WithEvents CLB_GRADE As CheckedListBox
End Class
