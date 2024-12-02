Imports MySql.Data.MySqlClient

Public Class Applicant_PrintCertificateForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=tesda_db"
    Dim id As String

    Private Sub Applicant_PrintCertificateForm_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        Me.filtercbo.SelectedIndex = 0
        Me.searchtxt.Text = ""
        Me.passedchk.Checked = True
        Me.failedchk.Checked = True
        id = ""
        PrintPreviewControl1.Document = PrintDocument1

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

    Public Sub formloadfromviewrecord(initialid As String)
        Me.filtercbo.SelectedIndex = 0
        Me.searchtxt.Text = ""
        Me.passedchk.Checked = True
        Me.failedchk.Checked = True
        id = initialid
        PrintPreviewControl1.Document = PrintDocument1

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

    Private Sub filtercbo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles filtercbo.SelectedIndexChanged
        searchexaminee(searchtxt.Text, filtercbo.Text, passedchk.Checked, failedchk.Checked)
    End Sub

    Private Sub passedchk_Click(sender As Object, e As EventArgs) Handles passedchk.Click
        If Not failedchk.Checked Then
            passedchk.Checked = True
        End If
        searchexaminee(searchtxt.Text, filtercbo.Text, passedchk.Checked, failedchk.Checked)
    End Sub

    Private Sub failedchk_Click(sender As Object, e As EventArgs) Handles failedchk.Click
        If Not passedchk.Checked Then
            failedchk.Checked = True
        End If
        searchexaminee(searchtxt.Text, filtercbo.Text, passedchk.Checked, failedchk.Checked)
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            'Dim logo As Image = Image.FromFile("")

            conn.ConnectionString = connstring
            conn.Open()

            Dim query As String = "SELECT * FROM examinee_tbl WHERE id = " & id.ToString
            Dim reader As MySqlDataReader
            Dim comm As New MySqlCommand(query, conn)
            reader = comm.ExecuteReader

            While reader.Read

                'start of customizing document

                Dim stringformat As New StringFormat
                stringformat.Alignment = StringAlignment.Center
                stringformat.LineAlignment = StringAlignment.Center

                'Dim stringformatalignonly As New StringFormat
                'stringformat.Alignment = StringAlignment.Center

                'ung nasa taas tapat ng logo
                e.Graphics.DrawString("Republic of the Philippines", New Font("Arial", 12), New SolidBrush(Color.Black), New Rectangle(50, 30, 727, 20), stringformat)

                e.Graphics.DrawString("Department of Labor and Employment", New Font("Arial", 12), New SolidBrush(Color.Black), New Rectangle(50, 50, 727, 20), stringformat)

                e.Graphics.DrawString("TECHNICAL EDUCATION AND SKILLS DEVELOPMENT AUTHORITY", New Font("Arial", 12, FontStyle.Bold), New SolidBrush(Color.Black), New Rectangle(50, 70, 727, 20), stringformat)

                'for national certificate
                e.Graphics.DrawString("NATIONAL CERTIFICATE", New Font("Times New Roman", 30, FontStyle.Bold), New SolidBrush(Color.Green), New Rectangle(50, 150, 727, 150), stringformat)
                Dim rank As String
                If reader("qualification").ToString.Equals("National Certificate I") Then
                    rank = "I"
                ElseIf reader("qualification").ToString.Equals("National Certificate II") Then
                    rank = "II"
                ElseIf reader("qualification").ToString.Equals("National Certificate III") Then
                    rank = "III"
                ElseIf reader("qualification").ToString.Equals("National Certificate IV") Then
                    rank = "IV"
                Else
                    rank = ""
                End If

                'e.Graphics.FillRectangle(Brushes.Aqua, New Rectangle(650, 180, 50, 50))
                e.Graphics.DrawString(rank, New Font("Arial", 28), New SolidBrush(Color.Black), New Rectangle(670, 150, 50, 150), stringformat)

                'for middle one
                e.Graphics.DrawString("in", New Font("Arial", 10, FontStyle.Italic), New SolidBrush(Color.Black), New Rectangle(50, 200, 727, 150), stringformat)
                e.Graphics.DrawString("MASSAGE THERAPY", New Font("Arial", 20), New SolidBrush(Color.Black), New Rectangle(50, 250, 727, 150), stringformat)
                e.Graphics.DrawString("is awarded to", New Font("Arial", 10, FontStyle.Italic), New SolidBrush(Color.Black), New Rectangle(50, 300, 727, 150), stringformat)

                'for name
                'e.Graphics.FillRectangle(Brushes.Red, New Rectangle(50, 400, 727, 100))
                e.Graphics.DrawString(reader("surname").ToString & ", " & reader("firstname").ToString & " " & reader("middlename").ToString.Substring(0, 1) & ".", New Font("Arial", 25, FontStyle.Bold), New SolidBrush(Color.Black), New Rectangle(50, 400, 727, 100), stringformat)

                e.Graphics.DrawString("for having completed the competency requirements under the Philippine", New Font("Arial", 12, FontStyle.Italic), New SolidBrush(Color.Black), New Rectangle(50, 500, 727, 20), stringformat)
                e.Graphics.DrawString("TVET Competency Assessment and Certification System in the following", New Font("Arial", 12, FontStyle.Italic), New SolidBrush(Color.Black), New Rectangle(144, 520, 727, 20))
                e.Graphics.DrawString("units of competency:", New Font("Arial", 12, FontStyle.Italic), New SolidBrush(Color.Black), New Rectangle(144, 540, 727, 20))

                'ung competencies
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(100, 590, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(200, 590, 200, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(420, 590, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(520, 590, 200, 20))
                e.Graphics.DrawString("Unit Code", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(80, 590, 80, 20))
                e.Graphics.DrawString("BASIC COMPETENCIES", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(160, 590, 200, 20))
                e.Graphics.DrawString("Unit Code", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(420, 590, 80, 20))
                e.Graphics.DrawString("CORE COMPETENCIES", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(500, 590, 200, 20))

                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(100, 630, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(200, 630, 200, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(420, 630, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(520, 630, 200, 20))
                e.Graphics.DrawString("500311105", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(80, 630, 200, 20))
                e.Graphics.DrawString("Participate in workplace communication", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(160, 630, 400, 20))
                e.Graphics.DrawString("HCS322318", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(420, 630, 200, 20))
                e.Graphics.DrawString("Work within a holistic therapeutic massage framework", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(500, 630, 400, 20))

                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(100, 650, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(200, 650, 200, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(420, 650, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(520, 650, 200, 20))
                e.Graphics.DrawString("500311106", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(80, 650, 200, 20))
                e.Graphics.DrawString("Work in team environment", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(160, 650, 400, 20))
                e.Graphics.DrawString("HCS322319", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(420, 650, 200, 20))
                e.Graphics.DrawString("Perform therapeutic massage assessment", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(500, 650, 400, 20))

                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(100, 670, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(200, 670, 200, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(420, 670, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(520, 670, 200, 20))
                e.Graphics.DrawString("500311107", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(80, 670, 200, 20))
                e.Graphics.DrawString("Practice career professionalism", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(160, 670, 400, 20))
                e.Graphics.DrawString("HCS322320", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(420, 670, 200, 20))
                e.Graphics.DrawString("Plan the therapeutic massage treatment", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(500, 670, 400, 20))

                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(100, 690, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(200, 690, 200, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(420, 690, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(520, 690, 200, 20))
                e.Graphics.DrawString("500311108", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(80, 690, 200, 20))
                e.Graphics.DrawString("Practice occupational health and safety procedure", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(160, 690, 400, 20))
                e.Graphics.DrawString("HCS322321", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(420, 690, 200, 20))
                e.Graphics.DrawString("Implement therapeutic massage treatment", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(500, 690, 400, 20))

                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(420, 710, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(520, 710, 200, 20))
                e.Graphics.DrawString("HCS322322", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(420, 710, 200, 20))
                e.Graphics.DrawString("Perform remedial therapeutic massage treatment", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(500, 710, 400, 20))

                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(100, 750, 200, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(200, 750, 400, 20))
                e.Graphics.DrawString("Unit Code", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(80, 750, 200, 20))
                e.Graphics.DrawString("COMMON COMPETENCIES", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(160, 750, 400, 20))

                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(100, 770, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(200, 770, 200, 20))
                e.Graphics.DrawString("HCS323201", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(80, 770, 200, 20))
                e.Graphics.DrawString("Implement and monitor infection control policies and procedure", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(160, 770, 400, 20))

                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(100, 790, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(200, 790, 200, 20))
                e.Graphics.DrawString("HCS323202", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(80, 790, 200, 20))
                e.Graphics.DrawString("Respond effectively to difficult/challenging behavior", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(160, 790, 400, 20))

                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(100, 810, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(200, 810, 200, 20))
                e.Graphics.DrawString("HCS323203", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(80, 810, 200, 20))
                e.Graphics.DrawString("Apply basic first aid", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(160, 810, 400, 20))

                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(100, 830, 80, 20))
                'e.Graphics.FillRectangle(Brushes.Blue, New Rectangle(200, 830, 200, 20))
                e.Graphics.DrawString("HCS323204", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(80, 830, 200, 20))
                e.Graphics.DrawString("Maintain high standard of patient services", New Font("Arial", 8), New SolidBrush(Color.Black), New Rectangle(160, 830, 400, 20))

                'para sa signature
                e.Graphics.DrawString("Signature of the certificate holder", New Font("Arial", 12), New SolidBrush(Color.Black), New Rectangle(80, 900, 400, 20))
                e.Graphics.DrawString("Certificate No. ", New Font("Arial", 12), New SolidBrush(Color.Black), New Rectangle(80, 920, 400, 20))
                e.Graphics.DrawString(reader("certificate_number").ToString, New Font("Arial", 12, FontStyle.Bold), New SolidBrush(Color.Black), New Rectangle(200, 920, 200, 20))

                'date
                e.Graphics.DrawString("Issued on:", New Font("Arial", 12), New SolidBrush(Color.Black), New Rectangle(550, 900, 400, 20))
                e.Graphics.DrawString(Date.Now.ToString("MMMM dd, yyyy"), New Font("Arial", 12), New SolidBrush(Color.Black), New Rectangle(650, 900, 400, 20))
                e.Graphics.DrawString("Valid until:", New Font("Arial", 12), New SolidBrush(Color.Black), New Rectangle(550, 920, 400, 20))
                e.Graphics.DrawString(Date.Now.AddYears(5).ToString("MMMM dd, yyyy"), New Font("Arial", 12), New SolidBrush(Color.Black), New Rectangle(650, 920, 400, 20))

                'MsgBox(e.PageBounds.ToString)
            End While

        Catch ex As Exception
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub examineelistdgv_Click(sender As Object, e As EventArgs) Handles examineelistdgv.Click
        PrintPreviewControl1.Document = PrintDocument1
        id = Me.examineelistdgv.CurrentRow.Cells(3).Value.ToString
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PrintDialog1.Document = PrintDocument1
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainForm.Panel1.Controls.Clear()
        MainForm.Panel1.Controls.Add(MainForm.applicant_newapplicationform)
        MainForm.applicant_newapplicationform.formload()
        MainForm.applicant_newapplicationform.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MainForm.Panel1.Controls.Clear()
        MainForm.Panel1.Controls.Add(MainForm.applicant_viewrecordform)
        MainForm.applicant_viewrecordform.formload()
        MainForm.applicant_viewrecordform.Show()
    End Sub
End Class