<%@ Page Title="Login Cookie" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginCookie.aspx.cs" Inherits="StateManagement.LoginCookie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:Label ID="NotLoggedLabel" Text="Not logged in." runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="LoginButton" Text="Log in already!" runat="server" CssClass="btn btn-primary" OnClick="LoginButton_Click" />
    </p>
</asp:Content>
