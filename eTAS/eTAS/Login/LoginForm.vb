
Public Class LoginForm
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Application.Exit()
        eTASStartForm.reselectDepartment()
    End Sub

    Private Sub btnIT_Click(sender As Object, e As EventArgs) Handles btnIT.Click
        lblDept.Text = "IT"
        eTASStartForm.departmentSelected = "IT"
    End Sub

    Private Sub btnPA_Click(sender As Object, e As EventArgs) Handles btnPA.Click
        lblDept.Text = "PA"
        eTASStartForm.departmentSelected = "PA"
    End Sub

    Private Sub btnEntrep_Click(sender As Object, e As EventArgs) Handles btnEntrep.Click
        lblDept.Text = "Entrep"
        eTASStartForm.departmentSelected = "Entrep"
    End Sub
End Class