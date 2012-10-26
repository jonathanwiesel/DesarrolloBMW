using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;

namespace RapidNote.Logica.Comandos
{
    public abstract class Comando<T>
    {
        protected Entidad entidad;

        public Entidad Entidad
        {
            get { return entidad; }
            set { entidad = value; }
        }

        
        public Comando()
        {}

        
        public Comando(Entidad entidad)
        {}

        public abstract T Ejecutar();
    }
}