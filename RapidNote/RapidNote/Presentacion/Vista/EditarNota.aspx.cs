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
    public partial class EditarNota : System.Web.UI.Page, IContratoEditarNota
    {
        private string idNota;

        PresentadorEditarNota presentador;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            presentador = new PresentadorEditarNota(this);

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            presentador = new PresentadorEditarNota(this);
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

        public String getIdNota() {
            idNota = Request.QueryString["id"].ToString();
            return idNota;
        }

        public void setContenido(String contenido)
        {
            TextBoxContenido.Text = contenido;
        }

        public void setTitulo(String titulo)
        {
            TextBoxTitulo.Text = titulo;
        }
        
        //actualizar
        protected void Button1_Click(object sender, EventArgs e)
        {
            presentador.Ejecutar();
            LabelResultado.Text="Actualizando";
            Response.Redirect("../Vista/index.aspx");
        }

        //eliminar
        protected void Button2_Click(object sender, EventArgs e)
        {
            presentador.EjecutarDel();
            LabelResultado.Text = "Eliminando";
            Response.Redirect("../Vista/index.aspx");
        }


        public void setNombreLibreta(String nombreLibreta)
        {
            DropDownListLibretas.Items.Clear();
            DropDownListLibretas.Items.Add(nombreLibreta);
        }
    }
}