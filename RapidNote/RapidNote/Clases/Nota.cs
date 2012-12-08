using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases.Fabrica;

namespace RapidNote.Clases
{
    public class Nota : Entidad
    {
        private int idnota;
        private string contenido;
        private DateTime fechacreacion;
        private DateTime fechamodificacion;
        private string titulo;
        private List<Adjunto> listaAdjunto;
        private List<Etiqueta> listaEtiqueta;
        private Libreta libreta;

        public Nota() 
        {
            //libreta = (FabricaEntidad.CrearLibreta() as Libreta);
            libreta = FabricaEntidad.CrearLibretaNew();
        }

        public string Contenido
        {
            get { return contenido; }
            set { contenido = value; }
        }


        public DateTime Fechacreacion
        {
            get { return fechacreacion; }
            set { fechacreacion = value; }
        }


        public DateTime Fechamodificacion
        {
            get { return fechamodificacion; }
            set { fechamodificacion = value; }
        }


        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }


        public List<Adjunto> ListaAdjunto
        {
            get { return listaAdjunto; }
            set { listaAdjunto = value; }
        }


        public List<Etiqueta> ListaEtiqueta
        {
            get { return listaEtiqueta; }
            set { listaEtiqueta = value; }
        }


        public Libreta Libreta
        {
            get { return libreta; }
            set { libreta = value; }
        }

        public int Idnota
        {
            get { return idnota; }
            set { idnota = value; }
        }

        public override String ToString()
        {
            String resultado = "";

            resultado += "Id: " + this.idnota + " ";
            resultado += "contenido: " + this.contenido + " ";
            resultado += "fechacreacion: " + this.fechacreacion + " ";
            resultado += "fechamodificacion: " + this.fechamodificacion + " ";
            resultado += "titulo: " + this.titulo + " ";
            resultado += "libreta: " + this.libreta.NombreLibreta + " ";

            return resultado;
        }
    }
}