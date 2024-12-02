Public Class AuditTrailForm
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel1.Controls.Clear()
        ContainerForm.audittrailtasks.changeConnstring(ContainerForm.departmentSelected)
        ContainerForm.audittrailtasks.loadTasks()
        Panel1.Controls.Add(ContainerForm.audittrailtasks)
        ContainerForm.audittrailtasks.Show()
        changeButtonColor()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Panel1.Controls.Clear()
        ContainerForm.audittraillogs.changeConnstring(ContainerForm.departmentSelected)
        ContainerForm.audittraillogs.reloadLogs()
        Panel1.Controls.Add(ContainerForm.audittraillogs)
        ContainerForm.audittraillogs.Show()
        changeButtonColor()
    End Sub


    Public Sub changeButtonColor()
        If ContainerForm.audittrail.Panel1.Controls(0).Name.ToString.Equals("AuditTrailLogsForm") Then
            Button1.ForeColor = Color.White
            Button1.BackColor = Color.FromArgb(255, 6, 69, 133)
            Button2.ForeColor = Color.FromArgb(255, 6, 69, 133)
            Button2.BackColor = Color.White
        ElseIf ContainerForm.audittrail.Panel1.Controls(0).Name.ToString.Equals("AuditTrailTasksForm") Then
            Button2.ForeColor = Color.White
            Button2.BackColor = Color.FromArgb(255, 6, 69, 133)
            Button1.ForeColor = Color.FromArgb(255, 6, 69, 133)
            Button1.BackColor = Color.White
        End If
    End Sub
End Class