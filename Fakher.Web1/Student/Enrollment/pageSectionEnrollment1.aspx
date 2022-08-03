<%@ Page Title="شروع ثبت نام اینترنتی" Language="C#" MasterPageFile="~/Student/Enrollment/EnrollmentMasterPage.master"
    AutoEventWireup="true" CodeFile="pageSectionEnrollment1.aspx.cs" Inherits="Student_Enrollment_pageStartEnrollment" %>

<%@ Register TagPrefix="uc1" TagName="rSimpleMessageBox" Src="~/rComponents/rMessageBox/rSimpleMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <asp:Panel ID="pnlStep0" runat="server" Visible="True" Font-Names="Tahoma">
        <asp:Panel ID="Panel2" runat="server" Font-Names="Tahoma" Direction="RightToLeft"
            Font-Size="11pt">
            <table style="width: 100%">
                <tr>
                    <td style="background-color: #3772ab; color: #ffffff">
                        <asp:Label ID="Label1" runat="server" Text="راهنمای ثبت نام اینترنتی (مرحله 1) (حتما کامل مطالعه کنید)"
                            Font-Names="Tahoma" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #e5e6e6; text-align: justify; color: #000000">
                        <asp:Label ID="Label2" runat="server" Text="دانشجوی گرامی،" Font-Names="Tahoma" Font-Size="14px"></asp:Label>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="فـرآیند ثبت نام در 3 مرحله انجام می شود؛"
                            Font-Names="Tahoma" Font-Size="14px"></asp:Label>
                        <ol style="margin-right: 50px">
                            <li>
                                <asp:Label ID="Label11" runat="server" Text="انتخاب زمان بندی ثبت نام مناسب" Font-Names="Tahoma"
                                    Font-Size="14px" Font-Bold="True"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label13" runat="server" Text="انتخاب گــروه و کلاس درسی" Font-Names="Tahoma"
                                    Font-Size="14px" Font-Bold="True"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label14" runat="server" Text="پــرداخت اینترنتی شهریه" Font-Names="Tahoma"
                                    Font-Size="14px" Font-Bold="True"></asp:Label>
                            </li>
                        </ol>
                        <ul>
                            <li>
                                <asp:Label ID="Label20" runat="server" Text="دقت کنید که پس از پایان مرحله پرداخت اینترنتی دیگر امکان تغییر در گـروه های انتخاب شده وجود ندارد"
                                    Font-Names="Tahoma" Font-Size="14px"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label021" runat="server" Text=" اگر در مرحله پرداخت اینترنتی، به مشکل برخورد کردید؛ مجددا به همین سایت برگردید، به سیستم وارد شوید و مجددا فرآیند ثبت نام را از ابتدا انجام بدهید. انتخاب های قبلی شما تا پایان زمان ثبت نام در سیستم ثبت هستند و می توانید مجددا به مرحله پرداخت اینترنتی بروید و مجددا برای پرداخت تلاش کنید."
                                    Font-Names="Tahoma" Font-Size="14px"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label26" runat="server" Text="پس از پرداخت اینترنتی برای تایید ثبت نام، حتما باید رسید ثبت نام خود را دریافت کنید. دقت کنید که در رسید خود وضعیت مالی شما در حالت تسویه باشد و بدهکار نباشید. اگر به هر دلیل رسید ثبت نام خود را دریافت نکردید، ثبت نام شما تایید نهایی نخواهد شد."
                                    Font-Names="Tahoma" Font-Size="14px" Font-Bold="True"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label022" runat="server" Text="اگر به هر دلیل پرداخت اینترنتی خود را انجام ندهید، پس از مدت زمان مجاز ثبت نام گروههای شما به صورت خودکار از سیستم حذف خواهد شد"
                                    Font-Names="Tahoma" Font-Size="14px" Font-Bold="True"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label4" runat="server" Text="صبـور باشید؛ برخی عملیات ممکن است حتی تا چند ثانیه طول بکشند. صبر کنید تا عملیات انجام شود."
                                    Font-Names="Tahoma" Font-Size="14px"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label15" runat="server" Text="اکنون شما در مرحله یک قرار دارید؛ زمان بندی ثبت نام خود را با دقت و صحیح انتخاب کنید."
                                    Font-Names="Tahoma" Font-Size="14px"></asp:Label>
                            </li>
                        </ul>
                        <br />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <uc1:rSimpleMessageBox ID="rSimpleMessageBox1" runat="server" />
        <br />
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label12" runat="server" Text="زمان بندی های مجاز" Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
        </table>
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="زمان بندی ثبت نام:"></asp:Label>
                    <asp:DropDownList ID="rCmbLicense" runat="server" Width="100%" Font-Names="Tahoma">
                    </asp:DropDownList>
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
            <asp:Button ID="btnStart" runat="server" Text="شـــروع ثـبـت نــام" Font-Names="Tahoma"
                Width="210px" OnClick="btnStart_Click"></asp:Button>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
