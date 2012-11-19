using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Presentacion.Contrato.Usuario;
using RapidNote.Presentacion.Presentador.Usuario;

namespace RapidNote.Presentacion.Vista
{
    public partial class TokenizeUser : System.Web.UI.Page, IcontratoTokenizeUser
    {
        private PresentadorTokenizerUser presentador;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            presentador = new PresentadorTokenizerUser(this);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            presentador = new PresentadorTokenizerUser(this);
            bool estado = presentador.IniciarVista();
            if (estado == true)
            {
                Response.Redirect("Login.aspx");
            }
            else 
            {
                Response.Redirect("Login.aspx");
            }
        }


        public System.Web.SessionState.HttpSessionState Correo
        {
            get { return Session; }
        }
    }
}