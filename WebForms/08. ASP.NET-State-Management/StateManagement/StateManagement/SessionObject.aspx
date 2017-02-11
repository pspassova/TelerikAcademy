<%@ Page Title="Session Object" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SessionObject.aspx.cs" Inherits="StateManagement.SessionObject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <asp:TextBox ID="InputTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="SubmitButton" Text="Submit to Session" runat="server" OnClick="SubmitButton_Click" />
    <p>
    <p>
        From Session:
    <asp:Label ID="ResutLabel" runat="server"></asp:Label>
    </p>
</asp:Content>
