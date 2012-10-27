using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapidNote.Clases
{
    public class Bitacora : Entidad
    {
        private int idbitacora;
        private string accion;
        private DateTime fecha;
        private Usuario usuario;

        public int Idbitacora
        {
            get { return idbitacora; }
            set { idbitacora = value; }
        }


        public string Accion
        {
            get { return accion; }
            set { accion = value; }
        }


        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
    }
}