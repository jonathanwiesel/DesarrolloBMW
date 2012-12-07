using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring.IO;
using Spring.Social.OAuth1;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using Spring.Social.Dropbox.Api.Impl;
using RapidNote.Clases;

namespace RapidNote.Logica.Comandos.Dropbox
{
    public class ComandoAdjuntarDropbox : Comando<Boolean>
    {
        private string[] archivo;
        private string[] nombre;
        private Entidad usuario;
        private bool estado = false;
        private string consumerKey = "dbhvzaf6ugr4k6q";
        private string consumerSecret = "q35bdvwgrut9bq4";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ComandoAdjuntarDropbox(string[] archivo, string[] nombre, Entidad usuario)
        {
            this.archivo = archivo;
            this.nombre = nombre;
            this.usuario = usuario;
        }

        public override bool Ejecutar()
        {
            try
            {
                if (((usuario as Clases.Usuario).AccesToken != "") && ((usuario as Clases.Usuario).AccesSecret!=""))
                {
                    IDropbox dropbox = new DropboxTemplate(consumerKey, consumerSecret, (usuario as Clases.Usuario).AccesToken, (usuario as Clases.Usuario).AccesSecret, AccessLevel.AppFolder);
                    for (int i = 0; i < archivo.Count(); i++)
                    {
                        if (archivo[i] != "")
                        {
                            dropbox.UploadFileAsync(new FileResource(archivo[i]), "/RapidNote/" + nombre[i]);
                            estado = true;
                        }
                    }
                    if (log.IsInfoEnabled) log.Info((usuario as Clases.Usuario).ToString());
                    return estado;
                }
                else
                {
                    return estado;
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex =>
                {
                    if (ex is DropboxApiException)
                    {
                        Console.WriteLine(ex.Message);
                        if (log.IsErrorEnabled) log.Error(ex.Message, ex);
                        return false;
                    }
                    return false;
                });
                return estado;
            }
        }
    }
}