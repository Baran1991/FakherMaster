<%@ Page Title="ثبـت نام در آزمون مصاحبه" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="pageInterviewEnroll.aspx.cs" Inherits="Student_pageInterviewEnroll" %>

<%@ Register TagPrefix="uc1" TagName="rMessageBox" Src="~/rComponents/rMessageBox/rMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" OnDialogResult="rMessageBox1_DialogResult" />
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" Title="شرکت در آزمون مصاحبه"
                VisibleOnPageLoad="True" Width="600px" Height="200px" VisibleTitlebar="true"
                VisibleStatusbar="False" Visible="False" Style="z-index: 8001;" Behaviors="Close">
                <ContentTemplate>
                    <asp:Panel ID="Panel3" runat="server" Font-Names="Tahoma">
                        <table style="width: 98%; font-family: tahoma; font-size: 10pt;">
                            <tr>
                                <td style="width: 100px; text-align: left; background-color: #3772ab; color: #ffffff">
                                    <asp:Label ID="Label1" runat="server" Text="فـــرم آزمـــون:"></asp:Label>
                                </td>
                                <td style="background-color: #e5e6e6;">
                                    <telerik:RadComboBox ID="RadCmbExamForm" runat="server" Width="99%" DataValueField="Id"
                                        DataTextField="Name" Style="z-index: 8002">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; text-align: left; vertical-align: top; background-color: #3772ab;
                                    color: #ffffff">
                                    <asp:Label ID="Label2" runat="server" Text="زمـان آزمـــون:"></asp:Label>
                                </td>
                                <td style="background-color: #e5e6e6;">
                                    <telerik:RadComboBox ID="RadCmbExamFormation" runat="server" Width="99%" DataValueField="Id"
                                        DataTextField="FarsiText" Style="z-index: 8002">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                        </table>
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
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma">
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label7" runat="server" Text="مصاحبه های قابل ثبت نام" Font-Names="Tahoma"></asp:Label>
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
                    <telerik:GridBoundColumn DataField="Name" HeaderText="نــام آزمــون">
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
    <asp:Panel ID="pnlAbstract" runat="server" Visible="False" Font-Names="Tahoma" Font-Size="10pt">
        <table style="width: 70%; border: dashed 1px White; background: #009999; margin-left: auto;
            margin-right: auto">
            <tr>
                <td style="vertical-align: top; width: 68px; text-align: center; padding-right: 10px;">
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/offer_bulet.png" Height="64px"
                        Width="64px" />
                </td>
                <td style="vertical-align: top; text-align: justify">
                    <br />
                    <br />
                    <ul>
                        <li>
                            <asp:Label ID="Label010" runat="server" Text="دقت کنید،" Font-Names="Tahoma" Font-Size="14px"
                                ForeColor="White"></asp:Label>
                        </li>
                    </ul>
                    <ul>
                        <li>
                            <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px"
                                ForeColor="Orange" Text="برای تایید نهایی ثبت نام، حتما باید کارت ورود به آزمون خود را دریافت کنید. اگر به هر دلیل کارت ورود به آزمون خود را دریافت نکردید، ثبت نام شما تایید نهایی نخواهد شد."></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="Label022" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="14px"
                                ForeColor="Orange" Text="اگر به هر دلیل پرداخت اینترنتی خود را انجام ندهید، پس از مدت زمان 20 دقیقه ثبت نام گروههای شما به صورت خودکار از سیستم حذف خواهد شد"></asp:Label>
                        </li>
                    </ul>
                    <br />
                </td>
            </tr>
        </table>
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label3" runat="server" Text="خلاصه وضعیت ثبت نام در آزمون" Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width: 100px; text-align: left; background-color: #3772ab; color: #ffffff">
                    <asp:Label ID="Label4" runat="server" Text="نــام آزمون: " Font-Bold="True"></asp:Label>
                </td>
                <td style="background-color: #e5e6e6;">
                    <asp:Label ID="lblExam" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: left; background-color: #3772ab; color: #ffffff">
                    <asp:Label ID="Label5" runat="server" Text="فــرم آزمون: " Font-Bold="True"></asp:Label>
                </td>
                <td style="background-color: #e5e6e6;">
                    <asp:Label ID="lblExamForm" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: left; background-color: #3772ab; color: #ffffff">
                    <asp:Label ID="Label8" runat="server" Text="زمــان آزمون: " Font-Bold="True"></asp:Label>
                </td>
                <td style="background-color: #e5e6e6;">
                    <asp:Label ID="lblFormation" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Panel ID="Panel5" runat="server" Font-Names="Tahoma" HorizontalAlign="Center">
            <asp:Label ID="Label6" runat="server" Text="به منظور تکمیل ثبت نام، دکمه 'تایید و پرداخت' را کلیک کنید."
                Font-Size="11pt" Font-Bold="True" ForeColor="Red"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" HorizontalAlign="Center">
            <hr />
            <telerik:RadButton ID="RadButton1" runat="server" Text="<<  بازگشت به مرحله قبل"
                Font-Names="Tahoma" Width="210px" OnClick="btnPrev_Click">
            </telerik:RadButton>
            &&nbsp;
            <telerik:RadButton ID="btnPay" runat="server" Text="تایـیــد و پرداخت  >>" Font-Names="Tahoma"
                Width="210px" OnClick="btnPay_Click">
            </telerik:RadButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
