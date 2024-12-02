Public Class RemoveThesisPasswordForm
    'Dim password As String = "Password"
    Private Sub btnProceed_Click(sender As Object, e As EventArgs) Handles btnProceed.Click
        'MsgBox(txtPassword.Text)
        If Not txtPassword.Text.Equals(ContainerForm.adminpassword) Then
            MsgBox("Incorrect Password")
            Exit Sub
        End If

        ContainerForm.removethesis.decisionContinue = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ContainerForm.removethesis.decisionContinue = False
        Me.Close()
    End Sub
End Class