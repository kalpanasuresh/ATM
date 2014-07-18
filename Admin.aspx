<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" Title="Admin" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="width: 100px; height: 45px;">
                <asp:Button ID="cutomer" runat="server" Text="Customer Records" OnClick="cutomer_Click" /></td>
            <td style="width: 100px; height: 45px;">
                <asp:Button ID="ATM" runat="server" Text="ATM Account Records" OnClick="ATM_Click" /></td>
            <td style="width: 100px; height: 45px;">
                <asp:Button ID="Transaction" runat="server" Text="ATM Transaction Records" OnClick="Transaction_Click" /></td>
            <td style="width: 100px; height: 45px;">
                <asp:Button ID="adminrec" runat="server" Text="System Admin Records" OnClick="adminrec_Click" /></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 45px">
            </td>
            <td style="width: 100px; height: 45px">
            </td>
            <td style="width: 100px; height: 45px">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Black" Style="left: 2px;
                    position: static; top: 28px" Text="ATM" Visible="False"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource2"
                    DataTextField="branch_name" DataValueField="atm_id" Font-Names="Garamond" Font-Size="12pt"
                    ForeColor="Black" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                    Style="position: static" Visible="False" Width="122px">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 45px">
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 45px">
    <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
        BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Height="140px"
        Width="1024px" AllowPaging="True" AllowSorting="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowUpdated="GridView1_RowUpdated1" HorizontalAlign="Center" OnRowEditing="GridView1_RowEditing1" OnRowUpdating="GridView1_RowUpdating" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateSelectButton="True">
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
            </td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ATMConnectionString %>"
        SelectCommand="SELECT * FROM [Customer_ATM]"></asp:SqlDataSource>
    <asp:LinkButton ID="viewTransactionHistory" runat="server" OnClick="viewTransactionHistory_Click">View transaction history</asp:LinkButton>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Go" /><br />
    <asp:Panel ID="Panel1" runat="server" Height="364px" Width="761px">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1079px" Font-Names="Verdana" Font-Size="8pt" Height="555px">
            <LocalReport ReportPath="Report2.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
        &nbsp;
    </asp:Panel>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ATMConnectionString %>"
        SelectCommand="SELECT ATM_Machine.atm_id, Bank_branch_ATM.branch_name FROM ATM_Machine INNER JOIN Bank_branch_ATM ON ATM_Machine.branch_id = Bank_branch_ATM.branch_id">
    </asp:SqlDataSource>
</asp:Content>

