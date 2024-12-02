<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.homebtn = New System.Windows.Forms.Button()
        Me.applicantbtn = New System.Windows.Forms.Button()
        Me.reportsbtn = New System.Windows.Forms.Button()
        Me.adminbtn = New System.Windows.Forms.Button()
        Me.aboutbtn = New System.Windows.Forms.Button()
        Me.helpbtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1284, 721)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.homebtn, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.applicantbtn, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.reportsbtn, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.adminbtn, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.aboutbtn, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.helpbtn, 0, 6)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 8
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(205, 721)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'homebtn
        '
        Me.homebtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.homebtn.FlatAppearance.BorderSize = 0
        Me.homebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.homebtn.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.homebtn.ForeColor = System.Drawing.Color.White
        Me.homebtn.Image = Global.eNC.My.Resources.Resources.home
        Me.homebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.homebtn.Location = New System.Drawing.Point(0, 50)
        Me.homebtn.Margin = New System.Windows.Forms.Padding(0)
        Me.homebtn.Name = "homebtn"
        Me.homebtn.Size = New System.Drawing.Size(205, 50)
        Me.homebtn.TabIndex = 0
        Me.homebtn.Text = "HOME"
        Me.homebtn.UseVisualStyleBackColor = True
        '
        'applicantbtn
        '
        Me.applicantbtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.applicantbtn.FlatAppearance.BorderSize = 0
        Me.applicantbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.applicantbtn.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.applicantbtn.ForeColor = System.Drawing.Color.White
        Me.applicantbtn.Image = Global.eNC.My.Resources.Resources.applicant
        Me.applicantbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.applicantbtn.Location = New System.Drawing.Point(0, 100)
        Me.applicantbtn.Margin = New System.Windows.Forms.Padding(0)
        Me.applicantbtn.Name = "applicantbtn"
        Me.applicantbtn.Size = New System.Drawing.Size(205, 50)
        Me.applicantbtn.TabIndex = 1
        Me.applicantbtn.Text = "APPLICANT"
        Me.applicantbtn.UseVisualStyleBackColor = True
        '
        'reportsbtn
        '
        Me.reportsbtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reportsbtn.FlatAppearance.BorderSize = 0
        Me.reportsbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.reportsbtn.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.reportsbtn.ForeColor = System.Drawing.Color.White
        Me.reportsbtn.Image = Global.eNC.My.Resources.Resources.report
        Me.reportsbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.reportsbtn.Location = New System.Drawing.Point(0, 150)
        Me.reportsbtn.Margin = New System.Windows.Forms.Padding(0)
        Me.reportsbtn.Name = "reportsbtn"
        Me.reportsbtn.Size = New System.Drawing.Size(205, 50)
        Me.reportsbtn.TabIndex = 2
        Me.reportsbtn.Text = "REPORTS"
        Me.reportsbtn.UseVisualStyleBackColor = True
        '
        'adminbtn
        '
        Me.adminbtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.adminbtn.FlatAppearance.BorderSize = 0
        Me.adminbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.adminbtn.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.adminbtn.ForeColor = System.Drawing.Color.White
        Me.adminbtn.Image = Global.eNC.My.Resources.Resources.admin
        Me.adminbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.adminbtn.Location = New System.Drawing.Point(0, 200)
        Me.adminbtn.Margin = New System.Windows.Forms.Padding(0)
        Me.adminbtn.Name = "adminbtn"
        Me.adminbtn.Size = New System.Drawing.Size(205, 50)
        Me.adminbtn.TabIndex = 3
        Me.adminbtn.Text = "ADMIN"
        Me.adminbtn.UseVisualStyleBackColor = True
        '
        'aboutbtn
        '
        Me.aboutbtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.aboutbtn.FlatAppearance.BorderSize = 0
        Me.aboutbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.aboutbtn.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.aboutbtn.ForeColor = System.Drawing.Color.White
        Me.aboutbtn.Image = Global.eNC.My.Resources.Resources.about
        Me.aboutbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.aboutbtn.Location = New System.Drawing.Point(0, 250)
        Me.aboutbtn.Margin = New System.Windows.Forms.Padding(0)
        Me.aboutbtn.Name = "aboutbtn"
        Me.aboutbtn.Size = New System.Drawing.Size(205, 50)
        Me.aboutbtn.TabIndex = 4
        Me.aboutbtn.Text = "ABOUT"
        Me.aboutbtn.UseVisualStyleBackColor = True
        '
        'helpbtn
        '
        Me.helpbtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpbtn.FlatAppearance.BorderSize = 0
        Me.helpbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.helpbtn.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.helpbtn.ForeColor = System.Drawing.Color.White
        Me.helpbtn.Image = Global.eNC.My.Resources.Resources.hELP_ICON
        Me.helpbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.helpbtn.Location = New System.Drawing.Point(0, 300)
        Me.helpbtn.Margin = New System.Windows.Forms.Padding(0)
        Me.helpbtn.Name = "helpbtn"
        Me.helpbtn.Size = New System.Drawing.Size(205, 50)
        Me.helpbtn.TabIndex = 5
        Me.helpbtn.Text = "HELP"
        Me.helpbtn.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(205, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1079, 721)
        Me.Panel1.TabIndex = 1
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1284, 721)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MinimumSize = New System.Drawing.Size(1300, 760)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "eNC"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents homebtn As Button
    Friend WithEvents applicantbtn As Button
    Friend WithEvents reportsbtn As Button
    Friend WithEvents adminbtn As Button
    Friend WithEvents aboutbtn As Button
    Friend WithEvents helpbtn As Button
    Friend WithEvents Panel1 As Panel
End Class
