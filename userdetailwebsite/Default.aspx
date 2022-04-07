<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="userdetailwebsite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="font-size:x-large" align="center">Enter Information</div>
        <br />
        <table class="nav-justified">
            <tr>
                <td class="modal-sm" style="width: 220px">
                    <asp:Label ID="Label1" runat="server" Font-Size="Medium" Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="nameTB" runat="server" Font-Size="Medium"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nameTB" ErrorMessage="Name is required" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 220px">
                    <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Date of Birth"></asp:Label>
                </td>
                <td style="height: 20px">
                    <asp:TextBox ID="dobTB" runat="server" Font-Size="Medium" TextMode="date" placeholder="mm/dd/yyyy" AutoPostBack="True" OnTextChanged="dobTB_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dobTB" ErrorMessage="Select DOB" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 220px">
                    <asp:Label ID="Label3" runat="server" Font-Size="Medium" Text="Age"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ageTB" runat="server" Font-Size="Medium" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 220px">
                    <asp:Label ID="Label4" runat="server" Font-Size="Medium" Text="Phone"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="phoneTB" runat="server" Font-Size="Medium"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="numOnlyValidator"
                        ControlToValidate="phoneTB" runat="server"
                        ErrorMessage="Only Numbers allowed"
                        ValidationExpression="\d+" Font-Italic="True" ForeColor="Red"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 220px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 220px">
                    <asp:Button ID="btnSubmit" runat="server" Font-Bold="True" Font-Size="Medium" Text="Submit" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnReset" runat="server" Font-Bold="True" Font-Size="Medium" Text="Reset" OnClick="btnReset_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 220px">
                    <asp:Button ID="btnUpdate" runat="server" Font-Bold="True" Font-Size="Medium" Text="Update" Visible="false" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btncancel" runat="server" Font-Bold="True" Font-Size="Medium" Text="Cancel" Visible="false" OnClick="btncancel_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="modal-sm" style="width: 220px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
</asp:Content>
