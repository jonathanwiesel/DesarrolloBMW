using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.DAO.IDAOS;

namespace RapidNote.DAO.DAOFactory
{
    public abstract class FabricaDAO
    {
        public FabricaDAO()
        { }

        public static FabricaDAO CrearFabricaDeDAO(int tipoFabrica)
        {
            switch (tipoFabrica)
            {
                case 1:
                    return FabricaDAOSQLServer.getInstacia();
                case 2:
                //return FabricaDAOOracle.getInstancia();
                default:
                    return null;
            }
        }

        public abstract IDAOUsuario CrearDAOUsuario();

        public abstract IDAONota CrearDAONota();

        public abstract IDAOLibreta CrearDAOLibreta();

        public abstract IDAOAdjunto CrearDAOAdjunto();
    }
}