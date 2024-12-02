Public Class Login

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim conn As New Connection

        If type.Text = "None" Then
            MsgBox("Please Select Type")
        ElseIf type.Text = "Owner" Then
            Dim searchstring As String = "Select * FROM ownertbl WHERE name = '" & loginname.Text & "' AND password = '" & loginpassword.Text & "'"
            Dim login As Boolean
            login = (conn.login(searchstring))

            If login Then
                Me.Hide()
                Main.Show()
            End If
        ElseIf type.Text = "Employee" Then
            Dim searchstring As String = "Select * FROM employeetbl WHERE name = '" & loginname.Text & "' AND password = '" & loginpassword.Text & "'"
            Dim login As Boolean
            login = (conn.login(searchstring))

            If login Then
                Me.Hide()
                Main.Show()
            Else
            End If
        Else
            MsgBox("Please Choose Either Owner or Employee")
        End If

        conn.close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If type.Text = "Employee" Or type.Text = "Owner" Then
            Me.Hide()
            ChangePassword.Show()
        Else
            MsgBox("Please Choose the Type")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        type.SelectedIndex = 1
    End Sub
End Class
