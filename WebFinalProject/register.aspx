<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebFinalProject.register" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="styles/stylereg.css">
</head>
<body>
    <form id="form1" runat="server">
        <img id="background-image" src="images/login.png" alt="Background Image" />
        <div class = "reg-container">
            <asp:TextBox ID="TextBox1" runat="server"  placeholder="First Name"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server"  placeholder="Last Name"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server"  placeholder="Email" TextMode="Email"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server"  placeholder="Phone Number" TextMode="Phone"></asp:TextBox>
            <asp:TextBox ID="TextBox5" runat="server"  placeholder="Address"></asp:TextBox>
            <asp:TextBox ID="TextBox6" runat="server"  placeholder="Password" TextMode="Password"></asp:TextBox>
            <asp:TextBox ID="TextBox7" runat="server"  placeholder="Reenter Password" TextMode="Password"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click"/>
            <asp:Label ID="Label1" runat="server" Text="hello" AutoPostBack="true"></asp:Label>
        </div>
    </form>
</body>
</html>
