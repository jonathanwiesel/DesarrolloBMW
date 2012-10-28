using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;

namespace RapidNote.Logica.Comandos.Usuario
{
    public class ComandoListaUsuario : Comando<Entidad>
    {
        private Entidad usuario;

        public ComandoListaUsuario(Entidad _usuario)
        {
            usuario = _usuario ;
        }

        public override Entidad Ejecutar()
        {
            IDAOUsuario accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOUsuario();

            usuario = accion.ListarUsuario(usuario);

            return usuario;
        }
    }
}