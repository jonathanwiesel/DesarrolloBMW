using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;

namespace RapidNote.Logica.Comandos.Libreta
{
    public class ComandoEliminarLibreta : Comando<Boolean>
    {
        private Entidad libreta;
        private bool estado = false;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ComandoEliminarLibreta(Entidad libreta)
        {
            this.libreta = libreta;
        }

        public override bool Ejecutar()
        {
            IDAOLibreta accion = FabricaDAOSQLServer.CrearFabricaDeDAO(1).CrearDAOLibreta();

            if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " libreta: " + (libreta as Clases.Libreta).ToString());

            estado = accion.EditarLibreta(libreta);
            return estado;
        }
    }
}