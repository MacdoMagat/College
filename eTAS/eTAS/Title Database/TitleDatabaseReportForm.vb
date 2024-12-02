Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports MySql.Data.MySqlClient

Public Class TitleDatabaseReportForm
    Dim conn As New MySqlConnection
    Dim connectionString As String = "Server=localhost;User Id=root;Password=;Database=etas"

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


    Public Sub refreshreport(query As String)

        conn.ConnectionString = connectionString
        conn.Open()
        Dim dscmd As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet
        dscmd.Fill(ds, "Titles")
        conn.Close()

        Dim objRpt As New TitleDatabaseReport
        objRpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.Panel1.Controls.Add(ContainerForm.titledatabase)
        ContainerForm.titledatabase.Show()
    End Sub
End Class