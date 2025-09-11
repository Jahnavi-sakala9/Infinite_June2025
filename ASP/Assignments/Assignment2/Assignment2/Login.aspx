<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment2.Login" %>

<%--<!DOCTYPE html>

<html>
<head runat="server">
    <title>Admin Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Admin Login</h2>
        <p>Username: <asp:TextBox ID="txtUser" runat="server" /></p>
        <p>Password: <asp:TextBox ID="txtPass" runat="server" TextMode="Password" /></p>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <br /><br />
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
    </form>
</body>
</html>--%>
 
 
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Admin Login</title>
    <link href="Content/styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Admin Login</h2>
            <asp:Label runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
 
            <asp:Label runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
 
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
 