Imports MySql.Data.MySqlClient

Public Class LogsForm
    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=pos"

    Private Sub LogsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0

        refreshdatagrid(ComboBox1.Text, TextBox1.Text, ComboBox2.Text, ComboBox3.Text)
    End Sub

    Public Sub refreshdatagrid(searchfor As String, searchword As String, process As String, time As String)
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim query As String = "SELECT * FROM logstbl WHERE "
            If searchfor = "Username" Then
                query = query & "username LIKE '%" & searchword & "%' "
            ElseIf searchfor = "Description" Then
                query = query & "description LIKE '%" & searchword & "%' "
            Else
                query = query & "username LIKE '%" & searchword & "%' "
            End If

            If process = "All" Then
                query = query
            Else
                query = query & "AND process = '" & process & "' "
            End If

            If time = "Today" Then
                query = query & "AND YEAR(dateandtime) = '" & Now.ToString("yyyy") & "' AND MONTH(dateandtime) = '" & Now.ToString("MM") & "' AND DAY(dateandtime) = '" & Now.ToString("dd") & "' ORDER BY dateandtime DESC"
            ElseIf time = "This Month" Then
                query = query & "AND YEAR(dateandtime) = '" & Now.ToString("yyyy") & "' AND MONTH(dateandtime) = '" & Now.ToString("MM") & "' ORDER BY dateandtime DESC"
            ElseIf time = "This Year" Then
                query = query & "AND YEAR(dateandtime) = '" & Now.ToString("yyyy") & "' ORDER BY dateandtime DESC"
            ElseIf time = "All" Then
                query = query & " ORDER BY dateandtime DESC"
            Else
                query = query & " ORDER BY dateandtime DESC"
            End If

            Dim comm As New MySqlCommand
            Dim reader As MySqlDataReader

            comm.Connection = conn
            comm.CommandText = query
            reader = comm.ExecuteReader

            DataGridView1.Rows.Clear()

            While reader.Read
                DataGridView1.Rows.Add(reader("username").ToString, reader("process").ToString, reader("description").ToString, reader("dateandtime").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        refreshdatagrid(ComboBox1.Text, TextBox1.Text, ComboBox2.Text, ComboBox3.Text)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        refreshdatagrid(ComboBox1.Text, TextBox1.Text, ComboBox2.Text, ComboBox3.Text)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        refreshdatagrid(ComboBox1.Text, TextBox1.Text, ComboBox2.Text, ComboBox3.Text)
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        refreshdatagrid(ComboBox1.Text, TextBox1.Text, ComboBox2.Text, ComboBox3.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainForm.Show()
        Me.Close()
    End Sub

    Private Sub LogsForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        MainForm.Show()
    End Sub
End Class