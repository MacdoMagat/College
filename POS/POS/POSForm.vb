Imports MySql.Data.MySqlClient
Imports CrystalDecisions.Shared

Public Class POSForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=POS"

    Private Sub POSForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim categoryquery As String = "SELECT * FROM productcategorytbl"
            Dim categorycomm As New MySqlCommand
            Dim categoryreader As MySqlDataReader
            categorycomm.CommandText = categoryquery
            categorycomm.Connection = conn
            categoryreader = categorycomm.ExecuteReader

            Dim categorybtn As Button
            While categoryreader.Read
                categorybtn = New Button()
                categorybtn.Name = categoryreader("productcategoryname").ToString
                categorybtn.Text = categoryreader("productcategoryname").ToString
                categorybtn.Width = 100
                categorybtn.Height = 59
                categorybtn.ForeColor = Color.White
                categorybtn.Font = New Font("Century Gothic", 12)
                categorybtn.FlatStyle = FlatStyle.Flat
                categorybtn.BackColor = Color.Coral
                categorybtn.FlatAppearance.BorderColor = Color.Black
                AddHandler categorybtn.Click, AddressOf categorybuttonclicked
                FlowLayoutPanel2.Controls.Add(categorybtn)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim productquery As String = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid"
            Dim productcomm As New MySqlCommand
            Dim productreader As MySqlDataReader
            productcomm.CommandText = productquery
            productcomm.Connection = conn
            productreader = productcomm.ExecuteReader

            Dim productbtn As Button
            While productreader.Read
                productbtn = New Button()
                productbtn.Name = productreader("productname").ToString
                productbtn.Text = "ID: [" & productreader("productid").ToString & "]" & vbNewLine & productreader("productname").ToString & vbNewLine & "P " & productreader("productprice").ToString
                productbtn.Width = 165
                productbtn.Height = 100
                productbtn.ForeColor = Color.White
                productbtn.Font = New Font("Century Gothic", 12)
                productbtn.FlatStyle = FlatStyle.Flat
                productbtn.BackColor = Color.MediumTurquoise
                productbtn.FlatAppearance.BorderColor = Color.Black
                AddHandler productbtn.Click, AddressOf productbuttonclicked
                FlowLayoutPanel1.Controls.Add(productbtn)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub categorybuttonclicked(sender As Object, e As EventArgs)

        'MsgBox(sender.ToString)
        Dim start As Integer = sender.ToString.IndexOf(":") + 2
        Dim selectedcategory As String = sender.ToString.Substring(start, sender.ToString.Length - start)

        Try
            FlowLayoutPanel1.Controls.Clear()

            conn.ConnectionString = connstring
            conn.Open()

            Dim productquery As String = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid WHERE productcategorytbl.productcategoryname = '" & selectedcategory & "'"
            Dim productcomm As New MySqlCommand
            Dim productreader As MySqlDataReader
            productcomm.CommandText = productquery
            productcomm.Connection = conn
            productreader = productcomm.ExecuteReader

            Dim productbtn As Button
            While productreader.Read
                productbtn = New Button()
                productbtn.Name = productreader("productname").ToString
                productbtn.Text = "ID: [" & productreader("productid").ToString & "]" & vbNewLine & productreader("productname").ToString & vbNewLine & "P " & productreader("productprice").ToString
                productbtn.Width = 165
                productbtn.Height = 100
                productbtn.ForeColor = Color.White
                productbtn.Font = New Font("Century Gothic", 12)
                productbtn.FlatStyle = FlatStyle.Flat
                productbtn.BackColor = Color.MediumTurquoise
                productbtn.FlatAppearance.BorderColor = Color.Black
                AddHandler productbtn.Click, AddressOf productbuttonclicked
                FlowLayoutPanel1.Controls.Add(productbtn)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            FlowLayoutPanel1.Controls.Clear()

            conn.ConnectionString = connstring
            conn.Open()

            Dim productquery As String = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid"
            Dim productcomm As New MySqlCommand
            Dim productreader As MySqlDataReader
            productcomm.CommandText = productquery
            productcomm.Connection = conn
            productreader = productcomm.ExecuteReader

            Dim productbtn As Button
            While productreader.Read
                productbtn = New Button()
                productbtn.Name = productreader("productname").ToString
                productbtn.Text = "ID: [" & productreader("productid").ToString & "]" & vbNewLine & productreader("productname").ToString & vbNewLine & "P " & productreader("productprice").ToString
                productbtn.Width = 165
                productbtn.Height = 100
                productbtn.ForeColor = Color.White
                productbtn.Font = New Font("Century Gothic", 12)
                productbtn.FlatStyle = FlatStyle.Flat
                productbtn.BackColor = Color.MediumTurquoise
                productbtn.FlatAppearance.BorderColor = Color.Black
                AddHandler productbtn.Click, AddressOf productbuttonclicked

                'If CInt(productreader("productquantity")) > 0 Then
                FlowLayoutPanel1.Controls.Add(productbtn)
                'End If
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub productbuttonclicked(sender As Object, e As EventArgs)
        Dim productselectedid As String = sender.ToString.Substring(sender.ToString.IndexOf("[") + 1, sender.ToString.IndexOf("]") - sender.ToString.IndexOf("[") - 1)
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM producttbl WHERE productid = " & productselectedid & ""
            Dim reader As MySqlDataReader
            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader

            ' While reader.Read
            '    DataGridView1.Rows.Add(reader("productname").ToString, reader("productprice").ToString)
            '    Dim initialprice As Double = CDbl(Label4.Text)
            '    Label4.Text = initialprice + CDbl(reader("productprice").ToString)
            'End While

            'MsgBox(DataGridView1.Rows.Count)
            'MsgBox(DataGridView1.Rows(2).Cells(0).Value.ToString) ung 2 ung i
            'ung count ay minus one kase kasama ung blank sa bilangan
            While reader.Read
                Dim productalreadylisted As Boolean = False
                Dim rowindex As Integer
                If DataGridView1.Rows.Count > 1 Then
                    For i As Integer = 0 To DataGridView1.Rows.Count - 2
                        If DataGridView1.Rows(i).Cells(0).Value.ToString.Equals(reader("productname").ToString) Then
                            rowindex = i
                            productalreadylisted = True
                            Exit For
                        End If
                    Next
                End If
                If productalreadylisted Then
                    If CInt(reader("productquantity")) - CInt(DataGridView1.Rows(rowindex).Cells(1).Value.ToString) <= 0 Then
                        MsgBox("Out of Stock")
                        Exit Sub
                    Else
                        DataGridView1.Rows(rowindex).Cells(2).Value = CDbl(DataGridView1.Rows(rowindex).Cells(2).Value.ToString) + CDbl(reader("productprice").ToString)
                        DataGridView1.Rows(rowindex).Cells(1).Value = CInt(DataGridView1.Rows(rowindex).Cells(1).Value.ToString) + 1
                        Dim initialprice As Double = CDbl(Label4.Text)
                        Label4.Text = initialprice + CDbl(reader("productprice").ToString)
                    End If
                Else
                    If CInt(reader("productquantity") <= 0) Then
                        MsgBox("Out of Stock")
                        Exit Sub
                    Else
                        DataGridView1.Rows.Add(reader("productname").ToString, "1", reader("productprice").ToString)
                        Dim initialprice As Double = CDbl(Label4.Text)
                        Label4.Text = initialprice + CDbl(reader("productprice").ToString)
                    End If
                End If

                If DataGridView1.Rows.Count - 1 > 0 Then
                    Button4.Enabled = True
                Else
                    Button4.Enabled = False
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label9.Text = Date.Now.ToString("hh:mm:ss")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button4.Enabled = False
        Label4.Text = 0
        DataGridView1.Rows.Clear()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MainForm.Show()
        Me.Close()
    End Sub

    Private Sub POSForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        MainForm.Show()
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        Try
            Dim dummy As Integer = DataGridView1.CurrentRow.Index
            If DataGridView1.CurrentRow.Index + 1 = DataGridView1.Rows.Count Then
                Button2.Enabled = False
            Else
                Button2.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim priceofselecteditem As Double
        Try
            conn.ConnectionString = connstring
            conn.Open()


            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM producttbl WHERE productname = '" & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value.ToString & "'"
            Dim reader As MySqlDataReader
            comm.Connection = conn
            comm.CommandText = query
            reader = comm.ExecuteReader

            While reader.Read
                priceofselecteditem = CDbl(reader("productprice").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

        Try
            If DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value.ToString().Equals("1") Then
                DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
                Label4.Text = CDbl(Label4.Text) - priceofselecteditem
                Button2.Enabled = False
            Else
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value = CInt(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value.ToString()) - 1
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value = CDbl(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value.ToString()) - priceofselecteditem
                Label4.Text = CDbl(Label4.Text) - priceofselecteditem
            End If
            'MsgBox(DataGridView1.Rows.Count)
            If DataGridView1.Rows.Count - 1 > 0 Then
                Button4.Enabled = True
            Else
                Button4.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim cash As Double
        If TextBox1.Text = "" Then
            TextBox1.Text = 0
        End If
        Try
            cash = TextBox1.Text
        Catch ex As Exception
            MsgBox("Cash must be numbers")
            TextBox1.Text = 0
            Exit Sub
        End Try
        Label6.Text = cash - CDbl(Label4.Text)
        If CDbl(Label6.Text) < 0 Then
            MsgBox("Please check cash")
            Exit Sub
        End If


        purchaseconfirmed()

        POSPayReportForm.Label6.Text = cash
        POSPayReportForm.Label5.Text = Label6.Text
        'POSPayReportForm.Button1.Enabled = False
        POSPayReportForm.ShowDialog()
    End Sub

    Public Sub purchase(productname As String, quantitypurchased As Integer)
        Dim initialquantity As Integer
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM producttbl WHERE productname = '" & productname & "'"
            Dim reader As MySqlDataReader
            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader

            While reader.Read
                initialquantity = CInt(reader("productquantity").ToString)
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim updatequery As String = "UPDATE producttbl SET productquantity = " & initialquantity - quantitypurchased & " WHERE productname = '" & productname & "'"
            'MsgBox(initialquantity & " - " & quantitypurchased & " = " & initialquantity - quantitypurchased)
            comm.CommandText = updatequery
            comm.Connection = conn
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "INSERT INTO productpurchasestbl(productname,quantity,datepurchased) VALUES('" & productname & "','" & quantitypurchased & "',NOW())"

            comm.CommandText = query
            comm.Connection = conn
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

    End Sub

    Public Sub purchaseconfirmed()
        For i As Integer = 0 To DataGridView1.Rows.Count - 2
            purchase(DataGridView1.Rows(i).Cells(0).Value.ToString, CInt(DataGridView1.Rows(i).Cells(1).Value.ToString))
        Next
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "INSERT INTO `salestbl`(`sold`, `dateandtime`) VALUES (" & Label4.Text & ",now())"

            comm.CommandText = query
            comm.Connection = conn
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','POS - Sold Items','Sold items with a total value of " & Label4.Text & "',NOW())"

            comm.Connection = conn
            comm.CommandText = query
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim cash As Double
        If TextBox1.Text = "" Then
            TextBox1.Text = 0
        End If
        Try
            cash = TextBox1.Text
        Catch ex As Exception
            MsgBox("Cash must be numbers")
            TextBox1.Text = 0
            Exit Sub
        End Try
        Label6.Text = cash - CDbl(Label4.Text)
    End Sub
End Class