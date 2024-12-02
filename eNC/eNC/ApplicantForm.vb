Public Class ApplicantForm


    Private Sub addbtn_Click(sender As Object, e As EventArgs) Handles addbtn.Click
        MainForm.Panel1.Controls.Clear()
        MainForm.Panel1.Controls.Add(MainForm.applicant_newapplicationform)
        MainForm.applicant_newapplicationform.formload()
        MainForm.applicant_newapplicationform.Show()
    End Sub

    Private Sub viewbtn_Click(sender As Object, e As EventArgs) Handles viewbtn.Click
        MainForm.Panel1.Controls.Clear()
        MainForm.Panel1.Controls.Add(MainForm.applicant_viewrecordform)
        MainForm.applicant_viewrecordform.formload()
        MainForm.applicant_viewrecordform.Show()
    End Sub

    Private Sub printbtn_Click(sender As Object, e As EventArgs) Handles printbtn.Click
        MainForm.Panel1.Controls.Clear()
        MainForm.Panel1.Controls.Add(MainForm.applicant_printcertificateform)
        MainForm.applicant_printcertificateform.formload()
        MainForm.applicant_printcertificateform.Show()
    End Sub

    Private Sub addbtn_MouseHover(sender As Object, e As EventArgs) Handles addbtn.MouseHover
        addbtn.BackColor = Color.SkyBlue
    End Sub

    Private Sub addbtn_MouseLeave(sender As Object, e As EventArgs) Handles addbtn.MouseLeave
        addbtn.BackColor = Color.Gray
    End Sub

    Private Sub addbtn_MouseEnter(sender As Object, e As EventArgs) Handles addbtn.MouseEnter
        addbtn.BackColor = Color.SkyBlue
    End Sub

    Private Sub viewbtn_MouseHover(sender As Object, e As EventArgs) Handles viewbtn.MouseHover
        viewbtn.BackColor = Color.SkyBlue
    End Sub

    Private Sub viewbtn_MouseLeave(sender As Object, e As EventArgs) Handles viewbtn.MouseLeave
        viewbtn.BackColor = Color.Gray
    End Sub

    Private Sub viewbtn_MouseEnter(sender As Object, e As EventArgs) Handles viewbtn.MouseEnter
        viewbtn.BackColor = Color.SkyBlue
    End Sub

    Private Sub printbtn_MouseEnter(sender As Object, e As EventArgs) Handles printbtn.MouseEnter
        printbtn.BackColor = Color.SkyBlue
    End Sub

    Private Sub printbtn_MouseHover(sender As Object, e As EventArgs) Handles printbtn.MouseHover
        printbtn.BackColor = Color.SkyBlue
    End Sub

    Private Sub printbtn_MouseLeave(sender As Object, e As EventArgs) Handles printbtn.MouseLeave
        printbtn.BackColor = Color.Gray
    End Sub
End Class