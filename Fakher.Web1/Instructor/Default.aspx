<%@ Page Title="" Language="C#" MasterPageFile="~/Instructor/InstructorMasterPage.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Instructor_Default" %>

<%@ Register TagPrefix="uc1" TagName="rMessageBox" Src="~/rComponents/rMessageBox/rMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" Font-Size="9pt">
        <uc1:rMessageBox ID="rMessageBox1" runat="server" />
        <asp:Label ID="Label3" runat="server" Text="پنــل سیستـم آمـوزش استـاد" Font-Names="Tahoma"
            Font-Size="10pt"></asp:Label>
        <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;">
                    <asp:Label ID="Label6" runat="server" Text="نـــام:" Font-Bold="True"></asp:Label>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblName" runat="server" Text="Label" Font-Size="10pt"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:Label ID="Label5" runat="server" Text="کـــد پرسنـلــی:" Font-Bold="True"></asp:Label>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblStudentCode" runat="server" Text="Label" Font-Size="10pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; width: 110px;">
                    <asp:Label ID="Label2" runat="server" Text="رشـتـــه فعــــال:"></asp:Label>
                </td>
                <td style="text-align: right">
                    <telerik:RadComboBox ID="cmbMajor" runat="server" Width="100%" OnDataBound="cmbMajor_DataBound"
                        OnSelectedIndexChanged="cmbMajor_SelectedIndexChanged" AutoPostBack="True">
                    </telerik:RadComboBox>
                </td>
                <td style="text-align: left; width: 110px;">
                    <asp:Label ID="Label4" runat="server" Text="تــــرم فـعـــال:"></asp:Label>
                </td>
                <td style="text-align: right">
                    <telerik:RadComboBox ID="cmbPeriod" runat="server" Width="100%" OnDataBound="cmbPeriod_DataBound"
                        OnSelectedIndexChanged="cmbPeriod_SelectedIndexChanged" AutoPostBack="True">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <div runat="server" id="pnlUnread" Visible="False" style="width: 100%; text-align: center; margin-top: 10px;">
            <asp:HyperLink ID="lblUnread" runat="server" Text="" NavigateUrl="~/Instructor/MessageBox/Default.aspx" Font-Names="Tahoma" Font-Size="10pt" Font-Bold="True"></asp:HyperLink>
        </div>
        <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label1" runat="server" Text="گـــروه هـا" Font-Names="Tahoma" Font-Size="10pt"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="برای ورود نمرات هر گروه، در بازه تاریخ و زمان مشخص شده، برروی نام آن گروه کلیک کنید"
                        Font-Names="Tahoma" ForeColor="#006400"></asp:Label>
                </td>
            </tr>
        </table>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged"
            OnItemDataBound="RadGrid1_ItemDataBound" Font-Names="Tahoma">
            <ItemStyle CssClass="CustomStyle"></ItemStyle>
            <AlternatingItemStyle CssClass="CustomStyle"></AlternatingItemStyle>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" Font-Names="Tahoma">
            </HeaderContextMenu>
            <MasterTableView DataKeyNames="Id" Dir="RTL" NoMasterRecordsText="رکوردی برای نمایش وجود ندارد">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridTemplateColumn HeaderText="ردیف">
                        <ItemTemplate>
                            <asp:Label ID="lblIndex" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="FarsiName" HeaderText="گــروه">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ItemsText" HeaderText="درس/سـطــح">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="FarsiFormationText" HeaderText="برگزاری">
                    </telerik:GridBoundColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="True">
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
        </telerik:RadGrid>
    </asp:Panel>
</asp:Content>
