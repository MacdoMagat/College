Public Class AddForm

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(Me.Location.X.ToString)
        MsgBox(Me.Location.Y.ToString)
        MsgBox(Me.Size.ToString)

        Dim connection As New Connections
        connection.AddFormAddInformation(id_notxt.Text, lastnametxt.Text, firstnametxt.Text, middlenametxt.Text, addresstxt.Text, school_attendedtxt.Text, qualificationtxt.Text, assessortxt.Text, assessment_centertxt.Text, statustxt.Text, certificate_numbertxt.Text, date_of_assessmenttxt.Text, expiration_datetxt.Text, competenciestxt.Text, control_numbertxt.Text)
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        date_of_assessmenttxt.Text = DateTimePicker1.Value.Date.ToString("MM/dd/yyyy")
        'Dim d As Date = DateTimePicker1.Value
        'MsgBox(d.ToString)
        'd.AddYears(5)
        'DateTimePicker2.Value = d
        'MsgBox(d.ToString)
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        expiration_datetxt.Text = DateTimePicker2.Value.Date.ToString("MM/dd/yyyy")
    End Sub

    Private Sub AddForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class