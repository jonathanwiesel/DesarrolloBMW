using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RapidNote.Clases;

namespace RapidNote.DAO.IDAOS
{
    public interface IDAONota : IDAO
    {
        List<Entidad> ListarNotas(Entidad usuario);

        Entidad MostrarNota(Entidad nota);

        List<Entidad> ListarAjuntos(Entidad nota, Entidad usuario);

        List<Entidad> ListarEtiquetas(Entidad nota);

        Entidad NuevaNota(Entidad nota);

        List<Entidad> ListarLibretas(Entidad nota);

        List<Entidad> BuscarNotasEtiqueta(Entidad usuario);

        List<Entidad> BuscarNotas(Entidad usuario);

        Entidad EditarNota(Entidad nota);

        Entidad BorrarNota(Entidad nota);

        int BuscarIdNota(Entidad nota);

        Entidad BuscarNota(Entidad nota);

        List<Entidad> ListarNotasLibreta(Entidad libreta);

        Entidad VerificarNota(Entidad nota, Entidad usuario);
    }
}
