<%@ Page Title="Power Ulimited" Language="C#" MasterPageFile="~/PU.Master" AutoEventWireup="true" CodeBehind="MainPagina.aspx.cs" Inherits="PowerUnlimited.Paginas.MainPagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p> Welkom BakLappen op PU.NL</p><br/>
    <form ID="artikelform" runat="server">
        <asp:ListBox ID="LBArtikelen"  Width="500" On runat="server" /><br/>

    </form>
</asp:Content>