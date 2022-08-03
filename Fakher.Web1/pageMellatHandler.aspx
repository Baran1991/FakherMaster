<%@ Page Title="پردازش پرداخت اینترنتی درگاه بانک ملت..." Language="C#" MasterPageFile="~/MainMasterPage.master"
    AutoEventWireup="true" CodeFile="pageMellatHandler.aspx.cs" Inherits="pageMellatHandler" %>

<%@ Register Src="~/rComponents/rMessageBox/rMessageBox.ascx" TagName="rMessageBox"
    TagPrefix="uc1" %>
<%@ Register Src="~/rComponents/rMessageBox/rSimpleMessageBox.ascx" TagName="rSimpleMessageBox"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <%--    <uc1:rMessageBox ID="rMessageBox1" runat="server" OnDialogResult="rMessageBox1_DialogResult" />--%>
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
                    <asp:Label ID="Label2" runat="server" Text="شماره پرداخت و شماره پیگیری فوق را حتما یادداشت کنید و 'تایید و ادامه' را کلیک کنید." Font-Bold="True"
                        Font-Names="Tahoma" ForeColor="Orange" Font-Size="12pt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <uc1:rSimpleMessageBox ID="rSimpleMessageBox1" runat="server" />
                </td>
            </tr>
            <tr style="background: #009999; text-align: left">
                <td>
                    <asp:HyperLink ID="HyperLinkDefaultPage" runat="server" Font-Bold="True" Font-Names="Tahoma" ForeColor="White" Font-Size="14pt" NavigateUrl="~/Student/Default.aspx">بازگشت به صفحه اول >></asp:HyperLink>
                    <asp:HyperLink ID="HyperLinkContinue" runat="server" Visible="False" Font-Bold="True" Font-Names="Tahoma" ForeColor="White" Font-Size="14pt" NavigateUrl="~/Student/Default.aspx">تایید و ادامه >></asp:HyperLink>
                </td>
            </tr>
        </table>
        <%--    <asp:Panel ID="Panel1" runat="server" Direction="LeftToRight">--%>
        <%--        <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="White"></asp:Label>--%>
        <%--    </asp:Panel>--%>
    </asp:Panel>
</asp:Content>
