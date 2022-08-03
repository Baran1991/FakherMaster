<%@ Page Title="تماس با موسسه فاخر شیراز" Language="C#" MasterPageFile="~/Student/Enrollment/EnrollmentMasterPage.master" AutoEventWireup="true"
    CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <asp:Label ID="Label5" runat="server" Text="اطلاعات تماس با موسسه" Font-Names="Tahoma"
        Font-Size="14px" ForeColor="#009999"></asp:Label>
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma">
        <table width="100%">
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: #ffffff; vertical-align: top">
                    <div style="vertical-align: top; background-color: #4682B4; text-align: left; color: #ffffff; padding-top: 2px;">
                        <asp:Label ID="Label7" runat="server" Text="پست الکترونیک: "></asp:Label>
                    </div>
                    <div style="vertical-align: bottom; background-color: #4682B4; text-align: left; color: #ffffff; padding-top: 7px;">
                        <asp:Label ID="Label6" runat="server" Text="دپارتمان حقوق: "></asp:Label>
                    </div>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">
                    <div style="vertical-align: top">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/info_mail.png" />
                    </div>
                    <div style="vertical-align: bottom">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/law_mail.png" />
                    </div>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: #ffffff; vertical-align: top">
                    <asp:Label ID="Label3" runat="server" Text="تلفن: "></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; direction: ltr; vertical-align: top">
                    <asp:Label ID="Label4" runat="server" Text="(+98 711) 6263662"></asp:Label>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="(+98 711) 6263668"></asp:Label>
                    <br />
                    <asp:Label ID="Label11" runat="server" Text="همه روزه از ساعت 8:00 الی 20:00"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: #ffffff; vertical-align: top">
                    <asp:Label ID="Label12" runat="server" Text="نمــابــر: "></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; direction: ltr; vertical-align: top">
                    <asp:Label ID="Label13" runat="server" Text="(+98 711) 6263662"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: #ffffff; vertical-align: top">
                    <asp:Label ID="Label1" runat="server" Text="آدرس پستـی: "></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: top">
                    <asp:Label ID="Label2" runat="server" Text="موسسه آموزش عالی آزاد فاخــر"></asp:Label>
                    <br />
                    <asp:Label ID="Label10" runat="server" Text="خیابان قصرالدشت - بعد از خیابان قم آباد - روبروی دبیرستان دانشگاه - پلاک 226"></asp:Label>
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="ایران - شیراز"></asp:Label>
                    <br />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
