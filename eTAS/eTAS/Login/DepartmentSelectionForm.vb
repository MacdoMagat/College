Public Class DepartmentSelectionForm
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub btnIT_Click(sender As Object, e As EventArgs) Handles btnIT.Click
        eTASStartForm.departmentSelected = "IT"
        eTASStartForm.departmentClicked()
    End Sub

    Private Sub btnPA_Click(sender As Object, e As EventArgs) Handles btnPA.Click
        eTASStartForm.departmentSelected = "PA"
        eTASStartForm.departmentClicked()
    End Sub

    Private Sub btnEntrep_Click(sender As Object, e As EventArgs) Handles btnEntrep.Click
        eTASStartForm.departmentSelected = "Entrep"
        eTASStartForm.departmentClicked()
    End Sub
End Class