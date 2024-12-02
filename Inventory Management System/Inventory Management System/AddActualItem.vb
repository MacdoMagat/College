Public Class AddActualItem

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try

            Dim counter As Integer = 0
            While counter < Stock.actuallist.Items.Count
                If TextBox1.Text = Stock.actuallist.Items(counter).ToString Then
                    MsgBox("Name already exist")
                    Exit Sub
                End If
                counter = counter + 1
            End While

            Dim itemname As String = TextBox1.Text
            Dim itembelonged As String = Stock.sublist.SelectedItem.ToString()
            Dim quantity As Integer = TextBox2.Text
            Dim unitprice As Integer = TextBox3.Text
            Dim conn As New Connection

            If unitprice < 0 Or unitprice = 0 Or quantity < 0 Or quantity = 0 Then
                MsgBox("Unit Price or Quantity must be positive numbers")
                Exit Sub
            End If

            conn.stockaddactual(itemname, itembelonged, quantity, unitprice)

            Dim selected As String = Stock.sublist.SelectedItem.ToString()
            conn.stocksubselected(selected)
            Stock.cleariteminformation()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        Catch
            MsgBox("Quantity or Unit Price not number")
        End Try
    End Sub
End Class