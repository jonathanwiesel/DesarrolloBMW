using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;

namespace RapidNote.Logica.Comandos.Nota
{
    public class ComandoBuscarNota : Comando<Entidad>
    {
        private Entidad nota;

        public ComandoBuscarNota(Entidad _nota)
        {
            nota = _nota;
        }

        public override Entidad Ejecutar()
        {
            IDAONota accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();

            return accion.BuscarNota(nota);
        }
    }
}