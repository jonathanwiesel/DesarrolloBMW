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

        public ComandoVerificarLibreta(Entidad libreta, Entidad usuario)
        {
            this.usuario = usuario;
            this.libreta = libreta;
        }

        public override Entidad Ejecutar()
        {
            IDAOLibreta accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOLibreta();
            libreta = accion.VerificarLibreta(libreta, usuario);
            return libreta;
        }
    }
}