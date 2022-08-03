<%@ Page Title="" Language="C#" MasterPageFile="~/Student/OnlineExam/ExamMasterPage.master"
    AutoEventWireup="true" CodeFile="pageExamPage.aspx.cs" Inherits="Student_OnlineExam_pageExamPage" %>

<%@ Register Src="~/UserControls/ExamPage.ascx" TagName="ExamPage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        var remainingTimeHour;
        var remainingTimeMinute;
        var remainingTimeSecond;
        var lblDuration;
        
        function updateRemainingTime() {
            if (remainingTimeHour == 0 && remainingTimeMinute == 0 && remainingTimeSecond == 0)
                return;
            if (lblDuration == null)
                return;

            remainingTimeSecond--;

            if (remainingTimeSecond < 0) {
                remainingTimeMinute--;
                remainingTimeSecond = 59;
                if (remainingTimeMinute < 0) {
                    remainingTimeHour--;
                    remainingTimeMinute = 59;
                }
            }

            if (remainingTimeHour < 0) {
                remainingTimeHour = 0;
                remainingTimeMinute = 0;
                remainingTimeSecond = 0;
            }

            var hour = remainingTimeHour < 10 ? '0' + remainingTimeHour : remainingTimeHour;
            var minute = remainingTimeMinute < 10 ? '0' + remainingTimeMinute : remainingTimeMinute;
            var second = remainingTimeSecond < 10 ? '0' + remainingTimeSecond : remainingTimeSecond;

            lblDuration.innerText = "زمان باقیمانده: " + hour + ':' + minute + ':' + second;
            lblDuration.textContent = "زمان باقیمانده: " + hour + ':' + minute + ':' + second;
        }
    </script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TopContentPlaceHolder" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td style="text-align: right; padding-right: 12px;">
                <asp:Label ID="lblTopExamText" runat="server" Text="Label" Font-Names="Tahoma" Font-Size="11pt"
                    ForeColor="#FFFFFF"></asp:Label>
            </td>
            <td style="text-align: left; padding-left: 93px;">
                <asp:Label ID="lblDuration" runat="server" Text="Label" Font-Names="Tahoma" Font-Size="11pt"
                    ForeColor="#FFFFFF" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:ExamPage ID="ExamPage1" runat="server" />
    <br />
    <br />
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma">
        <table style="width: 100%; background-color: #e5e6e6; border-top: 1px dashed black">
            <tr>
                <td style="text-align: right">
                    <asp:Button ID="btnPrevPage" runat="server" Text="<< ثبـت و صفحـه قبـل" Width="200px"
                        Font-Names="Tahoma" OnClick="btnPrevPage_Click" />
                </td>
                <td style="text-align: left">
                    <asp:Button ID="btnNextPage" runat="server" Text="ثبـت و صفحــه بعـد >>" Width="200px"
                        Font-Names="Tahoma" OnClick="btnNextPage_Click" />
                </td>
            </tr>
        </table>
    </asp:Panel>
<%--    <div style="display: none">--%>
<%--        <iframe id="defibrillator" src="pageDefibrillator.aspx" frameborder="0" width="0"--%>
<%--            height="0"></iframe>--%>
<%--    </div>--%>
</asp:Content>
