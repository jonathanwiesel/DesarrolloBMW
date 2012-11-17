using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using RapidNote.Clases;

namespace RapidNote.Presentacion.Contrato.Nota
{
    public interface IContratoAccesarNota
    {
        List<Entidad> gridviewnota { set; }

        String contenidoBusqueda { get; }
        
        HttpSessionState Sesion { get; }
    }
}
