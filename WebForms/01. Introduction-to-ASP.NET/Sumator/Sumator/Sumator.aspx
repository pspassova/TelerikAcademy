<%@ Page Title="Simple Sumator" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Sumator.aspx.cs" Inherits="Sumator.Sumator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" class="panel panel-default">
    <div class="panel-body">
        <p>
            <asp:Label ID="FirstNumberLabel" runat="server" Text="Enter a number:" CssClass="label label-primary"></asp:Label>
            <asp:TextBox ID="FirstNumber" runat="server" CssClass="form-control"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="SecondNumberLabel" runat="server" Text="Enter a number:" CssClass="label label-primary"></asp:Label>
            <asp:TextBox ID="SecondNumber" runat="server" CssClass="form-control"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="SumButton" runat="server" Text="Sum numbers" OnClick="SumButton_Click" CssClass="btn btn-default" />
        </p>
        <p>
            <asp:Label ID="ResultLabel" runat="server" Text="Result:"></asp:Label>
            <asp:Label ID="FinalSumLabel" runat="server"></asp:Label>
        </p>
    </div>
</asp:Content>
