Public Class PrintNCForm
    Dim connections As New Connections

    Private Sub PrintNCForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim connections As New Connections
        connections.PrintNCFormLoadExaminee(passedchk.Checked, failedchk.Checked)

        searchcbo.SelectedIndex = 0
    End Sub


    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchtxt.TextChanged
        If searchtxt.Text.Length = 0 Then
            connections.PrintNCFormLoadExaminee(passedchk.Checked, failedchk.Checked)
        Else
            Dim typeofsearch As String
            If searchcbo.Text = "First Name" Then
                typeofsearch = "firstname"
            ElseIf searchcbo.Text = "Last Name" Then
                typeofsearch = "surname"
            ElseIf searchcbo.Text = "Middle Name" Then
                typeofsearch = "middlename"
            Else
                MsgBox("No value for type of search")
                Exit Sub
            End If
            connections.PrintNCFormSearchExaminee(searchtxt.Text, typeofsearch, passedchk.Checked, failedchk.Checked)
        End If
    End Sub

    Private Sub failedchk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles failedchk.CheckedChanged
        If Not Me.passedchk.Checked Then
            failedchk.Checked = True
        End If

        'Dim connections As New Connections

        Dim typeofsearch As String
        If searchcbo.Text = "First Name" Then
            typeofsearch = "firstname"
        ElseIf searchcbo.Text = "Last Name" Then
            typeofsearch = "surname"
        ElseIf searchcbo.Text = "Middle Name" Then
            typeofsearch = "middlename"
        Else
            'MsgBox("No value for type of search")
            Exit Sub
        End If

        connections.PrintNCFormSearchExaminee(searchtxt.Text, typeofsearch, passedchk.Checked, failedchk.Checked)
    End Sub

    Private Sub passedchk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles passedchk.CheckedChanged
        If Not Me.failedchk.Checked Then
            passedchk.Checked = True
        End If

        'Dim connections As New Connections

        Dim typeofsearch As String
        If searchcbo.Text = "First Name" Then
            typeofsearch = "firstname"
        ElseIf searchcbo.Text = "Last Name" Then
            typeofsearch = "surname"
        ElseIf searchcbo.Text = "Middle Name" Then
            typeofsearch = "middlename"
        Else
            'MsgBox("No value for type of search")
            Exit Sub
        End If

        connections.PrintNCFormSearchExaminee(searchtxt.Text, typeofsearch, passedchk.Checked, failedchk.Checked)
    End Sub

    Private Sub DataGridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Click
        Try
            Dim idnum As String
            idnum = DataGridView1.CurrentRow.Cells(0).Value.ToString

            Dim connections As New Connections
            connections.PrintNCFormLoadExamineeInformation(idnum)
        Catch ex As Exception

        End Try
    End Sub
End Class