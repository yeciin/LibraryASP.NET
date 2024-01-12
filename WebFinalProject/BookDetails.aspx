<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="WebFinalProject.BookDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="styles/stylemain.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="topnav">
            <div class="left">
              <img src="images/logo2.png" alt="" class="logo"/>
            </div>
            <div class="links" style="margin-left: -29px;">
            <asp:HyperLink
                ID="hlHome"
                CssClass="active"
                NavigateUrl="main.aspx"
                runat="server"
                >Home</asp:HyperLink
              >
              <asp:HyperLink ID="hlAbout" NavigateUrl="#about" runat="server" CssClass="active"
                >About</asp:HyperLink
              >
              <asp:HyperLink ID="hlContact" NavigateUrl="#contact" runat="server" CssClass="active"
                >Contact</asp:HyperLink
              >
            </div>
    
            <div class="search-container">
            </div>
            <div class="right" style="margin-right: -30px;">
            <asp:Button
              ID="Button1"
              runat="server"
              Text="Log Out"
              OnClick="Button1_Click"
            />
          </div>
          </div>
        <div>
            <asp:Image ID="Cover" runat="server" />
            <asp:Label ID="Title" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Author" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Publisher" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Year" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Genre" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Copies" runat="server" Text="Label"></asp:Label>
        </div>
    </form>
</body>
</html>
