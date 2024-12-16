Public Class baglantisorgu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim connectionString As String = "Server=localhost;Database=mydatabase;User Id=root;"

            Using connection As New MySql.Data.MySqlClient.MySqlConnection(connectionString)
                connection.Open()
                Label1.Text = "Bağlantı başarılı!"
            End Using
        Catch ex As Exception
            Label1.Text = "Bağlantı başarısız: " & ex.Message
        End Try
    End Sub
End Class