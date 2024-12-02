Imports MySql.Data.MySqlClient
Public Class login
    Dim usertype As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim conn As New MySqlConnection
        Dim comm As MySqlCommand
        Dim reader As MySqlDataReader
        Dim connstring As String = "Server=localhost; User ID=root;Password=;Database=oabel_db"
        Dim commstring As String

        conn.ConnectionString = connstring
        conn.Open()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        user_registration.Show()
    End Sub
End Class
