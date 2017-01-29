<%@ Page Title="EmployeesDetails" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesDetails.aspx.cs" Inherits="Employees.EmployeesDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="page-header">
            <h3>Employee's details</h3>
        </div>
        <div>
            <asp:DetailsView ID="EmployeesDetailsView" runat="server"></asp:DetailsView>
        </div>
        <div class="text-center">
            <asp:Button Text="Back" runat="server" CssClass="btn btn-danger" OnClick="ButtonBack_OnClick" />
        </div>
    </div>
</asp:Content>
