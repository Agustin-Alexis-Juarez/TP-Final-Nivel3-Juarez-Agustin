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
				ArticuloDatos lista = new ArticuloDatos();
				dgvListaArticulos.DataSource = lista.Listar();
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
    }
}