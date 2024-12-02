Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Imports Word = Microsoft.Office.Interop.Word
Public Class RetrieveThesisViewForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Dim thesispath As String
    Dim filename As String

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


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ViewThesisEditForm.changeConnstring(ContainerForm.departmentSelected)
        ViewThesisEditForm.formload(Label9.Text, Label10.Text)
        ViewThesisEditForm.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ''PrintDialog1.Document = PrintDocument1
        'If PrintDialog1.ShowDialog = DialogResult.OK Then
        '    PrintDocument1.Print()
        'End If
        Dim myprocess As New Process
        myprocess.StartInfo.CreateNoWindow = False
        myprocess.StartInfo.Verb = "print"
        myprocess.StartInfo.FileName = thesispath & ".pdf"
        myprocess.Start()
        myprocess.WaitForExit(10000)
        myprocess.CloseMainWindow()
        myprocess.Close()


        ContainerForm.executeTaskQuery("View Thesis", "Print a thesis (" & Label10.Text & ")")
    End Sub

    Public Sub viewthesis(selectedid As String)

        If Not ContainerForm.departmentSelected = "IT" Then
            Label5.Text = "Category"
        End If

        For Each con As FlowLayoutPanel In ContainerForm.topthesis.flpMain.Controls.OfType(Of FlowLayoutPanel)
            For Each cont As TableLayoutPanel In con.Controls.OfType(Of TableLayoutPanel)
                For Each contr As PictureBox In cont.Controls.OfType(Of PictureBox)
                    contr.Image.Dispose()
                Next
            Next
        Next
        If Not PictureBox1.Image Is Nothing Then PictureBox1.Image.Dispose()
        GC.Collect()

        Dim path As String

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM thesistbl LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid WHERE thesisid = " & selectedid
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        Dim researchers() As String
        Dim dateManipulator As Date

        While (reader.Read)
            thesispath = reader("thesispath").ToString
            path = reader("thesispath").ToString & ".pdf"
            If ContainerForm.loggedtype = "Guest" Then
                path = path & "#toolbar=0"
            End If
            'MsgBox(path)
            previewPDF.src = path
            Label9.Text = reader("thesisid").ToString
            Label10.Text = reader("thesistitle").ToString
            Label11.Text = reader("platformname").ToString
            dateManipulator = reader("datepublished").ToString
            lblDatePublished.Text = dateManipulator.Date.ToString("MMMM yyyy")
            researchers = Split(reader("researchername").ToString, "|")
            dateManipulator = reader("dateofsubmission").ToString
            Label14.Text = dateManipulator.Date.ToString("MMMM dd, yyyy")
            My.Computer.FileSystem.CopyFile(thesispath & ".jpg", Application.StartupPath & "\Others\tempImage.jpg", True)
            PictureBox1.Image = Image.FromFile(Application.StartupPath & "\Others\tempImage.jpg")
        End While
        Label13.Text = ""
        For i As Integer = 0 To researchers.Length - 1
            Label13.Text = Label13.Text & researchers(i).ToString & vbNewLine

        Next
        conn.Close()


        previewPDF.setShowToolbar(False)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim saveword As New SaveFileDialog
        saveword.Filter = "Word Document (*.docx)|*.docx"
        saveword.DefaultExt = "docx"
        saveword.FileName = Label10.Text
        saveword.OverwritePrompt = True
        If saveword.ShowDialog = DialogResult.OK Then
            My.Computer.FileSystem.CopyFile(thesispath & ".docx", saveword.FileName)
            MsgBox("File Successfully Retrieved")
        End If

        ContainerForm.executeTaskQuery("View Thesis", "Retrieved thesis as Word (" & Label10.Text & ")")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim saveword As New SaveFileDialog
        saveword.Filter = "PDF File (*.pdf)|*.pdf"
        saveword.DefaultExt = "pdf"
        saveword.FileName = Label10.Text
        saveword.OverwritePrompt = True
        If saveword.ShowDialog = DialogResult.OK Then
            My.Computer.FileSystem.CopyFile(thesispath & ".pdf", saveword.FileName)
            MsgBox("File Successfully Retrieved")
        End If

        ContainerForm.executeTaskQuery("View Thesis", "Retrieved thesis as PDF (" & Label10.Text & ")")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        PictureBox1.Image.Dispose()
        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.Panel1.Controls.Add(ContainerForm.viewthesis)
        ContainerForm.viewthesis.viewthesisload()
        ContainerForm.viewthesis.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        If Button6.Text = "Update Busy" Or BWUpdateFile.IsBusy Then
            Exit Sub
        End If
        Dim worddialog As New OpenFileDialog
        worddialog.Filter = "Word Document (*.docx)|*.docx"
        worddialog.DefaultExt = "docx"
        If worddialog.ShowDialog = DialogResult.OK Then
            Select Case (MsgBox("Are you sure you want to replace the old file", vbYesNo))
                Case vbYes
                    filename = worddialog.FileName
                    Button6.Text = "Update Busy"
                    BWUpdateFile.RunWorkerAsync()
                    'My.Computer.FileSystem.CopyFile(worddialog.FileName, Application.StartupPath.ToString & "\Documents\" & Label10.Text & ".docx", True)
                    'My.Computer.FileSystem.DeleteFile(Application.StartupPath.ToString & "\Documents\" & Label10.Text & ".pdf")
                    'Dim MyApp As New Word.Application
                    'Dim MyDoc As Word.Document = MyApp.Documents.Open(worddialog.FileName, False, True)
                    'Try
                    '    MyDoc.Activate()
                    '    MyDoc.SaveAs2(Application.StartupPath.ToString & "\Documents\" & Label10.Text & ".pdf", Word.WdSaveFormat.wdFormatPDF)
                    'Catch ex As Exception
                    '    MsgBox(ex.ToString)
                    'End Try
                    'MyDoc.Close()
                    'MyApp.Quit()

                    'If ContainerForm.loggedtype = "Guest" Then
                    '    previewPDF.src = Application.StartupPath.ToString & "\Documents\" & Label10.Text & ".pdf#toolbar=0"
                    'Else
                    '    previewPDF.src = Application.StartupPath.ToString & "\Documents\" & Label10.Text & ".pdf"
                    'End If

                    'MsgBox("File updated")
                Case vbNo

                Case Else
            End Select
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Dim picdialog As New OpenFileDialog
        picdialog.Filter = "Picture Files|*.jpg;*.png"
        If picdialog.ShowDialog = DialogResult.OK Then
            Select Case (MsgBox("Are you sure you want to replace the old picture", vbYesNo))
                Case vbYes
                    Try
                        'If PictureBox1.Image Is Nothing Then
                        'Else
                        '    PictureBox1.Image.Dispose()
                        'End If
                        For Each con As FlowLayoutPanel In ContainerForm.topthesis.flpMain.Controls.OfType(Of FlowLayoutPanel)
                            For Each cont As TableLayoutPanel In con.Controls.OfType(Of TableLayoutPanel)
                                For Each contr As PictureBox In cont.Controls.OfType(Of PictureBox)
                                    contr.Image.Dispose()
                                Next
                            Next
                        Next
                        PictureBox1.Image.Dispose()
                        GC.Collect()
                        My.Computer.FileSystem.CopyFile(picdialog.FileName, Application.StartupPath.ToString & "\Documents\" & Label10.Text & ".jpg", True)
                        PictureBox1.Image = Image.FromFile(Application.StartupPath.ToString & "\Documents\" & Label10.Text & ".jpg")
                        MsgBox("Photo Changed")
                    Catch ex As Exception
                        MsgBox("Try again changing later")
                        'MsgBox(ex.ToString)
                    End Try
                Case vbNo

                Case Else

            End Select

            'Label11.Text = picdialog.FileName
            'PictureBox1.Image = Image.FromFile(picdialog.FileName)
        End If
    End Sub

    Private Sub BWUpdateFile_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWUpdateFile.DoWork
        My.Computer.FileSystem.CopyFile(filename, Application.StartupPath.ToString & "\Documents\" & Label10.Text & ".docx", True)
        My.Computer.FileSystem.DeleteFile(Application.StartupPath.ToString & "\Documents\" & Label10.Text & ".pdf")
        Dim MyApp As New Word.Application
        Dim MyDoc As Word.Document = MyApp.Documents.Open(filename, False, True)
        Try
            MyDoc.Activate()
            MyDoc.SaveAs2(Application.StartupPath.ToString & "\Documents\" & Label10.Text & ".pdf", Word.WdSaveFormat.wdFormatPDF)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        MyDoc.Close()
        MyApp.Quit()



    End Sub

    Private Sub BWUpdateFile_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BWUpdateFile.RunWorkerCompleted
        If ContainerForm.loggedtype = "Guest" Then
            previewPDF.src = Application.StartupPath.ToString & "\Documents\" & Label10.Text & ".pdf#toolbar=0"
        Else
            previewPDF.src = Application.StartupPath.ToString & "\Documents\" & Label10.Text & ".pdf"
        End If

        Button6.Text = "Update File"
        MsgBox("File updated")
    End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    Me.Focus()
    'End Sub



    'Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
    '    previewPDF.Select()
    '    SendKeys.Send("^f")
    '    'SendKeys.Flush()
    '    SendKeys.Send("Gamitin")
    '    'SendKeys.Flush()
    '    SendKeys.Send("~")
    '    'SendKeys.SendWait("{ESCAPE 5}")
    '    'SendKeys.Flush()
    '    'previewPDF.Select()
    '    'SendKeys.Send("{ESCAPE}")
    '    'SendKeys.Flush()
    '    'SendKeys.Flush()
    '    'SendKeys.Flush()
    '    'SendKeys.SendWait("{ESC}")
    '    'SendKeys.Flush()
    'End Sub
End Class