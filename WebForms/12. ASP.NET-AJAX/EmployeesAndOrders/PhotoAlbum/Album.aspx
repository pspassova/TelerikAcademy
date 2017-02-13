<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="PhotoAlbum.Album" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <ajaxToolkit:ToolkitScriptManager ID="ScriptManager" runat="server"></ajaxToolkit:ToolkitScriptManager>

        <hr />
        <p>
            <asp:Image ID="ImageControl" runat="server" Height="440" />
            <ajaxToolkit:SlideShowExtender
                runat="server"
                BehaviorID="SSBehaviorID"
                TargetControlID="ImageControl"
                SlideShowServiceMethod="GetImages"
                AutoPlay="true"
                PreviousButtonID="ButtonPrevious"
                PlayButtonID="ButtonPlay"
                NextButtonID="ButtonNext"
                PlayButtonText="Play"
                StopButtonText="Stop"
                Loop="true">
            </ajaxToolkit:SlideShowExtender>
        </p>
        <hr />

        <div class="text-center">
            <asp:Button ID="ButtonPrevious" runat="server" Text="Previous" CssClass="btn btn-default" />
            <asp:Button ID="ButtonPlay" runat="server" Text="Play" CssClass="btn btn-warning" />
            <asp:Button ID="ButtonNext" runat="server" Text="Next" CssClass="btn btn-default" />
        </div>
    </form>
</body>
</html>
