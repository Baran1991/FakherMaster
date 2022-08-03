<%@ Control Language="C#" AutoEventWireup="true" CodeFile="rMessageBox.ascx.cs" Inherits="rComponents_rMessageBox" %>

<script type="text/javascript">
    var radWindow;
    function OnClientShow(oWnd) {
        radWindow = oWnd;
    }

    function OnClientClicking(button, args) {
//        debugger;
//        if (hasResult)
//            button.click();
        if(!hasResult) {
            radWindow.Close();
            args.set_cancel(true);   
        }
//        button.set_autoPostBack(false);
    }
</script>

<telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    <Windows>
        <telerik:RadWindow ID="RadWindow1" runat="server" Modal="true" Title="پیام سیستـم"
            VisibleOnPageLoad="True" VisibleTitlebar="True" VisibleStatusbar="false" Visible="False"
            Height="200px" Width="400px" Style="z-index: 200001;" OnClientShow="OnClientShow" Behaviors="Close">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" Font-Names="Tahoma" HorizontalAlign="Center" Font-Size="12px">
                    <p>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </p>
                    <br />
                    <asp:Panel ID="pnlInformation" runat="server" Visible="False" Font-Names="Tahoma" HorizontalAlign="Center">
                        <telerik:RadButton ID="rBtnOk" runat="server" Text="تایـیـد" Width="75px" Font-Names="Tahoma"
                            OnClientClicking="OnClientClicking" OnClick="rBtnOk_Click" CausesValidation="False">
                        </telerik:RadButton>
                    </asp:Panel>
                    
                    <asp:Panel ID="pnlOkCancel" runat="server" Visible="False" Font-Names="Tahoma" HorizontalAlign="Center">
                        <telerik:RadButton ID="rBtnOk2" runat="server" Text="تایـیـد" Width="75px" Font-Names="Tahoma"
                            OnClientClicking="OnClientClicking" OnClick="rBtnOk_Click" CausesValidation="False">
                        </telerik:RadButton>
                        <telerik:RadButton ID="rBtnCancel" runat="server" Text="انصـراف" Width="75px" Font-Names="Tahoma"
                            OnClientClicking="OnClientClicking" OnClick="rBtnCancel_Click" CausesValidation="False">
                        </telerik:RadButton>
                    </asp:Panel>
                    <asp:Panel ID="pnlYesNo" runat="server" Visible="False" Font-Names="Tahoma" HorizontalAlign="Center">
                        <telerik:RadButton ID="rBtnYes" runat="server" Text="بــلــه" Width="75px" Font-Names="Tahoma"
                            OnClientClicking="OnClientClicking" OnClick="rBtnYes_Click" CausesValidation="False">
                        </telerik:RadButton>
                        <telerik:RadButton ID="rBtnNo" runat="server" Text="نــــه" Width="75px" Font-Names="Tahoma"
                            OnClientClicking="OnClientClicking" OnClick="rBtnNo_Click" CausesValidation="False">
                        </telerik:RadButton>
                    </asp:Panel>
                </asp:Panel>
            </ContentTemplate>
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
