<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Examen02.Pages.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ha ocurrido un error</h2>

    <div class="alert-danger">

        <p>Algo ha salido mal...</p>
    </div>

    <div>
        <a href="ListaPersonas.aspx">Regresar</a>
    </div>
</asp:Content>
