<%@ Page Title="گزارش فیش حقوقی" Language="C#" MasterPageFile="~/Instructor/InstructorMasterPage.master"
    AutoEventWireup="true" CodeFile="rptPayroll.aspx.cs" Inherits="Instructor_rptPayroll" %>

<%@ Register Src="~/UserControls/ReportViewer.ascx" TagName="ReportViewer" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <asp:Label ID="Label1" runat="server" Text="گزارش فیش حقوقی" Font-Names="Tahoma"></asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td style="vertical-align: central; width: 100%" valign="middle" align="center">
                <telerik:RadComboBox ID="RadComboBox1" runat="server" Width="100%" Font-Names="Tahoma"
                    DataValueField="Id">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: central; width: 100%; padding: 5px 0px;" valign="middle" align="center">
                <telerik:RadButton ID="btnShow" runat="server" Text="نمــایــش" Font-Names="Tahoma"
                    Width="150px" OnClick="btnShow_Click">
                    <Icon SecondaryIconUrl="~/images/mag.gif"></Icon>
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" Height="100%" Style="margin-right: -40px; float: right;"
        Visible="True">
        <uc1:ReportViewer ID="ReportViewer1" runat="server" />
    </asp:Panel>
</asp:Content>
