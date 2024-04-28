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


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ArticuloDatos datos = new ArticuloDatos();
                    repRepiter.DataSource = datos.Listar();
                    repRepiter.DataBind();

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //protected void btnDetalles_Click(object sender, EventArgs e)
        //{
        //    //string id = ((Button)sender).CommandArgument;
        //    //Response.Redirect("Favoritos.aspx?id=" + id, false);
        //}
    }
}