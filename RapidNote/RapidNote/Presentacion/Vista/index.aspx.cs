using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Presentacion.Contrato;
using System.Web.SessionState;
using RapidNote.Clases;

namespace Sistema_Totem.Vista
{
    public partial class WebForm1 : System.Web.UI.Page, IContratoIndex
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sesion["usuario"] == null)
                Response.Redirect("login.aspx");
            else
            {
                if (!IsPostBack)
                {
                    //presentador.IniciarVista();
                }
            }
        }

        protected void ClickBuscarNota(object sender, EventArgs e)
        {
            (Sesion["usuario"] as Usuario).Estado = TextBoxBuscadorSiteM.Text;
            Response.Redirect("BuscarNota.aspx");
        }

        public HttpSessionState Sesion
        {
            get { return Session; }
        }
    }
}