<%@ Page Title="ورود نمرات" Language="C#" MasterPageFile="~/Instructor/InstructorMasterPage.master"
    AutoEventWireup="true" CodeFile="pageMarkEntry.aspx.cs" Inherits="Instructor_pageMarkEntry" %>

<%@ Register TagPrefix="uc1" TagName="rMessageBox" Src="~/rComponents/rMessageBox/rMessageBox.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <uc1:rMessageBox ID="rMessageBox1" runat="server" />
    <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" Font-Size="9pt">
        <asp:Label ID="Label1" runat="server" Text="ورود نمرات" Font-Names="Tahoma"></asp:Label>
        <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; width: 100px;">
                    <asp:Label ID="Label6" runat="server" Text="عنـوان گـــروه:" Font-Bold="True"></asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:Label ID="lblLesson" runat="server" Text="" Font-Size="10pt"></asp:Label>
                </td>
                <td style="text-align: left; width: 100px;">
                </td>
                <td style="text-align: right">
                </td>
            </tr>
            <tr>
                <td>
                    &&nbsp
                </td>
                <td colspan="3" style="text-align: right">
                    <asp:Label ID="lblFormation" runat="server" Text="" Font-Size="10pt"></asp:Label>
                </td>
            </tr>
        </table>
        <br/>
        <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td style="vertical-align: central; width: 75px; text-align: left; padding-left: 3px;"
                    valign="middle" align="center">
                    <asp:Label ID="Label3" runat="server" Text="درس/سطح:"></asp:Label>
                </td>
                <td style="vertical-align: central; width: 620px" valign="middle" align="center">
                    <telerik:RadComboBox ID="RadCmbLesson" runat="server" Width="100%" Font-Names="Tahoma"
                        DataValueField="Id" AutoPostBack="True" OnSelectedIndexChanged="RadCmbLesson_SelectedIndexChanged">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: central; width: 75px; text-align: left; padding-left: 3px;">
                    <asp:Label ID="Label2" runat="server" Text="آیتم نمره:"></asp:Label>
                </td>
                <td style="vertical-align: central; width: 620px" valign="middle" align="center">
                    <telerik:RadComboBox ID="RadCmbMarkEntryLicense" runat="server" Width="100%" Font-Names="Tahoma"
                        DataValueField="Id">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; padding: 5px 0px;" colspan="2">
                    <telerik:RadButton ID="btnMarkEntry" runat="server" Text="ورود نمــره" Font-Names="Tahoma"
                        Width="150px" OnClick="btnMarkEntry_Click">
                        <Icon SecondaryIconUrl="~/images/edit.png"></Icon>
                    </telerik:RadButton>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlMarkEntry" runat="server" Visible="False">
            <table style="width: 200px; height: 37px;">
                <tr>
                    <td class="heading">
                        <asp:Label ID="Label5" runat="server" Text="دانشجویـان" Font-Names="Tahoma" Font-Size="10pt"></asp:Label>
                    </td>
                </tr>
            </table>
            <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" OnItemDataBound="RadGrid1_ItemDataBound"
                Font-Names="Tahoma" CellSpacing="0" GridLines="None">
                <ItemStyle CssClass="CustomStyle"></ItemStyle>
                <AlternatingItemStyle CssClass="CustomStyle"></AlternatingItemStyle>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default" Font-Names="Tahoma">
                </HeaderContextMenu>
                <MasterTableView DataKeyNames="Id" Dir="RTL" NoMasterRecordsText="رکوردی برای نمایش وجود ندارد">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="ردیف">
                            <ItemTemplate>
                                <asp:Label ID="lblIndex" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="Register.Code" HeaderText="شماره دانشجویـی">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Register.Student.FarsiFirstName" HeaderText="نـام">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Register.Student.FarsiLastName" HeaderText="نـام خـانوادگـی">
                        </telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn HeaderText="نمــره">
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="RadTxtMark" runat="server" ShowSpinButtons="False"
                                    Type="Number" Font-Names="Tahoma" Font-Bold="True" AllowOutOfRangeAutoCorrect="False"
                                    CssClass="ltr" Style="text-align: center">
                                    <NumberFormat DecimalDigits="2"></NumberFormat>
                                    <IncrementSettings InterceptArrowKeys="False" InterceptMouseWheel="False"></IncrementSettings>
                                </telerik:RadNumericTextBox>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <ClientSettings EnablePostBackOnRowClick="False" EnableRowHoverStyle="False">
                    <Selecting AllowRowSelect="False" />
                </ClientSettings>
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
            </telerik:RadGrid>
            <asp:Panel ID="Panel3" runat="server">
                <table style="width: 100%">
                    <tr>
                        <td style="background-color: #3772ab; color: #ffffff">
                            <asp:Label ID="Label11" runat="server" Text="ثبت نمرات" Font-Names="Tahoma" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #e5e6e6; text-align: justify">
                            <table width="100%">
                                <tr>
                                    <td valign="middle" style="text-align: left;">
                                        <asp:Label ID="Label4" runat="server" Text="کـد ورود نمـره:" Font-Names="Tahoma"
                                            Font-Bold="True"></asp:Label>
                                    </td>
                                    <td valign="middle" style="text-align: right;">
                                        <telerik:RadTextBox ID="RadTxtEntryCode" runat="server" TextMode="Password" CssClass="ltr">
                                            <PasswordStrengthSettings CalculationWeightings="50;15;15;20" IndicatorElementBaseStyle="riStrengthBar"
                                                IndicatorElementID="" MinimumLowerCaseCharacters="2" MinimumNumericCharacters="2"
                                                MinimumSymbolCharacters="2" MinimumUpperCaseCharacters="2" OnClientPasswordStrengthCalculating=""
                                                PreferredPasswordLength="10" RequiresUpperAndLowerCaseCharacters="True" ShowIndicator="False"
                                                TextStrengthDescriptions="Very Weak;Weak;Medium;Strong;Very Strong" TextStrengthDescriptionStyles="riStrengthBarL0;riStrengthBarL1;riStrengthBarL2;riStrengthBarL3;riStrengthBarL4;riStrengthBarL5;" />
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="RadTxtEntryCode"
                                            runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td valign="middle" style="text-align: center;">
                                        <telerik:RadButton ID="btnSave" runat="server" Text="ثبت نمرات" Font-Names="Tahoma"
                                            Width="150px" OnClick="btnSave_Click">
                                        </telerik:RadButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
