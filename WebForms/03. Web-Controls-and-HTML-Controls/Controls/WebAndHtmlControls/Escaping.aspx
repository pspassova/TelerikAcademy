<%@ Page Title="Escaping" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" validateRequest="false" CodeBehind="Escaping.aspx.cs" Inherits="WebAndHtmlControls.Escaping" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron"">
        <p>
            <label for="TextBox" class="label label-primary">Enter some very dangerous text.: </label>
            <br />
            <asp:TextBox ID="TextBox" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
        </p>
        <%--<pre>example: &lt;h1&gt;Heading&lt;/h1&gt;Text&lt;script&gt;alert(&quot;bug!&quot;)&lt;/script&gt;</pre>--%>
        <p>
            <asp:Button ID="DisplayText" runat="server" Text="Display text" OnClick="DisplayText_Click" CssClass="btn btn-default" />
        </p>
            <br />
        <div>
            <h4>Escaped text in a label: </h4>
            <asp:Label ID="ResultLabel" runat="server"></asp:Label>
            <h4>Escaped text in a texbox: </h4>
            <asp:TextBox ID="ResultTextBox" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
</asp:Content>
