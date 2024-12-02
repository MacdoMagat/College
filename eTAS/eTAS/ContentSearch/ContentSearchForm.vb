Imports Word = Microsoft.Office.Interop.Word
Imports MySql.Data.MySqlClient
Imports System.Math
Imports System.ComponentModel

Public Class ContentSearchForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Dim searchsettings As Integer
    Dim searchedstring As New List(Of String)
    Dim categoryFilter As String


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


    Public Sub search(rng As Word.Range, searchstring As String, path As String, thesisid As String, thesistitle As String)
        'For i As Integer = 1 To rng.Paragraphs.Count
        '    Label3.Text = i & " of " & rng.Paragraphs.Count & " paragraphs"
        '    With rng.Paragraphs.Item(i).Range.Find
        '        .Text = searchstring
        '        .Forward = True
        '        .Execute()
        '        If .Found = True Then
        '            DataGridView1.Rows.Add(thesisid, thesistitle, "Match Found on paragraph " & i)
        '        End If
        '    End With
        'Next


        Dim counter As Integer = Floor(searchstring.Count / 255)
        For i As Integer = 1 To rng.Paragraphs.Count
            'Label3.Text = i & " of " & rng.Paragraphs.Count & " paragraphs"
            Label3.Text = i & " of " & rng.Paragraphs.Count & " paragraphs"
            With rng.Paragraphs.Item(i).Range.Find
                Dim newsearchstring As String
                If searchstring.Count > 255 Then
                    For o As Integer = 0 To counter
                        If o = counter Then
                            newsearchstring = searchstring.Substring(255 * o, searchstring.Count Mod 255)
                        Else
                            newsearchstring = searchstring.Substring(255 * o, 255)
                        End If
                        If newsearchstring.Count < 15 Then
                            Exit For
                        End If
                        .Text = newsearchstring
                        .Forward = True
                        .Execute()
                        If .Found = True Then
                            DataGridView1.Rows.Add(thesisid, thesistitle, "Match Found on paragraph " & i)
                        End If
                    Next
                Else
                    newsearchstring = searchstring
                    .Text = newsearchstring
                    .Forward = True
                    .Execute()
                    If .Found = True Then
                        DataGridView1.Rows.Add(thesisid, thesistitle, "Match Found on paragraph " & i)
                    End If
                End If


                'try ko muna alamin ung number of text na limit sa search 
                '255 lahat
            End With
        Next


    End Sub

    Function totalthesis()
        conn.ConnectionString = connstring
        conn.Open()


        Dim sql As String = "Select COUNT(*) as total FROM thesistbl"
        If Not categoryFilter.Equals("All") Then
            sql = sql & " WHERE platformid = " & categoryFilter
        End If

        Dim comm As New MySqlCommand
        Dim commstring As String = sql
        Dim reader As MySqlDataReader

        comm.Connection = conn
        comm.CommandText = commstring
        reader = comm.ExecuteReader

        Dim total As String = 0
        While reader.Read
            total = reader("total").ToString
        End While

        conn.Close()
        Return total
    End Function

    Public Sub wildcardsearch(rng As Word.Range, searchstring As String, path As String, thesisid As String, thesistitle As String)
        'hatiin muna sa dalawa tapos saka i loop
        For i As Integer = 1 To rng.Paragraphs.Count
            Label3.Text = i & " of " & rng.Paragraphs.Count & " paragraphs"
            Dim r As Word.Range = rng.Paragraphs.Item(i).Range
            Dim stringarray() As String
            stringarray = Split(searchstring, " ")
            For a As Integer = 0 To stringarray.Count - 1
                stringarray = Split(searchstring, " ")
                stringarray(a) = "*"
                r.Find.MatchWildcards = True
                Dim stringmanipulator As String = Join(stringarray, " ")
                stringmanipulator = stringmanipulator.Replace(" * ", "*")
                r.Find.Text = stringmanipulator
                While (r.Find.Execute())
                    DataGridView1.Rows.Add(thesisid, thesistitle, "Match Found on paragraph " & i)
                    Exit For
                End While
            Next
        Next
    End Sub

    Public Sub countfound()
        Label2.Text = "Found " & DataGridView1.Rows.Count & " Match(es)"
        Label3.Text = "Done!"
        doSearchBtn.Text = "Search"
        MsgBox("Searching Done!" & vbNewLine & "Matches Found: " & DataGridView1.Rows.Count, vbOKOnly, "Axtaris")
    End Sub

    Public Sub searchevery5words(rng As Word.Range, searchstring As String, path As String, thesisid As String, thesistitle As String)
        For i As Integer = 1 To rng.Paragraphs.Count
            Label3.Text = i & " of " & rng.Paragraphs.Count & " paragraphs"
            Dim r As Word.Range = rng.Paragraphs.Item(i).Range
            Dim stringarray() As String
            For j As Integer = 0 To 4
                stringarray = Split(searchstring, " ")
                Dim a As Integer = j
                While a < stringarray.Count - 1
                    stringarray(a) = "*"
                    a = a + 5
                End While
                Dim truesearchstring As String = Join(stringarray, " ")
                truesearchstring = truesearchstring.Replace(" * ", "*")
                With r.Find
                    .MatchWildcards = True
                    .Text = truesearchstring
                    .Execute()
                    If .Found = True Then
                        If DataGridView1.Rows.Count = 0 Then
                            DataGridView1.Rows.Add(thesisid, thesistitle, "Match Found on paragraph " & i)
                        Else
                            Dim g As Integer = 0
                            Dim first As Boolean = True
                            While g <= DataGridView1.Rows.Count - 1
                                If DataGridView1.Rows(g).Cells(0).Value.Equals(thesisid) And DataGridView1.Rows(g).Cells(2).Value.Equals("Match Found on paragraph " & i) Then
                                    first = False
                                End If
                                g = g + 1
                            End While
                            If first Then
                                DataGridView1.Rows.Add(thesisid, thesistitle, "Match Found on paragraph " & i)
                            End If
                        End If
                    End If
                End With
            Next
        Next
    End Sub

    Public Sub killwordprocess()
        For Each p As Process In System.Diagnostics.Process.GetProcessesByName("WINWORD")
            Try
                p.Kill()
                p.WaitForExit()
            Catch ex As Exception

            End Try
        Next
    End Sub

    Private Sub settingBtn_Click(sender As Object, e As EventArgs) Handles settingBtn.Click
        ContentSearchSettingsForm.settingload()
        ContentSearchSettingsForm.ShowDialog()
    End Sub

    Public Sub wildcardsearch2(rng As Word.Range, searchstring As String, path As String, thesisid As String, thesistitle As String)
        For i As Integer = 1 To rng.Paragraphs.Count
            Label3.Text = i & " of " & rng.Paragraphs.Count & " paragraphs"
            Dim r As Word.Range = rng.Paragraphs.Item(i).Range
            Dim stringarray() As String 'collection of sentences
            stringarray = Split(searchstring, ".")
            Dim numofsentences As Integer = stringarray.Count - 1
            Dim wildcardplace As New List(Of Integer)
            Dim wildcardlimit As New List(Of Integer)
            For j As Integer = 0 To stringarray.Count - 1
                Dim temparray() As String = Split(stringarray(j), " ")
                wildcardplace.Add(0)
                wildcardlimit.Add(temparray.Count)
            Next
            Dim k As Integer = 0
            While True
                wildcardplace(0) = k
                For z As Integer = 1 To numofsentences
                    If wildcardplace(z - 1) = wildcardlimit(z - 1) Then
                        wildcardplace(z - 1) = 0
                        wildcardplace(z) = wildcardplace(z) + 1
                        k = 0
                    End If
                Next
                If wildcardplace(numofsentences) >= wildcardlimit(numofsentences) Then
                    wildcardplace(numofsentences) = wildcardlimit(numofsentences)
                    Exit While
                End If

                Dim paragraphtosentencearray() As String = Split(searchstring, ".")
                Dim wordtosentencelist As New List(Of String)
                For o As Integer = 0 To paragraphtosentencearray.Count - 1
                    Dim sentencetowordarray() As String = Split(paragraphtosentencearray(o), " ")
                    sentencetowordarray(wildcardplace(o)) = "*"
                    Dim sentencemanipulator As String = Join(sentencetowordarray, " ")
                    sentencemanipulator = sentencemanipulator.Replace(" * ", "*")
                    wordtosentencelist.Add(sentencemanipulator)
                Next
                Dim wordtosentencearray() As String = wordtosentencelist.ToArray
                Dim truesearchstring As String = Join(wordtosentencearray, ".")

                With r.Find
                    .MatchWildcards = True
                    .Text = truesearchstring
                    .Execute()
                    If .Found = True Then
                        If DataGridView1.Rows.Count = 0 Then
                            DataGridView1.Rows.Add(thesisid, thesistitle, "Match Found on paragraph " & i)
                        Else
                            Dim g As Integer = 0
                            Dim first As Boolean = True
                            While g <= DataGridView1.Rows.Count - 1
                                If DataGridView1.Rows(g).Cells(0).Value.Equals(thesisid) And DataGridView1.Rows(g).Cells(2).Value.Equals("Match Found on paragraph " & i) Then
                                    first = False
                                End If
                                g = g + 1
                            End While
                            If first Then
                                DataGridView1.Rows.Add(thesisid, thesistitle, "Match Found on paragraph " & i)
                            End If
                        End If
                    End If
                End With
                k = k + 1
            End While
        Next
    End Sub

    'Private Sub searchBtn_Click(sender As Object, e As EventArgs) Handles searchBtn.Click
    '    Label2.Text = "Please Wait..."
    '    Dim total As String = totalthesis()
    '    Dim searchstring As String = TextBox1.Text

    '    While True
    '        If searchstring.EndsWith(" ") Or searchstring.EndsWith(".") Then
    '            searchstring = searchstring.Substring(0, searchstring.Length - 1)
    '        Else
    '            Exit While
    '        End If
    '    End While

    '    DataGridView1.Rows.Clear()

    '    conn.ConnectionString = connstring
    '    conn.Open()

    '    Dim comm As New MySqlCommand
    '    Dim commstring As String = "Select * FROM thesistbl"
    '    Dim reader As MySqlDataReader

    '    comm.Connection = conn
    '    comm.CommandText = commstring
    '    reader = comm.ExecuteReader

    '    'killwordprocess()
    '    Dim i As Integer = 1

    '    Dim MyDoc As New Word.Document
    '    Dim MyApp As New Word.Application
    '    Dim rng As Word.Range

    '    While reader.Read
    '        Dim path As String = reader("thesispath").ToString & ".docx"
    '        Dim thesisid As String = reader("thesisid").ToString
    '        Dim thesistitle As String = reader("thesistitle").ToString

    '        MyDoc = MyApp.Documents.Open(path, False, True)
    '        rng = MyDoc.Content

    '        Label2.Text = i & " Of " & total & " Thesis"

    '        If ContainerForm.contentsearchtype = 1 Then
    '            search(rng, searchstring, path, thesisid, thesistitle)
    '        ElseIf ContainerForm.contentsearchtype = 2 Then
    '            wildcardsearch(rng, searchstring, path, thesisid, thesistitle)
    '        ElseIf ContainerForm.contentsearchtype = 3 Then
    '            searchevery5words(rng, searchstring, path, thesisid, thesistitle)
    '        ElseIf ContainerForm.contentsearchtype = 4 Then
    '            wildcardsearch2(rng, searchstring, path, thesisid, thesistitle)
    '        Else

    '        End If
    '        i = i + 1
    '    End While

    '    conn.Close()

    '    MyDoc.Close()
    '    MyApp.Quit()
    '    MyDoc = Nothing

    '    Label3.Text = ""
    '    countfound()
    'End Sub

    Private Sub pickAFileBtn_Click(sender As Object, e As EventArgs) Handles pickAFileBtn.Click
        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.Panel1.Controls.Add(ContainerForm.contentsearchpick)
        ContainerForm.contentsearchpick.Show()
    End Sub













    'The codes below are just experimental


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWSearch.DoWork
        Dim total As String = totalthesis()
        Dim searchstring As String = TextBox1.Text

        BWSearch.ReportProgress(4)
        BWSearch.ReportProgress(1)
        BWSearch.ReportProgress(2, "Initializing...")

        'While True
        '    If searchstring.EndsWith(" ") Or searchstring.EndsWith(".") Then
        '        searchstring = searchstring.Substring(0, searchstring.Length - 1)
        '    Else
        '        Exit While
        '    End If
        'End While
        While searchstring.EndsWith(" ") Or searchstring.EndsWith(".")
            searchstring = searchstring.Substring(0, searchstring.Length - 1)
        End While
        While searchstring.StartsWith(" ") Or searchstring.StartsWith(".")
            searchstring = searchstring.Substring(1, searchstring.Length - 1)
        End While


        searchstring = searchstring.Replace(". ", ".")

        Dim conn2 As New MySqlConnection
        conn2.ConnectionString = connstring
        conn2.Open()

        Dim sql As String = "Select * FROM thesistbl"
        If Not categoryFilter.Equals("All") Then
            sql = sql & " WHERE platformid = " & categoryFilter
        End If

        Dim comm As New MySqlCommand
        Dim commstring As String = sql
        Dim reader As MySqlDataReader

        comm.Connection = conn2
        comm.CommandText = commstring
        reader = comm.ExecuteReader

        'killwordprocess()
        Dim ii As Integer = 1

        Dim MyDoc As New Word.Document
        Dim MyApp As New Word.Application
        'Dim rng As Word.Range

        Dim counter As Integer = Floor(searchstring.Count / 240) 'Binago ko from 255 to 100
        Dim foundOnFile As Boolean = False


        While reader.Read

            Dim path As String = reader("thesispath").ToString & ".docx"
            Dim thesisid As String = reader("thesisid").ToString
            Dim thesistitle As String = reader("thesistitle").ToString

            MyDoc = MyApp.Documents.Open(path, False, True)
            Dim rng As Word.Range = MyDoc.Content

            If searchsettings = 1 Then

                foundOnFile = False

                Dim percentage2 As Double = (((ii - 1) / total) * 100)
                BWSearch.ReportProgress(2, percentage2.ToString("#.##") & "%")

                searchstring = searchstring.Replace(".", ". ")

                With rng.Find
                    Dim newsearchstring As String
                    If searchstring.Count > 255 Then
                        For o As Integer = 0 To counter
                            If o = counter Then
                                newsearchstring = searchstring.Substring(255 * o, searchstring.Count Mod 255)
                            Else
                                newsearchstring = searchstring.Substring(255 * o, 255)
                            End If
                            If newsearchstring.Count < 15 Then
                                Exit For
                            End If
                            .Text = newsearchstring
                            .Forward = True
                            .Execute()
                            If .Found = True Then
                                foundOnFile = True
                            End If
                        Next
                    Else
                        newsearchstring = searchstring
                        .Text = newsearchstring
                        .Forward = True
                        .Execute()
                        If .Found = True Then
                            foundOnFile = True
                        End If
                    End If
                End With

                If foundOnFile Then
                    rng = MyDoc.Content
                    For i As Integer = 1 To rng.Paragraphs.Count
                        Dim percentage As Double = (((((ii - 1) / total) * 100) + (((1 / total) * (i / rng.Paragraphs.Count)) * 100)))
                        BWSearch.ReportProgress(2, percentage.ToString("#.##") & "%")
                        With rng.Paragraphs.Item(i).Range.Find
                            Dim newsearchstring As String
                            If searchstring.Count > 255 Then
                                For o As Integer = 0 To counter
                                    If o = counter Then
                                        newsearchstring = searchstring.Substring(255 * o, searchstring.Count Mod 255)
                                    Else
                                        newsearchstring = searchstring.Substring(255 * o, 255)
                                    End If
                                    If newsearchstring.Count < 15 Then
                                        Exit For
                                    End If
                                    .Text = newsearchstring
                                    .Forward = True
                                    .Execute()
                                    If .Found = True Then
                                        BWSearch.ReportProgress(5, .Text)
                                        Dim resultstring As New List(Of String)
                                        resultstring.Add(thesisid)
                                        resultstring.Add(thesistitle)
                                        resultstring.Add("Match Found on paragraph " & i)
                                        Dim resultt() As String = resultstring.ToArray
                                        Dim resulttt As String = Join(resultt, "|")
                                        BWSearch.ReportProgress(3, resulttt)
                                    End If
                                Next
                            Else
                                newsearchstring = searchstring
                                .Text = newsearchstring
                                .Forward = True
                                .Execute()
                                If .Found = True Then
                                    'MsgBox(.Text)
                                    BWSearch.ReportProgress(5, .Text)

                                    Dim resultstring As New List(Of String)
                                    resultstring.Add(thesisid)
                                    resultstring.Add(thesistitle)
                                    resultstring.Add("Match Found on paragraph " & i)
                                    Dim resultt() As String = resultstring.ToArray
                                    Dim resulttt As String = Join(resultt, "|")
                                    BWSearch.ReportProgress(3, resulttt)
                                End If
                            End If
                        End With
                    Next
                End If

            ElseIf searchsettings = 2 Then
                Dim detectedWildCard As String
                foundOnFile = False

                Dim percentage2 As Double = (((ii - 1) / total) * 100)
                BWSearch.ReportProgress(2, percentage2.ToString("#.##") & "%")

                With rng.Find
                    .Forward = False
                    .MatchWildcards = True
                    Dim newsearchstring As String
                    If searchstring.Count > 240 Then
                        For o As Integer = 0 To counter
                            If o = counter Then
                                newsearchstring = searchstring.Substring(240 * o, searchstring.Count Mod 240)
                            Else
                                newsearchstring = searchstring.Substring(240 * o, 240)
                            End If

                            If newsearchstring.Count < 35 And Split(newsearchstring, " ").Count < 5 Then
                                Exit For
                            End If
                            Dim stringarray() As String
                            stringarray = Split(newsearchstring, " ")
                            '.ClearFormatting()
                            '.Forward = True
                            '.MatchWildcards = True
                            For a As Integer = 0 To stringarray.Count - 1
                                stringarray = Split(newsearchstring, " ")
                                stringarray(a) = "*"
                                Dim stringmanipulator As String = Join(stringarray, " ")
                                stringmanipulator = stringmanipulator.Replace(" * ", "*")
                                stringmanipulator = stringmanipulator.Replace(".", ". ")
                                While stringmanipulator.StartsWith("*")
                                    stringmanipulator = stringmanipulator.Substring(1, stringmanipulator.Length - 1)
                                End While
                                While stringmanipulator.EndsWith("*")
                                    stringmanipulator = stringmanipulator.Substring(0, stringmanipulator.Length - 1)
                                End While
                                .Text = stringmanipulator
                                BWSearch.ReportProgress(6, stringmanipulator)
                                .Execute()
                                If .Found = True Then
                                    detectedWildCard = stringmanipulator
                                    foundOnFile = True
                                    'MsgBox("Found)")
                                    Exit For
                                End If
                            Next
                        Next
                    Else
                        newsearchstring = searchstring
                        Dim stringmanipulator As String
                        Dim stringarray() As String
                        stringarray = Split(newsearchstring, " ")
                        '.ClearFormatting()
                        '.MatchWildcards = True
                        '.Forward = True
                        For a As Integer = 0 To stringarray.Count - 1
                            stringarray = Split(newsearchstring, " ")
                            stringarray(a) = "*"
                            stringmanipulator = Join(stringarray, " ")
                            stringmanipulator = stringmanipulator.Replace(" * ", "*")
                            stringmanipulator = stringmanipulator.Replace(".", ". ")
                            While stringmanipulator.StartsWith("*")
                                stringmanipulator = stringmanipulator.Substring(1, stringmanipulator.Length - 1)
                            End While
                            While stringmanipulator.EndsWith("*")
                                stringmanipulator = stringmanipulator.Substring(0, stringmanipulator.Length - 1)
                            End While
                            .Text = stringmanipulator
                            BWSearch.ReportProgress(6, stringmanipulator)
                            .Execute()
                            If .Found = True Then
                                detectedWildCard = stringmanipulator
                                foundOnFile = True
                                Exit For
                            End If
                        Next
                    End If
                End With

                If foundOnFile Then
                    rng = MyDoc.Content
                    For i As Integer = 1 To rng.Paragraphs.Count
                        Dim percentage As Double = (((((ii - 1) / total) * 100) + (((1 / total) * (i / rng.Paragraphs.Count)) * 100)))
                        BWSearch.ReportProgress(2, percentage.ToString("#.##") & "%")
                        With rng.Paragraphs.Item(i).Range.Find
                            .Text = detectedWildCard
                            .Forward = False
                            .MatchWildcards = True
                            While (.Execute())
                                BWSearch.ReportProgress(5, rng.Paragraphs.Item(i).Range.Text)
                                Dim resultstring As New List(Of String)
                                resultstring.Add(thesisid)
                                resultstring.Add(thesistitle)
                                resultstring.Add("Match Found on paragraph " & i)
                                Dim resultt() As String = resultstring.ToArray
                                Dim resulttt As String = Join(resultt, "|")
                                BWSearch.ReportProgress(3, resulttt)
                                Exit While
                            End While

                            'Dim newsearchstring As String
                            'If searchstring.Count > 255 Then
                            '    For o As Integer = 0 To counter
                            '        If o = counter Then
                            '            newsearchstring = searchstring.Substring(255 * o, searchstring.Count Mod 255)
                            '        Else
                            '            newsearchstring = searchstring.Substring(255 * o, 255)
                            '        End If
                            '        If newsearchstring.Count < 15 Then
                            '            Exit For
                            '        End If
                            '        Dim stringarray() As String
                            '        stringarray = Split(newsearchstring, " ")
                            '        For a As Integer = 0 To stringarray.Count - 1
                            '            stringarray = Split(newsearchstring, " ")
                            '            stringarray(a) = "*"
                            '            '.MatchWildcards = True
                            '            Dim stringmanipulator As String = Join(stringarray, " ")
                            '            stringmanipulator = stringmanipulator.Replace(" * ", "*")
                            '            stringmanipulator = stringmanipulator.Replace(".", ". ")
                            '            .Text = stringmanipulator
                            '            .MatchCase = False
                            '            .Forward = True
                            '            .MatchWildcards = True
                            '            While (.Execute())
                            '                BWSearch.ReportProgress(5, rng.Paragraphs.Item(i).Range.Text)
                            '                Dim resultstring As New List(Of String)
                            '                resultstring.Add(thesisid)
                            '                resultstring.Add(thesistitle)
                            '                resultstring.Add("Match Found on paragraph " & i)
                            '                Dim resultt() As String = resultstring.ToArray
                            '                Dim resulttt As String = Join(resultt, "|")
                            '                BWSearch.ReportProgress(3, resulttt)
                            '                Exit For
                            '            End While
                            '        Next
                            '    Next
                            'Else
                            '    newsearchstring = searchstring
                            '    Dim stringarray() As String
                            '    stringarray = Split(newsearchstring, " ")
                            '    For a As Integer = 0 To stringarray.Count - 1
                            '        stringarray = Split(newsearchstring, " ")
                            '        stringarray(a) = "*"
                            '        .MatchWildcards = True
                            '        Dim stringmanipulator As String = Join(stringarray, " ")
                            '        stringmanipulator = stringmanipulator.Replace(" * ", "*")
                            '        stringmanipulator = stringmanipulator.Replace(".", ". ")
                            '        .Text = stringmanipulator
                            '        .MatchCase = False
                            '        .Forward = True
                            '        While (.Execute())
                            '            BWSearch.ReportProgress(5, rng.Paragraphs.Item(i).Range.Text)
                            '            Dim resultstring As New List(Of String)
                            '            resultstring.Add(thesisid)
                            '            resultstring.Add(thesistitle)
                            '            resultstring.Add("Match Found on paragraph " & i)
                            '            Dim resultt() As String = resultstring.ToArray
                            '            Dim resulttt As String = Join(resultt, "|")
                            '            BWSearch.ReportProgress(3, resulttt)
                            '            Exit For
                            '        End While
                            '    Next
                            'End If
                        End With
                    Next
                End If



















            ElseIf searchsettings = 3 Then

                Dim stringWithWildCards As String

                foundOnFile = False
                'MsgBox("nextTitle")
                Dim percentage2 As Double = (((ii - 1) / total) * 100)
                BWSearch.ReportProgress(2, percentage2.ToString("#.##") & "%")

                With rng.Find

                    Dim stringarray2() As String 'collection of sentences
                    stringarray2 = Split(searchstring, ".")
                    Dim numofsentences As Integer = stringarray2.Count - 1
                    Dim wildcardplace As New List(Of Integer)
                    Dim wildcardlimit As New List(Of Integer)
                    For j As Integer = 0 To stringarray2.Count - 1
                        Dim temparray() As String = Split(stringarray2(j), " ")
                        wildcardplace.Add(0)
                        wildcardlimit.Add(temparray.Count)
                    Next
                    Dim k As Integer = 0

                    While True




                        wildcardplace(0) = k

                        'Dim increment As Double = 1
                        'Dim message As String = ""
                        'For i As Integer = stringarray2.Count - 1 To 0 Step -1
                        '    increment = (increment * ((wildcardplace(i) + 1) / (wildcardlimit(i) + 1)))
                        '    'MsgBox("i: " & i & " ; wildcardplace(i): " & wildcardplace(i) + 1 & " ; wildcardlimit(i): " & wildcardlimit(i) + 1 & " ; increment: " & increment & " | " & (wildcardplace(i) + 1) / (wildcardlimit(i) + 1) & " ( " & wildcardplace(i) + 1 & " / " & (wildcardlimit(i) + 1) & " )")
                        '    'message = message & vbNewLine & "i: " & i & " ; wildcardplace(i): " & wildcardplace(i) + 1 & " ; wildcardlimit(i): " & wildcardlimit(i) + 1 & " ; increment: " & increment & " | " & (wildcardplace(i) + 1) / (wildcardlimit(i) + 1) & " ( " & wildcardplace(i) + 1 & " / " & (wildcardlimit(i) + 1) & " )"
                        '    'Clipboard.SetText(Clipboard.GetText & " | " & "i: " & i & " ; wildcardplace(i): " & wildcardplace(i) & " ; wildcardlimit(i): " & wildcardlimit(i))
                        'Next
                        'Dim percentage3 As Double = (((((ii - 1) / total)) + ((1 / total) * increment))) * 100
                        'BWSearch.ReportProgress(2, percentage3.ToString("#.##") & "%")
                        'MsgBox(message)


                        For z As Integer = 1 To numofsentences
                            If wildcardplace(z - 1) = wildcardlimit(z - 1) Then ' ung = ay ginawa kong >
                                wildcardplace(z - 1) = 0
                                wildcardplace(z) = wildcardplace(z) + 1
                                k = 0
                            End If
                        Next
                        If wildcardplace(numofsentences) >= wildcardlimit(numofsentences) Then
                            wildcardplace(numofsentences) = wildcardlimit(numofsentences)
                            Exit While
                        End If











                        Dim paragraphtosentencearray() As String = Split(searchstring, ".")
                        Dim wordtosentencelist As New List(Of String)
                        'For o As Integer = 1 To paragraphtosentencearray.Count
                        '    MsgBox(paragraphtosentencearray(o - 1))
                        '    Dim sentencetowordarray() As String = Split(paragraphtosentencearray(o - 1), " ")

                        '    'MsgBox(sentencetowordarray(wildcardplace(o - 1)))
                        '    'MsgBox("WildCardPlace(o-1) : " & wildcardplace(o - 1) - 1 & " / " & sentencetowordarray.Count)
                        '    sentencetowordarray(wildcardplace(o - 1)) = "*"
                        '    Dim sentencemanipulator As String = Join(sentencetowordarray, " ")
                        '    sentencemanipulator = sentencemanipulator.Replace(" * ", "*")
                        '    wordtosentencelist.Add(sentencemanipulator)
                        'Next
                        For o As Integer = 0 To paragraphtosentencearray.Count - 1
                            Dim sentencetowordarray() As String = Split(paragraphtosentencearray(o), " ")
                            sentencetowordarray(wildcardplace(o)) = "*"
                            Dim sentencemanipulator As String = Join(sentencetowordarray, " ")
                            sentencemanipulator = sentencemanipulator.Replace(" * ", "*")
                            wordtosentencelist.Add(sentencemanipulator)
                        Next
                        Dim wordtosentencearray() As String = wordtosentencelist.ToArray
                        Dim truesearchstring As String = Join(wordtosentencearray, ".")

                        truesearchstring = truesearchstring.Replace(".*.", "*")
                        truesearchstring = truesearchstring.Replace("*.", "*")
                        truesearchstring = truesearchstring.Replace(".*", "*")
                        truesearchstring = truesearchstring.Replace(".", ". ")


                        Dim newsearchstring As String
                        If truesearchstring.Count > 240 Then 'Binago ko from 255 to 240
                            For o As Integer = 0 To counter
                                If o = counter Then
                                    newsearchstring = truesearchstring.Substring(240 * o, truesearchstring.Count Mod 240) 'Binago ko from 255 to 100
                                Else
                                    newsearchstring = truesearchstring.Substring(240 * o, 240) 'Binago ko from 255 to 100
                                End If

                                If newsearchstring.Count < 40 Then
                                    Exit For
                                End If

                                While newsearchstring.StartsWith("*")
                                    newsearchstring = newsearchstring.Substring(1, newsearchstring.Length - 1)
                                End While
                                While newsearchstring.EndsWith("*")
                                    newsearchstring = newsearchstring.Substring(0, newsearchstring.Length - 1)
                                End While
                                BWSearch.ReportProgress(6, newsearchstring)
                                'MsgBox(newsearchstring)
                                'Dim temprng As Word.Range
                                'temprng = MyDoc.Content
                                'temprng.Find.ClearFormatting()
                                'temprng.Find.Text = newsearchstring
                                'temprng.Find.MatchWildcards = True
                                'temprng.Find.Forward = True
                                'temprng.Find.Execute()
                                'If temprng.Find.Found Then
                                '    foundOnFile = True
                                '    stringWithWildCards = newsearchstring
                                '    Exit While
                                'End If
                                '.ClearFormatting()
                                .MatchWildcards = True
                                .Forward = True
                                .Text = newsearchstring
                                .Execute()
                                If .Found = True Then
                                    'BWSearch.ReportProgress(5, rng.Text)
                                    'Dim resultstring As New List(Of String)
                                    'resultstring.Add(thesisid)
                                    'resultstring.Add(thesistitle)
                                    'resultstring.Add("Text Matched: " & rng.Text)
                                    'Dim resultt() As String = resultstring.ToArray
                                    'Dim resulttt As String = Join(resultt, "|")
                                    'BWSearch.ReportProgress(3, resulttt)
                                    foundOnFile = True
                                    stringWithWildCards = newsearchstring
                                    Exit While
                                End If
                            Next
                        Else
                            'If truesearchstring.EndsWith("*") Then truesearchstring = truesearchstring.Substring(0, truesearchstring.Length - 1)
                            'If truesearchstring.StartsWith("*") Then truesearchstring = truesearchstring.Substring(1, truesearchstring.Length - 1)
                            While truesearchstring.StartsWith("*")
                                truesearchstring = truesearchstring.Substring(1, truesearchstring.Length - 1)
                            End While
                            While truesearchstring.EndsWith("*")
                                truesearchstring = truesearchstring.Substring(0, truesearchstring.Length - 1)
                            End While
                            BWSearch.ReportProgress(6, truesearchstring)
                            'MsgBox(truesearchstring)
                            'Dim temprng As Word.Range
                            'temprng = MyDoc.Content
                            'temprng.Find.ClearFormatting()
                            'temprng.Find.Text = truesearchstring
                            'temprng.Find.MatchWildcards = True
                            'temprng.Find.Forward = True
                            'temprng.Find.Execute()
                            'If temprng.Find.Found Then
                            '    foundOnFile = True
                            '    stringWithWildCards = truesearchstring
                            '    Exit While
                            'End If

                            'rng = Nothing
                            'rng = MyDoc.Content
                            '.ClearFormatting()
                            .MatchWildcards = True
                            .Forward = False
                            .Text = truesearchstring
                            '.Wrap = Word.WdFindWrap.wdFindStop
                            .Execute()

                            If .Found = True Then
                                'BWSearch.ReportProgress(5, rng.Text)
                                'Dim resultstring As New List(Of String)
                                'resultstring.Add(thesisid)
                                'resultstring.Add(thesistitle)
                                'resultstring.Add("Text Matched: " & rng.Text)
                                'Dim resultt() As String = resultstring.ToArray
                                'Dim resulttt As String = Join(resultt, "|")
                                'BWSearch.ReportProgress(3, resulttt)
                                foundOnFile = True
                                stringWithWildCards = truesearchstring
                                Exit While
                            End If

                        End If




                        k = k + 1
                    End While

                End With

                If foundOnFile Then
                    rng = MyDoc.Content
                    For i As Integer = 1 To rng.Paragraphs.Count
                        'Dim percentage As Double = (((((ii - 1) / total) * 100) + (((1 / total) * (i / rng.Paragraphs.Count)) * 100)))
                        'BWSearch.ReportProgress(2, percentage.ToString("#.##") & "%")

                        With rng.Paragraphs.Item(i).Range.Find

                            .ClearFormatting()
                            .MatchWildcards = True
                            .Forward = True
                            .Text = stringWithWildCards

                            BWSearch.ReportProgress(6, stringWithWildCards)
                            .Execute()

                            If .Found = True Then
                                BWSearch.ReportProgress(5, rng.Paragraphs.Item(i).Range.Text)
                                Dim resultstring As New List(Of String)
                                resultstring.Add(thesisid)
                                resultstring.Add(thesistitle)
                                resultstring.Add("Match Found on paragraph " & i)
                                Dim resultt() As String = resultstring.ToArray
                                Dim resulttt As String = Join(resultt, "|")
                                BWSearch.ReportProgress(3, resulttt)
                            End If

                            '    Dim stringarray2() As String 'collection of sentences
                            '    stringarray2 = Split(searchstring, ".")
                            '    Dim numofsentences As Integer = stringarray2.Count - 1
                            '    Dim wildcardplace As New List(Of Integer)
                            '    Dim wildcardlimit As New List(Of Integer)
                            '    For j As Integer = 0 To stringarray2.Count - 1
                            '        Dim temparray() As String = Split(stringarray2(j), " ")
                            '        wildcardplace.Add(0)
                            '        wildcardlimit.Add(temparray.Count)
                            '    Next
                            '    Dim k As Integer = 0

                            '    While True
                            '        wildcardplace(0) = k
                            '        For z As Integer = 1 To numofsentences
                            '            If wildcardplace(z - 1) = wildcardlimit(z - 1) Then
                            '                wildcardplace(z - 1) = 0
                            '                wildcardplace(z) = wildcardplace(z) + 1
                            '                k = 0
                            '            End If
                            '        Next
                            '        If wildcardplace(numofsentences) >= wildcardlimit(numofsentences) Then
                            '            wildcardplace(numofsentences) = wildcardlimit(numofsentences)
                            '            Exit While
                            '        End If

                            '        Dim paragraphtosentencearray() As String = Split(searchstring, ".")
                            '        Dim wordtosentencelist As New List(Of String)
                            '        For o As Integer = 0 To paragraphtosentencearray.Count - 1
                            '            Dim sentencetowordarray() As String = Split(paragraphtosentencearray(o), " ")
                            '            sentencetowordarray(wildcardplace(o)) = "*"
                            '            Dim sentencemanipulator As String = Join(sentencetowordarray, " ")
                            '            sentencemanipulator = sentencemanipulator.Replace(" * ", "*")
                            '            wordtosentencelist.Add(sentencemanipulator)
                            '        Next
                            '        Dim wordtosentencearray() As String = wordtosentencelist.ToArray
                            '        Dim truesearchstring As String = Join(wordtosentencearray, ".")

                            '        Dim newsearchstring As String
                            '        If truesearchstring.Count > 255 Then
                            '            For o As Integer = 0 To counter
                            '                If o = counter Then
                            '                    newsearchstring = truesearchstring.Substring(255 * o, truesearchstring.Count Mod 255)
                            '                Else
                            '                    newsearchstring = truesearchstring.Substring(255 * o, 255)
                            '                End If

                            '                If newsearchstring.Count < 40 Then
                            '                    Exit For
                            '                End If
                            '                .ClearFormatting()
                            '                .MatchWildcards = True
                            '                .Forward = True
                            '                .Text = newsearchstring

                            '                BWSearch.ReportProgress(6, newsearchstring)
                            '                .Execute()

                            '                If .Found = True Then
                            '                    BWSearch.ReportProgress(5, rng.Paragraphs.Item(i).Range.Text)
                            '                    Dim resultstring As New List(Of String)
                            '                    resultstring.Add(thesisid)
                            '                    resultstring.Add(thesistitle)
                            '                    resultstring.Add("Match Found on paragraph " & i)
                            '                    Dim resultt() As String = resultstring.ToArray
                            '                    Dim resulttt As String = Join(resultt, "|")
                            '                    BWSearch.ReportProgress(3, resulttt)
                            '                End If
                            '            Next
                            '        Else
                            '            .ClearFormatting()
                            '            .MatchWildcards = True
                            '            .Forward = True
                            '            .Text = truesearchstring

                            '            BWSearch.ReportProgress(6, truesearchstring)
                            '            .Execute()
                            '            If .Found = True Then
                            '                BWSearch.ReportProgress(5, rng.Paragraphs.Item(i).Range.Text)
                            '                Dim resultstring As New List(Of String)
                            '                resultstring.Add(thesisid)
                            '                resultstring.Add(thesistitle)
                            '                resultstring.Add("Match Found on paragraph " & i)
                            '                Dim resultt() As String = resultstring.ToArray
                            '                Dim resulttt As String = Join(resultt, "|")
                            '                BWSearch.ReportProgress(3, resulttt)
                            '            End If

                            '        End If
                            '        k = k + 1
                            '    End While
                        End With
                    Next
                End If

            ElseIf searchsettings = 4 Then
                MsgBox("b")
                Exit Sub
                wildcardsearch2(rng, searchstring, path, thesisid, thesistitle)
            Else

            End If
            If BWSearch.CancellationPending Then
                e.Cancel = True
                Exit While
            End If
            'MyDoc = Nothing
            ii = ii + 1
        End While

        conn2.Close()

        MyDoc.Close()
        MyApp.Quit()
        MyDoc = Nothing

    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    If doSearchBtn.Text = "Search" Then
    '        If BWSearch.IsBusy Then
    '            MsgBox("There is already a process")
    '        Else
    '            searchsettings = ContainerForm.contentsearchtype

    '            Dim stringToTest As String = TextBox1.Text
    '            While stringToTest.EndsWith(" ") Or stringToTest.EndsWith(".")
    '                stringToTest = stringToTest.Substring(0, stringToTest.Length - 1)
    '            End While
    '            While stringToTest.StartsWith(" ") Or stringToTest.StartsWith(".")
    '                stringToTest = stringToTest.Substring(1, stringToTest.Length - 1)
    '            End While

    '            If stringToTest = "" Then
    '                MsgBox("Don't leave the search field blank")
    '                Exit Sub
    '            End If

    '            If Not searchsettings = 1 Then
    '                If Split(stringToTest, " ").Count = 1 Then
    '                    MsgBox("Cannot do a single word searching with wildcard searching")
    '                    Exit Sub
    '                End If
    '            End If

    '            If ContainerForm.contentsearchCategoryFilter.Equals("All") Then
    '                categoryFilter = ContainerForm.contentsearchCategoryFilter
    '            Else
    '                categoryFilter = getcategoryid(ContainerForm.contentsearchCategoryFilter)
    '            End If
    '            'categoryFilter = "All"
    '            'searchsettings = 3

    '            ContainerForm.executeTaskQuery("Content Search", "Scanned a paragraph (" & TextBox1.Text & ")")

    '            BWSearch.RunWorkerAsync()
    '        End If
    '        doSearchBtn.Text = "Stop"
    '    ElseIf doSearchBtn.Text = "Stop" Then
    '        Select Case MsgBox("Are you sure you want to stop searching?", vbYesNo)
    '            Case vbYes
    '                If Not doSearchBtn.Text = "Search" Then
    '                    doSearchBtn.Text = "Stopping"
    '                    BWSearch.CancelAsync()
    '                End If
    '            Case vbNo
    '            Case Else
    '        End Select
    '    End If

    'End Sub

    Private Sub BWSearch_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BWSearch.ProgressChanged
        If e.ProgressPercentage() = 1 Then
            Label2.Text = "Please Wait"
            Timer1.Enabled = True
        ElseIf e.ProgressPercentage() = 2 Then
            If e.UserState.ToString.StartsWith(".") Or e.UserState.ToString.StartsWith("%") Then
                Label3.Text = "0" & e.UserState
            Else
                Label3.Text = e.UserState
            End If

        ElseIf e.ProgressPercentage() = 3 Then
            Dim asd() As String = Split(e.UserState.ToString, "|")
            DataGridView1.Rows.Add(asd(0), asd(1), asd(2))
        ElseIf e.ProgressPercentage() = 4 Then
            searchedstring.Clear()
            DataGridView1.Rows.Clear()
        ElseIf e.ProgressPercentage() = 5 Then
            searchedstring.Add(e.UserState.ToString)
        ElseIf e.ProgressPercentage() = 6 Then
            TextBox2.Text = e.UserState.ToString
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Label2.Text.Equals("Please Wait.") Then
            Label2.Text = "Please Wait.."
        ElseIf Label2.Text.Equals("Please Wait..") Then
            Label2.Text = "Please Wait..."
        ElseIf Label2.Text.Equals("Please Wait...") Then
            Label2.Text = "Please Wait."
        Else
            Label2.Text = "Please Wait."
        End If
    End Sub

    Private Sub BWSearch_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BWSearch.RunWorkerCompleted
        Timer1.Enabled = False
        countfound()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            e.Handled = True
            doSearchBtn.PerformClick()
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'Try


        Dim idselected As Integer = DataGridView1.CurrentRow.Cells(0).Value.ToString
        Dim occurence As Integer = 0
        For Each a As DataGridViewRow In DataGridView1.Rows
            If a.Index <= DataGridView1.CurrentRow.Index Then
                If idselected = CInt(a.Cells(0).Value.ToString) Then
                    occurence += 1
                End If
            Else
                Exit For
            End If
        Next
        'Walang kwenta tong occurence

        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.Panel1.Controls.Add(ContainerForm.contentsearchhighlight)
        ContainerForm.contentsearchhighlight.changeConnstring(ContainerForm.departmentSelected)
        ContainerForm.contentsearchhighlight.viewhighlights(DataGridView1.CurrentRow.Cells(0).Value.ToString, searchedstring(DataGridView1.CurrentRow.Index), occurence)
        ContainerForm.contentsearchhighlight.Show()


        'ContentSearchHighlightForm.Show()
        'ContentSearchHighlightForm.viewhighlights(DataGridView1.CurrentRow.Cells(0).Value.ToString, searchedstring(DataGridView1.CurrentRow.Index), occurence)
        'Catch ex As Exception
        '    MsgBox("Currently on work")
        'End Try
    End Sub







    Public Function getcategoryid(category As String) As String
        'SELECT * FROM `topthesiscategorytbl`
        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM platformtbl"
        'SELECT * FROM thesistbl LEFT JOIN categorytbl ON thesistbl.categoryid = categorytbl.categoryid LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        Dim categoryid As String = ""

        While (reader.Read)
            If reader("platformname").ToString.Equals(category) Then
                categoryid = reader("platformid").ToString
            End If
            'Dim testarray() As String = Split(reader("researchername").ToString, "|")
            'Dim researchers As String = Join(testarray, ", ")
            'DataGridView1.Rows.Add(reader("thesisid").ToString, reader("thesistitle").ToString, reader("platformname").ToString, researchers, reader("dateofsubmission").ToString)
        End While

        conn.Close()

        Return categoryid

    End Function

    Private Sub doSearchBtn_Click(sender As Object, e As EventArgs) Handles doSearchBtn.Click
        If doSearchBtn.Text = "Search" Then
            If BWSearch.IsBusy Then
                MsgBox("There is already a process", vbOKOnly, "Axtaris")
            Else
                changeConnstring(ContainerForm.departmentSelected)

                searchsettings = ContainerForm.contentsearchtype

                Dim stringToTest As String = TextBox1.Text
                While stringToTest.EndsWith(" ") Or stringToTest.EndsWith(".")
                    stringToTest = stringToTest.Substring(0, stringToTest.Length - 1)
                End While
                While stringToTest.StartsWith(" ") Or stringToTest.StartsWith(".")
                    stringToTest = stringToTest.Substring(1, stringToTest.Length - 1)
                End While

                If stringToTest = "" Then
                    MsgBox("Don't leave the search field blank", vbOKOnly, "Axtaris")
                    Exit Sub
                End If

                If Not searchsettings = 1 Then
                    If Split(stringToTest, " ").Count = 1 Then
                        MsgBox("Cannot do a single word searching with wildcard searching", vbOKOnly, "Axtaris")
                        Exit Sub
                    End If
                End If

                If ContainerForm.contentsearchCategoryFilter.Equals("All") Then
                    categoryFilter = ContainerForm.contentsearchCategoryFilter
                Else
                    categoryFilter = getcategoryid(ContainerForm.contentsearchCategoryFilter)
                End If
                'categoryFilter = "All"
                'searchsettings = 3

                ContainerForm.executeTaskQuery("Content Search", "Scanned a paragraph (" & TextBox1.Text & ")")

                BWSearch.RunWorkerAsync()
            End If
            doSearchBtn.Text = "Stop"
        ElseIf doSearchBtn.Text = "Stop" Then
            Select Case MsgBox("Are you sure you want to stop searching?", vbYesNo, "Axtaris")
                Case vbYes
                    If Not doSearchBtn.Text = "Search" Then
                        doSearchBtn.Text = "Stopping"
                        BWSearch.CancelAsync()
                    End If
                Case vbNo
                Case Else
            End Select
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class