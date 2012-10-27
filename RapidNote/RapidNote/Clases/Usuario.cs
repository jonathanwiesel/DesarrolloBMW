using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RapidNote.Clases
{
    public class Usuario : Entidad
    {
        private int id;

        private String correo;

        private String clave;

        private String nombre;

        private String apellido;

        private String urlImagen;

        private String idDropBox;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public String Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        
        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public String UrlImagen
        {
            get { return urlImagen; }
            set { urlImagen = value; }
        }

        public String IdDropBox
        {
            get { return idDropBox; }
            set { idDropBox = value; }
        }

    }
}