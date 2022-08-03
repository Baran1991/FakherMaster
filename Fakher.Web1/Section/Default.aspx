<%@ Page Title="" Language="C#" MasterPageFile="~/Section/SectionMasterPage.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Section_Default" %>

<%@ Register src="../UserControls/WebPageView.ascx" tagname="WebPageView" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
<%--    <asp:Label ID="lblTitle" runat="server" Text="" Font-Names="Tahoma" Font-Size="11pt"--%>
<%--        Font-Bold="True"></asp:Label>--%>
<%--    <hr style="color: #fff; background-color: #fff; border: 1px dotted #ff0000; border-style: none none dotted;" />--%>
    
<%--    <asp:Panel ID="pnlCenter" runat="server">--%>
        <uc1:WebPageView ID="WebPageView1" runat="server" />
<%--    </asp:Panel>--%>
    
</asp:Content>
