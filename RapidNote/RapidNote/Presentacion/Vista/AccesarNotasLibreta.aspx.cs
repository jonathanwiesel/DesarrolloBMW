using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Clases;
using RapidNote.Presentacion.Contrato.Nota;
using RapidNote.Presentacion.Presentador.Nota;

namespace RapidNote.Presentacion.Vista
{
    public partial class AccesarNotasLibreta : System.Web.UI.Page, IContratoAccesarNotaLibreta
    {
        private PresentadorAccesarNotasLibreta presentador;
        private string idLibreta;

       protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            presentador = new PresentadorAccesarNotasLibreta(this);

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            presentador = new PresentadorAccesarNotasLibreta(this);
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

        public List<Entidad> gridviewnota
        {
            set
            {
                GridViewNotas.DataSource = value;
                GridViewNotas.DataBind();
            }
        }

        public Label MensajeError
        {
            get { return mensajeError; }
            set { mensajeError = value; }
        }

        public string contenidoBusqueda
        {
            get { return "%" + TextBoxBuscadorSiteM.Text + "%"; }
        }

        public string getIdLibreta()
        {
            idLibreta = Request.QueryString["id"].ToString();
            return idLibreta;
        }

        public System.Web.SessionState.HttpSessionState Sesion
        {
            get { return Session; }
        }

        protected void ClickBuscarNota(object sender, EventArgs e)
        {
            (Sesion["usuario"] as Usuario).Estado = TextBoxBuscadorSiteM.Text;
            Response.Redirect("BuscarNota.aspx");
        }

        protected void GridViewRowEventHandler(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ceedfc'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
                e.Row.Attributes.Add("style", "cursor:pointer;");
                e.Row.Attributes.Add("onclick", "location='EditarNota.aspx?id=" + e.Row.Cells[0].Text + "'");
            }
        }
    }
}