<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFinalProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="styles/stylelogin.css" />
</head>
<body>
    <form id="form1" runat="server">
    <img id="background-image" src="/images/login.png" alt="Background Image" />
    <img src="/images/logo.png" alt="logo" id="logo-image" />
        <div>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Email" placeholder="Enter your Email"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Log In" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="New Here?" OnClick="Button2_Click" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
