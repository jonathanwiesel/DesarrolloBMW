using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;

namespace RapidNote.Logica.Comandos.Nota
{
    public class ComandoListarNotasLibreta : Comando<List<Entidad>>
    {
        private Entidad libreta;
        private List<Entidad> nota;

        public ComandoListarNotasLibreta(Entidad libreta)
        {
            this.libreta = libreta;
        }

        public override List<Entidad> Ejecutar()
        {
            IDAONota accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();
            nota = accion.ListarNotasLibreta(libreta);
            return nota;
        }
    }
}