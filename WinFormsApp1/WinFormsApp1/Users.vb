Public Class Users

    Private sql As String

    Sub createNewUser(username As String, password As String, role As String)
        Try
            sql = "INSERT INTO tbl_users(username, password, role) VALUES('" & username & "', '" & password & "', '" & role & "')"
            create(sql)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Function readUserByUsername(username As String) As DataTable
        Dim dataTable As New DataTable
        Try
            sql = "SELECT * FROM tbl_users WHERE username = '" & username & "'"
            dataTable = read(sql)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

        Return dataTable
    End Function

    Sub updateUserByUsername(username As String, newPassword As String, newRole As String)
        Try
            sql = "UPDATE tbl_users SET password = '" & newPassword & "', role = '" & newRole & "' WHERE username = '" & username & "'"
            update(sql)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Sub deleteUserByUsername(username As String)
        Try
            sql = "DELETE FROM tbl_users WHERE username = '" & username & "'"
            delete(sql)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Function readAllUsers() As DataTable
        Dim dataTable As New DataTable
        Try
            sql = "SELECT * FROM tbl_users"
            dataTable = read(sql)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

        Return dataTable
    End Function

End Class
