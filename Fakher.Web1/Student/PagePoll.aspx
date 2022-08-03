<%@ Page Title="صفحه نظر سنجی" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="PagePoll.aspx.cs" Inherits="Student_PagePoll"
    Culture="fa-IR" %>


<%@ Register Src="~/rComponents/rMessageBox/rMessageBox.ascx" TagName="rMessageBox"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/PollControl.ascx" TagName="PollControl" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" />
    <asp:Label ID="Label3" runat="server" Text="صفحه نظرسنجی" Font-Names="Tahoma" Font-Size="10pt"></asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
  <p>دانشجوی گرامی بمنظور استفاده از امکانات سایت ابتدا نظر سنجی را پاسخ دهید.</p>
     <uc3:PollControl ID="PollControl1" runat="server" SubmitAction="ShowThanksPanel" />
   
</asp:Content>
