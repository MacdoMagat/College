Imports System.Security.AccessControl
Imports System.IO
Imports System

Public Class eTASStartForm

    Dim adminlogin As New AdminLoginForm
    Dim login As New LoginForm
    Dim guestlogin As New GuestLoginForm
    Public departmentSelected As String = "IT"
    Dim departmentSelection As New DepartmentSelectionForm

    Private Sub eTASStartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        adminlogin.TopLevel = False
        adminlogin.Dock = DockStyle.Fill
        'adminlogin.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        'adminlogin.DoubleBuffered = True
        login.TopLevel = False
        login.Dock = DockStyle.Fill
        guestlogin.TopLevel = False
        guestlogin.Dock = DockStyle.Fill
        departmentSelection.TopLevel = False
        departmentSelection.Dock = DockStyle.Fill

        Panel1.Controls.Add(departmentSelection)
        departmentSelection.Show()


        Dim counter As Integer = 0
        For Each p As Process In System.Diagnostics.Process.GetProcesses
            If p.ProcessName.Equals("httpd") Then
                counter += 1
            End If
        Next

        If counter = 0 Then
            Dim startinfo As New ProcessStartInfo("C:\xampp\xampp_start.exe")
            startinfo.WindowStyle = ProcessWindowStyle.Hidden
            Process.Start(startinfo)
        End If

        'For Each p As Process In System.Diagnostics.Process.GetProcessesByName("WINWORD")
        '    MsgBox(p.Id.ToString)
        '    MsgBox(p.ToString)
        '    MsgBox(p.MainWindowTitle.ToString)
        'Next




        'for unlocking
        Dim dInfo As New DirectoryInfo(Application.StartupPath.ToString & "\Documents")

        ' Get a DirectorySecurity object that represents the 
        ' current security settings.
        Dim dSecurity As DirectorySecurity = dInfo.GetAccessControl()

        ' Add the FileSystemAccessRule to the security settings. 
        dSecurity.RemoveAccessRule(New FileSystemAccessRule("Administrators", FileSystemRights.FullControl, AccessControlType.Deny))


        ' Set the new access settings.
        dInfo.SetAccessControl(dSecurity)
        'MsgBox("Unlocked")
        'end of unlocking


        'Dim fs As FileSystemSecurity = File.GetAccessControl(TextBox1.Text)
        'fs.RemoveAccessRule(New FileSystemAccessRule(Environment.UserDomainName, FileSystemRights.FullControl, AccessControlType.Deny))
        'File.SetAccessControl(TextBox1.Text, fs)













        Me.Select()
        'For Each p As Process In System.Diagnostics.Process.GetProcessesByName("httpd")
        'Next
        'For Each p As Process In System.Diagnostics.Process.GetProcessesByName("WINWORD")
        '    Try
        '        p.Kill()
        '        p.WaitForExit()
        '    Catch ex As Exception

        '    End Try
        'Next

    End Sub

    Public Sub adminclicked()
        Panel1.Controls.Clear()
        adminlogin.changeConnstring(departmentSelected)
        Panel1.Controls.Add(adminlogin)
        adminlogin.Show()
        adminlogin.txtun.Focus()
    End Sub

    Public Sub adminbackclicked()
        adminlogin.clearfields()
        Panel1.Controls.Clear()
        Panel1.Controls.Add(login)
        login.Show()
    End Sub

    Public Sub guestbackclicked()
        guestlogin.clearfields()
        Panel1.Controls.Clear()
        Panel1.Controls.Add(login)
        login.Show()
    End Sub

    Public Sub guestclicked()
        Panel1.Controls.Clear()
        guestlogin.changeConnstring(departmentSelected)
        Panel1.Controls.Add(guestlogin)
        guestlogin.Show()
        guestlogin.txtfirstname.Focus()
    End Sub



    Private Sub eTASStartForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Dim dInfo As New DirectoryInfo(Application.StartupPath.ToString & "\Documents")

        ' Get a DirectorySecurity object that represents the 
        ' current security settings.
        Dim dSecurity As DirectorySecurity = dInfo.GetAccessControl()

        ' Add the FileSystemAccessRule to the security settings. 
        dSecurity.SetAccessRule(New FileSystemAccessRule("Administrators", FileSystemRights.FullControl, AccessControlType.Deny))




        ' Set the new access settings.
        dInfo.SetAccessControl(dSecurity)


        'Dim fs As FileSystemSecurity = File.GetAccessControl(TextBox1.Text)
        'fs.AddAccessRule(New FileSystemAccessRule(Environment.UserDomainName, FileSystemRights.FullControl, AccessControlType.Deny))
        'File.SetAccessControl(TextBox1.Text, fs)
    End Sub

    Public Sub departmentClicked()
        Panel1.Controls.Clear()
        Panel1.Controls.Add(login)
        login.Show()
    End Sub

    Public Sub reselectDepartment()
        Panel1.Controls.Clear()
        Panel1.Controls.Add(departmentSelection)
        departmentSelection.Show()
    End Sub

End Class