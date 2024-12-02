Public Class AboutForm
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        If ContainerForm.contentsearch.TextBox2.Visible = True Then
            ContainerForm.contentsearch.TextBox2.Visible = False
        Else
            ContainerForm.contentsearch.TextBox2.Visible = True
        End If

    End Sub
End Class