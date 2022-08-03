<%@ Page Title="" Language="C#" MasterPageFile="~/Section/SectionMasterPage.master"
    AutoEventWireup="true" CodeFile="Page.aspx.cs" Inherits="Page" %>

<%@ Register src="../UserControls/WebPageView.ascx" tagname="WebPageView" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
<%--    <asp:Panel ID="pnlPage" runat="server" Direction="RightToLeft">--%>
<%--        <asp:Label ID="lblTitle" runat="server" Text="" Font-Names="Tahoma" Font-Size="11pt"--%>
<%--            Font-Bold="True"></asp:Label>--%>
<%--        <hr style="color: #fff; background-color: #fff; border: 1px dotted #ff0000; border-style: none none dotted;" />--%>
<%--        <asp:Literal ID="Literal1" runat="server"></asp:Literal>--%>
<%--        --%>
<%--        <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma">--%>
<%--            <table style="width: 100%; background-color: #e5e6e6; border-top: 1px dashed black">--%>
<%--                <tr>--%>
<%--                    <td style="text-align: right">--%>
<%--                        <asp:Label ID="Label1" runat="server" Text="هم اکنون برای پیش ثبت نام در این دوره "></asp:Label>--%>
<%--                        <asp:HyperLink ID="HyperLink1" runat="server">اینجا را کلیک کنید.</asp:HyperLink>--%>
<%--                    </td>--%>
<%--                </tr>--%>
<%--            </table>--%>
<%--        </asp:Panel>--%>
<%--    </asp:Panel>--%>
    <uc1:WebPageView ID="WebPageView1" runat="server" />
</asp:Content>
