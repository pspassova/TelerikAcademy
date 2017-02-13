<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="PhotoAlbum.Album" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="album">
        <table>
            <tr>
                <td>
                    <asp:Button ID="ButtonPrevious" runat="server" Text="Previous" />
                </td>
                <td>
                    <div class="image">
                        <asp:Image ID="Image" ImageUrl="~/images/train.jpg" runat="server" Width="600" />
                    </div>
                    <ajaxToolkit:SlideShowExtender ID="SlideShowExtender" runat="server" TargetControlID="Image"
                        SlideShowServiceMethod="GetImages" ImageTitleLabelID="ImageTitleLabel" ImageDescriptionLabelID="ImageDescriptionLabel"
                        AutoPlay="true" PlayInterval="2500" Loop="true" PlayButtonID="ButtonPlay" StopButtonText="Stop"
                        PlayButtonText="Play" NextButtonID="ButtonNext" PreviousButtonID="ButtonPrevious"></ajaxToolkit:SlideShowExtender>
                </td>
                <td>
                    <asp:Button ID="ButtonNext" runat="server" Text="Next" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="ButtonPlay" runat="server" Text="Play" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
