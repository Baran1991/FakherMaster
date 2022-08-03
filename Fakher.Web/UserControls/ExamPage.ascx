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
<asp:Panel ID="Panel1" runat="server">
</asp:Panel>

