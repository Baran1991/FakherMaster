<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MajorSections.ascx.cs" Inherits="Components_MajorSections" %>
<asp:Panel ID="Panel1" runat="server">
    <table style="width: 200px; height: 37px;">
        <tr>
            <td class="heading">
                <asp:Label ID="Label1" runat="server" Text="نــام رشتـه" Font-Names="Tahoma"></asp:Label>
            </td>
        </tr>
    </table>
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" OnItemDataBound="RadGrid1_ItemDataBound"
        Font-Names="Tahoma">
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" Font-Names="Tahoma">
        </HeaderContextMenu>
        <MasterTableView DataKeyNames="Id" Dir="RTL" NoMasterRecordsText="هیچ گـروهـی در این رشته ارائه نشده است">
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
                <telerik:GridBoundColumn DataField="ItemsText" HeaderText="درس/سـطــح">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FarsiName" HeaderText="گـــروه">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FarsiFormationText" HeaderText="زمان برگزاری">
                </telerik:GridBoundColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
    </telerik:RadGrid>
</asp:Panel>
