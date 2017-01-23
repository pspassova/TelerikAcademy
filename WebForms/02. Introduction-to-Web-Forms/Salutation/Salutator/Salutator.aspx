<%@ Page Title="Salutator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Salutator.aspx.cs" Inherits="Salutator.Salutator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel-body">
        <asp:Label ID="NameLabel" runat="server" Text="Enter you name:" CssClass="label label-primary"></asp:Label>
        <asp:TextBox ID="NameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <p>
            <asp:Button ID="SubmitButton" runat="server" Text="Just click me!" OnClick="SubmitButton_Click" CssClass="btn btn-default" />
        </p>
        <asp:Label ID="SalutationLabel" runat="server"></asp:Label>
    </div>
</asp:Content>
