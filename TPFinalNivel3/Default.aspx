<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <div class="separador"></div>

   

     <div class="row row-cols-lg-3 row-cols-sm-1 row-cols-md-2 py-4" style="max-width: 959.988px; margin: 0 auto;">

            <asp:Repeater ID="repRepiter" runat="server">
                <ItemTemplate>
                    <div class="col mb-4">
                        <div class="card sombra-card h-100" style="width: 18rem; margin: 0 auto;">
                            <img src="<%#Eval("ImagenUrl") %>" alt="<%#Eval("Nombre") %>" onerror="this.onerror=null; this.src='https://www.sennheiser.com/images/placeholder.raw.svg'" class="card-img-top imagen-card" />
                            <div class="card-body">
                                <h3 class="card-title"><%#Eval("Nombre") %></h3>
                                <div class="cont-precio mb-2">
                                    <h5 class="precio"><%#Eval("Precio","{0:F2}") %></h5>
                                </div>
                                <button class="navbar-toggler shadow-none border-0"
                        type="button"
                        data-bs-toggle="offcanvas"
                        data-bs-target="#offcanvasNavbar"
                        aria-controls="offcanvasNavbar"
                        aria-label="Toggle navigation">
                        
                    </button>
                           </div>
                       </div>
                   </div>
               </ItemTemplate>
           </asp:Repeater>
     </div>

  <!--Sidebar-->
                    <div class="sidebar offcanvas offcanvas-start text-bg-dark"
                        tabindex="-1" id="offcanvasNavbar"
                        aria-labelledby="offcanvasNavbarLabel">

                        <!--Sidebar Header-->
                        <div class="offcanvas-header border-bottom">
                            <%if (false)
                                {
                            %>

                            <h5 class="offcanvas-title" id="offcanvasNavbarLabel">
                                <asp:Image CssClass="imagen-perfil-default" ID="imgAvatarMovil" ImageUrl="https://cdn-icons-png.flaticon.com/512/1077/1077114.png" runat="server" />
                                <asp:Label Text="" ID="lblNombreMovil" runat="server" />
                            </h5>
                            <%}
                            else
                            {%>

                            <h5 class="offcanvas-title"></h5>

                            <% }%>
                            <button
                                type="button"
                                class="btn-close btn-close-white shadow-none"
                                data-bs-dismiss="offcanvas"
                                aria-label="Close">
                            </button>
                        </div>

                        <!--Sidebar Body-->
                        <div class="offcanvas-body d-flex flex-column justify-content-between flex-lg-row">
                            <ul class="navbar-nav justify-content-center p-1 align-items-center">
                                <li class="nav-item home mx-2">
                                    <a class="nav-link" aria-current="page" href="Default.aspx">Home</a>
                                </li>
                                <li class="nav-item perfil mx-2">
                                    <a class="nav-link" aria-current="page" href="Perfil.aspx">Mi Perfil</a>
                                </li>
                                <li class="nav-item Favoritos mx-2">
                                    <a class="nav-link" aria-current="page" href="Favoritos.aspx">Favoritos</a>
                                </li>
                                <%if (false)
                                    { %>
                                             <li class="nav-item lista mx-2">
                                                <a class="nav-link " aria-current="page" href="ListaArticulos.aspx">Lista Artículos</a>
                                            </li>
                                   <% } %>
                            </ul>




                            <%if (true)
                                {%>

                            <div class="d-flex justify-content-center flex-column flex-lg-row align-items-center gap-2">
                                <asp:Button Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" CssClass="btnCerrarSesion btn btn-danger" runat="server" />
                                <div class="dropdown">
                                    <button class="boton-foto d-flex justify-content-center align-items-center gab-2 dropdown-toggle" role="button" data-bs-toggle="dropdown" aria-expanded="false" style="margin-right: 60px;">
                                        <asp:Label Text="" ID="lblNombre" CssClass="nombre" runat="server" />
                                      
                                        <asp:Image ID="imgAvatar" CssClass="imagen-perfil-default" ImageUrl="https://cdn-icons-png.flaticon.com/512/1077/1077114.png" runat="server" />
                                       
                                    </button>
                                    <ul class="dropdown-menu dropdown-menu-dark">
                                        <li><a class="dropdown-item" href="Perfil.aspx">Perfil</a></li>
                                        <li><a class="dropdown-item" href="#">Favoritos</a></li>
                                         <%if (false)
                                           { %>
                                               <li><a class="dropdown-item" href="ListaArticulos.aspx">Lista de articulos</a></li>
                                         <%} %>
                                      
                                        <li>
                                            <hr class="dropdown-divider">
                                        </li>
                                        <li><a class="dropdown-item" href="#"><i class="fa-solid fa-right-from-bracket"></i>
                                            <asp:Button Text="Cerrar Sesión" ID="btnCerrarSesion" CssClass="btn-cerrar-sesion" OnClick="btnCerrarSesion_Click" runat="server" /></a></li>
                                    </ul>
                                </div>

                            </div>
                            <%}
                                else
                                { %>
                            <div class="d-flex justify-content-center flex-column flex-lg-row align-items-center gap-2">
                                <a href="Login.aspx" class="iniciar-registrar text-white text-decoration-none px-3 py-2 bg-success rounded-5">Iniciar Sesión</a>
                                <a href="Registrar.aspx" class="iniciar-registrar text-white text-decoration-none px-4 py-2 bg-primary rounded-5">Registrarse</a>
                                <div class="dropdown">
                                    <button class="boton-foto d-flex justify-content-center align-items-center gab-2 dropdown-toggle" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                        <p class="nombre">Iniciar Sesión/Registrarse</p>

                                    </button>
                                    <ul class="dropdown-menu dropdown-menu-dark">
                                        <li><a class="dropdown-item" href="Login.aspx">Iniciar Sesión</a></li>
                                        <li><a class="dropdown-item" href="Registrar.aspx">Registrarse</a></li>
                                    </ul>
                                </div>
                            </div>
                            <%  } %>
                        </div> 
                    </div>

</asp:Content>
