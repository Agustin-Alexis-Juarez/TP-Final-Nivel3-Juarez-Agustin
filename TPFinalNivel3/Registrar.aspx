<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="TPFinalNivel3.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row row-login d-flex align-items-center justify-content-center">
        <div class="tarjeta-login py-3 d-flex flex-column align-items-center rounded-3">
            <div class="mb-auto">
                <h1 class="login-titulo">Registrarse</h1>
            </div>
            <div class="mb-4">
                <label for="">Correo electrónico</label>
                <asp:TextBox CssClass="form-control txtLargo" ID="txtEmail" runat="server" />
            </div>
            <div class="mb-auto">
                <label for="">Contraseña</label>
                <asp:TextBox CssClass="form-control txtLargo" ID="txtContraseña" runat="server" />
            </div>

            <div class="mb-auto">
                <asp:Button CssClass="boton-login btn btn-success" ID="btnRegistrar" OnClick="btnRegistrar_Click" Text="Registrar" runat="server" />
            </div>
        </div>
    </div>



</asp:Content>
