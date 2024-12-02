Imports MySql.Data.MySqlClient
Imports Spire.Pdf
Imports Spire.Pdf.General.Find
Imports System.Math
Imports Word = Microsoft.Office.Interop.Word
Public Class ContentSearchPickHighlightForm
    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"
    Dim thesispath As String
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


    Public Sub viewHighlights(thesisId As String, filePath As String, searchedString As String)
        Label1.Text = "Generating Preview"
        Label2.Text = "Generating Preview"
        AxAcroPDF1.src = Application.StartupPath.ToString & "\Others\GeneratingPreview.pdf"
        AxAcroPDF2.src = Application.StartupPath.ToString & "\Others\GeneratingPreview.pdf"

        loadHighlightedLeftPDF(thesisId, searchedString)
        loadHighlightedRightPDF(filePath, searchedString)


        Dim title As String = ""
        title = filepath.Substring(filepath.LastIndexOf("\")).Replace("\", "")
        title = title.Substring(0, title.LastIndexOf("."))
        Label1.Text = thesistitle
        Label2.Text = title
        AxAcroPDF1.src = Application.StartupPath & "\Others\Left.pdf#toolbar=0"
        AxAcroPDF2.src = Application.StartupPath & "\Others\Right.pdf#toolbar=0"

    End Sub

    Public Sub loadHighlightedLeftPDF(thesisId As String, searchedString As String)

        Dim path As String = ""

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM thesistbl LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid WHERE thesisid = " & thesisId
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
        End While

        conn.Close()


        'MsgBox(path & " | " & searchedString)
        Dim pdf As New PdfDocument(path)
        Dim stringko As String = searchedString
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

        Dim result As PdfTextFind() = Nothing

        For Each page As PdfPageBase In pdf.Pages
            For Each aa As String In stringarrayko
                If aa.Length > 10 Then
                    result = page.FindText(aa).Finds
                    For Each find As PdfTextFind In result
                        find.ApplyHighLight(Color.Red)
                    Next
                End If
            Next
        Next

        pdf.SaveToFile(Application.StartupPath & "\Others\Left.pdf")
    End Sub


    Public Sub loadHighlightedRightPDF(path As String, searchedString As String)
        Dim MyApp As New Word.Application
        Dim MyDoc As Word.Document = MyApp.Documents.Open(path, False, True)
        Try
            MyDoc.Activate()
            MyDoc.SaveAs2(Application.StartupPath.ToString & "\Others\tempRight.pdf", Word.WdSaveFormat.wdFormatPDF)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        MyDoc.Close()
        MyApp.Quit()

        Dim pdf As New PdfDocument(Application.StartupPath.ToString & "\Others\tempRight.pdf")
        Dim stringko As String = searchedString
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

        Dim result As PdfTextFind() = Nothing

        For Each page As PdfPageBase In pdf.Pages
            For Each aa As String In stringarrayko
                If aa.Length > 10 Then
                    result = page.FindText(aa).Finds
                    For Each find As PdfTextFind In result
                        find.ApplyHighLight(Color.Red)
                    Next
                End If
            Next
        Next

        pdf.SaveToFile(Application.StartupPath & "\Others\Right.pdf")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.Panel1.Controls.Add(ContainerForm.contentsearchpick)
        ContainerForm.contentsearchpick.Show()
    End Sub
End Class