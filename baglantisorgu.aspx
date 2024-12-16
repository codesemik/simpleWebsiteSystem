<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="baglantisorgu.aspx.vb" Inherits="mywebsite.baglantisorgu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Baglanti Kontrol" />
            <br />
            Baglantı: <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
