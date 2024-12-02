Imports MySql.Data.MySqlClient



Public Class RemoveThesisForm
    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Public decisionContinue As Boolean

    'Public Sub removeThesisLoad()
    '    DataGridView1.Rows.Clear()

    '    conn.ConnectionString = connstring
    '    conn.Open()

    '    Dim comm As New MySqlCommand
    '    Dim commstring As String = "SELECT thesistbl.thesisid as 'ID', thesistbl.thesistitle as 'Thesis Title', thesistbl.researchername as 'Researcher(s)', thesistbl.dateofsubmission as 'Date of Submission', thesistbl.datepublished as 'Date Published', platformtbl.platformname as 'Platform' FROM thesistbl LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"
    '    'SELECT * FROM thesistbl LEFT JOIN categorytbl ON thesistbl.categoryid = categorytbl.categoryid LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"
    '    Dim reader As MySqlDataReader
    '    comm.CommandText = commstring
    '    comm.Connection = conn
    '    reader = comm.ExecuteReader

    '    While (reader.Read)
    '        Dim datepublished As Date = reader("Date Published").ToString
    '        Dim datesubmitted As Date = reader("Date of Submission").ToString
    '        Dim testarray() As String = Split(reader("Researcher(s)").ToString, "|")
    '        Dim researchers As String = Join(testarray, ", ")
    '        DataGridView1.Rows.Add(reader("ID").ToString, reader("Thesis Title").ToString, reader("Platform").ToString, researchers, datesubmitted.ToString("MMMM dd, yyyy"), datepublished.ToString("MMMM yyyy"))
    '    End While

    '    conn.Close()
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


    Private Sub txtTitle_TextChanged(sender As Object, e As EventArgs) Handles txtTitle.TextChanged
        Dim commstring As String = "SELECT thesistbl.thesisid as 'ID', thesistbl.thesistitle as 'Thesis Title', thesistbl.researchername as 'Researcher(s)', thesistbl.dateofsubmission as 'Date of Submission', thesistbl.datepublished as 'Date Published', platformtbl.platformname as 'Platform' FROM thesistbl LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"
        If Not txtTitle.Text.Equals("") Then
            If txtTitle.Text.Contains(" ") Then
                Dim titlearray() As String = Split(txtTitle.Text, " ")
                For i As Integer = 0 To titlearray.Length - 1
                    If i = 0 Then
                        commstring = commstring & " WHERE thesistbl.thesistitle LIKE '%" & titlearray(i) & "%'"
                    Else
                        commstring = commstring & " AND thesistbl.thesistitle LIKE '%" & titlearray(i) & "%'"
                    End If
                Next
            Else
                commstring = commstring & " WHERE thesistbl.thesistitle LIKE '%" & txtTitle.Text.Replace("'", "''") & "%'"
            End If


            'commstring += " WHERE thesistbl.thesistitle LIKE '%" & txtTitle.Text.Replace("'", "''") & "%'"
        End If

        DataGridView1.Rows.Clear()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand

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

    Public Sub loadDatagrid()

        If Not ContainerForm.departmentSelected = "IT" Then
            DataGridView1.Columns(2).HeaderText = "Category"
        End If

        Dim commstring As String = "SELECT thesistbl.thesisid as 'ID', thesistbl.thesistitle as 'Thesis Title', thesistbl.researchername as 'Researcher(s)', thesistbl.dateofsubmission as 'Date of Submission', thesistbl.datepublished as 'Date Published', platformtbl.platformname as 'Platform' FROM thesistbl LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"


        DataGridView1.Rows.Clear()
        If conn.State = ConnectionState.Open Then conn.Close()
        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim RemoveThesisPassword As New RemoveThesisPasswordForm

        decisionContinue = False
        Dim title As String = ""
        Try
            title = DataGridView1.CurrentRow.Cells(1).Value.ToString
        Catch ex As Exception
            MsgBox("Please select a title")
            Exit Sub
        End Try

        If isTopThesis(getThesisId(title)) Then
            Select Case MsgBox("The Thesis you will remove is a Top Thesis. Do you want to proceed", vbYesNo)
                Case vbYes

                Case vbNo
                    Exit Sub
                Case Else

            End Select
            'MsgBox("The Thesis you will remove is a Top Thesis. Do you want to proceed", vbYesNo)
        End If

        For i As Integer = 0 To 2
            Dim message As String = ""

            Select Case i
                Case 0
                    message = "For verification, please enter your password."
                Case 1
                    message = "Are you sure you want to remove """ & title & """"
                Case 2
                    message = "Pressing 'Remove' would now remove the thesis """ & title & """"
                    RemoveThesisPassword.btnProceed.Text = "Remove"
                Case Else

            End Select
            RemoveThesisPassword.Label1.Text = message
            RemoveThesisPassword.txtPassword.Text = ""
            RemoveThesisPassword.ShowDialog()
            If Not decisionContinue Then
                Exit Sub
            End If
        Next

        If decisionContinue Then
            deleteThesis(getThesisId(title))
            ContainerForm.executeTaskQuery("Archive Thesis", "Archived a thesis (" & title & ")")
        End If

    End Sub

    Public Sub deleteThesis(thesisId As String)
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "DELETE FROM `topthesistbl` WHERE thesisid = " & thesisId & "; DELETE FROM `thesistbl` WHERE thesisid = " & thesisId
        comm.CommandText = commstring
        comm.Connection = conn

        comm.ExecuteNonQuery()

        conn.Close()

        MsgBox("Thesis removed")
        ContainerForm.removethesis.loadDatagrid()
    End Sub

    'Private Sub RemoveThesisForm_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    loadDatagrid()
    'End Sub
End Class