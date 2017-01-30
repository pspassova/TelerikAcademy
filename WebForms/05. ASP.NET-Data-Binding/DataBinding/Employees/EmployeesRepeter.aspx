<%@ Page Title="EmployeesRepeter" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesRepeter.aspx.cs" Inherits="Employees.EmployeesRepeter" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Repeater ID="RepeaterEmployees" ItemType="Employees.Employee" runat="server">
            <HeaderTemplate>
                <h3>Employees from Northwind database</h3>
                <br />
            </HeaderTemplate>
            <ItemTemplate>
                <table>
                    <tr>
                        <td><%# Item.EmployeeID %>. </td>
                        <td><%# Item.FirstName %></td>
                        <td><%# Item.LastName %></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
