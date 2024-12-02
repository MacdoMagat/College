Imports MySql.Data.MySqlClient

Public Class ViewThesisEditForm
    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Dim initialname As String = ""
    Dim id As String = ""

    'Private Sub ViewThesisEditForm_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    rdoNo.Checked = True

    '    Dim year As Integer = Date.Now.Year.ToString
    '    While year >= 2002
    '        cboYear.Items.Add(year)
    '        year -= 1
    '    End While
    '    cboYear.SelectedIndex = 0
    '    'cboYear.Text = "2007"
    'End Sub

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


    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub rdoYes_CheckedChanged_1(sender As Object, e As EventArgs) Handles rdoYes.CheckedChanged
        If rdoYes.Checked Then
            cboCategory.Enabled = True
            cboYear.Enabled = True
        Else
            cboCategory.Enabled = False
            cboYear.Enabled = False
        End If
    End Sub

    Private Sub rdoNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNo.CheckedChanged
        If rdoNo.Checked Then
            cboCategory.Enabled = False
            cboYear.Enabled = False
        Else
            cboCategory.Enabled = True
            cboYear.Enabled = True
        End If
    End Sub

    Public Sub formload(selectedid As Integer, initialtitle As String)
        initialname = initialtitle
        id = selectedid

        If Not ContainerForm.departmentSelected = "IT" Then
            Label2.Text = "Category"
        End If

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.ConnectionString = connstring

        rdoNo.Checked = True
        FlowLayoutPanel1.Controls.Clear()

        Dim year As Integer = Date.Now.Year.ToString
        While year >= 2002
            cboYear.Items.Add(year)
            year -= 1
        End While
        cboYear.SelectedIndex = 0

        refreshcboplatform()
        refreshcbocategory()
        loaddetails(selectedid)

        If isTopThesis(selectedid) Then
            rdoYes.Checked = True
            loadtopthesisdetails(selectedid)
        Else
            rdoNo.Checked = True
        End If

        'SELECT * FROM topthesistbl LEFT JOIN thesistbl ON topthesistbl.thesisid = thesistbl.thesisid LEFT JOIN topthesiscategorytbl ON topthesistbl.topthesiscategoryid = topthesiscategorytbl.topthesiscategoryid WHERE thesistbl.thesisid = 1



    End Sub

    Public Sub loadtopthesisdetails(selectedid As Integer)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM topthesistbl LEFT JOIN thesistbl ON topthesistbl.thesisid = thesistbl.thesisid LEFT JOIN topthesiscategorytbl ON topthesistbl.topthesiscategoryid = topthesiscategorytbl.topthesiscategoryid WHERE thesistbl.thesisid = " & selectedid
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        While reader.Read
            cboCategory.Text = reader("topthesiscategoryname").ToString
            cboYear.Text = reader("yeartopped").ToString
        End While

        conn.Close()
    End Sub

    Public Function isTopThesis(selectedid) As Boolean
        'conn.ConnectionString = connstring

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM topthesistbl WHERE thesisid = " & selectedid
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        Dim counter As Integer = 0
        While reader.Read
            counter += 1
        End While

        If counter = 0 Then
            Return False
        Else
            Return True
        End If
        conn.Close()
    End Function

    Public Sub loaddetails(selectedid As Integer)
        'conn.ConnectionString = connstring
        'My.Computer.FileSystem.RenameFile(Application.StartupPath.ToString & "\Documents\" & initialname & ".jpg", txtThesisTitle.Text & ".jpg")
        'My.Computer.FileSystem.CopyFile(Application.StartupPath.ToString & "\Documents\" & initialname & ".jpg", Application.StartupPath.ToString & "\Others\tempImage.jpg", True)
        'ContainerForm.retrievethesisview.PictureBox1.Image = Image.FromFile(Application.StartupPath.ToString & "\Others\tempImage.jpg")

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM thesistbl LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid WHERE thesisid = " & selectedid
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        Dim researchers() As String
        'Dim datesubmitted As New Date

        While (reader.Read)
            txtThesisTitle.Text = reader("thesistitle").ToString
            cboPlatform.Text = reader("platformname").ToString
            'datesubmitted = reader("dateofsubmission").ToString
            dtpDateSubmitted.Value = reader("dateofsubmission").ToString
            dtpDatePublished.Value = reader("datepublished").ToString
            'thesispath = reader("thesispath").ToString
            'path = reader("thesispath").ToString & ".pdf"
            'previewPDF.src = path
            'Label9.Text = reader("thesisid").ToString
            'Label10.Text = reader("thesistitle").ToString
            'Label11.Text = reader("platformname").ToString
            'Label12.Text = reader("platformname").ToString
            researchers = Split(reader("researchername").ToString, "|")
            'Label14.Text = reader("dateofsubmission").ToString
        End While
        'Label13.Text = ""
        For i As Integer = 0 To researchers.Length - 1
            'Label13.Text = Label13.Text & researchers(i).ToString & vbNewLine
            Dim a As New TextBox
            'a.Size = New Size(310, 20)
            a.Name = i.ToString + 1
            a.Text = researchers(i).ToString
            a.Width = 345
            a.Font = New Font("Century Gothic", 12)
            AddHandler a.TextChanged, AddressOf check
            'AddHandler a.TextChanged, AddressOf check
            FlowLayoutPanel1.Controls.Add(a)
        Next
        conn.Close()
    End Sub

    Public Sub refreshcbocategory()
        'SELECT * FROM `topthesiscategorytbl`
        cboCategory.Items.Clear()

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM `topthesiscategorytbl"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        While (reader.Read)
            cboCategory.Items.Add(reader("topthesiscategoryname").ToString)
        End While

        conn.Close()
    End Sub

    Public Sub refreshcboplatform()
        cboPlatform.Items.Clear()

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        'conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM `platformtbl`"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        While (reader.Read)
            cboPlatform.Items.Add(reader("platformname").ToString)
        End While

        conn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim titleChanged As Boolean = False
        If Not (initialname.Equals(txtThesisTitle.Text)) Then
            titleChanged = True
            If hasDuplicate(txtThesisTitle.Text.Replace("'", "''")) Then
                MsgBox("A duplicate in title has been detected")
                Exit Sub
            End If
        End If
        If txtThesisTitle.Text = "" Then
            MsgBox("Please Enter Thesis Title")
            Exit Sub
        End If
        If dtpDateSubmitted.Value > Date.Now Then
            MsgBox("The submission date you have selected is set on the future")
            Exit Sub
        End If

        If dtpDatePublished.Value > Date.Now Then
            MsgBox("The publish date you have selected is set on the future")
            Exit Sub
        End If

        If rdoYes.Checked = True Then
            If isOccupied(cboYear.Text, cboCategory.Text) Then
                Select Case MsgBox("This category and year is occupied by another thesis!" & vbNewLine & "Title: " & getAffectedTopThesis(cboYear.Text, cboCategory.Text) & vbNewLine & "Do you want to replace it?", vbYesNo)
                    Case vbYes
                    Case vbNo : Exit Sub
                    Case Else
                End Select
            End If
        End If

        Dim indexx As Integer = 0
        Dim indexy As Integer = 0
        For Each cont As Control In FlowLayoutPanel1.Controls
            indexy = indexx + 1
            While (indexy <= FlowLayoutPanel1.Controls.Count - 1)
                If cont.Text.Equals(FlowLayoutPanel1.Controls.Item(indexy).Text) Then
                    MsgBox("A duplicate in researchers' name has been detected.")
                    Exit Sub
                End If
                indexy += 1
            End While
            indexx += 1
        Next

        For Each txtbx As TextBox In FlowLayoutPanel1.Controls.OfType(Of TextBox)
            If txtbx.ForeColor = Color.Red Then
                MsgBox("Please check the researchers name")
                Exit Sub
            End If
        Next

        'This part is for SQL
        Dim researcherlist As New List(Of String)

        For i As Integer = 0 To FlowLayoutPanel1.Controls.Count - 1
            researcherlist.Add(FlowLayoutPanel1.Controls.Item(i).Text)
        Next
        Dim researchers() As String = researcherlist.ToArray
        Dim researcherstodatabase As String = Join(researchers, "|")

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If



        Dim comm As New MySqlCommand
        Dim commstring As String = "UPDATE `thesistbl` SET `thesistitle`='" & txtThesisTitle.Text.Replace("'", "''") & "',`platformid`=" & getplatformid(cboPlatform.Text) & ",`researchername`='" & researcherstodatabase & "',`dateofsubmission`='" & dtpDateSubmitted.Value.ToString("yyyy-MM-dd") & "',`datepublished`='" & dtpDatePublished.Value.ToString("yyyy-MM-dd") & "'"
        If titleChanged Then
            Dim tempthesispath As String = Application.StartupPath.ToString & "\Documents\" & txtThesisTitle.Text.Replace("'", "''")
            Dim thesispath As String = tempthesispath.Replace("\", "\\")
            commstring += " ,thesispath = '" & thesispath & "'"
        End If
        commstring += " WHERE thesisid=" & id & ";"

        If rdoNo.Checked = True Then
            commstring += "DELETE FROM `topthesistbl` WHERE thesisid = " & id
        ElseIf rdoYes.Checked = True Then
            If isOccupied(cboYear.Text, cboCategory.Text) Then
                commstring += "DELETE FROM `topthesistbl` WHERE thesisid = " & id & ";"
                commstring += "UPDATE `topthesistbl` SET thesisid = " & id & " WHERE topthesiscategoryid = " & getcategoryid(cboCategory.Text) & " AND yeartopped = " & cboYear.Text
            Else
                commstring += "DELETE FROM `topthesistbl` WHERE thesisid = " & id & ";"
                commstring += "INSERT INTO topthesistbl (thesisid,topthesiscategoryid,yeartopped) VALUES (" & id & "," & getcategoryid(cboCategory.Text) & "," & cboYear.Text & ")"
            End If
        End If


        'Clipboard.SetText(commstring)
        'MsgBox(commstring)

        conn.ConnectionString = connstring
        conn.Open()
        comm.CommandText = commstring
        comm.Connection = conn
        comm.CommandType = CommandType.Text
        comm.ExecuteNonQuery()

        conn.Close()

        If titleChanged Then
            'txtThesisTitle.Text
            'ContainerForm.Panel1.Controls.Clear()
            'ContainerForm.retrievethesisview.PictureBox1 = Nothing
            For Each con As FlowLayoutPanel In ContainerForm.topthesis.flpMain.Controls.OfType(Of FlowLayoutPanel)
                For Each cont As TableLayoutPanel In con.Controls.OfType(Of TableLayoutPanel)
                    For Each contr As PictureBox In cont.Controls.OfType(Of PictureBox)
                        contr.Image.Dispose()
                    Next
                Next
            Next
            ContainerForm.retrievethesisview.PictureBox1.Image.Dispose()
            GC.Collect()
            My.Computer.FileSystem.RenameFile(Application.StartupPath.ToString & "\Documents\" & initialname & ".jpg", txtThesisTitle.Text & ".jpg")
            'ContainerForm.retrievethesisview.PictureBox1.Image = Image.FromFile(Application.StartupPath.ToString & "\Others\NoImage.jpg")
            'ContainerForm.retrievethesisview.previewPDF.LoadFile("none")
            ContainerForm.retrievethesisview.previewPDF.src = Application.StartupPath.ToString & "\Others\NoFileSelected.pdf"
            My.Computer.FileSystem.RenameFile(Application.StartupPath.ToString & "\Documents\" & initialname & ".docx", txtThesisTitle.Text & ".docx")

            My.Computer.FileSystem.RenameFile(Application.StartupPath.ToString & "\Documents\" & initialname & ".pdf", txtThesisTitle.Text & ".pdf")

            'ContainerForm.Panel1.Controls.Add(ContainerForm.retrievethesisview)
            'ContainerForm.retrievethesisview.Show()
        End If

        ContainerForm.executeTaskQuery("View Thesis", "Edited the thesis (" & txtThesisTitle.Text & ")")

        ContainerForm.retrievethesisview.viewthesis(id)
        Me.Close()

    End Sub

    Public Function hasDuplicate(title As String) As Boolean
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.ConnectionString = connstring
        conn.Open()

        Dim detected As Boolean = False

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM thesistbl WHERE thesistitle='" & title & "'"
        'SELECT * FROM thesistbl LEFT JOIN categorytbl ON thesistbl.categoryid = categorytbl.categoryid LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        Dim counter As Integer = 0
        While (reader.Read)
            counter += 1
            'Dim testarray() As String = Split(reader("researchername").ToString, "|")
            'Dim researchers As String = Join(testarray, ", ")
            'DataGridView1.Rows.Add(reader("thesisid").ToString, reader("thesistitle").ToString, reader("platformname").ToString, researchers, reader("dateofsubmission").ToString)
        End While

        conn.Close()

        If counter >= 1 Then
            detected = True
        Else
            detected = False
        End If

        Return detected

    End Function

    Private Sub txtThesisTitle_TextChanged(sender As Object, e As EventArgs) Handles txtThesisTitle.TextChanged
        If txtThesisTitle.Text.Length > 0 Then
            If txtThesisTitle.Text.EndsWith("  ") Then
                txtThesisTitle.Text = txtThesisTitle.Text.Substring(0, txtThesisTitle.Text.Length - 1)
                txtThesisTitle.SelectionStart = txtThesisTitle.Text.Length
            End If
            If txtThesisTitle.Text.StartsWith(" ") Then
                txtThesisTitle.Text = txtThesisTitle.Text.Substring(1, txtThesisTitle.Text.Length - 1)
            End If
            If txtThesisTitle.Text.Contains("  ") Then
                txtThesisTitle.Text = txtThesisTitle.Text.Replace("  ", " ")
                txtThesisTitle.SelectionStart = txtThesisTitle.Text.Length
            End If
        End If
    End Sub

    Public Sub check(sender As Object, e As EventArgs)
        Dim txtbx As TextBox = DirectCast(sender, TextBox)
        'MsgBox(txtbx.Name)

        Dim controlindex As Integer = CInt(txtbx.Name) - 1
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

    Public Function countdot(str As String) As Integer
        Dim count As Integer = 0
        For Each c As Char In str
            If c = "." Then
                count += 1
            End If
        Next
        Return count
    End Function

    Public Function isOccupied(yeartopped As String, category As String) As Boolean
        'SELECT * FROM topthesistbl LEFT JOIN topthesiscategorytbl ON topthesistbl.topthesiscategoryid = topthesiscategorytbl.topthesiscategoryid LEFT JOIN thesistbl ON topthesistbl.thesisid = thesistbl.thesisid WHERE yeartopped = 2017 AND topthesiscategorytbl.topthesiscategoryname = 'Best in Database Design'

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.ConnectionString = connstring
        conn.Open()

        Dim detected As Boolean = False

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM topthesistbl LEFT JOIN topthesiscategorytbl ON topthesistbl.topthesiscategoryid = topthesiscategorytbl.topthesiscategoryid LEFT JOIN thesistbl ON topthesistbl.thesisid = thesistbl.thesisid WHERE yeartopped = " & yeartopped & " AND topthesiscategorytbl.topthesiscategoryname = '" & category & "'"
        'SELECT * FROM thesistbl LEFT JOIN categorytbl ON thesistbl.categoryid = categorytbl.categoryid LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        Dim counter As Integer = 0
        While (reader.Read)
            'MsgBox(reader("thesisid").ToString & " " & id)
            If Not reader("thesisid").ToString.Equals(id) Then
                counter += 1
            End If
            'Dim testarray() As String = Split(reader("researchername").ToString, "|")
            'Dim researchers As String = Join(testarray, ", ")
            'DataGridView1.Rows.Add(reader("thesisid").ToString, reader("thesistitle").ToString, reader("platformname").ToString, researchers, reader("dateofsubmission").ToString)
        End While

        conn.Close()

        If counter >= 1 Then
            detected = True
        Else
            detected = False
        End If

        Return detected

    End Function

    Public Function getAffectedTopThesis(yeartopped As String, category As String) As String
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM topthesistbl LEFT JOIN topthesiscategorytbl ON topthesistbl.topthesiscategoryid = topthesiscategorytbl.topthesiscategoryid LEFT JOIN thesistbl ON topthesistbl.thesisid = thesistbl.thesisid WHERE yeartopped = " & yeartopped & " AND topthesiscategorytbl.topthesiscategoryname = '" & category & "'"
        'SELECT * FROM thesistbl LEFT JOIN categorytbl ON thesistbl.categoryid = categorytbl.categoryid LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        Dim affectedTitle As String = ""
        While reader.Read
            affectedTitle = reader("thesistitle").ToString
        End While

        conn.Close()

        Return affectedTitle
    End Function

    Public Function getplatformid(platform As String) As String
        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM platformtbl"
        'SELECT * FROM thesistbl LEFT JOIN categorytbl ON thesistbl.categoryid = categorytbl.categoryid LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        Dim platformid As String = ""

        While (reader.Read)
            If reader("platformname").ToString.Equals(platform) Then
                platformid = reader("platformid").ToString
            End If
            'Dim testarray() As String = Split(reader("researchername").ToString, "|")
            'Dim researchers As String = Join(testarray, ", ")
            'DataGridView1.Rows.Add(reader("thesisid").ToString, reader("thesistitle").ToString, reader("platformname").ToString, researchers, reader("dateofsubmission").ToString)
        End While

        conn.Close()

        Return platformid

    End Function

    Public Function getcategoryid(category As String) As String
        'SELECT * FROM `topthesiscategorytbl`
        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM topthesiscategorytbl"
        'SELECT * FROM thesistbl LEFT JOIN categorytbl ON thesistbl.categoryid = categorytbl.categoryid LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        Dim categoryid As String = ""

        While (reader.Read)
            If reader("topthesiscategoryname").ToString.Equals(category) Then
                categoryid = reader("topthesiscategoryid").ToString
            End If
            'Dim testarray() As String = Split(reader("researchername").ToString, "|")
            'Dim researchers As String = Join(testarray, ", ")
            'DataGridView1.Rows.Add(reader("thesisid").ToString, reader("thesistitle").ToString, reader("platformname").ToString, researchers, reader("dateofsubmission").ToString)
        End While

        conn.Close()

        Return categoryid

    End Function

End Class