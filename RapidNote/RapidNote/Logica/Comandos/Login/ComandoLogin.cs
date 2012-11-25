using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;
[assembly: log4net.Config.XmlConfigurator(Watch=true)]

namespace RapidNote.Logica.Comandos.Login
{
    public class ComandoLogin : Comando<Entidad>
    {
        private Entidad usuario;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ComandoLogin(Entidad _usuario) 
        {
            usuario = _usuario;
        }
        
        public override Entidad Ejecutar()
        {
            IDAOUsuario accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOUsuario();

            usuario = accion.ConsultarLogin(usuario);

            if (log.IsInfoEnabled) log.Info((usuario as Clases.Usuario).ToString());

            return usuario;
        }
    }
}