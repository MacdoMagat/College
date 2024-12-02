Imports MySql.Data.MySqlClient


Public Class Form3

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost; User ID=root;Password=;Database=sampledb3a"





    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conn.ConnectionString = connstring
        conn.Open()
        Dim selectstring As String = "SELECT * FROM vbstudentform"
        Dim comm As New MySqlCommand(selectstring, conn)
        Dim adapter As New MySqlDataAdapter
        Dim reader As MySqlDataReader
        Dim table As New DataTable

        adapter.SelectCommand = comm
        adapter.Fill(table)

        reader = comm.ExecuteReader

        While reader.Read
            studentid.Text = reader("studentid").ToString
        End While

        DataGridView1.DataSource = table
        conn.Close()
        conn.Dispose()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim comm As New MySqlCommand
        conn.ConnectionString = connstring
        conn.Open()
        Dim savequery As String

        Dim gender As String
        If male.Enabled = True Then
            gender = "Male"
        End If
        If female.Enabled = True Then
            gender = "Female"
        End If

        savequery = "INSERT INTO vbstudentform VALUES ('" & studentid.Text & "','" & studentname.Text & "','" & fathersname.Text & "','" & form.Text & "','" & dob.Text & "','" & dor.Text & "','" & classs.Text & "','" & medium.Text & "','" & gender & "','" & mobile.Text & "','" & address.Text & "')"
        With comm
            .CommandType = CommandType.Text
            .Connection = conn
            .CommandText = savequery
            .ExecuteNonQuery()
        End With
        MsgBox("Saved")
        conn.Close()
        conn.Dispose()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        MsgBox("This option will be available on the next update")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        studentid.Text = ""
        studentname.Text = ""
        fathersname.Text = ""
        form.Text = ""
        dob.Text = ""
        dor.Text = ""
        classs.Text = ""
        medium.Text = ""
        mobile.Text = ""
        address.Text = ""

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Delete.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        MsgBox("This option will be available on the next update")
    End Sub
End Class