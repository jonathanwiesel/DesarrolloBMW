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
    public class ComandoDercargarDropbox : Comando<bool>
    {
        private Entidad usuario;
        private string nombre;

        public ComandoDercargarDropbox(Entidad usuario, string nombre)
        {
            this.usuario = usuario;
            this.nombre = nombre;
        }

        public override bool Ejecutar()
        {
            string consumerKey = "dbhvzaf6ugr4k6q";
            string consumerSecret = "q35bdvwgrut9bq4";
            string accessToken = (usuario as Clases.Usuario).AccesToken;
            string accessTokenSecret = (usuario as Clases.Usuario).AccesSecret;
            bool estado = false;

            try
            {
                DropboxServiceProvider serviceProvider = new DropboxServiceProvider(consumerKey, consumerSecret, AccessLevel.AppFolder);
                IDropbox dropboxApi = serviceProvider.GetApi(accessToken, accessTokenSecret);
                var file = dropboxApi.DownloadFileAsync("/RapidNote/" + nombre).Result;
                System.IO.FileStream _FileStream = new System.IO.FileStream(@"C:\prueba\" + nombre, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                _FileStream.Write(file.Content, 0, file.Content.Length);
                _FileStream.Close();
                estado = true;
                return estado;
            }
            catch (Exception ex)
            {
                return estado;
            }
        }
    }
}