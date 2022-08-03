<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="Articles.aspx.cs" Inherits="Articles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <asp:HyperLink ID="HyperLink2" runat="server" Font-Names="Tahoma" Font-Size="10pt"
        NavigateUrl="News.aspx">مقـالـات و مطـالــب</asp:HyperLink>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    
    <table width="100%" cellpadding="0" cellspacing="0" style="font-family: Tahoma">
        <tr style="height: 25px;">
            <td style="border-top: 1px solid; border-bottom: 1px solid; text-align: center">
                <asp:Label ID="Label1" runat="server" Text="عنـــوان"></asp:Label>
            </td>
            <td style="border-top: 1px solid; border-bottom: 1px solid; text-align: center">
                <asp:Label ID="Label3" runat="server" Text="بخـــش"></asp:Label>
            </td>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr style="height: 25px; vertical-align: middle" onmouseover="this.style.backgroundColor='#E1EAFE';"
                    onmouseout="this.style.backgroundColor='transparent';">
                    <td style="border-bottom: 1px solid #000000; text-align: justify">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Section/Page.aspx?id=" + Eval("WebsiteSection.Id") + "&&pageid=" + Eval("Id") %>'
                            Style="width: 100%; display: block;">
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Title") %>' Font-Names="Tahoma"
                                Font-Size="10pt" Font-Bold="false"></asp:Label>
                        </asp:HyperLink>
                    </td>
                    <td style="border-bottom: 1px solid #000000; text-align: center">
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("WebsiteSection.Name") %>' Font-Names="Tahoma"
                            Font-Size="10pt" Font-Bold="false"></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
