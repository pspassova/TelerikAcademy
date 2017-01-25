<%@ Page Title="Personal info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="UserProfile.PersonalInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="text-center">
            <asp:Image ID="Avatar" runat="server" CssClass="img-fluid rounded mx-auto d-block img-circle" />
        </div>
        <br />
        <div class="text-center">
            <p>First name: <strong>Justin</strong></p>
            <p>Last name: <strong>Timberlake</strong></p>
            <p>Age: <strong>3</strong></p>
        </div>
    </div>
</asp:Content>
