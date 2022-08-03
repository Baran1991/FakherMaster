<%@ Page Title="ثبت نام کلـاسـی جدید" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="pageSectionEnroll.aspx.cs" Inherits="Student_pageSectionEnroll" %>

<%@ Register Src="~/rComponents/rMessageBox/rMessageBox.ascx" TagName="rMessageBox"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
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
                                <asp:Label ID="Label21" runat="server" Text="فـرآیند ثبت نام در 3 مرحله ساده انجام می شود؛"
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                        </ul>
                        <ol style="margin-right: 50px">
                            <li>
                                <asp:Label ID="Label11" runat="server" Text="انتخاب رشته ثبت نامی" Font-Names="Tahoma"
                                    Font-Size="14px" ForeColor="White" Font-Bold="True"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label13" runat="server" Text="انتخاب گــروه های درسی" Font-Names="Tahoma"
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
                                <asp:Label ID="Label20" runat="server" Text="دقت کنید که پس از پایان مرحله پرداخت اینترنتی دیگر امکان تغییر در گـروه های انتخاب شده وجود ندارد"
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label15" runat="server" Text="اکنون شما در مرحله یک قرار دارید؛ رشته ثبت نامی خود را با دقت انتخاب کنید."
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
                                <asp:Label ID="Label021" runat="server" Text=" اگر در مرحله پرداخت اینترنتی، به مشکل برخورد کردید؛ مجددا به همین سایت برگردید، به سیستم آموزش وارد شوید و مجددا دکمه ثبت نام در کلاس را بزنید. انتخاب های قبلی شما به مدت 20 دقیقه در سیستم ثبت هستند و می توانید مجددا به مرحله پرداخت اینترنتی بروید و مجددا برای پرداخت تلاش کنید."
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label26" runat="server" Text="برای تایید نهایی ثبت نام، حتما باید رسید ثبت نام خود را دریافت کنید. اگر به هر دلیل رسید ثبت نام خود را دریافت نکردید، ثبت نام شما تایید نهایی نخواهد شد."
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="Orange" Font-Bold="True"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label022" runat="server" Text="اگر به هر دلیل پرداخت اینترنتی خود را انجام ندهید، پس از مدت زمان 20 دقیقه ثبت نام گروههای شما به صورت خودکار از سیستم حذف خواهد شد"
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="Orange" Font-Bold="True"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label27" runat="server" Text="برای رفتن به صفحه بعد یا قبل به هیچ وجه از دکمه های Back یا Next مرورگر خود استفاده نکنید!! فقط از دکمه های پایین صفحه استفاده کنید. تاکید میشود: به هیچ وجه از دکمه های Back و Next مرورگر خود استفاده نکنید."
                                    Font-Size="11pt" Font-Bold="True"></asp:Label>
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
                    <asp:Label ID="Label12" runat="server" Text="انتخـاب رشـتــه" Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
        </table>
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="رشتــه/تـرم/سطح ثبت نامی:"></asp:Label>
                    <telerik:RadComboBox ID="rCmbLicense" runat="server" Width="100%" Font-Names="Tahoma">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="chkPolicy" runat="server" Text="کلیه مفاد و شرایط ثبت نام در موسسه را می پذیرم و متعهد به اجرای تمام و کمال آن در طول تحصیل در موسسه می باشم." />
                </td>
            </tr>
        </table>
        <asp:Panel ID="Panel6" runat="server" HorizontalAlign="Center">
            <br />
            <br />
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
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/offer_bulet.png" Height="64px"
                            Width="64px" />
                    </td>
                    <td style="vertical-align: top; text-align: justify">
                        <br />
                        <br />
                        <ul>
                            <li>
                                <asp:Label ID="Label1" runat="server" Text="در جـدول بالا، لیست گـروه هایی که برای شما قابل اخذ می باشند را مشاهده می کنید. لیست پایین شامل گـروه هایی است که شما اخذ کرده اید."
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label2" runat="server" Text="برای انتخاب یک گـروه، ابتدا روی آن در لیست بالا کلیک کنید و آن را انتخاب نمایید. سپس دکمه اخذ را فشار دهید، کمی منتظر باشید تا گـروه به لیست پایین اضافه گردد"
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label18" runat="server" Text="برای حـذف یک گـروه، ابتدا روی آن در لیست پایین کلیک کنید و آن را انتخاب نمایید. سپس دکمه حذف از لیست پایین را فشار دهید، کمی منتظر باشید تا گـروه از لیست پایین حذف گردد"
                                    Font-Names="Tahoma" Font-Size="14px" ForeColor="White"></asp:Label>
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
                    <asp:Label ID="Label3" runat="server" Text="گـــروه های قابل اخــذ" Font-Names="Tahoma"></asp:Label>
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
                    <telerik:GridBoundColumn DataField="Lesson.Name" HeaderText="نــام درس/سـطــح">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Section.FarsiName" HeaderText="نـام گـــروه">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="RemainderCount" HeaderText="ظرفیت">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Section.FarsiFormationText" HeaderText="زمان برگزاری">
                    </telerik:GridBoundColumn>
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
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
            <telerik:RadButton ID="btnSubmit" runat="server" Text="اخــــذ" Font-Names="Tahoma"
                Width="150px" OnClick="btnSubmit_Click">
                <Icon SecondaryIconUrl="~/images/Plus.png"></Icon>
            </telerik:RadButton>
        </asp:Panel>
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label4" runat="server" Text="گـــروه های اخــذ شده" Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
        </table>
        <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="False" OnItemDataBound="RadGrid1_ItemDataBound"
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
                    <telerik:GridBoundColumn DataField="SectionItem.Lesson.Name" HeaderText="نــام درس/سـطــح">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SectionItem.Section.FarsiName" HeaderText="نـام گـــروه">
                    </telerik:GridBoundColumn>
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
        <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Left">
            <telerik:RadButton ID="btnRemove" runat="server" Text="حـــــذف" Font-Names="Tahoma"
                Width="150px" OnClick="btnRemove_Click">
                <Icon SecondaryIconUrl="~/images/Delete.png"></Icon>
            </telerik:RadButton>
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server" HorizontalAlign="Center">
            <br />
            <br />
            <hr />
            <telerik:RadButton ID="RadButton1" runat="server" Text="<<  بازگشت به مرحله قبل"
                Font-Names="Tahoma" Width="210px" OnClick="btnPrev_Click">
            </telerik:RadButton>
            &&nbsp;
            <telerik:RadButton ID="btnNext" runat="server" Text="تایـیــد و ادامــه  >>" Font-Names="Tahoma"
                Width="210px" OnClick="btnNext_Click">
            </telerik:RadButton>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="pnlStep2" runat="server" Visible="false">
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
                    <telerik:GridBoundColumn DataField="SectionItem.Lesson.Name" HeaderText="نــام درس/سـطــح">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SectionItem.Section.FarsiName" HeaderText="نـام گـــروه">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SectionItem.Section.FarsiFormationText" HeaderText="زمان برگزاری">
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
