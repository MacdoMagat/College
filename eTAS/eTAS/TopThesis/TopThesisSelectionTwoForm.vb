Imports MySql.Data.MySqlClient

Public Class TopThesisSelectionTwoForm

    Dim yearconn As New MySqlConnection
    Dim topconn As New MySqlConnection
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


    Private Sub TopThesisSelectionTwoForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        'yearconn.ConnectionString = connstring
        'yearconn.Open()


        'Dim yearcomm As New MySqlCommand
        'Dim yearcommstring As String = "SELECT DISTINCT yeartopped FROM topthesistbl ORDER  BY yeartopped DESC"
        'Dim yearreader As MySqlDataReader
        'yearcomm.CommandText = yearcommstring
        'yearcomm.Connection = yearconn
        'yearreader = yearcomm.ExecuteReader

        'While (yearreader.Read)
        '    Dim datepanel As New Panel
        '    Dim datelabel As New Label
        '    datepanel.Name = yearreader("yeartopped").ToString
        '    datepanel.Height = 50
        '    datepanel.Width = 1130
        '    '1164x696
        '    datelabel.TextAlign = ContentAlignment.MiddleCenter
        '    datelabel.Text = yearreader("yeartopped").ToString
        '    datelabel.Dock = DockStyle.Fill
        '    datelabel.ForeColor = Color.White
        '    datelabel.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        '    datepanel.BackColor = Color.FromArgb(255, 6, 69, 133)
        '    datepanel.Controls.Add(datelabel)
        '    flpMain.Controls.Add(datepanel)

        '    Dim topsflp As New FlowLayoutPanel
        '    topsflp.FlowDirection = FlowDirection.LeftToRight
        '    topsflp.AutoScroll = True
        '    topsflp.WrapContents = False
        '    topsflp.Height = 450
        '    topsflp.Width = 1130
        '    'topsflp.AutoSize = True


        '    topconn.ConnectionString = connstring
        '    topconn.Open()

        '    Dim topcomm As New MySqlCommand
        '    Dim topcommstring As String = "SELECT * FROM `topthesistbl` LEFT JOIN thesistbl ON topthesistbl.thesisid = thesistbl.thesisid LEFT JOIN topthesiscategorytbl ON topthesistbl.topthesiscategoryid = topthesiscategorytbl.topthesiscategoryid WHERE yeartopped=" & yearreader("yeartopped").ToString
        '    Dim topreader As MySqlDataReader
        '    topcomm.CommandText = topcommstring
        '    topcomm.Connection = topconn
        '    topreader = topcomm.ExecuteReader

        '    While (topreader.Read)


        '        Dim toptlp As New TableLayoutPanel
        '        toptlp.Width = 250
        '        toptlp.Height = 400
        '        toptlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 250))
        '        toptlp.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 250))
        '        toptlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 50))
        '        toptlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 100))
        '        Dim picture As New PictureBox
        '        picture.Dock = DockStyle.Fill
        '        picture.SizeMode = PictureBoxSizeMode.StretchImage
        '        picture.Name = topreader("thesisid").ToString
        '        picture.Image = Image.FromFile(topreader("thesispath").ToString & ".jpg")
        '        AddHandler picture.Click, AddressOf pictureClicked
        '        toptlp.Controls.Add(picture, 0, 0)
        '        Dim title As New Label
        '        title.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        '        title.Text = topreader("thesistitle").ToString
        '        title.Dock = DockStyle.Fill
        '        title.TextAlign = ContentAlignment.MiddleCenter
        '        toptlp.Controls.Add(title, 0, 2)
        '        Dim best As New Label
        '        best.TextAlign = ContentAlignment.MiddleCenter
        '        best.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        '        best.Text = topreader("topthesiscategoryname").ToString
        '        best.Dock = DockStyle.Fill
        '        toptlp.Controls.Add(best, 0, 1)
        '        topsflp.Controls.Add(toptlp)





        '    End While

        '    topconn.Close()
        '    flpMain.Controls.Add(topsflp)
        'End While


        'yearconn.Close()














        'For i As Integer = 2017 To 2010 Step -1 'SELECT DISTINCT yeartopped FROM topthesistbl ORDER  BY yeartopped DESC
        '    Dim datepanel As New Panel
        '    Dim datelabel As New Label
        '    datepanel.Name = i
        '    datepanel.Height = 50
        '    datepanel.Width = 950
        '    datelabel.TextAlign = ContentAlignment.MiddleCenter
        '    datelabel.Text = i
        '    datelabel.Dock = DockStyle.Fill
        '    datelabel.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        '    datepanel.Controls.Add(datelabel)
        '    flpMain.Controls.Add(datepanel)

        '    Dim topsflp As New FlowLayoutPanel
        '    topsflp.FlowDirection = FlowDirection.LeftToRight
        '    topsflp.AutoScroll = True
        '    topsflp.WrapContents = False
        '    topsflp.Height = 450
        '    topsflp.Width = 950
        '    'topsflp.AutoSize = True
        '    For ii As Integer = 0 To 4
        '        Dim toptlp As New TableLayoutPanel
        '        toptlp.Width = 250
        '        toptlp.Height = 400
        '        toptlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 250))
        '        toptlp.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 250))
        '        toptlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 50))
        '        toptlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 100))
        '        Dim picture As New PictureBox
        '        picture.Dock = DockStyle.Fill
        '        picture.SizeMode = PictureBoxSizeMode.StretchImage
        '        picture.Name = i & " " & ii
        '        picture.Image = Image.FromFile("C:\Users\C a e l l a c h\Pictures\10339503_862366663791511_3136520635685879242_o.jpg")
        '        AddHandler picture.Click, AddressOf pictureClicked
        '        toptlp.Controls.Add(picture, 0, 0)
        '        Dim title As New Label
        '        title.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        '        title.Text = "This is the title"
        '        title.Dock = DockStyle.Fill
        '        title.TextAlign = ContentAlignment.MiddleCenter
        '        toptlp.Controls.Add(title, 0, 2)
        '        Dim best As New Label
        '        best.TextAlign = ContentAlignment.MiddleCenter
        '        best.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        '        best.Text = "Best in Database Design"
        '        best.Dock = DockStyle.Fill
        '        toptlp.Controls.Add(best, 0, 1)
        '        topsflp.Controls.Add(toptlp)
        '    Next
        '    flpMain.Controls.Add(topsflp)
        'Next
    End Sub

    Public Sub refreshCbo()

        cboCategory.Items.Clear()
        cboDate.Items.Clear()

        yearconn.ConnectionString = connstring
        yearconn.Open()

        Dim yearcomm As New MySqlCommand
        Dim yearcommstring As String = "SELECT DISTINCT yeartopped FROM topthesistbl ORDER  BY yeartopped DESC"
        Dim yearreader As MySqlDataReader
        yearcomm.CommandText = yearcommstring
        yearcomm.Connection = yearconn
        yearreader = yearcomm.ExecuteReader

        cboDate.Items.Add("ALL")
        While (yearreader.Read)
            cboDate.Items.Add(yearreader("yeartopped").ToString)
        End While
        yearconn.Close()





        topconn.ConnectionString = connstring
        topconn.Open()

        Dim topcomm As New MySqlCommand
        Dim topcommstring As String = "SELECT * FROM topthesiscategorytbl"
        Dim topreader As MySqlDataReader
        topcomm.CommandText = topcommstring
        topcomm.Connection = topconn
        topreader = topcomm.ExecuteReader

        cboCategory.Items.Add("ALL")
        While (topreader.Read)
            cboCategory.Items.Add(topreader("topthesiscategoryname").ToString)
        End While

        topconn.Close()
        cboDate.SelectedIndex = 0
        cboCategory.SelectedIndex = 0

        'cboDate.SelectedIndex = 0
        'cboCategory.SelectedIndex = 0
    End Sub



    Public Sub loadTopTheses()
        refreshCbo()
        flpMain.Controls.Clear()

        filterChanged(cboCategory.Text, cboDate.Text) 'ito ang ipinalit ko sa mahaba sa baba
        'yearconn.ConnectionString = connstring
        'yearconn.Open()


        'Dim yearcomm As New MySqlCommand
        'Dim yearcommstring As String = "SELECT DISTINCT yeartopped FROM topthesistbl ORDER  BY yeartopped DESC"
        'Dim yearreader As MySqlDataReader
        'yearcomm.CommandText = yearcommstring
        'yearcomm.Connection = yearconn
        'yearreader = yearcomm.ExecuteReader

        'While (yearreader.Read)
        '    Dim datepanel As New Panel
        '    Dim datelabel As New Label
        '    datepanel.Name = yearreader("yeartopped").ToString
        '    datepanel.Height = 50
        '    datepanel.Width = 1025
        '    '1164x696
        '    datelabel.TextAlign = ContentAlignment.MiddleCenter
        '    datelabel.Text = yearreader("yeartopped").ToString
        '    datelabel.Dock = DockStyle.Fill
        '    datelabel.ForeColor = Color.White
        '    datelabel.Font = New Font("Century Gothic", 15, FontStyle.Regular)
        '    datepanel.BackColor = Color.FromArgb(255, 6, 69, 133)
        '    datepanel.Controls.Add(datelabel)
        '    flpMain.Controls.Add(datepanel)

        '    Dim topsflp As New FlowLayoutPanel
        '    topsflp.FlowDirection = FlowDirection.LeftToRight
        '    topsflp.AutoScroll = True
        '    topsflp.WrapContents = False
        '    topsflp.Height = 450
        '    topsflp.Width = 1025
        '    'topsflp.AutoSize = True


        '    topconn.ConnectionString = connstring
        '    topconn.Open()

        '    Dim topcomm As New MySqlCommand
        '    Dim topcommstring As String = "SELECT * FROM `topthesistbl` LEFT JOIN thesistbl ON topthesistbl.thesisid = thesistbl.thesisid LEFT JOIN topthesiscategorytbl ON topthesistbl.topthesiscategoryid = topthesiscategorytbl.topthesiscategoryid WHERE yeartopped=" & yearreader("yeartopped").ToString
        '    Dim topreader As MySqlDataReader
        '    topcomm.CommandText = topcommstring
        '    topcomm.Connection = topconn
        '    topreader = topcomm.ExecuteReader

        '    While (topreader.Read)


        '        Dim toptlp As New TableLayoutPanel

        '        AddHandler toptlp.Click, AddressOf tlpClicked
        '        AddHandler toptlp.MouseHover, AddressOf tlpselected
        '        AddHandler toptlp.MouseEnter, AddressOf tlpselected
        '        AddHandler toptlp.MouseLeave, AddressOf tlpdisselected



        '        toptlp.Name = topreader("thesisid").ToString
        '        toptlp.BackColor = Color.FromArgb(255, 6, 69, 133)
        '        toptlp.Width = 250
        '        toptlp.Height = 400
        '        toptlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 250))
        '        toptlp.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 250))
        '        toptlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 50))
        '        toptlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 100))
        '        Dim picture As New PictureBox
        '        AddHandler picture.Click, AddressOf pictureClicked
        '        AddHandler picture.MouseHover, AddressOf pictureselected
        '        AddHandler picture.MouseEnter, AddressOf pictureselected
        '        AddHandler picture.MouseLeave, AddressOf picturedisselected
        '        picture.Dock = DockStyle.Fill
        '        picture.SizeMode = PictureBoxSizeMode.StretchImage
        '        picture.Name = topreader("thesisid").ToString
        '        picture.Image = Image.FromFile(topreader("thesispath").ToString & ".jpg")
        '        toptlp.Controls.Add(picture, 0, 0)
        '        Dim title As New Label
        '        AddHandler title.Click, AddressOf labelClicked
        '        AddHandler title.MouseHover, AddressOf controlselected
        '        AddHandler title.MouseEnter, AddressOf controlselected
        '        AddHandler title.MouseLeave, AddressOf controldisselected
        '        title.Name = topreader("thesisid").ToString
        '        title.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        '        title.Text = topreader("thesistitle").ToString
        '        title.ForeColor = Color.White
        '        title.Dock = DockStyle.Fill
        '        title.TextAlign = ContentAlignment.MiddleCenter
        '        toptlp.Controls.Add(title, 0, 2)
        '        Dim best As New Label
        '        AddHandler best.Click, AddressOf labelClicked
        '        AddHandler best.MouseHover, AddressOf controlselected
        '        AddHandler best.MouseEnter, AddressOf controlselected
        '        AddHandler best.MouseLeave, AddressOf controldisselected
        '        best.Name = topreader("thesisid").ToString
        '        best.TextAlign = ContentAlignment.MiddleCenter
        '        best.Font = New Font("Century Gothic", 12, FontStyle.Regular)
        '        best.ForeColor = Color.White
        '        best.Text = topreader("topthesiscategoryname").ToString
        '        best.Dock = DockStyle.Fill
        '        toptlp.Controls.Add(best, 0, 1)
        '        topsflp.Controls.Add(toptlp)





        '    End While

        '    topconn.Close()
        '    flpMain.Controls.Add(topsflp)
        'End While


        'yearconn.Close()
    End Sub

    Public Sub filterChanged(categoryFilter As String, dateFilter As String)
        flpMain.Controls.Clear()
        yearconn.ConnectionString = connstring
        yearconn.Open()


        Dim yearcomm As New MySqlCommand
        Dim yearcommstring As String = "SELECT DISTINCT yeartopped FROM topthesistbl"
        If Not dateFilter.Equals("ALL") Or dateFilter.Equals("") Then
            yearcommstring = yearcommstring & " WHERE yeartopped = " & dateFilter
        End If
        yearcommstring = yearcommstring & " ORDER  BY yeartopped DESC"
        Dim yearreader As MySqlDataReader
        yearcomm.CommandText = yearcommstring
        yearcomm.Connection = yearconn
        yearreader = yearcomm.ExecuteReader

        While (yearreader.Read)
            Dim datepanel As New Panel
            Dim datelabel As New Label
            datepanel.Name = yearreader("yeartopped").ToString
            datepanel.Height = 50
            datepanel.Width = 1025
            '1164x696
            datelabel.TextAlign = ContentAlignment.MiddleCenter
            datelabel.Text = yearreader("yeartopped").ToString
            datelabel.Dock = DockStyle.Fill
            datelabel.ForeColor = Color.White
            datelabel.Font = New Font("Century Gothic", 15, FontStyle.Regular)
            datepanel.BackColor = Color.FromArgb(255, 6, 69, 133)
            datepanel.Controls.Add(datelabel)
            flpMain.Controls.Add(datepanel)

            Dim topsflp As New FlowLayoutPanel
            topsflp.FlowDirection = FlowDirection.LeftToRight
            topsflp.AutoScroll = True
            topsflp.WrapContents = False
            topsflp.Height = 450
            topsflp.Width = 1025
            'topsflp.AutoSize = True


            topconn.ConnectionString = connstring
            topconn.Open()

            Dim topcomm As New MySqlCommand
            Dim topcommstring As String = "SELECT * FROM `topthesistbl` LEFT JOIN thesistbl ON topthesistbl.thesisid = thesistbl.thesisid LEFT JOIN topthesiscategorytbl ON topthesistbl.topthesiscategoryid = topthesiscategorytbl.topthesiscategoryid WHERE yeartopped=" & yearreader("yeartopped").ToString
            If Not categoryFilter.Equals("ALL") Or categoryFilter.Equals("") Then
                topcommstring = topcommstring & " AND topthesiscategoryname = '" & categoryFilter & "'"
            End If
            Dim topreader As MySqlDataReader
            topcomm.CommandText = topcommstring
            topcomm.Connection = topconn
            topreader = topcomm.ExecuteReader

            Dim counter As Integer = 0
            While (topreader.Read)
                counter += 1

                Dim toptlp As New TableLayoutPanel


                AddHandler toptlp.Click, AddressOf tlpClicked
                AddHandler toptlp.MouseHover, AddressOf tlpselected
                AddHandler toptlp.MouseEnter, AddressOf tlpselected
                AddHandler toptlp.MouseLeave, AddressOf tlpdisselected



                toptlp.Name = topreader("thesisid").ToString
                toptlp.BackColor = Color.FromArgb(255, 6, 69, 133)
                toptlp.Width = 250
                toptlp.Height = 400
                toptlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 250))
                toptlp.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 250))
                toptlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 50))
                toptlp.RowStyles.Add(New RowStyle(SizeType.Absolute, 100))
                Dim picture As New PictureBox
                AddHandler picture.Click, AddressOf pictureClicked
                AddHandler picture.MouseHover, AddressOf pictureselected
                AddHandler picture.MouseEnter, AddressOf pictureselected
                AddHandler picture.MouseLeave, AddressOf picturedisselected
                picture.Dock = DockStyle.Fill
                picture.SizeMode = PictureBoxSizeMode.StretchImage
                picture.Name = topreader("thesisid").ToString
                picture.Image = Image.FromFile(topreader("thesispath").ToString & ".jpg")
                toptlp.Controls.Add(picture, 0, 0)
                Dim title As New Label
                AddHandler title.Click, AddressOf labelClicked
                AddHandler title.MouseHover, AddressOf controlselected
                AddHandler title.MouseEnter, AddressOf controlselected
                AddHandler title.MouseLeave, AddressOf controldisselected
                title.Name = topreader("thesisid").ToString
                title.Font = New Font("Century Gothic", 12, FontStyle.Regular)
                title.Text = topreader("thesistitle").ToString
                title.ForeColor = Color.White
                title.Dock = DockStyle.Fill
                title.TextAlign = ContentAlignment.MiddleCenter
                toptlp.Controls.Add(title, 0, 2)
                Dim best As New Label
                AddHandler best.Click, AddressOf labelClicked
                AddHandler best.MouseHover, AddressOf controlselected
                AddHandler best.MouseEnter, AddressOf controlselected
                AddHandler best.MouseLeave, AddressOf controldisselected
                best.Name = topreader("thesisid").ToString
                best.TextAlign = ContentAlignment.MiddleCenter
                best.Font = New Font("Century Gothic", 12, FontStyle.Regular)
                best.ForeColor = Color.White
                best.Text = topreader("topthesiscategoryname").ToString
                best.Dock = DockStyle.Fill
                toptlp.Controls.Add(best, 0, 1)
                topsflp.Controls.Add(toptlp)





            End While

            topconn.Close()
            If Not counter = 0 Then
                flpMain.Controls.Add(topsflp)
            End If

        End While


        yearconn.Close()
    End Sub


    Public Sub pictureClicked(sender As Object, e As EventArgs)
        Dim pictureClicked As PictureBox = CType(sender, PictureBox)

        'If ContainerForm.retrievethesisview.PictureBox1.Image Is Nothing Then
        'Else
        '    ContainerForm.retrievethesisview.PictureBox1.Image.Dispose()
        'End If
        '        For Each con As FlowLayoutPanel In ContainerForm.topthesis.flpMain.Controls.OfType(Of FlowLayoutPanel)
        '    For Each cont As TableLayoutPanel In con.Controls.OfType(Of TableLayoutPanel)
        '        For Each contr As PictureBox In cont.Controls.OfType(Of PictureBox)
        '            contr.Image.Dispose()
        '        Next
        '    Next
        'Next


        ContainerForm.executeTaskQuery("Top Thesis", "Clicked a thesis (" & getTitle(pictureClicked.Name) & ")")


        ContainerForm.retrievethesisview.viewthesis(pictureClicked.Name)


        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.Panel1.Controls.Add(ContainerForm.retrievethesisview)
        ContainerForm.retrievethesisview.Show()

        ContainerForm.btnViewThesis.BackColor = ColorTranslator.FromHtml("#f7e041")
        ContainerForm.btnViewThesis.ForeColor = ColorTranslator.FromHtml("#064585")
        ContainerForm.btnViewThesis.Font = New Font("Century Gothic", 12, FontStyle.Bold)
        ContainerForm.selectedmenu = 3
        ContainerForm.menuclicked()
    End Sub

    Public Sub labelClicked(sender As Object, e As EventArgs)
        Dim pictureClicked As Label = CType(sender, Label)

        ContainerForm.executeTaskQuery("Top Thesis", "Clicked a thesis (" & getTitle(pictureClicked.Name) & ")")

        ContainerForm.retrievethesisview.viewthesis(pictureClicked.Name)

        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.Panel1.Controls.Add(ContainerForm.retrievethesisview)
        ContainerForm.retrievethesisview.Show()

        ContainerForm.btnViewThesis.BackColor = ColorTranslator.FromHtml("#f7e041")
        ContainerForm.btnViewThesis.ForeColor = ColorTranslator.FromHtml("#064585")
        ContainerForm.btnViewThesis.Font = New Font("Century Gothic", 12, FontStyle.Bold)
        ContainerForm.selectedmenu = 3
        ContainerForm.menuclicked()

    End Sub

    Public Sub controlselected(sender As Object, e As EventArgs)
        CType(sender, Label).Parent.BackColor = ColorTranslator.FromHtml("#f7e041")
        For Each textlabel As Label In CType(sender, Label).Parent.Controls.OfType(Of Label)
            textlabel.ForeColor = Color.FromArgb(255, 6, 69, 133)
        Next
    End Sub
    Public Sub controldisselected(sender As Object, e As EventArgs)
        CType(sender, Label).Parent.BackColor = Color.FromArgb(255, 6, 69, 133)
        For Each textlabel As Label In CType(sender, Label).Parent.Controls.OfType(Of Label)
            textlabel.ForeColor = Color.White
        Next
    End Sub
    Public Sub pictureselected(sender As Object, e As EventArgs)
        CType(sender, PictureBox).Parent.BackColor = ColorTranslator.FromHtml("#f7e041")
        For Each textlabel As Label In CType(sender, PictureBox).Parent.Controls.OfType(Of Label)
            textlabel.ForeColor = Color.FromArgb(255, 6, 69, 133)
        Next
    End Sub
    Public Sub picturedisselected(sender As Object, e As EventArgs)
        CType(sender, PictureBox).Parent.BackColor = Color.FromArgb(255, 6, 69, 133)
        For Each textlabel As Label In CType(sender, PictureBox).Parent.Controls.OfType(Of Label)
            textlabel.ForeColor = Color.White
        Next
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        filterChanged(cboCategory.Text, cboDate.Text)
    End Sub

    Private Sub cboDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDate.SelectedIndexChanged
        filterChanged(cboCategory.Text, cboDate.Text)
    End Sub

    Public Function getTitle(id As String) As String
        topconn.ConnectionString = connstring
        topconn.Open()
        Dim comm As New MySqlCommand
        comm.CommandType = CommandType.Text
        comm.Connection = topconn
        comm.CommandText = "SELECT * FROM thesistbl WHERE thesisid = " & id
        Dim reader As MySqlDataReader
        reader = comm.ExecuteReader

        Dim title As String = ""
        While reader.Read
            title = reader("thesistitle").ToString
        End While

        topconn.Close()
        Return title


    End Function

    Private Sub tlpselected(sender As Object, e As EventArgs)
        CType(sender, TableLayoutPanel).BackColor = ColorTranslator.FromHtml("#f7e041")
        For Each textlabel As Label In CType(sender, TableLayoutPanel).Controls.OfType(Of Label)
            textlabel.ForeColor = Color.FromArgb(255, 6, 69, 133)
        Next
    End Sub

    Private Sub tlpdisselected(sender As Object, e As EventArgs)
        CType(sender, TableLayoutPanel).BackColor = Color.FromArgb(255, 6, 69, 133)
        For Each textlabel As Label In CType(sender, TableLayoutPanel).Controls.OfType(Of Label)
            textlabel.ForeColor = Color.White
        Next
    End Sub

    Private Sub tlpClicked(sender As Object, e As EventArgs)
        Dim pictureClicked As TableLayoutPanel = CType(sender, TableLayoutPanel)

        ContainerForm.executeTaskQuery("Top Thesis", "Clicked a thesis (" & getTitle(pictureClicked.Name) & ")")

        ContainerForm.retrievethesisview.viewthesis(pictureClicked.Name)


        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.Panel1.Controls.Add(ContainerForm.retrievethesisview)
        ContainerForm.retrievethesisview.Show()

        ContainerForm.btnViewThesis.BackColor = ColorTranslator.FromHtml("#f7e041")
        ContainerForm.btnViewThesis.ForeColor = ColorTranslator.FromHtml("#064585")
        ContainerForm.btnViewThesis.Font = New Font("Century Gothic", 12, FontStyle.Bold)
        ContainerForm.selectedmenu = 3
        ContainerForm.menuclicked()
    End Sub

End Class