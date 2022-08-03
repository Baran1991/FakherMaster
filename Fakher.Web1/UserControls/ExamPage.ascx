<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExamPage.ascx.cs" Inherits="Components_ExamPage" %>

<%@ Register src="~/UserControls/ExamPageItem.ascx" tagname="ExamPageItem" tagprefix="uc1" %>
<script type="text/javascript">
    var radioChecked;
    function myMouseDown(radio) {
        radioChecked = radio.checked;
    }
    function myClick(radio) {
        radio.checked = !radioChecked;
    }
</script>
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
    float: left!important;
}
    :dir(ltr):not(.fa)
    {
        font-family:'Times New Roman'!important;
    }
     :dir(rtl):not(.fa)
    {
        font-family:iranSans !important;
    }
</style>
<div class="pagebodysection" style="margin-left: auto; margin-right: auto">
<asp:Panel ID="Panel1" runat="server">
</asp:Panel>
</div>
<script>
    function showDescription(element) {
        $(element).parent("div").parent("div").find(".desc").removeClass("hidden");
        $(element).parent("div").parent("div").find(".correct").parent("div").prepend("<span class='fa fa-check-circle' style='font-size:20px; color:green'></span>")
    }
</script>
