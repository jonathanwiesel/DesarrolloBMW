using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using RapidNote.Clases;

namespace RapidNote.Presentacion.Contrato.Etiqueta
{
    public interface IContratoAccesarEtiqueta
    {
        List<Entidad> gridviewlibreta { set; }

        String contenidoBusqueda { get; }

        Label MensajeError { get; set; }

        HttpSessionState Sesion { get; }
    }
}
