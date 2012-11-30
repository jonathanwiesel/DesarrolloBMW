using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace RapidNote.Logica.Comandos.Dropbox
{
    public class ComandoSubirArchivoServidor : Comando<Boolean>
    {
        private string ruta;
        private bool estado = false;
        private HttpFileCollection hfc;
        private HttpPostedFile hpf;
        private string directorio = @"C:\Users\victor\Documents\GitHub\DesarrolloBMW\RapidNote\RapidNote\Archivo\";

        public ComandoSubirArchivoServidor(HttpFileCollection hfc)
        {
            this.hfc = hfc;
        }

        public override bool Ejecutar()
        {
            try
            {
                for (int i = 0; i < hfc.Count; i++)
                {
                    HttpPostedFile hpf = hfc[i];
                    if (hpf.ContentLength > 0)
                    {
                        ruta = directorio + hpf.FileName;

                        if (!File.Exists(ruta))
                        {
                            hpf.SaveAs(ruta);
                        }
                    }

                }

                estado = true;
                return estado;
            }
            catch
            {
                return estado;
            }
        }
    }
}