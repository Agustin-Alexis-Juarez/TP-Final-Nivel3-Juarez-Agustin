using Datos;
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
            try
            {
                if(!IsPostBack)
                {


                    if ((Usuario)Session["usuario"] != null)
                    {
                        Usuario usuario = (Usuario)Session["usuario"];

                        txtCorreo.Text = usuario.Email;
                        txtCorreo.Enabled = false;
                        txtContraseña.Text = usuario.Contraseña;
                        txtContraseña.Enabled = false;
                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;

                        if (!string.IsNullOrEmpty(usuario.UrlImagen))
                            imgImagen.ImageUrl = "~/Imagenes/Perfil/" + usuario.UrlImagen;
                    }
                
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx",false);
            }
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usuario"];
                UsuarioDatos datos = new UsuarioDatos();

                usuario.Nombre = txtNombre.Text;
                
                usuario.Apellido = txtApellido.Text;

                if (inputImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Imagenes/Perfil/"); 
                    inputImagen.PostedFile.SaveAs(ruta + "Perfil-" + usuario.Id + ".jpg"); 
                    usuario.UrlImagen = "Perfil-" + usuario.Id + ".jpg";

                    //leer imagen para cargarla en el img.
                    Image img = (Image)Master.FindControl("imgAvatar"); 
                    img.ImageUrl = "~/Imagenes/Perfil/" + usuario.UrlImagen;
                }

                datos.actualizar(usuario);
                Response.Redirect("Perfil.aspx", false);
               
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

    }
}