using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;

namespace RapidNote.Logica.Comandos.Libreta
{
    public class ComandoEditarLibreta : Comando<Boolean>
    {
        private Entidad libreta;
        private bool estado = false;

        public ComandoEditarLibreta(Entidad libreta)
        {
            this.libreta = libreta;
        }

        public override bool Ejecutar()
        {
            IDAOLibreta accion = FabricaDAOSQLServer.CrearFabricaDeDAO(1).CrearDAOLibreta();
            estado = accion.EditarLibreta(libreta);
            return estado;
        }
    }
}