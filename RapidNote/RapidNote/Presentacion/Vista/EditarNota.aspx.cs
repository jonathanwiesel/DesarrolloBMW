using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using RapidNote.Presentacion.Contrato.Nota;
using RapidNote.Clases;
using RapidNote.Presentacion.Presentador.Nota;
using AjaxControlToolkit;

namespace RapidNote.Presentacion.Vista
{
    public partial class EditarNota : System.Web.UI.Page, IContratoEditarNota
    {
        private PresentadorEditarNota presentador; 
        private string idNota;
        private string arch = null;
        private string rutaArchivo = "";
        private string nombreArchivo = "";
        private bool estado = true;
        private HttpFileCollection hffc;
        

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
            ScriptManager scripManager = ScriptManager.GetCurrent(this.Page);
            scripManager.RegisterPostBackControl(Button1);

            ScriptManager scripManager2 = ScriptManager.GetCurrent(this.Page);
            scripManager2.RegisterPostBackControl(Button2);

            ScriptManager scripManager4 = ScriptManager.GetCurrent(this.Page);
            scripManager4.RegisterPostBackControl(Button4);
        }

        public System.Web.SessionState.HttpSessionState Sesion
        {
            get { return Session; }
        }

        public void Redireccionar(string _ruta)
        {
            Response.Redirect(_ruta);
        } 

        public string getContenido()
        {
            return TextBoxContenido.Text;
        }

        public string[] getRutas()
        {
            return rutaArchivo.Split(';');
        }

        public string[] getNombrearchivo()
        {
            return nombreArchivo.Split(';');
        }

        public HttpFileCollection getHfc()
        {
            return hffc;
        }

        public void Redireccionar2(string _ruta)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "myScript", "alert('El archivo a sido eliminado con éxito');", true);
            Response.Redirect(_ruta);
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

        public String archivo()
        {
            if (ListBoxArchivos.SelectedIndex >= 0)
            {
                arch = ListBoxArchivos.SelectedItem.Value;
            }
            return arch;
        }

        public void setContenido(String contenido)
        {
            TextBoxContenido.Text = contenido;
        }

        public void setTitulo(String titulo)
        {
            TextBoxTitulo.Text = titulo;
        }

        public Label MensajeError
        {
            get { return LabelResultado; }
            set { LabelResultado = value; }
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
            bool resultado = presentador.VerificarNota();
            if (resultado == true)
            {
                String url = AppDomain.CurrentDomain.BaseDirectory + "Archivo\\";
                hffc = Request.Files;
                for (int i = 0; i < hffc.Count; i++)
                {
                    HttpPostedFile hpf = hffc[i];
                    if (hpf.ContentLength > 0)
                    {
                        nombreArchivo += hpf.FileName + ";";
                        rutaArchivo += url + hpf.FileName + ";";
                    }

                }
                if (rutaArchivo != "")
                {
                    estado = presentador.Adjuntar();
                }
                if (estado == true)
                {
                    presentador.Ejecutar();
                }
            }
            else
            {   LabelResultado.Text="Error, ya posee una nota igual en esta libreta";
                
            }
            
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


        public void setArchivoAdjunto(List<Entidad> listaArchivos)
        {
            ListBoxArchivos.Items.Clear();
            for (int i = 0; i < listaArchivos.Count; i++)
            {
                ListBoxArchivos.Items.Add((listaArchivos[i] as Adjunto).Titulo);
            }
        }

        protected void ClickBuscarNota(object sender, EventArgs e)
        {
            (Sesion["usuario"] as Usuario).Estado = TextBoxBuscadorSiteM.Text;
            Response.Redirect("BuscarNota.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            bool resultado = presentador.DescargarAdjunto();
            if (resultado == true)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "myScript", "alert('El archivo a sido descargado con éxito');", true);
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            bool resultado = presentador.EliminarAdjunto();
            if (resultado == true)
            {


            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            bool resultado = presentador.visualizarAdjunto();
            if (resultado == true)
            {

            }
        }
        
    }
}