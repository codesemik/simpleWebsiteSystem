<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="datacolumn.aspx.vb" Inherits="mywebsite.datacolumn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            Üye listesini görmek için
            <asp:LinkButton ID="LinkButton1" runat="server">tıklayınız</asp:LinkButton>
            ..<br />
            <asp:Button ID="Button1" runat="server" Text="Kaydet" />
        </div>
    </form>
</body>
</html>
