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
        public bool ActivarEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

			try
			{
				if(!IsPostBack)
				{
					lblId.Visible = false;
					txtId.Visible = false;
					ActivarEliminacion = false;
					

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

					//Modificar articulo
					if (Request.QueryString["id"] != null)
					{
						lblId.Visible = true;
						txtId.Visible = true;
						txtId.Enabled = false;
                        btnAgregar.Text = "Modificar";
						h1AgregarArticulo.InnerText = "Modificar articulo";
                        string id = Request.QueryString["id"];

						//trae el articulo a modificar
						ArticuloDatos articuloDatos = new ArticuloDatos();
						List<Articulo> articulo = articuloDatos.Listar(id);
						
						//carga txt

						txtId.Text = id;
						txtCodigoArticulo.Text = articulo[0].CodigoArticulo;
						txtNombre.Text = articulo[0].Nombre;
						txtDescripcion.Text = articulo[0].Descripcion;
						txtPrecio.Text = articulo[0].Precio.ToString();
						txtUrlImagen.Text = articulo[0].ImagenUrl;
						ddlMarca.SelectedValue = articulo[0].Marca.Id.ToString();
						ddlCategoria.SelectedValue = articulo[0].Categoria.Id.ToString();
						txtUrlImagen_TextChanged(sender, e);

                    }


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


				//modifica
				if (Request.QueryString["id"] != null)
				{
					nuevoArticulo.Id = int.Parse(Request.QueryString["id"].ToString());
					articuloDatos.Modificar(nuevoArticulo);
					Response.Redirect("ListaArticulos.aspx", false);
				} else
				{
					articuloDatos.Agregar(nuevoArticulo);
                    Response.Redirect("ListaArticulos.aspx", false);
                }


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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
			ActivarEliminacion = true;
			btnEliminar.Visible = false;
        }

        protected void btnCancelarEliminar_Click(object sender, EventArgs e)
        {
			ActivarEliminacion = false;
			btnEliminar.Visible = true;
        }

        protected void btnSiEliminar_Click(object sender, EventArgs e)
        {
			try
			{
				int id = int.Parse(Request.QueryString["id"].ToString());

				ArticuloDatos articuloDatos = new ArticuloDatos();
				articuloDatos.Borrar(id);

				Response.Redirect("ListaArticulos.aspx", false);

			}
			catch (Exception ex)
			{

				Session.Add("error", ex);
				Response.Redirect("Error.aspx", false);
			}
        }
    }
}