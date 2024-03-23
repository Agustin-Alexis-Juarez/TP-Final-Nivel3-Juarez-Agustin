<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <div class="separador"></div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row d-flex justify-content-center">
                <div class="d-flex contenedor-filtro-rapido align-items-center justify-content-center" style="width:920px; border:1px solid #ccc; gap:10px; padding:10px;">
                    <div class="col-4">
                        <asp:TextBox ID="txtFiltro" CssClass="form-control" placeholder="Buscar" AutoPostBack="true"  runat="server" />
                    </div>
                    <div class="col-4">
                        <asp:CheckBox Text="" ID="chkFiltroAvanzado" AutoPostBack="true" runat="server" />
                        <label>Filtro Avanzado</label>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

     <div class="row row-cols-lg-3 row-cols-sm-1 row-cols-md-2 py-4" style="max-width: 959.988px; margin: 0 auto;">
            <asp:Repeater ID="repRepiter" runat="server">
                <ItemTemplate>
                    <div class="col mb-4">
                        <div class="card sombra-card h-100" style="width: 18rem; margin: 0 auto;">
                            <img class="card-img-top imagen-card" src="<%#Eval("ImagenUrl") %>" alt="<%#Eval("Nombre") %>" />
                            <div class="card-body">
                                <h3 class="card-title"><%#Eval("Nombre") %></h3>
                                <div class="cont-precio mb-2">
                                    <h5 class="precio"><%#Eval("Precio") %></h5>
                                </div>
                                <asp:Button ID="btnDetalles" CssClass="btn-detalles" Text="Ver Detalles" runat="server" />
                           </div>
                       </div>
                   </div>
               </ItemTemplate>
           </asp:Repeater>
     </div>


</asp:Content>
