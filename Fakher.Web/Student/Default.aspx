<%@ Page Title="پنــل سیستـم آمـوزش دانشـجــو" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Student_Default"
    Culture="fa-IR" %>

<%@ Register Src="~/UserControls/StudentTopPanel.ascx" TagName="StudentTopPanel"
    TagPrefix="uc1" %>
<%--<%@ Register Src="~/rComponents/rMessageBox/rMessageBox.ascx" TagName="rMessageBox"
    TagPrefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <%--<uc1:rMessageBox ID="rMessageBox1" runat="server" />--%>
    <asp:Label ID="Label3" runat="server" Text="پنــل سیستـم آمـوزش دانشـجــو" Font-Names="Tahoma" Font-Size="10pt"></asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <uc1:StudentTopPanel ID="StudentTopPanel1" runat="server" OnRegisterChanged="StudentTopPanel1_OnRegisterChanged" />
    <asp:Panel ID="pnlAnnouncement" runat="server" Visible="False">
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label7" runat="server" Text="اطــلاعیــــه" Font-Names="Tahoma" Font-Size="10pt"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblAnnouncement" runat="server"
                        Font-Names="Tahoma" ForeColor="#000066"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server">
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
                    <asp:Label ID="Label4" runat="server" Text="برای مشاهده یا انجام امور مربوط به هر گروه، برروی نام آن گروه کلیک کنید و از منوی پیش رو امور آموزشی خود را انتخاب کنید"
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
                    
                    <telerik:GridBoundColumn DataField="SectionItem.Lesson.Name" HeaderText="نــام درس/سـطــح">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SectionItem.Section.FarsiName" HeaderText="گـــروه">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="StatusText" HeaderText="وضعیت آموزشی">
                    </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn Text="مشاهده" > </telerik:GridButtonColumn>
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
    <br />
    <asp:Panel ID="Panel2" runat="server">
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label2" runat="server" Text="آزمـون هـای کتبی" Font-Names="Tahoma" Font-Size="10pt"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="برای مشاهده یا انجام امور مربوط به هر آزمون، بر روی نام آن آزمــون کلیک کنید و از منوی پیش رو امور آزمون خود را انتخاب کنید"
                        Font-Names="Tahoma" ForeColor="#006400"></asp:Label>
                </td>
            </tr>
        </table>
        <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="RadGrid2_SelectedIndexChanged"
            OnItemDataBound="RadGrid2_ItemDataBound" Font-Names="Tahoma">
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
                    <telerik:GridBoundColumn DataField="ExamForm.Exam.Name" HeaderText="نــام آزمـــون">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExamForm.Exam.FarsiTypeText" HeaderText="نـوع آزمـــون">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SeatNumber" HeaderText="شماره آزمـــون/شماره صندلی">
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
    <br />
    <asp:Panel ID="Panel3" runat="server">
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label6" runat="server" Text="آزمـون هـای آنلاین" Font-Names="Tahoma" Font-Size="10pt"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Size="10pt" NavigateUrl="http://azmoon.fakher.ac.ir" Target="_blank">
                        برای شرکت در آزمون آنلاین یا مشاهده کارنامه آزمونهای آنلاین، اینجا را کلیک کنید. در سیستم آزمون آنلاین نام کاربری شما، شماره دانشجویی و رمزعبور، شماره شناسنامه شما خواهد بود. دقت کنید که نام کاربری و رمزعبور شما در سیستم آموزش (همین وب سایت) و سیستم آزمون آنلاین متفاوت است.
                    </asp:HyperLink>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
