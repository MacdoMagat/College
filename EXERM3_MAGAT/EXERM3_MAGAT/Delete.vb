Imports MySql.Data.MySqlClient


Public Class Delete

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim conn As New MySqlConnection
        Dim comm As New MySqlCommand
        Dim connstring As String = "Server=localhost; User ID=root;Password=;Database=sampledb3a"
        Dim commstring As String

        conn.ConnectionString = connstring
        conn.Open()

        commstring = "DELETE FROM vbstudentform WHERE studentid = '" & TextBox1.Text & "'"

        comm.Connection = conn
        comm.CommandText = commstring
        comm.CommandType = CommandType.Text
        comm.ExecuteNonQuery()

        MsgBox("Deleted")


        conn.Close()
        conn.Dispose()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class