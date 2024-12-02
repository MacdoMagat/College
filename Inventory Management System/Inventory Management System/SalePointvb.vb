Public Class SalePoint

    Private Sub SalePoint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim conn As New Connection
        conn.loaditem()
    End Sub

    Private Sub spselectitemcbo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spselectitemcbo.SelectedIndexChanged
        Dim name As String = spselectitemcbo.SelectedItem.ToString
        Dim conn As New Connection
        conn.selectsitem(name)
        spquantitypurchasedtxt.Text = ""
    End Sub

    Private Sub spaddbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spaddbtn.Click
        On Error GoTo hindinumber

        If spselectitemcbo.Text = "" Then
            MsgBox("Please Choose Item")
        Else

            Dim a As Integer = CInt(spquantitypurchasedtxt.Text)
            If a <= CInt(spquantityavailablelbl.Text) Then
                If a > 0 Then
                    spcart.Rows.Add(spcart.Rows.Count.ToString, spselectitemcbo.Text, spquantitypurchasedtxt.Text, spunitpricelbl.Text, (CInt(spquantitypurchasedtxt.Text) * CInt(spunitpricelbl.Text).ToString))

                    Dim numberofitems As Integer
                    Dim totalprice As Integer
                    Dim counter As Integer = 0
                    While counter < spcart.Rows.Count
                        numberofitems = numberofitems + CInt(spcart.Rows(counter).Cells(2).Value)
                        totalprice = totalprice + CInt(spcart.Rows(counter).Cells(4).Value)
                        counter = counter + 1
                    End While

                    spundiscountedpricetxt.Text = totalprice
                    spnumberofitemstxt.Text = numberofitems
                    spdiscountedpricetxt.Text = totalprice - (totalprice * (CInt(spdiscounttxt.Text) / 100))
                    Label3.Text = spdiscountedpricetxt.Text
                    spquantitypurchasedtxt.Text = ""

                    Dim change As Double
                    change = CInt(spamounttxt.Text) - CDbl(spdiscountedpricetxt.Text)
                    spchangetxt.Text = change

                    spselectitemcbo.Text = ""
                    spunitpricelbl.Text = ""
                    spquantityavailablelbl.Text = ""

                    spselectitemcbo.Items.Clear()
                    Dim conn As New Connection
                    conn.loaditem()

                Else
                    MsgBox("Invalid purchase quantity")
                End If
            Else
                MsgBox("Insufficient stock")
            End If

            End If
            Exit Sub

hindinumber:
            MsgBox("Quantity is not number")



            'spcart.Rows.Add("a", "b", "c", "d", "e")
            'MsgBox(spcart.Rows.Count.ToString)
            'MsgBox(spcart.Rows(0).Cells(4).Value)

    End Sub

    Private Sub spdiscounttxt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spdiscounttxt.TextChanged

        Try
            spdiscountedpricetxt.Text = CInt(spundiscountedpricetxt.Text) - (CInt(spundiscountedpricetxt.Text) * (CInt(spdiscounttxt.Text) / 100))
            Label3.Text = spdiscountedpricetxt.Text

            Dim change As Double
            change = CInt(spamounttxt.Text) - CDbl(spdiscountedpricetxt.Text)
            spchangetxt.Text = change
        Catch
            spdiscounttxt.Text = 0
        End Try
        Exit Sub


    End Sub

    Private Sub spamounttxt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spamounttxt.TextChanged
        On Error GoTo hindinumber
        Dim change As Double

        If spamounttxt.Text.Length = 0 Then
            spamounttxt.Text = "0"
        End If
        If spdiscountedpricetxt.Text.Length = 0 Then
            spdiscountedpricetxt.Text = "0"
        End If

        change = CInt(spamounttxt.Text) - CDbl(spdiscountedpricetxt.Text)
        spchangetxt.Text = change
        Exit Sub
hindinumber:
        MsgBox("Amount is not number")
        spamounttxt.Text = 0

 

    End Sub

    Private Sub spclearbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spclearbtn.Click
        spcart.Rows.Clear()
        spcustomernametxt.Text = ""
        spnumberofitemstxt.Text = ""
        spundiscountedpricetxt.Text = "0"
        spdiscounttxt.Text = "0"
        spdiscountedpricetxt.Text = "0"
        spamounttxt.Text = "0"
        spchangetxt.Text = "0"
        Label3.Text = "0"
    End Sub

    Private Sub spremovebtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spremovebtn.Click
        On Error GoTo walangrow
        spcart.Rows.RemoveAt(spcart.CurrentRow.Index)

        Dim numberofitems As Integer
        Dim totalprice As Integer
        Dim counter As Integer = 0
        While counter < spcart.Rows.Count
            numberofitems = numberofitems + CInt(spcart.Rows(counter).Cells(2).Value)
            totalprice = totalprice + CInt(spcart.Rows(counter).Cells(4).Value)
            counter = counter + 1
        End While

        spundiscountedpricetxt.Text = totalprice
        spnumberofitemstxt.Text = numberofitems
        spdiscountedpricetxt.Text = totalprice - (totalprice * (CInt(spdiscounttxt.Text) / 100))
        Label3.Text = spdiscountedpricetxt.Text


        Dim change As Double
        change = CInt(spamounttxt.Text) - CDbl(spdiscountedpricetxt.Text)
        spchangetxt.Text = change
        Exit Sub
walangrow:
        MsgBox("Please select one row")
    End Sub

    Private Sub spbackbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spbackbtn.Click
        Me.Close()
        Main.Show()
    End Sub

    Private Sub spoutbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spoutbtn.Click
        Main.Close()
        Login.Show()
        Login.type.Text = "None"
        Login.loginname.Text = ""
        Login.loginpassword.Text = ""
        Me.Close()
    End Sub

    Private Sub spprocessbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spprocessbtn.Click

        If spnumberofitemstxt.Text = "0" Then
            MsgBox("Please add an item")
        ElseIf spcustomernametxt.Text = "" Then
            MsgBox("Please enter customer name")
        ElseIf CDbl(spchangetxt.Text) < 0 Then
            MsgBox("Cash Insufficient")
        ElseIf CDbl(spdiscounttxt.Text) >= 100 Or CDbl(spdiscounttxt.Text) < 0 Then
            MsgBox("Please check the discount ratio")
        Else
            Dim conn As New Connection
            Dim counter As Integer = 0
            While counter < spcart.Rows.Count - 1
                conn.deductitem(spcart.Rows(counter).Cells(1).Value, spcart.Rows(counter).Cells(2).Value, Label16.Text)
                counter = counter + 1
            End While


            Dim discountexpense As Double
            discountexpense = CDbl(spundiscountedpricetxt.Text) - CDbl(spdiscountedpricetxt.Text)
            conn.customerpurchases(spcustomernametxt.Text, discountexpense, CInt(spdiscountedpricetxt.Text), Label16.Text)

            spcart.Rows.Clear()
            Label3.Text = ""
            spcustomernametxt.Text = ""
            spnumberofitemstxt.Text = ""
            spundiscountedpricetxt.Text = ""
            spdiscounttxt.Text = ""
            spdiscountedpricetxt.Text = ""
            spamounttxt.Text = ""
            spchangetxt.Text = ""
            spnumberofitemstxt.Text = "0"
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label16.Text = Date.Now.ToString("MM/dd/yyyy")
    End Sub

   
    Private Sub spprintbtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles spprintbtn.Click
    End Sub

End Class