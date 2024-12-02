Imports MySql.Data.MySqlClient

Public Class TitleDatabaseForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Dim globalquery As String = ""

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


    Public Sub refreshThesisTitles(search As String, approve As Boolean, disapprove As Boolean, finished As Boolean)
        Dim query As String
        Dim first As Boolean = False 'First means may nauna nang WHERE, baka maulit

        query = "SELECT titletbl.title as Title, titlestatustbl.statusname as Status, titletbl.researchers, titletbl.yearSubmitted as Year FROM `titletbl` LEFT JOIN titlestatustbl ON titletbl.titlestatusid = titlestatustbl.titlestatusid"
        'LEFT JOIN categorytbl ON thesistbl.categoryid = categorytbl.categoryid
        If search = "" Then
            query = query
        Else
            If search.Contains(" ") Then
                Dim titlearray() As String = Split(search.Replace("'", "''"), " ")
                For i As Integer = 0 To titlearray.Length - 1
                    If i = 0 Then
                        query = query & " WHERE titletbl.title LIKE '%" & titlearray(i) & "%'"
                    Else
                        query = query & " AND titletbl.title LIKE '%" & titlearray(i) & "%'"
                    End If
                Next
            Else
                query = query & " WHERE titletbl.title LIKE '%" & search.Replace("'", "''") & "%'"
            End If
            first = True
        End If

        'SELECT * FROM `titletbl` WHERE titlestatusid not in (2) AND titlestatusid not in (1)
        If Not approve Then
            If first Then
                query = query & " AND titletbl.titlestatusid not in (1) "
            Else
                query = query & " WHERE titletbl.titlestatusid not in (1) "
                first = True
            End If
        End If

        If Not disapprove Then
            If first Then
                query = query & " AND titletbl.titlestatusid not in (2) "
            Else
                query = query & " WHERE titletbl.titlestatusid not in (2) "
                first = True
            End If
        End If

        If Not finished Then
            If first Then
                query = query & " AND titletbl.titlestatusid not in (3) "
            Else
                query = query & " WHERE titletbl.titlestatusid not in (3) "
                first = True
            End If
        End If

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim reader As MySqlDataReader

        comm.CommandText = query
        comm.Connection = conn
        reader = comm.ExecuteReader

        dtgThesisTitles.Rows.Clear()
        While (reader.Read)
            dtgThesisTitles.Rows.Add(reader("Title").ToString, reader("Status").ToString, reader("Year").ToString, reader("researchers").ToString.Replace("|", ", "))
        End While

        globalquery = query
        conn.Close()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        refreshThesisTitles(txtSearch.Text, chkApproved.Checked, chkDisapproved.Checked, chkFinished.Checked)
    End Sub

    Private Sub chkApproved_CheckedChanged(sender As Object, e As EventArgs) Handles chkApproved.CheckedChanged
        If Not dtgThesisTitles.ColumnCount = 0 Then
            refreshThesisTitles(txtSearch.Text, chkApproved.Checked, chkDisapproved.Checked, chkFinished.Checked)
        End If
    End Sub

    Private Sub chkDisapproved_CheckedChanged(sender As Object, e As EventArgs) Handles chkDisapproved.CheckedChanged
        If Not dtgThesisTitles.ColumnCount = 0 Then
            refreshThesisTitles(txtSearch.Text, chkApproved.Checked, chkDisapproved.Checked, chkFinished.Checked)
        End If
    End Sub

    Private Sub chkFinished_CheckedChanged(sender As Object, e As EventArgs) Handles chkFinished.CheckedChanged
        If Not dtgThesisTitles.ColumnCount = 0 Then
            refreshThesisTitles(txtSearch.Text, chkApproved.Checked, chkDisapproved.Checked, chkFinished.Checked)
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        TitleDatabaseAddEditForm.changeConnstring(ContainerForm.departmentSelected)
        TitleDatabaseAddEditForm.addClicked()
        TitleDatabaseAddEditForm.ShowDialog()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            TitleDatabaseAddEditForm.changeConnstring(ContainerForm.departmentSelected)
            TitleDatabaseAddEditForm.editClicked(dtgThesisTitles.CurrentRow.Cells(0).Value.ToString)
            TitleDatabaseAddEditForm.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dtgThesisTitles.CurrentRow.Cells(1).Value.ToString.Equals("Published") Then
            MsgBox("Cannot remove published title", vbOKOnly, "Published title")
            Exit Sub
        End If

        Select Case MsgBox("Remove this title [ " & dtgThesisTitles.CurrentRow.Cells(0).Value.ToString & " ]?", vbYesNo)
            Case vbYes
                Try

                    ContainerForm.executeTaskQuery("Title Database", "Removed title (" & dtgThesisTitles.CurrentRow.Cells(0).Value.ToString & ")")
                    conn.ConnectionString = connstring
                    conn.Open()

                    Dim comm As New MySqlCommand
                    comm.CommandText = "DELETE FROM `titletbl` WHERE title = '" & dtgThesisTitles.CurrentRow.Cells(0).Value.ToString.Replace("'", "''") & "'"
                    comm.Connection = conn
                    comm.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                Finally
                    conn.Close()
                    If Not dtgThesisTitles.ColumnCount = 0 Then
                        refreshThesisTitles(txtSearch.Text, chkApproved.Checked, chkDisapproved.Checked, chkFinished.Checked)
                    End If
                End Try
            Case vbNo

            Case Else

        End Select
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.titledatabasereport.changeConnstring(ContainerForm.departmentSelected)
        ContainerForm.Panel1.Controls.Add(ContainerForm.titledatabasereport)
        ContainerForm.titledatabasereport.refreshreport(globalquery)
        ContainerForm.titledatabasereport.Show()
        ContainerForm.executeTaskQuery("Title Database", "Created report of titles")
    End Sub
End Class