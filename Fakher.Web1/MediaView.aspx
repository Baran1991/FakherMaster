<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MediaView.aspx.cs" Inherits="MediaView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--    <script src="<%= Page.ResolveClientUrl("~/Scripts/jquery-1.7.2.min.js") %>" type="text/javascript"></script>--%>
    <script src="<%= Page.ResolveClientUrl("~/Scripts/jwplayer.js") %>" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">Loading the player ...</div>
        
        <script type="text/javascript">
            jwplayer("container").setup({
                flashplayer: '<%= Page.ResolveClientUrl("~/Scripts/player.swf") %>',
                playlist: [
                    { file: '<%= Page.ResolveClientUrl("~/Media.aspx?c=" + Request.QueryString[0]) %>', provider: "sound" }
                ],
                height: 60
            });
        </script>
    </form>
</body>
</html>
