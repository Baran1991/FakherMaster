<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Enrollment/EnrollmentMasterPage.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Student_Enrollment_Default" %>

<%@ Register TagPrefix="uc1" TagName="rSimpleMessageBox" Src="~/rComponents/rMessageBox/rSimpleMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rSimpleMessageBox ID="rSimpleMessageBox1" runat="server" />
    <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
        <asp:Label ID="lblTitle" runat="server" Text="سـیـسـتــم ثبت نام اینترنتی دانشجویان مـوسـســه فاخــــــر"
            Font-Names="Tahoma" Font-Size="11pt" Font-Bold="True"></asp:Label>
    </asp:Panel>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <table style="width: 100%;">
        <tr>
            <td style="width: 50%; vertical-align: top;">
                <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" HorizontalAlign="Center"
                    DefaultButton="btnLogin">
                    <table style="width: 100%; height: 300px; margin-left: auto; margin-right: auto;"
                        cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="background-color: #c5d8e9; height: 35px; border-bottom: 1px solid #abc8e6;
                                border-left: 2px solid #abc8e6; border-right: 2px solid #abc8e6; border-top: 2px solid #abc8e6">
                                <asp:Label ID="Label3" runat="server" Text="ورود بـه سیستــم" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100%; border-left: 2px solid #abc8e6; border-right: 2px solid #abc8e6" valign="top">
                                <table style="margin-left: auto; margin-right: auto; height: 223px">
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="Label1" runat="server" Text="پـســت الـکـتــرونــیــک:"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox1" runat="server" Font-Names="Tahoma" Width="250px" CssClass="ltr">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                ControlToValidate="TextBox1" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="Label2" runat="server" Text="رمــز عبـــور:"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="250px" CssClass="ltr">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                ControlToValidate="TextBox2" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: right">
                                            <asp:Label ID="Label8" runat="server" Text="شنــاســــه تـصــویــری:"></asp:Label>
                                            <asp:LinkButton ID="lnkNewCaptcha" runat="server" OnClick="lnkNewCaptcha_Click" CausesValidation="False">(اگر تصویر ناخواناست، اینجا را کلیک کنید)</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: center">
                                            <asp:Image ID="imgCaptcha" ImageUrl="Captcha.aspx" runat="server" />
                                            <asp:TextBox ID="txtCaptcha" runat="server" Width="200px" CssClass="ltr" MaxLength="6">
                                            </asp:TextBox>
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
                                <asp:Button ID="btnLogin" runat="server" Text="ورود" Font-Names="Tahoma" Width="95px"
                                    OnClick="btnLogin_Click"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td style="width: 50%; vertical-align: top; font-family: Tahoma;">
                <table style="width: 100%; height: 300px; margin-left: auto; margin-right: auto;"
                    cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="background-color: #c5d8e9; height: 35px; border-bottom: 1px solid #abc8e6;
                            border-left: 2px solid #abc8e6; border-right: 2px solid #abc8e6; border-top: 2px solid #abc8e6;
                            text-align: center">
                            <asp:Label ID="Label4" runat="server" Text="دریافت  شناســه کـاربــری" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; vertical-align: top; border-left: 2px solid #abc8e6; border-right: 2px solid #abc8e6" valign="top">
                            <table style="font-family: Tahoma; font-size: 8.25pt; margin-left: auto; margin-right: auto; height: 223px">
                                <tr>
                                    <td style="text-align: right;">
                                        <ul>
                                            <li>
                                                <asp:Label ID="Label5" runat="server" Text="اگر دانشجوی موسسه هستید" Font-Size="10pt"></asp:Label>
                                            </li>
                                            <li>
                                                <asp:Label ID="Label7" runat="server" Text="شماره دانشجویی خود را دارید" Font-Size="10pt"></asp:Label>
                                            </li>
                                            <li>
                                                <asp:Label ID="Label6" runat="server" Text="جهت دریافت مشخصات ورود خود، از این قسمت اقدام کنید"
                                                    Font-Size="10pt"></asp:Label>
                                            </li>
                                        </ul>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #c5d8e9; height: 50px; border-left: 2px solid #abc8e6;
                            border-right: 2px solid #abc8e6; border-top: 1px solid #abc8e6; border-bottom: 2px solid #abc8e6;
                            text-align: center">
                            <asp:Button ID="BtnCredential" runat="server" Text="دریافت شناسه کاربری" Font-Names="Tahoma"
                                OnClick="BtnCredential_Click" CausesValidation="False"></asp:Button>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlDescription" runat="server" Visible="False" Font-Names="Tahoma" Font-Size="12pt" Style="margin: auto auto" HorizontalAlign="Center">
        <br/>
        <br/>
        <asp:Label ID="lblWebsiteDescription" runat="server" Text="Label" Font-Bold="True"></asp:Label>
    </asp:Panel>
</asp:Content>
