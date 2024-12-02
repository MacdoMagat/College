Imports MySql.Data.MySqlClient

Public Class AdminLoginForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Dim idOfAdmin As String
    'Dim usernameIgnoreCaseMatched As Boolean
    'Dim passwordIgnoreCaseMatched As Boolean

    Public Sub clearfields()
        txtpw.Text = ""
        txtun.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnback.Click
        eTASStartForm.adminbackclicked()
    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Dim type As String = ""
        Dim name As String = ""
        Dim counter As Integer = 0
        'checkIgnoredCase()
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim commstring As String = "SELECT * FROM admintbl WHERE BINARY adminusername='" & txtun.Text.Replace("'", "''") & "' AND BINARY adminpassword='" & txtpw.Text.Replace("'", "''") & "'"
            Dim reader As MySqlDataReader
            comm.CommandText = commstring
            comm.Connection = conn
            reader = comm.ExecuteReader



            While (reader.Read)
                counter = counter + 1
                If Not counter = 0 Then
                    type = reader("admintype").ToString
                    name = reader("adminfirstname").ToString & " " & reader("adminmiddlename").ToString & " " & reader("adminlastname").ToString
                    idOfAdmin = reader("adminid").ToString
                End If
            End While

            If counter = 1 Then
                ContainerForm.changeConnstring(eTASStartForm.departmentSelected)
                ContainerForm.Show()
                eTASStartForm.Hide()
            ElseIf counter > 1 Then
                MsgBox("Account Overload")
            Else
                MsgBox("Please check your usename and password")
                'If usernameIgnoreCaseMatched Then
                '    Label4.Visible = True
                'Else
                '    Label4.Visible = False
                'End If
                'If passwordIgnoreCaseMatched Then
                '    Label5.Visible = True
                'Else
                '    Label5.Visible = False
                'End If
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
            If counter = 1 Then
                adminloggedin(name, type, txtun.Text, txtpw.Text)
            End If
        End Try


    End Sub

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

    Public Sub hasNotif(adminid As String)
        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        comm.Connection = conn
        comm.CommandText = "SELECT * FROM adminnotiftbl WHERE adminid = " & adminid
        comm.CommandType = CommandType.Text

        Dim reader As MySqlDataReader
        reader = comm.ExecuteReader

        Dim detected As Boolean = False

        While reader.Read
            detected = True
        End While
        conn.Close()
        If detected = True Then
            Select Case (MsgBox("Master admin has edited your account information", vbOKOnly))
                Case vbOK
                    conn.Open()
                    comm.Connection = conn
                    comm.CommandText = "DELETE FROM adminnotiftbl WHERE adminid = " & adminid
                    comm.CommandType = CommandType.Text
                    comm.ExecuteNonQuery()
                    conn.Close()
                Case Else

            End Select


        End If



    End Sub

    'Public Sub checkIgnoredCase()
    '    '______________________________________
    '    Dim counter As Integer = 0
    '    Try
    '        conn.ConnectionString = connstring
    '        conn.Open()

    '        Dim comm As New MySqlCommand
    '        Dim commstring As String = "SELECT * FROM admintbl WHERE adminusername='" & txtun.Text & "'"
    '        Dim reader As MySqlDataReader
    '        comm.CommandText = commstring
    '        comm.Connection = conn
    '        reader = comm.ExecuteReader



    '        While (reader.Read)
    '            counter = counter + 1
    '        End While

    '        If counter >= 1 Then
    '            usernameIgnoreCaseMatched = True
    '        Else
    '            usernameIgnoreCaseMatched = False
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    Finally
    '        conn.Close()
    '    End Try

    '    '________________________________________
    '    counter = 0
    '    Try
    '        conn.ConnectionString = connstring
    '        conn.Open()

    '        Dim comm As New MySqlCommand
    '        Dim commstring As String = "SELECT * FROM admintbl WHERE adminpassword='" & txtpw.Text & "'"
    '        Dim reader As MySqlDataReader
    '        comm.CommandText = commstring
    '        comm.Connection = conn
    '        reader = comm.ExecuteReader



    '        While (reader.Read)
    '            counter = counter + 1
    '        End While

    '        If counter >= 1 Then
    '            passwordIgnoreCaseMatched = True
    '        Else
    '            passwordIgnoreCaseMatched = False
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    Finally
    '        conn.Close()
    '    End Try

    '    '_________________________________________
    'End Sub

    Public Sub adminloggedin(name As String, type As String, username As String, password As String)
        Dim id As String = getnewid()

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim commstring As String = "INSERT INTO logstbl(id,usertype,logname,loggedin) VALUES ('" & id & "','Admin','" & name & "',NOW())"
            comm.CommandText = commstring
            comm.Connection = conn
            comm.CommandType = CommandType.Text
            comm.ExecuteNonQuery()

            ContainerForm.Show()
            'ContainerForm.btnMaximize.PerformClick()
            ContainerForm.departmentSelected = eTASStartForm.departmentSelected 'idinagdag ko
            eTASStartForm.Hide()
            ContainerForm.loggedid = id
            ContainerForm.loggedtype = "Admin"
            ContainerForm.loggedname = name
            ContainerForm.admintype = type
            ContainerForm.adminusername = username
            ContainerForm.adminpassword = password

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
            hasNotif(idOfAdmin)
        End Try

    End Sub


    Function getnewid()

        Dim lastnum As String = 0

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim commstring As String = "SELECT * FROM logstbl"
            Dim reader As MySqlDataReader
            comm.CommandText = commstring
            comm.Connection = conn
            reader = comm.ExecuteReader



            While (reader.Read)
                lastnum = reader("id").ToString
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

        Return lastnum + 1

    End Function

    Private Sub txtpw_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpw.KeyPress
        If e.KeyChar = Chr(13) Then
            btnlogin.PerformClick()
        End If
    End Sub

End Class