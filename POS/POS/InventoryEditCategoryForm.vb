Imports MySql.Data.MySqlClient

Public Class InventoryEditCategoryForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=POS"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        InventoryEditCategoryAddForm.TextBox1.Text = ""
        InventoryEditCategoryAddForm.ShowDialog()
    End Sub

    Private Sub InventoryEditCategoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshcategory()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim category As String
        Try
            category = ListBox1.SelectedItem.ToString()
            Select Case (MsgBox("Are you sure you want to delete this category(" & category & ")?" & vbNewLine & "Deleting categories will delete products included in the category", vbYesNo))
                Case vbYes : deletecategory(category)
            End Select
        Catch ex As Exception
            MsgBox("Please select category to delete")
        End Try
    End Sub

    Public Sub refreshcategory()
        ListBox1.Items.Clear()
        Button2.Enabled = False
        Button3.Enabled = False

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM productcategorytbl ORDER BY productcategoryname"
            Dim reader As MySqlDataReader

            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader


            While reader.Read
                ListBox1.Items.Add(reader("productcategoryname").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub InventoryEditCategoryForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        InventoryForm.refreshcategoryanddatagrid()
        InventoryForm.loadcategory()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        InventoryEditCategoryEditForm.TextBox1.Text = ""
        InventoryEditCategoryEditForm.ShowDialog()
    End Sub

    Private Sub deletecategory(category As String)
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
            Dim query As String = "DELETE FROM productcategorytbl WHERE productcategoryid = " & categoryindex

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
            Dim query As String = "DELETE FROM producttbl WHERE productcategoryid = " & categoryindex

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
            Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Inventory - Delete Category','Deleted category (" & category & ")',NOW())"

            comm.Connection = conn
            comm.CommandText = query
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

        MsgBox("Deleted Successfully")
        refreshcategory()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
End Class