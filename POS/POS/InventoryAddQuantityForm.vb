Imports MySql.Data.MySqlClient

Public Class InventoryAddQuantityForm
    Dim initialquantity As Integer
    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;oDatabase=POS"

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub InventoryAddQuantityForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initialquantity = InventoryForm.TextBox3.Text
        Me.Label2.Text = InventoryForm.TextBox2.Text
        Me.Label3.Text = InventoryForm.Label8.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim dummy As Integer = CInt(TextBox1.Text)
        Catch ex As Exception
            MsgBox("Please enter a valid quantity")
            Exit Sub
        End Try
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim finalquantity As Integer = initialquantity + CInt(TextBox1.Text)

            Dim comm As New MySqlCommand
            Dim query As String = "UPDATE producttbl SET productquantity = " & finalquantity & " WHERE productid = '" & Label3.Text & "'"
            'UPDATE `producttbl` SET `productid`=[value-1],`productname`=[value-2],`productcategoryid`=[value-3],`productquantity`=[value-4],`productprice`=[value-5] WHERE 1

            comm.CommandText = query
            comm.Connection = conn
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        Finally
            conn.Close()
        End Try

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Inventory - Add Quantity','Quantity (" & TextBox1.Text & ") added to Product (" & Label2.Text & ")',NOW())"

            comm.Connection = conn
            comm.CommandText = query
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

        InventoryForm.searchitem(InventoryForm.TextBox1.Text, InventoryForm.ComboBox1.Text)
        InventoryForm.iteminfo(Label3.Text)
        Me.Close()

    End Sub
End Class