using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.IDAOS;
using RapidNote.DAO.DAOFactory;

namespace RapidNote.Logica.Comandos.Nota
{
    public class ComandoBuscarIdNota : Comando<int>
    {
        private Entidad nota;

        public ComandoBuscarIdNota(Entidad _nota)
        {
            nota = _nota;
        }

        public override int Ejecutar()
        {
            IDAONota accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();

            return accion.BuscarIdNota(nota);
        }
    }
}