Imports MySql.Data.MySqlClient

Public Class Applicant_NewApplicantForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=tesda_db"

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
    End Sub

    Private Sub dateofassessmentdtp_ValueChanged(sender As Object, e As EventArgs) Handles dateofassessmentdtp.ValueChanged
        Me.dateofassessmenttxt.Text = Me.dateofassessmentdtp.Value.Date.ToString("MM/dd/yyyy")
        Dim newdate As Date = Me.dateofassessmentdtp.Value.Date.AddYears(5)
        Me.expirationdatedtp.Value = newdate
    End Sub

    Private Sub expirationdatedtp_ValueChanged(sender As Object, e As EventArgs) Handles expirationdatedtp.ValueChanged
        Me.expirationdatetxt.Text = Me.expirationdatedtp.Value.Date.ToString("MM/dd/yyyy")
    End Sub

    Public Sub savedata(idno As String, lastname As String, firstname As String, middlename As String, address As String, schoolattended As String, qualification As String, assessor As String, assessmentcenter As String, status As String, certificatenumber As String, dateofassessment As String, expirationdate As String, competencies As String, controlnumber As String)
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim savequery As String = "INSERT INTO `examinee_tbl`(`id_no`, `surname`, `firstname`, `middlename`, `address`, `school_attended`, `qualification`, `assessor`, `assessment_center`, `status`, `certificate_number`, `date_of_assessment`, `expiration_date`, `competencies`, `control_number`, `signature_status`) VALUES ('" & idno & "','" & lastname & "','" & firstname & "','" & middlename & "','" & address & "','" & schoolattended & "','" & qualification & "','" & assessor & "','" & assessmentcenter & "','" & status & "','" & certificatenumber & "',STR_TO_DATE('" & dateofassessment & "','%m/%d/%Y'),STR_TO_DATE('" & expirationdate & "','%m/%d/%Y'),'" & competencies & "','" & controlnumber & "','Signed')"
            Dim comm As New MySqlCommand

            With comm
                .Connection = conn
                .CommandType = CommandType.Text
                .CommandText = savequery
                .ExecuteNonQuery()
            End With

            MsgBox("Added Successfully")

        Catch ex As Exception
            Select Case (MsgBox("An error has occcured. Want to view the error?", vbYesNo))
                Case vbYes : MsgBox(ex.ToString)
            End Select

        Finally
            conn.Close()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If identificationnotxt.Text = "" Then
            MsgBox("Please enter ID")
            Exit Sub
        End If
        If lastnametxt.Text = "" Then
            MsgBox("Please enter last name")
            Exit Sub
        End If
        If firstnametxt.Text = "" Then
            MsgBox("Please enter first name")
            Exit Sub
        End If
        If middlenametxt.Text = "" Then
            MsgBox("Please enter middle name")
            Exit Sub
        End If
        If addresstxt.Text = "" Then
            MsgBox("Please enter address")
            Exit Sub
        End If
        If schoolattendedtxt.Text = "" Then
            MsgBox("Please enter school attended")
            Exit Sub
        End If
        If qualificationtxt.Text = "" Then
            MsgBox("Please enter qualification")
            Exit Sub
        End If
        If assessortxt.Text = "" Then
            MsgBox("Please enter assessor")
            Exit Sub
        End If
        If assessmentcentertxt.Text = "" Then
            MsgBox("Please enter assessment center")
            Exit Sub
        End If
        If assessortxt.Text = "" Then
            MsgBox("Please enter assessor")
            Exit Sub
        End If
        If certificatenotxt.Text = "" Then
            MsgBox("Please enter certificate number")
            Exit Sub
        End If
        If competenciestxt.Text = "" Then
            MsgBox("Please enter competencies")
            Exit Sub
        End If
        If controlnumbertxt.Text = "" Then
            MsgBox("Please enter control number")
            Exit Sub
        End If
        With lastnametxt.Text
            If .Contains("0") Or .Contains("1") Or .Contains("2") Or .Contains("3") Or .Contains("4") Or .Contains("5") Or .Contains("6") Or .Contains("7") Or .Contains("8") Or .Contains("9") Then
                MsgBox("Last name must not contain number")
                Exit Sub
            End If
        End With
        With firstnametxt.Text
            If .Contains("0") Or .Contains("1") Or .Contains("2") Or .Contains("3") Or .Contains("4") Or .Contains("5") Or .Contains("6") Or .Contains("7") Or .Contains("8") Or .Contains("9") Then
                MsgBox("First name must not contain number")
                Exit Sub
            End If
        End With
        With middlenametxt.Text
            If .Contains("0") Or .Contains("1") Or .Contains("2") Or .Contains("3") Or .Contains("4") Or .Contains("5") Or .Contains("6") Or .Contains("7") Or .Contains("8") Or .Contains("9") Then
                MsgBox("Middle name must not contain number")
                Exit Sub
            End If
        End With
        With assessortxt.Text
            If .Contains("0") Or .Contains("1") Or .Contains("2") Or .Contains("3") Or .Contains("4") Or .Contains("5") Or .Contains("6") Or .Contains("7") Or .Contains("8") Or .Contains("9") Then
                MsgBox("Assessor must not contain number")
                Exit Sub
            End If
        End With
        If identificationnotxt.ForeColor = Color.Red Then
            MsgBox("Duplicate ID Number")
            Exit Sub
        End If
        savedata(identificationnotxt.Text, lastnametxt.Text, firstnametxt.Text, middlenametxt.Text, addresstxt.Text, schoolattendedtxt.Text, qualificationtxt.Text, assessortxt.Text, assessmentcentertxt.Text, statuscbo.Text, certificatenotxt.Text, dateofassessmenttxt.Text, expirationdatetxt.Text, competenciestxt.Text, controlnumbertxt.Text)
        formload()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MainForm.Panel1.Controls.Clear()
        MainForm.Panel1.Controls.Add(MainForm.applicant_viewrecordform)
        MainForm.applicant_newapplicationform.formload()
        MainForm.applicant_viewrecordform.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MainForm.Panel1.Controls.Clear()
        MainForm.Panel1.Controls.Add(MainForm.applicant_printcertificateform)
        MainForm.applicant_printcertificateform.formload()
        MainForm.applicant_printcertificateform.Show()
    End Sub

    Private Sub identificationnotxt_TextChanged(sender As Object, e As EventArgs) Handles identificationnotxt.TextChanged
        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim query As String = "SELECT * FROM examinee_tbl WHERE id_no = '" & identificationnotxt.Text & "'"
            Dim comm As New MySqlCommand
            Dim reader As MySqlDataReader
            comm.Connection = conn
            comm.CommandText = query
            reader = comm.ExecuteReader

            Dim count As Integer = 0
            While reader.Read
                count = count + 1
            End While

            If count = 0 Then
                identificationnotxt.ForeColor = Color.Black
            Else
                identificationnotxt.ForeColor = Color.Red
            End If

        Catch ex As Exception
            Select Case (MsgBox("An error has occcured. Want to view the error?", vbYesNo))
                Case vbYes : MsgBox(ex.ToString)
            End Select

        Finally
            conn.Close()
        End Try
    End Sub
End Class