Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Web.UI
Public Class mydata
    Inherits System.Web.UI.Page
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ek As String = "attachment;filename=uye.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", ek)
        Response.ContentType = "application/ms-excel"
        Using sw As New StringWriter()
            Using htw As New HtmlTextWriter(sw)
                GridView1.GridLines = GridLines.Both
                GridView1.RenderControl(htw)
                Response.Write(sw.ToString())
            End Using
        End Using
        Response.End()
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Dim connectionString As String = "Server=localhost;Database=mydatabase;User Id=root;"
        Dim Sql As String = "select ad,soyad, k_adi from users"
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                Using cmd As New MySqlCommand(Sql, connection)
                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim ds As New DataSet()
                        adapter.Fill(ds)
                        GridView1.DataSource = ds.Tables(0)
                        GridView1.DataBind()
                    End Using
                End Using
                LinkButton1.Visible = True
            Catch ex As Exception
                Response.Write("Hata: " & ex.Message)
            End Try
        End Using
    End Sub
End Class