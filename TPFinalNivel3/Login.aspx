<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row row-login d-flex align-items-center justify-content-center">
            <div class="tarjeta-login py-3 d-flex flex-column align-items-center rounded-3">

                <%if (Request.QueryString["b"] == "1")
                    { %>
                        <div class="mb-auto">
                            <h1 class="login-titulo">Iniciar Sesión</h1>
                        </div>
                        <div class="mb-4">
                            <label for="">Correo electrónico</label>
                            <input class="form-control txtLargo">
                        </div>
                        <div class="mb-auto">
                            <label for="">Contraseña</label>
                            <input class="form-control txtLargo">
                        </div>

                        <div class="mb-auto">
                            <button class="boton-login btn btn-success">Ingresar</button>
                        </div>

            <%}%>
           
               <% else { %>
                    
                        <div class="mb-auto">
                            <h1 class="login-titulo">Registrarse</h1>
                        </div>
                        <div class="mb-4">
                            <label for="">Correo Electrónico</label>
                            <input class="form-control txtLargo">
                        </div>
                        <div class="mb-auto">
                            <label for="">Contraseña</label>
                            <input class="form-control txtLargo" >
                        </div>

                        <div class="mb-auto">
                            <button class="boton-login btn btn-primary">Registrar</button>
                        </div>
                
               <% } %>

            </div>
        </div>



</asp:Content>
