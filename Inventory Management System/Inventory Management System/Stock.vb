Public Class Stock

    Private Sub Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New Connection
        conn.stocmainload()
    End Sub

    Private Sub mainlist_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainlist.SelectedIndexChanged
        Try
            Dim selected As String = mainlist.SelectedItem.ToString()
            Dim conn As New Connection
            conn.stockmainselected(selected)
            actuallist.Items.Clear()
            cleariteminformation()
            Button3.Enabled = True
            Button4.Enabled = False
            Button5.Enabled = False
            Button10.Enabled = False
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub sublist_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sublist.SelectedIndexChanged
        Try
            Dim selected As String = sublist.SelectedItem.ToString()
            Dim conn As New Connection
            conn.stocksubselected(selected)
            cleariteminformation()
            Button4.Enabled = True
            Button5.Enabled = False
            Button10.Enabled = False
        Catch
        End Try
    End Sub

    Private Sub actuallist_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles actuallist.SelectedIndexChanged
        Try
            Dim selected As String = actuallist.SelectedItem.ToString()
            Dim conn As New Connection
            conn.stockactualselected(selected)
            Button5.Enabled = True
            Button10.Enabled = True
        Catch

        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        AddItem.Show()
        AddItem.Label1.Text = "Add Item to Main Items"
        AddItem.TextBox2.Text = "main"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        AddItem.Show()
        AddItem.Label1.Text = "Add Item to Sub Items"
        AddItem.TextBox2.Text = "sub"
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        AddActualItem.Show()
    End Sub
    Public Sub cleariteminformation()
        itemname.Text = ""
        quantity.Text = ""
        unitprice.Text = ""
        totalprice.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Main.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Login.Show()
        Login.type.Text = "None"
        Login.loginname.Text = ""
        Login.loginpassword.Text = ""
        Main.Close()
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim conn As New Connection
            Dim olditemname As String = TextBox1.Text
            Dim newitemname As String = itemname.Text
            Dim iquantity As String = quantity.Text
            Dim iunitprice As String = unitprice.Text

            If CInt(iquantity) < 0 Or CInt(iquantity) = 0 Or CDbl(iunitprice) < 0 Or CDbl(iunitprice) = 0 Then
                MsgBox("Quantity or Unit Price must be positive")
                Exit Sub
            End If

            conn.stockupdateactual(olditemname, newitemname, iquantity, iunitprice)
            Dim selected As String = actuallist.SelectedItem.ToString()
            conn.stockactualselected(selected)
        Catch
            MsgBox("Quantity or Unit Price is not a valid Number")
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim conn As New Connection
        Dim selected As String = sublist.SelectedItem.ToString()

        Select Case (MsgBox("Are you sure?", vbYesNo))
            Case vbYes : conn.removeactualitem(TextBox2.Text)
                conn.stocksubselected(selected)
                cleariteminformation()
            Case vbNo
        End Select

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim conn As New Connection

        Select Case (MsgBox("Are you sure?", vbYesNo))
            Case vbYes : conn.removesubitem(sublist.SelectedItem.ToString, mainlist.SelectedItem.ToString)
                Dim selected As String = mainlist.SelectedItem.ToString()
                conn.stockmainselected(selected)
                cleariteminformation()
                actuallist.Items.Clear()
            Case vbNo
        End Select

        
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim conn As New Connection
        Select Case (MsgBox("Are you sure?", vbYesNo))
            Case vbYes : conn.removemainitem(mainlist.SelectedItem.ToString)
                conn.stocmainload()
                sublist.Items.Clear()
                actuallist.Items.Clear()
                Button3.Enabled = False
            Case vbNo
        End Select
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        AddQuantity.Show()
    End Sub
End Class