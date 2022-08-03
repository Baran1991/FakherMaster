<%@ Page Title="ورود بــه سـیـسـتــم آمــوزش دانشجــویــان" Language="C#" MasterPageFile="~/MainMasterPage1.master"
    AutoEventWireup="true" CodeFile="pageSignin.aspx.cs" Inherits="Student_Signin" %>

<%@ Register Src="~/rComponents/rMessageBox/rMessageBox.ascx" TagName="rMessageBox"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" />
    <asp:Label ID="lblTitle" runat="server" Text="سـیـسـتــم آمــوزش دانشجــویــان مـوسـســه فاخــــــر"
        Font-Names="Tahoma" Font-Size="11pt" Font-Bold="True"></asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <div class="row">
        <div class="col-md-6"> <asp:Panel ID="Panel1" runat="server"  HorizontalAlign="Center"
                    DefaultButton="btnLogin">
            <div class="panel panel-info">
                    <div class="panel-heading">
                          <asp:Label ID="Label3" runat="server" Text="ورود بـه سیستــم" Font-Bold="true"></asp:Label>
                    </div>
                    <div class="panel-body">
                          <%--<div class="col-md-8 col-md-offset-2">
                              <asp:Label ID="Label9" runat="server" Text="شعبه:"></asp:Label>
                             <telerik:RadComboBox ID="cmbBranch" runat="server" Width="100%" 
                                ondatabound="cmbBranch_DataBound" 
                                onselectedindexchanged="cmbBranch_SelectedIndexChanged" AutoPostBack="True">
                            </telerik:RadComboBox>
                        </div>--%>
                        <div class="col-md-8 col-md-offset-2">
                              <asp:Label ID="Label1" runat="server" Text="پـســت الـکـتــرونــیــک:"></asp:Label>
                             <telerik:RadTextBox ID="RadTextBox1" runat="server" Width="100%"
                                                CssClass="form-control">
                                                <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar"
                                                    IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2"
                                                    MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating=""
                                                    PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False"
                                                    TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                ControlToValidate="RadTextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-8 col-md-offset-2">
                             <asp:Label ID="Label2" runat="server" Text="رمــز عبـــور:"></asp:Label>
                             <telerik:RadTextBox ID="RadTextBox2" runat="server" TextMode="Password" 
                                                CssClass="form-control" Width="100%">
                                                <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar"
                                                    IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2"
                                                    MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating=""
                                                    PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False"
                                                    TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                ControlToValidate="RadTextBox2" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        <div class="col-md-8 col-md-offset-2 center-block">
                             <asp:Label ID="Label8" runat="server" Text="شنــاســــه تـصــویــری:"></asp:Label>
                        <div style="text-align:center">   <telerik:RadCaptcha ID="RadCaptcha1" runat="server" ProtectionMode="Captcha" CaptchaTextBoxLabel=""
                                                Display="Dynamic" Width="100%" ValidatedTextBoxID="txtCaptcha" CssClass="captcha">
                                                <CaptchaImage TextChars="Numbers" TextColor="#0066CC" RenderImageOnly="True" TextLength="4"
                                                    LineNoise="Low" BackgroundNoise="Medium"></CaptchaImage>
                                            </telerik:RadCaptcha></div> 
                                            <telerik:RadTextBox ID="txtCaptcha" runat="server" Width="100%" CssClass="form-control" MaxLength="4">
                                                <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar"
                                                    IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2"
                                                    MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating=""
                                                    PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False"
                                                    TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                            </telerik:RadTextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                                ControlToValidate="txtCaptcha" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        
                    </div>
            <div class="panel-footer">
                  <telerik:RadButton ID="btnLogin" runat="server" Text="ورود" Width="100px"
                                    OnClick="btnLogin_Click">
                                </telerik:RadButton>
            </div>
                </div></asp:Panel></div>
        <div class="col-md-6">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <asp:Label ID="Label4" runat="server" Text="دریافت  شناســه کـاربــری" Font-Bold="True"></asp:Label>
                </div>
                <div class="panel-body" style="height:243px;">
                   <ul>     <li>
                                                <asp:Label ID="Label5" runat="server" Text="اگر دانشجوی موسسه هستید"></asp:Label>
                                            </li>
                                            <li>
                                                <asp:Label ID="Label7" runat="server" Text="شماره دانشجویی خود را دارید" ></asp:Label>
                                            </li>
                                            <li>
                                                <asp:Label ID="Label6" runat="server" Text="جهت دریافت مشخصات ورود خود، از این قسمت اقدام کنید"
                                                  ></asp:Label>
                                            </li>
                                        </ul>
                </div>
                <div class="panel-footer center-block" style="text-align:center">
                    <telerik:RadButton ID="RadBtnCredential" runat="server" Text="دریافت شناسه کاربری"
                                OnClick="RadBtnCredential_Click" CausesValidation="False">
                            </telerik:RadButton>
                </div>
            </div>
        </div>
    </div>
    
  
</asp:Content>
