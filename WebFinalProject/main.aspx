﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs"
EnableViewState="true" Inherits="WebFinalProject.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title></title>
    <link rel="stylesheet" href="styles/stylemain.css" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link
      href="https://fonts.googleapis.com/css2?family=Barlow&display=swap"
      rel="stylesheet"
    />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/purchasemenu.js"></script>
    <script type="text/javascript">
      function redirectToBookDetails(bookId) {
        window.location.href = "BookDetails.aspx?bookId=" + bookId;
      }
    </script>
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

        <div class="search-container">
          <asp:TextBox
            ID="txtSearch"
            runat="server"
            placeholder="Search.."
            CssClass="search"
          ></asp:TextBox>
          <asp:Button
            ID="btnSearch"
            runat="server"
            CssClass="search-btn"
            Text="Search"
            OnClick="btnSearch_Click"
          >
          </asp:Button>
        </div>
        <div class="right">
          <asp:Button
            ID="Button1"
            runat="server"
            Text="Log Out"
            OnClick="Button1_Click"
          />
        </div>
      </div>
      <div class="sortdiv">
        <asp:Label ID="Label1" runat="server" Text="Sort By:"></asp:Label>
        <asp:DropDownList
          ID="DropDownList1"
          runat="server"
          AutoPostBack="true"
          OnSelectedIndexChanged="SelectedIndexChanged"
          Cssclass="search"
        >
          <asp:ListItem Text="Author" Value="author" />
          <asp:ListItem Text="Genre" Value="genre" />
          <asp:ListItem Text="Publication Year" Value="year" />
          <asp:ListItem Text="Copies Available" Value="availablecopies" />
        </asp:DropDownList>
      </div>
      <div class="book-container bookrepeater">
        <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
            <div class="flex-item clickable">
              <asp:Image
                ID="BookImage"
                runat="server"
                CssClass="coverimage"
                ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("cover")) %>'
              />
              <h3><%# Eval("title") %></h3>
              <p>Author: <%# Eval("author") %></p>
              <p>Genre: <%# Eval("genre") %></p>
              <p>Available Copies: <%# Eval("copies_available") %></p>
              <asp:Button
                ID="btnPurchase"
                runat="server"
                CssClass="purchase-button"
                Text="Borrow"
                OnClientClick='<%# Eval("book_id", "redirectToBookDetails({0}); return false;") %>'
              />
            </div>
          </ItemTemplate>
        </asp:Repeater>
      </div>
    </form>
  </body>
</html>
