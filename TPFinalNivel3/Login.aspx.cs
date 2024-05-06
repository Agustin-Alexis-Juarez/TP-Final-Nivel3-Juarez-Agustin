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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.sesionActiva((Usuario)Session["usuario"]))
                {
                    Response.Redirect("./", false);
                }

            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            lblNoExiste.Text = "";
            UsuarioDatos datos = new UsuarioDatos();
            Usuario usuario = new Usuario();
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                    usuario.Email = txtCorreo.Text;
                    usuario.Contraseña = txtContraseña.Text;
                if (datos.login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    lblNoExiste.Text = "Correo Electrónico o contraseña incorrectos.";
                    return;
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}