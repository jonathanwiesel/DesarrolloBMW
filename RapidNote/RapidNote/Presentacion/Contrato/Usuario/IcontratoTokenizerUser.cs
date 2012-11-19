using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;

namespace RapidNote.Presentacion.Contrato.Usuario
{
    public interface IcontratoTokenizeUser
    {
        HttpSessionState Correo { get; }
    }
}
