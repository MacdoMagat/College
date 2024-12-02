Imports MySql.Data.MySqlClient

Public Class RetrieveThesisForm

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost;User Id=root;Password=;Database=etas"

    Public Sub retrievethesisformclicked()
        ComboBox1.SelectedIndex = 0
        DataGridView1.Rows.Clear()

        conn.ConnectionString = connstring
        conn.Open()

        Dim comm As New MySqlCommand
        Dim commstring As String = "SELECT * FROM thesistbl LEFT JOIN categorytbl ON thesistbl.categoryid = categorytbl.categoryid LEFT JOIN platformtbl ON thesistbl.platformid = platformtbl.platformid"
        Dim reader As MySqlDataReader
        comm.CommandText = commstring
        comm.Connection = conn
        reader = comm.ExecuteReader

        While (reader.Read)
            Dim testarray() As String = Split(reader("researchername").ToString, "|")
            Dim researchers As String = Join(testarray, ", ")
            DataGridView1.Rows.Add(reader("thesisid").ToString, reader("thesistitle").ToString, reader("platformname").ToString, reader("categoryname").ToString, researchers, reader("dateofsubmission").ToString)
        End While

        conn.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ContainerForm.Panel1.Controls.Clear()
        ContainerForm.Panel1.Controls.Add(ContainerForm.retrievethesisview)

        'ContainerForm.retrievethesisview.currentid = DataGridView1.CurrentRow.Cells(0).Value.ToString
        ContainerForm.retrievethesisview.viewthesis(DataGridView1.CurrentRow.Cells(0).Value.ToString)
        ContainerForm.retrievethesisview.Show()

    End Sub
End Class