<%@ Page Title="Employees and orders" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeesAndOrders.aspx.cs" Inherits="EmployeesAndOrders.EmployeesAndOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Select an employee to list it's orders.</h3>
    <p>
        <asp:UpdatePanel ID="EmployeesUpdatePanel" runat="server">
            <ContentTemplate>
                <asp:GridView ID="EmployeesGridView" runat="server" AutoGenerateColumns="false" DataSourceID="EmployeesDataSource" DataKeyNames="EmployeeID" OnSelectedIndexChanged="EmployeesGridView_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="EmployeeID" HeaderText="ID" />
                        <asp:BoundField DataField="FirstName" HeaderText="First name" />
                        <asp:BoundField DataField="LastName" HeaderText="Last name" />
                        <asp:CommandField ShowSelectButton="true" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:ObjectDataSource ID="EmployeesDataSource" runat="server" SelectMethod="SelectEmployees" TypeName="EmployeesAndOrders.EmployeesProvider"></asp:ObjectDataSource>
    </p>
    <br />
    <p>
        <asp:UpdatePanel ID="OrdersUpdatePanel" runat="server">
            <ContentTemplate>
                <asp:GridView ID="OrdersGridView" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="EmployeeID" HeaderText="Employee's ID" ControlStyle-BackColor="WhiteSmoke" />
                        <asp:BoundField DataField="OrderID" HeaderText="Order's ID" />
                        <asp:BoundField DataField="OrderDate" HeaderText="Date" />
                        <asp:BoundField DataField="ShipCountry" HeaderText="Ship country" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </p>
    <br />
    <asp:UpdateProgress ID="OrdersUpdateProgress" AssociatedUpdatePanelID="EmployeesUpdatePanel" runat="server">
        <ProgressTemplate>
            <img src="images/ajax-loader.gif" width="60" class="text-center" />
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
