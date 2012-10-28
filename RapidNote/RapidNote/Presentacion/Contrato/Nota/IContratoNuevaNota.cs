using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using RapidNote.Clases;

namespace RapidNote.Presentacion.Contrato.Nota
{
    public interface IContratoNuevaNota
    {
        HttpSessionState Sesion { get; }

        String getContenido();

        String getTitulo();

        String getNombreLibreta();

        void setListaLibretas(List<Entidad> listaLibretas);
    }
}
