Imports MySql.Data.MySqlClient

Public Class InventoryForm
    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=POS"
    Dim newclicked As Boolean
    Dim editclicked As Boolean

    Private Sub InventoryForm_Load(qsender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid"
            Dim reader As MySqlDataReader

            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader

            While reader.Read
                DataGridView1.Rows.Add(reader("productid").ToString, reader("productname").ToString, reader("productquantity").ToString, reader("productcategoryname").ToString, reader("productprice").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            conn.Close()
        End Try

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM productcategorytbl ORDER BY productcategoryname"
            Dim reader As MySqlDataReader

            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader

            ComboBox1.Items.Add("All")
            While reader.Read
                ComboBox1.Items.Add(reader("productcategoryname").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            conn.Close()
        End Try
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        searchitem(TextBox1.Text, ComboBox1.Text)
    End Sub

    Public Sub searchitem(productname As String, productcategory As String)
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String
            If productcategory.Equals("All") Then
                query = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid WHERE producttbl.productname LIKE '%" & productname & "%'"
            Else
                query = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid WHERE producttbl.productname LIKE '%" & productname & "%' AND productcategorytbl.productcategoryname = '" & productcategory & "'"
            End If
            Dim reader As MySqlDataReader

            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader

            DataGridView1.Rows.Clear()
            While reader.Read
                DataGridView1.Rows.Add(reader("productid").ToString, reader("productname").ToString, reader("productquantity").ToString, reader("productcategoryname").ToString, reader("productprice").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        searchitem(TextBox1.Text, ComboBox1.Text)
    End Sub

    Public Sub loadcategory()
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM productcategorytbl ORDER BY productcategoryname"
            Dim reader As MySqlDataReader

            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader

            ComboBox2.Items.Clear()

            While reader.Read
                ComboBox2.Items.Add(reader("productcategoryname").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        Dim category As String = ""
        Try
            Dim idselected As String = DataGridView1.CurrentRow.Cells(0).Value.ToString

            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid WHERE productid = '" & idselected & "'"
            Dim reader As MySqlDataReader

            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader

            While reader.Read
                Label8.Text = reader("productid").ToString
                TextBox2.Text = reader("productname").ToString
                TextBox3.Text = reader("productquantity").ToString
                TextBox4.Text = reader("productprice").ToString
                category = reader("productcategoryname").ToString
            End While
        Catch ex As Exception

        Finally
            conn.Close()
        End Try
        loadcategory()
        If Not category = "" Then
            ComboBox2.SelectedItem = category
        Else
            MsgBox("Please select product")
            ComboBox2.SelectedIndex = 0
        End If
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        InventoryAddQuantityForm.ShowDialog()
        InventoryAddQuantityForm.TextBox1.Text = ""
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Select Case MsgBox("Are you sure you want to delete this product(" & TextBox2.Text & ")?", vbYesNo)
            Case vbYes : deleteproduct(Label8.Text)
        End Select
    End Sub

    Public Sub deleteproduct(id)
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Inventory - Delete Product','Delete product (" & TextBox2.Text & ")',NOW())"

            comm.Connection = conn
            comm.CommandText = query
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
            Dim query As String = "DELETE FROM producttbl WHERE productid = '" & id & "'"

            comm.CommandText = query
            comm.Connection = conn
            comm.ExecuteNonQuery()

            MsgBox("Deleted Successfully")

            Label8.Text = "Please select product"
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            ComboBox2.Items.Clear()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
            searchitem(TextBox1.Text, ComboBox1.Text)
        End Try
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Public Sub iteminfo(id)
        Dim category As String = ""
        Try
            Dim idselected As String = id

            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid WHERE productid = '" & idselected & "'"
            Dim reader As MySqlDataReader

            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader

            While reader.Read
                Label8.Text = reader("productid").ToString
                TextBox2.Text = reader("productname").ToString
                TextBox3.Text = reader("productquantity").ToString
                TextBox4.Text = reader("productprice").ToString
                category = reader("productcategoryname").ToString
            End While
        Catch ex As Exception

        Finally
            conn.Close()
        End Try
        loadcategory()
        If Not category = "" Then
            ComboBox2.SelectedItem = category
        Else
            MsgBox("Please select product")
            ComboBox2.SelectedIndex = 0
        End If
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        DataGridView1.Enabled = False
        ComboBox2.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True

        Label8.Text = "To be generated"
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""


        loadcategory()

        newclicked = True
        editclicked = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        DataGridView1.Enabled = True
        ComboBox2.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False

        If newclicked Then
            Label8.Text = "Please select product"
            Button6.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            ComboBox2.Items.Clear()
        ElseIf editclicked Then

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        DataGridView1.Enabled = False
        ComboBox2.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True

        newclicked = False
        editclicked = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            MsgBox("Please enter product name")
            Exit Sub
        End If
        Try
            Dim dummy As Double = CDbl(TextBox3.Text)
        Catch ex As Exception
            MsgBox("Please use only numbers on quantity")
            Exit Sub
        End Try
        Try
            Dim dummy As Double = CDbl(TextBox4.Text)
        Catch ex As Exception
            MsgBox("Please use only numbers on price")
            Exit Sub
        End Try
        If ComboBox2.Text = "" Then
            MsgBox("Please select category")
            Exit Sub
        End If

        If newclicked Then

            Dim nameexists As Boolean = False
            Try
                conn.ConnectionString = connstring
                conn.Open()

                Dim comm As New MySqlCommand
                Dim query As String = "SELECT * FROM producttbl"
                Dim reader As MySqlDataReader

                comm.CommandText = query
                comm.Connection = conn
                reader = comm.ExecuteReader

                While reader.Read
                    If reader("productname").ToString.Equals(TextBox2.Text) Then
                        nameexists = True
                        Exit While
                    End If
                End While
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
            End Try
            If nameexists Then
                MsgBox("Product name already exists")
                Exit Sub
            End If

            Dim categoryindex As Integer
            Try
                conn.ConnectionString = connstring
                conn.Open()

                Dim comm As New MySqlCommand
                Dim query As String = "SELECT * FROM productcategorytbl WHERE productcategoryname = '" & ComboBox2.Text & "'"
                Dim reader As MySqlDataReader
                comm.Connection = conn
                comm.CommandText = query
                reader = comm.ExecuteReader

                While reader.Read
                    categoryindex = CInt(reader("productcategoryid").ToString)
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
                Dim query As String = "INSERT INTO producttbl(productname,productcategoryid,productquantity,productprice) VALUES ('" & TextBox2.Text & "'," & categoryindex & "," & TextBox3.Text & "," & TextBox4.Text & ")"

                comm.CommandText = query
                comm.Connection = conn
                comm.ExecuteNonQuery()

                MsgBox("Saved")
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
            End Try

            Try
                conn.ConnectionString = connstring
                conn.Open()

                Dim comm As New MySqlCommand
                Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Inventory - New Product','Added new product (" & TextBox2.Text & ")',NOW())"

                comm.Connection = conn
                comm.CommandText = query
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
            End Try

            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            DataGridView1.Enabled = True
            ComboBox2.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False

            Label8.Text = "Please select product"
            Button6.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            ComboBox2.Items.Clear()

            searchitem(TextBox1.Text, ComboBox1.Text)

        ElseIf editclicked Then
            Dim categoryindex As Integer
            Try
                conn.ConnectionString = connstring
                conn.Open()

                Dim comm As New MySqlCommand
                Dim query As String = "SELECT * FROM productcategorytbl WHERE productcategoryname = '" & ComboBox2.Text & "'"
                Dim reader As MySqlDataReader
                comm.Connection = conn
                comm.CommandText = query
                reader = comm.ExecuteReader

                While reader.Read
                    categoryindex = CInt(reader("productcategoryid").ToString)
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
                'Dim query As String = "INSERT INTO producttbl(productname,productcategoryid,productquantity,productprice) VALUES ('" & TextBox2.Text & "'," & categoryindex & "," & TextBox3.Text & "," & TextBox4.Text & ")"
                Dim query As String = "UPDATE producttbl SET productname = '" & TextBox2.Text & "', productcategoryid = " & categoryindex & ", productquantity = " & TextBox3.Text & ", productprice = " & TextBox4.Text & " WHERE productid = " & Label8.Text

                comm.CommandText = query
                comm.Connection = conn
                comm.ExecuteNonQuery()

                MsgBox("Updated")
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
            End Try

            Try
                conn.ConnectionString = connstring
                conn.Open()

                Dim comm As New MySqlCommand
                Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Inventory - Edit Product','Edit Product (" & TextBox2.Text & ")',NOW())"

                comm.Connection = conn
                comm.CommandText = query
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
            End Try

            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            DataGridView1.Enabled = True
            ComboBox2.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False

            Label8.Text = "Please select product"
            Button6.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            ComboBox2.Items.Clear()

            searchitem(TextBox1.Text, ComboBox1.Text)

        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MainForm.Show()
        Me.Close()
    End Sub

    Private Sub InventoryForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        MainForm.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        InventoryEditCategoryForm.ShowDialog()
    End Sub

    Public Sub refreshcategoryanddatagrid()
        ComboBox1.Items.Clear()
        DataGridView1.Rows.Clear()

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM producttbl LEFT JOIN productcategorytbl ON producttbl.productcategoryid = productcategorytbl.productcategoryid"
            Dim reader As MySqlDataReader

            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader

            While reader.Read
                DataGridView1.Rows.Add(reader("productid").ToString, reader("productname").ToString, reader("productquantity").ToString, reader("productcategoryname").ToString, reader("productprice").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            conn.Close()
        End Try

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM productcategorytbl ORDER BY productcategoryname"
            Dim reader As MySqlDataReader

            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader

            ComboBox1.Items.Add("All")
            While reader.Read
                ComboBox1.Items.Add(reader("productcategoryname").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            conn.Close()
        End Try
        ComboBox1.SelectedIndex = 0
    End Sub

End Class