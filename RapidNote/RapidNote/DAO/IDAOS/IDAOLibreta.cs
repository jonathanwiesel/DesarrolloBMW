using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RapidNote.Clases;

namespace RapidNote.DAO.IDAOS
{
    public interface IDAOLibreta
    {
        Boolean AgregarLibreta(Entidad libreta, Entidad usuario);
        Entidad VerificarLibreta(Entidad libreta, Entidad usuario);
    }
}
