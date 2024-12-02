Imports MySql.Data.MySqlClient

Public Class AdminChangePWForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    'Dim oldpass As String

    Public Sub changeConnstring(department As String)
        If department.Equals("IT") Then
            connstring = "Server=localhost;User Id=root;Password=;Database=etas"
        ElseIf department.Equals("PA") Then
            connstring = "Server=localhost;User Id=root;Password=;Database=etaspa"
        ElseIf department.Equals("Entrep") Then
            connstring = "Server=localhost;User Id=root;Password=;Database=etasentrep"
        Else
            connstring = "Server=localhost;User Id=root;Password=;Database=etas"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtnewpw.Text = "" Or txtoldpw.Text = "" Or txtreppw.Text = "" Then
            MsgBox("Please fill up all fields")
            Exit Sub
        End If


        'Try
        '    conn.ConnectionString = connstring
        '    conn.Open()

        '    Dim comm As New MySqlCommand
        '    Dim commstring As String = "SELECT * FROM admintbl"
        '    Dim reader As MySqlDataReader
        '    comm.CommandText = commstring
        '    comm.Connection = conn
        '    reader = comm.ExecuteReader

        '    While (reader.Read)
        '        oldpass = reader("adminpassword").ToString
        '    End While

        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'Finally
        '    conn.Close()
        'End Try

        If Not txtoldpw.Text.Equals(ContainerForm.adminpassword) Then
            MsgBox("Old Password is incorrect")
            Exit Sub
        End If

        If Not txtnewpw.Text.Equals(txtreppw.Text) Then
            MsgBox("New password does not match")
            Exit Sub
        End If

        If txtoldpw.Text.Equals(ContainerForm.adminpassword) And txtnewpw.Text.Equals(txtreppw.Text) Then
            updatepw()
            ContainerForm.admin.loadfields()
            Me.Close()
        End If

    End Sub

    Public Sub resetfields()
        txtreppw.Text = ""
        txtoldpw.Text = ""
        txtnewpw.Text = ""
    End Sub

    Public Sub updatepw()

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim commstring As String = "Update `admintbl` Set `adminpassword`='" & txtnewpw.Text.Replace("'", "''") & "' WHERE adminusername='" & ContainerForm.adminusername.Replace("'", "''") & "'"
            comm.CommandText = commstring
            comm.Connection = conn
            comm.CommandType = CommandType.Text
            comm.ExecuteNonQuery()

            ContainerForm.adminpassword = txtnewpw.Text
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

        'Update() `admintbl` Set `adminusername`=[value-2],`adminpassword`=[value-3] WHERE id=1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ContainerForm.admin.loadfields()
        Me.Close()
    End Sub
End Class