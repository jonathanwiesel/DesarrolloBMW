using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Presentacion.Contrato.Nota;
using RapidNote.Presentacion.Presentador.Nota;
using RapidNote.Clases;

namespace RapidNote.Presentacion.Vista
{
    public partial class BuscarNota : System.Web.UI.Page, IContratoBuscarNota
    {
        private PresentarBuscarNota presentador;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            presentador = new PresentarBuscarNota(this);

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            presentador = new PresentarBuscarNota(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sesion["usuario"] == null)
                Response.Redirect("login.aspx");
            else
            {
                if (!IsPostBack)
                {
                     if((Sesion["usuario"] as Usuario).Estado!=null)
                     {
                        TextBoxBuscadorSiteM.Text = (Sesion["usuario"] as Usuario).Estado;
                        presentador.IniciarVista();
                     }
                }
            }
        }

        public List<Clases.Entidad> gridviewnota
        {
            set 
            { 
                GridViewNotas.DataSource = value;
                GridViewNotas.DataBind();
            }
        }

        protected void ClickBuscarNota(object sender, EventArgs e) 
        {
            presentador.IniciarVista();
        }


        public string contenidoBusqueda
        {
            //get { return "%"+TextBoxBuscar.Text+"%"; }
            get { return "%" + TextBoxBuscadorSiteM.Text + "%"; }
        }


        public System.Web.SessionState.HttpSessionState Sesion
        {
            get { return Session; }
        }

        protected void GridViewRowEventHandler(object sender,  GridViewRowEventArgs e) 
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ceedfc'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
                e.Row.Attributes.Add("style", "cursor:pointer;");
                e.Row.Attributes.Add("onclick", "location='EditarNota.aspx?id=" + e.Row.Cells[0].Text + "'");
            } 
        }

        protected void Gridview1_DataBound(object sender, EventArgs e)
        {

        }
    }
}