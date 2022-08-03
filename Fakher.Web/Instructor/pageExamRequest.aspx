<%@ Page Title="ثبت درخواست آزمون" Language="C#" MasterPageFile="~/Instructor/InstructorMasterPage.master" AutoEventWireup="true" CodeFile="pageExamRequest.aspx.cs" Inherits="Instructor_pageExamRequest" %>

<%@ Register TagPrefix="uc1" TagName="rmessagebox" Src="~/rComponents/rMessageBox/rMessageBox.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rmessagebox ID="rMessageBox1" runat="server" OnDialogResult="rMessageBox1_DialogResult" />
    <asp:Label ID="Label5" runat="server" Text="درخواست آزمــون" Font-Names="Tahoma" NavigateUrl="~/Instructor/pageExamRequest.aspx"></asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" Font-Size="10pt">

        <table width="100%">
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White; width: 200px;">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="rTxtExamDate"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:Label ID="Label2" runat="server" Text="تاریخ آزمون:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">
                    <telerik:RadMaskedTextBox ID="rTxtExamDate" runat="server" Mask="####/##/##" Width="99%"
                        CssClass="ltr">
                    </telerik:RadMaskedTextBox>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="تاریخ آزمون را به فرمت مقابل وارد کنید:"
                                    Font-Size="8pt"></asp:Label>
                            </td>
                            <td style="direction: ltr">
                                <asp:Label ID="Label10" runat="server" Text="1392/01/15" Font-Size="8pt"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="RadTxtMajor"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:Label ID="Label1" runat="server" Text="رشته/دوره:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTxtMajor" runat="server" Width="99%">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="RadTxtLesson"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:Label ID="Label3" runat="server" Text="درس/سطح:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTxtLesson" runat="server" Width="99%">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="RadTxtSection"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:Label ID="Label4" runat="server" Text="گروه:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTxtSection" runat="server" Width="99%">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="RadTxtCount"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:Label ID="Label6" runat="server" Text="تعداد شرکت کننده:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadNumericTextBox ID="RadTxtCount" runat="server" Type="Number" Width="99%"
                        CssClass="ltr" DataType="System.Int64" MinValue="0">
                        <NumberFormat GroupSeparator="" DecimalDigits="0"></NumberFormat>
                    </telerik:RadNumericTextBox>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="RadTxtExamName"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:Label ID="Label7" runat="server" Text="نـام آزمون:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadTextBox ID="RadTxtExamName" runat="server" Width="99%">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="RadMaskedTxtFrom"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:Label ID="Label8" runat="server" Text="از ساعت:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadMaskedTextBox ID="RadMaskedTxtFrom" runat="server" Mask="##:##" Width="99%"
                        CssClass="ltr">
                    </telerik:RadMaskedTextBox>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="RadMaskedTxtTo"
                        runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:Label ID="Label11" runat="server" Text="تا ساعت:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; padding-top: 10px">
                    <telerik:RadMaskedTextBox ID="RadMaskedTxtTo" runat="server" Mask="##:##" Width="99%"
                        CssClass="ltr">
                    </telerik:RadMaskedTextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="Panel3" runat="server" Font-Names="Tahoma" HorizontalAlign="Center">
        <telerik:RadButton ID="RadBtnSubmit" runat="server" Text="ارسال درخواست"
            Font-Names="Tahoma" OnClick="RadBtnSubmit_Click">
        </telerik:RadButton>
    </asp:Panel>
</asp:Content>

