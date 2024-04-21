using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPFinalNivel3
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {


                if ((Usuario)Session["usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["usuario"];

                    txtCorreo.Text = usuario.Email;
                    txtCorreo.ReadOnly = true;
                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;

                    if (!string.IsNullOrEmpty(usuario.UrlImagen))
                        imgImagen.ImageUrl = "~/Imagenes/Perfil" + usuario.UrlImagen;
                }
                
            }
            
        }
    }
}