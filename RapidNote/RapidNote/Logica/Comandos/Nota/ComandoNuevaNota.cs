using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;

namespace RapidNote.Logica.Comandos.Nota
{
    public class ComandoNuevaNota : Comando<Entidad>
    {
        private Entidad nota;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ComandoNuevaNota(Entidad _nota)
        {
            nota = _nota;
        }

        public override Entidad Ejecutar()
        {
            IDAONota accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();

            if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " nota: " + (nota as Clases.Nota).ToString());

            nota = accion.NuevaNota(nota);

            return nota;
        }
    }
}