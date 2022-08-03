<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<%@ Register Src="~/rComponents/rMessageBox/rMessageBox.ascx" TagName="rMessageBox"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" OnDialogResult="rMessageBox1_DialogResult" />
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" Font-Size="12px">
        <table cellspacing="0" cellpadding="0" width="550" align="center">
            <tr>
                <td>
                    در انتخاب کلمه رمز نکات زير را رعايت کنيد:
                </td>
            </tr>
            <tr>
                <td>
                    <p>
                    </p>
                </td>
            </tr>
            <tr>
                <td>
                    <ul>
                        <li>از نامهای مشهور يا نام خودتان يا نام نزديکانتان نبايد استفاده نماييد. </li>
                        <li>از حداقل شش حرف استفاده کنيد. </li>
                        <li>از تکرار حروف پرهيز کنيد.</li>
                        <li>از حروفی که در صفحه کليد نزديک هم هستند يا ترکيب آنها
                            خطوط منظمی را توليد می کنند استفاده نکنيد. </li>
                    </ul>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Font-Names="Tahoma" Font-Size="12px">
        <table cellspacing="0" cellpadding="0" width="220" align="center" style="text-align: center">
            <tr>
                <td>
                    <span id="ctl00_CenterContentPlaceHolder_Label3">تغییر رمزعبور</span>
                    <hr />
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label1" runat="server" Text="رمزعبور فعلی: "></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <telerik:RadTextBox ID="rTxtOldPassword" runat="server" TextMode="Password" CssClass="ltr" Width="200px">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                        ControlToValidate="rTxtOldPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label2" runat="server" Text="رمزعبور جدید: "></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <telerik:RadTextBox ID="rTxtNewPassword" runat="server" TextMode="Password" CssClass="ltr" Width="200px">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                        ControlToValidate="rTxtNewPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="Label3" runat="server" Text="تکرار رمزعبور جدید: "></asp:Label>
                </td>
             </tr>
             <tr>
                <td style="text-align: right">
                    <telerik:RadTextBox ID="rTxtNewPassword2" runat="server" TextMode="Password" CssClass="ltr" Width="200px">
                    </telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                        ControlToValidate="rTxtNewPassword2" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="رمزعبور جدید و تکرار آن یکسان نیستند" ControlToValidate="rTxtNewPassword" ControlToCompare="rTxtNewPassword2" Operator="Equal"></asp:CompareValidator>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" Font-Names="Tahoma" Font-Size="12px" HorizontalAlign="Center">
        <br />
        <telerik:RadButton ID="btnSubmit" runat="server" Text="تغییر رمز" Font-Names="Tahoma"
            Width="95px" OnClick="btnSubmit_Click">
        </telerik:RadButton>
    </asp:Panel>
</asp:Content>
