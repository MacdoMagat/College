Imports MySql.Data.MySqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class ProductPurchasedReport

    Private Sub ProductPurchasedReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New MySqlConnection
        conn.ConnectionString = "Server=localhost;User Id=root;Password=;Database=vbnetdb"
        Dim comm As New MySqlCommand
        Dim selectquery As String = "SELECT itemname,SUM(quantity),datetime FROM `itempurchasestbl` WHERE datetime LIKE '" & Report.DateTimePicker1.Value.Date.ToString("yyyy-MM-dd") & "%' GROUP BY datetime, itemname"
        Dim ds As New DataSet1

        comm.Connection = conn
        comm.CommandText = selectquery
        Dim adapter As New MySqlDataAdapter(selectquery, conn)
        adapter.Fill(ds)
        'Dim objrpt As New ReportDocument
        'objrpt.SetDataSource("C:\Users\C a e l l a c h\Documents\Visual Studio 2010\Projects\WindowsApplication1\WindowsApplication1\Permit.rpt")
        'CrystalReportViewer1.ReportSource = objrpt





    End Sub
End Class