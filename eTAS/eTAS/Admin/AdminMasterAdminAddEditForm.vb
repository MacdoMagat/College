Imports MySql.Data.MySqlClient


Public Class AdminMasterAdminAddForm

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

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Dim id As String = ""
    Dim un As String = ""
    Public Sub addClicked()
        Me.lblTitle.Text = "Add New"
        Me.btnAction.Text = "Add"
        txtFirstName.Text = ""
        txtMiddleName.Text = ""
        txtLastName.Text = ""
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtConfirmPassword.Text = ""
        'INSERT INTO `admintbl`(`adminid`, `admintype`, `adminfirstname`, `adminmiddlename`, `adminlastname`, `adminusername`, `adminpassword`) VALUES ([value-1],[value-2],[value-3],[value-4],[value-5],[value-6],[value-7])
    End Sub

    Public Sub editClicked(adminid As String)
        Me.lblTitle.Text = "Edit"
        Me.btnAction.Text = "Save"

        id = adminid

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim commstring As String = "SELECT * FROM admintbl WHERE admintype = 'Normal' AND adminid=" & adminid
            Dim reader As MySqlDataReader
            comm.CommandText = commstring
            comm.Connection = conn
            reader = comm.ExecuteReader

            While (reader.Read)
                txtFirstName.Text = reader("adminfirstname").ToString
                txtMiddleName.Text = reader("adminmiddlename").ToString
                txtLastName.Text = reader("adminlastname").ToString
                txtUsername.Text = reader("adminusername").ToString
                txtPassword.Text = reader("adminpassword").ToString
                txtConfirmPassword.Text = reader("adminpassword").ToString
                un = reader("adminusername").ToString
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAction.Click
        If txtFirstName.Text = "" Then
            MsgBox("First Name must have a value")
            Exit Sub
        End If
        If txtMiddleName.Text = "" Then
            MsgBox("Middle Name must have a value")
            Exit Sub
        End If
        If txtLastName.Text = "" Then
            MsgBox("Last Name must have a value")
            Exit Sub
        End If
        If txtUsername.Text = "" Then
            MsgBox("Username must have a value")
            Exit Sub
        End If
        If txtPassword.Text = "" Then
            MsgBox("Password must have a value")
            Exit Sub
        End If

        If lengthChecker(txtFirstName.Text) = 0 Or txtFirstName.ForeColor = Color.Red Then
            MsgBox("Please check your first name")
            Exit Sub
        End If

        If lengthChecker(txtMiddleName.Text) = 0 Or txtMiddleName.ForeColor = Color.Red Then
            MsgBox("Please check your middle name")
            Exit Sub
        End If

        If lengthChecker(txtLastName.Text) = 0 Or txtLastName.ForeColor = Color.Red Then
            MsgBox("Please check your last name")
            Exit Sub
        End If

        Dim query As String = ""

        If btnAction.Text = "Add" Then
            If hasDuplicate(txtUsername.Text.Replace("'", "''")) Then
                MsgBox("Username already exists")
                Exit Sub
            End If
            ContainerForm.executeTaskQuery("Admin", "Added new admin (" & txtFirstName.Text.Replace("'", "''") & " " & txtMiddleName.Text.Replace("'", "''") & " " & txtLastName.Text.Replace("'", "''") & ")")
            query = "INSERT INTO `admintbl`(`admintype`, `adminfirstname`, `adminmiddlename`, `adminlastname`, `adminusername`, `adminpassword`) VALUES ('Normal','" & txtFirstName.Text.Replace("'", "''") & "','" & txtMiddleName.Text.Replace("'", "''") & "','" & txtLastName.Text.Replace("'", "''") & "','" & txtUsername.Text.Replace("'", "''") & "','" & txtPassword.Text.Replace("'", "''") & "')"
        ElseIf btnAction.Text = "Save" Then
            If Not un.Equals(txtUsername.Text) Then
                If hasDuplicate(txtUsername.Text.Replace("'", "''")) Then
                    MsgBox("Username already exists")
                    Exit Sub
                End If
            End If
            ContainerForm.executeTaskQuery("Admin", "Edited an admin (" & txtFirstName.Text.Replace("'", "''") & " " & txtMiddleName.Text.Replace("'", "''") & " " & txtLastName.Text.Replace("'", "''") & ")")
            query = "UPDATE `admintbl` Set `adminfirstname`='" & txtFirstName.Text.Replace("'", "''") & "',`adminmiddlename`='" & txtMiddleName.Text.Replace("'", "''") & "',`adminlastname`='" & txtLastName.Text.Replace("'", "''") & "',`adminusername`='" & txtUsername.Text.Replace("'", "''") & "',`adminpassword`='" & txtPassword.Text.Replace("'", "''") & "' WHERE adminid = " & id
            query = query & "; INSERT INTO `adminnotiftbl`(`adminid`) VALUES (" & id & ")"
        End If

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            comm.CommandText = query
            comm.Connection = conn
            comm.ExecuteNonQuery()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
            ContainerForm.masteradmin.RefreshDataGrid()
        End Try


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

    Public Function hasDuplicate(username As String) As Boolean
        Dim detected As Boolean = False
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim commstring As String = "SELECT * FROM admintbl WHERE adminusername = '" & username & "'"
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