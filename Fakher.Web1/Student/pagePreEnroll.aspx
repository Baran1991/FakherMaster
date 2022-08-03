<%@ Page Title="ثبـت نام در رویدادها" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="pagePreEnroll.aspx.cs" Inherits="Student_pagePreEnroll" %>

<%@ Register TagPrefix="uc1" TagName="rMessageBox" Src="~/rComponents/rMessageBox/rMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" OnDialogResult="rMessageBox1_DialogResult" />
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma">
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label7" runat="server" Text="رویدادهای قابل ثبت نام" Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
        </table>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" OnItemDataBound="RadGrid1_ItemDataBound"
            Font-Names="Tahoma">
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" Font-Names="Tahoma">
            </HeaderContextMenu>
            <MasterTableView DataKeyNames="Id" Dir="RTL" NoMasterRecordsText="رکوردی برای نمایش وجود ندارد"
                Font-Names="Tahoma">
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
                    <telerik:GridBoundColumn DataField="Name" HeaderText="عنوان">
                    </telerik:GridBoundColumn>
                      <telerik:GridBoundColumn DataField="DateTime" HeaderText="زمان">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <telerik:RadButton ID="btnSelect" runat="server" Text="انتخـاب" Font-Names="Tahoma"
                                Width="150px" OnClick="btnSelect_Click">
                                <Icon SecondaryIconUrl="~/images/Plus.png"></Icon>
                            </telerik:RadButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </telerik:GridTemplateColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="True">
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
        </telerik:RadGrid>
    </asp:Panel>
   
</asp:Content>
