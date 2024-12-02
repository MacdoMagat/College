Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Imports Spire.Pdf
Imports Spire.Pdf.General.Find
Imports System.Math

Public Class ContentSearchHighlightForm
    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Dim thesispath As String
    Dim count As Integer = 0
    Dim occ As Integer = 0
    Dim a As String
    Dim b As Integer
    Dim thesistitle As String

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


    Public Sub viewhighlights(selectedid As String, searchedstring As String, occurence As Integer)
        AxAcroPDF1.src = Application.StartupPath.ToString & "\Others\NoFileSelected.pdf"
        a = searchedstring
        b = occurence

        Dim path As String = ""

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM thesistbl LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid WHERE thesisid = " & selectedid
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        'Dim researchers() As String
        Dim dateManipulator As Date
        While (reader.Read)
            thesispath = reader("thesispath").ToString
            path = reader("thesispath").ToString & ".pdf"

            dateManipulator = reader("datepublished").ToString

            thesistitle = reader("thesistitle").ToString & vbNewLine & dateManipulator.Date.ToString("MMMM yyyy")

            'thesistitle = reader("thesistitle").ToString
            'AxAcroPDF1.src = path
            'Label9.Text = reader("thesisid").ToString
            'Label10.Text = reader("thesistitle").ToString
            'Label11.Text = reader("platformname").ToString
            'Label12.Text = reader("platformname").ToString
            'researchers = Split(reader("researchername").ToString, "|")
            'Label14.Text = reader("dateofsubmission").ToString
        End While
        'Label13.Text = ""
        'For i As Integer = 0 To researchers.Length - 1
        '    Label13.Text = Label13.Text & researchers(i).ToString & vbNewLine

        'Next
        conn.Close()













        'MsgBox(path & " | " & searchedstring)
        Label1.Text = thesistitle

        Dim pdf As New PdfDocument(path)
        Dim stringko As String = searchedstring
        While stringko.EndsWith(".") Or stringko.EndsWith(" ")
            stringko = stringko.Substring(0, stringko.Length - 1)
        End While


        Dim stringarrayko As New List(Of String)

        Dim count As Integer = Ceiling(stringko.Length / 20)



        For i As Integer = 0 To count
            If i = count - 1 Then
                stringarrayko.Add(stringko.Substring(i * 20, stringko.Count Mod 20))
                Exit For
            Else

                stringarrayko.Add(stringko.Substring(i * 20, 20))
            End If
        Next










        'pdf.LoadFromFile()

        'While sentence.EndsWith(".") Or sentence.EndsWith(" ")
        '        sentence = sentence.Substring(0, sentence.Length - 1)
        '    End While



        Dim result As PdfTextFind() = Nothing


        For Each page As PdfPageBase In pdf.Pages
            For Each aa As String In stringarrayko
                If aa.Length > 5 Then
                    result = page.FindText(aa).Finds
                    For Each find As PdfTextFind In result
                        find.ApplyHighLight(Color.Red)
                    Next
                End If
            Next





        Next



        'result = page.FindText("elements you want from the different galleries").Finds

        'For Each find As PdfTextFind In result
        '    find.ApplyHighLight(Color.Red)
        'Next


        'pdf.Close()




        'pdf.SaveToFile("C:\Users\C a e l l a c h\Desktop\result.pdf")

        pdf.SaveToFile(Application.StartupPath & "\Others\Result.pdf")
        AxAcroPDF1.src = Application.StartupPath & "\Others\Result.pdf#toolbar=0"


        'AxAcroPDF1.src = "C:\Users\C a e l l a c h\Desktop\result.pdf#toolbar=0"
        'System.Diagnostics.Process.Start("result.pdf")














        ''MsgBox(selectedid)
        ''MsgBox(searchedstring)
        ''MsgBox(path)

        'If AxAcroPDF1.src Then


        'System.Threading.Thread.Sleep(1000)

        'If AxAcroPDF1.src = path Then

        ''''AxAcroPDF1.Select()
        ''''SendKeys.Send("^f")
        ''''SendKeys.Send(searchedstring)
        ''''SendKeys.Send("~")
        'count = 0
        'occ = occurence
        'Timer1.Enabled = True



        '_____________
        'Timer2.Enabled = True

        'End If





        'AxAcroPDF1.Select()
        'SendKeys.Send("{ESC}")
        'For i As Integer = 0 To occurence - 1
        '    'MsgBox(i)
        '    SendKeys.Send("~")
        '    SendKeys.Flush()
        '    System.Threading.Thread.Sleep(100)
        'Next











        '_____________________________________________________








        'Dim pAcroPDPage As Acrobat.AcroPDPage
        'Dim avobj As Acrobat.AcroAVDoc
        'Dim myPDFPageHiliteObj As Acrobat.AcroHiliteList
        'Dim wordToHilite As Acrobat.AcroHiliteList

        'Dim acroAppObj As Object, PDFDocObj As Object, PDFJScriptObj As Object
        'Dim wordHilite As Object, annot As Object, props As Object, RectDim As Object
        'Dim colorObject(3) As Object, objRect(3) As Object
        'Dim iword As Integer, popupRect(0 To 3) As Integer, iTotalWords As Integer
        'Dim numOfPage As Integer, Nthpage As Integer, result As Integer
        'Dim word As String, sPath As String
        'Dim bUKtext As Boolean, bUStext As Boolean



        'acroAppObj = CreateObject("AcroExch.App")
        'PDFDocObj = CreateObject("AcroExch.PDDoc")
        'avobj = CreateObject("AcroExch.AVDoc")
        'myPDFPageHiliteObj = CreateObject("AcroExch.HiliteList")
        'wordToHilite = CreateObject("AcroExch.HiliteList")
        'myPDFPageHiliteObj.Add(0, 32767)
        '' RectDim = CreateObject("AcroExch.Rect")
        'sPath = "E:\00001.pdf"
        'PDFDocObj.Open(path)
        ''to open for testing doc
        ''avobj = PDFDocObj.OpenAVDoc("testing")
        '' Hide Acrobat application so everything is done in silent

        'acroAppObj.Hide()

        'numOfPage = PDFDocObj.GetNumPAges


        'word = vbNullString
        'PDFJScriptObj = Nothing

        'For Nthpage = 0 To numOfPage - 1

        '    pAcroPDPage = PDFDocObj.AcquirePage(Nthpage)
        '    wordHilite = pAcroPDPage.CreateWordHilite(myPDFPageHiliteObj)
        '    PDFJScriptObj = PDFDocObj.GetJSObject
        '    iTotalWords = wordHilite.GetNumText
        '    iTotalWords = PDFJScriptObj.getPageNumWords(Nthpage)
        '    ''check the each word
        '    For iword = 0 To iTotalWords - 1

        '        bUStext = False
        '        bUKtext = False
        '        wordToHilite = CreateObject("AcroExch.HiliteList")
        '        wordHilite = pAcroPDPage.CreateWordHilite(myPDFPageHiliteObj)
        '        'word = Trim(CStr(PDFJScriptObj.getPageNthWord(Nthpage, iword)))
        '        word = PDFJScriptObj.getPageNthWord(Nthpage, iword).ToString.Trim
        '        ' word = Trim(word)
        '        '' Check to see if the word contains the desired text at the start
        '        result = -1
        '        If word <> "" Then

        '            If word = "sample1" Then
        '                result = 0
        '                bUStext = True
        '            End If

        '            If result <> 0 And bUStext = False Then
        '                If word = "sample2" Then
        '                    result = 0
        '                    bUKtext = True
        '                End If
        '            End If
        '            If result = 0 Then
        '                ''create obj to highlight word
        '                wordToHilite.Add(iword, 1)
        '                wordHilite = pAcroPDPage.CreateWordHilite(wordToHilite)
        '                RectDim = wordHilite.GetBoundingRect

        '                If Not PDFJScriptObj Is Nothing Then

        '                    popupRect(0) = RectDim.Left
        '                    popupRect(1) = RectDim.Top
        '                    popupRect(2) = RectDim.Right
        '                    popupRect(3) = RectDim.bottom
        '                    annot = PDFJScriptObj.AddAnnot
        '                    props = annot.getProps
        '                    props.Type = "Square"
        '                    annot.setProps(props)
        '                    props = annot.getProps
        '                    ' props.fillColor = PDFJScriptObj.Color.red
        '                    props.page = Nthpage
        '                    props.Hidden = False
        '                    props.Lock = True 'False
        '                    props.Name = word
        '                    props.noView = False
        '                    props.opacity = 0.5
        '                    props.ReadOnly = True ' False
        '                    props.Style = "S"
        '                    props.toggleNoView = False
        '                    props.popupOpen = False
        '                    props.rect = popupRect
        '                    props.popupRect = popupRect
        '                    If bUStext = True Then
        '                        props.strokeColor = PDFJScriptObj.Color.red
        '                        props.fillColor = PDFJScriptObj.Color.red
        '                    ElseIf bUKtext = True Then
        '                        props.strokeColor = PDFJScriptObj.Color.blue
        '                        props.fillColor = PDFJScriptObj.Color.blue
        '                    End If
        '                    annot.setProps(props)
        '                    wordToHilite = Nothing
        '                End If
        '            End If
        '            word = ""
        '        End If
        '    Next iword
        'Next Nthpage








        '__________________________________________________________________________________-

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        count += 1
        If count > occ Then
            Timer1.Enabled = False
        Else
            SendKeys.Send("~")
        End If

    End Sub

    Private Sub ContentSearchHighlightForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        AxAcroPDF1.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        AxAcroPDF1.Select()

        SendKeys.Send("^f")

        SendKeys.Flush()

        SendKeys.Send(a)

        SendKeys.Flush()
        count = 0
        occ = b
        Timer1.Enabled = True
        Timer2.Enabled = False
    End Sub

    Private Sub ContentSearchHighlightForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        AxAcroPDF1.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.Panel1.Controls.Add(ContainerForm.contentsearch)
        ContainerForm.contentsearch.Show()
    End Sub
End Class