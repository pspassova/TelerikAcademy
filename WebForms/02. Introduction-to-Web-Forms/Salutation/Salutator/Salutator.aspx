<%@ Page Title="Salutator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Salutator.aspx.cs" Inherits="Salutator.Salutator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel-body">
        <asp:Label ID="NameLabel" runat="server" Text="Enter you name:" CssClass="label label-primary"></asp:Label>
        <asp:TextBox ID="NameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <p>
            <asp:Button ID="SubmitButton" runat="server" Text="Just click me!" OnClick="SubmitButton_Click" CssClass="btn btn-default" />
        </p>
        <div class="jumbotron">
            <p>
                <asp:Label ID="SalutationLabel" runat="server"></asp:Label>
            </p>
            <asp:Label ID="HelloFromTheAspxCodeLabel" runat="server">This is the aspx code talking.</asp:Label>
            <br />
            <asp:Label ID="HelloFromTheCsharpCodeLabel" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
