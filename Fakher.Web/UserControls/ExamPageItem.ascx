<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExamPageItem.ascx.cs"
    Inherits="Components_ExamPageItem" %>
<asp:Panel ID="pnlTextPageItem" runat="server" Visible="false">
    <asp:Literal ID="LiteralText" runat="server"></asp:Literal>
</asp:Panel>
<asp:Panel ID="pnlExamTestQuestion" runat="server" Visible="false">
    <table style="width: 100%;">
        <tr>
            <td style="vertical-align: middle; width: 10px">
                <asp:Label ID="lblTestIndex" runat="server" Text="Label" Font-Names="Tahoma" Font-Bold="True"
                    Font-Size="10pt"></asp:Label>
            </td>
            <td style="vertical-align: middle;" colspan="5">
                <asp:Literal ID="LiteralTestQuestionText" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 30px;">
                <asp:RadioButton ID="RadioButton1" runat="server" />
            </td>
            <td style="vertical-align: top;">
                <asp:Label ID="Label2" runat="server" Text="الف) " Font-Bold="True" Font-Names="Tahoma"></asp:Label>
            </td>
            <td style="vertical-align: top;">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
            <td style="vertical-align: top; width: 30px;">
                <asp:RadioButton ID="RadioButton2" runat="server" />
            </td>
            <td style="vertical-align: top;">
                <asp:Label ID="Label3" runat="server" Text="ب) " Font-Bold="True" Font-Names="Tahoma"></asp:Label>
            </td>
            <td style="vertical-align: top;">
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 30px;">
                <asp:RadioButton ID="RadioButton3" runat="server" />
            </td>
            <td style="vertical-align: top;">
                <asp:Label ID="Label4" runat="server" Text="ج) " Font-Bold="True" Font-Names="Tahoma"></asp:Label>
            </td>
            <td style="vertical-align: top;">
                <asp:Literal ID="Literal3" runat="server"></asp:Literal>
            </td>
            <td style="vertical-align: top; width: 30px;">
                <asp:RadioButton ID="RadioButton4" runat="server" />
            </td>
            <td style="vertical-align: top;">
                <asp:Label ID="Label5" runat="server" Text="د) " Font-Bold="True" Font-Names="Tahoma"></asp:Label>
            </td>
            <td style="vertical-align: top;">
                <asp:Literal ID="Literal4" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlExamEssayQuestion" runat="server" Visible="false">
    <table style="width: 100%;">
        <tr>
            <td style="vertical-align: middle; width: 10px">
                <asp:Label ID="lblEssayIndex" runat="server" Text="Label" Font-Names="Tahoma" Font-Bold="True"
                    Font-Size="10pt"></asp:Label>
            </td>
            <td style="vertical-align: middle;">
                <asp:Literal ID="LiteralEssayQuestionText" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:TextBox ID="txtEssayText" runat="server" TextMode="MultiLine" Width="100%" 
                    Height="150px" BorderStyle="Dashed"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Panel>
