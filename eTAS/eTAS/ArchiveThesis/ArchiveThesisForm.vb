Imports MySql.Data.MySqlClient
Imports Word = Microsoft.Office.Interop.Word

Public Class ArchiveThesisForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Dim numofresearcher As Integer = 1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If numofresearcher >= 5 Then
            Exit Sub
        Else
            numofresearcher = numofresearcher + 1
            Dim a As New TextBox
            'a.Size = New Size(310, 20)
            a.Name = numofresearcher.ToString
            a.Width = 345
            a.Font = New Font("Century Gothic", 12)
            AddHandler a.TextChanged, AddressOf check
            FlowLayoutPanel1.Controls.Add(a)
        End If
        If numofresearcher > 1 Then
            Button6.Enabled = True
        End If
        If numofresearcher = 5 Then
            Button1.Enabled = False
        End If
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


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        clear()

        'ContainerForm.archivethesis.FlowLayoutPanel1.Controls.Clear()
        'Dim a As New TextBox
        'a.Size = New Size(310, 20)
        'FlowLayoutPanel1.Controls.Add(a)
        'ContainerForm.Panel1.Controls.Clear()
        'ContainerForm.Panel1.Controls.Add(ContainerForm.archivethesis)
        'ContainerForm.archivethesis.Show()
        'numofresearcher = 1

        'TextBox2.Text = ""
        'TextBox3.Text = ""
        'TextBox4.Text = ""
        'ComboBox1.SelectedIndex = 0
        'ComboBox2.SelectedIndex = 0
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim worddialog As New OpenFileDialog
        worddialog.Filter = "Word Document (*.docx)|*.docx"
        worddialog.DefaultExt = "docx"
        If worddialog.ShowDialog = DialogResult.OK Then
            txtWordFile.Text = worddialog.FileName
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pdfdialog As New OpenFileDialog
        pdfdialog.Filter = "PDF File (*.pdf)|*.pdf"
        pdfdialog.DefaultExt = "pdf"
        If pdfdialog.ShowDialog = DialogResult.OK Then
            txtPDFFile.Text = pdfdialog.FileName
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If txtThesisTitle.Text = "" Then
            MsgBox("Please Enter Thesis Title", vbOKOnly, "No Title")
            Exit Sub
        End If
        If hasDuplicate(txtThesisTitle.Text) Then
            MsgBox("A duplicate in the title you have entered has been detected", vbOKOnly, "Title already exist")
            Exit Sub
        End If
        If cboPlatform.Text = "Select Platform" Then
            MsgBox("Please Select Platform", vbOKOnly, "No Platform selected")
            Exit Sub
        End If
        If cboPlatform.Text = "Select Category" Then
            MsgBox("Please Select Category", vbOKOnly, "No Category selected")
            Exit Sub
        End If

        'If cboCategory.Text = "Select Category" Then
        '    MsgBox("Please Select Category")
        '    Exit Sub
        'End If
        For Each cont As Control In FlowLayoutPanel1.Controls
            If cont.Text.Length = 0 Then
                MsgBox("Please check the fields on researchers", vbOKOnly, "Empty researcher field")
                Exit Sub
            End If
            If cont.ForeColor = Color.Red Then
                MsgBox("Please check the fields on researchers", vbOKOnly, "Invalid researcher name")
                Exit Sub
            End If
        Next

        Dim indexx As Integer = 0
        Dim indexy As Integer = 0
        For Each cont As Control In FlowLayoutPanel1.Controls
            indexy = indexx + 1
            While (indexy <= FlowLayoutPanel1.Controls.Count - 1)
                If cont.Text.Equals(FlowLayoutPanel1.Controls.Item(indexy).Text) Then
                    MsgBox("A duplicate in researchers' name has been detected.", vbOKOnly, "Duplicate in researcher's name")
                    Exit Sub
                End If
                indexy += 1
            End While
            indexx += 1
        Next


        'Dim ii As Integer = 0
        'For i As Integer = 0 To FlowLayoutPanel1.Controls.Count - 1
        '    ii = i + 1
        '    While (i < FlowLayoutPanel1.Controls.Count - 1)
        '        If FlowLayoutPanel1.Controls.Item(i).Text.Equals(FlowLayoutPanel1.Controls.Item(ii).Text) Then
        '            MsgBox("A duplicate in researchers' name has been detected.")
        '            Exit Sub
        '        End If
        '    End While
        'Next


        If DateTimePicker1.Value > Date.Now Then
            MsgBox("The submission date you have selected is set on the future", vbOKOnly, "Invalid date")
            Exit Sub
        End If

        If DateTimePicker2.Value > Date.Now Then
            MsgBox("The publish date you have selected is set on the future", vbOKOnly, "Invalid date")
            Exit Sub
        End If


        If txtWordFile.Text = "" Then
            MsgBox("Please select a Word File", vbOKOnly, "No Word file selected")
            Exit Sub
        End If
        'If txtPDFFile.Text = "" Then
        '    MsgBox("Please select a PDF File")
        '    Exit Sub
        'End If

        If PictureBox1.Image Is Nothing Then
            MsgBox("Please Insert a Cover Image", vbOKOnly, "No Image selected")
            Exit Sub
        End If

        If rdoYes.Checked Then
            If cboCategory.Text = "Please select a category" Then
                MsgBox("Please select a category", vbOKOnly, "No category selected")
                Exit Sub
            End If

            If cboYear.Text = "Please select a year" Then
                MsgBox("Please select a year", vbOKOnly, "No year selected")
                Exit Sub
                End If
            End If

            If rdoYes.Checked Then
            If lblCategoryWarning.Visible = True Then
                Select Case (MsgBox(lblCategoryWarning.Text & vbNewLine & "Do you wish to overwrite it?", vbYesNo, "Confirmation"))
                    Case vbYes

                    Case vbNo
                        Exit Sub
                    Case Else
                        Exit Sub
                End Select
            End If
        End If


        Dim message As String
        message = "Are you sure about this details?" & vbNewLine & vbNewLine & "Thesis Title: " & vbNewLine & "          " & txtThesisTitle.Text & vbNewLine & "Platform/Category: " & vbNewLine & "          " & cboPlatform.Text & vbNewLine

        If FlowLayoutPanel1.Controls.Count > 1 Then
            message = message & vbNewLine & "Researchers: "
        Else
            message = message & vbNewLine & "Researcher: "
        End If
        For Each cont As Control In FlowLayoutPanel1.Controls
            message = message & vbNewLine & "          " & cont.Text
        Next
        message = message & vbNewLine & "Submission Date: " & vbNewLine & "          " & DateTimePicker1.Value.Date & vbNewLine & "Date Published: " & vbNewLine & "          " & DateTimePicker2.Value.Date
        Select Case MsgBox(message, vbYesNo, "Confirmation Note")
            Case vbYes
            Case vbNo : Exit Sub
        End Select

        Dim researcherlist As New List(Of String)

        For i As Integer = 0 To numofresearcher - 1
            researcherlist.Add(FlowLayoutPanel1.Controls.Item(i).Text)
        Next
        Dim researchers() As String = researcherlist.ToArray
        Dim researcherstodatabase As String = Join(researchers, "|")
        'MsgBox(researcherstodatabase) 'this is the data to be sent to the database
        'MsgBox(Application.StartupPath.ToString & "\Documents\" & TextBox4.Text) 'path to be sent to the database
        Dim tempthesispath As String = Application.StartupPath.ToString & "\Documents\" & txtThesisTitle.Text
        Dim thesispath As String = tempthesispath.Replace("\", "\\")
        Dim platformid As String = getplatformid()
        'Dim categoryid As String = getcategoryid()
        Dim dateofsubmission As String = DateTimePicker1.Value.ToString("d-MM-yyyy")
        Dim publishdate As String = DateTimePicker2.Value.ToString("d-MM-yyyy")






        My.Computer.FileSystem.CopyFile(txtWordFile.Text, Application.StartupPath.ToString & "\Documents\" & txtThesisTitle.Text & ".docx", True)
        My.Computer.FileSystem.CopyFile(Label11.Text, Application.StartupPath.ToString & "\Documents\" & txtThesisTitle.Text & ".jpg", True)
        'My.Computer.FileSystem.RenameFile(Application.StartupPath.ToString & "\Documents\","title.docx")
        'My.Computer.FileSystem.CopyFile(txtPDFFile.Text, Application.StartupPath.ToString & "\Documents\" & txtThesisTitle.Text & ".pdf", True)
        'converting word to pdf
        Dim MyApp As New Word.Application
        Dim MyDoc As Word.Document = MyApp.Documents.Open(txtWordFile.Text, False, True)
        Try
            MyDoc.Activate()
            MyDoc.SaveAs2(Application.StartupPath.ToString & "\Documents\" & txtThesisTitle.Text & ".pdf", Word.WdSaveFormat.wdFormatPDF)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        MyDoc.Close()
        MyApp.Quit()

        '___________ inilipat ko lang ng pwesto ito, dati kase ay bago ung sa word file
        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        With comm
            .CommandType = CommandType.Text
            .CommandText = "INSERT INTO `thesistbl`(`thesistitle`, `platformid`, `researchername`, `dateofsubmission`, `datepublished`, `thesispath`) VALUES ('" & txtThesisTitle.Text.Replace("'", "''") & "'," & platformid & ",'" & researcherstodatabase & "',STR_TO_DATE('" & dateofsubmission & "','%d-%m-%Y'),STR_TO_DATE('" & publishdate & "','%d-%m-%Y'),'" & thesispath.Replace("'", "''") & "')"
            .Connection = conn
            'Clipboard.SetText("INSERT INTO `thesistbl`(`thesistitle`, `platformid`, `researchername`, `dateofsubmission`, `datepublished`, `thesispath`) VALUES ('" & txtThesisTitle.Text.Replace("'", "''") & "'," & platformid & ",'" & researcherstodatabase & "',STR_TO_DATE('" & dateofsubmission & "','%d-%m-%Y'),STR_TO_DATE('" & publishdate & "','%d-%m-%Y'),'" & thesispath & "')")
            .ExecuteNonQuery()
        End With
        conn.Close()
        '___________ 

        If rdoYes.Checked Then
            Dim topcomm As New MySqlCommand
            With topcomm
                .CommandType = CommandType.Text
                .Connection = conn

                If lblCategoryWarning.Visible = True Then

                    .CommandText = "DELETE FROM `topthesistbl` WHERE thesisid = " & getAffectedTopThesisId(cboYear.Text, cboCategory.Text) & "; INSERT INTO topthesistbl (thesisid,topthesiscategoryid,yeartopped) VALUES (" & getThesisId(txtThesisTitle.Text) & "," & getcategoryid(cboCategory.Text) & "," & cboYear.Text & ")"
                Else
                    .CommandText = "INSERT INTO topthesistbl (thesisid,topthesiscategoryid,yeartopped) VALUES (" & getThesisId(txtThesisTitle.Text) & "," & getcategoryid(cboCategory.Text) & "," & cboYear.Text & ")"
                End If

                conn.Open()
                .ExecuteNonQuery()
                conn.Close()
            End With
        End If


        ContainerForm.executeTaskQuery("Import Thesis", "Imported Thesis (" & txtThesisTitle.Text & ")")
        MsgBox("Thesis Archived")
        clear()

    End Sub

    Public Function hasDuplicate(title As String) As Boolean
        conn.ConnectionString = connstring
        conn.Open()

        Dim detected As Boolean = False

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM thesistbl WHERE thesistitle='" & title.Replace("'", "''") & "'"
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

    'Function getcategoryid()
    '    conn.ConnectionString = connstring
    '    conn.Open()

    '    Dim comm As New MySqlCommand
    '    Dim commstring As String = "SELECT * FROM categorytbl WHERE categoryname='" & cboCategory.Text & "'"
    '    Dim reader As MySqlDataReader

    '    comm.Connection = conn
    '    comm.CommandText = commstring
    '    reader = comm.ExecuteReader

    '    Dim categoryid As String
    '    While reader.Read
    '        categoryid = reader("categoryid").ToString
    '    End While

    '    conn.Close()

    '    Return categoryid
    'End Function

    Function getplatformid()
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM platformtbl WHERE platformname='" & cboPlatform.Text & "'"
        Dim reader As MySqlDataReader

        comm.Connection = conn
        comm.CommandText = commstring
        reader = comm.ExecuteReader

        Dim platformid As String = ""
        While reader.Read
            platformid = reader("platformid").ToString
        End While

        conn.Close()

        Return platformid
    End Function


    'Dim numofresearcher As Integer = 1
    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    FlowLayoutPanel1.Controls.Clear()
    '    For i As Integer = 0 To numofresearcher
    '        Dim a As New TextBox
    '        a.Size = New Size(310, 20)
    '        FlowLayoutPanel1.Controls.Add(a)
    '    Next
    '    Dim addresearcher As New Button
    '    addresearcher.Text = "Add"
    '    AddHandler addresearcher.Click, AddressOf addresearcherfunc
    '    FlowLayoutPanel1.Controls.Add(addresearcher)
    '    numofresearcher = numofresearcher + 1
    'End Sub

    'Public Sub addresearcherfunc()
    '    FlowLayoutPanel1.Controls.Clear()
    '    For i As Integer = 0 To numofresearcher
    '        Dim a As New TextBox
    '        a.Size = New Size(310, 20)
    '        FlowLayoutPanel1.Controls.Add(a)
    '    Next
    '    Dim addresearcher As New Button
    '    addresearcher.Text = "Add"
    '    AddHandler addresearcher.Click, AddressOf addresearcherfunc
    '    FlowLayoutPanel1.Controls.Add(addresearcher)
    '    numofresearcher = numofresearcher + 1
    'End Sub

    Public Sub archivethesisload()
        cboPlatform.Items.Clear()

        If Not ContainerForm.departmentSelected.Equals("IT") Then
            Label2.Text = "Category"
        End If

        If Not ContainerForm.departmentSelected.Equals("IT") Then
            cboPlatform.Items.Add("Select Category")
        Else
            cboPlatform.Items.Add("Select Platform")
        End If
        'conn.ConnectionString = connstring
        'conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String
        'Dim commstring As String = "SELECT * FROM categorytbl"
        Dim reader As MySqlDataReader
        'comm.CommandText = commstring
        'comm.Connection = conn
        'reader = comm.ExecuteReader

        'While (reader.Read)
        '    cboCategory.Items.Add(reader("categoryname").ToString)
        'End While
        ''ComboBox2.Items.Add("Add New")
        'cboCategory.SelectedIndex = 0
        'conn.Close()

        conn.ConnectionString = connstring
        conn.Open()


        commstring = "SELECT * FROM platformtbl"
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        While (reader.Read)
            cboPlatform.Items.Add(reader("platformname").ToString)
        End While
        'ComboBox1.Items.Add("Add New")
        cboPlatform.SelectedIndex = 0
        conn.Close()




        Dim year As Integer = Date.Now.Year.ToString
        cboYear.Items.Clear()
        cboYear.Items.Add("Please select a year")
        While year >= 2002
            cboYear.Items.Add(year)
            year -= 1
        End While
        cboYear.SelectedIndex = 0

        refreshCboCategory()
        lblCategoryWarning.Visible = False

        clear()
    End Sub

    Public Sub clear()
        Button6.Enabled = False
        ContainerForm.archivethesis.FlowLayoutPanel1.Controls.Clear()
        numofresearcher = 1
        Dim a As New TextBox
        'a.Size = New Size(310, 20)
        a.Name = numofresearcher.ToString
        a.Width = 345
        a.Font = New Font("Century Gothic", 12)
        AddHandler a.TextChanged, AddressOf check
        FlowLayoutPanel1.Controls.Add(a)
        'ContainerForm.Panel1.Controls.Clear()
        'ContainerForm.Panel1.Controls.Add(ContainerForm.archivethesis)
        'ContainerForm.archivethesis.Show()
        txtWordFile.Text = ""
        txtPDFFile.Text = ""
        txtThesisTitle.Text = ""
        cboPlatform.SelectedIndex = 0

        PictureBox1.Image = Nothing
        Label11.Text = "Please Select a File"
        rdoNo.Checked = True
        'cboCategory.SelectedIndex = 0
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If numofresearcher > 1 Then
            FlowLayoutPanel1.Controls.RemoveAt(numofresearcher - 1)
            numofresearcher -= 1
        End If
        If Not numofresearcher > 1 Then
            Button6.Enabled = False
        End If
        If numofresearcher < 5 Then
            Button1.Enabled = True
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim picdialog As New OpenFileDialog
        picdialog.Filter = "Picture Files|*.jpg;*.png"
        If picdialog.ShowDialog = DialogResult.OK Then
            Label11.Text = picdialog.FileName
            PictureBox1.Image = Image.FromFile(picdialog.FileName)
        End If
    End Sub


    Public Sub refreshCboCategory()
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
        cboCategory.Items.Add("Please select a category")
        While (reader.Read)
            cboCategory.Items.Add(reader("topthesiscategoryname").ToString)
        End While

        cboCategory.SelectedIndex = 0
        conn.Close()
    End Sub

    Private Sub rdoNo_CheckedChanged(sender As Object, e As EventArgs) Handles rdoNo.CheckedChanged
        If rdoNo.Checked Then
            cboYear.Enabled = False
            cboCategory.Enabled = False
            cboYear.SelectedIndex = 0
            cboCategory.SelectedIndex = 0
        End If
    End Sub

    Private Sub rdoYes_CheckedChanged(sender As Object, e As EventArgs) Handles rdoYes.CheckedChanged
        If rdoYes.Checked Then
            cboYear.Enabled = True
            cboCategory.Enabled = True
        End If
    End Sub

    Public Function getThesisId(thesistitle As String) As String
        Dim thesisid As String = ""

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM thesistbl WHERE thesistitle='" & thesistitle.Replace("'", "''") & "'"
        'SELECT * FROM thesistbl LEFT JOIN categorytbl ON thesistbl.categoryid = categorytbl.categoryid LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        Dim affectedTitle As String = ""
        While reader.Read
            thesisid = reader("thesisid").ToString
        End While

        conn.Close()

        Return thesisid
    End Function

    Public Function isOccupied(yeartopped As String, category As String) As Boolean
        'SELECT * FROM topthesistbl LEFT JOIN topthesiscategorytbl ON topthesistbl.topthesiscategoryid = topthesiscategorytbl.topthesiscategoryid LEFT JOIN thesistbl ON topthesistbl.thesisid = thesistbl.thesisid WHERE yeartopped = 2017 AND topthesiscategorytbl.topthesiscategoryname = 'Best in Database Design'

        If yeartopped.Equals("Please select a year") Or category.Equals("Please select a category") Then
            Return False
            Exit Function
        End If

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

            counter += 1
        End While

        conn.Close()

        If counter >= 1 Then
            detected = True
        Else
            detected = False
        End If

        Return detected

    End Function

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        If isOccupied(cboYear.Text, cboCategory.Text) Then
            lblCategoryWarning.Text = "This category is already occupied by '" & getAffectedTopThesis(cboYear.Text, cboCategory.Text) & "'"
            lblCategoryWarning.Visible = True
        Else
            lblCategoryWarning.Visible = False
        End If
    End Sub

    Private Sub cboYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboYear.SelectedIndexChanged
        If isOccupied(cboYear.Text, cboCategory.Text) Then
            lblCategoryWarning.Text = "This category is already occupied by '" & getAffectedTopThesis(cboYear.Text, cboCategory.Text) & "'"
            lblCategoryWarning.Visible = True
        Else
            lblCategoryWarning.Visible = False
        End If
    End Sub

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

    Public Function getAffectedTopThesisId(yeartopped As String, category As String) As String
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

        Dim affectedTitleId As String = ""
        While reader.Read
            affectedTitleId = reader("thesisid").ToString
        End While

        conn.Close()

        Return affectedTitleId
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