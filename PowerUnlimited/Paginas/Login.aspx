<%@ Page Title="" Language="C#" MasterPageFile="~/PU.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PowerUnlimited.Paginas.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form role="form" id="formLogin" runat="server">
        <div id="LoginDiv" runat="server">
            <asp:Label Text="Email" Font-Size="9" BackColor="Black" ForeColor="White" runat="server"></asp:Label>
            <asp:TextBox ID="loginNaam" TextMode="Email" runat="server"></asp:TextBox>
            <asp:TextBox ID="loginWW" TextMode="Password" runat="server"></asp:TextBox>
            <asp:Button ID="loginSubmit" runat="server" Text="Login" OnClick="SubmitLoginForm"/>
        </div>
        <div id="LogoutDiv" runat="server">
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_OnClick"/><br/>
        </div>
        <div id="ATDiv" runat="server">
            <asp:HyperLink runat="server" NavigateUrl="NewPost.aspx">
                <Button type="button">Maak een nieuwe post</Button>
            </asp:HyperLink>
        </div>
    </form><br/>
</asp:Content>