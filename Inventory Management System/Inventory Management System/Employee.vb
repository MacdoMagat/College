Public Class Employee

    Private Sub Employee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New Connection
        conn.listemployeeid()
        cboemployeeid.Text = "Please Choose ID"
        conn.loademployee()
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub cboemployeeid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboemployeeid.SelectedIndexChanged
        Dim conn As New Connection
        Dim id As Integer
        id = cboemployeeid.Text
        clear()
        conn.refreshemployeedata(id)
        Button5.Enabled = True
        Button6.Enabled = True
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        AddEmployee.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        UpdateEmployee.Show()
    End Sub

    Public Sub clear()
        'cboemployeeid.Text = "Please Choose ID"
        employeename.Text = ""
        employeeaddress.Text = ""
        employeemobilephone.Text = ""
        employeehomephone.Text = ""
        employeepassword.Text = ""
        employeeconfirmpassword.Text = ""
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Dim conn As New Connection
            conn.deleteemployee(cboemployeeid.Text)
            cboemployeeid.Text = "Please Choose ID"
            clear()
            conn.loademployee()
            Button5.Enabled = False
            Button6.Enabled = False
        Catch ex As Exception
            MsgBox("Please Choose row")
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Main.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Login.Show()
        Login.type.Text = "None"
        Login.loginname.Text = ""
        Login.loginpassword.Text = ""
        Main.Close()
        Me.Close()
    End Sub


    Private Sub DataGridView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Click
        'MsgBox()
        cboemployeeid.Text = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(0).Value
    End Sub



    
End Class