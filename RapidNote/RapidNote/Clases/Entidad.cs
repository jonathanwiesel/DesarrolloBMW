using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapidNote.Clases
{
    public abstract class Entidad
    {
        private String estado;

        public String Estado
        {
            get { return estado; }
            set { estado = value; }
        }
    }
}