using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Clases;
using RapidNote.Presentacion.Contrato.Etiqueta;
using RapidNote.Presentacion.Presentador.Etiqueta;
using System.Data;

namespace RapidNote.Presentacion.Vista
{
    public partial class AccesarEtiquetas : System.Web.UI.Page, IContratoAccesarEtiqueta
    {
        private PresentadorAccesarEtiqueta presentador;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            presentador = new PresentadorAccesarEtiqueta(this);

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            presentador = new PresentadorAccesarEtiqueta(this);
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

        public List<Entidad> gridviewlibreta
        {
            set
            {
                GridViewLibreta.DataSource = value;
                GridViewLibreta.DataBind();
            }
        }

        public string contenidoBusqueda
        {
            get { return "%" + TextBoxBuscadorSiteM.Text + "%"; }
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

        protected void ClickBuscarNota(object sender, EventArgs e)
        {
            (Sesion["usuario"] as Usuario).Estado = TextBoxBuscadorSiteM.Text;
            Response.Redirect("BuscarNota.aspx");
            //presentador.IniciarVista();
        }

        protected void GridViewRowEventHandler(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ceedfc'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
                e.Row.Attributes.Add("style", "cursor:pointer;");
                
            }
        }

        protected void GridViewNotas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            presentador.IniciarVista();
            GridViewLibreta.PageIndex = e.NewPageIndex;
            GridViewLibreta.DataBind();
        }

        protected void GridViewNotas_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = GridViewLibreta.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                GridViewLibreta.DataSource = dataView;
                GridViewLibreta.DataBind();
            }
        }

        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }
    }
}