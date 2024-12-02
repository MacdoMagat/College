Imports MySql.Data.MySqlClient
Public Class AuditTrailTasksForm

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


    Public Sub refreshdatagrid(name As String, usertype As String, logdate As String, category As String)

        If usertype Is Nothing Or logdate Is Nothing Or category Is Nothing Then
            Exit Sub
        End If

        datagrid.Rows.Clear()

        Dim query As String = "SELECT logname as 'Name',taskcategory as 'Category',taskdescription as 'Description',taskdate as 'Date' FROM taskstbl WHERE (usertype='" & usertype & "'"
        If usertype = "Admin" Then
            query = query & " OR usertype='Master') "
        Else
            query = query & ") "
        End If
        If Not name = "" Then
            query = query & " AND logname LIKE'%" & name.Replace("'", "''") & "%' "
        End If

        Dim tempdate As New Date
        tempdate = Now

        If logdate = "All" Then
            query = query
        ElseIf logdate = "Daily" Then
            query = query & "AND YEAR(taskdate)='" & tempdate.ToString("yyyy") & "' AND MONTH(taskdate)>='" & tempdate.ToString("MM") & "' AND DAY(taskdate)>='" & tempdate.ToString("dd") & "'"
        ElseIf logdate = "Weekly" Then
            tempdate = tempdate.AddDays(-6)
            query = query & "AND YEAR(taskdate)='" & tempdate.ToString("yyyy") & "' AND MONTH(taskdate)>='" & tempdate.ToString("MM") & "' AND DAY(taskdate)>='" & tempdate.ToString("dd") & "'"
        ElseIf logdate = "Monthly" Then
            tempdate = tempdate.AddDays(-30)
            query = query & "AND YEAR(taskdate)='" & tempdate.ToString("yyyy") & "' AND MONTH(taskdate)>='" & tempdate.ToString("MM") & "'" ' AND DAY(taskdate)>='" & tempdate.ToString("dd") & "'"
        Else
            query = query
        End If

        If Not category.Equals("All") Then
            query = query & " AND taskcategory = '" & category & "'"
        End If

        query = query & " ORDER BY taskdate DESC"

        conn.ConnectionString = connstring
        conn.Open()

            Dim comm As New MySqlCommand
        Dim reader As MySqlDataReader
        comm.CommandText = query
        comm.Connection = conn
            reader = comm.ExecuteReader

        Dim dateManipulator As DateTime

        While (reader.Read)
            dateManipulator = reader("Date").ToString
            datagrid.Rows.Add(reader("Name").ToString, reader("Category").ToString, reader("Description").ToString, dateManipulator.ToString("MMMM dd, yyyy hh:mm:ss"))
        End While

            globalquery = query


        conn.Close()

    End Sub

    Private Sub AuditTrailTasksForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        fillCategoryCbo()
        cboCategory.SelectedIndex = 0
        cbodate.SelectedIndex = 0
        cbotype.SelectedIndex = 0
        refreshdatagrid(txtname.Text, cbotype.Text, cbodate.Text, cboCategory.Text)
    End Sub


    Public Sub reloadTasks()
        refreshdatagrid(txtname.Text, cbotype.Text, cbodate.Text, cboCategory.Text)
    End Sub

    Public Sub loadTasks()
        fillCategoryCbo()
        cboCategory.SelectedIndex = 0
        cbodate.SelectedIndex = 0
        cbotype.SelectedIndex = 0
        refreshdatagrid(txtname.Text, cbotype.Text, cbodate.Text, cboCategory.Text)
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        refreshdatagrid(txtname.Text, cbotype.Text, cbodate.Text, cboCategory.Text)
    End Sub



    Public Sub fillCategoryCbo()



        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim reader As MySqlDataReader
        comm.CommandText = "SELECT DISTINCT(taskcategory) FROM `taskstbl`"
        comm.Connection = conn
        reader = comm.ExecuteReader
        cboCategory.Items.Clear()
        cboCategory.Items.Add("All")
        While (reader.Read)
            cboCategory.Items.Add(reader("taskcategory").ToString)
        End While

        conn.Close()
    End Sub


    Private Sub txtname_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged
        refreshdatagrid(txtname.Text, cbotype.Text, cbodate.Text, cboCategory.Text)
    End Sub

    Private Sub cbotype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbotype.SelectedIndexChanged
        refreshdatagrid(txtname.Text, cbotype.Text, cbodate.Text, cboCategory.Text)
    End Sub

    Private Sub cbodate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbodate.SelectedIndexChanged
        refreshdatagrid(txtname.Text, cbotype.Text, cbodate.Text, cboCategory.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'AuditTrailTasksReportForm.refreshreport(globalquery)
        'AuditTrailTasksReportForm.Show()
        ContainerForm.audittrail.Panel1.Controls.Clear()
        ContainerForm.audittrailtasksreport.changeConnstring(ContainerForm.departmentSelected)
        ContainerForm.audittrail.Panel1.Controls.Add(ContainerForm.audittrailtasksreport)
        ContainerForm.audittrailtasksreport.refreshreport(globalquery)
        ContainerForm.audittrailtasksreport.Show()

        ContainerForm.executeTaskQuery("Logs", "Created report on tasks")

    End Sub
End Class