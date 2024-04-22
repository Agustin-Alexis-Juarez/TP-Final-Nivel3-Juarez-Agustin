using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
namespace TPFinalNivel3
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public bool SesionIniciada { get; set; }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login || Page is Default || Page is Registrar || Page is Error))
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);

            }

            if((Page is ListaArticulos || Page is AgregarArticulo))
            {
                if (!Seguridad.esAdmin(Session["usuario"]))
                {
                    Session.Add("error", "No tienes acceso a esta Página.");
                    Response.Redirect("Error.aspx", false);
                }
            }

            if (Seguridad.sesionActiva(Session["usuario"]))
            {
                Usuario usuario = (Usuario)Session["usuario"];
                SesionIniciada = true;
                if (usuario.Nombre != null && usuario.Nombre != "")
                {
                    lblNombre.Text = usuario.Nombre + " " + usuario.Apellido;
                    lblNombreMovil.Text = lblNombre.Text;
                }
                else{
                    lblNombre.Text = "Anónimo ";
                    lblNombreMovil.Text = "Anónimo";
                }
                if (usuario.UrlImagen != null)
                {
                    imgAvatarMovil.ImageUrl = "~/Imagenes/Perfil/" + usuario.UrlImagen;
                    imgAvatar.ImageUrl = "~/Imagenes/Perfil/" + usuario.UrlImagen;

                }
            }



        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Default.aspx",false);
        }
    }
}