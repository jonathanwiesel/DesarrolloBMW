using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spring.IO;
using Spring.Social.OAuth1;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;

namespace RapidNote.Logica.Comandos
{
    public abstract class Comandodrop
    {
        private static OAuthToken token;

        public static OAuthToken Token
        {
            get { return token; }
            set { token = value; }
        }


    }
}