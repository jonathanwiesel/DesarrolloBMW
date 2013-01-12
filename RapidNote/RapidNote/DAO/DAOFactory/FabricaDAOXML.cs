using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.DAO.DAOFILE;

namespace RapidNote.DAO.DAOFactory
{
    public class FabricaDAOXML : FabricaDAO
    {
        private static FabricaDAO fabricaDAOXML;
        
        private FabricaDAOXML()
        { }

        public static FabricaDAO getInstancia()
        {
            if (fabricaDAOXML == null)
            {
                fabricaDAOXML = new FabricaDAOXML();
            }
            return fabricaDAOXML;
        }

        public override IDAOS.IDAOUsuario CrearDAOUsuario()
        {
            return new DAOUsuario();
        }

        public override IDAOS.IDAONota CrearDAONota()
        {
            throw new NotImplementedException();
        }

        public override IDAOS.IDAOLibreta CrearDAOLibreta()
        {
            throw new NotImplementedException();
        }

        public override IDAOS.IDAOAdjunto CrearDAOAdjunto()
        {
            throw new NotImplementedException();
        }

        public override IDAOS.IDAOEtiqueta CrearDAOEtiqueta()
        {
            throw new NotImplementedException();
        }
    }
}