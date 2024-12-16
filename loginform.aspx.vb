Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Public Class loginform
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Label1.Text = kodOlustur()
        End If
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text
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
                Dim query As String = "Select * from users where username = @username And password = @password"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", guvenlisifre)
                    Using reading As MySqlDataReader = cmd.ExecuteReader()
                        If Label1.Text = TextBox3.Text Then
                            If reading.Read() Then
                                Session.Add("Kullanici", username)
                                Response.Redirect("baglantisorgu.aspx")
                            Else
                                Label2.Text = "Kullanici adı veya şifre hatalı!"
                            End If
                        Else
                            Label2.Text = "Güvenlik kodu yanlış girildi!"
                        End If
                    End Using
                End Using
                End Using
        Catch ex As Exception

        End Try
    End Sub
    Private Function kodOlustur() As String
        Dim sayilar() As String = {"K", "2", "3", "4", "5", "L", "7", "8", "9"}
        Dim random As New Random
        Dim e1 As String = sayilar(random.Next(0, 9))
        Dim e2 As String = sayilar(random.Next(0, 9))
        Dim e3 As String = sayilar(random.Next(0, 9))
        Dim e4 As String = sayilar(random.Next(0, 9))
        Dim e5 As String = sayilar(random.Next(0, 9))
        Dim e6 As String = sayilar(random.Next(0, 9))
        Return e1 + e2 + e3 + e4 + e5 + e6
    End Function
End Class