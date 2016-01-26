<%@ Page Title="" Language="C#" MasterPageFile="~/PU.Master" AutoEventWireup="true" CodeBehind="NewThread.aspx.cs" Inherits="PowerUnlimited.Paginas.NewThread" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <asp:Label Text="Titel" Font-Size="12" runat="server"></asp:Label><br/>
        <asp:TextBox ID="tbTitel" Columns="30" runat="server"></asp:TextBox></><br/>
        <asp:Label Text="Body" Font-Size="12" runat="server"></asp:Label><br/>
        <asp:TextBox ID="tbBody" Rows="30" Columns="30" TextMode="MultiLine" runat="server"></asp:TextBox><br/>
        <asp:Button Text="Maakaan" runat="server" OnClick="UploadThread"/>
    </form>
</asp:Content>