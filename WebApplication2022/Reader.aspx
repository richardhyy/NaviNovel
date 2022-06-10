<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Reader.aspx.cs" Inherits="WebApplication2022.Reader" %>


<asp:Content ID="Header" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            max-width: 800px;
            min-width: 400px;
            display: block;
            margin-left: auto;
            margin-right: auto;
            margin-top: 3em;
            margin-bottom: 3em;
            line-height: 2em;
            font-size: 14pt;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="AlertPanel" runat="server" Visible="False">
        <div class="alert alert-danger" role="alert">
            <asp:Label ID="ALertLabel" runat="server"></asp:Label>
        </div>
    </asp:Panel>


    <div class="d-flex justify-content-between">
        <h2>
            <asp:Label ID="TitleLabel" runat="server" Text="NaviNovel Reader"></asp:Label>
        </h2>

        <button type="button" class="btn btn-light" data-bs-toggle="modal" data-bs-target="#tocModal">
            Table of Contents
        </button>
    </div>


    <div class="container">
        <asp:Label ID="ContentLabel" runat="server" Text=":( Sorry"></asp:Label>
    </div>

    
    <div class="d-flex justify-content-between">
        <asp:Button ID="PreviousChapterButton" runat="server"  class="btn btn-secondary previous" Text="&lt; Previous Chapter" OnClick="PreviousChapterButton_Click" />

        <button type="button" class="btn btn-light" data-bs-toggle="modal" data-bs-target="#tocModal">
            Table of Contents
        </button>

        <asp:Button ID="NextChapterButton" runat="server"  class="btn btn-primary previous" Text="Next Chapter &gt;" OnClick="NextChapterButton_Click" />
    </div>

    <div class="modal fade" id="tocModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="tocModalLabel">Table of Contents</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="TableOfContentsLabel" runat="server" Text="Not available"></asp:Label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
