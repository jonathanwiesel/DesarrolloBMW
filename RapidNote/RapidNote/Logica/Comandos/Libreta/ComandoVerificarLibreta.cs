using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;

namespace RapidNote.Logica.Comandos.Libreta
{
    public class ComandoVerificarLibreta : Comando<Entidad>
    {
        private Entidad usuario;
        private Entidad libreta;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ComandoVerificarLibreta(Entidad libreta, Entidad usuario)
        {
            this.usuario = usuario;
            this.libreta = libreta;
        }

        public override Entidad Ejecutar()
        {
            IDAOLibreta accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOLibreta();

            if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " usuario: " + (usuario as Clases.Usuario).ToString());
            if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " libreta: " + (libreta as Clases.Libreta).ToString());

            libreta = accion.VerificarLibreta(libreta, usuario);
            return libreta;
        }
    }
}