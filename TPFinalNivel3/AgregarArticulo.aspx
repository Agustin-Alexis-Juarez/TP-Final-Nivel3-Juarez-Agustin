<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarArticulo.aspx.cs" Inherits="TPFinalNivel3.AgregarArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="agregar-articulo__separador"></div>

    <div class="perfil__contenedor py-4 px-4">
            <div class="agregar-articulo__titulo">
                <h1>Agregar articulo</h1>
            </div>
            <div class="perfil__datos d-flex container-fluid flex-column">
                <div class="row agregar-articulo__datos-imagen">
                    <div class="col">

                        <div class="mb-3">
                            <asp:Label Text="Id:" ID="lblId" runat="server" />
                            <asp:TextBox ID="txtId" CssClass="form-control" runat="server" />
                        </div>
                        <div class="mb-3">
                            <label for="txtCodigoArticulo">Codigo de Articulo:</label>
                            <asp:TextBox ID="txtCodigoArticulo" CssClass="form-control" runat="server" />
                        </div>
                        <div class="mb-3">
                            <label for="txtNombre">Nombre:</label>
                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                        </div>
                        <div class="mb-3">
                            <label for="txtDescripcion">Descripción:</label>
                            <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" />
                        </div>
                        <div class="mb-3">
                            <label for="ddlMarca">Marca:</label>
                            <asp:DropDownList  id="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <label for="ddlCategoria">Categoria:</label>
                            <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <label for="txtPrecio">Precio:</label>
                            <asp:TextBox ID="txtPrecio" CssClass="form-control"  runat="server" />
                        </div>
                    </div>
                            <div class="col">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                                <div class="mb-3">
                                    <label>Imagen:</label>
                                    <asp:TextBox ID="txtUrlImagen" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" runat="server" />
                               
                                </div>
                                <div class="d-flex mb-3">
                                    <asp:Image ID="imgArticulo" ImageUrl="https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png" CssClass="img-fluid mb-3 agregar-articulo__imagen" runat="server" />
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                            </div>
               
                </div>
                <div class="row agregar-articulo__btn">
                    <div class="mb-3">
                        <asp:Button Text="Guardar" CssClass="btn btn-primary py-2 px-4 rounded-1" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
                        <a href="ListaArticulos.aspx">Cancelar</a>
                    </div>
                </div>
            </div>
       </div>


</asp:Content>
