<%@ Page Title="پرداخت اینترنتی..." Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="pagePayRequest.aspx.cs" Inherits="pagePayRequest" %>

<%@ Import Namespace="Fakher.Core.DomainModel" %>
<%@ Register Src="~/rComponents/rMessageBox/rMessageBox.ascx" TagName="rMessageBox"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function postRefId(refIdValue) {
            var form = document.createElement("form");
            form.setAttribute("method", "POST");
            form.setAttribute("action", "<%= MellatPayTransaction.GatewayUrl %>");
            form.setAttribute("target", "_self");
            var hiddenField = document.createElement("input");
            hiddenField.setAttribute("name", "RefId");
            hiddenField.setAttribute("value", refIdValue);
            form.appendChild(hiddenField);
            document.body.appendChild(form);
            form.submit();
            document.body.removeChild(form);
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" OnDialogResult="rMessageBox1_DialogResult" />
    <div>
        <table style="width: 70%; border: dashed 1px White; background: #009999; margin-left: auto;
            margin-right: auto">
            <tr>
                <td style="vertical-align: bottom; width: 36px; text-align: center;background: url('images/waiting.gif') no-repeat center;">
<%--                    <asp:Image ID="Image3" runat="server" ImageUrl="~/images/waiting.gif" Height="36px"--%>
<%--                        Width="36px" />--%>
                </td>
                <td style="vertical-align: top; text-align: justify">
                    <asp:Label ID="Label1" runat="server" Text="کمــی صبــر کنیــد..." Font-Bold="True"
                        Font-Names="Tahoma" ForeColor="White" Font-Size="14pt"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="درحال اتصال به سـرور پرداخت الکترونیک "
                        Font-Bold="True" Font-Names="Tahoma" ForeColor="White" Font-Size="12pt"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="بانک ملـت" Font-Names="Tahoma" Font-Bold="True"
                        ForeColor="Orange" Font-Size="12pt"></asp:Label>
                </td>
                <td style="width: 48px; vertical-align: top; text-align: justify;background: url('images/leftarrow.gif') no-repeat center">
<%--                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/leftarrow.png" Height="48px"--%>
<%--                        Width="48px" />--%>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
