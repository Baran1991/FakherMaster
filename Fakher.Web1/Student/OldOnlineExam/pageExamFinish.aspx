<%@ Page Title="پـایـان آزمــون اینترنتی" Language="C#" MasterPageFile="~/Student/OnlineExam/ExamMasterPage.master"
    AutoEventWireup="true" CodeFile="pageExamFinish.aspx.cs" Inherits="Student_OnlineExam_pageExamFinish" %>

<%@ Register TagPrefix="uc1" TagName="rSimpleMessageBox" Src="~/rComponents/rMessageBox/rSimpleMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TopContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rSimpleMessageBox ID="rSimpleMessageBox1" runat="server" />
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" Font-Size="10pt">
        <asp:Label ID="Label1" runat="server" Text="داوطلب گرامی؛" Font-Size="11pt"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="پاسخگویی به سئوالات آزمون به پایان رسیده است. در زیر خلاصه ای از وضعیت پاسخگویی شما مشاهده می کنید."
            Font-Size="11pt"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="این خلاصه را بررسی کنید و درصورتی که مورد تایید است، نتایج را ثبت کنید."
            Font-Size="11pt"></asp:Label>
        <br />
        <asp:Label ID="Label22" runat="server" Text="به یاد داشته باشید؛ " Font-Size="11pt"
            Font-Bold="True" ForeColor="Red"></asp:Label>
        <asp:Label ID="Label23" runat="server" Text="برای ثبت پاسخهای شما در سیستم، باید حتما در این مرحله ثبت نهایی را کلیک کنید."
            Font-Size="11pt" Font-Bold="True" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <table width="100%">
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: #ffffff; vertical-align: top;
                    width: 200px">
                    <asp:Label ID="Label7" runat="server" Text="تعداد کل سئوالات: "></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: top">
                    <asp:Label ID="lblQuestionCount" runat="server" Text="text"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: #ffffff; vertical-align: top">
                    <asp:Label ID="Label4" runat="server" Text="تعداد سئوالات پاسخ داده: "></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: top">
                    <asp:Label ID="lblAnsweredCount" runat="server" Text="text"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: #ffffff; vertical-align: top">
                    <asp:Label ID="Label6" runat="server" Text="تعداد سئوالات بی پاسخ: "></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: top">
                    <asp:Label ID="lblNotAnsweredCount" runat="server" Text="text"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: #ffffff; vertical-align: top">
                    <asp:Label ID="Label5" runat="server" Text="زمان پاسخگویی به کل سئوالات: "></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: top">
                    <asp:Label ID="lblTotalDuration" runat="server" Text="text"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="Panel3" runat="server" Font-Names="Tahoma" HorizontalAlign="Center">
            <asp:Label ID="Label8" runat="server" Text="حتما قبل از خـروج ثبت نهایی آزمــون را کلیک کنید"
                Font-Size="11pt" Font-Bold="True" ForeColor="Red"></asp:Label>
        </asp:Panel>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="Panel2" runat="server" Font-Names="Tahoma" Direction="RightToLeft"
        HorizontalAlign="Center">
        <table style="width: 100%; background-color: #e5e6e6; border-top: 1px dashed black">
            <tr>
                <td style="text-align: right">
                    <asp:Button ID="btnPrevPage" runat="server" Text="<< صفحــه قبـــل" Width="200px"
                        Font-Names="Tahoma" OnClick="btnPrevPage_Click" />
                </td>
                <td style="text-align: left">
                    <asp:Button ID="btnSubmitExam" runat="server" Text="ثبت نهایی آزمــون" Font-Names="Tahoma"
                        Font-Size="12pt" Font-Bold="True" Width="200px" OnClick="btnSubmitExam_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
