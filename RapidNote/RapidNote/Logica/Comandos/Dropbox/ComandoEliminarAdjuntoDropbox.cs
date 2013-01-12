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
    public class ComandoEliminarAdjuntoDropbox : Comando<bool>
    {
        private Entidad usuario;
        private string nombre;

        public ComandoEliminarAdjuntoDropbox(Entidad usuario, string nombre)
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
                dropboxApi.DeleteAsync("/RapidNote/" + nombre);
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