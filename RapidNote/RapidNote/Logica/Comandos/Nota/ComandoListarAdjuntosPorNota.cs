using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RapidNote.Clases;
using RapidNote.DAO.DAOFactory;
using RapidNote.DAO.IDAOS;

namespace RapidNote.Logica.Comandos.Nota
{
    public class ComandoListarAdjuntosPorNota : Comando<List<Entidad>>
    {
        private Entidad nota;
        
        private List<Entidad> listaAdjuntos;

        public ComandoListarAdjuntosPorNota(Entidad _nota) 
        {
            nota = _nota;
        }

        public override List<Entidad> Ejecutar()
        {
            IDAONota accion = FabricaDAO.CrearFabricaDeDAO(1).CrearDAONota();

            listaAdjuntos = accion.ListarAjuntos(nota);

            return listaAdjuntos;
        }
    }
}