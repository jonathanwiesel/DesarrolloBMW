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
        TextBox Nombre { get; set; }
        TextBox Apellido { get; set; }
        TextBox Correo { get; set; }
        TextBox clave { get; set; }
        FileUpload avatar { get; set; }

    }
}
