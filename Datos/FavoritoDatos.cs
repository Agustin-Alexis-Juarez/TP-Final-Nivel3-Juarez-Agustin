using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class FavoritoDatos
    {
       public List<Favorito> ObtenerFavoritos(string iduser, string idArt = "")
        {
            List<Favorito> lista = new List<Favorito>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select IdArticulo from FAVORITOS where IdUser = " + iduser;

                if(idArt != "")
                   consulta += "and IdArticulo = " + idArt; 
                
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Favorito favorito = new Favorito();

                    favorito.IdArticulo = (int)datos.Lector["IdArticulo"];
                    lista.Add(favorito);
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

        public void AgregarFavorito(Favorito fav)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearConsulta("Insert into FAVORITOS (IdUser, IdArticulo) values(@idUsuario, @idArticulo)");
                datos.setearParametros("@idUsuario",fav.IdUser);
                datos.setearParametros("@idArticulo",fav.IdArticulo);
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

        public void BorrarFavorito(Favorito fav)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("delete from FAVORITOS where IdUser = @idUser and IdArticulo = @idArt");
                datos.setearParametros("@idArt", fav.IdArticulo);
                datos.setearParametros("@idUser", fav.IdUser);
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
    }
}
