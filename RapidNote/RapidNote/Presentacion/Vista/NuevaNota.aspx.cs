﻿using System;
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
using System.Reflection;

namespace RapidNote.Presentacion.Vista
{
    public partial class NuevaNota : System.Web.UI.Page, IContratoNuevaNota
    {
        private PresentadorNuevaNota presentador;
        private string rutaArchivo="";
        private string nombreArchivo = "";
        private bool estado = true;
        private HttpFileCollection hffc;

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
     
            ScriptManager scripManager = ScriptManager.GetCurrent(this.Page);
            scripManager.RegisterPostBackControl(Button1);

            ScriptManager scripManager2 = ScriptManager.GetCurrent(this.Page);
            scripManager2.RegisterPostBackControl(Button2);

            ScriptManager scripManager4 = ScriptManager.GetCurrent(this.Page);
            scripManager4.RegisterPostBackControl(Button4);

        }

        protected void ClickBuscarNota(object sender, EventArgs e)
        {
            (Sesion["usuario"] as Usuario).Estado = TextBoxBuscadorSiteM.Text;
            Response.Redirect("BuscarNota.aspx");
            //presentador.IniciarVista();
        }

        public Label MensajeError
        {
            get { return LabelResultado; }
            set { LabelResultado = value; }
        }

        public void Redireccionar(string _ruta)
        {
            Response.Redirect(_ruta);
        } 

        public System.Web.SessionState.HttpSessionState Sesion
        {
            get { return Session; }
        }


        public string getContenido()
        {
            return TextBoxContenido.Text;
        }

        public string archivo() 
        {
            return FileUploadArchivo.FileName;
        }

        public string getTitulo()
        {
            return TextBoxTitulo.Text;
        }                

        public string getNombreLibreta()
        {
            return DropDownListLibretas.SelectedValue;
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

        public void setListaLibretas(List<Entidad> listaLibretas)
        {
            DropDownListLibretas.Items.Clear();
            for (int i = 0; i < listaLibretas.Count; i++) 
            {
                DropDownListLibretas.Items.Add((listaLibretas[i] as Libreta).NombreLibreta);
            }
        }

        public List<Entidad> getEtiquetas()
        {
            List<Entidad> listaE = new List<Entidad>();
            foreach (ListItem item in ListBoxEtiquetas.Items)
            {
                Etiqueta e = new Etiqueta();
                e.Nombre = item.Text;
                listaE.Add(e);
            }
            return listaE;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool resultado = presentador.VerificarNota();
            if (resultado == true)
            {
                String url = AppDomain.CurrentDomain.BaseDirectory+"Archivo\\";
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
            {
                LabelResultado.Text = "Error, ya posee una nota igual en esta libreta";
            }
        }

        //agregar etiqueta a lista
        protected void Button4_Click(object sender, EventArgs e)
        {
            ListBoxEtiquetas.Items.Add(TextBoxEtiqueta.Text);
            TextBoxEtiqueta.Text = "";

        }


        //eliminar etiqueta de lista
        protected void Button2_Click(object sender, EventArgs e)
        {
            ListBoxEtiquetas.Items.RemoveAt(ListBoxEtiquetas.SelectedIndex);
        }

    }
}