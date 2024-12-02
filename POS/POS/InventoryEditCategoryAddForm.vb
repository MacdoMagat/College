Imports MySql.Data.MySqlClient

Public Class InventoryEditCategoryAddForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=POS"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Please input name for new category")
            Exit Sub
        End If
        If InventoryEditCategoryForm.ListBox1.Items.Contains(Me.TextBox1.Text) Then
            MsgBox("Category already exists")
            Exit Sub
        End If
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "INSERT INTO productcategorytbl (productcategoryname) VALUES ('" & TextBox1.Text & "')"

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
            Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Inventory - New Category','New category added (" & TextBox1.Text & ")',NOW())"

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


End Class