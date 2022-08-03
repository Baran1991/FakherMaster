<%@ Page Title="جلسات مشاوره حضوری" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Student_ConsultationSession_Default" %>

<%@ Register TagPrefix="uc1" TagName="rMessageBox" Src="~/rComponents/rMessageBox/rMessageBox.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" />
        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" Title="شرکت در مشاوره حضوری"
                VisibleOnPageLoad="True" Width="600px" Height="200px" VisibleTitlebar="true"
                VisibleStatusbar="False" Visible="False" Style="z-index: 8001;" Behaviors="Close">
                <ContentTemplate>
                    <asp:Panel ID="Panel3" runat="server" Font-Names="Tahoma">
                        <table style="width: 98%; font-family: tahoma; font-size: 10pt;">
                            <tr>
                                <td style="width: 100px; text-align: left; background-color: #3772ab; color: #ffffff">
                                    <asp:Label ID="Label1" runat="server" Text="زمان مشاوره:"></asp:Label>
                                </td>
                                <td style="background-color: #e5e6e6;">
                                    <telerik:RadComboBox ID="RadCmbFormation" runat="server" Width="99%" DataValueField="Id"
                                        DataTextField="Time" Style="z-index: 8002">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hfSession" runat="server" />
                        <br />
                        <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center" Font-Names="Tahoma">
                            <telerik:RadButton ID="radBtnOk" runat="server" Text="انتخـاب" Font-Names="Tahoma"
                                Width="95px" OnClick="radBtnOk_Click">
                            </telerik:RadButton>
                            <telerik:RadButton ID="radBtnCancel" runat="server" Text="انصـراف" Font-Names="Tahoma"
                                Width="95px" OnClick="radBtnCancel_Click" CausesValidation="False">
                            </telerik:RadButton>
                        </asp:Panel>
                    </asp:Panel>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <table style="width: 200px; height: 37px;">
        <tr>
            <td class="heading">
                <asp:Label ID="Label5" runat="server" Text="جلسات مشاوره حضوری" Font-Names="Tahoma" Font-Size="10pt"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" OnItemDataBound="RadGrid1_ItemDataBound"
            Font-Names="Tahoma" CellSpacing="0" GridLines="None">
<%--            <ItemStyle CssClass="CustomStyle"></ItemStyle>--%>
<%--            <AlternatingItemStyle CssClass="CustomStyle"></AlternatingItemStyle>--%>
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
                    <telerik:GridBoundColumn DataField="Name" HeaderText="نــام">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="HoldingDate" HeaderText="تاریخ برگزاری">
                    </telerik:GridBoundColumn>
                     <telerik:GridTemplateColumn HeaderText="">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnCommand" Font-Names="Tahoma" Width="125px" OnClick="btn_Click" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
<%--            <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="True">--%>
<%--                <Selecting AllowRowSelect="True" />--%>
<%--            </ClientSettings>--%>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
        </telerik:RadGrid>
    </asp:Panel>

</asp:Content>

