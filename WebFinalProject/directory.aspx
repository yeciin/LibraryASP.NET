﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="directory.aspx.cs" Inherits="WebFinalProject.directory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar">
            <asp:Button ID="Button1" runat="server" Text="Log Out" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Books" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="Staff" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Text="Customers" OnClick="Button4_Click" />
        </div>
    </form>
</body>
</html>