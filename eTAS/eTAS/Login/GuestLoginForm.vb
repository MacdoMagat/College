Imports MySql.Data.MySqlClient

Public Class GuestLoginForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Dim invalidname As Boolean = False
    Dim invalidfirstname As Boolean = False

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

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click

        If txtfirstname.Text.Length = 1 Then
            Select Case MsgBox("Are you sure about your first name?", vbYesNo)
                Case vbYes
                Case vbNo : Exit Sub
                Case Else
            End Select
        End If

        If txtfirstname.Text = "" Then
            MsgBox("Please enter your first name")
            Exit Sub
        End If




        If txtname.Text.Length = 1 Then
            Select Case MsgBox("Are you sure about your last name?", vbYesNo)
                Case vbYes
                Case vbNo : Exit Sub
                Case Else
            End Select
        End If

        If txtname.Text.Length > 0 Then
            'If txtname.Text.Substring(txtname.Text.Length - 1, 1) = " " Then
            '    MsgBox("Space Na naman?")
            'End If
            While txtname.Text.Contains("  ")
                txtname.Text = txtname.Text.Replace("  ", " ")
            End While
            If txtname.Text.StartsWith(" ") Then
                txtname.Text = txtname.Text.Substring(1, txtname.Text.Length - 1)
            End If
            If txtname.Text.EndsWith(" ") Then
                txtname.Text = txtname.Text.Substring(0, txtname.Text.Length - 1)
            End If
        End If

        If txtfirstname.Text.Length > 0 Then
            'If txtname.Text.Substring(txtname.Text.Length - 1, 1) = " " Then
            '    MsgBox("Space Na naman?")
            'End If
            While txtfirstname.Text.Contains("  ")
                txtfirstname.Text = txtfirstname.Text.Replace("  ", " ")
            End While
            If txtfirstname.Text.StartsWith(" ") Then
                txtfirstname.Text = txtfirstname.Text.Substring(1, txtfirstname.Text.Length - 1)
            End If
            If txtfirstname.Text.EndsWith(" ") Then
                txtfirstname.Text = txtfirstname.Text.Substring(0, txtfirstname.Text.Length - 1)
            End If
        End If


        Dim tempstring As String
        tempstring = txtname.Text.Replace(" ", "")
        If tempstring.Length = 0 Then
            MsgBox("Please input your name")
            Exit Sub
        End If

        If invalidname Then
            MsgBox("Make sure your last name don't have symbols")
            Exit Sub
        End If

        If invalidfirstname Then
            MsgBox("Make sure your first name don't have symbols")
            Exit Sub
        End If

        If txtname.Text.Equals("") Then
            MsgBox("Please input your last name")
            Exit Sub
        End If

        'For i As Integer = 0 To 9
        '    If txtname.Text.Contains(i) Then
        '        MsgBox("You can't include number in names")
        '        Exit Sub
        '    End If
        'Next

        Dim id As String = getnewid()

        If id = 1 Then
            Exit Sub
        End If

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim name As String = txtfirstname.Text & " " & txtname.Text
            Dim comm As New MySqlCommand
            Dim commstring As String = "INSERT INTO logstbl(id,usertype,logname,loggedin) VALUES ('" & id & "','Guest','" & name & "',NOW())"
            comm.CommandText = commstring
            comm.Connection = conn
            comm.CommandType = CommandType.Text
            comm.ExecuteNonQuery()

            ContainerForm.changeConnstring(eTASStartForm.departmentSelected)
            ContainerForm.Show()
            ContainerForm.departmentSelected = eTASStartForm.departmentSelected 'idinagdag ko
            eTASStartForm.Hide()
            ContainerForm.loggedid = id
            ContainerForm.loggedtype = "Guest"
            ContainerForm.loggedname = txtfirstname.Text & " " & txtname.Text
            ContainerForm.UserIn("Guest")

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

    End Sub

    Public Sub clearfields()
        txtname.Text = ""
        txtfirstname.Text = ""
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        eTASStartForm.guestbackclicked()
    End Sub

    Function getnewid()

        Dim lastnum As String = 0

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim commstring As String = "SELECT * FROM logstbl ORDER BY id"
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

    Private Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged
        'If txtname.Text.Substring(txtname.Text.Length - 1, 1) = Asc(13) Then
        '    MsgBox("Enter")
        'End If

        If txtname.Text.Length > 0 Then
            If txtname.Text.EndsWith("  ") Then
                txtname.Text = txtname.Text.Substring(0, txtname.Text.Length - 1)
                txtname.SelectionStart = txtname.Text.Length
            End If
            If txtname.Text.StartsWith(" ") Then
                txtname.Text = txtname.Text.Substring(1, txtname.Text.Length - 1)
            End If
            If countdot(txtname.Text) > 1 Then
                txtname.Text = txtname.Text.Substring(0, txtname.Text.Length - 1)
                txtname.SelectionStart = txtname.Text.Length
            End If
        End If

        Try
            invalidname = Checktxtbox(txtname)
            If invalidname Then
                txtname.ForeColor = Color.Red
            Else
                txtname.ForeColor = Color.Black
            End If
            If txtfirstname.ForeColor = Color.Red Or txtname.ForeColor = Color.Red Then
                Label3.Visible = True
            Else
                Label3.Visible = False
            End If
        Catch ex As Exception
            MsgBox("May Error")
        End Try

    End Sub

    Public Function Checktxtbox(txtbx As TextBox) As Boolean
        Dim invalidchardetected As Boolean = False
        If txtbx.Text = "" Then
            Return invalidchardetected
            Exit Function
        End If
        For i As Integer = 0 To 255
            If i = 32 Or i = 46 Then
                i = i + 1
            End If
            If (i >= 65 And i <= 90) Then
                i = 91
            End If
            If (i >= 97 And i <= 122) Then
                i = 123
            End If
            If txtbx.Text.Contains(Chr(i)) Then
                'MsgBox("Detected")
                invalidchardetected = True
                Exit For
            End If
        Next
        Return invalidchardetected
    End Function

    Private Sub txtname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtname.KeyPress
        If e.KeyChar = Chr(13) Then
            btnlogin.PerformClick()
        End If
        'If e.KeyChar = Chr(27) Then
        '    btnback.PerformClick()
        'End If
    End Sub

    Public Function countdot(str As String) As Integer
        Dim count As Integer = 0
        For Each c As Char In str
            If c = "." Then
                count += 1
            End If
        Next
        Return count
    End Function

    Private Sub txtfirstname_TextChanged(sender As Object, e As EventArgs) Handles txtfirstname.TextChanged
        If txtfirstname.Text.Length > 0 Then
            If txtfirstname.Text.EndsWith("  ") Then
                txtfirstname.Text = txtfirstname.Text.Substring(0, txtfirstname.Text.Length - 1)
                txtfirstname.SelectionStart = txtfirstname.Text.Length
            End If
            If txtfirstname.Text.StartsWith(" ") Then
                txtfirstname.Text = txtfirstname.Text.Substring(1, txtfirstname.Text.Length - 1)
            End If
            If countdot(txtfirstname.Text) > 1 Then
                txtfirstname.Text = txtfirstname.Text.Substring(0, txtfirstname.Text.Length - 1)
                txtfirstname.SelectionStart = txtfirstname.Text.Length
            End If
        End If

        Try
            invalidfirstname = Checktxtbox(txtfirstname)
            If invalidfirstname Then
                txtfirstname.ForeColor = Color.Red
            Else
                txtfirstname.ForeColor = Color.Black
            End If
            If txtfirstname.ForeColor = Color.Red Or txtname.ForeColor = Color.Red Then
                Label3.Visible = True
            Else
                Label3.Visible = False
            End If
        Catch ex As Exception
            MsgBox("May Error")
        End Try
    End Sub

    Private Sub txtfirstname_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfirstname.KeyPress
        If e.KeyChar = Chr(13) Then
            btnlogin.PerformClick()
        End If
    End Sub

End Class