<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillRetrieve.aspx.cs" Inherits="Assignment2.BillRetrieve" %>

<%--<form id="form1" runat="server">
  Enter Last 'N' Number of Bills To Generate:
  <asp:TextBox ID="txtN" runat="server" Text="2" />
  <asp:Button ID="btnGet" runat="server" Text="Get" OnClick="btnGet_Click" />
  <br /><br />
  <asp:GridView ID="gv" runat="server" AutoGenerateColumns="true" />
</form>--%>
 
 
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Retrieve Bills</title>
    <link href="Content/styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Retrieve Last N Bills</h2>
            
            <asp:Label runat="server" Text="Enter N"></asp:Label>
            <asp:TextBox ID="txtN" runat="server" TextMode="Number"></asp:TextBox>
            
            <asp:Button ID="btnRetrieve" runat="server" Text="Get Bills" OnClick="btnRetrieve_Click" />
            
            <div class="result-box">
                <asp:Literal ID="litBills" runat="server"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>
 