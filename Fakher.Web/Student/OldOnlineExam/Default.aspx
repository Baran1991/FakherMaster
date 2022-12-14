<%@ Page Title="شــروع آزمــون اینترنتی" Language="C#" MasterPageFile="~/Student/OnlineExam/ExamMasterPage.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Student_OnlineExam_Default" %>

<%@ Register Src="~/rComponents/rMessageBox/rSimpleMessageBox.ascx" TagName="rSimpleMessageBox"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TopContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rSimpleMessageBox ID="rSimpleMessageBox1" runat="server" />
    <asp:Panel ID="pnlMain" runat="server" Font-Names="Tahoma">
        <table style="width: 100%">
            <tr>
                <td style="width: 128px">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/fakherlogo.gif" Width="120px"
                        Height="120px" AlternateText="موسسه آموزش عالی فاخر" />
                </td>
                <td style="text-align: center; vertical-align: middle">
                    <asp:Label ID="lblExamName" runat="server" Text="نــام آزمون" Font-Size="20pt" Font-Bold="True"
                        ForeColor="#009999"></asp:Label>
                    <br />
                    <asp:Label ID="lblExamHolder" runat="server" Text="برگزار کننده" Font-Size="12pt"></asp:Label>
                </td>
                <td style="width: 128px">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/VezarateOlom-Logo.gif" AlternateText="وزارت علوم، تحقیقات و فناوری" />
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table style="width: 100%; font-size: 10pt;">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" style="margin: auto auto; width: 220px;">
                        <tr>
                            <td style="text-align: right; border-bottom: 1px solid #009999;">
                                <asp:Label ID="Label1" runat="server" Text="نــام: " Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: left; border-bottom: 1px solid #009999;">
                                <asp:Label ID="lblFirstname" runat="server" Text="Text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; border-bottom: 1px solid #009999;">
                                <asp:Label ID="Label2" runat="server" Text="نــام خانوادگـی: " Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: left; border-bottom: 1px solid #009999;">
                                <asp:Label ID="lblLastname" runat="server" Text="Text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; border-bottom: 1px solid #009999;">
                                <asp:Label ID="Label3" runat="server" Text="نــام پــدر: " Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: left; border-bottom: 1px solid #009999;">
                                <asp:Label ID="lblFatherName" runat="server" Text="Text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; border-bottom: 1px solid #009999;">
                                <asp:Label ID="Label4" runat="server" Text="شنـاسـه داوطلبـی: " Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: left; border-bottom: 1px solid #009999;">
                                <asp:Label ID="lblCode" runat="server" Text="Text"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0" style="margin: auto auto; width: 220px;">
                        <tr>
                            <td style="text-align: right; border-bottom: 1px solid #009999;">
                                <asp:Label ID="Label5" runat="server" Text="تاریخ شروع:" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: left; border-bottom: 1px solid #009999;">
                                <asp:Label ID="lblStartDate" runat="server" Text="Text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; border-bottom: 1px solid #009999;">
                                <asp:Label ID="Label6" runat="server" Text="زمان شروع:" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: left; border-bottom: 1px solid #009999;">
                                <asp:Label ID="lblStartTime" runat="server" Text="Text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; border-bottom: 1px solid #009999;">
                                <asp:Label ID="Label8" runat="server" Text="تاریخ پایان:" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: left; border-bottom: 1px solid #009999;">
                                <asp:Label ID="lblEndDate" runat="server" Text="Text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; border-bottom: 1px solid #009999;">
                                <asp:Label ID="Label10" runat="server" Text="زمان پایان:" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: left; border-bottom: 1px solid #009999;">
                                <asp:Label ID="lblEndTime" runat="server" Text="Text"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0" style="margin: auto auto; width: 220px;">
                        <tr>
                            <td style="text-align: right; border-bottom: 1px solid #009999;">
                                <asp:Label ID="Label7" runat="server" Text="تعداد سئوال:" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: left; border-bottom: 1px solid #009999;">
                                <asp:Label ID="lblQuestionCount" runat="server" Text="Text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; border-bottom: 1px solid #009999;">
                                <asp:Label ID="Label19" runat="server" Text="تعداد صفحات:" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: left; border-bottom: 1px solid #009999;">
                                <asp:Label ID="lblQuestionPageCount" runat="server" Text="Text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; border-bottom: 1px solid #009999;">
                                <asp:Label ID="Label9" runat="server" Text="نمــره منفی:" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: left; border-bottom: 1px solid #009999;">
                                <asp:Label ID="lblNegativePoint" runat="server" Text="Text"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; border-bottom: 1px solid #009999;">
                                <asp:Label ID="Label12" runat="server" Text="مدت پاسخگویـی:" Font-Bold="True"></asp:Label>
                            </td>
                            <td style="text-align: left; border-bottom: 1px solid #009999;">
                                <asp:Label ID="lblDuration" runat="server" Text="Text"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server" Font-Names="Tahoma" Direction="RightToLeft"
        Font-Size="11pt">
        <table style="width: 100%">
            <tr>
                <td style="background-color: #3772ab; color: #ffffff">
                    <asp:Label ID="Label11" runat="server" Text="راهنمای شرکت در آزمون (حتما کامل مطالعه کنید)"
                        Font-Names="Tahoma" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #e5e6e6; text-align: justify">
                    <ul>
                        <li>
                            <asp:Label ID="Label13" runat="server" Text="هر سئوال، دارای 4 گزینه است. هر سئوال فقط یک پاسخ صحیح دارد."
                                Font-Size="11pt"></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="Label14" runat="server" Text="برای انتخاب پاسخ، روی دایره کنار هر سئوال کلیک کنید تا دایره به صورت توپر درآید."
                                Font-Size="11pt"></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="Label16" runat="server" Text="سئوالات به صورت صفحه به صفحه نمایش داده خواهند شد. به سئوالات هر صفحه پاسخ دهید و سپس به صفحه بعد بروید."
                                Font-Size="11pt"></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="Label15" runat="server" Text="در پایین هر صفحه یک دکمه برای رفتن به صفحه بعد، و یک دکمه برای بازگشت به صفحه قبل وجود دارد. می توانید به صفحات قبل بازگردید و جواب های خود را تصحیح کنید."
                                Font-Size="11pt"></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="Label20" runat="server" Text="برای رفتن به صفحه بعد یا قبل به هیچ وجه از دکمه های Back یا Next مرورگر خود استفاده نکنید!! فقط از دکمه های پایین هر صفحه آزمون استفاده کنید. تاکید میشود: به هیچ وجه از دکمه های Back و Next مرورگر خود استفاده نکنید."
                                Font-Size="11pt" Font-Bold="True"></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="Label27" runat="server" Text="اگر در حین آزمون با خطایی مواجه شدید، صفحه خود را Refresh کنید."
                                Font-Size="11pt"></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="Label24" runat="server" Text="در بالای صفحه سمت چپ، زمان باقیمانده از آزمون شما نمایش داده می شود، همواره به این زمان توجه داشته باشید."
                                Font-Size="11pt"></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="Label21" runat="server" Text="پس از پایان پاسخگویی به سئوالات، ابتدا یک خلاصه از وضعیت آزمون به شما نمایش داده می شود. در صورت نیاز می توانید به صفحات قبل برگردید و پاسخهای خود را تصحیح یا تغییر دهید. در غیر این صورت برای ثبت پاسخهای شما باید حتما آزمون را ثبت نهایی نمایید"
                                Font-Size="11pt"></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="Label26" runat="server" Text="به تعداد پاسخ های خالی (جواب نداده خود) دقت کنید و در صورتیکه پاسخ های شما ثبت نشده است، مجددا به آن صفحه برگردید و پاسخ ها را ثبت کنید."
                                Font-Size="11pt" Font-Bold="True"></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="Label23" runat="server" Text="برای ثبت پاسخهای شما در سیستم، باید حتما در مرحله آخر آزمون را ثبت نهایی نمایید"
                                Font-Size="11pt"></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="Label25" runat="server" Text="پس از پایان زمان آزمون، فقط می توانید پاسخ های خود را ثبت کنید و دیگر نمی توانید به پاسخگویی به سئوالات ادامه دهید."
                                Font-Size="11pt"></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="Label22" runat="server" Text="شروع آزمون بر اساس زمان سـرور محاسبه می گردد. بنابراین به زمان سرور توجه کنید."
                                Font-Size="11pt"></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="Label18" runat="server" Text="حتما مشخصات خود را با مشخصات مندرج در جدول فوق تطبیق دهید و از صحت و درستی آن مطمئن شوید."
                                Font-Size="11pt"></asp:Label>
                        </li>
                        <li>
                            <asp:Label ID="Label17" runat="server" Text="با فرا رسیدن زمان شروع آزمون، دکمه شروع آزمون کلیک کنید. حتما در مرحله آخر آزمون را ثبت نهایی نمایید."
                                Font-Bold="true" Font-Size="11pt"></asp:Label>
                        </li>
                    </ul>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" Direction="RightToLeft"
        HorizontalAlign="Center">
        <asp:Button ID="btnStartExam" runat="server" Text="شـــروع آزمـــــون" OnClick="btnStartExam_Click"
            Font-Names="Tahoma" Width="200px" />
    </asp:Panel>
    <div style="display: none">
        <iframe id="defibrillator" src="pageDefibrillator.aspx" frameborder="0" width="0"
            height="0"></iframe>
    </div>
</asp:Content>
