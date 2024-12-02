Public Class POSPayReportForm
    Dim total As Double
    Dim cash As Double
    Dim change As Double
    Private Sub POSPayReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        total = POSForm.Label4.Text
        Label2.Text = total
        PrintPreviewControl1.Document = PrintDocument1
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim stringformat As New StringFormat
        stringformat.Alignment = StringAlignment.Center
        stringformat.LineAlignment = StringAlignment.Center

        e.Graphics.DrawString("ACE Hardware", New Font("Arial", 20, FontStyle.Bold), Brushes.Black, New Point(315, 100))
        e.Graphics.DrawString("Product Name", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(75, 200))
        e.Graphics.DrawString("Quantity", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(600, 200))
        e.Graphics.DrawString("Price", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(700, 200))
        'MsgBox(e.PageBounds.Width & ", " & e.PageBounds.Height)
        Dim x As Integer = 75
        Dim y As Integer = 230
        For i As Integer = 0 To POSForm.DataGridView1.Rows.Count - 2
            e.Graphics.DrawString(POSForm.DataGridView1.Rows(i).Cells(0).Value.ToString, New Font("Arial", 12), Brushes.Black, New Point(x, y))
            x = x + 525
            e.Graphics.DrawString(POSForm.DataGridView1.Rows(i).Cells(1).Value.ToString, New Font("Arial", 12), Brushes.Black, New Point(x, y))
            x = x + 100
            e.Graphics.DrawString(POSForm.DataGridView1.Rows(i).Cells(2).Value.ToString, New Font("Arial", 12), Brushes.Black, New Point(x, y))
            x = x - 625
            y = y + 20
        Next
        y = y + 10
        e.Graphics.DrawString("Total", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(75, y))
        e.Graphics.DrawString(Label2.Text, New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(700, y))
        y = y + 20
        e.Graphics.DrawString("Cash", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(75, y))
        e.Graphics.DrawString(Label6.Text, New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(700, y))
        y = y + 20
        e.Graphics.DrawString("Change", New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(75, y))
        e.Graphics.DrawString(Label5.Text, New Font("Arial", 12, FontStyle.Bold), Brushes.Black, New Point(700, y))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PrintDialog1.Document = PrintDocument1
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.Print()

            POSForm.purchaseconfirmed()
            POSForm.Label4.Text = 0
            POSForm.Label6.Text = 0
            POSForm.TextBox1.Text = 0
            POSForm.DataGridView1.Rows.Clear()
            POSForm.Button4.Enabled = False
            Me.Dispose()
        End If
    End Sub

    'Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
    'If TextBox1.Text = "" Then
    '    TextBox1.Text = 0
    'End If
    'Try
    '    cash = TextBox1.Text
    'TextBox1.Text = cash
    'Catch ex As Exception
    '    MsgBox("Cash Paid must be numbers")
    'Exit Sub
    'End Try
    'change = cash - total
    'Label5.Text = change
    'If change < 0 Then
    '  Button1.Enabled = False
    'Else
    '      Button1.Enabled = True
    '  End If
    '  PrintPreviewControl1.Document = PrintDocument1
    ' End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub
End Class