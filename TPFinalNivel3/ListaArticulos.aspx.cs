using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace TPFinalNivel3
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                if(!IsPostBack)
                {
                   
				    ArticuloDatos lista = new ArticuloDatos();
                    Session.Add("listaArticulos", lista.Listar());

                    //cargamos los dll marca y categoria para el filtro avanzado.
                    MarcaDatos marcaDatos = new MarcaDatos();
                    
                    foreach (var item in marcaDatos.Listar())
                    {
                        ddlMarca.Items.Add(item.Descripcion);
                    }
                        ddlMarca.DataBind();

                    CategoriaDatos categoriaDatos = new CategoriaDatos();

                    foreach (var item in categoriaDatos.Listar())
                    {
                        ddlCategoria.Items.Add(item.Descripcion);
                    }
                        ddlCategoria.DataBind();

			    }
				    dgvListaArticulos.DataSource = Session["listaArticulos"];
				    dgvListaArticulos.DataBind();

                }
			catch (Exception ex)
			{

				throw ex;
			}
        }

        protected void dgvListaArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
			string id = dgvListaArticulos.SelectedValue.ToString();
			Response.Redirect("AgregarArticulo.aspx?id=" + id);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarArticulo.aspx");
        }

        protected void dgvListaArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListaArticulos.PageIndex = e.NewPageIndex; 
            dgvListaArticulos.DataBind();
        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}