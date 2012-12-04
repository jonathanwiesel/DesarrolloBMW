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

        public ComandoTraerLibreta(Entidad libreta)
        {
            this.Libreta = libreta;
        }

        public override Entidad Ejecutar()
        {
            IDAOLibreta accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAOLibreta();
            Libreta = accion.TraerLibreta(Libreta);
            return Libreta;
        }
    }
}