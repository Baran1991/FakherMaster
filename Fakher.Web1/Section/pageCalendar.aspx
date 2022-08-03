<%@ Page Title="" Language="C#" MasterPageFile="~/Section/SectionMasterPage.master"
    AutoEventWireup="true" CodeFile="pageCalendar.aspx.cs" Inherits="Department_pageCalendar" %>

<%@ Register src="~/UserControls/MajorSections.ascx" tagname="MajorGroups" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma">
        <asp:Panel ID="Panel2" runat="server" Font-Names="Tahoma" Width="100%">
            <asp:Label ID="Label2" runat="server" Text="تــــرم: "></asp:Label>
            <telerik:RadComboBox ID="cmbPeriod" runat="server" Width="95%" OnDataBound="cmbPeriod_DataBound"
                OnSelectedIndexChanged="cmbPeriod_SelectedIndexChanged" AutoPostBack="True">
            </telerik:RadComboBox>
        </asp:Panel>
        
        <asp:Table ID="Table1" runat="server" Width="100%">
        </asp:Table>
    </asp:Panel>
</asp:Content>
