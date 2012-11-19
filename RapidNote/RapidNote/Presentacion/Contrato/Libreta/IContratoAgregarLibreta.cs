using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;

namespace RapidNote.Presentacion.Contrato.Libreta
{
    public interface IContratoAgregarLibreta
    {
        String getNombre();

        HttpSessionState Sesion { get; }
    }
}
