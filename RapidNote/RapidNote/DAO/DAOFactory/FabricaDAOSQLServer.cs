using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOSQL;

namespace RapidNote.DAO.DAOFactory
{
    public class FabricaDAOSQLServer : FabricaDAO
    {
        private static FabricaDAO fabricaDAOSQLServer;

        private FabricaDAOSQLServer()
        { }

        public static FabricaDAO getInstacia()
        {
            if (fabricaDAOSQLServer == null)
            {
                fabricaDAOSQLServer = new FabricaDAOSQLServer();
            }
            return fabricaDAOSQLServer;
        }

        public override IDAOUsuario CrearDAOUsuario()
        {
            return new DAOUsuario();
        }

        public override IDAONota CrearDAONota()
        {
            return new DAONota();
        }

        public override IDAOLibreta CrearDAOLibreta()
        {
            return new DAOLibreta();
        }

        public override IDAOAdjunto CrearDAOAdjunto()
        {
            return new DAOAdjunto();
        }
    }
}