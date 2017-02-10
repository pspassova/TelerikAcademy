<%@ Page Title="Uploader" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Uploader.aspx.cs" Inherits="ZipUploader.WebClient.Uploader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FileUpload ID="FileUploadControl" runat="server" />
    <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" />
    <br />
    <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
    <asp:Label runat="server" ID="ResultLabel" Text="File: " />
</asp:Content>
