using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RapidNote.Clases;
using System.Web.SessionState;

namespace RapidNote.Presentacion.Contrato.Nota
{
    public interface IContratoBuscarNota
    {
        List<Entidad> gridviewnota { set; }

        String contenidoBusqueda { get; }

        HttpSessionState Sesion { get; }
    }
}
