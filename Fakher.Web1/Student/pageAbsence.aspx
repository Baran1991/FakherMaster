<%@ Page Title="درخواست ها" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="pageAbsence.aspx.cs" Inherits="Student_pageAbsence" %>

<%--<%@ Register TagPrefix="telerik" Namespace="Telerik.ReportViewer.WebForms" Assembly="Telerik.ReportViewer.WebForms, Version=5.1.11.713, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
  
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
        OnItemDataBound="RadGrid1_ItemDataBound" Font-Names="Tahoma">
        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" Font-Names="Tahoma">
        </HeaderContextMenu>
        <MasterTableView DataKeyNames="Id" Dir="RTL" NoMasterRecordsText="رکوردی برای نمایش وجود ندارد"
            Font-Names="Tahoma">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="ردیف">
                    <ItemTemplate>
                        <asp:Label ID="lblIndex" runat="server" Text="Label"></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="Date" HeaderText="تاریخ غیبت">
                </telerik:GridBoundColumn>
                
               
                <telerik:GridBoundColumn DataField="SectionItem.Lesson.Name" HeaderText="درس">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="SectionItem.Section.Name" HeaderText="کلاس">
                </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="StatusText" HeaderText="وضعیت">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Reason" HeaderText="دلیل">
                </telerik:GridBoundColumn>
            </Columns>
        
        </MasterTableView>
        
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
    </telerik:RadGrid>
 
</asp:Content>
