<%@ Page Title="ورود بــه سـیـسـتــم آمــوزش اســاتیـــد" Language="C#" MasterPageFile="~/MainMasterPage.master"
    AutoEventWireup="true" CodeFile="pageSignin.aspx.cs" Inherits="Student_Signin" %>

<%@ Register Src="~/rComponents/rMessageBox/rMessageBox.ascx" TagName="rMessageBox"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" />
    <asp:Label ID="lblTitle" runat="server" Text="ورود بــه سـیـسـتــم آمــوزش اســاتیـــد"
        Font-Names="Tahoma" Font-Size="11pt" Font-Bold="True"></asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" HorizontalAlign="Center"
        DefaultButton="btnLogin">
        <table style="width: 600px; margin-left: auto; margin-right: auto;" cellpadding="0"
            cellspacing="0">
            <tr>
                <td style="background-color: #c5d8e9; height: 35px; border-bottom: 1px solid #abc8e6;
                    border-left: 2px solid #abc8e6; border-right: 2px solid #abc8e6; border-top: 2px solid #abc8e6">
                    <asp:Label ID="Label3" runat="server" Text="ورود بـه سیستــم" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100%; border-left: 2px solid #abc8e6; border-right: 2px solid #abc8e6">
                    <table style="margin-left: auto; margin-right: auto;">
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label4" runat="server" Text="کـــد پرسنـلــی:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadTextBox ID="RadTextBox3" runat="server" Font-Names="Tahoma" Width="200px"
                                    CssClass="ltr">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                    ControlToValidate="RadTextBox3" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label1" runat="server" Text="شنــاســــه کـــاربــــری:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadTextBox ID="RadTextBox1" runat="server" Font-Names="Tahoma" Width="200px"
                                    CssClass="ltr">
                                    <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar"
                                        IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2"
                                        MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating=""
                                        PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False"
                                        TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="RadTextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label2" runat="server" Text="رمــز عبـــور:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadTextBox ID="RadTextBox2" runat="server" TextMode="Password" Width="200px"
                                    CssClass="ltr">
                                    <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar"
                                        IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2"
                                        MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating=""
                                        PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False"
                                        TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="RadTextBox2" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label8" runat="server" Text="شنــاســــه تـصــویــری:"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <telerik:RadCaptcha ID="RadCaptcha1" runat="server" ProtectionMode="Captcha" CaptchaTextBoxLabel=""
                                    Display="Dynamic" Width="200px" ValidatedTextBoxID="txtCaptcha" CssClass="captcha">
                                    <CaptchaImage TextChars="Numbers" TextColor="#0066CC" RenderImageOnly="True" TextLength="6"
                                        LineNoise="Low" BackgroundNoise="Medium"></CaptchaImage>
                                </telerik:RadCaptcha>
                                <telerik:RadCaptcha ID="RadCaptcha2" runat="server" ProtectionMode="MinimumTimeout">
                                </telerik:RadCaptcha>
                                <telerik:RadTextBox ID="txtCaptcha" runat="server" Width="200px" CssClass="ltr" MaxLength="6">
                                    <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar"
                                        IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2"
                                        MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating=""
                                        PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False"
                                        TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="txtCaptcha" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="background-color: #c5d8e9; height: 50px; border-left: 2px solid #abc8e6;
                    border-right: 2px solid #abc8e6; border-top: 1px solid #abc8e6; border-bottom: 2px solid #abc8e6">
                    <telerik:RadButton ID="btnLogin" runat="server" Text="ورود" Font-Names="Tahoma" Width="95px"
                        OnClick="btnLogin_Click">
                    </telerik:RadButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
