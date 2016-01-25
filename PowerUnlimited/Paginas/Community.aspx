<%@ Page Title="" Language="C#" MasterPageFile="~/PU.Master" AutoEventWireup="true" CodeBehind="Community.aspx.cs" Inherits="PowerUnlimited.Paginas.Community" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Baklap community</h1>
    <form role="form" id="threadform" runat="server">
        <div id="LoginDiv" runat="server">
            <asp:HyperLink runat="server" NavigateUrl="NewThread.aspx">
                <Button type="button">Nieuwe thread maken</Button>
            </asp:HyperLink>
        </div><br/>
        <asp:ListBox ID="LBThread" runat="server"/>
    </form>
</asp:Content>