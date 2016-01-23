<%@ Page Title="" Language="C#" MasterPageFile="~/PU.Master" AutoEventWireup="true" CodeBehind="AllArtikels.aspx.cs" Inherits="PowerUnlimited.Paginas.AllArtikels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Alle Artikelen die we hebben baklap</h1>
    <form runat="server">
        <asp:ListBox ID="LBArtikelen" Width="500" runat="server"/>
    </form>
</asp:Content>