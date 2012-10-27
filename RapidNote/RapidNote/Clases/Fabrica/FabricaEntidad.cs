using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapidNote.Clases.Fabrica
{
    public class FabricaEntidad
    {
        public static Entidad CrearUsuario() 
        {
            return new Usuario();
        }
    }
}