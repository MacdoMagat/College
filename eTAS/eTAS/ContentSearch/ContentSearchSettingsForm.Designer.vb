<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ContentSearchSettingsForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.matchCaseRdo = New System.Windows.Forms.RadioButton()
        Me.wildCardsRdo = New System.Windows.Forms.RadioButton()
        Me.singleWordRdo = New System.Windows.Forms.RadioButton()
        Me.fiveWordsRdo = New System.Windows.Forms.RadioButton()
        Me.allWordsRdo = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 15.0!)
        Me.Label1.Location = New System.Drawing.Point(225, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Settings"
        '
        'matchCaseRdo
        '
        Me.matchCaseRdo.AutoSize = True
        Me.matchCaseRdo.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.matchCaseRdo.Location = New System.Drawing.Point(13, 6)
        Me.matchCaseRdo.Name = "matchCaseRdo"
        Me.matchCaseRdo.Size = New System.Drawing.Size(125, 25)
        Me.matchCaseRdo.TabIndex = 1
        Me.matchCaseRdo.TabStop = True
        Me.matchCaseRdo.Text = "Match Case"
        Me.matchCaseRdo.UseVisualStyleBackColor = True
        '
        'wildCardsRdo
        '
        Me.wildCardsRdo.AutoSize = True
        Me.wildCardsRdo.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.wildCardsRdo.Location = New System.Drawing.Point(13, 37)
        Me.wildCardsRdo.Name = "wildCardsRdo"
        Me.wildCardsRdo.Size = New System.Drawing.Size(141, 25)
        Me.wildCardsRdo.TabIndex = 2
        Me.wildCardsRdo.TabStop = True
        Me.wildCardsRdo.Text = "Use Wild Cards"
        Me.wildCardsRdo.UseVisualStyleBackColor = True
        '
        'singleWordRdo
        '
        Me.singleWordRdo.AutoSize = True
        Me.singleWordRdo.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.singleWordRdo.Location = New System.Drawing.Point(3, 3)
        Me.singleWordRdo.Name = "singleWordRdo"
        Me.singleWordRdo.Size = New System.Drawing.Size(183, 23)
        Me.singleWordRdo.TabIndex = 3
        Me.singleWordRdo.TabStop = True
        Me.singleWordRdo.Text = "Single Word Difference"
        Me.singleWordRdo.UseVisualStyleBackColor = True
        '
        'fiveWordsRdo
        '
        Me.fiveWordsRdo.AutoSize = True
        Me.fiveWordsRdo.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.fiveWordsRdo.Location = New System.Drawing.Point(3, 32)
        Me.fiveWordsRdo.Name = "fiveWordsRdo"
        Me.fiveWordsRdo.Size = New System.Drawing.Size(132, 23)
        Me.fiveWordsRdo.TabIndex = 4
        Me.fiveWordsRdo.TabStop = True
        Me.fiveWordsRdo.Text = "Sentence Scan"
        Me.fiveWordsRdo.UseVisualStyleBackColor = True
        '
        'allWordsRdo
        '
        Me.allWordsRdo.AutoSize = True
        Me.allWordsRdo.Enabled = False
        Me.allWordsRdo.Font = New System.Drawing.Font("Century Gothic", 10.0!)
        Me.allWordsRdo.Location = New System.Drawing.Point(3, 61)
        Me.allWordsRdo.Name = "allWordsRdo"
        Me.allWordsRdo.Size = New System.Drawing.Size(151, 23)
        Me.allWordsRdo.TabIndex = 5
        Me.allWordsRdo.TabStop = True
        Me.allWordsRdo.Text = "All Words Traversal"
        Me.allWordsRdo.UseVisualStyleBackColor = True
        Me.allWordsRdo.Visible = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(135, 217)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 32)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(133, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(294, 221)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(109, 32)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.matchCaseRdo)
        Me.Panel1.Controls.Add(Me.wildCardsRdo)
        Me.Panel1.Location = New System.Drawing.Point(18, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 66)
        Me.Panel1.TabIndex = 10
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.fiveWordsRdo)
        Me.Panel2.Controls.Add(Me.allWordsRdo)
        Me.Panel2.Controls.Add(Me.singleWordRdo)
        Me.Panel2.Location = New System.Drawing.Point(46, 101)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(188, 110)
        Me.Panel2.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 12.0!)
        Me.Label2.Location = New System.Drawing.Point(290, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 21)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Filter"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(291, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 17)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Category:"
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.Font = New System.Drawing.Font("Century Gothic", 9.75!)
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Location = New System.Drawing.Point(370, 98)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(166, 25)
        Me.cboCategory.TabIndex = 14
        '
        'ContentSearchSettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(548, 265)
        Me.ControlBox = False
        Me.Controls.Add(Me.cboCategory)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ContentSearchSettingsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents matchCaseRdo As RadioButton
    Friend WithEvents wildCardsRdo As RadioButton
    Friend WithEvents singleWordRdo As RadioButton
    Friend WithEvents fiveWordsRdo As RadioButton
    Friend WithEvents allWordsRdo As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboCategory As ComboBox
End Class
