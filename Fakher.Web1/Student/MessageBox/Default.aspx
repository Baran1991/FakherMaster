<%@ Page Async="true" Title="صندوق پیام های دریافتی" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Student_MessageBox_Default" %>

<%@ Register TagPrefix="uc1" TagName="rMessageBox" Src="~/rComponents/rMessageBox/rMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" />
    <table style="width: 200px; height: 37px;">
        <tr>
            <td class="heading">
                <asp:Label ID="Label5" runat="server" Text="صندوق پیام های دریافتی" Font-Names="Tahoma" Font-Size="10pt"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Left" Style="padding: 5px 0px;">
            <telerik:RadButton ID="btnNewMessage" runat="server" Text="پیـام جـدیـد" Font-Names="Tahoma"
                Width="150px" OnClick="btnNewMessage_Click">
                <Icon SecondaryIconUrl="~/images/plus.png"></Icon>
            </telerik:RadButton>
        </asp:Panel>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" OnItemDataBound="RadGrid1_ItemDataBound"
            Font-Names="Tahoma" CellSpacing="0" GridLines="None" OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged">
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
                    <telerik:GridBoundColumn DataField="SendDateTime" HeaderText="تاریخ ارسال">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Sender" HeaderText="فرستنده">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="GridSubject" HeaderText="عنوان">
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
