<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillRetrieve.aspx.cs" Inherits="Assignment2.BillRetrieve" %>

<form id="form1" runat="server">
  Enter Last 'N' Number of Bills To Generate:
  <asp:TextBox ID="txtN" runat="server" Text="2" />
  <asp:Button ID="btnGet" runat="server" Text="Get" OnClick="btnGet_Click" />
  <br /><br />
  <asp:GridView ID="gv" runat="server" AutoGenerateColumns="true" />
</form>
 
