<%@ Page Title="TreeView" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="TreeView.aspx.cs" Inherits="XmlTree.TreeView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <asp:Label ID="InnerXmlLabel" runat="server" CssClass="label label-info"></asp:Label>
        <asp:XmlDataSource ID="XmlSource" DataFile="sources/plant-catalog.xml" runat="server"></asp:XmlDataSource>
        <asp:TreeView ID="XmlTreeView" DataSourceID="XmlSource" runat="server" OnTreeNodeDataBound="XmlTreeView_TreeNodeDataBound" OnSelectedNodeChanged="XmlSource_SelectedNodeChanged">
        </asp:TreeView>
    </div>
</asp:Content>
