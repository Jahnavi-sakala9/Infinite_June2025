<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment1.Validator" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validation Form</title>
    <style>
        body {
            font-family: Arial;
            background-color: #f0f2f5;
        }
        .form-container {
            width: 700px;
            margin: 40px auto;
            background-color: #fff;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        table {
            width: 100%;
            border-spacing: 12px;
        }
        td {
            vertical-align: top;
        }
        input[type="text"] {
            width: 96%;
            padding: 6px;
            font-size: 14px;
        }
        .note {
            color: gray;
            font-size: 12px;
        }
        .error {
            color: red;
            font-size: 13px;
        }
        .btn-check {
            padding: 8px 16px;
            background-color: #007ACC;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        .btn-check:hover {
            background-color: #005fa3;
        }
        .summary-title {
            font-weight: bold;
            color: red;
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Insert Personal Details</h2>
            <table>
                <tr>
                    <td style="width:30%">Name</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="TextBox1" ErrorMessage="Name is required." CssClass="error" />
                    </td>
                </tr>

                <tr>
                    <td>Family Name</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="TextBox2" ErrorMessage="Family Name is required." CssClass="error" />
                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                            ControlToValidate="TextBox2" ControlToCompare="TextBox1"
                            ErrorMessage="Name must be different from Family Name." CssClass="error"
                            Operator="NotEqual" />
                        <div class="note">Must differ from Name</div>
                    </td>
                </tr>

                <tr>
                    <td>Address</td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="TextBox3" ErrorMessage="Address is required." CssClass="error" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="TextBox3" ValidationExpression=".{2,}"
                            ErrorMessage="Address must have at least 2 characters." CssClass="error" />
                        <div class="note">Minimum 2 characters</div>
                    </td>
                </tr>

                <tr>
                    <td>City</td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="TextBox4" ErrorMessage="City is required." CssClass="error" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                            ControlToValidate="TextBox4" ValidationExpression=".{2,}"
                            ErrorMessage="City must have at least 2 characters." CssClass="error" />
                        <div class="note">Minimum 2 characters</div>
                    </td>
                </tr>

                <tr>
                    <td>Zip Code</td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ControlToValidate="TextBox5" ErrorMessage="Zip Code is required." CssClass="error" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                            ControlToValidate="TextBox5" ValidationExpression="^\d{5}$"
                            ErrorMessage="Zip Code must be 5 digits." CssClass="error" />
                        <div class="note">Format: xxxxx</div>
                    </td>
                </tr>

                <tr>
                    <td>Phone</td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                            ControlToValidate="TextBox6" ErrorMessage="Phone is required." CssClass="error" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                            ControlToValidate="TextBox6"
                            ValidationExpression="^\d{2}-\d{8}$|^\d{3}-\d{8}$"
                            ErrorMessage="Phone must follow XX-XXXXXXXX or XXX-XXXXXXXX." CssClass="error" />
                        <div class="note">Format: xx-xxxxxxxx or xxx-xxxxxxxx</div>
                    </td>
                </tr>

                <tr>
                    <td>E-Mail</td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                            ControlToValidate="TextBox7" ErrorMessage="Email is required." CssClass="error" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                            ControlToValidate="TextBox7"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ErrorMessage="Enter a valid email address." CssClass="error" />
                        <div class="note">Format: example@example.com</div>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Check" CssClass="btn-check" OnClick="Button1_Click" />
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <div class="summary-title">Validation Summary:</div>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                            ShowMessageBox="True" ShowSummary="False" ForeColor="Red" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
 