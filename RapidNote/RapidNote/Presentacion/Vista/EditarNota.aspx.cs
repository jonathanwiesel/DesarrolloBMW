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

        public List<Entidad> getEtiquetas(){
            List<Entidad> listaE = new List<Entidad>();
            foreach (ListItem item in ListBoxEtiquetas.Items) {
                Etiqueta e = new Etiqueta();
                e.Nombre = item.Text;
                listaE.Add(e);
            }
            return listaE;
        }

        public void setListaEtiquetas(List<Entidad> listaEtiquetas)
        {
            ListBoxEtiquetas.Items.Clear();
            for (int i = 0; i < listaEtiquetas.Count; i++)
            {
                ListBoxEtiquetas.Items.Add((listaEtiquetas[i] as Etiqueta).Nombre);
            }
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

        //eliminar etiqueta de lista
        protected void Button3_Click(object sender, EventArgs e)
        {
            ListBoxEtiquetas.Items.RemoveAt(ListBoxEtiquetas.SelectedIndex);
        }

        //agregar etiqueta a lista
        protected void Button4_Click(object sender, EventArgs e)
        {
            ListBoxEtiquetas.Items.Add(TextBoxEtiqueta.Text);
            TextBoxEtiqueta.Text = "";
        }


        public void setNombreLibreta(String nombreLibreta)
        {
            DropDownListLibretas.Items.Clear();
            DropDownListLibretas.Items.Add(nombreLibreta);
        }
    }
}