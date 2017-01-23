<%@ Page Title="Lifecycle events" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Events.aspx.cs" Inherits="LifecycleEvents.Events" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <p>
            <asp:Label ID="PageEventsLabel" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="EventsButton" Text="Click for more button events" runat="server" CssClass="btn btn-default"
                OnClick="EventsButton_Click"
                OnInit="EventsButton_Init"
                OnLoad="EventsButton_Load"
                OnPreRender="EventsButton_PreRender"
                OnCommand="EventsButton_Command"
                OnDataBinding="EventsButton_DataBinding"
                OnDisposed="EventsButton_Disposed" />
        </p>
        <p>
            <asp:Label ID="ButtonEventsLabel" runat="server"></asp:Label>
        </p>
    </div>
</asp:Content>
