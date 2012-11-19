using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Presentacion.Contrato.Libreta;
using RapidNote.Presentacion.Presentador.Libreta;



namespace RapidNote.Presentacion.Vista
{
    public partial class CrearLibreta : System.Web.UI.Page, IContratoAgregarLibreta
    {
        private PresentadorAgregarLibreta presentador;
        protected void Page_Load(object sender, EventArgs e)
        {
            presentador = new PresentadorAgregarLibreta(this);
        }

        public string getNombre()
        {
            return nombre.Text;
        }

        public System.Web.SessionState.HttpSessionState Sesion
        {
            get { return Session; }
        }

        protected void registrar_Click(object sender, EventArgs e)
        {
            Boolean estado = presentador.Ejecutar();
            if (estado == true)
            {
                Response.Redirect("../../index.aspx");     
            }
           
        }
    }
}