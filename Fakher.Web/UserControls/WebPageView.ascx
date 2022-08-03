<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebPageView.ascx.cs" Inherits="UserControls_WebPageView" %>
<%--<%@ Register Src="../rComponents/rMessageBox/rMessageBox.ascx" TagName="rMessageBox"
    TagPrefix="uc1" %>--%>
<%@ Register src="AttachmentView.ascx" tagname="AttachmentView" tagprefix="uc2" %>
<asp:Panel ID="pnlPage" runat="server" Direction="RightToLeft">
    <asp:Label ID="lblTitle" runat="server" Text="" Font-Names="Tahoma" Font-Size="11pt"
        Font-Bold="True"></asp:Label>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #ff0000; border-style: none none dotted;" />
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <uc2:AttachmentView ID="AttachmentView1" runat="server" />

    
    <asp:Panel ID="pnlPreEnrollment" runat="server" Font-Names="Tahoma" Font-Size="10pt"
        Visible="False">
        <p class="bg-info" style="padding:15px;font-weight:bold">
            <asp:Label ID="Label1" runat="server" Text="هم اکنون برای پیش ثبت نام "></asp:Label>
                    <%--<asp:LinkButton ID="lnkBtnPreEnrollment" OnClick="lnkBtnPreEnrollment_Click" runat="server">اینجا را کلیک کنید.</asp:LinkButton>--%>
                    <asp:LinkButton ID="lnkBtnPreEnrollment"  runat="server" data-toggle="modal" data-target="#myModal">اینجا را کلیک کنید.</asp:LinkButton>

        </p>
    
        <div id="myModal" class="modal fade modal-primary" role="dialog">
             <div class="modal-dialog">
                 <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">پیش ثبت نــام</h4>
      </div>
      <div class="modal-body">
              <asp:Panel ID="Panel1" runat="server" >
                <div class="row">  <div class="col-md-12">
     <asp:Label ID="Label2" runat="server" Text="نـــام:" CssClass="col-md-3"></asp:Label>
                             <div class="col-md-9"> <asp:TextBox cssClass="form-control" ID="rTxtFirstName" runat="server" >
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="rTxtFirstName"
                                            runat="server" ErrorMessage="نام را وارد کنید" Display="Dynamic"></asp:RequiredFieldValidator>    
                </div>   </div>
                  <div class="col-md-12">
    <asp:Label ID="Label8" runat="server" Text="نــام خـانوادگـی:" CssClass="col-md-3"></asp:Label>
                                    <div class="col-md-9">  <asp:TextBox cssClass="form-control" ID="rTxtLastName" runat="server" >
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="rTxtLastName"
                                            runat="server" ErrorMessage="نام خانوادگی را وارد کنید" Display="Dynamic"></asp:RequiredFieldValidator>
                                  </div> 
                  </div>
                  <div class="col-md-12">
                          <asp:Label ID="Label4" runat="server" Text="استان:" CssClass="col-md-3"></asp:Label>
                                 <div class="col-md-9">  <asp:DropDownList CssClass="form-control" ID="RadCmbProvince" runat="server">
                                            <Items>
                                                <asp:ListItem Text="آذربایجان شرقی" Selected="True" runat="server" >
                                                </asp:ListItem>
                                                <asp:ListItem Text="آذربایجان غربی" > </asp:ListItem>
                                                <asp:ListItem Text="اردبیل" > </asp:ListItem>
                                                <asp:ListItem Text="اصفهان" > </asp:ListItem>
                                                <asp:ListItem Text="البرز" > </asp:ListItem>
                                                <asp:ListItem Text="ایلام" > </asp:ListItem>
                                                <asp:ListItem Text="بوشهر" > </asp:ListItem>
                                                <asp:ListItem Text="تهران" > </asp:ListItem>
                                                <asp:ListItem Text="چهارمحال و بختیاری" > </asp:ListItem>
                                                <asp:ListItem Text="خراسان جنوبی" > </asp:ListItem>
                                                <asp:ListItem Text="خراسان رضوی" > </asp:ListItem>
                                                <asp:ListItem Text="خراسان شمالی"> </asp:ListItem>
                                                <asp:ListItem Text="خوزستان" > </asp:ListItem>
                                                <asp:ListItem Text="زنجان" > </asp:ListItem>
                                                <asp:ListItem Text="سمنان" > </asp:ListItem>
                                                <asp:ListItem Text="سیستان و بلوچستان" > </asp:ListItem>
                                                <asp:ListItem Text="فارس" > </asp:ListItem>
                                                <asp:ListItem Text="قزوین"> </asp:ListItem>
                                                <asp:ListItem Text="قم" > </asp:ListItem>
                                                <asp:ListItem Text="کردستان" > </asp:ListItem>
                                                <asp:ListItem Text="کرمان" > </asp:ListItem>
                                                <asp:ListItem Text="کرمانشاه" > </asp:ListItem>
                                                <asp:ListItem Text="کهکیلویه و بویراحمد" > </asp:ListItem>
                                                <asp:ListItem Text="گلستان" > </asp:ListItem>
                                                <asp:ListItem Text="گیلان" > </asp:ListItem>
                                                <asp:ListItem Text="لرستان" > </asp:ListItem>
                                                <asp:ListItem Text="مازندران" > </asp:ListItem>
                                                <asp:ListItem Text="مرکزی" > </asp:ListItem>
                                                <asp:ListItem Text="هرمزگان" > </asp:ListItem>
                                                <asp:ListItem Text="همدان" > </asp:ListItem>
                                                <asp:ListItem Text="یزد" > </asp:ListItem>
                                            </Items>
                                        </asp:DropDownList></div> 
                  </div>
                  <div class="col-md-12">
                       <asp:Label ID="Label5" runat="server" Text="شهـر:" CssClass="col-md-3"></asp:Label>
                     <div class="col-md-9">  <asp:TextBox CssClass="form-control" ID="RadTxtCity" runat="server">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="RadTxtCity"
                                            runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                 </div> </div>
                  <div class="col-md-12">
                       <asp:Label ID="Label3" runat="server" Text="پست الکترونیکی:" CssClass="col-md-3"></asp:Label>
                     <div class="col-md-9"> <asp:TextBox CssClass="form-control" ID="rTxtEmail"  runat="server">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="RadTxtCity"
                                            runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                 </div>  </div>
                  <div class="col-md-12">
                       <asp:Label ID="Label7" runat="server" Text="تلفن همراه:" CssClass="col-md-3"></asp:Label>
                  <div class="col-md-9">     <asp:TextBox CssClass="form-control" ID="rTxtPhone" runat="server" >
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="rTxtPhone"
                                            runat="server" ErrorMessage="تلفن تماس را وارد کنید"></asp:RequiredFieldValidator>
               </div>    </div>
                           </div>
                       </asp:Panel>     
      </div>
      <div class="modal-footer">

        <asp:Panel ID="Panel3" runat="server" Font-Names="Tahoma" HorizontalAlign="Center">
                            <asp:Button ID="rBtnPreEnrollment" runat="server" Text="پـیــش ثـبــت نــام"
                                CssClass="btn btn-primary" OnClick="rBtnPreEnrollment_Click">
                            </asp:Button>
                        </asp:Panel>
      </div>
    </div>
                 </div>
        </div>
      
     <%--   <uc1:rMessageBox ID="rMessageBox1" runat="server" />--%>
    </asp:Panel>
</asp:Panel>
