<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs"
Inherits="WebFinalProject.BookDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title></title>
    <link rel="stylesheet" href="styles/stylemain.css" />
    <link rel="stylesheet" href="styles/stylebookdetails.css" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link
      href="https://fonts.googleapis.com/css2?family=Barlow:ital,wght@1,800&display=swap"
      rel="stylesheet"
    />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link
      href="https://fonts.googleapis.com/css2?family=Barlow&display=swap"
      rel="stylesheet"
    />
  </head>
  <body>
    <form id="form1" runat="server">
      <div class="topnav">
        <div class="left">
          <img src="images/logo2.png" alt="" class="logo" />
        </div>
        <div class="links">
          <asp:HyperLink
            ID="hlHome"
            CssClass="active"
            NavigateUrl="main.aspx"
            runat="server"
            >Home</asp:HyperLink
          >
          <asp:HyperLink
            ID="hlAbout"
            NavigateUrl="#about"
            runat="server"
            CssClass="active"
            >About</asp:HyperLink
          >
          <asp:HyperLink
            ID="hlContact"
            NavigateUrl="#contact"
            runat="server"
            CssClass="active"
            >Contact</asp:HyperLink
          >
        </div>
        <div class="emptydiv"></div>
        <div class="search-container"></div>
        <div class="right">
          <asp:Button
            ID="Button1"
            runat="server"
            Text="Log Out"
            OnClick="Button1_Click"
          />
        </div>
      </div>
      <div class="body-container">
        <div class="bookdetail">
          <div class="imgdiv">
            <asp:Image ID="Cover" runat="server" />
          </div>
          <div class="detaildiv">
            <asp:Label
              ID="BTitle"
              runat="server"
              Text="Label"
              Cssclass="booktitle"
            ></asp:Label>
            <asp:Label
              ID="Author"
              runat="server"
              Text="Label"
              Cssclass="bookauthor"
            ></asp:Label>
            <asp:Label
              ID="Publisher"
              runat="server"
              Text="Label"
              Cssclass="bookpublisher"
            ></asp:Label>
            <asp:Label
              ID="Year"
              runat="server"
              Text="Label"
              Cssclass="bookyear"
            ></asp:Label>
            <asp:Label
              ID="Genre"
              runat="server"
              Text="Label"
              Cssclass="bookgenre"
            ></asp:Label>
            <asp:Label
              ID="Copies"
              runat="server"
              Text="Label"
              Cssclass="bookcopies"
            ></asp:Label>
          </div>
        </div>
        <div class="quote">
          <asp:Label
            ID="quoteoftheday"
            runat="server"
            Text=""
            Cssclass="qotd"
          ></asp:Label>
        </div>
      </div>
    </form>
  </body>
</html>
