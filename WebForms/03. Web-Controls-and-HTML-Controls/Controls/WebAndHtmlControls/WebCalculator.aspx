<%@ Page Title="Web Calculator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebCalculator.aspx.cs" Inherits="WebAndHtmlControls.WebCalculator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-4 well form-group text-center">
                <asp:TextBox ID="InputTextBox" runat="server" CssClass="text-right"></asp:TextBox>
                <div class="container">
                    <div class="row">
                        <asp:Button ID="ButtonOne" Text="1" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonOne_Click" />
                        <asp:Button ID="ButtonTwo" Text="2" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonTwo_Click" />
                        <asp:Button ID="ButtonThree" Text="3" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonThree_Click" />
                        <asp:Button ID="ButtonAdd" Text="+" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonAdd_Click" />
                    </div>
                    <div class="row">
                        <asp:Button ID="ButtonFour" Text="4" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonFour_Click" />
                        <asp:Button ID="ButtonFive" Text="5" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonFive_Click" />
                        <asp:Button ID="ButtonSix" Text="6" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonSix_Click" />
                        <asp:Button ID="ButtonSubtract" Text="-" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonSubtract_Click" />
                    </div>
                    <div class="row">
                        <asp:Button ID="ButtonSeven" Text="7" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonSeven_Click" />
                        <asp:Button ID="ButtonEight" Text="8" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonEight_Click" />
                        <asp:Button ID="ButtonNine" Text="9" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonNine_Click" />
                        <asp:Button ID="ButtonMultiply" Text="x" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonMultiply_Click" />
                    </div>
                    <div class="row">
                        <asp:Button ID="ButtonClear" Text="Clear" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonClear_Click" />
                        <asp:Button ID="ButtonZero" Text="0" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonZero_Click" />
                        <asp:Button ID="ButtonDivide" Text="/" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonDivide_Click" />
                        <asp:Button ID="ButtonSqrt" Text="√" runat="server" CssClass="btn btn-info" Width="60px" OnClick="ButtonSqrt_Click" />
                    </div>
                </div>
                <div class="container">
                    <div class="row">
                        <asp:Button ID="ButtonEquals" Text="=" runat="server" CssClass="btn btn-info" Width="160px" OnClick="ButtonEquals_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
