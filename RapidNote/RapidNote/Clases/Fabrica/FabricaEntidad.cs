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

        public static Entidad CrearNota()
        {
            return new Nota();
        }

        public static Entidad CrearLibreta() 
        {
            return new Libreta();
        }

        public static Libreta CrearLibretaNew()
        {
            return new Libreta();
        }

        public static Adjunto CrearAdjunto() 
        {
            return new Adjunto();
        }

        public static Etiqueta CrearEtiqueta() 
        {
            return new Etiqueta();
        }

    }
}