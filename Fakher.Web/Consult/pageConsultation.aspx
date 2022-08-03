<%@ Page Title="" Language="C#" MasterPageFile="~/Consult/ConsultMasterPage.master"
    AutoEventWireup="true" CodeFile="pageConsultation.aspx.cs" Inherits="Consult_pageConsultation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <asp:HyperLink ID="HyperLink2" runat="server" Font-Names="Tahoma" Font-Size="10pt"
        NavigateUrl="~/Consult/Default.aspx">مــرکز مشــاوره فاخــر</asp:HyperLink>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <asp:Panel ID="Panel2" runat="server" Font-Names="Tahoma" Direction="RightToLeft"
        Font-Size="11pt">
        <table style="width: 100%">
            <tr>
                <td style="background-color: #3772ab; height: 25px; color: #ffffff; width: 100%;
                    text-align: right; padding: 0px 10px;">
                    <asp:Label ID="lblTitle" runat="server" Text="" Font-Names="Tahoma" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #e5e6e6; text-align: justify; vertical-align: top; padding: 0px 10px;">
                    <asp:Label ID="Label1" runat="server" Text="ســوال: " ForeColor="Red" Font-Bold="True"></asp:Label>
                    <blockquote>
                        <asp:Label ID="lblQuestion" runat="server" Text=""></asp:Label>
                    </blockquote>
                    <br />
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="پاســـخ: " ForeColor="Blue" Font-Bold="True"></asp:Label>
                    <blockquote>
                        <asp:Label ID="lblAnswer" runat="server" Text=""></asp:Label>
                    </blockquote>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="background-color: #3772ab; height: 25px; text-align: justify; color: #ffffff;
                    vertical-align: top; padding: 0px 10px;">
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="Label3" runat="server" Text="کــد پیگیری: "></asp:Label>
                                <asp:Label ID="lblCode" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="Label4" runat="server" Text="تعداد بازدید: "></asp:Label>
                                <asp:Label ID="lblHits" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
