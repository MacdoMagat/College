Imports MySql.Data.MySqlClient

Public Class InventoryEditCategoryEditForm
    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=POS"
    Dim category As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("New name must not be blank")
            Exit Sub
        End If
        If InventoryEditCategoryForm.ListBox1.Items.Contains(Me.TextBox1.Text) Then
            MsgBox("Category already exists")
            Exit Sub
        End If
        Dim categoryindex As Integer
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM productcategorytbl WHERE productcategoryname = '" & category & "'"
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
            Dim query As String = "UPDATE productcategorytbl SET productcategoryname = '" & TextBox1.Text & "' WHERE productcategoryid = " & categoryindex

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
            Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Inventory - Edit Category','Edited category (" & category & ")',NOW())"

            comm.Connection = conn
            comm.CommandText = query
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try


        Me.Close()
        InventoryEditCategoryForm.refreshcategory()
    End Sub

    Private Sub InventoryEditCategoryEditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        category = InventoryEditCategoryForm.ListBox1.SelectedItem.ToString()
        Label4.Text = category
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class