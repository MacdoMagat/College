Public Class MainForm

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim form As New HomeForm
        form.TopLevel = False
        form.Dock = DockStyle.Fill
        Me.SplitContainer1.Panel2.Controls.Add(form)
        form.Show()
        'form.Parent = Me.SplitContainer1.Panel2
        'form.Anchor = AnchorStyles.Bottom
        'form.Anchor = AnchorStyles.Top
        'form.Anchor = AnchorStyles.Left
        'form.Anchor = AnchorStyles.Right
        'form.BringToFront()
        'Me.SplitContainer1.Panel2.Controls(0).Dock = DockStyle.Fill
        'Me.MaximizeBox = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("Width: " & Me.Width.ToString & "; Height: " & Me.Height.ToString & vbNewLine & "Left Panel Width: " & Me.SplitContainer1.Panel1.Width.ToString & "; Left Panel Height: " & Me.SplitContainer1.Panel1.Height.ToString & vbNewLine & "Right Panel Width: " & Me.SplitContainer1.Panel2.Width.ToString & "; Right Panel Height: " & Me.SplitContainer1.Panel2.Height.ToString)
        MsgBox(Date.Now.ToString)
    End Sub

    Private Sub addbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addbtn.Click
        Me.SplitContainer1.Panel2.Controls.Clear()

        Dim form As New AddForm
        form.TopLevel = False
        'form.Parent = Me.SplitContainer1.Panel2
        form.Dock = DockStyle.Fill
        Me.SplitContainer1.Panel2.Controls.Add(form)
        'Panel1.Location = New Point(100, 100)
        'MsgBox(Panel1.Location.ToString)
        'form.Parent = Panel1
        'Panel1.Width = 100
        'Panel1.Height = 100
        form.Show()
    End Sub

    Private Sub homebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles homebtn.Click
        Me.SplitContainer1.Panel2.Controls.Clear()

        Dim form As New HomeForm
        form.TopLevel = False
        'form.Parent = Me.SplitContainer1.Panel2
        form.Dock = DockStyle.Fill
        Me.SplitContainer1.Panel2.Controls.Add(form)
        form.Show()
    End Sub

    Private Sub reportbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reportbtn.Click
        'Me.SplitContainer1.Panel2.Controls.Clear()
        MsgBox("Function will be added soon!")
        'Dim form As New ReportsForm
        'form.TopLevel = False
        'form.Parent = Me.SplitContainer1.Panel2
        'form.Dock = DockStyle.Fill
        'Me.SplitContainer1.Panel2.Controls.Add(form)
        'form.Show()
    End Sub


    Private Sub printbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles printbtn.Click
        Me.SplitContainer1.Panel2.Controls.Clear()

        Dim form As New PrintForm
        form.TopLevel = False
        'form.Parent = Me.SplitContainer1.Panel2
        form.Dock = DockStyle.Fill
        Me.SplitContainer1.Panel2.Controls.Add(form)
        form.Show()

        'Dim connection As New Connections
        'connection.loadExaminee()
    End Sub

    Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'Panel1.Location = New Point(100, 200)
        'Panel1.Width = 200
        'Panel1.Height = 200
    End Sub

    Private Sub helpbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles helpbtn.Click
        'Me.SplitContainer1.Panel2.Controls.Clear()
        MsgBox("Function will be added soon!")
        'Dim form As New PrintForm
        'form.TopLevel = False
        'Panel1.Location = New Point(100, 100)
        'MsgBox(Panel1.Location.ToString)
        'form.Parent = Panel1
        'Panel1.Controls.Add(form)
        'form.Dock = DockStyle.Fill
        'Panel1.Width = 800
        'Panel1.Height = 800
        'form.Show()
    End Sub

    Private Sub aboutbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aboutbtn.Click
        'Panel1.Size = New Size(500, 500)
        Me.SplitContainer1.Panel2.Controls.Clear()

        Dim form As New AboutForm
        form.TopLevel = False
        'form.Parent = Me.SplitContainer1.Panel2
        form.Dock = DockStyle.Fill
        Me.SplitContainer1.Panel2.Controls.Add(form)
        form.Show()
    End Sub

    Private Sub adminbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adminbtn.Click
        MsgBox("Function will be added soon!")
    End Sub
End Class
