<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinalNivel3.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="perfil__separador"></div>

    <div class="perfil__contenedor py-4 px-4">
                <div class="perfil__titulo">
                    <h1>Mi Perfil</h1>
                </div>
                <div class="perfil__datos d-flex container-fluid flex-column">
                    <div class="row">
                        <div class="col">

                            <div class="mb-3">
                                <label for="">Correo electrónico</label>
                                <asp:TextBox CssClass="form-control" ID="txtCorreo" runat="server" />
                            </div>
                            <div class="mb-3">
                                <label for="">Contraseña</label>
                                <asp:TextBox CssClass="form-control" ID="txtContraseña" runat="server" />
                            </div>
                            <div class="mb-3">
                                <label for="">Nombre</label>
                                 <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server" />
                            </div>
                            <div class="mb-3">
                                <label for="">Apellido</label>
                                 <asp:TextBox CssClass="form-control" ID="txtApellido" runat="server" />
                            </div>

                        </div>
                        <div class="col">
                            <div class="mb-3">
                                <label for="">Imagen</label>
                                <input type="file" id="inputImagen" class="form-control" style="max-width: 400px;" runat="server"  />
                            </div>
                            <div class="d-flex mb-3">
                            <asp:Image  id="imgImagen" class="perfil__imagen-perfil mb-3" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mb-3">
                            <button class="btn btn-primary py-2 px-4 rounded-1">Guardar</button>
                            <a href="Default.aspx">Cancelar</a>
                        </div>
                    </div>
                </div>
            </div>
    

</asp:Content>
