<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnadmin = New System.Windows.Forms.Button()
        Me.btnguest = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnIT = New System.Windows.Forms.Button()
        Me.btnPA = New System.Windows.Forms.Button()
        Me.btnEntrep = New System.Windows.Forms.Button()
        Me.lblDept = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(527, 349)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(596, 162)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Login"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Location = New System.Drawing.Point(384, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(203, 153)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Guest"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 57)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(191, 45)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Guest"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(360, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Or"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(359, 285)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnadmin, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnguest, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Button2, 1, 5)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 83)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 8
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(359, 202)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'btnadmin
        '
        Me.btnadmin.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnadmin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnadmin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnadmin.FlatAppearance.BorderSize = 0
        Me.btnadmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnadmin.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.btnadmin.ForeColor = System.Drawing.Color.White
        Me.btnadmin.Location = New System.Drawing.Point(131, 20)
        Me.btnadmin.Margin = New System.Windows.Forms.Padding(0)
        Me.btnadmin.Name = "btnadmin"
        Me.btnadmin.Size = New System.Drawing.Size(97, 42)
        Me.btnadmin.TabIndex = 0
        Me.btnadmin.Text = "Admin"
        Me.btnadmin.UseVisualStyleBackColor = False
        '
        'btnguest
        '
        Me.btnguest.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnguest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnguest.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnguest.FlatAppearance.BorderSize = 0
        Me.btnguest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnguest.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.btnguest.ForeColor = System.Drawing.Color.White
        Me.btnguest.Location = New System.Drawing.Point(131, 74)
        Me.btnguest.Margin = New System.Windows.Forms.Padding(0)
        Me.btnguest.Name = "btnguest"
        Me.btnguest.Size = New System.Drawing.Size(97, 42)
        Me.btnguest.TabIndex = 1
        Me.btnguest.Text = "Guest"
        Me.btnguest.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(131, 128)
        Me.Button2.Margin = New System.Windows.Forms.Padding(0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(97, 42)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Back"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnIT, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnPA, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnEntrep, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblDept, 1, 3)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Enabled = False
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 4
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(359, 83)
        Me.TableLayoutPanel3.TabIndex = 1
        Me.TableLayoutPanel3.Visible = False
        '
        'btnIT
        '
        Me.btnIT.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnIT.FlatAppearance.BorderSize = 0
        Me.btnIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIT.Font = New System.Drawing.Font("Century Gothic", 8.0!)
        Me.btnIT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnIT.Location = New System.Drawing.Point(0, 0)
        Me.btnIT.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.btnIT.Name = "btnIT"
        Me.btnIT.Size = New System.Drawing.Size(58, 20)
        Me.btnIT.TabIndex = 0
        Me.btnIT.Text = "IT"
        Me.btnIT.UseVisualStyleBackColor = False
        '
        'btnPA
        '
        Me.btnPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnPA.FlatAppearance.BorderSize = 0
        Me.btnPA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPA.Font = New System.Drawing.Font("Century Gothic", 8.0!)
        Me.btnPA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnPA.Location = New System.Drawing.Point(0, 21)
        Me.btnPA.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.btnPA.Name = "btnPA"
        Me.btnPA.Size = New System.Drawing.Size(58, 20)
        Me.btnPA.TabIndex = 1
        Me.btnPA.Text = "PA"
        Me.btnPA.UseVisualStyleBackColor = False
        '
        'btnEntrep
        '
        Me.btnEntrep.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnEntrep.FlatAppearance.BorderSize = 0
        Me.btnEntrep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEntrep.Font = New System.Drawing.Font("Century Gothic", 8.0!)
        Me.btnEntrep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnEntrep.Location = New System.Drawing.Point(0, 42)
        Me.btnEntrep.Margin = New System.Windows.Forms.Padding(0, 0, 0, 1)
        Me.btnEntrep.Name = "btnEntrep"
        Me.btnEntrep.Size = New System.Drawing.Size(58, 20)
        Me.btnEntrep.TabIndex = 2
        Me.btnEntrep.Text = "Entrep"
        Me.btnEntrep.UseVisualStyleBackColor = False
        '
        'lblDept
        '
        Me.lblDept.AutoSize = True
        Me.lblDept.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDept.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.lblDept.ForeColor = System.Drawing.Color.Black
        Me.lblDept.Location = New System.Drawing.Point(61, 63)
        Me.lblDept.Name = "lblDept"
        Me.lblDept.Size = New System.Drawing.Size(237, 20)
        Me.lblDept.TabIndex = 3
        Me.lblDept.Text = "IT"
        Me.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblDept.Visible = False
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.eTAS.My.Resources.Resources.LOGINbg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(359, 285)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnadmin As Button
    Friend WithEvents btnguest As Button

    Private Sub btnadmin_Click(sender As Object, e As EventArgs) Handles btnadmin.Click
        eTASStartForm.adminclicked()
    End Sub

    Private Sub btnguest_Click(sender As Object, e As EventArgs) Handles btnguest.Click
        eTASStartForm.guestclicked()
    End Sub

    Friend WithEvents Button2 As Button
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents btnIT As Button
    Friend WithEvents btnPA As Button
    Friend WithEvents btnEntrep As Button
    Friend WithEvents lblDept As Label
End Class
