<%@ Page Title="دعوت به همکاری در موسسه آموزش عالی آزاد فاخر" Language="C#" MasterPageFile="~/MainMasterPage1.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Career_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server" ScriptMode="Release"
        EnableScriptCombine="true" OutputCompression="AutoDetect">
    </telerik:RadScriptManager>--%>
    <asp:HyperLink ID="HyperLink2" runat="server"  Font-Size="10pt"
        NavigateUrl="~/Career/Default.aspx">دعوت به همکاری در موسسه آموزش عالی آزاد فاخر</asp:HyperLink>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <asp:Panel ID="Panel1" runat="server"  Font-Size="10pt">
        موسسه آموزش عالی آزاد فاخر، به عنوان یکی از بزرگترین موسسات آموزش عالی آزاد در جنوب
        کشور، با دارا بودن کادری مجرب و متعهد در زمینه های حقوق، زبانهای خارجی و موسیقی  فعالیت مینماید.
        <br />
         این موسسه علاقمند است تا در صورتی که شما خود را فردی فعال، پویا و متعهد ارزیابی مینمایید در زمینه فرصت های شغلی زیر با شما همکاری نماید. 
         پذیرش و ثبت نام در این فرصت های شغلی به صورت کاملا الکترونیکی و آنلاین انجام میشود.
        <br />
        <br />
        <table width="100%">
            <tr>
                <td style="vertical-align: top;">
                    <h3>
                        شرایط اولیه جهت همکاری:
                    </h3>
                    <hr style="border: 1px dotted #abc8e6; width: 200px; text-align: right; padding: 0;
                        margin: 0;" />
                    <ul>
                        <li>برخورداری از تجربه و مهارت های کافی</li>
                        <li>علاقمندی و انگیزه قوی جهت کار در یک محیط آموزشی</li>
                        <li>داشتن فن بیان</li>
                        <li>پایبندی به نظم و قوانین موسسه</li>
                    </ul>
                </td>
                <td style="vertical-align: top;">
                    <h3>
                        مزایای همکاری:
                    </h3>
                    <hr style="border: 1px dotted #abc8e6; width: 200px; text-align: right; padding: 0;
                        margin: 0;" />
                    <ul>
                        <li>محیط کاری فرهنگی</li>
                        <li>روش کاری کاملا منظم و ساخت یافته</li>
                        <li>امکان پیشرفت در محیط کاری</li>
                    </ul>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label6" runat="server" Text="موقعیت هـای شغلی موجـود" 
                        Font-Size="10pt"></asp:Label>
                </td>
            </tr>
        </table>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False"  OnSelectedIndexChanged="RadGrid1_SelectedIndexChanged"
            OnItemDataBound="RadGrid1_ItemDataBound" >
            <ItemStyle CssClass="CustomStyle"></ItemStyle>
            <AlternatingItemStyle CssClass="CustomStyle"></AlternatingItemStyle>
            <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
            </HeaderContextMenu>
            <MasterTableView DataKeyNames="Id" Dir="RTL" NoMasterRecordsText="در حال حاضر هیچ فرصت شغلی وجود ندارد">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                </ExpandCollapseColumn>
                <Columns>
                    
                    <telerik:GridTemplateColumn HeaderText="ردیف شغلی">
                        <ItemTemplate>
                            <asp:Label ID="lblIndex" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate> </telerik:GridTemplateColumn>
                           <telerik:GridHyperLinkColumn  DataTextFormatString=" ثبت نام "
                    DataNavigateUrlFields="ID" UniqueName="ID" DataNavigateUrlFormatString="~/Career/Career.aspx?id={0}"
                    HeaderText="ثبت نام" DataTextField="ID">
                </telerik:GridHyperLinkColumn>
                   
                    <telerik:GridBoundColumn DataField="Name" HeaderText="عنوان">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="EducationalDegreeText" HeaderText="مدرک تحصیلی لـازم">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="GenderTypeText" HeaderText="جنسيـت">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Qualifications" HeaderText="ساير شرايط لازم">
                    </telerik:GridBoundColumn>
                
                     
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <ClientSettings EnablePostBackOnRowClick="True" EnableRowHoverStyle="True">
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
        </telerik:RadGrid>
    </asp:Panel>
</asp:Content>
