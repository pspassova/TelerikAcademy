<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Countries.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="page-header">
            <h2>Welcome welcome to the simplest international company app of all times!</h2>
        </div>
        <div>
            <p class="text-warning">Choose your country</p>
            <div class="list-group">
                <asp:HyperLink Text="Bulgaria" runat="server" NavigateUrl="Bulgaria/Home.aspx" CssClass="list-group-item"></asp:HyperLink>
                <asp:HyperLink Text="England" runat="server" NavigateUrl="England/Home.aspx" CssClass="list-group-item"></asp:HyperLink>
                <asp:HyperLink Text="Japan" runat="server" NavigateUrl="Japan/Home.aspx" CssClass="list-group-item"></asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>
