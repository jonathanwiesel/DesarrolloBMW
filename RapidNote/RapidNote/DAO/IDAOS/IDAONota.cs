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

        List<Entidad> ListarAjuntos(Entidad nota);

        List<Entidad> ListarEtiquetas(Entidad nota);

        Entidad NuevaNota(Entidad nota);

        List<Entidad> ListarLibretas(Entidad nota);
    }
}
