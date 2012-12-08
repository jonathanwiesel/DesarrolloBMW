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
        private static String url = AppDomain.CurrentDomain.BaseDirectory+"Archivo\\";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                        ruta = url + hpf.FileName;

                        if (!File.Exists(ruta))
                        {
                            hpf.SaveAs(ruta);
                        }
                        if (log.IsInfoEnabled) log.Info(ruta.ToString());
                    }

                }

                estado = true;
                return estado;
            }
            catch( Exception E)
            {
                if (log.IsErrorEnabled) log.Error(E.Message, E);
                return estado;
            }
        }
    }
}