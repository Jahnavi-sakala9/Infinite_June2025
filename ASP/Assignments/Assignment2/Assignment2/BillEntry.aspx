<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillEntry.aspx.cs" Inherits="Assignment2.BillEntry" %>

<%--<!DOCTYPE html>

<form id="form2" runat="server">
  Number of bills to be added: <asp:TextBox ID="txtCount" runat="server" Text="1" /><br />
  Enter Consumer Number: <asp:TextBox ID="txtCN" runat="server" /><br />
  Enter Consumer Name: <asp:TextBox ID="txtName" runat="server" /><br />
  Units Consumed: <asp:TextBox ID="txtUnits" runat="server" /><br />
  <asp:Button ID="btnSave" runat="server" Text="Calculate & Save"
            OnClick="btnSave_Click" UseSubmitBehavior="false" />
  <asp:Label ID="lblMsg" runat="server" ForeColor="Red" /><br />
  <asp:Label ID="lblOut" runat="server" Font-Bold="true" />
  <hr />
  Go to: <a href="BillRetrieve.aspx">Retrieve last N bills</a>
</form>--%>


<%--<!DOCTYPE html>
<html>
<head runat="server">
    <title>Bill Entry</title>
    <link href="Content/styles.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
  <div class="container">
    <h2>Enter Electricity Bills</h2>
 
    <label>Number of bills to be added</label>
    <asp:TextBox ID="txtCount" runat="server" Text="1" />
 
    <label>Consumer Number (EB + 5 digits)</label>
    <asp:TextBox ID="txtCN" runat="server" />
 
    <label>Consumer Name</label>
    <asp:TextBox ID="txtName" runat="server" />
 
    <label>Units Consumed</label>
    <asp:TextBox ID="txtUnits" runat="server" />
 
    <asp:Button ID="btnSave" runat="server" Text="Calculate & Save"
                OnClick="btnSave_Click" UseSubmitBehavior="false" />
    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
    <br /><br />
 
    <!-- Message label -->
<asp:Label ID="lblMsg" runat="server" ForeColor="Green"></asp:Label>
<br /><br />
 
<!-- GridView for showing saved bills -->
<asp:GridView ID="gv" runat="server" AutoGenerateColumns="true" BorderColor="Black" BorderWidth="1px">
</asp:GridView>
 
    <div class="result-box">
      <asp:Label ID="lblOut" runat="server" />
    </div>
    <hr />
    <a href="BillRetrieve.aspx">Retrieve last N bills</a>
  </div>
</form>
</body>
</html>--%>
 

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill Entry</title>
    <style>
        body { font-family: Arial, sans-serif; background:#f4f6f9; margin:0; }
        .container { width:520px; margin:40px auto; background:#fff; border:1px solid #ddd;
            border-radius:10px; padding:20px; box-shadow:0 4px 8px rgba(0,0,0,.08); }
        h2 { text-align:center; margin-top:0; color:#333; }
        label { display:block; margin:12px 0 6px; font-weight:600; color:#444; }
        input[type=text] { width:100%; padding:8px 10px; border:1px solid #ccc; border-radius:6px; }
        .btn { width:100%; padding:10px; margin-top:14px; background:#007bff; color:#fff;
            border:0; border-radius:6px; cursor:pointer; }
        .btn:hover { background:#005dc1; }
        .msg { margin-top:10px; font-weight:bold; color:green; }
        .grid-wrap { width:900px; margin:20px auto; }
        .grid-wrap h3 { margin:0 0 10px 0; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Enter Electricity Bill</h2>
 
            <label>Consumer Number (e.g., EB12345)</label>
            <asp:TextBox ID="txtCN" runat="server" placeholder="EB12345"></asp:TextBox>
 
            <label>Consumer Name</label>
            <asp:TextBox ID="txtName" runat="server" placeholder="Name"></asp:TextBox>
 
            <label>Units Consumed</label>
            <asp:TextBox ID="txtUnits" runat="server" placeholder="e.g., 250"></asp:TextBox>
 
            <!-- Save button (UseSubmitBehavior=false helps prevent double submit) -->
            <asp:Button ID="btnSave" runat="server" Text="Calculate & Save"
                        CssClass="btn" OnClick="btnSave_Click" UseSubmitBehavior="false" />
 
            <!-- Success / error message -->
            <asp:Label ID="lblMsg" runat="server" CssClass="msg"></asp:Label>
        </div>
 
        <!-- Recent bills grid -->
        <div class="grid-wrap">
            <h3>Saved Bills</h3>
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="true"
                          BorderWidth="1px" BorderColor="#ccc" CellPadding="6"
                          GridLines="Both">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
XHTML namespace
 
