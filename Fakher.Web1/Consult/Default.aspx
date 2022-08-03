<%@ Page Title="مــرکز مشــاوره فاخــر" Language="C#" MasterPageFile="~/Consult/ConsultMasterPage.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Consult_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TopRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BottomRightContentPlaceHolder" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="CenterContentPlaceHolder" runat="Server">
    <asp:HyperLink ID="HyperLink2" runat="server" Font-Names="Tahoma" Font-Size="10pt"
        NavigateUrl="~/Consult/Default.aspx">مــرکز مشــاوره فاخــر</asp:HyperLink>
    <hr style="color: #fff; background-color: #fff; border: 1px dotted #abc8e6; border-style: none none dotted;" />
    <asp:Panel ID="Panel2" runat="server" Font-Names="Tahoma" Direction="RightToLeft"
        Font-Size="11pt">
        <table style="width: 100%" class="table">
            <tr>
                <td style="background-color: #3772ab; color: #ffffff; width: 50%; text-align: center">
                    <asp:Label ID="Label11" runat="server" Text="سـوال های خـود را از ما بپرسید" Font-Names="Tahoma"
                        Font-Bold="true"></asp:Label>
                </td>
                <td style="background-color: #009999; color: #ffffff; width: 50%; text-align: center">
                    <asp:Label ID="Label12" runat="server" Text="پیگیری مشاوره" Font-Names="Tahoma" Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #e5e6e6; text-align: justify; vertical-align: top; padding: 0px 10px;">
                    <asp:Label ID="Label2" runat="server" Text="کارشناسان باتجربه ما در مرکز مشاوره موسسه فاخر، مشاور شما خواهند بود و سئوالات شما را به صورت عمومی یا خصوصی در کمال دقت و مسئولیت پاسخگو خواهند بود."></asp:Label>
                    <br />
                    <br />
                    <asp:Panel ID="Panel3" runat="server" HorizontalAlign="Center">
                        <asp:LinkButton ID="btnNewConsultant" runat="server" Text="درخـواسـت مشــاوره"
                             OnClick="btnNewConsultant_Click" CssClass="btn btn-primary" >
                           
                        </asp:LinkButton>
                    </asp:Panel>
                    <br/>
                </td>
                <td style="background-color: #e5e6e6; text-align: justify; vertical-align: top; padding: 0px 10px;">
                    <asp:Label ID="Label5" runat="server" Text="جهت پیگیری مشاوره خود، کد پیگیری مشاوره را در زیر وارد کنید؛"></asp:Label>
                    <br />
                    <br />
                    <asp:Panel ID="Panel4" runat="server" HorizontalAlign="Center">
                        <telerik:RadNumericTextBox ID="rTxtConsultantId" runat="server" Type="Number" CssClass="ltr"
                            DataType="System.Int64">
                            <NumberFormat GroupSeparator="" DecimalDigits="0"></NumberFormat>
                        </telerik:RadNumericTextBox>
                        <br />
                        <br />
                         <asp:LinkButton ID="btnSearch" runat="server" Text="پیگیــری مشــاوره"
                             OnClick="btnSearch_Click" CssClass="btn btn-primary" >
                           
                        </asp:LinkButton>
                      
                    </asp:Panel>
                    <br/>
                </td>
            </tr>
        </table>
    </asp:Panel>
<%--    <asp:Panel ID="pnlDescription" runat="server" Visible="True">--%>
<%--        <br />--%>
<%--        <table style="width: 100%">--%>
<%--            <tr>--%>
<%--                <td style="background-color: #3772ab; color: #ffffff; width: 50%; text-align: center">--%>
<%--                    <asp:Label ID="Label9" runat="server" Text="تــوجــه" Font-Names="Tahoma"--%>
<%--                        Font-Bold="true"></asp:Label>--%>
<%--                </td>--%>
<%--            </tr>--%>
<%--            <tr>--%>
<%--                <td style="background-color: #e5e6e6; text-align: justify; vertical-align: top; padding: 0px 10px;">--%>
<%--                    <asp:Label ID="lblDescription" runat="server" Font-Names="Tahoma" --%>
<%--                        Font-Size="10pt"></asp:Label>--%>
<%--                </td>--%>
<%--            </tr>--%>
<%--        </table>--%>
<%--        <br />--%>
<%--    </asp:Panel>--%>
    <asp:Panel ID="Panel1" runat="server">
        <table style="width: 200px; height: 37px;">
            <tr>
                <td class="heading">
                    <asp:Label ID="Label1" runat="server" Text="آخرین مشــاوره هــا" Font-Names="Tahoma"
                        Font-Size="10pt"></asp:Label>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text=" " Font-Names="Tahoma" ForeColor="#006400"></asp:Label>
                </td>
            </tr>
        </table>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" OnItemDataBound="RadGrid1_ItemDataBound"
            Font-Names="Tahoma">
            <HeaderContextMenu Font-Names="Tahoma">
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
                        <HeaderStyle Width="10px" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridHyperLinkColumn DataTextField="Title" DataNavigateUrlFields="Code" HeaderText="عنــوان"
                        DataNavigateUrlFormatString="~/Consult/pageConsultation.aspx?ConsultationCode={0}">
                        <HeaderStyle Width="220px" />
                    </telerik:GridHyperLinkColumn>
                    <telerik:GridBoundColumn DataField="CategoryText" HeaderText="موضوع">
                        <HeaderStyle Width="50px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Hits" HeaderText="مشاهـده">
                        <HeaderStyle Width="10px" />
                    </telerik:GridBoundColumn>
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
    </asp:Panel>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" Title="مشــاوره جــدید"
                VisibleOnPageLoad="True" Width="600px" Height="520px" VisibleTitlebar="true"
                VisibleStatusbar="False" Visible="False" Style="z-index: 200001;" Behaviors="Close">
                <ContentTemplate>
                    <table style="width: 100%; font-family: tahoma; font-size: 10pt;">
                        <tr>
                            <td style="width: 100px; text-align: left; background-color: #3772ab; color: #ffffff">
                                <asp:Label ID="Label6" runat="server" Text="نـــام:"></asp:Label>
                            </td>
                            <td style="background-color: #e5e6e6;">
                                <telerik:RadTextBox ID="RadTxtFirstname" runat="server" Width="99%" Font-Names="Tahoma">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                    ControlToValidate="RadTxtFirstname" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                            <td style="text-align: left; background-color: #3772ab; color: #ffffff">
                                <asp:Label ID="Label8" runat="server" Text="نــام خـانـوادگــی:"></asp:Label>
                            </td>
                            <td style="background-color: #e5e6e6;">
                                <telerik:RadTextBox ID="RadTxtLastname" runat="server" Width="97%" Font-Names="Tahoma">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                    ControlToValidate="RadTxtLastname" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: left; background-color: #3772ab; color: #ffffff">
                                <asp:Label ID="lblEmail" runat="server" Text="ایمیــل:"></asp:Label>
                            </td>
                            <td style="background-color: #e5e6e6;" colspan="3">
                                <telerik:RadTextBox ID="RadTxtEmail" runat="server" Font-Names="Tahoma" Width="99%"
                                    CssClass="ltr">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                    ControlToValidate="RadTxtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: left; background-color: #3772ab; color: #ffffff">
                                <asp:Label ID="Label3" runat="server" Text="تلفن تماس:"></asp:Label>
                            </td>
                            <td style="background-color: #ffffff;" colspan="3">
                                <telerik:RadTextBox ID="rTxtPhone" runat="server" Width="99%" CssClass="ltr" Font-Names="Tahoma">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="rTxtPhone"
                                    runat="server" ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: left; background-color: #ffffff; color: #ffffff">&&nbsp;
                            </td>
                            <td style="background-color: #ffffff;" colspan="3">&&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: left; background-color: #3772ab; color: #ffffff">
                                <asp:Label ID="Label10" runat="server" Text="مـوضـوع (مختصر):"></asp:Label>
                            </td>
                            <td style="background-color: #e5e6e6;" colspan="3">
                                <telerik:RadTextBox ID="RadTxtTitle" runat="server" Width="99%" Font-Names="Tahoma">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                    ControlToValidate="RadTxtTitle" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: left; vertical-align: top; background-color: #3772ab; color: #ffffff">
                                <asp:Label ID="Label7" runat="server" Text="متن کامل سئوال:"></asp:Label>
                            </td>
                            <td style="background-color: #e5e6e6;" colspan="3">
                                <telerik:RadTextBox ID="RadTxtQuestion" runat="server" Width="99%" TextMode="MultiLine"
                                    Font-Names="Tahoma" Height="250px">
                                </telerik:RadTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                                    ControlToValidate="RadTxtQuestion" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: left; background-color: #3772ab; color: #ffffff">&&nbsp;
                            </td>
                            <td style="background-color: #e5e6e6;" colspan="3">
                                <asp:CheckBox ID="chkPrivate" runat="server" Text="این مشـاوره به صورت خصـوصـی، پاسخ داده شود." />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:Panel ID="Panel5" runat="server" HorizontalAlign="Center" Font-Names="Tahoma">
                        <telerik:RadButton ID="radBtnOk" runat="server" Text="تایـیــد" Font-Names="Tahoma"
                            Width="95px" OnClick="radBtnOk_Click">
                        </telerik:RadButton>
                        <telerik:RadButton ID="radBtnCancel" runat="server" Text="انصـراف" Font-Names="Tahoma"
                            Width="95px" CausesValidation="False">
                        </telerik:RadButton>
                    </asp:Panel>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</asp:Content>
