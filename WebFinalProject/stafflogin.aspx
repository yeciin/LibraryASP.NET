<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stafflogin.aspx.cs"
Inherits="WebFinalProject.stafflogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <link rel="stylesheet" href="styles/stylestaff.css" />
    <title>Staff Login</title>
  </head>
  <body>
    <form id="form1" runat="server">
      <div class="login">
        <asp:TextBox
          ID="TextBox1"
          runat="server"
          placeholder="Email"
          TextMode="Email"
        ></asp:TextBox>
        <asp:TextBox
          ID="TextBox2"
          runat="server"
          placeholder="Password"
          TextMode="Password"
        ></asp:TextBox>
        <asp:Button
          ID="Button1"
          runat="server"
          Text="Log in"
          OnClick="Button1_Click"
        />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
      </div>
    </form>
  </body>
</html>
