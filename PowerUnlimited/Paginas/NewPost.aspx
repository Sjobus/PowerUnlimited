<%@ Page Title="" Language="C#" MasterPageFile="~/PU.Master" AutoEventWireup="true" CodeBehind="NewPost.aspx.cs" Inherits="PowerUnlimited.Paginas.NewPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <asp:Label Text="Artikel type" Font-Size="12" runat="server"></asp:Label>
        <asp:RadioButtonList ID="ASoort" runat="server">
            <asp:ListItem>N8W8</asp:ListItem>
            <asp:ListItem>Artikel</asp:ListItem>
            <asp:ListItem>Blog</asp:ListItem>
            <asp:ListItem>Review</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label Text="Titel" Font-Size="12" runat="server"></asp:Label><br/>
        <asp:TextBox ID="tbTitel" Columns="30" runat="server"></asp:TextBox></><br/>
        <asp:Label Text="Body" Font-Size="12" runat="server"></asp:Label><br/>
        <asp:TextBox ID="tbBody" Rows="30" Columns="30" TextMode="MultiLine" runat="server"></asp:TextBox><br/>
        <asp:Button Text="Maakaan" runat="server" OnClick="UploadArtikel"/>
    </form>
</asp:Content>