<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="TPFinalNivel3.ListaArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="separador"></div>
    <div class="row">
        <asp:GridView ID="dgvListaArticulos"  DataKeyNames="Id" AutoGenerateColumns="false" 
            CssClass="table table-bordered table-striped shadow-sm" style="text-align:center;"
             OnSelectedIndexChanged="dgvListaArticulos_SelectedIndexChanged" runat="server">
            <Columns>
                <asp:BoundField HeaderText="Codigo de Articulo" DataField="CodigoArticulo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                <asp:CommandField HeaderText="Modificar" SelectText="✍️" ShowSelectButton="true"  />
            </Columns>
        </asp:GridView>
    </div>

    <asp:Button Text="Agregar" CssClass="btn btn-primary px-4" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />


</asp:Content>
