Public Class MainForm

    Dim homeform As New HomeForm
    Dim applicantform As New ApplicantForm
    Public applicant_newapplicationform As New Applicant_NewApplicantForm
    Public applicant_printcertificateform As New Applicant_PrintCertificateForm
    Public applicant_viewrecordform As New Applicant_ViewRecord
    Dim reportsform As New ReportsForm
    Dim aboutform As New AboutForm
    Dim adminform As New AdminForm

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim form1 As New HomeForm
        homeform.TopLevel = False
        homeform.Dock = DockStyle.Fill
        applicantform.TopLevel = False
        applicantform.Dock = DockStyle.Fill
        applicant_newapplicationform.TopLevel = False
        applicant_newapplicationform.Dock = DockStyle.Fill
        applicant_printcertificateform.TopLevel = False
        applicant_printcertificateform.Dock = DockStyle.Fill
        applicant_viewrecordform.TopLevel = False
        applicant_viewrecordform.Dock = DockStyle.Fill
        reportsform.TopLevel = False
        reportsform.Dock = DockStyle.Fill
        aboutform.TopLevel = False
        aboutform.Dock = DockStyle.Fill
        adminform.TopLevel = False
        adminform.Dock = DockStyle.Fill

        Me.Panel1.Controls.Add(homeform)
        homeform.Show()
    End Sub

    Private Sub homebtn_Click(sender As Object, e As EventArgs) Handles homebtn.Click
        Me.Panel1.Controls.Clear()
        'Dim form1 As New HomeForm
        'homeform.TopLevel = False
        'homeform.Dock = DockStyle.Fill
        Me.Panel1.Controls.Add(homeform)
        homeform.Show()
    End Sub

    Private Sub applicantbtn_Click(sender As Object, e As EventArgs) Handles applicantbtn.Click
        'Me.Panel1.Controls.Clear()
        'Me.Panel1.Dispose()
        'Me.Panel1.Refresh()
        'Me.Panel1.Controls("form1").Dispose()
        'Dim form1 As New ApplicantForm
        'form1.TopLevel = False
        'form1.Dock = DockStyle.Fill
        'Me.Panel1.Controls.Add(form1)
        'form1.Show()
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(applicantform)
        applicantform.Show()
    End Sub

    Private Sub reportsbtn_Click(sender As Object, e As EventArgs) Handles reportsbtn.Click
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(reportsform)
        reportsform.Show()
    End Sub

    Private Sub aboutbtn_Click(sender As Object, e As EventArgs) Handles aboutbtn.Click
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(aboutform)
        aboutform.Show()
    End Sub

    Private Sub MainForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        LoginForm.Close()
    End Sub

    Private Sub adminbtn_Click(sender As Object, e As EventArgs) Handles adminbtn.Click
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(adminform)
        adminform.Show()
    End Sub
End Class
