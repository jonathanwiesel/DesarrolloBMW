using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;

namespace RapidNote.Logica.Comandos.Libreta
{
    public class ComandoAgregarLibreta : Comando<Boolean>
    {
        private Entidad libreta;
        private Entidad usuario;
        private Boolean estado;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ComandoAgregarLibreta(Entidad libreta, Entidad usuario)
        {
            this.libreta = libreta;
            this.usuario = usuario;
        }

        public override bool Ejecutar()
        {
            IDAOLibreta accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOLibreta();

            if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " usuario: " + (usuario as Clases.Usuario).ToString());
            if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " libreta: " + (libreta as Clases.Libreta).ToString());

            estado = accion.AgregarLibreta(libreta, usuario);
            return estado;
        }
    }
}