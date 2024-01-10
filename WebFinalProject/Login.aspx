<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFinalProject.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="styles/stylelogin.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="logo">
        <img src="images/logo.png" alt="logo" >
    </div>
        <div>
            <div class="form">
            <asp:Label ID="Label1" runat="server" Text="" Cssclass="label"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" TextMode="Email" placeholder="Enter your Email"  CssClass="box"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="Enter your password" CssClass="box"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Log In" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="New Here?" OnClick="Button2_Click"  />
        </div>
            <asp:Button ID="Button3" runat="server" Text="staff" OnClick="Button3_Click" CssClass="staffbutton"/>
        </div>
    </form>
</body>
</html>
