<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PollControl.ascx.cs" Inherits="UserControls_PollControl" %>
<asp:Panel ID="pnlPoll" runat="server" Font-Names="Tahoma" Visible="False">
    <div class="panel panel-default">
        <div class="panel-heading">
     <asp:Label ID="Label11" runat="server" Text="نظــرسنـجــی" ></asp:Label>
           
        </div>
        <div class="panel-body">
              <table width="100%">
                    <tr>
                        <td style="padding: 0px 10px;">
                            <asp:Label ID="lblText" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 0px 30px;">
                            <asp:RadioButtonList ID="RadioButtonListItems" runat="server">
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:Button ID="btnSubmit" runat="server" Text="ثبـت نظــر" Width="75px" OnClick="btnSubmit_Click"
                                Font-Names="Tahoma" />
                        </td>
                    </tr>
                </table>
        </div>
    </div>
   
</asp:Panel>
<asp:Panel ID="pnlThanks" runat="server" Font-Names="Tahoma" Visible="False">
    <table style="width: 100%">
        <tr>
            <td class="heading2">
                <asp:Label ID="Label2" runat="server" Text="نظــرسنـجــی" Font-Names="Tahoma" Font-Bold="true"></asp:Label>
            </td>
        </tr>
        <tr style="background-color: #ECECEC;">
            <td style="text-align: center; padding: 5px 0px;">
                <asp:Label ID="Label1" runat="server" Text="با تشکر، نظر شما ثبت گردید." Font-Bold="True"
                    Font-Size="12pt"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
