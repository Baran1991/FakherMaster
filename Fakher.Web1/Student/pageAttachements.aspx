<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="pageAttachements.aspx.cs" Inherits="Student_pageAttachements" %>

<%@ Register Assembly="Telerik.ReportViewer.Html5.WebForms, Version=14.1.20.618, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.Html5.WebForms" TagPrefix="telerik" %>
<%--<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=5.1.11.713, Culture=neutral, PublicKeyToken=a9d7983dfcc261be"
    Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>--%>
<%@ Register TagPrefix="uc1" TagName="rMessageBox" Src="~/rComponents/rMessageBox/rMessageBox.ascx" %>
<%@ Register Src="~/UserControls/AttachmentView.ascx" TagName="AttachmentView" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/PollControl.ascx" TagName="PollControl" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" />
    <asp:Label ID="Label1" runat="server" Text="لیست پیوست ها" Font-Names="Tahoma"></asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
   
      <telerik:RadGrid ID="RadGrid1" runat="server" OnItemDataBound="RadGrid1_ItemDataBound" AutoGenerateColumns="False" Font-Names="Tahoma" OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged">
            <ItemStyle CssClass="CustomStyle"></ItemStyle>
            <AlternatingItemStyle CssClass="CustomStyle"></AlternatingItemStyle>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" Font-Names="Tahoma">
            </HeaderContextMenu>
            <MasterTableView DataKeyNames="Id" Dir="RTL" NoMasterRecordsText="رکوردی برای نمایش وجود ندارد">
                
                <Columns>
                    <telerik:GridTemplateColumn HeaderText="ردیف">
                        <ItemTemplate>
                            <asp:Label ID="lblIndex" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    
                    <telerik:GridBoundColumn DataField="SectionItem.Lesson.Name" HeaderText="نــام درس/سـطــح">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="SectionItem.Section.FarsiName" HeaderText="گـــروه">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="پیوست">
                        <ItemTemplate>
                           <asp:Image ID="Image2" runat="server" ImageUrl="~/images/clip.png" Width="36px" Height="34px"
                                        AlternateText="پیـوسـت هـا" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    
                </Columns>
              
            </MasterTableView>
            <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="True">
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
        </telerik:RadGrid>
    <uc2:AttachmentView ID="AttachmentView1" runat="server" />
   
</asp:Content>
