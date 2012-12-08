using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;

namespace RapidNote.Logica.Comandos.usuario
{
    public class ComandoAgregarUsuario : Comando<Entidad>
    {
        private Entidad usuario;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ComandoAgregarUsuario(Entidad _usuario)
        {
            usuario = _usuario;
        }

        public override Entidad Ejecutar()
        {
            IDAOUsuario accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOUsuario();

            if (log.IsInfoEnabled) log.Info("Clase: " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " usuario: " + (usuario as Clases.Usuario).ToString());

            accion.AgregarUsuario(usuario);

            return entidad;
        }
    }
}