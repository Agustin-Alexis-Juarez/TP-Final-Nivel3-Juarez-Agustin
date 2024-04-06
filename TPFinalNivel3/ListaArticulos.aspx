<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="TPFinalNivel3.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="separador"></div>


    <div class="row">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                     <div class="d-flex  align-items-center justify-content-center" style="max-width:900px; gap: 10px; padding: 10px; margin-left:10px;">
                        <div class="col-6">
                            <div class="mb-3">
                                <asp:TextBox ID="txtFiltroRapido" AutoPostBack="true" OnTextChanged="txtFiltroRapido_TextChanged" placeholder="Buscar" CssClass="form-control" runat="server" />
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="mb-3">
                                <asp:CheckBox Text="" ID="chkFiltroAvanzado" AutoPostBack="true" runat="server" />
                                <label>Filtro avanzado</label>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>

    <div class="row">
         <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <%if (chkFiltroAvanzado.Checked)
                    { %>

                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <label>Campo</label>
                            <asp:DropDownList ID="ddlCampo" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" CssClass="form-select" runat="server">
                                <asp:ListItem Text="Nombre" />
                                <asp:ListItem Text="Precio" />
                                <asp:ListItem Text="Codigo de Articulo" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <label>Marca</label>
                            <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server">
                                <asp:ListItem Text="Todas" />
                            </asp:DropDownList>
                        </div>
                    </div>
                     <div class="col-3">
                        <div class="mb-3">
                            <label>Categoria</label>
                            <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server">
                                <asp:ListItem Text="Todas" />
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-3">
                        <div class="mb-3">
                            <label>Criterio</label>
                            <asp:DropDownList ID="ddlCriterio" CssClass="form-select" runat="server">
                                <asp:ListItem Text="Contiene" />
                                <asp:ListItem Text="Comienza con" />
                                <asp:ListItem Text="Termina con" />
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-3">
                        <div class="mb-3">
                            <asp:Button Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary px-4" ID="btnBuscar" placeholder="Buscar" runat="server" />
                        </div>
                    </div>
                </div>
                <% } %>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <%--  <div class="row">
         <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label>Filtro</label>
                        <asp:TextBox ID="txtFiltroRapido" AutoPostBack="true" OnTextChanged="txtFiltroRapido_TextChanged" CssClass="form-control" runat="server" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="col-6" style="display: flex; flex-direction: column;">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:CheckBox Text="" ID="chkFiltroAvanzado" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" AutoPostBack="true" runat="server" />
                        <label>Filtro avanzado</label>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>--%>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <asp:GridView ID="dgvListaArticulos" DataKeyNames="Id" AutoGenerateColumns="false"
                    CssClass="table table-bordered table-striped shadow-sm" Style="text-align: center;"
                    OnSelectedIndexChanged="dgvListaArticulos_SelectedIndexChanged"
                    AllowPaging="true" OnPageIndexChanging="dgvListaArticulos_PageIndexChanging" PageSize="6" runat="server">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                        <asp:CommandField HeaderText="Modificar" SelectText="✍️" ShowSelectButton="true" />
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:Button Text="Agregar" CssClass="btn btn-primary px-4" ID="btnAgregar" OnClick="btnAgregar_Click" runat="server" />


</asp:Content>
