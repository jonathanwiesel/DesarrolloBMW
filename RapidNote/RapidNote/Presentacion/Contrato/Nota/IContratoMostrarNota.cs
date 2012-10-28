using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using RapidNote.Clases;

namespace RapidNote.Presentacion.Contrato.Nota
{
    public interface IContratoMostrarNota
    {
        void setListaNotas(List<Entidad> listaNotas);

        HttpSessionState Sesion { get; }

        String getTituloNota();

        void setContenido(String contenido);

        void setArchivoAdjunto(List<Entidad> listaArchivos);

        void setNombreLibreta(String nombreLibreta);

        void setFechaCreacion(String fechaCreacion);

        void setFechaModificacion(String fechaModificacion);

        void setListaEtiquetas(List<Entidad> listaEtiquetas);
    }
}
