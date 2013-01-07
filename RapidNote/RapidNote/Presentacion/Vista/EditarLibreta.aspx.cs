using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Presentacion.Presentador.Libreta;
using RapidNote.Presentacion.Contrato.Libreta;
using RapidNote.Clases;

namespace RapidNote.Presentacion.Vista
{
    public partial class EditarLibreta : System.Web.UI.Page, IContratoEditarLibreta
    {
        private PresentadorEditarLibreta presentador;
        private string idLibreta;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            presentador = new PresentadorEditarLibreta(this);

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            presentador = new PresentadorEditarLibreta(this);
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sesion["usuario"] == null)
                Response.Redirect("login.aspx");
            else
            {
                if (!IsPostBack)
                {
                    presentador.IniciarVista();
                }
            }
        }

        public string getNombre()
        {
            return nombre.Text;
        }

        public void setNombre(string valor)
        {
            nombre.Text = valor;
        }

        public string getIdLibreta()
        {
            idLibreta = Request.QueryString["id"].ToString();
            return idLibreta;
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

        public void Redireccionar(string _ruta)
        {
            Response.Redirect(_ruta);
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Vista/AccesarLibreta.aspx");
        }

        protected void registrar_Click(object sender, EventArgs e)
        {
            presentador.Ejecutar();
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            presentador.Eliminar();
        }

        protected void ClickBuscarNota(object sender, EventArgs e)
        {
            (Sesion["usuario"] as Usuario).Estado = TextBoxBuscadorSiteM.Text;
            Response.Redirect("BuscarNota.aspx");
        }
    }
}