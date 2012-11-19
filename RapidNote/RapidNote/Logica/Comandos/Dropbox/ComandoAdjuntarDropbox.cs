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
    public class ComandoAdjuntarDropbox: Comando<Boolean>
    {
        private String archivo;
        private String nombre;
        private Entidad usuario;
        private bool estado = false;
        private string consumerKey = "dbhvzaf6ugr4k6q"; 
        private string consumerSecret = "q35bdvwgrut9bq4";

        public ComandoAdjuntarDropbox(String archivo, String nombre, Entidad usuario)
        {
            this.archivo = archivo;
            this.nombre = nombre;
            this.usuario = usuario;
        }

        public override bool Ejecutar()
        {
            try
            {
                IDropbox dropbox = new DropboxTemplate(consumerKey, consumerSecret, (usuario as Clases.Usuario).AccesToken, (usuario as Clases.Usuario).AccesSecret ,AccessLevel.AppFolder);
                dropbox.UploadFileAsync(new FileResource(archivo), "/RapidNote/" + nombre);
                estado = true;
                return estado;
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex =>
                {
                    if (ex is DropboxApiException)
                    {
                        Console.WriteLine(ex.Message);
                        return true;
                    }
                    return false;
                });
                return estado;
            }
        }
    }
}