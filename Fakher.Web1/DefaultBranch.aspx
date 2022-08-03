<%@ Page Title="موسسه آموزش عالی آزاد فاخر" Language="C#" MasterPageFile="~/BranchMasterPage.master"
    AutoEventWireup="true" CodeFile="DefaultBranch.aspx.cs" Inherits="_DefaultBranch" %>

<%@ Import Namespace="Fakher.Core.Website" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content runat="server" ID="Top" ContentPlaceHolderID="TopContentPlaceHolder">
    <div class="text-center">
        <h2 id="title" runat="server"></h2>
  <div class="col-md-4 col-md-offset-4" style="margin-top:20px;">
<asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-primary" NavigateUrl="~/Student/Default.aspx">سیستم آموزش دانشجویان</asp:HyperLink>
  </div>  
    <div class="col-md-4 col-md-offset-4" style="margin-top:20px;">
     <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="btn btn-primary" NavigateUrl="~/Instructor/Default.aspx">سیستم آموزش اساتید</asp:HyperLink>
        </div>
    <div class="col-md-4 col-md-offset-4" style="margin-top:20px;margin-bottom:20px;">
     <asp:HyperLink ID="HyperLink3" runat="server"  CssClass="btn btn-primary" NavigateUrl="~/Student/pageCredential.aspx">دریافت شناسه کاربری</asp:HyperLink>
        </div></div>
</asp:Content>

