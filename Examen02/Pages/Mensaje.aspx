<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mensaje.aspx.cs" Inherits="Examen02.Pages.Mensaje" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2>Proceso completado con exito</h2>

    <div class="alert alert-success">

        <p>Ha registrado correctamente los datos de una persona en la base de datos</p>
    </div>

    <div>
        <a href="ListaPersonas.aspx">Regresar</a>
    </div>
</asp:Content>
