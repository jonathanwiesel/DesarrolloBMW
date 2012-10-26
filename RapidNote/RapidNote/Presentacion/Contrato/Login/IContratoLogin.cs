using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RapidNote.Presentacion.Contrato.Login
{
    public interface IContratoLogin
    {
        String getCorreo();

        String getClave();
    }
}
