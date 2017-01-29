<%@ Page Title="EmployeesFormView" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesFormView.aspx.cs" Inherits="Employees.EmployeesFormView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="page-header">
            <h3>Employees from Northwind database</h3>
        </div>
        <div>
            <asp:GridView ID="EmployeesGridview" AutoGenerateColumns="false" AllowPaging="true" runat="server" OnSelectedIndexChanged="EmployeesGridview_OnSelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="EmployeeId" HeaderText="Id" />
                    <asp:BoundField DataField="FirstName" HeaderText="First name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last name" />
                    <asp:CommandField ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
            <asp:FormView ID="EmployeesFormview" runat="server" ItemType="Employees.Employee">
                <ItemTemplate>
                    <p><strong>Name:</strong> <%# Item.FirstName + " " + Item.LastName %></p>
                    <p><strong>Title:</strong> <%# Item.Title %></p>
                    <p><strong>Birth date:</strong> <%# Item.BirthDate %></p>
                    <p><strong>Address:</strong> <%# Item.Address %></p>
                    <p><strong>City:</strong> <%# Item.City %></p>
                    <p><strong>Region:</strong> <%# Item.Region %></p>
                    <p><strong>Postal code:</strong> <%# Item.PostalCode %></p>
                    <p><strong>Country:</strong> <%# Item.Country %></p>
                    <p><strong>Notes:</strong> <%# Item.Notes %></p>
                    <p><strong>Photo path:</strong> <%# Item.PhotoPath %></p>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </div>
</asp:Content>
