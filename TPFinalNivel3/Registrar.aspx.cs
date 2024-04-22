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
    public partial class Registrar : System.Web.UI.Page
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

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioDatos usuarioDatos = new UsuarioDatos();
                Usuario usuarioNuevo = new Usuario();

                usuarioNuevo.Email = txtEmail.Text;
                usuarioNuevo.Contraseña = txtContraseña.Text;
                usuarioNuevo.Id = usuarioDatos.registrar(usuarioNuevo);
              
                Session.Add("usuario", usuarioNuevo);

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}