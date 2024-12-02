Imports MySql.Data.MySqlClient

Public Class ContainerForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Public departmentSelected As String

    Public homeform As New HomeForm
    Public retrievethesis As New RetrieveThesisForm
    Public retrievethesisview As New RetrieveThesisViewForm
    Public archivethesis As New ArchiveThesisForm
    Public viewthesis As New ViewThesis
    Public contentsearch As New ContentSearchForm
    'Public topthesis As New TopThesisForm
    Public topthesis As New TopThesisSelectionTwoForm
    Public contentsearchpick As New ContentSearchPickForm
    Public admin As New AdminForm
    Public intro As New IntroForm
    Public audittrail As New AuditTrailForm
    Public audittraillogs As New AuditTrailLogsForm
    Public masteradmin As New AdminMasterAdminForm
    Public titledatabase As New TitleDatabaseForm

    Public audittrailtasks As New AuditTrailTasksForm
    Public audittrailtasksreport As New AuditTrailTasksReportForm
    Public audittraillogsreport As New AuditTrailReportForm
    Public titledatabasereport As New TitleDatabaseReportForm
    Public thesisreport As New ViewThesisReportForm
    Public contentsearchpickhighlight As New ContentSearchPickHighlightForm
    Public spellingnandgrammarcheck As New SpellingAndGrammarCheckForm
    Public contentsearchhighlight As New ContentSearchHighlightForm
    Public about As New AboutForm
    Public removethesis As New RemoveThesisForm

    Dim selectedfont As New Font("Century Gothic", 12, FontStyle.Bold)
    Dim unselectedfont As New Font("Century Gothic", 12)
    Dim unselectedbackcolor As Color = Color.Transparent
    Dim unselectedforecolor As Color = Color.White
    Dim selectedbackcolor As Color = ColorTranslator.FromHtml("#f7e041") 'Color.Yellow
    Dim selectedforecolor As Color = ColorTranslator.FromHtml("#064585") 'Color.Blue
    'Maganda ang Style nung nabaliktad
    'Me.BackColor = ColorTranslator.FromHtml("#003399")
    'Blue Color = #064585
    'Yellow Color = #f7e041


    Dim ftop, fleft, fwidth, fheight As Integer

    Public selectedmenu As Integer = 1
    Public logoutclicked As Boolean = False
    Public loggedid As String = ""
    Public loggedtype As String = ""
    Public loggedname As String = ""
    'Guest or Admin
    Public adminusername As String = ""
    Public adminpassword As String = ""
    Public admintype As String = ""

    Dim opacitycontrol As Integer = 0

    Public contentsearchCategoryFilter As String = "All"
    Public contentsearchtype As Integer = 1
    '1 for Match Case, 2 for Single Word Difference, 3 for Five Words Interval, 4 for All Words Traversal
    '1 is default

    Private Sub ParentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load '

        ftop = Me.Top
        fleft = Me.Left
        fwidth = Me.Width
        fheight = Me.Height
        'MsgBox(ftop & " " & fleft & " " & fwidth & " " & fheight)
        Me.Bounds = Screen.GetWorkingArea(Me)

        homeform.TopLevel = False
        homeform.Dock = DockStyle.Fill
        retrievethesis.TopLevel = False
        retrievethesis.Dock = DockStyle.Fill
        retrievethesisview.TopLevel = False
        retrievethesisview.Dock = DockStyle.Fill
        archivethesis.TopLevel = False
        archivethesis.Dock = DockStyle.Fill
        viewthesis.TopLevel = False
        viewthesis.Dock = DockStyle.Fill
        contentsearch.TopLevel = False
        contentsearch.Dock = DockStyle.Fill
        topthesis.TopLevel = False
        topthesis.Dock = DockStyle.Fill
        contentsearchpick.TopLevel = False
        contentsearchpick.Dock = DockStyle.Fill
        admin.TopLevel = False
        admin.Dock = DockStyle.Fill
        audittrail.TopLevel = False
        audittrail.Dock = DockStyle.Fill
        audittraillogs.TopLevel = False
        audittraillogs.Dock = DockStyle.Fill
        intro.TopLevel = False
        intro.Dock = DockStyle.Fill
        masteradmin.TopLevel = False
        masteradmin.Dock = DockStyle.Fill
        titledatabase.TopLevel = False
        titledatabase.Dock = DockStyle.Fill

        audittrailtasksreport.TopLevel = False
        audittrailtasksreport.Dock = DockStyle.Fill
        audittrailtasks.TopLevel = False
        audittrailtasks.Dock = DockStyle.Fill
        audittraillogsreport.TopLevel = False
        audittraillogsreport.Dock = DockStyle.Fill
        titledatabasereport.TopLevel = False
        titledatabasereport.Dock = DockStyle.Fill
        thesisreport.TopLevel = False
        thesisreport.Dock = DockStyle.Fill
        contentsearchpickhighlight.TopLevel = False
        contentsearchpickhighlight.Dock = DockStyle.Fill
        spellingnandgrammarcheck.TopLevel = False
        spellingnandgrammarcheck.Dock = DockStyle.Fill
        contentsearchhighlight.TopLevel = False
        contentsearchhighlight.Dock = DockStyle.Fill
        about.TopLevel = False
        about.Dock = DockStyle.Fill
        removethesis.TopLevel = False
        removethesis.Dock = DockStyle.Fill

        btnHome.BackColor = selectedbackcolor
        btnHome.ForeColor = selectedforecolor
        btnHome.Font = selectedfont

        logoutclicked = False

        TableLayoutPanel1.ColumnStyles(0).Width = 0
        For Each cont As Control In TableLayoutPanel2.Controls
            cont.Enabled = False
        Next

        Panel1.Controls.Add(intro)
        intro.Show()

        'Panel1.Controls.Add(homeform)
        'homeform.Show()
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Panel1.Controls.Clear()
    '    Panel1.Controls.Add(retrievethesis)
    '    retrievethesis.retrievethesisformclicked()
    '    retrievethesis.Show()
    'End Sub


    Public Sub menuCategoryClicked(buttonClicked As Button)

        'MsgBox(buttonClicked.Text.ToString)
        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        comm.Connection = conn
        comm.CommandType = CommandType.Text

        Dim sql As String = ""

        If loggedtype = "Admin" Then
            If admintype.Equals("Master") Then
                sql = "INSERT INTO `taskstbl`(`taskcategory`, `taskdescription`, `logname`, `usertype`, `taskdate`) VALUES ('Menu','Clicked " & buttonClicked.Text.ToString.Replace("&&", "And") & " button','" & loggedname & "','" & admintype & "',NOW())"
            Else
                sql = "INSERT INTO `taskstbl`(`taskcategory`, `taskdescription`, `logname`, `usertype`, `taskdate`) VALUES ('Menu','Clicked " & buttonClicked.Text.ToString.Replace("&&", "And") & " button','" & loggedname & "','Admin',NOW())"
            End If
        ElseIf loggedtype = "Guest" Then
            sql = "INSERT INTO `taskstbl`(`taskcategory`, `taskdescription`, `logname`, `usertype`, `taskdate`) VALUES ('Menu','Clicked " & buttonClicked.Text.ToString.Replace("&&", "And") & " button','" & loggedname & "','Guest',NOW())"
        Else
            sql = "INSERT INTO `taskstbl`(`taskcategory`, `taskdescription`, `logname`, `usertype`, `taskdate`) VALUES ('Menu','Clicked " & buttonClicked.Text.ToString.Replace("&&", "And") & " button','" & loggedname & "','Guest',NOW())"
        End If
        comm.CommandText = sql
        comm.ExecuteNonQuery()
        conn.Close()
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        menuCategoryClicked(btnHome)
        selectedmenu = 1
        menuclicked()
        Panel1.Controls.Clear()
        Panel1.Controls.Add(homeform)
        homeform.Focus()
        homeform.Show()

    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Select Case (MsgBox("Do you want to log out?", vbYesNo, "Confirm"))
            Case vbYes

            Case vbNo
                Exit Sub
            Case Else

        End Select
        menuCategoryClicked(btnLogout)

        logoutclicked = True
        userloggedout()

        If loggedtype.Equals("Admin") Then
            eTASStartForm.adminbackclicked()
        ElseIf loggedtype.Equals("Guest") Then
            eTASStartForm.guestbackclicked()
        Else
            eTASStartForm.adminbackclicked()
            eTASStartForm.guestbackclicked()
        End If
        selectedmenu = 9
        menuclicked()
        eTASStartForm.Show()
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnArchiveThesis.Click
        menuCategoryClicked(btnArchiveThesis)
        selectedmenu = 2
        menuclicked()
        Panel1.Controls.Clear()
        Panel1.Controls.Add(archivethesis)
        archivethesis.changeConnstring(departmentSelected)
        archivethesis.archivethesisload()
        archivethesis.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnViewThesis.Click
        menuCategoryClicked(btnViewThesis)
        selectedmenu = 3
        menuclicked()


        If retrievethesisview.PictureBox1.Image Is Nothing Then
        Else
            retrievethesisview.PictureBox1.Image.Dispose()
        End If



        For Each con As FlowLayoutPanel In topthesis.flpMain.Controls.OfType(Of FlowLayoutPanel)
            For Each cont As TableLayoutPanel In con.Controls.OfType(Of TableLayoutPanel)
                For Each contr As PictureBox In cont.Controls.OfType(Of PictureBox)
                    contr.Image.Dispose()
                Next
            Next
        Next

        Panel1.Controls.Clear()
        viewthesis.changeConnstring(departmentSelected)
        Panel1.Controls.Add(viewthesis)
        viewthesis.viewthesisload()
        viewthesis.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnContentSearch.Click
        menuCategoryClicked(btnContentSearch)
        selectedmenu = 4
        menuclicked()
        Panel1.Controls.Clear()
        Panel1.Controls.Add(contentsearch)
        contentsearch.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnTopThesis.Click
        If retrievethesisview.PictureBox1.Image Is Nothing Then
        Else
            retrievethesisview.PictureBox1.Image.Dispose()
        End If
        For Each con As FlowLayoutPanel In topthesis.flpMain.Controls.OfType(Of FlowLayoutPanel)
            For Each cont As TableLayoutPanel In con.Controls.OfType(Of TableLayoutPanel)
                For Each contr As PictureBox In cont.Controls.OfType(Of PictureBox)
                    contr.Image.Dispose()
                Next
            Next
        Next
        'For Each con As Control In topthesis.flpMain.Controls
        '    con.Dispose()
        'Next
        GC.Collect()
        menuCategoryClicked(btnTopThesis)
        selectedmenu = 5
        menuclicked()
        Panel1.Controls.Clear()
        'topthesis.updatecomboboxes()
        topthesis.changeConnstring(departmentSelected)
        Panel1.Controls.Add(topthesis)
        topthesis.loadTopTheses()
        topthesis.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        menuCategoryClicked(btnAdmin)
        selectedmenu = 7
        menuclicked()
        Panel1.Controls.Clear()
        If admintype = "Master" Then
            masteradmin.changeConnstring(departmentSelected)
            masteradmin.RefreshDataGrid()
            Panel1.Controls.Add(masteradmin)
            masteradmin.Show()
        Else
            admin.changeConnstring(departmentSelected)
            admin.loadfields()
            Panel1.Controls.Add(admin)
            admin.Show()
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        menuCategoryClicked(btnAbout)
        selectedmenu = 8
        menuclicked()
        Panel1.Controls.Clear()
        Panel1.Controls.Add(about)
        about.Show()


        'experiment
        'MsgBox(TableLayoutPanel1.ColumnStyles(0).Width.ToString)

        'Select Case MsgBox("Run experiment codes?", vbYesNo)
        '    Case vbYes : Panel1.Controls.Clear()
        '        If TableLayoutPanel1.ColumnStyles(0).Width.ToString >= 200 Then
        '            'Panel1.Controls(0).Dock = DockStyle.None
        '            leftnavcloseanimation.Enabled = True
        '            'TableLayoutPanel1.ColumnStyles(0).Width = 30
        '        End If
        '    Case Else

        'End Select


    End Sub

    Private Sub Button6_MouseHover(sender As Object, e As EventArgs) Handles btnHome.MouseHover
        btnHome.BackColor = selectedbackcolor
        btnHome.ForeColor = selectedforecolor
        btnHome.Font = selectedfont
    End Sub

    Private Sub btnHome_MouseLeave(sender As Object, e As EventArgs) Handles btnHome.MouseLeave
        If Not selectedmenu = 1 Then
            btnHome.BackColor = unselectedbackcolor
            btnHome.ForeColor = unselectedforecolor
            btnHome.Font = unselectedfont
        End If
    End Sub

    Private Sub btnHome_MouseEnter(sender As Object, e As EventArgs) Handles btnHome.MouseEnter
        btnHome.BackColor = selectedbackcolor
        btnHome.ForeColor = selectedforecolor
        btnHome.Font = selectedfont
    End Sub

    Private Sub btnContentSearch_MouseEnter(sender As Object, e As EventArgs) Handles btnContentSearch.MouseEnter
        btnContentSearch.BackColor = selectedbackcolor
        btnContentSearch.ForeColor = selectedforecolor
        btnContentSearch.Font = selectedfont
    End Sub

    Private Sub btnContentSearch_MouseHover(sender As Object, e As EventArgs) Handles btnContentSearch.MouseHover
        btnContentSearch.BackColor = selectedbackcolor
        btnContentSearch.ForeColor = selectedforecolor
        btnContentSearch.Font = selectedfont
    End Sub

    Private Sub btnContentSearch_MouseLeave(sender As Object, e As EventArgs) Handles btnContentSearch.MouseLeave
        If Not selectedmenu = 4 Then
            btnContentSearch.BackColor = unselectedbackcolor
            btnContentSearch.ForeColor = unselectedforecolor
            btnContentSearch.Font = unselectedfont
        End If
    End Sub

    Private Sub btnArchiveThesis_MouseEnter(sender As Object, e As EventArgs) Handles btnArchiveThesis.MouseEnter
        btnArchiveThesis.BackColor = selectedbackcolor
        btnArchiveThesis.ForeColor = selectedforecolor
        btnArchiveThesis.Font = selectedfont
    End Sub

    Private Sub btnArchiveThesis_MouseHover(sender As Object, e As EventArgs) Handles btnArchiveThesis.MouseHover
        btnArchiveThesis.BackColor = selectedbackcolor
        btnArchiveThesis.ForeColor = selectedforecolor
        btnArchiveThesis.Font = selectedfont
    End Sub

    Private Sub btnArchiveThesis_MouseLeave(sender As Object, e As EventArgs) Handles btnArchiveThesis.MouseLeave
        If Not selectedmenu = 2 Then
            btnArchiveThesis.BackColor = unselectedbackcolor
            btnArchiveThesis.ForeColor = unselectedforecolor
            btnArchiveThesis.Font = unselectedfont
        End If
    End Sub

    Private Sub btnAuditTrail_MouseLeave(sender As Object, e As EventArgs) Handles btnAuditTrail.MouseLeave
        If Not selectedmenu = 6 Then
            btnAuditTrail.BackColor = unselectedbackcolor
            btnAuditTrail.ForeColor = unselectedforecolor
            btnAuditTrail.Font = unselectedfont
        End If
    End Sub

    Private Sub btnAuditTrail_MouseHover(sender As Object, e As EventArgs) Handles btnAuditTrail.MouseHover
        btnAuditTrail.BackColor = selectedbackcolor
        btnAuditTrail.ForeColor = selectedforecolor
        btnAuditTrail.Font = selectedfont
    End Sub

    Private Sub btnAuditTrail_MouseEnter(sender As Object, e As EventArgs) Handles btnAuditTrail.MouseEnter
        btnAuditTrail.BackColor = selectedbackcolor
        btnAuditTrail.ForeColor = selectedforecolor
        btnAuditTrail.Font = selectedfont
    End Sub

    Private Sub btnLogout_MouseEnter(sender As Object, e As EventArgs) Handles btnLogout.MouseEnter
        btnLogout.BackColor = selectedbackcolor
        btnLogout.ForeColor = selectedforecolor
        btnLogout.Font = selectedfont
    End Sub

    Private Sub btnLogout_MouseHover(sender As Object, e As EventArgs) Handles btnLogout.MouseHover
        btnLogout.BackColor = selectedbackcolor
        btnLogout.ForeColor = selectedforecolor
        btnLogout.Font = selectedfont
    End Sub

    Private Sub btnLogout_MouseLeave(sender As Object, e As EventArgs) Handles btnLogout.MouseLeave
        If Not selectedmenu = 9 Then
            btnLogout.BackColor = unselectedbackcolor
            btnLogout.ForeColor = unselectedforecolor
            btnLogout.Font = unselectedfont
        End If
    End Sub

    Private Sub btnTopThesis_MouseEnter(sender As Object, e As EventArgs) Handles btnTopThesis.MouseEnter
        btnTopThesis.BackColor = selectedbackcolor
        btnTopThesis.ForeColor = selectedforecolor
        btnTopThesis.Font = selectedfont
    End Sub

    Private Sub btnTopThesis_MouseHover(sender As Object, e As EventArgs) Handles btnTopThesis.MouseHover
        btnTopThesis.BackColor = selectedbackcolor
        btnTopThesis.ForeColor = selectedforecolor
        btnTopThesis.Font = selectedfont
    End Sub

    Private Sub btnTopThesis_MouseLeave(sender As Object, e As EventArgs) Handles btnTopThesis.MouseLeave
        If Not selectedmenu = 5 Then
            btnTopThesis.BackColor = unselectedbackcolor
            btnTopThesis.ForeColor = unselectedforecolor
            btnTopThesis.Font = unselectedfont
        End If
    End Sub

    Private Sub btnViewThesis_MouseEnter(sender As Object, e As EventArgs) Handles btnViewThesis.MouseEnter
        btnViewThesis.BackColor = selectedbackcolor
        btnViewThesis.ForeColor = selectedforecolor
        btnViewThesis.Font = selectedfont
    End Sub

    Private Sub btnViewThesis_MouseHover(sender As Object, e As EventArgs) Handles btnViewThesis.MouseHover
        btnViewThesis.BackColor = selectedbackcolor
        btnViewThesis.ForeColor = selectedforecolor
        btnViewThesis.Font = selectedfont
    End Sub

    Private Sub btnViewThesis_MouseLeave(sender As Object, e As EventArgs) Handles btnViewThesis.MouseLeave
        If Not selectedmenu = 3 Then
            btnViewThesis.BackColor = unselectedbackcolor
            btnViewThesis.ForeColor = unselectedforecolor
            btnViewThesis.Font = unselectedfont
        End If
    End Sub

    Private Sub btnAdmin_MouseEnter(sender As Object, e As EventArgs) Handles btnAdmin.MouseEnter
        btnAdmin.BackColor = selectedbackcolor
        btnAdmin.ForeColor = selectedforecolor
        btnAdmin.Font = selectedfont
    End Sub

    Private Sub btnAdmin_MouseHover(sender As Object, e As EventArgs) Handles btnAdmin.MouseHover
        btnAdmin.BackColor = selectedbackcolor
        btnAdmin.ForeColor = selectedforecolor
        btnAdmin.Font = selectedfont
    End Sub

    Private Sub btnAdmin_MouseLeave(sender As Object, e As EventArgs) Handles btnAdmin.MouseLeave
        If Not selectedmenu = 7 Then
            btnAdmin.BackColor = unselectedbackcolor
            btnAdmin.ForeColor = unselectedforecolor
            btnAdmin.Font = unselectedfont
        End If
    End Sub

    Private Sub btnAbout_MouseEnter(sender As Object, e As EventArgs) Handles btnAbout.MouseEnter
        btnAbout.BackColor = selectedbackcolor
        btnAbout.ForeColor = selectedforecolor
        btnAbout.Font = selectedfont
    End Sub

    Private Sub btnAbout_MouseHover(sender As Object, e As EventArgs) Handles btnAbout.MouseHover
        btnAbout.BackColor = selectedbackcolor
        btnAbout.ForeColor = selectedforecolor
        btnAbout.Font = selectedfont
    End Sub

    Private Sub btnAbout_MouseLeave(sender As Object, e As EventArgs) Handles btnAbout.MouseLeave
        If Not selectedmenu = 8 Then
            btnAbout.BackColor = unselectedbackcolor
            btnAbout.ForeColor = unselectedforecolor
            btnAbout.Font = unselectedfont
        End If
    End Sub

    Public Sub menuclicked()
        If selectedmenu = 1 Then
            btnContentSearch.BackColor = unselectedbackcolor
            btnContentSearch.ForeColor = unselectedforecolor
            btnContentSearch.Font = unselectedfont

            btnArchiveThesis.BackColor = unselectedbackcolor
            btnArchiveThesis.ForeColor = unselectedforecolor
            btnArchiveThesis.Font = unselectedfont

            btnAuditTrail.BackColor = unselectedbackcolor
            btnAuditTrail.ForeColor = unselectedforecolor
            btnAuditTrail.Font = unselectedfont

            btnLogout.BackColor = unselectedbackcolor
            btnLogout.ForeColor = unselectedforecolor
            btnLogout.Font = unselectedfont

            btnTopThesis.BackColor = unselectedbackcolor
            btnTopThesis.ForeColor = unselectedforecolor
            btnTopThesis.Font = unselectedfont

            btnViewThesis.BackColor = unselectedbackcolor
            btnViewThesis.ForeColor = unselectedforecolor
            btnViewThesis.Font = unselectedfont

            btnAdmin.BackColor = unselectedbackcolor
            btnAdmin.ForeColor = unselectedforecolor
            btnAdmin.Font = unselectedfont

            btnAbout.BackColor = unselectedbackcolor
            btnAbout.ForeColor = unselectedforecolor
            btnAbout.Font = unselectedfont

            btnTitleDatabase.BackColor = unselectedbackcolor
            btnTitleDatabase.ForeColor = unselectedforecolor
            btnTitleDatabase.Font = unselectedfont

            btnSpellingAndGrammarChecker.BackColor = unselectedbackcolor
            btnSpellingAndGrammarChecker.ForeColor = unselectedforecolor
            btnSpellingAndGrammarChecker.Font = unselectedfont

            btnRemoveThesis.BackColor = unselectedbackcolor
            btnRemoveThesis.ForeColor = unselectedforecolor
            btnRemoveThesis.Font = unselectedfont


        ElseIf selectedmenu = 2 Then
            btnHome.BackColor = unselectedbackcolor
            btnHome.ForeColor = unselectedforecolor
            btnHome.Font = unselectedfont

            btnContentSearch.BackColor = unselectedbackcolor
            btnContentSearch.ForeColor = unselectedforecolor
            btnContentSearch.Font = unselectedfont

            btnAuditTrail.BackColor = unselectedbackcolor
            btnAuditTrail.ForeColor = unselectedforecolor
            btnAuditTrail.Font = unselectedfont

            btnLogout.BackColor = unselectedbackcolor
            btnLogout.ForeColor = unselectedforecolor
            btnLogout.Font = unselectedfont

            btnTopThesis.BackColor = unselectedbackcolor
            btnTopThesis.ForeColor = unselectedforecolor
            btnTopThesis.Font = unselectedfont

            btnViewThesis.BackColor = unselectedbackcolor
            btnViewThesis.ForeColor = unselectedforecolor
            btnViewThesis.Font = unselectedfont

            btnAdmin.BackColor = unselectedbackcolor
            btnAdmin.ForeColor = unselectedforecolor
            btnAdmin.Font = unselectedfont

            btnAbout.BackColor = unselectedbackcolor
            btnAbout.ForeColor = unselectedforecolor
            btnAbout.Font = unselectedfont

            btnTitleDatabase.BackColor = unselectedbackcolor
            btnTitleDatabase.ForeColor = unselectedforecolor
            btnTitleDatabase.Font = unselectedfont


            btnSpellingAndGrammarChecker.BackColor = unselectedbackcolor
            btnSpellingAndGrammarChecker.ForeColor = unselectedforecolor
            btnSpellingAndGrammarChecker.Font = unselectedfont

            btnRemoveThesis.BackColor = unselectedbackcolor
            btnRemoveThesis.ForeColor = unselectedforecolor
            btnRemoveThesis.Font = unselectedfont


        ElseIf selectedmenu = 3 Then
            btnHome.BackColor = unselectedbackcolor
            btnHome.ForeColor = unselectedforecolor
            btnHome.Font = unselectedfont

            btnContentSearch.BackColor = unselectedbackcolor
            btnContentSearch.ForeColor = unselectedforecolor
            btnContentSearch.Font = unselectedfont

            btnArchiveThesis.BackColor = unselectedbackcolor
            btnArchiveThesis.ForeColor = unselectedforecolor
            btnArchiveThesis.Font = unselectedfont

            btnAuditTrail.BackColor = unselectedbackcolor
            btnAuditTrail.ForeColor = unselectedforecolor
            btnAuditTrail.Font = unselectedfont

            btnLogout.BackColor = unselectedbackcolor
            btnLogout.ForeColor = unselectedforecolor
            btnLogout.Font = unselectedfont

            btnTopThesis.BackColor = unselectedbackcolor
            btnTopThesis.ForeColor = unselectedforecolor
            btnTopThesis.Font = unselectedfont

            btnAdmin.BackColor = unselectedbackcolor
            btnAdmin.ForeColor = unselectedforecolor
            btnAdmin.Font = unselectedfont

            btnAbout.BackColor = unselectedbackcolor
            btnAbout.ForeColor = unselectedforecolor
            btnAbout.Font = unselectedfont

            btnTitleDatabase.BackColor = unselectedbackcolor
            btnTitleDatabase.ForeColor = unselectedforecolor
            btnTitleDatabase.Font = unselectedfont

            btnSpellingAndGrammarChecker.BackColor = unselectedbackcolor
            btnSpellingAndGrammarChecker.ForeColor = unselectedforecolor
            btnSpellingAndGrammarChecker.Font = unselectedfont

            btnRemoveThesis.BackColor = unselectedbackcolor
            btnRemoveThesis.ForeColor = unselectedforecolor
            btnRemoveThesis.Font = unselectedfont

        ElseIf selectedmenu = 4 Then
            btnHome.BackColor = unselectedbackcolor
            btnHome.ForeColor = unselectedforecolor
            btnHome.Font = unselectedfont

            btnArchiveThesis.BackColor = unselectedbackcolor
            btnArchiveThesis.ForeColor = unselectedforecolor
            btnArchiveThesis.Font = unselectedfont

            btnAuditTrail.BackColor = unselectedbackcolor
            btnAuditTrail.ForeColor = unselectedforecolor
            btnAuditTrail.Font = unselectedfont

            btnLogout.BackColor = unselectedbackcolor
            btnLogout.ForeColor = unselectedforecolor
            btnLogout.Font = unselectedfont

            btnTopThesis.BackColor = unselectedbackcolor
            btnTopThesis.ForeColor = unselectedforecolor
            btnTopThesis.Font = unselectedfont

            btnViewThesis.BackColor = unselectedbackcolor
            btnViewThesis.ForeColor = unselectedforecolor
            btnViewThesis.Font = unselectedfont

            btnAdmin.BackColor = unselectedbackcolor
            btnAdmin.ForeColor = unselectedforecolor
            btnAdmin.Font = unselectedfont

            btnAbout.BackColor = unselectedbackcolor
            btnAbout.ForeColor = unselectedforecolor
            btnAbout.Font = unselectedfont

            btnTitleDatabase.BackColor = unselectedbackcolor
            btnTitleDatabase.ForeColor = unselectedforecolor
            btnTitleDatabase.Font = unselectedfont

            btnSpellingAndGrammarChecker.BackColor = unselectedbackcolor
            btnSpellingAndGrammarChecker.ForeColor = unselectedforecolor
            btnSpellingAndGrammarChecker.Font = unselectedfont

            btnRemoveThesis.BackColor = unselectedbackcolor
            btnRemoveThesis.ForeColor = unselectedforecolor
            btnRemoveThesis.Font = unselectedfont

        ElseIf selectedmenu = 5 Then
            btnHome.BackColor = unselectedbackcolor
            btnHome.ForeColor = unselectedforecolor
            btnHome.Font = unselectedfont

            btnContentSearch.BackColor = unselectedbackcolor
            btnContentSearch.ForeColor = unselectedforecolor
            btnContentSearch.Font = unselectedfont

            btnArchiveThesis.BackColor = unselectedbackcolor
            btnArchiveThesis.ForeColor = unselectedforecolor
            btnArchiveThesis.Font = unselectedfont

            btnAuditTrail.BackColor = unselectedbackcolor
            btnAuditTrail.ForeColor = unselectedforecolor
            btnAuditTrail.Font = unselectedfont

            btnLogout.BackColor = unselectedbackcolor
            btnLogout.ForeColor = unselectedforecolor
            btnLogout.Font = unselectedfont

            btnViewThesis.BackColor = unselectedbackcolor
            btnViewThesis.ForeColor = unselectedforecolor
            btnViewThesis.Font = unselectedfont

            btnAdmin.BackColor = unselectedbackcolor
            btnAdmin.ForeColor = unselectedforecolor
            btnAdmin.Font = unselectedfont

            btnAbout.BackColor = unselectedbackcolor
            btnAbout.ForeColor = unselectedforecolor
            btnAbout.Font = unselectedfont

            btnTitleDatabase.BackColor = unselectedbackcolor
            btnTitleDatabase.ForeColor = unselectedforecolor
            btnTitleDatabase.Font = unselectedfont

            btnSpellingAndGrammarChecker.BackColor = unselectedbackcolor
            btnSpellingAndGrammarChecker.ForeColor = unselectedforecolor
            btnSpellingAndGrammarChecker.Font = unselectedfont

            btnRemoveThesis.BackColor = unselectedbackcolor
            btnRemoveThesis.ForeColor = unselectedforecolor
            btnRemoveThesis.Font = unselectedfont

        ElseIf selectedmenu = 6 Then
            btnHome.BackColor = unselectedbackcolor
            btnHome.ForeColor = unselectedforecolor
            btnHome.Font = unselectedfont

            btnContentSearch.BackColor = unselectedbackcolor
            btnContentSearch.ForeColor = unselectedforecolor
            btnContentSearch.Font = unselectedfont

            btnArchiveThesis.BackColor = unselectedbackcolor
            btnArchiveThesis.ForeColor = unselectedforecolor
            btnArchiveThesis.Font = unselectedfont

            btnLogout.BackColor = unselectedbackcolor
            btnLogout.ForeColor = unselectedforecolor
            btnLogout.Font = unselectedfont

            btnTopThesis.BackColor = unselectedbackcolor
            btnTopThesis.ForeColor = unselectedforecolor
            btnTopThesis.Font = unselectedfont

            btnViewThesis.BackColor = unselectedbackcolor
            btnViewThesis.ForeColor = unselectedforecolor
            btnViewThesis.Font = unselectedfont

            btnAdmin.BackColor = unselectedbackcolor
            btnAdmin.ForeColor = unselectedforecolor
            btnAdmin.Font = unselectedfont

            btnAbout.BackColor = unselectedbackcolor
            btnAbout.ForeColor = unselectedforecolor
            btnAbout.Font = unselectedfont

            btnTitleDatabase.BackColor = unselectedbackcolor
            btnTitleDatabase.ForeColor = unselectedforecolor
            btnTitleDatabase.Font = unselectedfont

            btnSpellingAndGrammarChecker.BackColor = unselectedbackcolor
            btnSpellingAndGrammarChecker.ForeColor = unselectedforecolor
            btnSpellingAndGrammarChecker.Font = unselectedfont

            btnRemoveThesis.BackColor = unselectedbackcolor
            btnRemoveThesis.ForeColor = unselectedforecolor
            btnRemoveThesis.Font = unselectedfont


        ElseIf selectedmenu = 7 Then
            btnHome.BackColor = unselectedbackcolor
            btnHome.ForeColor = unselectedforecolor
            btnHome.Font = unselectedfont

            btnContentSearch.BackColor = unselectedbackcolor
            btnContentSearch.ForeColor = unselectedforecolor
            btnContentSearch.Font = unselectedfont

            btnArchiveThesis.BackColor = unselectedbackcolor
            btnArchiveThesis.ForeColor = unselectedforecolor
            btnArchiveThesis.Font = unselectedfont

            btnAuditTrail.BackColor = unselectedbackcolor
            btnAuditTrail.ForeColor = unselectedforecolor
            btnAuditTrail.Font = unselectedfont

            btnLogout.BackColor = unselectedbackcolor
            btnLogout.ForeColor = unselectedforecolor
            btnLogout.Font = unselectedfont

            btnTopThesis.BackColor = unselectedbackcolor
            btnTopThesis.ForeColor = unselectedforecolor
            btnTopThesis.Font = unselectedfont

            btnViewThesis.BackColor = unselectedbackcolor
            btnViewThesis.ForeColor = unselectedforecolor
            btnViewThesis.Font = unselectedfont

            btnAbout.BackColor = unselectedbackcolor
            btnAbout.ForeColor = unselectedforecolor
            btnAbout.Font = unselectedfont

            btnTitleDatabase.BackColor = unselectedbackcolor
            btnTitleDatabase.ForeColor = unselectedforecolor
            btnTitleDatabase.Font = unselectedfont

            btnSpellingAndGrammarChecker.BackColor = unselectedbackcolor
            btnSpellingAndGrammarChecker.ForeColor = unselectedforecolor
            btnSpellingAndGrammarChecker.Font = unselectedfont

            btnRemoveThesis.BackColor = unselectedbackcolor
            btnRemoveThesis.ForeColor = unselectedforecolor
            btnRemoveThesis.Font = unselectedfont

        ElseIf selectedmenu = 8 Then
            btnHome.BackColor = unselectedbackcolor
            btnHome.ForeColor = unselectedforecolor
            btnHome.Font = unselectedfont

            btnContentSearch.BackColor = unselectedbackcolor
            btnContentSearch.ForeColor = unselectedforecolor
            btnContentSearch.Font = unselectedfont

            btnArchiveThesis.BackColor = unselectedbackcolor
            btnArchiveThesis.ForeColor = unselectedforecolor
            btnArchiveThesis.Font = unselectedfont

            btnAuditTrail.BackColor = unselectedbackcolor
            btnAuditTrail.ForeColor = unselectedforecolor
            btnAuditTrail.Font = unselectedfont

            btnLogout.BackColor = unselectedbackcolor
            btnLogout.ForeColor = unselectedforecolor
            btnLogout.Font = unselectedfont

            btnTopThesis.BackColor = unselectedbackcolor
            btnTopThesis.ForeColor = unselectedforecolor
            btnTopThesis.Font = unselectedfont

            btnViewThesis.BackColor = unselectedbackcolor
            btnViewThesis.ForeColor = unselectedforecolor
            btnViewThesis.Font = unselectedfont

            btnAdmin.BackColor = unselectedbackcolor
            btnAdmin.ForeColor = unselectedforecolor
            btnAdmin.Font = unselectedfont

            btnTitleDatabase.BackColor = unselectedbackcolor
            btnTitleDatabase.ForeColor = unselectedforecolor
            btnTitleDatabase.Font = unselectedfont


            btnSpellingAndGrammarChecker.BackColor = unselectedbackcolor
            btnSpellingAndGrammarChecker.ForeColor = unselectedforecolor
            btnSpellingAndGrammarChecker.Font = unselectedfont

            btnRemoveThesis.BackColor = unselectedbackcolor
            btnRemoveThesis.ForeColor = unselectedforecolor
            btnRemoveThesis.Font = unselectedfont
        ElseIf selectedmenu = 9 Then
            btnHome.BackColor = unselectedbackcolor
            btnHome.ForeColor = unselectedforecolor
            btnHome.Font = unselectedfont

            btnContentSearch.BackColor = unselectedbackcolor
            btnContentSearch.ForeColor = unselectedforecolor
            btnContentSearch.Font = unselectedfont

            btnArchiveThesis.BackColor = unselectedbackcolor
            btnArchiveThesis.ForeColor = unselectedforecolor
            btnArchiveThesis.Font = unselectedfont

            btnAuditTrail.BackColor = unselectedbackcolor
            btnAuditTrail.ForeColor = unselectedforecolor
            btnAuditTrail.Font = unselectedfont

            btnTopThesis.BackColor = unselectedbackcolor
            btnTopThesis.ForeColor = unselectedforecolor
            btnTopThesis.Font = unselectedfont

            btnViewThesis.BackColor = unselectedbackcolor
            btnViewThesis.ForeColor = unselectedforecolor
            btnViewThesis.Font = unselectedfont

            btnAdmin.BackColor = unselectedbackcolor
            btnAdmin.ForeColor = unselectedforecolor
            btnAdmin.Font = unselectedfont

            btnAbout.BackColor = unselectedbackcolor
            btnAbout.ForeColor = unselectedforecolor
            btnAbout.Font = unselectedfont

            btnTitleDatabase.BackColor = unselectedbackcolor
            btnTitleDatabase.ForeColor = unselectedforecolor
            btnTitleDatabase.Font = unselectedfont


            btnSpellingAndGrammarChecker.BackColor = unselectedbackcolor
            btnSpellingAndGrammarChecker.ForeColor = unselectedforecolor
            btnSpellingAndGrammarChecker.Font = unselectedfont

            btnRemoveThesis.BackColor = unselectedbackcolor
            btnRemoveThesis.ForeColor = unselectedforecolor
            btnRemoveThesis.Font = unselectedfont

        ElseIf selectedmenu = 10 Then
            btnHome.BackColor = unselectedbackcolor
            btnHome.ForeColor = unselectedforecolor
            btnHome.Font = unselectedfont

            btnContentSearch.BackColor = unselectedbackcolor
            btnContentSearch.ForeColor = unselectedforecolor
            btnContentSearch.Font = unselectedfont

            btnArchiveThesis.BackColor = unselectedbackcolor
            btnArchiveThesis.ForeColor = unselectedforecolor
            btnArchiveThesis.Font = unselectedfont

            btnAuditTrail.BackColor = unselectedbackcolor
            btnAuditTrail.ForeColor = unselectedforecolor
            btnAuditTrail.Font = unselectedfont

            btnTopThesis.BackColor = unselectedbackcolor
            btnTopThesis.ForeColor = unselectedforecolor
            btnTopThesis.Font = unselectedfont

            btnViewThesis.BackColor = unselectedbackcolor
            btnViewThesis.ForeColor = unselectedforecolor
            btnViewThesis.Font = unselectedfont

            btnAdmin.BackColor = unselectedbackcolor
            btnAdmin.ForeColor = unselectedforecolor
            btnAdmin.Font = unselectedfont

            btnAbout.BackColor = unselectedbackcolor
            btnAbout.ForeColor = unselectedforecolor
            btnAbout.Font = unselectedfont

            btnLogout.BackColor = unselectedbackcolor
            btnLogout.ForeColor = unselectedforecolor
            btnLogout.Font = unselectedfont

            btnSpellingAndGrammarChecker.BackColor = unselectedbackcolor
            btnSpellingAndGrammarChecker.ForeColor = unselectedforecolor
            btnSpellingAndGrammarChecker.Font = unselectedfont

            btnRemoveThesis.BackColor = unselectedbackcolor
            btnRemoveThesis.ForeColor = unselectedforecolor
            btnRemoveThesis.Font = unselectedfont

        ElseIf selectedmenu = 11 Then
            btnHome.BackColor = unselectedbackcolor
            btnHome.ForeColor = unselectedforecolor
            btnHome.Font = unselectedfont

            btnContentSearch.BackColor = unselectedbackcolor
            btnContentSearch.ForeColor = unselectedforecolor
            btnContentSearch.Font = unselectedfont

            btnArchiveThesis.BackColor = unselectedbackcolor
            btnArchiveThesis.ForeColor = unselectedforecolor
            btnArchiveThesis.Font = unselectedfont

            btnAuditTrail.BackColor = unselectedbackcolor
            btnAuditTrail.ForeColor = unselectedforecolor
            btnAuditTrail.Font = unselectedfont

            btnTopThesis.BackColor = unselectedbackcolor
            btnTopThesis.ForeColor = unselectedforecolor
            btnTopThesis.Font = unselectedfont

            btnViewThesis.BackColor = unselectedbackcolor
            btnViewThesis.ForeColor = unselectedforecolor
            btnViewThesis.Font = unselectedfont

            btnAdmin.BackColor = unselectedbackcolor
            btnAdmin.ForeColor = unselectedforecolor
            btnAdmin.Font = unselectedfont

            btnAbout.BackColor = unselectedbackcolor
            btnAbout.ForeColor = unselectedforecolor
            btnAbout.Font = unselectedfont

            btnLogout.BackColor = unselectedbackcolor
            btnLogout.ForeColor = unselectedforecolor
            btnLogout.Font = unselectedfont


            btnTitleDatabase.BackColor = unselectedbackcolor
            btnTitleDatabase.ForeColor = unselectedforecolor
            btnTitleDatabase.Font = unselectedfont


            btnRemoveThesis.BackColor = unselectedbackcolor
            btnRemoveThesis.ForeColor = unselectedforecolor
            btnRemoveThesis.Font = unselectedfont

        ElseIf selectedmenu = 12 Then
            btnHome.BackColor = unselectedbackcolor
            btnHome.ForeColor = unselectedforecolor
            btnHome.Font = unselectedfont

            btnContentSearch.BackColor = unselectedbackcolor
            btnContentSearch.ForeColor = unselectedforecolor
            btnContentSearch.Font = unselectedfont

            btnArchiveThesis.BackColor = unselectedbackcolor
            btnArchiveThesis.ForeColor = unselectedforecolor
            btnArchiveThesis.Font = unselectedfont

            btnAuditTrail.BackColor = unselectedbackcolor
            btnAuditTrail.ForeColor = unselectedforecolor
            btnAuditTrail.Font = unselectedfont

            btnTopThesis.BackColor = unselectedbackcolor
            btnTopThesis.ForeColor = unselectedforecolor
            btnTopThesis.Font = unselectedfont

            btnViewThesis.BackColor = unselectedbackcolor
            btnViewThesis.ForeColor = unselectedforecolor
            btnViewThesis.Font = unselectedfont

            btnAdmin.BackColor = unselectedbackcolor
            btnAdmin.ForeColor = unselectedforecolor
            btnAdmin.Font = unselectedfont

            btnAbout.BackColor = unselectedbackcolor
            btnAbout.ForeColor = unselectedforecolor
            btnAbout.Font = unselectedfont

            btnLogout.BackColor = unselectedbackcolor
            btnLogout.ForeColor = unselectedforecolor
            btnLogout.Font = unselectedfont

            btnTitleDatabase.BackColor = unselectedbackcolor
            btnTitleDatabase.ForeColor = unselectedforecolor
            btnTitleDatabase.Font = unselectedfont

            btnSpellingAndGrammarChecker.BackColor = unselectedbackcolor
            btnSpellingAndGrammarChecker.ForeColor = unselectedforecolor
            btnSpellingAndGrammarChecker.Font = unselectedfont


        End If
    End Sub

    Private Sub btnAuditTrail_Click(sender As Object, e As EventArgs) Handles btnAuditTrail.Click
        menuCategoryClicked(btnAuditTrail)
        selectedmenu = 6
        menuclicked()
        Panel1.Controls.Clear()
        If audittrail.Panel1.Controls.Count = 0 Then
            audittraillogs.changeConnstring(departmentSelected)
            audittraillogs.reloadLogs()
            audittrail.Panel1.Controls.Add(audittraillogs)
            audittraillogs.Show()
        End If
        audittrailtasks.changeConnstring(departmentSelected)
        audittrailtasks.reloadTasks()
        Panel1.Controls.Add(audittrail)
        audittrail.changeButtonColor()
        audittrail.Show()
    End Sub

    Private Sub ContainerForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If Not logoutclicked Then
            userloggedout()
            Application.Exit()
        End If
    End Sub

    Public Sub userloggedout()

        Try
            conn.ConnectionString = connstring
            conn.Open()

            Dim comm As New MySqlCommand

            Dim commstring As String = "UPDATE `logstbl` SET `loggedout`=NOW() WHERE id=" & loggedid
            comm.CommandText = commstring
            comm.Connection = conn
            comm.CommandType = CommandType.Text
            comm.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            conn.Close()
        End Try

    End Sub

    Public Sub UserIn(usertype As String)
        If usertype = "Guest" Then
            TableLayoutPanel2.Controls("btnArchiveThesis").Enabled = False
            TableLayoutPanel2.Controls("btnAdmin").Enabled = False
            TableLayoutPanel2.Controls("btnAuditTrail").Enabled = False
            TableLayoutPanel2.Controls("btnRemoveThesis").Enabled = False
            TableLayoutPanel2.Controls("btnArchiveThesis").Visible = False
            TableLayoutPanel2.Controls("btnAdmin").Visible = False
            TableLayoutPanel2.Controls("btnAuditTrail").Visible = False
            TableLayoutPanel2.Controls("btnRemoveThesis").Visible = False
            TableLayoutPanel2.RowStyles(2).Height = 0
            TableLayoutPanel2.RowStyles(3).Height = 0
            TableLayoutPanel2.RowStyles(7).Height = 0
            TableLayoutPanel2.RowStyles(8).Height = 0

            viewthesis.TableLayoutPanel5.Controls("Button1").Enabled = False
            viewthesis.TableLayoutPanel5.Controls("Button1").Visible = False
            viewthesis.TableLayoutPanel5.Controls("Button2").Enabled = False
            viewthesis.TableLayoutPanel5.Controls("Button2").Visible = False
            viewthesis.TableLayoutPanel5.Controls("Button4").Enabled = False
            viewthesis.TableLayoutPanel5.Controls("Button4").Visible = False

            retrievethesisview.TableLayoutPanel7.Controls("Button7").Enabled = False
            retrievethesisview.TableLayoutPanel7.Controls("Button7").Visible = False

            retrievethesisview.TableLayoutPanel5.Controls("Button1").Enabled = False
            retrievethesisview.TableLayoutPanel5.Controls("Button1").Visible = False
            retrievethesisview.TableLayoutPanel5.Controls("Button2").Enabled = False
            retrievethesisview.TableLayoutPanel5.Controls("Button2").Visible = False
            retrievethesisview.TableLayoutPanel5.Controls("Button3").Enabled = False
            retrievethesisview.TableLayoutPanel5.Controls("Button3").Visible = False
            retrievethesisview.TableLayoutPanel5.Controls("Button4").Enabled = False
            retrievethesisview.TableLayoutPanel5.Controls("Button4").Visible = False
            retrievethesisview.TableLayoutPanel5.Controls("Button6").Enabled = False
            retrievethesisview.TableLayoutPanel5.Controls("Button6").Visible = False
            retrievethesisview.TableLayoutPanel5.ColumnStyles(1).Width = 0

            titledatabase.btnAdd.Enabled = False
            titledatabase.btnAdd.Visible = False
            titledatabase.btnRemove.Enabled = False
            titledatabase.btnRemove.Visible = False
            titledatabase.btnEdit.Enabled = False
            titledatabase.btnEdit.Visible = False
            titledatabase.btnPrint.Visible = False
            titledatabase.btnPrint.Enabled = False

        End If

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles leftnavanimation.Tick
        If TableLayoutPanel1.ColumnStyles(0).Width >= 200 Then
            leftnavanimation.Enabled = False
            For Each cont As Control In TableLayoutPanel2.Controls
                cont.Enabled = True
            Next
            'TableLayoutPanel2.BackgroundImage = My.Resources.ResourceManager.GetObject("PANEL")
            Panel1.Controls.Add(homeform)
            homeform.Show()
            'mainpanelanimation.Enabled = True
        Else
            TableLayoutPanel1.ColumnStyles(0).Width += 10
        End If
    End Sub

    Public Sub start()
        Panel1.Controls.Clear()
        Panel1.BackColor = Color.FromArgb(255, Color.White)
        leftnavanimation.Enabled = True
        'opacitycontrol = 255
    End Sub


    Private Sub mainpanelanimation_Tick(sender As Object, e As EventArgs) Handles mainpanelanimation.Tick
        If opacitycontrol <= 5 Then
            opacitycontrol = 0
            Panel1.BackColor = Color.FromArgb(opacitycontrol, Color.White)
            mainpanelanimation.Enabled = False
        Else
            MsgBox(opacitycontrol)
            Panel1.BackColor = Color.FromArgb(opacitycontrol, Color.White)
        End If
        opacitycontrol = opacitycontrol - 10
    End Sub

    Private Sub leftnavcloseanimation_Tick(sender As Object, e As EventArgs) Handles leftnavcloseanimation.Tick
        If TableLayoutPanel1.ColumnStyles(0).Width <= 0 Then
            leftnavcloseanimation.Enabled = False
            For Each cont As Control In TableLayoutPanel2.Controls
                cont.Enabled = False
            Next
            leftnavanimation.Enabled = True
            'mainpanelanimation.Enabled = True
        Else
            TableLayoutPanel1.ColumnStyles(0).Width -= 10
            'TableLayoutPanel1.ColumnStyles(1).Width += 20
        End If
    End Sub

    Private Sub btnTitleDatabase_Click(sender As Object, e As EventArgs) Handles btnTitleDatabase.Click
        menuCategoryClicked(btnTitleDatabase)
        selectedmenu = 10
        menuclicked()
        Panel1.Controls.Clear()
        titledatabase.changeConnstring(departmentSelected)
        titledatabase.refreshThesisTitles(titledatabase.txtSearch.Text, titledatabase.chkApproved.Checked, titledatabase.chkDisapproved.Checked, titledatabase.chkFinished.Checked)
        Panel1.Controls.Add(titledatabase)
        titledatabase.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btnMaximize.Click
        'Me.MaximumSize = Screen.FromControl(Me).WorkingArea.Size
        'If Me.WindowState = FormWindowState.Maximized Then
        '    'If Me.Bounds = Screen.GetWorkingArea(Me) Then
        '    Me.WindowState = FormWindowState.Normal
        'Else
        '    'Me.Bounds = Screen.GetWorkingArea(Me)
        '    Me.WindowState = FormWindowState.Maximized
        'End If


        'Me.MaximumSize = Screen.FromRectangle(Me.Bounds).WorkingArea.Size
        'If Me.WindowState = FormWindowState.Maximized Then
        '    'If Me.Bounds = Screen.GetWorkingArea(Me) Then
        '    Me.WindowState = FormWindowState.Normal
        'Else
        '    'Me.Bounds = Screen.GetWorkingArea(Me)
        '    Me.WindowState = FormWindowState.Maximized
        'End If




        If Me.Bounds = Screen.GetWorkingArea(Me) Then
            'MsgBox("Width: " & width & vbNewLine & "Screen Width: " & Screen.PrimaryScreen.WorkingArea.Width)
            Me.SetBounds(fleft, ftop, fwidth, fheight)
            'Me.CenterToScreen()
        Else
            Me.Bounds = Screen.GetWorkingArea(Me)
        End If






    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub btnTitleDatabase_MouseEnter(sender As Object, e As EventArgs) Handles btnTitleDatabase.MouseEnter
        btnTitleDatabase.BackColor = selectedbackcolor
        btnTitleDatabase.ForeColor = selectedforecolor
        btnTitleDatabase.Font = selectedfont

    End Sub

    Private Sub btnTitleDatabase_MouseHover(sender As Object, e As EventArgs) Handles btnTitleDatabase.MouseHover
        btnTitleDatabase.BackColor = selectedbackcolor
        btnTitleDatabase.ForeColor = selectedforecolor
        btnTitleDatabase.Font = selectedfont
    End Sub

    Private Sub btnTitleDatabase_MouseLeave(sender As Object, e As EventArgs) Handles btnTitleDatabase.MouseLeave
        If Not selectedmenu = 10 Then
            btnTitleDatabase.BackColor = unselectedbackcolor
            btnTitleDatabase.ForeColor = unselectedforecolor
            btnTitleDatabase.Font = unselectedfont
        End If
    End Sub

    Private Sub btnClose_MouseHover(sender As Object, e As EventArgs) Handles btnClose.MouseHover
        btnClose.BackColor = Color.Red
    End Sub

    Private Sub btnSpellingAndGrammarChecker_Click(sender As Object, e As EventArgs) Handles btnSpellingAndGrammarChecker.Click
        menuCategoryClicked(btnSpellingAndGrammarChecker)
        selectedmenu = 11
        menuclicked()
        Panel1.Controls.Clear()
        Panel1.Controls.Add(spellingnandgrammarcheck)
        spellingnandgrammarcheck.Show()



    End Sub

    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        btnClose.BackColor = Color.FromArgb(255, 185, 184, 183)
    End Sub

    Private Sub btnClose_MouseEnter(sender As Object, e As EventArgs) Handles btnClose.MouseEnter
        btnClose.BackColor = Color.Red
    End Sub


    Public Sub executeTaskQuery(category As String, description As String)
        conn.ConnectionString = connstring
        conn.Open()

        'category = category.Replace("'", "''")
        description = description.Replace("'", "''")

        Dim comm As New MySqlCommand
        comm.Connection = conn
        comm.CommandType = CommandType.Text

        Dim sql As String = ""

        If loggedtype = "Admin" Then
            If admintype.Equals("Master") Then
                sql = "INSERT INTO `taskstbl`(`taskcategory`, `taskdescription`, `logname`, `usertype`, `taskdate`) VALUES ('" & category & "','" & description & "','" & loggedname & "','" & admintype & "',NOW())"
            Else
                sql = "INSERT INTO `taskstbl`(`taskcategory`, `taskdescription`, `logname`, `usertype`, `taskdate`) VALUES ('" & category & "','" & description & "','" & loggedname & "','Admin',NOW())"
            End If
        ElseIf loggedtype = "Guest" Then
            sql = "INSERT INTO `taskstbl`(`taskcategory`, `taskdescription`, `logname`, `usertype`, `taskdate`) VALUES ('" & category & "','" & description & "','" & loggedname & "','Guest',NOW())"
        Else
            sql = "INSERT INTO `taskstbl`(`taskcategory`, `taskdescription`, `logname`, `usertype`, `taskdate`) VALUES ('" & category & "','" & description & "','" & loggedname & "','Guest',NOW())"
        End If
        comm.CommandText = sql
        comm.ExecuteNonQuery()
        conn.Close()
    End Sub

    Private Sub btnRemoveThesis_Click(sender As Object, e As EventArgs) Handles btnRemoveThesis.Click
        menuCategoryClicked(btnRemoveThesis)
        selectedmenu = 12
        menuclicked()
        Panel1.Controls.Clear()
        removethesis.changeConnstring(departmentSelected)
        Panel1.Controls.Add(removethesis)
        removethesis.loadDatagrid()
        removethesis.Show()
    End Sub

    Private Sub btnSpellingAndGrammarChecker_MouseHover(sender As Object, e As EventArgs) Handles btnSpellingAndGrammarChecker.MouseHover
        btnSpellingAndGrammarChecker.BackColor = selectedbackcolor
        btnSpellingAndGrammarChecker.ForeColor = selectedforecolor
        btnSpellingAndGrammarChecker.Font = selectedfont
    End Sub

    Private Sub btnSpellingAndGrammarChecker_MouseLeave(sender As Object, e As EventArgs) Handles btnSpellingAndGrammarChecker.MouseLeave
        If Not selectedmenu = 11 Then
            btnSpellingAndGrammarChecker.BackColor = unselectedbackcolor
            btnSpellingAndGrammarChecker.ForeColor = unselectedforecolor
            btnSpellingAndGrammarChecker.Font = unselectedfont
        End If
    End Sub

    Private Sub btnSpellingAndGrammarChecker_MouseEnter(sender As Object, e As EventArgs) Handles btnSpellingAndGrammarChecker.MouseEnter
        btnSpellingAndGrammarChecker.BackColor = selectedbackcolor
        btnSpellingAndGrammarChecker.ForeColor = selectedforecolor
        btnSpellingAndGrammarChecker.Font = selectedfont

    End Sub

    Private Sub btnRemoveThesis_MouseEnter(sender As Object, e As EventArgs) Handles btnRemoveThesis.MouseEnter
        btnRemoveThesis.BackColor = selectedbackcolor
        btnRemoveThesis.ForeColor = selectedforecolor
        btnRemoveThesis.Font = selectedfont
    End Sub

    Private Sub btnRemoveThesis_MouseLeave(sender As Object, e As EventArgs) Handles btnRemoveThesis.MouseLeave
        If Not selectedmenu = 12 Then
            btnRemoveThesis.BackColor = unselectedbackcolor
            btnRemoveThesis.ForeColor = unselectedforecolor
            btnRemoveThesis.Font = unselectedfont
        End If
    End Sub

    Private Sub btnRemoveThesis_MouseHover(sender As Object, e As EventArgs) Handles btnRemoveThesis.MouseHover
        btnRemoveThesis.BackColor = selectedbackcolor
        btnRemoveThesis.ForeColor = selectedforecolor
        btnRemoveThesis.Font = selectedfont
    End Sub


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


    'Private Sub Button6_MouseHover(sender As Object, e As EventArgs) Handles Button6.MouseHover
    '    Button6.ForeColor = Color.Red
    '    Button6.BackColor = Color.Blue
    'End Sub
End Class
