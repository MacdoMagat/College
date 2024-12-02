<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Applicant_ViewRecord
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.examineelistdgv = New System.Windows.Forms.DataGridView()
        Me.idcol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.namecol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarkscol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dbid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.updatebtn = New System.Windows.Forms.Button()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.identificationnotxt = New System.Windows.Forms.TextBox()
        Me.lastnametxt = New System.Windows.Forms.TextBox()
        Me.firstnametxt = New System.Windows.Forms.TextBox()
        Me.middlenametxt = New System.Windows.Forms.TextBox()
        Me.addresstxt = New System.Windows.Forms.TextBox()
        Me.schoolattendedtxt = New System.Windows.Forms.TextBox()
        Me.qualificationtxt = New System.Windows.Forms.TextBox()
        Me.assessortxt = New System.Windows.Forms.TextBox()
        Me.assessmentcentertxt = New System.Windows.Forms.TextBox()
        Me.certificatenotxt = New System.Windows.Forms.TextBox()
        Me.competenciestxt = New System.Windows.Forms.TextBox()
        Me.controlnumbertxt = New System.Windows.Forms.TextBox()
        Me.statuscbo = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.dateofassessmenttxt = New System.Windows.Forms.MaskedTextBox()
        Me.dateofassessmentdtp = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.expirationdatetxt = New System.Windows.Forms.MaskedTextBox()
        Me.expirationdatedtp = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.searchtxt = New System.Windows.Forms.TextBox()
        Me.filtercbo = New System.Windows.Forms.ComboBox()
        Me.passedchk = New System.Windows.Forms.CheckBox()
        Me.failedchk = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.examineelistdgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackgroundImage = Global.eNC.My.Resources.Resources.bg1
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 896.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel10, 3, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 636.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1063, 682)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel4, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(17, 26)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.874214!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.12579!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(896, 636)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.13393!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.86607!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel5, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel6, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 30)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(896, 606)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.TableLayoutPanel5.ColumnCount = 3
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.examineelistdgv, 1, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel5.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 3
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(494, 606)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'examineelistdgv
        '
        Me.examineelistdgv.AllowUserToAddRows = False
        Me.examineelistdgv.AllowUserToDeleteRows = False
        Me.examineelistdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.examineelistdgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idcol, Me.namecol, Me.remarkscol, Me.dbid})
        Me.examineelistdgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.examineelistdgv.Location = New System.Drawing.Point(23, 23)
        Me.examineelistdgv.Name = "examineelistdgv"
        Me.examineelistdgv.ReadOnly = True
        Me.examineelistdgv.Size = New System.Drawing.Size(448, 560)
        Me.examineelistdgv.TabIndex = 0
        '
        'idcol
        '
        Me.idcol.HeaderText = "ID"
        Me.idcol.Name = "idcol"
        Me.idcol.ReadOnly = True
        '
        'namecol
        '
        Me.namecol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.namecol.HeaderText = "Name"
        Me.namecol.Name = "namecol"
        Me.namecol.ReadOnly = True
        '
        'remarkscol
        '
        Me.remarkscol.HeaderText = "Remarks"
        Me.remarkscol.Name = "remarkscol"
        Me.remarkscol.ReadOnly = True
        '
        'dbid
        '
        Me.dbid.HeaderText = "dbid"
        Me.dbid.Name = "dbid"
        Me.dbid.ReadOnly = True
        Me.dbid.Visible = False
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 3
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.updatebtn, 1, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.TableLayoutPanel7, 1, 1)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(494, 0)
        Me.TableLayoutPanel6.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 4
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(402, 606)
        Me.TableLayoutPanel6.TabIndex = 1
        '
        'updatebtn
        '
        Me.updatebtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(86, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(185, Byte), Integer))
        Me.updatebtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.updatebtn.FlatAppearance.BorderSize = 0
        Me.updatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.updatebtn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.updatebtn.ForeColor = System.Drawing.Color.White
        Me.updatebtn.Location = New System.Drawing.Point(1, 546)
        Me.updatebtn.Margin = New System.Windows.Forms.Padding(0)
        Me.updatebtn.Name = "updatebtn"
        Me.updatebtn.Size = New System.Drawing.Size(400, 40)
        Me.updatebtn.TabIndex = 0
        Me.updatebtn.Text = "Update"
        Me.updatebtn.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.66667!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.33333!))
        Me.TableLayoutPanel7.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel7.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel7.Controls.Add(Me.Label6, 0, 5)
        Me.TableLayoutPanel7.Controls.Add(Me.Label7, 0, 6)
        Me.TableLayoutPanel7.Controls.Add(Me.Label8, 0, 7)
        Me.TableLayoutPanel7.Controls.Add(Me.Label9, 0, 8)
        Me.TableLayoutPanel7.Controls.Add(Me.Label10, 0, 9)
        Me.TableLayoutPanel7.Controls.Add(Me.Label11, 0, 10)
        Me.TableLayoutPanel7.Controls.Add(Me.Label12, 0, 11)
        Me.TableLayoutPanel7.Controls.Add(Me.Label13, 0, 12)
        Me.TableLayoutPanel7.Controls.Add(Me.Label14, 0, 13)
        Me.TableLayoutPanel7.Controls.Add(Me.Label15, 0, 14)
        Me.TableLayoutPanel7.Controls.Add(Me.identificationnotxt, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.lastnametxt, 1, 1)
        Me.TableLayoutPanel7.Controls.Add(Me.firstnametxt, 1, 2)
        Me.TableLayoutPanel7.Controls.Add(Me.middlenametxt, 1, 3)
        Me.TableLayoutPanel7.Controls.Add(Me.addresstxt, 1, 4)
        Me.TableLayoutPanel7.Controls.Add(Me.schoolattendedtxt, 1, 5)
        Me.TableLayoutPanel7.Controls.Add(Me.qualificationtxt, 1, 6)
        Me.TableLayoutPanel7.Controls.Add(Me.assessortxt, 1, 7)
        Me.TableLayoutPanel7.Controls.Add(Me.assessmentcentertxt, 1, 8)
        Me.TableLayoutPanel7.Controls.Add(Me.certificatenotxt, 1, 10)
        Me.TableLayoutPanel7.Controls.Add(Me.competenciestxt, 1, 13)
        Me.TableLayoutPanel7.Controls.Add(Me.controlnumbertxt, 1, 14)
        Me.TableLayoutPanel7.Controls.Add(Me.statuscbo, 1, 9)
        Me.TableLayoutPanel7.Controls.Add(Me.TableLayoutPanel8, 1, 11)
        Me.TableLayoutPanel7.Controls.Add(Me.TableLayoutPanel9, 1, 12)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(1, 25)
        Me.TableLayoutPanel7.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 15
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666666!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(390, 521)
        Me.TableLayoutPanel7.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 5)
        Me.Label1.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Identification NO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 39)
        Me.Label2.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(169, 29)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Last Name:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 73)
        Me.Label3.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(169, 29)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "First Name:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 107)
        Me.Label4.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(169, 29)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Middle Name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(10, 141)
        Me.Label5.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(169, 29)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Address:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(10, 175)
        Me.Label6.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(169, 29)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "School Attended:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(10, 209)
        Me.Label7.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(169, 29)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Qualification:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(10, 243)
        Me.Label8.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(169, 29)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Assessor:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(10, 277)
        Me.Label9.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(169, 29)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Assessment Center:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(10, 311)
        Me.Label10.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(169, 29)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Status:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(10, 345)
        Me.Label11.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(169, 29)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Certificate NO:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(10, 379)
        Me.Label12.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(169, 29)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Date of Assessment:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(10, 413)
        Me.Label13.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(169, 29)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Expiration Date:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(10, 447)
        Me.Label14.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(169, 29)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Competencies:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(10, 481)
        Me.Label15.Margin = New System.Windows.Forms.Padding(10, 5, 3, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(169, 40)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Control Number:"
        '
        'identificationnotxt
        '
        Me.identificationnotxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.identificationnotxt.Location = New System.Drawing.Point(182, 5)
        Me.identificationnotxt.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.identificationnotxt.Name = "identificationnotxt"
        Me.identificationnotxt.Size = New System.Drawing.Size(198, 20)
        Me.identificationnotxt.TabIndex = 15
        '
        'lastnametxt
        '
        Me.lastnametxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lastnametxt.Location = New System.Drawing.Point(182, 39)
        Me.lastnametxt.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.lastnametxt.Name = "lastnametxt"
        Me.lastnametxt.Size = New System.Drawing.Size(198, 20)
        Me.lastnametxt.TabIndex = 16
        '
        'firstnametxt
        '
        Me.firstnametxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.firstnametxt.Location = New System.Drawing.Point(182, 73)
        Me.firstnametxt.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.firstnametxt.Name = "firstnametxt"
        Me.firstnametxt.Size = New System.Drawing.Size(198, 20)
        Me.firstnametxt.TabIndex = 17
        '
        'middlenametxt
        '
        Me.middlenametxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.middlenametxt.Location = New System.Drawing.Point(182, 107)
        Me.middlenametxt.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.middlenametxt.Name = "middlenametxt"
        Me.middlenametxt.Size = New System.Drawing.Size(198, 20)
        Me.middlenametxt.TabIndex = 18
        '
        'addresstxt
        '
        Me.addresstxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.addresstxt.Location = New System.Drawing.Point(182, 141)
        Me.addresstxt.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.addresstxt.Name = "addresstxt"
        Me.addresstxt.Size = New System.Drawing.Size(198, 20)
        Me.addresstxt.TabIndex = 19
        '
        'schoolattendedtxt
        '
        Me.schoolattendedtxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.schoolattendedtxt.Location = New System.Drawing.Point(182, 175)
        Me.schoolattendedtxt.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.schoolattendedtxt.Name = "schoolattendedtxt"
        Me.schoolattendedtxt.Size = New System.Drawing.Size(198, 20)
        Me.schoolattendedtxt.TabIndex = 20
        '
        'qualificationtxt
        '
        Me.qualificationtxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.qualificationtxt.Location = New System.Drawing.Point(182, 209)
        Me.qualificationtxt.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.qualificationtxt.Name = "qualificationtxt"
        Me.qualificationtxt.Size = New System.Drawing.Size(198, 20)
        Me.qualificationtxt.TabIndex = 21
        '
        'assessortxt
        '
        Me.assessortxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.assessortxt.Location = New System.Drawing.Point(182, 243)
        Me.assessortxt.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.assessortxt.Name = "assessortxt"
        Me.assessortxt.Size = New System.Drawing.Size(198, 20)
        Me.assessortxt.TabIndex = 22
        '
        'assessmentcentertxt
        '
        Me.assessmentcentertxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.assessmentcentertxt.Location = New System.Drawing.Point(182, 277)
        Me.assessmentcentertxt.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.assessmentcentertxt.Name = "assessmentcentertxt"
        Me.assessmentcentertxt.Size = New System.Drawing.Size(198, 20)
        Me.assessmentcentertxt.TabIndex = 23
        '
        'certificatenotxt
        '
        Me.certificatenotxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.certificatenotxt.Location = New System.Drawing.Point(182, 345)
        Me.certificatenotxt.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.certificatenotxt.Name = "certificatenotxt"
        Me.certificatenotxt.Size = New System.Drawing.Size(198, 20)
        Me.certificatenotxt.TabIndex = 25
        '
        'competenciestxt
        '
        Me.competenciestxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.competenciestxt.Location = New System.Drawing.Point(182, 447)
        Me.competenciestxt.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.competenciestxt.Name = "competenciestxt"
        Me.competenciestxt.Size = New System.Drawing.Size(198, 20)
        Me.competenciestxt.TabIndex = 28
        '
        'controlnumbertxt
        '
        Me.controlnumbertxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.controlnumbertxt.Location = New System.Drawing.Point(182, 481)
        Me.controlnumbertxt.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.controlnumbertxt.Name = "controlnumbertxt"
        Me.controlnumbertxt.Size = New System.Drawing.Size(198, 20)
        Me.controlnumbertxt.TabIndex = 29
        '
        'statuscbo
        '
        Me.statuscbo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.statuscbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.statuscbo.FormattingEnabled = True
        Me.statuscbo.Items.AddRange(New Object() {"Passed", "Failed"})
        Me.statuscbo.Location = New System.Drawing.Point(182, 311)
        Me.statuscbo.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.statuscbo.Name = "statuscbo"
        Me.statuscbo.Size = New System.Drawing.Size(198, 21)
        Me.statuscbo.TabIndex = 30
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.dateofassessmenttxt, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.dateofassessmentdtp, 1, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(182, 374)
        Me.TableLayoutPanel8.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(208, 34)
        Me.TableLayoutPanel8.TabIndex = 31
        '
        'dateofassessmenttxt
        '
        Me.dateofassessmenttxt.Location = New System.Drawing.Point(0, 5)
        Me.dateofassessmenttxt.Margin = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.dateofassessmenttxt.Mask = "00/00/0000"
        Me.dateofassessmenttxt.Name = "dateofassessmenttxt"
        Me.dateofassessmenttxt.Size = New System.Drawing.Size(100, 20)
        Me.dateofassessmenttxt.TabIndex = 0
        '
        'dateofassessmentdtp
        '
        Me.dateofassessmentdtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dateofassessmentdtp.Location = New System.Drawing.Point(104, 5)
        Me.dateofassessmentdtp.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.dateofassessmentdtp.Name = "dateofassessmentdtp"
        Me.dateofassessmentdtp.Size = New System.Drawing.Size(94, 20)
        Me.dateofassessmentdtp.TabIndex = 1
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 2
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.expirationdatetxt, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.expirationdatedtp, 1, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(182, 408)
        Me.TableLayoutPanel9.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(208, 34)
        Me.TableLayoutPanel9.TabIndex = 32
        '
        'expirationdatetxt
        '
        Me.expirationdatetxt.Location = New System.Drawing.Point(0, 5)
        Me.expirationdatetxt.Margin = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.expirationdatetxt.Mask = "00/00/0000"
        Me.expirationdatetxt.Name = "expirationdatetxt"
        Me.expirationdatetxt.Size = New System.Drawing.Size(100, 20)
        Me.expirationdatetxt.TabIndex = 0
        Me.expirationdatetxt.ValidatingType = GetType(Date)
        '
        'expirationdatedtp
        '
        Me.expirationdatedtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.expirationdatedtp.Location = New System.Drawing.Point(104, 5)
        Me.expirationdatedtp.Margin = New System.Windows.Forms.Padding(0, 5, 10, 0)
        Me.expirationdatedtp.Name = "expirationdatedtp"
        Me.expirationdatedtp.Size = New System.Drawing.Size(94, 20)
        Me.expirationdatedtp.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.TableLayoutPanel4.ColumnCount = 6
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 372.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.searchtxt, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.filtercbo, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.passedchk, 3, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.failedchk, 4, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(896, 30)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'searchtxt
        '
        Me.searchtxt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.searchtxt.Location = New System.Drawing.Point(22, 5)
        Me.searchtxt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.searchtxt.Name = "searchtxt"
        Me.searchtxt.Size = New System.Drawing.Size(366, 20)
        Me.searchtxt.TabIndex = 0
        '
        'filtercbo
        '
        Me.filtercbo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.filtercbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.filtercbo.FormattingEnabled = True
        Me.filtercbo.Items.AddRange(New Object() {"Last Name", "First Name", "Middle Name"})
        Me.filtercbo.Location = New System.Drawing.Point(394, 5)
        Me.filtercbo.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.filtercbo.Name = "filtercbo"
        Me.filtercbo.Size = New System.Drawing.Size(174, 21)
        Me.filtercbo.TabIndex = 1
        '
        'passedchk
        '
        Me.passedchk.AutoSize = True
        Me.passedchk.Checked = True
        Me.passedchk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.passedchk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.passedchk.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passedchk.ForeColor = System.Drawing.Color.White
        Me.passedchk.Location = New System.Drawing.Point(574, 5)
        Me.passedchk.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.passedchk.Name = "passedchk"
        Me.passedchk.Size = New System.Drawing.Size(94, 22)
        Me.passedchk.TabIndex = 2
        Me.passedchk.Text = "Passed"
        Me.passedchk.UseVisualStyleBackColor = True
        '
        'failedchk
        '
        Me.failedchk.AutoSize = True
        Me.failedchk.Checked = True
        Me.failedchk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.failedchk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.failedchk.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.failedchk.ForeColor = System.Drawing.Color.White
        Me.failedchk.Location = New System.Drawing.Point(674, 5)
        Me.failedchk.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.failedchk.Name = "failedchk"
        Me.failedchk.Size = New System.Drawing.Size(94, 22)
        Me.failedchk.TabIndex = 3
        Me.failedchk.Text = "Failed"
        Me.failedchk.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel10.ColumnCount = 1
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.Button1, 0, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.Button2, 0, 2)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(944, 26)
        Me.TableLayoutPanel10.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 4
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(99, 636)
        Me.TableLayoutPanel10.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.eNC.My.Resources.Resources.add
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Margin = New System.Windows.Forms.Padding(0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 90)
        Me.Button1.TabIndex = 0
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.eNC.My.Resources.Resources.print
        Me.Button2.Location = New System.Drawing.Point(0, 95)
        Me.Button2.Margin = New System.Windows.Forms.Padding(0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 90)
        Me.Button2.TabIndex = 1
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Applicant_ViewRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1063, 682)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Applicant_ViewRecord"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        CType(Me.examineelistdgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents examineelistdgv As DataGridView
    Friend WithEvents searchtxt As TextBox
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents updatebtn As Button
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents identificationnotxt As TextBox
    Friend WithEvents filtercbo As ComboBox
    Friend WithEvents passedchk As CheckBox
    Friend WithEvents failedchk As CheckBox
    Friend WithEvents lastnametxt As TextBox
    Friend WithEvents firstnametxt As TextBox
    Friend WithEvents middlenametxt As TextBox
    Friend WithEvents addresstxt As TextBox
    Friend WithEvents schoolattendedtxt As TextBox
    Friend WithEvents qualificationtxt As TextBox
    Friend WithEvents assessortxt As TextBox
    Friend WithEvents assessmentcentertxt As TextBox
    Friend WithEvents certificatenotxt As TextBox
    Friend WithEvents competenciestxt As TextBox
    Friend WithEvents controlnumbertxt As TextBox
    Friend WithEvents statuscbo As ComboBox
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents dateofassessmenttxt As MaskedTextBox
    Friend WithEvents dateofassessmentdtp As DateTimePicker
    Friend WithEvents TableLayoutPanel9 As TableLayoutPanel
    Friend WithEvents expirationdatetxt As MaskedTextBox
    Friend WithEvents expirationdatedtp As DateTimePicker
    Friend WithEvents idcol As DataGridViewTextBoxColumn
    Friend WithEvents namecol As DataGridViewTextBoxColumn
    Friend WithEvents remarkscol As DataGridViewTextBoxColumn
    Friend WithEvents dbid As DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel10 As TableLayoutPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
