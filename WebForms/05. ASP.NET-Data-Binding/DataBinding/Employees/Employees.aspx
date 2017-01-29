<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="Employees.Employees" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="page-header">
            <h3>Employees from Northwind database</h3>
        </div>
        <div>
            <asp:GridView ID="EmployeesGridview" AutoGenerateColumns="false" AllowPaging="true" runat="server">
                <Columns>
                    <asp:BoundField DataField="EmployeeId" HeaderText="Id" />
                    <asp:BoundField DataField="FirstName" HeaderText="First name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last name" />
                    <asp:HyperLinkField Text="Details" DataNavigateUrlFormatString="EmployeesDetails.aspx?id={0}" DataNavigateUrlFields="EmployeeId"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
