<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stock
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mainlist = New System.Windows.Forms.ListBox()
        Me.sublist = New System.Windows.Forms.ListBox()
        Me.actuallist = New System.Windows.Forms.ListBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.itemname = New System.Windows.Forms.TextBox()
        Me.totalprice = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.quantity = New System.Windows.Forms.TextBox()
        Me.unitprice = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(15, 213)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 41)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Back"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(158, 212)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 42)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Logout"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Maiandra GD", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(573, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 35)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Stock Point"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Maiandra GD", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(343, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 22)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Main Items"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Maiandra GD", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(475, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 22)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Sub Items"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Maiandra GD", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(590, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 22)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Actual Items"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Maiandra GD", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(845, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 22)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Information"
        '
        'mainlist
        '
        Me.mainlist.FormattingEnabled = True
        Me.mainlist.ItemHeight = 14
        Me.mainlist.Location = New System.Drawing.Point(336, 89)
        Me.mainlist.Name = "mainlist"
        Me.mainlist.Size = New System.Drawing.Size(120, 102)
        Me.mainlist.TabIndex = 7
        '
        'sublist
        '
        Me.sublist.FormattingEnabled = True
        Me.sublist.ItemHeight = 14
        Me.sublist.Location = New System.Drawing.Point(462, 89)
        Me.sublist.Name = "sublist"
        Me.sublist.Size = New System.Drawing.Size(120, 102)
        Me.sublist.TabIndex = 8
        '
        'actuallist
        '
        Me.actuallist.FormattingEnabled = True
        Me.actuallist.ItemHeight = 14
        Me.actuallist.Location = New System.Drawing.Point(588, 89)
        Me.actuallist.Name = "actuallist"
        Me.actuallist.Size = New System.Drawing.Size(120, 102)
        Me.actuallist.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(734, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 14)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Item Name:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(734, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 14)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Quantity:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(734, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 14)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Unit Price:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(734, 173)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 14)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Total Price:"
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(484, 198)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 25)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Add"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(614, 198)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 25)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "Add"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Location = New System.Drawing.Point(837, 197)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 25)
        Me.Button5.TabIndex = 16
        Me.Button5.Text = "Update"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(614, 229)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 25)
        Me.Button6.TabIndex = 17
        Me.Button6.Text = "Remove"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(354, 198)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 25)
        Me.Button7.TabIndex = 18
        Me.Button7.Text = "Add"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'itemname
        '
        Me.itemname.Location = New System.Drawing.Point(816, 92)
        Me.itemname.Name = "itemname"
        Me.itemname.Size = New System.Drawing.Size(220, 21)
        Me.itemname.TabIndex = 19
        '
        'totalprice
        '
        Me.totalprice.Enabled = False
        Me.totalprice.Location = New System.Drawing.Point(816, 170)
        Me.totalprice.Name = "totalprice"
        Me.totalprice.Size = New System.Drawing.Size(220, 21)
        Me.totalprice.TabIndex = 22
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(406, 0)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 21)
        Me.TextBox1.TabIndex = 23
        Me.TextBox1.Visible = False
        '
        'quantity
        '
        Me.quantity.Location = New System.Drawing.Point(816, 118)
        Me.quantity.Name = "quantity"
        Me.quantity.Size = New System.Drawing.Size(220, 21)
        Me.quantity.TabIndex = 24
        '
        'unitprice
        '
        Me.unitprice.Location = New System.Drawing.Point(816, 145)
        Me.unitprice.Name = "unitprice"
        Me.unitprice.Size = New System.Drawing.Size(220, 21)
        Me.unitprice.TabIndex = 25
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(300, 0)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 21)
        Me.TextBox2.TabIndex = 26
        Me.TextBox2.Visible = False
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(484, 229)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 25)
        Me.Button8.TabIndex = 27
        Me.Button8.Text = "Remove"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(354, 229)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 25)
        Me.Button9.TabIndex = 28
        Me.Button9.Text = "Remove"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Enabled = False
        Me.Button10.Location = New System.Drawing.Point(918, 197)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 25)
        Me.Button10.TabIndex = 29
        Me.Button10.Text = "Add"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Inventory_Management_System.My.Resources.Resources.Samsung_Logo
        Me.PictureBox1.Location = New System.Drawing.Point(-4, -36)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(298, 227)
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'Stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1048, 267)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.unitprice)
        Me.Controls.Add(Me.quantity)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.totalprice)
        Me.Controls.Add(Me.itemname)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.actuallist)
        Me.Controls.Add(Me.sublist)
        Me.Controls.Add(Me.mainlist)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Maiandra GD", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Stock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents mainlist As System.Windows.Forms.ListBox
    Friend WithEvents sublist As System.Windows.Forms.ListBox
    Friend WithEvents actuallist As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents itemname As System.Windows.Forms.TextBox
    Friend WithEvents totalprice As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents quantity As System.Windows.Forms.TextBox
    Friend WithEvents unitprice As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
