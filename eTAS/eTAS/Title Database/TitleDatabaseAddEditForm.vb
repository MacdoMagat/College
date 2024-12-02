Imports MySql.Data.MySqlClient

Public Class TitleDatabaseAddEditForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Dim edit As Boolean
    Dim add As Boolean
    Dim tempTitle As String

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


    Public Sub addClicked()
        refreshCboStatus()
        Label1.Text = "Add Title"
        btnAction.Text = "Add"
        txtTitle.Text = ""
        btnRemoveResearcher.Enabled = False

        cboYear.Items.Clear()
        Dim year As Integer = Date.Now.Year.ToString
        While year >= 2002
            cboYear.Items.Add(year)
            year -= 1
        End While
        cboYear.SelectedIndex = 0

        FlowLayoutPanel1.Controls.Clear()

        Dim txtbx As New TextBox
        txtbx.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        txtbx.Width = 361
        txtbx.Height = 27
        txtbx.Name = 0
        AddHandler txtbx.TextChanged, AddressOf check
        FlowLayoutPanel1.Controls.Add(txtbx)

        edit = False
        add = True
    End Sub

    Public Sub editClicked(thesistitle As String)
        edit = True
        add = False
        tempTitle = thesistitle
        btnAction.Text = "Save"
        Label1.Text = "Edit Title"

        refreshCboStatus()

        cboYear.Items.Clear()
        Dim year As Integer = Date.Now.Year.ToString
        While year >= 2002
            cboYear.Items.Add(year)
            year -= 1
        End While
        'cboYear.SelectedIndex = 0

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim reader As MySqlDataReader

        Dim query As String = "SELECT * FROM `titletbl` LEFT JOIN titlestatustbl ON titletbl.titlestatusid = titlestatustbl.titlestatusid WHERE titletbl.title = '" & thesistitle.Replace("'", "''") & "'"
        comm.CommandText = query
        comm.Connection = conn
        reader = comm.ExecuteReader

        Dim researchers() As String


        While (reader.Read)
            txtTitle.Text = reader("title").ToString
            cboStatus.Text = reader("statusname").ToString
            cboYear.Text = reader("yearSubmitted").ToString

            'MsgBox(reader("yearSubmitted").ToString)
            researchers = Split(reader("researchers").ToString, "|")
        End While



        FlowLayoutPanel1.Controls.Clear()
        For i As Integer = 0 To researchers.Length - 1
            Dim txtbx As New TextBox
            txtbx.Font = New Font("Century Gothic", 12, FontStyle.Regular)
            txtbx.Width = 361
            txtbx.Height = 27
            txtbx.Text = researchers(i).ToString
            txtbx.Name = i
            AddHandler txtbx.TextChanged, AddressOf check
            FlowLayoutPanel1.Controls.Add(txtbx)
        Next

        conn.Close()

        If txtboxCount() > 1 Then
            btnRemoveResearcher.Enabled = True
        Else
            btnRemoveResearcher.Enabled = False
        End If

    End Sub

    Public Sub refreshCboStatus()
        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim reader As MySqlDataReader

        Dim query As String = "SELECT * FROM titlestatustbl"
        comm.CommandText = query
        comm.Connection = conn
        reader = comm.ExecuteReader

        cboStatus.Items.Clear()

        While (reader.Read)
            cboStatus.Items.Add(reader("statusname").ToString)
        End While

        conn.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Public Function alreadyExisted(title As String) As Boolean
        Dim detected As Boolean = False

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim reader As MySqlDataReader

        Dim query As String = "SELECT * FROM `titletbl` WHERE title='" & title & "'"
        comm.CommandText = query
        comm.Connection = conn
        reader = comm.ExecuteReader

        While (reader.Read)
            detected = True
        End While

        conn.Close()

        Return detected
    End Function

    Public Function getStatusID(statusname As String) As Integer
        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim reader As MySqlDataReader

        Dim query As String = "SELECT * FROM titlestatustbl WHERE statusname = '" & statusname & "'"
        comm.CommandText = query
        comm.Connection = conn
        reader = comm.ExecuteReader

        Dim index As Integer = 0

        While (reader.Read)
            index = CInt(reader("titlestatusid").ToString)
        End While

        conn.Close()

        Return index
    End Function

    Private Sub btnAction_Click(sender As Object, e As EventArgs) Handles btnAction.Click
        Dim query As String = ""
        Dim statusindex As Integer = getStatusID(cboStatus.Text)

        If edit Then

            If strLen(txtTitle.Text) = 0 Then
                MsgBox("Please insert a title")
                Exit Sub
            End If

            If cboStatus.Text = "" Then
                MsgBox("Please select a status")
                Exit Sub
            End If

            If Not txtTitle.Text = tempTitle Then
                If alreadyExisted(txtTitle.Text.Replace("'", "''")) Then
                    MsgBox("Title already exists")
                    Exit Sub
                End If
            End If

            For Each txtbox As TextBox In FlowLayoutPanel1.Controls
                If strLen(txtbox.Text) = 0 Then
                    MsgBox("Please don't leave researcher name blank")
                    Exit Sub
                End If
                If txtbox.ForeColor = Color.Red Then
                    MsgBox("Please check the fields in researchers")
                    Exit Sub
                End If
            Next

            Dim researcherlist As New List(Of String)

            For i As Integer = 0 To txtboxCount() - 1
                researcherlist.Add(FlowLayoutPanel1.Controls.Item(i).Text)
            Next
            Dim researchers() As String = researcherlist.ToArray
            Dim researcherstodatabase As String = Join(researchers, "|")
            ContainerForm.executeTaskQuery("Title Database", "Edited title (" & txtTitle.Text.Replace("'", "''") & ")")
            query = "UPDATE `titletbl` SET `title`='" & txtTitle.Text.Replace("'", "''") & "',`titlestatusid`=" & statusindex & ",yearSubmitted=" & cboYear.Text & ",researchers = '" & researcherstodatabase.Replace("'", "''") & "' WHERE title='" & tempTitle.Replace("'", "''") & "'"
            ContainerForm.executeTaskQuery("Title Database", "Edited " & txtTitle.Text)
        ElseIf add Then



            If strLen(txtTitle.Text) = 0 Then
                MsgBox("Please insert a title")
                Exit Sub
            End If

            If cboStatus.Text = "" Then
                MsgBox("Please select a status")
                Exit Sub
            End If

            If alreadyExisted(txtTitle.Text.Replace("'", "''")) Then
                MsgBox("Title already exists")
                Exit Sub
            End If

            For Each txtbox As TextBox In FlowLayoutPanel1.Controls
                If strLen(txtbox.Text) = 0 Then
                    MsgBox("Please don't leave researcher name blank")
                    Exit Sub
                End If
                If txtbox.ForeColor = Color.Red Then
                    MsgBox("Please check the fields in researchers")
                    Exit Sub
                End If
            Next


            Dim researcherlist As New List(Of String)

            For i As Integer = 0 To txtboxCount() - 1
                researcherlist.Add(FlowLayoutPanel1.Controls.Item(i).Text)
            Next
            Dim researchers() As String = researcherlist.ToArray
            Dim researcherstodatabase As String = Join(researchers, "|")
            ContainerForm.executeTaskQuery("Title Database", "Added title (" & txtTitle.Text.Replace("'", "''") & ")")
            query = "INSERT INTO `titletbl`(`title`, `titlestatusid`,yearSubmitted,researchers) VALUES ('" & txtTitle.Text.Replace("'", "''") & "'," & statusindex & "," & cboYear.Text & ",'" & researcherstodatabase.Replace("'", "''") & "')"
            ContainerForm.executeTaskQuery("Title Database", "Added " & txtTitle.Text)
        End If

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            comm.CommandText = query
            comm.Connection = conn
            comm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
            ContainerForm.titledatabase.refreshThesisTitles(ContainerForm.titledatabase.txtSearch.Text, ContainerForm.titledatabase.chkApproved.Checked, ContainerForm.titledatabase.chkDisapproved.Checked, ContainerForm.titledatabase.chkFinished.Checked)
            Me.Close()
        End Try

    End Sub

    Public Function txtboxCount() As Integer
        Dim counter As Integer = 0
        For Each box As TextBox In FlowLayoutPanel1.Controls.OfType(Of TextBox)
            counter += 1
        Next
        Return counter
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAddResearcher.Click
        'MsgBox(txtboxCount)
        If txtboxCount() < 5 Then
            Dim txtbx As New TextBox
            txtbx.Font = New Font("Century Gothic", 12, FontStyle.Regular)
            txtbx.Width = 361
            txtbx.Height = 27
            txtbx.Name = txtboxCount()
            AddHandler txtbx.TextChanged, AddressOf check
            FlowLayoutPanel1.Controls.Add(txtbx)
            btnRemoveResearcher.Enabled = True
            If txtboxCount() = 5 Then
                btnAddResearcher.Enabled = False
            End If
        Else
            btnAddResearcher.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnRemoveResearcher.Click
        'MsgBox(txtboxCount)
        If txtboxCount() > 1 Then
            FlowLayoutPanel1.Controls.RemoveAt(txtboxCount() - 1)
            btnAddResearcher.Enabled = True
            If txtboxCount() = 1 Then
                btnRemoveResearcher.Enabled = False
            End If
        Else
            btnRemoveResearcher.Enabled = False
        End If
    End Sub

    Public Function strLen(stringToCount As String) As Integer
        Dim tempString As String
        tempString = stringToCount
        While tempString.EndsWith(" ") Or tempString.EndsWith(".")
            tempString = tempString.Substring(0, tempString.Length - 1)
        End While
        While tempString.StartsWith(" ") Or tempString.StartsWith(".")
            tempString = tempString.Substring(1, tempString.Length - 1)
        End While
        Return tempString.Length
    End Function


    Public Sub check(sender As Object, e As EventArgs)
        Dim txtbx As TextBox = DirectCast(sender, TextBox)
        'MsgBox(txtbx.Name)

        Dim controlindex As Integer = CInt(txtbx.Name)
        'MsgBox(controlindex.ToString)
        'MsgBox(controlindex)
        If FlowLayoutPanel1.Controls.Item(controlindex).Text.Length > 0 Then
            If FlowLayoutPanel1.Controls.Item(controlindex).Text.Contains("  ") Then
                'FlowLayoutPanel1.Controls.Item(controlindex).Text = FlowLayoutPanel1.Controls.Item(controlindex).Text.Substring(0, FlowLayoutPanel1.Controls.Item(controlindex).Text.Length - 1)
                FlowLayoutPanel1.Controls.Item(controlindex).Text = FlowLayoutPanel1.Controls.Item(controlindex).Text.Replace("  ", " ")
                'FlowLayoutPanel1.Controls.Item(controlindex).Refresh()
                'FlowLayoutPanel1.Controls.Item(controlindex).Select()
                CType(FlowLayoutPanel1.Controls.Item(controlindex), TextBox).SelectionStart = FlowLayoutPanel1.Controls.Item(controlindex).Text.Length
            End If
            'For Each cont As Control In FlowLayoutPanel1.Controls
            '    cont.Select()
            'Next
            If FlowLayoutPanel1.Controls.Item(controlindex).Text.StartsWith(" ") Then
                FlowLayoutPanel1.Controls.Item(controlindex).Text = FlowLayoutPanel1.Controls.Item(controlindex).Text.Substring(1, FlowLayoutPanel1.Controls.Item(controlindex).Text.Length - 1)
            End If
        End If
        If countdot(txtbx.Text) > 1 Then
            FlowLayoutPanel1.Controls.Item(controlindex).Text = FlowLayoutPanel1.Controls.Item(controlindex).Text.Substring(0, FlowLayoutPanel1.Controls.Item(controlindex).Text.Length - 1)
            CType(FlowLayoutPanel1.Controls.Item(controlindex), TextBox).SelectionStart = FlowLayoutPanel1.Controls.Item(controlindex).Text.Length
        End If

        If Checktxtbox(txtbx) Then
            FlowLayoutPanel1.Controls.Item(controlindex).ForeColor = Color.Red
        Else
            FlowLayoutPanel1.Controls.Item(controlindex).ForeColor = Color.Black
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