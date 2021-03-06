﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using RapidNote.Clases;

namespace RapidNote.Presentacion.Contrato.Nota
{
    public interface IContratoAccesarNota
    {
        List<Entidad> gridviewnota { set; }

        String contenidoBusqueda { get; }

        Label MensajeError { get; set; }
        
        HttpSessionState Sesion { get; }
    }
}
