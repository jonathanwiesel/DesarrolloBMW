using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Presentacion.Contrato.Usuario;
using RapidNote.Clases;
using RapidNote.Presentacion.Presentador.Usuario;

namespace RapidNote.Presentacion.Vista
{
    public partial class ExportarConfiguracion : System.Web.UI.Page, IExportarConfiguracion
    {
        private PresentadorExportarConfiguracion presentador;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            presentador = new PresentadorExportarConfiguracion(this);

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            presentador = new PresentadorExportarConfiguracion(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Sesion["usuario"] == null)
                Response.Redirect("login.aspx");
            else
            {
                if (!IsPostBack)
                {
                    presentador.Ejecutar();
                }
            }
        }

        protected void ClickBuscarNota(object sender, EventArgs e)
        {
            (Sesion["usuario"] as Usuario).Estado = TextBoxBuscadorSiteM.Text;
            Response.Redirect("BuscarNota.aspx");
        }

        public Label MensajeError
        {
            get { return mensajeError; }
            set { mensajeError = value; }
        }

        public System.Web.SessionState.HttpSessionState Sesion
        {
            get { return Session; }
        }
    }
}