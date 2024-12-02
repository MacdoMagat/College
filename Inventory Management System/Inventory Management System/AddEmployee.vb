Public Class AddEmployee

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim conn As New Connection
        Try
            If employeename.Text = "" Then
                MsgBox("Name must have a value")
                Exit Sub
            End If
            If employeeaddress.Text = "" Then
                MsgBox("Address must have a value")
                Exit Sub
            End If
            If employeemobilephone.Text = "" Then
                MsgBox("Mobile Phone must have a value")
                Exit Sub
            End If
            If employeehomephone.Text = "" Then
                MsgBox("Home Phone must have a value")
                Exit Sub
            End If
            If employeepassword.Text = "" Then
                MsgBox("Password must have a value")
                Exit Sub
            End If
            If employeeconfirmpassword.Text = "" Then
                MsgBox("Please retype your password")
                Exit Sub
            End If

            If employeepassword.Text.Equals(employeeconfirmpassword.Text) Then
                Dim name As String = employeename.Text
                Dim address As String = employeeaddress.Text
                Dim mobilephone As String = employeemobilephone.Text
                Dim homephone As String = employeehomephone.Text
                Dim password As String = employeepassword.Text
                conn.addemployee(name, address, mobilephone, homephone, password)
                Me.Close()
                Employee.Show()
                conn.loademployee()
                Employee.cboemployeeid.Text = "Please Choose ID"
                Employee.clear()
                Employee.Button5.Enabled = False
                Employee.Button6.Enabled = False
            Else
                MsgBox("Password does not match")

            End If
        Catch ex As Exception
            'MsgBox("Mobile or Home Number must not contain a letter")
            MsgBox(ex.ToString)
        End Try
        
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class