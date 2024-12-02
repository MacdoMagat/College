Imports MySql.Data.MySqlClient

Public Class LoginForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=pos"
    Public type As String
    Public username As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM usertbl WHERE username='" & TextBox1.Text & "' AND userpassword='" & TextBox2.Text & "'"
            Dim reader As MySqlDataReader

            comm.Connection = conn
            comm.CommandText = query
            reader = comm.ExecuteReader

            Dim counter As Integer = 0

            While reader.Read
                counter = counter + 1
            End While
            If counter > 0 Then
                type = reader("usertype").ToString
                username = reader("username").ToString
                MainForm.Show()
                Me.Hide()
            Else
                MsgBox("Please check your username and password")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
        If type = "Employee" Then
            MainForm.Button1.Enabled = True
            MainForm.Button2.Enabled = False
            MainForm.Button3.Enabled = False
            MainForm.Button4.Enabled = False
            MainForm.Button5.Enabled = False
            MainForm.Button6.Enabled = True

            Try
                conn.ConnectionString = connstring
                conn.Open()

                Dim comm As New MySqlCommand
                Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & username & "','Login','Logged in',NOW())"

                comm.Connection = conn
                comm.CommandText = query
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
            End Try

        ElseIf type = "Administrator" Then
            MainForm.Button1.Enabled = True
            MainForm.Button2.Enabled = True
            MainForm.Button3.Enabled = True
            MainForm.Button4.Enabled = True
            MainForm.Button5.Enabled = True
            MainForm.Button6.Enabled = True

            Try
                conn.ConnectionString = connstring
                conn.Open()

                Dim comm As New MySqlCommand
                Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & username & "','Login','Logged In',NOW())"

                comm.Connection = conn
                comm.CommandText = query
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

End Class