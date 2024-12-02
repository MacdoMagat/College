Public Class AddQuantity

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim conn As New Connection
            'Dim olditemname As String = TextBox1.Text
            Dim newitemname As String = Stock.itemname.Text
            Dim iquantity As String = Stock.quantity.Text
            Dim iunitprice As String = Stock.unitprice.Text
            Dim add As Integer = CInt(TextBox1.Text)
            Dim newquantity As Integer = iquantity + add

            If add > 0 Then

                conn.stockupdateactual(newitemname, newitemname, newquantity, iunitprice)
                Dim selected As String = Stock.actuallist.SelectedItem.ToString()
                conn.stockactualselected(selected)

                Me.Close()
                Stock.Show()

            Else
                MsgBox("Please enter only positive number")
            End If

        Catch
            MsgBox("Quantity is not Number")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class