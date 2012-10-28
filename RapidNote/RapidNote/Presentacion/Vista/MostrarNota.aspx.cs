using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Presentacion.Contrato.Nota;
using RapidNote.Presentacion.Presentador.Nota;
using System.Web.SessionState;
using RapidNote.Clases;

namespace RapidNote.Presentacion.Vista
{
    public partial class MostrarNota : System.Web.UI.Page, IContratoMostrarNota
    {
        private PresentadorMostrarNota presentador;
        
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            presentador = new PresentadorMostrarNota(this);

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            presentador = new PresentadorMostrarNota(this);
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

        public void setListaNotas(List<Entidad> listaNotas)
        {
            DropDownList1.Items.Clear();
            for (int i = 0; i < listaNotas.Count; i++)
            {
                DropDownList1.Items.Add((listaNotas[i] as Nota).Titulo);
            }
        }

        public HttpSessionState Sesion
        {
            get { return Session; }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            presentador.Ejecutar();
        }

        public void setContenido(string contenido)
        {
            TextBoxContenido.Text = contenido;
        }

        public void setNombreLibreta(string nombreLibreta)
        {
            TextBoxLibreta.Text = nombreLibreta;
        }

        public void setFechaCreacion(string fechaCreacion)
        {
            TextBoxFechaC.Text = fechaCreacion;
        }

        public void setFechaModificacion(string fechaModificacion)
        {
            TextBoxFechaM.Text = fechaModificacion;
        }

        public void setListaEtiquetas(List<Entidad> listaEtiquetas)
        {
            ListBoxEtiquetas.Items.Clear();
            for (int i = 0; i < listaEtiquetas.Count; i++) 
            {
                ListBoxEtiquetas.Items.Add((listaEtiquetas[i] as Etiqueta).Nombre);
            }
        }


        public string getTituloNota()
        {
            return DropDownList1.SelectedItem.Text;
        }


        public void setArchivoAdjunto(List<Entidad> listaArchivos)
        {
            ListBoxArchivos.Items.Clear();
            for (int i = 0; i < listaArchivos.Count; i++)
            {
                ListBoxArchivos.Items.Add((listaArchivos[i] as Adjunto).Titulo);
            }
        }
    }
}