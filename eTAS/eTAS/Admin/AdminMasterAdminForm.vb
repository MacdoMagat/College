Imports MySql.Data.MySqlClient

Public Class AdminMasterAdminForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"

    Public Sub changeConnstring(department As String)
        If department.Equals("IT") Then
            connstring = "Server=localhost;User Id=root;Password=;Database=etas"
        ElseIf department.Equals("PA") Then
            connstring = "Server=localhost;User Id=root;Password=;Database=etaspa"
        ElseIf department.Equals("Entrep") Then
            connstring = "Server=localhost;User Id=root;Password=;Database=etasentrep"
        Else
            connstring = "Server=localhost;User Id=root;Password=;Database=etas"
        End If
    End Sub

    Public Sub RefreshDataGrid()
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim commstring As String = "SELECT * FROM admintbl WHERE admintype = 'Normal'"
            Dim reader As MySqlDataReader
            comm.CommandText = commstring
            comm.Connection = conn
            reader = comm.ExecuteReader

            DataGridView1.Rows.Clear()

            While (reader.Read)
                DataGridView1.Rows.Add(reader("adminid").ToString, reader("adminfirstname").ToString & " " & reader("adminmiddlename").ToString & " " & reader("adminlastname").ToString, reader("adminusername").ToString, reader("adminpassword").ToString)
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        AdminMasterAdminAddForm.changeConnstring(ContainerForm.departmentSelected)
        AdminMasterAdminAddForm.addClicked()
        AdminMasterAdminAddForm.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Try
            AdminMasterAdminAddForm.changeConnstring(ContainerForm.departmentSelected)
            AdminMasterAdminAddForm.editClicked(DataGridView1.CurrentRow.Cells(0).Value.ToString)
            AdminMasterAdminAddForm.ShowDialog()
        Catch ex As Exception
            MsgBox("Please select an admin account first")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnMyAccount.Click
        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.admin.changeConnstring(ContainerForm.departmentSelected)
        ContainerForm.admin.loadfields()
        ContainerForm.Panel1.Controls.Add(ContainerForm.admin)
        ContainerForm.admin.Show()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try

            Dim id As Integer = DataGridView1.CurrentRow.Cells(0).Value.ToString
            Select Case MsgBox("Are you sure you want to remove " & DataGridView1.CurrentRow.Cells(1).Value.ToString & " as Admin?", vbYesNo, "Axtaris")
                Case vbYes
                    ContainerForm.executeTaskQuery("Admin", "Deleted admin (" & DataGridView1.CurrentRow.Cells(1).Value.ToString & ")")
                    conn.ConnectionString = connstring
                    conn.Open()
                    Dim comm As New MySqlCommand
                    comm.CommandText = "DELETE FROM `admintbl` WHERE `admintbl`.`adminid` = " & id
                    comm.Connection = conn
                    comm.ExecuteNonQuery()

                Case vbNo
                Case Else
            End Select
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
            RefreshDataGrid()
        End Try

    End Sub
End Class