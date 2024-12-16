Imports System.Data
Imports System.Data.OleDb
Imports System.IO

Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Dim yol, sql As String
        yol = Server.MapPath("Database1.accdb")
        sql = "select ad,soyad, k_adi from uyeler"
        Dim baglanti As New OleDbConnection("provider=Microsoft.ACE.OLDEB.12.0;DATA Source=" &
        Dim verial As New OledbDataAdapter(sql, baglanti)
        Dim ds As New DataSet
        Verial.Fiil(ds)
        GridView1.DataSource = ds.Tables
        GridView1.DataBind()
        LinkButton1.Visible = True


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ek As String
        ek = "attachment;filename=uye.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", ek)
        Response.ContentType = "application/ms-excel"
        Dim sw As New StringWriter
        Dim htw As New HtmlTextWriter(sw)
        GridView1.GridLines = GridLines.Both
        GridView1.RenderControl(htw)
        Response.Write(sw.ToString)
        Response.End()
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(control As Control)

    End Sub
End Class