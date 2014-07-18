<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Transaction.aspx.cs" Inherits="Transaction" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
        <tr>
            <td style="width: 200px" align="left" valign="top">
                <br />
                <br />
                <table>
                    <tr>
                        <td style="width: 100px">
                            <asp:Button ID="checkBalance" runat="server" Height="40px" OnClick="checkBalance_Click" Text="Check Account Balance"
                                Width="236px" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Button ID="TransferAccount" runat="server" Height="39px" Text="Transfer to another account" OnClick="TransferAccount_Click" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Button ID="withdraw" runat="server" Height="35px" Text="Withdraw" Width="236px" OnClick="withdraw_Click" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Button ID="print" runat="server" Height="43px" Text="Exit" Width="236px" OnClick="print_Click" /></td>
                    </tr>
                </table>
            </td>
            <td valign="top">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Garamond" ForeColor="#000066">Checking</asp:Label></td>
                                <td style="width: 100px">
                                    <asp:Label ID="lblChecking" runat="server" Font-Bold="True" Font-Names="Garamond" ForeColor="#000066" Width="570px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; height: 20px;">
                                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Garamond" ForeColor="#000066">Savings</asp:Label></td>
                                <td style="width: 100px; height: 20px;">
                                    <asp:Label ID="lblSavings" runat="server" Font-Bold="True" Font-Names="Garamond" ForeColor="#000066" Width="572px"></asp:Label></td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td style="width: 100px; text-align: right">
                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Garamond" Font-Size="12pt"
                                        ForeColor="DarkBlue" Text="I would like to transfer $" Width="170px"></asp:Label></td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="txtAmountTrns" runat="server" Height="15px" Width="135px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; text-align: right">
                                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Garamond" Font-Size="12pt"
                                        ForeColor="DarkBlue" Text="From"></asp:Label></td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="143px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        <asp:ListItem>Checking</asp:ListItem>
                                        <asp:ListItem>Savings</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; text-align: right">
                                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Garamond" Font-Size="12pt"
                                        ForeColor="DarkBlue" Text="To"></asp:Label></td>
                                <td style="width: 100px">
                                    <asp:Label ID="lblTransfer" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <asp:Button ID="Button1" runat="server" Text="Transfer" OnClick="Button1_Click1" /></td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <br />
                        <br />
                        <table>
                            <tr>
                                <td style="width: 100px; text-align: right">
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Garamond" Font-Size="12pt"
                                        ForeColor="DarkBlue" Height="9px" Text="Withdraw from" Width="137px"></asp:Label></td>
                                <td style="width: 100px">
                                    <asp:DropDownList ID="DropDownList2" runat="server" Width="143px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                        <asp:ListItem>Checking</asp:ListItem>
                                        <asp:ListItem>Savings</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Button ID="Button5" runat="server" Height="39px" Text="$20" Width="154px" OnClick="Button5_Click1" /></td>
                                <td style="width: 100px">
                                    <asp:Button ID="Button6" runat="server" Height="37px" Text="$40" Width="156px" OnClick="Button5_Click1" /></td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <asp:Button ID="Button7" runat="server" Height="35px" Text="$60" Width="154px" OnClick="Button5_Click1" /></td>
                                <td style="width: 100px">
                                    <asp:Button ID="Button8" runat="server" Height="33px" Text="$80" Width="159px" OnClick="Button5_Click1" /></td>
                            </tr>
                            <tr>
                                <td style="width: 100px; height: 42px;">
                                    <asp:Button ID="Button9" runat="server" Height="40px" Text="$100" Width="152px" OnClick="Button5_Click1" /></td>
                                <td style="width: 100px; height: 42px;">
                                    <asp:Label ID="Label2" runat="server" Font-Size="Smaller" Height="1px" Text="Other, Please enter amount"
                                        Width="145px"></asp:Label>
                                    <asp:TextBox ID="TextBox1" runat="server" Width="108px" OnTextChanged="TextBox1_TextChanged"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 42px; text-align: center">
                        <asp:Button ID="ok" runat="server" Height="31px" Text="Done" Width="107px" OnClick="ok_Click" /></td>
                            </tr>
                        </table>
                        </asp:View>
                </asp:MultiView>
                <asp:Label ID="message" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

