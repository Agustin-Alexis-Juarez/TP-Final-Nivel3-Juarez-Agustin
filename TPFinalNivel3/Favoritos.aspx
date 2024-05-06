<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="TPFinalNivel3.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:ScriptManager runat="server" />

    <div class="separador"></div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
                     <%if (MostrarDetalles)
                         {%>
   
                            <div class="position-fixed fixed-top z-2 d-flex container">
                                <div class="row detalles__tarjeta perfil__contenedor position-relative overflow-auto py-4 px-4 ">
                    
                    
                                    <div class="z-3 d-flex flex-column overflow-auto">
                                        <asp:Button Text="X" CssClass="detalles__boton-cerrar px-3" ID="btnCerrarDetalles" OnClick="btnCerrarDetalles_Click" runat="server" />
                                        <div class="col d-flex justify-content-center">
                                            <asp:Image  ID="imagenDetalles" CssClass="img-detalles" onerror="this.onerror=null; this.src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7Np7JL_kcrPvGlF7knXZqPyrEuH3jpjg5-Xb9X51vMQ&s'" runat="server" />
                                        </div>
                                        <div class="col d-flex flex-column">
                                            <asp:Label ID="lblTitulo" CssClass="text-break border-top mt-1 fs-2" Text="" runat="server" />
                                            <asp:Label ID="lblMarca" Text="" CssClass=" detalles__marca" runat="server" />
                                            <asp:Label Text="" ID="lblPrecio" CssClass="fs-4" runat="server" />
                                            <p class="mb-0">Descripcion:</p>
                                            <div class="mb-auto text-break overflow-auto" style="max-height:114px" >
                                                <asp:Label ID="lblDescripcion" Text="" runat="server" />
                                            </div>
                                            <asp:Button Text="Añadir a favoritos" CssClass="btn btn-danger w-100 mt-3" ID="btnAñadirFavorito" OnClick="btnAñadirFavorito_Click" runat="server" />
                                        </div>
                                    </div>
                            

                               </div>
                          </div>
                                    <div class=" position-absolute z-1">
                                        <div class="offcanvas-backdrop fade show"></div>
                                    </div>
                    <%}%>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <h1 runat="server" id="h1Fav">Favoritos</h1>
    <hr />
    <div class="row row-cols-lg-3 row-cols-sm-1 row-cols-md-2 py-4" style="max-width: 959.988px; margin: 0 auto;">

        <asp:Repeater ID="repRepiter" runat="server">
            <ItemTemplate>
                <div class="col mb-4">
                    <div class="card  sombra-card h-100" style="width: 18rem; margin: 0 auto;">

                        <img id="imagen" src="<%#Eval("ImagenUrl") %>" alt="<%#Eval("Nombre") %>" onerror="this.onerror=null; this.src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7Np7JL_kcrPvGlF7knXZqPyrEuH3jpjg5-Xb9X51vMQ&s'" class="card-img-top imagen-card" />

                        <div class="card-body">
                            <h3 id="nombre" class="card-title"><%#Eval("Nombre") %></h3>
                            <div class="cont-precio mb-2">
                                <h5 id="precio" class="precio"><%#Eval("Precio","{0:F2}") %></h5>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Button Text="Ver detalles" ID="btnDetalles" CssClass="btn-detalles" OnClick="btnDetalles_Click" CommandArgument='<%#Eval("Id") %>' CommandName="ArticuloId" runat="server" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>


            </ItemTemplate>
        </asp:Repeater>
    </div>

   

</asp:Content>
