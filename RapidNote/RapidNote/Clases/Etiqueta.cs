using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapidNote.Clases
{
    public class Etiqueta : Entidad
    {
        private int idetiqueta;
        private string nombre;
        private List<Nota> listaNota;

        public int Idetiqueta
        {
            get { return idetiqueta; }
            set { idetiqueta = value; }
        }


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public List<Nota> ListaNota
        {
            get { return listaNota; }
            set { listaNota = value; }
        }
    }
}