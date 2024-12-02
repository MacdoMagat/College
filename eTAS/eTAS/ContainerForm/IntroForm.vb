Public Class IntroForm

    Dim counter As Integer = 0

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.BackgroundImage.Dispose()
        If counter = 1 Then
            Me.BackgroundImage = My.Resources.ResourceManager.GetObject("2")
            counter = 2
            Button1.Enabled = True
            Button1.Visible = True
        ElseIf counter = 2 Then
            Me.BackgroundImage = My.Resources.ResourceManager.GetObject("3")
            counter = 3
        ElseIf counter = 3 Then
            Me.BackgroundImage = My.Resources.ResourceManager.GetObject("4")
            counter = 4
        ElseIf counter = 4 Then
            Me.BackgroundImage = My.Resources.ResourceManager.GetObject("5")
            counter = 5
        ElseIf counter = 5 Then
            Me.BackgroundImage = My.Resources.ResourceManager.GetObject("6")
            counter = 6
            Button2.Text = "Start"
        ElseIf counter = 6 Then
            ContainerForm.start()
        End If
    End Sub

    Private Sub IntroForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        counter = 1
        Button1.Enabled = False
        Button1.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.BackgroundImage.Dispose()
        If counter = 6 Then
            Me.BackgroundImage = My.Resources.ResourceManager.GetObject("5")
            counter = 5
            Button2.Text = "Next"
        ElseIf counter = 5 Then
            Me.BackgroundImage = My.Resources.ResourceManager.GetObject("4")
            counter = 4
        ElseIf counter = 4 Then
            Me.BackgroundImage = My.Resources.ResourceManager.GetObject("3")
            counter = 3
        ElseIf counter = 3 Then
            Me.BackgroundImage = My.Resources.ResourceManager.GetObject("2")
            counter = 2
        ElseIf counter = 2 Then
            Me.BackgroundImage = My.Resources.ResourceManager.GetObject("1")
            counter = 1
            Button1.Enabled = False
            Button1.Visible = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ContainerForm.start()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Select Case (MsgBox("Do you want to log out?", vbYesNo, "Confirm"))
            Case vbYes

            Case vbNo
                Exit Sub
            Case Else

        End Select
        ContainerForm.menuCategoryClicked(ContainerForm.btnLogout)

        ContainerForm.logoutclicked = True
        ContainerForm.userloggedout()

        If ContainerForm.loggedtype.Equals("Admin") Then
            eTASStartForm.adminbackclicked()
        ElseIf ContainerForm.loggedtype.Equals("Guest") Then
            eTASStartForm.guestbackclicked()
        Else
            eTASStartForm.adminbackclicked()
            eTASStartForm.guestbackclicked()
        End If
        ContainerForm.selectedmenu = 9
        ContainerForm.menuclicked()
        eTASStartForm.Show()
        ContainerForm.Dispose()
        ContainerForm.Close()
    End Sub
End Class