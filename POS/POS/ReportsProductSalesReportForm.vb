Imports MySql.Data.MySqlClient

Public Class ReportsProductSalesReportForm
    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=pos"

    Public Sub refreshchart(productname As String, condition As String)
        Chart1.Series("Sales").Points.Clear()

        If condition = "Weekly" Then

            Dim dailydate As New Date
            dailydate = Now()
            dailydate = dailydate.AddDays(-7)
            For i As Integer = 0 To 7
                Try
                    conn.ConnectionString = connstring
                    conn.Open()

                    Dim comm As New MySqlCommand
                    Dim commstring As String = "SELECT productname, SUM(quantity), datepurchased FROM productpurchasestbl WHERE productname='" & productname & "'  AND YEAR(datepurchased)='" & dailydate.ToString("yyyy") & "' AND MONTH(datepurchased)='" & dailydate.ToString("MM") & "' AND DAY(datepurchased)='" & dailydate.ToString("dd") & "' GROUP BY productname"
                    Dim reader As MySqlDataReader

                    comm.Connection = conn
                    comm.CommandText = commstring
                    reader = comm.ExecuteReader

                    While reader.Read
                        Chart1.Series("Sales").Points.AddXY(dailydate.ToString("yyyy-MM-dd"), CInt(reader("SUM(quantity)").ToString))
                    End While
                    dailydate = dailydate.AddDays(1)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    conn.Close()
                End Try
            Next

        ElseIf condition = "Monthly" Then

            Dim dailydate As New Date
            dailydate = Now()
            dailydate = dailydate.AddMonths(-6)
            For i As Integer = 0 To 6
                Try
                    conn.ConnectionString = connstring
                    conn.Open()

                    Dim comm As New MySqlCommand
                    Dim commstring As String = "SELECT productname, SUM(quantity), datepurchased FROM productpurchasestbl WHERE productname='" & productname & "'  AND YEAR(datepurchased)='" & dailydate.ToString("yyyy") & "' AND MONTH(datepurchased)='" & dailydate.ToString("MM") & "' GROUP BY productname"
                    Dim reader As MySqlDataReader

                    comm.Connection = conn
                    comm.CommandText = commstring
                    reader = comm.ExecuteReader

                    Dim total As Double = 0
                    While reader.Read
                        total = total + CDbl(reader("SUM(Quantity)").ToString)
                    End While

                    Chart1.Series("Sales").Points.AddXY(dailydate.ToString("MMM"), total)
                    dailydate = dailydate.AddMonths(1)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    conn.Close()
                End Try
            Next

        ElseIf condition = "Yearly" Then

            Dim dailydate As New Date
            dailydate = Now()
            dailydate = dailydate.AddYears(-5)
            For i As Integer = 0 To 5
                Try
                    conn.ConnectionString = connstring
                    conn.Open()

                    Dim comm As New MySqlCommand
                    Dim commstring As String = "SELECT productname, SUM(quantity), datepurchased FROM productpurchasestbl WHERE productname='" & productname & "'  AND YEAR(datepurchased)='" & dailydate.ToString("yyyy") & "' GROUP BY productname"
                    Dim reader As MySqlDataReader

                    comm.Connection = conn
                    comm.CommandText = commstring
                    reader = comm.ExecuteReader

                    Dim total As Double = 0
                    While reader.Read
                        total = total + CDbl(reader("SUM(quantity)").ToString)
                    End While

                    Chart1.Series("Sales").Points.AddXY(dailydate.ToString("yyyy"), total)
                    dailydate = dailydate.AddYears(1)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    conn.Close()
                End Try
            Next

        End If

    End Sub

    Public Sub refreshproduct(productcategoryname As String)
        Dim id As String
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM productcategorytbl WHERE productcategoryname = '" & productcategoryname & "'"
            Dim reader As MySqlDataReader

            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader


            While reader.Read
                id = reader("productcategoryid").ToString
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        Finally
            conn.Close()
        End Try
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM producttbl WHERE productcategoryid = '" & id & "'"
            Dim reader As MySqlDataReader

            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader

            ComboBox2.Items.Clear()
            While reader.Read
                ComboBox2.Items.Add(reader("productname").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub refreshcategory()
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim query As String = "SELECT * FROM productcategorytbl"
            Dim reader As MySqlDataReader

            comm.CommandText = query
            comm.Connection = conn
            reader = comm.ExecuteReader

            ComboBox1.Items.Clear()
            While reader.Read
                ComboBox1.Items.Add(reader("productcategoryname").ToString)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub ReportsProductSalesReportForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        refreshcategory()
        ComboBox1.SelectedIndex = 0
        refreshproduct(ComboBox1.SelectedItem.ToString)
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        refreshchart(ComboBox2.Text, ComboBox3.Text)
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        refreshchart(ComboBox2.Text, ComboBox3.Text)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        refreshchart(ComboBox2.Text, ComboBox3.Text)
        Label1.Text = "Product Sales Report: " & ComboBox2.Text
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        refreshproduct(ComboBox1.SelectedItem.ToString)
        ComboBox2.SelectedIndex = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(1200, 1200)
        Chart1.DrawToBitmap(bm, New Rectangle(0, 0, 1200, 1200))
        e.Graphics.DrawImage(bm, 100, 300)

        e.Graphics.DrawString("ACE Hardware", New Font("Arial", 20, FontStyle.Bold), Brushes.Black, New Point(300, 100))

        e.Graphics.DrawString(ComboBox2.Text, New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(355, 180))
        e.Graphics.DrawString(ComboBox3.Text, New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(375, 200))
        e.Graphics.DrawString("Sales Report", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(350, 220))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub
End Class