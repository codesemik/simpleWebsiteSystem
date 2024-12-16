<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="mydata.aspx.vb" Inherits="mywebsite.mydata" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Üye listesini görmek için
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="False">tıklayınız</asp:LinkButton>
        ..<br />
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Excel'e Aktar" />
        <div>
        </div>
    </form>
</body>
</html>
