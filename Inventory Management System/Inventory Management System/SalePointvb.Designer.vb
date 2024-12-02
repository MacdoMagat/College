<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalePoint
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.spcart = New System.Windows.Forms.DataGridView()
        Me.itemid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.itemname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.spcustomernametxt = New System.Windows.Forms.TextBox()
        Me.spdiscounttxt = New System.Windows.Forms.TextBox()
        Me.spamounttxt = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.spselectitemcbo = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.spquantitypurchasedtxt = New System.Windows.Forms.TextBox()
        Me.spquantityavailablelbl = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.spunitpricelbl = New System.Windows.Forms.Label()
        Me.spaddbtn = New System.Windows.Forms.Button()
        Me.spprocessbtn = New System.Windows.Forms.Button()
        Me.spprintbtn = New System.Windows.Forms.Button()
        Me.spprocessandprintbtn = New System.Windows.Forms.Button()
        Me.spclearbtn = New System.Windows.Forms.Button()
        Me.spremovebtn = New System.Windows.Forms.Button()
        Me.spbackbtn = New System.Windows.Forms.Button()
        Me.spoutbtn = New System.Windows.Forms.Button()
        Me.spnumberofitemstxt = New System.Windows.Forms.TextBox()
        Me.spundiscountedpricetxt = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.spchangetxt = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.spdiscountedpricetxt = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.spcart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Maiandra GD", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(346, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 35)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sale Point"
        '
        'spcart
        '
        Me.spcart.AllowUserToAddRows = False
        Me.spcart.AllowUserToDeleteRows = False
        Me.spcart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.spcart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.itemid, Me.itemname, Me.quantity, Me.price, Me.amount})
        Me.spcart.Location = New System.Drawing.Point(26, 54)
        Me.spcart.Name = "spcart"
        Me.spcart.ReadOnly = True
        Me.spcart.Size = New System.Drawing.Size(543, 261)
        Me.spcart.TabIndex = 1
        '
        'itemid
        '
        Me.itemid.HeaderText = "Purchase Count"
        Me.itemid.Name = "itemid"
        Me.itemid.ReadOnly = True
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
        'price
        '
        Me.price.HeaderText = "Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        '
        'amount
        '
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        Me.amount.ReadOnly = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Maiandra GD", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(639, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Total Price"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Maiandra GD", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(601, 82)
        Me.Label3.MinimumSize = New System.Drawing.Size(200, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 57)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "0"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(575, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 14)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Customer Name:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(575, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Number of Items:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(575, 206)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 14)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Undiscounted Price:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(575, 233)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Discount:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(575, 280)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 14)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Cash:"
        '
        'spcustomernametxt
        '
        Me.spcustomernametxt.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spcustomernametxt.Location = New System.Drawing.Point(673, 150)
        Me.spcustomernametxt.Name = "spcustomernametxt"
        Me.spcustomernametxt.Size = New System.Drawing.Size(139, 21)
        Me.spcustomernametxt.TabIndex = 9
        '
        'spdiscounttxt
        '
        Me.spdiscounttxt.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spdiscounttxt.Location = New System.Drawing.Point(673, 230)
        Me.spdiscounttxt.Name = "spdiscounttxt"
        Me.spdiscounttxt.Size = New System.Drawing.Size(118, 21)
        Me.spdiscounttxt.TabIndex = 12
        Me.spdiscounttxt.Text = "0"
        '
        'spamounttxt
        '
        Me.spamounttxt.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spamounttxt.Location = New System.Drawing.Point(673, 277)
        Me.spamounttxt.Name = "spamounttxt"
        Me.spamounttxt.Size = New System.Drawing.Size(139, 21)
        Me.spamounttxt.TabIndex = 13
        Me.spamounttxt.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(23, 336)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 14)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Select Item:"
        '
        'spselectitemcbo
        '
        Me.spselectitemcbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.spselectitemcbo.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spselectitemcbo.FormattingEnabled = True
        Me.spselectitemcbo.Location = New System.Drawing.Point(92, 333)
        Me.spselectitemcbo.Name = "spselectitemcbo"
        Me.spselectitemcbo.Size = New System.Drawing.Size(397, 22)
        Me.spselectitemcbo.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(23, 365)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 14)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Quantity Purchased:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(217, 365)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 14)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Quantity Available:"
        '
        'spquantitypurchasedtxt
        '
        Me.spquantitypurchasedtxt.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spquantitypurchasedtxt.Location = New System.Drawing.Point(132, 362)
        Me.spquantitypurchasedtxt.Name = "spquantitypurchasedtxt"
        Me.spquantitypurchasedtxt.Size = New System.Drawing.Size(79, 21)
        Me.spquantitypurchasedtxt.TabIndex = 19
        '
        'spquantityavailablelbl
        '
        Me.spquantityavailablelbl.AutoSize = True
        Me.spquantityavailablelbl.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spquantityavailablelbl.Location = New System.Drawing.Point(318, 365)
        Me.spquantityavailablelbl.Name = "spquantityavailablelbl"
        Me.spquantityavailablelbl.Size = New System.Drawing.Size(0, 14)
        Me.spquantityavailablelbl.TabIndex = 20
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(373, 365)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 14)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Unit Price:"
        '
        'spunitpricelbl
        '
        Me.spunitpricelbl.AutoSize = True
        Me.spunitpricelbl.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spunitpricelbl.Location = New System.Drawing.Point(435, 365)
        Me.spunitpricelbl.Name = "spunitpricelbl"
        Me.spunitpricelbl.Size = New System.Drawing.Size(0, 14)
        Me.spunitpricelbl.TabIndex = 22
        '
        'spaddbtn
        '
        Me.spaddbtn.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spaddbtn.Location = New System.Drawing.Point(494, 333)
        Me.spaddbtn.Name = "spaddbtn"
        Me.spaddbtn.Size = New System.Drawing.Size(75, 50)
        Me.spaddbtn.TabIndex = 23
        Me.spaddbtn.Text = "Add"
        Me.spaddbtn.UseVisualStyleBackColor = True
        '
        'spprocessbtn
        '
        Me.spprocessbtn.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spprocessbtn.Location = New System.Drawing.Point(656, 331)
        Me.spprocessbtn.Name = "spprocessbtn"
        Me.spprocessbtn.Size = New System.Drawing.Size(75, 23)
        Me.spprocessbtn.TabIndex = 24
        Me.spprocessbtn.Text = "Process"
        Me.spprocessbtn.UseVisualStyleBackColor = True
        '
        'spprintbtn
        '
        Me.spprintbtn.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spprintbtn.Location = New System.Drawing.Point(737, 331)
        Me.spprintbtn.Name = "spprintbtn"
        Me.spprintbtn.Size = New System.Drawing.Size(75, 23)
        Me.spprintbtn.TabIndex = 25
        Me.spprintbtn.Text = "Print"
        Me.spprintbtn.UseVisualStyleBackColor = True
        '
        'spprocessandprintbtn
        '
        Me.spprocessandprintbtn.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spprocessandprintbtn.Location = New System.Drawing.Point(659, 360)
        Me.spprocessandprintbtn.Name = "spprocessandprintbtn"
        Me.spprocessandprintbtn.Size = New System.Drawing.Size(156, 23)
        Me.spprocessandprintbtn.TabIndex = 26
        Me.spprocessandprintbtn.Text = "Process and Print"
        Me.spprocessandprintbtn.UseVisualStyleBackColor = True
        '
        'spclearbtn
        '
        Me.spclearbtn.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spclearbtn.Location = New System.Drawing.Point(578, 331)
        Me.spclearbtn.Name = "spclearbtn"
        Me.spclearbtn.Size = New System.Drawing.Size(75, 23)
        Me.spclearbtn.TabIndex = 27
        Me.spclearbtn.Text = "Clear"
        Me.spclearbtn.UseVisualStyleBackColor = True
        '
        'spremovebtn
        '
        Me.spremovebtn.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spremovebtn.Location = New System.Drawing.Point(578, 360)
        Me.spremovebtn.Name = "spremovebtn"
        Me.spremovebtn.Size = New System.Drawing.Size(75, 23)
        Me.spremovebtn.TabIndex = 28
        Me.spremovebtn.Text = "Remove"
        Me.spremovebtn.UseVisualStyleBackColor = True
        '
        'spbackbtn
        '
        Me.spbackbtn.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spbackbtn.Location = New System.Drawing.Point(26, 20)
        Me.spbackbtn.Name = "spbackbtn"
        Me.spbackbtn.Size = New System.Drawing.Size(75, 23)
        Me.spbackbtn.TabIndex = 29
        Me.spbackbtn.Text = "Back"
        Me.spbackbtn.UseVisualStyleBackColor = True
        '
        'spoutbtn
        '
        Me.spoutbtn.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spoutbtn.Location = New System.Drawing.Point(107, 20)
        Me.spoutbtn.Name = "spoutbtn"
        Me.spoutbtn.Size = New System.Drawing.Size(75, 23)
        Me.spoutbtn.TabIndex = 30
        Me.spoutbtn.Text = "Logout"
        Me.spoutbtn.UseVisualStyleBackColor = True
        '
        'spnumberofitemstxt
        '
        Me.spnumberofitemstxt.Enabled = False
        Me.spnumberofitemstxt.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spnumberofitemstxt.Location = New System.Drawing.Point(673, 177)
        Me.spnumberofitemstxt.Name = "spnumberofitemstxt"
        Me.spnumberofitemstxt.Size = New System.Drawing.Size(139, 21)
        Me.spnumberofitemstxt.TabIndex = 10
        Me.spnumberofitemstxt.Text = "0"
        '
        'spundiscountedpricetxt
        '
        Me.spundiscountedpricetxt.Enabled = False
        Me.spundiscountedpricetxt.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spundiscountedpricetxt.Location = New System.Drawing.Point(673, 203)
        Me.spundiscountedpricetxt.Name = "spundiscountedpricetxt"
        Me.spundiscountedpricetxt.Size = New System.Drawing.Size(139, 21)
        Me.spundiscountedpricetxt.TabIndex = 11
        Me.spundiscountedpricetxt.Text = "0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(797, 229)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(18, 14)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "%"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(575, 304)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 14)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Change:"
        '
        'spchangetxt
        '
        Me.spchangetxt.Enabled = False
        Me.spchangetxt.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spchangetxt.Location = New System.Drawing.Point(673, 301)
        Me.spchangetxt.Name = "spchangetxt"
        Me.spchangetxt.Size = New System.Drawing.Size(139, 21)
        Me.spchangetxt.TabIndex = 33
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(575, 257)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(87, 14)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Discounted Price"
        '
        'spdiscountedpricetxt
        '
        Me.spdiscountedpricetxt.Enabled = False
        Me.spdiscountedpricetxt.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.spdiscountedpricetxt.Location = New System.Drawing.Point(673, 254)
        Me.spdiscountedpricetxt.Name = "spdiscountedpricetxt"
        Me.spdiscountedpricetxt.Size = New System.Drawing.Size(139, 21)
        Me.spdiscountedpricetxt.TabIndex = 35
        Me.spdiscountedpricetxt.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Maiandra GD", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(734, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 14)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Label16"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'SalePoint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 404)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.spdiscountedpricetxt)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.spchangetxt)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.spoutbtn)
        Me.Controls.Add(Me.spbackbtn)
        Me.Controls.Add(Me.spremovebtn)
        Me.Controls.Add(Me.spclearbtn)
        Me.Controls.Add(Me.spprocessandprintbtn)
        Me.Controls.Add(Me.spprintbtn)
        Me.Controls.Add(Me.spprocessbtn)
        Me.Controls.Add(Me.spaddbtn)
        Me.Controls.Add(Me.spunitpricelbl)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.spquantityavailablelbl)
        Me.Controls.Add(Me.spquantitypurchasedtxt)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.spselectitemcbo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.spamounttxt)
        Me.Controls.Add(Me.spdiscounttxt)
        Me.Controls.Add(Me.spundiscountedpricetxt)
        Me.Controls.Add(Me.spnumberofitemstxt)
        Me.Controls.Add(Me.spcustomernametxt)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.spcart)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "SalePoint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sale Point"
        CType(Me.spcart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents spcart As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents spcustomernametxt As System.Windows.Forms.TextBox
    Friend WithEvents spdiscounttxt As System.Windows.Forms.TextBox
    Friend WithEvents spamounttxt As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents spselectitemcbo As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents spquantitypurchasedtxt As System.Windows.Forms.TextBox
    Friend WithEvents spquantityavailablelbl As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents spunitpricelbl As System.Windows.Forms.Label
    Friend WithEvents spaddbtn As System.Windows.Forms.Button
    Friend WithEvents spprocessbtn As System.Windows.Forms.Button
    Friend WithEvents spprintbtn As System.Windows.Forms.Button
    Friend WithEvents spprocessandprintbtn As System.Windows.Forms.Button
    Friend WithEvents spclearbtn As System.Windows.Forms.Button
    Friend WithEvents spremovebtn As System.Windows.Forms.Button
    Friend WithEvents spbackbtn As System.Windows.Forms.Button
    Friend WithEvents spoutbtn As System.Windows.Forms.Button
    Friend WithEvents spnumberofitemstxt As System.Windows.Forms.TextBox
    Friend WithEvents spundiscountedpricetxt As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents itemid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents itemname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents spchangetxt As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents spdiscountedpricetxt As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
