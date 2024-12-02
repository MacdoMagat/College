Imports MySql.Data.MySqlClient
Imports Word = Microsoft.Office.Interop.Word
Imports System.Math
Imports System.ComponentModel

Public Class ContentSearchPickForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Dim ptotal As Integer
    Dim pmatched As Integer
    Dim searchedstring As New List(Of String)
    Dim searchsettings As Integer
    Dim filePath As String = ""

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


    Function totalthesis()
        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "Select COUNT(*) As total FROM `thesistbl`"
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

    Public Sub countfound()
        'Label4.Text = "Found " & DataGridView1.Rows.Count & " Match(es)"
        'Label4.Text = (DataGridView1.Rows.Count / ptotal) * 100 & "%"
        Dim plagiarizedPercent As Double = (pmatched / ptotal) * 100
        Label4.Text = plagiarizedPercent.ToString("#.##") & "% plagiarized"
        Button2.Text = "Search"
        MsgBox("Searching Done!" & vbNewLine & "Matches Found: " & DataGridView1.Rows.Count)
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



    Private Sub Button2_Click(sender As Object, e As EventArgs)


        'Label2.Text = "Please Wait..."
        'ptotal = 0
        'killwordprocess()
        'Dim total As String = totalthesis()
        'Dim searchstring As String

        'Dim FileDoc As New Word.Document
        'Dim FileApp As New Word.Application
        'Dim Filerng As Word.Range

        'FileDoc = FileApp.Documents.Open(TextBox1.Text)
        'Filerng = FileDoc.Content

        'DataGridView1.Rows.Clear()

        'For paragraphnum As Integer = 1 To Filerng.Paragraphs.Count
        '    'Label3.Text = paragraphnum & " of " & Filerng.Paragraphs.Count
        '    Label3.Text = paragraphnum / Filerng.Paragraphs.Count * 100 & "%"
        '    searchstring = Filerng.Paragraphs.Item(paragraphnum).Range.Text 'kaya nag eeror dito ay dahil hindi paragraph ung nasa doc, tapos error din kase may vbcr ung string kaya di nag fifind
        '    searchstring = searchstring.Replace(vbCr, "") 'kaya may laktaw ay dahil paragraph na din ung enter vbcr
        '    searchstring = searchstring.Replace(vbTab, "")
        '    'MsgBox(searchstring.Count & vbNewLine & searchstring)
        '    If searchstring.Contains(".") Then
        '        ptotal = ptotal + 1
        '        While True
        '            If (searchstring.EndsWith(" ") Or searchstring.EndsWith(".")) And Not ContainerForm.contentsearchtype = 1 Then
        '                searchstring = searchstring.Substring(0, searchstring.Length - 1)
        '            Else
        '                Exit While
        '            End If
        '        End While

        '        conn.ConnectionString = connstring
        '        conn.Open()

        '        Dim comm As New MySqlCommand
        '        Dim commstring As String = "Select * FROM thesistbl"
        '        Dim reader As MySqlDataReader

        '        comm.Connection = conn
        '        comm.CommandText = commstring
        '        reader = comm.ExecuteReader

        '        Dim i As Integer = 1

        '        Dim MyDoc As New Word.Document
        '        Dim MyApp As New Word.Application
        '        Dim rng As Word.Range

        '        While reader.Read
        '            Dim path As String = reader("thesispath").ToString & ".docx"
        '            Dim thesisid As String = reader("thesisid").ToString
        '            Dim thesistitle As String = reader("thesistitle").ToString

        '            MyDoc = MyApp.Documents.Open(path)
        '            rng = MyDoc.Content

        '            'Label4.Text = i & " Of " & total & " Thesis"
        '            Label4.Text = i / total * 100 & "%"

        '            If ContainerForm.contentsearchtype = 1 Then
        '                search(paragraphnum, rng, searchstring, path, thesisid, thesistitle)
        '            ElseIf ContainerForm.contentsearchtype = 2 Then
        '                wildcardsearch(paragraphnum, rng, searchstring, path, thesisid, thesistitle)
        '            ElseIf ContainerForm.contentsearchtype = 3 Then
        '                searchevery5words(paragraphnum, rng, searchstring, path, thesisid, thesistitle)
        '            ElseIf ContainerForm.contentsearchtype = 4 Then
        '                wildcardsearch2(paragraphnum, rng, searchstring, path, thesisid, thesistitle)
        '            Else

        '            End If
        '            i = i + 1
        '        End While

        '        conn.Close()

        '        MyDoc.Close()
        '        MyApp.Quit()
        '        MyDoc = Nothing

        '    End If


        'Next
        'countfound()

    End Sub

    Public Sub search(paragraphnum As String, rng As Word.Range, searchstring As String, path As String, thesisid As String, thesistitle As String)
        Dim counter As Integer = Floor(searchstring.Count / 255)
        For i As Integer = 1 To rng.Paragraphs.Count
            'Label3.Text = i & " of " & rng.Paragraphs.Count & " paragraphs"
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
                            DataGridView1.Rows.Add(paragraphnum, thesisid, thesistitle, "Match Found on paragraph " & i)
                        End If
                    Next
                Else
                    newsearchstring = searchstring
                    .Text = newsearchstring
                    .Forward = True
                    .Execute()
                    If .Found = True Then
                        DataGridView1.Rows.Add(paragraphnum, thesisid, thesistitle, "Match Found on paragraph " & i)
                    End If
                End If


                'try ko muna alamin ung number of text na limit sa search 
                '255 lahat
            End With
        Next
    End Sub

    Public Sub wildcardsearch(paragraphnum As String, rng As Word.Range, searchstring As String, path As String, thesisid As String, thesistitle As String)
        For i As Integer = 1 To rng.Paragraphs.Count
            'Label3.Text = i & " of " & rng.Paragraphs.Count & " paragraphs"
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
                    DataGridView1.Rows.Add(paragraphnum, thesisid, thesistitle, "Match Found on paragraph " & i)
                    Exit For
                End While
            Next
        Next
    End Sub

    Public Sub searchevery5words(paragraphnum As String, rng As Word.Range, searchstring As String, path As String, thesisid As String, thesistitle As String)
        For i As Integer = 1 To rng.Paragraphs.Count
            'Label3.Text = i & " of " & rng.Paragraphs.Count & " paragraphs"
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
                        If DataGridView1.Rows.Count = 1 Then
                            DataGridView1.Rows.Add(paragraphnum, thesisid, thesistitle, "Match Found on paragraph " & i)
                        Else
                            Dim g As Integer = 0
                            Dim first As Boolean = True
                            While g <= DataGridView1.Rows.Count - 2
                                If DataGridView1.Rows(g).Cells(0).Value.Equals(paragraphnum) And DataGridView1.Rows(g).Cells(1).Value.Equals(thesisid) And DataGridView1.Rows(g).Cells(3).Value.Equals("Match Found on paragraph " & i) Then
                                    first = False
                                End If
                                g = g + 1
                            End While
                            If first Then
                                DataGridView1.Rows.Add(paragraphnum, thesisid, thesistitle, "Match Found on paragraph " & i)
                            End If
                        End If
                    End If
                End With
            Next
        Next
    End Sub

    Public Sub wildcardsearch2(paragraphnum As String, rng As Word.Range, searchstring As String, path As String, thesisid As String, thesistitle As String)
        For i As Integer = 1 To rng.Paragraphs.Count
            'Label3.Text = i & " of " & rng.Paragraphs.Count & " paragraphs"
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
                        If DataGridView1.Rows.Count = 1 Then
                            DataGridView1.Rows.Add(paragraphnum, thesisid, thesistitle, "Match Found on paragraph " & i)
                        Else
                            Dim g As Integer = 0
                            Dim first As Boolean = True
                            While g <= DataGridView1.Rows.Count - 2
                                If DataGridView1.Rows(g).Cells(0).Value.Equals(paragraphnum) And DataGridView1.Rows(g).Cells(1).Value.Equals(thesisid) And DataGridView1.Rows(g).Cells(3).Value.Equals("Match Found on paragraph " & i) Then
                                    first = False
                                End If
                                g = g + 1
                            End While
                            If first Then
                                DataGridView1.Rows.Add(paragraphnum, thesisid, thesistitle, "Match Found on paragraph " & i)
                            End If
                        End If
                    End If
                End With
                k = k + 1
            End While
        Next
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BWSearch.DoWork
        'Label2.Text = "Please Wait..."
        BWSearch.ReportProgress(1)

        BWSearch.ReportProgress(4)

        BWSearch.ReportProgress(2, "Initializing...")

        ptotal = 0
        pmatched = 0
        'killwordprocess()
        Dim total As String = totalthesis()
        Dim searchstring As String
        Dim detectedParagraphNums As New List(Of String)
        Dim citedParagraphNums As New List(Of String)


        Dim FileDoc As New Word.Document
        Dim FileApp As New Word.Application
        Dim Filerng As Word.Range

        FileDoc = FileApp.Documents.Open(TextBox1.Text, False, True)
        Filerng = FileDoc.Content


        Dim conn2 As New MySqlConnection
        conn2.ConnectionString = connstring
        conn2.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "Select * FROM thesistbl"
        ' WHERE thesistitle='Web-Based Ordering System for Jolibee'
        Dim reader As MySqlDataReader

        comm.Connection = conn2
        comm.CommandText = commstring
        reader = comm.ExecuteReader

        For paragraphCounter As Integer = 1 To Filerng.Paragraphs.Count
            If Filerng.Paragraphs.Item(paragraphCounter).Range.Text.Count < 20 Then
            Else
                'ptotal = ptotal + 1
            End If
        Next






        Dim MyDoc As New Word.Document
        Dim MyApp As New Word.Application
        Dim rng As Word.Range

        Dim counter As Integer
        Dim foundOnFile As Boolean = False
        Dim thesisNumber As Integer = 1
        Dim cited As Boolean = False
        Dim citedParagraphs As New List(Of Integer)
        Dim found As Boolean = False


        While reader.Read
            ptotal = 0

            Dim path As String = reader("thesispath").ToString & ".docx"
            Dim thesisid As String = reader("thesisid").ToString
            Dim thesistitle As String = reader("thesistitle").ToString
            Dim researchersname As String = reader("researchername").ToString

            MyDoc = MyApp.Documents.Open(path, False, True)
            rng = MyDoc.Content

            'Label4.Text = i & " Of " & total & " Thesis"
            'Label4.Text = i / total * 100 & "%"
            '(thesisNumber / total) * 100
            '_______________________________________________________________________
            Dim researcherIsCited As Boolean = False
            Dim matchFound As Boolean = False
            Dim detectedText As String = ""

            For paragraphnum As Integer = 1 To Filerng.Paragraphs.Count
                researcherIsCited = False
                matchFound = False
                detectedText = ""

                'Label3.Text = paragraphnum & " of " & Filerng.Paragraphs.Count
                'Label3.Text = paragraphnum / Filerng.Paragraphs.Count * 100 & "%"
                searchstring = Filerng.Paragraphs.Item(paragraphnum).Range.Text 'kaya nag eeror dito ay dahil hindi paragraph ung nasa doc, tapos error din kase may vbcr ung string kaya di nag fifind
                searchstring = searchstring.Replace(vbCr, "") 'kaya may laktaw ay dahil paragraph na din ung enter vbcr
                searchstring = searchstring.Replace(vbTab, "")
                'MsgBox(searchstring.Count & vbNewLine & searchstring)
                counter = Floor(searchstring.Count / 255)

                'ito ung inadjust ko para dun sa may "i-adjust ung least string to search, pataasin, kase nadedetect pa ito "Operational Analysis of the Existing System " , "Economical Analysis of the Existing System " - gawing 50"
                If Filerng.Paragraphs.Item(paragraphnum).Range.Text.Count < 50 Or (Filerng.Paragraphs.Item(paragraphnum).Range.Text.Count < 80 And Filerng.Paragraphs.Item(paragraphnum).Range.Text.StartsWith("Chapter")) Then 'ibigsabihin ay di kasama ung mga title
                Else

                    If searchstring.Contains(".") Then

                        While True
                            If (searchstring.EndsWith(" ") Or searchstring.EndsWith(".")) And Not searchsettings = 1 Then
                                searchstring = searchstring.Substring(0, searchstring.Length - 1)
                            Else
                                Exit While
                            End If
                        End While

                    End If
                    ptotal = ptotal + 1
                    foundOnFile = False


                    '(paragraphnum / Filerng.Paragraphs.Count ) * 100 (1/total)
                    '((paragraph / rng.Paragraphs.Count)) * 100) * (1/rng.Paragraphs.Count)

                    Dim percentage2 As Double = (((thesisNumber - 1) / total) * 100) + (((1 / total) * ((paragraphnum - 1) / Filerng.Paragraphs.Count)) * 100)
                    'Dim percentage2 As Double = (((thesisNumber - 1) / total) * 100)
                    'percentage2 = ((paragraphnum / Filerng.Paragraphs.Count * 100) / total) * 100
                    BWSearch.ReportProgress(2, percentage2.ToString("#.##") & "%")



                    'MsgBox(searchstring)
                    'Dim qoutedDivision As String()

                    'qoutedDivision = Split(searchstring, ControlChars.Quote)
                    'For Each qoutedString As String In qoutedDivision
                    '    'MsgBox(qoutedString)
                    'Next
                    'For Each qoutedString As String In qoutedDivision


                    Dim searchStringSentences As String()
                    searchStringSentences = Split(searchstring, ".")
                    For Each stringSentences As String In searchStringSentences

                        Dim sentenceOver255Limit = Floor(searchStringSentences.Count / 100)
                        Dim textToSearchList As New List(Of String)
                        For sentenceOver255Counter As Integer = 0 To sentenceOver255Limit
                            If sentenceOver255Counter = sentenceOver255Limit Then
                                textToSearchList.Add(stringSentences.Substring(100 * sentenceOver255Counter, stringSentences.Count Mod 100))

                            Else
                                textToSearchList.Add(stringSentences.Substring(100 * sentenceOver255Counter, 100))

                            End If
                        Next
                        For Each textToSearch As String In textToSearchList
                            If textToSearch.Count > 40 Then 'Baguhin ung > num kung mahaba pa o maikli ung sentences
                                Dim myRange As Word.Range
                                myRange = MyDoc.Content
                                myRange.Find.Text = textToSearch
                                myRange.Find.Forward = True
                                'MsgBox(textToSearch)
                                'MsgBox(myRange.Text)
                                myRange.Find.Execute()
                                If myRange.Find.Found Then
                                    'MsgBox("Found")
                                    detectedText = myRange.Find.Text
                                    matchFound = True
                                    Dim researcherKeyName As New List(Of String)
                                    Dim researchers() As String
                                    researchers = Split(researchersname, "|")
                                    For researcherName As Integer = 0 To researchers.Length - 1
                                        Dim researcherNickName() As String
                                        researcherNickName = Split(researchers(researcherName), " ")
                                        For nameCounter As Integer = 0 To researcherNickName.Length - 1
                                            If Not researcherNickName(nameCounter).Length <= 2 Then
                                                Dim myFileRange As Word.Range
                                                myFileRange = Filerng.Paragraphs.Item(paragraphnum).Range
                                                myFileRange.Find.Text = researcherNickName(nameCounter)
                                                myFileRange.Find.Forward = True
                                                'MsgBox(researcherNickName(nameCounter) & " | in? | " & myFileRange.Text)
                                                myFileRange.Find.Execute()
                                                If myFileRange.Find.Found Then
                                                    'MsgBox("Cited")
                                                    citedParagraphNums.Add(paragraphnum)
                                                    researcherIsCited = True
                                                    'Else
                                                    '    MsgBox("Not Cited")
                                                End If
                                            End If
                                        Next
                                    Next
                                    'Else
                                    '    MsgBox("Not Found")
                                End If
                            End If

                        Next
                        'Next


                    Next
                    'MsgBox("Paragraph Number = " & ptotal & "; matchFound = " & matchFound & "; researcherIsCited = " & researcherIsCited)
                    If matchFound And Not researcherIsCited And Not citedParagraphNums.Contains(paragraphnum) Then
                        BWSearch.ReportProgress(5, detectedText)
                        Dim resultstring As New List(Of String)
                        resultstring.Add(ptotal)
                        resultstring.Add(thesisid)
                        resultstring.Add(thesistitle)
                        resultstring.Add("Match Found on paragraph " & ptotal)
                        If Not detectedParagraphNums.Contains(paragraphnum) Then
                            pmatched = pmatched + 1
                            detectedParagraphNums.Add(paragraphnum)
                        Else
                            detectedParagraphNums.Add(paragraphnum)
                        End If
                        Dim resultt() As String = resultstring.ToArray
                        Dim resulttt As String = Join(resultt, "|")
                        BWSearch.ReportProgress(3, resulttt)
                        'If Not detectedParagraphNums.Contains(paragraphnum) Then
                        '    pmatched = pmatched + 1
                        '    detectedParagraphNums.Add(paragraphnum)
                        'Else
                        '    detectedParagraphNums.Add(paragraphnum)
                        'End If
                        'ito sana ung sa problem sa citation
                        '__________
                    ElseIf matchFound And researcherIsCited And citedParagraphNums.Contains(paragraphnum) Then 'ito ung dinagdag
                        'MsgBox(1)
                        Dim detectedFirstButCitedLater As Boolean = False
                        For Each row As DataGridViewRow In DataGridView1.Rows
                            'MsgBox(row.Cells(0).Value.ToString & " =?= " & paragraphnum)

                            If row.Cells(0).Value.ToString = paragraphnum Then
                                'MsgBox("true")
                                detectedFirstButCitedLater = True
                                Exit For
                            End If
                        Next
                        If detectedFirstButCitedLater Then
                            'MsgBox(2)
                            pmatched = pmatched - 1
                        End If
                        '__________
                    End If
                    'MsgBox(DataGridView1.ToString) 'ito ung dinagdag


                    ''''Exit Sub



                    ''''For databaseThesisParagraph As Integer = 1 To MyDoc.Range.Paragraphs.Count
                    ''''    Dim sentencesNotFoundCounter As Integer = 0
                    ''''    Dim sentencesFoundCounter As Integer = 0
                    ''''    For databaseThesisSentence As Integer = 1 To MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Count
                    ''''        Dim textToSearchList As New List(Of String)
                    ''''        If MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Item(databaseThesisSentence).Text.Length > 255 Then
                    ''''            Dim sentenceOver255Limit = Floor(MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Item(databaseThesisSentence).Text.Count / 255)
                    ''''            For sentenceOver255Counter As Integer = 0 To sentenceOver255Limit
                    ''''                If sentenceOver255Counter = sentenceOver255Limit Then
                    ''''                    textToSearchList.Add(MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Item(databaseThesisSentence).Text.Substring(255 * sentenceOver255Counter, MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Item(databaseThesisSentence).Text.Count Mod 255))
                    ''''                Else
                    ''''                    textToSearchList.Add(MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Item(databaseThesisSentence).Text.Substring(255 * sentenceOver255Counter, 255))
                    ''''                End If
                    ''''            Next
                    ''''        End If
                    ''''        For Each textToSearch As String In textToSearchList
                    ''''            MsgBox(textToSearch & " | is in? | " & FileDoc.Paragraphs.Item(paragraphnum).Range.Text)
                    ''''            If textToSearch.Length > 30 Then
                    ''''                FileDoc.Paragraphs.Item(paragraphnum).Range.Find.Text = textToSearch
                    ''''                If FileDoc.Paragraphs.Item(paragraphnum).Range.Find.Found Then
                    ''''                    MsgBox(MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Item(databaseThesisSentence).Text & " | Founded on:" & FileDoc.Paragraphs.Item(paragraphnum).Range.Text)
                    ''''                    sentencesFoundCounter = sentencesFoundCounter + 1
                    ''''                Else
                    ''''                    sentencesNotFoundCounter = sentencesNotFoundCounter + 1
                    ''''                End If
                    ''''            End If
                    ''''        Next
                    ''''        'MsgBox(MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Item(databaseThesisSentence).Text)
                    ''''    Next
                    ''''    MsgBox(sentencesFoundCounter & " / " & sentencesNotFoundCounter)
                    ''''Next






                    '''''For i As Integer = 1 To MyDoc.Paragraphs.Count
                    '''''    MsgBox(MyDoc.Paragraphs.Item(i).Range.Text)
                    '''''Next
                    '''''MsgBox(thesistitle)
                    '''''For databaseThesisParagraph As Integer = 1 To MyDoc.Range.Paragraphs.Count
                    '''''    Dim sentencesNotFoundCounter As Integer = 0
                    '''''    Dim sentencesFoundCounter As Integer = 0
                    '''''    For databaseThesisSentence As Integer = 1 To MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Count
                    '''''        Dim textToSearchList As New List(Of String)
                    '''''        If MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Item(databaseThesisSentence).Text.Length > 255 Then
                    '''''            Dim sentenceOver255Limit = Floor(MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Item(databaseThesisSentence).Text.Count / 255)
                    '''''            For sentenceOver255Counter As Integer = 0 To sentenceOver255Limit
                    '''''                If sentenceOver255Counter = sentenceOver255Limit Then
                    '''''                    textToSearchList.Add(MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Item(databaseThesisSentence).Text.Substring(255 * sentenceOver255Counter, MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Item(databaseThesisSentence).Text.Count Mod 255))
                    '''''                Else
                    '''''                    textToSearchList.Add(MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Item(databaseThesisSentence).Text.Substring(255 * sentenceOver255Counter, 255))
                    '''''                End If
                    '''''            Next
                    '''''        End If
                    '''''        For Each textToSearch As String In textToSearchList
                    '''''            MsgBox(textToSearch & " | is in? | " & FileDoc.Paragraphs.Item(paragraphnum).Range.Text)
                    '''''            If textToSearch.Length > 30 Then
                    '''''                FileDoc.Paragraphs.Item(paragraphnum).Range.Find.Text = textToSearch
                    '''''                If FileDoc.Paragraphs.Item(paragraphnum).Range.Find.Found Then
                    '''''                    MsgBox(MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Item(databaseThesisSentence).Text & " | Founded on:" & FileDoc.Paragraphs.Item(paragraphnum).Range.Text)
                    '''''                    sentencesFoundCounter = sentencesFoundCounter + 1
                    '''''                Else
                    '''''                    sentencesNotFoundCounter = sentencesNotFoundCounter + 1
                    '''''                End If
                    '''''            End If
                    '''''        Next
                    '''''        'MsgBox(MyDoc.Range.Paragraphs.Item(databaseThesisParagraph).Range.Sentences.Item(databaseThesisSentence).Text)
                    '''''    Next
                    '''''    MsgBox(sentencesFoundCounter & " / " & sentencesNotFoundCounter)
                    '''''Next




                    ''''Exit Sub










                    ''''With rng.Find
                    ''''    Dim newsearchstring As String
                    ''''    Dim searchsentences() As String = Split(searchstring, ".")
                    ''''    For Each sentenceToSearch As String In searchsentences
                    ''''        If sentenceToSearch.Equals("") Or sentenceToSearch.Equals(" ") Then
                    ''''        Else
                    ''''            MsgBox(sentenceToSearch)
                    ''''            If sentenceToSearch.Count > 255 Then
                    ''''                For o As Integer = 0 To counter
                    ''''                    If o = counter Then
                    ''''                        newsearchstring = sentenceToSearch.Substring(255 * o, sentenceToSearch.Count Mod 255)
                    ''''                    Else
                    ''''                        newsearchstring = sentenceToSearch.Substring(255 * o, 255)
                    ''''                    End If
                    ''''                    If newsearchstring.Count < 15 Then
                    ''''                        Exit For
                    ''''                    End If
                    ''''                    .Text = sentenceToSearch
                    ''''                    .Forward = True
                    ''''                    .Execute()
                    ''''                    If .Found = True Then
                    ''''                        MsgBox("Found on File")
                    ''''                        foundOnFile = True
                    ''''                    End If
                    ''''                Next
                    ''''            Else
                    ''''                newsearchstring = sentenceToSearch
                    ''''                .Text = newsearchstring
                    ''''                .Forward = True
                    ''''                .Execute()
                    ''''                If .Found = True Then
                    ''''                    MsgBox("Found on File")
                    ''''                    foundOnFile = True
                    ''''                End If
                    ''''            End If


                    ''''        End If



                    ''''    Next

                    ''''End With

                    ''''If foundOnFile Then
                    ''''    MsgBox("Found on File")
                    ''''    rng = MyDoc.Content
                    ''''    For paragraph As Integer = 1 To rng.Paragraphs.Count
                    ''''        cited = False
                    ''''        found = False
                    ''''        If Not citedParagraphs.Contains(paragraph) Or citedParagraphs.Count = 0 Then


                    ''''            'MsgBox(thesisNumber - 1 & " /  " & total & " * 100 = " & (thesisNumber - 1 / total) * 100)
                    ''''            Dim percentage As Double = (((thesisNumber - 1) / total) * 100) + (((1 / total) * ((paragraphnum - 1) / Filerng.Paragraphs.Count)) * 100) + (((1 / total) * (1 / Filerng.Paragraphs.Count)) * ((paragraph - 1) / rng.Paragraphs.Count) * 100)
                    ''''            '(paragraphnum / Filerng.Paragraphs.Count * 100)
                    ''''            'Dim percentage As Double = (((((thesisNumber - 1) / total) * 100) + (((1 / total) * (paragraph / rng.Paragraphs.Count)) * 100)))
                    ''''            'Dim percentage As Double = ((((((thesisNumber - 1) / total) * 100) + (((1 / total) * (paragraph / rng.Paragraphs.Count)) * 100))) * 1 / Filerng.Paragraphs.Count) + (paragraphnum / Filerng.Paragraphs.Count * 100)
                    ''''            BWSearch.ReportProgress(2, percentage.ToString("#.##") & "%")
                    ''''            With rng.Paragraphs.Item(paragraph).Range.Find

                    ''''                Dim paragraphRange As Word.Range = Filerng.Paragraphs.Item(paragraphnum).Range
                    ''''                Dim searchsentences() As String = Split(searchstring, ".")
                    ''''                For Each sentenceToSearch As String In searchsentences
                    ''''                    Dim newsearchstring As String
                    ''''                    If sentenceToSearch.Count > 255 Then
                    ''''                        For o As Integer = 0 To counter
                    ''''                            If o = counter Then
                    ''''                                newsearchstring = sentenceToSearch.Substring(255 * o, sentenceToSearch.Count Mod 255)
                    ''''                            Else
                    ''''                                newsearchstring = sentenceToSearch.Substring(255 * o, 255)
                    ''''                            End If
                    ''''                            If newsearchstring.Count < 15 Then
                    ''''                                Exit For
                    ''''                            End If
                    ''''                            .Text = sentenceToSearch
                    ''''                            .Forward = True
                    ''''                            .Execute()
                    ''''                            If .Found = True Then
                    ''''                                found = True
                    ''''                                Dim researcherKeyName As New List(Of String)
                    ''''                                Dim researchers() As String
                    ''''                                researchers = Split(researchersname, "|")
                    ''''                                For i As Integer = 0 To researchers.Length - 1
                    ''''                                    Dim researcherNickName() As String
                    ''''                                    researcherNickName = Split(researchers(i), " ")
                    ''''                                    For nameCounter As Integer = 0 To researcherNickName.Length - 1
                    ''''                                        If Not researcherNickName(nameCounter).Length <= 2 Then
                    ''''                                            researcherKeyName.Add(researcherNickName(nameCounter))
                    ''''                                        End If
                    ''''                                    Next

                    ''''                                Next
                    ''''                                For Each name As String In researcherKeyName
                    ''''                                    paragraphRange.Find.Text = name
                    ''''                                    paragraphRange.Find.Execute()
                    ''''                                    MsgBox(name)
                    ''''                                    If paragraphRange.Find.Found Then
                    ''''                                        MsgBox("Found")
                    ''''                                        cited = True
                    ''''                                    End If
                    ''''                                Next


                    ''''                                'BWSearch.ReportProgress(5, .Text)
                    ''''                                'Dim resultstring As New List(Of String)
                    ''''                                'resultstring.Add(paragraphnum)
                    ''''                                'resultstring.Add(thesisid)
                    ''''                                'resultstring.Add(thesistitle)
                    ''''                                'resultstring.Add("Match Found on paragraph " & paragraph)
                    ''''                                'If Not detectedParagraphNums.Contains(paragraphnum) Then
                    ''''                                '    pmatched = pmatched + 1
                    ''''                                '    detectedParagraphNums.Add(paragraphnum)
                    ''''                                'Else
                    ''''                                '    detectedParagraphNums.Add(paragraphnum)
                    ''''                                'End If
                    ''''                                'Dim resultt() As String = resultstring.ToArray
                    ''''                                'Dim resulttt As String = Join(resultt, "|")
                    ''''                                'BWSearch.ReportProgress(3, resulttt)
                    ''''                            End If
                    ''''                        Next
                    ''''                    Else
                    ''''                        newsearchstring = sentenceToSearch
                    ''''                        .Text = newsearchstring
                    ''''                        .Forward = True
                    ''''                        .Execute()
                    ''''                        If .Found = True Then
                    ''''                            found = True
                    ''''                            Dim researcherKeyName As New List(Of String)
                    ''''                            Dim researchers() As String
                    ''''                            researchers = Split(researchersname, "|")
                    ''''                            For i As Integer = 0 To researchers.Length - 1
                    ''''                                Dim researcherNickName() As String
                    ''''                                researcherNickName = Split(researchers(i), " ")
                    ''''                                For nameCounter As Integer = 0 To researcherNickName.Length - 1
                    ''''                                    If Not researcherNickName(nameCounter).Length <= 2 Then
                    ''''                                        researcherKeyName.Add(researcherNickName(nameCounter))
                    ''''                                    End If
                    ''''                                Next
                    ''''                            Next
                    ''''                            For Each name As String In researcherKeyName
                    ''''                                paragraphRange.Find.Text = name
                    ''''                                paragraphRange.Find.Execute()
                    ''''                                If paragraphRange.Find.Found Then
                    ''''                                    cited = True
                    ''''                                End If
                    ''''                            Next


                    ''''                            ''MsgBox(.Text)
                    ''''                            'BWSearch.ReportProgress(5, .Text)

                    ''''                            'Dim resultstring As New List(Of String)
                    ''''                            'resultstring.Add(paragraphnum)
                    ''''                            'resultstring.Add(thesisid)
                    ''''                            'resultstring.Add(thesistitle)
                    ''''                            'resultstring.Add("Match Found on paragraph " & paragraph)
                    ''''                            'If Not detectedParagraphNums.Contains(paragraphnum) Then
                    ''''                            '    pmatched = pmatched + 1
                    ''''                            '    detectedParagraphNums.Add(paragraphnum)
                    ''''                            'Else
                    ''''                            '    detectedParagraphNums.Add(paragraphnum)
                    ''''                            'End If
                    ''''                            'Dim resultt() As String = resultstring.ToArray
                    ''''                            'Dim resulttt As String = Join(resultt, "|")
                    ''''                            'BWSearch.ReportProgress(3, resulttt)
                    ''''                        End If

                    ''''                    End If
                    ''''                Next




                    ''''                If found And Not cited Then
                    ''''                    BWSearch.ReportProgress(5, .Text)

                    ''''                    Dim resultstring As New List(Of String)
                    ''''                    resultstring.Add(paragraphnum)
                    ''''                    resultstring.Add(thesisid)
                    ''''                    resultstring.Add(thesistitle)
                    ''''                    resultstring.Add("Match Found on paragraph " & paragraph)
                    ''''                    If Not detectedParagraphNums.Contains(paragraphnum) Then
                    ''''                        pmatched = pmatched + 1
                    ''''                        detectedParagraphNums.Add(paragraphnum)
                    ''''                    Else
                    ''''                        detectedParagraphNums.Add(paragraphnum)
                    ''''                    End If
                    ''''                    Dim resultt() As String = resultstring.ToArray
                    ''''                    Dim resulttt As String = Join(resultt, "|")
                    ''''                    BWSearch.ReportProgress(3, resulttt)
                    ''''                End If
                    ''''            End With
                    ''''        End If
                    ''''    Next
                    ''''End If










                    '_______________________________________________________________________
                    If BWSearch.CancellationPending Then
                        e.Cancel = True
                        Exit While
                    End If
                End If



            Next
            thesisNumber = thesisNumber + 1
        End While

        ptotal = 0
        For paragraphCounter As Integer = 1 To Filerng.Paragraphs.Count
            If Filerng.Paragraphs.Item(paragraphCounter).Range.Text.Count < 20 Then
            Else
                ptotal = ptotal + 1
            End If
        Next

        MyDoc.Close(Word.WdSaveOptions.wdDoNotSaveChanges)
        MyApp.Quit()
        MyDoc = Nothing

        FileDoc.Close(Word.WdSaveOptions.wdDoNotSaveChanges)
        FileApp.Quit()
        FileDoc = Nothing

        conn2.Close()
        'countfound()
    End Sub




    Private Sub BWSearch_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BWSearch.RunWorkerCompleted
        Timer1.Enabled = False
        Button1.Enabled = True
        countfound()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Label3.Text.Equals("Please Wait.") Then
            Label3.Text = "Please Wait.."
        ElseIf Label3.Text.Equals("Please Wait..") Then
            Label3.Text = "Please Wait..."
        ElseIf Label3.Text.Equals("Please Wait...") Then
            Label3.Text = "Please Wait."
        Else
            Label3.Text = "Please Wait."
        End If
    End Sub

    Private Sub BWSearch_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BWSearch.ProgressChanged
        If e.ProgressPercentage() = 1 Then
            Label3.Text = "Please Wait"
            Timer1.Enabled = True
        ElseIf e.ProgressPercentage() = 2 Then
            If e.UserState.ToString.StartsWith(".") Or e.UserState.ToString.StartsWith("%") Then
                Label4.Text = "0" & e.UserState
            Else
                Label4.Text = e.UserState
            End If

        ElseIf e.ProgressPercentage() = 3 Then
            Dim asd() As String = Split(e.UserState.ToString, "|")
            DataGridView1.Rows.Add(asd(0), asd(1), asd(2), asd(3))

        ElseIf e.ProgressPercentage() = 4 Then
            searchedstring.Clear()
            DataGridView1.Rows.Clear()
        ElseIf e.ProgressPercentage() = 5 Then
            searchedstring.Add(e.UserState.ToString)
        End If
    End Sub



    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim worddialog As New OpenFileDialog
        worddialog.Filter = "Word Document (*.docx)|*.docx"
        worddialog.DefaultExt = "docx"
        If worddialog.ShowDialog = DialogResult.OK Then
            TextBox1.Text = worddialog.FileName
            Dim title As String = ""
            title = worddialog.FileName.ToString.Substring(worddialog.FileName.LastIndexOf("\")).Replace("\", "")
            title = title.Substring(0, title.LastIndexOf("."))
            Label6.Text = title
            'Label6.Text = worddialog.FileName.ToString.Substring(worddialog.FileName.LastIndexOf("\")).Replace("\", "")
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("Please select a document first")
            Exit Sub
        End If
        If Button2.Text = "Search" Then
            If BWSearch.IsBusy Then
                MsgBox("There is already a process")
            Else
                changeConnstring(ContainerForm.departmentSelected)
                searchsettings = ContainerForm.contentsearchtype
                ContainerForm.executeTaskQuery("Content Search", "Scanned a Word File (" & Label6.Text & ")")
                Button1.Enabled = False
                filePath = TextBox1.Text
                BWSearch.RunWorkerAsync()
            End If
            Button2.Text = "Stop"
        ElseIf Button2.Text = "Stop" Then
            Select Case MsgBox("Are you sure you want to stop searching?", vbYesNo)
                Case vbYes
                    If Not Button2.Text = "Search" Then
                        Button2.Text = "Stopping"
                        BWSearch.CancelAsync()
                    End If
                Case vbNo
                Case Else
            End Select
        End If

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.Panel1.Controls.Add(ContainerForm.contentsearch)
        ContainerForm.contentsearch.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'MsgBox(searchedstring(DataGridView1.CurrentRow.Index))
        'Try

        'Dim occurence As Integer = 0
        'For Each a As DataGridViewRow In DataGridView1.Rows
        '    If a.Index <= DataGridView1.CurrentRow.Index Then
        '        If idselected = CInt(a.Cells(0).Value.ToString) Then
        '            occurence += 1
        '        End If
        '    Else
        '        Exit For
        '    End If
        'Next



        'menuCategoryClicked(btnContentSearch)
        'selectedmenu = 4
        'menuclicked()
        'Panel1.Controls.Clear()
        'Panel1.Controls.Add(contentsearch)
        'contentsearch.Show()

        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.Panel1.Controls.Add(ContainerForm.contentsearchpickhighlight)
        ContainerForm.contentsearchpickhighlight.changeConnstring(ContainerForm.departmentSelected)
        ContainerForm.contentsearchpickhighlight.Show()
        ContainerForm.contentsearchpickhighlight.viewHighlights(DataGridView1.CurrentRow.Cells(1).Value.ToString, filePath, searchedstring(DataGridView1.CurrentRow.Index))

        'ContentSearchPickHighlightForm.Show()
        'ContentSearchPickHighlightForm.viewHighlights(DataGridView1.CurrentRow.Cells(1).Value.ToString, filePath, searchedstring(DataGridView1.CurrentRow.Index))
    End Sub
End Class