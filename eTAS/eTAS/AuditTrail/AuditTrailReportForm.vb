Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports MySql.Data.MySqlClient

Public Class AuditTrailReportForm
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
        'MsgBox(query)

        'Dim sql As String = "SELECT logname as 'Name',loggedin as 'Logged In',loggedout as 'Logged Out' FROM logstbl"

        '       connectionString = "data source=servername; _
        'initial catalog=crystaldb;user id=username;password=password;"
        conn.ConnectionString = connectionString
        conn.Open()
        Dim dscmd As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet
        dscmd.Fill(ds, "Logs")
        conn.Close()

        Dim objRpt As New AuditTrailLogsReport
        objRpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = objRpt
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ContainerForm.audittrail.Panel1.Controls.Clear()
        ContainerForm.audittraillogs.changeConnstring(ContainerForm.departmentSelected)
        ContainerForm.audittrail.Panel1.Controls.Add(ContainerForm.audittraillogs)
        ContainerForm.audittraillogs.Show()
    End Sub
End Class