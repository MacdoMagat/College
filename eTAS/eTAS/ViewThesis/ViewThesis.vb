Imports MySql.Data.MySqlClient


Public Class ViewThesis

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Dim globalquery As String


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


    Public Sub fillallcombobox()
        platformcbo.Items.Clear()
        'categorycbo.Items.Clear()
        datecbo.Items.Clear()
        platformcbo.Items.Add("All")
        'categorycbo.Items.Add("All")
        datecbo.Items.Add("All")

        conn.ConnectionString = connstring
        'conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String
        Dim reader As MySqlDataReader

        'comm.CommandText = commstring
        'comm.Connection = conn
        'reader = comm.ExecuteReader

        'While reader.Read
        '    categorycbo.Items.Add(reader("categoryname").ToString)
        'End While
        'conn.Close()

        conn.Open()

        commstring = "SELECT * FROM platformtbl"

        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        While reader.Read
            platformcbo.Items.Add(reader("platformname").ToString)
        End While
        conn.Close()

        conn.Open()

        commstring = "SELECT YEAR(dateofsubmission) as datesubmitted from thesistbl group BY YEAR(dateofsubmission)"

        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        While reader.Read
            datecbo.Items.Add(reader("datesubmitted").ToString)
        End While
        conn.Close()

        'categorycbo.SelectedIndex = 0
        platformcbo.SelectedIndex = 0
        datecbo.SelectedIndex = 0

    End Sub





    Public Sub viewthesisload()

        If Not ContainerForm.departmentSelected = "IT" Then
            Label5.Text = "Category"
            DataGridView1.Columns(2).HeaderText = "Category"
        End If

        fillallcombobox()

        DataGridView1.Rows.Clear()

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT thesistbl.thesisid as 'ID', thesistbl.thesistitle as 'Thesis Title', thesistbl.researchername as 'Researcher(s)', thesistbl.dateofsubmission as 'Date of Submission', thesistbl.datepublished as 'Date Published', platformtbl.platformname as 'Platform' FROM thesistbl LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"
        'SELECT * FROM thesistbl LEFT JOIN categorytbl ON thesistbl.categoryid = categorytbl.categoryid LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        While (reader.Read)
            Dim datepublished As Date = reader("Date Published").ToString
            Dim datesubmitted As Date = reader("Date of Submission").ToString
            Dim testarray() As String = Split(reader("Researcher(s)").ToString, "|")
            Dim researchers As String = Join(testarray, ", ")
            DataGridView1.Rows.Add(reader("ID").ToString, reader("Thesis Title").ToString, reader("Platform").ToString, researchers, datesubmitted.ToString("MMMM dd, yyyy"), datepublished.ToString("MMMM yyyy"))
        End While

        conn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim id As String = DataGridView1.CurrentRow.Cells(0).Value.ToString
        Dim path As String

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM thesistbl WHERE thesisid=" & id
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        While reader.Read
            path = reader("thesispath").ToString & ".docx"
            Diagnostics.Process.Start(path)
        End While

        conn.Close()

        ContainerForm.executeTaskQuery("View Thesis", "Open Thesis in Word (" & DataGridView1.CurrentRow.Cells(1).Value.ToString & ")")


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim id As String = DataGridView1.CurrentRow.Cells(0).Value.ToString
        Dim path As String

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM thesistbl WHERE thesisid=" & id
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        While reader.Read
            path = reader("thesispath").ToString & ".pdf"
            Diagnostics.Process.Start(path)
        End While

        conn.Close()

        ContainerForm.executeTaskQuery("View Thesis", "Open Thesis in PDF (" & DataGridView1.CurrentRow.Cells(1).Value.ToString & ")")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'ContainerForm.retrievethesisview.currentid = DataGridView1.CurrentRow.Cells(0).Value.ToString
        If DataGridView1.SelectedRows.Count = 0 Then
            MsgBox("Please Select a thesis to view")
            Exit Sub
        End If
        Try
            ContainerForm.retrievethesisview.changeConnstring(ContainerForm.departmentSelected)
            ContainerForm.retrievethesisview.viewthesis(DataGridView1.CurrentRow.Cells(0).Value.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try
        ContainerForm.executeTaskQuery("View Thesis", "Viewed Thesis (" & DataGridView1.CurrentRow.Cells(1).Value.ToString & ")")
        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.Panel1.Controls.Add(ContainerForm.retrievethesisview)
        ContainerForm.retrievethesisview.Show()


    End Sub

    Public Sub refreshdatagrid(thesistitle As String, platform As String, researcher As String, dateofsubmission As String)
        Dim query As String
        Dim first As Boolean = False 'First means may nauna nang WHERE, baka maulit
        thesistitle = thesistitle.Replace("'", "''")
        researcher = researcher.Replace("'", "''")
        query = "SELECT thesistbl.thesisid as 'ID', thesistbl.thesistitle as 'Thesis Title', thesistbl.researchername as 'Researcher(s)', thesistbl.dateofsubmission as 'Date of Submission', thesistbl.datepublished as 'Date Published', platformtbl.platformname as 'Platform' FROM thesistbl LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"
        'LEFT JOIN categorytbl ON thesistbl.categoryid = categorytbl.categoryid
        If thesistitle = "" Then
            query = query
        Else
            If thesistitle.Contains(" ") Then
                Dim titlearray() As String = Split(thesistitle, " ")
                For i As Integer = 0 To titlearray.Length - 1
                    If i = 0 Then
                        query = query & " WHERE thesistbl.thesistitle LIKE '%" & titlearray(i) & "%'"
                    Else
                        query = query & " AND thesistbl.thesistitle LIKE '%" & titlearray(i) & "%'"
                    End If
                Next
            Else
                query = query & " WHERE thesistbl.thesistitle LIKE '%" & thesistitle & "%'"
            End If
            first = True
        End If

        If platform = "All" Then
            query = query
        ElseIf first Then
            query = query & " AND platformtbl.platformname = '" & platform & "'"
        Else
            query = query & " WHERE platformtbl.platformname = '" & platform & "'"
            first = True
        End If

        'If category = "All" Then
        '    query = query
        'ElseIf first Then
        '    query = query & " AND categorytbl.categoryname = '" & category & "'"
        'Else
        '    query = query & " WHERE categorytbl.categoryname = '" & category & "'"
        '    first = True
        'End If



        'ito ung tunay na codes
        'If researcher = "" Then
        '    query = query
        'ElseIf first Then
        '    query = query & " AND thesistbl.researchername LIKE '%" & researcher & "%'"
        'Else
        '    query = query & " WHERE thesistbl.researchername LIKE '%" & researcher & "%'"
        '    first = True
        'End If
        '__________________

        If researcher = "" Then
            query = query
        Else
            If first Then
                query = query & " AND"
            Else
                query = query & " WHERE"
                first = True
            End If
            If researcher.Contains(" ") Then
                Dim researcherarray() As String = Split(researcher, " ")
                For i As Integer = 0 To researcherarray.Length - 1
                    If i = 0 Then
                        query = query & " thesistbl.researchername LIKE '%" & researcherarray(i) & "%'"
                    Else
                        query = query & " AND thesistbl.researchername LIKE '%" & researcherarray(i) & "%'"
                    End If
                Next
            Else
                query = query & " thesistbl.researchername LIKE '%" & researcher & "%'"
            End If
        End If


        'If thesistitle.Contains("|") Then
        '    Dim titlearray() As String = Split(thesistitle, "|")
        '    For i As Integer = 0 To titlearray.Length - 1
        '        If i = 0 Then
        '            query = query & " WHERE thesistbl.thesistitle LIKE '%" & titlearray(i) & "%'"
        '        Else
        '            query = query & " AND thesistbl.thesistitle LIKE '%" & titlearray(i) & "%'"
        '        End If
        '    Next

        '    query = query & " WHERE thesistbl.thesistitle LIKE '%" & thesistitle & "%'"
        'End If
        'first = True



        '________







        If dateofsubmission = "All" Then
            query = query
        ElseIf first Then
            query = query & " AND YEAR(thesistbl.dateofsubmission)='" & dateofsubmission & "'"
        Else
            query = query & " WHERE YEAR(thesistbl.dateofsubmission)='" & dateofsubmission & "'"
        End If

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim reader As MySqlDataReader

        comm.CommandText = query
        comm.Connection = conn
        reader = comm.ExecuteReader

        DataGridView1.Rows.Clear()

        While (reader.Read)
            Dim datepublished As Date = reader("Date Published").ToString
            Dim datesubmitted As Date = reader("Date of Submission").ToString
            Dim testarray() As String = Split(reader("Researcher(s)").ToString, "|")
            Dim researchers As String = Join(testarray, ", ")
            DataGridView1.Rows.Add(reader("ID").ToString, reader("Thesis Title").ToString, reader("Platform").ToString, researchers, datesubmitted.ToString("MMMM dd, yyyy"), datepublished.ToString("MMMM yyyy"))
        End While

        conn.Close()

        globalquery = query
        'Clipboard.SetText(query)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        refreshdatagrid(TextBox1.Text, platformcbo.Text, TextBox2.Text, datecbo.Text)
    End Sub

    Private Sub platformcbo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles platformcbo.SelectedIndexChanged
        refreshdatagrid(TextBox1.Text, platformcbo.Text, TextBox2.Text, datecbo.Text)
    End Sub

    Private Sub categorycbo_SelectedIndexChanged(sender As Object, e As EventArgs)
        refreshdatagrid(TextBox1.Text, platformcbo.Text, TextBox2.Text, datecbo.Text)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        refreshdatagrid(TextBox1.Text, platformcbo.Text, TextBox2.Text, datecbo.Text)
    End Sub

    Private Sub datecbo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles datecbo.SelectedIndexChanged
        refreshdatagrid(TextBox1.Text, platformcbo.Text, TextBox2.Text, datecbo.Text)
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Button3.PerformClick()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.thesisreport.changeConnstring(ContainerForm.departmentSelected)
        ContainerForm.Panel1.Controls.Add(ContainerForm.thesisreport)
        ContainerForm.thesisreport.refreshreport(globalquery)
        ContainerForm.thesisreport.Show()
        ContainerForm.executeTaskQuery("View Thesis", "Created report of theses")
    End Sub
End Class