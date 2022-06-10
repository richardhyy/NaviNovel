<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2022.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Books</h2>

    <div class="container overflow-hidden">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Label ID="LabelBookList" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
