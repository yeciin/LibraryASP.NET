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
          <asp:TextBox
            ID="txtSearch"
            runat="server"
            placeholder="Search.."
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
        <asp:Button
          ID="Button1"
          runat="server"
          Text="Log Out"
          OnClick="Button1_Click"
        />
      </div>
      <div class="book-container bookrepeater">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="flex-item">
                    <asp:Image
                        ID="BookImage"
                        runat="server"
                        ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("cover")) %>'
                    />
                    <h3><%# Eval("title") %></h3>
                    <p>Author: <%# Eval("author") %></p>
                    <p>Genre: <%# Eval("genre") %></p>
                    <p>Available Copies: <%# Eval("copies_available") %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    
    </form>
  </body>
</html>
