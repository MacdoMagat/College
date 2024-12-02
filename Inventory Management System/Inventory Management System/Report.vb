Public Class Report

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Dim conn As New Connection
        conn.loadpurchasesreport(DateTimePicker1.Value.Date.ToString("yyyy-MM-dd"))
        conn.loadproductreport(DateTimePicker1.Value.Date.ToString("yyyy-MM-dd"))
    End Sub

    Private Sub Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New Connection
        conn.loadpurchasesreport(DateTimePicker1.Value.Date.ToString("yyyy-MM-dd"))
        conn.loadproductreport(DateTimePicker1.Value.Date.ToString("yyyy-MM-dd"))
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Login.Show()
        Login.type.Text = "None"
        Login.loginname.Text = ""
        Login.loginpassword.Text = ""
        Main.Close()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Main.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ProductPurchasedReport.Show()
    End Sub
End Class