using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Presentacion.Contrato.Nota;
using RapidNote.Clases;
using RapidNote.Presentacion.Presentador.Nota;

namespace RapidNote.Presentacion.Vista
{
    public partial class NuevaNota : System.Web.UI.Page, IContratoNuevaNota
    {
        PresentadorNuevaNota presentador;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            presentador = new PresentadorNuevaNota(this);

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            presentador = new PresentadorNuevaNota(this);
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

        public System.Web.SessionState.HttpSessionState Sesion
        {
            get { return Session; }
        }


        public string getContenido()
        {
            return TextBoxContenido.Text;
        }

        public string getTitulo()
        {
            return TextBoxTitulo.Text;
        }                

        public string getNombreLibreta()
        {
            return DropDownListLibretas.SelectedValue;
        }

        public void setListaLibretas(List<Entidad> listaLibretas)
        {
            DropDownListLibretas.Items.Clear();
            for (int i = 0; i < listaLibretas.Count; i++) 
            {
                DropDownListLibretas.Items.Add((listaLibretas[i] as Libreta).NombreLibreta);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            presentador.Ejecutar();
        }
    }
}