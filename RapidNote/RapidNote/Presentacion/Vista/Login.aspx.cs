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
            }
            else if (resultado > 0)
            {

                excepcion.Text = "Bienvenido";
                Console.WriteLine("Bienvenido");
            }
            else if (resultado == null)
            {
                excepcion.Text = "nulo";
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
    }
}