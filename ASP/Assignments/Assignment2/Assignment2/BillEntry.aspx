<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillEntry.aspx.cs" Inherits="Assignment2.BillEntry" %>

<!DOCTYPE html>

<form id="form2" runat="server">
  Number of bills to be added: <asp:TextBox ID="txtCount" runat="server" Text="1" /><br />
  Consumer Number: <asp:TextBox ID="txtCN" runat="server" /><br />
  Consumer Name: <asp:TextBox ID="txtName" runat="server" /><br />
  Units Consumed: <asp:TextBox ID="txtUnits" runat="server" /><br />
  <asp:Button ID="btnAdd" runat="server" Text="Add & Next" OnClick="btnAdd_Click" />
  <asp:Label ID="lblMsg" runat="server" ForeColor="Red" /><br />
  <asp:Label ID="lblOut" runat="server" Font-Bold="true" />
  <hr />
  Go to: <a href="BillRetrieve.aspx">Retrieve last N bills</a>
</form>
