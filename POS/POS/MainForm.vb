Imports System.ComponentModel
Imports MySql.Data.MySqlClient

Public Class MainForm
    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=pos"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Open POS','Opened POS',NOW())"

            comm.Connection = conn
            comm.CommandText = query
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
        POSForm.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Open Inventory','Opened Inventory',NOW())"

            comm.Connection = conn
            comm.CommandText = query
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
        InventoryForm.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ExitForm.ShowDialog()
    End Sub

    Private Sub MainForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Logout','Logout',NOW())"

            comm.Connection = conn
            comm.CommandText = query
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

        Application.Exit()



    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Open Admin','Opened Admin',NOW())"

            comm.Connection = conn
            comm.CommandText = query
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
        AdminForm.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Open Reports','Opened Reports',NOW())"

            comm.Connection = conn
            comm.CommandText = query
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
        ReportsForm.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Open Logs','Opened Logs',NOW())"

            comm.Connection = conn
            comm.CommandText = query
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
        LogsForm.Show()
        Me.Hide()
    End Sub
End Class
