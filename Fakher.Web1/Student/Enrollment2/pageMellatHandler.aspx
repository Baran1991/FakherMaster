<%@ Page Title="پردازش پرداخت اینترنتی درگاه بانک ملت..." Language="C#" MasterPageFile="~/Student/Enrollment/EnrollmentMasterPage.master"
    AutoEventWireup="true" CodeFile="pageMellatHandler.aspx.cs" Inherits="pageMellatHandler" %>
<%@ Register TagPrefix="uc1" TagName="rSimpleMessageBox" Src="~/rComponents/rMessageBox/rSimpleMessageBox.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" ForeColor="White">
        <table style="width: 80%; border: dashed 1px White; margin-left: auto; margin-right: auto">
            <tr style="background: #009999;">
                <td style="vertical-align: top; text-align: justify">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 50%; text-align: center;">
                                <asp:Label ID="lblOrderId" runat="server" Text="" Font-Size="12pt" ForeColor="White"
                                    Font-Bold="True"></asp:Label>
                            </td>
                            <td style="width: 50%; text-align: center;">
                                <asp:Label ID="lblSaleReferenceId" runat="server" Text="" ForeColor="White" Font-Bold="True"
                                    Font-Size="12pt" Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="background: #009999;" runat="server" id="rowOk" visible="False">
                <td style="vertical-align: top; text-align: center">
                    <asp:Label ID="Label1" runat="server" Text="پرداخت با موفقیت انجام گرفت." Font-Bold="True"
                        Font-Names="Tahoma" ForeColor="White" Font-Size="14pt"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" 
                        Text="شماره پرداخت و شماره پیگیری فوق را حتما یادداشت کنید و 'تایید و ادامه' را کلیک کنید." Font-Bold="True"
                        Font-Names="Tahoma" ForeColor="White" Font-Size="12pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:rSimpleMessageBox ID="rSimpleMessageBox1" runat="server" />
                </td>
            </tr>
            <tr style="background: #009999; text-align: left">
                <td>
                    <asp:HyperLink ID="HyperLinkDefaultPage" runat="server" Font-Bold="True" Font-Names="Tahoma" ForeColor="White" Font-Size="14pt" NavigateUrl="~/Student/Enrollment/pageSectionEnrollment1.aspx">بازگشت به صفحه اول >></asp:HyperLink>
                    <asp:HyperLink ID="HyperLinkContinue" runat="server" Visible="False" Font-Bold="True" Font-Names="Tahoma" ForeColor="White" Font-Size="14pt" NavigateUrl="~/Student/Enrollment/rptSignupReceipt.aspx">تایید، ادامه و دریافت رسید ثبت نام >></asp:HyperLink>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
