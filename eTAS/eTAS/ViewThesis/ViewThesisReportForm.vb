Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports MySql.Data.MySqlClient

    Public Class ViewThesisReportForm
        Dim conn As New MySqlConnection
        Dim connectionString As String = "Server=localhost;User Id=root;Password=;Database=etas"
        Public Sub refreshreport(query As String)
        'MsgBox(query)
        conn.ConnectionString = connectionString
        conn.Open()
        Dim dscmd As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet
        dscmd.Fill(ds, "View Thesis")
        conn.Close()

        'ds.Tables("View Thesis").Columns("Date Published")
        With ds.Tables("View Thesis")
            .Columns("Date Published").ColumnName = "tmp Date Published"
            .Columns.Add("Date Published")
            .Columns("Date Published").DataType = GetType(String)
            Dim tempdate As Date
            For Each dr As DataRow In ds.Tables("View Thesis").Rows
                dr.BeginEdit()
                tempdate = dr("tmp Date Published").ToString
                dr("Date Published") = tempdate.ToString("MMMM yyyy")
                dr.EndEdit()
            Next

            .Columns("Date of Submission").ColumnName = "tmp Date of Submission"
            .Columns.Add("Date of Submission")
            .Columns("Date of Submission").DataType = GetType(String)
            For Each dr As DataRow In ds.Tables("View Thesis").Rows
                dr.BeginEdit()
                tempdate = dr("tmp Date of Submission").ToString
                dr("Date of Submission") = tempdate.ToString("MMMM dd, yyyy")
                dr.EndEdit()
            Next
        End With




        For Each dr As DataRow In ds.Tables("View Thesis").Rows
            dr.BeginEdit()
            dr("Researcher(s)") = dr("Researcher(s)").ToString.Replace("|", ", ")
            dr.EndEdit()
        Next

        Dim objRpt As New ViewThesisReport
        objRpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
        End Sub


    Public Sub changeConnstring(department As String)
        If department.Equals("IT") Then
            connectionString = "Server=localhost;User Id=root;Password=;Database=etas"
        ElseIf department.Equals("PA") Then
            connectionString = "Server=localhost;User Id=root;Password=;Database=etaspa"
        ElseIf department.Equals("Entrep") Then
            connectionString = "Server=localhost;User Id=root;Password=;Database=etasentrep"
        Else
            connectionString = "Server=localhost;User Id=root;Password=;Database=etas"
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.Panel1.Controls.Add(ContainerForm.viewthesis)
        ContainerForm.viewthesis.Show()
    End Sub
End Class