using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RapidNote.Clases;

namespace RapidNote.DAO.IDAOS
{
    public interface IDAOEtiqueta
    {
        List<Entidad> ListarEtiquetas(Entidad usuario);
        
    }
}
