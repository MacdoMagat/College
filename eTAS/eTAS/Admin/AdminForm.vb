Imports MySql.Data.MySqlClient

Public Class AdminForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"

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

    Public Sub loadfields()
        txtFirstName.Enabled = False
        txtMiddleName.Enabled = False
        txtLastName.Enabled = False
        txtun.Enabled = False
        txtpw.Enabled = False
        btnChangeFirst.Text = "Change"
        btnChangeMiddle.Text = "Change"
        btnChangeLast.Text = "Change"
        btnChangeUsername.Text = "Change"
        btnChangePassword.Text = "Change"

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim commstring As String = "SELECT * FROM admintbl WHERE adminusername = '" & ContainerForm.adminusername.Replace("'", "''") & "'"
            Dim reader As MySqlDataReader
            comm.CommandText = commstring
            comm.Connection = conn
            reader = comm.ExecuteReader

            While (reader.Read)
                txtFirstName.Text = reader("adminfirstname").ToString
                txtMiddleName.Text = reader("adminmiddlename").ToString
                txtLastName.Text = reader("adminlastname").ToString
                txtun.Text = reader("adminusername").ToString
                txtpw.Text = reader("adminpassword").ToString
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnChangePassword.Click
        AdminChangePWForm.changeConnstring(ContainerForm.departmentSelected)
        AdminChangePWForm.resetfields()
        AdminChangePWForm.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnChangeUsername.Click
        AdminChangeUNForm.changeConnstring(ContainerForm.departmentSelected)
        AdminChangeUNForm.resetfields()
        AdminChangeUNForm.ShowDialog()
    End Sub

    Private Sub btnChangeFirst_Click(sender As Object, e As EventArgs) Handles btnChangeFirst.Click
        If btnChangeFirst.Text = "Change" Then
            btnChangeFirst.Text = "Save"
            txtFirstName.Enabled = True

            btnChangeMiddle.Enabled = False
            btnChangeLast.Enabled = False
            btnChangePassword.Enabled = False
            btnChangeUsername.Enabled = False
        ElseIf btnChangeFirst.Text = "Save" Then
            If lengthChecker(txtFirstName.Text) = 0 Or txtFirstName.ForeColor = Color.Red Then
                MsgBox("Please check your first name")
                Exit Sub
            End If
            Try
                conn.ConnectionString = connstring
                conn.Open()

                Dim comm As New MySqlCommand
                Dim commstring As String = "Update `admintbl` Set `adminfirstname`='" & txtFirstName.Text.Replace("'", "''") & "' WHERE adminusername = '" & ContainerForm.adminusername.Replace("'", "''") & "'"
                comm.CommandText = commstring
                comm.Connection = conn
                comm.CommandType = CommandType.Text
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()

                btnChangeMiddle.Enabled = True
                btnChangeLast.Enabled = True
                btnChangePassword.Enabled = True
                btnChangeUsername.Enabled = True
                ContainerForm.admin.loadfields()
            End Try
        End If
    End Sub

    Public Function lengthChecker(text As String) As Integer
        Dim a As String = text
        While (a.EndsWith(" ") Or a.EndsWith("."))
            a = a.Substring(0, a.Length - 1)
        End While
        While (a.StartsWith(" ") Or a.StartsWith("."))
            a = a.Substring(1, a.Length - 1)
        End While
        Return a.Length
    End Function

    Private Sub btnChangeMiddle_Click(sender As Object, e As EventArgs) Handles btnChangeMiddle.Click
        If btnChangeMiddle.Text = "Change" Then
            btnChangeMiddle.Text = "Save"
            txtMiddleName.Enabled = True

            btnChangeFirst.Enabled = False
            btnChangeLast.Enabled = False
            btnChangePassword.Enabled = False
            btnChangeUsername.Enabled = False
        ElseIf btnChangeMiddle.Text = "Save" Then
            If lengthChecker(txtMiddleName.Text) = 0 Or txtMiddleName.ForeColor = Color.Red Then
                MsgBox("Please check your middle name")
                Exit Sub
            End If
            Try
                conn.ConnectionString = connstring
                conn.Open()

                Dim comm As New MySqlCommand
                Dim commstring As String = "Update `admintbl` Set `adminmiddlename`='" & txtMiddleName.Text.Replace("'", "''") & "' WHERE adminusername = '" & ContainerForm.adminusername.Replace("'", "''") & "'"
                comm.CommandText = commstring
                comm.Connection = conn
                comm.CommandType = CommandType.Text
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
                btnChangeFirst.Enabled = True
                btnChangeLast.Enabled = True
                btnChangePassword.Enabled = True
                btnChangeUsername.Enabled = True
                ContainerForm.admin.loadfields()
            End Try
        End If
    End Sub

    Private Sub btnChangeLast_Click(sender As Object, e As EventArgs) Handles btnChangeLast.Click
        If btnChangeLast.Text = "Change" Then
            btnChangeLast.Text = "Save"
            txtLastName.Enabled = True

            btnChangeFirst.Enabled = False
            btnChangeMiddle.Enabled = False
            btnChangePassword.Enabled = False
            btnChangeUsername.Enabled = False
        ElseIf btnChangeLast.Text = "Save" Then
            If lengthChecker(txtLastName.Text) = 0 Or txtLastName.ForeColor = Color.Red Then
                MsgBox("Please check your last name")
                Exit Sub
            End If
            Try
                conn.ConnectionString = connstring
                conn.Open()

                Dim comm As New MySqlCommand
                Dim commstring As String = "Update `admintbl` Set `adminlastname`='" & txtLastName.Text.Replace("'", "''") & "' WHERE adminusername = '" & ContainerForm.adminusername.Replace("'", "''") & "'"
                comm.CommandText = commstring
                comm.Connection = conn
                comm.CommandType = CommandType.Text
                comm.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                conn.Close()
                btnChangeFirst.Enabled = True
                btnChangeMiddle.Enabled = True
                btnChangePassword.Enabled = True
                btnChangeUsername.Enabled = True
                ContainerForm.admin.loadfields()
            End Try
        End If
    End Sub


    Public Sub check(sender As Object, e As EventArgs) Handles txtFirstName.TextChanged, txtMiddleName.TextChanged, txtLastName.TextChanged
        Dim txtbx As TextBox = DirectCast(sender, TextBox)
        'MsgBox(txtbx.Name)

        'MsgBox(controlindex)
        If txtbx.Text.Length > 0 Then
            If txtbx.Text.Contains("  ") Then
                'txtbx.Text = txtbx.Text.Substring(0, txtbx.Text.Length - 1)
                txtbx.Text = txtbx.Text.Replace("  ", " ")
                'txtbx.Refresh()
                'txtbx.Select()
                CType(txtbx, TextBox).SelectionStart = txtbx.Text.Length
            End If
            'For Each cont As Control In FlowLayoutPanel1.Controls
            '    cont.Select()
            'Next
            If txtbx.Text.StartsWith(" ") Then
                txtbx.Text = txtbx.Text.Substring(1, txtbx.Text.Length - 1)
            End If
        End If
        If countdot(txtbx.Text) > 1 Then
            txtbx.Text = txtbx.Text.Substring(0, txtbx.Text.Length - 1)
            CType(txtbx, TextBox).SelectionStart = txtbx.Text.Length
        End If

        If Checktxtbox(txtbx) Then
            txtbx.ForeColor = Color.Red
        Else
            txtbx.ForeColor = Color.Black
        End If
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

End Class