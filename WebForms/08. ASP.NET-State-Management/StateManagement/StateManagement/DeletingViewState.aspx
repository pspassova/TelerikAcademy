<%@ Page Title="Deleting ViewState" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeletingViewState.aspx.cs" Inherits="StateManagement.DeletingViewState" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <p>
            <asp:TextBox ID="ViewStateWriteTextBox" runat="server"></asp:TextBox>
            <asp:Button ID="ViewStateWriteButton" Text="Write in ViewState" runat="server" OnClick="ViewStateWriteButton_Click" />
        </p>
        <p>
            <button id="DeleteViewStateButton">Delete ViewState</button>
        </p>
        <p>
            <asp:Label ID="ViewStateResultLabel" runat="server"></asp:Label>
        </p>
    </div>
    <script>
        $(document).ready(
                    $('#DeleteViewStateButton').on('click', () => {
                        $('#__VIEWSTATE').val('');
                    }));
    </script>
</asp:Content>

