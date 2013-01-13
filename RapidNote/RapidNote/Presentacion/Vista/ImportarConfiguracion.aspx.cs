using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Presentacion.Contrato.Usuario;
using RapidNote.Presentacion.Presentador.Usuario;
using RapidNote.Clases;

namespace RapidNote.Presentacion.Vista
{
    public partial class ImportarConfiguracion : System.Web.UI.Page, IContratoImportarConfiguracion
    {
        private PresentadorImportarConfiguracion presentador;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            presentador = new PresentadorImportarConfiguracion(this);

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            presentador = new PresentadorImportarConfiguracion(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Sesion["usuario"] == null)
                Response.Redirect("login.aspx");
            else
            {
                if (!IsPostBack)
                {
                    
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


        public string nombreArchivo
        {
            get { return FileUploadArchivo.FileName; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUploadArchivo.HasFile)
            {
                presentador.Ejecutar();
            }
        }


        public FileUpload fileUpload
        {
            get { return FileUploadArchivo; }
        }
    }
}