<%@ Page Title="دریافت شناسه کاربری" Language="C#" MasterPageFile="~/MainMasterPage1.master"
    AutoEventWireup="true" CodeFile="pageCredential.aspx.cs" Inherits="Student_pageCredential" %>

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

<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" />
    <asp:Panel ID="Panel2" runat="server" Style="text-align: justify">
        <asp:Label ID="Label4" runat="server" Text="دانشجوی گرامی؛"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server"  Text=" برای ورود به سیستم آموزش، نیاز به شناسه کاربری و رمز عبور خواهید داشت. در فرم زیر با وارد کردن شماره دانشجویی و ایمیل خود، شناسه کاربری و رمز عبور مناسب برای شما ایمیل خواهید شد."></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="توجــه: " Font-Bold="True"
            ForeColor="Red"></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="حتما از یک ایمیل معتبر، صحیح و دائمی استفاده کنید، چراکه ایمیل شما به عنوان شناسه کاربری شما قرار خواهد گرفت و رمز عبور نیز به همان ایمیل ارسال خواهد گردید."></asp:Label>
        <br />
        <asp:Label ID="Label12" runat="server"  Text="توجــه: " Font-Bold="True"
            ForeColor="Red"></asp:Label>
        <asp:Label ID="Label11" runat="server" Text="آدرس ایمیل برخلاف آدرس وب سایتها با www شروع نمی شود. در وارد کردن آدرس ایمیل خود دقت کنید."></asp:Label>
        <br />
        <asp:Label ID="Label13" runat="server" Text="توجــه: " Font-Bold="True"
            ForeColor="Red"></asp:Label>
        <asp:Label ID="Label14" runat="server"  Text="حتما پوشه SPAM ایمیل خود را نیز چک کنید. در برخی مواقع ایمیل ارسالی در پوشه SPAM قرار خواهد گرفت."></asp:Label>
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" >
        <table width="100%">
            
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label1" runat="server" Text="شمــاره دانشجــویــی:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">
                    <telerik:RadNumericTextBox ID="RadTextBox1" runat="server" Type="Number" Width="99%"
                        CssClass="ltr" DataType="System.Int64" MinValue="0">
                        <NumberFormat GroupSeparator="" DecimalDigits="0"></NumberFormat>
                    </telerik:RadNumericTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="RadTextBox1"
                        runat="server" ErrorMessage="شماره دانشجویی را وارد کنید" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label8" runat="server" Text="تاریخ تــولــد:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">
                    <telerik:RadMaskedTextBox ID="rTxtBirthDate" runat="server" Mask="####/##/##" Width="99%"
                        CssClass="ltr">
                    </telerik:RadMaskedTextBox>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="تاریخ تولد را به فرمت مقابل وارد کنید:"
                                    Font-Size="8pt"></asp:Label>
                            </td>
                            <td style="direction: ltr">
                                <asp:Label ID="Label10" runat="server" Text="1364/01/15" Font-Size="8pt"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="rTxtBirthDate"
                        runat="server" ErrorMessage="تاریخ تولد را وارد کنید" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label2" runat="server" Text="پست الکترونیکی:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTextBox2" runat="server" CssClass="ltr" Width="99%">
                        <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar"
                            IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2"
                            MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating=""
                            PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False"
                            TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="RadTextBox2"
                        runat="server" ErrorMessage="ایمیل را وارد کنید"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="RadTextBox2"
                        SetFocusOnError="true" ValidationExpression="^([a-zA-Z0-9_\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                        ErrorMessage="ایمیل را به صورت صحیح وارد کنید" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="RadTextBox2"
                        ClientValidationFunction="CheckEmail" ErrorMessage="آدرس ایمیل با www شروع نمی شود."
                        Display="Dynamic">
                    </asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label7" runat="server" Text="ورود مجدد پست الکترونیکی:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTextBox3" runat="server" CssClass="ltr" Width="99%">
                        <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar"
                            IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2"
                            MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating=""
                            PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False"
                            TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="RadTextBox3"
                        runat="server" ErrorMessage="ایمیل را وارد کنید"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="RadTextBox3"
                        SetFocusOnError="true" ValidationExpression="^([a-zA-Z0-9_\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                        ErrorMessage="ایمیل را به صورت صحیح وارد کنید" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="پست الکترونیک و تایید آن همسان نیستند"
                        ControlToValidate="RadTextBox2" ControlToCompare="RadTextBox3" Operator="Equal"></asp:CompareValidator>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="RadTextBox3"
                        ClientValidationFunction="CheckEmail" ErrorMessage="آدرس ایمیل با www شروع نمی شود."
                        Display="Dynamic">
                    </asp:CustomValidator>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" Font-Names="Tahoma" HorizontalAlign="Center">
        <telerik:RadButton ID="RadBtnCredential" runat="server" Text="دریافت شناسه کاربری"
            Font-Names="Tahoma" OnClick="RadBtnCredential_Click">
        </telerik:RadButton>
    </asp:Panel>
</asp:Content>
