<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="userdetailwebsite.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="font-size:x-large" align="center">Employee Information<table class="nav-justified">
            <tr>
                <td style="width: 339px">&nbsp;</td>
                <td style="width: 1067px">
                    <asp:Button ID="addbtn" runat="server" BackColor="#FF99FF" ForeColor="Black" OnClick="addbtn_Click" Text="New" />
&nbsp;<asp:Button ID="delbtn" runat="server" BackColor="Red" ForeColor="White" OnClick="delbtn_Click" Text="Delete" OnClientClick="return confirm('Do you want to delete the record ? ');"/>
&nbsp;<asp:Button ID="updatebtn" runat="server" BackColor="#99FFCC" ForeColor="Black" OnClick="updatebtn_Click" Text="Update" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 339px">&nbsp;</td>
                <td style="width: 1067px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 339px">&nbsp;</td>
                <td style="width: 1067px">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="u_id" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" Width="792px" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="ChkHeader" runat="server" AutoPostBack="true" Text="Select All" OnCheckedChanged="ChkHeader_CheckedChanged"/>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkEmpty" runat="server" OnCheckedChanged="ChkEmpty_CheckedChanged"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="u_id" HeaderText="ID" ReadOnly="True" >
                            <HeaderStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="u_name" HeaderText="Name" />
                            <asp:BoundField DataField="u_DOB" HeaderText="DoB" DataFormatString = "{0:dd/MM/yyyy}"/>
                            <asp:BoundField DataField="u_phone" HeaderText="Contact" />
                            <asp:CommandField ShowEditButton="True" HeaderText="Edit"/>
                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" HeaderText="Delete" >
                            <ControlStyle BackColor="Red" ForeColor="White" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 339px">&nbsp;</td>
                <td style="width: 1067px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 339px">&nbsp;</td>
                <td style="width: 1067px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 339px">&nbsp;</td>
                <td style="width: 1067px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 339px">&nbsp;</td>
                <td style="width: 1067px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 339px">&nbsp;</td>
                <td style="width: 1067px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            </table>
        </div>
    </div>
</asp:Content>
