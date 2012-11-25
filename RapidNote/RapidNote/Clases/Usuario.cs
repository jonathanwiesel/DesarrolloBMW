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

        private String accesToken;

        private String accesSecret;

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


        public String AccesToken
        {
            get { return accesToken; }
            set { accesToken = value; }
        }

        public String AccesSecret
        {
            get { return accesSecret; }
            set { accesSecret = value; }
        }

        public override String ToString() 
        {
            String resultado = "";

            resultado += "Id: " + this.id + " ";
            resultado += "correo: " + this.correo + " ";
            resultado += "clave: " + this.clave + " ";
            resultado += "nombre: " + this.nombre + " ";
            resultado += "apellido: " + this.apellido + " ";
            resultado += "urlImagen: " + this.urlImagen + " ";
            resultado += "accesToken: " + this.accesToken + " ";
            resultado += "accesSecret: " + this.accesSecret + " ";

            return resultado;
        }
    }
}