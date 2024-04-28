<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AgregarArticulo.aspx.cs" Inherits="TPFinalNivel3.AgregarArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="agregar-articulo__separador"></div>

    <div class="perfil__contenedor py-4 px-4">
            <div class="agregar-articulo__titulo">
                <h1 id="h1AgregarArticulo" runat="server">Agregar artículo</h1>
            </div>
            <div class="perfil__datos d-flex container-fluid flex-column">
                <div class="row agregar-articulo__datos-imagen">
                    <div class="col">

                        <div class="mb-3">
                            <asp:Label Text="Id:" ID="lblId" runat="server" />
                            <asp:TextBox ID="txtId" CssClass="form-control" runat="server" />
                        </div>
                        <div class="mb-3">
                            <label for="txtCodigoArticulo">Código de Artículo:</label>
                            <asp:TextBox ID="txtCodigoArticulo" CssClass="form-control" runat="server" MaxLength="50" />
                            <asp:RequiredFieldValidator ErrorMessage="El código de artículo no puede quedar vacío." ControlToValidate="txtCodigoArticulo" ForeColor="Red" Display="Dynamic" runat="server" />
                        </div>
                        <div class="mb-3">
                            <label for="txtNombre">Nombre:</label>
                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" MaxLength="50" />
                            <asp:RequiredFieldValidator ErrorMessage="El nombre no puede quedar vacío." ControlToValidate="txtNombre" ForeColor="Red" runat="server" Display="Dynamic" />
                        </div>
                        <div class="mb-3">
                            <label for="txtDescripcion">Descripción:</label>
                            <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" MaxLength="150" />
                        </div>
                        <div class="mb-3">
                            <label for="ddlMarca">Marca:</label>
                            <asp:DropDownList  id="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <label for="ddlCategoria">Categoría:</label>
                            <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <label for="txtPrecio">Precio:</label>
                            <asp:TextBox ID="txtPrecio" CssClass="form-control"  runat="server" />
                            <asp:RequiredFieldValidator ErrorMessage="No puede quedar vacío." ControlToValidate="txtPrecio" ForeColor="Red" Display="Dynamic" runat="server" />
                            <asp:RegularExpressionValidator ErrorMessage="Solo se permiten números sin punto." ControlToValidate="txtPrecio" ForeColor="Red" ValidationExpression="^[0-9]+(,[0-9]+)?$" runat="server" Display="Dynamic" />
                        </div>
                    </div>
                            <div class="col">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                                <div class="mb-3">
                                    <label>Imagen:</label>
                                    <asp:TextBox ID="txtUrlImagen" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" runat="server" MaxLength="1000" />
                                </div>
                                <div class="d-flex mb-3">
                                    <asp:Image ID="imgArticulo" CssClass="img-fluid mb-3 agregar-articulo__imagen" onerror="this.onerror=null; this.src='https://www.latinamericancargo.com/wp-content/themes/lac_tema_2023/assets/res/img/other/placeholder_img.jpg'" runat="server" />
                                </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                            </div>
               
                </div>
                <div class="row agregar-articulo__btn">
                    <div class="col">
                    <div class="mb-3">
                        <asp:Button Text="Agregar" CssClass="btn btn-primary py-2 px-4 rounded-1" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />
                        <a href="ListaArticulos.aspx">Cancelar</a>
                    </div>
                    </div>
                </div>
                <%if (Request.QueryString["id"] != null){
%>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="row agregar-articulo__contenedor-eliminar d-flex flex-row align-items-center">
                                <div class="col-4">
                                    <div class="mb-2">
                                        <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-outline-danger py-2 px-4 agregar-articulo__btnEliminar" OnClick="btnEliminar_Click" runat="server" />
                                    </div>
                                </div>
                                <%if (ActivarEliminacion)
                                    { %>
                                        <div class="agregar-articulo__confirmar-eliminacion py-1 d-flex flex-column text-center">
                                            ¿Seguro que quiere eliminar este artículo?
                                            <div>
                                                <asp:Button ID="btnSiEliminar" Text="Si" CssClass="btn-outline-dark" OnClick="btnSiEliminar_Click" runat="server" style="padding-inline:12px" /> <asp:Button ID="btnCancelarEliminar" Text="No" CssClass=" btn-outline-dark px-2" OnClick="btnCancelarEliminar_Click" runat="server" />
                                            </div>
                                        </div>
                                   <% } %>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    
                <% } %>
            </div>
       </div>


</asp:Content>
