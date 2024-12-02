<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Report
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
        Me.Reports = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.productreportsumgridview = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.productreportgridview = New System.Windows.Forms.DataGridView()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.totalamountpaid = New System.Windows.Forms.Label()
        Me.totaldiscountexpense = New System.Windows.Forms.Label()
        Me.purchasesreportgridview = New System.Windows.Forms.DataGridView()
        Me.customername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.discountexpense = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amountpaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Reports.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.productreportsumgridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.productreportgridview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.purchasesreportgridview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Reports
        '
        Me.Reports.Controls.Add(Me.TabPage1)
        Me.Reports.Controls.Add(Me.TabPage2)
        Me.Reports.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reports.Location = New System.Drawing.Point(352, 58)
        Me.Reports.Name = "Reports"
        Me.Reports.SelectedIndex = 0
        Me.Reports.Size = New System.Drawing.Size(643, 379)
        Me.Reports.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.productreportsumgridview)
        Me.TabPage1.Controls.Add(Me.productreportgridview)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(635, 352)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Product Report"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(491, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 14)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Total"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(89, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Product"
        '
        'productreportsumgridview
        '
        Me.productreportsumgridview.AllowUserToAddRows = False
        Me.productreportsumgridview.AllowUserToDeleteRows = False
        Me.productreportsumgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.productreportsumgridview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.productreportsumgridview.Location = New System.Drawing.Point(385, 34)
        Me.productreportsumgridview.Name = "productreportsumgridview"
        Me.productreportsumgridview.ReadOnly = True
        Me.productreportsumgridview.Size = New System.Drawing.Size(244, 312)
        Me.productreportsumgridview.TabIndex = 2
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Item Name"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'productreportgridview
        '
        Me.productreportgridview.AllowUserToAddRows = False
        Me.productreportgridview.AllowUserToDeleteRows = False
        Me.productreportgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.productreportgridview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemname, Me.quantity})
        Me.productreportgridview.Location = New System.Drawing.Point(6, 34)
        Me.productreportgridview.Name = "productreportgridview"
        Me.productreportgridview.ReadOnly = True
        Me.productreportgridview.Size = New System.Drawing.Size(244, 312)
        Me.productreportgridview.TabIndex = 0
        '
        'itemname
        '
        Me.itemname.HeaderText = "Item Name"
        Me.itemname.Name = "itemname"
        Me.itemname.ReadOnly = True
        '
        'quantity
        '
        Me.quantity.HeaderText = "Quantity"
        Me.quantity.Name = "quantity"
        Me.quantity.ReadOnly = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.totalamountpaid)
        Me.TabPage2.Controls.Add(Me.totaldiscountexpense)
        Me.TabPage2.Controls.Add(Me.purchasesreportgridview)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(635, 352)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Purchases Report"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(367, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Total Income:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(367, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Total Discount Expense:"
        '
        'totalamountpaid
        '
        Me.totalamountpaid.AutoSize = True
        Me.totalamountpaid.Location = New System.Drawing.Point(503, 74)
        Me.totalamountpaid.Name = "totalamountpaid"
        Me.totalamountpaid.Size = New System.Drawing.Size(13, 14)
        Me.totalamountpaid.TabIndex = 2
        Me.totalamountpaid.Text = "0"
        '
        'totaldiscountexpense
        '
        Me.totaldiscountexpense.AutoSize = True
        Me.totaldiscountexpense.Location = New System.Drawing.Point(503, 41)
        Me.totaldiscountexpense.Name = "totaldiscountexpense"
        Me.totaldiscountexpense.Size = New System.Drawing.Size(13, 14)
        Me.totaldiscountexpense.TabIndex = 1
        Me.totaldiscountexpense.Text = "0"
        '
        'purchasesreportgridview
        '
        Me.purchasesreportgridview.AllowUserToAddRows = False
        Me.purchasesreportgridview.AllowUserToDeleteRows = False
        Me.purchasesreportgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.purchasesreportgridview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.customername, Me.discountexpense, Me.amountpaid})
        Me.purchasesreportgridview.Location = New System.Drawing.Point(6, 3)
        Me.purchasesreportgridview.Name = "purchasesreportgridview"
        Me.purchasesreportgridview.ReadOnly = True
        Me.purchasesreportgridview.Size = New System.Drawing.Size(343, 343)
        Me.purchasesreportgridview.TabIndex = 0
        '
        'customername
        '
        Me.customername.HeaderText = "Customer Name"
        Me.customername.Name = "customername"
        Me.customername.ReadOnly = True
        '
        'discountexpense
        '
        Me.discountexpense.HeaderText = "Discount Expense"
        Me.discountexpense.Name = "discountexpense"
        Me.discountexpense.ReadOnly = True
        '
        'amountpaid
        '
        Me.amountpaid.HeaderText = "Amount Paid"
        Me.amountpaid.Name = "amountpaid"
        Me.amountpaid.ReadOnly = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(122, 331)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(36, 244)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 42)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Back"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(189, 244)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 42)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Logout"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Maiandra GD", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(643, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 35)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Report"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Inventory_Management_System.My.Resources.Resources.Samsung_Logo
        Me.PictureBox1.Location = New System.Drawing.Point(12, -6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(297, 216)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Maiandra GD", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 333)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 19)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Report Date:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(101, 354)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(231, 14)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "(Change date to view reports from other date.)"
        '
        'Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 449)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Reports)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Report"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report"
        Me.Reports.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.productreportsumgridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.productreportgridview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.purchasesreportgridview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Reports As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents productreportgridview As System.Windows.Forms.DataGridView
    Friend WithEvents itemname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents purchasesreportgridview As System.Windows.Forms.DataGridView
    Friend WithEvents customername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents discountexpense As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents amountpaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents totalamountpaid As System.Windows.Forms.Label
    Friend WithEvents totaldiscountexpense As System.Windows.Forms.Label
    Friend WithEvents productreportsumgridview As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
