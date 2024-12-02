Imports MySql.Data.MySqlClient

Public Class Connection

    Dim conn As New MySqlConnection
    Dim connstring As String = "Server=localhost; User Id=root;Password=;Database=vbnetdb"

    Public Sub connect()
        conn.ConnectionString = connstring
        If (conn.State = ConnectionState.Closed) Then
            conn.Open()
        End If
    End Sub

    Public Sub close()
        If conn.State = ConnectionState.Open Then
            conn.Close()
            conn.dispose()
        End If
    End Sub

    Public Function login(ByVal searchstring As String)
        Dim comm As MySqlCommand
        Dim reader As MySqlDataReader

        connect()
        comm = New MySqlCommand(searchstring, conn)
        reader = comm.ExecuteReader

        Dim check As Integer

        While (reader.Read)
            check = check + 1
        End While

        If check = 1 Then
            Return True
        ElseIf check > 1 Then
            MsgBox("Multiple Accounts Detected")
            Return False
        ElseIf check < 1 Then
            MsgBox("No Account")
            Return False
        Else
            MsgBox("Error")
            Return False
        End If

        close()
    End Function

    Public Function changepassword(ByVal updatequery As String, ByVal type As String, ByVal name As String)
        connect()

        Dim comm As New MySqlCommand
        Dim reader As MySqlDataReader
        Dim checkstring As String

        If type = "Owner" Then
            checkstring = "SELECT * FROM ownertbl WHERE name = '" & name & "'"
            comm = New MySqlCommand(checkstring, conn)
        ElseIf type = "Employee" Then
            checkstring = "SELECT * FROM employeetbl WHERE name = '" & name & "'"
            comm = New MySqlCommand(checkstring, conn)
        End If

        reader = comm.ExecuteReader

        Dim check As Integer

        While (reader.Read)
            check = check + 1
        End While

        close()
        connect()

        If check = 1 Then
            With comm
                .CommandType = CommandType.Text
                .CommandText = updatequery
                .Connection = conn
                .ExecuteNonQuery()
            End With

            MsgBox("Updated")
            Return True
        ElseIf check > 1 Then
            MsgBox("Multiple Accounts Detected")
            Return False
        ElseIf check < 1 Then
            MsgBox("No Account")
            Return False
        Else
            MsgBox("Error")
            Return False
        End If
        close()
    End Function

    Public Sub listemployeeid()
        connect()

        Dim comm As MySqlCommand
        Dim reader As MySqlDataReader
        Dim searchid As String = "SELECT id FROM employeetbl"
        comm = New MySqlCommand(searchid, conn)
        reader = comm.ExecuteReader
        Employee.cboemployeeid.Items.Clear()
        While reader.Read
            Employee.cboemployeeid.Items.Add(reader("id"))
        End While

        close()
    End Sub

    Public Sub refreshemployeedata(ByVal id As Integer)
        connect()

        Dim comm As MySqlCommand
        Dim reader As MySqlDataReader
        Dim searchid As String = "SELECT * FROM employeetbl WHERE id = " & id
        comm = New MySqlCommand(searchid, conn)
        reader = comm.ExecuteReader

        While reader.Read
            Employee.employeename.Text = reader("name").ToString
            Employee.employeeaddress.Text = reader("address").ToString
            Employee.employeemobilephone.Text = reader("mobilephone").ToString
            Employee.employeehomephone.Text = reader("homephone").ToString
            Employee.employeepassword.Text = reader("password").ToString
        End While

        close()

    End Sub

    Public Sub addemployee(ByVal name As String, ByVal address As String, ByVal mobilephone As String, ByVal homephone As String, ByVal password As String)
        connect()

        Dim comm As New MySqlCommand
        Dim addquery As String = "INSERT INTO `employeetbl`(`name`, `address`, `mobilephone`, `homephone`, `password`) VALUES ('" & name & "','" & address & "','" & mobilephone & "','" & homephone & "','" & password & "')"
        With comm
            .Connection = conn
            .CommandText = addquery
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
        End With
        MsgBox("Added Successfully")

        close()

        listemployeeid()
    End Sub

    Public Sub updateemployee(ByVal id As Integer, ByVal name As String, ByVal address As String, ByVal mobilephone As String, ByVal homephone As String, ByVal password As String)
        connect()

        Dim comm As New MySqlCommand
        Dim updatequery As String = "UPDATE employeetbl SET name='" & name & "',address='" & address & "',mobilephone='" & mobilephone & "',homephone='" & homephone & "',password='" & password & "' WHERE id = " & id
        With comm
            .Connection = conn
            .CommandText = updatequery
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
        End With
        MsgBox("Updated Successfully")

        close()

        listemployeeid()
    End Sub

    Public Sub deleteemployee(ByVal id As Integer)
        connect()
        Select Case (MsgBox("Are you sure", vbYesNo, "Delete?"))
            Case vbYes : Dim comm As New MySqlCommand
                Dim updatequery As String = "DELETE FROM employeetbl WHERE id = " & id
                With comm
                    .Connection = conn
                    .CommandText = updatequery
                    .CommandType = CommandType.Text
                    .ExecuteNonQuery()
                End With
                MsgBox("Deleted Successfully")
            Case Else
        End Select


        close()

        listemployeeid()

    End Sub

    Public Sub stocmainload()
        connect()

        Dim comm As MySqlCommand
        Dim reader As MySqlDataReader
        Dim loadquery As String = "SELECT name FROM mainitemtbl"

        comm = New MySqlCommand(loadquery, conn)
        reader = comm.ExecuteReader
        Stock.mainlist.Items.Clear()
        While reader.Read
            Stock.mainlist.Items.Add(reader("name"))
        End While

        close()
    End Sub

    Public Sub stockmainselected(ByVal mainitem As String)
        connect()

        Dim comm As MySqlCommand
        Dim reader As MySqlDataReader
        Dim loadquery As String = "SELECT name FROM subitemtbl WHERE mainitembelonged = '" & mainitem & "'"

        comm = New MySqlCommand(loadquery, conn)
        reader = comm.ExecuteReader
        Stock.sublist.Items.Clear()
        While reader.Read
            Stock.sublist.Items.Add(reader("name"))
        End While

        close()
    End Sub

    Public Sub stocksubselected(ByVal subitem As String)
        connect()

        Dim comm As MySqlCommand
        Dim reader As MySqlDataReader
        Dim loadquery As String = "SELECT name FROM actualitemtbl WHERE subitembelonged = '" & subitem & "'"

        comm = New MySqlCommand(loadquery, conn)
        reader = comm.ExecuteReader
        Stock.actuallist.Items.Clear()
        While reader.Read
            Stock.actuallist.Items.Add(reader("name"))
        End While

        close()
    End Sub

    Public Sub stockactualselected(ByVal actualitem As String)
        connect()

        Dim comm As MySqlCommand
        Dim reader As MySqlDataReader
        Dim loadquery As String = "SELECT actualitemid,name,quantity,unitprice FROM actualitemtbl WHERE name = '" & actualitem & "'"

        comm = New MySqlCommand(loadquery, conn)
        reader = comm.ExecuteReader
        While reader.Read
            Stock.TextBox2.Text = reader("actualitemid").ToString
            Stock.itemname.Text = reader("name").ToString
            Stock.TextBox1.Text = reader("name").ToString
            Stock.quantity.Text = reader("quantity").ToString
            Stock.unitprice.Text = reader("unitprice").ToString
        End While
        Stock.totalprice.Text = CInt(Stock.quantity.Text) * CInt(Stock.unitprice.Text)

        close()
    End Sub

    Public Sub stockadditem(ByVal itemname As String, ByVal itemtype As String, ByVal itembelonged As String)
        connect()

        If itemtype.Equals("main") Then
            Dim comm As New MySqlCommand
            Dim addquery As String = "INSERT INTO mainitemtbl(name) VALUES ('" & itemname & "')"
            With comm
                .Connection = conn
                .CommandText = addquery
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
            MsgBox("Added Successfully")
        ElseIf itemtype.Equals("sub") Then
            Dim comm As New MySqlCommand
            Dim addquery As String = "INSERT INTO subitemtbl(name,mainitembelonged) VALUES ('" & itemname & "','" & itembelonged & "')"
            With comm
                .Connection = conn
                .CommandText = addquery
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
            MsgBox("Added Successfully")
        End If
        close()

    End Sub

    Public Sub stockaddactual(ByVal itemname As String, ByVal itembelonged As String, ByVal quantity As Integer, ByVal unitprice As Integer)
        connect()


        Dim comm As New MySqlCommand
        Dim addquery As String = "INSERT INTO actualitemtbl(name,subitembelonged,quantity,unitprice) VALUES ('" & itemname & "','" & itembelonged & "','" & quantity & "','" & unitprice & "')"
        With comm
            .Connection = conn
            .CommandText = addquery
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
        End With
        MsgBox("Added Successfully")
        
        close()

    End Sub

    Public Sub stockupdateactual(ByVal olditemname As String, ByVal newitemname As String, ByVal quantity As Integer, ByVal unitprice As Integer)
        connect()


        Dim comm As New MySqlCommand
        Dim addquery As String = "UPDATE actualitemtbl SET name='" & newitemname & "',quantity=" & quantity & ",unitprice=" & unitprice & " WHERE name = '" & olditemname & "'"
        With comm
            .Connection = conn
            .CommandText = addquery
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
        End With
        MsgBox("Updated Successfully")

        close()
    End Sub

    Public Sub removeactualitem(ByVal id As Integer)
        connect()


        Dim comm As New MySqlCommand
        Dim deletequery As String = "DELETE FROM actualitemtbl WHERE actualitemid = " & id & ""
        With comm
            .Connection = conn
            .CommandText = deletequery
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
        End With
        MsgBox("Removed Successfully")

        close()
    End Sub

    Public Sub removesubitem(ByVal name As String, ByVal mainitembelonged As String)
        connect()


        Dim comm As New MySqlCommand
        Dim deletequery As String = "DELETE FROM subitemtbl WHERE name = '" & name & "' AND mainitembelonged = '" & mainitembelonged & "'; DELETE FROM actualitemtbl WHERE subitembelonged = '" & name & "'"
        With comm
            .Connection = conn
            .CommandText = deletequery
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
        End With
        MsgBox("Removed Successfully")

        close()
    End Sub

    Public Sub removemainitem(ByVal mainitem As String)


        Dim comm As New MySqlCommand
        'Dim reader As MySqlDataReader
        ' With comm
        '.Connection = conn
        '.CommandText = "SELECT * FROM actualitemtbl LEFT JOIN subitemtbl ON actualitemtbl.subitembelonged = subitemtbl.name LEFT JOIN mainitemtbl ON subitemtbl.mainitembelonged = mainitemtbl.name WHERE mainitemtbl.name = '" & mainitem & "'"
        'End With
        'connect()
        'reader = comm.ExecuteReader

        'While reader.Read
        'Dim deletequery As String = "DELETE FROM subitemtbl WHERE subitemid = " & reader("subitemid").ToString & "; DELETE FROM actualitemtbl WHERE subitembelonged = '" & reader("subitemtbl.name") & "'"
        'With comm
        '.Connection = conn
        '.CommandText = deletequery
        '.CommandType = CommandType.Text
        '.ExecuteNonQuery()
        ' End With
        'MsgBox(reader("subitemid").ToString)
        'End While
        'close()
        connect()
        With comm
            .Connection = conn
            .CommandText = "DELETE FROM mainitemtbl WHERE name = '" & mainitem & "'"
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
        End With

        MsgBox("Removed")
        close()


    End Sub

    Public Sub loaditem()
        connect()

        Dim comm As New MySqlCommand
        Dim reader As MySqlDataReader
        Dim loaditemquery As String
        loaditemquery = "SELECT * FROM actualitemtbl"

        comm.Connection = conn
        comm.CommandText = loaditemquery
        reader = comm.ExecuteReader

        While reader.Read
            'SalePoint.spselectitemcbo.DataSource = reader("name")
            SalePoint.spselectitemcbo.Items.Add(reader("name").ToString)
        End While

        close()
    End Sub

    Public Sub selectsitem(ByVal name As String)
        connect()

        Dim comm As New MySqlCommand
        Dim reader As MySqlDataReader
        Dim loaditemquery As String
        loaditemquery = "SELECT * FROM actualitemtbl WHERE name = '" & name & "'"

        comm.Connection = conn
        comm.CommandText = loaditemquery
        reader = comm.ExecuteReader

        reader.Read()
        SalePoint.spquantityavailablelbl.Text = reader("quantity")
        SalePoint.spunitpricelbl.Text = reader("unitprice")

        close()
    End Sub

    Public Sub deductitem(ByVal itemname As String, ByVal quantitypurchased As Integer, ByVal datetime As String)
        connect()

        Dim comm As New MySqlCommand
        Dim reader As MySqlDataReader
        Dim availablequantity As Integer
        Dim newavailablequantity As Integer
        comm.Connection = conn
        comm.CommandText = "SELECT quantity FROM actualitemtbl WHERE name = '" & itemname & "'"
        reader = comm.ExecuteReader
        reader.Read()
        availablequantity = reader("quantity")

        close()
        connect()

        'MsgBox(reader("quantity").ToString)
        newavailablequantity = availablequantity - quantitypurchased

        comm.CommandText = "UPDATE actualitemtbl SET quantity = " & newavailablequantity & " WHERE name = '" & itemname & "'"
        comm.ExecuteNonQuery()

        close()

        connect()

        comm.CommandText = "INSERT INTO itempurchasestbl VALUES('" & itemname & "'," & quantitypurchased & ",STR_TO_DATE('" & DateTime & "','%m/%d/%Y'))"
        comm.ExecuteNonQuery()

        close()
    End Sub


    Public Sub customerpurchases(ByVal customername As String, ByVal discountexpense As Integer, ByVal amountpaid As Integer, ByVal datetime As String)
        connect()

        Dim comm As New MySqlCommand
        comm.Connection = conn
        comm.CommandText = "INSERT INTO customerpurchasestbl VALUES('" & customername & "'," & discountexpense & "," & amountpaid & ",STR_TO_DATE('" & datetime & "','%m/%d/%Y'))"
        comm.ExecuteNonQuery()

        close()
    End Sub


    Public Sub loadpurchasesreport(ByVal datetime As String)
        connect()

        Dim comm As New MySqlCommand
        'Dim adapter As New MySqlDataAdapter
        'Dim datatable As New DataTable
        Dim reader As MySqlDataReader
        comm.Connection = conn
        comm.CommandText = "SELECT * FROM customerpurchasestbl WHERE datetime LIKE '" & datetime & "%'"
        'adapter.SelectCommand = comm
        'adapter.Fill(datatable)
        'Report.purchasesreportgridview.DataSource = datatable
        reader = comm.ExecuteReader
        Report.purchasesreportgridview.Rows.Clear()

        Dim totaldiscount As Double
        Dim totalamount As Double
        While reader.Read
            Report.purchasesreportgridview.Rows.Add(reader("customername").ToString, reader("discountexpense").ToString, reader("amountpaid").ToString)
            totaldiscount = totaldiscount + CDbl(reader("discountexpense"))
            totalamount = totalamount + CDbl(reader("amountpaid"))
        End While
        Report.totalamountpaid.Text = totalamount
        Report.totaldiscountexpense.Text = totaldiscount

        close()
    End Sub


    Public Sub loadproductreport(ByVal datetime As String)
        connect()

        Dim comm As New MySqlCommand
        'Dim adapter As New MySqlDataAdapter
        'Dim datatable As New DataTable
        Dim reader As MySqlDataReader
        comm.Connection = conn
        comm.CommandText = "SELECT * FROM itempurchasestbl WHERE datetime LIKE '" & datetime & "%'"
        'adapter.SelectCommand = comm
        'adapter.Fill(datatable)
        'Report.purchasesreportgridview.DataSource = datatable
        reader = comm.ExecuteReader
        Report.productreportgridview.Rows.Clear()

        While reader.Read
            Report.productreportgridview.Rows.Add(reader("itemname").ToString, reader("quantity").ToString)
        End While
        close()

        connect()
        comm.Connection = conn
        comm.CommandText = "SELECT itemname,SUM(quantity),datetime FROM `itempurchasestbl` WHERE datetime LIKE '" & datetime & "%' GROUP BY datetime, itemname"
        reader = comm.ExecuteReader

        Report.productreportsumgridview.Rows.Clear()
        While reader.Read
            Report.productreportsumgridview.Rows.Add(reader("itemname").ToString, reader("SUM(quantity)").ToString)
        End While


        close()
    End Sub


    Public Sub loademployee()
        connect()

        Dim comm As New MySqlCommand
        Dim loadquery As String = "SELECT * FROM employeetbl"
        Dim reader As MySqlDataReader
        comm.Connection = conn
        comm.CommandText = loadquery
        Employee.DataGridView1.Rows.Clear()
        reader = comm.ExecuteReader
        While reader.Read
            Employee.DataGridView1.Rows.Add(reader("id"), reader("name"), reader("address"), reader("mobilephone"), reader("homephone"), reader("password"))
        End While

        close()
    End Sub
End Class
