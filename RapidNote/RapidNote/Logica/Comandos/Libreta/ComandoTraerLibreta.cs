using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;

namespace RapidNote.Logica.Comandos.Libreta
{
    public class ComandoTraerLibreta : Comando<Entidad>
    {
        private Entidad Libreta;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ComandoTraerLibreta(Entidad libreta)
        {
            this.Libreta = libreta;
        }

        public override Entidad Ejecutar()
        {
            IDAOLibreta accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOLibreta();

            if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " libreta: " + (Libreta as Clases.Libreta).ToString());

            Libreta = accion.TraerLibreta(Libreta);
            return Libreta;
        }
    }
}