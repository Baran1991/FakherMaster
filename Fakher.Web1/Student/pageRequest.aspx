<%@ Page Title="درخواست ها" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master"
    AutoEventWireup="true" CodeFile="pageRequest.aspx.cs" Inherits="Student_pageRequest" %>

<%@ Register Assembly="Telerik.ReportViewer.Html5.WebForms, Version=14.1.20.618, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.Html5.WebForms" TagPrefix="telerik" %>
<%--<%@ Register TagPrefix="telerik" Namespace="Telerik.ReportViewer.WebForms" Assembly="Telerik.ReportViewer.WebForms, Version=5.1.11.713, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" Title="درخواست" VisibleOnPageLoad="True"
                Width="600px" Height="420px" VisibleTitlebar="true" VisibleStatusbar="False"
                Visible="False" Style="z-index: 200001;overflow:auto;" Behaviors="Close">
                <ContentTemplate>
                    <div class="col-md-12">
                        <div class="form-group">
 <asp:Label ID="Label1" runat="server" Text="عنوان درخواست"></asp:Label>
                             <asp:DropDownList ID="RadTxtTitle" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="صدور گواهی اشتغال به تحصیل "  Value="صدور گواهی اشتغال به تحصل "></asp:ListItem>
                                    <asp:ListItem Text="صدور مدرک  " Value="صدور مدرک  " ></asp:ListItem>
                                    <asp:ListItem Text="امور مالی و شهریه  " Value="امور مالی و شهریه  "></asp:ListItem>
                                    <asp:ListItem Text=" انصراف  تغییر آزمون"  Value=" انصراف  تغییر آزمون"></asp:ListItem>
                                    <asp:ListItem Text="آزمون مجدد" Value="آزمون مجدد"></asp:ListItem>
                                    <asp:ListItem Text="ثبت نام در مصاحبه" Value="ثبت نام در مصاحبه"></asp:ListItem>
                                    <asp:ListItem Text="مصاحبه مجدد" Value="مصاحبه مجدد"></asp:ListItem>
                                    <asp:ListItem Text="تغییر کلاس" Value="تغییر کلاس"></asp:ListItem>
                                    <asp:ListItem Text="انتقادات" Value="انتقادات" ></asp:ListItem>
                                    <asp:ListItem Text="پیشنهادات" Value="پیشنهادات"></asp:ListItem>
                                    <asp:ListItem Text="سایر "  Value="سایر " ></asp:ListItem>
                                </asp:DropDownList>
                        </div>
                        <div id="prevText" runat="server" visible="false">
                           <div class="alert alert-info">پیام شما:   <asp:Label ID="lblPreText" runat="server" ></asp:Label></div>
                           <div class="alert alert-info">پاسخ شورای آموزش: <asp:Label ID="lblResDate1" runat="server" ></asp:Label> <br /><asp:Label ID="lblPreResponse" runat="server" ></asp:Label></div>
                        </div>
                               <div class="form-group">
                             <asp:Label ID="Label2" runat="server" Text="متن درخواست"></asp:Label>
                              <telerik:RadTextBox ID="RadTxtText" Width="100%" runat="server" CssClass="form-control" TextMode="MultiLine"
                                   Height="300px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="RadTxtText" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                              <asp:Label ID="Label11" runat="server" Text="نتیجـه شورای آموزش" 
                                    Font-Bold="true"></asp:Label><asp:Label ID="lblResDate2" runat="server" ></asp:Label> <br />
                             <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                        </div>
                        
                     
                    </div>
                  
             
                    <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center" Font-Names="Tahoma">
                        <telerik:RadButton ID="radBtnOk" runat="server" Text="تایـیــد" Font-Names="Tahoma"
                            Width="95px" OnClick="radBtnOk_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="radBtnCancel" runat="server" Text="انصـراف" Font-Names="Tahoma"
                            Width="95px" CausesValidation="False">
                        </telerik:RadButton>
                    </asp:Panel>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged"
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
                <telerik:GridBoundColumn DataField="CreateDateTime" HeaderText="تاریخ ثبت">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Title" HeaderText="عنوان">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="StatusText" HeaderText="وضعیت">
                </telerik:GridBoundColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="True">
            <Selecting AllowRowSelect="True" />
        </ClientSettings>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
    </telerik:RadGrid>
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left">
        <telerik:RadButton ID="btnNewRequest" runat="server" Text="درخواست جــدیــد" Font-Names="Tahoma"
            Width="150px" OnClick="btnNewRequest_Click" Visible="True">
            <Icon SecondaryIconUrl="~/images/Plus.png"></Icon>
        </telerik:RadButton>
    </asp:Panel>
</asp:Content>
