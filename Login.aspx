<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Login ID="Login1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid"
        BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" Height="157px" OnAuthenticate="Login1_Authenticate"
        Width="348px">
        <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
    </asp:Login>
</asp:Content>

