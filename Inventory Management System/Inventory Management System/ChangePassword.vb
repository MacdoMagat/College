Public Class ChangePassword

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Main.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim conn As New Connection
        Dim updatequery As String
        Dim type As String = Login.type.Text
        Dim name As String = cpname.Text
        Dim updatesuccess As Boolean

        If cpoldpassword.Text = "" Then
            MsgBox("Please input your old password")
            Exit Sub
        End If
        If cpnewpassword.Text = "" Then
            MsgBox("Please type your new password")
            Exit Sub
        End If
        If cpconfirmpassword.Text = "" Then
            MsgBox("Please retype your new password")
            Exit Sub
        End If

        If cpnewpassword.Text.Equals(cpconfirmpassword.Text) Then
            If cpoldpassword.Text.Equals(Main.pass.Text) Then
                If Login.type.Text = "Owner" Then
                    updatequery = "UPDATE ownertbl SET password = '" & cpnewpassword.Text & "' WHERE name = '" & cpname.Text & "'"
                    updatesuccess = conn.changepassword(updatequery, type, name)
                ElseIf Login.type.Text = "Employee" Then
                    updatequery = "UPDATE employeetbl SET password = '" & cpnewpassword.Text & "' WHERE name = '" & cpname.Text & "'"
                    updatesuccess = conn.changepassword(updatequery, type, name)
                Else
                    MsgBox("Error")
                End If
            Else
                MsgBox("Old Password Incorrect")
            End If
        Else
            MsgBox("Password does not match")
        End If

        If updatesuccess Then
            Main.pass.Text = cpnewpassword.Text
            Me.Close()
            Main.Show()
        End If
    End Sub

    Private Sub ChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cpname.Text = Main.username.Text
    End Sub
End Class