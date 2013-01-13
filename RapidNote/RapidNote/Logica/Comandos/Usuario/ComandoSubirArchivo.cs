using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using System.Web.UI.WebControls;
using System.IO;

namespace RapidNote.Logica.Comandos.Usuario
{
    public class ComandoSubirArchivo : Comando<Entidad>
    {
        private FileUpload trepador;
        private Entidad entidad;
        
        public ComandoSubirArchivo(FileUpload _trepador)
        {
            trepador = _trepador;
        }

        public override Entidad Ejecutar()
        {
            string directorio = AppDomain.CurrentDomain.BaseDirectory + "\\xml\\";

            if (Directory.Exists(directorio))
            {
                string archivo = directorio + trepador.FileName;

                if (File.Exists(archivo))
                {
                    // ya existe un archivo con el mismo nombre en el directorio,
                    // así que hay hacer algo al respecto (p.ej. renombrar el que 
                    // está en el servidor o asignarle otro nombre al que se está 
                    // subiendo), de lo contrario el archivo en el servidor será 
                    // sobreescrito
                }
                else
                {
                    trepador.SaveAs(archivo);
                    //entidad.Estado = "Tu archivo ha sido enviado exitosamente.";

                    // 
                    // TODO: código para procesar el archivo va aquí...
                    //
                }
            }
            else
            {
                throw new DirectoryNotFoundException(
                   "El directorio en el servidor donde se suben los archivos no existe");
            }

            return entidad;
        }

        
    }
}