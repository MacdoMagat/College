Imports MySql.Data.MySqlClient
Public Class ContentSearchSettingsForm

    Dim conn As New MySqlConnection
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


    Public Sub settingload()
        If ContainerForm.contentsearchtype = 1 Then
            matchCaseRdo.Checked = True
            wildCardsRdo.Checked = False
            singleWordRdo.Checked = False
            fiveWordsRdo.Checked = False
            allWordsRdo.Checked = False
            singleWordRdo.Enabled = False
            fiveWordsRdo.Enabled = False
            allWordsRdo.Enabled = False
        Else
            matchCaseRdo.Checked = False
            wildCardsRdo.Checked = True
            If ContainerForm.contentsearchtype = 2 Then
                singleWordRdo.Checked = True
                fiveWordsRdo.Checked = False
                allWordsRdo.Checked = False
            ElseIf ContainerForm.contentsearchtype = 3 Then
                singleWordRdo.Checked = False
                fiveWordsRdo.Checked = True
                allWordsRdo.Checked = False
            ElseIf ContainerForm.contentsearchtype = 4 Then
                singleWordRdo.Checked = False
                fiveWordsRdo.Checked = False
                allWordsRdo.Checked = True
            End If
        End If
        refreshCboCategory()
        cboCategory.Text = ContainerForm.contentsearchCategoryFilter
    End Sub

    Public Sub refreshCboCategory()
        cboCategory.Items.Clear()

        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM platformtbl"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader
        cboCategory.Items.Add("All")
        While (reader.Read)
            cboCategory.Items.Add(reader("platformname").ToString)
        End While

        cboCategory.SelectedIndex = 0
        conn.Close()
    End Sub

    Private Sub matchCaseRdo_CheckedChanged(sender As Object, e As EventArgs) Handles matchCaseRdo.CheckedChanged
        If matchCaseRdo.Checked = True Then
            wildCardsRdo.Checked = False
            singleWordRdo.Checked = False
            fiveWordsRdo.Checked = False
            allWordsRdo.Checked = False
            singleWordRdo.Enabled = False
            fiveWordsRdo.Enabled = False
            allWordsRdo.Enabled = False
        End If
    End Sub

    Private Sub wildCardsRdo_CheckedChanged(sender As Object, e As EventArgs) Handles wildCardsRdo.CheckedChanged
        If wildCardsRdo.Checked = True Then
            matchCaseRdo.Checked = False
            singleWordRdo.Checked = True
            singleWordRdo.Enabled = True
            fiveWordsRdo.Enabled = True
            allWordsRdo.Enabled = True
        End If
    End Sub

    Private Sub singleWordRdo_CheckedChanged(sender As Object, e As EventArgs) Handles singleWordRdo.CheckedChanged
        If singleWordRdo.Checked = True Then
            fiveWordsRdo.Checked = False
            allWordsRdo.Checked = False
        End If
    End Sub

    Private Sub fiveWordsRdo_CheckedChanged(sender As Object, e As EventArgs) Handles fiveWordsRdo.CheckedChanged
        If fiveWordsRdo.Checked = True Then
            singleWordRdo.Checked = False
            allWordsRdo.Checked = False
        End If
    End Sub

    Private Sub allWordsRdo_CheckedChanged(sender As Object, e As EventArgs) Handles allWordsRdo.CheckedChanged
        If allWordsRdo.Checked = True Then
            singleWordRdo.Checked = False
            fiveWordsRdo.Checked = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If matchCaseRdo.Checked = True Then
            ContainerForm.contentsearchtype = 1
        ElseIf singleWordRdo.Checked = True Then
            ContainerForm.contentsearchtype = 2
        ElseIf fiveWordsRdo.Checked = True Then
            ContainerForm.contentsearchtype = 3
        ElseIf allWordsRdo.Checked = True Then
            ContainerForm.contentsearchtype = 4
        Else
            MsgBox("Error on Settings")
            ContainerForm.contentsearchtype = 1
        End If
        ContainerForm.contentsearchCategoryFilter = cboCategory.Text
        Me.Close()


    End Sub

End Class