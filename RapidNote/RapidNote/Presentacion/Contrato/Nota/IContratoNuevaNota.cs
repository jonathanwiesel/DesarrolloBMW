using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

        string archivo();

        void setListaLibretas(List<Entidad> listaLibretas);
    }
}
