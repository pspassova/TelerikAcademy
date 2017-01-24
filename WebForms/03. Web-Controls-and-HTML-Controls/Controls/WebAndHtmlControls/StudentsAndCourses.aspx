<%@ Page Title="Students and Courses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentsAndCourses.aspx.cs" Inherits="WebAndHtmlControls.StudentsAndCourses" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="container">
            <div class="row centered-form">
                <div class="col-xs-20 col-sm-20 col-md-4 col-sm-offset-2 col-md-offset-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Register <small>Students</small></h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-xs-10 col-sm-10 col-md-10">
                                    <div class="form-group">
                                        <asp:TextBox ID="FirstName" runat="server" placeholder="First name" CssClass="form-control input-sm"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-xs-10 col-sm-10 col-md-10">
                                    <div class="form-group">
                                        <asp:TextBox ID="LastName" runat="server" placeholder="Last name" CssClass="form-control input-sm"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-10 col-sm-10 col-md-10">
                                    <div class="form-group">
                                        <asp:TextBox ID="FacultyNumber" runat="server" placeholder="Faculty number" CssClass="form-control input-sm"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-10 col-sm-10 col-md-10">
                                    <div class="form-group">
                                        <asp:DropDownList ID="UniversitiesDropdown" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Select university" Value="" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="Sofia University">Sofia University</asp:ListItem>
                                            <asp:ListItem Value="Sofia Medical University">Sofia Medical University</asp:ListItem>
                                            <asp:ListItem Value="University of National and World Economy">University of National and World Economy</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-10 col-sm-10 col-md-10">
                                    <div class="form-group">
                                        <asp:DropDownList ID="SpecialitiesDropdown" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Select specialty" Value="" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="Law">Law</asp:ListItem>
                                            <asp:ListItem Value="Psychology">Psychology</asp:ListItem>
                                            <asp:ListItem Value="Medical">Medical</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter specialty"
                                            ControlToValidate="SpecialitiesDropdown" Font-Bold="True" ForeColor="#FF0066"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-10 col-sm-10 col-md-10">
                                    <div class="form-group">
                                        <asp:ListBox ID="CoursesList" SelectionMode="Multiple" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Select specialty"></asp:ListItem>
                                            <asp:ListItem Value="Engineering & Technology">Engineering & Technology</asp:ListItem>
                                            <asp:ListItem Value="Business and Management">Business and Management</asp:ListItem>
                                            <asp:ListItem Value="Arts & Humanities">Arts & Humanities</asp:ListItem>
                                        </asp:ListBox>
                                    </div>
                                </div>
                            </div>
                            <asp:Button ID="RegisterButton" Text="Show registration info" runat="server" CssClass="btn btn-info btn-block" OnClick="RegisterButton_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <asp:Label ID="ResultLabel" runat="server" CssClass="panel-title"></asp:Label>
            <asp:Panel ID="ResultPanel" runat="server"></asp:Panel>
        </div>
    </div>
</asp:Content>
