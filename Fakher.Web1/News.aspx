<%@ Page Title="اخبار موسسه آموزش عالی فاخر" Language="C#" MasterPageFile="~/MainMasterPage.master"
    AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <asp:HyperLink ID="HyperLink2" runat="server" Font-Names="Tahoma" Font-Size="10pt" NavigateUrl="News.aspx">اخبـــار مـوسـســـه</asp:HyperLink>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <asp:Panel ID="pnlAllNews" runat="server" Direction="RightToLeft" Width="100%">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <table style="width: 100%; border-bottom: 1px dotted; padding-bottom: 10px;" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Title") %>' Font-Names="Tahoma"
                                Font-Size="11pt" Font-Bold="True"></asp:Label>
                        </td>
                        <td style="width: 64px" rowspan="3">
                            <asp:Image ID="Image1" runat="server" ImageUrl="images/news.png" Width="64px" Height="64px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>' Font-Names="Tahoma"
                                Font-Size="8.5pt"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Bind("AbstractHtml") %>'></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left;">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "News.aspx?Id=" + Eval("Id") %>'
                                Style="width: 100%; display: block;">ادامه خبــر...</asp:HyperLink>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
                <%--            <hr style="color: #fff; background-color: #fff; border: 1px dotted #000000; border-style: none none dotted;--%>
                <%--                margin-top: 10px; margin-bottom: 10px;" />--%>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </asp:Panel>
    <asp:Panel ID="pnlNewsDetail" runat="server" Direction="RightToLeft">
        <table>
            <tr>
                <td>
                    <div style="text-align: center; margin-left: auto; margin-right: auto;">
                        <asp:Label ID="lblTitle" runat="server" Text="" Font-Names="Tahoma" Font-Size="11pt"
                            Font-Bold="True"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDate" runat="server" Text="تاریخ" Font-Names="Tahoma" Font-Size="8.5pt">
                    </asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="  |  " Font-Names="Tahoma" Font-Size="8.5pt">
                    </asp:Label>
                    <asp:Label ID="lblHits" runat="server" Text="تعداد بازدید" Font-Names="Tahoma" Font-Size="8.5pt">
                    </asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table id="tblAbstract" runat="server" style="width: 95%; margin-left: auto; margin-right: auto;">
            <tr style="background-color: #e5e6e6;">
                <td style="text-align: justify; padding-right: 10px; padding-left:10px;border-bottom: 1px solid #3772ab; border-top: 1px solid #3772ab;">
                    <asp:Label ID="lblAbstract" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
    </asp:Panel>
</asp:Content>
