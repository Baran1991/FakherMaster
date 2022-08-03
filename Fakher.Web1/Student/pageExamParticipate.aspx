<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="pageExamParticipate.aspx.cs" Inherits="Student_pageExamParticipate" %>

<%@ Register Assembly="Telerik.ReportViewer.Html5.WebForms, Version=14.1.20.618, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.Html5.WebForms" TagPrefix="telerik" %>
<%--<%@ Register TagPrefix="telerik" Namespace="Telerik.ReportViewer.WebForms" Assembly="Telerik.ReportViewer.WebForms, Version=5.1.11.713, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" %>--%>
<%@ Register TagPrefix="uc1" TagName="rMessageBox" Src="~/rComponents/rMessageBox/rMessageBox.ascx" %>
<%@ Register TagPrefix="uc2" TagName="AttachmentView" Src="~/UserControls/AttachmentView.ascx" %>
<%@ Register TagPrefix="uc3" TagName="PollControl" Src="~/UserControls/PollControl.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
     <li class="active">  <a  href="#">امــور آزمـــون
                   </a></li>
    <%--<telerik:RadPanelBar ID="RadPanelBar1" runat="server" Width="210px" OnItemClick="RadPanelBar1_ItemClick">
        <Items>
            <telerik:RadPanelItem runat="server" Text="امــور آزمـــون" Font-Names="Tahoma" Expanded="true"
                PreventCollapse="True">
                <Items>
                    <telerik:RadPanelItem runat="server" Text="بازگشت به صفحه اول" CssClass="CustomStyle"
                        Font-Names="Tahoma" NavigateUrl="~/Student/Default.aspx">
                    </telerik:RadPanelItem>
                </Items>
            </telerik:RadPanelItem>
        </Items>
    </telerik:RadPanelBar>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" />
    <asp:Label ID="Label1" runat="server" Text="امـــــور آزمـــون" Font-Names="Tahoma"></asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma">
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; width: 100px;">
                    <asp:Label ID="Label2" runat="server" Text="عنـوان آزمـــون:" Font-Bold="True"></asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="lblLesson" runat="server" Text="" Font-Size="10pt"></asp:Label>
                </td>
                <td style="text-align: left; width: 100px;">
                </td>
                <td style="text-align: right">
                </td>
            </tr>
            <tr>
                <td>
                    &&nbsp;
                </td>
                <td colspan="3" style="text-align: right">
                </td>
            </tr>
        </table>
        <table style="width: 100%">
            <tr>
                <td style="background-color: #3772ab; color: #ffffff">
                    <asp:Label ID="Label11" runat="server" Text="منـوی سریع امــور آزمــــون" Font-Names="Tahoma"
                        Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr style="background-color: #e5e6e6;">
                <td>
                    <table style="text-align: center;">
                        <tr>
<%--                            <td id="cellOnlineExam" runat="server" style="padding-left: 20px; padding-right: 20px;--%>
<%--                                border-left: 2px solid #abc8e6; min-width: 80px;">--%>
<%--                                <asp:LinkButton ID="lnkOnlineExam" runat="server" OnClick="lnkOnlineExam_Click">--%>
<%--                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/images/online_exam.gif" Width="36px"--%>
<%--                                        Height="36px" AlternateText="شرکت در آزمون آنلاین" />--%>
<%--                                    <br />--%>
<%--                                    <asp:Label ID="Label4" runat="server" Text="شرکت در آزمون آنلاین"></asp:Label>--%>
<%--                                </asp:LinkButton>--%>
<%--                            </td>--%>
                            <td id="cellExamResult" runat="server" style="padding-left: 20px; padding-right: 20px;
                                border-left: 2px solid #abc8e6; min-width: 80px;">
                                <asp:LinkButton ID="lnkExamResult" runat="server" OnClick="lnkExamResult_Click">
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/reportCard.png" Width="36px"
                                        Height="34px" AlternateText="مشاهده نتیجه مصاحبه" />
                                    <br />
                                    <asp:Label ID="Label7" runat="server" Text="مشاهده نتیجه مصاحبه"></asp:Label>
                                </asp:LinkButton>
                            </td>
                            <td id="cellExamReportCard" runat="server" style="padding-left: 20px; padding-right: 20px;
                                border-right: 2px solid #abc8e6; border-left: 2px solid #abc8e6; min-width: 80px;">
                                <asp:LinkButton ID="lnkExamReportCard" runat="server" OnClick="lnkExamReportCard_Click">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/reportCard.png" Width="36px"
                                        Height="34px" AlternateText="کارنامه تحلیلی آزمون" />
                                    <br />
                                    <asp:Label ID="Label3" runat="server" Text="کارنامه تحلیلی آزمون"></asp:Label>
                                </asp:LinkButton>
                            </td>
                            <td id="cellExamCard" runat="server" style="padding-left: 20px; padding-right: 20px;
                                border-right: 2px solid #abc8e6; border-left: 2px solid #abc8e6; min-width: 80px;">
                                <asp:LinkButton ID="lnkExamCard" runat="server" OnClick="lnkExamCard_Click">
                                    <asp:Image ID="Image7" runat="server" ImageUrl="~/images/usercard.png" Width="36px"
                                        Height="34px" AlternateText="کارت ورود به آزمون" />
                                    <br />
                                    <asp:Label ID="Label10" runat="server" Text="کارت ورود به آزمون"></asp:Label>
                                </asp:LinkButton>
                            </td>
                            <td id="cellPoll" runat="server" style="padding-left: 20px; padding-right: 20px;
                                border-right: 2px solid #abc8e6; border-left: 2px solid #abc8e6; min-width: 80px;">
                                <asp:LinkButton ID="lnkPoll" runat="server" OnClick="lnkPoll_Click">
                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/images/poll.png" Width="36px" Height="34px"
                                        AlternateText="نظـرسنجـی" />
                                    <br />
                                    <asp:Label ID="Label9" runat="server" Text="نظـرسنجـی"></asp:Label>
                                </asp:LinkButton>
                            </td>
                            <td id="cellAttachments" runat="server" style="padding-left: 20px; padding-right: 20px;
                                border-right: 2px solid #abc8e6; border-left: 2px solid #abc8e6; min-width: 80px;">
                                <asp:LinkButton ID="lnkMedia" runat="server" OnClick="lnkMedia_Click">
                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/images/clip.png" Width="36px" Height="34px"
                                        AlternateText="پیـوسـت هـا" />
                                    <br />
                                    <asp:Label ID="Label8" runat="server" Text="پیـوسـت هـا"></asp:Label>
                                </asp:LinkButton>
                            </td>
                            <td style="padding-left: 20px; padding-right: 20px; border-right: 2px solid #abc8e6;
                                border-left: 2px solid #abc8e6; min-width: 80px;">
                                <asp:HyperLink ID="lnkReturn" runat="server" NavigateUrl="~/Student/Default.aspx">
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/return.png" Width="36px"
                                        Height="36px" AlternateText="بازگشت به صفحه اول" />
                                    <br />
                                    <asp:Label ID="Label5" runat="server" Text="بازگشت به صفحه اول"></asp:Label>
                                </asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <%--     Style="margin-right: -40px; float: right;"--%>
    <asp:Panel ID="Panel2" runat="server" Height="100%" Style="margin-right: -40px; float: right;">
        <%--                <telerik:ReportViewer ID="ReportViewer1" runat="server" Height="700px" Width="800px"--%>
        <%--                    ProgressText="صبـر کنـیـــد..." ToolbarVisible="False">--%>
        <%--                </telerik:ReportViewer>--%>
        <telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" Height="500px" Width="100%"
            Visible="false" />
    </asp:Panel>
    <table id="tblOralExamResult" runat="server" style="width: 100%; margin-left: auto;
        margin-right: auto;">
        <tr>
            <td style="background-color: #3772ab; color: #ffffff">
                <asp:Label ID="Label6" runat="server" Text="نتیجـه آزمــون مصـاحبــه" Font-Names="Tahoma"
                    Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr style="background-color: #e5e6e6;">
            <td style="font-family: tahoma; font-size: 11pt; padding-right: 10px; padding-left: 10px;
                text-align: justify;">
                <asp:Label ID="lblOralExamMark" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr style="background-color: #e5e6e6;">
            <td style="font-family: tahoma; font-size: 11pt; padding-right: 10px; padding-left: 10px;
                text-align: justify; text-align: left; direction: ltr">
                <asp:Label ID="lblOralExamResult" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <uc2:AttachmentView ID="AttachmentView1" runat="server" />
    <uc3:PollControl ID="PollControl1" runat="server" SubmitAction="ShowThanksPanel" />
</asp:Content>
