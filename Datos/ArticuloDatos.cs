using Dominio;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Datos
{
    public class ArticuloDatos
    {
        public List<Articulo> Listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select A.Id,Codigo, Nombre, A.Descripcion, M.Descripcion Marca, M.Id idmarca, C.Id idcat, C.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS A, CATEGORIAS C, MARCAS M where IdMarca = M.Id and IdCategoria = C.Id ";
                if(id != "")
                {
                    consulta += "and A.Id = " + id;
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();

                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.CodigoArticulo = (string)datos.Lector["Codigo"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];

                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)datos.Lector["idmarca"];
                    articulo.Marca.Descripcion = (string)datos.Lector["Marca"];

                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)datos.Lector["idcat"];
                    articulo.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    articulo.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(articulo);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void Agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values(@codigo,@nombre,@descripcion,@marca,@categoria,@imagen,@precio)");
                datos.setearParametros("@marca", articulo.Marca.Id);
                datos.setearParametros("@codigo", articulo.CodigoArticulo);
                datos.setearParametros("@nombre", articulo.Nombre);
                datos.setearParametros("@descripcion", articulo.Descripcion);
                datos.setearParametros("@categoria", articulo.Categoria.Id);
                datos.setearParametros("@imagen", articulo.ImagenUrl);
                datos.setearParametros("@precio", articulo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @marca, IdCategoria = @categoria, ImagenUrl = @imagen, Precio = @precio where Id = @id");
                datos.setearParametros("@id", articulo.Id);
                datos.setearParametros("@codigo", articulo.CodigoArticulo);
                datos.setearParametros("@nombre", articulo.Nombre);
                datos.setearParametros("@descripcion", articulo.Descripcion);
                datos.setearParametros("@categoria", articulo.Categoria.Id);
                datos.setearParametros("@marca", articulo.Marca.Id);
                datos.setearParametros("@imagen", articulo.ImagenUrl);
                datos.setearParametros("@precio", articulo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Borrar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List <Articulo> filtrar(string campo, string criterio, string filtro)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();

            try
            {

                string consulta = "select A.Id , Codigo, Nombre, Precio, A.Descripcion, ImagenUrl, IdMarca, M.Descripcion marca,IdCategoria, C.Descripcion categoria from ARTICULOS A, MARCAS M, CATEGORIAS C where IdMarca = M.Id and IdCategoria = C.Id and ";

                if (campo == "Precio")
                {
                    switch (criterio) 
                    {
                        case "Mayor a": consulta += "A.Precio > " + filtro; break;
                        case "Menor a": consulta += "A.Precio < " + filtro; break;
                        case "Igual a": consulta += "A.Precio = " + filtro; break;
                    }
                }else if(campo == "Nombre")
                {
                    switch(criterio)
                    {
                        case "Comienza con": consulta += "A.Nombre like '" + filtro + "%' "; break;
                        case "Termina con": consulta += "A.Nombre like '%" + filtro + "' "; break;
                        default: consulta += "A.Nombre like '%" + filtro + "%' "; break;
                    }
                }else if (campo == "Codigo de Articulo")
                {
                    switch(criterio)
                    {
                        case "Comienza con": consulta += "A.Codigo like '" + filtro + "%' "; break;
                        case "Termina con": consulta += "A.Codigo like '%" + filtro + "' "; break;
                        default: consulta += "A.Codigo like '%" + filtro + "%' "; break;
                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.CodigoArticulo = (string)datos.Lector["Codigo"];
                    articulo.Precio = (decimal)datos.Lector["Precio"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    articulo.ImagenUrl = (string)datos.Lector["ImagenUrl"];


                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Marca = new Marca();
                    articulo.Marca.Id = (int)datos.Lector["IdMarca"];
                    articulo.Marca.Descripcion = (string)datos.Lector["marca"];
                    articulo.Categoria = new Categoria();
                    articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)datos.Lector["categoria"];

                    lista.Add(articulo);

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }
}
