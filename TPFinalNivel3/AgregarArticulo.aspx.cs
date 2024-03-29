using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Datos;
namespace TPFinalNivel3
{
    public partial class AgregarArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			lblId.Visible = false;
			txtId.Visible = false;

			try
			{
				if(!IsPostBack)
				{
					//carga de los dropdowns

					MarcaDatos marcaDatos = new MarcaDatos();
					List<Marca> listaMarcas = marcaDatos.Listar();

					CategoriaDatos categoriaDatos = new CategoriaDatos();
					List<Categoria> listaCategoria = categoriaDatos.Listar();

					ddlMarca.DataSource = listaMarcas;
					ddlMarca.DataValueField = "Id";
					ddlMarca.DataTextField = "Descripcion";
					ddlMarca.DataBind();
					
					ddlCategoria.DataSource = listaCategoria;
					ddlCategoria.DataValueField= "Id";
					ddlCategoria.DataTextField = "Descripcion";
					ddlCategoria.DataBind();

				}
			}
			catch (Exception ex)
			{

                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }


        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

			try
			{
				//agregar articulo nuevo

				Articulo nuevoArticulo = new Articulo();
				ArticuloDatos articuloDatos = new ArticuloDatos();

				nuevoArticulo.CodigoArticulo = txtCodigoArticulo.Text;
				nuevoArticulo.Nombre = txtNombre.Text;
				nuevoArticulo.Descripcion = txtDescripcion.Text;
				nuevoArticulo.Precio = decimal.Parse(txtPrecio.Text);
				nuevoArticulo.ImagenUrl = txtUrlImagen.Text;

				nuevoArticulo.Marca = new Marca();
				nuevoArticulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

				nuevoArticulo.Categoria = new Categoria();
				nuevoArticulo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);


				

				articuloDatos.Agregar(nuevoArticulo);

			}
			catch (Exception ex)
			{

				Session.Add("error", ex);
				Response.Redirect("Error.aspx", false);
			}
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
			imgArticulo.ImageUrl = txtUrlImagen.Text;
        }
    }
}