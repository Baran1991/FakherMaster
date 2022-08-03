<%@ Page Title="ثبت نام کلـاسـی - انتخاب گروه" Language="C#" MasterPageFile="~/Student/Enrollment/EnrollmentMasterPage.master"
    AutoEventWireup="true" CodeFile="pageSectionEnrollment2.aspx.cs" Inherits="Student_pageSectionEnroll" %>

<%@ Import Namespace="Fakher.Core.DomainModel" %>
<%@ Register TagPrefix="uc1" TagName="rSimpleMessageBox" Src="~/rComponents/rMessageBox/rSimpleMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <asp:Panel ID="pnlStep1" runat="server" Visible="True">
        <asp:Panel ID="Panel2" runat="server" Font-Names="Tahoma" Direction="RightToLeft"
            Font-Size="11pt">
            <table style="width: 100%">
                <tr>
                    <td style="background-color: #3772ab; color: #ffffff">
                        <asp:Label ID="Label5" runat="server" Text="راهنمای ثبت نام اینترنتی (مرحله 2)" Font-Names="Tahoma"
                            Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #e5e6e6; text-align: justify; color: #000000">
                        <ul>
                            <li>
                                <asp:Label ID="Label1" runat="server" Text="در جـدول بالا، لیست گـروه هایی که برای شما قابل اخذ می باشند را مشاهده می کنید. لیست پایین شامل گـروه هایی است که شما اخذ کرده اید."
                                    Font-Names="Tahoma" Font-Size="14px"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label2" runat="server" Text="برای اخذ یک گـروه؛ روی دکمه اخذ در مقابل آن در لیست بالا کلیک کنید. سپس منتظر شوید تا گـروه به لیست پایین اضافه گردد."
                                    Font-Names="Tahoma" Font-Size="14px"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label18" runat="server" Text="برای حـذف گـروه؛ روی دکمه حذف در مقابل آن در لیست پایین کلیک کنید. سپس منتظر شوید تا گـروه از لیست پایین حذف گردد."
                                    Font-Names="Tahoma" Font-Size="14px"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label6" runat="server" Text="به منظور پرداخت؛ بر روی دکمه تایید و پرداخت کلیک کنید. سپس منتظر شوید تا به سایت بانک منتقل شوید. پس از پرداخت مجددا به سایت موسسه برخواهید گشت تا ثبت نام شما تکمیل و تایید نهایی گردد."
                                    Font-Names="Tahoma" Font-Size="14px"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="Label022" runat="server" Text="اگر به هر دلیل پرداخت اینترنتی خود را انجام ندهید، پس از مدت زمان 20دقیقه ثبت نام گروههای شما به صورت خودکار از سیستم حذف خواهد شد"
                                    Font-Names="Tahoma" Font-Size="14px" Font-Bold="True"></asp:Label>
                            </li>
                        </ul>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <uc1:rSimpleMessageBox ID="rSimpleMessageBox1" runat="server" />
        <br />
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label3" runat="server" Text="گـــروه های قابل اخــذ" Font-Names="Tahoma"
                        Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="90%"
            Font-Names="Tahoma" Style="margin: auto auto;" DataKeyNames="Id" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="ردیف">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="درس/سـطــح">
                    <ItemTemplate>
                        <%# Eval("Lesson.Name")%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="گـــروه">
                    <ItemTemplate>
                        <%# Eval("Section.FarsiName")%></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ظرفیت">
                    <ItemTemplate>
                        <%# Eval("RemainderCount")%></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="زمان برگزاری">
                    <ItemTemplate>
                        <%# Eval("Section.FarsiFormationText")%></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEnroll" runat="server" Text="اخــــذ" Font-Names="Tahoma" OnClick="btnEnroll_Click"
                            Width="75px" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="DarkKhaki"></SelectedRowStyle>
            <AlternatingRowStyle BackColor="#E7E7E7"></AlternatingRowStyle>
            <EmptyDataTemplate>
                <asp:Label ID="Label2" runat="server" Text="هیچ گروهی برای شما وجود ندارد" Font-Italic="True"
                    Font-Bold="True"></asp:Label>
            </EmptyDataTemplate>
        </asp:GridView>
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label4" runat="server" Text="گـــروه های اخــذ شده" Font-Names="Tahoma"
                        Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="90%"
            Font-Names="Tahoma" Style="margin: auto auto;" DataKeyNames="Id" OnRowDataBound="GridView2_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="ردیف">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="درس/سـطــح">
                    <ItemTemplate>
                        <%# Eval("SectionItem.Lesson.Name")%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="گـــروه">
                    <ItemTemplate>
                        <%# Eval("SectionItem.Section.FarsiName")%></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="زمان برگزاری">
                    <ItemTemplate>
                        <%# Eval("SectionItem.Section.FarsiFormationText")%></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="حـــذف" Font-Names="Tahoma" OnClick="btnDelete_Click"
                            Width="75px" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="DarkKhaki"></SelectedRowStyle>
            <AlternatingRowStyle BackColor="#E7E7E7"></AlternatingRowStyle>
            <EmptyDataTemplate>
                <asp:Label ID="Label2" runat="server" Text="هیچ گروهی اخذ نشده است" Font-Italic="True"
                    Font-Bold="True"></asp:Label>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:Panel ID="Panel5" runat="server" HorizontalAlign="Center" Font-Names="Tahoma"
            Font-Size="12px">
            <br />
            <br />
            <br />
            <asp:Label ID="Label8" runat="server" Text="شهـــریـه قـابـل پــرداخـت: "></asp:Label>
            <asp:Label ID="lblPayableAmout" runat="server" Text="Label" Font-Bold="True"></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" Text="وضعیت پــرداخـت: "></asp:Label>
            <asp:Label ID="lblPayStatus" runat="server" Text="Label" Font-Bold="True"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server" HorizontalAlign="Center">
            <hr />
            <asp:Button ID="btnPay" runat="server" Text="تایید و پرداخت اینترنتی >>" Font-Names="Tahoma"
                Width="210px" OnClick="btnPay_Click"></asp:Button>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
