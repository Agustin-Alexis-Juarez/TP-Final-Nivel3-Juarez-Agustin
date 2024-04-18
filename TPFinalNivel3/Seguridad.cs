using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;
namespace TPFinalNivel3
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null && usuario.Id != 0)  //retorna true si la session esta activa sino retorna false
                return true;
            else
                return false;
        }

        public static bool esAdmin(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            return usuario != null ? usuario.Admin : false; //si usuario es diferente de null verifica si es admin y devuelve true sino false.
        }


    }
    
}