<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserBar.ascx.cs" Inherits="Components_UserBar" %>
<asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="False">
<span style="float: left; direction: rtl">
    <asp:Label ID="Label2" runat="server" Text="نام و نام خانوادگی" Font-Names="Tahoma" Font-Size="9pt"></asp:Label>
    &&nbsp;
    <asp:Label ID="Label1" runat="server" Text="[ " Font-Names="Tahoma"></asp:Label>
    <asp:LinkButton ID="lnkBtnEducationalPanel" runat="server" Font-Names="Tahoma" OnClick="lnkBtnEducationalPanel_OnClick" ForeColor="#ffffff" CausesValidation="false">سیـسـتـم آمـــوزش</asp:LinkButton>
    <asp:Label ID="Label4" runat="server" Text=" | " Font-Names="Tahoma"></asp:Label>
    <asp:LinkButton ID="lnkBtnSignout" runat="server" Font-Names="Tahoma" OnClick="lnkBtnSignout_OnClick" ForeColor="#ffffff" CausesValidation="false">خـــــروج</asp:LinkButton>
    <asp:Label ID="Label3" runat="server" Text=" ]" Font-Names="Tahoma"></asp:Label>
</span>
</asp:PlaceHolder>
