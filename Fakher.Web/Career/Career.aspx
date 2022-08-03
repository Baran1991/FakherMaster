<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage1.master" AutoEventWireup="true"
    CodeFile="Career.aspx.cs" Inherits="Career_Career" %>

<%--<%@ Register Src="../rComponents/rMessageBox/rMessageBox.ascx" TagName="rMessageBox"
    TagPrefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/Content/js/inputmask/jasny-bootstrap.min.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <%--<uc1:rMessageBox ID="rMessageBox1" runat="server" />--%>
    <asp:Panel ID="pnlDetails" runat="server" Font-Names="Tahoma" Direction="RightToLeft"
       >
        <div class="">
            <div class="col-md-12">
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </div>
            <div class="row ">
 <h2 class="heading"><asp:Label ID="Label6" runat="server" Text="فرم درخواست همکاری" 
                                    ></asp:Label></h2>
            </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                     <asp:Label ID="Label11" runat="server" Text="اطلـاعــات فــردی*" ></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="col-md-4">
           <asp:Label ID="Label1" runat="server" Text="نـــام:"></asp:Label>
                                 <asp:TextBox CssClass="form-control" ID="RadTxtFirstname" runat="server" >
                                            </asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                                ControlToValidate="RadTxtFirstname" Display="Dynamic" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                              <asp:Label ID="Label2" runat="server" Text="نـــام خـانوادگــی:"></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="RadTxtLastname" runat="server" >
                                            </asp:TextBox >  
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                ControlToValidate="RadTxtLastname" Display="Dynamic" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                               <asp:Label ID="Label5" runat="server" Text="نـــام پــدر:"></asp:Label>
                                <asp:TextBox CssClass="form-control" ID="RadTxtFathername" runat="server" >
                                            </asp:TextBox >      
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                                ControlToValidate="RadTxtFathername" Display="Dynamic" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4 flex">
                         <asp:Label ID="Label3" runat="server" Text="جنسیت:"></asp:Label>
                         <asp:RadioButtonList ID="rBtnGenderType" runat="server" RepeatDirection="Horizontal"
                                              CssClass="form-control">
                                                <Items>
                                                    <asp:ListItem Selected="True">مــرد</asp:ListItem>
                                                    <asp:ListItem>زن</asp:ListItem>
                                                </Items>
                                            </asp:RadioButtonList>
                    </div>
                    <div class="col-md-4">
                          <asp:Label ID="Label4" runat="server" Text="وضعیت تاهل:"></asp:Label>
                         <asp:RadioButtonList CssClass="form-control" ID="rBtnMarriageStatus" runat="server" RepeatDirection="Horizontal"
                                                Font-Names="Tahoma">
                                                <Items>
                                                    <asp:ListItem Selected="True">مجــرد</asp:ListItem>
                                                    <asp:ListItem>متاهـل</asp:ListItem>
                                                </Items>
                                            </asp:RadioButtonList>
                    </div>
                    <div class="col-md-4">
                          <asp:Label ID="Label7" runat="server" Text="کــدملـی:"></asp:Label>
                         <asp:TextBox CssClass="form-control" ID="rTxtNationalCode" runat="server" >
                                            </asp:TextBox >
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                                ControlToValidate="rTxtNationalCode" Display="Dynamic" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                            <asp:Label ID="Label8" runat="server" Text="شمـاره شناسنامه:"></asp:Label>
                          <asp:TextBox CssClass="form-control" ID="rTxtIdNumber" runat="server" >
                                            </asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                                ControlToValidate="rTxtIdNumber" Display="Dynamic" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                                 <asp:Label ID="Label9" runat="server" Text="تـاریخ تـولـد:"></asp:Label>
                         <asp:TextBox ID="rTxtBirthDate" runat="server"  data-mask="9999/99/99"
                                                CssClass="form-control ">
                                            </asp:TextBox>
                                  <%-- <telerik:RadMaskedTextBox ID="rTxtBirthDate" runat="server" Mask="####/##/##"
                                                CssClass="form-control">
                                            </telerik:RadMaskedTextBox>--%>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                                                ControlToValidate="rTxtBirthDate" Display="Dynamic" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                          <asp:Label ID="Label10" runat="server" Text="محــل تـولـد:"></asp:Label>
                         <asp:TextBox CssClass="form-control" ID="rTxtBirthPlace" runat="server">
                                            </asp:TextBox >
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                                                ControlToValidate="rTxtBirthPlace" Display="Dynamic" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
             <div class="panel panel-primary">
                <div class="panel-heading">
                    <asp:Label ID="Label12" runat="server" Text="اطلـاعــات تحصیلـی*" ></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="col-md-3">
                                     <asp:Label ID="Label13" runat="server" Text="مدرک تحصیلی: " ></asp:Label>
                                <asp:DropDownList ID="RadCmbEducationalDegree" runat="server" DataTextField="Description" CssClass="form-control"
                                                DataValueField="Value">
                                            </asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                         <asp:Label ID="Label14" runat="server" Text="رشته تحصیلی: " ></asp:Label>
                          <asp:TextBox CssClass="form-control" ID="RadTxtEducationalMajor" runat="server" >
                                            </asp:TextBox >
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                                                ControlToValidate="RadTxtEducationalMajor" Display="Dynamic" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                                  <asp:Label ID="Label15" runat="server" Text="محل اخذ مدرک: "></asp:Label>
                                  <asp:TextBox CssClass="form-control" ID="RadTxtEcuationalUniversity" runat="server">
                                            </asp:TextBox>  
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*"
                                                ControlToValidate="RadTxtEcuationalUniversity" Display="Dynamic" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                           <asp:Label ID="Label23" runat="server" Text="معــدل: " ></asp:Label>
                        <asp:TextBox ID="RadTxtEducationalDegreeMark" runat="server"
                                                CssClass="form-control"  data-mask="99.99">
                                            </asp:TextBox>
                         <%--<telerik:RadMaskedTextBox ID="RadTxtEducationalDegreeMark" runat="server" Mask="##.##"
                                                CssClass="form-control" Text="00.00">
                                            </telerik:RadMaskedTextBox>--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*"
                                                ControlToValidate="RadTxtEducationalDegreeMark" Display="Dynamic" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>

                    </div>
                    
                    </div>
                 </div>
             <div class="panel panel-primary">
                <div class="panel-heading">
                   <asp:Label ID="Label16" runat="server" Text="اطلـاعــات ارتباطی*" 
                                   ></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="col-md-4">
                                  <asp:Label ID="Label17" runat="server" Text="تلفـن:"></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="RadTxtPhone" runat="server" >
                                            </asp:TextBox>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*"
                                                ControlToValidate="RadTxtPhone" Display="Dynamic" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                                 <asp:Label ID="Label18" runat="server" Text="تلفن همــراه:"></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="RadTxtMobile" runat="server">
                                            </asp:TextBox > 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*"
                                                ControlToValidate="RadTxtMobile" Display="Dynamic" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4">
                               <asp:Label ID="Label19" runat="server" Text="ایمیل:"></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="RadTxtEmail" runat="server">
                                            </asp:TextBox >    
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*"
                                                ControlToValidate="RadTxtEmail" Display="Dynamic" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-12">
                                <asp:Label ID="Label21" runat="server" Text="آدرس:"></asp:Label>
                                    <asp:TextBox CssClass="form-control" ID="RadTxtAddress" runat="server">
                                            </asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*"
                                                ControlToValidate="RadTxtAddress" Display="Dynamic" SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                    </div>
                   
                    </div>
                 </div>
            <div class="panel panel-primary">
                <div class="panel-heading">
                     
                          <asp:Label ID="Label20" runat="server" Text="خلاصه ای از سوابق کاری" 
                                 ></asp:Label>
                  
                </div>
                <div class="panel-body">
                    <asp:TextBox CssClass="form-control" ID="RadTxtExperiences" runat="server" TextMode="MultiLine" Width="99%" Height="100px">
                                </asp:TextBox>
                </div>
            </div>
            <div class="col-md-12">
                     <asp:CheckBox ID="chkPolicy" CssClass="form-control" runat="server" Text="اینجانب با کمال دقت، صحت و صراحت به همه سوالات مربوطه پاسخ صحیح و کامل داده ام." />
              
            </div>
        </div>
    
        <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
            <br />
            <br />
            <hr />
            <asp:Button ID="RadBtnOk" CssClass="btn btn-primary" runat="server" Text="ارسـال مشخصـات" 
               OnClick="RadBtnOk_Click">
            </asp:Button>
             <br />
            <br />
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="pnlOk" runat="server" Visible="False" HorizontalAlign="Center">
        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
        <br/>
        <asp:Label ID="Label24" runat="server" Text="در صورت لزوم از سوی موسسه با شما تماس گرفته خواهد شد." Font-Bold="True"></asp:Label>
        <br/>
        <asp:Label ID="Label22" runat="server" Text="با تشکـر" ></asp:Label>
    </asp:Panel>
</asp:Content>
