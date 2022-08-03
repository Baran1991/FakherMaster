<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentTopPanel.ascx.cs" 
Inherits="Components_StudentTopPanel" %>
<style > 
    img.img-responsive
    {
        max-height:120px!important;
    }

</style>
<asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" Visible="False">
    <div class="row">
    
        <div class="col-md-2">
<telerik:RadBinaryImage ID="RadBinaryImage1" runat="server"  CssClass="img-responsive img-thumbnail" 
                    />
        </div>
        <div class="col-md-10">
            <div class="row">
        <div class="col-md-5 " style="display:flex">
           
<asp:Label ID="Label1" runat="server" Text="رشـتـــه فعــــال:"></asp:Label>
             <telerik:RadComboBox ID="cmbMajor" runat="server" Width="100%" 
                                ondatabound="cmbMajor_DataBound" 
                                onselectedindexchanged="cmbMajor_SelectedIndexChanged" AutoPostBack="True">
                            </telerik:RadComboBox>
        </div>
        <div class="col-md-5 " style="display:flex">
             <asp:Label ID="Label2" runat="server" Text="تــــرم فـعـــال:"></asp:Label>
              <telerik:RadComboBox ID="cmbPeriod" runat="server" Width="100%" 
                                ondatabound="cmbPeriod_DataBound" 
                                onselectedindexchanged="cmbPeriod_SelectedIndexChanged" 
                                AutoPostBack="True">
                            </telerik:RadComboBox>
            </div></div>
            <div class="row">

            
        <div class="col-md-5" style="display:flex">
             <asp:Label ID="Label6" runat="server" Text="نـــام دانشجــو:" Font-Bold="True"></asp:Label>
             <asp:Label ID="lblName" runat="server" Text="Label" Font-Size="10pt"></asp:Label>
        </div>
         <div class="col-md-5" style="display:flex">
              <asp:Label ID="Label3" runat="server" Text="شمـاره دانشجــویـی:" Font-Bold="True"></asp:Label>
               <asp:Label ID="lblStudentCode" runat="server" Text="Label" Font-Size="10pt"></asp:Label>
             </div></div>
            <div class="row">
        <div class="col-md-5"  style="display:flex">
              <asp:Label ID="Label4" runat="server" Text="وضعـیـت آمــوزشــی:" 
                                Font-Bold="True"></asp:Label>
                       
                            <asp:Label ID="lblEducationalStatus" runat="server" Text="Label" Font-Size="10pt"></asp:Label>
        </div>
           <div class="col-md-5"  style="display:flex">
                <asp:Label ID="Label5" runat="server" Text="وضعـیـت مــالــی:" Font-Bold="True"></asp:Label>
                        
                            <asp:Label ID="lblFinancialStatus" runat="server" Text="Label" Font-Size="10pt"></asp:Label>
               </div>
    </div></div>
  </div>
</asp:Panel>
