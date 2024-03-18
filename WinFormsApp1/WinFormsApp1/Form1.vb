Public Class Form1

    Dim user As New Users
    Dim userData As DataTable
    Dim allUsersData As DataTable

    Dim stUsername As String
    Dim stPassword As String
    Dim stRole As String

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        stUsername = txt_username.Text.Trim
        stPassword = txt_password.Text.Trim
        stRole = cb_role.SelectedItem

        user.createNewUser(stUsername, stPassword, stRole)
        txt_username.Clear()
        txt_password.Clear()
        cb_role.SelectedItem = -1

        refreshData()
    End Sub

    Private Sub txt_username_TextChanged(sender As Object, e As EventArgs) Handles txt_username.TextChanged
        stUsername = txt_username.Text.Trim
    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        txt_username.Clear()
        txt_password.Clear()
        cb_role.SelectedItem = -1
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        user.updateUserByUsername(stUsername, stPassword, stRole)
        refreshData()
    End Sub

    Private Sub txt_password_TextChanged(sender As Object, e As EventArgs) Handles txt_password.TextChanged
        stPassword = txt_password.Text.Trim
    End Sub

    Private Sub cb_role_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_role.SelectedIndexChanged
        stRole = cb_role.SelectedItem
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        user.deleteUserByUsername(stUsername)
        refreshData()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshData()
    End Sub

    Private Sub dt_users_SelectionChanged(sender As Object, e As EventArgs) Handles dt_users.SelectionChanged
        ' Check if any row is selected
        If dt_users.SelectedRows.Count > 0 Then
            ' Get the selected row
            Dim selectedRow As DataGridViewRow = dt_users.SelectedRows(0)

            ' Populate TextBoxes with data from the selected row
            txt_username.Text = selectedRow.Cells("Username").Value.ToString()
            txt_password.Text = selectedRow.Cells("Password").Value.ToString()
            cb_role.SelectedItem = selectedRow.Cells("Role").Value.ToString()
        End If
    End Sub


    Private Sub refreshData()
        allUsersData = user.readAllUsers()

        allUsersData.Columns.Remove("id")
        dt_users.DataSource = allUsersData

        txt_username.Clear()
        txt_password.Clear()
        cb_role.SelectedItem = -1
    End Sub

    Private Sub txt_search_TextChanged(sender As Object, e As EventArgs) Handles txt_search.TextChanged
        refreshData()
        Dim stSearch As String = txt_search.Text.Trim

        If stSearch IsNot "" Then
            Dim filteredData As New DataTable
            Dim dataView As New DataView(allUsersData)

            dataView.RowFilter = "username LIKE '%" & stSearch & "%' OR password LIKE '%" & stSearch & "%' OR role LIKE '%" & stSearch & "%'"
            filteredData = dataView.ToTable

            dt_users.DataSource = filteredData
        Else
            dt_users.DataSource = allUsersData
        End If
    End Sub

    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        print_preview.Document = print_document
        print_preview.WindowState = FormWindowState.Maximized
        print_preview.ShowDialog()

    End Sub

    Private Sub print_document_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles print_document.PrintPage
        Dim printArea As New Rectangle(0, 0, dt_users.Width, dt_users.Height)

        Dim bitmap As New Bitmap(dt_users.Width, dt_users.Height)
        dt_users.DrawToBitmap(bitmap, printArea)

        e.Graphics.DrawImage(bitmap, 0, 0)
    End Sub
End Class
