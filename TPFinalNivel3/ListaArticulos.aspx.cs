using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.Linq.Expressions;

namespace TPFinalNivel3
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
      

        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                
                
                if(!IsPostBack)
                {
                   //carga la lista normal
				    ArticuloDatos lista = new ArticuloDatos();
                    Session.Add("listaArticulos", lista.Listar());
               
                    //carga los ddl marca y categoria para el filtro avanzado.
                    MarcaDatos marcaDatos = new MarcaDatos();
                    CategoriaDatos categoriaDatos = new CategoriaDatos();
                    ddlMarca.DataSource = marcaDatos.Listar();
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();
                    ddlMarca.Items.Insert(0, "Todas");
                    

                    ddlCategoria.DataSource = categoriaDatos.Listar();
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Insert(0,"Todas");
                    
                    
			    }
               
				    dgvListaArticulos.DataSource = Session["listaArticulos"];
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

        protected void dgvListaArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Session["listaFiltradaAvanzada"] != null && chkFiltroAvanzado.Checked)
            {
                dgvListaArticulos.DataSource = Session["listaFiltradaAvanzada"];

            } else if (Session["listaFiltrada"] != null && !chkFiltroAvanzado.Checked && !string.IsNullOrEmpty(txtFiltro.Text))
            {
                dgvListaArticulos.DataSource = Session["listaFiltrada"];
            }
            dgvListaArticulos.PageIndex = e.NewPageIndex; 
            dgvListaArticulos.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
           
            List<Articulo> lista = (List<Articulo>)(Session["listaArticulos"]);
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));

            Session.Add("ListaFiltrada", listaFiltrada);
            dgvListaArticulos.DataSource = listaFiltrada;
            dgvListaArticulos.DataBind();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Enabled = true;
            txtFiltroAvanzado.Enabled = true;
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Igual a");

            } else if(ddlCampo.SelectedItem.ToString() == "Solo Marca/Categoria")
            {

                ddlCriterio.Enabled = false;
                txtFiltroAvanzado.Enabled = false;
                txtFiltroAvanzado.Text = "";
                ddlCriterio.Items.Clear();

            } else
            {
                ddlCriterio.Items.Clear();
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Empieza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> lista = (List<Articulo>)(Session["listaArticulos"]);
                List<Articulo> listaFiltrada = lista;

                string criterio, campo, filtro, categoria, marca;

                campo = ddlCampo.SelectedValue;
                criterio = ddlCriterio.SelectedValue;
                filtro = txtFiltroAvanzado.Text;
                categoria = ddlCategoria.SelectedValue;
                marca = ddlMarca.SelectedValue;
                
                if (campo == "Precio")
                {
                        if(string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                        {
                            Session.Remove("listaFiltradaAvanzada");
                            return;
                        }

                        ArticuloDatos articulos = new ArticuloDatos();
                        listaFiltrada = articulos.filtrar(campo, criterio, filtro);

                        if(marca != "Todas" && categoria != "Todas")
                        {
                             listaFiltrada = listaFiltrada.FindAll(x => x.Marca.Id == int.Parse(marca) && x.Categoria.Id == int.Parse(categoria));
                        } else if(marca == "Todas" && categoria != "Todas")
                        {
                            listaFiltrada = listaFiltrada.FindAll(x => x.Categoria.Id == int.Parse(categoria));
                        } else if(marca != "Todas" && categoria == "Todas")
                        {
                            listaFiltrada = listaFiltrada.FindAll(x => x.Marca.Id == int.Parse(marca));
                        }
                        

                }else if(campo == "Solo Marca/Categoria")
                {

                        if (marca != "Todas" && categoria != "Todas")
                        {
                            listaFiltrada = listaFiltrada.FindAll(x => x.Marca.Id == int.Parse(marca) && x.Categoria.Id == int.Parse(categoria));
                        }
                        else if (marca == "Todas" && categoria != "Todas")
                        {
                            listaFiltrada = listaFiltrada.FindAll(x => x.Categoria.Id == int.Parse(categoria));
                        }
                        else if (marca != "Todas" && categoria == "Todas")
                        {
                            listaFiltrada = listaFiltrada.FindAll(x => x.Marca.Id == int.Parse(marca));
                        }

                } else
                {
                        ArticuloDatos articulos = new ArticuloDatos();
                        listaFiltrada = articulos.filtrar(campo, criterio, filtro);

                        if (marca != "Todas" && categoria != "Todas")
                        {
                            listaFiltrada = listaFiltrada.FindAll(x => x.Marca.Id == int.Parse(marca) && x.Categoria.Id == int.Parse(categoria));
                        }
                        else if (marca == "Todas" && categoria != "Todas")
                        {
                            listaFiltrada = listaFiltrada.FindAll(x => x.Categoria.Id == int.Parse(categoria));
                        }
                        else if (marca != "Todas" && categoria == "Todas")
                        {
                            listaFiltrada = listaFiltrada.FindAll(x => x.Marca.Id == int.Parse(marca));
                        }
                }
                




                Session.Add("listaFiltradaAvanzada", listaFiltrada);
                dgvListaArticulos.DataSource = listaFiltrada;
                dgvListaArticulos.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiltroAvanzado.Checked)
            {
                txtFiltro.Text = "";
                Session.Remove("listaFiltrada");
            }
            else 
            {
                txtFiltroAvanzado.Text = "";
                Session.Remove("listaFiltradaAvanzada");
            }
        }
    }
}