using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Presentacion.Contrato.Login;
using RapidNote.Presentacion.Presentador.Login;

namespace RapidNote.Presentacion.Vista
{
    public partial class Login : System.Web.UI.Page, IContratoLogin
    {
        private PresentadorLogin presentador;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            presentador = new PresentadorLogin(this);

        }

        protected void Page_Load(object sender, EventArgs e)
        {     
            presentador = new PresentadorLogin(this);
        }

        protected void iniciarsesion_Click(object sender, EventArgs e)
        {
            int resultado = presentador.Ejecutar();
            if (resultado == 0)
            {
                Console.WriteLine("No esta en sistema");
                excepcion.Text = "No esta en sistema";
                Response.Redirect("../Vista/Login.aspx");
            }
            else if (resultado > 0)
            {

                excepcion.Text = "Bienvenido";
                Console.WriteLine("Bienvenido");
                //Response.Redirect("../../index.aspx");
                Response.Redirect("../Vista/index.aspx");
            }
        }

        public string getCorreo()
        {
            return correo.Text;
        }


        public string getClave()
        {
            return clave.Text;
        }


        public System.Web.SessionState.HttpSessionState Sesion
        {
            get { return Session; }
        }
    }
}