using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RapidNote.Clases;

namespace RapidNote.DAO.IDAOS
{
    public interface IDAOAdjunto
    {
        bool AdjuntarBD(Entidad adjunto);
        Entidad VerificarAdjunto(Entidad adjunto);
        bool AgregarAdjunto_Nota(Entidad nota, Entidad adjunto);
        Entidad BorrarAdjunto(Entidad nota);
    }
}
