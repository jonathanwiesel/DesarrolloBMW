using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;

namespace RapidNote.Presentacion.Contrato.Login
{
    public interface IContratoLogin
    {
        String getCorreo();

        String getClave();

        HttpSessionState Sesion { get; }
    }
}
