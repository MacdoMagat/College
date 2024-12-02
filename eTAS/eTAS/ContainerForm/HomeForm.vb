Public Class HomeForm




    Private Sub Mouse_Leave(sender As Object, e As EventArgs) Handles RoundButton4.MouseLeave, RoundButton3.MouseLeave, RoundButton2.MouseLeave, RoundButton1.MouseLeave
        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("main home")
        RoundButton1.ForeColor = Color.Black
        RoundButton2.ForeColor = Color.Black
        RoundButton3.ForeColor = Color.Black
        RoundButton4.ForeColor = Color.Black
    End Sub

    Private Sub RoundButton1_MouseEnter(sender As Object, e As EventArgs) Handles RoundButton1.MouseEnter
        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("home 1")
        RoundButton1.ForeColor = Color.White
    End Sub

    Private Sub RoundButton2_MouseEnter(sender As Object, e As EventArgs) Handles RoundButton2.MouseEnter
        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("home 2")
        RoundButton2.ForeColor = Color.White
    End Sub

    Private Sub RoundButton3_MouseEnter(sender As Object, e As EventArgs) Handles RoundButton3.MouseEnter
        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("home 3")
        RoundButton3.ForeColor = Color.White
    End Sub

    Private Sub RoundButton4_MouseEnter(sender As Object, e As EventArgs) Handles RoundButton4.MouseEnter
        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("home 4")
        RoundButton4.ForeColor = Color.White
    End Sub
    'Dim counter As Integer
    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    Me.BackgroundImage.Dispose()
    '    If counter = 1 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("2")
    '        counter = 2
    '    ElseIf counter = 2 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("3")
    '        counter = 3
    '    ElseIf counter = 3 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("4")
    '        counter = 4
    '    ElseIf counter = 4 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("5")
    '        counter = 5
    '    ElseIf counter = 5 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("6")
    '        counter = 6
    '    ElseIf counter = 6 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("1")
    '        counter = 1
    '    Else
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("1")
    '        counter = 1
    '    End If

    'End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Timer1.Stop()
    '    Timer1.Start()
    '    Me.BackgroundImage.Dispose()
    '    If counter = 1 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("6")
    '        counter = 6
    '    ElseIf counter = 2 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("1")
    '        counter = 1
    '    ElseIf counter = 3 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("2")
    '        counter = 2
    '    ElseIf counter = 4 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("3")
    '        counter = 3
    '    ElseIf counter = 5 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("4")
    '        counter = 4
    '    ElseIf counter = 6 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("5")
    '        counter = 5
    '    Else
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("1")
    '        counter = 1
    '    End If
    'End Sub

    'Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    Me.BackgroundImage = My.Resources.ResourceManager.GetObject("1")
    '    counter = 1
    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    Timer1.Stop()
    '    Timer1.Start()
    '    Me.BackgroundImage.Dispose()
    '    If counter = 1 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("2")
    '        counter = 2
    '    ElseIf counter = 2 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("3")
    '        counter = 3
    '    ElseIf counter = 3 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("4")
    '        counter = 4
    '    ElseIf counter = 4 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("5")
    '        counter = 5
    '    ElseIf counter = 5 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("6")
    '        counter = 6
    '    ElseIf counter = 6 Then
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("1")
    '        counter = 1
    '    Else
    '        Me.BackgroundImage = My.Resources.ResourceManager.GetObject("1")
    '        counter = 1
    '    End If
    'End Sub

    'Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
    '    Button1.BackColor = Color.AntiqueWhite
    'End Sub

    'Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
    '    Button1.BackColor = Color.Transparent
    'End Sub

    'Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles Button2.MouseEnter
    '    Button2.BackColor = Color.AntiqueWhite
    'End Sub

    'Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
    '    Button2.BackColor = Color.Transparent
    'End Sub

    ''Private Sub HomeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    ''    'Me.BackgroundImage = My.Resources.ResourceManager.GetObject("")
    ''End Sub

    ''Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    ''End Sub

    ''Public Sub changebackground()
    ''    Me.BackgroundImage = Image.FromFile("C:\Users\C a e l l a c h\Desktop\359422-Ralph-Waldo-Emerson-Quote-Sometimes-a-scream-is-better-than-a.jpg")
    ''End Sub

End Class