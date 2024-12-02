Public Class AddItem

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim conn As New Connection
        Dim itemtype As String = TextBox2.Text
        If itemtype.Equals("main") Then
            conn.stocmainload()
            Stock.actuallist.Items.Clear()
            Stock.sublist.Items.Clear()
            Stock.cleariteminformation()
        End If
        If itemtype.Equals("sub") Then
            conn.stockmainselected(Stock.mainlist.SelectedItem.ToString)
            Stock.cleariteminformation()
        End If
        Stock.actuallist.Items.Clear()
        Me.Close()
        Stock.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Please enter name")
        Else
            If TextBox2.Text = "main" Then
                Dim counter As Integer = 0
                While counter < Stock.mainlist.Items.Count
                    If TextBox1.Text = Stock.mainlist.Items(counter).ToString Then
                        MsgBox("Name already exist")
                        Exit Sub
                    End If
                    counter = counter + 1
                End While
            End If
            If TextBox2.Text = "sub" Then
                Dim counter As Integer = 0
                While counter < Stock.sublist.Items.Count
                    If TextBox1.Text = Stock.sublist.Items(counter).ToString Then
                        MsgBox("Name already exist")
                        Exit Sub
                    End If
                    counter = counter + 1
                End While
            End If
            Dim conn As New Connection
            Dim itemname As String = TextBox1.Text
            Dim itemtype As String = TextBox2.Text
            If itemtype.Equals("main") Then
                conn.stockadditem(itemname, itemtype, "")
            ElseIf itemtype.Equals("sub") Then
                conn.stockadditem(itemname, itemtype, Stock.mainlist.SelectedItem.ToString)
            End If
        End If

    End Sub

End Class