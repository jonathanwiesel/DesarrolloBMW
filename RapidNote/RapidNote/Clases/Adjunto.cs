using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapidNote.Clases
{
    public class Adjunto : Entidad
    {
        private int idadjunto;
        private List<Nota> listaNota;
        private string titulo;
        private string urlarchivo;

        public int Idadjunto
        {
            get { return idadjunto; }
            set { idadjunto = value; }
        }


        public List<Nota> ListaNota
        {
            get { return listaNota; }
            set { listaNota = value; }
        }


        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }


        public string Urlarchivo
        {
            get { return urlarchivo; }
            set { urlarchivo = value; }
        }

        public override String ToString()
        {
            String resultado = "";

            resultado += "Idadjunto: " + this.idadjunto + " ";
            resultado += "titulo: " + this.titulo + " ";
            resultado += "urlArchivo: " + this.urlarchivo + " ";

            return resultado;
        }
    }
}