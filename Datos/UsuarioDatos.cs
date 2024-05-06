using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using static System.Net.Mime.MediaTypeNames;

namespace Datos
{
    public class UsuarioDatos
    {
      
        public int registrar(Usuario nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into USERS (email, pass) output inserted.id values(@email,@pass)");
                datos.setearParametros("@email", nuevo.Email);
                datos.setearParametros("@pass", nuevo.Contraseña);
              
                return datos.ejecutarAccionScalar();
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
        public void actualizar(Usuario usuario)
        {
                AccesoDatos datos = new AccesoDatos();
            try
            {
              
                datos.setearConsulta("update USERS set urlImagenPerfil = @imagen, nombre = @nombre, apellido = @apellido where Id = @id");
                datos.setearParametros("@imagen", (object)usuario.UrlImagen ?? DBNull.Value);
                datos.setearParametros("@nombre", usuario.Nombre);
                datos.setearParametros("@apellido", usuario.Apellido);
                datos.setearParametros("@id", usuario.Id);
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
        public bool login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, email, pass, admin, urlImagenPerfil, nombre, apellido from USERS where email = @correo And pass = @contraseña");
                datos.setearParametros("@correo", usuario.Email);
                datos.setearParametros("@contraseña", usuario.Contraseña);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.Admin = (bool)datos.Lector["admin"];

                    if (!(datos.Lector["nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["nombre"];

                    if (!(datos.Lector["apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["apellido"];

                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        usuario.UrlImagen = (string)datos.Lector["urlImagenPerfil"];

                   
             
                    return true;
                }
                return false;
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
        public bool Existe(string email)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select email from USERS where email = @correo");
                datos.setearParametros("@correo", email);
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    return true;
                }

                return false;
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
