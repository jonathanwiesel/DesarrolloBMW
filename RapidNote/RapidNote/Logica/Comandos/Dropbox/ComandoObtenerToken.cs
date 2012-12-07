using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
using System.Web.SessionState;
using System.Web.Services.Description;
using System.Web;


namespace RapidNote.Logica.Comandos.Dropbox
{
    public class ComandoObtenerToken : Comando<Boolean>
    {
        private const string DropboxAppKey = "dbhvzaf6ugr4k6q";
        private const string DropboxAppSecret = "q35bdvwgrut9bq4";
        private Entidad usuario;
        private String correo;
        private Boolean estado = false;
        private OAuthToken oauthToken;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public ComandoObtenerToken(String correo)
        {
            this.correo = correo;
        }



        public override bool Ejecutar()
        {
            try
            {
                usuario = FabricaEntidad.CrearUsuario();
                DropboxServiceProvider dropbocServiceProvider = new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.Full);
                oauthToken = Comandodrop.Token;
                AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
                OAuthToken oauthAccessToken = dropbocServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
                (usuario as Clases.Usuario).AccesToken = oauthAccessToken.Value;
                (usuario as Clases.Usuario).AccesSecret = oauthAccessToken.Secret;
                IDAOUsuario accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOUsuario();
                accion.InsertarToken(correo, usuario);
                if (log.IsInfoEnabled) log.Info(correo.ToString());
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
                        if (log.IsErrorEnabled) log.Error(ex.Message, ex);
                        return estado = false;
                    }
                    return estado = false;
                });
                return estado;
            }
        }

    }
}