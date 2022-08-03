<%@ Page Title="پرداخت اینترنتی" Language="C#" MasterPageFile="~/Student/Enrollment/EnrollmentMasterPage.master"
    AutoEventWireup="true" CodeFile="pageSectionEnrollment3.aspx.cs" Inherits="Student_Enrollment_pageSectionEnrollment3" %>
<%@ Register TagPrefix="uc1" TagName="rSimpleMessageBox" Src="~/rComponents/rMessageBox/rSimpleMessageBox.ascx" %>

<%@ Import Namespace="Fakher.Core.DomainModel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
            function postRefId(refIdValue) {
                var form = document.createElement("form");
                form.setAttribute("method", "POST");
                form.setAttribute("action", "https://pgw.bpm.bankmellat.ir/pgwchannel/startpay.mellat");
                form.setAttribute("target", "_self");
                var hiddenField = document.createElement("input");
                hiddenField.setAttribute("type", "hidden");
                hiddenField.setAttribute("name", "RefId");
                hiddenField.setAttribute("value", refIdValue);
                form.appendChild(hiddenField);
                document.body.appendChild(form);
                form.submit();
                document.body.removeChild(form);
            }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rSimpleMessageBox ID="rSimpleMessageBox1" runat="server" />
    <asp:Panel ID="pnlStepPay" runat="server" Visible="True">
        <table style="width: 70%; border: dashed 1px White; background: #009999; margin-left: auto;
            margin-right: auto">
            <tr>
                <td style="vertical-align: bottom; width: 36px; text-align: center; background: url('../../images/waiting.gif') no-repeat center;">
                </td>
                <td style="vertical-align: top; text-align: justify">
                    <asp:Label ID="Label5" runat="server" Text="کمــی صبــر کنیــد..." Font-Bold="True"
                        Font-Names="Tahoma" ForeColor="White" Font-Size="14pt"></asp:Label>
                    <br />
                    <asp:Label ID="Label6" runat="server" Text="درحال اتصال به سـرور پرداخت الکترونیک "
                        Font-Bold="True" Font-Names="Tahoma" ForeColor="White" Font-Size="12pt"></asp:Label>
                    <asp:Label ID="Label7" runat="server" Text="بانک ملـت" Font-Names="Tahoma" Font-Bold="True"
                        ForeColor="Orange" Font-Size="12pt"></asp:Label>
                </td>
                <td style="width: 48px; vertical-align: top; text-align: justify; background: url('../../images/leftarrow.gif') no-repeat center">
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
