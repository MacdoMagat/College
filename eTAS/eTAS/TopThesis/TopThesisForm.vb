Imports MySql.Data.MySqlClient

Public Class TopThesisForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"

    Private Sub TopThesisForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'categorycbo.SelectedIndex = 0
        'yearcbo.SelectedIndex = 0
    End Sub

    Public Sub displayThesis(categorycbo As String, yearcbo As String)
        If (categorycbo = "" Or yearcbo = "" Or categorycbo = "Select Category" Or yearcbo = "Select Year") Then
            categorycbo = ""
            yearcbo = ""
        End If

        Dim path As String

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM topthesistbl LEFT JOIN thesistbl ON topthesistbl.thesisid = thesistbl.thesisid LEFT JOIN topthesiscategorytbl ON topthesistbl.topthesiscategoryid = topthesiscategorytbl.topthesiscategoryid WHERE yeartopped='" & yearcbo & "' AND topthesiscategorytbl.topthesiscategoryname='" & categorycbo & "'"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        Dim researchers() As String
        Dim result As Integer = 0

        While (reader.Read)
            'thesispath = reader("thesispath").ToString
            path = reader("thesispath").ToString & ".pdf"
            previewPDF.src = path
            Label6.Text = reader("thesistitle").ToString
            researchers = Split(reader("researchername").ToString, "|")
            result += 1
        End While

        If result > 0 Then
            Label7.Text = ""
            For i As Integer = 0 To researchers.Length - 1
                Label7.Text = Label7.Text & researchers(i).ToString & vbNewLine
            Next
        Else
            Label6.Text = ""
            Label7.Text = ""
            previewPDF.src = Application.StartupPath.ToString & "\Others\NoFileSelected.pdf"
        End If


        'Label7.Text = ""
        'If researchers.Length - 1 = 0 Then
        'Else
        '    For i As Integer = 0 To researchers.Length - 1
        '        Label7.Text = Label7.Text & researchers(i).ToString & vbNewLine

        '    Next
        'End If
        conn.Close()
    End Sub
    'SELECT * FROM topthesistbl LEFT JOIN thesistbl ON topthesistbl.thesisid = thesistbl.thesisid LEFT JOIN topthesiscategorytbl ON topthesistbl.topthesiscategoryid = topthesiscategorytbl.topthesiscategoryid WHERE yeartopped=2017 AND topthesiscategorytbl.topthesiscategoryname='Best PHP'


    Public Sub updatecomboboxes()
        updatecategorycbo()
        updateyearcbo()
        categorycbo.SelectedIndex = 0
        yearcbo.SelectedIndex = 0
    End Sub

    Public Sub updatecategorycbo()
        categorycbo.Items.Clear()
        categorycbo.Items.Add("Select Category")

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM topthesiscategorytbl"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        While reader.Read
            categorycbo.Items.Add(reader("topthesiscategoryname").ToString)
        End While

        conn.Close()
    End Sub

    Public Sub updateyearcbo()
        yearcbo.Items.Clear()
        yearcbo.Items.Add("Select Year")

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT yeartopped FROM topthesistbl GROUP BY yeartopped"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        While reader.Read
            yearcbo.Items.Add(reader("yeartopped").ToString)
        End While

        conn.Close()
    End Sub

    Private Sub categorycbo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles categorycbo.SelectedIndexChanged
        displayThesis(categorycbo.Text, yearcbo.Text)
    End Sub

    Private Sub yearcbo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles yearcbo.SelectedIndexChanged
        displayThesis(categorycbo.Text, yearcbo.Text)
    End Sub
End Class