
Imports System.Runtime.InteropServices
Imports word = Microsoft.Office.Interop.Word

Public Class SpellingAndGrammarCheckForm
        Inherits System.Windows.Forms.Form

    ' Invokes either the spell or grammar checker.  
    Private Sub SpellOrGrammarCheck(ByVal SpellOnly As Boolean)



        If textbox1.Text.Length > 0 Then
            Dim word_server As New word.Application
            word_server.Visible = False
            Dim doc As word.Document = word_server.Documents.Add()
            Dim rng As word.Range

            rng = doc.Range
            rng.Text = textbox1.Text

            doc.Activate()
            If SpellOnly Then
                doc.CheckSpelling()
            Else
                doc.CheckGrammar()
            End If

            Dim chars() As Char = {CType(vbCr, Char), CType(vbLf, Char)}

            textbox1.Text = doc.Range().Text.Trim(chars)

            doc.Close(SaveChanges:=False)
            word_server.Quit()
        End If












        '    Try
        '        ' Create Word and temporary document objects.
        '        Dim objWord As Object
        '        Dim objTempDoc As Object
        '        ' Declare an IDataObject to hold the data returned from the 
        '        ' clipboard.
        '        Dim iData As IDataObject

        '    ' If there is no data to spell check, then exit sub here.
        '    If textbox1.Text = "" Then
        '        Exit Sub
        '    End If

        '    objWord = New word.Application()
        '    objTempDoc = objWord.Documents.Add
        '    objWord.Visible = False

        '    ' Position Word off the screen...this keeps Word invisible 
        '    ' throughout.
        '    objWord.WindowState = 0
        '    objWord.Top = -3000

        '    ' Copy the contents of the textbox to the clipboard
        '    Clipboard.SetDataObject(textbox1.Text)

        '    ' With the temporary document, perform either a spell check or a 
        '    ' complete
        '    ' grammar check, based on user selection.
        '    With objTempDoc
        '        .Content.Paste()
        '        .Activate()


        '        If blnSpellOnly Then
        '            .CheckSpelling()
        '        Else
        '            .CheckGrammar()
        '        End If
        '        ' After user has made changes, use the clipboard to
        '        ' transfer the contents back to the text box
        '        .Content.Copy()
        '        iData = Clipboard.GetDataObject
        '        If iData.GetDataPresent(DataFormats.Text) Then
        '            textbox1.Text = CType(iData.GetData(DataFormats.Text),
        '                String)
        '        End If
        '        .Saved = True
        '        .Close()
        '    End With

        '    objWord.Quit()

        '    MessageBox.Show("The spelling check is complete.",
        '        "Spell Checker", MessageBoxButtons.OK,
        '        MessageBoxIcon.Information)

        '    ' Microsoft Word must be installed. 
        'Catch COMExcep As COMException
        '    MessageBox.Show(
        '        "Microsoft Word must be installed for Spell/Grammar Check " _
        '        & "to run.", "Spell Checker")

        'Catch Excep As Exception
        '    MessageBox.Show("An error has occured.", "Spell Checker")

        'End Try

    End Sub

    Private Sub btnSpellCheck_Click_1(sender As Object, e As EventArgs) Handles btnSpellCheck.Click
        SpellOrGrammarCheck(True)
    End Sub

    Private Sub btnGrammarCheck_Click_1(sender As Object, e As EventArgs) Handles btnGrammarCheck.Click
        SpellOrGrammarCheck(False)
    End Sub
End Class