using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using RapidNote.Clases;

namespace RapidNote.Presentacion.Contrato.Nota
{
    public interface IContratoAccesarNotaLibreta
    {
        List<Entidad> gridviewnota { set; }

        String contenidoBusqueda { get; }

        String getIdLibreta();

        Label MensajeError { get; set; }

        HttpSessionState Sesion { get; }
    }
}
