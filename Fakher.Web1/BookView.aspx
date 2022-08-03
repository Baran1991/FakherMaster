<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="BookView.aspx.cs" Inherits="BookView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <asp:Label ID="HyperLink2" runat="server" Font-Names="Tahoma" Font-Size="10pt">جزوات و کتاب ها</asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" Font-Size="10pt">
        <table width="100%">
            <tr>
                <td style="width: 150px" valign="top">
                    <telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" Width="150px" Height="200px"
                        ResizeMode="Fit" Visible="False" />
                    <asp:Image ID="Image1" runat="server" Width="60px" Height="40px" Visible="False" />
                </td>
                <td valign="top" style="padding-right: 20px">
                    <asp:Label ID="lblName" runat="server" Text="Label" Font-Bold="True" ForeColor="Orange"
                        Font-Size="12pt"></asp:Label>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="نویسنده: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblAuthor" runat="server" Text="نویسنده: "></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="قیمت: " Font-Bold="True"></asp:Label>
                    <asp:Label ID="lblPrice" runat="server" Text="نویسنده: "></asp:Label>
                    <br />
                    <asp:Label ID="lblStatus" runat="server" Text="" Font-Italic="True"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="توضیحات: " Font-Bold="True"></asp:Label>
                    <br />
                    <blockquote>
                        <asp:Label ID="lblDescription" runat="server" Text="نویسنده: "></asp:Label>
                    </blockquote>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
