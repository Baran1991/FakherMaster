<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PollControl.ascx.cs" Inherits="UserControls_PollControl" %>
<style>
    .flex{
        display:flex;
    }
    .radioStyle label
    {
        font-weight:normal;
         margin-left: 5px !important;
    }
    .hidden
    {
        display:none;
    }
</style>
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
                            <asp:Repeater ID="RepeaterPollItems" runat="server">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Bind("Id") %>' ID="lblItemID" CssClass="hidden"></asp:Label>
                              <div style="border-bottom:1px dashed #c9c7c7" >   <span style="font-weight:bold">  <asp:Label ID="lblItem" runat="server" Text='<%# Bind("Text") %>' ></asp:Label></span>
                                  <br />
<asp:RadioButtonList ID="RadioButtonListItems" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="radioStyle">
    <asp:ListItem Value="1" Text="خیلی خوب" Selected="True" ></asp:ListItem>
     <asp:ListItem Value="2" Text=" خوب"></asp:ListItem>
     <asp:ListItem Value="3" Text="متوسط"></asp:ListItem>
     <asp:ListItem Value="4" Text="ضعیف"></asp:ListItem>
                            </asp:RadioButtonList></div> 
                                </ItemTemplate>
                            </asp:Repeater>
                            
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:Button ID="btnSubmit" runat="server" Text="ثبـت نظــر" Width="75px" OnClick="btnSubmit_Click"
                                 />
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
