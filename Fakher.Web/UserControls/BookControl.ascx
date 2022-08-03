<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BookControl.ascx.cs" Inherits="UserControls_BookControl" %>
<asp:Panel ID="Panel1" runat="server" Visible="False">
    <table style="margin: auto auto">
    <tr>
        <td style="text-align: center; ">
           <%-- <telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" Width="104px" Height="107px"
                ResizeMode="Fit" Visible="False" />--%>
            <asp:Image ID="Image1" runat="server" Width="60px" Height="40px"  />
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:HyperLink ID="lnkName" runat="server" Text="Label" Font-Bold="True" Font-Italic="True"></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:Label ID="Label1" runat="server" Text="نویسنده: " Font-Bold="True"></asp:Label>
            <asp:Label ID="lblAuthor" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: center">
            <asp:Label ID="Label2" runat="server" Text="قیمت: " Font-Bold="True"></asp:Label>
            <asp:Label ID="lblPrice" runat="server" Text="Label" ForeColor="Red"></asp:Label>
        </td>
    </tr>
</table>
</asp:Panel>

