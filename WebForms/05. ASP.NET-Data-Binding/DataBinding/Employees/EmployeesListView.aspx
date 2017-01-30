<%@ Page Title="EmployeesListView" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesListView.aspx.cs" Inherits="Employees.EmployeesListView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:ListView ID="EmployeesListview" runat="server" ItemType="Employees.Employee">
            <LayoutTemplate>
                <h3>Employees from Northwind database</h3>
                <br />
                <asp:PlaceHolder runat="server" ID="ItemPlaceholder"></asp:PlaceHolder>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="product-description">
                    <p><%#: string.Format("{0}. {1} {2}",Item.EmployeeID,Item.FirstName,Item.LastName) %></p>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
