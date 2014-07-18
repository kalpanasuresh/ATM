<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"><table style="width: 100%; height: 100%"><tr><td align="center" style="vertical-align: middle; width: 100%; text-align: center; padding-left: 20px; height: 100%;"
                valign="middle"><table style="height: 300px; width: 397px; background-color: #333333; clear: both;" ><caption style="text-align: right; "><strong style="background-color: transparent">&nbsp;</strong>&nbsp;</caption><tr><td style="width: 207px; height: 26px; text-align: right;" align="left" valign="bottom"><table style="width: 389px; height: 92px; position: relative;">
                    <tr>
                        <td align="left" style="width: 32px; position: relative; height: 26px; text-align: right"
                            valign="top">
                        </td>
                        <td align="left" style="width: 100px; height: 26px">
                    <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" Font-Names="Garamond"
                        Font-Size="12pt" ForeColor="#FFFFFF" PostBackUrl="~/Login.aspx">Admin Login</asp:LinkButton></td>
                    </tr>
                    <tr>
                        <td style="width: 32px; text-align: right; position: relative; height: 26px;" align="left" valign="top">

                            <asp:Label ID="Label04" runat="server" Font-Bold="True" ForeColor="White" Text="ATM" style="text-align: right"></asp:Label></td>
                        <td style="width: 100px; height: 26px;" align="left">
                            <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1"
                                DataTextField="branch_name" DataValueField="atm_id" Font-Names="Garamond" Font-Size="12pt"
                                ForeColor="Black" Width="122px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr><td style="width: 32px; text-align: right; height: 25px;" align="left" valign="top">
                        <asp:Label ID="Label1" runat="server" Text="Card Number" Width="102px" Font-Bold="True" Font-Names="Garamond" Font-Size="12pt" ForeColor="White" Height="18px" style="position: static; text-align: left;"></asp:Label></td><td style="width: 100px; text-align: left; height: 25px;"><asp:TextBox ID="TextBox2" runat="server" Height="17px" Width="116px"></asp:TextBox></td></tr><tr><td style="width: 32px; height: 2px; text-align: left" align="left" valign="top">
           
                    <asp:Label ID="Label2" runat="server" Text="Pin" Font-Bold="True" Font-Names="Garamond" Font-Size="12pt" ForeColor="White" style="text-align: left"></asp:Label></td><td style="width: 100px; height: 2px" align="left"><asp:TextBox ID="TextBox1" runat="server" Height="19px" Width="115px" TextMode="Password"></asp:TextBox></td></tr>
                    <tr>
                        <td align="left" style="width: 32px; height: 2px; text-align: right" valign="top">
                        </td>
                        <td align="left" style="width: 100px; height: 2px">
                    <table style="position: static;">
                        <tr>
                            <td style="height: 26px">
                                <asp:Button ID="Button1" runat="server" OnClick="Pin_Click" Text="1" Width="31px" /></td>
                            <td style="width: 23px; height: 26px;">
                                <asp:Button ID="Button2" runat="server" OnClick="Pin_Click" Text="2" Width="31px" /></td>
                            <td style="width: 10px; height: 26px;">
                                <asp:Button ID="Button3" runat="server" OnClick="Pin_Click" Text="3" Width="31px" /></td>
                        </tr>
                        <tr>
                            <td style="height: 26px">
                                <asp:Button ID="Button4" runat="server" OnClick="Pin_Click" Text="4" Width="31px" /></td>
                            <td style="width: 23px; height: 26px;">
                                <asp:Button ID="Button5" runat="server" OnClick="Pin_Click" Text="5" Width="31px" /></td>
                            <td style="width: 10px; height: 26px;">
                                <asp:Button ID="Button6" runat="server" OnClick="Pin_Click" Text="6" Width="31px" /></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button7" runat="server" OnClick="Pin_Click" Text="7" Width="31px" /></td>
                            <td style="width: 23px">
                                <asp:Button ID="Button8" runat="server" OnClick="Pin_Click" Text="8" Width="31px" /></td>
                            <td style="width: 10px">
                                <asp:Button ID="Button9" runat="server" OnClick="Pin_Click" Text="9" Width="31px" /></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td style="width: 23px">
                                <asp:Button ID="Button10" runat="server" OnClick="Pin_Click" Text="0" Width="31px" /></td>
                            <td style="width: 10px">
                            </td>
                        </tr>
                    </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="padding-left: 10px; height: 2px">
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            &nbsp; &nbsp;<asp:Button ID="enter" runat="server" Text="Enter" OnClick="Enter_Click" /> <asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" /> <asp:Button ID="back" runat="server" Text="Back" OnClick="back_Click" /> 
                            <br />
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Red" Font-Size="9pt"></asp:Label></td>
                    </tr>
                </table>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                </td></tr></table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ATMConnectionString %>" SelectCommand="SELECT ATM_Machine.atm_id, Bank_branch_ATM.branch_name FROM ATM_Machine INNER JOIN Bank_branch_ATM ON ATM_Machine.branch_id = Bank_branch_ATM.branch_id"></asp:SqlDataSource>
</td></tr></table>
</asp:Content>

