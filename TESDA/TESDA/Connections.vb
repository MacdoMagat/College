Imports MySql.Data.MySqlClient

Public Class Connections

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=tesda_db"

    Public Sub connect()
        conn.ConnectionString = connstring
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub

    Public Sub close()
        conn.Close()
    End Sub

    Public Sub PrintNCFormLoadExaminee(ByVal passed As Boolean, ByVal failed As Boolean)
        connect()

        PrintNCForm.DataGridView1.Rows.Clear()

        Dim comm As New MySqlCommand

        Dim selectquery As String

        If passed And failed Then
            selectquery = "SELECT id_no, CONCAT(surname,', ',firstname,' ',middlename) as name, status FROM examinee_tbl"
        ElseIf passed And Not failed Then
            selectquery = "SELECT id_no, CONCAT(surname,', ',firstname,' ',middlename) as name, status FROM examinee_tbl WHERE status = 'Passed'"
        ElseIf Not passed And failed Then
            selectquery = "SELECT id_no, CONCAT(surname,', ',firstname,' ',middlename) as name, status FROM examinee_tbl WHERE status = 'Failed'"
        Else
            selectquery = "SELECT id_no, CONCAT(surname,', ',firstname,' ',middlename) as name, status FROM examinee_tbl"
        End If
        comm.CommandText = selectquery
        comm.Connection = conn

        Dim reader As MySqlDataReader
        reader = comm.ExecuteReader

        While reader.Read
            PrintNCForm.DataGridView1.Rows.Add(reader("id_no"), reader("name"), reader("status"))
        End While

        close()

    End Sub

    Public Sub PrintNCFormSearchExaminee(ByVal searchstring As String, ByVal searchtype As String, ByVal passed As Boolean, ByVal failed As Boolean)
        connect()

        PrintNCForm.DataGridView1.Rows.Clear()

        Dim comm As New MySqlCommand

        Dim selectquery
        If passed And failed Then
            selectquery = "SELECT id_no, CONCAT(surname,', ',firstname,' ',middlename,'.') as name,status FROM examinee_tbl where " & searchtype & " LIKE '%" & searchstring & "%'"
        ElseIf passed And Not failed Then
            selectquery = "SELECT id_no, CONCAT(surname,', ',firstname,' ',middlename,'.') as name,status FROM examinee_tbl where " & searchtype & " LIKE '%" & searchstring & "%' AND status = 'Passed'"
        ElseIf Not passed And failed Then
            selectquery = "SELECT id_no, CONCAT(surname,', ',firstname,' ',middlename,'.') as name,status FROM examinee_tbl where " & searchtype & " LIKE '%" & searchstring & "%' AND status = 'Failed'"
        Else
            selectquery = "SELECT id_no, CONCAT(surname,', ',firstname,' ',middlename,'.') as name,status FROM examinee_tbl where " & searchtype & " LIKE '%" & searchstring & "%'"
        End If



        comm.CommandText = selectquery
        comm.Connection = conn

        Dim reader As MySqlDataReader
        reader = comm.ExecuteReader

        While reader.Read
            PrintNCForm.DataGridView1.Rows.Add(reader("id_no"), reader("name"), reader("status"))
        End While

        close()
    End Sub

    Public Sub PrintNCFormLoadExamineeInformation(ByVal idnum As String)
        connect()

        Dim comm As New MySqlCommand
        Dim reader As MySqlDataReader
        Dim query As String = "SELECT * FROM examinee_tbl WHERE id_no = '" & idnum & "'"
        comm.Connection = conn
        comm.CommandText = query
        reader = comm.ExecuteReader

        While reader.Read
            PrintNCForm.idnumberlbl.Text = reader("id_no").ToString
            PrintNCForm.surnamelbl.Text = reader("surname").ToString
            PrintNCForm.firstnamelbl.Text = reader("firstname").ToString
            PrintNCForm.middlenamelbl.Text = reader("middlename").ToString
            PrintNCForm.addresslbl.Text = reader("address").ToString
            PrintNCForm.schoolattendedlbl.Text = reader("school_attended").ToString
            PrintNCForm.qualificationlbl.Text = reader("qualification").ToString
            PrintNCForm.assessorlbl.Text = reader("assessor").ToString
            PrintNCForm.assessmentcenterlbl.Text = reader("assessment_center").ToString
            PrintNCForm.statuslbl.Text = reader("status").ToString
            PrintNCForm.certificatenumberlbl.Text = reader("certificate_number").ToString
            PrintNCForm.dateofassessmentlbl.Text = reader("date_of_assessment").ToString
            PrintNCForm.expirationdatelbl.Text = reader("expiration_date").ToString
            PrintNCForm.competencieslbl.Text = reader("competencies").ToString
            PrintNCForm.controlnumberlbl.Text = reader("control_number").ToString

            PrintNCForm.CertificateNamelbl.Text = reader("surname").ToString & ", " & reader("firstname").ToString & " " & reader("middlename").ToString.Substring(0, 1) & "."
        End While

        close()
    End Sub

    Public Sub AddFormAddInformation(ByVal id_no As String, ByVal surname As String, ByVal firstname As String, ByVal middlename As String, ByVal address As String, ByVal school_attended As String, ByVal qualification As String, ByVal assessor As String, ByVal assessment_center As String, ByVal status As String, ByVal certificate_number As Integer, ByVal date_of_assessment As String, ByVal expiration_date As String, ByVal competencies As String, ByVal control_number As Integer)
        connect()

        Dim comm As New MySqlCommand
        Dim savequery As String = "INSERT INTO `examinee_tbl`(`id_no`, `surname`, `firstname`, `middlename`, `address`, `school_attended`, `qualification`, `assessor`, `assessment_center`, `status`, `certificate_number`, `date_of_assessment`, `expiration_date`, `competencies`, `control_number`, `signature_status`) VALUES ('" & id_no & "', '" & surname & "', '" & firstname & "', '" & middlename & "', '" & address & "', '" & school_attended & "', '" & qualification & "', '" & assessor & "', '" & assessment_center & "', '" & status & "', " & certificate_number & ", STR_TO_DATE('" & date_of_assessment & "','%m/%d/%Y'), STR_TO_DATE('" & expiration_date & "','%m/%d/%Y'), '" & competencies & "', " & control_number & ", 'Unsigned')"

        comm.CommandText = savequery
        comm.CommandType = CommandType.Text
        comm.Connection = conn
        comm.ExecuteNonQuery()

        MsgBox("Saved")

        close()
    End Sub

End Class
