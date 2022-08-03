<%@ Page Title="لیست آزمون هـا" Language="C#" MasterPageFile="~/Student/OnlineExam/ExamMasterPage.master"
    AutoEventWireup="true" CodeFile="pageExamList.aspx.cs" Inherits="Student_OnlineExam_pageExamList" %>

<%@ Register TagPrefix="uc1" TagName="rSimpleMessageBox" Src="~/rComponents/rMessageBox/rSimpleMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rSimpleMessageBox ID="rSimpleMessageBox1" runat="server" />
    <asp:Panel ID="Panel2" runat="server" HorizontalAlign="Center">
        <asp:Label ID="lblTitle" runat="server" Text="سـامـانـه آزمــون اینترنتی دانشجویان مـوسـســه فاخــــــر"
            Font-Names="Tahoma" Font-Size="11pt" Font-Bold="True"></asp:Label>
    </asp:Panel>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <table style="width: 200px; height: 37px;">
        <tr>
            <td class="heading">
                <asp:Label ID="Label3" runat="server" Text="لیست آزمون هـا" Font-Names="Tahoma" Font-Bold="True"></asp:Label>
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
            <asp:TemplateField HeaderText="رشتــه">
                <ItemTemplate>
                    <%# Eval("ExamForm.Exam.ExamTrainingItem.Lesson.Major.Name")%>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="تــرم">
                <ItemTemplate>
                    <%# Eval("ExamForm.Exam.Period.Name")%>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نــام آزمـــون">
                <ItemTemplate>
                    <%# Eval("ExamForm.Exam.Name")%>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="زمان برگزاری">
                <ItemTemplate>
                    <%# Eval("ExamForm.Exam.ExamHolding.FormationText")%>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" BackColor="#184860" ForeColor="White" Height="25px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnParticipate" runat="server" Text="شرکت در آزمـون" Font-Names="Tahoma" OnClick="btnParticipate_Click"
                        Width="125px" />
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
</asp:Content>
