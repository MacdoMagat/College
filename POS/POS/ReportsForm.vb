Public Class ReportsForm
    Dim salesreport As New ReportsSalesReportForm
    Dim productsalesreport As New ReportsProductSalesReportForm
    Private Sub ReportsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        salesreport.TopLevel = False
        salesreport.Dock = DockStyle.Fill
        productsalesreport.TopLevel = False
        productsalesreport.Dock = DockStyle.Fill
        Panel1.Controls.Add(salesreport)
        salesreport.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel1.Controls.Clear()
        Panel1.Controls.Add(salesreport)
        salesreport.Show()
    End Sub

    Private Sub ReportsForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        MainForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MainForm.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel1.Controls.Clear()
        Panel1.Controls.Add(productsalesreport)
        productsalesreport.Show()
    End Sub
End Class