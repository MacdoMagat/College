Imports MySql.Data.MySqlClient

Public Class Applicant_ViewRecord

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=tesda_db"
    Dim id As String


    Private Sub Applicant_ViewRecord_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.filtercbo.SelectedIndex = 0
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Me.examineelistdgv.Rows.Clear()

            Dim comm As New MySqlCommand

            Dim selectquery As String


            selectquery = "SELECT id_no, CONCAT(surname,', ',firstname,' ',middlename) as name, status,id FROM examinee_tbl"

            comm.CommandText = selectquery
            comm.Connection = conn

            Dim reader As MySqlDataReader
            reader = comm.ExecuteReader

            While reader.Read
                Me.examineelistdgv.Rows.Add(reader("id_no"), reader("name"), reader("status"), reader("id"))
            End While
        Catch ex As Exception
            Select Case (MsgBox("An error has occcured. Want to view the error?", vbYesNo))
                Case vbYes : MsgBox(ex.ToString)
            End Select
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub formload()
        Me.identificationnotxt.Text = ""
        Me.lastnametxt.Text = ""
        Me.firstnametxt.Text = ""
        Me.middlenametxt.Text = ""
        Me.addresstxt.Text = ""
        Me.schoolattendedtxt.Text = ""
        Me.qualificationtxt.Text = ""
        Me.assessortxt.Text = ""
        Me.assessmentcentertxt.Text = ""
        Me.statuscbo.SelectedIndex = 0
        Me.certificatenotxt.Text = ""
        'Me.dateofassessmenttxt.Text = ""
        Me.dateofassessmentdtp.Value = Date.Now
        'Me.expirationdatetxt.Text = ""
        'Me.expirationdatedtp.Value = ""
        Me.competenciestxt.Text = ""
        Me.controlnumbertxt.Text = ""
        Me.searchtxt.Text = ""
        Me.failedchk.Checked = True
        Me.passedchk.Checked = True
        Me.filtercbo.SelectedIndex = 0
        id = ""
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Me.examineelistdgv.Rows.Clear()

            Dim comm As New MySqlCommand

            Dim selectquery As String


            selectquery = "SELECT id_no, CONCAT(surname,', ',firstname,' ',middlename) as name, status,id FROM examinee_tbl"

            comm.CommandText = selectquery
            comm.Connection = conn

            Dim reader As MySqlDataReader
            reader = comm.ExecuteReader

            While reader.Read
                Me.examineelistdgv.Rows.Add(reader("id_no"), reader("name"), reader("status"), reader("id"))
            End While
        Catch ex As Exception
            Select Case (MsgBox("An error has occcured. Want to view the error?", vbYesNo))
                Case vbYes : MsgBox(ex.ToString)
            End Select
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub searchexaminee(searchstring As String, searchtype As String, passed As Boolean, failed As Boolean)

        Try
            Dim stype As String
            If searchtype.Equals("Last Name") Then
                stype = "surname"
            ElseIf searchtype.Equals("First Name") Then
                stype = "firstname"
            ElseIf searchtype.Equals("Middle Name") Then
                stype = "middlename"
            Else
                stype = "surname"
            End If

            Me.examineelistdgv.Rows.Clear()

            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand

            Dim selectquery
            If passed And failed Then
                selectquery = "SELECT id_no, CONCAT(surname,', ',firstname,' ',middlename,'.') as name,status, id FROM examinee_tbl where " & stype & " LIKE '%" & searchstring & "%'"
            ElseIf passed And Not failed Then
                selectquery = "SELECT id_no, CONCAT(surname,', ',firstname,' ',middlename,'.') as name,status, id FROM examinee_tbl where " & stype & " LIKE '%" & searchstring & "%' AND status = 'Passed'"
            ElseIf Not passed And failed Then
                selectquery = "SELECT id_no, CONCAT(surname,', ',firstname,' ',middlename,'.') as name,status, id FROM examinee_tbl where " & stype & " LIKE '%" & searchstring & "%' AND status = 'Failed'"
            Else
                selectquery = "SELECT id_no, CONCAT(surname,', ',firstname,' ',middlename,'.') as name,status, id FROM examinee_tbl where " & stype & " LIKE '%" & searchstring & "%'"
            End If



            comm.CommandText = selectquery
            comm.Connection = conn

            Dim reader As MySqlDataReader
            reader = comm.ExecuteReader

            While reader.Read
                Me.examineelistdgv.Rows.Add(reader("id_no"), reader("name"), reader("status"), reader("id"))
            End While
        Catch ex As Exception
            Select Case (MsgBox("An error has occcured. Want to view the error?", vbYesNo))
                Case vbYes : MsgBox(ex.ToString)
            End Select
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub searchtxt_TextChanged(sender As Object, e As EventArgs) Handles searchtxt.TextChanged
        searchexaminee(searchtxt.Text, filtercbo.Text, passedchk.Checked, failedchk.Checked)
    End Sub

    'Private Sub passedchk_CheckedChanged(sender As Object, e As EventArgs) Handles passedchk.CheckedChanged
    'If Not failedchk.Checked Then
    '       passedchk.Checked = True
    'End If
    '   searchexaminee(searchtxt.Text, filtercbo.Text, passedchk.Checked, failedchk.Checked)
    ' End Sub

    ' Private Sub failedchk_CheckedChanged(sender As Object, e As EventArgs) Handles failedchk.CheckedChanged
    'If Not passedchk.Checked Then
    '        failedchk.Checked = True
    'End If
    '     searchexaminee(searchtxt.Text, filtercbo.Text, passedchk.Checked, failedchk.Checked)
    ' End Sub

    Private Sub filtercbo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles filtercbo.SelectedIndexChanged
        searchexaminee(searchtxt.Text, filtercbo.Text, passedchk.Checked, failedchk.Checked)
    End Sub

    Private Sub examineelistdgv_Click(sender As Object, e As EventArgs) Handles examineelistdgv.Click
        Try
            conn.ConnectionString = connstring
            conn.Open()
            Dim comm As New MySqlCommand
            Dim reader As MySqlDataReader
            Dim query As String = "SELECT * FROM examinee_tbl WHERE id_no = '" & Me.examineelistdgv.CurrentRow.Cells(0).Value.ToString & "'"
            comm.Connection = conn
            comm.CommandText = query
            reader = comm.ExecuteReader
            id = Me.examineelistdgv.CurrentRow.Cells(3).Value.ToString
            While reader.Read
                identificationnotxt.Text = reader("id_no").ToString
                lastnametxt.Text = reader("surname").ToString
                firstnametxt.Text = reader("firstname").ToString
                middlenametxt.Text = reader("middlename").ToString
                addresstxt.Text = reader("address").ToString
                schoolattendedtxt.Text = reader("school_attended").ToString
                qualificationtxt.Text = reader("qualification").ToString
                assessortxt.Text = reader("assessor").ToString
                assessmentcentertxt.Text = reader("assessment_center").ToString
                If reader("status").ToString.Equals("Passed") Then
                    statuscbo.SelectedIndex = 0
                Else
                    statuscbo.SelectedIndex = 1
                End If
                certificatenotxt.Text = reader("certificate_number").ToString
                Dim doa As Date = reader("date_of_assessment")
                dateofassessmentdtp.Value = doa
                'dateofassessmenttxt.Text = doa.ToString("MM/dd/yyyy")
                Dim expdate As Date = reader("expiration_date")
                expirationdatedtp.Value = expdate
                'expirationdatetxt.Text = expdate.ToString("MM/dd/yyyy")
                competenciestxt.Text = reader("competencies").ToString
                controlnumbertxt.Text = reader("control_number").ToString
            End While
        Catch ex As Exception
            Select Case (MsgBox("An error has occcured. Want to view the error?", vbYesNo))
                Case vbYes : MsgBox(ex.ToString)
            End Select
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles dateofassessmentdtp.ValueChanged
        Me.dateofassessmenttxt.Text = Me.dateofassessmentdtp.Value.Date.ToString("MM/dd/yyyy")
        Dim newdate As Date = Me.dateofassessmentdtp.Value.Date.AddYears(5)
        Me.expirationdatedtp.Value = newdate
    End Sub

    Private Sub expirationdatedtp_ValueChanged(sender As Object, e As EventArgs) Handles expirationdatedtp.ValueChanged
        Me.expirationdatetxt.Text = Me.expirationdatedtp.Value.Date.ToString("MM/dd/yyyy")
    End Sub

    Private Sub updatebtn_Click(sender As Object, e As EventArgs) Handles updatebtn.Click
        Try
            conn.ConnectionString = connstring
            conn.Open()
            Dim comm As New MySqlCommand
            Dim updatestring As String = "UPDATE `examinee_tbl` SET `id_no`='" & identificationnotxt.Text & "',`surname`='" & lastnametxt.Text & "',`firstname`='" & firstnametxt.Text & "',`middlename`='" & middlenametxt.Text & "',`address`='" & addresstxt.Text & "',`school_attended`='" & schoolattendedtxt.Text & "',`qualification`='" & qualificationtxt.Text & "',`assessor`='" & assessortxt.Text & "',`assessment_center`='" & assessmentcentertxt.Text & "',`status`='" & statuscbo.Text & "',`certificate_number`='" & certificatenotxt.Text & "',`date_of_assessment`=STR_TO_DATE('" & dateofassessmenttxt.Text & "','%m/%d/%Y'),`expiration_date`=STR_TO_DATE('" & expirationdatetxt.Text & "','%m/%d/%Y'),`competencies`='" & competenciestxt.Text & "',`control_number`='" & controlnumbertxt.Text & "' WHERE id = " & id.ToString
            With comm
                .CommandType = CommandType.Text
                .CommandText = updatestring
                .Connection = conn
                .ExecuteNonQuery()
            End With
            MsgBox("Data Updated")
        Catch ex As Exception
            Select Case (MsgBox("An error has occcured. Want to view the error?", vbYesNo))
                Case vbYes : MsgBox(ex.ToString)
            End Select
        Finally
            conn.Close()
            searchexaminee(searchtxt.Text, filtercbo.Text, passedchk.Checked, failedchk.Checked)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainForm.Panel1.Controls.Clear()
        MainForm.Panel1.Controls.Add(MainForm.applicant_newapplicationform)
        MainForm.applicant_newapplicationform.formload()
        MainForm.applicant_newapplicationform.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MainForm.Panel1.Controls.Clear()
        MainForm.Panel1.Controls.Add(MainForm.applicant_printcertificateform)
        If id.Equals("") Then
            MainForm.applicant_printcertificateform.formload()
        Else
            MainForm.applicant_printcertificateform.formloadfromviewrecord(id)
        End If

        MainForm.applicant_printcertificateform.Show()
    End Sub

    Private Sub failedchk_Click(sender As Object, e As EventArgs) Handles failedchk.Click
        If Not passedchk.Checked Then
            failedchk.Checked = True
        End If
        searchexaminee(searchtxt.Text, filtercbo.Text, passedchk.Checked, failedchk.Checked)
    End Sub

    Private Sub passedchk_Click(sender As Object, e As EventArgs) Handles passedchk.Click
        If Not failedchk.Checked Then
            passedchk.Checked = True
        End If
        searchexaminee(searchtxt.Text, filtercbo.Text, passedchk.Checked, failedchk.Checked)
    End Sub
End Class