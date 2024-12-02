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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.homebtn = New System.Windows.Forms.Button()
        Me.helpbtn = New System.Windows.Forms.Button()
        Me.aboutbtn = New System.Windows.Forms.Button()
        Me.adminbtn = New System.Windows.Forms.Button()
        Me.printbtn = New System.Windows.Forms.Button()
        Me.reportbtn = New System.Windows.Forms.Button()
        Me.addbtn = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.homebtn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.helpbtn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.aboutbtn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.adminbtn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.printbtn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.reportbtn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.addbtn)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SplitContainer1.Size = New System.Drawing.Size(1068, 702)
        Me.SplitContainer1.SplitterDistance = 223
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkRed
        Me.Panel1.Location = New System.Drawing.Point(3, 574)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 100)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(71, 541)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "View Size"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'homebtn
        '
        Me.homebtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.homebtn.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.homebtn.Location = New System.Drawing.Point(0, 63)
        Me.homebtn.Name = "homebtn"
        Me.homebtn.Size = New System.Drawing.Size(220, 62)
        Me.homebtn.TabIndex = 6
        Me.homebtn.Text = "Home"
        Me.homebtn.UseVisualStyleBackColor = True
        '
        'helpbtn
        '
        Me.helpbtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.helpbtn.Font = New System.Drawing.Font("Century Gothic", 15.75!)
        Me.helpbtn.Location = New System.Drawing.Point(0, 471)
        Me.helpbtn.Name = "helpbtn"
        Me.helpbtn.Size = New System.Drawing.Size(220, 62)
        Me.helpbtn.TabIndex = 5
        Me.helpbtn.Text = "Help"
        Me.helpbtn.UseVisualStyleBackColor = True
        '
        'aboutbtn
        '
        Me.aboutbtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.aboutbtn.Font = New System.Drawing.Font("Century Gothic", 15.75!)
        Me.aboutbtn.Location = New System.Drawing.Point(0, 403)
        Me.aboutbtn.Name = "aboutbtn"
        Me.aboutbtn.Size = New System.Drawing.Size(220, 62)
        Me.aboutbtn.TabIndex = 4
        Me.aboutbtn.Text = "About"
        Me.aboutbtn.UseVisualStyleBackColor = True
        '
        'adminbtn
        '
        Me.adminbtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.adminbtn.Font = New System.Drawing.Font("Century Gothic", 15.75!)
        Me.adminbtn.Location = New System.Drawing.Point(0, 335)
        Me.adminbtn.Name = "adminbtn"
        Me.adminbtn.Size = New System.Drawing.Size(220, 62)
        Me.adminbtn.TabIndex = 3
        Me.adminbtn.Text = "Admin"
        Me.adminbtn.UseVisualStyleBackColor = True
        '
        'printbtn
        '
        Me.printbtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.printbtn.Font = New System.Drawing.Font("Century Gothic", 15.75!)
        Me.printbtn.Location = New System.Drawing.Point(0, 267)
        Me.printbtn.Name = "printbtn"
        Me.printbtn.Size = New System.Drawing.Size(220, 62)
        Me.printbtn.TabIndex = 2
        Me.printbtn.Text = "Certificate and Reports"
        Me.printbtn.UseVisualStyleBackColor = True
        '
        'reportbtn
        '
        Me.reportbtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.reportbtn.Font = New System.Drawing.Font("Century Gothic", 15.75!)
        Me.reportbtn.Location = New System.Drawing.Point(0, 199)
        Me.reportbtn.Name = "reportbtn"
        Me.reportbtn.Size = New System.Drawing.Size(220, 62)
        Me.reportbtn.TabIndex = 1
        Me.reportbtn.Text = "Logs"
        Me.reportbtn.UseVisualStyleBackColor = True
        '
        'addbtn
        '
        Me.addbtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addbtn.Font = New System.Drawing.Font("Century Gothic", 15.75!)
        Me.addbtn.Location = New System.Drawing.Point(0, 131)
        Me.addbtn.Name = "addbtn"
        Me.addbtn.Size = New System.Drawing.Size(220, 62)
        Me.addbtn.TabIndex = 0
        Me.addbtn.Text = "Add"
        Me.addbtn.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 702)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MinimumSize = New System.Drawing.Size(1046, 713)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents reportbtn As System.Windows.Forms.Button
    Friend WithEvents addbtn As System.Windows.Forms.Button
    Friend WithEvents helpbtn As System.Windows.Forms.Button
    Friend WithEvents aboutbtn As System.Windows.Forms.Button
    Friend WithEvents adminbtn As System.Windows.Forms.Button
    Friend WithEvents printbtn As System.Windows.Forms.Button
    Friend WithEvents homebtn As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
