<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Summary" Title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="text-align: center">
        <tr>
            <td style="width: 100px; text-align: center">
                <table style="width: 674px">
                    <tr>
                        <td colspan="3" style="height: 24px; text-align: center; padding-left: 25px; padding-top: 25px;">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="24pt"
                                ForeColor="#663333" Text="Would like to do another Transation?"></asp:Label>&nbsp;</td>
                    </tr>
                </table>
                <span style="font-family: Garamond"><strong style="width: 100%"><span style="font-size: 14pt; color: maroon">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1"
                        Text="Yes" /></span>&nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="No" /></strong></span></td>
        </tr>
    </table>
</asp:Content>

