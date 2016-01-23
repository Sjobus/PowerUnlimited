<%@ Page Title="" Language="C#" MasterPageFile="~/PU.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="PowerUnlimited.Paginas.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Een accountje maken baklap</h1>
    <form role="form" id="CreateForm" runat="server">
        <asp:Label Text="User name" BackColor="black" ForeColor="white" runat="server"></asp:Label><br/>
        <asp:TextBox ID="UsernameBox" runat="server"></asp:TextBox><br/>
        <asp:Label BackColor="black" ForeColor="white" Text="Email" runat="server"></asp:Label><br/>
        <asp:TextBox ID="UserEmail" TextMode="Email" runat="server"></asp:TextBox><br/>
        <asp:Label Text="Wachtwoord" BackColor="black" ForeColor="white" runat="server"></asp:Label><br/>
        <asp:TextBox ID="Userww" TextMode="Password" runat="server"></asp:TextBox><br/>
        <asp:Label Text="nog een keertje" BackColor="black" ForeColor="white" runat="server"></asp:Label><br/>
        <asp:TextBox ID="wwCheck" TextMode="Password" runat="server"></asp:TextBox><br/>
        <asp:Button ID="CreateSubmit" runat="server" Text="Account aanmaken" OnClick="GebruikerMaken"/>
    </form>
</asp:Content>