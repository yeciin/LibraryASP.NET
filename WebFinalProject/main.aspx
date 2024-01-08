<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs"
Inherits="WebFinalProject.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title></title>
    <link rel="stylesheet" href="styles/stylemain.css" />
  </head>
  <body>
    <form id="form1" runat="server">
      <div class="topnav">
        <asp:HyperLink
          ID="hlHome"
          CssClass="active"
          NavigateUrl="#home"
          runat="server"
          >Home</asp:HyperLink
        >
        <asp:HyperLink ID="hlAbout" NavigateUrl="#about" runat="server"
          >About</asp:HyperLink
        >
        <asp:HyperLink ID="hlContact" NavigateUrl="#contact" runat="server"
          >Contact</asp:HyperLink
        >
        <div class="search-container">
            <asp:TextBox ID="txtSearch" runat="server" placeholder="Search.."></asp:TextBox>
          <asp:Button
            ID="btnSearch"
            runat="server"
            CssClass="search-btn"
            Text="Search"
            OnClick="btnSearch_Click"
          />
        </div>
        </div>
        <div class="book-container">
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
      </div>
    </form>
  </body>
</html>