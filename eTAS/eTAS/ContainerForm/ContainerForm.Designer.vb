<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ContainerForm
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnTopThesis = New System.Windows.Forms.Button()
        Me.btnViewThesis = New System.Windows.Forms.Button()
        Me.btnContentSearch = New System.Windows.Forms.Button()
        Me.btnArchiveThesis = New System.Windows.Forms.Button()
        Me.btnAdmin = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.btnAuditTrail = New System.Windows.Forms.Button()
        Me.btnTitleDatabase = New System.Windows.Forms.Button()
        Me.btnSpellingAndGrammarChecker = New System.Windows.Forms.Button()
        Me.btnRemoveThesis = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.btnMaximize = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.leftnavanimation = New System.Windows.Forms.Timer(Me.components)
        Me.mainpanelanimation = New System.Windows.Forms.Timer(Me.components)
        Me.leftnavcloseanimation = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(200, 30)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(967, 696)
        Me.Panel1.TabIndex = 5
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1167, 726)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.TableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnLogout, 0, 12)
        Me.TableLayoutPanel2.Controls.Add(Me.btnHome, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnTopThesis, 0, 6)
        Me.TableLayoutPanel2.Controls.Add(Me.btnViewThesis, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.btnContentSearch, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.btnArchiveThesis, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAdmin, 0, 8)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAbout, 0, 11)
        Me.TableLayoutPanel2.Controls.Add(Me.btnAuditTrail, 0, 7)
        Me.TableLayoutPanel2.Controls.Add(Me.btnTitleDatabase, 0, 9)
        Me.TableLayoutPanel2.Controls.Add(Me.btnSpellingAndGrammarChecker, 0, 10)
        Me.TableLayoutPanel2.Controls.Add(Me.btnRemoveThesis, 0, 3)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 30)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 14
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(200, 696)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.Transparent
        Me.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.ForeColor = System.Drawing.Color.White
        Me.btnLogout.Location = New System.Drawing.Point(0, 470)
        Me.btnLogout.Margin = New System.Windows.Forms.Padding(0)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(200, 45)
        Me.btnLogout.TabIndex = 7
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.Color.Transparent
        Me.btnHome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHome.FlatAppearance.BorderSize = 0
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHome.ForeColor = System.Drawing.Color.White
        Me.btnHome.Location = New System.Drawing.Point(0, 20)
        Me.btnHome.Margin = New System.Windows.Forms.Padding(0)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(200, 45)
        Me.btnHome.TabIndex = 6
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnTopThesis
        '
        Me.btnTopThesis.BackColor = System.Drawing.Color.Transparent
        Me.btnTopThesis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnTopThesis.FlatAppearance.BorderSize = 0
        Me.btnTopThesis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTopThesis.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTopThesis.ForeColor = System.Drawing.Color.White
        Me.btnTopThesis.Location = New System.Drawing.Point(0, 245)
        Me.btnTopThesis.Margin = New System.Windows.Forms.Padding(0)
        Me.btnTopThesis.Name = "btnTopThesis"
        Me.btnTopThesis.Size = New System.Drawing.Size(200, 45)
        Me.btnTopThesis.TabIndex = 4
        Me.btnTopThesis.Text = "Top Thesis"
        Me.btnTopThesis.UseVisualStyleBackColor = False
        '
        'btnViewThesis
        '
        Me.btnViewThesis.BackColor = System.Drawing.Color.Transparent
        Me.btnViewThesis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnViewThesis.FlatAppearance.BorderSize = 0
        Me.btnViewThesis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewThesis.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewThesis.ForeColor = System.Drawing.Color.White
        Me.btnViewThesis.Location = New System.Drawing.Point(0, 155)
        Me.btnViewThesis.Margin = New System.Windows.Forms.Padding(0)
        Me.btnViewThesis.Name = "btnViewThesis"
        Me.btnViewThesis.Size = New System.Drawing.Size(200, 45)
        Me.btnViewThesis.TabIndex = 2
        Me.btnViewThesis.Text = "View Thesis"
        Me.btnViewThesis.UseVisualStyleBackColor = False
        '
        'btnContentSearch
        '
        Me.btnContentSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnContentSearch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnContentSearch.FlatAppearance.BorderSize = 0
        Me.btnContentSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContentSearch.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContentSearch.ForeColor = System.Drawing.Color.White
        Me.btnContentSearch.Location = New System.Drawing.Point(0, 200)
        Me.btnContentSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.btnContentSearch.Name = "btnContentSearch"
        Me.btnContentSearch.Size = New System.Drawing.Size(200, 45)
        Me.btnContentSearch.TabIndex = 3
        Me.btnContentSearch.Text = "Content Search"
        Me.btnContentSearch.UseVisualStyleBackColor = False
        '
        'btnArchiveThesis
        '
        Me.btnArchiveThesis.BackColor = System.Drawing.Color.Transparent
        Me.btnArchiveThesis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnArchiveThesis.FlatAppearance.BorderSize = 0
        Me.btnArchiveThesis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnArchiveThesis.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArchiveThesis.ForeColor = System.Drawing.Color.White
        Me.btnArchiveThesis.Location = New System.Drawing.Point(0, 65)
        Me.btnArchiveThesis.Margin = New System.Windows.Forms.Padding(0)
        Me.btnArchiveThesis.Name = "btnArchiveThesis"
        Me.btnArchiveThesis.Size = New System.Drawing.Size(200, 45)
        Me.btnArchiveThesis.TabIndex = 1
        Me.btnArchiveThesis.Text = "Import Thesis"
        Me.btnArchiveThesis.UseVisualStyleBackColor = False
        '
        'btnAdmin
        '
        Me.btnAdmin.BackColor = System.Drawing.Color.Transparent
        Me.btnAdmin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAdmin.FlatAppearance.BorderSize = 0
        Me.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdmin.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdmin.ForeColor = System.Drawing.Color.White
        Me.btnAdmin.Location = New System.Drawing.Point(0, 335)
        Me.btnAdmin.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAdmin.Name = "btnAdmin"
        Me.btnAdmin.Size = New System.Drawing.Size(200, 45)
        Me.btnAdmin.TabIndex = 8
        Me.btnAdmin.Text = "Admin"
        Me.btnAdmin.UseVisualStyleBackColor = False
        '
        'btnAbout
        '
        Me.btnAbout.BackColor = System.Drawing.Color.Transparent
        Me.btnAbout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAbout.FlatAppearance.BorderSize = 0
        Me.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbout.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbout.ForeColor = System.Drawing.Color.White
        Me.btnAbout.Location = New System.Drawing.Point(0, 425)
        Me.btnAbout.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(200, 45)
        Me.btnAbout.TabIndex = 9
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = False
        '
        'btnAuditTrail
        '
        Me.btnAuditTrail.BackColor = System.Drawing.Color.Transparent
        Me.btnAuditTrail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAuditTrail.FlatAppearance.BorderSize = 0
        Me.btnAuditTrail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAuditTrail.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.btnAuditTrail.ForeColor = System.Drawing.Color.White
        Me.btnAuditTrail.Location = New System.Drawing.Point(0, 290)
        Me.btnAuditTrail.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAuditTrail.Name = "btnAuditTrail"
        Me.btnAuditTrail.Size = New System.Drawing.Size(200, 45)
        Me.btnAuditTrail.TabIndex = 11
        Me.btnAuditTrail.Text = "Logs"
        Me.btnAuditTrail.UseVisualStyleBackColor = False
        '
        'btnTitleDatabase
        '
        Me.btnTitleDatabase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnTitleDatabase.FlatAppearance.BorderSize = 0
        Me.btnTitleDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTitleDatabase.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.btnTitleDatabase.ForeColor = System.Drawing.Color.White
        Me.btnTitleDatabase.Location = New System.Drawing.Point(0, 380)
        Me.btnTitleDatabase.Margin = New System.Windows.Forms.Padding(0)
        Me.btnTitleDatabase.Name = "btnTitleDatabase"
        Me.btnTitleDatabase.Size = New System.Drawing.Size(200, 45)
        Me.btnTitleDatabase.TabIndex = 12
        Me.btnTitleDatabase.Text = "Title Database"
        Me.btnTitleDatabase.UseVisualStyleBackColor = True
        '
        'btnSpellingAndGrammarChecker
        '
        Me.btnSpellingAndGrammarChecker.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSpellingAndGrammarChecker.Enabled = False
        Me.btnSpellingAndGrammarChecker.FlatAppearance.BorderSize = 0
        Me.btnSpellingAndGrammarChecker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSpellingAndGrammarChecker.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.btnSpellingAndGrammarChecker.ForeColor = System.Drawing.Color.White
        Me.btnSpellingAndGrammarChecker.Location = New System.Drawing.Point(0, 425)
        Me.btnSpellingAndGrammarChecker.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSpellingAndGrammarChecker.Name = "btnSpellingAndGrammarChecker"
        Me.btnSpellingAndGrammarChecker.Size = New System.Drawing.Size(200, 1)
        Me.btnSpellingAndGrammarChecker.TabIndex = 13
        Me.btnSpellingAndGrammarChecker.Text = "Spelling && Grammar"
        Me.btnSpellingAndGrammarChecker.UseVisualStyleBackColor = True
        Me.btnSpellingAndGrammarChecker.Visible = False
        '
        'btnRemoveThesis
        '
        Me.btnRemoveThesis.BackColor = System.Drawing.Color.Transparent
        Me.btnRemoveThesis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnRemoveThesis.FlatAppearance.BorderSize = 0
        Me.btnRemoveThesis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveThesis.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.btnRemoveThesis.ForeColor = System.Drawing.Color.White
        Me.btnRemoveThesis.Location = New System.Drawing.Point(0, 110)
        Me.btnRemoveThesis.Margin = New System.Windows.Forms.Padding(0)
        Me.btnRemoveThesis.Name = "btnRemoveThesis"
        Me.btnRemoveThesis.Size = New System.Drawing.Size(200, 45)
        Me.btnRemoveThesis.TabIndex = 14
        Me.btnRemoveThesis.Text = "Archive Thesis"
        Me.btnRemoveThesis.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnMinimize, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnMaximize, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnClose, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel4, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(200, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(967, 30)
        Me.TableLayoutPanel3.TabIndex = 6
        '
        'btnMinimize
        '
        Me.btnMinimize.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.btnMinimize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnMinimize.FlatAppearance.BorderSize = 0
        Me.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimize.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.btnMinimize.Location = New System.Drawing.Point(787, 0)
        Me.btnMinimize.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(60, 30)
        Me.btnMinimize.TabIndex = 0
        Me.btnMinimize.Text = "_"
        Me.btnMinimize.UseVisualStyleBackColor = False
        '
        'btnMaximize
        '
        Me.btnMaximize.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.btnMaximize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnMaximize.FlatAppearance.BorderSize = 0
        Me.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMaximize.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.btnMaximize.Location = New System.Drawing.Point(847, 0)
        Me.btnMaximize.Margin = New System.Windows.Forms.Padding(0)
        Me.btnMaximize.Name = "btnMaximize"
        Me.btnMaximize.Size = New System.Drawing.Size(60, 30)
        Me.btnMaximize.TabIndex = 1
        Me.btnMaximize.Text = "□"
        Me.btnMaximize.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.btnClose.Location = New System.Drawing.Point(907, 0)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(60, 30)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(787, 30)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(761, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Axtaris"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(185, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 30)
        Me.Panel2.TabIndex = 7
        '
        'leftnavanimation
        '
        Me.leftnavanimation.Interval = 1
        '
        'mainpanelanimation
        '
        '
        'leftnavcloseanimation
        '
        Me.leftnavcloseanimation.Interval = 1
        '
        'ContainerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1167, 726)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimumSize = New System.Drawing.Size(1167, 726)
        Me.Name = "ContainerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents leftnavanimation As Timer
    Friend WithEvents mainpanelanimation As Timer
    Friend WithEvents leftnavcloseanimation As Timer
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents btnTopThesis As Button
    Friend WithEvents btnViewThesis As Button
    Friend WithEvents btnContentSearch As Button
    Friend WithEvents btnArchiveThesis As Button
    Friend WithEvents btnAdmin As Button
    Friend WithEvents btnAbout As Button
    Friend WithEvents btnAuditTrail As Button
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents btnMinimize As Button
    Friend WithEvents btnMaximize As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnTitleDatabase As Button
    Friend WithEvents btnSpellingAndGrammarChecker As Button
    Friend WithEvents btnRemoveThesis As Button
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Label1 As Label
End Class
