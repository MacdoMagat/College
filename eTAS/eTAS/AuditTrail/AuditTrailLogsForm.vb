Imports MySql.Data.MySqlClient

Public Class AuditTrailLogsForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Dim globalquery As String

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

    Public Sub reloadLogs()
        cbodate.SelectedIndex = 0
        cbotype.SelectedIndex = 0
        refreshdatagrid(txtname.Text, cbotype.Text, cbodate.Text)
    End Sub

    Public Sub refreshdatagrid(name As String, usertype As String, logdate As String)

        datagrid.Rows.Clear()

        Dim query As String = "SELECT logname as 'Name',loggedin as 'Logged In',loggedout as 'Logged Out' FROM logstbl WHERE usertype='" & usertype & "'"

        If Not name = "" Then
            query = query & " AND logname LIKE'%" & name.Replace("'", "''") & "%'"
        End If

        Dim tempdate As New Date
        tempdate = Now

        If logdate = "All" Then
            query = query
        ElseIf logdate = "Daily" Then
            query = query & "AND YEAR(loggedin)='" & tempdate.ToString("yyyy") & "' AND MONTH(loggedin)>='" & tempdate.ToString("MM") & "' AND DAY(loggedin)>='" & tempdate.ToString("dd") & "'"
        ElseIf logdate = "Weekly" Then
            tempdate = tempdate.AddDays(-6)
            query = query & "AND YEAR(loggedin)='" & tempdate.ToString("yyyy") & "' AND MONTH(loggedin)>='" & tempdate.ToString("MM") & " ' AND DAY(loggedin)>='" & tempdate.ToString("dd") & "'"
        ElseIf logdate = "Monthly" Then
            tempdate = tempdate.AddDays(-30)
            query = query & "AND YEAR(loggedin)='" & tempdate.ToString("yyyy") & "' AND MONTH(loggedin)>='" & tempdate.ToString("MM") & "'" ' AND DAY(loggedin)>='" & tempdate.ToString("dd") & "'"
        Else
            query = query
        End If

        query = query & " ORDER BY loggedin DESC"

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand
            Dim commstring As String = query
            Dim reader As MySqlDataReader
            comm.CommandText = commstring
            comm.Connection = conn
            reader = comm.ExecuteReader

            While (reader.Read)
                datagrid.Rows.Add(reader("Name").ToString, reader("Logged In").ToString, reader("Logged Out").ToString)
            End While

            globalquery = query

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub AuditTrailLogsForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        cbodate.SelectedIndex = 0
        cbotype.SelectedIndex = 0
        refreshdatagrid(txtname.Text, cbotype.Text, cbodate.Text)
    End Sub

    Private Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged
        refreshdatagrid(txtname.Text, cbotype.Text, cbodate.Text)
    End Sub

    Private Sub cbotype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbotype.SelectedIndexChanged
        refreshdatagrid(txtname.Text, cbotype.Text, cbodate.Text)
    End Sub

    Private Sub cbodate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbodate.SelectedIndexChanged
        refreshdatagrid(txtname.Text, cbotype.Text, cbodate.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ContainerForm.audittrail.Panel1.Controls.Clear()
        ContainerForm.audittraillogsreport.changeConnstring(ContainerForm.departmentSelected)
        ContainerForm.audittrail.Panel1.Controls.Add(ContainerForm.audittraillogsreport)
        ContainerForm.audittraillogsreport.refreshreport(globalquery)
        ContainerForm.audittraillogsreport.Show()

        ContainerForm.executeTaskQuery("Logs", "Created report on logs")
    End Sub
End Class