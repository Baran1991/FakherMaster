<%@ Page Title="گزارش رسید ثبت نام" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="rptSignupReceipt.aspx.cs" Inherits="Student_pageSignupReceipt" %>
<%@ Register Assembly="Telerik.ReportViewer.Html5.WebForms, Version=14.1.20.618, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.Html5.WebForms" TagPrefix="telerik" %>
<%--<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=5.1.11.713, Culture=neutral, PublicKeyToken=a9d7983dfcc261be"
    Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>--%>
<%@ Register TagPrefix="uc1" TagName="ReportViewer" Src="~/UserControls/ReportViewer.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="رسیــد ثبــت نـام" Font-Names="Tahoma"></asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <br/>
    <asp:Panel ID="Panel1" runat="server" Height="100%" Style="margin-right: -40px; float: right;"
        Visible="True">
        <uc1:ReportViewer ID="ReportViewer1" runat="server" />
    </asp:Panel>
</asp:Content>

