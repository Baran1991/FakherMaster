<%@ Page Title="ارسال پیام جدید" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="pageCompose.aspx.cs" Inherits="Student_MessageBox_pageCompose" %>

<%@ Register TagPrefix="uc1" TagName="rMessageBox" Src="~/rComponents/rMessageBox/rMessageBox.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" >
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" Title="انتخاب مدرس"
                VisibleOnPageLoad="True" VisibleTitlebar="true" VisibleStatusbar="true" Visible="False"
                Height="500px" Width="500px" Style="z-index: 8001;" Behaviors="Close">
                <ContentTemplate>
                    <asp:Panel ID="Panel4" runat="server" Font-Names="Tahoma" Font-Size="12px">
                        <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False" OnItemDataBound="RadGrid1_ItemDataBound"
                            Font-Names="Tahoma" CellSpacing="0" GridLines="None">
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
                                    <telerik:GridTemplateColumn>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="FarsiFullname" HeaderText="نــام">
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                            </MasterTableView>
                            <ClientSettings EnablePostBackOnRowClick="False" EnableRowHoverStyle="False">
                                <Selecting AllowRowSelect="False" />
                            </ClientSettings>
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
                        </telerik:RadGrid>
                    </asp:Panel>
                    <asp:Panel ID="Panel5" runat="server" Font-Names="Tahoma" HorizontalAlign="Center">
                        <telerik:RadButton ID="rBtnTeacherSelect" runat="server" Text="انتخـاب" Font-Names="Tahoma"
                            OnClick="rBtnTeacherSelect_Click">
                        </telerik:RadButton>
                    </asp:Panel>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <uc1:rMessageBox ID="rMessageBox1" runat="server" OnDialogResult="rMessageBox1_DialogResult" />
    <asp:Label ID="Label5" runat="server" Text="پیـام جـدیـد" Font-Names="Tahoma" NavigateUrl="~/Instructor/MessageBox/Default.aspx"></asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" Font-Size="10pt">
        <table width="100%">
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White; width: 200px;">
                    <asp:Label ID="Label2" runat="server" Text="گیـرنـده:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">
                    <asp:TextBox ID="TxtReciever" runat="server" ReadOnly="True" Width="99%" Font-Names="Tahoma"></asp:TextBox>
                    <asp:LinkButton ID="lnkTeacherSelect" runat="server" OnClick="lnkTeacherSelect_Click">انتخاب مدرس</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White; width: 200px;">
                    <asp:Label ID="Label3" runat="server" Text="عنــوان:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">
                    <asp:TextBox ID="txtSubject" runat="server" Width="99%" Font-Names="Tahoma"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White; width: 200px;"
                    valign="top">
                    <asp:Label ID="Label4" runat="server" Text="متـن پیـام:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">
                    <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Width="99%"
                        Height="350px" Font-Names="Tahoma"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White; width: 200px;"
                    valign="top"></td>
                <td style="background-color: #4682B4; text-align: right; vertical-align: middle">
                    <telerik:RadButton ID="btnSend" runat="server" Text="ارسال" Font-Names="Tahoma" Width="150px"
                        OnClick="btnSend_Click">
                    </telerik:RadButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
