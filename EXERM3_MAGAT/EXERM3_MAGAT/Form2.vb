Imports MySql.Data.MySqlClient


Public Class Form2

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost; User ID=root;Password=;Database=sampledb3a"

   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim comm As New MySqlCommand
        conn.ConnectionString = connstring
        conn.Open()
        Dim savequery As String

        savequery = "INSERT INTO vbaccounttbl VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "')"
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim conn As New MySqlConnection
        Dim comm As MySqlCommand
        Dim reader As MySqlDataReader
        Dim connstring As String = "Server=localhost; User ID=root;Password=;Database=sampledb3a"
        Dim commstring As String

        conn.ConnectionString = connstring
        conn.Open()


        commstring = "SELECT * FROM vbaccounttbl WHERE vbusername = '" & TextBox5.Text & "' AND vbpassword = '" & TextBox4.Text & "' AND vbtype = 'Administrator'"
        comm = New MySqlCommand(commstring, conn)
        reader = comm.ExecuteReader

        Dim check As Integer
        check = 0

        While (reader.Read)
            check = check + 1
        End While

        If check = 0 Then
            reader.Close()

            commstring = "SELECT * FROM vbaccounttbl WHERE vbusername = '" & TextBox5.Text & "' AND vbpassword = '" & TextBox4.Text & "' AND vbtype = 'User'"
            comm = New MySqlCommand(commstring, conn)
            reader = comm.ExecuteReader


            check = 0

            While (reader.Read)
                check = check + 1
            End While

            If check < 0 Then
                MsgBox("No Account Detected")
            ElseIf check = 1 Then
                MsgBox("Welcome User!")
                Form3.Show()
                Me.Hide()
            ElseIf check > 1 Then
                MsgBox("Multiple Accounts")
            Else
                MsgBox("Error")
            End If


        ElseIf check = 1 Then
            MsgBox("Welcome Admin!")
            Form3.Show()
            Me.Hide()
        ElseIf check > 1 Then
            MsgBox("Multiple Accounts")
        Else
            MsgBox("Error")
        End If

        



        conn.Close()
        conn.Dispose()
    End Sub
End Class