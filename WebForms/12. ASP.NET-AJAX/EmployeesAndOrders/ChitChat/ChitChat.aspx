<%@ Page Title="Chit Chat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="ChitChat.aspx.cs" Inherits="ChitChat.ChitChat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:ListView ID="MessagesListView" ItemType="ChitChat.Models.Models.Message" runat="server">
            <LayoutTemplate>
                <asp:UpdatePanel ID="MessagesUpdatePanel" runat="server">
                    <ContentTemplate>
                        <div id="ItemPlaceholder" runat="server"></div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger EventName="Tick" ControlID="RefreshTimer" />
                    </Triggers>
                </asp:UpdatePanel>
            </LayoutTemplate>

            <ItemTemplate>
                <%#: Item.Sender %>: <%#: Item.Content %>
                <br />
            </ItemTemplate>
        </asp:ListView>

        <asp:Timer ID="RefreshTimer" runat="server" Interval="500" />

    </div>

    <p>
        <asp:Label ID="UsernameLabel" runat="server" AssociatedControlID="UsernameTextBox" Text="Username: " />
        <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="MessagesLabel" runat="server" AssociatedControlID="MessagesTextBox" Text="Message: " />
        <asp:TextBox ID="MessagesTextBox" runat="server" CssClass="form-control"></asp:TextBox>
    </p>

    <asp:Button ID="ButtonSend" runat="server" Text="Send" CssClass="btn btn-info" OnClick="ButtonSend_Click" />
</asp:Content>
