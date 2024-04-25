<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearPersona.aspx.cs" Inherits="Examen02.Pages.CrearPersona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Crear persona</h2>

    <div>
        <div>
            <span>Provincia</span>
            <asp:DropDownList ID="DdProvincias" runat="server" Enabled="true"></asp:DropDownList>
        </div>
        <div>
            <span>Nombre completo</span>
            <asp:TextBox ID="TxtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <span>Teléfono (0000-0000)</span>
            <asp:TextBox ID="TxtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <span>Fecha nacimiento</span>
            <asp:TextBox ID="TxtNacimiento" runat="server" DataFormatString="{0:d}" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <span>Salario</span>
            <asp:TextBox ID="TxtSalario" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div style="margin-top: 10px">
            <asp:Button ID="BtnAgregar" runat="server" Text="Guardar"
                 ForeColor="White" CssClass="btn btn-primary"
                OnClick="BtnAgregar_Click" />
            <asp:Button ID="BtnRegresar" runat="server" Text="Regresar" BackColor="White" ForeColor="Black" CssClass="btn btn-primary" OnClick="BtnRegresar_Click" />
        </div>
    </div>
</asp:Content>
