<%@ Page Title="ثـبــت نــام در مــوسـســه" Language="C#" MasterPageFile="~/MainMasterPage.master"
    AutoEventWireup="true" CodeFile="pageSignup.aspx.cs" Inherits="Student_pageSignup" %>

<%@ Register Src="~/rComponents/rMessageBox/rMessageBox.ascx" TagName="rMessageBox"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" language="JavaScript">
        function CheckEmail(sender, args) {
            var email = args.Value;
            if (email.toString().length > 4 && email.toString().toLowerCase().substring(0, 4) == "www.") {
                args.IsValid = false;
            }
            else {
                args.IsValid = true;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" OnDialogResult="rMessageBox1_DialogResult" />
    <asp:Label ID="lblTitle" runat="server" Text="دانـشـجـوی مـوسـســه فــاخــــــر شــــویـــد"
        Font-Names="Tahoma" Font-Size="11pt" Font-Bold="True"></asp:Label>
    <br />
    <blockquote>
        <span style="font-weight: bold; font-family: Tahoma; font-size: 11pt; color: crimson">
            از هر کجای ایران که هستید، می توانید دانشجوی موسسه فاخر شوید و از خدمات آموزشی به
            صورت حضوری، مکاتبه ای و اینترنتی بهره مند گردید.
            <br />
            <br />
        </span><span style="font-weight: bold; font-family: Tahoma; font-size: 11pt;">جهت اطلاع
            از خدمات و شرایط قبل از ثبت نام
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Contact.aspx">با ما تماس بگیرید</asp:HyperLink>.
        </span>
    </blockquote>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" Direction="RightToLeft"
        Font-Size="11pt">
        <table style="width: 100%">
            <tr>
                <td style="background-color: #3772ab; color: #ffffff">
                    <asp:Label ID="Label18" runat="server" Text="راهنمای ثبت نـام دانشجو جدید در موسـسـه فاخر (حتما کامل مطالعه کنید)"
                        Font-Names="Tahoma" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #e5e6e6; text-align: justify; font-size: 11pt;">
                    <ul style="font-size: 10pt;">
                        <li>ثبت نام شما در سه مرحله انجام میشود:
                            <ol style="font-size: 9pt; font-weight: bold;">
                                <li>تایید آدرس ایمیل شما </li>
                                <li>تکمیل اطلاعات لازم </li>
                                <li>تایید ثبت نام شما توسط واحد آموزش موسسه </li>
                            </ol>
                        </li>
                        <li>شناسايی کاربران در سیستم آموزش این موسسه مبتنی بر آدرس ايميل افراد می باشد و شناسه
                            کاربری شما همان ايميلتان خواهد بود.</li>
                        <li>حتما از یک ایمیل و شماره همراه معتبر، صحیح و دائمی استفاده کنید، چراکه ایمیل شما
                            به عنوان شناسه کاربری شما قرار خواهد گرفت و رمز عبور نیز به همان ایمیل ارسال خواهد
                            گردید </li>
                        <li>آدرس ایمیل برخلاف آدرس وب سایتها با www شروع نمی شود. در وارد کردن آدرس ایمیل خود
                            دقت کنید. </li>
                        <li>حتما پوشه SPAM ایمیل خود را نیز چک کنید. در برخی مواقع ایمیل ارسالی در پوشه SPAM
                            قرار خواهد گرفت. </li>
                    </ul>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <table width="100%" style="margin-top: 5px;">
            <tr>
                <td style="background-color: #4682B4; text-align: right; color: White" colspan="2">
                    <asp:Label ID="Label19" runat="server" Text="قدم اول) تایید آدرس پست الکترونیک" Font-Size="10pt"
                        Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White; width: 200px;">
                    <asp:Label ID="Label32" runat="server" Text="پست الکترونیکی:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTxtEmail" runat="server" CssClass="ltr" Width="99%">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="RadTxtEmail"
                        runat="server" ErrorMessage="ایمیل را وارد کنید."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="RadTxtEmail"
                        SetFocusOnError="true" ValidationExpression="^([a-zA-Z0-9_\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                        ErrorMessage="ایمیل را به صورت صحیح وارد کنید." Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="RadTxtEmail"
                        ClientValidationFunction="CheckEmail" ErrorMessage="آدرس ایمیل با www شروع نمی شود."
                        Display="Dynamic">
                    </asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label22" runat="server" Text="رشته ثبت نـامی:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right;">
                    <telerik:RadComboBox ID="RadCmbMajor" runat="server" Font-Names="Tahoma" Width="100%"
                        DataValueField="Id" DataTextField="EnrollText">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label1" runat="server" Text="شناسه تصویری:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: center;">
                    <div style="text-align: right; width: 200px; margin: auto auto;">
                        <telerik:RadCaptcha ID="RadCaptcha1" runat="server" ProtectionMode="Captcha" CaptchaTextBoxLabel=""
                            Display="Dynamic" Width="200px" ValidatedTextBoxID="txtCaptcha" CssClass="captcha">
                            <CaptchaImage TextChars="Numbers" TextColor="#0066CC" RenderImageOnly="True" TextLength="4"
                                LineNoise="Low" BackgroundNoise="Medium"></CaptchaImage>
                        </telerik:RadCaptcha>
                        <telerik:RadTextBox ID="txtCaptcha" runat="server" Width="200px" CssClass="ltr" MaxLength="4">
                            <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar"
                                IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2"
                                MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating=""
                                PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False"
                                TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                        </telerik:RadTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            ControlToValidate="txtCaptcha" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>
        </table>
        <asp:Panel ID="PanelButtons1" runat="server" Font-Names="Tahoma" HorizontalAlign="Center"
            Style="padding-top: 10px;">
            <telerik:RadButton ID="RadBtnEmailConfirm" runat="server" Text="ارسـال ایمیل تایید"
                Font-Names="Tahoma" OnClick="RadBtnEmailConfirm_Click" Width="210px">
            </telerik:RadButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
