<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DepartmentSelectionForm
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
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnPA = New System.Windows.Forms.Button()
        Me.btnEntrep = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnIT = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(361, 287)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnPA, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.btnEntrep, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.btnExit, 1, 7)
        Me.TableLayoutPanel3.Controls.Add(Me.btnIT, 1, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 46)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 10
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(361, 241)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'btnPA
        '
        Me.btnPA.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnPA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnPA.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnPA.FlatAppearance.BorderSize = 0
        Me.btnPA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPA.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.btnPA.ForeColor = System.Drawing.Color.White
        Me.btnPA.Location = New System.Drawing.Point(132, 74)
        Me.btnPA.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPA.Name = "btnPA"
        Me.btnPA.Size = New System.Drawing.Size(97, 42)
        Me.btnPA.TabIndex = 0
        Me.btnPA.Text = "PA"
        Me.btnPA.UseVisualStyleBackColor = False
        '
        'btnEntrep
        '
        Me.btnEntrep.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnEntrep.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEntrep.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnEntrep.FlatAppearance.BorderSize = 0
        Me.btnEntrep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEntrep.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.btnEntrep.ForeColor = System.Drawing.Color.White
        Me.btnEntrep.Location = New System.Drawing.Point(132, 128)
        Me.btnEntrep.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEntrep.Name = "btnEntrep"
        Me.btnEntrep.Size = New System.Drawing.Size(97, 42)
        Me.btnEntrep.TabIndex = 1
        Me.btnEntrep.Text = "Entrep"
        Me.btnEntrep.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Location = New System.Drawing.Point(132, 182)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(0)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(97, 42)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnIT
        '
        Me.btnIT.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.btnIT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnIT.FlatAppearance.BorderSize = 0
        Me.btnIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIT.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.btnIT.ForeColor = System.Drawing.Color.White
        Me.btnIT.Location = New System.Drawing.Point(132, 20)
        Me.btnIT.Margin = New System.Windows.Forms.Padding(0)
        Me.btnIT.Name = "btnIT"
        Me.btnIT.Size = New System.Drawing.Size(97, 42)
        Me.btnIT.TabIndex = 3
        Me.btnIT.Text = "IT"
        Me.btnIT.UseVisualStyleBackColor = False
        '
        'DepartmentSelectionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.eTAS.My.Resources.Resources.LOGINbg
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(361, 287)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "DepartmentSelectionForm"
        Me.Text = "DepartmentSelectionForm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents btnPA As Button
    Friend WithEvents btnEntrep As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnIT As Button
End Class
