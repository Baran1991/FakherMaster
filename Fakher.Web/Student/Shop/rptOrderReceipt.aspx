<%@ Page Title="گزارش رسید خرید اینترنتی" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="rptOrderReceipt.aspx.cs" Inherits="Student_Shop_rptOrderReceipt" %>
<%@ Register TagPrefix="uc1" TagName="ReportViewer" Src="~/UserControls/ReportViewer.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" Runat="Server">
        <asp:Label ID="Label1" runat="server" Text="رسید خرید اینترنتی" Font-Names="Tahoma"></asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <br/>
    <asp:Panel ID="Panel1" runat="server" Height="100%" Style="margin-right: -40px; float: right;"
        Visible="True">
        <uc1:ReportViewer ID="ReportViewer1" runat="server" />
    </asp:Panel>
</asp:Content>

