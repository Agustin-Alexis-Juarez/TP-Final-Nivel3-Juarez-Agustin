<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="row row-login d-flex align-items-center justify-content-center">
        <div class="tarjeta-login py-3 d-flex flex-column align-items-center rounded-3">

            <div class="mb-auto">
                <h1 class="login-titulo">Iniciar Sesión</h1>
            </div>
             
            <div class="mb-4">
                <label for="">Correo electrónico</label>
                <asp:TextBox CssClass="form-control txtLargo" ID="txtCorreo" runat="server" />
                <asp:RequiredFieldValidator ErrorMessage="El correo electrónico es requerido." ControlToValidate="txtCorreo" ForeColor="Red" runat="server" Display="Dynamic" />
                <asp:RegularExpressionValidator ErrorMessage="El correo electrónico debe ser formato email" ControlToValidate="txtCorreo" ValidationExpression="^([\w-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([\w-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$" ForeColor="Red" runat="server" Display="Dynamic" />
            </div>
            <div class="mb-auto">
                <label for="">Contraseña</label>
                <asp:TextBox CssClass="form-control txtLargo" ID="txtContraseña" runat="server" TextMode="Password" />
                <asp:RequiredFieldValidator ErrorMessage="La contraseña es requerida." ControlToValidate="txtContraseña" ForeColor="Red" runat="server" Display="Dynamic" />
                 <asp:Label Text="" id="lblNoExiste" ForeColor="red" runat="server" />
            </div>

            <div class="mb-auto">
                <asp:Button CssClass="boton-login btn btn-success" ID="btnIngresar" OnClick="btnIngresar_Click" Text="Ingresar" runat="server" />
            </div>
        </div>
    </div>



</asp:Content>
