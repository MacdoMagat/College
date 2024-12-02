Imports MySql.Data.MySqlClient

Public Class Form1
    Dim usertype As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load






        usertype = "admin"

        Panel1.BackColor = Color.LightGray
        Button3.Enabled = False
        Button3.BackColor = Color.LightGray
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        usertype = "user"
        Button3.BackColor = Color.WhiteSmoke
        Button3.Enabled = True
        Button4.Enabled = False
        Button4.BackColor = Color.LightGray
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        usertype = "admin"
        Button4.BackColor = Color.WhiteSmoke
        Button4.Enabled = True
        Button3.Enabled = False
        Button3.BackColor = Color.LightGray
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim conn As New MySqlConnection
        Dim comm As MySqlCommand
        Dim reader As MySqlDataReader
        Dim connstring As String = "Server=localhost; User ID=root;Password=;Database=sampledb3a"
        Dim commstring As String

        conn.ConnectionString = connstring
        conn.Open()

        If usertype = "admin" Then
            commstring = "SELECT * FROM vbaccounttbl WHERE vbusername = '" & TextBox1.Text & "' AND vbpassword = '" & TextBox2.Text & "' AND vbtype = 'Administrator'"
            comm = New MySqlCommand(commstring, conn)
            reader = comm.ExecuteReader

            Dim check As Integer
            check = 0

            While (reader.Read)
                check = check + 1
            End While

            If check < 0 Then
                MsgBox("No Account Detected")
            ElseIf check = 1 Then
                MsgBox("Welcome Admin!")
                Form2.Show()
                Me.Hide()
            ElseIf check > 1 Then
                MsgBox("Multiple Accounts")
            Else
                MsgBox("Error")
            End If
        End If

        If usertype = "user" Then
            commstring = "SELECT * FROM vbaccounttbl WHERE vbusername = '" & TextBox1.Text & "' AND vbpassword = '" & TextBox2.Text & "' AND vbtype = 'User'"
            comm = New MySqlCommand(commstring, conn)
            reader = comm.ExecuteReader

            Dim check As Integer
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
        End If



        conn.Close()
        conn.Dispose()

    End Sub
End Class
