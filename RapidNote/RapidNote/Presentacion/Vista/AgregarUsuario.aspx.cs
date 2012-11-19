using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RapidNote.Presentacion.Contrato;
using RapidNote.Presentacion.Presentador;

namespace RapidNote.Presentacion.Vista
{
    public partial class Registrausuario : System.Web.UI.Page, IcontratoAgregarUsuario
    {
        private PresentadorAgregarUsuario presentador;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            presentador = new PresentadorAgregarUsuario(this);
        }

        public String getNombre()
        {
            return nombre.Text;
        }


        public String getApellido()
        {
            return apellido.Text;
        }

        public String getCorreo()
        {
            return correo.Text;
        }

        public String getclave()
        {
            return password.Text;
        }

        public String getconfirmar()
        {
            return confpassword.Text;
        }

        public String puerto
        {
            get { return Request.Url.GetLeftPart(UriPartial.Authority); }
        }

        public Label MensajeError
        {
            get { return mensajeError; }
            set { mensajeError = value; }
        }


        public System.Web.SessionState.HttpSessionState Correo
        {
            get { return Session; }
        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
            String ruta =  presentador.Ejecutar();
            Response.Redirect(ruta);
            
        }
    }
}