<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AttachmentView.ascx.cs" Inherits="UserControls_AttachmentView" %>
    <asp:Panel ID="pnlAttachments" runat="server" Font-Names="Tahoma" Font-Size="10pt"
        Visible="False">
        <table style="width: 100%">
            <tr>
                <td style="background-color: #3772ab; color: #ffffff">
                    <asp:Label ID="Label11" runat="server" Text="پیوست هــا؛" Font-Names="Tahoma" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #e5e6e6; text-align: justify">
                    <telerik:RadGrid ID="RadGridAttachments" runat="server" AutoGenerateColumns="False"
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
                                <telerik:GridHyperLinkColumn DataTextField="Name" HeaderText="عنــوان" DataNavigateUrlFields="Code"
                                    DataNavigateUrlFormatString="~/Media.aspx?c={0}">
                                </telerik:GridHyperLinkColumn>
                                <telerik:GridBoundColumn DataField="Hits" HeaderText="تعداد دریافت">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings EnablePostBackOnRowClick="False" EnableRowHoverStyle="False">
                            <Selecting AllowRowSelect="False" />
                        </ClientSettings>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>

