using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace RapidNote.Presentacion.Contrato.Libreta
{
    public interface IContratoEditarLibreta
    {
        String getNombre();

        void setNombre(string valor);

        String getIdLibreta();

        Label MensajeError { get; set; }

        HttpSessionState Sesion { get; }

        void Redireccionar(string _ruta);
    }
}
