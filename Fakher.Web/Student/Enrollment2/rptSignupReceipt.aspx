<%@ Page Title="گزارش رسید ثبت نام" Language="C#" MasterPageFile="~/Student/Enrollment/EnrollmentMasterPage.master"
    AutoEventWireup="true" CodeFile="rptSignupReceipt.aspx.cs" Inherits="Student_pageSignupReceipt" %>

<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=5.1.11.713, Culture=neutral, PublicKeyToken=a9d7983dfcc261be"
    Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<%@ Register TagPrefix="uc1" TagName="ReportViewer" Src="~/UserControls/ReportViewer.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <asp:Label ID="Label1" runat="server" Text="رسیــد ثبــت نـام (این رسید را می توانید چاپ کنید یا آن را در کامپیوتر خود ذخیره کنید)"
        Font-Names="Tahoma" Font-Size="10pt"></asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <br />
<%--    <table width="100%">--%>
<%--        <tr>--%>
<%--            <td>--%>
<%--                <asp:Label ID="Label2" runat="server" Text="رشته:"></asp:Label>--%>
<%--            </td>--%>
<%--            <td>--%>
<%--                <asp:DropDownList ID="cmbMajor" runat="server" Width="99%" DataTextField="Name" DataValueField="Id">--%>
<%--                </asp:DropDownList>--%>
<%--            </td>--%>
<%--        </tr>--%>
<%--        <tr>--%>
<%--            <td>--%>
<%--                <asp:Label ID="Label3" runat="server" Text="تـرم:"></asp:Label>--%>
<%--            </td>--%>
<%--            <td>--%>
<%--                <asp:DropDownList ID="cmbPeriod" runat="server" Width="99%" DataTextField="Name" DataValueField="Id">--%>
<%--                </asp:DropDownList>--%>
<%--            </td>--%>
<%--        </tr>--%>
<%--    </table>--%>
    <asp:Panel ID="Panel1" runat="server" Height="100%" Style="margin-right: -40px; float: right;"
        Visible="True">
        <uc1:ReportViewer ID="ReportViewer1" runat="server" />
    </asp:Panel>
</asp:Content>
