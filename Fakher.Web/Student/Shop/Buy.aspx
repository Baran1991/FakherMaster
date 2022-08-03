<%@ Page Title="خرید اینترنتی جزوه و کتاب" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="Buy.aspx.cs" Inherits="Student_Shop_Buy" %>

<%@ Register TagPrefix="uc1" TagName="rMessageBox" Src="~/rComponents/rMessageBox/rMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" />
    <asp:Label ID="Label3" runat="server" Text="خرید اینترنتی جزوه و کتاب" Font-Names="Tahoma"
        Font-Size="10pt"></asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <table style="width: 200px; height: 37px;">
        <tr>
            <td class="heading">
                <asp:Label ID="Label1" runat="server" Text="کتاب های قابل خرید" Font-Names="Tahoma"
                    Font-Size="10pt"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" OnItemDataBound="RadGrid1_ItemDataBound"
            Font-Names="Tahoma" CellSpacing="0" GridLines="None">
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" Font-Names="Tahoma">
            </HeaderContextMenu>
            <MasterTableView DataKeyNames="Id" Dir="RTL" NoMasterRecordsText="کتابی برای نمایش وجود ندارد">
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
                    <telerik:GridBoundColumn DataField="Name" HeaderText="نام">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SellPrice" HeaderText="قیمت" DataFormatString="{0:C0}">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="StatusText" HeaderText="وضعیت">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <telerik:RadButton ID="btnAddToCart" runat="server" Text="اضافه به سبد خرید" Font-Names="Tahoma"
                                Width="150px" OnClick="btnAddToCart_Click">
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
    <table style="width: 200px; height: 37px;">
        <tr>
            <td class="heading">
                <asp:Label ID="Label2" runat="server" Text="سبد خرید سفارش شما" Font-Names="Tahoma"
                    Font-Size="10pt"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel3" runat="server">
        <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False" OnItemDataBound="RadGrid1_ItemDataBound"
            Font-Names="Tahoma" CellSpacing="0" GridLines="None">
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" Font-Names="Tahoma">
            </HeaderContextMenu>
            <MasterTableView DataKeyNames="Id" Dir="RTL" NoMasterRecordsText="سبد خرید سفارش شما خالی است">
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
                    <telerik:GridBoundColumn DataField="Name" HeaderText="نام">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SellPrice" HeaderText="قیمت" DataFormatString="{0:C0}">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn>
                        <ItemTemplate>
                            <telerik:RadButton ID="btnRemove" runat="server" Text="حـــــذف" Font-Names="Tahoma"
                                Width="150px" OnClick="btnRemove_Click">
                                <Icon SecondaryIconUrl="~/images/Delete.png"></Icon>
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
    <br />
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center" Font-Names="Tahoma"
        Font-Size="14px">
        <asp:Label ID="Label8" runat="server" Text="مبلـــغ قـابـل پــرداخـت: "></asp:Label>
        <asp:Label ID="lblPayableAmout" runat="server" Text="Label" Font-Bold="True"></asp:Label>
    </asp:Panel>
    <hr />
    <asp:Panel ID="Panel5" runat="server" HorizontalAlign="Center">
        <telerik:RadButton ID="btnPay" runat="server" Text="پرداخت آنلاین >>" Font-Names="Tahoma"
            Width="210px" OnClick="btnPay_Click">
        </telerik:RadButton>
    </asp:Panel>
</asp:Content>
