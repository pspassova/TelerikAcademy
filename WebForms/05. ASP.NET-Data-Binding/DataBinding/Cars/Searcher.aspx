<%@ Page Title="Searcher" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Searcher.aspx.cs" Inherits="Cars.Searcher" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="page-header">
            <h3>Search cars by producer, extra and type of engine</h3>
        </div>
        <div class="well well-lg">
            <div class="row">
                <asp:Label Text="Pick a producer's name" runat="server" CssClass="label label-danger"></asp:Label>
                <asp:DropDownList ID="ProducerNameDropdown" DataValueField="Name" runat="server" CssClass="btn btn-default dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ProducerNameDropdown_OnSelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="row">
                <asp:Label Text="Pick a model" runat="server" CssClass="label label-danger"></asp:Label>
                <asp:DropDownList ID="ProducerModelDropdown" runat="server" CssClass="btn btn-default dropdown-toggle"></asp:DropDownList>
            </div>
            <div class="row">
                <asp:Label Text="Pick an engine type" runat="server" CssClass="label label-danger"></asp:Label>
                <asp:RadioButtonList ID="EngineRadiobutton" RepeatDirection="Horizontal" runat="server" CssClass="radio radio-inline"></asp:RadioButtonList>
            </div>
            <div class="row">
                <asp:Label Text="Pick some extras" runat="server" CssClass="label label-danger"></asp:Label>
                <asp:CheckBoxList ID="ExtrasCheckbox" DataValueField="Type" runat="server" CssClass="checkbox"></asp:CheckBoxList>
            </div>
        </div>
        <div class="text-center">
            <asp:Button ID="SubmitButton" Text="Search" runat="server" CssClass="btn btn-danger" OnClick="SubmitButton_OnClick"/>
        </div>
        <div>
            <asp:Literal ID="SearchResultLiteral" runat="server"></asp:Literal>
        </div>
    </div>
</asp:Content>
