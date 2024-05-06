using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Dominio;

namespace TPFinalNivel3
{
    public partial class Default : System.Web.UI.Page
    {
        public bool MostrarDetalles { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!IsPostBack)
                {
                    MostrarDetalles = false;
                    ArticuloDatos datos = new ArticuloDatos();
                   
                   
                    repRepiter.DataSource = datos.Listar();
                    repRepiter.DataBind();

                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnDetalles_Click(object sender, EventArgs e)
        {

                string id = ((Button)sender).CommandArgument;
                ArticuloDatos datos = new ArticuloDatos();
                List<Articulo> articulo = new List<Articulo>();
                try
                {

                    if (Seguridad.sesionActiva(Session["usuario"]))
                    {
                        FavoritoDatos favDatos = new FavoritoDatos();
                        List<Favorito> fav = new List<Favorito>();
                        fav = favDatos.ObtenerFavoritos(((Usuario)Session["usuario"]).Id.ToString(), id);

                        if (fav.Count != 0)
                        {
                            btnAñadirFavorito.Text = "Quitar favorito";
                            btnAñadirFavorito.CssClass.Remove(0);
                            btnAñadirFavorito.CssClass = "btn btn-dark w-100 mt-3";
                        }
                        else
                        {
                            btnAñadirFavorito.Text = "Añadir a favoritos";
                            btnAñadirFavorito.CssClass.Remove(0);
                            btnAñadirFavorito.CssClass = "btn btn-danger w-100 mt-3";
                    }
                        
                    }

                    articulo = datos.Listar(id);
                    Session.Add("idAñadirFav", id);
                    if (!string.IsNullOrEmpty(articulo[0].ImagenUrl))
                        imagenDetalles.ImageUrl = articulo[0].ImagenUrl;
                    else
                        imagenDetalles.ImageUrl = "imagen_rota";
                    lblTitulo.Text = articulo[0].Nombre;
                    lblMarca.Text = articulo[0].Marca.Descripcion;
                    lblPrecio.Text = "Precio: $" + articulo[0].Precio.ToString();
                    lblDescripcion.Text = articulo[0].Descripcion;

                    MostrarDetalles = true;
                }
                catch (Exception ex)
                {

                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            
            

        }

        protected void btnAñadirFavorito_Click(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Favorito favorito = new Favorito();
                FavoritoDatos datos = new FavoritoDatos();
                try
                {
                        favorito.IdArticulo = int.Parse(Session["idAñadirFav"].ToString());
                        favorito.IdUser = ((Usuario)Session["usuario"]).Id;

                    if (btnAñadirFavorito.Text == "Quitar favorito")
                        datos.BorrarFavorito(favorito);
                    else
                        datos.AgregarFavorito(favorito);
                    


                   
                }
                catch (Exception ex)
                {

                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void btnCerrarDetalles_Click(object sender, EventArgs e)
        {
            MostrarDetalles = false;
        }
    }
}