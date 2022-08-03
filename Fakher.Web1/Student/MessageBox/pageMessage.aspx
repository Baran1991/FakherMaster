<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="pageMessage.aspx.cs" Inherits="Student_MessageBox_pageMessage" %>
<%@ Register TagPrefix="uc2" TagName="AttachmentView" Src="~/UserControls/AttachmentView.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <asp:HyperLink ID="Label5" runat="server" Text="صنـدوق پیـام استـاد" Font-Names="Tahoma" NavigateUrl="~/Instructor/MessageBox/Default.aspx"></asp:HyperLink>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
     <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Left" Style="padding: 5px 0px;">
            <telerik:RadButton ID="btnReply" runat="server" Text="ارسال پاسخ" Font-Names="Tahoma"
                Width="150px" OnClick="btnReply_Click">
                <Icon SecondaryIconUrl="~/images/undo.png"></Icon>
            </telerik:RadButton>
        </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" Font-Size="10pt">
        <table width="100%">
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White; width: 200px;">
                    <asp:Label ID="Label1" runat="server" Text="فرستنـده:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">
                    <asp:Label ID="lblSender" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White; width: 200px;">
                    <asp:Label ID="Label2" runat="server" Text="گیـرنـده:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">
                    <asp:Label ID="lblReciever" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White; width: 200px;">
                    <asp:Label ID="Label3" runat="server" Text="عنــوان:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">
                    <asp:Label ID="lblSubject" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #4682B4; text-align: left; color: White; width: 200px;"
                    valign="top">
                    <asp:Label ID="Label4" runat="server" Text="متـن پیـام:"></asp:Label>
                </td>
                <td style="background-color: #dddddd; text-align: right; vertical-align: middle">
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" ReadOnly="True" Width="99%"
                        Height="350px" Font-Names="Tahoma"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td style="vertical-align: top" colspan="2">
                    <uc2:AttachmentView ID="AttachmentView1" runat="server" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
