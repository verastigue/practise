Imports MySql.Data.MySqlClient

Module Database
    Private conn As New MySqlConnection
    Private cmd As New MySqlCommand

    Sub openConn()
        Try
            conn.ConnectionString = "server=localhost;user=root;password=;database=practise_schema"
            conn.Open()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Sub closeConn()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Sub create(sql As String)
        Try
            openConn()
            cmd = New MySqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Successfuly created!")
        Catch ex As Exception
            MessageBox.Show("Error inserting Data: " & ex.Message)
        Finally
            closeConn()
        End Try
    End Sub

    Function read(sql As String) As DataTable
        Dim dataTable As New DataTable()
        Try
            openConn()
            cmd = New MySqlCommand(sql, conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            adapter.Fill(dataTable)
        Catch ex As Exception
            Console.WriteLine("Error reading data: " & ex.ToString)
        Finally
            closeConn()
        End Try
        Return dataTable
    End Function

    Sub update(sql As String)
        Try
            openConn()
            cmd = New MySqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Successfully Updated!")
        Catch ex As Exception
            Console.WriteLine("Error updating data: " & ex.ToString)
        Finally
            closeConn()
        End Try
    End Sub

    Sub delete(sql As String)
        Try
            openConn()
            cmd = New MySqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Successfully Deleted!")
        Catch ex As Exception
            Console.WriteLine("Error deleting data: " & ex.ToString)
        Finally
            closeConn()
        End Try
    End Sub
End Module
