<%@ Page Title="درخواست ها" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="pageRequest.aspx.cs" Inherits="Student_pageRequest" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.ReportViewer.WebForms" Assembly="Telerik.ReportViewer.WebForms, Version=5.1.11.713, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" Title="درخواست" VisibleOnPageLoad="True"
                Width="600px" Height="420px" VisibleTitlebar="true" VisibleStatusbar="False"
                Visible="False" Style="z-index: 200001;" Behaviors="Close">
                <ContentTemplate>
                    <table style="width: 98%; font-family: tahoma; font-size: 10pt;">
                        <tr>
                            <td style="width: 100px; text-align: left; background-color: #3772ab; color: #ffffff">
                                <asp:Label ID="Label1" runat="server" Text="عنوان درخواست:"></asp:Label>
                            </td>
                            <td style="background-color: #e5e6e6;">
                                <telerik:RadTextBox ID="RadTxtTitle" runat="server" Width="100%" Font-Names="Tahoma">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                    ControlToValidate="RadTxtTitle" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: left; vertical-align: top; background-color: #3772ab;
                                color: #ffffff">
                                <asp:Label ID="Label2" runat="server" Text="متن درخواست:"></asp:Label>
                            </td>
                            <td style="background-color: #e5e6e6;">
                                <telerik:RadTextBox ID="RadTxtText" runat="server" Width="100%" TextMode="MultiLine"
                                    Font-Names="Tahoma" Height="300px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="RadTxtText" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <table id="resultTable" runat="server" style="width: 90%; margin-left: auto; margin-right: auto;">
                        <tr>
                            <td style="background-color: #3772ab; color: #ffffff">
                                <asp:Label ID="Label11" runat="server" Text="نتیجـه شورای آموزش" Font-Names="Tahoma"
                                    Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #e5e6e6;">
                            <td style="font-family: tahoma; font-size: 11pt; padding-right: 10px; padding-left: 10px;
                                text-align: justify;">
                                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center" Font-Names="Tahoma">
                        <telerik:RadButton ID="radBtnOk" runat="server" Text="تایـیــد" Font-Names="Tahoma"
                            Width="95px" OnClick="radBtnOk_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="radBtnCancel" runat="server" Text="انصـراف" Font-Names="Tahoma"
                            Width="95px" CausesValidation="False">
                        </telerik:RadButton>
                    </asp:Panel>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged"
        OnItemDataBound="RadGrid1_ItemDataBound" Font-Names="Tahoma">
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
                <telerik:GridBoundColumn DataField="Date" HeaderText="تاریخ ثبت">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Title" HeaderText="عنوان">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="StatusText" HeaderText="وضعیت">
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
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
        <telerik:RadButton ID="btnNewRequest" runat="server" Text="درخواست جــدیــد" Font-Names="Tahoma"
            Width="150px" OnClick="btnNewRequest_Click" Visible="True">
            <Icon SecondaryIconUrl="~/images/Plus.png"></Icon>
        </telerik:RadButton>
    </asp:Panel>
</asp:Content>
