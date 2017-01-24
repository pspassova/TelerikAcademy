<%@ Page Title="Students and Courses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentsAndCourses.aspx.cs" Inherits="WebAndHtmlControls.StudentsAndCourses" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="container">
            <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">Register <small>Students</small></h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-10 col-sm-10 col-md-10">
                            <asp:TextBox ID="FirstName" runat="server" placeholder="First name" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ErrorMessage="You must enter your first name!" ControlToValidate="FirstName"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-xs-10 col-sm-10 col-md-10">
                            <asp:TextBox ID="LastName" runat="server" placeholder="Last name" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ErrorMessage="You must enter your last name!" ControlToValidate="LastName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-10 col-sm-10 col-md-10">
                            <asp:TextBox ID="FacultyNumber" runat="server" placeholder="Faculty number" CssClass="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ErrorMessage="You must enter your faculty number!" ControlToValidate="FacultyNumber"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-10 col-sm-10 col-md-10">
                            <asp:DropDownList ID="UniversitiesDropdown" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Select university" Value="" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="Sofia University">Sofia University</asp:ListItem>
                                <asp:ListItem Value="Sofia Medical University">Sofia Medical University</asp:ListItem>
                                <asp:ListItem Value="University of National and World Economy">University of National and World Economy</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ErrorMessage="You must choose a university!" ControlToValidate="UniversitiesDropdown"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-10 col-sm-10 col-md-10">
                            <asp:DropDownList ID="SpecialitiesDropdown" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Select specialty" Value="" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="Law">Law</asp:ListItem>
                                <asp:ListItem Value="Psychology">Psychology</asp:ListItem>
                                <asp:ListItem Value="Medical">Medical</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator runat="server" ErrorMessage="You must choose a specialty!" ControlToValidate="SpecialitiesDropdown"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-xs-10 col-sm-10 col-md-10">
                            <asp:ListBox ID="CoursesList" SelectionMode="Multiple" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Select specialty"></asp:ListItem>
                                <asp:ListItem Value="Engineering & Technology">Engineering & Technology</asp:ListItem>
                                <asp:ListItem Value="Business and Management">Business and Management</asp:ListItem>
                                <asp:ListItem Value="Arts & Humanities">Arts & Humanities</asp:ListItem>
                            </asp:ListBox>
                            <asp:RequiredFieldValidator runat="server" ErrorMessage="You must choose at least one course!" ControlToValidate="CoursesList"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <asp:Button ID="RegisterButton" Text="Show registration info" runat="server" CssClass="btn btn-info btn-block" OnClick="RegisterButton_Click"></asp:Button>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <asp:Label ID="ResultLabel" runat="server" CssClass="panel-title"></asp:Label>
        <asp:Panel ID="ResultPanel" runat="server"></asp:Panel>
    </div>
</asp:Content>
