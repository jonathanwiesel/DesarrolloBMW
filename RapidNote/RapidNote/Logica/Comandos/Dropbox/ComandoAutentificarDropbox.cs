using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web.SessionState;
using System.Diagnostics;
using Spring.IO;
using Spring.Social.OAuth1;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using System.Text;
using RapidNote.Clases;
using RapidNote.Clases.Fabrica;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;
using System.Web.Services.Description;

namespace RapidNote.Logica.Comandos.Dropbox
{
    public class ComandoAutentificarDropbox : Comando<String>
    {
        private const string DropboxAppKey = "dbhvzaf6ugr4k6q";
        private const string DropboxAppSecret = "q35bdvwgrut9bq4";
        private string ruta = null;
        private bool estado;
        private String puerto;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public ComandoAutentificarDropbox(String puerto)
        {
            this.puerto = puerto;
        }



        public override String Ejecutar()
        {
            try
            {
                DropboxServiceProvider dropbocServiceProvider = new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.Full);
                OAuthToken oauthToken = dropbocServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
                Comandodrop.Token = oauthToken;
                OAuth1Parameters parameters = new OAuth1Parameters();
                parameters.CallbackUrl = puerto + "/Presentacion/Vista/TokenizeUser.aspx";
                string authenticateUrl = dropbocServiceProvider.OAuthOperations.BuildAuthorizeUrl(oauthToken.Value, parameters);
                ruta = authenticateUrl;
                if (log.IsInfoEnabled) log.Info(puerto.ToString());
                return ruta;
            }
            catch (AggregateException ae)
            {
                ae.Handle(ex =>
                {
                    if (ex is DropboxApiException)
                    {
                        Console.WriteLine(ex.Message);
                        if (log.IsErrorEnabled) log.Error(ex.Message, ex);
                        return estado = false;
                    }
                    return estado = false;
                });
                return ruta;
            }
        }

    }
}