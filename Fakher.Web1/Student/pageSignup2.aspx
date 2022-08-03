<%@ Page Title="تـکـمـیـل ثـبــت نــام" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="pageSignup2.aspx.cs" Inherits="Student_pageSignup2" %>

<%@ Register Src="~/rComponents/rMessageBox/rMessageBox.ascx" TagName="rMessageBox"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" OnDialogResult="rMessageBox1_DialogResult" />
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" Font-Size="12px">
        <table width="100%" style="margin-top: 5px; font-size: 10pt; ">
            <tr>
                <td style="background-color: #4682B4; text-align: center; color: White" colspan="2">
                    &&nbsp;
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White; width: 200px;">
                    <asp:Label ID="Label32" runat="server" Text="پست الکترونیکی:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right;">
                    <asp:Label ID="lblEmail" runat="server" Text="" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White; width: 200px;">
                    <asp:Label ID="Label33" runat="server" Text="رشته ثبت نامی:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right;">
                    <asp:Label ID="lblMajor" runat="server" Text="" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
            <br />
            <asp:Label ID="Label24" runat="server" Font-Size="12pt" Text="جهت تکمیل ثبت نام در موسسه، اطلاعات زیر را به صورت کامل، صحیح و معتبر پر کنید."></asp:Label>
            <br />
            <br />
        </asp:Panel>
        <table width="100%">
            <tr>
                <td style="background-color: #4682B4; text-align: center; color: White" colspan="2">
                    <asp:Label ID="Label6" runat="server" Text="اطلـاعـات عمــومــی" Font-Size="10pt"
                        Font-Bold="True"></asp:Label>
                </td>
                <%--                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">--%>
                <%--                    &&nbsp;--%>
                <%--                </td>--%>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White; width: 200px;">
                    <asp:Label ID="Label1" runat="server" Text="نــام:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">
                    <telerik:RadTextBox ID="RadTxtFirstname" runat="server" Width="99%" Font-Names="Tahoma">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="RadTxtFirstname"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label8" runat="server" Text="نــام خـانوادگـی:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">
                    <telerik:RadTextBox ID="RadTxtLastname" runat="server" Width="99%" Font-Names="Tahoma">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="RadTxtLastname"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label2" runat="server" Text="نــام پــدر:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTxtFathername" runat="server" Width="99%" Font-Names="Tahoma">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="RadTxtFathername"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label7" runat="server" Text="جـنـسـیـت:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <asp:RadioButtonList ID="RadioButtonListGender" runat="server" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label3" runat="server" Text="تـاریـخ تـولـد:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadMaskedTextBox ID="rTxtBirthDate" runat="server" Mask="####/##/##" Width="99%"
                        CssClass="ltr" Font-Names="Tahoma">
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="rTxtBirthDate"
                        runat="server" ErrorMessage="تاریخ تولد را وارد کنید" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label4" runat="server" Text="شماره شناسنامه:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTxtIdNumber" runat="server" CssClass="ltr" Width="99%" Font-Names="Tahoma">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="RadTxtIdNumber"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label5" runat="server" Text="کــد مـلــی:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTxtNationalCode" runat="server" CssClass="ltr" Width="99%" Font-Names="Tahoma">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="RadTxtNationalCode"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <table width="100%" style="margin-top: 5px;">
            <tr>
                <td style="background-color: #4682B4; text-align: center; color: White" colspan="2">
                    <asp:Label ID="Label11" runat="server" Text="اطلاعات تماســی" Font-Size="10pt" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White; width: 200px;">
                    <asp:Label ID="Label12" runat="server" Text="استــان: "></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">
                    <telerik:RadComboBox ID="RadCmbProvince" runat="server" Width="205px" Font-Names="Tahoma" Style="z-index: 7002">
                        <Items>
                            <telerik:RadComboBoxItem Text="آذربایجان شرقی" Selected="True" runat="server" Font-Names="Tahoma">
                            </telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="آذربایجان غربی" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="اردبیل" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="اصفهان" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="البرز" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="ایلام" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="بوشهر" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="تهران" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="چهارمحال و بختیاری" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="خراسان جنوبی" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="خراسان رضوی" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="خراسان شمالی" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="خوزستان" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="زنجان" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="سمنان" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="سیستان و بلوچستان" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="فارس" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="قزوین" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="قم" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="کردستان" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="کرمان" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="کرمانشاه" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="کهکیلویه و بویراحمد" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="گلستان" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="گیلان" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="لرستان" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="مازندران" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="مرکزی" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="هرمزگان" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="همدان" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                            <telerik:RadComboBoxItem Text="یزد" Font-Names="Tahoma"></telerik:RadComboBoxItem>
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label13" runat="server" Text="شـهــر:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTxtCity" runat="server" Width="200px" Font-Names="Tahoma">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="RadTxtCity"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label14" runat="server" Text="آدرس:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTxtAddress" runat="server" Width="99%" Font-Names="Tahoma">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="RadTxtAddress"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label15" runat="server" Text="کد پستی 10 رقمی:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTxtPostalCode" runat="server" CssClass="ltr" Width="200px" Font-Names="Tahoma">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="RadTxtPostalCode"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label16" runat="server" Text="نلفن ثابت:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTxtPhone" runat="server" CssClass="ltr" Width="200px" Font-Names="Tahoma">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="RadTxtPhone"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:Label ID="Label17" runat="server" Text="تلفن همراه:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTxtMobile" runat="server" CssClass="ltr" Width="200px" Font-Names="Tahoma">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="RadTxtMobile"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: center; color: White" colspan="2">
                    <asp:CheckBox ID="chkPolicy" runat="server" Text="کلیه مفاد و شرایط ثبت نام در موسسه را می پذیرم و متعهد به اجرای تمام و کمال آن در طول تحصیل در موسسه می باشم." />
                </td>
            </tr>
        </table>
        <asp:Panel ID="PanelButtons2" runat="server" Font-Names="Tahoma" HorizontalAlign="Center"
            Style="padding-top: 10px;">
            <telerik:RadButton ID="RadBtnSignup" runat="server" Text="ثـبـت نــام" Font-Names="Tahoma"
                OnClick="RadBtnSignup_Click" Width="210px">
            </telerik:RadButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
