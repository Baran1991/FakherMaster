<%@ Page Title="ثبت نـام در آزمــون" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="pageExamEnroll.aspx.cs" Inherits="Student_pageExamEnroll" %>

<%@ Register Src="~/rComponents/rMessageBox/rMessageBox.ascx" TagName="rMessageBox"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" OnDialogResult="rMessageBox1_DialogResult" />
    <asp:Panel ID="pnlStep0" runat="server" Visible="false" Font-Names="Tahoma">
        <div>
            <table style="width: 70%; border: dashed 1px White; background: #009999; margin-left: auto;
                margin-right: auto">
                <tr>
                    <td style="vertical-align: top; width: 68px; text-align: center; padding-right: 10px;">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/offer_bulet.png" Height="64px"
                            Width="64px" />
                    </td>
                    <td style="vertical-align: top; text-align: justify">
                        <br />
                        <br />
                        <ul>
                            <li>
                                <asp:Label ID="Label10" runat="server" Text="دانشجوی گرامی،" Font-Names="Tahoma"
                                    Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label21" runat="server" Text="فـرآیند ثبت نام در آزمون در 2 مرحله ساده انجام می شود؛"
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                        </ul>
                        <ol style="margin-right: 50px">
                            <li>
                                <asp:Label ID="Label13" runat="server" Text="انتخاب آزمــون هـا" Font-Names="Tahoma"
                                    Font-Size="14px" ForeColor="White" Font-Bold="True"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label14" runat="server" Text="پــرداخت اینترنتی شهریه" Font-Names="Tahoma"
                                    Font-Size="14px" ForeColor="White" Font-Bold="True"></asp:Label>
                            </li>
                        </ol>
                        <ul>
                            <li>
                                <asp:Label ID="Label17" runat="server" Text="پس از پایان هر مرحله آن را تایید کرده و به مرحله بعد بروید"
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label16" runat="server" Text="در هر مرحله امکان بازگشت به مرحله قبل را خواهید داشت"
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label20" runat="server" Text="دقت کنید که پس از پایان مرحله پرداخت اینترنتی دیگر امکان تغییر در موارد انتخاب شده وجود ندارد"
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label15" runat="server" Text="اکنون شما در مرحله یک قرار دارید؛ آزمـون های خود را با دقت انتخاب کنید."
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                        </ul>
                        <br />
                    </td>
                </tr>
            </table>
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
                            <li>
                                <asp:Label ID="Label021" runat="server" Text=" اگر در مرحله پرداخت اینترنتی، به مشکل برخورد کردید؛ مجددا به همین سایت برگردید، به سیستم آموزش وارد شوید و مجددا دکمه ثبت نام در آزمون را بزنید. انتخاب های قبلی شما هنوز در سیستم ثبت هستند و می توانید مجددا به مرحله پرداخت اینترنتی بروید و مجددا برای پرداخت تلاش کنید."
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label022" runat="server" Text="اگر به هر دلیل پرداخت اینترنتی خود را انجام ندهید، پس از مدت زمان 20 دقیقه ثبت نام آزمون های شما به صورت خودکار از سیستم حذف خواهد شد"
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="Orange" Font-Bold="True"></asp:Label>
                            </li>
                        </ul>
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label12" runat="server" Text="انتخـاب آزمـــون هـا" Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
        </table>
        <table style="width: 100%">
            <tr>
                <td>
                    <table width="100%" cellpadding="0" cellspacing="0" style="font-family: Tahoma">
                        <tr style="height: 25px;">
                            <td style="border-top: 1px solid; border-bottom: 1px solid; text-align: center">
                            </td>
                            <td style="border-top: 1px solid; border-bottom: 1px solid; text-align: right">
                                <asp:Label ID="Label1" runat="server" Text="نـام آزمون"></asp:Label>
                            </td>
                            <td style="border-top: 1px solid; border-bottom: 1px solid; text-align: center">
                                <asp:Label ID="Label3" runat="server" Text="شروع آزمون"></asp:Label>
                            </td>
                            <td style="border-top: 1px solid; border-bottom: 1px solid; text-align: center">
                                <asp:Label ID="Label4" runat="server" Text="پایان آزمون"></asp:Label>
                            </td>
                        </tr>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <tr style="height: 25px; vertical-align: middle" onmouseover="this.style.backgroundColor='#E1EAFE';"
                                    onmouseout="this.style.backgroundColor='transparent';">
                                    <td style="border-bottom: 1px solid #000000; text-align: justify">
                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                        <asp:HiddenField ID="hFieldId" runat="server" Value='<%# Eval("Id") %>' />
                                    </td>
                                    <td style="border-bottom: 1px solid #000000; text-align: justify">
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Name") %>' Font-Names="Tahoma"
                                            Font-Size="10pt" Font-Bold="false"></asp:Label>
                                    </td>
                                    <td style="border-bottom: 1px solid #000000; text-align: center; direction: ltr">
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("ExamHolding.StartDate") + " - " + Eval("ExamHolding.StartTime") %>'
                                            Font-Names="Tahoma" Font-Size="10pt" Font-Bold="false"></asp:Label>
                                    </td>
                                    <td style="border-bottom: 1px solid #000000; text-align: center; direction: ltr">
                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("ExamHolding.EndDate") + " - " + Eval("ExamHolding.EndTime") %>'
                                            Font-Names="Tahoma" Font-Size="10pt" Font-Bold="false"></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    &&nbsp;
                    <br/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="chkPolicy" runat="server" Text="کلیه مفاد و شرایط ثبت نام در آزمون های موسسه فاخر را می پذیرم و متعهد به اجرای تمام و کمال آن می باشم." />
                </td>
            </tr>
        </table>
        <asp:Panel ID="Panel6" runat="server" HorizontalAlign="Center">
            <hr />
            <telerik:RadButton ID="RadButton3" runat="server" Text="تایـیــد و ادامــه  >>" Font-Names="Tahoma"
                Width="210px" OnClick="btnNext0_Click">
            </telerik:RadButton>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="pnlStep1" runat="server" Visible="false">
        <div>
            <table style="width: 70%; border: dashed 1px White; background: #009999; margin-left: auto;
                margin-right: auto">
                <tr>
                    <td style="vertical-align: top; width: 68px; text-align: center; padding-right: 10px;">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/offer_bulet.png" Height="64px"
                            Width="64px" />
                    </td>
                    <td style="vertical-align: top; text-align: justify">
                        <br />
                        <br />
                        <ul>
                            <li>
                                <asp:Label ID="Label5" runat="server" Text="در این مرحله، خلاصه ای از آنچه شما انتخاب کرده اید را مشاهده می کنید؛"
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label6" runat="server" Text="اگر این خلاصه مورد تایید است، آن را تایید کنید و به مرحله پرداخت اینترنتی بروید"
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label19" runat="server" Text="اگر این خلاصه مورد تایید نیست، به مرحله قبل بازگردید و آن را تصحیح کنید"
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                        </ul>
                        <br />
                    </td>
                </tr>
            </table>
            <table style="width: 70%; border: dashed 1px White; background: #009999; margin-left: auto;
                margin-right: auto">
                <tr>
                    <td style="vertical-align: top; width: 68px; text-align: center; padding-right: 10px;">
                        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/offer_bulet.png" Height="64px"
                            Width="64px" />
                    </td>
                    <td style="vertical-align: top; text-align: justify">
                        <br />
                        <br />
                        <ul>
                            <li>
                                <asp:Label ID="Label23" runat="server" Text="دقت کنید،" Font-Names="Tahoma" Font-Size="14px"
                                    ForeColor="White" Font-Bold="True"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label24" runat="server" Text=" اگر در مرحله پرداخت اینترنتی، به مشکل برخورد کردید؛ مجددا به همین سایت برگردید، به سیستم آموزش وارد شوید و مجددا دکمه ثبت نام جدید را بزنید. انتخاب های قبلی شما هنوز در سیستم ثبت هستند و می توانید مجددا به مرحله پرداخت اینترنتی بروید و مجددا برای پرداخت تلاش کنید."
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label25" runat="server" Text="دقت کنید که اگر به هر دلیل پرداخت اینترنتی خود را انجام ندهید، پس از مدت زمان 20 دقیقه ثبت نام گروههای شما به صورت خودکار از سیستم حذف خواهد شد"
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="Orange" Font-Bold="True"></asp:Label>
                            </li>
                        </ul>
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label7" runat="server" Text="خلاصه وضعیت ثبت نـام" Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
        </table>
        <telerik:RadGrid ID="RadGrid3" runat="server" AutoGenerateColumns="False" OnItemDataBound="RadGrid1_ItemDataBound"
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
                    <telerik:GridBoundColumn DataField="ExamHolding.StartDate" HeaderText="شروع آزمــون">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="ExamHolding.EndDate" HeaderText="پایان آزمــون">
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
        <br />
        <asp:Panel ID="Panel5" runat="server" HorizontalAlign="Center" Font-Names="Tahoma"
            Font-Size="12px">
            <asp:Label ID="Label8" runat="server" Text="شهـــریـه قـابـل پــرداخـت: "></asp:Label>
            <asp:Label ID="lblPayableAmout" runat="server" Text="Label" Font-Bold="True"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" HorizontalAlign="Center">
            <br />
            <br />
            <hr />
            <telerik:RadButton ID="btnPrev" runat="server" Text="<<  بازگشت به مرحله قبل" Font-Names="Tahoma"
                Width="210px" OnClick="btnPrev_Click">
            </telerik:RadButton>
            &&nbsp;
            <telerik:RadButton ID="btnNext2" runat="server" Text="تایید نهـایــی و پرداخت اینترنتی >>"
                Font-Names="Tahoma" Width="210px" OnClick="btnNext2_Click">
            </telerik:RadButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
