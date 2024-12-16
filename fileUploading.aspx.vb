Public Class fileUploading
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        If FileUpload1.HasFile Then
            Try
                Dim yol As String = FileUpload1.FileName
                Dim dosya As String = System.IO.Path.GetFileName(yol)
                Dim post_dosya As HttpPostedFile
                post_dosya = FileUpload1.PostedFile
                post_dosya.SaveAs(Server.MapPath("resimler/") & dosya)
                Label1.Text = dosya
                Label2.Text = post_dosya.ContentType
                Label3.Text = post_dosya.ContentLength.ToString()
                Image1.ImageUrl = "resimler/" & dosya
            Catch ex As Exception
                Label1.Text = "Bağlantı başarısız: " & ex.Message
            End Try
            Dim tarih As DateTime
            tarih = DateTime.Now
            Response.Write(tarih)
        Else
            Label1.Text = "Lütfen dosya seçiniz."
        End If
    End Sub
End Class