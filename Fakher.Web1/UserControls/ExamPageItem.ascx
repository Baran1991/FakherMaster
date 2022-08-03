<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExamPageItem.ascx.cs"
    Inherits="Components_ExamPageItem" %>
<asp:Panel ID="pnlTextPageItem" runat="server" Visible="false">
    <asp:Literal ID="LiteralText" runat="server"></asp:Literal>
</asp:Panel>
<asp:Panel ID="pnlExamTestQuestion" runat="server" Visible="false">
    <style>
           :dir(ltr) .col-md-1,
  :dir(ltr)  .col-md-2,
    :dir(ltr) .col-md-3,
    :dir(ltr) .col-md-4,
    :dir(ltr) .col-md-5,
    :dir(ltr) .col-md-6,
    :dir(ltr) .col-md-7,
    :dir(ltr) .col-md-8,
    :dir(ltr) .col-md-9,
    :dir(ltr) .col-md-10,
    :dir(ltr) .col-md-11,
    :dir(ltr) .col-md-12 {
    float: left;
}
        .flex
        {
            display:flex;
        }
         :dir(ltr):not(.fa),:dir(ltr) span,span
    {
        font-family:'Times New Roman'!important;
    }
         div[style*="direction:rtl"] span{
     font-family:iranSans!important;
}
     :dir(rtl):not(.fa), div[style*="direction:rtl"] span
    {
        font-family:iranSans !important;
    }

    </style>

                <div class="panel panel-info">
                    <div class="panel-body">
                    <div class="col-md-8">
<div class="col-md-12 flex" style="margin-bottom:15px; line-height:25px;">
                     <asp:Label ID="lblTestIndex" runat="server" Text="Label"  Font-Bold="True" CssClass="badge badge-danger margin-10"
                    Font-Size="12pt"></asp:Label>
                    <div style="line-height:25px;padding:8px;font-weight:bold">  <asp:Label ID="LiteralTestQuestionText" runat="server" ></asp:Label>
                 </div>
                </div>
                          <div class="col-md-6 " style="margin-bottom:15px;" runat="server" id="q1">
                   <div class="col-md-12 flex">  <asp:RadioButton ID="RadioButton1" runat="server" style="margin-left:5px;"/>
                     <asp:Label ID="Label2" runat="server" Text="1) " Font-Bold="True" style="margin-left:5px;margin-right:5px"></asp:Label>
                     <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                              </div>
                              <div class="col-md-12 hidden desc alert-info">
 <asp:Label ID="Literal1desc" runat="server" ></asp:Label>
                              </div>
                              
                </div>
                <div class="col-md-6 " style="margin-bottom:15px;" runat="server" id="q2">
                    <div class="col-md-12 flex">
                     <asp:RadioButton ID="RadioButton2" runat="server" style="margin-left:5px;"/>
                     <asp:Label ID="Label3" runat="server" Text="2) " Font-Bold="True" style="margin-left:5px;margin-right:5px"></asp:Label>
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                    </div>
                     <div class="col-md-12 hidden desc alert-info">
                     <asp:Label ID="Literal2desc" runat="server" ></asp:Label>
                         </div>
                </div>
                <div class="col-md-6 " style="margin-bottom:15px;" runat="server" id="q3">
                    <div class="col-md-12 flex"> <asp:RadioButton ID="RadioButton3" runat="server" style="margin-left:5px;"/>
                     <asp:Label ID="Label4" runat="server" Text="3) " Font-Bold="True" style="margin-left:5px;margin-right:5px"></asp:Label>
                     <asp:Literal ID="Literal3" runat="server"></asp:Literal></div>
                    <div class="col-md-12 hidden desc alert-info">
                     <asp:Label ID="Literal3desc" runat="server" ></asp:Label>
                        </div>
                </div>
                <div class="col-md-6 " style="margin-bottom:15px;" runat="server" id="q4">
                    <div class="col-md-12 flex">
                     <asp:RadioButton ID="RadioButton4" runat="server" style="margin-left:5px;"/>
                      <asp:Label ID="Label5" runat="server" Text="4) " Font-Bold="True" style="margin-left:5px;margin-right:5px"></asp:Label>
                     <asp:Literal ID="Literal4" runat="server"></asp:Literal></div>
                     <div class="col-md-12 hidden desc alert-info">
                     <asp:Label ID="Literal4desc" runat="server"></asp:Label>
                         </div>
                </div>
                        <div class="col-md-12">
                            <input type="button" class="btn btn-default" runat="server" onclick="showDescription(this)" id="btnShowDesc" visible="false" value="نمایش پاسخ"/>
                        </div>
                    </div>
                    <div class="col-md-4">
 <asp:HiddenField ID="attachment" runat="server"  />
                   <video style="max-width:100%;" controls  id="videoAttachment" runat="server" >
 
Your browser does not support the video tag.
</video> 
                        <img runat="server" id="imageAttachment" class="hidden img-responsive" src="" />
                    </div>
                </div>
                
                </div>
  
</asp:Panel>
<asp:Panel ID="pnlExamEssayQuestion" runat="server" Visible="false">
    <table class="table table-bordered">
        <tr>
            <td>
                <div class="row">
                    <div class="col-md-8">
                        <div class="col-md-12">
 <asp:Label ID="lblEssayIndex" runat="server" Text="Label" Font-Bold="True"
                    Font-Size="12pt"></asp:Label>
                        <asp:Literal ID="LiteralEssayQuestionText" runat="server"></asp:Literal>
                   </div> 
                        <div class="col-md-12">
<asp:TextBox ID="txtEssayText" runat="server" TextMode="MultiLine" Width="100%" 
                    Height="150px" BorderStyle="Dashed"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <asp:HiddenField ID="attachment1" runat="server"  />
                   <video style="max-width:100%;" controls  id="videoAttachment1" runat="server" >
 
Your browser does not support the video tag.
</video> 
                         <img runat="server" id="imageAttachment1" class="hidden img-responsive" src="" style="max-width:100%;"/>
                    </div>
                </div>
               
            </td>
           
        </tr>
      
    </table>
</asp:Panel>
<script>

    jQuery(document).ready(function () {
        if ($("#<%= attachment.ClientID %>").length) {
            if ($("#<%= attachment.ClientID %>").val() != "") {
                if ($("#<%= attachment.ClientID %>").val().startsWith("data:image")) {
                    jQuery("#<%= videoAttachment.ClientID %>").addClass("hidden");
                    jQuery("#<%= imageAttachment.ClientID %>").removeClass("hidden");
                    jQuery("#<%= imageAttachment.ClientID %>").attr("src", $("#<%= attachment.ClientID %>").val());
                }
                else {
                    jQuery("#<%= videoAttachment.ClientID %>").attr("src", $("#<%= attachment.ClientID %>").val());
                }
            }
            else {
                jQuery("#<%= videoAttachment.ClientID %>").addClass("hidden");
            }
        }
        else {
            jQuery("#<%= videoAttachment.ClientID %>").addClass("hidden");
        }
        if ($("#<%= attachment1.ClientID %>").length) {
            if ($("#<%= attachment1.ClientID %>").val() != "") {
                if ($("#<%= attachment1.ClientID %>").val().startsWith("data:image")) {
                    jQuery("#<%= videoAttachment1.ClientID %>").addClass("hidden");
                    jQuery("#<%= imageAttachment1.ClientID %>").removeClass("hidden");
                    jQuery("#<%= imageAttachment1.ClientID %>").attr("src", $("#<%= attachment1.ClientID %>").val());
                }
                else {
                    jQuery("#<%= videoAttachment1.ClientID %>").attr("src", $("#<%= attachment1.ClientID %>").val());
                }
            }
            else {
                jQuery("#<%= videoAttachment1.ClientID %>").addClass("hidden");
            }
        }
            else {
                jQuery("#<%= videoAttachment1.ClientID %>").addClass("hidden");
            }
       
    })
</script>