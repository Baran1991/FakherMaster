<%@ Page Title="موسسه آموزش عالی آزاد فاخر" Language="C#" MasterPageFile="~/MainMasterPage.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="uc3" TagName="PollControl" Src="~/UserControls/PollControl.ascx" %>
<%@ Import Namespace="Fakher.Core.Website" %>
<%@ Register Src="UserControls/BookControl.ascx" TagName="BookControl" TagPrefix="uc1" %>
<%--<%@ Register TagPrefix="uc1" TagName="rMessageBox" Src="~/rComponents/rMessageBox/rMessageBox.ascx" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content runat="server" ID="Top" ContentPlaceHolderID="TopContentPlaceHolder">
    <%--<uc1:rMessageBox ID="rMessageBox1" runat="server" />--%>
    <div class="col-md-5 " style="padding-top:20px;padding-bottom:20px;">
 <p style="font-size: 11pt; text-align: justify; margin-top: 0;">
                    موسسه آموزش عالی آزاد فاخر با کسب مجوز از وزارت علوم تحقیقات و فناوری در خیابان
                    قصردشت شیراز در فضای آموزشی 2500 مترمربع با رعایت آخرین استانداردهای آموزشی موردنظر
                    وزارت علوم، تحقیقات و فناوری تاسیس شده است. این موسسه به صورت کاملا علمی و تخصصی
                    در زمینه های <span style="color: #28A1D8;">حقوق، زبان های خارجی، موسیقی و کلاسهای امادگی
                        وکالت، قضاوت، سردفتری اسناد رسمی، آمادگی فراگیر پیام نور و کارشناسی ارشد و دکتری
                        حقوق و زبان های خارجی</span> فعالیت مینماید.
                </p>
                <p style="font-size: 11pt; text-align: justify;">
                    در این موسسه تلاش شده است تا تمام امکانات موردنیاز آموزشی برای دانشجویان علاقه مند
                    به تحصیل فراهم گردد. از جمله این امکانات می توان به وجود کتابخانه مجهز، میز مشاوره،
                    میز اینترنت پرسرعت، بوفه، ژتون پذیرایی، نمازخانه، کلاس های استاندارد، سیستم سرمایش
                    و گرمایش مناسب، فضای استراحت دانشجویان و سرویس ایاب و ذهاب دانشجو اشاره کرد.
                </p>
    </div>
    <div class="col-md-7">
         <div id="show" class="slideshow" style="padding: 4px 8px 4px 5px;">

<div id="myCarousel" class="carousel slide" data-ride="carousel">
 
                 <asp:Repeater ID="RepeaterSlider" runat="server"  OnItemDataBound="SliderRotator_ItemDataBound">
        <ItemTemplate>
            <div class="item">
            <asp:Image runat="server" ID="Image1" />
                </div>
        </ItemTemplate>
    </asp:Repeater>
    </div>
                  <%--  <telerik:RadRotator ID="RadRotator1" runat="server" Width="589px" Height="292px"
                        CssClass="" ScrollDuration="500" FrameDuration="5000" ItemWidth="589" ItemHeight="292"
                        OnItemDataBound="RadRotator1_ItemDataBound">
                        <ItemTemplate>
                            <telerik:RadBinaryImage runat="server" ID="radBinaryImage1" ResizeMode="Fit" Width="589" Height="292" />
                        </ItemTemplate>
                    </telerik:RadRotator>--%>
                </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
    
    <div class="panel-body">
    <asp:Repeater ID="Repeater3" runat="server">
        <ItemTemplate>
             <div class="list-item row side">
                       <h2> <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="<%# WebsiteManager.GetNavigateUrl((DataBinder.GetDataItem(Container) as WebsiteWidget).MenuItem) %>"
                           ><%# Eval("Title") %></asp:HyperLink></h2>
                
                         <asp:Label ID="Label4" runat="server"  Text='<%# Bind("Text") %>'></asp:Label>
                      
                    </div>
        </ItemTemplate>
    </asp:Repeater>
       </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
     <div class="col-md-6">
         <div class="panel panel-default">
             <div class="panel-heading">
                 <asp:Label ID="Label3" runat="server" Text="آخرین مطالب و مقالـات" ></asp:Label>
             </div>
             <div class="panel-body">
                 
                   <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
                                    <ItemTemplate>
                                         <div class="list-item row">
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/Section/Page.aspx?id=" + Eval("WebsiteSection.Id") + "&&pageid=" + Eval("Id") %>'  >
                                                 
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Title") %>' ></asp:Label>
                                                </asp:HyperLink>
                                            </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                   
             </div>
         </div>
         <div class="panel panel-default">
             <div class="panel-heading">
                  <asp:Label ID="Label6" runat="server" Text="آخرین اخبـار حوزه آموزش کشور" ></asp:Label>
             </div>
             <div class="panel-body">
                    <asp:Repeater ID="Repeater4" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="list-item row">
                                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/News.aspx?id=" + Eval("Id") %>'>
                                                   
                                                    <i class="fa fa-calendar"></i>
                                                    <asp:Label ID="lblNewsDate" runat="server" Text='<%# Bind("Date") %>' CssClass="date"></asp:Label>
                                                <br />
                                                    <asp:Label ID="lblNewsTitle" runat="server" Text='<%# Bind("Title") %>' ></asp:Label>
                                                </asp:HyperLink>
                                           </div>
                                    </ItemTemplate>
                                </asp:Repeater>
             </div>
         </div>
         
         </div>
    <div class="col-md-6">
         <div class="panel panel-default">
             <div class="panel-heading">
                    <asp:Label ID="Label1" runat="server" Text="آخرین اخبـار موسســه" ></asp:Label>
             </div>
             <div class="panel-body">
                  <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="list-item row">
                                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "~/News.aspx?id=" + Eval("Id") %>' >
                                                  <i class="fa fa-calendar"></i>
                                                    <asp:Label ID="lblNewsDate" runat="server" Text='<%# Bind("Date") %>' CssClass="date"></asp:Label>
                                                 <br />
                                                    <asp:Label ID="lblNewsTitle" runat="server" Text='<%# Bind("Title") %>' ></asp:Label>
                                                </asp:HyperLink>
                                           </div>
                                    </ItemTemplate>
                                </asp:Repeater>
             </div>
         </div>
             </div>
    
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bottomContentPlaceHolder" runat="Server">
<div class="col-md-8">
    
          <asp:Panel ID="pnlBooks" runat="server" Visible="False"><div class="panel panel-default">
                  <div class="panel-heading text-center">
                                <asp:Label ID="Label5" runat="server" Text="جزوات و کتاب ها" ></asp:Label>
                                <asp:Label ID="Label7" runat="server" CssClass="small center-block" Text="برای مشاهده جزئیات هر کتاب برروی نام آن کلیک کنید" ></asp:Label>
                          </div>
              <div class="panel-body">
                    <asp:ListView ID="ListViewBooks" runat="server" OnItemDataBound="ListViewBooks_ItemDataBound" GroupItemCount="4" GroupPlaceholderID="groupPlaceholder" ItemPlaceholderID="itemPlaceholder">
                        <LayoutTemplate>
                            <table width="100%" >

                                <tr id="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <GroupTemplate>
                            <tr>
                                <td id="itemPlaceholder" runat="server"></td>
                            </tr>
                        </GroupTemplate>
                        <ItemTemplate>
                            <td>
                                <uc1:BookControl ID="BookControl1" runat="server" />
                            </td>
                        </ItemTemplate>
                    </asp:ListView></div>
               </div>  </asp:Panel>
        </div>
   
    <div class="col-md-4">
             <uc3:PollControl ID="PollControl1" runat="server" SubmitAction="ShowThanksPanel" />
                       
    </div>
    <div class="col-md-12">
          <asp:Panel ID="pnlNewsletter" runat="server" Font-Names="Tahoma" Visible="True">
                    <table style="width: 100%">
                        <tr>
                            <td class="heading2">
                                <asp:Label ID="Label11" runat="server" Text="خـبــــرنــامه پیامکـی سایت" Font-Names="Tahoma" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #ECECEC;">
                            <td style="text-align: center; padding: 5px 0px;">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="RadTxtNewsletterPhone" runat="server" 
                                                CssClass="form-control" EmptyMessage="شماره تلفن همراه">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnNewsletterSubmit" runat="server" Text="عضویت!" CssClass="btn btn-default"
                                                OnClick="btnNewsletterSubmit_Click">
                                            </asp:Button>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlNewsletterThanks" runat="server" Font-Names="Tahoma" Visible="False">
                    <table style="width: 100%">
                        <tr>
                            <td class="heading2">
                                <asp:Label ID="Label2" runat="server" Text="خـبــــرنــامه پیامکـی سایت" Font-Names="Tahoma" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr style="background-color: #ECECEC;">
                            <td style="text-align: center; padding: 5px 0px;">
                                <asp:Label ID="Label8" runat="server" Text="با تشکر، مشخصات شما ثبت گردید." Font-Bold="True"
                                    Font-Size="12pt"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
    </div>
    </asp:Content>