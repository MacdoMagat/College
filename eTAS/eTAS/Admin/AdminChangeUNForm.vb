Imports MySql.Data.MySqlClient

Public Class AdminChangeUNForm

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

        If txtnewun.Text = "" Or txtpw.Text = "" Then
            MsgBox("Please fill up the fields")
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

        If txtpw.Text.Equals(ContainerForm.adminpassword) Then
            If hasDuplicate(txtnewun.Text) Then
                MsgBox("Username already exists")
            Else
                updateun()
                ContainerForm.admin.loadfields()
                Me.Close()
            End If
        Else
            MsgBox("Password is incorrect")
        End If

    End Sub


    Public Sub resetfields()
        txtnewun.Text = ""
        txtpw.Text = ""
    End Sub

    Public Sub updateun()
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim commstring As String = "Update `admintbl` Set `adminusername`='" & txtnewun.Text.Replace("'", "''") & "' WHERE adminusername = '" & ContainerForm.adminusername.Replace("'", "''") & "'"
            comm.CommandText = commstring
            comm.Connection = conn
            comm.CommandType = CommandType.Text
            comm.ExecuteNonQuery()

            ContainerForm.adminusername = txtnewun.Text
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

    Public Function hasDuplicate(username As String) As Boolean
        Dim detected As Boolean = False
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim commstring As String = "SELECT * FROM admintbl WHERE adminusername = '" & username.Replace("'", "''") & "'"
            Dim reader As MySqlDataReader
            comm.CommandText = commstring
            comm.Connection = conn
            reader = comm.ExecuteReader


            While (reader.Read)
                detected = True
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
        Return detected
    End Function

End Class