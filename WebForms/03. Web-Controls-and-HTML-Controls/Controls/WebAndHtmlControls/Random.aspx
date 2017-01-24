<%@ Page Title="Random" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Random.aspx.cs" Inherits="WebAndHtmlControls.Random" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel-body">
        <p>
            <label for="LowerRangeInput" class="label label-primary">Lower Range: </label>
            <input id="LowerRangeInput" type="number" runat="server" class="form" />
        </p>
        <p>
            <label for="UpperRangeInput" class="label label-primary">Upper Range: </label>
            <input id="UpperRangeInput" type="number" runat="server" class="form" />
        </p>
        <p>
            <asp:Button ID="GeneratorButton" runat="server" Text="Generate random number" OnClick="GeneratorButton_Click" CssClass="btn btn-default" />
        </p>
        <asp:Label ID="ResultLabel" runat="server"></asp:Label>
    </div>
</asp:Content>
