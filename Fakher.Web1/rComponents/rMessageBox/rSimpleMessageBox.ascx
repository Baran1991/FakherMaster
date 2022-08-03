<%@ Control Language="C#" AutoEventWireup="true" CodeFile="rSimpleMessageBox.ascx.cs"
    Inherits="rComponents_rMessageBox_rSimpleMessageBox" %>
<asp:Panel ID="Panel1" runat="server" Visible="false" Font-Names="Tahoma" Direction="RightToLeft" EnableViewState="False">
    <table style="border: 10px royalblue; width:100%">
        <tr>
            <td style="background-color: #c93340; height: 55px; vertical-align: middle; text-align:center">
                <asp:Label ID="lblTopMessage" runat="server" Text="Label" Font-Size="10pt" Font-Bold="true" ForeColor="#ffffff"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" Text="Label" Font-Bold="true" ForeColor="#ffffff"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
