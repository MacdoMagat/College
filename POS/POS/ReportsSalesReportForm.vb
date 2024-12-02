Imports MySql.Data.MySqlClient

Public Class ReportsSalesReportForm
    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=pos"

    Public Sub refreshlist(condition As String)
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
                    Dim commstring As String = "SELECT SUM(sold) FROM `salestbl` WHERE DATE(dateandtime)='" & dailydate.ToString("yyyy-MM-dd") & "' GROUP BY dateandtime"
                    Dim reader As MySqlDataReader

                    comm.Connection = conn
                    comm.CommandText = commstring
                    reader = comm.ExecuteReader

                    While reader.Read
                        Chart1.Series("Sales").Points.AddXY(dailydate.ToString("yyyy-MM-dd"), CInt(reader("SUM(sold)").ToString))
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
                    Dim commstring As String = "SELECT SUM(sold) FROM `salestbl` WHERE YEAr(dateandtime)='" & dailydate.ToString("yyyy") & "' AND MONTH(dateandtime)='" & dailydate.ToString("MM") & "' GROUP BY dateandtime"
                    Dim reader As MySqlDataReader

                    comm.Connection = conn
                    comm.CommandText = commstring
                    reader = comm.ExecuteReader

                    Dim total As Double = 0
                    While reader.Read
                        total = total + CDbl(reader("SUM(sold)").ToString)
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
                    Dim commstring As String = "SELECT SUM(sold) FROM `salestbl` WHERE YEAr(dateandtime)='" & dailydate.ToString("yyyy") & "' GROUP BY dateandtime"
                    Dim reader As MySqlDataReader

                    comm.Connection = conn
                    comm.CommandText = commstring
                    reader = comm.ExecuteReader

                    Dim total As Double = 0
                    While reader.Read
                        total = total + CDbl(reader("SUM(sold)").ToString)
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

    Private Sub ReportsSalesReportForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ComboBox1.SelectedIndex = 0
        refreshlist(ComboBox1.Text)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        refreshlist(ComboBox1.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(1200, 1200)
        Chart1.DrawToBitmap(bm, New Rectangle(0, 0, 1200, 1200))
        e.Graphics.DrawImage(bm, 100, 300)

        e.Graphics.DrawString("ACE Hardware", New Font("Arial", 20, FontStyle.Bold), Brushes.Black, New Point(300, 100))

        e.Graphics.DrawString(ComboBox1.Text, New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(375, 200))
        e.Graphics.DrawString("Sales Report", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(350, 220))
    End Sub
End Class