Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Public Class registerform
    Inherits System.Web.UI.Page
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim name As String = TextBox1.Text
        Dim surname As String = TextBox2.Text
        Dim username As String = TextBox3.Text
        Dim password As String = TextBox4.Text
        Dim connectionString As String = "Server=localhost;Database=mydatabase;User Id=root;"
        Dim enc As Encoding = Encoding.GetEncoding("iso-8859-9")
        Dim kaynakByte() As Byte = enc.GetBytes(password)
        Dim md5 As New MD5CryptoServiceProvider
        Dim byteHosh() As Byte = md5.ComputeHash(kaynakByte)
        Dim sifremd5 As New StringBuilder
        Dim sonucbyte As Byte
        For Each sonucbyte In byteHosh
            sifremd5.Append(sonucbyte.ToString("x2").ToUpper)
        Next
        Dim guvenlisifre As String
        guvenlisifre = sifremd5.ToString
        Try
            Using connection As New MySql.Data.MySqlClient.MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "INSERT INTO users (username, name, surname, password) VALUES (@Username, @Name, @Surname, @Password)"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@name", name)
                    cmd.Parameters.AddWithValue("@surname", surname)
                    cmd.Parameters.AddWithValue("@password", guvenlisifre)

                    cmd.ExecuteNonQuery()
                    Response.Redirect("loginform.aspx")
                    Label1.Text = "Kayıt Başarılı!"
                End Using
            End Using
        Catch ex As Exception
            ' Hata mesajı
            Label1.Text = "Kayıt başarısız: " & ex.Message
            Label1.ForeColor = System.Drawing.Color.Red
        End Try
    End Sub
End Class