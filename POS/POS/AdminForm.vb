Imports MySql.Data.MySqlClient

Public Class AdminForm
    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=pos"
    Dim addclicked As Boolean = False
    Dim editclicked As Boolean = False
    Private Sub AdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM usertbl"
            Dim reader As MySqlDataReader

            comm.Connection = conn
            comm.CommandText = query
            reader = comm.ExecuteReader

            While reader.Read
                DataGridView1.Rows.Add(reader("id").ToString, reader("name").ToString, reader("usertype").ToString, reader("username").ToString, reader("userpassword").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
        Button1.Enabled = False
        Button2.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox1.Enabled = False

    End Sub

    Public Sub searchuser(searchstring As String, administrator As Boolean, employee As Boolean)
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim query As String
            Dim comm As New MySqlCommand
            If administrator And employee Then
                query = "SELECT * FROM usertbl WHERE name LIKE '%" & searchstring & "%'"
            ElseIf administrator And Not employee Then
                query = "SELECT * FROM usertbl WHERE name LIKE '%" & searchstring & "%' AND usertype = 'Administrator'"
            ElseIf Not administrator And employee Then
                query = "SELECT * FROM usertbl WHERE name LIKE '%" & searchstring & "%' AND usertype = 'Employee'"
            Else
                query = "SELECT * FROM usertbl WHERE name LIKE '%" & searchstring & "%'"
            End If

            Dim reader As MySqlDataReader

            comm.Connection = conn
            comm.CommandText = query
            reader = comm.ExecuteReader

            DataGridView1.Rows.Clear()

            While reader.Read
                DataGridView1.Rows.Add(reader("id").ToString, reader("name").ToString, reader("usertype").ToString, reader("username").ToString, reader("userpassword").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        searchuser(TextBox4.Text, CheckBox1.Checked, CheckBox2.Checked)
    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As EventArgs) Handles CheckBox1.Click
        If Not CheckBox2.Checked Then
            CheckBox1.Checked = True
        End If
        searchuser(TextBox4.Text, CheckBox1.Checked, CheckBox2.Checked)
    End Sub

    Private Sub CheckBox2_Click(sender As Object, e As EventArgs) Handles CheckBox2.Click
        If Not CheckBox1.Checked Then
            CheckBox2.Checked = True
        End If
        searchuser(TextBox4.Text, CheckBox1.Checked, CheckBox2.Checked)
    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs) Handles DataGridView1.Click
        Dim id As String
        Try
            id = DataGridView1.CurrentRow.Cells(0).Value.ToString
        Catch ex As Exception
            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            ComboBox1.Enabled = False

            Label7.Text = ""
            TextBox1.Text = ""
            ComboBox1.Items.Clear()
            TextBox2.Text = ""
            TextBox3.Text = ""
            Label7.Text = "Please select a user"
            Exit Sub
        End Try

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM usertbl WHERE id=" & id
            Dim reader As MySqlDataReader

            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader

            While reader.Read
                Label7.Text = reader("id").ToString
                TextBox1.Text = reader("name").ToString

                ComboBox1.Items.Clear()
                ComboBox1.Items.Add("Administrator")
                ComboBox1.Items.Add("Employee")
                If reader("usertype").ToString = "Administrator" Then
                    ComboBox1.SelectedIndex = 0
                ElseIf reader("usertype").ToString = "Employee" Then
                    ComboBox1.SelectedIndex = 1
                Else
                    ComboBox1.SelectedIndex = 0
                End If

                TextBox2.Text = reader("username").ToString
                TextBox3.Text = reader("userpassword").ToString

            End While

            Button4.Enabled = True
            Button5.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        addclicked = True
        editclicked = False
        Label7.Text = "To be generated"
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Administrator")
        ComboBox1.Items.Add("Employee")
        DataGridView1.Enabled = False
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If addclicked Then
            Label7.Text = "Please select a user"
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            ComboBox1.Enabled = False
            ComboBox1.Items.Clear()
            DataGridView1.Enabled = True
            Button1.Enabled = False
            Button2.Enabled = False
            Button3.Enabled = True
            Button4.Enabled = False
            Button5.Enabled = False
        ElseIf editclicked Then
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button1.Enabled = False
            Button2.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            ComboBox1.Enabled = False
            DataGridView1.Enabled = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        editclicked = True
        addclicked = False
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button1.Enabled = True
        Button2.Enabled = True
        DataGridView1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Please input name")
            Exit Sub
        End If
        If TextBox2.Text = "" Then
            MsgBox("Please input username")
            Exit Sub
        End If
        If TextBox3.Text = "" Then
            MsgBox("Please input password")
            Exit Sub
        End If
        If ComboBox1.Text = "" Then
            MsgBox("Please choose type")
            Exit Sub
        End If
        Dim usernamealreadyexisted As Boolean = False
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM usertbl"
            Dim reader As MySqlDataReader

            comm.Connection = conn
            comm.CommandText = query
            reader = comm.ExecuteReader

            While reader.Read
                If reader("username") = TextBox2.Text Then
                    usernamealreadyexisted = True
                    Exit While
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

        If usernamealreadyexisted Then
            MsgBox("Username already in use")
            Exit Sub
        End If

        If addclicked Then
            Try
                conn.ConnectionString = connstring
                conn.Open()

                Dim comm As New MySqlCommand
                Dim query As String = "INSERT INTO usertbl(username,userpassword,usertype,name) VALUES('" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "','" & TextBox1.Text & "')"

                comm.Connection = conn
                comm.CommandText = query
                comm.ExecuteNonQuery()

                MsgBox("Added Successfully")

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
                Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Admin - New Account','New account added (username is " & TextBox2.Text & ")',NOW())"

                comm.Connection = conn
                comm.CommandText = query
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
            End Try

            Label7.Text = "Please select a user"
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            ComboBox1.Items.Clear()

            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            ComboBox1.Items.Clear()

            Button3.Enabled = True
            Button1.Enabled = False
            Button2.Enabled = False
            Button4.Enabled = False
            Button5.Enabled = False
            ComboBox1.Enabled = False

            DataGridView1.Enabled = True

            searchuser(TextBox4.Text, CheckBox1.Checked, CheckBox2.Checked)

        ElseIf editclicked Then
            Try
                conn.ConnectionString = connstring
                conn.Open()

                Dim comm As New MySqlCommand
                Dim query As String = "UPDATE usertbl SET username='" & TextBox2.Text & "', userpassword='" & TextBox3.Text & "', usertype='" & ComboBox1.Text & "', name='" & TextBox1.Text & "' WHERE id=" & Label7.Text
                comm.CommandText = query
                comm.Connection = conn
                comm.ExecuteNonQuery()

                MsgBox("Updated successfully")


            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
            End Try

            Try
                conn.ConnectionString = connstring
                conn.Open()

                Dim comm As New MySqlCommand
                Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Admin - Edit Account','Account edited (username is " & TextBox2.Text & ")',NOW())"

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
            Button4.Enabled = False
            Button5.Enabled = False

            DataGridView1.Enabled = True

            searchuser(TextBox4.Text, CheckBox1.Checked, CheckBox2.Checked)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Select Case (MsgBox("Are you sure you want to delete this user?", vbYesNo))
            Case vbYes : deleteuser(Label7.Text)
        End Select
    End Sub

    Public Sub deleteuser(id As String)
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "DELETE FROM usertbl WHERE id=" & id
            comm.CommandText = query
            comm.Connection = conn
            comm.ExecuteNonQuery()

            MsgBox("Deleted successfully")
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
            Dim query As String = "INSERT INTO logstbl(username,process,description,dateandtime) VALUES('" & LoginForm.username & "','Admin - Delete Account','Deleted account (" & TextBox2.Text & ")',NOW())"

            comm.Connection = conn
            comm.CommandText = query
            comm.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

        Label7.Text = "Please select a user"
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.Items.Clear()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox1.Enabled = False

        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = False
        Button5.Enabled = False

        DataGridView1.Enabled = True

        searchuser(TextBox4.Text, CheckBox1.Checked, CheckBox2.Checked)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MainForm.Show()
        Me.Close()
    End Sub

    Private Sub AdminForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        MainForm.Show()
    End Sub
End Class