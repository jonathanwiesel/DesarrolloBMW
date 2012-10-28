using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace RapidNote.Presentacion.Contrato
{
    public interface IcontratoAgregarUsuario
    {
        String getNombre();
        String getApellido();
        String getCorreo();
        String getclave();
        String getconfirmar();
        Label MensajeError { get; set; }

    }
}
