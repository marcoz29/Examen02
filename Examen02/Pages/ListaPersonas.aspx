<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaPersonas.aspx.cs" Inherits="Examen02.Pages.ListaPersonas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>
        Lista de Personas
        </h2>
    </div>
    <div style="margin-bottom: 10px;">
        <a href="CrearPersona.aspx" class="btn btn-primary">Crear persona</a>
    </div>
    <asp:GridView ID="GvListarPersonas" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" Style="margin-bottom: 10px">
        <Columns>
            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="idPersona" HeaderText="Id" />
            <asp:BoundField ItemStyle-HorizontalAlign="Left" DataField="nombreProvincia" HeaderText="Provincia" />
            <asp:BoundField ItemStyle-HorizontalAlign="Left" DataField="nombreCompleto" HeaderText="Nombre completo" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataField="telefono" HeaderText="Teléfono" />
            <asp:BoundField ItemStyle-HorizontalAlign="Center" DataFormatString="{0:d}" DataField="fechaNacimiento" HeaderText="Fecha nacimiento" />
            <asp:BoundField ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" DataField="salario" HeaderText="Salario" />
            <asp:TemplateField HeaderText="Edad" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="LabelEdad" runat="server" Text='<%# CalcularEdad((DateTime)Eval("fechaNacimiento")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Generacion" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="LblGeneracion" runat="server" Text='<%# CalcularGeneracion((DateTime)Eval("fechaNacimiento")) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="EditarPersona.aspx?id=<%# Eval("idPersona") %> ">Editar</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
